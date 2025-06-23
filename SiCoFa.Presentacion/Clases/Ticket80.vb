Imports System.Drawing.Printing
Imports SiCoFa.Entidades
Public Class Ticket80
    Property Impresora As String
    Property Comprobante As Comprobante
    Property Copia As String
    Private Sub FACTURA(ByVal sender As Object, ByVal e As PrintPageEventArgs)
        Dim fuenteGrande As Font = New Font("consolas", 15)
        Dim printFont As Font = New Font("consolas", 8)
        Dim topMargin As Double = e.MarginBounds.Top
        Dim yPos As Double
        Dim strLinea2Item As String
        Dim strCantPUnit As String
        Dim strImpItem As String
        Dim strImpDesItem As String
        Dim strSubTotal As String
        Dim strImpEx As String
        Dim strImpNeto1 As String
        Dim strIVA As String
        Dim strIVA1 As String
        Dim strImpNeto2 As String
        Dim strIVA2 As String
        Dim strTotal As String
        Dim strOS As String
        Dim strTar As String
        Dim strCC As String
        Dim strEf As String
        Dim Tab As String

        Const IncrementoYPreTexto As Integer = 15
        Const IncrementoYPreLinea As Integer = 5
        Const IncrementoYPreItem As Integer = 20
        Const MargenIzquierdo As Integer = 10
        Const Linea As String = "__________________________________________"

        e.Graphics.DrawString(Copia, printFont, Brushes.Black, MargenIzquierdo, 5)

        If Len(Comprobante.Empresa.Nombre) > 20 Then
            e.Graphics.DrawString(Comprobante.Empresa.Nombre, printFont, Brushes.Black, MargenIzquierdo, 30)
        Else
            e.Graphics.DrawString(Comprobante.Empresa.Nombre, fuenteGrande, Brushes.Black, MargenIzquierdo, 30)
        End If

        yPos = 60

        e.Graphics.DrawString(Comprobante.Empresa.Domicilio, printFont, Brushes.Black, MargenIzquierdo, yPos)
        yPos += IncrementoYPreTexto
        e.Graphics.DrawString(Comprobante.Empresa.Localidad & "-" & Comprobante.Empresa.Provincia, printFont, Brushes.Black, MargenIzquierdo, yPos)
        yPos += IncrementoYPreTexto
        e.Graphics.DrawString("Telefono: " & Comprobante.Empresa.Telefono, printFont, Brushes.Black, MargenIzquierdo, yPos)
        yPos += IncrementoYPreTexto
        e.Graphics.DrawString("Tipo Iva: " & Comprobante.Empresa.IVA.TipoIVA, printFont, Brushes.Black, MargenIzquierdo, yPos)
        yPos += IncrementoYPreTexto
        e.Graphics.DrawString("CUIT: " & Comprobante.Empresa.Documento.Numero, printFont, Brushes.Black, MargenIzquierdo, yPos)
        yPos += IncrementoYPreTexto
        e.Graphics.DrawString("Ing.Btos: " & Comprobante.Empresa.IB, printFont, Brushes.Black, MargenIzquierdo, yPos)
        yPos += IncrementoYPreTexto
        e.Graphics.DrawString("Inicio Actividades: " & Comprobante.Empresa.FechaAlta, printFont, Brushes.Black, MargenIzquierdo, yPos)
        yPos += IncrementoYPreLinea
        e.Graphics.DrawString(Linea, printFont, Brushes.Black, MargenIzquierdo, yPos)
        yPos += IncrementoYPreTexto
        Dim fuenteGigante As Font = New Font("consolas", 30)
        Dim rectF1 As New RectangleF(MargenIzquierdo + 3, yPos + 4, 50, 50)
        Dim stringFormat As New StringFormat()

        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center

        e.Graphics.DrawString(Comprobante.TipoComprobante.Letra, fuenteGigante, Brushes.Black, rectF1, stringFormat)
        e.Graphics.DrawRectangle(Pens.Black, Rectangle.Round(rectF1))
        e.Graphics.DrawString("Cod." & Comprobante.TipoComprobante.CodiTC_ARCA, printFont, Brushes.Black, MargenIzquierdo + 9, yPos + 42)
        e.Graphics.DrawString(Comprobante.TipoComprobante.TipoComprobanteSLetra, printFont, Brushes.Black, MargenIzquierdo + 58, yPos + 3)
        yPos += IncrementoYPreTexto
        e.Graphics.DrawString("P.Vta:" & Comprobante.PVenta & "           Nro:" & Comprobante.NumComp, printFont, Brushes.Black, MargenIzquierdo + 58, yPos + 10)
        yPos += IncrementoYPreTexto
        e.Graphics.DrawString("Fecha:" & Comprobante.FechaComp, printFont, Brushes.Black, MargenIzquierdo + 58, yPos + 10)

        Dim hora As String = TimeString
        e.Graphics.DrawString("Hora:" & hora, printFont, Brushes.Black, MargenIzquierdo + 183, yPos + 10)
        yPos += IncrementoYPreLinea + 15
        e.Graphics.DrawString(Linea, printFont, Brushes.Black, MargenIzquierdo, yPos)

        Dim strCliente As String = Left(Comprobante.Cliente.Nombre, 34)
        yPos += IncrementoYPreTexto
        e.Graphics.DrawString("Cliente:" & strCliente, printFont, Brushes.Black, MargenIzquierdo, yPos)

        If Len(Comprobante.Cliente.Nombre) > 34 Then
            yPos += IncrementoYPreTexto
            strCliente = Mid(Comprobante.Cliente.Nombre, 35, 42)
            e.Graphics.DrawString(strCliente, printFont, Brushes.Black, MargenIzquierdo, yPos)
        End If

        yPos += IncrementoYPreTexto
        e.Graphics.DrawString("Domicilio:" & Comprobante.Cliente.Localidad & "-" & Comprobante.Cliente.Provincia, printFont, Brushes.Black, MargenIzquierdo, yPos)
        yPos += IncrementoYPreTexto
        e.Graphics.DrawString("IVA:" & Comprobante.Cliente.IVA.TipoIVA, printFont, Brushes.Black, MargenIzquierdo, yPos)
        yPos += IncrementoYPreTexto
        e.Graphics.DrawString("Tipo Doc:" & Comprobante.Cliente.Documento.TipoDoc.TipoDocumento, printFont, Brushes.Black, MargenIzquierdo, yPos)
        yPos += IncrementoYPreTexto
        e.Graphics.DrawString("Num.Doc:" & Comprobante.Cliente.Documento.Numero, printFont, Brushes.Black, MargenIzquierdo, yPos)
        yPos += IncrementoYPreLinea
        e.Graphics.DrawString(Linea, printFont, Brushes.Black, MargenIzquierdo, yPos)
        'Fin del Encabezado

        'Aca comienza el detalle del comprobante
        yPos += IncrementoYPreTexto
        e.Graphics.DrawString("Descripción", printFont, Brushes.Black, MargenIzquierdo, yPos)
        yPos += IncrementoYPreTexto
        e.Graphics.DrawString("Cant/P.Unit.     %IVA     Desc.    Importe", printFont, Brushes.Black, MargenIzquierdo, yPos)
        yPos += IncrementoYPreLinea
        e.Graphics.DrawString(Linea, printFont, Brushes.Black, MargenIzquierdo, yPos)

        For Each Item As ItemComprobante In Comprobante.Detalle
            Dim strDescripcion As String = Left(Item.Descripcion, 42)
            Dim strAlicIVA As String = "(" & Format(Item.AlicIVA, "Fixed") & ")"

            If Comprobante.TipoComprobante.Letra = "A" Then
                strCantPUnit = Format(Item.Cantidad, "##0.000") & "/" & Format(Item.PrecioNeto, "Fixed")
                strImpItem = Format(Item.ImporteNetoConDescuento, "Fixed")
                strImpDesItem = Format(Item.ImporteNetoDescuento, "Fixed")
            Else
                strCantPUnit = Format(Item.Cantidad, "##0.000") & "/" & Format(Item.PrecioUnitario, "Fixed")
                strImpItem = Format(Item.ImporteConDescuento, "Fixed")
                strImpDesItem = Format(Item.ImporteDescuento, "Fixed")
            End If

            Tab = StrDup(16 - Len(strCantPUnit), " ")
            strLinea2Item = strCantPUnit & Tab & strAlicIVA & StrDup(8 - Len(strImpDesItem), " ") & strImpDesItem & StrDup(11 - Len(strImpItem), " ") & strImpItem

            yPos += IncrementoYPreItem
            e.Graphics.DrawString(LTrim(strDescripcion), printFont, Brushes.Black, MargenIzquierdo, yPos)

            yPos += IncrementoYPreTexto
            e.Graphics.DrawString(strLinea2Item, printFont, Brushes.Black, MargenIzquierdo, yPos)

        Next

        yPos += IncrementoYPreLinea + 5
        e.Graphics.DrawString(Linea, printFont, Brushes.Black, MargenIzquierdo, yPos)

        If Me.Comprobante.TipoComprobante.Letra = "A" Then
            strSubTotal = Format(Comprobante.ImpNeto1 + Comprobante.ImpNeto2 + Comprobante.ImpEx, "Standard")
            yPos += IncrementoYPreTexto
            e.Graphics.DrawString("Subtotal: " & StrDup(32 - Len(strSubTotal), " ") & strSubTotal, printFont, Brushes.Black, MargenIzquierdo, yPos)

            strImpEx = Format(Comprobante.ImpEx, "Standard")
            yPos += IncrementoYPreTexto
            e.Graphics.DrawString("Imp.Exento: " & StrDup(30 - Len(strImpEx), " ") & strImpEx, printFont, Brushes.Black, MargenIzquierdo, yPos)

            strImpNeto1 = Format(Comprobante.ImpNeto1, "Standard")
            yPos += IncrementoYPreTexto
            e.Graphics.DrawString("Imp.Neto 10,5%: " & StrDup(26 - Len(strImpNeto1), " ") & strImpNeto1, printFont, Brushes.Black, MargenIzquierdo, yPos)

            strIVA1 = Format(Comprobante.ImpIVA1, "Standard")
            yPos += IncrementoYPreTexto
            e.Graphics.DrawString("I.V.A 10,5%: " & StrDup(29 - Len(strIVA1), " ") & strIVA1, printFont, Brushes.Black, MargenIzquierdo, yPos)

            strImpNeto2 = Format(Comprobante.ImpNeto2, "Standard")
            yPos += IncrementoYPreTexto
            e.Graphics.DrawString("Imp.Neto 21%: " & StrDup(28 - Len(strImpNeto2), " ") & strImpNeto2, printFont, Brushes.Black, MargenIzquierdo, yPos)

            strIVA2 = Format(Comprobante.ImpIVA2, "Standard")
            yPos += IncrementoYPreTexto
            e.Graphics.DrawString("I.V.A 21%: " & StrDup(31 - Len(strIVA2), " ") & strIVA2, printFont, Brushes.Black, MargenIzquierdo, yPos)

            strTotal = Format(Comprobante.ImpBto, "Standard")
            yPos += IncrementoYPreTexto
            e.Graphics.DrawString("TOTAL: " & StrDup(15 - Len(strTotal), " ") & strTotal, fuenteGrande, Brushes.Black, MargenIzquierdo, yPos)

        Else
            strTotal = Format(Comprobante.ImpBto, "Standard")
            yPos += IncrementoYPreTexto
            e.Graphics.DrawString("TOTAL: " & StrDup(15 - Len(strTotal), " ") & strTotal, fuenteGrande, Brushes.Black, MargenIzquierdo, yPos)

        End If

        If Comprobante.TipoComprobante.Letra = "B" Then
            yPos += IncrementoYPreTexto
            e.Graphics.DrawString(Linea, printFont, Brushes.Black, MargenIzquierdo, yPos)
            yPos += IncrementoYPreTexto
            e.Graphics.DrawString("Régimen de Transparencia Fiscal(Ley 27743)", printFont, Brushes.Black, MargenIzquierdo, yPos)
            strIVA = Format(Comprobante.ImpIVA1 + Comprobante.ImpIVA2, "Standard")
            yPos += IncrementoYPreTexto
            e.Graphics.DrawString("IVA Contenido: " & StrDup(26 - Len(strIVA), " ") & strIVA, printFont, Brushes.Black, MargenIzquierdo, yPos)
            yPos += IncrementoYPreTexto
            e.Graphics.DrawString("Otros Impuestos Nacionales: " & StrDup(13 - Len("0,00"), " ") & "0,00", printFont, Brushes.Black, MargenIzquierdo, yPos)
            yPos += IncrementoYPreLinea
            e.Graphics.DrawString(Linea, printFont, Brushes.Black, MargenIzquierdo, yPos)
        Else
            yPos += IncrementoYPreLinea * 2
        End If

        yPos += IncrementoYPreTexto
        e.Graphics.DrawString("RECIBI(MOS)", printFont, Brushes.Black, MargenIzquierdo, yPos)

        If Comprobante.ImpCB > 0 Then
            strOS = Format(Comprobante.ImpCB, "Standard")
            yPos += IncrementoYPreTexto
            e.Graphics.DrawString("Obra Social: " & StrDup(29 - Len(strOS), " ") & strOS, printFont, Brushes.Black, MargenIzquierdo, yPos)
        End If

        If Comprobante.ImpPE > 0 Then
            strTar = Format(Comprobante.ImpPE, "Standard")
            yPos += IncrementoYPreTexto
            e.Graphics.DrawString("Tarjeta/s: " & StrDup(31 - Len(strTar), " ") & strTar, printFont, Brushes.Black, MargenIzquierdo, yPos)
        End If

        If Comprobante.ImpCC > 0 Then
            strCC = Format(Comprobante.ImpCC, "Standard")
            yPos += IncrementoYPreTexto
            e.Graphics.DrawString("Cuenta Corriente: " & StrDup(24 - Len(strCC), " ") & strCC, printFont, Brushes.Black, MargenIzquierdo, yPos)
        End If

        If Comprobante.ImpEf > 0 Then
            strEf = Format(Comprobante.ImpEf, "Standard")
            yPos += IncrementoYPreTexto
            e.Graphics.DrawString("Efectivo: " & StrDup(32 - Len(strEf), " ") & strEf, printFont, Brushes.Black, MargenIzquierdo, yPos)
        End If

        yPos += IncrementoYPreLinea
        e.Graphics.DrawString(Linea, printFont, Brushes.Black, MargenIzquierdo, yPos)

        If Not (Comprobante.CAE Is Nothing) Then
            yPos += IncrementoYPreTexto
            e.Graphics.DrawString("      Dirección de comercio interior", printFont, Brushes.Black, MargenIzquierdo, yPos)
            yPos += IncrementoYPreTexto
            e.Graphics.DrawString("        Teléfono 0800-444-03346", printFont, Brushes.Black, MargenIzquierdo, yPos)

            Dim imgQR As Image = Me.Bytes_Imagen(Me.Comprobante.QR.QR)
            Dim x As Single = MargenIzquierdo
            yPos += IncrementoYPreTexto
            Dim y As Single = yPos
            e.Graphics.DrawImage(imgQR, x, y, 100, 100)
            imgQR.Dispose()

            yPos += 60
            e.Graphics.DrawString("CAE:" & Comprobante.CAE.NumCAE, printFont, Brushes.Black, 115, yPos)
            yPos += IncrementoYPreTexto
            e.Graphics.DrawString("Vto:" & Comprobante.CAE.VtoCAE, printFont, Brushes.Black, 115, yPos)
        End If

        If Copia.Trim = "ORIGINAL" Then
            yPos += 30
            e.Graphics.DrawString("           GRACIAS POR SU COMPRA      ", printFont, Brushes.Black, MargenIzquierdo, yPos)
        Else
            yPos += 50
            e.Graphics.DrawString(Linea, printFont, Brushes.Black, MargenIzquierdo, yPos)
            yPos += 15
            e.Graphics.DrawString("                  FIRMA               ", printFont, Brushes.Black, MargenIzquierdo, yPos)
            yPos += 30
            e.Graphics.DrawString(Linea, printFont, Brushes.Black, MargenIzquierdo, yPos)
            yPos += 15
            e.Graphics.DrawString("                ACLARACIÓN            ", printFont, Brushes.Black, MargenIzquierdo, yPos)
        End If

        If Comprobante.CAE Is Nothing Then
            yPos += 30
            e.Graphics.DrawString("DOCUMENTO NO VALIDO COMO FACTURA", printFont, Brushes.Black, MargenIzquierdo, yPos)
        End If

        e.Graphics.Dispose()

    End Sub
    Private Sub RECIBO(ByVal sender As Object, ByVal e As PrintPageEventArgs)
        Dim fuenteGrande As Font = New Font("consolas", 15)
        Dim printFont As Font = New Font("consolas", 8)
        Dim topMargin As Double = e.MarginBounds.Top
        Dim yPos As Double
        Dim strTotal As String
        Dim strTar As String
        Dim strEf As String

        Const IncrementoYPreTexto As Integer = 15
        Const IncrementoYPreLinea As Integer = 5
        Const IncrementoYPreItem As Integer = 20
        Const MargenIzquierdo As Integer = 10
        Const Linea As String = "__________________________________________"

        e.Graphics.DrawString(Copia, printFont, Brushes.Black, MargenIzquierdo, 5)

        If Len(Comprobante.Empresa.Nombre) > 20 Then
            e.Graphics.DrawString(Comprobante.Empresa.Nombre, printFont, Brushes.Black, MargenIzquierdo, 30)
        Else
            e.Graphics.DrawString(Comprobante.Empresa.Nombre, fuenteGrande, Brushes.Black, MargenIzquierdo, 30)
        End If

        yPos = 60

        e.Graphics.DrawString(Comprobante.Empresa.Domicilio, printFont, Brushes.Black, MargenIzquierdo, yPos)
        yPos += IncrementoYPreTexto
        e.Graphics.DrawString(Comprobante.Empresa.Localidad & "-" & Comprobante.Empresa.Provincia, printFont, Brushes.Black, MargenIzquierdo, yPos)
        yPos += IncrementoYPreTexto
        e.Graphics.DrawString("Telefono: " & Comprobante.Empresa.Telefono, printFont, Brushes.Black, MargenIzquierdo, yPos)
        yPos += IncrementoYPreTexto
        e.Graphics.DrawString("Tipo Iva: " & Comprobante.Empresa.IVA.TipoIVA, printFont, Brushes.Black, MargenIzquierdo, yPos)
        yPos += IncrementoYPreTexto
        e.Graphics.DrawString("CUIT: " & Comprobante.Empresa.Documento.Numero, printFont, Brushes.Black, MargenIzquierdo, yPos)
        yPos += IncrementoYPreTexto
        e.Graphics.DrawString("Ing.Btos: " & Comprobante.Empresa.IB, printFont, Brushes.Black, MargenIzquierdo, yPos)
        yPos += IncrementoYPreTexto
        e.Graphics.DrawString("Inicio Actividades: " & Comprobante.Empresa.FechaAlta, printFont, Brushes.Black, MargenIzquierdo, yPos)
        yPos += IncrementoYPreLinea
        e.Graphics.DrawString(Linea, printFont, Brushes.Black, MargenIzquierdo, yPos)
        yPos += IncrementoYPreTexto
        Dim fuenteGigante As Font = New Font("consolas", 30)
        Dim rectF1 As New RectangleF(MargenIzquierdo + 3, yPos + 4, 50, 50)
        Dim stringFormat As New StringFormat()

        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center

        e.Graphics.DrawString(Comprobante.TipoComprobante.Letra, fuenteGigante, Brushes.Black, rectF1, stringFormat)
        e.Graphics.DrawRectangle(Pens.Black, Rectangle.Round(rectF1))
        e.Graphics.DrawString("Cod." & Comprobante.TipoComprobante.CodiTC_ARCA, printFont, Brushes.Black, MargenIzquierdo + 9, yPos + 42)
        e.Graphics.DrawString(Comprobante.TipoComprobante.TipoComprobanteSLetra, printFont, Brushes.Black, MargenIzquierdo + 58, yPos + 3)
        yPos += IncrementoYPreTexto
        e.Graphics.DrawString("P.Vta:" & Comprobante.PVenta & "           Nro:" & Comprobante.NumComp, printFont, Brushes.Black, MargenIzquierdo + 58, yPos + 10)
        yPos += IncrementoYPreTexto
        e.Graphics.DrawString("Fecha:" & Comprobante.FechaComp, printFont, Brushes.Black, MargenIzquierdo + 58, yPos + 10)

        Dim hora As String = TimeString
        e.Graphics.DrawString("Hora:" & hora, printFont, Brushes.Black, MargenIzquierdo + 183, yPos + 10)
        yPos += IncrementoYPreLinea + 15
        e.Graphics.DrawString(Linea, printFont, Brushes.Black, MargenIzquierdo, yPos)

        Dim strCliente As String = Left(Comprobante.Cliente.Nombre, 34)
        yPos += IncrementoYPreTexto
        e.Graphics.DrawString("Cliente:" & strCliente, printFont, Brushes.Black, MargenIzquierdo, yPos)

        If Len(Comprobante.Cliente.Nombre) > 34 Then
            yPos += IncrementoYPreTexto
            strCliente = Mid(Comprobante.Cliente.Nombre, 35, 42)
            e.Graphics.DrawString(strCliente, printFont, Brushes.Black, MargenIzquierdo, yPos)
        End If

        yPos += IncrementoYPreTexto
        e.Graphics.DrawString("Domicilio:" & Comprobante.Cliente.Localidad & "-" & Comprobante.Cliente.Provincia, printFont, Brushes.Black, MargenIzquierdo, yPos)
        yPos += IncrementoYPreTexto
        e.Graphics.DrawString("IVA:" & Comprobante.Cliente.IVA.TipoIVA, printFont, Brushes.Black, MargenIzquierdo, yPos)
        yPos += IncrementoYPreTexto
        e.Graphics.DrawString("Tipo Doc:" & Comprobante.Cliente.Documento.TipoDoc.TipoDocumento, printFont, Brushes.Black, MargenIzquierdo, yPos)
        yPos += IncrementoYPreTexto
        e.Graphics.DrawString("Num.Doc:" & Comprobante.Cliente.Documento.Numero, printFont, Brushes.Black, MargenIzquierdo, yPos)
        yPos += IncrementoYPreLinea
        e.Graphics.DrawString(Linea, printFont, Brushes.Black, MargenIzquierdo, yPos)
        'Fin del Encabezado

        'Aca comienza el detalle del comprobante
        yPos += IncrementoYPreTexto
        e.Graphics.DrawString("RECIBI(MOS) LA SUMA DE PESOS: ", printFont, Brushes.Black, MargenIzquierdo, yPos)

        Dim strTextoImporte As String = UCase(vecho.NumEnLetras(Format(Comprobante.ImpBto, "Fixed")))
        Dim CaracteresLeidos As Integer
        Dim TotalCaracteres As Integer = Len(strTextoImporte)
        Dim LeerCantidad As Integer
        Dim CaracteresRestantes As Integer
        Dim strTextoParcial As String

        If TotalCaracteres > 41 Then
            LeerCantidad = 41
        Else
            LeerCantidad = TotalCaracteres
        End If

        Do While LeerCantidad > 0
            strTextoParcial = Mid(strTextoImporte, CaracteresLeidos + 1, LeerCantidad)
            CaracteresLeidos += LeerCantidad

            yPos += IncrementoYPreTexto
            e.Graphics.DrawString(strTextoParcial, printFont, Brushes.Black, MargenIzquierdo, yPos)
            CaracteresRestantes = TotalCaracteres - CaracteresLeidos
            If CaracteresRestantes > 41 Then
                LeerCantidad = 41
            Else
                LeerCantidad = CaracteresRestantes
            End If
        Loop

        yPos += 2 * IncrementoYPreTexto
        e.Graphics.DrawString("EN CONCEPTO DE: ", printFont, Brushes.Black, MargenIzquierdo, yPos)

        For Each Item As ItemComprobante In Comprobante.Detalle

            yPos += IncrementoYPreItem
            e.Graphics.DrawString(Left(Item.Descripcion, 41), printFont, Brushes.Black, MargenIzquierdo, yPos)

        Next

        yPos += IncrementoYPreTexto
        strTotal = "$" & Format(Comprobante.ImpBto, "Fixed")
        e.Graphics.DrawString("SON PESOS: " & StrDup(11 - Len(strTotal), " ") & strTotal, fuenteGrande, Brushes.Black, MargenIzquierdo, yPos)
        yPos += 2 * IncrementoYPreTexto
        e.Graphics.DrawString("RECIBI(MOS)", printFont, Brushes.Black, MargenIzquierdo, yPos)

        If Comprobante.ImpPE > 0 Then
            yPos += IncrementoYPreTexto
            strTar = "$" & Format(Comprobante.ImpPE, "Fixed")
            e.Graphics.DrawString("Tarjeta/s: " & StrDup(31 - Len(strTar), " ") & strTar, printFont, Brushes.Black, MargenIzquierdo, yPos)
        End If

        If Comprobante.ImpEf > 0 Then
            yPos += IncrementoYPreTexto
            strEf = "$" & Format(Comprobante.ImpEf, "Fixed")
            e.Graphics.DrawString("Efectivo: " & StrDup(32 - Len(strEf), " ") & strEf, printFont, Brushes.Black, MargenIzquierdo, yPos)
        End If

        yPos += IncrementoYPreLinea
        e.Graphics.DrawString(Linea, printFont, Brushes.Black, MargenIzquierdo, yPos)
        yPos += IncrementoYPreTexto
        e.Graphics.DrawString("Documento no válido como Factura", printFont, Brushes.Black, MargenIzquierdo, yPos)

        If Comprobante.Operacion.Observaciones <> "" Then
            Dim intNumCarRestantes As Integer
            Dim strLineaObservaciones As String
            Dim x As Integer
            Dim y As Integer = 1
            Dim lineas() As String = Split(Comprobante.Operacion.Observaciones, vbCrLf)

            yPos += IncrementoYPreLinea
            e.Graphics.DrawString(Linea, printFont, Brushes.Black, MargenIzquierdo, yPos)
            yPos += IncrementoYPreTexto
            e.Graphics.DrawString("Observaciones:", printFont, Brushes.Black, MargenIzquierdo, yPos)

            For Each strLinea As String In lineas
                intNumCarRestantes = Len(strLinea)
                If intNumCarRestantes > 42 Then
                    Do While intNumCarRestantes > 0
                        x += 1
                        strLineaObservaciones = Mid(strLinea, y, 42)
                        y += 42
                        intNumCarRestantes = Len(strLinea) - 42 * x
                        yPos += IncrementoYPreTexto
                        e.Graphics.DrawString(strLineaObservaciones.TrimStart(" "), printFont, Brushes.Black, MargenIzquierdo, yPos)
                    Loop
                Else
                    yPos += IncrementoYPreTexto
                    e.Graphics.DrawString(strLinea.TrimStart(" "), printFont, Brushes.Black, MargenIzquierdo, yPos)
                End If
            Next

        End If
        e.Graphics.Dispose()

    End Sub
    Public Sub Imprimir(ByVal argCopia As String)

        Dim printDoc As New PrintDocument()

        If Me.Impresora <> "" Then
            printDoc.PrinterSettings.PrinterName = Me.Impresora
        End If

        If Not printDoc.PrinterSettings.IsValid Then
            Throw New Exception("Error: No se puede encontrar la impresora predeterminada.")
            Exit Sub
        End If

        Copia = argCopia
        Select Case Comprobante.TipoComprobante.CodiTC_SiCoFa
            Case "FAA", "FAB", "FAC", "NCA", "NCB", "NCC", "NCX", "RECR", "PRESU", "RTOX", "DI"
                AddHandler printDoc.PrintPage, AddressOf FACTURA
            Case "REC"
                AddHandler printDoc.PrintPage, AddressOf RECIBO
        End Select

        printDoc.Print()

        printDoc.Dispose()

    End Sub
    Private Function Bytes_Imagen(ByVal Foto As Byte()) As Image
        If Not Foto Is Nothing Then
            Dim Codi As New IO.MemoryStream(Foto)
            Dim resultado As Image = Image.FromStream(Codi)
            Return resultado
            Codi.Dispose()
            resultado.Dispose()

        Else
            Return Nothing
        End If
    End Function

End Class
