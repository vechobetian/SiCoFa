Imports System.IO
Imports System.Net
Imports System.Security
Imports System.Text
Imports System.Xml
Imports SiCoFa.Entidades
Imports Vecho

Public Class MISV

    Implements IValidador

    Private Const UrlProduccion As String = "https://servicios.farmalink.com.ar/VentaSecureSvc?WSDL"

    Public Function ConsultaRecetasBeneficiario(argIdPC As String, argCredencial As CredencialOS, argPValidacion As ParametrosValidacion, argIdMensaje As Long) As List(Of Receta) Implements IValidador.ConsultaRecetasBeneficiario

        Throw New NotImplementedException()

    End Function

    Private Function ConsultaRecetaElectronica(argIdPC As String, argReceta As Receta, argIdMensaje As Long) As Receta Implements IValidador.ConsultaRecetaElectronica

        Try

            Dim xmlCRE As String = MensajeConsultaRecetaElectronica(argReceta)

            Dim pVal As ParametrosValidacion =
                argReceta.Plan.OS.PValidacion

            Dim soap As String =
                $"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/""
                                   xmlns:tns=""tns""
                                   xmlns:apps=""apps.wsmv"">
                    <soapenv:Header/>
                    <soapenv:Body>
                        <tns:consulta_receta_digital>
                            <tns:datos_req>
                                <apps:usuario>{XmlEscape(pVal.NumPrestador)}</apps:usuario>
                                <apps:clave>{XmlEscape(pVal.Licencia)}</apps:clave>
                                <apps:clave_id>cc12077bm687NB987si7</apps:clave_id>
                                <apps:convenio>{XmlEscape(argReceta.Plan.PlanValidacion)}</apps:convenio>
                                {xmlCRE}
                            </tns:datos_req>
                        </tns:consulta_receta_digital>
                    </soapenv:Body>
                </soapenv:Envelope>"

            IO.File.WriteAllText("C:\SiCoFaFarmacias\SiCoFa.Presentacion\bin\Debug\Temp\soap_request.xml", soap)

            Dim xmlResponse As XmlDocument = PostWebservice(UrlProduccion, soap)

            IO.File.WriteAllText("C:\SiCoFaFarmacias\SiCoFa.Presentacion\bin\Debug\Temp\soap_response.xml", xmlResponse.OuterXml)

            Return argReceta

        Catch ex As Exception

            Throw New Exception(Funciones.MensajeError(Me.ToString, "ConsultaRecetaElectronica", ex.Message))

        End Try

    End Function

    Public Sub SolicitarAutorizacion(argIdPC As String, argReceta As Receta, argIdMensaje As Long) Implements IValidador.SolicitarAutorizacion

        Try

            Dim xmlAUT As String = MensajeAutorizacion(argReceta)

            Dim pVal As ParametrosValidacion =
                argReceta.Plan.OS.PValidacion

            Dim soap As String =
                $"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/""
                                   xmlns:tns=""tns""
                                   xmlns:apps=""apps.wsmv"">
                    <soapenv:Header/>
                    <soapenv:Body>
                        <tns:validar_receta>
                            <tns:datos_receta>
                                <apps:usuario>{XmlEscape(pVal.NumPrestador)}</apps:usuario>
                                <apps:clave>{XmlEscape(pVal.Licencia)}</apps:clave>
                                <apps:clave_id>cc12077bm687NB987si7</apps:clave_id>
                                <apps:cuf/>
                                <apps:convenio>{XmlEscape(argReceta.Plan.PlanValidacion)}</apps:convenio>
                                {xmlAUT}
                            </tns:datos_receta>
                        </tns:validar_receta>
                    </soapenv:Body>
                </soapenv:Envelope>"

            IO.File.WriteAllText("C:\SiCoFaFarmacias\SiCoFa.Presentacion\bin\Debug\Temp\soap_request.xml", soap)

        Catch ex As Exception

            Throw New Exception(Funciones.MensajeError(Me.ToString, "SolicitarAutorizacion", ex.Message))

        End Try

    End Sub

    Public Sub CancelarAutorizacion(argIdPC As String, argReceta As Receta, argIdMensaje As Long) Implements IValidador.CancelarAutorizacion

        Throw New NotImplementedException()

    End Sub

    Private Function MensajeConsultaRecetaElectronica(argReceta As Receta) As String

        Dim sb As New StringBuilder()

        sb.AppendLine($"<apps:nro_recetario>{XmlEscape(argReceta.NumReceta)}</apps:nro_recetario>")

        sb.AppendLine($"<apps:afiliado_documento>{XmlEscape(argReceta.Documento.Numero)}</apps:afiliado_documento>")

        sb.AppendLine($"<apps:afiliado_credencial>{XmlEscape(argReceta.Documento.Numero)}</apps:afiliado_credencial>")

        Return sb.ToString()

    End Function

    Private Function MensajeAutorizacion(argReceta As Receta) As String

        Dim sb As New StringBuilder()

        sb.AppendLine($"<apps:nro_recetario>{XmlEscape(argReceta.NumReceta)}</apps:nro_recetario>")

        sb.AppendLine($"<apps:afiliado_documento>{XmlEscape(argReceta.Documento.Numero)}</apps:afiliado_documento>")

        sb.AppendLine($"<apps:afiliado_credencial>{XmlEscape(argReceta.Documento.Numero)}</apps:afiliado_credencial>")

        sb.AppendLine("<apps:afiliado_nombre/>")

        sb.AppendLine($"<apps:medico_tipo_mat>{XmlEscape("M" & argReceta.Prescriptor.Matricula.TipoMatricula.CodiTMADESFA)}</apps:medico_tipo_mat>")

        sb.AppendLine($"<apps:medico_nro_mat>{XmlEscape(argReceta.Prescriptor.Matricula.Numero)}</apps:medico_nro_mat>")

        sb.AppendLine($"<apps:medico_nombres>{XmlEscape(argReceta.Prescriptor.Apellido & " " & argReceta.Prescriptor.Nombre)}</apps:medico_nombres>")

        sb.AppendLine("<apps:auditor_tipo_mat/>")

        sb.AppendLine("<apps:auditor_nro_mat>0</apps:auditor_nro_mat>")

        sb.AppendLine("<apps:auditor_nombres/>")

        sb.AppendLine("<apps:factura_nro>ND</apps:factura_nro>")

        sb.AppendLine($"<apps:fecha_receta>{argReceta.FechaPrescripcion:yyyyMMdd}</apps:fecha_receta>")

        sb.AppendLine("<apps:cod_operacion>0</apps:cod_operacion>")

        sb.AppendLine("<apps:items>")

        Dim nroItem As Integer = 0

        For Each i As ItemComprobante In argReceta.Items

            If i.Articulo IsNot Nothing AndAlso i.Cantidad > 0 Then

                nroItem += 1

                sb.AppendLine("<apps:item_receta>")

                sb.AppendLine($"<apps:nro_item>{nroItem}</apps:nro_item>")

                sb.AppendLine($"<apps:codbarras>{XmlEscape(i.CodBarras)}</apps:codbarras>")

                sb.AppendLine($"<apps:troquel>{XmlEscape(i.NTroquel)}</apps:troquel>")

                sb.AppendLine($"<apps:alfabeta>{XmlEscape(i.Codigo)}</apps:alfabeta>")

                sb.AppendLine("<apps:cod_trazabilidad/>")

                sb.AppendLine($"<apps:cantidad>{i.Cantidad}</apps:cantidad>")

                sb.AppendLine("<apps:precio_unitario>0</apps:precio_unitario>")

                sb.AppendLine($"<apps:porc_cobertura>{CInt(i.PorcentajeOS)}</apps:porc_cobertura>")

                sb.AppendLine("</apps:item_receta>")

            End If

        Next

        sb.AppendLine("</apps:items>")

        Return sb.ToString()

    End Function


    Private Function XmlEscape(argValor As Object) As String

        If argValor Is Nothing Then
            Return String.Empty
        End If

        Return SecurityElement.Escape(argValor.ToString())

    End Function


    Friend Function PostWebservice(Url As String, xmlBody As String) As XmlDocument

        Try

            Dim request As HttpWebRequest = CType(WebRequest.Create(Url), HttpWebRequest)

            request.Method = "POST"
            request.ContentType = "text/xml;charset=UTF-8"

            Dim data As Byte() = Encoding.UTF8.GetBytes(xmlBody)

            request.ContentLength = data.Length

            Using stream As Stream = request.GetRequestStream()

                stream.Write(data, 0, data.Length)

            End Using

            Using response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)

                Using reader As New StreamReader(response.GetResponseStream())

                    Dim responseString As String = reader.ReadToEnd()

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