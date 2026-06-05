Imports Newtonsoft.Json
Imports System.ComponentModel
Imports SiCoFa.Entidades
Imports SiCoFa.Negocio
Imports SiCoFa.Entidades.Enums

Public Class FrmVentas
    Property Usuario As Usuario

    Public Property Cliente As Cliente

        Get
            Return mobj_Cliente
        End Get

        Set(value As Cliente)
            mobj_Cliente = value
            Me.ActualizarDatosOperacion()
            mobj_AdminOperacion.ActualizarOperacionCL(mobj_Operacion.IdOperacion, mobj_Cliente.Id)
            'mobj_ClienteOriginal = ClonarObjeto(mobj_Cliente)
        End Set
    End Property

    Private mobj_AdminOperacion As New N_AdminOperaciones
    Private mobj_Operacion As Operacion
    'Private mobj_OperacionOriginal As Operacion
    Private mobj_TipoOperacion As TipoOperacion
    Private mobj_Cliente As Cliente
    'Private mobj_ClienteOriginal As Cliente
    Private mobj_Items As New BindingList(Of ItemComprobante)
    'Private mobj_ItemsOriginal As BindingList(Of ItemComprobante)
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
                    Dim AdminClientes As New N_AdminClientes
                    Dim objCC As CuentaCorriente = AdminClientes.ObtenerCuentaCorrientePorIdCliente(c.Id)
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
            Dim frm As New FrmBuscaOperacionesIniciadas()

            If frm.CargarVentasIniciadas(g_ParametrosTerminal.Empresa.Id, Me.Usuario.Id, "VTAM") Then
                frm.ShowDialog()
            Else
                MsgBox("El Usuario " & Me.Usuario.Id & " no tiene Ventas Iniciadas", vbInformation, "SiCoFa")
                frm.Dispose()
            End If

            If frm.IdOperacionSeleccionado > 0 Then
                mobj_Operacion = mobj_AdminOperacion.ObtenerOperacion(frm.IdOperacionSeleccionado)
                mobj_Operacion.Empresa = g_ParametrosTerminal.Empresa
                mobj_Operacion.Usuario = Me.Usuario
                mobj_Operacion.TipoOperacion = mobj_TipoOperacion
                'mobj_OperacionOriginal = ClonarObjeto(mobj_Operacion)
                mobj_Cliente = mobj_AdminOperacion.ObtenerOperacionCL(mobj_Operacion.IdOperacion)

                If mobj_Cliente Is Nothing Then
                    Dim AdminClientes As New N_AdminClientes
                    mobj_Cliente = AdminClientes.ObtenerClientePorId(1)
                End If

                'mobj_ClienteOriginal = ClonarObjeto(mobj_Cliente)

                Dim AdminItems As New N_AdminItemsComprobante
                Dim objItems As List(Of ItemComprobante) = AdminItems.ListarItemsPorIdOperacion(mobj_Operacion.IdOperacion)
                mobj_Items = New BindingList(Of ItemComprobante)(objItems)
                'mobj_ItemsOriginal = ClonarObjeto(mobj_Items)
                RenderItemsUC()
                Me.ActualizarTotales()
                Me.ActualizarDatosOperacion()
                Me.AgregarItemVacio()

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
                mobj_Operacion = mobj_AdminOperacion.IniciarOperacion(argEmpresa:=g_ParametrosTerminal.Empresa, Me.Usuario, mobj_TipoOperacion, "", "GUARDADO")
                'If mobj_Operacion IsNot Nothing Then
                'mobj_OperacionOriginal = ClonarObjeto(mobj_Operacion)
                'End If
            Else
                mobj_Operacion.Inicio = Now
                mobj_Operacion.Observaciones = ""
                mobj_Operacion.EstadoOperacion = "GUARDADO"
                Dim Actualizado As Boolean = mobj_AdminOperacion.ActualizarOperacion(mobj_Operacion)

                'If Actualizado = True Then
                'mobj_OperacionOriginal = ClonarObjeto(mobj_Operacion)
                'End If

            End If

            If mobj_Cliente Is Nothing Then
                Dim AdminClientes As New N_AdminClientes
                mobj_Cliente = AdminClientes.ObtenerClientePorId(1)
                'mobj_ClienteOriginal = ClonarObjeto(mobj_Cliente)
                mobj_AdminOperacion.InsertarOperacionCL(mobj_Operacion.IdOperacion, mobj_Cliente.Id)
            End If

            'Dim clienteCambio = Not JsonConvert.SerializeObject(mobj_Cliente).Equals(JsonConvert.SerializeObject(mobj_ClienteOriginal))

            'If clienteCambio Then
            mobj_AdminOperacion.ActualizarOperacionCL(mobj_Operacion.IdOperacion, mobj_Cliente.Id)
            'mobj_ClienteOriginal = ClonarObjeto(mobj_Cliente)
            'End If

            Me.InsertarItems(mobj_Operacion.IdOperacion)

            If argTecla = Keys.F9 OrElse argTecla = Keys.F10 Then

                Using FPagos As New FrmPagos
                    Dim AdminComprobantes As New N_AdminComprobantes
                    With FPagos
                        .FrmOrigen = Me
                        .Operacion = mobj_Operacion
                        .Cliente = mobj_Cliente

                        If argTecla = Keys.F9 Then
                            Dim tc As TipoComprobante = AdminComprobantes.ObtenerTipoComprobantePorCodiTC("RTOX")
                            .TipoComprobante = tc
                        ElseIf argTecla = Keys.F10 AndAlso g_ParametrosSistema.GetValor("SFISCAL") = "FE" Then
                            .TipoComprobante = Nothing
                        Else
                            Dim tc As TipoComprobante = AdminComprobantes.ObtenerTipoComprobantePorCodiTC("RTOX")
                            .TipoComprobante = tc
                        End If

                        .ImporteBruto = mdec_ImporteSinDescuentos
                        .ImporteDescuento = mdec_ImporteDescuentos
                        .ImporteAPagar = mdec_ImporteConDescuentos
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
            Dim AdminItems As New N_AdminItemsComprobante
            For Each i As ItemComprobante In mobj_Items

                If i.Articulo Is Nothing Then Continue For

                If i.IdItem = 0 Then
                    i.IdItem = AdminItems.InsertarItemComprobante(argIdOperacion, i)
                Else
                    Dim Actualizado As Boolean = AdminItems.ActualizarItemComprobante(i.IdItem, i.Cantidad, i.Articulo.PrecioCosto, i.PrecioUnitario, i.DescuentoUnitario)
                End If
            Next

            'mobj_ItemsOriginal = ClonarObjeto(mobj_Items)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try
    End Sub

    Private Sub RenderItemsUC()

        PanelItems.Controls.Clear()

        For i As Integer = mobj_Items.Count - 1 To 0 Step -1

            Dim item As ItemComprobante = mobj_Items(i)
            Dim uc As New UcItemVenta()
            uc.Bind(mobj_Items(i))

            If item.Articulo Is Nothing Then
                uc.ModoBusqueda()
            Else
                uc.ModoItemCargado(item.Articulo.Seccion.EstablecerPrecio)
            End If

            uc.Dock = DockStyle.Top

            AddHandler uc.OnEliminar, AddressOf EliminarItem
            AddHandler uc.BuscarArticuloRequest, AddressOf BuscarArticuloDesdeUC
            AddHandler uc.CantidadConfirmada, AddressOf CantidadConfirmada
            AddHandler uc.PrecioConfirmado, AddressOf PrecioConfirmado

            PanelItems.Controls.Add(uc)

        Next

    End Sub

    Private Sub RenderItemsUC1()

        PanelItems.Controls.Clear()

        For Each item As ItemComprobante In mobj_Items

            Dim uc As New UcItemVenta()
            uc.Bind(item)
            uc.Dock = DockStyle.Top

            AddHandler uc.OnEliminar, AddressOf EliminarItem
            AddHandler uc.BuscarArticuloRequest, AddressOf BuscarArticuloDesdeUC
            AddHandler uc.CantidadConfirmada, AddressOf CantidadConfirmada
            AddHandler uc.PrecioConfirmado, AddressOf PrecioConfirmado

            PanelItems.Controls.Add(uc)

        Next

    End Sub

    Private Sub AgregarItemUC(item As ItemComprobante)

        Dim uc As New UcItemVenta()

        uc.Bind(item)
        uc.Dock = DockStyle.Top

        AddHandler uc.OnEliminar, AddressOf EliminarItem
        AddHandler uc.BuscarArticuloRequest, AddressOf BuscarArticuloDesdeUC
        AddHandler uc.CantidadConfirmada, AddressOf CantidadConfirmada
        AddHandler uc.PrecioConfirmado, AddressOf PrecioConfirmado

        PanelItems.Controls.Add(uc)
        PanelItems.Controls.SetChildIndex(uc, 0)

    End Sub

    Private Sub AgregarItemVacio()

        Dim itemNuevo As New ItemComprobante()
        itemNuevo.EsNuevo = True

        mobj_Items.Add(itemNuevo)

        AgregarItemUC(itemNuevo)

        Dim nuevoUC As UcItemVenta = CType(PanelItems.Controls(0), UcItemVenta)

        nuevoUC.EnfocarDescripcion()

    End Sub

    Private Sub PasarAlSiguienteItem(ucActual As UcItemVenta)

        Dim index As Integer = PanelItems.Controls.GetChildIndex(ucActual)

        For i As Integer = index - 1 To 0 Step -1

            Dim uc As UcItemVenta = TryCast(PanelItems.Controls(i), UcItemVenta)

            If uc Is Nothing OrElse uc.ItemVenta Is Nothing Then Continue For

            If uc.ItemVenta.EsNuevo Then
                uc.EnfocarDescripcion()
            Else
                uc.EnfocarCantidad()
            End If

            Exit Sub

        Next

    End Sub

    Private Sub EliminarItem(item As ItemComprobante)

        mobj_Items.Remove(item)

        ' Eliminar filas vacías sobrantes
        For i As Integer = mobj_Items.Count - 1 To 0 Step -1

            If mobj_Items(i).Articulo Is Nothing Then
                mobj_Items.RemoveAt(i)
            End If

        Next

        ' Agregar una única fila vacía
        AgregarItemVacio()

        RenderItemsUC()

        ActualizarTotales()

    End Sub

    Private Sub EliminarItemSeleccionado()
        Try


        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
        End Try

    End Sub

    Private Sub BuscarArticuloDesdeUC(uc As UcItemVenta, texto As String)

        If String.IsNullOrWhiteSpace(texto) Then Exit Sub
        BuscarArticulo(uc, texto)

    End Sub

    Private Sub BuscarArticulo(uc As UcItemVenta, ByVal argTextoBuscado As String)

        Try

            If argTextoBuscado = "*" OrElse argTextoBuscado = "/" Then
                MsgBox("Articulo no Encontrado", vbInformation, "SiCoFa")
                Exit Sub
            End If

            Dim AdminArticulos As New N_AdminArticulos
            Dim a As Articulo = Nothing
            Dim la As New List(Of Articulo)

            Select Case Strings.Left(argTextoBuscado, 1)
                Case "*"
                    a = AdminArticulos.ArticuloGenericoExento(argTextoBuscado)
                    la.Add(a)

                Case "/"
                    a = AdminArticulos.ArticuloGenericoGravado(argTextoBuscado)
                    la.Add(a)

                Case Else
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

            If a IsNot Nothing Then

                Dim i As ItemComprobante = uc.ItemVenta

                i.Articulo = a
                i.CodBarras = a.CodBarras
                i.Descripcion = a.Nombre
                i.Cantidad = 1
                i.PrecioUnitario = a.PrecioVenta
                i.AlicIVA = a.AlicIVA

                uc.Bind(i)
                uc.ModoItemCargado(a.Seccion.EstablecerPrecio)
                uc.HabilitarCantidad()
                uc.EnfocarCantidad()

                ActualizarTotales()
            Else
                uc.txtDescripcion.Text = ""
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub CantidadConfirmada(uc As UcItemVenta)

        If uc.ItemVenta.Articulo Is Nothing Then
            uc.EnfocarDescripcion()
            Exit Sub
        End If

        uc.ItemVenta.Cantidad = Val(uc.txtCantidad.Text)

        ActualizarTotales()

        ' 🔥 SI ES NUEVO (flujo de carga)
        If uc.ItemVenta.EsNuevo Then

            If uc.ItemVenta.Articulo.Seccion.EstablecerPrecio Then

                uc.HabilitarPrecio()
                uc.EnfocarPrecio()

            Else

                uc.ItemVenta.EsNuevo = False
                AgregarItemVacio()

                Dim nuevoUC As UcItemVenta =
                CType(PanelItems.Controls(0), UcItemVenta)

            End If

            Exit Sub
        End If

        ' 🔁 SI NO ES NUEVO (EDICIÓN)
        PasarAlSiguienteItem(uc)

    End Sub

    Private Sub PrecioConfirmado(uc As UcItemVenta)

        If uc.ItemVenta.Articulo Is Nothing Then
            uc.EnfocarDescripcion()
            Exit Sub
        End If

        uc.ItemVenta.PrecioUnitario = Val(uc.txtPrecioUnitario.Text)

        ActualizarTotales()

        If uc.ItemVenta.EsNuevo Then

            uc.ItemVenta.EsNuevo = False
            AgregarItemVacio()

            Dim nuevoUC As UcItemVenta =
            CType(PanelItems.Controls(0), UcItemVenta)

            nuevoUC.EnfocarDescripcion()

        Else
            PasarAlSiguienteItem(uc)

        End If

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

                If i.Articulo Is Nothing Then Continue For

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
            Me.MaximizedBounds = Screen.FromHandle(Me.Handle).WorkingArea
            Me.WindowState = FormWindowState.Maximized

            mobj_TipoOperacion = mobj_AdminOperacion.ObtenerTipoOperacionPorCodiTO("VTAM")
            'mobj_OperacionOriginal = ClonarObjeto(mobj_Operacion)
            'mobj_ClienteOriginal = ClonarObjeto(mobj_Cliente)
            'mobj_ItemsOriginal = ClonarObjeto(mobj_Items)

            Me.ActualizarDatosOperacion()

            For Each item As ToolStripItem In ToolStrip1.Items
                item.Overflow = ToolStripItemOverflow.Never
            Next

            AgregarItemVacio()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub FrmVentas_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        Try

            'Dim operacionCambio = Not JsonConvert.SerializeObject(mobj_Operacion).Equals(JsonConvert.SerializeObject(mobj_OperacionOriginal))
            'Dim clienteCambio = Not JsonConvert.SerializeObject(mobj_Cliente).Equals(JsonConvert.SerializeObject(mobj_ClienteOriginal))
            'Dim itemsCambio = Not JsonConvert.SerializeObject(mobj_Items).Equals(JsonConvert.SerializeObject(mobj_ItemsOriginal))

            'If operacionCambio OrElse clienteCambio Then 'OrElse itemsCambio Then
            'Dim resultado = MessageBox.Show("Hay cambios sin guardar. ¿Desea guardar los cambios?", "Confirmar", MessageBoxButtons.YesNoCancel)

            'If resultado = DialogResult.Cancel Then
            'e.Cancel = True

            'ElseIf resultado = DialogResult.Yes Then
            'Me.GuardarCambios(Keys.Escape)

            'ElseIf resultado = DialogResult.No Then
            ' Salir sin guardar

            'End If
            'End If
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

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

    Private Sub ElimininarItemSeleccionadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuEditarElimininarItemSeleccionado.Click
        Me.EliminarItemSeleccionado()
    End Sub

    Private Sub AplicarDescuentoItemSeleccionadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuEditarAplicarDescuentoItemSeleccionado.Click

        Try
            'If DataGridView1.SelectedRows.Count = 1 Then
            'Dim indiceFilaSeleccionada As Integer = DataGridView1.SelectedRows(0).Index

            'If indiceFilaSeleccionada >= 0 AndAlso indiceFilaSeleccionada < mobj_Items.Count Then
            'Dim itemSeleccionado = mobj_Items(indiceFilaSeleccionada)

            Dim descuentoStr As String = InputBox("Ingrese el porcentaje de descuento a aplicar:", "Aplicar Descuento", "0")

                    If Not String.IsNullOrEmpty(descuentoStr) Then
                        Dim descuentoPorcentaje As Decimal
                        If Decimal.TryParse(descuentoStr, descuentoPorcentaje) Then
                            ' Asegurarse de que el descuento sea un valor válido (por ejemplo, entre 0 y 100)
                            If descuentoPorcentaje >= 0 AndAlso descuentoPorcentaje <= 100 Then
                        'itemSeleccionado.PorcentajeDescuento = descuentoPorcentaje
                        'Me.DataGridView1.Refresh()
                        ActualizarTotales()
                            Else
                                MessageBox.Show("Por favor, ingrese un porcentaje de descuento válido (entre 0 y 100).", "Error de Descuento", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                        Else
                            MessageBox.Show("Por favor, ingrese un valor numérico para el descuento.", "Error de Descuento", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    End If
                'ElseIf DataGridView1.SelectedRows.Count > 1 Then
                MessageBox.Show("Por favor, seleccione solo un ítem para aplicar el descuento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Else
            'MessageBox.Show("Por favor, seleccione un ítem para aplicar el descuento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'End If
            'End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub NuevoToolStripButton_Click(sender As Object, e As EventArgs) Handles NuevoToolStripButton.Click

        Dim nuevaVentanaVentas As New FrmVentas()
        nuevaVentanaVentas.Usuario = Me.Usuario
        nuevaVentanaVentas.Show()

        Me.Close()

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
            'Me.DataGridView1.DataSource = Nothing
            'Me.DataGridView1.DataSource = mobj_Items
            'Me.DataGridView1.ClearSelection()

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

            Dim AdminClientes As New N_AdminClientes
            Dim lc As List(Of Cliente) = AdminClientes.ListarClientes(str)
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
