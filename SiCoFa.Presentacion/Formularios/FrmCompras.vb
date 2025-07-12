Imports Newtonsoft.Json
Imports System.ComponentModel
Imports SiCoFa.Entidades
Imports SiCoFa.Negocio

Public Class FrmCompras
    Property Usuario As Usuario

    Private mobj_AdminOperacion As New N_AdminOperaciones
    Private mobj_Operacion As Operacion
    Private mobj_OperacionOriginal As Operacion
    Private mobj_TipoOperacion As TipoOperacion
    Private mobj_Items As New BindingList(Of ItemComprobanteCompra)
    Private mobj_ItemsOriginal As BindingList(Of ItemComprobanteCompra)
    Private mint_CantidadItems As Integer = 0
    Private mdec_ImporteNeto As Decimal = 0
    Private mdec_ImporteIva As Decimal = 0
    Private mdec_ImporteTotal As Decimal = 0

    Private Function ClonarObjeto(Of T)(obj As T) As T
        Dim json As String = JsonConvert.SerializeObject(obj)
        Return JsonConvert.DeserializeObject(Of T)(json)
    End Function

    Private Sub BuscarCompraIniciada()

        Try

            Dim AdminDB As New N_AdminDB
            Dim sql As String = $"SELECT IdOperacion, CONCAT(DATE_FORMAT(Inicio, '%d/%m/%Y %H:%i:%s'),'   |   ',IFNULL(Observaciones, '')) As Descripcion FROM TblOperaciones WHERE IdUsuario = {Me.Usuario.Id} And CodiTO = 'COMPM' And EstadoOperacion = 'GUARDADO'"
            Dim dt As DataTable = AdminDB.ObtenerTabla(sql)

            Select Case dt.Rows.Count
                Case 0
                    MsgBox($"No existen Compras Iniciadas por el Usuario {Me.Usuario.Nombre}", vbInformation, "SiCoFa")
                    Exit Sub

                Case 1
                    Dim fila As DataRow = dt.Rows(0)
                    Dim idOperacion As Long = Convert.ToInt64(fila("IdOperacion"))
                    Me.AbrirCompra(idOperacion)
                    Exit Sub

                Case > 1

                    Using f As New FrmSelectorUniversal
                        f.Text = "Compras Iniciadas"
                        f.Objetos = dt.DefaultView
                        f.NombrePropiedadId = "IdOperacion"
                        f.NombrePropiedadDescripcion = "Descripcion"
                        f.HeaderPropiedadDescripcion = "            Fecha              |            Descripcion"

                        If f.ShowDialog() = DialogResult.OK Then
                            Dim idOperacion As Long = Convert.ToInt64(f.Valor1Seleccionado)
                            Me.AbrirCompra(idOperacion)
                            f.Close()
                        End If

                    End Using

            End Select

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub AbrirCompra(ByVal argIdOperaciones As Long)
        Try
            mobj_Operacion = mobj_AdminOperacion.ObtenerOperacion(argIdOperaciones)
            mobj_Operacion.Empresa = g_ParametrosTerminal.Empresa
            mobj_Operacion.Usuario = Me.Usuario
            mobj_Operacion.TipoOperacion = mobj_TipoOperacion
            mobj_OperacionOriginal = ClonarObjeto(mobj_Operacion)

            Dim AdminItems As New N_AdminItemsComprobante
            Dim objItems As List(Of ItemComprobanteCompra) = AdminItems.ListarItemsCompraPorIdOperacion(mobj_Operacion.IdOperacion)
            mobj_Items = New BindingList(Of ItemComprobanteCompra)(objItems)
            mobj_ItemsOriginal = ClonarObjeto(mobj_Items)
            Me.ActualizarTotales()
            Me.ActualizarDatosOperacion()
            Me.DataGridView1.AutoGenerateColumns = False
            Me.DataGridView1.DataSource = Me.mobj_Items
            Me.DataGridView1.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try
    End Sub

    Private Sub Serializar()
        Dim json1 = JsonConvert.SerializeObject(mobj_Items, Formatting.Indented)
        Dim json2 = JsonConvert.SerializeObject(mobj_ItemsOriginal, Formatting.Indented)

        ' Guardalos en archivo o mostralos en consola para comparar:
        Debug.WriteLine(json1)
        Debug.WriteLine("-----")
        Debug.WriteLine(json2)
    End Sub

    Private Sub GuardarCambios(ByVal argTecla As Keys, ByVal argDescripcion As String)
        Try

            If Me.mdec_ImporteNeto = 0 Then
                Exit Sub
            End If

            If mobj_Operacion Is Nothing Then

                Dim descripcion As String
                If mobj_Operacion IsNot Nothing Then
                    descripcion = mobj_Operacion.Observaciones
                Else
                    descripcion = "COMPRA SIN DESCRIPCION"
                End If

                Dim str = InputBox("Ingrese una descripcion", "SiCoFa", descripcion)

                mobj_Operacion = mobj_AdminOperacion.IniciarOperacion(argEmpresa:=g_ParametrosTerminal.Empresa, Me.Usuario, mobj_TipoOperacion, descripcion, "GUARDADO")

                If mobj_Operacion IsNot Nothing Then
                    mobj_OperacionOriginal = ClonarObjeto(mobj_Operacion)
                End If

            Else

                mobj_Operacion.Inicio = Now

                If argDescripcion = "" Then
                    mobj_Operacion.Observaciones = mobj_Operacion.Observaciones
                Else
                    mobj_Operacion.Observaciones = argDescripcion
                End If

                mobj_Operacion.EstadoOperacion = "GUARDADO"
                Dim Actualizado As Boolean = mobj_AdminOperacion.ActualizarOperacion(mobj_Operacion)

                If Actualizado = True Then
                    mobj_OperacionOriginal = ClonarObjeto(mobj_Operacion)
                End If

            End If

            Me.InsertarItems(mobj_Operacion.IdOperacion)

            If argTecla = Keys.F10 Then

                Using FPagos As New FrmPagos
                    Dim AdminComprobantes As New N_AdminComprobantes
                    With FPagos
                        '.FrmOrigen = Me
                        '.Operacion = mobj_Operacion
                        '.ImporteAPagar = mdec_ImporteConDescuentos
                        '.ImporteDescuento = mdec_ImporteDescuentos
                        '.ImporteGravado1 = mdec_ImporteGravado1
                        '.ImporteGravado2 = mdec_ImporteGravado2
                        '.ItemsComprobante = mobj_Items.ToList
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
            Dim AdminItems As New N_AdminItemsComprobante
            For Each i As ItemComprobanteCompra In mobj_Items
                If i.IdItem = 0 Then
                    i.IdItem = AdminItems.InsertarItemComprobanteCompra(argIdOperacion, i)
                Else
                    Dim Actualizado As Boolean = AdminItems.ActualizarItemComprobanteCompra(i.IdItem, i.Cantidad, i.PrecioCosto, i.PrecioVenta)
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
                Dim AdminItems As New N_AdminItemsComprobante
                Dim indicesAEliminar As New List(Of Integer)

                For i As Integer = DataGridView1.SelectedRows.Count - 1 To 0 Step -1
                    Dim indiceFilaSeleccionada As Integer = DataGridView1.SelectedRows(i).Index
                    If indiceFilaSeleccionada >= 0 AndAlso indiceFilaSeleccionada < mobj_Items.Count Then
                        If mobj_Items.Item(indiceFilaSeleccionada).IdItem > 0 Then
                            Dim Eliminado As Boolean = AdminItems.EliminarItemComprobante(mobj_Items.Item(indiceFilaSeleccionada).IdItem)
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

            If DataGridView1.ColumnCount = 11 Then
                Dim totalAncho As Integer = DataGridView1.Width
                Dim proporciones As Double() = {0.0R, 0.0R, 0.05R, 0.5R, 0.05R, 0.05R, 0.08R, 0.08R, 0.08R, 0.08R, 0.03R}

                For i As Integer = 0 To 10 ' Itera a través de las 11 columnas
                    DataGridView1.Columns(i).Width = CInt(totalAncho * proporciones(i))
                Next
            Else
                MessageBox.Show("El DataGridView no tiene 11 columnas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                    Dim AdminArticulos As New N_AdminArticulos
                    la = AdminArticulos.ListarArticulos(argTextoBuscado)

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
                    Dim i As ItemComprobanteCompra
                    Dim precioCosto As Decimal
                    If Me.mnuOpcionesIVAIncluidoEnPrecioCosto.Checked Then
                        i = New ItemComprobanteCompra(a, 1, a.PrecioCosto, a.PrecioVenta, a.ListaPrecios.PorcentajeAplicado, True)
                    Else
                        precioCosto = a.PrecioCosto / (1 + a.AlicuotaIVA.AlicIVA / 100)
                        i = New ItemComprobanteCompra(a, 1, precioCosto, a.PrecioVenta, a.ListaPrecios.PorcentajeAplicado, False)
                    End If

                    mobj_Items.Add(i)
                    Me.DataGridView1.ClearSelection()

                    Dim nuevoIndiceFila As Integer = Me.DataGridView1.Rows.Count - 1
                    Dim nombreColumnaCantidad As String = "Cantidad" ' Reemplaza con el nombre real

                    If Me.DataGridView1.Columns.Contains(nombreColumnaCantidad) AndAlso nuevoIndiceFila >= 0 Then
                        ' Aplazar la configuración de CurrentCell y BeginEdit
                        Me.BeginInvoke(New Action(Sub()
                                                      Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(nuevoIndiceFila).Cells(nombreColumnaCantidad)
                                                      Me.DataGridView1.BeginEdit(True) ' Iniciar la edición de la celda
                                                  End Sub))
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
            mdec_ImporteNeto = 0
            mdec_ImporteIva = 0
            mdec_ImporteTotal = 0


            For Each i As ItemComprobanteCompra In Me.mobj_Items
                mint_CantidadItems += 1
                mdec_ImporteNeto += i.ImporteNeto
                mdec_ImporteIva += i.ImporteIVA
                mdec_ImporteTotal += i.ImporteTotal
            Next

            Me.lblCantidadItems.Text = "- Items: " & mint_CantidadItems
            Me.lblImporteNeto.Text = "$ " & Format(mdec_ImporteNeto, "#,##0.00")
            Me.lblImporteIVA.Text = "$ " & Format(mdec_ImporteIva, "#,##0.00")
            Me.lblImporteTotal.Text = "$ " & Format(mdec_ImporteTotal, "#,##0.00")

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub ActualizarDatosOperacion()

        Dim UltimaActualizacion As String

        If mobj_Operacion Is Nothing Then
            Me.Text = "Nueva venta iniciada el " & Now & " por el usuario " & Me.Usuario.Nombre
            UltimaActualizacion = "- Inicio Operación: " & Now
        Else
            Me.Text = "Venta actualizada el " & mobj_Operacion.Inicio & " por el usuario " & Me.Usuario.Nombre
            UltimaActualizacion = "- Ultima Actualizacion: " & mobj_Operacion.Inicio
        End If

        Dim Datos As String = UltimaActualizacion & vbCrLf &
                                     "- Usuario: " & Me.Usuario.Nombre

        Me.lblDatosOperacion.Text = Datos
    End Sub

    Private Sub FrmVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            mobj_TipoOperacion = mobj_AdminOperacion.ObtenerTipoOperacionPorCodiTO("COMPM")
            mobj_OperacionOriginal = ClonarObjeto(mobj_Operacion)
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

        Try

            Dim operacionCambio = Not JsonConvert.SerializeObject(mobj_Operacion).Equals(JsonConvert.SerializeObject(mobj_OperacionOriginal))
            Dim itemsCambio = Not JsonConvert.SerializeObject(mobj_Items).Equals(JsonConvert.SerializeObject(mobj_ItemsOriginal))

            If operacionCambio OrElse itemsCambio Then
                Dim resultado = MessageBox.Show("Hay cambios sin guardar. ¿Desea guardar los cambios?", "Confirmar", MessageBoxButtons.YesNoCancel)

                If resultado = DialogResult.Cancel Then
                    e.Cancel = True

                ElseIf resultado = DialogResult.Yes Then
                    Me.GuardarCambios(Keys.Escape, "")

                ElseIf resultado = DialogResult.No Then
                    ' Salir sin guardar

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean

        Select Case keyData
            Case Keys.F10
                Me.GuardarCambios(Keys.F10, "")

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

                    ' No llames a BeginEdit aquí, es problemático dentro de CellValidating.
                    ' El DataGridView volverá automáticamente al modo de edición si e.Cancel es verdadero.

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
                Dim nombreColumnaPrecioCosto As String = "PrecioCosto"
                Dim nombreColumnaPrecioVenta As String = "PrecioVenta"

                If nombreColumnaEditada.Equals(nombreColumnaCantidad, StringComparison.OrdinalIgnoreCase) Then
                    If String.IsNullOrEmpty(DataGridView1.Rows(e.RowIndex).ErrorText) Then
                        ' Usa BeginInvoke para aplazar la operación de la interfaz de usuario
                        Me.BeginInvoke(New Action(Sub()
                                                      Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(e.RowIndex).Cells(nombreColumnaPrecioCosto)
                                                      Me.DataGridView1.CurrentCell.ReadOnly = False
                                                      Me.DataGridView1.BeginEdit(True)
                                                      Me.DataGridView1.Refresh()
                                                      Me.ActualizarTotales()
                                                  End Sub))
                    End If
                End If

                If nombreColumnaEditada.Equals(nombreColumnaPrecioCosto, StringComparison.OrdinalIgnoreCase) Then
                    If String.IsNullOrEmpty(DataGridView1.Rows(e.RowIndex).ErrorText) Then
                        ' Usa BeginInvoke para aplazar la operación de la interfaz de usuario
                        Me.BeginInvoke(New Action(Sub()
                                                      Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(e.RowIndex).Cells(nombreColumnaPrecioVenta)
                                                      Me.DataGridView1.CurrentCell.ReadOnly = False
                                                      Me.DataGridView1.BeginEdit(True)
                                                      Me.DataGridView1.Refresh()
                                                      Me.ActualizarTotales()
                                                  End Sub))
                    End If
                End If

                If nombreColumnaEditada.Equals(nombreColumnaPrecioVenta, StringComparison.OrdinalIgnoreCase) Then
                    If String.IsNullOrEmpty(DataGridView1.Rows(e.RowIndex).ErrorText) Then
                        ' Usa BeginInvoke para aplazar la operación de la interfaz de usuario
                        Me.BeginInvoke(New Action(Sub()
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
                                                  End Sub))
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub ElimininarItemSeleccionadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuEdicionEliminarItem.Click
        Me.EliminarItemSeleccionado()
    End Sub

    Private Sub NuevoToolStripButton_Click(sender As Object, e As EventArgs) Handles NuevoToolStripButton.Click

        Dim nuevaVentanaVentas As New FrmCompras()
        nuevaVentanaVentas.Usuario = Me.Usuario
        nuevaVentanaVentas.Show()

        Me.Close()

    End Sub

    Private Sub mnuArchivoAbrir_Click(sender As Object, e As EventArgs) Handles mnuArchivoAbrir.Click
        Me.BuscarCompraIniciada()
    End Sub

    Private Sub AbrirToolStripButton_Click(sender As Object, e As EventArgs) Handles AbrirToolStripButton.Click
        Me.BuscarCompraIniciada()
    End Sub

    Private Sub mnuArchivoGuardar_Click(sender As Object, e As EventArgs) Handles mnuArchivoGuardar.Click
        Me.GuardarCambios(Keys.Escape, "")
        MsgBox("Los cambios se guardaron con exito", vbInformation, "SiCoFa")
    End Sub

    Private Sub mnuArchivoGuardarComo_Click(sender As Object, e As EventArgs) Handles mnuArchivoGuardarComo.Click

        Dim descripcion As String
        If mobj_Operacion IsNot Nothing Then
            descripcion = mobj_Operacion.Observaciones
        Else
            descripcion = "COMPRA SIN DESCRIPCION"
        End If

        Dim str = InputBox("Ingrese una descripcion", "SiCoFa", descripcion)

        Me.GuardarCambios(Keys.Escape, str)

    End Sub

    Private Sub GuardarToolStripButton_Click(sender As Object, e As EventArgs) Handles GuardarToolStripButton.Click
        Me.GuardarCambios(Keys.Escape, "")
        MsgBox("Los cambios se guardaron con exito", vbInformation, "SiCoFa")
    End Sub

    Private Sub SalirToolStripButton_Click(sender As Object, e As EventArgs) Handles SalirToolStripButton.Click
        Me.Close()
    End Sub

    Private Sub mnuArchivoSalir_Click(sender As Object, e As EventArgs) Handles mnuArchivoSalir.Click
        Me.Close()
    End Sub

    Private Sub mnuOpcionesIVAIncluidoEnPrecioCosto_Click(sender As Object, e As EventArgs) Handles mnuOpcionesIVAIncluidoEnPrecioCosto.Click
        Dim IVA As Boolean = Me.mnuOpcionesIVAIncluidoEnPrecioCosto.Checked

        For Each i As ItemComprobanteCompra In Me.mobj_Items

            If Me.mnuOpcionesIVAIncluidoEnPrecioCosto.Checked Then
                i.PrecioCosto = i.PrecioCosto * (1 + i.AlicIVA / 100)
                Me.lblIVAIncluido.Text = "-Precio Costo con IVA Incluido"
            Else
                Dim precioCosto As Decimal = i.PrecioCosto / (1 + i.AlicIVA / 100)
                i.PrecioCosto = precioCosto
                Me.lblIVAIncluido.Text = "-Precio Costo sin IVA"
            End If

            i.IVAIncluido = IVA
        Next
        Me.DataGridView1.Refresh()
        Me.ActualizarTotales()

    End Sub

End Class