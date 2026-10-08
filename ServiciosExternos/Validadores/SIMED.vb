Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Xml
Imports SiCoFa.Entidades
Imports Vecho

Public Class SIMED

    Implements IValidador

    Private Const NOMBRE_SOFTWARE As String = "SiCoFa"
    Private Const VERSION_SOFTWARE As String = "4.0.0"

    Private Const UrlProduccion As String = "http://transac.imed.com.ar/SwitchImed/SwitchClient.svc"
    Private Const UrlTest As String = "http://test-transac.imed.com.ar/SwitchImed/SwitchClient.svc"
    Private Const SoapAction As String = "http://www.imed.com.ar/SwitchImed/SwitchClientService/Autorizar"

    Private Function EnviarSoap(argPVal As ParametrosValidacion, argXmlAdesfa As String) As XmlDocument

        Dim soap As String =
        $"<?xml version=""1.0"" encoding=""UTF-8""?>
        <soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/""
                          xmlns:swit=""http://www.imed.com.ar/SwitchImed/"">
            <soapenv:Header/>
            <soapenv:Body>
                <swit:Autorizar>
                    <swit:user>{argPVal.Usuario}</swit:user>
                    <swit:pass>{argPVal.Licencia}</swit:pass>
                    <swit:mensaje><![CDATA[{argXmlAdesfa}]]></swit:mensaje>
                </swit:Autorizar>
            </soapenv:Body>
        </soapenv:Envelope>"

        File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Temp", "soap_request.xml"), soap)

        Dim xmlResponse As XmlDocument = PostWebservice(UrlProduccion, SoapAction, soap)

        File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Temp", "soap_response.xml"), xmlResponse.OuterXml)

        Return xmlResponse

    End Function

    Private Function LeerRespuestaAutorizacion() As XmlDocument

        Dim ruta As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Temp", "soap_response_autor.xml")

        If Not File.Exists(ruta) Then
            Throw New FileNotFoundException("No se encontró el archivo de respuesta del validador.", ruta)
        End If

        Dim xmlResponse As New XmlDocument()

        Try

            xmlResponse.Load(ruta)

        Catch ex As XmlException

            Throw New Exception("El archivo soap_response.xml no contiene un XML válido: " & ex.Message)

        End Try

        Return xmlResponse

    End Function

    Private Function LeerRespuestaCancelacion() As XmlDocument

        Dim ruta As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Temp", "soap_response_cancel.xml")

        If Not File.Exists(ruta) Then
            Throw New FileNotFoundException("No se encontró el archivo de respuesta del validador.", ruta)
        End If

        Dim xmlResponse As New XmlDocument()

        Try

            xmlResponse.Load(ruta)

        Catch ex As XmlException

            Throw New Exception("El archivo soap_response.xml no contiene un XML válido: " & ex.Message)

        End Try

        Return xmlResponse

    End Function


    Public Function ConsultaRecetasBeneficiario(argIdPC As String, argCredencial As CredencialOS, argPValidacion As ParametrosValidacion, argIdMensaje As Long) As List(Of Receta) Implements IValidador.ConsultaRecetasBeneficiario

        Throw New NotSupportedException(argPValidacion.Descripcion & " no acepta consulta de recetas por beneficiario.")

    End Function

    Private Function ConsultaRecetaElectronica(argIdPC As String, argReceta As Receta, argIdMensaje As Long) As Receta Implements IValidador.ConsultaRecetaElectronica

        Throw New NotSupportedException(argReceta.Plan.OS.PValidacion.Descripcion & " no acepta consulta de receta electronica.")

    End Function

    Public Sub SolicitarAutorizacion(argIdPC As String, argReceta As Receta, argIdMensaje As Long) Implements IValidador.SolicitarAutorizacion

        Try

            'Dim xmlAdesfa As String = MensajeAdesfaAutorizacion(argIdPC, argReceta, argIdMensaje, "200")
            'Dim pVal As ParametrosValidacion = argReceta.Plan.OS.PValidacion
            'Dim xmlResponse As XmlDocument = EnviarSoap(pVal, xmlAdesfa)

            'VerificarRespuestaGeneral(xmlResponse)

            'ParsearAutorizacion(argReceta, xmlResponse)

            Dim xmlResponse As XmlDocument = LeerRespuestaAutorizacion()

            Dim xmlAdesfa As XmlDocument = ObtenerXmlAdesfa(xmlResponse)

            VerificarRespuestaGeneral(xmlAdesfa)

            ParsearAutorizacion(argReceta, xmlAdesfa)

        Catch ex As Exception
            Throw New Exception(Funciones.MensajeError(Me.ToString, "AutorizacionReceta", ex.Message))

        End Try

    End Sub

    Public Sub CancelarAutorizacion(argIdPC As String, argReceta As Receta, argIdMensaje As Long) Implements IValidador.CancelarAutorizacion

        Try

            'Dim xmlAdesfa As String = MensajeAdesfaCancelacion(argIdPC, argReceta, argIdMensaje)
            'Dim pVal As ParametrosValidacion = argReceta.Plan.OS.PValidacion
            'Dim xmlResponse As XmlDocument = EnviarSoap(pVal, xmlAdesfa)

            'VerificarRespuestaGeneral(xmlResponse)

            'ParsearCancelacion(argReceta, xmlResponse)

            Dim xmlResponse As XmlDocument = LeerRespuestaCancelacion()

            Dim xmlAdesfa As XmlDocument = ObtenerXmlAdesfa(xmlResponse)

            VerificarRespuestaGeneral(xmlAdesfa)

            ParsearAutorizacion(argReceta, xmlAdesfa)

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
                                       argIdPC As String,
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

        writer.WriteElementString("VersionMsj", "")

        writer.WriteStartElement("Prestador")
        writer.WriteElementString("Cuit", If(argPValidacion?.CuitPrestador, ""))
        writer.WriteElementString("Sucursal", "1")
        writer.WriteElementString("RazonSocial", "")
        writer.WriteElementString("Codigo", If(argPValidacion?.NumPrestador, ""))
        writer.WriteEndElement()

        writer.WriteElementString("SetCaracteres", "")

        writer.WriteEndElement()

    End Sub

    '=========================================================
    ' ENCABEZADO RECETA AUTORIZACION
    '=========================================================
    Private Sub EncabezadoRecetaAdesfaAutorziacion(writer As XmlWriter, argReceta As Receta, argFechaHora As DateTime)

        writer.WriteStartElement("EncabezadoReceta")

        writer.WriteStartElement("Prescriptor")
        writer.WriteElementString("Apellido", If(argReceta.Prescriptor?.Apellido, ""))
        writer.WriteElementString("Nombre", If(argReceta.Prescriptor?.Nombre, ""))
        writer.WriteElementString("TipoMatricula", If(argReceta.Prescriptor?.Matricula?.TipoMatricula?.CodiTMADESFA, ""))
        writer.WriteElementString("Provincia", If(argReceta.Prescriptor?.Provincia?.CodiP, ""))
        writer.WriteElementString("NroMatricula", If(argReceta.Prescriptor?.Matricula?.Numero, ""))
        writer.WriteElementString("TipoPrescriptor", If(argReceta.Prescriptor?.TipoPrescriptor?.CodiTPADESFA, ""))
        writer.WriteElementString("Cuit", "")
        writer.WriteElementString("Especialidad", "")
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

        writer.WriteStartElement("Financiador")
        writer.WriteElementString("Codigo", If(argReceta.Plan?.OS?.PValidacion?.Financiador, ""))
        writer.WriteElementString("Cuit", "")
        writer.WriteElementString("Sucursal", "")
        writer.WriteEndElement()

        writer.WriteStartElement("Credencial")
        writer.WriteElementString("cvc2", "")
        writer.WriteElementString("Numero", If(argReceta.Credencial?.Numero, ""))
        writer.WriteElementString("Track", "")
        writer.WriteElementString("Version", "")
        writer.WriteElementString("Vencimiento", "")
        writer.WriteElementString("ModoIngreso", "A")
        writer.WriteElementString("EsProvisorio", "")
        writer.WriteElementString("Plan", "")
        writer.WriteEndElement()

        writer.WriteStartElement("Preautorizacion")
        writer.WriteElementString("Codigo", "")
        writer.WriteElementString("Fecha", "")
        writer.WriteEndElement()

        writer.WriteElementString("FechaReceta", argReceta.FechaPrescripcion.Value.ToString("yyyyMMdd"))

        writer.WriteStartElement("Dispensa")
        writer.WriteElementString("Fecha", argFechaHora.ToString("yyyyMMdd"))
        writer.WriteElementString("Hora", argFechaHora.ToString("HHmmss"))
        writer.WriteEndElement()

        writer.WriteStartElement("Formulario")
        writer.WriteElementString("NroAutEspecial", "")
        writer.WriteElementString("NroFormulario", "")
        writer.WriteElementString("Fecha", "")
        writer.WriteElementString("Tipo", "")
        writer.WriteElementString("Numero", "")
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

        writer.WriteStartElement("MedioPago")
        writer.WriteElementString("CantidadCuotas", "")
        writer.WriteElementString("MontoTrx", "")
        writer.WriteEndElement()

        writer.WriteEndElement()

    End Sub

    '=========================================================
    ' DETALLE AUTORIZACION
    '=========================================================
    Private Sub DetalleRecetaAdesfaAturizacion(writer As XmlWriter, argReceta As Receta)

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
                    writer.WriteElementString("Alfabeta", i.Codigo.ToString)
                    writer.WriteElementString("Kairos", "")
                    writer.WriteElementString("Codigo", "")
                    writer.WriteElementString("ImporteUnitario", Strings.Replace(Math.Round(i.PrecioUnitario, 2).ToString, ",", "."))
                    writer.WriteElementString("CantidadSolicitada", i.Cantidad.ToString())
                    writer.WriteElementString("PorcentajeCobertura", Strings.Replace(i.PorcentajeOS.ToString, ",", "."))
                    writer.WriteElementString("CodPreautorizacion", "")
                    writer.WriteElementString("ImporteCobertura", Strings.Replace(i.DescuentoUnitarioOS.ToString, ",", "."))
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

        End If

        writer.WriteEndElement()

    End Sub

    Private Function MensajeAdesfaAutorizacion(argIdPC As String, argReceta As Receta, argIdMensaje As Long) As String

        Dim settings As New XmlWriterSettings With {.Indent = True, .OmitXmlDeclaration = True}

        Dim sb As New StringBuilder()
        Dim argFechaHora As DateTime = DateTime.Now

        Using writer As XmlWriter = XmlWriter.Create(sb, settings)

            writer.WriteStartElement("MensajeADESFA")
            writer.WriteAttributeString("version", "2.0")

            writer.WriteStartElement("EncabezadoMensaje")

            writer.WriteElementString("TipoMsj", "200")
            writer.WriteElementString("CodAccion", "910100")
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

            writer.WriteElementString("VersionMsj", "")

            writer.WriteStartElement("Prestador")
            writer.WriteElementString("Cuit", If(argReceta.Plan.OS.PValidacion?.CuitPrestador, ""))
            writer.WriteElementString("Sucursal", "1")
            writer.WriteElementString("RazonSocial", "")
            writer.WriteElementString("Codigo", If(argReceta.Plan.OS.PValidacion?.NumPrestador, ""))
            writer.WriteEndElement()

            writer.WriteElementString("SetCaracteres", "")

            writer.WriteEndElement() 'EncabezadoMensaje

            writer.WriteStartElement("EncabezadoReceta")

            writer.WriteStartElement("Prescriptor")
            writer.WriteElementString("Apellido", If(argReceta.Prescriptor?.Apellido, ""))
            writer.WriteElementString("Nombre", If(argReceta.Prescriptor?.Nombre, ""))
            writer.WriteElementString("TipoMatricula", If(argReceta.Prescriptor?.Matricula?.TipoMatricula?.CodiTMADESFA, ""))
            writer.WriteElementString("Provincia", If(argReceta.Prescriptor?.Provincia?.CodiP, ""))
            writer.WriteElementString("NroMatricula", If(argReceta.Prescriptor?.Matricula?.Numero, ""))
            writer.WriteElementString("TipoPrescriptor", If(argReceta.Prescriptor?.TipoPrescriptor?.CodiTPADESFA, ""))
            writer.WriteElementString("Cuit", "")
            writer.WriteElementString("Especialidad", "")
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

            writer.WriteStartElement("Financiador")
            writer.WriteElementString("Codigo", If(argReceta.Plan?.OS?.PValidacion?.Financiador, ""))
            writer.WriteElementString("Cuit", "")
            writer.WriteElementString("Sucursal", "")
            writer.WriteEndElement()

            writer.WriteStartElement("Credencial")
            writer.WriteElementString("cvc2", "")
            writer.WriteElementString("Numero", If(argReceta.Credencial?.Numero, ""))
            writer.WriteElementString("Track", "")
            writer.WriteElementString("Version", "")
            writer.WriteElementString("Vencimiento", "")
            writer.WriteElementString("ModoIngreso", "A")
            writer.WriteElementString("EsProvisorio", "")
            writer.WriteElementString("Plan", "")
            writer.WriteEndElement()

            writer.WriteStartElement("Preautorizacion")
            writer.WriteElementString("Codigo", "")
            writer.WriteElementString("Fecha", "")
            writer.WriteEndElement()

            writer.WriteElementString("FechaReceta", argReceta.FechaPrescripcion.Value.ToString("yyyyMMdd"))

            writer.WriteStartElement("Dispensa")
            writer.WriteElementString("Fecha", argFechaHora.ToString("yyyyMMdd"))
            writer.WriteElementString("Hora", argFechaHora.ToString("HHmmss"))
            writer.WriteEndElement()

            writer.WriteStartElement("Formulario")
            writer.WriteElementString("NroAutEspecial", "")
            writer.WriteElementString("NroFormulario", "")
            writer.WriteElementString("Fecha", "")
            writer.WriteElementString("Tipo", "")
            writer.WriteElementString("Numero", "")
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

            writer.WriteStartElement("MedioPago")
            writer.WriteElementString("CantidadCuotas", "")
            writer.WriteElementString("MontoTrx", "")
            writer.WriteEndElement()

            writer.WriteEndElement() 'EncabezadoReceta

            writer.WriteStartElement("DetalleReceta")

            Dim nroItem As Integer = 0

            If argReceta.Items Is Nothing Then
                Return String.Empty
            End If

            For Each i In argReceta.Items

                If i.Articulo IsNot Nothing Then
                    nroItem += 1

                    writer.WriteStartElement("Item")

                    writer.WriteElementString("NroItem", nroItem.ToString())
                    writer.WriteElementString("CodBarras", i.CodBarras)
                    writer.WriteElementString("CodTroquel", i.NTroquel)
                    writer.WriteElementString("Alfabeta", i.Codigo.ToString)
                    writer.WriteElementString("Kairos", "")
                    writer.WriteElementString("Codigo", "")
                    writer.WriteElementString("ImporteUnitario", Strings.Replace(Math.Round(i.PrecioUnitario, 2).ToString, ",", "."))
                    writer.WriteElementString("CantidadSolicitada", i.Cantidad.ToString())
                    writer.WriteElementString("PorcentajeCobertura", Strings.Replace(i.PorcentajeOS.ToString, ",", "."))
                    writer.WriteElementString("CodPreautorizacion", "")
                    writer.WriteElementString("ImporteCobertura", Strings.Replace(i.DescuentoUnitarioOS.ToString, ",", "."))
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
            writer.WriteElementString("CodAccion", "910200")
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

            writer.WriteElementString("VersionMsj", "")

            writer.WriteStartElement("Prestador")
            writer.WriteElementString("Cuit", If(argReceta.Plan.OS.PValidacion?.CuitPrestador, ""))
            writer.WriteElementString("Sucursal", "1")
            writer.WriteElementString("RazonSocial", "")
            writer.WriteElementString("Codigo", If(argReceta.Plan.OS.PValidacion?.NumPrestador, ""))
            writer.WriteEndElement()

            writer.WriteElementString("SetCaracteres", "")

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
            writer.WriteElementString("Codigo", If(argReceta.Plan?.OS?.PValidacion?.Financiador, ""))
            writer.WriteElementString("Cuit", "")
            writer.WriteElementString("Sucursal", "")
            writer.WriteEndElement()

            writer.WriteStartElement("Credencial")
            writer.WriteElementString("cvc2", "")
            writer.WriteElementString("Numero", If(argReceta.Credencial?.Numero, ""))
            writer.WriteElementString("Track", "")
            writer.WriteElementString("Version", "")
            writer.WriteElementString("Vencimiento", "")
            writer.WriteElementString("ModoIngreso", "A")
            writer.WriteElementString("EsProvisorio", "")
            writer.WriteElementString("Plan", "")
            writer.WriteEndElement()

            writer.WriteElementString("FechaReceta", argReceta.FechaPrescripcion.Value.ToString("yyyyMMdd"))

            writer.WriteStartElement("Dispensa")
            writer.WriteElementString("Fecha", argFechaHora.ToString("yyyyMMdd"))
            writer.WriteElementString("Hora", argFechaHora.ToString("HHmmss"))
            writer.WriteEndElement()

            writer.WriteStartElement("MedioPago")
            writer.WriteElementString("CantidadCuotas", "")
            writer.WriteElementString("MontoTrx", "")
            writer.WriteEndElement()

            writer.WriteEndElement() 'EncabezadoReceta

            writer.WriteStartElement("DetalleReceta")

            Dim nroItem As Integer = 0

            If argReceta.Items Is Nothing Then
                Return String.Empty
            End If

            For Each i In argReceta.Items

                If i.Articulo IsNot Nothing Then
                    nroItem += 1

                    writer.WriteStartElement("Item")

                    writer.WriteElementString("NroItem", nroItem.ToString())
                    writer.WriteElementString("CodAutori", i.NumeroAutorizacionItem)
                    writer.WriteElementString("CodBarras", i.CodBarras)
                    writer.WriteElementString("CodTroquel", i.NTroquel)
                    writer.WriteElementString("Alfabeta", i.Codigo.ToString)
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

    Private Function ObtenerXmlAdesfa(xmlSoap As XmlDocument) As XmlDocument

        Dim nodoResult As XmlNode = xmlSoap.SelectSingleNode("//*[local-name()='AutorizarResult']")

        If nodoResult Is Nothing Then
            Throw New Exception("La respuesta SOAP no contiene AutorizarResult.")
        End If

        Dim xmlAdesfaTexto As String = nodoResult.InnerText.Trim()

        If String.IsNullOrWhiteSpace(xmlAdesfaTexto) Then
            Throw New Exception("AutorizarResult está vacío.")
        End If

        Dim xmlAdesfa As New XmlDocument()

        Try

            xmlAdesfa.LoadXml(xmlAdesfaTexto)

        Catch ex As XmlException
            Throw New Exception("El contenido de AutorizarResult no es un XML ADESFA válido: " &
                ex.Message)

        End Try

        Return xmlAdesfa

    End Function

    Private Sub VerificarRespuestaGeneral(xml As XmlDocument)

        Dim nodoCodRtaGeneral As XmlNode = xml.SelectSingleNode("//*[local-name()='CodRtaGeneral']")

        Dim nodoDescripcion As XmlNode = xml.SelectSingleNode("//*[local-name()='Descripcion']")

        If nodoCodRtaGeneral Is Nothing Then

            Throw New Exception("La respuesta del validador no contiene CodRtaGeneral.")

        End If

        Dim codRtaGeneral As String = nodoCodRtaGeneral.InnerText.Trim()

        Dim descripcion As String = ""

        If nodoDescripcion IsNot Nothing Then
            descripcion = nodoDescripcion.InnerText.Trim()
        End If

        ' IMED devuelve "00" cuando la transacción fue aprobada.
        If codRtaGeneral <> "00" Then

            Throw New Exception(If(String.IsNullOrWhiteSpace(descripcion), "Transacción rechazada por el validador.", descripcion))

        End If

    End Sub

    Private Sub ParsearAutorizacion(argReceta As Receta, xml As XmlDocument)

        Try

            '==========================================================
            ' NRO REFERENCIA
            '==========================================================

            Dim nroReferencia As String = xml.SelectSingleNode("//*[local-name()='NroReferencia']")?.InnerText

            If String.IsNullOrWhiteSpace(nroReferencia) Then

                Throw New Exception("La respuesta de autorización no contiene NroReferencia.")

            End If

            nroReferencia = nroReferencia.Trim()

            argReceta.NumAutorizacion = nroReferencia


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
                codRta = If(codRta, "").Trim()

                '------------------------------------------------------
                ' MENSAJE DE RESPUESTA
                '------------------------------------------------------

                Dim mensajeRta As String = nodoItem.SelectSingleNode("./*[local-name()='MensajeRta']")?.InnerText

                mensajeRta = If(mensajeRta, "").Trim()

                '------------------------------------------------------
                ' CÓDIGO DE AUTORIZACIÓN
                '------------------------------------------------------

                Dim codAutorizacion As String = nodoItem.SelectSingleNode("./*[local-name()='CodAutorizacion']")?.InnerText

                codAutorizacion = If(codAutorizacion, "").Trim()

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

                Dim tieneImporteCobertura As Boolean = Not String.IsNullOrWhiteSpace(importeCoberturaTexto)

                If tieneImporteCobertura Then

                    Decimal.TryParse(importeCoberturaTexto, Globalization.NumberStyles.Any, Globalization.CultureInfo.InvariantCulture, importeCobertura)

                End If


                '------------------------------------------------------
                ' CÓDIGO DE BARRAS
                '------------------------------------------------------

                Dim codBarras As String = nodoItem.SelectSingleNode("./*[local-name()='CodBarras']")?.InnerText

                codBarras = If(codBarras, "").Trim()


                '------------------------------------------------------
                ' TROQUEL
                '------------------------------------------------------

                Dim nTroquel As String = nodoItem.SelectSingleNode("./*[local-name()='CodTroquel']")?.InnerText

                nTroquel = If(nTroquel, "").Trim()


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
                '
                ' SIMED devuelve:
                '
                ' <CodRta>00</CodRta>
                '
                '======================================================

                If codRta <> "00" Then

                    Throw New Exception("Item " & nroItem.ToString() & " rechazado por SIMED. Código: " & codRta & ". " & If(String.IsNullOrWhiteSpace(mensajeRta), "", mensajeRta))

                End If

                '======================================================
                ' ACTUALIZAR ITEM EXISTENTE
                '======================================================

                itemReceta.PrecioUnitario = importeUnitario

                itemReceta.PorcentajeOS = porcentajeCobertura

                itemReceta.Cantidad = cantidadAprobada

                itemReceta.NumeroAutorizacionItem = codAutorizacion


                '------------------------------------------------------
                ' IMPORTANTE:
                '
                ' SIMED puede devolver ImporteCobertura vacío.
                '
                ' En ese caso NO ponemos 0 porque estaríamos
                ' pisando un valor que ya pudiera tener el item.
                '------------------------------------------------------

                If tieneImporteCobertura Then

                    itemReceta.DescuentoUnitarioOS = importeCobertura

                End If

            Next


        Catch ex As Exception

            Throw New Exception(Funciones.MensajeError(Me.ToString, "ParsearAutorizacion", ex.Message))

        End Try

End Sub


    Private Sub ParsearCancelacion(argReceta As Receta, xml As XmlDocument)

    End Sub


End Class
