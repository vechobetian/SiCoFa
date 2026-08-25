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
                    <ser:in2><![CDATA[{argXmlAdesfa}]]></ser:in2>
                </ser:enviarMensaje>
            </soapenv:Body>
        </soapenv:Envelope>"

        IO.File.WriteAllText("C:\SiCoFaFarmacias\SiCoFa.Presentacion\bin\Debug\Temp\soap_request.xml", soap)

        Dim xmlResponse As XmlDocument = PostWebservice(UrlVentaProduccion, soap)

        IO.File.WriteAllText("C:\SiCoFaFarmacias\SiCoFa.Presentacion\bin\Debug\Temp\soap_response.xml", xmlResponse.OuterXml)

        Return xmlResponse

    End Function

    Public Function ConsultaRecetasBeneficiario(argIdPC As String, argCredencial As CredencialOS, argPValidacion As ParametrosValidacion, argIdMensaje As Long) As List(Of Receta) Implements IValidador.ConsultaRecetasBeneficiario

        Throw New NotSupportedException(argPValidacion.Descripcion & " no acepta consulta de recetas por beneficiario.")

    End Function

    Private Function ConsultaRecetaElectronica(argIdPC As String, argReceta As Receta, argIdMensaje As Long) As Receta Implements IValidador.ConsultaRecetaElectronica

        Try

            Dim xmlAdesfa As String = MensajeAdesfaConsultaRecetaElectronica(argIdPC, argReceta, argIdMensaje)
            Dim xmlResponse As XmlDocument = EnviarSoap(UrlRecetaElectronicaTest, xmlAdesfa)

            VerificarRespuestaGeneral(xmlResponse)

            ParsearAutorizacion(argReceta, xmlResponse)

        Catch ex As Exception
            Throw New Exception(Funciones.MensajeError(Me.ToString, "AutorizacionReceta", ex.Message))

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

    Private Sub ParsearAutorizacion(argReceta As Receta, xml As XmlDocument)

    End Sub

    Private Sub ParsearCancelacion(argReceta As Receta, xml As XmlDocument)

    End Sub


End Class

