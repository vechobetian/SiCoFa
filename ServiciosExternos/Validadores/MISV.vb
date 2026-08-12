Imports System.IO
Imports System.Net
Imports System.Runtime.Remoting.Metadata
Imports System.Text
Imports System.Xml
Imports SiCoFa.Entidades
Imports Vecho

Public Class MISV

    Implements IValidador

    Private Function ConsultaRecetaElectronica(argIdPC As String, argReceta As Receta, argIdMensaje As Long) As Receta Implements IValidador.ConsultaRecetaElectronica
        Throw New NotSupportedException(argReceta.Plan.OS.PValidacion.Descripcion & " no acepta consulta de recetas por beneficiario.")
    End Function

    Public Function ConsultaRecetasBeneficiario(argIdPC As String, argCredencial As CredencialOS, argPValidacion As ParametrosValidacion, argIdMensaje As Long) As List(Of Receta) Implements IValidador.ConsultaRecetasBeneficiario
        Throw New NotImplementedException()
    End Function

    Public Sub SolicitarAutorizacion(argIdPC As String, argReceta As Receta, argIdMensaje As Long) Implements IValidador.SolicitarAutorizacion

        Dim xmlAutorizacion As String = MensajeAutorizacion(argReceta, argIdMensaje, "200")
        Dim pVal As ParametrosValidacion = argReceta.Plan.OS.PValidacion

        Dim soap As String =
            $"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/""
                               xmlns:tns=""tns""
                               xmlns:apps=""apps.wsmv"">
                <soapenv:Header/>
                <soapenv:Body>
                    <tns:validar_receta>
                        <tns:datos_receta>
                        <apps:usuario>{pVal.NumPrestador}</apps:usuario>
                        <apps:clave>{pVal.Licencia}</apps:clave>
                        <apps:clave_id>cc12077bm687NB987si7</apps:clave_id>
                        <apps:cuf/>
                        <apps:convenio>{argReceta.Plan.PlanValidacion}</apps:convenio>
                            {xmlAutorizacion}
                        </tns:datos_receta>                 
                    </tns:validar_receta>
                </soapenv:Body>
            </soapenv:Envelope>"

        IO.File.WriteAllText("C:\SiCoFaFarmacias\SiCoFa.Presentacion\bin\Debug\Temp\soap_request.xml", soap)

    End Sub

    Public Sub CancelarAutorizacion(argIdPC As String, argReceta As Receta, argIdMensaje As Long) Implements IValidador.CancelarAutorizacion
        Throw New NotImplementedException()
    End Sub

    Private Function MensajeAutorizacion(argReceta As Receta, argIdMensaje As Long, argTipoMensaje As String) As String

        Dim settings As New XmlWriterSettings With {
                                                    .Indent = True,
                                                    .OmitXmlDeclaration = False,
                                                    .Encoding = New UTF8Encoding(False)
                                                    }

        Dim sb As New StringBuilder()

        Using writer As XmlWriter = XmlWriter.Create(sb, settings)

            writer.WriteElementString("apps", "nro_recetario", "apps.wsmv", argReceta.NumReceta)

            writer.WriteElementString("apps", "afiliado_documento", "apps.wsmv", argReceta.Documento.Numero)

            writer.WriteElementString("apps", "afiliado_credencial", "apps.wsmv", argReceta.Documento.Numero)

            writer.WriteStartElement("apps", "afiliado_nombre", "apps.wsmv")
            writer.WriteEndElement()

            writer.WriteElementString("apps", "medico_tipo_mat", "apps.wsmv", "M" & argReceta.Prescriptor.Matricula.TipoMatricula.CodiTMADESFA)

            writer.WriteElementString("apps", "medico_nro_mat", "apps.wsmv", argReceta.Prescriptor.Matricula.Numero)

            writer.WriteElementString("apps", "medico_nombres", "apps.wsmv", argReceta.Prescriptor.Apellido & " " & argReceta.Prescriptor.Nombre)

            writer.WriteStartElement("apps", "auditor_tipo_mat", "apps.wsmv")
            writer.WriteEndElement()

            writer.WriteElementString("apps", "auditor_nro_mat", "apps.wsmv", "0")

            writer.WriteStartElement("apps", "auditor_nombres", "apps.wsmv")
            writer.WriteEndElement()

            writer.WriteElementString("apps", "factura_nro", "apps.wsmv", "ND")

            writer.WriteElementString("apps", "fecha_receta", "apps.wsmv", argReceta.FechaPrescripcion.ToString("yyyyMMdd"))

            writer.WriteElementString("apps", "cod_operacion", "apps.wsmv", "0")

            writer.WriteStartElement("apps", "items", "apps.wsmv")

            Dim nroItem As Integer = 0

            For Each i As ItemComprobante In argReceta.Items

                If i.Articulo IsNot Nothing AndAlso i.Cantidad > 0 Then

                    nroItem += 1

                    writer.WriteStartElement("apps", "item_receta", "apps.wsmv")

                    writer.WriteElementString("apps", "nro_item", "apps.wsmv", nroItem.ToString())

                    writer.WriteElementString("apps", "codbarras", "apps.wsmv", i.CodBarras)

                    writer.WriteElementString("apps", "troquel", "apps.wsmv", i.NTroquel)

                    writer.WriteElementString("apps", "alfabeta", "apps.wsmv", i.Codigo)

                    writer.WriteStartElement("apps", "cod_trazabilidad", "apps.wsmv")
                    writer.WriteEndElement()

                    writer.WriteElementString("apps", "cantidad", "apps.wsmv", i.Cantidad.ToString())

                    writer.WriteElementString("apps", "precio_unitario", "apps.wsmv", "0")

                    writer.WriteElementString("apps", "porc_cobertura", "apps.wsmv", i.PorcentajeOS.ToString())

                    writer.WriteEndElement() ' item_receta

                End If

            Next

            writer.WriteEndElement() ' items

        End Using

        Return sb.ToString()

    End Function

    Friend Function PostWebservice(Url As String, xmlBody As String) As XmlDocument

        Try
            ' Crear la solicitud HTTP
            Dim request As HttpWebRequest = CType(WebRequest.Create(Url), HttpWebRequest)
            request.Method = "POST"
            request.ContentType = "text/xml;charset=UTF-8"

            ' Agregar el sobre SOAP al cuerpo de la solicitud
            Dim data As Byte() = Encoding.UTF8.GetBytes(xmlBody)
            request.ContentLength = data.Length

            Using stream As Stream = request.GetRequestStream()
                stream.Write(data, 0, data.Length)
            End Using

            ' Obtener la respuesta del servidor
            Using response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
                Using reader As New StreamReader(response.GetResponseStream())
                    Dim responseString As String = reader.ReadToEnd()

                    ' Convertir a XmlDocument
                    Dim xmlResponse As New XmlDocument()
                    xmlResponse.LoadXml(responseString)
                    Return xmlResponse
                End Using
            End Using

        Catch ex As XmlException
            Throw New Exception(Funciones.MensajeError(Me.ToString, "PostWebservice", "Error al procesar la respuesta XML: " & ex.Message))

        Catch ex As WebException
            If ex.Response IsNot Nothing Then
                Using reader As New StreamReader(ex.Response.GetResponseStream())
                    Dim serverError As String = reader.ReadToEnd()
                    Throw New Exception(Funciones.MensajeError(Me.ToString, "PostWebservice", serverError))
                End Using
            Else
                Throw New Exception(Funciones.MensajeError(Me.ToString, "PostWebservice", "Error de red: " & ex.Message))
            End If

        Catch ex As Exception

            Throw New Exception(Funciones.MensajeError(Me.ToString, "PostWebservice", ex.Message))

        End Try

    End Function


End Class
