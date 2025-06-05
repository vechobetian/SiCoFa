Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports System.IO
Imports System.Text
Imports Microsoft.Reporting.WinForms
Imports SiCoFa.Entidades

Public Class ReporteComprobantes
    Implements IDisposable
    Property Operacion As New List(Of Operacion)
    Property Empresa As New List(Of Empresa)
    Property DocumentoEmpresa As New List(Of Documento)
    Property IVAEmpresa As New List(Of IVA)
    Property Cliente As New List(Of Cliente)
    Property DocumentoCliente As New List(Of Documento)
    Property IVACliente As New List(Of IVA)
    Property TipoDocumentoCliente As New List(Of TipoDocumento)
    Property Encabezado As New List(Of Comprobante)
    Property TipoComprobante As New List(Of TipoComprobante)
    'Property Detalle As New List(Of ItemComprobante)
    Property CAE As New List(Of CAE)
    Property QR As New List(Of QRCompE)
    Property Impresora As String
    'Property Copia As String
    'Property CompAsoc As String

    Private m_currentPageIndex As Integer

    Private m_streams As IList(Of Stream)

    'Rutina para proporcionar al procesador de informes, a fin de guardar una imagen para cada página del informe
    Private Function CreateStream(ByVal name As String, ByVal fileNameExtension As String, ByVal encoding As Encoding, ByVal mimeType As String, ByVal willSeek As Boolean) As Stream
        Dim stream As Stream = New MemoryStream()
        m_streams.Add(stream)
        Return stream
    End Function

    'Exportar el informe dado como un archivo EMF (metarchivo mejorado).
    Public Sub Export(ByVal report As LocalReport)
        Dim deviceInfo As String =
      "<DeviceInfo>" +
      "  <OutputFormat>EMF</OutputFormat>" +
      "  <PageWidth>21cm</PageWidth>" +
      "  <PageHeight>29.7cm</PageHeight>" +
      "  <MarginTop>0cm</MarginTop>" +
      "  <MarginLeft>0cm</MarginLeft>" +
      "  <MarginRight>0cm</MarginRight>" +
      "  <MarginBottom>0cm</MarginBottom>" +
      "</DeviceInfo>"
        Dim warnings() As Warning = Nothing
        m_streams = New List(Of Stream)()

        report.Render("Image", deviceInfo, AddressOf CreateStream, warnings)

        For Each stream As Stream In m_streams
            stream.Position = 0
        Next
    End Sub

    'Controlador para PrintPageEvents
    Private Sub PrintPage(ByVal sender As Object, ByVal ev As PrintPageEventArgs)
        Dim pageImage As New Metafile(m_streams(m_currentPageIndex))

        'Ajustar el area rectangular con los margenes de la impresora
        Dim adjustedRect As New Rectangle(ev.PageBounds.Left - CInt(ev.PageSettings.HardMarginX),
                                          ev.PageBounds.Top - CInt(ev.PageSettings.HardMarginY),
                                          ev.PageBounds.Width,
                                          ev.PageBounds.Height)

        'Dibujar un fondo blanco para el informe
        ev.Graphics.DrawImage(pageImage, adjustedRect)

        'Extraer el contenido del informe
        ev.Graphics.DrawImage(pageImage, adjustedRect)

        'Prepararse para la siguiente página. Nos aseguramos de que no hemos alcanzado el final.
        m_currentPageIndex += 1
        ev.HasMorePages = (m_currentPageIndex < m_streams.Count)

    End Sub

    Public Sub Print()
        If m_streams Is Nothing OrElse m_streams.Count = 0 Then
            Throw New Exception("Error: no hay ningún flujo de impresión.")
            Exit Sub
        End If

        Dim printDoc As New PrintDocument()

        'If Me.Impresora <> "" Then
        'printDoc.PrinterSettings.PrinterName = Me.Impresora
        'End If

        If Not printDoc.PrinterSettings.IsValid Then
            Throw New Exception("Error: No se puede encontrar la impresora predeterminada.")
            Exit Sub
        End If

        AddHandler printDoc.PrintPage, AddressOf PrintPage
        m_currentPageIndex = 0
        printDoc.Print()

    End Sub

    'Crear un informe local para Report.rdlc, cargar los datos, exportar el informe a un archivo .emf e imprimirlo.
    Public Sub Run()
        Try
            Dim report As New LocalReport()
            'Dim param As New List(Of ReportParameter)
            'param.Add(New ReportParameter("Copia", Me.Copia))
            'param.Add(New ReportParameter("CompAsoc", Me.CompAsoc))

            'Select Case Me.TipoComprobante(0).Letra
            'Case "A", "M"
            'report.ReportPath = Application.StartupPath & "\rptCompAA4.rdlc"
            'Case "B"
            'report.ReportPath = "C:\SiCoFaCom\SiCoFa.Presentacion\Reportes\rptCompBA4.rdlc"
            report.ReportPath = "C:\SiCoFaCom\SiCoFa.Presentacion\Reportes\report1.rdlc"
            'Case "C"
            'report.ReportPath = Application.StartupPath & "\rptCompCA4.rdlc"
            'Case "R"
            'report.ReportPath = Application.StartupPath & "\rptCompRA4.rdlc"
            'End Select

            'report.DataSources.Add(New ReportDataSource("Operacion", Operacion))
            report.DataSources.Add(New ReportDataSource("Empresa", Empresa))
            report.DataSources.Add(New ReportDataSource("DocumentoEmpresa", DocumentoEmpresa))
            report.DataSources.Add(New ReportDataSource("IVAEmpresa", IVAEmpresa))
            report.DataSources.Add(New ReportDataSource("Cliente", Cliente))
            report.DataSources.Add(New ReportDataSource("DocumentoCliente", DocumentoCliente))
            report.DataSources.Add(New ReportDataSource("IVACliente", IVACliente))
            report.DataSources.Add(New ReportDataSource("TipoDocumentoCliente", TipoDocumentoCliente))
            report.DataSources.Add(New ReportDataSource("Encabezado", Encabezado))
            report.DataSources.Add(New ReportDataSource("TipoComprobante", TipoComprobante))
            'report.DataSources.Add(New ReportDataSource("Detalle", Detalle))
            report.DataSources.Add(New ReportDataSource("CAE", CAE))
            report.DataSources.Add(New ReportDataSource("QR", QR))
            'report.SetParameters(param)

            Export(report)
            Print()
        Catch ex As Exception
            ' Registra la excepción para un análisis detallado.
            ' Para depuración, puedes usar un MsgBox para retroalimentación inmediata,
            ' pero para producción, el registro en un archivo o visor de eventos es mejor.
            MsgBox("Se produjo un error al generar o imprimir el informe: " & ex.Message & vbCrLf & "StackTrace: " & ex.StackTrace, MsgBoxStyle.Critical, "Error de Informe")
            ' Podrías querer relanzar la excepción o manejarla de manera más elegante
            ' dependiendo de la estrategia general de manejo de errores de la aplicación.
            ' Throw ex
        Finally
            ' Asegúrate de que el objeto report se libere si es necesario, aunque es una variable local.
            ' Si el informe tuviera recursos no administrados que necesitaran una limpieza explícita más allá del GC estándar.
        End Try
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        If m_streams IsNot Nothing Then
            For Each stream As Stream In m_streams
                stream.Close()
            Next
            m_streams = Nothing
        End If
    End Sub

End Class