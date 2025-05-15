Imports System.ComponentModel
Imports SiCoFa.Entidades
Imports SiCoFa.Negocio

Public Class FrmFacturacion
    Private mobj_N_AdminSiCoFa As New cls_N_AdminSiCoFa
    Private Items As New BindingList(Of ItemComprobante)

    Private Sub AjustarAnchoToolStripTextBox()
        ' Encontramos el ToolStripTextBox
        Dim txtBox As ToolStripTextBox = Nothing

        ' Calculamos el espacio ocupado por los otros elementos
        Dim anchoOcupado As Integer = 0

        ' Recorremos los elementos del ToolStrip
        For Each item As ToolStripItem In ToolStrip1.Items
            If TypeOf item Is ToolStripTextBox Then
                txtBox = CType(item, ToolStripTextBox)
            Else
                anchoOcupado += item.Width
            End If
        Next

        ' Si encontramos el ToolStripTextBox, ajustamos su tamaño
        If txtBox IsNot Nothing Then
            ' Definimos un margen de separación
            Dim margen As Integer = 10
            ' Calculamos el espacio disponible en el ToolStrip
            Dim anchoDisponible As Integer = ToolStrip1.DisplayRectangle.Width - anchoOcupado - margen

            ' Ajustamos el tamaño del TextBox
            txtBox.Width = Math.Max(50, anchoDisponible)
        End If
    End Sub
    Private Sub AjustarAnchoColumnasProporcional()
        If DataGridView1.ColumnCount = 10 Then
            Dim totalAncho As Integer = DataGridView1.Width
            ' Define las proporciones para las 10 columnas (la primera es invisible y tiene ancho 0)
            Dim proporciones As Double() = {0.0R, 0.08R, 0.5R, 0.05R, 0.05R, 0.08R, 0.08R, 0.05R, 0.08R, 0.08R}
            ' Suma de las proporciones (excluyendo la primera): 0.1 + 0.15 + 0.1 + 0.2 + 0.05 + 0.15 + 0.1 + 0.05 = 0.9 (ajusta según necesites)

            For i As Integer = 0 To 9 ' Itera a través de las 9 columnas
                DataGridView1.Columns(i).Width = CInt(totalAncho * proporciones(i))
            Next
        Else
            MessageBox.Show("El DataGridView no tiene 9 columnas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub BuscarArticulo(ByVal argTextoBuscado As String)

        Try

            Dim la As List(Of Articulo) = mobj_N_AdminSiCoFa.ListarArticulos(argTextoBuscado)
            Dim a As Articulo = Nothing

            If la Is Nothing Then
                MsgBox("Articulo no Encontrado", vbInformation, "SiCoFa")
                Exit Sub
            End If

            Select Case la.Count
                Case 0
                    MsgBox("Articulo no Encontrado", vbInformation, "SiCoFa")

                Case 1
                    a = la.First

                Case > 1

                    Using f As New FrmBuscaArticulos
                        f.Articulos = la
                        f.ShowDialog()
                        If f.DialogResult = DialogResult.OK Then
                            a = f.ArticuloSeleccionado
                        End If
                        f.Close()
                    End Using

            End Select

            With Me
                If a IsNot Nothing Then
                    Dim i As New ItemComprobante(a.CodBarras, a.Nombre, 1, a.PrecioVenta, a.AlicuotaIVA.AlicIVA, 0)
                    Items.Add(i)
                    Me.DataGridView1.ClearSelection()

                    ' *** Establecer el foco en la celda Cantidad del nuevo ítem ***
                    Dim nuevoIndiceFila As Integer = Me.DataGridView1.Rows.Count - 1
                    ' Asegúrate de que la columna "Cantidad" tenga el nombre correcto
                    Dim nombreColumnaCantidad As String = "Cantidad" ' Reemplaza con el nombre real

                    ' Verificar que la columna exista
                    If Me.DataGridView1.Columns.Contains(nombreColumnaCantidad) AndAlso nuevoIndiceFila >= 0 Then
                        Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(nuevoIndiceFila).Cells(nombreColumnaCantidad)
                        Me.DataGridView1.BeginEdit(True) ' Iniciar la edición de la celda
                    End If
                End If

                .SelectorArticulos.Text = ""
                Me.ActualizarTotales()

            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Private Sub ActualizarTotales()
        Dim ImporteTotal As Decimal
        For Each i As ItemComprobante In Me.Items
            ImporteTotal = ImporteTotal + i.ImporteConDescuento
        Next
        MsgBox(ImporteTotal)

    End Sub
    Private Sub FrmFacturacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Evita que los controles se muevan al área de desbordamiento
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.DataSource = Me.Items
        For Each item As ToolStripItem In ToolStrip1.Items
            item.Overflow = ToolStripItemOverflow.Never
        Next
    End Sub
    Private Sub FrmFacturacion_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.AjustarAnchoColumnasProporcional()
        Me.AjustarAnchoToolStripTextBox()
        ' Le damos el enfoque al ToolStripTextBox para que sea el primer control activo
        For Each item As ToolStripItem In ToolStrip1.Items
            If TypeOf item Is ToolStripTextBox Then
                ' Le damos el enfoque al ToolStripTextBox
                CType(item, ToolStripTextBox).Focus()
                Exit For
            End If
        Next

    End Sub
    Private Sub FrmFacturacion_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.AjustarAnchoColumnasProporcional()
        Me.AjustarAnchoToolStripTextBox()
    End Sub
    Private Sub SelectorArticulos_KeyDown(sender As Object, e As KeyEventArgs) Handles SelectorArticulos.KeyDown
        If String.IsNullOrWhiteSpace(Me.SelectorArticulos.Text) Then
            Exit Sub
        End If

        If e.KeyCode = Keys.Enter Then
            Me.BuscarArticulo(Me.SelectorArticulos.Text)
            e.Handled = True ' Indica que el evento KeyDown ha sido manejado
            e.SuppressKeyPress = True ' Evita que se genere el evento KeyPress
        End If
    End Sub
    Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyCode = Keys.Delete AndAlso DataGridView1.SelectedRows.Count > 0 Then
            ' Confirmar la eliminación (opcional)
            If MessageBox.Show("¿Seguro que desea eliminar los ítems seleccionados?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                ' Crear una lista para almacenar los índices a eliminar (para evitar problemas al modificar la colección mientras se itera)
                Dim indicesAEliminar As New List(Of Integer)

                ' Recorrer las filas seleccionadas de abajo hacia arriba para evitar problemas con los índices al eliminar
                For i As Integer = DataGridView1.SelectedRows.Count - 1 To 0 Step -1
                    Dim indiceFilaSeleccionada As Integer = DataGridView1.SelectedRows(i).Index
                    If indiceFilaSeleccionada >= 0 AndAlso indiceFilaSeleccionada < Items.Count Then
                        Items.RemoveAt(indiceFilaSeleccionada)
                    End If
                Next

                DataGridView1.ClearSelection()
                ActualizarTotales()
                ' ... (actualizar otros totales)
            End If
        End If
    End Sub
    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        ' Asegurarse de que la edición terminó en una celda válida
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            ' Obtener el nombre de la columna que se editó
            Dim nombreColumnaEditada As String = DataGridView1.Columns(e.ColumnIndex).Name

            ' Verificar si la columna editada es la columna "Cantidad"
            Dim nombreColumnaCantidad As String = "Cantidad" ' Reemplaza con el nombre real
            If nombreColumnaEditada.Equals(nombreColumnaCantidad, StringComparison.OrdinalIgnoreCase) Then
                ' Devolver el foco al ToolStripTextBox SelectorArticulos
                For Each item As ToolStripItem In ToolStrip1.Items
                    If TypeOf item Is ToolStripTextBox Then
                        CType(item, ToolStripTextBox).Focus()
                        CType(item, ToolStripTextBox).SelectAll() ' Opcional: Seleccionar el texto para la siguiente búsqueda
                        Exit For
                    End If
                Next
                Me.DataGridView1.ClearSelection()
            End If
        End If
    End Sub
End Class
