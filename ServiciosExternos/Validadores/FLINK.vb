Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Xml
Imports SiCoFa.Entidades
Imports Vecho

Public Class FLINK

    Implements IValidador

    Private Const VERSION_ADESFA As String = "3.1.0"
    Private Const NOMBRE_SOFTWARE As String = "SiCoFa"
    Private Const VERSION_SOFTWARE As String = "4.0.0"
    Private Const COD_ACCION_CONSULTA_RECETAS As String = "490220"
    Private Const COD_ACCION_CONSULTA_RECETA_ELECTRONICA As String = "490120"
    Private Const COD_ACCION_AUTORIZACION As String = "290020"

    Private Const UrlVentaTest As String = "https://homologacion.farmalink.com.ar/VentaSecureSvc?WSDL"
    Private Const UrlVentaProduccion As String = "https://servicios.farmalink.com.ar/VentaSecureSvc?WSDL"
    Private Const UrlRecetaElectronicaTest As String = "https://homologacion.farmalink.com.ar/RecetaElectSecureSvc?WSDL"
    Private Const UrlRecetaElectronicaProduccion As String = "https://servicios.farmalink.com.ar/RecetaElectSecureSvc?WSDL"

    Public Function ConsultaRecetasBeneficiario(argIdPC As String, argCredencial As CredencialOS, argPValidacion As ParametrosValidacion, argIdMensaje As Long) As List(Of Receta) Implements IValidador.ConsultaRecetasBeneficiario

        Throw New NotSupportedException(argPValidacion.Descripcion & " no acepta consulta de recetas por beneficiario.")

    End Function

    Private Function ConsultaRecetaElectronica(argIdPC As String, argReceta As Receta, argIdMensaje As Long) As Receta Implements IValidador.ConsultaRecetaElectronica

        Try

            Dim xmlAdesfa As String = MensajeAdesfaConsultaRecetaElectronica(argReceta, argIdMensaje, "200")
            Dim ahora As String = Year(Now) & "-" & Format(Month(Now), "00") & "-" & Format(Day(Now), "00") & "T" & Format(Hour(Now), "00") & ":" & Format(Minute(Now), "00") & ":" & Format(Second(Now), "00") & "Z"
            Dim pVal As ParametrosValidacion = argReceta.Plan.OS.PValidacion

            Dim soap As String =
                $"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>
                <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                    <soap:Header>
                        <wsse:Security xmlns:wsse=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"">
                            <wsse:UsernameToken xmlns:wsse=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"" 
                                xmlns:wsu=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"" 
                                wsu:Id=""Id-288f0808-3666-49ff-a478-7ad89cfcfea7"">
                                <wsse:Username>{pVal.Usuario}</wsse:Username>
                                <wsse:Password Type=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText"">{pVal.Licencia}</wsse:Password>
                                <wsu:Created>{ahora}</wsu:Created>
                            </wsse:UsernameToken>
                        </wsse:Security>
                    </soap:Header>
                    <soap:Body>
                        <ns1:consultaRecetaElectRq xmlns:ns1=""http://farmalink.com.ar/applicationService/V1/ConsultaRecetaElectSecureOutAppSvc"">
                            <ns1:infoCabeceraRq>
                                <ns1:idOrganizacion>{pVal.IdOrganizacion}</ns1:idOrganizacion>
                                <ns1:tipoOrganizacion>FAR</ns1:tipoOrganizacion>
                            </ns1:infoCabeceraRq>
                            <ns1:payload>{xmlAdesfa}</ns1:payload>
                        </ns1:consultaRecetaElectRq>
                    </soap:Body>
                </soap:Envelope>"

            File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Temp", "soap_request.xml"), soap)

            Dim soapAction As String = "http://farmalink.com.ar/applicationService/V1/ConsultaRecetaElectSecureOutAppSvc"

            Dim xmlResponse As XmlDocument = PostWebservice(UrlRecetaElectronicaProduccion, soapAction, soap)

            File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Temp", "soap_request.xml"), xmlResponse.OuterXml)

            VerificarRespuestaGeneral(xmlResponse)

            argReceta = ParsearRecetaElectronica(argReceta, xmlResponse)

            Return argReceta

        Catch ex As Exception
            Throw New Exception(Funciones.MensajeError(Me.ToString, "ConsultaRecetaElectronica", ex.Message))

        End Try

    End Function

    Public Sub SolicitarAutorizacion(argIdPC As String, argReceta As Receta, argIdMensaje As Long) Implements IValidador.SolicitarAutorizacion

        Try

            Dim xmlAdesfa As String = MensajeAdesfaAutorizacion(argReceta, argIdMensaje, "200")
            Dim ahora As String = Year(Now) & "-" & Format(Month(Now), "00") & "-" & Format(Day(Now), "00") & "T" & Format(Hour(Now), "00") & ":" & Format(Minute(Now), "00") & ":" & Format(Second(Now), "00") & "Z"
            Dim pVal As ParametrosValidacion = argReceta.Plan.OS.PValidacion

            Dim soap As String =
                $"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>
                <soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" 
                    xmlns:oas=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"" 
                    xmlns:wsu=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"" 
                    xmlns:aut=""http://farmalink.com.ar/applicationService/V1/AutorizacionRecetaVentaSecureOutAppSvc"">
                    <soapenv:Header>
                        <oas:Security>
                            <oas:UsernameToken wsu:Id=""Id-288f0808-3666-49ff-a478-7ad89cfcfea7"">
                                <oas:Username>{pVal.Usuario}</oas:Username>
                                <oas:Password Type=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText"">{pVal.Licencia}</oas:Password>
                                <wsu:Created>{ahora}</wsu:Created>
                            </oas:UsernameToken>
                        </oas:Security>
                    </soapenv:Header>
                    <soapenv:Body>
                        <aut:autorizacionRecetaVentaRq>
                            <aut:infoCabeceraRq>
                                <aut:idOrganizacion>{pVal.IdOrganizacion}</aut:idOrganizacion>
                                <aut:tipoOrganizacion>FAR</aut:tipoOrganizacion>
                            </aut:infoCabeceraRq>
                            <aut:payload>{xmlAdesfa}</aut:payload>
                        </aut:autorizacionRecetaVentaRq>
                    </soapenv:Body>
                </soapenv:Envelope>"

            File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Temp", "soap_request.xml"), soap)

            Dim soapAction As String = "http://farmalink.com.ar/applicationService/V1/AutorizacionRecetaVentaSecureOutAppSvc"

            Dim xmlResponse As XmlDocument = PostWebservice(UrlVentaProduccion, soapAction, soap)

            File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Temp", "soap_request.xml"), xmlResponse.OuterXml)

            'argReceta = ParsearRecetaElectronica(argReceta, xmlResponse)

            'Return argReceta

        Catch ex As Exception
            Throw New Exception(Funciones.MensajeError(Me.ToString, "AutorizacionReceta", ex.Message))

        End Try

    End Sub

    Public Sub CancelarAutorizacion(argIdPC As String, argReceta As Receta, argIdMensaje As Long) Implements IValidador.CancelarAutorizacion

        Try

            Dim xmlAdesfa As String = MensajeAdesfaAutorizacion(argReceta, argIdMensaje, "200")
            Dim ahora As String = Year(Now) & "-" & Format(Month(Now), "00") & "-" & Format(Day(Now), "00") & "T" & Format(Hour(Now), "00") & ":" & Format(Minute(Now), "00") & ":" & Format(Second(Now), "00") & "Z"
            Dim pVal As ParametrosValidacion = argReceta.Plan.OS.PValidacion

            Dim soap As String =
                $"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>
                <soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" 
                    xmlns:oas=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"" 
                    xmlns:wsu=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"" 
                    xmlns:aut=""http://farmalink.com.ar/applicationService/V1/CancelacionRecetaVentaSecureOutAppSvc"">
                    <soapenv:Header>
                        <oas:Security>
                            <oas:UsernameToken wsu:Id=""Id-288f0808-3666-49ff-a478-7ad89cfcfea7"">
                                <oas:Username>{pVal.Usuario}</oas:Username>
                                <oas:Password Type=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText"">{pVal.Licencia}</oas:Password>
                                <wsu:Created>{ahora}</wsu:Created>
                            </oas:UsernameToken>
                        </oas:Security>
                    </soapenv:Header>
                    <soapenv:Body>
                        <aut:cancelacionRecetaVentaRq>
                            <aut:infoCabeceraRq>
                                <aut:idOrganizacion>{pVal.IdOrganizacion}</aut:idOrganizacion>
                                <aut:tipoOrganizacion>FAR</aut:tipoOrganizacion>
                            </aut:infoCabeceraRq>
                            <aut:payload>{xmlAdesfa}</aut:payload>
                        </aut:cancelacionRecetaVentaRq>
                    </soapenv:Body>
                </soapenv:Envelope>"

            File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Temp", "soap_request.xml"), soap)

            Dim soapAction As String = "http://farmalink.com.ar/applicationService/V1/CancelacionRecetaVentaSecureOutAppSvc"

            Dim xmlResponse As XmlDocument = PostWebservice(UrlVentaProduccion, soapAction, soap)

            File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Temp", "soap_request.xml"), xmlResponse.OuterXml)

        Catch ex As Exception
            Throw New Exception(Funciones.MensajeError(Me.ToString, "CancelacionReceta", ex.Message))

        End Try

    End Sub

    '=========================================================
    ' ENCABEZADO MENSAJE
    '=========================================================
    Private Sub EncabezadoMensajeAdesfa(writer As XmlWriter,
                                       argPValidacion As ParametrosValidacion,
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
        writer.WriteElementString("CodigoADESFA", "0")
        writer.WriteElementString("Nombre", "IMED")
        writer.WriteEndElement()

        writer.WriteStartElement("Prestador")
        writer.WriteElementString("Cuit", If(argPValidacion?.CuitPrestador, ""))
        writer.WriteElementString("Sucursal", "0")
        writer.WriteElementString("RazonSocial", "")
        writer.WriteElementString("Codigo", If(argPValidacion?.NumPrestador, ""))
        writer.WriteEndElement()

        writer.WriteEndElement()

    End Sub

    Private Sub EncabezadoConsultaRecetaElectronicaAdesfa(writer As XmlWriter, argReceta As Receta)

        writer.WriteStartElement("EncabezadoReceta")

        writer.WriteStartElement("Financiador")
        writer.WriteElementString("CodigoADESFA", "")
        writer.WriteElementString("Codigo", If(argReceta.Plan?.OS?.PValidacion?.Financiador, ""))
        writer.WriteElementString("Cuit", "")
        writer.WriteElementString("Sucursal", "")
        writer.WriteEndElement()

        writer.WriteStartElement("Credencial")
        writer.WriteElementString("Numero", If(argReceta.Credencial?.Numero, ""))
        writer.WriteElementString("Track", "")
        writer.WriteElementString("Version", "")
        writer.WriteElementString("Vencimiento", "")
        writer.WriteElementString("ModoIngreso", "")
        writer.WriteElementString("EsProvisorio", "")
        writer.WriteElementString("Plan", "")
        writer.WriteEndElement()

        writer.WriteStartElement("Formulario")
        writer.WriteElementString("Fecha", "")
        writer.WriteElementString("Tipo", "")
        writer.WriteElementString("Numero", argReceta.NumReceta)
        writer.WriteElementString("Serie", "")
        writer.WriteEndElement()

        writer.WriteEndElement() 'EncabezadoReceta

    End Sub

    '=========================================================
    ' ENCABEZADO RECETA
    '=========================================================
    Private Sub EncabezadoRecetaAdesfa(writer As XmlWriter, argReceta As Receta, argFechaHora As DateTime)

        writer.WriteStartElement("EncabezadoReceta")

        writer.WriteStartElement("Validador")
        writer.WriteElementString("CodigoADESFA", "0")
        writer.WriteElementString("Nombre", "IMED")
        writer.WriteEndElement()

        writer.WriteStartElement("Prescriptor")
        writer.WriteElementString("Apellido", "")
        writer.WriteElementString("Nombre", "")
        writer.WriteElementString("TipoMatricula", If(argReceta.Prescriptor?.Matricula?.TipoMatricula?.CodiTMADESFA, ""))
        writer.WriteElementString("Provincia", "")
        writer.WriteElementString("NroMatricula", If(argReceta.Prescriptor?.Matricula?.Numero, ""))
        writer.WriteElementString("TipoPrescriptor", If(argReceta.Prescriptor?.TipoPrescriptor?.CodiTPADESFA, ""))
        writer.WriteElementString("Cuit", "")
        writer.WriteElementString("Especialidad", "")
        writer.WriteEndElement()

        writer.WriteElementString("Beneficiario", "")

        writer.WriteStartElement("Financiador")
        writer.WriteElementString("Codigo", If(argReceta.Plan?.OS?.PValidacion?.Financiador, ""))
        writer.WriteEndElement()

        writer.WriteStartElement("Credencial")
        writer.WriteElementString("Numero", If(argReceta.Credencial?.Numero, ""))
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
    Private Sub DetalleRecetaAdesfa(writer As XmlWriter, argReceta As Receta)

        writer.WriteStartElement("DetalleReceta")

        Dim nroItem As Integer = 0

        If argReceta.Items IsNot Nothing Then

            For Each i In argReceta.Items

                If i.Articulo IsNot Nothing Then
                    nroItem += 1

                    writer.WriteStartElement("Item")

                    writer.WriteElementString("NroItem", nroItem.ToString())
                    writer.WriteElementString("CodBarras", i.CodBarras)
                    writer.WriteElementString("CodTroquel", i.NTroquel)
                    writer.WriteElementString("Alfabeta", i.Codigo)
                    writer.WriteElementString("Kairos", "0")
                    writer.WriteElementString("Codigo", "0")
                    writer.WriteElementString("ImporteUnitario", "0")
                    writer.WriteElementString("CantidadSolicitada", i.Cantidad.ToString())
                    writer.WriteElementString("PorcentajeCobertura", "0")
                    writer.WriteElementString("CodPreautorizacion", "0")
                    writer.WriteElementString("ImporteCobertura", "0")
                    writer.WriteElementString("Diagnostico", "N")
                    writer.WriteElementString("DosisDiaria", "0")
                    writer.WriteElementString("Generico", "M")

                    writer.WriteEndElement()
                End If

            Next

        End If

        writer.WriteEndElement()

    End Sub

    Private Function MensajeAdesfaConsultaRecetaElectronica(argReceta As Receta, argIdMensaje As Long, argTipoMensaje As String) As String

        Dim settings As New XmlWriterSettings With {
        .Indent = True,
        .OmitXmlDeclaration = True}

        Dim sb As New StringBuilder()
        Dim argFechaHora As DateTime = DateTime.Now

        Using writer As XmlWriter = XmlWriter.Create(sb, settings)

            writer.WriteStartElement("MensajeADESFA")
            writer.WriteAttributeString("version", VERSION_ADESFA)

            EncabezadoMensajeAdesfa(writer, argReceta.Plan.OS.PValidacion, argTipoMensaje, COD_ACCION_CONSULTA_RECETA_ELECTRONICA, argIdMensaje, argFechaHora)

            EncabezadoConsultaRecetaElectronicaAdesfa(writer, argReceta)

            writer.WriteEndElement() 'MensajeADESFA

        End Using

        Return sb.ToString()

    End Function

    Private Function MensajeAdesfaAutorizacion(argReceta As Receta, argIdMensaje As Long, argTipoMensaje As String) As String

        Dim settings As New XmlWriterSettings With {.Indent = True, .OmitXmlDeclaration = True}

        Dim sb As New StringBuilder()
        Dim argFechaHora As DateTime = DateTime.Now

        Using writer As XmlWriter = XmlWriter.Create(sb, settings)

            writer.WriteStartElement("MensajeADESFA")
            writer.WriteAttributeString("version", VERSION_ADESFA)

            EncabezadoMensajeAdesfa(writer, argReceta.Plan.OS.PValidacion, argTipoMensaje, COD_ACCION_AUTORIZACION, argIdMensaje, argFechaHora)

            EncabezadoRecetaAdesfa(writer, argReceta, argFechaHora)

            DetalleRecetaAdesfa(writer, argReceta)

            writer.WriteEndElement()

        End Using

        Return sb.ToString()

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

    Private Sub VerificarRespuestaGeneral(xml As XmlDocument)

        Dim codRtaGeneral As String = xml.SelectSingleNode("//CodRtaGeneral")?.InnerText

        Dim descripcion As String = xml.SelectSingleNode("//Descripcion")?.InnerText

        If String.IsNullOrWhiteSpace(codRtaGeneral) Then
            Throw New Exception("La respuesta del validador no contiene CodRtaGeneral.")
        End If

        If codRtaGeneral <> "0" Then
            Throw New Exception(descripcion)
        End If

    End Sub

    Private Function ParsearRecetaElectronica(argReceta As Receta, xml As XmlDocument) As Receta

        '=========================
        ' Encabezado de la receta
        '=========================

        Dim encabezado As XmlNode = xml.SelectSingleNode("//MensajeADESFA/EncabezadoReceta")

        Dim fecha As String = encabezado.SelectSingleNode("FechaReceta")?.InnerText

        If Not String.IsNullOrEmpty(fecha) Then
            argReceta.FechaPrescripcion = DateTime.ParseExact(fecha, "yyyyMMdd", Globalization.CultureInfo.InvariantCulture)
        End If

        argReceta.NumReceta = encabezado.SelectSingleNode("Formulario/Numero")?.InnerText
        argReceta.Tratamiento = encabezado.SelectSingleNode("TipoTratamiento")?.InnerText

        If argReceta.Prescriptor Is Nothing Then
            Dim codiTPrescriptor As String = encabezado.SelectSingleNode("Prescriptor/TipoPrescriptor")?.InnerText
            Dim tipoPrescriptor As New TipoPrescriptor(codiTPrescriptor)
            Dim codiTM As String = encabezado.SelectSingleNode("Prescriptor/TipoMatricula")?.InnerText
            Dim nMatricula As String = encabezado.SelectSingleNode("Prescriptor/NroMatricula")?.InnerText
            Dim matricula As New Matricula(codiTM, nMatricula)
            argReceta.Prescriptor = New Prescriptor(tipoPrescriptor, Nothing, "", "", matricula)
        End If

        '=========================
        ' Detalle
        '=========================

        argReceta.Items = New List(Of ItemComprobante)

        Dim referencias As XmlNodeList = xml.SelectNodes("//MensajeADESFA/DetalleReceta/ReferenciaRx")

        For Each referencia As XmlNode In referencias

            Dim idItem As Long
            Long.TryParse(referencia.SelectSingleNode("NroLinea")?.InnerText, idItem)

            Dim cantidadPrescripta As Integer
            Integer.TryParse(referencia.SelectSingleNode("CantidadPrescripta")?.InnerText, cantidadPrescripta)

            Dim itemSeleccionado As XmlNode = Nothing

            For Each nodoItem As XmlNode In referencia.SelectNodes("Item")

                If itemSeleccionado Is Nothing Then
                    itemSeleccionado = nodoItem
                End If

                If nodoItem.SelectSingleNode("Estado")?.InnerText = "1" Then
                    itemSeleccionado = nodoItem
                    Exit For
                End If

            Next


            If itemSeleccionado IsNot Nothing Then

                Dim codigo As String = ""
                Dim idArticulo As String = ""
                Dim codBarras As String = ""
                Dim nTroquel As String = ""

                Dim alfabeta = itemSeleccionado.SelectSingleNode("Alfabeta")?.InnerText

                If Not String.IsNullOrWhiteSpace(alfabeta) Then
                    codigo = alfabeta
                    idArticulo = "M" & alfabeta
                End If

                codBarras = itemSeleccionado.SelectSingleNode("CodBarras")?.InnerText
                nTroquel = itemSeleccionado.SelectSingleNode("CodTroquel")?.InnerText

                Dim pUnit As Decimal
                Decimal.TryParse(itemSeleccionado.SelectSingleNode("ImporteUnitario")?.InnerText, Globalization.NumberStyles.Any, Globalization.CultureInfo.InvariantCulture, pUnit)

                Dim descripcion = itemSeleccionado.SelectSingleNode("Descripcion")?.InnerText

                Dim item As New ItemComprobante(idItem, idArticulo, codBarras, descripcion, 0, cantidadPrescripta, 0, 0, pUnit, 0, codigo, nTroquel)

                argReceta.Items.Add(item)

            End If
        Next

        Return argReceta

    End Function

    Public Sub ParsearAutorizacion(argReceta As Receta, xml As XmlDocument)

    End Sub

End Class