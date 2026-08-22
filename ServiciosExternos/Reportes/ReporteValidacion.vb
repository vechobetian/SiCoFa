Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Imports System.Text

Public Class ReporteValidacion

    Public Shared Function CrearPdf(mensaje As String) As Byte()

        Try

            Dim carpeta As String = "C:\SiCoFa_Cliente\Temp"

            If Not Directory.Exists(carpeta) Then
                Directory.CreateDirectory(carpeta)
            End If

            Dim rutaPdf As String =
            Path.Combine(carpeta, "ITC_Autorizacion.pdf")

            '==========================================================
            ' CORREGIR CARACTERES
            '==========================================================

            mensaje = mensaje.Replace("ÃƒÂ³", "ó")
            mensaje = mensaje.Replace("ÃƒÂ©", "é")
            mensaje = mensaje.Replace("Ã‚Â", "")

            '==========================================================
            ' ELIMINAR SALTOS EXISTENTES
            '==========================================================

            mensaje = mensaje.Replace(vbCrLf, " ")
            mensaje = mensaje.Replace(vbCr, " ")
            mensaje = mensaje.Replace(vbLf, " ")

            '==========================================================
            ' ARMAR LINEAS PARA 80 MM
            '==========================================================

            Dim lineas As New List(Of String)

            Dim anchoCaracteres As Integer = 48

            Dim texto As String = mensaje.Trim()

            While texto.Length > 0

                If texto.Length <= anchoCaracteres Then

                    lineas.Add(texto)
                    Exit While

                End If

                Dim posicion As Integer =
                texto.LastIndexOf(" "c, anchoCaracteres)

                If posicion <= 0 Then
                    posicion = anchoCaracteres
                End If

                Dim linea As String =
                texto.Substring(0, posicion).Trim()

                lineas.Add(linea)

                texto =
                texto.Substring(posicion).Trim()

            End While

            '==========================================================
            ' PAPEL 80 MM
            '==========================================================

            Dim ancho As Single =
            80.0F / 25.4F * 72.0F

            Dim alto As Single =
            Math.Max(
                200.0F,
                lineas.Count * 10.0F + 20.0F
            )

            Dim rectangulo As New Rectangle(
            ancho,
            alto
        )

            Dim documento As New Document(
            rectangulo,
            5,
            5,
            5,
            5
        )

            '==========================================================
            ' CREAR PDF
            '==========================================================

            Using archivo As New FileStream(
            rutaPdf,
            FileMode.Create,
            FileAccess.Write,
            FileShare.None)

                Dim writer As PdfWriter =
                PdfWriter.GetInstance(
                    documento,
                    archivo
                )

                documento.Open()

                '======================================================
                ' COURIER
                '======================================================

                Dim baseFont As BaseFont =
                BaseFont.CreateFont(
                    BaseFont.COURIER,
                    BaseFont.CP1252,
                    BaseFont.NOT_EMBEDDED
                )

                Dim fuente As New Font(
                baseFont,
                8,
                Font.NORMAL
            )

                '======================================================
                ' ESCRIBIR
                '======================================================

                For Each linea As String In lineas

                    Dim parrafo As New Paragraph(
                    linea,
                    fuente
                )

                    parrafo.Leading = 10
                    parrafo.SpacingBefore = 0
                    parrafo.SpacingAfter = 0

                    documento.Add(parrafo)

                Next

                documento.Close()

            End Using

            '==========================================================
            ' DEVOLVER BYTE()
            '==========================================================

            Return File.ReadAllBytes(rutaPdf)

        Catch ex As Exception

            Throw New Exception(
            "Error al generar PDF del reporte ITC: " &
            ex.Message,
            ex
        )

        End Try

    End Function

End Class