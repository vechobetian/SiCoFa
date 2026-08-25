Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Xml
Imports iTextSharp.text
Imports iTextSharp.text.pdf
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

            Dim xmlAdesfa As String = MensajeAdesfaConsultaRecetasBeneficiario(argIdPC, argCredencial, argPValidacion, argIdMensaje, "200")
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
                </soap:Envelope>
"

            File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Temp", "soap_request.xml"), soap)

            Dim xmlResponse As XmlDocument = PostWebservice(UrlProduccion, SoapAction, soap)

            File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Temp", "soap_request.xml"), xmlResponse.OuterXml)

            VerificarRespuestaGeneral(xmlResponse)

            Dim recetas As List(Of Receta) = ParsearRecetasBeneficiario(xmlResponse)

            Return recetas

        Catch ex As Exception
            Throw New Exception(Funciones.MensajeError(Me.ToString, "ConsultaRecetasBeneficiario", ex.Message))

        End Try

    End Function

    Private Function ConsultaRecetaElectronica(argIdPC As String, argReceta As Receta, argIdMensaje As Long) As Receta Implements IValidador.ConsultaRecetaElectronica

        Try

            Dim xmlAdesfa As String = MensajeAdesfaConsultaRecetaElectronica(argIdPC, argReceta, argIdMensaje)
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
                </soap:Envelope>
"

            File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Temp", "soap_request.xml"), soap)

            Dim xmlResponse As XmlDocument = PostWebservice(UrlProduccion, SoapAction, soap)

            File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Temp", "soap_request.xml"), xmlResponse.OuterXml)

            VerificarRespuestaGeneral(xmlResponse)

            argReceta = ParsearRecetaElectronica(argReceta, xmlResponse)

            Return argReceta

        Catch ex As Exception
            Throw New Exception(Funciones.MensajeError(Me.ToString, "ConsultaRecetaElectronica", ex.Message))

        End Try

    End Function

    Public Sub SolicitarAutorizacion1(argIdPC As String, argReceta As Receta, argIdMensaje As Long) 'Implements IValidador.SolicitarAutorizacion

        Try


            Dim rutaRespuesta As String = "C:\sicofa_cliente\Temp\RespuestaOsde.xml"

            Dim xmlResponse As New XmlDocument()

            xmlResponse.Load(rutaRespuesta)

            '========================================================
            ' FIN PRUEBA LOCAL
            '========================================================

            VerificarRespuestaGeneral(xmlResponse)

            ParsearAutorizacion(argReceta, xmlResponse)

        Catch ex As Exception

            Throw New Exception(
            Funciones.MensajeError(
                Me.ToString,
                "AutorizacionReceta",
                ex.Message
            )
        )

        End Try

    End Sub

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
                </soap:Envelope>
"

            File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Temp", "soap_request.xml"), soap)

            Dim xmlResponse As XmlDocument = PostWebservice(UrlProduccion, SoapAction, soap)

            File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Temp", "soap_request.xml"), xmlResponse.OuterXml)

            VerificarRespuestaGeneral(xmlResponse)

            ParsearAutorizacion(argReceta, xmlResponse)

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
                        <mensaje>{System.Security.SecurityElement.Escape(xmlAdesfa)}</mensaje>
                    </ProcesarXml>
                </soap:Body>
                </soap:Envelope>
