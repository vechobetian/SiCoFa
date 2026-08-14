Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Xml
Imports SiCoFa.Entidades
Imports Vecho

Public Class SIMED

    Implements IValidador

    Private Const VERSION_ADESFA As String = "2.0"
    Private Const NOMBRE_SOFTWARE As String = "SiCoFa"
    Private Const VERSION_SOFTWARE As String = "4.0.0"
    Private Const COD_ACCION_AUTORIZACION As String = "910100"
    Private Const COD_ACCION_CANCELACION As String = "910200"

    Private Const UrlProduccion As String = "http://transac.imed.com.ar/SwitchImed/SwitchClient.svc"
    Private Const UrlTest As String = "http://test-transac.imed.com.ar/SwitchImed/SwitchClient.svc"
    Private Const SoapAction As String = "http://www.imed.com.ar/SwitchImed/SwitchClientService/Autorizar"

    Private Function EnviarSoap(pVal As ParametrosValidacion, xmlAdesfa As String) As XmlDocument

        Dim soap As String =
        $"<?xml version=""1.0"" encoding=""UTF-8""?>
        <soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/""
                          xmlns:swit=""http://www.imed.com.ar/SwitchImed/"">
            <soapenv:Header/>
            <soapenv:Body>
                <swit:Autorizar>
                    <swit:user>{pVal.Usuario}</swit:user>
                    <swit:pass>{pVal.Licencia}</swit:pass>
                    <swit:mensaje><![CDATA[{xmlAdesfa}]]></swit:mensaje>
                </swit:Autorizar>
            </soapenv:Body>
        </soapenv:Envelope>"

        IO.File.WriteAllText("C:\SiCoFaFarmacias\SiCoFa.Presentacion\bin\Debug\Temp\soap_request.xml", soap)

        Dim xmlResponse As XmlDocument = PostWebservice(UrlProduccion, SoapAction, soap)

        IO.File.WriteAllText("C:\SiCoFaFarmacias\SiCoFa.Presentacion\bin\Debug\Temp\soap_response.xml", xmlResponse.OuterXml)

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

            Dim xmlAdesfa As String = MensajeAdesfaAutorizacion(argIdPC, argReceta, argIdMensaje, "200")
            Dim pVal As ParametrosValidacion = argReceta.Plan.OS.PValidacion
            Dim xmlResponse As XmlDocument = EnviarSoap(pVal, xmlAdesfa)

            VerificarRespuestaGeneral(xmlResponse)

            ParsearAutorizacion(argReceta, xmlResponse)

        Catch ex As Exception
            Throw New Exception(Funciones.MensajeError(Me.ToString, "AutorizacionReceta", ex.Message))

        End Try

    End Sub

    Public Sub CancelarAutorizacion(argIdPC As String, argReceta As Receta, argIdMensaje As Long) Implements IValidador.CancelarAutorizacion

        Try

            Dim xmlAdesfa As String = MensajeAdesfaCancelacion(argIdPC, argReceta, argIdMensaje, "200")
            Dim pVal As ParametrosValidacion = argReceta.Plan.OS.PValidacion
            Dim xmlResponse As XmlDocument = EnviarSoap(pVal, xmlAdesfa)

            VerificarRespuestaGeneral(xmlResponse)

            ParsearCancelacion(argReceta, xmlResponse)

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
        writer.WriteElementString("Cuit", argPValidacion.CuitPrestador)
        writer.WriteElementString("Sucursal", "1")
        writer.WriteElementString("RazonSocial", "")
        writer.WriteElementString("Codigo", argPValidacion.NumPrestador)
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
        writer.WriteElementString("Apellido", argReceta.Prescriptor.Apellido)
        writer.WriteElementString("Nombre", argReceta.Prescriptor.Nombre)
        writer.WriteElementString("TipoMatricula", argReceta.Prescriptor.Matricula.TipoMatricula.CodiTMADESFA)
        writer.WriteElementString("Provincia", argReceta.Prescriptor.Provincia.CodiP)
        writer.WriteElementString("NroMatricula", argReceta.Prescriptor.Matricula.Numero)
        writer.WriteElementString("TipoPrescriptor", argReceta.Prescriptor.TipoPrescriptor.CodiTPADESFA)
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
        writer.WriteElementString("Codigo", argReceta.Plan.OS.PValidacion.Financiador)
        writer.WriteElementString("Cuit", "")
        writer.WriteElementString("Sucursal", "")
        writer.WriteEndElement()

        writer.WriteStartElement("Credencial")
        writer.WriteElementString("cvc2", "")
        writer.WriteElementString("Numero", argReceta.Credencial.Numero)
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

        writer.WriteElementString("FechaReceta", argReceta.FechaPrescripcion.ToString("yyyyMMdd"))

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
    ' ENCABEZADO RECETA CANCELACION
    '=========================================================
    Private Sub EncabezadoRecetaAdesfaCancelacion(writer As XmlWriter, argReceta As Receta, argFechaHora As DateTime)

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
        writer.WriteElementString("cvc2", "")
        writer.WriteElementString("Numero", argReceta.Credencial.Numero)
        writer.WriteElementString("Track", "")
        writer.WriteElementString("Version", "")
        writer.WriteElementString("Vencimiento", "")
        writer.WriteElementString("ModoIngreso", "A")
        writer.WriteElementString("EsProvisorio", "")
        writer.WriteElementString("Plan", "")
        writer.WriteEndElement()

        writer.WriteElementString("FechaReceta", argReceta.FechaPrescripcion.ToString("yyyyMMdd"))

        writer.WriteStartElement("Dispensa")
        writer.WriteElementString("Fecha", argFechaHora.ToString("yyyyMMdd"))
        writer.WriteElementString("Hora", argFechaHora.ToString("HHmmss"))
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

        writer.WriteEndElement()

    End Sub

    '=========================================================
    ' DETALLE AUTORIZACION
    '=========================================================
    Private Sub DetalleRecetaAdesfaCancelacion(writer As XmlWriter, argReceta As Receta)

        writer.WriteStartElement("DetalleReceta")

        Dim nroItem As Integer = 0

        For Each i In argReceta.Items

            If i.Articulo IsNot Nothing Then
                nroItem += 1

                writer.WriteStartElement("Item")

                writer.WriteElementString("NroItem", nroItem.ToString())
                writer.WriteElementString("CodAutori", i.NumeroAutorizacionItem)
                writer.WriteElementString("CodBarras", i.CodBarras)
                writer.WriteElementString("CodTroquel", i.NTroquel)
                writer.WriteElementString("Alfabeta", i.Codigo)
                writer.WriteElementString("Kairos", "")
                writer.WriteElementString("Codigo", "")

                writer.WriteEndElement()
            End If

        Next

        writer.WriteEndElement()

    End Sub

    Private Function MensajeAdesfaAutorizacion(argIdPC As String, argReceta As Receta, argIdMensaje As Long, argTipoMensaje As String) As String

        Dim settings As New XmlWriterSettings With {.Indent = True, .OmitXmlDeclaration = True}

        Dim sb As New StringBuilder()
        Dim argFechaHora As DateTime = DateTime.Now

        Using writer As XmlWriter = XmlWriter.Create(sb, settings)

            writer.WriteStartElement("MensajeADESFA")
            'writer.WriteAttributeString("version", VERSION_ADESFA)

            EncabezadoMensajeAdesfa(writer, argReceta.Plan.OS.PValidacion, argTipoMensaje, COD_ACCION_AUTORIZACION, argIdPC, argIdMensaje, argFechaHora)

            EncabezadoRecetaAdesfaAutorziacion(writer, argReceta, argFechaHora)

            DetalleRecetaAdesfaAturizacion(writer, argReceta)

            writer.WriteEndElement()

        End Using

        Return sb.ToString()

    End Function

    Private Function MensajeAdesfaCancelacion(argIdPC As String, argReceta As Receta, argIdMensaje As Long, argTipoMensaje As String) As String

        Dim settings As New XmlWriterSettings With {.Indent = True, .OmitXmlDeclaration = True}

        Dim sb As New StringBuilder()
        Dim argFechaHora As DateTime = DateTime.Now

        Using writer As XmlWriter = XmlWriter.Create(sb, settings)

            writer.WriteStartElement("MensajeADESFA")
            writer.WriteAttributeString("version", VERSION_ADESFA)

            EncabezadoMensajeAdesfa(writer, argReceta.Plan.OS.PValidacion, argTipoMensaje, COD_ACCION_CANCELACION, argIdPC, argIdMensaje, argFechaHora)

            EncabezadoRecetaAdesfaCancelacion(writer, argReceta, argFechaHora)

            DetalleRecetaAdesfaCancelacion(writer, argReceta)

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

    Private Sub ParsearAutorizacion(argReceta As Receta, xml As XmlDocument)

    End Sub

    Private Sub ParsearCancelacion(argReceta As Receta, xml As XmlDocument)

    End Sub


End Class
