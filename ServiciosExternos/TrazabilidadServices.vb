Imports System.Collections.Generic
Imports System.Net.Http
Imports System.Threading.Tasks
Imports System.Xml.Linq
Imports Org.BouncyCastle.Asn1
Imports SiCoFa.Entidades

Public Class TrazabilidadServices

    Private Const MstrUrl As String = "https://trazabilidad.pami.org.ar:9050/trazamed.WebService"

    ' Cabecera SOAP fija con las credenciales de sistema de PAMI (idéntico a VB6)
    Private ReadOnly _soapHead As String =
        "<soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">" &
            "<soap:Header>" &
                "<wsse:Security soap:mustUnderstand=""1"" xmlns:wsse=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"">" &
                    "<wsse:UsernameToken wsu:Id=""UsernameToken-2"" xmlns:wsu=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"">" &
                        "<wsse:Username>testwservice</wsse:Username>" &
                        "<wsse:Password Type=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText"">testwservicepsw</wsse:Password>" &
                    "</wsse:UsernameToken>" &
                "</wsse:Security>" &
            "</soap:Header>" &
            "<soap:Body>"

    Private ReadOnly _soapFoot As String =
            "</soap:Body>" &
        "</soap:Envelope>"

    Public Property EsError As Boolean
    Public Property CodigoError As Integer
    Public Property DescripcionError As String

    Private Async Function EjecutarSoapAsync(cuerpoSoap As String, soapAction As String) As Task(Of XDocument)
        Dim soapXml As String = _soapHead & cuerpoSoap & _soapFoot

        System.Net.ServicePointManager.Expect100Continue = False
        System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12 Or System.Net.SecurityProtocolType.Tls11 Or System.Net.SecurityProtocolType.Tls

        Using handler As New HttpClientHandler()
            handler.UseProxy = True
            handler.Proxy = System.Net.WebRequest.GetSystemWebProxy()

            Using client As New HttpClient(handler)
                client.DefaultRequestHeaders.UserAgent.ParseAdd("MSXML")

                Dim encodingAnsi As System.Text.Encoding = System.Text.Encoding.GetEncoding(1252)
                Dim bytes = encodingAnsi.GetBytes(soapXml)

                Dim content As New System.Net.Http.ByteArrayContent(bytes)
                content.Headers.ContentType = New System.Net.Http.Headers.MediaTypeHeaderValue("text/xml")
                content.Headers.ContentType.CharSet = "ISO-8859-1"

                ' Asignamos el SOAPAction dinámico correspondiente al método que se está ejecutando
                content.Headers.Add("SOAPAction", soapAction)

                Dim response = Await client.PostAsync(MstrUrl, content)
                Dim respuestaStr = Await response.Content.ReadAsStringAsync()

                If Not response.IsSuccessStatusCode Then
                    Me.EsError = True
                    Me.CodigoError = CInt(response.StatusCode)
                    Me.DescripcionError = "Error en servidor PAMI (HTTP 500): " & respuestaStr
                    Return Nothing
                End If

                Dim doc = XDocument.Parse(respuestaStr)
                ValidarErroresXml(doc)
                Return doc
            End Using
        End Using
    End Function

    Private Sub ValidarErroresXml(doc As XDocument)
        EsError = False
        CodigoError = 0
        DescripcionError = String.Empty

        Dim resultadoNode = doc.Descendants().FirstOrDefault(Function(e) e.Name.LocalName = "resultado")
        If resultadoNode IsNot Nothing AndAlso resultadoNode.Value.ToLower() = "false" Then
            EsError = True
            Dim errorNode = doc.Descendants().FirstOrDefault(Function(e) e.Name.LocalName = "errores")
            If errorNode IsNot Nothing Then
                CodigoError = CInt(If(errorNode.Elements().FirstOrDefault(Function(e) e.Name.LocalName = "_c_error")?.Value, "0"))
                DescripcionError = errorNode.Elements().FirstOrDefault(Function(e) e.Name.LocalName = "_d_error")?.Value
            End If
        End If
    End Sub

    Public Async Function TransaccionesNoConfirmadasAsync(argUsuario As String, argContrasena As String, argGln As String, argDesde As String, argHasta As String) As Task(Of List(Of TransaccionTrazabilidad))
        Dim cuerpo =
            "<ns1:getTransaccionesNoConfirmadas xmlns:ns1=""http://business.mywebservice.inssjp.com/"">" &
                $"<arg0>{argUsuario}</arg0>" &
                $"<arg1>{argContrasena}</arg1>" &
                "<arg2></arg2><arg3></arg3><arg4></arg4>" &
                $"<arg5>{argGln}</arg5>" &
                "<arg6></arg6><arg7></arg7>" &
                $"<arg8>{argDesde}</arg8>" &
                $"<arg9>{argHasta}</arg9>" &
                "<arg10></arg10><arg11></arg11><arg12></arg12><arg13></arg13><arg14></arg14><arg15></arg15><arg16></arg16><arg17></arg17><arg18></arg18><arg19></arg19><arg21></arg21>" &
            "</ns1:getTransaccionesNoConfirmadas>"

        Dim soapAction = "http://business.mywebservice.inssjp.com/getTransaccionesNoConfirmadas"
        Dim doc = Await EjecutarSoapAsync(cuerpo, soapAction)
        Dim listaItems As New List(Of TransaccionTrazabilidad)()

        If EsError Then Return listaItems

        Dim returnNode = doc.Descendants().FirstOrDefault(Function(e) e.Name.LocalName = "return")
        If returnNode IsNot Nothing Then
            For Each itemXml In returnNode.Elements().Where(Function(e) e.Name.LocalName = "list")
                Dim item As New TransaccionTrazabilidad()

                Dim idTrans = itemXml.Elements().FirstOrDefault(Function(e) e.Name.LocalName = "_id_transaccion")?.Value
                If IsNumeric(idTrans) Then item.IdTransaccion = CLng(idTrans)

                Dim fechaTexto = itemXml.Elements().FirstOrDefault(Function(e) e.Name.LocalName = "_f_evento")?.Value
                Dim fechaConvertida As Date
                If Date.TryParse(fechaTexto, fechaConvertida) Then
                    item.FechaEvento = fechaConvertida
                End If

                item.DescripcionEvento = itemXml.Elements().FirstOrDefault(Function(e) e.Name.LocalName = "_d_evento")?.Value
                item.GlnOrigen = itemXml.Elements().FirstOrDefault(Function(e) e.Name.LocalName = "_gln_origen")?.Value
                item.RazonSocialOrigen = itemXml.Elements().FirstOrDefault(Function(e) e.Name.LocalName = "_razon_social_origen")?.Value
                item.Comprobante = itemXml.Elements().FirstOrDefault(Function(e) e.Name.LocalName = "_n_factura")?.Value
                item.Nombre = itemXml.Elements().FirstOrDefault(Function(e) e.Name.LocalName = "_nombre")?.Value
                item.Gtin = itemXml.Elements().FirstOrDefault(Function(e) e.Name.LocalName = "_gtin")?.Value
                item.Serie = itemXml.Elements().FirstOrDefault(Function(e) e.Name.LocalName = "_numero_serial")?.Value
                item.Lote = itemXml.Elements().FirstOrDefault(Function(e) e.Name.LocalName = "_lote")?.Value

                Dim venc = itemXml.Elements().FirstOrDefault(Function(e) e.Name.LocalName = "_vencimiento")?.Value
                If DateTime.TryParse(venc, Nothing) Then item.Vencimiento = Convert.ToDateTime(venc)

                item.Estado = "NO CONFIRMADO"
                listaItems.Add(item)
            Next
        End If

        Return listaItems
    End Function

    ''' <summary>
    ''' Consulta el historial de transacciones filtrando por estado y fechas.
    ''' </summary>
    Public Async Function VerTransaccionesAsync(argUsuario As String, argContrasena As String, argGln As String, argDesde As String, argHasta As String, argIdEstado As Integer) As Task(Of List(Of TransaccionTrazabilidad))
        Dim cuerpo =
            "<ns1:getTransaccionesWS xmlns:ns1=""http://business.mywebservice.inssjp.com/"">" &
                $"<arg0>{argUsuario}</arg0>" &
                $"<arg1>{argContrasena}</arg1>" &
                "<arg2></arg2><arg3></arg3><arg4></arg4><arg5></arg5><arg6></arg6><arg7></arg7><arg8></arg8>" &
                $"<arg9>{argDesde}</arg9>" &
                $"<arg10>{argHasta}</arg10>" &
                "<arg11></arg11><arg12></arg12><arg13></arg13><arg14></arg14>" &
                $"<arg15>{argIdEstado}</arg15>" &
                "<arg16></arg16><arg17></arg17>" &
            "</ns1:getTransaccionesWS>"

        ' Definimos el texto del estado de forma equivalente a VB6
        Dim estadoStr As String = String.Empty
        Select Case argIdEstado
            Case 1 : estadoStr = "INFORMADO"
            Case 2 : estadoStr = "ANULADO"
            Case 3 : estadoStr = "CONFIRMADO"
            Case 4 : estadoStr = "ALERTADO"
            Case 5 : estadoStr = "CARGADO"
        End Select

        ' Ejecutamos la consulta enviando el SOAPAction correcto para getTransaccionesWS
        Dim soapAction = "http://business.mywebservice.inssjp.com/getTransaccionesWS"
        Dim doc = Await EjecutarSoapAsync(cuerpo, soapAction)
        Dim listaItems As New List(Of TransaccionTrazabilidad)()

        If EsError Then Return listaItems

        Dim returnNode = doc.Descendants().FirstOrDefault(Function(e) e.Name.LocalName = "return")
        If returnNode IsNot Nothing Then
            For Each itemXml In returnNode.Elements().Where(Function(e) e.Name.LocalName = "list")
                Dim item As New TransaccionTrazabilidad()

                Dim idTrans = itemXml.Elements().FirstOrDefault(Function(e) e.Name.LocalName = "_id_transaccion")?.Value
                If IsNumeric(idTrans) Then item.IdTransaccion = CLng(idTrans)

                item.Nombre = itemXml.Elements().FirstOrDefault(Function(e) e.Name.LocalName = "_nombre")?.Value
                item.Gtin = itemXml.Elements().FirstOrDefault(Function(e) e.Name.LocalName = "_gtin")?.Value
                item.Serie = itemXml.Elements().FirstOrDefault(Function(e) e.Name.LocalName = "_numero_serial")?.Value
                item.Lote = itemXml.Elements().FirstOrDefault(Function(e) e.Name.LocalName = "_lote")?.Value

                Dim venc = itemXml.Elements().FirstOrDefault(Function(e) e.Name.LocalName = "_vencimiento")?.Value
                If DateTime.TryParse(venc, Nothing) Then item.Vencimiento = Convert.ToDateTime(venc)

                item.GlnOrigen = itemXml.Elements().FirstOrDefault(Function(e) e.Name.LocalName = "_gln_origen")?.Value
                item.RazonSocialOrigen = itemXml.Elements().FirstOrDefault(Function(e) e.Name.LocalName = "_razon_social_origen")?.Value
                item.DescripcionEvento = itemXml.Elements().FirstOrDefault(Function(e) e.Name.LocalName = "_descripcion_evento")?.Value

                Dim fechaTexto = itemXml.Elements().FirstOrDefault(Function(e) e.Name.LocalName = "_f_evento")?.Value
                Dim fechaConvertida As Date
                If Date.TryParse(fechaTexto, fechaConvertida) Then
                    item.FechaEvento = fechaConvertida
                End If

                item.Estado = estadoStr
                listaItems.Add(item)
            Next
        End If

        Return listaItems
    End Function

End Class