"

            File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Temp", "soap_request.xml"), soap)

            Dim xmlResponse As XmlDocument = PostWebservice(UrlProduccion, SoapAction, soap)

            File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Temp", "soap_request.xml"), xmlResponse.OuterXml)

            VerificarRespuestaGeneral(xmlResponse)

        Catch ex As Exception
            Throw New Exception(Funciones.MensajeError(Me.ToString, "CancelacionReceta", ex.Message))

        End Try

    End Sub

    Private Sub WriteElementStringNullSafe(writer As XmlWriter, nombre As String, valor As String)

        writer.WriteElementString(nombre, If(valor, ""))

    End Sub

    Private Function MensajeAdesfaConsultaRecetasBeneficiario(argIdPC As String, argCredencial As CredencialOS, argPValidacion As ParametrosValidacion, argIdMensaje As Long, argTipoMensaje As String) As String

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

    Private Function MensajeAdesfaConsultaRecetaElectronica(argIdPC As String, argReceta As Receta, argIdMensaje As Long) As String

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

                    '==========================================================
                    ' GUARDAR COPIA DE LA RESPUESTA
                    ' SOLO PARA REVISIÓN / DEBUG
                    '==========================================================

                    Dim rutaRespuesta As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Temp", "soap_response.xml")

                    File.WriteAllText(rutaRespuesta, responseString, Encoding.UTF8)

                    '==========================================================
                    ' PROCESAR LA RESPUESTA EN MEMORIA
                    '==========================================================
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
            'File.WriteAllText("C:\SiCoFaFarmacias\SiCoFa.Presentacion\bin\Debug\Temp\soap_error.txt", mensaje.ToString(), Encoding.UTF8)

            File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Temp", "soap_error.txt"), mensaje.ToString(), Encoding.UTF8)

            Throw New Exception(Funciones.MensajeError(Me.ToString, "PostWebservice", mensaje.ToString()))

        Catch ex As XmlException

            Throw New Exception(Funciones.MensajeError(Me.ToString, "PostWebservice", "Error al procesar la respuesta XML:      " & ex.Message))

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

        Try

            '==========================================================
            ' NRO REFERENCIA
            ' Ejemplo:
            ' ID:2292260821-352009
            '
            ' Para la cancelación necesitamos:
            ' 352009
            '==========================================================

            Dim nroReferencia As String = xml.SelectSingleNode("//*[local-name()='NroReferencia']")?.InnerText

            If String.IsNullOrWhiteSpace(nroReferencia) Then

                Throw New Exception("La respuesta de autorización no contiene NroReferencia.")

            End If

            nroReferencia = nroReferencia.Trim()

            If nroReferencia.Length < 6 Then

                Throw New Exception("El NroReferencia recibido no tiene 6 dígitos: " & nroReferencia)

            End If

            'Guardar los 6 dígitos de la derecha
            argReceta.NumAutorizacion = nroReferencia.Substring(nroReferencia.Length - 6)


            '==========================================================
            ' REPORTE DEVUELTO POR ITC
            '==========================================================

            Dim mensajeReporte As String = xml.SelectSingleNode("//*[local-name()='Rta']/*[local-name()='Mensaje']")?.InnerText


            If Not String.IsNullOrWhiteSpace(mensajeReporte) Then
                Dim rutaTemp As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Temp")

                If Not Directory.Exists(rutaTemp) Then
                    Directory.CreateDirectory(rutaTemp)
                End If

                Dim nombreArchivo As String = argReceta.Plan.OS.PValidacion.Validador & argReceta.NumAutorizacion & ".pdf"

                Dim ruta As String = Path.Combine(rutaTemp, nombreArchivo)

                Me.GenerarPdfTicket(mensajeReporte, ruta)
            End If

            '==========================================================
            ' DETALLE DE LA RECETA
            '==========================================================

            Dim nodosItems As XmlNodeList = xml.SelectNodes("//*[local-name()='MensajeADESFA']" & "/*[local-name()='DetalleReceta']" & "/*[local-name()='Item']")

            If nodosItems Is Nothing OrElse nodosItems.Count = 0 Then

                Throw New Exception("La respuesta de autorización no contiene Items.")

            End If

            '==========================================================
            ' PROCESAR ITEMS
            '==========================================================

            For Each nodoItem As XmlNode In nodosItems

                '------------------------------------------------------
                ' NÚMERO DE ITEM
                '------------------------------------------------------

                Dim nroItemTexto As String = nodoItem.SelectSingleNode("./*[local-name()='NroItem']")?.InnerText

                Dim nroItem As Integer = 0

                Integer.TryParse(nroItemTexto, nroItem)

                '------------------------------------------------------
                ' CÓDIGO DE RESPUESTA
                '------------------------------------------------------

                Dim codRta As String = nodoItem.SelectSingleNode("./*[local-name()='CodRta']")?.InnerText

                '------------------------------------------------------
                ' MENSAJE DE RESPUESTA
                '------------------------------------------------------

                Dim mensajeRta As String = nodoItem.SelectSingleNode("./*[local-name()='MensajeRta']")?.InnerText

                '------------------------------------------------------
                ' CÓDIGO DE AUTORIZACIÓN
                '------------------------------------------------------

                Dim codAutorizacion As String = nodoItem.SelectSingleNode("./*[local-name()='CodAutorizacion']")?.InnerText

                '------------------------------------------------------
                ' CANTIDAD APROBADA
                '------------------------------------------------------

                Dim cantidadAprobadaTexto As String = nodoItem.SelectSingleNode("./*[local-name()='CantidadAprobada']")?.InnerText

                Dim cantidadAprobada As Integer = 0

                Integer.TryParse(cantidadAprobadaTexto, cantidadAprobada)

                '------------------------------------------------------
                ' PORCENTAJE DE COBERTURA
                '------------------------------------------------------

                Dim porcentajeTexto As String = nodoItem.SelectSingleNode("./*[local-name()='PorcentajeCobertura']")?.InnerText

                Dim porcentajeCobertura As Decimal = 0D

                Decimal.TryParse(porcentajeTexto, Globalization.NumberStyles.Any, Globalization.CultureInfo.InvariantCulture, porcentajeCobertura)

                '------------------------------------------------------
                ' IMPORTE UNITARIO
                '------------------------------------------------------

                Dim importeUnitarioTexto As String = nodoItem.SelectSingleNode("./*[local-name()='ImporteUnitario']")?.InnerText

                Dim importeUnitario As Decimal = 0D

                Decimal.TryParse(importeUnitarioTexto, Globalization.NumberStyles.Any, Globalization.CultureInfo.InvariantCulture, importeUnitario)

                '------------------------------------------------------
                ' IMPORTE A CARGO DEL AFILIADO
                '------------------------------------------------------

                Dim importeAfiliadoTexto As String = nodoItem.SelectSingleNode("./*[local-name()='ImporteACargoAfiliado']")?.InnerText

                Dim importeAfiliado As Decimal = 0D

                Decimal.TryParse(importeAfiliadoTexto, Globalization.NumberStyles.Any, Globalization.CultureInfo.InvariantCulture, importeAfiliado)

                '------------------------------------------------------
                ' IMPORTE DE COBERTURA
                '------------------------------------------------------

                Dim importeCoberturaTexto As String = nodoItem.SelectSingleNode("./*[local-name()='ImporteCobertura']")?.InnerText

                Dim importeCobertura As Decimal = 0D

                Decimal.TryParse(importeCoberturaTexto, Globalization.NumberStyles.Any, Globalization.CultureInfo.InvariantCulture, importeCobertura)

                '------------------------------------------------------
                ' CÓDIGO DE BARRAS
                '------------------------------------------------------

                Dim codBarras As String = nodoItem.SelectSingleNode("./*[local-name()='CodBarras']")?.InnerText

                '------------------------------------------------------
                ' TROQUEL
                '------------------------------------------------------

                Dim nTroquel As String = nodoItem.SelectSingleNode("./*[local-name()='CodTroquel']")?.InnerText

                '------------------------------------------------------
                ' ALFABETA
                '------------------------------------------------------

                Dim codigo As String = nodoItem.SelectSingleNode("./*[local-name()='Alfabeta']")?.InnerText

                If String.IsNullOrWhiteSpace(codigo) Then

                    Throw New Exception("El item Nro " & nroItem.ToString() & " no contiene código Alfabeta.")

                End If

                codigo = codigo.Trim()

                '======================================================
                ' ID ARTICULO
                '======================================================

                Dim idArticulo As String = "M" & codigo

                '======================================================
                ' BUSCAR ITEM DE LA RECETA
                '
                ' NO se busca por NroItem.
                '
                ' Se busca por IdArticulo:
                '
                ' Alfabeta 35097
                '       ↓
                ' IdArticulo M35097
                '======================================================

                Dim itemReceta As ItemComprobante = Nothing

                If argReceta.Items IsNot Nothing Then

                    itemReceta = argReceta.Items.FirstOrDefault(Function(i) i.IdArticulo = idArticulo)

                End If

                '======================================================
                ' VERIFICAR QUE EL ITEM EXISTA
                '======================================================

                If itemReceta Is Nothing Then

                    Throw New Exception("No se encontró en la receta el artículo " & idArticulo & " correspondiente al Alfabeta " & codigo)

                End If

                '======================================================
                ' VERIFICAR RESPUESTA DEL ITEM
                '======================================================

                If codRta <> "0" Then

                    Throw New Exception("Item " & nroItem.ToString() & " rechazado por ITC. Código: " & codRta & ". " & If(String.IsNullOrWhiteSpace(mensajeRta), "", mensajeRta))

                End If

                '======================================================
                ' ACTUALIZAR ITEM EXISTENTE
                '======================================================

                itemReceta.PrecioUnitario = importeUnitario

                itemReceta.PorcentajeOS = porcentajeCobertura

                itemReceta.DescuentoOS = importeCobertura

                itemReceta.Cantidad = cantidadAprobada

                itemReceta.NumeroAutorizacionItem = codAutorizacion


            Next


        Catch ex As Exception

            Throw New Exception(Funciones.MensajeError(Me.ToString, "ParsearAutorizacion", ex.Message))

        End Try

    End Sub


    Private Function FormatearMensajePuntoSalud1(rawText As String) As String
        Dim sb As New StringBuilder()

        ' 1. Normalizar y forzar saltos de línea en cada tira de guiones
        Dim texto As String = Regex.Replace(rawText, "-{5,}", vbCrLf & "----------------------------------------" & vbCrLf)

        ' 2. Insertar saltos de línea antes de cada palabra clave (Se excluyen las del bloque de firma para procesarlas en grupo)
        Dim etiquetas() As String = {
            "AUTORIZACION", "Cupón N°:", "Prestador:", "Afiliado:", "Plan:", "Tipo:",
            "Médico Receta:", "Fecha Receta :", "Fecha Receta:", "Fecha Prestación:",
            "Medicamentos", "Tipo Prescripción:", "TOTAL:", "A cargo O.S.", "A cargo Afil.",
            "TOTAL A CARGO AFIL.:", "PuntoSalud.com"
        }

        For Each etq In etiquetas
            texto = texto.Replace(etq, vbCrLf & etq)
        Next

        ' 3. Procesar el texto línea por línea
        Dim lineas() As String = texto.Split(New String() {vbCr, vbLf}, StringSplitOptions.RemoveEmptyEntries)

        For Each l As String In lineas
            Dim linea As String = l.Trim()

            ' Saltear etiquetas secundarias del bloque de firma para que no se dupliquen
            If linea.StartsWith("Firma del Titular") OrElse linea.StartsWith("Aclaración") OrElse
               linea.StartsWith("Documento Nro:") OrElse linea.StartsWith("Telf.y Direc.:") Then

                ' Marcador especial para que el generador de PDF levante el espacio físico
                If linea.StartsWith("Firma del Titular") Then
                    sb.AppendLine("[BLOQUE_FIRMA_AMPLIADO]")
                End If
                Continue For
            End If

            ' Encabezado de la tabla de medicamentos (Se escribe una sola vez)
            If linea.StartsWith("Medicamentos") Then
                sb.AppendLine("Medicamentos")
                sb.AppendLine("Can Troquel    P.Unit.  %Cob.   P.Final")
                Continue For
            End If

            ' Ignorar la línea de títulos si el WS la vuelve a enviar suelta
            If linea.StartsWith("Can Troquel") OrElse linea.StartsWith("P.Unit.") Then
                Continue For
            End If

            ' Fila de importes de troquel para CUALQUIER medicamento de la lista (1, 2, 3, etc.)
            Dim matchTroquel As Match = Regex.Match(linea, "^(\d+)\s+(\d{7})\s+(\$\d+[\d\.,]*)\s+(\d+[\d\.,]*%)\s+(\$\d+[\d\.,]*)(.*)")

            If matchTroquel.Success Then
                Dim can As String = matchTroquel.Groups(1).Value
                Dim troquel As String = matchTroquel.Groups(2).Value
                Dim pUnit As String = matchTroquel.Groups(3).Value
                Dim cob As String = matchTroquel.Groups(4).Value
                Dim pFinal As String = matchTroquel.Groups(5).Value
                Dim restoTexto As String = matchTroquel.Groups(6).Value.Trim()

                ' Imprimir valores numéricos alineados a la tabla
                Dim det As String = String.Format("{0,2} {1,-8} {2,10} {3,6} {4,10}", can, troquel, pUnit, cob, pFinal)
                sb.AppendLine(det)

                ' Imprimir el nombre del medicamento en el renglón siguiente con sangría
                If Not String.IsNullOrEmpty(restoTexto) Then
                    sb.AppendLine("    " & restoTexto)
                End If
                Continue For
            End If

            ' Formatear totales (TOTAL, A cargo O.S., A cargo Afil.)
            If linea.StartsWith("TOTAL:") OrElse linea.StartsWith("A cargo") OrElse linea.StartsWith("TOTAL A CARGO") Then
                Dim matchMonto = Regex.Match(linea, "(.*?)\s*(\$\d+[\d\.,]*)")
                If matchMonto.Success Then
                    Dim lbl As String = matchMonto.Groups(1).Value.Trim()
                    Dim val As String = matchMonto.Groups(2).Value.Trim()
                    Dim espacio As Integer = Math.Max(1, 40 - lbl.Length - val.Length)
                    sb.AppendLine(lbl & New String(" "c, espacio) & val)
                    Continue For
                End If
            End If

            ' Líneas estándar de texto plano
            sb.AppendLine(linea)
        Next

        Return sb.ToString()
    End Function

    Private Function FormatearMensajePuntoSalud(rawText As String) As String

        If String.IsNullOrWhiteSpace(rawText) Then
            Return ""
        End If

        Dim sb As New StringBuilder()

        '==============================================================
        ' NORMALIZAR TEXTO
        '==============================================================

        Dim texto As String = rawText

        texto = texto.Replace(vbCrLf, vbLf)
        texto = texto.Replace(vbCr, vbLf)
        texto = texto.Replace(ChrW(160), " "c)

        'Reducir espacios consecutivos
        texto = Regex.Replace(texto, "[ \t]+", " ")

        '==============================================================
        ' SEPARAR LAS TIRAS DE GUIONES
        '==============================================================

        texto = Regex.Replace(texto, "-{5,}", vbLf & "----------------------------------------" & vbLf)

        '==============================================================
        ' ETIQUETAS
        '
        ' Se acepta:
        '
        ' Prestador:
        ' Prestador :
        ' Prestador     :
        '
        ' y diferencias de mayúsculas/minúsculas.
        '==============================================================

        texto = Regex.Replace(texto, "(?i)\bAUTORIZACI[ÓO]N\b", vbLf & "AUTORIZACION")

        texto = Regex.Replace(texto, "(?i)\bCup[oó]n\s*(N[°ºoO]\.?|Nro\.?)?\s*:", vbLf & "Cupón N°:")

        texto = Regex.Replace(texto, "(?i)\bPrestador\s*:", vbLf & "Prestador:")

        texto = Regex.Replace(texto, "(?i)\bAfiliado\s*:", vbLf & "Afiliado:")

        texto = Regex.Replace(texto, "(?i)\bPlan\s*:", vbLf & "Plan:")

        texto = Regex.Replace(texto, "(?i)\bTipo\s*:", vbLf & "Tipo:")

        texto = Regex.Replace(texto, "(?i)\bM[ée]dico\s+Receta\s*:", vbLf & "Médico Receta:")

        texto = Regex.Replace(texto, "(?i)\bFecha\s+Receta\s*:", vbLf & "Fecha Receta:")

        texto = Regex.Replace(texto, "(?i)\bFecha\s+Prestaci[oó]n\s*:", vbLf & "Fecha Prestación:")

        texto = Regex.Replace(texto, "(?i)\bMedicamentos\b", vbLf & "Medicamentos")

        texto = Regex.Replace(texto, "(?i)\bTipo\s+Prescripci[oó]n\s*:", vbLf & "Tipo Prescripción:")

        texto = Regex.Replace(texto, "(?i)\bTOTAL\s*:", vbLf & "TOTAL:")

        texto = Regex.Replace(texto, "(?i)\bA\s+cargo\s+O\.?\s*S\.?\s*:", vbLf & "A cargo O.S.:")

        texto = Regex.Replace(texto, "(?i)\bA\s+cargo\s+Afil\.?\s*:", vbLf & "A cargo Afil.:")

        texto = Regex.Replace(texto, "(?i)\bTOTAL\s+A\s+CARGO\s+AFIL\.?\s*:", vbLf & "TOTAL A CARGO AFIL.:")

        texto = Regex.Replace(texto, "(?i)\bPuntoSalud\.com\b", vbLf & "PuntoSalud.com")

        '==============================================================
        ' BLOQUE DE FIRMA
        '==============================================================

        texto = Regex.Replace(texto, "(?i)\bFirma\s+del\s+Titular\s*:?", vbLf & "Firma del Titular")

        texto = Regex.Replace(texto, "(?i)\bAclaraci[oó]n\s*:?", vbLf & "Aclaración")

        texto = Regex.Replace(texto, "(?i)\bDocumento\s+Nro\.?\s*:?", vbLf & "Documento Nro:")

        texto = Regex.Replace(texto, "(?i)\bTelf\.?\s*y\s*Direc\.?\s*:?", vbLf & "Telf.y Direc.:")

        '==============================================================
        ' PROCESAR LÍNEAS
        '==============================================================

        Dim lineas() As String = texto.Split(New String() {vbLf}, StringSplitOptions.RemoveEmptyEntries)

        For Each l As String In lineas

            Dim linea As String = l.Trim()

            If String.IsNullOrWhiteSpace(linea) Then
                Continue For
            End If

            '==========================================================
            ' FIRMA
            '==========================================================

            If Regex.IsMatch(linea, "(?i)^Firma\s+del\s+Titular") Then

                sb.AppendLine("[BLOQUE_FIRMA_AMPLIADO]")
                Continue For

            End If

            If Regex.IsMatch(linea, "(?i)^Aclaraci[oó]n") Then

                Continue For

            End If

            If Regex.IsMatch(linea, "(?i)^Documento\s+Nro\.?") Then

                Continue For

            End If

            If Regex.IsMatch(linea, "(?i)^Telf\.?\s*y\s*Direc\.?") Then

                Continue For

            End If

            '==========================================================
            ' MEDICAMENTOS
            '==========================================================

            If Regex.IsMatch(linea, "(?i)^Medicamentos\b") Then

                sb.AppendLine("Medicamentos")
                sb.AppendLine("Can Troquel    P.Unit.  %Cob.   P.Final")

                Continue For

            End If

            '==========================================================
            ' ENCABEZADO DE COLUMNAS
            '==========================================================

            If Regex.IsMatch(linea, "(?i)^Can\s+Troquel") Then

                Continue For

            End If

            If Regex.IsMatch(linea, "(?i)^P\.?\s*Unit\.?") Then

                Continue For

            End If

            '==========================================================
            ' MEDICAMENTO
            '
            ' Ejemplo:
            '
            ' 1 1234567 $1000,00 40% $600,00 PRODUCTO
            '
            ' Los espacios son flexibles.
            '==========================================================

            Dim patronMedicamento As String = "^\s*" & "(\d+)" & "\s+" & "(\d{7})" & "\s+" & "(\$?\s*[\d\.,]+)" & "\s+" & "(\d+(?:[\.,]\d+)?\s*%)" & "\s+" & "(\$?\s*[\d\.,]+)" & "(?:\s+(.*))?" & "\s*$"
            Dim matchTroquel As Match = Regex.Match(linea, patronMedicamento, RegexOptions.IgnoreCase)

            If matchTroquel.Success Then

                Dim can As String = matchTroquel.Groups(1).Value.Trim()

                Dim troquel As String = matchTroquel.Groups(2).Value.Trim()

                Dim pUnit As String = matchTroquel.Groups(3).Value.Trim()

                Dim cob As String = matchTroquel.Groups(4).Value.Trim()

                Dim pFinal As String = matchTroquel.Groups(5).Value.Trim()

                Dim restoTexto As String = ""

                If matchTroquel.Groups.Count > 6 Then
                    restoTexto =
                    matchTroquel.Groups(6).Value.Trim()
                End If

                pUnit = Regex.Replace(pUnit, "\$\s+", "$")

                pFinal = Regex.Replace(pFinal, "\$\s+", "$")

                Dim det As String = String.Format("{0,2} {1,-8} {2,10} {3,6} {4,10}", can, troquel, pUnit, cob, pFinal)

                sb.AppendLine(det)

                If Not String.IsNullOrWhiteSpace(restoTexto) Then
                    sb.AppendLine("    " & restoTexto)
                End If

                Continue For

            End If

            '==========================================================
            ' TOTALES
            '==========================================================

            Dim esTotal As Boolean = False

            If Regex.IsMatch(linea, "(?i)^TOTAL\s*:?") Then

                esTotal = True

            ElseIf Regex.IsMatch(linea, "(?i)^A\s+cargo") Then

                esTotal = True

            End If

            If esTotal Then

                Dim matchMonto As Match = Regex.Match(linea, "^(.*?)\s*(\$?\s*[\d\.,]+)\s*$", RegexOptions.IgnoreCase)

                If matchMonto.Success Then

                    Dim lbl As String = matchMonto.Groups(1).Value.Trim()

                    Dim val As String = matchMonto.Groups(2).Value.Trim()

                    val = Regex.Replace(val, "\$\s+", "$")

                    Dim espacio As Integer = Math.Max(1, 40 - lbl.Length - val.Length)

                    sb.AppendLine(lbl & New String(" "c, espacio) & val)

                    Continue For

                End If

            End If

            '==========================================================
            ' LÍNEA NORMAL
            '==========================================================

            sb.AppendLine(linea)

        Next

        Return sb.ToString()

    End Function

    Private Sub GenerarPdfTicket(textoTicketRaw As String, rutaPdfSalida As String)
        Dim textoFormateado As String = FormatearMensajePuntoSalud(textoTicketRaw)

        ' 1. Crear documento temporal en memoria para calcular el alto exacto ocupado
        Using ms As New MemoryStream()
            Dim docMedicion As New Document(New Rectangle(226.0F, 2000.0F), 6.0F, 6.0F, 8.0F, 8.0F)
            Dim writerMedicion As PdfWriter = PdfWriter.GetInstance(docMedicion, ms)
            docMedicion.Open()

            Dim fuenteTicket As Font = FontFactory.GetFont(FontFactory.COURIER, 7.0F, Font.NORMAL, BaseColor.BLACK)

            ProcesarContenidoTicket(docMedicion, textoFormateado, fuenteTicket)

            Dim altoRequerido As Single = 2000.0F - writerMedicion.GetVerticalPosition(False) + 15.0F
            docMedicion.Close()

            ' 2. Generar el PDF definitivo en disco con la altura exacta obtenida
            Dim tamanoDefinitivo As New Rectangle(226.0F, altoRequerido)
            Dim docFinal As New Document(tamanoDefinitivo, 6.0F, 6.0F, 8.0F, 8.0F)

            Try
                PdfWriter.GetInstance(docFinal, New FileStream(rutaPdfSalida, FileMode.Create))
                docFinal.Open()
                ProcesarContenidoTicket(docFinal, textoFormateado, fuenteTicket)
            Finally
                If docFinal.IsOpen Then docFinal.Close()
            End Try
        End Using
    End Sub

    ''' <summary>
    ''' Rutina auxiliar para renderizar el contenido en el documento PDF
    ''' </summary>
    Private Sub ProcesarContenidoTicket(doc As Document, textoFormateado As String, fuente As Font)
        Using reader As New StringReader(textoFormateado)
            Dim linea As String = reader.ReadLine()

            While linea IsNot Nothing
                If linea = "[BLOQUE_FIRMA_AMPLIADO]" Then
                    doc.Add(New Paragraph("----------------------------------------", fuente) With {.Leading = 8.0F})
                    doc.Add(New Paragraph("          Firma del Titular", fuente) With {.Leading = 8.0F})

                    Dim espacioFirma As New Paragraph(" ", fuente) With {
                        .SpacingBefore = 40.0F,
                        .SpacingAfter = 5.0F
                    }
                    doc.Add(espacioFirma)

                    doc.Add(New Paragraph("----------------------------------------", fuente) With {.Leading = 8.0F})
                    doc.Add(New Paragraph("           Aclaración Firma", fuente) With {.Leading = 8.0F})

                    Dim espacioAclaracion As New Paragraph("Documento Nro:" & vbCrLf & vbCrLf & "Telf.y Direc.:", fuente) With {
                        .Leading = 16.0F,
                        .SpacingBefore = 10.0F,
                        .SpacingAfter = 10.0F
                    }
                    doc.Add(espacioAclaracion)
                Else
                    Dim p As New Paragraph(linea, fuente) With {.Leading = 8.0F}
                    doc.Add(p)
                End If

                linea = reader.ReadLine()
            End While
        End Using
    End Sub

End Class