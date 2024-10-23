Imports SiCoFa.Entidades
Imports SiCoFa.Negocio
Public Class FrmComprobantes
    Private mobj_N_AdminContratos As New cls_N_AdminSiCoFa
    Private mobj_N_AdminDB As New cls_N_AdminDB
    Private mobjComprobantes As DataTable
    Private Sub GenerarReporte(ByVal argComprobante As Comprobante, ByVal argTipo As String, Optional ByVal argPathArchivo As String = "")
        Select Case argComprobante.TipoComprobante.CodiTC_SiCoFa
            Case "REC"
                Me.GenerarRecibo(argComprobante, argTipo, argPathArchivo)
            Case "FAA", "FAB", "FAC", "NCA", "NCB", "NCC"
                Me.GenerarComprobante(argComprobante, argTipo, argPathArchivo)
        End Select
    End Sub
    Private Sub GenerarComprobante(ByVal argComprobante As Comprobante, ByVal argTipo As String, Optional ByVal argPathArchivo As String = "")
        Try
            Dim Reporte As New clsReporteComprobantes

            If argComprobante.CAE IsNot Nothing Then
                Dim CUIT As Long = CLng(Replace(argComprobante.Locador.Documento.Numero, "-", ""))
                Dim PVta As Integer = CInt(argComprobante.PVenta)
                Dim NumComp As Long = CLng(argComprobante.NumComp)
                argComprobante.QR = New QRCompE(argComprobante.FechaComp, CUIT, PVta, argComprobante.TipoComprobante.CodiTC_AFIP, NumComp, argComprobante.ImpBto, argComprobante.Cliente.Documento.TipoDoc.CodiTDoc, argComprobante.Cliente.Documento.Numero, argComprobante.CAE.NumCAE)
            End If

            With Reporte
                .Locador.Add(argComprobante.Locador)
                .DocumentoLocador.Add(argComprobante.Locador.Documento)
                .IVALocador.Add(argComprobante.Locador.IVA)
                .Cliente.Add(argComprobante.Cliente)
                .DocumentoCliente.Add(argComprobante.Cliente.Documento)
                .IVACliente.Add(argComprobante.Cliente.IVA)
                .TipoDocumentoCliente.Add(argComprobante.Cliente.Documento.TipoDoc)
                .Encabezado.Add(argComprobante)
                .TipoComprobante.Add(argComprobante.TipoComprobante)
                .Detalle = argComprobante.Detalle
                .CAE.Add(argComprobante.CAE)
                .QR.Add(argComprobante.QR)
                .Copia = "ORIGINAL"

                If argComprobante.CompAsoc IsNot Nothing Then
                    .CompAsoc = "Comprobante Asociado: " & argComprobante.CompAsoc.TipoComprobante.TipoComprobante & " " & argComprobante.CompAsoc.TipoComprobante.Letra & " " & argComprobante.CompAsoc.PVenta & "-" & argComprobante.CompAsoc.NumComp
                Else
                    .CompAsoc = ""
                End If

                .PathArchivo = argPathArchivo
                .Run(argTipo)
                .Dispose()
            End With

            Reporte = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Private Sub GenerarRecibo(ByVal argComprobante As Comprobante, ByVal argTipo As String, Optional ByVal argPathArchivo As String = "")
        Try
            Dim Reporte As New clsReporteRecibo
            Dim Concepto As String = ""
            Dim sql As String = "SELECT ImpPagado,ImpAplicado,ImpNoAplicado FROM ConPagoClientes WHERE IdOperacion=" & argComprobante.IdOperacion
            Dim dt As DataTable = mobj_N_AdminDB.ObtenerTabla(sql)
            Dim ImpPagado As Decimal = CType(dt.Rows(0)(0), Decimal)
            Dim ImpAplicado As Decimal = CType(dt.Rows(0)(1), Decimal)
            Dim ImpAnticipos As Decimal = CType(dt.Rows(0)(2), Decimal)

            If ImpAplicado > 0 And ImpAnticipos > 0 Then
                Concepto =
                "-Cancelación Cuenta Clientes:" & Space(10 - Len(Format(ImpAplicado, "Standard"))) & "$" & Format(ImpAplicado, "Standard") & vbCrLf &
                "-Anticipo de Clientes:" & Space(17 - Len(Format(ImpAnticipos, "Standard"))) & "$" & Format(ImpAnticipos, "Standard")

            ElseIf ImpAplicado > 0 And ImpAnticipos = 0 Then
                Concepto = "Cancelación Cuenta de Clientes"

            ElseIf ImpAplicado = 0 And ImpAnticipos > 0 Then
                Concepto = "Anticipo de Clientes"

            End If

            With Reporte
                .Locador.Add(argComprobante.Locador)
                .DocumentoLocador.Add(argComprobante.Locador.Documento)
                .IVALocador.Add(argComprobante.Locador.IVA)
                .Cliente.Add(argComprobante.Cliente)
                .DocumentoCliente.Add(argComprobante.Cliente.Documento)
                .IVACliente.Add(argComprobante.Cliente.IVA)
                .TipoDocumentoCliente.Add(argComprobante.Cliente.Documento.TipoDoc)
                .Encabezado.Add(argComprobante)
                .TipoComprobante.Add(argComprobante.TipoComprobante)
                .Copia = "ORIGINAL"
                .CantidadEnLetras = UCase(Vecho.NumEnLetras(ImpPagado))
                .Concepto = Concepto
                .PathArchivo = argPathArchivo
                .Run(argTipo)
                .Dispose()
            End With

            Reporte = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Public Sub MostrarComprobantes(ByVal argIdCliente As Integer, ByVal argCodiTC As String, ByVal argFechaDesde As String, ByVal argFechaHasta As String)

        Try
            Dim sql As String

            If argIdCliente = 0 And argCodiTC = "0" Then
                sql = "SELECT IdOperacion,FechaComp,TipoComp,PVenta,NumComp,Locador,Cliente,CompAsoc FROM ConComprobantesCompAsoc WHERE FechaComp BETWEEN '" & argFechaDesde & "' AND '" & argFechaHasta & "'"
            ElseIf argIdCliente > 0 And argCodiTC <> "0" Then
                sql = "SELECT IdOperacion,FechaComp,TipoCompr,PVenta,NumComp,Locador,Cliente,CompAsoc FROM ConComprobantesCompAsoc WHERE CodiTC='" & argCodiTC & "' AND IdCliente=" & argIdCliente & " AND FechaComp BETWEEN '" & argFechaDesde & "' AND '" & argFechaHasta & "'"
            ElseIf argIdCliente = 0 And argCodiTC <> "0" Then
                sql = "SELECT IdOperacion,FechaComp,TipoComp,PVenta,NumComp,Locador,Cliente,CompAsoc FROM ConComprobantesCompAsoc WHERE CodiTC='" & argCodiTC & "' AND FechaComp BETWEEN '" & argFechaDesde & "' AND '" & argFechaHasta & "'"
            ElseIf argIdCliente > 0 And argCodiTC = "0" Then
                sql = "SELECT IdOperacion,FechaComp,TipoComp,PVenta,NumComp,Locador,Cliente,CompAsoc FROM ConComprobantesCompAsoc WHERE IdCliente=" & argIdCliente & " AND FechaComp BETWEEN '" & argFechaDesde & "' AND '" & argFechaHasta & "'"
            End If

            mobjComprobantes = mobj_N_AdminDB.ObtenerTabla(sql)

            If mobjComprobantes Is Nothing Then
                Exit Sub
            End If

            Me.DataGridView1.DataSource = mobjComprobantes

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Private Sub ActualizarTotales()
        Try
            If Me.DataGridView1.CurrentRow.Cells(0).Value Is Nothing Then
                Exit Sub
            End If
            Dim sql As String = "SELECT ImpBto,ImpEf,ImpCC,ImpCB,ImpTar FROM TblComprobantes WHERE IdOperacion=" & Me.DataGridView1.CurrentRow.Cells(0).Value

            Using dt As DataTable = mobj_N_AdminDB.ObtenerTabla(sql)
                Dim row As DataRow = dt.Rows(0)
                Me.ImpBto.Text = Format(row("ImpBto").ToString, "Standard")
                Me.ImpEf.Text = Format(row("ImpEf").ToString, "Standard")
                Me.ImpCC.Text = Format(row("ImpCC").ToString, "Standard")
                Me.ImpCB.Text = Format(row("ImpCB").ToString, "Standard")
                Me.ImpTar.Text = Format(row("ImpTar").ToString, "Standard")
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Private Sub ActualizarDetalle(ByVal argTipoComp As String)
        Try

            Select Case argTipoComp
                Case "Recibo"
                    Me.DataGridView2.Visible = False
                    Me.DataGridView3.Visible = True
                    Me.ActualizarDetalleRecibo()

                Case Else
                    Me.DataGridView2.Visible = True
                    Me.DataGridView3.Visible = False
                    Me.ActualizarDetalleComprobante()

            End Select

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Private Sub ActualizarDetalleComprobante()

        Try
            If Me.DataGridView1.CurrentRow.Cells(0).Value Is Nothing Then
                Exit Sub
            End If

            Dim sql As String = "SELECT Descripcion,Cantidad,PUnit,(Cantidad*PUnit) AS Importe FROM TblDetServicios WHERE IdOperaFactura=" & Me.DataGridView1.CurrentRow.Cells(0).Value
            Dim DetalleFactura As DataTable = mobj_N_AdminDB.ObtenerTabla(sql)
            Me.DataGridView3.DataSource = DetalleFactura
            Me.DataGridView3.Refresh()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub ActualizarDetalleRecibo()

        Try
            If Me.DataGridView1.CurrentRow.Cells(0).Value Is Nothing Then
                Exit Sub
            End If

            Dim sql As String = "SELECT IdOperacion AS IdPago,ImpPagado,ImpAplicado,ImpNoAplicado,EstadoPago FROM ConPagoClientes WHERE IdOperacion=" & Me.DataGridView1.CurrentRow.Cells(0).Value
            Dim DetalleRecibo As DataTable = mobj_N_AdminDB.ObtenerTabla(sql)
            Me.DataGridView3.DataSource = DetalleRecibo
            Me.DataGridView3.Refresh()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Private Sub DetallePago(ByVal argIdPago As Long)
        ' Crear un nuevo formulario para mostrar los datos relacionados

        Try
            Dim sql As String = "SELECT Fecha,CodiTo,Resu,ImpFacturado,ImpCancelado,SaldoCA,SaldoCP,SaldoPA,SaldoPP,EstadoOperaContrato FROM ConOperaCancel WHERE IdOperaPago=" & argIdPago

            Dim relatedForm As New Form()
            With relatedForm
                .ControlBox = False
                .FormBorderStyle = FormBorderStyle.None
                .StartPosition = FormStartPosition.Manual
                .Left = Me.Left + 32
                .Top = Me.DataGridView3.Top + 245 + Me.DataGridView3.CurrentRow.Height + Me.DataGridView3.CurrentRow.Index * 22 'Top + (barra de titulo + encabezado dgv) + Altura del Registro
                .Width = 980
                .Height = 100
                .KeyPreview = True
            End With

            Dim relatedGrid As New DataGridView()
            With relatedGrid
                .Dock = DockStyle.Fill
                .AllowUserToDeleteRows = False
                .AllowUserToAddRows = False
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .DataSource = mobj_N_AdminDB.ObtenerTabla(sql)
            End With

            AddHandler relatedGrid.DataBindingComplete, AddressOf AdjustColumnWidths

            ' Asignar el evento KeyDown para cerrar el formulario con la tecla Escape
            AddHandler relatedForm.KeyDown, AddressOf relatedForm_KeyDown

            With relatedForm
                .Controls.Add(relatedGrid)
                .Height = relatedGrid.Height
                .ShowDialog()
            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Private Sub AdjustColumnWidths(sender As Object, e As DataGridViewBindingCompleteEventArgs)
        Dim grid As DataGridView = CType(sender, DataGridView)
        ' Ajustar el ancho de las columnas aquí
        With grid
            With .Columns(0)
                .HeaderText = "Fecha"
                .Width = 120
            End With

            With .Columns(1)
                .HeaderText = "CodiTO"
                .Width = 60
            End With

            With .Columns(2)
                .HeaderText = "Resumen"
                .Width = 70
            End With

            With .Columns(3)
                .HeaderText = "Imp.Facturado"
                .Width = 90
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With

            With .Columns(4)
                .HeaderText = "Imp.Cancelado"
                .Width = 90
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With

            With .Columns(5)
                .HeaderText = "SaldoResu.Ant."
                .Width = 90
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With

            With .Columns(6)
                .HeaderText = "SaldoResu.Post."
                .Width = 90
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With

            With .Columns(7)
                .HeaderText = "SaldoPago.Ant."
                .Width = 100
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With

            With .Columns(8)
                .HeaderText = "SaldoPago.Post."
                .Width = 100
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End With

            With .Columns(9)
                .HeaderText = "Estado Resumen"
                .Width = 100
            End With

            .ClearSelection()
        End With
    End Sub
    Private Sub DataGridView3_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick, DataGridView3.CellClick

        Try
            If e.ColumnIndex = 0 AndAlso e.RowIndex >= 0 Then
                Dim btnCell As DataGridViewButtonCell = CType(Me.DataGridView3.Rows(e.RowIndex).Cells(0), DataGridViewButtonCell)

                With btnCell
                    .UseColumnTextForButtonValue = False
                    .Value = "-"
                End With

                Me.DetallePago(Me.DataGridView3.CurrentRow.Cells(1).Value)

            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Private Sub relatedForm_KeyDown(sender As Object, e As KeyEventArgs)

        Try
            ' Cierra el formulario cuando se presiona la tecla Escape
            If e.KeyCode = Keys.Escape Then
                DirectCast(sender, Form).Close()
                Dim btnCell As DataGridViewButtonCell = CType(Me.DataGridView3.CurrentRow.Cells(0), DataGridViewButtonCell)
                With btnCell
                    .UseColumnTextForButtonValue = False
                    .Value = "+"
                End With
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        'If mblnCargaFinalizada = False Then
        'Exit Sub
        'End If

        Try
            'Dim c As Comprobante = mobjComprobantes.Find(Function(p) p.IdOperacion = Me.DataGridView1.CurrentRow.Cells(0).Value)
            Me.ActualizarTotales()
            Me.ActualizarDetalle(Me.DataGridView1.CurrentRow.Cells(2).Value)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Private Sub ImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirToolStripMenuItem.Click
        Try
            If Me.DataGridView1.CurrentRow.Cells(0).Value Is Nothing Then
                Exit Sub
            End If

            Dim o As Operacion = mobj_N_AdminContratos.ObtenerOperacion(Me.DataGridView1.CurrentRow.Cells(0).Value)
            Dim c As Comprobante = mobj_N_AdminContratos.ObtenerComprobante(o) 'mobjComprobantes.Find(Function(p) p.IdOperacion = Me.DataGridView1.CurrentRow.Cells(0).Value)
            Me.GenerarReporte(c, "IMPA4")

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Private Sub GuardarComoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarComoToolStripMenuItem.Click

        If Me.DataGridView1.CurrentRow.Cells(0).Value Is Nothing Then
            Exit Sub
        End If

        Try

            Dim saveFileDialog1 As New SaveFileDialog()
            Dim o As Operacion = mobj_N_AdminContratos.ObtenerOperacion(Me.DataGridView1.CurrentRow.Cells(0).Value)
            Dim c As Comprobante = mobj_N_AdminContratos.ObtenerComprobante(o) 'mobjComprobantes.Find(Function(p) p.IdOperacion = Me.DataGridView1.CurrentRow.Cells(0).Value)

            If c.IdOperAsoc > 0 Then
                c.CompAsoc = mobj_N_AdminContratos.ObtenerComprobante(c.Operacion)
            End If

            With saveFileDialog1
                .Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
                .FilterIndex = 2
                .FileName = c.TipoComprobante.CodiTC_SiCoFa & "-" & c.PVenta & "-" & c.NumComp
                .DefaultExt = ".pdf"
                .RestoreDirectory = True
            End With

            If saveFileDialog1.ShowDialog() = DialogResult.OK Then
                Me.GenerarReporte(c, "PDFA4", saveFileDialog1.FileName)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Private Sub EnviarMailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnviarMailToolStripMenuItem.Click

        If Me.DataGridView1.CurrentRow.Cells(0).Value Is Nothing Then
            Exit Sub
        End If

        Try
            Dim o As Operacion = mobj_N_AdminContratos.ObtenerOperacion(Me.DataGridView1.CurrentRow.Cells(0).Value)
            Dim c As Comprobante = mobj_N_AdminContratos.ObtenerComprobante(o) 'mobjComprobantes.Find(Function(p) p.IdOperacion = Me.DataGridView1.CurrentRow.Cells(0).Value)
            Dim Archivo = c.TipoComprobante.CodiTC_SiCoFa & "-" & c.PVenta & "-" & c.NumComp & ".pdf"
            Dim TempPat As String = Application.StartupPath & "\Temp\" & Archivo
            Me.GenerarReporte(c, "PDFA4", TempPat)
            Dim obj_N_AdminEmail As New cls_N_AdminEmail
            Dim Mensaje = "Estimado Cliente, adjunto Comprobante " & Archivo & vbCrLf & vbCrLf & "Atentamente: " & c.Locador.Nombre
            obj_N_AdminEmail.EnviarMail(c.Locador.Nombre, c.Cliente.Email, Archivo, Mensaje, TempPat)
            MsgBox("Se envió el comprobante " & Archivo, vbInformation, "SiCoFa")

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Private Sub FrmComprobantes_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        FrmAperComprobantes.Close()
    End Sub

End Class