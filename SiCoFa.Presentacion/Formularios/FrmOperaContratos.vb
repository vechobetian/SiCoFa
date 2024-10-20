Imports SiCoFa.Negocio
Public Class FrmOperaContratos
    Property Nivel As Integer = 1
    Property Id As Integer
    Property CoordenadaX As Integer
    Property CoordenadaY As Integer

    Private mobj_N_AdminDB As New cls_N_AdminDB
    Public Sub MostrarDatos()
        Select Case Me.Nivel
            Case 1
                Me.SaldoGrupoContratos()
            Case 2
                Me.SaldoContratos()
            Case 3
                Me.OperaContratos()
        End Select

    End Sub
    Private Sub SaldoGrupoContratos()

        Me.DataGridView1.Columns(0).Visible = True

        With Me.DataGridView1.Columns(1)
            .HeaderText = "IdGC"
            .DataPropertyName = "IdGC"
        End With

        With Me.DataGridView1.Columns(2)
            .HeaderText = "Grupo"
            .DataPropertyName = "Descripcion"
        End With
        Dim sql As String = "SELECT IdGC,Descripcion,ImpFacturado,ImpCancelado,ImpNoCancelado FROM ConSaldoGrupoContratos"
        Me.DataGridView1.DataSource = mobj_N_AdminDB.ObtenerTabla(sql)
        Me.DataGridView1.ClearSelection()

    End Sub
    Private Sub SaldoContratos()
        With Me
            .ControlBox = False
            .FormBorderStyle = FormBorderStyle.None
            .StartPosition = FormStartPosition.Manual
            .Left = CoordenadaX
            .Top = CoordenadaY
        End With

        Me.DataGridView1.Columns(0).Visible = True

        With Me.DataGridView1.Columns(1)
            .HeaderText = "IdContrato"
            .DataPropertyName = "IdContrato"
        End With

        With Me.DataGridView1.Columns(2)
            .HeaderText = "Cliente"
            .DataPropertyName = "Nombre"
        End With
        Dim sql As String = "SELECT IdContrato,Nombre,ImpFacturado,ImpCancelado,ImpNoCancelado FROM ConSaldoContratos WHERE IdGC=" & Me.Id
        Me.DataGridView1.DataSource = mobj_N_AdminDB.ObtenerTabla(sql)
        Me.DataGridView1.ClearSelection()

    End Sub
    Private Sub OperaContratos()

        Dim sql = "SELECT IdOperacion,Resu,ImpFacturado,ImpCancelado,ImpNoCancelado FROM ConOperaContratos WHERE IdContrato=" & Me.Id & " AND EstadoOperaContrato='DEBE'"

        With Me
            .ControlBox = False
            .FormBorderStyle = FormBorderStyle.None
            .StartPosition = FormStartPosition.Manual
            .Left = CoordenadaX
            .Top = CoordenadaY
        End With

        Me.DataGridView1.Columns(0).Visible = True

        With Me.DataGridView1.Columns(1)
            .HeaderText = "IdOperacion"
            .DataPropertyName = "IdOperacion"
        End With

        With Me.DataGridView1.Columns(2)
            .HeaderText = "Resumen"
            .DataPropertyName = "Resu"
        End With

        Me.DataGridView1.DataSource = mobj_N_AdminDB.ObtenerTabla(sql)
        Me.DataGridView1.ClearSelection()

    End Sub
    Private Sub DetalleServicios(ByVal argIdOpera As Long)
        ' Crear un nuevo formulario para mostrar los datos relacionados
        Dim sql As String = "SELECT Descripcion,Cantidad,PUnit,Cantidad*PUnit AS Importe FROM TblDetServicios WHERE IdOperaDevin=" & argIdOpera

        Dim relatedForm As New Form()
        With relatedForm
            .ControlBox = False
            .FormBorderStyle = FormBorderStyle.None
            .StartPosition = FormStartPosition.Manual
            .Left = Me.Left + 25
            .Top = Me.Top + 20 + Me.DataGridView1.CurrentRow.Height + Me.DataGridView1.CurrentRow.Index * 22 'Top + (barra de titulo + encabezado dgv) + Altura del Registro
            .Width = 810
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

    End Sub
    Private Sub AdjustColumnWidths(sender As Object, e As DataGridViewBindingCompleteEventArgs)
        Dim grid As DataGridView = CType(sender, DataGridView)
        ' Ajustar el ancho de las columnas aquí
        With grid
            .Columns(0).Width = 400
            .Columns(1).Width = 100
            .Columns(2).Width = 100
            .Columns(3).Width = 150
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .ClearSelection()
        End With
    End Sub
    Private Sub relatedForm_KeyDown(sender As Object, e As KeyEventArgs)
        ' Cierra el formulario cuando se presiona la tecla Escape
        If e.KeyCode = Keys.Escape Then
            DirectCast(sender, Form).Close()
        End If
    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.ColumnIndex = 0 AndAlso e.RowIndex >= 0 Then
            Dim btnCell As DataGridViewButtonCell = CType(Me.DataGridView1.Rows(e.RowIndex).Cells(0), DataGridViewButtonCell)

            With btnCell
                .UseColumnTextForButtonValue = False
                .Value = "-"
            End With

            Dim frm As New FrmOperaContratos
            Select Case Me.Nivel
                Case 1
                    With frm
                        .Nivel = 2
                        .Id = Me.DataGridView1.CurrentRow.Cells(1).Value
                        .CoordenadaX = Me.Left + 32
                        .CoordenadaY = Me.Top + 50 + Me.DataGridView1.CurrentRow.Height + Me.DataGridView1.CurrentRow.Index * 22 'Top + (barra de titulo + encabezado dgv) + Altura del Registro
                        .MostrarDatos()
                        Me.DataGridView1.CurrentRow.Height = .Height + 22
                        Dim AlturaInicial As Integer = Me.Height
                        Me.Height += Me.DataGridView1.Height
                        .ShowDialog()
                        Me.DataGridView1.CurrentRow.Height = 22
                        btnCell.Value = "+"
                        Me.Height = AlturaInicial
                    End With
                Case 2
                    With frm
                        .Nivel = 3
                        .Id = Me.DataGridView1.CurrentRow.Cells(1).Value
                        .CoordenadaX = Me.Left + 25
                        .CoordenadaY = Me.Top + 20 + Me.DataGridView1.CurrentRow.Height + Me.DataGridView1.CurrentRow.Index * 22 'Top + (barra de titulo + encabezado dgv) + Altura del Registro
                        .MostrarDatos()
                        Me.DataGridView1.CurrentRow.Height = .Height + 22
                        Dim AlturaInicial As Integer = Me.Height
                        Me.Height += Me.DataGridView1.Height
                        .ShowDialog()
                        Me.DataGridView1.CurrentRow.Height = 22
                        btnCell.Value = "+"
                        Me.Height = AlturaInicial
                    End With
                Case 3
                    Me.DetalleServicios(Me.DataGridView1.CurrentRow.Cells(1).Value)
            End Select
        End If

    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If Nivel = 1 Then
            Exit Function
        End If

        If keyData = Keys.Escape Then
            Me.Close()
        End If

    End Function

End Class

