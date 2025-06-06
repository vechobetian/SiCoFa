Imports Newtonsoft.Json
Imports System.ComponentModel
Imports SiCoFa.Entidades
Imports SiCoFa.Negocio

Public Class FrmVentas
    Property Usuario As Usuario

    Public Property Cliente As Cliente

        Get
            Return mobj_Cliente
        End Get

        Set(value As Cliente)
            mobj_Cliente = value
            Me.ActualizarDatosOperacion()
            mobj_AdminSicofa.ActualizarOperacionCL(mobj_Operacion.IdOperacion, mobj_Cliente.Id)
            mobj_ClienteOriginal = ClonarObjeto(mobj_Cliente)
        End Set
    End Property

    Private mobj_AdminSicofa As New N_AdminSiCoFa
    Private mobj_Operacion As Operacion
    Private mobj_OperacionOriginal As Operacion
    Private mobj_TipoOperacion As TipoOperacion
    Private mobj_Cliente As Cliente
    Private mobj_ClienteOriginal As Cliente
    Private mobj_Items As New BindingList(Of ItemComprobante)
    Private mobj_ItemsOriginal As BindingList(Of ItemComprobante)
    Private mint_CantidadItems As Integer = 0
    Private mdec_ImporteCosto As Decimal = 0
    Private mdec_ImporteSinDescuentos As Decimal = 0
    Private mdec_ImporteDescuentos As Decimal = 0
    Private mdec_ImporteConDescuentos As Decimal = 0
    Private mdec_PorcentaDescuentos As Decimal = 0
    Private mdec_ImporteGravado1 As Decimal = 0
    Private mdec_ImporteGravado2 As Decimal = 0

    Private Function ClonarObjeto(Of T)(obj As T) As T
        Dim json As String = JsonConvert.SerializeObject(obj)
        Return JsonConvert.DeserializeObject(Of T)(json)
    End Function

    Private Function SeleccionarClienteListado(ByVal Id As Int32, ByVal ListaClientes As List(Of Cliente)) As Cliente

        Try
            Dim ClienteSeleccionado As Cliente = Nothing

            For Each c As Cliente In ListaClientes
                If c.Id = Id Then
                    Dim objCC As CuentaCorriente = mobj_AdminSicofa.ObtenerCuentaCorrientePorIdCliente(c.Id)
                    If objCC IsNot Nothing Then
                        c.CuentaCorriente = objCC
                    End If

                    ClienteSeleccionado = c

                    Exit For ' Opcional: detener la búsqueda una vez encontrado el cliente
                End If
            Next
            Return ClienteSeleccionado

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
            Return Nothing
        End Try

    End Function

    Private Sub AbrirOperacion()
        Try
            Dim frm As New FrmBuscaVentasIniciadas()

            If frm.CargarVentasIniciadas(g_ParametrosTerminal.Empresa.Id, Me.Usuario.Id) Then
                frm.ShowDialog()
            Else
                MsgBox("El Usuario " & Me.Usuario.Id & " no tiene Ventas Iniciadas", vbInformation, "SiCoFa")
                frm.Dispose()
            End If

            If frm.IdOperacionSeleccionado > 0 Then
                mobj_Operacion = mobj_AdminSicofa.ObtenerOperacion(frm.IdOperacionSeleccionado)
                mobj_Operacion.Empresa = g_ParametrosTerminal.Empresa
                mobj_Operacion.Usuario = Me.Usuario
                mobj_Operacion.TipoOperacion = mobj_TipoOperacion
                mobj_OperacionOriginal = ClonarObjeto(mobj_Operacion)
                mobj_Cliente = mobj_AdminSicofa.ObtenerOperacionCL(mobj_Operacion.IdOperacion)

                If mobj_Cliente Is Nothing Then
                    mobj_Cliente = mobj_AdminSicofa.ObtenerClientePorId(1)
                End If

                mobj_ClienteOriginal = ClonarObjeto(mobj_Cliente)

                Dim objItems As List(Of ItemComprobante) = mobj_AdminSicofa.ListarItemsPorIdOperacion(mobj_Operacion.IdOperacion)
                mobj_Items = New BindingList(Of ItemComprobante)(objItems)
                mobj_ItemsOriginal = ClonarObjeto(mobj_Items)
                Me.ActualizarTotales()
                Me.ActualizarDatosOperacion()

                Me.DataGridView1.AutoGenerateColumns = False
                Me.DataGridView1.DataSource = Me.mobj_Items
                Me.DataGridView1.ClearSelection()

            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try
    End Sub

    Private Sub GuardarCambios(ByVal argTecla As Keys)
        Try

            If Me.mdec_ImporteSinDescuentos = 0 Then
                Exit Sub
            End If

            If mobj_Operacion Is Nothing Then
                mobj_Operacion = mobj_AdminSicofa.IniciarOperacion(argEmpresa:=g_ParametrosTerminal.Empresa, Me.Usuario, mobj_TipoOperacion, "", "GUARDADO")
                If mobj_Operacion IsNot Nothing Then
                    mobj_OperacionOriginal = ClonarObjeto(mobj_Operacion)
                End If
            Else
                mobj_Operacion.Inicio = Now
                mobj_Operacion.Observaciones = ""
                mobj_Operacion.EstadoOperacion = "GUARDADO"
                Dim Actualizado As Boolean = mobj_AdminSicofa.ActualizarOperacion(mobj_Operacion)

                If Actualizado = True Then
                    mobj_OperacionOriginal = ClonarObjeto(mobj_Operacion)
                End If

            End If

            If mobj_Cliente Is Nothing Then
                mobj_Cliente = mobj_AdminSicofa.ObtenerClientePorId(1)
                mobj_ClienteOriginal = ClonarObjeto(mobj_Cliente)
                mobj_AdminSicofa.InsertarOperacionCL(mobj_Operacion.IdOperacion, mobj_Cliente.Id)
            End If

            Dim clienteCambio = Not JsonConvert.SerializeObject(mobj_Cliente).Equals(JsonConvert.SerializeObject(mobj_ClienteOriginal))

            If clienteCambio Then
                mobj_AdminSicofa.ActualizarOperacionCL(mobj_Operacion.IdOperacion, mobj_Cliente.Id)
                mobj_ClienteOriginal = ClonarObjeto(mobj_Cliente)
            End If

            Me.InsertarItems(mobj_Operacion.IdOperacion)

            If argTecla = Keys.F9 OrElse argTecla = Keys.F10 Then

                Using FPagos As New FrmPagos

                    With FPagos
                        .FrmOrigen = Me
                        .Operacion = mobj_Operacion
                        .Cliente = mobj_Cliente
                        .TeclaPresionada = argTecla
                        .ImporteAPagar = mdec_ImporteConDescuentos
                        .ImporteDescuento = mdec_ImporteDescuentos
                        .ImporteGravado1 = mdec_ImporteGravado1
                        .ImporteGravado2 = mdec_ImporteGravado2
                        .ItemsComprobante = mobj_Items.ToList
                        .ShowDialog()
                    End With
                End Using

            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
        End Try
    End Sub

    Private Sub InsertarItems(ByVal argIdOperacion As Long)
        Try
            For Each i As ItemComprobante In mobj_Items
                If i.IdItem = 0 Then
                    i.IdItem = mobj_AdminSicofa.InsertarItemComprobante(argIdOperacion, i)
                Else
                    Dim Actualizado As Boolean = mobj_AdminSicofa.ActualizarItemComprobante(i.IdItem, i.Cantidad, i.PrecioUnitario, i.DescuentoUnitario)
                End If
            Next

            mobj_ItemsOriginal = ClonarObjeto(mobj_Items)

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
                    If indiceFilaSeleccionada >= 0 AndAlso indiceFilaSeleccionada < mobj_Items.Count Then
                        If mobj_Items.Item(indiceFilaSeleccionada).IdItem > 0 Then
                            Dim Eliminado As Boolean = mobj_AdminSicofa.EliminarItemComprobante(mobj_Items.Item(indiceFilaSeleccionada).IdItem)
                        End If

                        mobj_Items.RemoveAt(indiceFilaSeleccionada)
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
                    la = mobj_AdminSicofa.ListarArticulos(argTextoBuscado)

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
                    mobj_Items.Add(i)
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
            mint_CantidadItems = 0
            mdec_ImporteCosto = 0
            mdec_ImporteSinDescuentos = 0
            mdec_ImporteDescuentos = 0
            mdec_ImporteConDescuentos = 0
            mdec_PorcentaDescuentos = 0
            mdec_ImporteGravado1 = 0
            mdec_ImporteGravado2 = 0

            For Each i As ItemComprobante In Me.mobj_Items
                mint_CantidadItems += 1
                mdec_ImporteCosto += (i.Articulo.PrecioCosto * i.Cantidad)
                mdec_ImporteSinDescuentos += i.ImporteSinDescuento
                mdec_ImporteDescuentos += i.ImporteDescuento
                mdec_ImporteConDescuentos += i.ImporteConDescuento

                Select Case i.AlicIVA
                    Case 10.5
                        mdec_ImporteGravado1 += i.ImporteConDescuento
                    Case 21
                        mdec_ImporteGravado2 += i.ImporteConDescuento
                End Select
            Next

            If mdec_ImporteSinDescuentos > 0 Then
                mdec_PorcentaDescuentos = Math.Round(mdec_ImporteDescuentos / mdec_ImporteSinDescuentos * 100, 2, MidpointRounding.ToEven)
            Else
                mdec_PorcentaDescuentos = 0
            End If

            Me.lblCantidadItems.Text = "- Items: " & mint_CantidadItems
            Me.lblImporteSinDescuentos.Text = "$ " & Format(mdec_ImporteSinDescuentos, "#,##0.00")
            Me.lblPorcentajeAplicado.Text = "- Porcentaje Descuentos: " & Format(mdec_PorcentaDescuentos, "#,##0.00") & "%"
            Me.lblImporteDescuentos.Text = "$ " & Format(mdec_ImporteDescuentos, "#,##0.00")
            Me.lblImporteConDescuentos.Text = "$ " & Format(mdec_ImporteConDescuentos, "#,##0.00")

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub ActualizarDatosOperacion()
        Dim NombreCliente As String
        If mobj_Cliente Is Nothing Then
            NombreCliente = "CONSUMIDOR FINAL NO IDENTIFICADO"
        Else
            NombreCliente = mobj_Cliente.Nombre
        End If

        Dim UltimaActualizacion As String

        If mobj_Operacion Is Nothing Then
            Me.Text = "Nueva venta iniciada el " & Now & " por el usuario " & Me.Usuario.Nombre
            UltimaActualizacion = "- Inicio Operación: " & Now
        Else
            Me.Text = "Venta actualizada el " & mobj_Operacion.Inicio & " por el usuario " & Me.Usuario.Nombre
            UltimaActualizacion = "- Ultima Actualizacion: " & mobj_Operacion.Inicio
        End If

        Dim Datos As String = UltimaActualizacion & vbCrLf &
                              "- Usuario: " & Me.Usuario.Nombre & vbCrLf &
                              "- Cliente: " & NombreCliente
        Me.lblDatosOperacion.Text = Datos
    End Sub

    Private Sub FrmVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            mobj_TipoOperacion = mobj_AdminSicofa.ObtenerTipoOperacionPorCodiTO("VTAM")
            mobj_OperacionOriginal = ClonarObjeto(mobj_Operacion)
            mobj_ClienteOriginal = ClonarObjeto(mobj_Cliente)
            mobj_ItemsOriginal = ClonarObjeto(mobj_Items)

            Me.ActualizarDatosOperacion()
            Me.DataGridView1.AutoGenerateColumns = False
            Me.DataGridView1.DataSource = Me.mobj_Items
            Me.DataGridView1.ClearSelection()

            For Each item As ToolStripItem In ToolStrip1.Items
                item.Overflow = ToolStripItemOverflow.Never
            Next

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub FrmVentas_Shown(sender As Object, e As EventArgs) Handles Me.Shown

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

    Private Sub FrmVentas_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        Dim operacionCambio = Not JsonConvert.SerializeObject(mobj_Operacion).Equals(JsonConvert.SerializeObject(mobj_OperacionOriginal))
        Dim clienteCambio = Not JsonConvert.SerializeObject(mobj_Cliente).Equals(JsonConvert.SerializeObject(mobj_ClienteOriginal))
        Dim itemsCambio = Not JsonConvert.SerializeObject(mobj_Items).Equals(JsonConvert.SerializeObject(mobj_ItemsOriginal))

        If operacionCambio OrElse clienteCambio OrElse itemsCambio Then
            Dim resultado = MessageBox.Show("Hay cambios sin guardar. ¿Desea salir sin guardar?", "Confirmar", MessageBoxButtons.YesNoCancel)

            If resultado = DialogResult.Cancel Then
                e.Cancel = True
            ElseIf resultado = DialogResult.Yes Then
                Me.GuardarCambios(Keys.Escape)
            ElseIf resultado = DialogResult.No Then
                ' Salir sin guardar
            End If
        End If

    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData
            Case Keys.F10
                Me.GuardarCambios(Keys.F10)
            Case Keys.F9
                Me.GuardarCambios(Keys.F9)
            Case Keys.F8

            Case Else
                Return MyBase.ProcessCmdKey(msg, keyData)
        End Select
        Return True ' Asegúrate de devolver True para que la tecla se procese correctamente
    End Function

    Private Sub FrmVentas_Resize(sender As Object, e As EventArgs) Handles Me.Resize
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
                        Dim itemComprobante As ItemComprobante = mobj_Items(e.RowIndex)

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

                If indiceFilaSeleccionada >= 0 AndAlso indiceFilaSeleccionada < mobj_Items.Count Then
                    Dim itemSeleccionado = mobj_Items(indiceFilaSeleccionada)

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

    Private Sub NuevoToolStripButton_Click(sender As Object, e As EventArgs) Handles NuevoToolStripButton.Click
        mobj_Operacion = Nothing
        mobj_OperacionOriginal = Nothing
        mobj_Items = Nothing
        mobj_ItemsOriginal = Nothing
        mobj_Cliente = Nothing
        mobj_ClienteOriginal = Nothing
        Me.DataGridView1.Rows.Clear()
    End Sub

    Private Sub AbrirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AbrirToolStripMenuItem.Click
        Me.AbrirOperacion()
    End Sub

    Private Sub AbrirToolStripButton_Click(sender As Object, e As EventArgs) Handles AbrirToolStripButton.Click
        Me.AbrirOperacion()
    End Sub

    Private Sub GuardarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarToolStripMenuItem.Click
        Me.GuardarCambios(Keys.Escape)
        MsgBox("Los cambios se guardaron con exito", vbInformation, "SiCoFa")
    End Sub

    Private Sub GuardarToolStripButton_Click(sender As Object, e As EventArgs) Handles GuardarToolStripButton.Click
        Me.GuardarCambios(Keys.Escape)
        MsgBox("Los cambios se guardaron con exito", vbInformation, "SiCoFa")
    End Sub

    Private Sub SalirToolStripButton_Click(sender As Object, e As EventArgs) Handles SalirToolStripButton.Click
        Me.Close()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub FacturarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacturarToolStripMenuItem.Click
        Me.GuardarCambios(Keys.F10)
    End Sub

    Private Sub RemitoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemitoToolStripMenuItem.Click
        Me.GuardarCambios(Keys.F9)
    End Sub

    Private Sub CopiarToolStripButton_Click(sender As Object, e As EventArgs) Handles CopiarToolStripButton.Click

        PortapapelesVenta.Operacion = ClonarObjeto(mobj_Operacion)
        PortapapelesVenta.Items = ClonarObjeto(mobj_Items)
        PortapapelesVenta.Cliente = ClonarObjeto(mobj_Cliente)

    End Sub

    Private Sub PegarToolStripButton_Click(sender As Object, e As EventArgs) Handles PegarToolStripButton.Click
        If PortapapelesVenta.Operacion IsNot Nothing Then
            mobj_Items = ClonarObjeto(PortapapelesVenta.Items)
            mobj_Cliente = ClonarObjeto(PortapapelesVenta.Cliente)

            ' Actualizar la fuente de datos del DataGridView
            Me.DataGridView1.DataSource = Nothing
            Me.DataGridView1.DataSource = mobj_Items
            Me.DataGridView1.ClearSelection()

            ' Actualizar cualquier dato visual relacionado, por ejemplo:
            Me.ActualizarDatosOperacion()
            Me.ActualizarTotales()
        End If
    End Sub

    Private Sub ClienteToolStripButton_Click(sender As Object, e As EventArgs) Handles ClienteToolStripButton.Click

        Try
            Dim str = InputBox("Ingrese la Persona", "SiCoFa")


            If str = "" Then
                Exit Sub
            End If

            Dim lc As List(Of Cliente) = mobj_AdminSicofa.ListarClientes(str)
            Dim c As Cliente = Nothing

            If lc Is Nothing Then
                MsgBox("Cliente no Encontrado", vbInformation, "SiCoFa")
                Exit Sub
            End If

            Select Case lc.Count
                Case 0
                    MsgBox("Cliente no Encontrado", vbInformation, "SiCoFa")
                    Exit Sub

                Case 1
                    c = lc.First

                Case > 1
                    Using f As New FrmBuscaPersonas
                        f.Personas = lc
                        f.ShowDialog()
                        If f.DialogResult = DialogResult.OK Then
                            Dim p As Persona = f.PersonaSeleccionado
                            c = Me.SeleccionarClienteListado(p.Id, lc)
                        End If
                        f.Close()
                    End Using

            End Select

            Me.mobj_Cliente = c
            Me.ActualizarDatosOperacion()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

End Class
