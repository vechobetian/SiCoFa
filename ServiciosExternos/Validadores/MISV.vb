Imports System.IO
Imports System.Net
Imports System.Security
Imports System.Text
Imports System.Xml
Imports SiCoFa.Entidades
Imports Vecho

Public Class MISV

    Implements IValidador

    Private Const UrlProduccion As String = "http://www.misvalidaciones.com.ar/wsmv"

    Public Function ConsultaRecetasBeneficiario(argIdPC As String, argCredencial As CredencialOS, argPValidacion As ParametrosValidacion, argIdMensaje As Long) As List(Of Receta) Implements IValidador.ConsultaRecetasBeneficiario

        Throw New NotSupportedException(argPValidacion.Descripcion & " no acepta consulta de recetas por beneficiario.")

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

            VerificarRespuestaGeneral(xmlResponse)

            Return argReceta

        Catch ex As Exception

            Throw New Exception(Funciones.MensajeError(Me.ToString, "ConsultaRecetaElectronica", ex.Message))

        End Try

    End Function

    Public Sub SolicitarAutorizacion(argIdPC As String, argReceta As Receta, argIdMensaje As Long) Implements IValidador.SolicitarAutorizacion

        Try

            Dim xmlAUT As String = MensajeAutorizacion(argReceta)

            Dim pVal As ParametrosValidacion = argReceta.Plan.OS.PValidacion

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

            Dim xmlResponse As XmlDocument = PostWebservice(UrlProduccion, soap)

            IO.File.WriteAllText("C:\SiCoFaFarmacias\SiCoFa.Presentacion\bin\Debug\Temp\soap_response.xml", xmlResponse.OuterXml)

            VerificarRespuestaGeneral(xmlResponse)

        Catch ex As Exception

            Throw New Exception(Funciones.MensajeError(Me.ToString, "SolicitarAutorizacion", ex.Message))

        End Try

    End Sub

    Public Sub CancelarAutorizacion(argIdPC As String, argReceta As Receta, argIdMensaje As Long) Implements IValidador.CancelarAutorizacion

        Try

            Dim pVal As ParametrosValidacion = argReceta.Plan.OS.PValidacion

            Dim soap As String =
                $"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/""
                                   xmlns:tns=""tns""
                                   xmlns:apps=""apps.wsmv"">
                    <soapenv:Header/>
                    <soapenv:Body>
                        <tns:anular_receta>
                            <tns:datos_receta>
                                <apps:usuario>{XmlEscape(pVal.NumPrestador)}</apps:usuario>
                                <apps:clave>{XmlEscape(pVal.Licencia)}</apps:clave>
                                <apps:clave_id>cc12077bm687NB987si7</apps:clave_id>
                                <apps:cuf/>
                                <apps:cod_validacion>{XmlEscape(argReceta.NumAutorizacion)}</apps:cod_validacion>
                            </tns:datos_receta>
                        </tns:anular_receta>
                    </soapenv:Body>
                </soapenv:Envelope>"

            IO.File.WriteAllText("C:\SiCoFaFarmacias\SiCoFa.Presentacion\bin\Debug\Temp\soap_request.xml", soap)

            Dim xmlResponse As XmlDocument = PostWebservice(UrlProduccion, soap)

            IO.File.WriteAllText("C:\SiCoFaFarmacias\SiCoFa.Presentacion\bin\Debug\Temp\soap_response.xml", xmlResponse.OuterXml)

        Catch ex As Exception

            Throw New Exception(Funciones.MensajeError(Me.ToString, "CancelarAutorizacion", ex.Message))

        End Try


    End Sub

    Private Function MensajeConsultaRecetaElectronica(argReceta As Receta) As String

        If argReceta Is Nothing Then Return String.Empty

        Dim sb As New StringBuilder()

        ' Manejo seguro de nulos para evitar exepciones en la capa de acceso a datos
        Dim nroReceta As String = If(argReceta.NumReceta, String.Empty)
        Dim nroDoc As String = If(argReceta.Documento IsNot Nothing, argReceta.Documento.Numero, String.Empty)
        Dim nroCredencial As String = If(String.IsNullOrEmpty(argReceta.Credencial.Numero), nroDoc, argReceta.Credencial.Numero)

        sb.AppendLine($"<apps:nro_recetario>{XmlEscape(nroReceta)}</apps:nro_recetario>")
        sb.AppendLine($"<apps:afiliado_documento>{XmlEscape(nroDoc)}</apps:afiliado_documento>")
        sb.AppendLine($"<apps:afiliado_credencial>{XmlEscape(nroCredencial)}</apps:afiliado_credencial>")

        Return sb.ToString()

    End Function

    Private Function MensajeAutorizacion(argReceta As Receta) As String
        If argReceta Is Nothing Then Return String.Empty

        Dim sb As New StringBuilder()

        ' Datos del Afiliado de forma segura
        Dim nroDoc As String = String.Empty
        Dim nroCredencial As String = String.Empty

        If argReceta.Documento IsNot Nothing Then
            nroDoc = If(argReceta.Documento IsNot Nothing, argReceta.Documento.Numero, String.Empty)
        End If

        If argReceta.Credencial IsNot Nothing Then
            nroCredencial = If(String.IsNullOrEmpty(argReceta.Credencial.Numero), nroDoc, argReceta.Credencial.Numero)
        End If

        ' Datos del Prescriptor con comprobación de nulos por niveles
        Dim tipoMatricula As String = String.Empty
        Dim nroMatricula As String = String.Empty
        Dim nombreMedico As String = String.Empty

        If argReceta.Prescriptor IsNot Nothing Then
            Dim medico = argReceta.Prescriptor
            nombreMedico = $"{medico.Apellido} {medico.Nombre}".Trim()

            If medico.Matricula IsNot Nothing Then
                nroMatricula = medico.Matricula.Numero
                If medico.Matricula.TipoMatricula IsNot Nothing Then
                    tipoMatricula = "M" & medico.Matricula.TipoMatricula.CodiTMADESFA
                End If
            End If
        End If

        ' Encabezado de la solicitud
        sb.AppendLine($"<apps:nro_recetario>{XmlEscape(argReceta.NumReceta)}</apps:nro_recetario>")
        sb.AppendLine($"<apps:afiliado_documento>{XmlEscape(nroDoc)}</apps:afiliado_documento>")
        sb.AppendLine($"<apps:afiliado_credencial>{XmlEscape(nroCredencial)}</apps:afiliado_credencial>")
        sb.AppendLine("<apps:afiliado_nombre/>")
        sb.AppendLine($"<apps:medico_tipo_mat>{XmlEscape(tipoMatricula)}</apps:medico_tipo_mat>")
        sb.AppendLine($"<apps:medico_nro_mat>{XmlEscape(nroMatricula)}</apps:medico_nro_mat>")
        sb.AppendLine($"<apps:medico_nombres>{XmlEscape(nombreMedico)}</apps:medico_nombres>")
        sb.AppendLine("<apps:auditor_tipo_mat/>")
        sb.AppendLine("<apps:auditor_nro_mat>0</apps:auditor_nro_mat>")
        sb.AppendLine("<apps:auditor_nombres/>")
        sb.AppendLine("<apps:factura_nro>ND</apps:factura_nro>")
        sb.AppendLine($"<apps:fecha_receta>{argReceta.FechaPrescripcion:yyyyMMdd}</apps:fecha_receta>")
        sb.AppendLine("<apps:cod_operacion>0</apps:cod_operacion>")

        ' Detalle de Items
        sb.AppendLine("<apps:items>")
        If argReceta.Items IsNot Nothing Then
            Dim nroItem As Integer = 0
            For Each item As ItemComprobante In argReceta.Items
                If item IsNot Nothing AndAlso item.Articulo IsNot Nothing AndAlso item.Cantidad > 0 Then
                    nroItem += 1
                    sb.AppendLine("<apps:item_receta>")
                    sb.AppendLine($"<apps:nro_item>{nroItem}</apps:nro_item>")
                    sb.AppendLine($"<apps:codbarras>{XmlEscape(item.CodBarras)}</apps:codbarras>")
                    sb.AppendLine($"<apps:troquel>{XmlEscape(item.NTroquel)}</apps:troquel>")
                    sb.AppendLine($"<apps:alfabeta>{XmlEscape(item.Codigo)}</apps:alfabeta>")
                    sb.AppendLine("<apps:cod_trazabilidad/>")
                    sb.AppendLine($"<apps:cantidad>{item.Cantidad}</apps:cantidad>")
                    sb.AppendLine("<apps:precio_unitario>0</apps:precio_unitario>")
                    sb.AppendLine($"<apps:porc_cobertura>{CInt(item.PorcentajeOS)}</apps:porc_cobertura>")
                    sb.AppendLine("</apps:item_receta>")
                End If
            Next
        End If
        sb.AppendLine("</apps:items>")

        Return sb.ToString()
    End Function


    Private Function XmlEscape(argValor As Object) As String

        If argValor Is Nothing Then
            Return String.Empty
        End If

        Return SecurityElement.Escape(argValor.ToString())

    End Function

    Private Sub VerificarRespuestaGeneral(xml As XmlDocument)

        Dim status As String = xml.SelectSingleNode("//*[local-name()='status']")?.InnerText
        Dim data As String = xml.SelectSingleNode("//*[local-name()='data']")?.InnerText

        If String.IsNullOrWhiteSpace(status) Then
            Throw New Exception("La respuesta de MisValidaciones no contiene status.")
        End If

        If status <> "OK" Then
            Throw New Exception(data)
        End If

    End Sub

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