Imports System.Drawing.Printing
Imports SiCoFa.Entidades
Public Class Ticket80
    Property Impresora As String
    Property Comprobante As Comprobante
    Property Copia As String
    Private Sub FACTURA(ByVal sender As Object, ByVal e As PrintPageEventArgs)
        ' 1. Tipos Font y Coordenadas unificados en Single para GDI+
        Dim fuenteGrande As New Font("consolas", 15.0F)
        Dim printFont As New Font("consolas", 8.0F)
        Dim fuenteGigante As New Font("consolas", 30.0F)

        ' Posicionamiento estricto en Single
        Dim MargenIzquierdo As Single = 10.0F
        Dim yPos As Single = 0.0F

        Dim strLinea2Item As String = String.Empty
        Dim strLinea3Item As String = String.Empty
        Dim strCantPUnit As String = String.Empty
        Dim strImpItem As String = String.Empty
        Dim strImpDesItem As String = String.Empty
        Dim strSubTotal As String = String.Empty
        Dim strImpEx As String = String.Empty
        Dim strImpNeto1 As String = String.Empty
        Dim strIVA As String = String.Empty
        Dim strIVA1 As String = String.Empty
        Dim strImpNeto2 As String = String.Empty
        Dim strIVA2 As String = String.Empty
        Dim strTotal As String = String.Empty
        Dim strTar As String = String.Empty
        Dim strCC As String = String.Empty
        Dim strEf As String = String.Empty
        Dim strOS As String = String.Empty
        Dim Tab As String = String.Empty

        Const IncrementoYPreTexto As Single = 15.0F
        Const IncrementoYPreLinea As Single = 5.0F
        Const IncrementoYPreItem As Single = 20.0F
        Const Linea As String = "__________________________________________"

        ' Copia del comprobante
        Dim textoCopia As String = If(Copia, String.Empty)
        e.Graphics.DrawString(textoCopia, printFont, Brushes.Black, MargenIzquierdo, 5.0F)

        ' Encabezado Empresa
        Dim nombreEmpresa As String = If(Comprobante?.Empresa?.Nombre, String.Empty)
        If nombreEmpresa.Length > 20 Then
            e.Graphics.DrawString(nombreEmpresa, printFont, Brushes.Black, MargenIzquierdo, 30.0F)
        Else
            e.Graphics.DrawString(nombreEmpresa, fuenteGrande, Brushes.Black, MargenIzquierdo, 30.0F)
        End If

        yPos = 60.0F

        e.Graphics.DrawString(If(Comprobante?.Empresa?.Domicilio, String.Empty), printFont, Brushes.Black, MargenIzquierdo, yPos)
        yPos += IncrementoYPreTexto

        Dim locProv As String = String.Format("{0}-{1}", Comprobante?.Empresa?.Localidad, Comprobante?.Empresa?.Provincia)
        e.Graphics.DrawString(locProv, printFont, Brushes.Black, MargenIzquierdo, yPos)
        yPos += IncrementoYPreTexto

        e.Graphics.DrawString("Telefono: " & Comprobante?.Empresa?.Telefono, printFont, Brushes.Black, MargenIzquierdo, yPos)
        yPos += IncrementoYPreTexto

        e.Graphics.DrawString("Tipo Iva: " & Comprobante?.Empresa?.IVA?.Descripcion, printFont, Brushes.Black, MargenIzquierdo, yPos)
        yPos += IncrementoYPreTexto

        e.Graphics.DrawString("CUIT: " & Comprobante?.Empresa?.Documento?.Numero, printFont, Brushes.Black, MargenIzquierdo, yPos)
        yPos += IncrementoYPreTexto

        e.Graphics.DrawString("Ing.Btos: " & Comprobante?.Empresa?.IB, printFont, Brushes.Black, MargenIzquierdo, yPos)
        yPos += IncrementoYPreTexto

        e.Graphics.DrawString("Inicio Actividades: " & Format(Comprobante?.Empresa?.FechaAlta, "dd/MM/yyyy"), printFont, Brushes.Black, MargenIzquierdo, yPos)
        yPos += IncrementoYPreLinea

        e.Graphics.DrawString(Linea, printFont, Brushes.Black, MargenIzquierdo, yPos)
        yPos += IncrementoYPreTexto

        ' Cuadro del Tipo de Comprobante (Letra / Código)
        Dim rectF1 As New RectangleF(MargenIzquierdo + 3.0F, yPos + 4.0F, 50.0F, 50.0F)
        Dim stringFormat As New StringFormat() With {
        .Alignment = StringAlignment.Center,
        .LineAlignment = StringAlignment.Center
    }

        e.Graphics.DrawString(Comprobante.TipoComprobante.Letra, fuenteGigante, Brushes.Black, rectF1, stringFormat)
        e.Graphics.DrawRectangle(Pens.Black, Rectangle.Round(rectF1))

        e.Graphics.DrawString("Cod." & Comprobante.TipoComprobante.CodiTC_ARCA, printFont, Brushes.Black, MargenIzquierdo + 9.0F, yPos + 42.0F)
        e.Graphics.DrawString(Comprobante.TipoComprobante.TipoComprobanteSLetra, printFont, Brushes.Black, MargenIzquierdo + 58.0F, yPos + 3.0F)
        yPos += IncrementoYPreTexto

        e.Graphics.DrawString("P.Vta:" & Comprobante.PVenta & "           Nro:" & Comprobante.NumComp, printFont, Brushes.Black, MargenIzquierdo + 58.0F, yPos + 10.0F)
        yPos += IncrementoYPreTexto

        e.Graphics.DrawString("Fecha:" & Format(Comprobante.FechaComp, "dd/MM/yyyy"), printFont, Brushes.Black, MargenIzquierdo + 58.0F, yPos + 10.0F)
        e.Graphics.DrawString("Hora:" & DateTime.Now.ToString("HH:mm:ss"), printFont, Brushes.Black, MargenIzquierdo + 183.0F, yPos + 10.0F)

        yPos += IncrementoYPreLinea + 15.0F
        e.Graphics.DrawString(Linea, printFont, Brushes.Black, MargenIzquierdo, yPos)

        ' Datos del Cliente
        Dim nombreCliente As String = If(Comprobante?.Cliente?.Nombre, String.Empty)
        Dim strCliente As String = If(nombreCliente.Length > 34, nombreCliente.Substring(0, 34), nombreCliente)

        yPos += IncrementoYPreTexto
        e.Graphics.DrawString("Cliente:" & strCliente, printFont, Brushes.Black, MargenIzquierdo, yPos)

        If nombreCliente.Length > 34 Then
            yPos += IncrementoYPreTexto
            Dim longitudRestante As Integer = Math.Min(42, nombreCliente.Length - 34)
            strCliente = nombreCliente.Substring(34, longitudRestante)
            e.Graphics.DrawString(strCliente, printFont, Brushes.Black, MargenIzquierdo, yPos)
        End If

        yPos += IncrementoYPreTexto
        e.Graphics.DrawString("Domicilio:" & Comprobante?.Cliente?.Localidad & "-" & Comprobante?.Cliente?.Provincia, printFont, Brushes.Black, MargenIzquierdo, yPos)
        yPos += IncrementoYPreTexto
        e.Graphics.DrawString("IVA:" & Comprobante?.Cliente?.IVA?.Descripcion, printFont, Brushes.Black, MargenIzquierdo, yPos)
        yPos += IncrementoYPreTexto
        e.Graphics.DrawString("Tipo Doc:" & Comprobante?.Cliente?.Documento?.TipoDocumento?.Descripcion, printFont, Brushes.Black, MargenIzquierdo, yPos)
        yPos += IncrementoYPreTexto
        e.Graphics.DrawString("Num.Doc:" & Comprobante?.Cliente?.Documento?.Numero, printFont, Brushes.Black, MargenIzquierdo, yPos)
        yPos += IncrementoYPreLinea
        e.Graphics.DrawString(Linea, printFont, Brushes.Black, MargenIzquierdo, yPos)

        ' Detalle del comprobante
        yPos += IncrementoYPreTexto
        e.Graphics.DrawString("Descripción", printFont, Brushes.Black, MargenIzquierdo, yPos)
        yPos += IncrementoYPreTexto
        e.Graphics.DrawString("Cant/P.Unit.     %IVA     Desc.    Importe", printFont, Brushes.Black, MargenIzquierdo, yPos)
        yPos += IncrementoYPreLinea
        e.Graphics.DrawString(Linea, printFont, Brushes.Black, MargenIzquierdo, yPos)

        For Each Item As ItemComprobante In Comprobante.Detalle
            If Item.IdArticulo Is Nothing Then Continue For

            Dim descItem As String = If(Item.Descripcion, String.Empty)
            Dim strDescripcion As String = If(descItem.Length > 42, descItem.Substring(0, 42), descItem)
            Dim strAlicIVA As String = "(" & Format(Item.AlicIVA, "Fixed") & ")"

            If Comprobante.TipoComprobante.Letra = "A" Then
                strCantPUnit = Format(Item.Cantidad, "##0.000") & "/" & Format(Item.PrecioNeto, "Fixed")
                strImpItem = Format(Item.ImporteNetoConDescuento, "Fixed")
                strImpDesItem = Format(Item.ImporteNetoDescuento, "Fixed")
                strLinea3Item = String.Empty
            Else
                strCantPUnit = Item.Cantidad.ToString() & "/" & Format(Item.PrecioUnitario, "Fixed")

                If Item.ImporteOS = 0D Then
                    strImpItem = Format(Item.ImporteConDescuento, "Fixed")
                    strImpDesItem = Format(Item.ImporteDescuento, "Fixed")
                    strLinea3Item = String.Empty
                Else
                    strImpItem = Format(Item.ImporteSinDescuento, "Fixed")
                    strImpDesItem = Format(0D, "Fixed")
                    strLinea3Item = "OS: (" & Item.PorcentajeOS.ToString() & "%) " & Format(Item.ImporteOS, "Fixed") & " AF: " & Format(Item.ImporteSinDescuento - Item.ImporteOS, "Fixed")
                End If
            End If

            Dim espaciosTab As Integer = Math.Max(0, 16 - strCantPUnit.Length)
            Tab = New String(" "c, espaciosTab)

            Dim espDesc As Integer = Math.Max(0, 8 - strImpDesItem.Length)
            Dim espImp As Integer = Math.Max(0, 11 - strImpItem.Length)

            strLinea2Item = strCantPUnit & Tab & strAlicIVA & New String(" "c, espDesc) & strImpDesItem & New String(" "c, espImp) & strImpItem

            yPos += IncrementoYPreItem
            e.Graphics.DrawString(strDescripcion.TrimStart(), printFont, Brushes.Black, MargenIzquierdo, yPos)

            yPos += IncrementoYPreTexto
            e.Graphics.DrawString(strLinea2Item, printFont, Brushes.Black, MargenIzquierdo, yPos)

            If Not String.IsNullOrEmpty(strLinea3Item) Then
                yPos += IncrementoYPreTexto
                e.Graphics.DrawString(strLinea3Item, printFont, Brushes.Black, MargenIzquierdo, yPos)
            End If
        Next

        yPos += IncrementoYPreLinea + 5.0F
        e.Graphics.DrawString(Linea, printFont, Brushes.Black, MargenIzquierdo, yPos)

        ' Totales
        If Me.Comprobante.TipoComprobante.Letra = "A" Then
            strSubTotal = Format(Comprobante.ImpNeto1 + Comprobante.ImpNeto2 + Comprobante.ImpEx, "Standard")
            yPos += IncrementoYPreTexto
            Dim espSub As Integer = Math.Max(0, 32 - strSubTotal.Length)
            e.Graphics.DrawString("Subtotal: " & New String(" "c, espSub) & strSubTotal, printFont, Brushes.Black, MargenIzquierdo, yPos)

            If Comprobante.ImpEx > 0D Then
                strImpEx = Format(Comprobante.ImpEx, "Standard")
                yPos += IncrementoYPreTexto
                Dim espEx As Integer = Math.Max(0, 30 - strImpEx.Length)
                e.Graphics.DrawString("Imp.Exento: " & New String(" "c, espEx) & strImpEx, printFont, Brushes.Black, MargenIzquierdo, yPos)
            End If

            If Comprobante.ImpNeto1 > 0D Then
                strImpNeto1 = Format(Comprobante.ImpNeto1, "Standard")
                yPos += IncrementoYPreTexto
                Dim espN1 As Integer = Math.Max(0, 26 - strImpNeto1.Length)
                e.Graphics.DrawString("Imp.Neto 10,5%: " & New String(" "c, espN1) & strImpNeto1, printFont, Brushes.Black, MargenIzquierdo, yPos)

                strIVA1 = Format(Comprobante.ImpIVA1, "Standard")
                yPos += IncrementoYPreTexto
                Dim espI1 As Integer = Math.Max(0, 29 - strIVA1.Length)
                e.Graphics.DrawString("I.V.A 10,5%: " & New String(" "c, espI1) & strIVA1, printFont, Brushes.Black, MargenIzquierdo, yPos)
            End If

            If Comprobante.ImpNeto2 > 0D Then
                strImpNeto2 = Format(Comprobante.ImpNeto2, "Standard")
                yPos += IncrementoYPreTexto
                Dim espN2 As Integer = Math.Max(0, 28 - strImpNeto2.Length)
                e.Graphics.DrawString("Imp.Neto 21%: " & New String(" "c, espN2) & strImpNeto2, printFont, Brushes.Black, MargenIzquierdo, yPos)

                strIVA2 = Format(Comprobante.ImpIVA2, "Standard")
                yPos += IncrementoYPreTexto
                Dim espI2 As Integer = Math.Max(0, 31 - strIVA2.Length)
                e.Graphics.DrawString("I.V.A 21%: " & New String(" "c, espI2) & strIVA2, printFont, Brushes.Black, MargenIzquierdo, yPos)
            End If
        End If

        strTotal = Format(Comprobante.ImpNeto + Comprobante.ImpOS, "Standard")
        yPos += IncrementoYPreTexto
        Dim espTot As Integer = Math.Max(0, 15 - strTotal.Length)
        e.Graphics.DrawString("TOTAL: " & New String(" "c, espTot) & strTotal, fuenteGrande, Brushes.Black, MargenIzquierdo, yPos)

        ' Régimen Transparencia Fiscal Ley 27743 (Facturas B)
        If Comprobante.TipoComprobante.Letra = "B" Then
            yPos += IncrementoYPreTexto
            e.Graphics.DrawString(Linea, printFont, Brushes.Black, MargenIzquierdo, yPos)
            yPos += IncrementoYPreTexto
            e.Graphics.DrawString("Régimen de Transparencia Fiscal(Ley 27743)", printFont, Brushes.Black, MargenIzquierdo, yPos)
            strIVA = Format(Comprobante.ImpIVA1 + Comprobante.ImpIVA2, "Standard")
            yPos += IncrementoYPreTexto
            Dim espIvaC As Integer = Math.Max(0, 26 - strIVA.Length)
            e.Graphics.DrawString("IVA Contenido: " & New String(" "c, espIvaC) & strIVA, printFont, Brushes.Black, MargenIzquierdo, yPos)
            yPos += IncrementoYPreTexto
            e.Graphics.DrawString("Otros Impuestos Nacionales: " & New String(" "c, 9) & "0,00", printFont, Brushes.Black, MargenIzquierdo, yPos)
            yPos += IncrementoYPreLinea
            e.Graphics.DrawString(Linea, printFont, Brushes.Black, MargenIzquierdo, yPos)
        Else
            yPos += IncrementoYPreLinea * 2.0F
        End If

        yPos += IncrementoYPreTexto
        e.Graphics.DrawString("RECIBI(MOS)", printFont, Brushes.Black, MargenIzquierdo, yPos)

        ' Formas de Pago
        If Comprobante.ImpOS > 0D Then
            strOS = Format(Comprobante.ImpOS, "Standard")
            yPos += IncrementoYPreTexto
            Dim espOS As Integer = Math.Max(0, 29 - strOS.Length)
            e.Graphics.DrawString("Obra Social: " & New String(" "c, espOS) & strOS, printFont, Brushes.Black, MargenIzquierdo, yPos)
        End If

        If Comprobante.ImpPE > 0D Then
            strTar = Format(Comprobante.ImpPE, "Standard")
            yPos += IncrementoYPreTexto
            Dim espTar As Integer = Math.Max(0, 31 - strTar.Length)
            e.Graphics.DrawString("Tarjeta/s: " & New String(" "c, espTar) & strTar, printFont, Brushes.Black, MargenIzquierdo, yPos)
        End If

        If Comprobante.ImpCC > 0D Then
            strCC = Format(Comprobante.ImpCC, "Standard")
            yPos += IncrementoYPreTexto
            Dim espCC As Integer = Math.Max(0, 24 - strCC.Length)
            e.Graphics.DrawString("Cuenta Corriente: " & New String(" "c, espCC) & strCC, printFont, Brushes.Black, MargenIzquierdo, yPos)
        End If

        If Comprobante.ImpEf > 0D Then
            strEf = Format(Comprobante.ImpEf, "Standard")
            yPos += IncrementoYPreTexto
            Dim espEf As Integer = Math.Max(0, 32 - strEf.Length)
            e.Graphics.DrawString("Efectivo: " & New String(" "c, espEf) & strEf, printFont, Brushes.Black, MargenIzquierdo, yPos)
        End If

        yPos += IncrementoYPreLinea
        e.Graphics.DrawString(Linea, printFont, Brushes.Black, MargenIzquierdo, yPos)

        ' Datos de ARCA / CAE / Código QR
        If Comprobante.CAE IsNot Nothing Then
            yPos += IncrementoYPreTexto
            e.Graphics.DrawString("      Dirección de comercio interior", printFont, Brushes.Black, MargenIzquierdo, yPos)
            yPos += IncrementoYPreTexto
            e.Graphics.DrawString("        Teléfono 0800-444-03346", printFont, Brushes.Black, MargenIzquierdo, yPos)

            If Comprobante.QR IsNot Nothing AndAlso Comprobante.QR.QR IsNot Nothing Then
                Using imgQR As Image = Me.Bytes_Imagen(Me.Comprobante.QR.QR)
                    yPos += IncrementoYPreTexto
                    e.Graphics.DrawImage(imgQR, MargenIzquierdo, yPos, 100.0F, 100.0F)
                End Using
            End If

            yPos += 60.0F
            e.Graphics.DrawString("CAE:" & Comprobante.CAE.NumCAE, printFont, Brushes.Black, 115.0F, yPos)
            yPos += IncrementoYPreTexto
            e.Graphics.DrawString("Vto:" & Format(Comprobante.CAE.VtoCAE, "dd/MM/yyyy"), printFont, Brushes.Black, 115.0F, yPos)
        End If

        ' Pie de Página / Firmas
        If textoCopia.Trim() = "ORIGINAL" Then
            yPos += 30.0F
            e.Graphics.DrawString("            GRACIAS POR SU COMPRA      ", printFont, Brushes.Black, MargenIzquierdo, yPos)
        Else
            yPos += 50.0F
            e.Graphics.DrawString(Linea, printFont, Brushes.Black, MargenIzquierdo, yPos)
            yPos += 15.0F
            e.Graphics.DrawString("                 FIRMA               ", printFont, Brushes.Black, MargenIzquierdo, yPos)
            yPos += 30.0F
            e.Graphics.DrawString(Linea, printFont, Brushes.Black, MargenIzquierdo, yPos)
            yPos += 15.0F
            e.Graphics.DrawString("               ACLARACIÓN             ", printFont, Brushes.Black, MargenIzquierdo, yPos)
        End If

        If Comprobante.CAE Is Nothing Then
            yPos += 30.0F
            e.Graphics.DrawString("DOCUMENTO NO VALIDO COMO FACTURA", printFont, Brushes.Black, MargenIzquierdo, yPos)
        End If

        ' NOTA IMPORTANTE: Se quitó e.Graphics.Dispose() para evitar romper el motor de impresión de .NET
    End Sub

    Private Sub RECIBO(ByVal sender As Object, ByVal e As PrintPageEventArgs)
        ' Declaramos las constantes directamente como Single
        Const IncrementoYPreTexto As Single = 15.0F
        Const IncrementoYPreLinea As Single = 5.0F
        Const IncrementoYPreItem As Single = 20.0F
        Const MargenIzquierdo As Single = 10.0F
        Const Linea As String = "__________________________________________"

        ' Variable de posición vertical en tipo Single para Option Strict On
        Dim yPos As Single = 60.0F
        Dim strTotal As String
        Dim strTar As String
        Dim strEf As String

        ' Usamos 'Using' para asegurar la correcta liberación de memoria de TODAS las fuentes
        Using printFont As New Font("consolas", 8),
          fuenteGrande As New Font("consolas", 15),
          fuenteGigante As New Font("consolas", 30),
          stringFormat As New StringFormat()

            stringFormat.Alignment = StringAlignment.Center
            stringFormat.LineAlignment = StringAlignment.Center

            ' Copia
            e.Graphics.DrawString(Copia, printFont, Brushes.Black, MargenIzquierdo, 5.0F)

            ' Empresa
            If Len(Comprobante.Empresa.Nombre) > 20 Then
                e.Graphics.DrawString(Comprobante.Empresa.Nombre, printFont, Brushes.Black, MargenIzquierdo, 30.0F)
            Else
                e.Graphics.DrawString(Comprobante.Empresa.Nombre, fuenteGrande, Brushes.Black, MargenIzquierdo, 30.0F)
            End If

            e.Graphics.DrawString(Comprobante.Empresa.Domicilio, printFont, Brushes.Black, MargenIzquierdo, yPos)
            yPos += IncrementoYPreTexto
            e.Graphics.DrawString(Comprobante.Empresa.Localidad & "-" & Comprobante.Empresa.Provincia, printFont, Brushes.Black, MargenIzquierdo, yPos)
            yPos += IncrementoYPreTexto
            e.Graphics.DrawString("Telefono: " & Comprobante.Empresa.Telefono, printFont, Brushes.Black, MargenIzquierdo, yPos)
            yPos += IncrementoYPreTexto
            e.Graphics.DrawString("Tipo Iva: " & Comprobante.Empresa.IVA.Descripcion, printFont, Brushes.Black, MargenIzquierdo, yPos)
            yPos += IncrementoYPreTexto
            e.Graphics.DrawString("CUIT: " & Comprobante.Empresa.Documento.Numero, printFont, Brushes.Black, MargenIzquierdo, yPos)
            yPos += IncrementoYPreTexto
            e.Graphics.DrawString("Ing.Btos: " & Comprobante.Empresa.IB, printFont, Brushes.Black, MargenIzquierdo, yPos)
            yPos += IncrementoYPreTexto
            e.Graphics.DrawString("Inicio Actividades: " & Comprobante.Empresa.FechaAlta, printFont, Brushes.Black, MargenIzquierdo, yPos)
            yPos += IncrementoYPreLinea
            e.Graphics.DrawString(Linea, printFont, Brushes.Black, MargenIzquierdo, yPos)
            yPos += IncrementoYPreTexto

            ' Comprobante / Recuadro Letra
            Dim rectF1 As New RectangleF(MargenIzquierdo + 3.0F, yPos + 4.0F, 50.0F, 50.0F)
            e.Graphics.DrawString(Comprobante.TipoComprobante.Letra, fuenteGigante, Brushes.Black, rectF1, stringFormat)
            e.Graphics.DrawRectangle(Pens.Black, Rectangle.Round(rectF1))

            e.Graphics.DrawString("Cod." & Comprobante.TipoComprobante.CodiTC_ARCA, printFont, Brushes.Black, MargenIzquierdo + 9.0F, yPos + 42.0F)
            e.Graphics.DrawString(Comprobante.TipoComprobante.TipoComprobanteSLetra, printFont, Brushes.Black, MargenIzquierdo + 58.0F, yPos + 3.0F)
            yPos += IncrementoYPreTexto
            e.Graphics.DrawString("P.Vta:" & Comprobante.PVenta & "           Nro:" & Comprobante.NumComp, printFont, Brushes.Black, MargenIzquierdo + 58.0F, yPos + 10.0F)
            yPos += IncrementoYPreTexto
            e.Graphics.DrawString("Fecha:" & Comprobante.FechaComp, printFont, Brushes.Black, MargenIzquierdo + 58.0F, yPos + 10.0F)

            Dim hora As String = TimeString
            e.Graphics.DrawString("Hora:" & hora, printFont, Brushes.Black, MargenIzquierdo + 183.0F, yPos + 10.0F)
            yPos += IncrementoYPreLinea + 15.0F
            e.Graphics.DrawString(Linea, printFont, Brushes.Black, MargenIzquierdo, yPos)

            ' Cliente
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
            e.Graphics.DrawString("IVA:" & Comprobante.Cliente.IVA.Descripcion, printFont, Brushes.Black, MargenIzquierdo, yPos)
            yPos += IncrementoYPreTexto
            e.Graphics.DrawString("Tipo Doc:" & Comprobante.Cliente.Documento.TipoDocumento.Descripcion, printFont, Brushes.Black, MargenIzquierdo, yPos)
            yPos += IncrementoYPreTexto
            e.Graphics.DrawString("Num.Doc:" & Comprobante.Cliente.Documento.Numero, printFont, Brushes.Black, MargenIzquierdo, yPos)
            yPos += IncrementoYPreLinea
            e.Graphics.DrawString(Linea, printFont, Brushes.Black, MargenIzquierdo, yPos)

            ' Detalle
            yPos += IncrementoYPreTexto
            e.Graphics.DrawString("RECIBI(MOS) LA SUMA DE PESOS: ", printFont, Brushes.Black, MargenIzquierdo, yPos)

            ' Importe en Letras con wrap de 41 caracteres
            Dim strTextoImporte As String = UCase(Vecho.NumEnLetras(Format(Comprobante.ImpBto, "Fixed")))
            Dim caracteresLeidos As Integer = 0
            Dim totalCaracteres As Integer = Len(strTextoImporte)

            Do While caracteresLeidos < totalCaracteres
                Dim leerCantidad As Integer = Math.Min(41, totalCaracteres - caracteresLeidos)
                Dim strTextoParcial As String = Mid(strTextoImporte, caracteresLeidos + 1, leerCantidad)

                yPos += IncrementoYPreTexto
                e.Graphics.DrawString(strTextoParcial, printFont, Brushes.Black, MargenIzquierdo, yPos)
                caracteresLeidos += leerCantidad
            Loop

            yPos += 2.0F * IncrementoYPreTexto
            e.Graphics.DrawString("EN CONCEPTO DE: ", printFont, Brushes.Black, MargenIzquierdo, yPos)

            yPos += IncrementoYPreItem
            e.Graphics.DrawString(Left(Me.Comprobante.Operacion.TipoOperacion.TipoOperacion, 41), printFont, Brushes.Black, MargenIzquierdo, yPos)

            yPos += IncrementoYPreTexto
            strTotal = "$" & Comprobante.ImpBto.ToString("N2")
            e.Graphics.DrawString("SON PESOS: " & StrDup(Math.Max(0, 11 - Len(strTotal)), " "c) & strTotal, fuenteGrande, Brushes.Black, MargenIzquierdo, yPos)
            yPos += 2.0F * IncrementoYPreTexto
            e.Graphics.DrawString("RECIBI(MOS)", printFont, Brushes.Black, MargenIzquierdo, yPos)

            If Comprobante.ImpPE > 0 Then
                yPos += IncrementoYPreTexto
                strTar = "$" & Comprobante.ImpPE.ToString("N2")
                e.Graphics.DrawString("Tarjeta/s: " & StrDup(Math.Max(0, 31 - Len(strTar)), " "c) & strTar, printFont, Brushes.Black, MargenIzquierdo, yPos)
            End If

            If Comprobante.ImpEf > 0 Then
                yPos += IncrementoYPreTexto
                strEf = "$" & Comprobante.ImpEf.ToString("N2")
                e.Graphics.DrawString("Efectivo: " & StrDup(Math.Max(0, 32 - Len(strEf)), " "c) & strEf, printFont, Brushes.Black, MargenIzquierdo, yPos)
            End If

            yPos += IncrementoYPreLinea
            e.Graphics.DrawString(Linea, printFont, Brushes.Black, MargenIzquierdo, yPos)
            yPos += IncrementoYPreTexto
            e.Graphics.DrawString("Documento no válido como Factura", printFont, Brushes.Black, MargenIzquierdo, yPos)

            ' Observaciones
            If Not String.IsNullOrEmpty(Comprobante.Operacion.Observaciones) Then
                Dim lineas() As String = Split(Comprobante.Operacion.Observaciones, vbCrLf)

                yPos += IncrementoYPreLinea
                e.Graphics.DrawString(Linea, printFont, Brushes.Black, MargenIzquierdo, yPos)
                yPos += IncrementoYPreTexto
                e.Graphics.DrawString("Observaciones:", printFont, Brushes.Black, MargenIzquierdo, yPos)

                For Each strLinea As String In lineas
                    Dim inicioSubcadena As Integer = 1
                    Dim largoLinea As Integer = Len(strLinea)

                    If largoLinea > 42 Then
                        Do While inicioSubcadena <= largoLinea
                            Dim strLineaObservaciones As String = Mid(strLinea, inicioSubcadena, 42)
                            yPos += IncrementoYPreTexto
                            e.Graphics.DrawString(strLineaObservaciones.TrimStart(" "c), printFont, Brushes.Black, MargenIzquierdo, yPos)
                            inicioSubcadena += 42
                        Loop
                    Else
                        yPos += IncrementoYPreTexto
                        e.Graphics.DrawString(strLinea.TrimStart(" "c), printFont, Brushes.Black, MargenIzquierdo, yPos)
                    End If
                Next
            End If

        End Using
    End Sub

    Private Sub DINTERNO(ByVal sender As Object, ByVal e As PrintPageEventArgs)
        ' Declaración directa como Single para Option Strict On
        Const IncrementoYPreTexto As Single = 15.0F
        Const IncrementoYPreLinea As Single = 5.0F
        Const MargenIzquierdo As Single = 10.0F
        Const Linea As String = "__________________________________________"

        Dim yPos As Single = 60.0F
        Dim strTotal As String

        ' Liberación segura de recursos gráficos mediante Using
        Using printFont As New Font("consolas", 8),
          fuenteGrande As New Font("consolas", 15),
          fuenteGigante As New Font("consolas", 30),
          stringFormat As New StringFormat()

            stringFormat.Alignment = StringAlignment.Center
            stringFormat.LineAlignment = StringAlignment.Center

            ' Encabezado
            e.Graphics.DrawString(Copia, printFont, Brushes.Black, MargenIzquierdo, 5.0F)

            If Len(Comprobante.Empresa.Nombre) > 20 Then
                e.Graphics.DrawString(Comprobante.Empresa.Nombre, printFont, Brushes.Black, MargenIzquierdo, 30.0F)
            Else
                e.Graphics.DrawString(Comprobante.Empresa.Nombre, fuenteGrande, Brushes.Black, MargenIzquierdo, 30.0F)
            End If

            e.Graphics.DrawString(Comprobante.Empresa.Domicilio, printFont, Brushes.Black, MargenIzquierdo, yPos)
            yPos += IncrementoYPreTexto
            e.Graphics.DrawString(Comprobante.Empresa.Localidad & "-" & Comprobante.Empresa.Provincia, printFont, Brushes.Black, MargenIzquierdo, yPos)
            yPos += IncrementoYPreTexto
            e.Graphics.DrawString("Telefono: " & Comprobante.Empresa.Telefono, printFont, Brushes.Black, MargenIzquierdo, yPos)
            yPos += IncrementoYPreTexto
            e.Graphics.DrawString("Tipo Iva: " & Comprobante.Empresa.IVA.Descripcion, printFont, Brushes.Black, MargenIzquierdo, yPos)
            yPos += IncrementoYPreTexto
            e.Graphics.DrawString("CUIT: " & Comprobante.Empresa.Documento.Numero, printFont, Brushes.Black, MargenIzquierdo, yPos)
            yPos += IncrementoYPreTexto
            e.Graphics.DrawString("Ing.Btos: " & Comprobante.Empresa.IB, printFont, Brushes.Black, MargenIzquierdo, yPos)
            yPos += IncrementoYPreTexto
            e.Graphics.DrawString("Inicio Actividades: " & Comprobante.Empresa.FechaAlta, printFont, Brushes.Black, MargenIzquierdo, yPos)
            yPos += IncrementoYPreLinea
            e.Graphics.DrawString(Linea, printFont, Brushes.Black, MargenIzquierdo, yPos)
            yPos += IncrementoYPreTexto

            ' Recuadro Letra
            Dim rectF1 As New RectangleF(MargenIzquierdo + 3.0F, yPos + 4.0F, 50.0F, 50.0F)
            e.Graphics.DrawString(Comprobante.TipoComprobante.Letra, fuenteGigante, Brushes.Black, rectF1, stringFormat)
            e.Graphics.DrawRectangle(Pens.Black, Rectangle.Round(rectF1))

            e.Graphics.DrawString("Cod." & Comprobante.TipoComprobante.CodiTC_ARCA, printFont, Brushes.Black, MargenIzquierdo + 9.0F, yPos + 42.0F)
            e.Graphics.DrawString(Comprobante.TipoComprobante.TipoComprobanteSLetra, printFont, Brushes.Black, MargenIzquierdo + 58.0F, yPos + 3.0F)
            yPos += IncrementoYPreTexto
            e.Graphics.DrawString("P.Vta:" & Comprobante.PVenta & "           Nro:" & Comprobante.NumComp, printFont, Brushes.Black, MargenIzquierdo + 58.0F, yPos + 10.0F)
            yPos += IncrementoYPreTexto
            e.Graphics.DrawString("Fecha:" & Comprobante.FechaComp, printFont, Brushes.Black, MargenIzquierdo + 58.0F, yPos + 10.0F)

            Dim hora As String = TimeString
            e.Graphics.DrawString("Hora:" & hora, printFont, Brushes.Black, MargenIzquierdo + 183.0F, yPos + 10.0F)
            yPos += IncrementoYPreLinea + 15.0F
            e.Graphics.DrawString(Linea, printFont, Brushes.Black, MargenIzquierdo, yPos)

            ' Detalle del Comprobante
            yPos += IncrementoYPreTexto
            e.Graphics.DrawString("Operación: " & Comprobante.Operacion.TipoOperacion.TipoOperacion, printFont, Brushes.Black, MargenIzquierdo, yPos)

            yPos += IncrementoYPreTexto
            strTotal = "$" & Comprobante.ImpBto.ToString("N2")
            e.Graphics.DrawString("Importe Operacion: " & strTotal, printFont, Brushes.Black, MargenIzquierdo, yPos)

            yPos += IncrementoYPreLinea
            e.Graphics.DrawString(Linea, printFont, Brushes.Black, MargenIzquierdo, yPos)
            yPos += IncrementoYPreTexto
            e.Graphics.DrawString("Documento no válido como Factura", printFont, Brushes.Black, MargenIzquierdo, yPos)

            ' Observaciones
            If Not String.IsNullOrEmpty(Comprobante.Operacion.Observaciones) Then
                Dim lineas() As String = Split(Comprobante.Operacion.Observaciones, vbCrLf)

                yPos += IncrementoYPreLinea
                e.Graphics.DrawString(Linea, printFont, Brushes.Black, MargenIzquierdo, yPos)
                yPos += IncrementoYPreTexto
                e.Graphics.DrawString("Observaciones:", printFont, Brushes.Black, MargenIzquierdo, yPos)

                For Each strLinea As String In lineas
                    Dim inicioSubcadena As Integer = 1
                    Dim largoLinea As Integer = Len(strLinea)

                    If largoLinea > 42 Then
                        Do While inicioSubcadena <= largoLinea
                            Dim strLineaObservaciones As String = Mid(strLinea, inicioSubcadena, 42)
                            yPos += IncrementoYPreTexto
                            e.Graphics.DrawString(strLineaObservaciones.TrimStart(" "c), printFont, Brushes.Black, MargenIzquierdo, yPos)
                            inicioSubcadena += 42
                        Loop
                    Else
                        yPos += IncrementoYPreTexto
                        e.Graphics.DrawString(strLinea.TrimStart(" "c), printFont, Brushes.Black, MargenIzquierdo, yPos)
                    End If
                Next
            End If

        End Using
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
            Case "FAA", "FAB", "FAC", "NCA", "NCB", "NCC", "NCX", "RECR", "PRESU", "RTOX"
                AddHandler printDoc.PrintPage, AddressOf FACTURA
            Case "REC"
                AddHandler printDoc.PrintPage, AddressOf RECIBO
            Case "DI"
                AddHandler printDoc.PrintPage, AddressOf DINTERNO

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
