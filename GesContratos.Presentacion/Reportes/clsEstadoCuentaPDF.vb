Imports System.IO
Imports Microsoft.Reporting.WinForms
Imports SiCoFa.Entidades
Public Class clsEstadoCuentaPDF
    Implements IDisposable
    Property Locador As New List(Of Locador)
    Property DocumentoLocador As New List(Of Documento)
    Property IVALocador As New List(Of IVA)
    Property Cliente As New List(Of Cliente)
    Property DocumentoCliente As New List(Of Documento)
    Property IVACliente As New List(Of IVA)
    Property TipoDocumentoCliente As New List(Of TipoDocumento)
    Property DetalleServicios As String
    Property DetalleCuenta As String
    Property TotalAdeudado As String
    Property SaldoAnticipos As String
    Property NombreArchivo As String

    Private m_streams As IList(Of Stream)

    Public Sub Export(ByVal report As LocalReport)

        Dim pdfContent As Byte() = report.Render("PDF")
        Dim pdfPath As String = Application.StartupPath & "\Temp\" & NombreArchivo & ".pdf"
        Dim pdfFile As New System.IO.FileStream(pdfPath, System.IO.FileMode.Create)
        pdfFile.Write(pdfContent, 0, pdfContent.Length)
        pdfFile.Close()

    End Sub

    'Crear un informe local para Report.rdlc, cargar los datos, exportar el informe a un archivo .emf e imprimirlo.
    Public Sub Run()
        Dim report As New LocalReport()
        Dim param As New List(Of ReportParameter)
        param.Add(New ReportParameter("DetalleServicios", Me.DetalleServicios))
        param.Add(New ReportParameter("DetalleCuenta", Me.DetalleCuenta))
        param.Add(New ReportParameter("TotalAdeudado", Me.TotalAdeudado))
        param.Add(New ReportParameter("SaldoAnticipos", Me.SaldoAnticipos))
        report.ReportPath = Application.StartupPath & "\rptEstadoCuenta.rdlc"
        report.DataSources.Add(New ReportDataSource("Locador", Me.Locador))
        report.DataSources.Add(New ReportDataSource("DocumentoLocador", Me.DocumentoLocador))
        report.DataSources.Add(New ReportDataSource("IVALocador", Me.IVALocador))
        report.DataSources.Add(New ReportDataSource("Cliente", Cliente))
        report.DataSources.Add(New ReportDataSource("DocumentoCliente", Me.DocumentoCliente))
        report.DataSources.Add(New ReportDataSource("IVACliente", Me.IVACliente))
        report.DataSources.Add(New ReportDataSource("TipoDocumentoCliente", Me.TipoDocumentoCliente))
        report.SetParameters(param)

        Export(report)

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
