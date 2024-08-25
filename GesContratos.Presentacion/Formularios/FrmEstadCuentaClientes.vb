Imports SiCoFa.Entidades
Imports SiCoFa.Negocio
Public Class FrmEstadCuentaClientes

    Private mobjCliente As Cliente
    Private mobjContrato As Contrato

    Private mobj_N_AdminDB As New cls_N_AdminDB
    Public Sub OperaContratos(ByVal argCliente As Cliente, ByVal argContrato As Contrato, ByVal argEstadoResu As String)
        Dim sql As String

        Select Case argEstadoResu
            Case "DEBE"
                sql = "SELECT IdOperacion,Resu,ImpFacturado,ImpCancelado,ImpNoCancelado,EstadoOperaContrato FROM ConOperaContratos WHERE IdCliente=" & argCliente.IdCliente & " AND EstadoOperaContrato='DEBE'"
                For Each i As ToolStripMenuItem In Me.VerToolStripMenuItem.DropDownItems
                    i.Checked = False
                Next

                Me.OperacionesNoCanceladasToolStripMenuItem.Checked = True

            Case "CANCELADO"
                sql = "SELECT IdOperacion,Resu,ImpFacturado,ImpCancelado,ImpNoCancelado,EstadoOperaContrato FROM ConOperaContratos WHERE IdCliente=" & argCliente.IdCliente & " AND EstadoOperaContrato='CANCELADO'"

                For Each i As ToolStripMenuItem In Me.VerToolStripMenuItem.DropDownItems
                    i.Checked = False
                Next

                Me.OperacionesCanceladasToolStripMenuItem.Checked = True

            Case "TODOS"
                sql = "SELECT IdOperacion,Resu,ImpFacturado,ImpCancelado,ImpNoCancelado,EstadoOperaContrato FROM ConOperaContratos WHERE IdCliente=" & argCliente.IdCliente

                For Each i As ToolStripMenuItem In Me.VerToolStripMenuItem.DropDownItems
                    i.Checked = False
                Next

                Me.TodasLasOperacionesToolStripMenuItem.Checked = True

        End Select

        If mobjCliente Is Nothing Then
            Me.mobjCliente = argCliente
            Me.Label1.Text = "IdCliente:" & Me.mobjCliente.IdCliente
            Me.Label2.Text = "Cliente:  " & Me.mobjCliente.Nombre
        End If

        If mobjContrato Is Nothing Then
            Me.mobjContrato = argContrato
            Dim TotalesContrato As String = "SELECT * FROM ConSaldoContratos WHERE IdContrato=" & mobjContrato.IdContrato
            Dim TotalPagos As String = "SELECT * FROM ConPagoClientes WHERE IdContrato=" & mobjContrato.IdContrato

            Dim dt As DataTable = mobj_N_AdminDB.ObtenerTabla(TotalesContrato)

            If dt.Rows.Count > 0 Then
                Me.ImpTotalNoCancelado.Text = Format(CType(dt.Rows(0)("ImpNoCancelado"), Decimal), "Standard")
            Else
                Me.ImpTotalNoCancelado.Text = Format(0, "Standard")
            End If

            dt = mobj_N_AdminDB.ObtenerTabla(TotalPagos)

            If dt.Rows.Count > 0 Then
                Dim ImpTotalPagoAbierto As Decimal

                For Each MiDataRow As DataRow In dt.Rows
                    ImpTotalPagoAbierto += CType(MiDataRow("ImpNoAplicado"), Decimal)
                Next

                Me.ImpTotalAnticipos.Text = Format(ImpTotalPagoAbierto, "Standard")
            Else
                Me.ImpTotalAnticipos.Text = Format(0, "Standard")
            End If
        End If

        Me.DataGridView1.Columns(0).Visible = True
        Me.DataGridView1.DataSource = mobj_N_AdminDB.ObtenerTabla(sql)
        Me.DataGridView1.ClearSelection()

    End Sub
    Private Sub DetalleCancelaciones(ByVal argIdOperaCancelada As Long)
        ' Crear un nuevo formulario para mostrar los datos relacionados
        Dim sql As String = "SELECT Fecha,CodiTo,Resu,ImpFacturado,ImpCancelado,SaldoCA,SaldoCP,SaldoPA,SaldoPP,EstadoOperaContrato FROM ConOperaCancel WHERE IdOperaCancelada=" & argIdOperaCancelada
        Dim currentRowIndex As Integer = Me.DataGridView1.CurrentRow.Index
        Dim rowRectangle As Rectangle = Me.DataGridView1.GetRowDisplayRectangle(currentRowIndex, True)
        Dim rowPositionY As Integer = rowRectangle.Y

        ' Ajustar la posición del formulario relacionado basado en la posición de la fila seleccionada y el encabezado del DataGridView

        Dim relatedForm As New Form()
        With relatedForm
            .ControlBox = False
            .FormBorderStyle = FormBorderStyle.None
            .StartPosition = FormStartPosition.Manual
            .Left = Me.Left + 32
            .Top = Me.DataGridView1.Top + 280 + rowPositionY + Me.DataGridView1.ColumnHeadersHeight
            .Width = 980
            .Height = 100
            .KeyPreview = True
        End With

        Dim relatedGrid As New DataGridView()
        With relatedGrid
            .Name = "DetalleCancelaciones"
            .Dock = DockStyle.Fill
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .DataSource = mobj_N_AdminDB.ObtenerTabla(sql)
        End With

        AddHandler relatedGrid.DataBindingComplete, AddressOf AdjustColumnWidths

        ' Asignar el evento KeyDown para cerrar el formulario con la tecla Escape
        AddHandler relatedForm.KeyDown, AddressOf relatedForm_KeyDown

        Dim btnCell As DataGridViewButtonCell = CType(Me.DataGridView1.Rows(currentRowIndex).Cells(0), DataGridViewButtonCell)

        With btnCell
            .UseColumnTextForButtonValue = False
            .Value = "-"
        End With

        With relatedForm
            .Controls.Add(relatedGrid)
            .Height = relatedGrid.Height
            .ShowDialog()
        End With

    End Sub
    Private Sub AdjustColumnWidths(sender As Object, e As DataGridViewBindingCompleteEventArgs)
        Dim grid As DataGridView = CType(sender, DataGridView)
        ' Ajustar el ancho de las columnas aquí
        Select Case grid.Name
            Case "DetalleCancelaciones"
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

            Case "PagosAbiertos"
                With grid
                    With .Columns(0)
                        .HeaderText = ""
                        .Width = 24
                    End With

                    With .Columns(1)
                        .HeaderText = "IdPago"
                        .Width = 60
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter
                    End With

                    With .Columns(2)
                        .HeaderText = "Fecha"
                        .Width = 120
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter
                    End With

                    With .Columns(3)
                        .HeaderText = "T.Comp."
                        .Width = 60
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft
                    End With

                    With .Columns(4)
                        .HeaderText = "P.Vta."
                        .Width = 60
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter
                    End With

                    With .Columns(5)
                        .HeaderText = "N.Comp."
                        .Width = 70
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter
                    End With

                    With .Columns(6)
                        .HeaderText = "Imp.Pagado"
                        .Width = 100
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
                    End With

                    With .Columns(7)
                        .HeaderText = "Imp.Aplicado"
                        .Width = 100
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
                    End With

                    With .Columns(8)
                        .HeaderText = "Imp.No Aplicado"
                        .Width = 100
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
                    End With

                    .ClearSelection()
                End With
            Case "AplicacionesPago"
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
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter
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
        End Select
    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        If e.ColumnIndex = 0 AndAlso e.RowIndex >= 0 Then
            Dim btnCell As DataGridViewButtonCell = CType(Me.DataGridView1.Rows(e.RowIndex).Cells(0), DataGridViewButtonCell)

            Me.DetalleCancelaciones(Me.DataGridView1.Rows(e.RowIndex).Cells(1).Value)

            With btnCell
                .UseColumnTextForButtonValue = False
                .Value = "+"
            End With

        End If

    End Sub
    Private Sub relatedForm_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Escape Then
            e.Handled = True
            DirectCast(sender, Form).Close()
        End If
    End Sub
    Private Sub OperacionesCanceladasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OperacionesCanceladasToolStripMenuItem.Click
        Me.OperaContratos(mobjCliente, mobjContrato, "CANCELADO")

    End Sub
    Private Sub OperacionesNoCanceladasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OperacionesNoCanceladasToolStripMenuItem.Click
        Me.OperaContratos(mobjCliente, mobjContrato, "DEBE")
    End Sub
    Private Sub TodasLasOperacionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TodasLasOperacionesToolStripMenuItem.Click
        Me.OperaContratos(mobjCliente, mobjContrato, "TODOS")
    End Sub
    Private Sub PagosAbiertosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PagosAbiertosToolStripMenuItem.Click

        ' Crear un nuevo formulario para mostrar los datos relacionados

        Dim sql As String = "SELECT IdOperacion,Fecha,CodiTC,PVenta,NumComp,ImpPagado,ImpAplicado,ImpNoAplicado FROM ConPagoClientes WHERE IdContrato=" & mobjContrato.IdContrato & " AND EstadoPago='ABIERTO'"

        Dim relatedForm As New Form()
        With relatedForm
            .Text = "Pago Abierto"
            .StartPosition = FormStartPosition.CenterScreen
            .Width = 755
            .Height = 300
        End With

        Dim relatedGrid As New DataGridView()
        With relatedGrid
            .Name = "PagosAbiertos"
            .RowHeadersVisible = False
            .Dock = DockStyle.Fill
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .DataSource = mobj_N_AdminDB.ObtenerTabla(sql)

            ' Agregar una columna de botón
            Dim btnColumn As New DataGridViewButtonColumn()

            With btnColumn
                .Name = "btnExpandir"
                .HeaderText = "Expandir"
                .Text = "+"
                .UseColumnTextForButtonValue = True
            End With

            .Columns.Add(btnColumn)
        End With

        AddHandler relatedGrid.DataBindingComplete, AddressOf AdjustColumnWidths
        AddHandler relatedGrid.CellClick, AddressOf RelatedGridView_CellClick

        With relatedForm
            .Controls.Add(relatedGrid)
            .Height = relatedGrid.Height
            .ShowDialog()
        End With

    End Sub
    Private Sub RelatedGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.ColumnIndex = 0 AndAlso e.RowIndex >= 0 Then
            Dim btnCell As DataGridViewButtonCell = CType(sender.Rows(e.RowIndex).Cells(0), DataGridViewButtonCell)

            Me.AplicacionesPago(sender.Rows(e.RowIndex).Cells(1).Value)

            With btnCell
                .UseColumnTextForButtonValue = False
                .Value = "+"
            End With

        End If
    End Sub
    Private Sub AplicacionesPago(ByVal argIdPago As Long)
        Dim sql As String = "SELECT Fecha,CodiTo,Resu,ImpFacturado,ImpCancelado,SaldoCA,SaldoCP,SaldoPA,SaldoPP,EstadoOperaContrato FROM ConOperaCancel WHERE IdOperaPago=" & argIdPago

        Dim relatedForm As New Form()
        With relatedForm
            .ControlBox = False
            .FormBorderStyle = FormBorderStyle.None
            .StartPosition = FormStartPosition.Manual
            .Left = Me.Left + 38
            .Top = 465
            .Width = 980
            .Height = 100
            .KeyPreview = True
        End With

        Dim relatedGrid As New DataGridView()
        With relatedGrid
            .Name = "AplicacionesPago"
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
    End Sub
End Class