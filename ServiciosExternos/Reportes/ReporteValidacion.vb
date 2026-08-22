Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class ReporteValidacion

    Public Sub GenerarPdfTicket(ByVal textoMensaje As String, ByVal rutaSalidaPdf As String)
        ' 1. Ancho 80mm x Alto 200mm (en puntos: 1mm = 2.83465 pt)
        Dim anchoPt As Single = 80.0F * 2.83465F
        Dim altoPt As Single = 200.0F * 2.83465F
        Dim pageSize As New Rectangle(anchoPt, altoPt)

        ' Margenes: Izq, Der, Arriba, Abajo
        Dim doc As New Document(pageSize, 10.0F, 10.0F, 10.0F, 10.0F)

        Using fs As New FileStream(rutaSalidaPdf, FileMode.Create, FileAccess.Write)
            PdfWriter.GetInstance(doc, fs)
            doc.Open()

            ' 2. Fuente Courier monoespaciada
            Dim fontCourier As Font = FontFactory.GetFont(FontFactory.COURIER, 7.5F, Font.NORMAL, BaseColor.BLACK)

            ' 3. Agregar el mensaje
            Dim p As New Paragraph(textoMensaje, fontCourier)
            p.Leading = 9.0F ' Interlineado

            doc.Add(p)
            doc.Close()
        End Using
    End Sub

End Class