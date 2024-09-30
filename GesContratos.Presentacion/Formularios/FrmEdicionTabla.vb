Imports SiCoFa.Negocio
Public Class FrmEdicionTabla
    Property Caption As String
    Property SQL As String
    Property dTable As DataTable


    Private obj_N_AdminDB As New cls_N_AdminDB
    Private MenuContextual As New ContextMenuStrip()
    Private selectedColumn As DataGridViewColumn
    Private Sub FrmEdicionTabla_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            If SQL <> "" Then
                dTable = obj_N_AdminDB.ObtenerTabla(Me.SQL)
            End If

            If dTable IsNot Nothing Then
                Me.DataGridView1.DataSource = dTable
                Me.DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            End If

            Me.Text = Me.Caption
            Me.ActualizarCantidadRegistros()
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation, "SiCoFa")
        End Try

    End Sub
    Private Sub ActualizarCantidadRegistros()
        ' Obtener la cantidad de filas visibles del DataGridView
        Dim cantidadRegistros As Integer = DataGridView1.Rows.Cast(Of DataGridViewRow)().Count(Function(row) row.Visible)

        ' Actualizar el texto del ToolStripStatusLabel
        ToolStripStatusLabel1.Text = "Cantidad de registros visibles: " & cantidadRegistros.ToString()
    End Sub
    Private Sub DataGridView1_RowValidated(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.RowValidated
        Try

            If Me.SQL = "" Then
                Exit Sub
            End If

            obj_N_AdminDB.ActualizarTabla(Me.SQL, dTable)
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation, "SiCoFa")

        End Try

    End Sub
    Public Sub New()
        ' Configurar KeyPreview para que el formulario capture las teclas
        Me.KeyPreview = True

        ' Inicializar componentes
        InitializeComponent()

        Dim copyMenuItem As New ToolStripMenuItem("Copiar datos")
        Dim filterMenuItem As New ToolStripMenuItem("Seleccionar Elementos")
        Dim alignLeftMenuItem As New ToolStripMenuItem("Alinear a la Izquierda")
        Dim alignRightMenuItem As New ToolStripMenuItem("Alinear a la Derecha")

        ' Agregar manejadores de eventos para los ítems del menú
        AddHandler copyMenuItem.Click, AddressOf CopyDataGridViewToClipboard
        AddHandler alignLeftMenuItem.Click, AddressOf AlignLeftMenuItem_Click
        AddHandler alignRightMenuItem.Click, AddressOf AlignRightMenuItem_Click
        AddHandler filterMenuItem.Click, AddressOf ApplyFilter_Click

        'Agregar items al menu contextual
        MenuContextual.Items.Add(copyMenuItem)
        MenuContextual.Items.Add(filterMenuItem)
        MenuContextual.Items.Add(alignLeftMenuItem)
        MenuContextual.Items.Add(alignRightMenuItem)

        ' Asociar el menú contextual con el DataGridView
        AddHandler DataGridView1.CellMouseClick, AddressOf DataGridView1_CellMouseClick

        ' Asignar el menú contextual al DataGridView
        AddHandler DataGridView1.ColumnHeaderMouseClick, AddressOf DataGridView1_ColumnHeaderMouseClick

    End Sub
    Private Sub DataGridView1_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs)
        If e.Button = MouseButtons.Right Then
            selectedColumn = DataGridView1.Columns(e.ColumnIndex)
            MenuContextual.Show(Cursor.Position)
        End If
    End Sub
    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs)
        If e.Button = MouseButtons.Right AndAlso e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            ' Establecer la columna seleccionada
            selectedColumn = DataGridView1.Columns(e.ColumnIndex)
            ' Mostrar el menú contextual
            MenuContextual.Show(DataGridView1, e.Location)
        End If
    End Sub

    '---------------------------------------------------------------------------------------------------------------------------------------------------
    'Codigo para manejo del filtro
    ' Variable global para almacenar los valores únicos

    Private uniqueValues As List(Of String)
    Private WithEvents CheckedListBox1 As New CheckedListBox()
    Private Sub CheckedListBox1_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles CheckedListBox1.ItemCheck
        Dim checkedListBox As CheckedListBox = CType(sender, CheckedListBox)

        ' Usar una variable para evitar cambios repetidos durante el evento
        Static isProcessing As Boolean = False
        If isProcessing Then Return
        isProcessing = True

        If checkedListBox.Items(e.Index).ToString() = "Todos" Then
            If e.NewValue = CheckState.Checked Then
                ' Marcar todos los ítems
                For i As Integer = 1 To checkedListBox.Items.Count - 1
                    checkedListBox.SetItemChecked(i, True)
                Next
            Else
                ' Desmarcar todos los ítems
                For i As Integer = 1 To checkedListBox.Items.Count - 1
                    checkedListBox.SetItemChecked(i, False)
                Next
            End If
        Else
            ' Si se desmarca cualquier otro elemento, desmarcar "Todos"
            If e.NewValue = CheckState.Unchecked Then
                checkedListBox.SetItemChecked(0, False)
            End If
        End If

        isProcessing = False
    End Sub
    Private Sub ApplyFilter_Click(sender As Object, e As EventArgs)
        If selectedColumn IsNot Nothing Then
            ' Crear el Panel primero
            Dim panel As New Panel()
            panel.Width = selectedColumn.Width + 50
            panel.Height = 200
            panel.Left = DataGridView1.GetCellDisplayRectangle(selectedColumn.Index, -1, True).Left
            panel.Top = DataGridView1.Top
            panel.BorderStyle = BorderStyle.FixedSingle

            ' Crear CheckedListBox
            Dim checkedListBox As New CheckedListBox()
            checkedListBox.CheckOnClick = True
            checkedListBox.Tag = selectedColumn.Name

            ' Asociar dinámicamente el evento ItemCheck
            AddHandler checkedListBox.ItemCheck, AddressOf CheckedListBox1_ItemCheck

            ' Crear una nueva lista de valores únicos cada vez
            uniqueValues = New List(Of String)()
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    Dim cellValue As String = row.Cells(selectedColumn.Index).Value.ToString()
                    If Not uniqueValues.Contains(cellValue) Then
                        uniqueValues.Add(cellValue)
                    End If
                End If
            Next
            uniqueValues.Insert(0, "Todos")

            ' Añadir los valores únicos al CheckedListBox
            checkedListBox.Items.AddRange(uniqueValues.ToArray())

            ' Marcar los elementos visibles por defecto
            For i As Integer = 0 To checkedListBox.Items.Count - 1
                checkedListBox.SetItemChecked(i, True)
            Next

            ' Crear botones Aceptar y Cancelar
            Dim btnAceptar As New Button()
            btnAceptar.Text = "Aceptar"
            AddHandler btnAceptar.Click, Sub()
                                             ApplyFilterToDataGridView(checkedListBox)
                                             Me.Controls.Remove(panel)
                                             panel.Dispose()
                                             Me.ActualizarCantidadRegistros()
                                         End Sub

            Dim btnCancelar As New Button()
            btnCancelar.Text = "Cancelar"
            AddHandler btnCancelar.Click, Sub()
                                              Me.Controls.Remove(panel)
                                              panel.Dispose()
                                          End Sub

            ' Ajustar el tamaño del CheckedListBox para que quepa dentro del panel
            checkedListBox.Width = panel.Width - 20
            checkedListBox.Height = panel.Height - 50
            checkedListBox.Left = 10
            checkedListBox.Top = 10

            ' Posicionar los botones en la parte inferior del panel
            btnAceptar.Width = (panel.Width / 2) - 15
            btnAceptar.Top = checkedListBox.Bottom + 5
            btnAceptar.Left = 10

            btnCancelar.Width = (panel.Width / 2) - 15
            btnCancelar.Top = checkedListBox.Bottom + 5
            btnCancelar.Left = btnAceptar.Right + 10

            ' Añadir CheckedListBox y botones al panel
            panel.Controls.Add(checkedListBox)
            panel.Controls.Add(btnAceptar)
            panel.Controls.Add(btnCancelar)

            ' Eliminar cualquier panel anterior del formulario
            For Each ctrl As Control In Me.Controls.OfType(Of Panel)()
                Me.Controls.Remove(ctrl)
                ctrl.Dispose()
            Next

            ' Añadir el panel al formulario
            Me.Controls.Add(panel)
            panel.BringToFront()

            ' Configurar el manejo de la tecla Escape
            AddHandler Me.KeyDown, Sub(s, ev)
                                       If ev.KeyCode = Keys.Escape Then
                                           Me.Controls.Remove(panel)
                                           panel.Dispose()
                                       End If
                                   End Sub

            ' Asegurarse de que el panel reciba los eventos de teclado
            panel.Focus()
        End If
    End Sub
    Private Sub ApplyFilterToDataGridView(checkedListBox As CheckedListBox)
        ' Obtener el índice de la columna seleccionada
        Dim columnIndex As Integer = DataGridView1.Columns(selectedColumn.Name).Index

        ' Crear una lista de valores seleccionados
        Dim selectedValues As New List(Of String)()

        ' Agregar solo los elementos seleccionados, excluyendo "Todos" si está seleccionado
        For Each item In checkedListBox.CheckedItems
            If item.ToString() <> "Todos" Then
                selectedValues.Add(item.ToString())
            End If
        Next

        ' Si no hay elementos seleccionados, mostrar todas las filas
        If selectedValues.Count = 0 OrElse checkedListBox.CheckedItems.Contains("Todos") Then
            For Each row As DataGridViewRow In DataGridView1.Rows
                row.Visible = True
            Next
            Return
        End If

        ' Verificar si la fila actual debe ocultarse y cambiarla si es necesario
        Dim currentRow As DataGridViewRow = DataGridView1.CurrentRow
        If currentRow IsNot Nothing AndAlso Not selectedValues.Contains(currentRow.Cells(columnIndex).Value.ToString()) Then
            ' Buscar la primera fila que será visible después de aplicar el filtro
            For Each row As DataGridViewRow In DataGridView1.Rows
                If selectedValues.Contains(row.Cells(columnIndex).Value.ToString()) Then
                    DataGridView1.CurrentCell = row.Cells(0) ' Cambia la celda activa a una visible
                    Exit For
                End If
            Next
        End If

        ' Aplicar el filtro, ocultando las filas que no coincidan con los valores seleccionados
        For Each row As DataGridViewRow In DataGridView1.Rows
            If selectedValues.Contains(row.Cells(columnIndex).Value.ToString()) Then
                row.Visible = True
            Else
                row.Visible = False
            End If
        Next

        Me.DataGridView1.Refresh()

    End Sub
    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs)
        Dim panel As Panel = CType(CType(sender, Control).Parent, Panel)
        Dim checkedListBox As CheckedListBox = CType(panel.Controls(0), CheckedListBox)
        Dim columnName As String = checkedListBox.Tag.ToString()

        ' Construir un filtro basado en los elementos seleccionados
        Dim selectedItems As New List(Of String)
        For Each item In checkedListBox.CheckedItems
            If item.ToString() <> "Todos" Then
                selectedItems.Add($"{columnName} = '{item}'")
            End If
        Next

        ' Aplicar el filtro al DataGridView
        Dim dt As DataTable = TryCast(DataGridView1.DataSource, DataTable)
        Dim dv As DataView = dt.DefaultView

        If selectedItems.Count = 0 Then
            dv.RowFilter = String.Empty
        Else
            dv.RowFilter = String.Join(" OR ", selectedItems)
        End If

        ' Cerrar el panel
        Me.Controls.Remove(panel)
        panel.Dispose()

    End Sub
    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs)
        Dim panel As Panel = CType(CType(sender, Control).Parent, Panel)
        Me.Controls.Remove(panel)
        panel.Dispose()
    End Sub

    Private Sub DataGridView1_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles DataGridView1.DataBindingComplete
        ' Llamar al procedimiento después de completar el enlace de datos
        ActualizarCantidadRegistros()
    End Sub
    'Fin codigo para menejo del filtro    '-----------------------------------------------------------------------------------------------------------------------------------------------------

    Private Sub AlignLeftMenuItem_Click(sender As Object, e As EventArgs)
        If selectedColumn IsNot Nothing Then
            ' Establecer el alineamiento de texto a la izquierda para la columna seleccionada
            selectedColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End If
    End Sub

    Private Sub AlignRightMenuItem_Click(sender As Object, e As EventArgs)
        If selectedColumn IsNot Nothing Then
            ' Establecer el alineamiento de texto a la derecha para la columna seleccionada
            selectedColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If
    End Sub
    Private Sub CopyDataGridViewToClipboard()
        Dim clipboardContent As New System.Text.StringBuilder()

        ' Copiar encabezados de las columnas
        For Each column As DataGridViewColumn In DataGridView1.Columns
            clipboardContent.Append(column.HeaderText & vbTab)
        Next
        clipboardContent.AppendLine()

        ' Copiar las filas
        For Each row As DataGridViewRow In DataGridView1.Rows
            For Each cell As DataGridViewCell In row.Cells
                clipboardContent.Append(cell.Value.ToString() & vbTab)
            Next
            clipboardContent.AppendLine()
        Next

        ' Copiar el contenido al portapapeles
        Clipboard.SetText(clipboardContent.ToString())
    End Sub

End Class