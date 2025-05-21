Imports System.ComponentModel
Imports SiCoFa.Entidades
Imports SiCoFa.Negocio

Public Class FrmVentas
    Private mobj_N_AdminSiCoFa As New cls_N_AdminSiCoFa
    Private Operacion As Operacion
    Private Items As New BindingList(Of ItemComprobante)

    Private Sub IniciarOperacion()
        Try

            Dim IdOperacion As Long = mobj_N_AdminSiCoFa.IniciarOperacion(g_ParametrosTerminal.MacAddress, 3, "VTAM", "")
            Me.InsertarItems(IdOperacion)
            Dim fin As Boolean = mobj_N_AdminSiCoFa.FinalizarOperacion(g_ParametrosTerminal.MacAddress, "", IdOperacion)
            MsgBox(fin)
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try
    End Sub

    Private Sub InsertarItems(ByVal argIdOperacion As Long)
        Try
            For Each i As ItemComprobante In Items
                mobj_N_AdminSiCoFa.InsertarItemComprobante(argIdOperacion,
                                                           i.Articulo.IdArticulo,
                                                           i.Descripcion,
                                                           i.Cantidad,
                                                           i.AlicIVA,
                                                           i.Articulo.PrecioCosto,
                                                           i.PrecioUnitario,
                                                           i.DescuentoUnitario
                                                           )
            Next
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try
    End Sub

    Private Sub EliminarItemSeleccionado()
        Try
            If DataGridView1.IsCurrentCellInEditMode Then
                MsgBox("El Item se encuentra en modo Edición, no se puede eliminar", vbCritical, "SiCoFa")
                Exit Sub
            End If

            If DataGridView1.SelectedRows.Count = 0 Then
                MsgBox("No hay ningun Item seleccionado para eliminar", vbInformation, "SiCoFa")
                Exit Sub
            End If

            If MessageBox.Show("¿Seguro que desea eliminar los ítems seleccionados?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim indicesAEliminar As New List(Of Integer)

                For i As Integer = DataGridView1.SelectedRows.Count - 1 To 0 Step -1
                    Dim indiceFilaSeleccionada As Integer = DataGridView1.SelectedRows(i).Index
                    If indiceFilaSeleccionada >= 0 AndAlso indiceFilaSeleccionada < Items.Count Then
                        Items.RemoveAt(indiceFilaSeleccionada)
                    End If
                Next

                DataGridView1.ClearSelection()
                ActualizarTotales()

            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
        End Try

    End Sub

    Private Sub AjustarAnchoToolStripTextBox()
        Try

            Dim txtBox As ToolStripTextBox = Nothing

            Dim anchoOcupado As Integer = 0

            For Each item As ToolStripItem In ToolStrip1.Items
                If TypeOf item Is ToolStripTextBox Then
                    txtBox = CType(item, ToolStripTextBox)
                Else
                    anchoOcupado += item.Width
                End If
            Next

            If txtBox IsNot Nothing Then

                Dim margen As Integer = 10
                Dim anchoDisponible As Integer = ToolStrip1.DisplayRectangle.Width - anchoOcupado - margen

                txtBox.Width = Math.Max(50, anchoDisponible)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub AjustarAnchoColumnasProporcional()
        Try

            If DataGridView1.ColumnCount = 10 Then
                Dim totalAncho As Integer = DataGridView1.Width
                Dim proporciones As Double() = {0.0R, 0.08R, 0.5R, 0.05R, 0.05R, 0.08R, 0.08R, 0.05R, 0.08R, 0.08R}

                For i As Integer = 0 To 9 ' Itera a través de las 9 columnas
                    DataGridView1.Columns(i).Width = CInt(totalAncho * proporciones(i))
                Next
            Else
                MessageBox.Show("El DataGridView no tiene 9 columnas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub BuscarArticulo(ByVal argTextoBuscado As String)

        Try
            If argTextoBuscado = "*" OrElse argTextoBuscado = "/" Then
                MsgBox("Articulo no Encontrado", vbInformation, "SiCoFa")
                Exit Sub
            End If

            Dim a As Articulo = Nothing
            Dim la As New List(Of Articulo)

            Select Case Strings.Left(argTextoBuscado, 1)
                Case "*"
                    Dim SeccionItem As Seccion = New Seccion("0", "GENERICO 1", True)
                    a = New Articulo("0", "", "", UCase(Replace(argTextoBuscado, "*", "")), New AlicuotaIVA(10.5), Now.Date, 0, 0, 0, SeccionItem, True, 0, Nothing, Nothing)
                    la.Add(a)

                Case "/"
                    Dim SeccionItem As Seccion = New Seccion("0", "GENERICO 2", True)
                    a = New Articulo("0", "", "", UCase(Replace(argTextoBuscado, "/", "")), New AlicuotaIVA(21), Now.Date, 0, 0, 0, SeccionItem, True, 0, Nothing, Nothing)
                    la.Add(a)

                Case Else
                    la = mobj_N_AdminSiCoFa.ListarArticulos(argTextoBuscado)

            End Select

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
                    Dim i As New ItemComprobante(a, a.CodBarras, a.Nombre, 1, a.PrecioVenta, a.AlicuotaIVA.AlicIVA, 0)
                    Items.Add(i)
                    Me.DataGridView1.ClearSelection()

                    Dim nuevoIndiceFila As Integer = Me.DataGridView1.Rows.Count - 1
                    Dim nombreColumnaCantidad As String = "Cantidad" ' Reemplaza con el nombre real

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

        Try

            Dim CantidadItems As Integer = 0
            Dim ImporteSinDescuentos As Decimal = 0
            Dim ImporteDescuentos As Decimal = 0
            Dim ImporteConDescuentos As Decimal = 0
            Dim PorcentaDescuentos As Decimal = 0

            For Each i As ItemComprobante In Me.Items
                CantidadItems += 1
                ImporteSinDescuentos += i.ImporteSinDescuento
                ImporteDescuentos += i.ImporteDescuento
                ImporteConDescuentos += i.ImporteConDescuento
            Next

            If ImporteSinDescuentos > 0 Then
                PorcentaDescuentos = Math.Round(ImporteDescuentos / ImporteSinDescuentos * 100, 2, MidpointRounding.ToEven)
            Else
                PorcentaDescuentos = 0
            End If

            Me.lblCantidadItems.Text = "Items: " & CantidadItems
            Me.lblImporteSinDescuentos.Text = "Importe sin Descuentos: $ " & Format(ImporteSinDescuentos, "#,##0.00")
            Me.lblPorcentajeAplicado.Text = "Porcentaje Descuentos: " & Format(PorcentaDescuentos, "#,##0.00") & "%"
            Me.lblImporteDescuentos.Text = "Importe Descuentos: $ " & Format(ImporteDescuentos, "#,##0.00")
            Me.lblImporteConDescuentos.Text = "Importe Neto: $ " & Format(ImporteConDescuentos, "#,##0.00")

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub FrmFacturacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Me.DataGridView1.AutoGenerateColumns = False
            Me.DataGridView1.DataSource = Me.Items
            For Each item As ToolStripItem In ToolStrip1.Items
                item.Overflow = ToolStripItemOverflow.Never
            Next

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub FrmFacturacion_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Try
            Me.AjustarAnchoColumnasProporcional()
            Me.AjustarAnchoToolStripTextBox()
            For Each item As ToolStripItem In ToolStrip1.Items
                If TypeOf item Is ToolStripTextBox Then
                    CType(item, ToolStripTextBox).Focus()
                    Exit For
                End If
            Next

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub FrmFacturacion_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.AjustarAnchoColumnasProporcional()
        Me.AjustarAnchoToolStripTextBox()
    End Sub

    Private Sub SelectorArticulos_KeyDown(sender As Object, e As KeyEventArgs) Handles SelectorArticulos.KeyDown
        Try

            If String.IsNullOrWhiteSpace(Me.SelectorArticulos.Text) Then
                Exit Sub
            End If

            If e.KeyCode = Keys.Enter Then
                Me.BuscarArticulo(Me.SelectorArticulos.Text)
                e.Handled = True ' Indica que el evento KeyDown ha sido manejado
                e.SuppressKeyPress = True ' Evita que se genere el evento KeyPress
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyDown
        Try

            If e.KeyCode = Keys.Delete AndAlso DataGridView1.SelectedRows.Count > 0 Then
                Me.EliminarItemSeleccionado()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub DataGridView1_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles DataGridView1.CellValidating

        Try
            If DataGridView1.Columns(e.ColumnIndex).Name.Equals("Cantidad", StringComparison.OrdinalIgnoreCase) Then
                Dim valorIngresado As String = e.FormattedValue.ToString().Trim()
                Dim cantidad As Decimal

                If String.IsNullOrWhiteSpace(valorIngresado) OrElse Not Decimal.TryParse(valorIngresado, cantidad) OrElse cantidad <= 0 Then

                    MsgBox("Cantidad debe ser un valor mayor que cero", vbCritical, "SiCoFa")
                    e.Cancel = True

                    DataGridView1.BeginEdit(True)

                    Dim editingControl = TryCast(DataGridView1.EditingControl, TextBox)

                    If editingControl IsNot Nothing Then
                        editingControl.SelectAll()
                    End If

                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        Try
            If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
                Dim nombreColumnaEditada As String = DataGridView1.Columns(e.ColumnIndex).Name
                Dim nombreColumnaCantidad As String = "Cantidad"
                Dim nombreColumnaPrecioUnitario As String = "PrecioUnitario"

                If nombreColumnaEditada.Equals(nombreColumnaCantidad, StringComparison.OrdinalIgnoreCase) Then
                    If String.IsNullOrEmpty(DataGridView1.Rows(e.RowIndex).ErrorText) Then
                        Dim itemComprobante As ItemComprobante = Items(e.RowIndex)

                        If itemComprobante.Articulo?.Seccion?.EstablecerPrecio Then ' Usando el operador ?. para evitar NullReferenceException
                            Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(e.RowIndex).Cells(nombreColumnaPrecioUnitario)
                            Me.DataGridView1.CurrentCell.ReadOnly = False
                            Me.DataGridView1.BeginEdit(True)
                        Else
                            For Each item As ToolStripItem In ToolStrip1.Items
                                If TypeOf item Is ToolStripTextBox Then
                                    CType(item, ToolStripTextBox).Focus()
                                    CType(item, ToolStripTextBox).SelectAll()
                                    Exit For
                                End If
                            Next
                            Me.DataGridView1.ClearSelection()
                            ' Intenta establecer CurrentCell a Nothing
                            Me.DataGridView1.CurrentCell = Nothing
                        End If
                        Me.DataGridView1.Refresh()
                        Me.ActualizarTotales()

                    End If
                End If

                If nombreColumnaEditada.Equals(nombreColumnaPrecioUnitario, StringComparison.OrdinalIgnoreCase) Then
                    If String.IsNullOrEmpty(DataGridView1.Rows(e.RowIndex).ErrorText) Then
                        For Each item As ToolStripItem In ToolStrip1.Items
                            If TypeOf item Is ToolStripTextBox Then
                                CType(item, ToolStripTextBox).Focus()
                                CType(item, ToolStripTextBox).SelectAll()
                                Exit For
                            End If
                        Next
                        Me.DataGridView1.ClearSelection()
                        Me.DataGridView1.CurrentCell = Nothing ' Intenta establecer CurrentCell a Nothing también aquí
                        Me.DataGridView1.Refresh()
                        Me.ActualizarTotales()
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub ElimininarItemSeleccionadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ElimininarItemSeleccionadoToolStripMenuItem.Click
        Me.EliminarItemSeleccionado()
    End Sub

    Private Sub AplicarDescuentoItemSeleccionadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AplicarDescuentoItemSeleccionadoToolStripMenuItem.Click

        Try
            If DataGridView1.SelectedRows.Count = 1 Then
                Dim indiceFilaSeleccionada As Integer = DataGridView1.SelectedRows(0).Index

                If indiceFilaSeleccionada >= 0 AndAlso indiceFilaSeleccionada < Items.Count Then
                    Dim itemSeleccionado = Items(indiceFilaSeleccionada)

                    Dim descuentoStr As String = InputBox("Ingrese el porcentaje de descuento a aplicar:", "Aplicar Descuento", "0")

                    If Not String.IsNullOrEmpty(descuentoStr) Then
                        Dim descuentoPorcentaje As Decimal
                        If Decimal.TryParse(descuentoStr, descuentoPorcentaje) Then
                            ' Asegurarse de que el descuento sea un valor válido (por ejemplo, entre 0 y 100)
                            If descuentoPorcentaje >= 0 AndAlso descuentoPorcentaje <= 100 Then
                                itemSeleccionado.PorcentajeDescuento = descuentoPorcentaje
                                Me.DataGridView1.Refresh()
                                ActualizarTotales()
                            Else
                                MessageBox.Show("Por favor, ingrese un porcentaje de descuento válido (entre 0 y 100).", "Error de Descuento", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                        Else
                            MessageBox.Show("Por favor, ingrese un valor numérico para el descuento.", "Error de Descuento", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    End If
                ElseIf DataGridView1.SelectedRows.Count > 1 Then
                    MessageBox.Show("Por favor, seleccione solo un ítem para aplicar el descuento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Por favor, seleccione un ítem para aplicar el descuento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub GuardarToolStripButton_Click(sender As Object, e As EventArgs) Handles GuardarToolStripButton.Click
        Me.IniciarOperacion()
    End Sub
End Class
