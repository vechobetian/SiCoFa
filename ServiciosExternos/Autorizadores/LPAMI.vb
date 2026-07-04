Imports System.IO
Imports System.Net
Imports System.Net.WebRequestMethods
Imports System.Security.Cryptography
Imports System.Text
Imports System.Xml
Imports SiCoFa.Entidades
Imports Vecho


Public Class LPAMI
    Implements IValidador

    Private Const VERSION_ADESFA As String = "3.1.0"
    Private Const NOMBRE_SOFTWARE As String = "SiCoFa"
    Private Const VERSION_SOFTWARE As String = "4.0.0"
    Private Const COD_ACCION_AUTORIZACION As String = "290020"
    Private Const COD_ACCION_CONSULTA_RECETAS As String = "490220"
    Private Const UrlVentaHomologacion As String = "https://homologacion.farmalink.com.ar/VentaSecureSvc?WSDL"
    Private Const UrlVentaProduccion As String = "https://ws.farmalink.com.ar/VentaSecureSvc?WSDL"
    Private Const UrlRecetaElectronicaHomologacion As String = "https://homologacion.farmalink.com.ar/RecetaElectSecureSvc?WSDL"
    Private Const UrlRecetaElectronicaProduccion As String = "https://ws.farmalink.com.ar/RecetaElectSecureSvc?WSDL"

    Public Function ConsultaRecetasBeneficiario(argIdMensaje As Long, argReceta As Receta) As ResultadoValidacion Implements IValidador.ConsultaRecetasBeneficiario

        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

        Dim xmlAdesfa As String = MensajeAdesfaConsultaRecetas(argReceta, 1, "200")
        Dim pv As ParametrosValidacion = argReceta.Plan.OS.PValidacion
        Dim ahora As String = Year(Now) & "-" & Format(Month(Now), "00") & "-" & Format(Day(Now), "00") & "T" & Format(Hour(Now), "00") & ":" & Format(Minute(Now), "00") & ":" & Format(Second(Now), "00") & "Z"

        Dim soap As String =
                $"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>
                <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:oas=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"" xmlns:wsu=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"" xmlns:ns1=""http://farmalink.com.ar/applicationService/V1/ConsultaAfiliadoRecetaElectSecureOutAppSvc"">
                    <soap:Header>
                        <wsse:Security xmlns:wsse=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"">
                            <wsse:UsernameToken xmlns:wsse=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"" xmlns:wsu=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"" wsu:Id=""Id-288f0808-3666-49ff-a478-7ad89cfcfea7"">
                                <wsse:Username>{pv.Usuario}</wsse:Username>
                                <wsse:Password Type=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText"">{pv.Licencia}</wsse:Password>
                                <wsu:Created>{ahora}</wsu:Created>
                            </wsse:UsernameToken>
                        </wsse:Security>
                    </soap:Header>
                    <soap:Body>
                        <ns1:consultaAfiliadoRecetaElectRq xmlns:ns1=""http://farmalink.com.ar/applicationService/V1/ConsultaAfiliadoRecetaElectSecureOutAppSvc"">
                            <ns1:infoCabeceraRq>
                                <ns1:idOrganizacion>{pv.IdOrganizacion}</ns1:idOrganizacion>
                                <ns1:tipoOrganizacion>FAR</ns1:tipoOrganizacion>
                            </ns1:infoCabeceraRq>
                            <ns1:payload>{xmlAdesfa}</ns1:payload>
                        </ns1:consultaAfiliadoRecetaElectRq>
                    </soap:Body>
                </soap:Envelope>"

        IO.File.WriteAllText("C:\SiCoFaFarmacias\SiCoFa.Presentacion\bin\Debug\Temp\soap_request.xml", soap)

        Dim url As String = UrlRecetaElectronicaProduccion

        Dim soapAction As String = "http://farmalink.com.ar/applicationService/V1/ConsultaAfiliadoRecetaElectSecureOutAppSvc"

        Dim respuesta As XmlDocument = PostWebService(url, soapAction, soap)

        Dim resultado As New ResultadoValidacion
        resultado.XmlRespuesta = respuesta.OuterXml

        IO.File.WriteAllText("C:\SiCoFaFarmacias\SiCoFa.Presentacion\bin\Debug\Temp\soap_response.xml", resultado.XmlRespuesta)

        Return resultado

    End Function

    Public Function SolicitarAutorizacion(argIdMensaje As Long, argReceta As Receta) As ResultadoValidacion Implements IValidador.SolicitarAutorizacion

        Throw New NotImplementedException()

    End Function

    '=========================================================
    ' ENCABEZADO MENSAJE
    '=========================================================
    Private Sub EncabezadoMensajeAdesfa(writer As XmlWriter,
                                       argReceta As Receta,
                                       argTipoMensaje As String,
                                       argCodigoAccion As String,
                                       argIdMensaje As Long,
                                       argFechaHora As DateTime)

        writer.WriteStartElement("EncabezadoMensaje")

        writer.WriteElementString("TipoMsj", argTipoMensaje)
        writer.WriteElementString("CodAccion", argCodigoAccion)
        writer.WriteElementString("IdMsj", argIdMensaje.ToString())

        writer.WriteStartElement("InicioTrx")
        writer.WriteElementString("Fecha", argFechaHora.ToString("yyyyMMdd"))
        writer.WriteElementString("Hora", argFechaHora.ToString("HHmmss"))
        writer.WriteEndElement()

        writer.WriteStartElement("Software")
        writer.WriteElementString("Nombre", NOMBRE_SOFTWARE)
        writer.WriteElementString("Version", VERSION_SOFTWARE)
        writer.WriteEndElement()

        writer.WriteStartElement("Validador")
        writer.WriteElementString("CodigoADESFA", "")
        writer.WriteElementString("Nombre", "IMED")
        writer.WriteEndElement()

        writer.WriteStartElement("Prestador")
        writer.WriteElementString("Cuit", argReceta.Plan.OS.PValidacion.CuitPrestador)
        writer.WriteElementString("Sucursal", "0")
        writer.WriteElementString("RazonSocial", "")
        writer.WriteElementString("Codigo", argReceta.Plan.OS.PValidacion.NumPrestador)
        writer.WriteEndElement()

        writer.WriteEndElement()

    End Sub

    Private Sub EncabezadoConsultaRecetasAdesfa(writer As XmlWriter,
                                            argReceta As Receta)

        writer.WriteStartElement("EncabezadoReceta")

        writer.WriteStartElement("Financiador")
        writer.WriteElementString("CodigoADESFA", "")
        writer.WriteElementString("Codigo", argReceta.Plan.OS.Financiador)
        writer.WriteElementString("Cuit", "")
        writer.WriteElementString("Sucursal", "")
        writer.WriteEndElement()

        writer.WriteStartElement("Beneficiario")
        writer.WriteElementString("TipoDoc", "")
        writer.WriteElementString("NroDoc", "")
        writer.WriteElementString("Apellido", "")
        writer.WriteElementString("Nombre", "")
        writer.WriteElementString("Sexo", "")
        writer.WriteElementString("FechaNacimiento", "")
        writer.WriteElementString("Parentesco", "")
        writer.WriteElementString("EdadUnidad", "")
        writer.WriteElementString("Edad", "")
        writer.WriteEndElement()

        writer.WriteStartElement("Credencial")
        writer.WriteElementString("Numero", argReceta.Credencial.Numero)
        writer.WriteElementString("Track", "")
        writer.WriteElementString("Version", "")
        writer.WriteElementString("Vencimiento", "")
        writer.WriteElementString("ModoIngreso", "")
        writer.WriteElementString("EsProvisorio", "")
        writer.WriteElementString("Plan", "41")
        writer.WriteElementString("cvc2", "")
        writer.WriteEndElement()

        writer.WriteEndElement() 'EncabezadoReceta

    End Sub

    '=========================================================
    ' ENCABEZADO RECETA
    '=========================================================
    Private Sub EncabezadoRecetaAdesfa(writer As XmlWriter,
                                       argReceta As Receta,
                                       argFechaHora As DateTime)

        writer.WriteStartElement("EncabezadoReceta")

        writer.WriteStartElement("Validador")
        writer.WriteElementString("CodigoADESFA", "0")
        writer.WriteElementString("Nombre", "IMED")
        writer.WriteEndElement()

        writer.WriteStartElement("Prescriptor")
        writer.WriteElementString("Apellido", "")
        writer.WriteElementString("Nombre", "")
        writer.WriteElementString("TipoMatricula", argReceta.Prescriptor.Matricula.CodiTMatADESFA)
        writer.WriteElementString("Provincia", argReceta.Prescriptor.Provincia.CodigoProvincia)
        writer.WriteElementString("NroMatricula", argReceta.Prescriptor.Matricula.Numero)
        writer.WriteElementString("TipoPrescriptor", argReceta.Prescriptor.TipoPrescriptor.CodiTPresADESFA)
        writer.WriteElementString("Cuit", "")
        writer.WriteElementString("Especialidad", "")
        writer.WriteEndElement()

        writer.WriteElementString("Beneficiario", "")

        writer.WriteStartElement("Financiador")
        writer.WriteElementString("Codigo", argReceta.Plan.OS.Financiador)
        writer.WriteEndElement()

        writer.WriteStartElement("Credencial")
        writer.WriteElementString("Numero", argReceta.Credencial.Numero)
        writer.WriteElementString("Track", "")
        writer.WriteElementString("Version", "")
        writer.WriteElementString("Vencimiento", "")
        writer.WriteElementString("ModoIngreso", "A")
        writer.WriteElementString("EsProvisorio", "")
        writer.WriteElementString("Plan", "0")
        writer.WriteElementString("cvc2", "")
        writer.WriteEndElement()

        writer.WriteStartElement("Preautorizacion")
        writer.WriteElementString("Codigo", "")
        writer.WriteElementString("Fecha", "")
        writer.WriteEndElement()

        writer.WriteElementString("FechaReceta", argReceta.FechaPrescripcion.ToString("yyyyMMdd"))

        writer.WriteStartElement("Dispensa")
        writer.WriteElementString("Fecha", argFechaHora.ToString("yyyyMMdd"))
        writer.WriteElementString("Hora", argFechaHora.ToString("HHmmss"))
        writer.WriteEndElement()

        writer.WriteStartElement("Formulario")
        writer.WriteElementString("Fecha", "")
        writer.WriteElementString("Tipo", "0")
        writer.WriteElementString("Numero", argReceta.NumReceta)
        writer.WriteElementString("Serie", "0")
        writer.WriteElementString("NroAutEspecial", "0")
        writer.WriteElementString("NroFormulario", "0")
        writer.WriteEndElement()

        writer.WriteElementString("TipoTratamiento", argReceta.Tratamiento)
        writer.WriteElementString("Diagnostico", "")

        writer.WriteStartElement("Institucion")
        writer.WriteElementString("Codigo", "000000000000000")
        writer.WriteElementString("Cuit", "0")
        writer.WriteElementString("Sucursal", "0")
        writer.WriteEndElement()

        writer.WriteStartElement("Retira")
        writer.WriteElementString("Apellido", "")
        writer.WriteElementString("Nombre", "")
        writer.WriteElementString("TipoDoc", "")
        writer.WriteElementString("NroDoc", "")
        writer.WriteElementString("NroTelefono", "")
        writer.WriteEndElement()

        writer.WriteEndElement()

    End Sub

    '=========================================================
    ' DETALLE
    '=========================================================
    Private Sub DetalleRecetaAdesfa(writer As XmlWriter,
                                   argReceta As Receta)

        writer.WriteStartElement("DetalleReceta")

        Dim nroItem As Integer = 0

        For Each argItem In argReceta.Items

            nroItem += 1

            writer.WriteStartElement("Item")

            writer.WriteElementString("NroItem", nroItem.ToString())
            writer.WriteElementString("CodBarras", argItem.Articulo.CodBarras)
            writer.WriteElementString("CodTroquel", argItem.Articulo.NTroquel)
            writer.WriteElementString("Alfabeta", argItem.Articulo.Codigo)
            writer.WriteElementString("Kairos", "0")
            writer.WriteElementString("Codigo", "0")
            writer.WriteElementString("ImporteUnitario", "0")
            writer.WriteElementString("CantidadSolicitada", argItem.Cantidad.ToString())
            writer.WriteElementString("PorcentajeCobertura", "0")
            writer.WriteElementString("CodPreautorizacion", "0")
            writer.WriteElementString("ImporteCobertura", "0")
            writer.WriteElementString("Diagnostico", "N")
            writer.WriteElementString("DosisDiaria", "0")
            writer.WriteElementString("Generico", "M")

            writer.WriteEndElement()

        Next

        writer.WriteEndElement()

    End Sub

    Private Function MensajeAdesfaConsultaRecetas(argReceta As Receta,
                                              argIdMensaje As Long,
                                              argTipoMensaje As String) As String

        Dim settings As New XmlWriterSettings With {
        .Indent = True,
        .OmitXmlDeclaration = True
    }

        Dim sb As New StringBuilder()
        Dim argFechaHora As DateTime = DateTime.Now

        Using writer As XmlWriter = XmlWriter.Create(sb, settings)

            writer.WriteStartElement("MensajeADESFA")
            writer.WriteAttributeString("version", VERSION_ADESFA)

            EncabezadoMensajeAdesfa(writer,
                                argReceta,
                                argTipoMensaje,
                                COD_ACCION_CONSULTA_RECETAS,
                                argIdMensaje,
                                argFechaHora)

            EncabezadoConsultaRecetasAdesfa(writer,
                                        argReceta)

            writer.WriteEndElement() 'MensajeADESFA

        End Using

        Return sb.ToString()

    End Function

    '=========================================================
    ' MENSAJE COMPLETO
    '=========================================================
    Private Function MensajeAdesfaAutorizacion(argReceta As Receta,
                                               argIdMensaje As Long,
                                               argTipoMensaje As String) As String

        Dim settings As New XmlWriterSettings With {
            .Indent = True,
            .OmitXmlDeclaration = True
        }

        Dim sb As New StringBuilder()
        Dim argFechaHora As DateTime = DateTime.Now

        Using writer As XmlWriter = XmlWriter.Create(sb, settings)

            writer.WriteStartElement("MensajeADESFA")
            writer.WriteAttributeString("version", VERSION_ADESFA)

            EncabezadoMensajeAdesfa(writer,
                                    argReceta,
                                    argTipoMensaje,
                                    COD_ACCION_AUTORIZACION,
                                    argIdMensaje,
                                    argFechaHora)

            EncabezadoRecetaAdesfa(writer,
                                  argReceta,
                                  argFechaHora)

            DetalleRecetaAdesfa(writer,
                               argReceta)

            writer.WriteEndElement()

        End Using

        Return sb.ToString()

    End Function

    '=========================================================
    ' SOAP
    '=========================================================
    Private Function CrearSoap(
    argMetodo As String,
    argNamespace As String,
    argMensajeAdesfa As String,
    p As ParametrosValidacion
) As String

        Dim fechaUtc As String = Format$(Now, "yyyy-mm-dd\Thh:nn:ss") & "Z"

        Dim soap As String

        soap = ""
        soap = soap & "<soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" "
        soap = soap & "xmlns:oas=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"" "
        soap = soap & "xmlns:wsu=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"" "
        soap = soap & "xmlns:ns1=""" & argNamespace & """>"

        '========================
        ' HEADER WSSE (VB6 STYLE)
        '========================
        soap = soap & "<soap:Header>"
        soap = soap & "<wsse:Security xmlns:wsse=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"">"
        soap = soap & "<wsse:UsernameToken xmlns:wsse=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"" "
        soap = soap & "xmlns:wsu=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"" "
        'soap = soap & "wsu:Id=""Id-" & Replace(CStr(Guid.NewGuid()), "{", "") & """>"

        soap = soap & "<wsse:Username>" & p.Usuario & "</wsse:Username>"

        soap = soap & "<wsse:Password Type=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText"">"
        soap = soap & p.Licencia
        soap = soap & "</wsse:Password>"

        soap = soap & "<wsu:Created>" & fechaUtc & "</wsu:Created>"
        soap = soap & "</wsse:UsernameToken>"
        soap = soap & "</wsse:Security>"
        soap = soap & "</soap:Header>"

        '========================
        ' BODY (STRICT VB6)
        '========================
        soap = soap & "<soap:Body>"
        soap = soap & "<ns1:" & argMetodo & " xmlns:ns1=""" & argNamespace & """>"

        soap = soap & "<ns1:infoCabeceraRq>"
        soap = soap & "<ns1:idOrganizacion>" & p.IdOrganizacion & "</ns1:idOrganizacion>"
        soap = soap & "<ns1:tipoOrganizacion>FAR</ns1:tipoOrganizacion>"
        soap = soap & "</ns1:infoCabeceraRq>"

        soap = soap & "<ns1:payload>"
        soap = soap & argMensajeAdesfa
        soap = soap & "</ns1:payload>"

        soap = soap & "</ns1:" & argMetodo & ">"
        soap = soap & "</soap:Body>"

        soap = soap & "</soap:Envelope>"

        Return soap

    End Function

    Friend Function PostWebservice(Url As String, soapAction As String, xmlBody As String) As XmlDocument

        Try
            ' Crear la solicitud HTTP
            Dim request As HttpWebRequest = CType(WebRequest.Create(Url), HttpWebRequest)
            request.Method = "POST"
            request.ContentType = "text/xml;charset=UTF-8"
            request.Headers.Add("SOAPAction", soapAction)

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