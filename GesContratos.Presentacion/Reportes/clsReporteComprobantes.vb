Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports System.IO
Imports System.Text
Imports Microsoft.Reporting.WinForms
Imports SiCoFa.Entidades
Public Class clsReporteComprobantes
    Implements IDisposable

    Property Operacion As New List(Of Operacion)
    Property Locador As New List(Of Locador)
    Property DocumentoLocador As New List(Of Documento)
    Property IVALocador As New List(Of IVA)
    Property Cliente As New List(Of Cliente)
    Property DocumentoCliente As New List(Of Documento)
    Property IVACliente As New List(Of IVA)
    Property TipoDocumentoCliente As New List(Of TipoDocumento)
    Property Encabezado As New List(Of Comprobante)
    Property TipoComprobante As New List(Of TipoComprobante)
    Property Detalle As New List(Of ItemComprobante)
    Property CAE As New List(Of CAE)
    Property QR As New List(Of QRCompE)
    Property Copia As String
    Property CompAsoc As String
    Property PathArchivo As String


    Private m_currentPageIndex As Integer

    Private m_streams As IList(Of Stream)

    'Rutina para proporcionar al procesador de informes, a fin de guardar una imagen para cada página del informe
    Private Function CreateStream(ByVal name As String, ByVal fileNameExtension As String, ByVal encoding As Encoding, ByVal mimeType As String, ByVal willSeek As Boolean) As Stream
        Dim stream As Stream = New MemoryStream()
        m_streams.Add(stream)
        Return stream
    End Function
    Public Sub ExportPdfA4(ByVal report As LocalReport)

        Dim pdfContent As Byte() = report.Render("PDF")
        'pdfPath = Application.StartupPath & "\Temp\" & NombreArchivo & ".pdf"

        Dim pdfFile As New System.IO.FileStream(PathArchivo, System.IO.FileMode.Create)
        pdfFile.Write(pdfContent, 0, pdfContent.Length)
        pdfFile.Close()

    End Sub
    'Exportar el informe dado como un archivo EMF (metarchivo mejorado).
    Public Sub ExportImpresoraA4(ByVal report As LocalReport)
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
            MsgBox("Error: no hay ningún flujo de impresión.", vbInformation, "SiCoFa_CompE")
            Exit Sub
        End If

        Dim printDoc As New PrintDocument()

        If Not printDoc.PrinterSettings.IsValid Then
            MsgBox("Error: No se puede encontrar la impresora predeterminada.", vbInformation, "SiCoFa_CompE")
            Exit Sub
        End If

        AddHandler printDoc.PrintPage, AddressOf PrintPage
        m_currentPageIndex = 0
        printDoc.Print()

    End Sub

    'Crear un informe local para Report.rdlc, cargar los datos, exportar el informe a un archivo .emf e imprimirlo.
    Public Sub Run(ByVal argTipoReporte As String)
        Dim report As New LocalReport()
        Dim param As New List(Of ReportParameter)
        param.Add(New ReportParameter("Copia", Me.Copia))
        param.Add(New ReportParameter("CompAsoc", Me.CompAsoc))

        Select Case Me.TipoComprobante(0).Letra
            Case "A", "M"
                report.ReportPath = Application.StartupPath & "\rptCompAA4.rdlc"
            Case "B"
                report.ReportPath = Application.StartupPath & "\rptCompBA4.rdlc"
            Case "C"
                report.ReportPath = Application.StartupPath & "\rptCompCA4.rdlc"
            Case "R"
                report.ReportPath = Application.StartupPath & "\rptCompRA4.rdlc"
        End Select

        report.DataSources.Add(New ReportDataSource("Operacion", Operacion))
        report.DataSources.Add(New ReportDataSource("Locador", Locador))
        report.DataSources.Add(New ReportDataSource("DocumentoLocador", DocumentoLocador))
        report.DataSources.Add(New ReportDataSource("IVALocador", IVALocador))
        report.DataSources.Add(New ReportDataSource("Cliente", Cliente))
        report.DataSources.Add(New ReportDataSource("DocumentoCliente", DocumentoCliente))
        report.DataSources.Add(New ReportDataSource("IVACliente", IVACliente))
        report.DataSources.Add(New ReportDataSource("TipoDocumentoCliente", TipoDocumentoCliente))
        report.DataSources.Add(New ReportDataSource("Encabezado", Encabezado))
        report.DataSources.Add(New ReportDataSource("TipoComprobante", TipoComprobante))
        report.DataSources.Add(New ReportDataSource("Detalle", Detalle))
        report.DataSources.Add(New ReportDataSource("CAE", CAE))
        report.DataSources.Add(New ReportDataSource("QR", QR))
        report.SetParameters(param)

        Select Case argTipoReporte
            Case "PDFA4"
                ExportPdfA4(report)

            Case "IMPA4"
                ExportImpresoraA4(report)
                Me.Print()
        End Select

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
