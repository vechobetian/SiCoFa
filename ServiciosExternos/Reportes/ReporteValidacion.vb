Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class ReporteValidacion

    ''' <summary>
    ''' Procesa y maqueta el texto plano recibido de PuntoSalud / ITC para darle formato de ticket, manejando múltiples medicamentos y amplios espacios de firma.
    ''' </summary>
    Public Function FormatearMensajePuntoSalud(rawText As String) As String
        Dim sb As New StringBuilder()

        ' 1. Normalizar y forzar saltos de línea en cada tira de guiones
        Dim texto As String = Regex.Replace(rawText, "-{5,}", vbCrLf & "----------------------------------------" & vbCrLf)

        ' 2. Insertar saltos de línea antes de cada palabra clave (Se excluyen las del bloque de firma para procesarlas en grupo)
        Dim etiquetas() As String = {
            "AUTORIZACION", "Cupón N°:", "Prestador:", "Afiliado:", "Plan:", "Tipo:",
            "Médico Receta:", "Fecha Receta :", "Fecha Receta:", "Fecha Prestación:",
            "Medicamentos", "Tipo Prescripción:", "TOTAL:", "A cargo O.S.", "A cargo Afil.",
            "TOTAL A CARGO AFIL.:", "PuntoSalud.com"
        }

        For Each etq In etiquetas
            texto = texto.Replace(etq, vbCrLf & etq)
        Next

        ' 3. Procesar el texto línea por línea
        Dim lineas() As String = texto.Split(New String() {vbCr, vbLf}, StringSplitOptions.RemoveEmptyEntries)

        For Each l As String In lineas
            Dim linea As String = l.Trim()

            ' Saltear etiquetas secundarias del bloque de firma para que no se dupliquen
            If linea.StartsWith("Firma del Titular") OrElse linea.StartsWith("Aclaración") OrElse
               linea.StartsWith("Documento Nro:") OrElse linea.StartsWith("Telf.y Direc.:") Then

                ' Marcador especial para que el generador de PDF levante el espacio físico
                If linea.StartsWith("Firma del Titular") Then
                    sb.AppendLine("[BLOQUE_FIRMA_AMPLIADO]")
                End If
                Continue For
            End If

            ' Encabezado de la tabla de medicamentos (Se escribe una sola vez)
            If linea.StartsWith("Medicamentos") Then
                sb.AppendLine("Medicamentos")
                sb.AppendLine("Can Troquel    P.Unit.  %Cob.   P.Final")
                Continue For
            End If

            ' Ignorar la línea de títulos si el WS la vuelve a enviar suelta
            If linea.StartsWith("Can Troquel") OrElse linea.StartsWith("P.Unit.") Then
                Continue For
            End If

            ' Fila de importes de troquel para CUALQUIER medicamento de la lista (1, 2, 3, etc.)
            Dim matchTroquel As Match = Regex.Match(linea, "^(\d+)\s+(\d{7})\s+(\$\d+[\d\.,]*)\s+(\d+[\d\.,]*%)\s+(\$\d+[\d\.,]*)(.*)")

            If matchTroquel.Success Then
                Dim can As String = matchTroquel.Groups(1).Value
                Dim troquel As String = matchTroquel.Groups(2).Value
                Dim pUnit As String = matchTroquel.Groups(3).Value
                Dim cob As String = matchTroquel.Groups(4).Value
                Dim pFinal As String = matchTroquel.Groups(5).Value
                Dim restoTexto As String = matchTroquel.Groups(6).Value.Trim()

                ' Imprimir valores numéricos alineados a la tabla
                Dim det As String = String.Format("{0,2} {1,-8} {2,10} {3,6} {4,10}", can, troquel, pUnit, cob, pFinal)
                sb.AppendLine(det)

                ' Imprimir el nombre del medicamento en el renglón siguiente con sangría
                If Not String.IsNullOrEmpty(restoTexto) Then
                    sb.AppendLine("    " & restoTexto)
                End If
                Continue For
            End If

            ' Formatear totales (TOTAL, A cargo O.S., A cargo Afil.)
            If linea.StartsWith("TOTAL:") OrElse linea.StartsWith("A cargo") OrElse linea.StartsWith("TOTAL A CARGO") Then
                Dim matchMonto = Regex.Match(linea, "(.*?)\s*(\$\d+[\d\.,]*)")
                If matchMonto.Success Then
                    Dim lbl As String = matchMonto.Groups(1).Value.Trim()
                    Dim val As String = matchMonto.Groups(2).Value.Trim()
                    Dim espacio As Integer = Math.Max(1, 40 - lbl.Length - val.Length)
                    sb.AppendLine(lbl & New String(" "c, espacio) & val)
                    Continue For
                End If
            End If

            ' Líneas estándar de texto plano
            sb.AppendLine(linea)
        Next

        Return sb.ToString()
    End Function

    ''' <summary>
    ''' Genera un documento PDF con formato de ticket térmico de 80mm
    ''' </summary>
    Public Sub GenerarPdfTicket(textoTicketRaw As String, rutaPdfSalida As String)
        Dim textoFormateado As String = FormatearMensajePuntoSalud(textoTicketRaw)

        ' 1. Crear documento temporal en memoria para calcular el alto exacto ocupado
        Using ms As New MemoryStream()
            Dim docMedicion As New Document(New Rectangle(226.0F, 2000.0F), 6.0F, 6.0F, 8.0F, 8.0F)
            Dim writerMedicion As PdfWriter = PdfWriter.GetInstance(docMedicion, ms)
            docMedicion.Open()

            Dim fuenteTicket As Font = FontFactory.GetFont(FontFactory.COURIER, 7.0F, Font.NORMAL, BaseColor.BLACK)

            ProcesarContenidoTicket(docMedicion, textoFormateado, fuenteTicket)

            Dim altoRequerido As Single = 2000.0F - writerMedicion.GetVerticalPosition(False) + 15.0F
            docMedicion.Close()

            ' 2. Generar el PDF definitivo en disco con la altura exacta obtenida
            Dim tamanoDefinitivo As New Rectangle(226.0F, altoRequerido)
            Dim docFinal As New Document(tamanoDefinitivo, 6.0F, 6.0F, 8.0F, 8.0F)

            Try
                PdfWriter.GetInstance(docFinal, New FileStream(rutaPdfSalida, FileMode.Create))
                docFinal.Open()
                ProcesarContenidoTicket(docFinal, textoFormateado, fuenteTicket)
            Finally
                If docFinal.IsOpen Then docFinal.Close()
            End Try
        End Using
    End Sub

    ''' <summary>
    ''' Rutina auxiliar para renderizar el contenido en el documento PDF
    ''' </summary>
    Private Sub ProcesarContenidoTicket(doc As Document, textoFormateado As String, fuente As Font)
        Using reader As New StringReader(textoFormateado)
            Dim linea As String = reader.ReadLine()

            While linea IsNot Nothing
                If linea = "[BLOQUE_FIRMA_AMPLIADO]" Then
                    doc.Add(New Paragraph("----------------------------------------", fuente) With {.Leading = 8.0F})
                    doc.Add(New Paragraph("          Firma del Titular", fuente) With {.Leading = 8.0F})

                    Dim espacioFirma As New Paragraph(" ", fuente) With {
                        .SpacingBefore = 40.0F,
                        .SpacingAfter = 5.0F
                    }
                    doc.Add(espacioFirma)

                    doc.Add(New Paragraph("----------------------------------------", fuente) With {.Leading = 8.0F})
                    doc.Add(New Paragraph("           Aclaración Firma", fuente) With {.Leading = 8.0F})

                    Dim espacioAclaracion As New Paragraph("Documento Nro:" & vbCrLf & vbCrLf & "Telf.y Direc.:", fuente) With {
                        .Leading = 16.0F,
                        .SpacingBefore = 10.0F,
                        .SpacingAfter = 10.0F
                    }
                    doc.Add(espacioAclaracion)
                Else
                    Dim p As New Paragraph(linea, fuente) With {.Leading = 8.0F}
                    doc.Add(p)
                End If

                linea = reader.ReadLine()
            End While
        End Using
    End Sub

End Class