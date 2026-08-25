Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Xml
Imports SiCoFa.Entidades
Imports Vecho

Public Class COMPA

    Implements IValidador

    Private Const VERSION_ADESFA As String = "2.0"
    Private Const NOMBRE_SOFTWARE As String = "SiCoFa"
    Private Const VERSION_SOFTWARE As String = "4.0.0"
    Private Const COD_ACCION_AUTORIZACION As String = "290020"
    Private Const COD_ACCION_CANCELACION As String = "20010"

    Private Const UrlVentaProduccion As String = "http://Ia.plataformacsf.com/SaludIA/services/IAService.wsdl"
    Private Const UrlVentaTest As String = "https://qa.plataformacsf.com/SaludIA/services/IAService.wsdl"
    Private Const UrlRecetaElectronicaTest As String = "https://qa.plataformacsf.com/services/IAService"
    Private Const UrlRecetaElectronicaProduccion As String = "https://ws.farmalink.com.ar/RecetaElectSecureSvc?WSDL"

    Private Function EnviarSoap(url As String, argXmlAdesfa As String) As XmlDocument

        Dim soap As String =
        $"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" 
                            xmlns:ser=""http://service.core.ia.csf.com"">
            <soapenv:Header/>
            <soapenv:Body>
                <ser:enviarMensaje>
                    <ser:in0>sicofa</ser:in0>
                    <ser:in1>s1c0f4</ser:in1>
                    <ser:in2><![CDATA[<?xml version=""1.0"" encoding=""ISO-8859-1""?>
                        {argXmlAdesfa}]]>
                    </ser:in2>
                </ser:enviarMensaje>
            </soapenv:Body>
        </soapenv:Envelope>"

        IO.File.WriteAllText("C:\SiCoFaFarmacias\SiCoFa.Presentacion\bin\Debug\Temp\soap_request.xml", soap)

        Dim xmlResponse As XmlDocument = PostWebservice(url, soap)

        IO.File.WriteAllText("C:\SiCoFaFarmacias\SiCoFa.Presentacion\bin\Debug\Temp\soap_response.xml", xmlResponse.OuterXml)

        Return xmlResponse

    End Function

    Public Function ConsultaRecetasBeneficiario(argIdPC As String, argCredencial As CredencialOS, argPValidacion As ParametrosValidacion, argIdMensaje As Long) As List(Of Receta) Implements IValidador.ConsultaRecetasBeneficiario

        Try

            Dim xmlAdesfa As String = MensajeAdesfaConsultaRecetasBeneficiario(argIdPC, argCredencial, argPValidacion, argIdMensaje)
            Dim xmlResponse As XmlDocument = EnviarSoap(UrlRecetaElectronicaTest, xmlAdesfa)

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
            Dim xmlResponse As XmlDocument = EnviarSoap(UrlRecetaElectronicaTest, xmlAdesfa)

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
            Dim xmlResponse As XmlDocument = EnviarSoap(UrlVentaProduccion, xmlAdesfa)

            VerificarRespuestaGeneral(xmlResponse)

            ParsearAutorizacion(argReceta, xmlResponse)

        Catch ex As Exception
            Throw New Exception(Funciones.MensajeError(Me.ToString, "AutorizacionReceta", ex.Message))

        End Try

    End Sub

    Public Sub CancelarAutorizacion(argIdPC As String, argReceta As Receta, argIdMensaje As Long) Implements IValidador.CancelarAutorizacion

        Try

            Dim xmlAdesfa As String = MensajeAdesfaCancelacion(argIdPC, argReceta, argIdMensaje)
            Dim xmlResponse As XmlDocument = EnviarSoap(UrlVentaProduccion, xmlAdesfa)

            VerificarRespuestaGeneral(xmlResponse)

            ParsearCancelacion(argReceta, xmlResponse)

        Catch ex As Exception
            Throw New Exception(Funciones.MensajeError(Me.ToString, "CancelacionReceta", ex.Message))

        End Try

    End Sub

    Private Sub WriteElementStringNullSafe(writer As XmlWriter, nombre As String, valor As String)

        writer.WriteElementString(nombre, If(valor, ""))

    End Sub

    Private Function MensajeAdesfaConsultaRecetasBeneficiario(argIdPC As String, argCredencial As CredencialOS, argPValidacion As ParametrosValidacion, argIdMensaje As Long) As String

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
            writer.WriteElementString("Sucursal", "")
            writer.WriteElementString("RazonSocial", "")
            writer.WriteElementString("Codigo", argReceta.Plan.OS.PValidacion.NumPrestador)
            writer.WriteElementString("Vendedor", "")
            writer.WriteEndElement()

            writer.WriteEndElement() 'EncabezadoMensaje

            writer.WriteStartElement("EncabezadoReceta")

            writer.WriteStartElement("Financiador")
            writer.WriteElementString("CodigoADESFA", "")
            writer.WriteElementString("Codigo", argReceta.Plan.OS.PValidacion.Financiador)
            writer.WriteElementString("Cuit", "")
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
            writer.WriteElementString("Codigo", argReceta.Plan.OS.PValidacion.Financiador)
            writer.WriteElementString("Cuit", "")
            writer.WriteElementString("Sucursal", "")
            writer.WriteEndElement()

            writer.WriteStartElement("Credencial")
            WriteElementStringNullSafe(writer, "Numero", argReceta.Credencial?.Numero)
            WriteElementStringNullSafe(writer, "Track", argReceta.Credencial?.Numero)
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
            writer.WriteElementString("Vendedor", "")
            writer.WriteEndElement()

            writer.WriteEndElement() 'EncabezadoMensaje

            writer.WriteStartElement("EncabezadoReceta")

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

            writer.WriteStartElement("Financiador")
            writer.WriteElementString("Codigo", argReceta.Plan.OS.PValidacion.Financiador)
            writer.WriteElementString("Cuit", "")
            writer.WriteElementString("Sucursal", "")
            writer.WriteEndElement()

            writer.WriteStartElement("Credencial")
            WriteElementStringNullSafe(writer, "Numero", argReceta.Credencial?.Numero)
            WriteElementStringNullSafe(writer, "Track", argReceta.Credencial?.Numero)
            writer.WriteElementString("Version", "")
            writer.WriteElementString("Vencimiento", "")
            writer.WriteElementString("ModoIngreso", "A")
            writer.WriteElementString("EsProvisorio", "0")
            writer.WriteElementString("Plan", "")
            writer.WriteEndElement()

            writer.WriteElementString("FechaReceta", argReceta.FechaPrescripcion.ToString("yyyyMMdd"))

            writer.WriteStartElement("Dispensa")
            writer.WriteElementString("Fecha", argFechaHora.ToString("yyyyMMdd"))
            writer.WriteElementString("Hora", argFechaHora.ToString("HHmmss"))
            writer.WriteEndElement()

            writer.WriteEndElement() 'EncabezadoReceta

            writer.WriteStartElement("DetalleReceta")

            Dim nroItem As Integer = 0

            For Each i In argReceta.Items

                If i.Articulo IsNot Nothing Then
                    nroItem += 1

                    writer.WriteStartElement("Item")
                    writer.WriteElementString("NroItem", nroItem.ToString())
                    writer.WriteElementString("CodiAutOri", i.NumeroAutorizacionItem)
                    writer.WriteElementString("CodBarras", i.CodBarras)
                    writer.WriteElementString("CodTroquel", i.NTroquel)
                    writer.WriteElementString("Alfabeta", i.Codigo)
                    writer.WriteElementString("Kairos", "")
                    writer.WriteElementString("Codigo", "")
                    writer.WriteEndElement()

                End If

            Next

            writer.WriteEndElement() 'DetalleReceta

            writer.WriteEndElement() 'MensajeAdesfa

        End Using

        Return sb.ToString()

    End Function

    Friend Function PostWebservice(Url As String, xmlBody As String) As XmlDocument

        Try

            Dim request As HttpWebRequest = CType(WebRequest.Create(Url), HttpWebRequest)

            request.Method = "POST"
            request.ContentType = "text/xml;charset=ISO-8859-1"

            Dim data As Byte() = Encoding.GetEncoding("ISO-8859-1").GetBytes(xmlBody)

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

    Private Sub VerificarRespuestaGeneral(xml As XmlDocument)

        ' Buscar el XML ADESFA dentro de <out>
        Dim nodoOut As XmlNode = xml.SelectSingleNode("//*[local-name()='out']")

        If nodoOut Is Nothing Then
            Throw New Exception("La respuesta de Compañía no contiene el nodo 'out'.")
        End If

        Dim xmlAdesfa As New XmlDocument()

        Try
            xmlAdesfa.LoadXml(nodoOut.InnerText.Trim())
        Catch ex As Exception
            Throw New Exception("La respuesta de Compañía contiene un XML ADESFA inválido.", ex)
        End Try

        ' Obtener respuesta general
        Dim codRtaGeneral As String = xmlAdesfa.SelectSingleNode("//*[local-name()='CodRtaGeneral']")?.InnerText

        Dim descripcion As String = xmlAdesfa.SelectSingleNode("//*[local-name()='Descripcion']")?.InnerText

        Dim mensaje As String = xmlAdesfa.SelectSingleNode("//*[local-name()='Mensaje']")?.InnerText

        If String.IsNullOrWhiteSpace(codRtaGeneral) Then
            Throw New Exception("La respuesta de Compañía no contiene CodRtaGeneral.")
        End If

        If codRtaGeneral <> "0" Then

            Dim detalle As String = mensaje

            If String.IsNullOrWhiteSpace(detalle) Then
                detalle = descripcion
            End If

            If String.IsNullOrWhiteSpace(detalle) Then
                detalle = "Compañía rechazó la transacción. Código: " & codRtaGeneral
            Else
                detalle = "Código " & codRtaGeneral & ": " & detalle
            End If

            Throw New Exception(detalle)

        End If

    End Sub

    Private Function ParsearRecetasBeneficiario(xml As XmlDocument) As List(Of Receta)

        Try

            Dim recetas As New List(Of Receta)

            '==========================================================
            ' OBTENER XML ADESFA
            '
            ' Compañía devuelve:
            '
            ' SOAP
            '   └── enviarMensajeResponse
            '        └── out
            '             └── MensajeADESFA como texto
            '
            ' Si ya recibimos directamente MensajeADESFA,
            ' también lo aceptamos.
            '==========================================================

            Dim xmlAdesfa As XmlDocument = Nothing

            '----------------------------------------------------------
            ' Si el documento recibido ya es MensajeADESFA
            '----------------------------------------------------------

            If xml.DocumentElement IsNot Nothing AndAlso xml.DocumentElement.LocalName = "MensajeADESFA" Then

                xmlAdesfa = xml

            Else

                '------------------------------------------------------
                ' Buscar el nodo out dentro de la respuesta SOAP
                '------------------------------------------------------

                Dim nodoOut As XmlNode = xml.SelectSingleNode("//*[local-name()='out']")

                If nodoOut Is Nothing Then

                    Throw New Exception("La respuesta SOAP no contiene el nodo 'out'.")

                End If

                Dim contenidoAdesfa As String = nodoOut.InnerText

                If String.IsNullOrWhiteSpace(contenidoAdesfa) Then

                    Throw New Exception("El nodo 'out' de la respuesta está vacío.")

                End If

                '------------------------------------------------------
                ' Cargar el XML ADESFA contenido dentro de out
                '------------------------------------------------------

                xmlAdesfa = New XmlDocument()

                Try

                    xmlAdesfa.LoadXml(contenidoAdesfa.Trim())

                Catch ex As XmlException

                    Throw New Exception("El contenido del nodo 'out' no contiene un XML ADESFA válido. " & ex.Message)

                End Try

            End If


            '==========================================================
            ' VALIDAR MENSAJE ADESFA
            '==========================================================

            Dim mensaje As XmlNode = xmlAdesfa.SelectSingleNode("/*[local-name()='MensajeADESFA']")

            If mensaje Is Nothing Then

                Throw New Exception("La respuesta no contiene MensajeADESFA.")

            End If


            '==========================================================
            ' OBTENER LAS RECETAS
            '==========================================================

            Dim nodosRecetas As XmlNodeList = mensaje.SelectNodes("./*[local-name()='Recetas']/*[local-name()='Receta']")

            '==========================================================
            ' RECORRER RECETAS
            '==========================================================

            For Each nodo As XmlNode In nodosRecetas

                Dim receta As New Receta

                '======================================================
                ' NÚMERO DE RECETA
                '======================================================

                receta.IdReceta = nodo.SelectSingleNode("./*[local-name()='NroReceta']")?.InnerText

                '======================================================
                ' PRESCRIPTOR
                '
                ' Compañía devuelve:
                '
                ' <Prescriptor>MN 58685 DANIEL</Prescriptor>
                '
                ' En esta respuesta es un texto simple.
                '======================================================

                Dim prescriptor As String = nodo.SelectSingleNode("./*[local-name()='Prescriptor']")?.InnerText

                'No construimos un objeto Prescriptor porque esta
                'respuesta no trae los datos separados.


                '======================================================
                ' FORMULARIO
                '======================================================

                Dim formulario As XmlNode = nodo.SelectSingleNode("./*[local-name()='Formulario']")

                If formulario IsNot Nothing Then

                    '--------------------------------------------------
                    ' Número de formulario
                    '--------------------------------------------------

                    Dim numeroFormulario As String = formulario.SelectSingleNode("./*[local-name()='Numero']")?.InnerText

                    If Not String.IsNullOrWhiteSpace(numeroFormulario) Then

                        receta.NumReceta = numeroFormulario.Trim()

                    End If

                    '--------------------------------------------------
                    ' Fecha de receta
                    '
                    ' La respuesta de Compañía NO devuelve Fecha
                    ' dentro de Formulario.
                    '--------------------------------------------------

                    Dim fecha As String = formulario.SelectSingleNode("./*[local-name()='Fecha']")?.InnerText

                    If Not String.IsNullOrWhiteSpace(fecha) Then

                        Dim fechaPrescripcion As DateTime

                        If DateTime.TryParseExact(fecha.Trim(), "yyyyMMdd", Globalization.CultureInfo.InvariantCulture, Globalization.DateTimeStyles.None, fechaPrescripcion) Then

                            receta.FechaPrescripcion =
                            fechaPrescripcion

                        End If

                    End If

                End If

                '======================================================
                ' DETALLE DE LA RECETA
                '======================================================

                Dim itemsReceta As New List(Of ItemComprobante)

                Dim numItem As Integer = 0

                Dim nodosItems As XmlNodeList = nodo.SelectNodes("./*[local-name()='DetalleReceta']" & "/*[local-name()='Item']")

                For Each item As XmlNode In nodosItems

                    numItem += 1

                    '--------------------------------------------------
                    ' En Compañía el Item es texto:
                    '
                    ' Envases: 1 - FOSFO-DOM env.x 45 ml
                    '--------------------------------------------------

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


            '==========================================================
            ' RETORNAR RECETAS
            '==========================================================

            Return recetas


        Catch ex As Exception

            Throw New Exception(Funciones.MensajeError(Me.ToString, "ParsearRecetasBeneficiario", ex.Message))

        End Try

    End Function

    Private Function ParsearRecetaElectronica(argReceta As Receta, xml As XmlDocument) As Receta

        Try

            '==========================================================
            ' OBTENER XML ADESFA
            '
            ' Compañía devuelve:
            '
            ' SOAP
            '   └── enviarMensajeResponse
            '        └── out
            '             └── XML ADESFA como texto
            '
            ' Si el XmlDocument recibido ya es MensajeADESFA,
            ' también lo aceptamos directamente.
            '==========================================================

            Dim xmlAdesfa As XmlDocument = Nothing

            '----------------------------------------------------------
            ' CASO 1:
            ' El documento recibido ya es MensajeADESFA
            '----------------------------------------------------------

            If xml.DocumentElement IsNot Nothing AndAlso xml.DocumentElement.LocalName = "MensajeADESFA" Then

                xmlAdesfa = xml

            Else

                '------------------------------------------------------
                ' CASO 2:
                ' El documento recibido es la respuesta SOAP
                '------------------------------------------------------

                Dim nodoOut As XmlNode = xml.SelectSingleNode("//*[local-name()='out']")

                If nodoOut Is Nothing Then

                    Throw New Exception("La respuesta SOAP no contiene el nodo 'out'.")

                End If

                Dim contenidoAdesfa As String = nodoOut.InnerText

                If String.IsNullOrWhiteSpace(contenidoAdesfa) Then

                    Throw New Exception("El nodo 'out' de la respuesta está vacío.")

                End If

                '------------------------------------------------------
                ' Cargar el XML ADESFA contenido dentro de out
                '------------------------------------------------------

                xmlAdesfa = New XmlDocument()

                Try

                    xmlAdesfa.LoadXml(contenidoAdesfa.Trim())

                Catch ex As XmlException

                    Throw New Exception("El contenido del nodo 'out' no contiene un XML ADESFA válido. " & ex.Message)

                End Try

            End If


            '==========================================================
            ' VALIDAR MENSAJE ADESFA
            '==========================================================

            Dim nodoMensaje As XmlNode = xmlAdesfa.SelectSingleNode("/*[local-name()='MensajeADESFA']")

            If nodoMensaje Is Nothing Then

                Throw New Exception("La respuesta no contiene MensajeADESFA.")

            End If


            '==========================================================
            ' ENCABEZADO DE LA RECETA
            '==========================================================

            Dim encabezado As XmlNode = nodoMensaje.SelectSingleNode("./*[local-name()='EncabezadoReceta']")

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

                Dim nodoPrescriptor As XmlNode = encabezado.SelectSingleNode("./*[local-name()='Prescriptor']")

                If nodoPrescriptor IsNot Nothing Then

                    Dim codiTPrescriptor As String = nodoPrescriptor.SelectSingleNode("./*[local-name()='TipoPrescriptor']")?.InnerText

                    Dim tipoPrescriptor As New TipoPrescriptor(If(codiTPrescriptor, "").Trim())

                    Dim codiTM As String = nodoPrescriptor.SelectSingleNode("./*[local-name()='TipoMatricula']")?.InnerText

                    Dim nMatricula As String = nodoPrescriptor.SelectSingleNode("./*[local-name()='NroMatricula']")?.InnerText

                    Dim matricula As New Matricula(If(codiTM, "").Trim(), If(nMatricula, "").Trim())

                    Dim apellido As String = nodoPrescriptor.SelectSingleNode("./*[local-name()='Apellido']")?.InnerText

                    Dim nombre As String = nodoPrescriptor.SelectSingleNode("./*[local-name()='Nombre']")?.InnerText

                    Dim codiP As String = nodoPrescriptor.SelectSingleNode("./*[local-name()='Provincia']")?.InnerText

                    Dim provincia As New Provincia(If(codiP, "").Trim())

                    argReceta.Prescriptor = New Prescriptor(tipoPrescriptor, provincia, If(apellido, "").Trim(), If(nombre, "").Trim(), matricula)

                End If

            End If

            '==========================================================
            ' DETALLE DE LA RECETA
            '==========================================================

            argReceta.Items = New List(Of ItemComprobante)

            Dim referencias As XmlNodeList = nodoMensaje.SelectNodes("./*[local-name()='DetalleReceta']" & "/*[local-name()='ReferenciaRx']")

            For Each referencia As XmlNode In referencias


                '======================================================
                ' NÚMERO DE LÍNEA
                '======================================================

                Dim idItem As Long

                Long.TryParse(referencia.SelectSingleNode("./*[local-name()='NroLinea']")?.InnerText, idItem)

                '======================================================
                ' CANTIDAD PRESCRIPTA
                '======================================================

                Dim cantidadPrescripta As Integer

                Integer.TryParse(referencia.SelectSingleNode("./*[local-name()='CantidadPrescripta']")?.InnerText, cantidadPrescripta)

                '======================================================
                ' BUSCAR ITEM SELECCIONADO
                '======================================================

                Dim itemSeleccionado As XmlNode = Nothing

                Dim items As XmlNodeList = referencia.SelectNodes("./*[local-name()='Item']")


                For Each nodoItem As XmlNode In items

                    '--------------------------------------------------
                    ' Si todavía no tenemos ninguno, usamos el primero
                    '--------------------------------------------------

                    If itemSeleccionado Is Nothing Then

                        itemSeleccionado = nodoItem

                    End If

                    '--------------------------------------------------
                    ' Si existe un Item con Estado = 0,
                    ' tiene prioridad.
                    '--------------------------------------------------

                    Dim estado As String = nodoItem.SelectSingleNode("./*[local-name()='Estado']")?.InnerText

                    If estado IsNot Nothing AndAlso estado.Trim() = "0" Then

                        itemSeleccionado = nodoItem

                        Exit For

                    End If

                Next

                '======================================================
                ' PROCESAR ITEM
                '======================================================

                If itemSeleccionado IsNot Nothing Then

                    Dim codigo As String = ""
                    Dim idArticulo As String = ""
                    Dim codBarras As String = ""
                    Dim nTroquel As String = ""

                    '==================================================
                    ' ALFABETA
                    '
                    ' Algunos validadores devuelven Alfabeta dentro
                    ' de Item.
                    '==================================================

                    Dim alfabeta As String = itemSeleccionado.SelectSingleNode("./*[local-name()='Alfabeta']")?.InnerText

                    If Not String.IsNullOrWhiteSpace(alfabeta) Then

                        codigo = alfabeta.Trim()

                        idArticulo = "M" & codigo

                    End If

                    '==================================================
                    ' CÓDIGO DE DROGA
                    '
                    ' Compañía devuelve:
                    '
                    ' <ReferenciaRx>
                    '     <Droga>
                    '         <Codigo>10305</Codigo>
                    '     </Droga>
                    '
                    ' Si no encontramos Alfabeta, usamos este código.
                    '==================================================

                    If String.IsNullOrWhiteSpace(codigo) Then

                        Dim codigoDroga As String = referencia.SelectSingleNode("./*[local-name()='Droga']/*[local-name()='Codigo']")?.InnerText

                        If Not String.IsNullOrWhiteSpace(codigoDroga) Then

                            codigo = codigoDroga.Trim()

                        End If

                    End If

                    '==================================================
                    ' CÓDIGO DE BARRAS
                    '==================================================

                    Dim nodoCodBarras As XmlNode = itemSeleccionado.SelectSingleNode("./*[local-name()='CodBarras']")

                    If nodoCodBarras IsNot Nothing Then

                        codBarras = nodoCodBarras.InnerText.Trim()

                    End If

                    '==================================================
                    ' TROQUEL
                    '==================================================

                    Dim nodoTroquel As XmlNode = itemSeleccionado.SelectSingleNode("./*[local-name()='CodTroquel']")

                    If nodoTroquel IsNot Nothing Then

                        nTroquel = nodoTroquel.InnerText.Trim()

                    End If

                    '==================================================
                    ' DESCRIPCIÓN
                    '==================================================

                    Dim descripcion As String = ""

                    Dim nodoDescripcion As XmlNode = itemSeleccionado.SelectSingleNode("./*[local-name()='Descripcion']")

                    If nodoDescripcion IsNot Nothing Then

                        descripcion = nodoDescripcion.InnerText.Trim()

                    End If


                    '==================================================
                    ' PRECIO UNITARIO
                    '==================================================

                    Dim pUnit As Decimal = 0D

                    Dim importeUnitario As String = itemSeleccionado.SelectSingleNode("./*[local-name()='ImporteUnitario']")?.InnerText

                    If Not String.IsNullOrWhiteSpace(importeUnitario) Then

                        Decimal.TryParse(importeUnitario.Trim(), Globalization.NumberStyles.Any, Globalization.CultureInfo.InvariantCulture, pUnit)

                    End If


                    '==================================================
                    ' CREAR ITEM
                    '==================================================

                    Dim item As New ItemComprobante(idItem, idArticulo, codBarras, descripcion, 0, cantidadPrescripta, 0, 0, pUnit, 0, codigo, nTroquel)

                    argReceta.Items.Add(item)

                End If

            Next


            '==========================================================
            ' RETORNAR RECETA
            '==========================================================

            Return argReceta


        Catch ex As Exception

            Throw New Exception(Funciones.MensajeError(Me.ToString, "ParsearRecetaElectronica", ex.Message))

        End Try

    End Function

    Private Sub ParsearAutorizacion(argReceta As Receta, xml As XmlDocument)

    End Sub

    Private Sub ParsearCancelacion(argReceta As Receta, xml As XmlDocument)

    End Sub


End Class

