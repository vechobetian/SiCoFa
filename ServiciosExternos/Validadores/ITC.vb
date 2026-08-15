Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Xml
Imports SiCoFa.Entidades
Imports Vecho

Public Class ITC

    Implements IValidador

    Private Const NOMBRE_SOFTWARE As String = "SiCoFa"
    Private Const VERSION_SOFTWARE As String = "4.0.0"

    Private Const UrlTest As String = "https://tx.itcsoluciones.ar/sitelrest/v1/txs/xml?"
    Private Const UrlProduccion As String = "http://ws.itcsoluciones.com/sitelgateway/gw.asmx"
    Private Const SoapAction As String = "http://ws.itcsoluciones.com/sitelgateway/ProcesarXml"

    Public Function ConsultaRecetasBeneficiario(argIdPC As String, argCredencial As CredencialOS, argPValidacion As ParametrosValidacion, argIdMensaje As Long) As List(Of Receta) Implements IValidador.ConsultaRecetasBeneficiario

        Try

            Dim xmlAdesfa As String = MensajeAdesfaConsultaRecetas(argIdPC, argCredencial, argPValidacion, argIdMensaje, "200")
            Dim empresa As String = Strings.Left(argPValidacion.Financiador, 2)

            Dim soap As String =
            $"<soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" 
                             xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" 
                             xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" >
                <soap:Body>
                    <ProcesarXml xmlns=""http://ws.itcsoluciones.com/sitelgateway/"">
                        <version>V251</version>
                        <empresa>{empresa}</empresa>
                        <actividad>01</actividad>
                        <licencia>{argPValidacion.Licencia}</licencia>
                        <mensaje>{System.Security.SecurityElement.Escape(xmlAdesfa)}</mensaje>
                    </ProcesarXml>
                </soap:Body>
                </soap:Envelope>"

            IO.File.WriteAllText("C:\SiCoFaFarmacias\SiCoFa.Presentacion\bin\Debug\Temp\soap_request.xml", soap)

            Dim xmlResponse As XmlDocument = PostWebservice(UrlProduccion, SoapAction, soap)

            IO.File.WriteAllText("C:\SiCoFaFarmacias\SiCoFa.Presentacion\bin\Debug\Temp\soap_response.xml", xmlResponse.OuterXml)

            VerificarRespuestaGeneral(xmlResponse)

            Dim recetas As List(Of Receta) = ParsearRecetasBeneficiario(xmlResponse)

            Return recetas

        Catch ex As Exception
            Throw New Exception(Funciones.MensajeError(Me.ToString, "ConsultaRecetasBeneficiario", ex.Message))

        End Try

    End Function

    Private Function ConsultaRecetaElectronica(argIdPC As String, argReceta As Receta, argIdMensaje As Long) As Receta Implements IValidador.ConsultaRecetaElectronica

        Try

            Dim xmlAdesfa As String = MensajeAdesfaConsultaRecetaElectronica(argIdPC, argReceta, argIdMensaje, "200")
            Dim pVal As ParametrosValidacion = argReceta.Plan.OS.PValidacion
            Dim empresa As String = Strings.Left(pVal.Financiador, 2)

            Dim soap As String =
            $"<soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" 
                             xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" 
                             xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" >
                <soap:Body>
                    <ProcesarXml xmlns=""http://ws.itcsoluciones.com/sitelgateway/"">
                        <version>V251</version>
                        <empresa>{empresa}</empresa>
                        <actividad>01</actividad>
                        <licencia>{pVal.Licencia}</licencia>
                        <mensaje>{System.Security.SecurityElement.Escape(xmlAdesfa)}</mensaje>
                    </ProcesarXml>
                </soap:Body>
                </soap:Envelope>"

            IO.File.WriteAllText("C:\SiCoFaFarmacias\SiCoFa.Presentacion\bin\Debug\Temp\soap_request.xml", soap)

            Dim xmlResponse As XmlDocument = PostWebservice(UrlProduccion, SoapAction, soap)

            IO.File.WriteAllText("C:\SiCoFaFarmacias\SiCoFa.Presentacion\bin\Debug\Temp\soap_response.xml", xmlResponse.OuterXml)

            VerificarRespuestaGeneral(xmlResponse)

            argReceta = ParsearRecetaElectronica(argReceta, xmlResponse)

            Return argReceta

        Catch ex As Exception
            Throw New Exception(Funciones.MensajeError(Me.ToString, "ConsultaRecetaElectronica", ex.Message))

        End Try

    End Function

    Public Sub SolicitarAutorizacion(argIdPC As String, argReceta As Receta, argIdMensaje As Long) Implements IValidador.SolicitarAutorizacion

        Try

            Dim xmlAdesfa As String = MensajeAdesfaAutorizacion(argIdPC, argReceta, argIdMensaje)
            Dim pVal As ParametrosValidacion = argReceta.Plan.OS.PValidacion
            Dim empresa As String = Strings.Left(pVal.Financiador, 2)

            Dim soap As String =
            $"<soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" 
                             xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" 
                             xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" >
                <soap:Body>
                    <ProcesarXml xmlns=""http://ws.itcsoluciones.com/sitelgateway/"">
                        <version>V251</version>
                        <empresa>{empresa}</empresa>
                        <actividad>01</actividad>
                        <licencia>{pVal.Licencia}</licencia>
                        <mensaje>{System.Security.SecurityElement.Escape(xmlAdesfa)}</mensaje>
                    </ProcesarXml>
                </soap:Body>
                </soap:Envelope>"

            IO.File.WriteAllText("C:\SiCoFaFarmacias\SiCoFa.Presentacion\bin\Debug\Temp\soap_request.xml", soap)

            Dim xmlResponse As XmlDocument = PostWebservice(UrlProduccion, SoapAction, soap)

            IO.File.WriteAllText("C:\SiCoFaFarmacias\SiCoFa.Presentacion\bin\Debug\Temp\soap_response.xml", xmlResponse.OuterXml)

            'argReceta = ParsearRecetaElectronica(argReceta, xmlResponse)

            'Return argReceta

        Catch ex As Exception
            Throw New Exception(Funciones.MensajeError(Me.ToString, "AutorizacionReceta", ex.Message))

        End Try

    End Sub

    Public Sub CancelarAutorizacion(argIdPC As String, argReceta As Receta, argIdMensaje As Long) Implements IValidador.CancelarAutorizacion

        Try

            Dim xmlAdesfa As String = MensajeAdesfaCancelacion(argIdPC, argReceta, argIdMensaje)
            Dim pVal As ParametrosValidacion = argReceta.Plan.OS.PValidacion
            Dim empresa As String = Strings.Left(pVal.Financiador, 2)

            Dim soap As String =
            $"<soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" 
                             xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" 
                             xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" >
                <soap:Body>
                    <ProcesarXml xmlns=""http://ws.itcsoluciones.com/sitelgateway/"">
                        <version>V251</version>
                        <empresa>{empresa}</empresa>
                        <actividad>01</actividad>
                        <licencia>{pVal.Licencia}</licencia>
                        <mensaje>{xmlAdesfa}</mensaje>
                    </ProcesarXml>
                </soap:Body>
                </soap:Envelope>"

            IO.File.WriteAllText("C:\SiCoFaFarmacias\SiCoFa.Presentacion\bin\Debug\Temp\soap_request.xml", soap)

            'Dim soapAction As String = "http://farmalink.com.ar/applicationService/V1/AutorizacionRecetaVentaSecureOutAppSvc"

            'Dim xmlResponse As XmlDocument = PostWebservice(UrlProduccion, soapAction, soap)

            'IO.File.WriteAllText("C:\SiCoFaFarmacias\SiCoFa.Presentacion\bin\Debug\Temp\soap_response.xml", xmlResponse.OuterXml)

        Catch ex As Exception
            Throw New Exception(Funciones.MensajeError(Me.ToString, "CancelacionReceta", ex.Message))

        End Try

    End Sub

    Private Sub WriteElementStringNullSafe(writer As XmlWriter, nombre As String, valor As String)

        writer.WriteElementString(nombre, If(valor, ""))

    End Sub

    Private Function MensajeAdesfaConsultaRecetas(argIdPC As String, argCredencial As CredencialOS, argPValidacion As ParametrosValidacion, argIdMensaje As Long, argTipoMensaje As String) As String

        Dim settings As New XmlWriterSettings With {
        .Indent = True,
        .OmitXmlDeclaration = True}

        Dim sb As New StringBuilder()
        Dim argFechaHora As DateTime = DateTime.Now
        Dim cuitFinanciador As String = Strings.Right(argPValidacion.Financiador, 11)

        Using writer As XmlWriter = XmlWriter.Create(sb, settings)

            writer.WriteStartElement("MensajeADESFA")
            writer.WriteAttributeString("version", "3.1.0")

            writer.WriteStartElement("EncabezadoMensaje")

            writer.WriteElementString("TipoMsj", "200")
            writer.WriteElementString("CodAccion", "490220")
            writer.WriteElementString("IdMsj", argIdMensaje.ToString())

            writer.WriteStartElement("InicioTrx")
            writer.WriteElementString("Fecha", argFechaHora.ToString("yyyyMMdd"))
            writer.WriteElementString("Hora", argFechaHora.ToString("HHmmss"))
            writer.WriteEndElement()

            writer.WriteStartElement("Software")
            writer.WriteElementString("CodigoADESFA", "")
            writer.WriteElementString("Nombre", NOMBRE_SOFTWARE)
            writer.WriteElementString("Version", VERSION_SOFTWARE)
            writer.WriteEndElement()

            writer.WriteStartElement("Validador")
            writer.WriteElementString("CodigoADESFA", "")
            writer.WriteElementString("Nombre", "")
            writer.WriteEndElement()

            writer.WriteStartElement("Prestador")
            writer.WriteElementString("CodigoADESFA", "")
            writer.WriteElementString("Cuit", argPValidacion.CuitPrestador)
            writer.WriteElementString("Codigo", argPValidacion.NumPrestador)
            writer.WriteEndElement()

            writer.WriteEndElement() 'EncabezadoMensaje

            writer.WriteStartElement("EncabezadoReceta")

            writer.WriteStartElement("Financiador")
            writer.WriteElementString("CodigoADESFA", "")
            writer.WriteElementString("Codigo", cuitFinanciador)
            writer.WriteElementString("Cuit", cuitFinanciador)
            writer.WriteEndElement()

            writer.WriteStartElement("Credencial")
            writer.WriteElementString("Numero", argCredencial.Numero)
            writer.WriteEndElement()

            writer.WriteEndElement() 'EncabezadoReceta

            writer.WriteEndElement() 'MensajeAdesfa

        End Using

        Return sb.ToString()

    End Function

    Private Function MensajeAdesfaConsultaRecetaElectronica(argIdPC As String, argReceta As Receta, argIdMensaje As Long, argTipoMensaje As String) As String

        Dim settings As New XmlWriterSettings With {
        .Indent = True,
        .OmitXmlDeclaration = True}

        Dim sb As New StringBuilder()
        Dim argFechaHora As DateTime = DateTime.Now
        Dim cuitFinanciador As String = Strings.Right(argReceta.Plan.OS.PValidacion.Financiador, 11)

        Using writer As XmlWriter = XmlWriter.Create(sb, settings)

            writer.WriteStartElement("MensajeADESFA")
            writer.WriteAttributeString("version", "3.1.0")

            writer.WriteStartElement("EncabezadoMensaje")

            writer.WriteElementString("TipoMsj", "200")
            writer.WriteElementString("CodAccion", "490120")
            writer.WriteElementString("IdMsj", argIdMensaje.ToString())

            writer.WriteStartElement("InicioTrx")
            writer.WriteElementString("Fecha", argFechaHora.ToString("yyyyMMdd"))
            writer.WriteElementString("Hora", argFechaHora.ToString("HHmmss"))
            writer.WriteEndElement()

            writer.WriteStartElement("Software")
            writer.WriteElementString("CodigoADESFA", "")
            writer.WriteElementString("Nombre", NOMBRE_SOFTWARE)
            writer.WriteElementString("Version", VERSION_SOFTWARE)
            writer.WriteEndElement()

            writer.WriteStartElement("Validador")
            writer.WriteElementString("CodigoADESFA", "")
            writer.WriteElementString("Nombre", "")
            writer.WriteEndElement()

            writer.WriteStartElement("Prestador")
            writer.WriteElementString("CodigoADESFA", "")
            writer.WriteElementString("Cuit", argReceta.Plan.OS.PValidacion.CuitPrestador)
            writer.WriteElementString("Sucursal", "1")
            writer.WriteElementString("Codigo", argReceta.Plan.OS.PValidacion.NumPrestador)
            writer.WriteElementString("Vendedor", "")
            writer.WriteEndElement()

            writer.WriteEndElement() 'EncabezadoMensaje

            writer.WriteStartElement("EncabezadoReceta")

            writer.WriteStartElement("Financiador")
            writer.WriteElementString("CodigoADESFA", "")
            writer.WriteElementString("Codigo", "0")
            writer.WriteElementString("Cuit", cuitFinanciador)
            writer.WriteElementString("Sucursal", "")
            writer.WriteEndElement()

            writer.WriteStartElement("Credencial")
            writer.WriteElementString("Numero", argReceta.Credencial.Numero)
            writer.WriteElementString("Track", "")
            writer.WriteElementString("Version", "")
            writer.WriteElementString("Vencimiento", "")
            writer.WriteElementString("ModoIngreso", "")
            writer.WriteElementString("EsProvisorio", "")
            writer.WriteElementString("Plan", "")
            writer.WriteElementString("cvc2", "")
            writer.WriteEndElement()

            writer.WriteStartElement("Formulario")
            writer.WriteElementString("Fecha", "")
            writer.WriteElementString("Tipo", "")
            writer.WriteElementString("Numero", argReceta.NumReceta)
            writer.WriteElementString("Serie", "")
            writer.WriteEndElement()

            writer.WriteEndElement() 'EncabezadoReceta

            writer.WriteEndElement() 'MensajeAdesfa
        End Using

        Return sb.ToString()

    End Function

    Private Function MensajeAdesfaAutorizacion(argIdPC As String, argReceta As Receta, argIdMensaje As Long) As String

        Dim settings As New XmlWriterSettings With {.Indent = False, .OmitXmlDeclaration = True}

        Dim sb As New StringBuilder()
        Dim argFechaHora As DateTime = DateTime.Now
        Dim cuitFinanciador As String = Strings.Right(argReceta.Plan.OS.PValidacion.Financiador, 11)

        Using writer As XmlWriter = XmlWriter.Create(sb, settings)

            writer.WriteStartElement("MensajeADESFA")
            writer.WriteAttributeString("version", "2.0")

            writer.WriteStartElement("EncabezadoMensaje")

            writer.WriteElementString("TipoMsj", "200")
            writer.WriteElementString("CodAccion", "290020")
            writer.WriteElementString("IdMsj", argIdMensaje.ToString())

            writer.WriteStartElement("InicioTrx")
            writer.WriteElementString("Fecha", argFechaHora.ToString("yyyyMMdd"))
            writer.WriteElementString("Hora", argFechaHora.ToString("HHmmss"))
            writer.WriteEndElement()

            writer.WriteStartElement("Terminal")
            writer.WriteElementString("Tipo", "PC")
            writer.WriteElementString("Numero", argIdPC)
            writer.WriteEndElement()

            writer.WriteStartElement("Software")
            writer.WriteElementString("Nombre", NOMBRE_SOFTWARE)
            writer.WriteElementString("Version", VERSION_SOFTWARE)
            writer.WriteEndElement()

            writer.WriteStartElement("Validador")
            writer.WriteElementString("Nombre", "")
            writer.WriteElementString("Version", "")
            writer.WriteEndElement()

            writer.WriteElementString("VersionMsj", "2.0")

            writer.WriteStartElement("Prestador")
            writer.WriteElementString("Cuit", argReceta.Plan.OS.PValidacion.CuitPrestador)
            writer.WriteElementString("Sucursal", "1")
            writer.WriteElementString("RazonSocial", "")
            writer.WriteElementString("Codigo", argReceta.Plan.OS.PValidacion.NumPrestador)
            writer.WriteEndElement()

            writer.WriteElementString("SetCaracteres", "")

            writer.WriteEndElement() 'EncabezadoMensaje

            writer.WriteStartElement("EncabezadoReceta")

            writer.WriteStartElement("Prescriptor")
            WriteElementStringNullSafe(writer, "Apellido", argReceta.Prescriptor?.Apellido)
            WriteElementStringNullSafe(writer, "Nombre", argReceta.Prescriptor?.Nombre)
            WriteElementStringNullSafe(writer, "TipoMatricula", argReceta.Prescriptor?.Matricula.TipoMatricula.CodiTMADESFA)
            WriteElementStringNullSafe(writer, "Provincia", argReceta.Prescriptor?.Provincia.CodiP)
            WriteElementStringNullSafe(writer, "NroMatricula", argReceta.Prescriptor?.Matricula.Numero)
            WriteElementStringNullSafe(writer, "TipoPrescriptor", argReceta.Prescriptor?.TipoPrescriptor.CodiTPADESFA)
            writer.WriteElementString("Cuit", "")
            writer.WriteElementString("Especialidad", "")
            writer.WriteEndElement()

            writer.WriteStartElement("Beneficiario")
            WriteElementStringNullSafe(writer, "TipoDoc", argReceta.Documento?.TipoDocumento?.CodiTDADESFA)
            WriteElementStringNullSafe(writer, "NroDoc", argReceta.Documento?.Numero)
            WriteElementStringNullSafe(writer, "Apellido", argReceta.Credencial?.Nombre)
            WriteElementStringNullSafe(writer, "Nombre", argReceta.Credencial?.Nombre)
            writer.WriteElementString("Sexo", "")
            writer.WriteElementString("FechaNacimiento", "")
            writer.WriteElementString("Parentesco", "")
            writer.WriteElementString("EdadUnidad", "")
            writer.WriteElementString("Edad", "")
            writer.WriteEndElement()

            writer.WriteStartElement("Financiador")
            writer.WriteElementString("Codigo", "")
            writer.WriteElementString("Cuit", cuitFinanciador)
            writer.WriteElementString("Sucursal", "")
            writer.WriteEndElement()

            writer.WriteStartElement("Credencial")
            WriteElementStringNullSafe(writer, "Numero", argReceta.Credencial?.Numero)
            WriteElementStringNullSafe(writer, "Track", argReceta.Credencial?.Numero)
            WriteElementStringNullSafe(writer, "CSC", argReceta.Credencial?.Token)
            writer.WriteElementString("Version", "")
            writer.WriteElementString("Vencimiento", "")
            writer.WriteElementString("ModoIngreso", "A")
            writer.WriteElementString("EsProvisorio", "0")
            writer.WriteElementString("Plan", "")
            WriteElementStringNullSafe(writer, "cvc2", argReceta.Credencial?.Token)
            writer.WriteEndElement()

            writer.WriteElementString("CoberturaEspecial", "")

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
            writer.WriteElementString("Tipo", "")
            writer.WriteElementString("Numero", argReceta.NumReceta)
            writer.WriteElementString("Serie", "")
            writer.WriteEndElement()

            writer.WriteElementString("TipoTratamiento", argReceta.Tratamiento)
            writer.WriteElementString("Diagnostico", "")

            writer.WriteStartElement("Institucion")
            writer.WriteElementString("Codigo", "")
            writer.WriteElementString("Cuit", "")
            writer.WriteElementString("Sucursal", "")
            writer.WriteEndElement()

            writer.WriteStartElement("Retira")
            writer.WriteElementString("Apellido", "")
            writer.WriteElementString("Nombre", "")
            writer.WriteElementString("TipoDoc", "")
            writer.WriteElementString("NroDoc", "")
            writer.WriteElementString("NroTelefono", "")
            writer.WriteEndElement()

            writer.WriteEndElement() 'EncabezadoReceta

            writer.WriteStartElement("DetalleReceta")

            Dim nroItem As Integer = 0

            For Each i In argReceta.Items

                If i.Articulo IsNot Nothing Then
                    nroItem += 1

                    writer.WriteStartElement("Item")
                    writer.WriteElementString("NroItem", nroItem.ToString())
                    writer.WriteElementString("CodBarras", i.CodBarras)
                    writer.WriteElementString("CodTroquel", i.NTroquel)
                    writer.WriteElementString("Alfabeta", i.Codigo)
                    writer.WriteElementString("Kairos", "")
                    writer.WriteElementString("Codigo", "")
                    writer.WriteElementString("ImporteUnitario", Strings.Replace(Math.Round(i.PrecioUnitario, 2), ",", "."))
                    writer.WriteElementString("CantidadSolicitada", i.Cantidad.ToString())
                    writer.WriteElementString("PorcentajeCobertura", Strings.Replace(i.PorcentajeOS, ",", "."))
                    writer.WriteElementString("CodPreautorizacion", "")
                    writer.WriteElementString("ImporteCobertura", Strings.Replace(i.DescuentoOS, ",", "."))
                    writer.WriteElementString("ExcepcionPrescripcion", "")
                    writer.WriteElementString("Diagnostico", "")
                    writer.WriteElementString("DosisDiaria", "")
                    writer.WriteElementString("DiasTratamiento", "")
                    writer.WriteElementString("Generico", "")
                    writer.WriteElementString("CodConflicto", "")
                    writer.WriteElementString("CodIntervencion", "")
                    writer.WriteElementString("CodAccion", "")
                    writer.WriteEndElement()

                End If

            Next

            writer.WriteEndElement() 'DetalleReceta

            writer.WriteEndElement() 'MensajeAdesfa

        End Using

        Return sb.ToString()

    End Function

    Private Function MensajeAdesfaCancelacion(argIdPC As String, argReceta As Receta, argIdMensaje As Long) As String

        Dim settings As New XmlWriterSettings With {.Indent = True, .OmitXmlDeclaration = True}

        Dim sb As New StringBuilder()
        Dim argFechaHora As DateTime = DateTime.Now
        Dim cuitFinanciador As String = Strings.Right(argReceta.Plan.OS.PValidacion.Financiador, 11)

        Using writer As XmlWriter = XmlWriter.Create(sb, settings)

            writer.WriteStartElement("MensajeADESFA")
            writer.WriteAttributeString("version", "2.0")

            writer.WriteStartElement("EncabezadoMensaje")

            writer.WriteElementString("NroReferencia", argReceta.NumAutorizacion)
            writer.WriteElementString("TipoMsj", "200")
            writer.WriteElementString("CodAccion", "020010")
            writer.WriteElementString("IdMsj", argIdMensaje.ToString())

            writer.WriteStartElement("InicioTrx")
            writer.WriteElementString("Fecha", argFechaHora.ToString("yyyyMMdd"))
            writer.WriteElementString("Hora", argFechaHora.ToString("HHmmss"))
            writer.WriteEndElement()

            writer.WriteStartElement("Terminal")
            writer.WriteElementString("Tipo", "PC")
            writer.WriteElementString("Numero", argIdPC)
            writer.WriteEndElement()

            writer.WriteStartElement("Software")
            writer.WriteElementString("Nombre", NOMBRE_SOFTWARE)
            writer.WriteElementString("Version", VERSION_SOFTWARE)
            writer.WriteEndElement()

            writer.WriteStartElement("Prestador")
            writer.WriteElementString("Cuit", argReceta.Plan.OS.PValidacion.CuitPrestador)
            writer.WriteElementString("Sucursal", "1")
            writer.WriteElementString("RazonSocial", "")
            writer.WriteEndElement()

            writer.WriteEndElement() 'EncabezadoMensaje

            writer.WriteStartElement("EncabezadoReceta")

            writer.WriteStartElement("Prescriptor")
            writer.WriteElementString("Apellido", "")
            writer.WriteElementString("Nombre", "")
            writer.WriteElementString("TipoMatricula", argReceta.Prescriptor.Matricula.TipoMatricula.CodiTMADESFA)
            writer.WriteElementString("Provincia", argReceta.Prescriptor.Provincia.CodiP)
            writer.WriteElementString("NroMatricula", argReceta.Prescriptor.Matricula.Numero)
            writer.WriteElementString("TipoPrescriptor", argReceta.Prescriptor.TipoPrescriptor.CodiTPADESFA)
            writer.WriteElementString("Cuit", "")
            writer.WriteEndElement()

            writer.WriteStartElement("Beneficiario")
            writer.WriteEndElement()

            writer.WriteStartElement("Financiador")
            writer.WriteElementString("Cuit", cuitFinanciador)
            writer.WriteEndElement()

            writer.WriteStartElement("Credencial")
            writer.WriteElementString("Track", argReceta.Credencial.Numero)
            writer.WriteElementString("ModoIngreso", "A")
            writer.WriteEndElement()

            writer.WriteElementString("FechaReceta", argReceta.FechaPrescripcion.ToString("yyyyMMdd"))

            writer.WriteStartElement("Dispensa")
            writer.WriteElementString("Fecha", argFechaHora.ToString("yyyyMMdd"))
            writer.WriteElementString("Hora", argFechaHora.ToString("HHmmss"))
            writer.WriteEndElement()

            writer.WriteEndElement() 'EncabezadoReceta

            writer.WriteEndElement() 'MensajeAdesfa

        End Using

        Return sb.ToString()

    End Function
    Friend Function PostWebservice(Url As String, soapAction As String, xmlBody As String) As XmlDocument

        Try

            '==========================================================
            ' CREAR SOLICITUD HTTP
            '==========================================================

            Dim request As HttpWebRequest = CType(WebRequest.Create(Url), HttpWebRequest)

            request.Method = "POST"

            ' SOAP 1.1
            request.ProtocolVersion = HttpVersion.Version11

            ' Evitar problemas de conexión persistente
            request.KeepAlive = False

            ' Headers
            request.ContentType = "text/xml; charset=utf-8"
            request.Accept = "text/xml"

            ' SOAPAction debe enviarse entre comillas
            request.Headers.Add("SOAPAction", """" & soapAction & """")

            '==========================================================
            ' GUARDAR EL XML EXACTO QUE SE ENVÍA
            '==========================================================

            IO.File.WriteAllText("C:\SiCoFaFarmacias\SiCoFa.Presentacion\bin\Debug\Temp\soap_request_enviado.xml", xmlBody, Encoding.UTF8)

            '==========================================================
            ' CONVERTIR XML A BYTES
            '==========================================================

            Dim data As Byte() = Encoding.UTF8.GetBytes(xmlBody)

            request.ContentLength = data.Length

            '==========================================================
            ' ENVIAR
            '==========================================================

            Using stream As Stream = request.GetRequestStream()

                stream.Write(data, 0, data.Length)

            End Using

            '==========================================================
            ' RECIBIR RESPUESTA
            '==========================================================

            Using response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)

                Using reader As New StreamReader(response.GetResponseStream(), Encoding.UTF8)

                    Dim responseString As String = reader.ReadToEnd()

                    ' Guardar respuesta
                    IO.File.WriteAllText("C:\SiCoFaFarmacias\SiCoFa.Presentacion\bin\Debug\Temp\soap_response.xml", responseString, Encoding.UTF8)

                    ' Convertir respuesta a XML
                    Dim xmlResponse As New XmlDocument()

                    xmlResponse.LoadXml(responseString)

                    Return xmlResponse

                End Using

            End Using


        Catch ex As WebException

            '==========================================================
            ' ERROR HTTP
            '==========================================================

            Dim mensaje As New StringBuilder()

            mensaje.AppendLine("ERROR WEB SERVICE ITC")
            mensaje.AppendLine("----------------------------------------")

            mensaje.AppendLine("URL:")
            mensaje.AppendLine(Url)
            mensaje.AppendLine()

            mensaje.AppendLine("SOAPAction:")
            mensaje.AppendLine(soapAction)
            mensaje.AppendLine()

            mensaje.AppendLine("WebException:")
            mensaje.AppendLine(ex.Message)
            mensaje.AppendLine()

            If ex.Response IsNot Nothing Then

                Dim response As HttpWebResponse =
                CType(ex.Response, HttpWebResponse)

                mensaje.AppendLine("HTTP STATUS:")
                mensaje.AppendLine(
                CInt(response.StatusCode).ToString() &
                " - " &
                response.StatusDescription)

                mensaje.AppendLine()

                mensaje.AppendLine("HEADERS:")
                mensaje.AppendLine(
                response.Headers.ToString())

                mensaje.AppendLine()

                mensaje.AppendLine("RESPUESTA DEL SERVIDOR:")
                mensaje.AppendLine()

                Using reader As New StreamReader(
                response.GetResponseStream())

                    Dim serverError As String =
                    reader.ReadToEnd()

                    mensaje.AppendLine(serverError)

                End Using

            Else

                mensaje.AppendLine("ITC NO DEVOLVIÓ RESPUESTA HTTP.")

            End If

            ' Guardar error completo
            IO.File.WriteAllText("C:\SiCoFaFarmacias\SiCoFa.Presentacion\bin\Debug\Temp\soap_error.txt", mensaje.ToString(), Encoding.UTF8)

            Throw New Exception(Funciones.MensajeError(Me.ToString, "PostWebservice", mensaje.ToString()))

        Catch ex As XmlException

            Throw New Exception(Funciones.MensajeError(Me.ToString, "PostWebservice", "Error al procesar la respuesta XML: " & ex.Message))

        Catch ex As Exception

            Throw New Exception(Funciones.MensajeError(Me.ToString, "PostWebservice", ex.ToString()))

        End Try

    End Function

    Private Sub VerificarRespuestaGeneral(xml As XmlDocument)

        Dim codRtaGeneralTexto As String = xml.SelectSingleNode("//*[local-name()='CodRtaGeneral']")?.InnerText

        Dim descripcion As String = xml.SelectSingleNode("//*[local-name()='Descripcion']")?.InnerText

        If String.IsNullOrWhiteSpace(codRtaGeneralTexto) Then
            Throw New Exception("La respuesta del validador no contiene CodRtaGeneral.")
        End If

        Dim codRtaGeneral As Integer

        If Not Integer.TryParse(codRtaGeneralTexto, codRtaGeneral) Then
            Throw New Exception("El CodRtaGeneral recibido no es numérico: " & codRtaGeneralTexto)
        End If

        If codRtaGeneral <> 0 Then
            Throw New Exception(If(String.IsNullOrWhiteSpace(descripcion), "El validador devolvió código de error " & codRtaGeneralTexto, descripcion))
        End If

    End Sub

    Private Function ParsearRecetasBeneficiario(xml As XmlDocument) As List(Of Receta)

        Dim recetas As New List(Of Receta)

        '==========================================================
        ' OBTENER LAS RECETAS
        '==========================================================

        Dim nodosRecetas As XmlNodeList = xml.SelectNodes("//*[local-name()='MensajeADESFA']/*[local-name()='Recetas']/*[local-name()='Receta']")

        '==========================================================
        ' RECORRER RECETAS
        '==========================================================

        For Each nodo As XmlNode In nodosRecetas

            Dim receta As New Receta

            '======================================================
            ' NÚMERO DE RECETA
            '======================================================

            receta.IdReceta = nodo.SelectSingleNode("*[local-name()='NroReceta']")?.InnerText


            '======================================================
            ' FORMULARIO
            '======================================================

            Dim formulario As XmlNode = nodo.SelectSingleNode("*[local-name()='Formulario']")

            If formulario IsNot Nothing Then

                '----------------------------------------------
                ' Número de formulario
                '----------------------------------------------

                receta.NumReceta = formulario.SelectSingleNode("*[local-name()='Numero']")?.InnerText


                '----------------------------------------------
                ' Fecha de receta
                '----------------------------------------------

                Dim fecha As String = formulario.SelectSingleNode("*[local-name()='Fecha']")?.InnerText

                If Not String.IsNullOrWhiteSpace(fecha) Then

                    Dim fechaPrescripcion As DateTime

                    If DateTime.TryParseExact(fecha, "yyyyMMdd", Globalization.CultureInfo.InvariantCulture, Globalization.DateTimeStyles.None, fechaPrescripcion) Then

                        receta.FechaPrescripcion = fechaPrescripcion

                    End If

                End If

            End If

            '======================================================
            ' DETALLE DE LA RECETA
            '======================================================

            Dim itemsReceta As New List(Of ItemComprobante)

            Dim numItem As Integer = 0

            Dim nodosItems As XmlNodeList = nodo.SelectNodes("*[local-name()='DetalleReceta']/*[local-name()='Item']")

            For Each item As XmlNode In nodosItems

                numItem += 1

                Dim descripcion As String = item.InnerText.Trim()

                Dim itemReceta As New ItemComprobante(numItem, "", "", descripcion, 0, 1, 0, 1, 1, 0, 0)

                itemsReceta.Add(itemReceta)

            Next

            '======================================================
            ' ASIGNAR ITEMS
            '======================================================

            receta.Items = itemsReceta

            '======================================================
            ' AGREGAR RECETA
            '======================================================

            recetas.Add(receta)

        Next

        Return recetas

    End Function

    Private Function ParsearRecetaElectronica(argReceta As Receta, xml As XmlDocument) As Receta

        Try

            '==========================================================
            ' ENCABEZADO DE LA RECETA
            '==========================================================

            Dim encabezado As XmlNode = xml.SelectSingleNode("//*[local-name()='MensajeADESFA']/*[local-name()='EncabezadoReceta']")

            If encabezado Is Nothing Then
                Throw New Exception("La respuesta no contiene EncabezadoReceta.")
            End If

            '==========================================================
            ' FECHA DE RECETA
            '==========================================================

            Dim fecha As String = encabezado.SelectSingleNode("./*[local-name()='FechaReceta']")?.InnerText

            If Not String.IsNullOrWhiteSpace(fecha) Then

                Dim fechaPrescripcion As DateTime

                If DateTime.TryParseExact(fecha.Trim(), "yyyyMMdd", Globalization.CultureInfo.InvariantCulture, Globalization.DateTimeStyles.None, fechaPrescripcion) Then

                    argReceta.FechaPrescripcion = fechaPrescripcion

                End If

            End If

            '==========================================================
            ' NÚMERO DE RECETA
            '==========================================================

            argReceta.NumReceta = encabezado.SelectSingleNode("./*[local-name()='Formulario']/*[local-name()='Numero']")?.InnerText

            '==========================================================
            ' TIPO DE TRATAMIENTO
            '==========================================================

            argReceta.Tratamiento = encabezado.SelectSingleNode("./*[local-name()='TipoTratamiento']")?.InnerText


            '==========================================================
            ' PRESCRIPTOR
            '==========================================================

            If argReceta.Prescriptor Is Nothing Then

                Dim codiTPrescriptor As String = encabezado.SelectSingleNode("./*[local-name()='Prescriptor']/*[local-name()='TipoPrescriptor']")?.InnerText

                Dim tipoPrescriptor As New TipoPrescriptor(codiTPrescriptor)

                Dim codiTM As String = encabezado.SelectSingleNode("./*[local-name()='Prescriptor']/*[local-name()='TipoMatricula']")?.InnerText

                Dim nMatricula As String = encabezado.SelectSingleNode("./*[local-name()='Prescriptor']/*[local-name()='NroMatricula']")?.InnerText

                Dim matricula As New Matricula(codiTM, nMatricula)

                Dim apellido As String = encabezado.SelectSingleNode("./*[local-name()='Prescriptor']/*[local-name()='Apellido']")?.InnerText

                Dim nombre As String = encabezado.SelectSingleNode("./*[local-name()='Prescriptor']/*[local-name()='Nombre']")?.InnerText

                Dim codiP As String = encabezado.SelectSingleNode("./*[local-name()='Prescriptor']/*[local-name()='Provincia']")?.InnerText

                Dim provincia As New Provincia(codiP)

                argReceta.Prescriptor = New Prescriptor(tipoPrescriptor, provincia, apellido, nombre, matricula)

            End If

            '==========================================================
            ' DETALLE DE LA RECETA
            '==========================================================

            argReceta.Items = New List(Of ItemComprobante)

            Dim referencias As XmlNodeList = xml.SelectNodes("//*[local-name()='MensajeADESFA']" & "/*[local-name()='DetalleReceta']" & "/*[local-name()='ReferenciaRx']")

            For Each referencia As XmlNode In referencias

                '------------------------------------------------------
                ' NÚMERO DE LÍNEA
                '------------------------------------------------------

                Dim idItem As Long

                Long.TryParse(referencia.SelectSingleNode("./*[local-name()='NroLinea']")?.InnerText, idItem)

                '------------------------------------------------------
                ' CANTIDAD PRESCRIPTA
                '------------------------------------------------------

                Dim cantidadPrescripta As Integer

                Integer.TryParse(referencia.SelectSingleNode("./*[local-name()='CantidadPrescripta']")?.InnerText, cantidadPrescripta)

                '------------------------------------------------------
                ' BUSCAR EL ITEM SELECCIONADO
                '------------------------------------------------------

                Dim itemSeleccionado As XmlNode = Nothing

                Dim items As XmlNodeList = referencia.SelectNodes("./*[local-name()='Item']")

                For Each nodoItem As XmlNode In items

                    'Primero guardamos el primero
                    If itemSeleccionado Is Nothing Then
                        itemSeleccionado = nodoItem
                    End If

                    'Si hay uno autorizado/seleccionado,
                    'Estado = 1 tiene prioridad
                    Dim estado As String = nodoItem.SelectSingleNode("./*[local-name()='Estado']")?.InnerText

                    If estado = "0" Then
                        itemSeleccionado = nodoItem
                        Exit For
                    End If

                Next

                '------------------------------------------------------
                ' PROCESAR ITEM
                '------------------------------------------------------

                If itemSeleccionado IsNot Nothing Then

                    Dim codigo As String = ""
                    Dim idArticulo As String = ""
                    Dim codBarras As String = ""
                    Dim nTroquel As String = ""

                    '==================================================
                    ' ALFABETA
                    '==================================================

                    Dim alfabeta As String = itemSeleccionado.SelectSingleNode("./*[local-name()='Alfabeta']")?.InnerText

                    If Not String.IsNullOrWhiteSpace(alfabeta) Then

                        codigo = alfabeta.Trim()

                        idArticulo = "M" & codigo

                    End If

                    '==================================================
                    ' CÓDIGO DE BARRAS
                    '==================================================

                    codBarras = itemSeleccionado.SelectSingleNode("./*[local-name()='CodBarras']")?.InnerText

                    '==================================================
                    ' TROQUEL
                    '==================================================

                    nTroquel = itemSeleccionado.SelectSingleNode("./*[local-name()='CodTroquel']")?.InnerText

                    '==================================================
                    ' DESCRIPCIÓN
                    '==================================================

                    Dim descripcion As String = itemSeleccionado.SelectSingleNode("./*[local-name()='Descripcion']")?.InnerText

                    '==================================================
                    ' PRECIO UNITARIO
                    '==================================================

                    Dim pUnit As Decimal = 0D

                    Decimal.TryParse(itemSeleccionado.SelectSingleNode("./*[local-name()='ImporteUnitario']")?.InnerText, Globalization.NumberStyles.Any, Globalization.CultureInfo.InvariantCulture, pUnit)

                    '==================================================
                    ' CREAR ITEM
                    '==================================================

                    Dim item As New ItemComprobante(idItem, idArticulo, codBarras, If(descripcion, "").Trim(), 0, cantidadPrescripta, 0, 0, pUnit, 0, codigo, nTroquel)

                    argReceta.Items.Add(item)

                End If

            Next

            Return argReceta


        Catch ex As Exception

            Throw New Exception(Funciones.MensajeError(Me.ToString, "ParsearRecetaElectronica", ex.Message))

        End Try

    End Function
    Private Sub ParsearAutorizacion(argReceta As Receta, xml As XmlDocument)

    End Sub

End Class
