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
            mobj_AdminOperacion.ActualizarOperacionCL(mobj_Operacion.IdOperacion, mobj_Cliente.Id)
        End Set
    End Property

    Private mobj_AdminOperacion As New N_AdminOperaciones
    Private mobj_Operacion As Operacion
    Private mobj_TipoOperacion As TipoOperacion
    Private mobj_Cliente As Cliente
    Private mobj_Recetas As New List(Of Receta)
    Private mobj_Items As New BindingList(Of ItemComprobante)
    Private mobj_ItemSeleccionado As UcItemVenta
    Private mint_CantidadItems As Integer = 0
    Private mdec_ImporteCosto As Decimal = 0
    Private mdec_ImporteSinDescuentos As Decimal = 0
    Private mdec_ImporteDescuentos As Decimal = 0
    Private mdec_ImporteConDescuentos As Decimal = 0
    Private mdec_PorcentaDescuentos As Decimal = 0
    Private mdec_ImporteExento As Decimal = 0
    Private mdec_ImporteGravado1 As Decimal = 0
    Private mdec_ImporteGravado2 As Decimal = 0
    Private mdec_ImporteOS As Decimal = 0
    Private mdec_ImporteCS As Decimal = 0
    Private mint_NextIdReceta = 0

    Private Function ObtenerNuevoIdReceta() As Long

        mint_NextIdReceta += 1

        Return mint_NextIdReceta

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

    Private Sub GuardarCambios(ByVal argTecla As Keys)
        Try

            If Me.mdec_ImporteSinDescuentos = 0 Then
                Exit Sub
            End If

            If mobj_Cliente Is Nothing Then
                Dim AdminClientes As New N_AdminClientes
                mobj_Cliente = AdminClientes.ObtenerClientePorId(1)
            End If

            mobj_Operacion = New Operacion(0, Date.MinValue, Date.MinValue, g_ParametrosTerminal.Empresa, g_ParametrosTerminal.IdPc, 0, Me.Usuario, mobj_TipoOperacion, "", "", "")
            If argTecla = Keys.F9 OrElse argTecla = Keys.F10 Then

                Using FPagos As New FrmPagos
                    Dim AdminComprobantes As New N_AdminComprobantes
                    With FPagos
                        .FrmOrigen = Me
                        .Operacion = mobj_Operacion
                        .Cliente = mobj_Cliente
                        .Recetas = mobj_Recetas

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
                        .ImporteExento = mdec_ImporteExento
                        .ImporteOS = mdec_ImporteOS
                        .ImporteCS = mdec_ImporteCS
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
                    'i.IdItem = AdminItems.InsertarItemComprobanteVenta(argIdOperacion, i)

                Else
                    Dim Actualizado As Boolean = AdminItems.ActualizarItemComprobante(i.IdItem, i.Cantidad, i.Articulo.PrecioCosto, i.PrecioUnitario, i.DescuentoUnitario)

                End If
            Next

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try
    End Sub

    Private Sub RenderItemsUC()

        PanelItems.SuspendLayout()

        Try

            PanelItems.Controls.Clear()

            For i As Integer = mobj_Items.Count - 1 To 0 Step -1

                Dim item As ItemComprobante = mobj_Items(i)

                Dim uc As New UcItemVenta()

                uc.Bind(item)

                If item.Articulo Is Nothing Then
                    uc.ModoBusqueda()
                Else
                    uc.ModoItemCargado(item.Articulo.Fraccionable, item.Articulo.Seccion.EstablecerPrecio)
                End If

                uc.Dock = DockStyle.Top

                AddHandler uc.ItemEliminado, AddressOf EliminarItem
                AddHandler uc.BusquedaArticuloSolicitada, AddressOf BuscarArticuloDesdeUC
                AddHandler uc.CantidadConfirmada, AddressOf CantidadConfirmada
                AddHandler uc.PrecioConfirmado, AddressOf PrecioConfirmado
                AddHandler uc.ItemSeleccionado, AddressOf SeleccionarItem

                PanelItems.Controls.Add(uc)

            Next

        Finally

            PanelItems.ResumeLayout()

        End Try

    End Sub

    Private Sub MoverItemSeleccionado(delta As Integer)

        If PanelItems.Controls.Count = 0 Then Exit Sub

        If mobj_ItemSeleccionado Is Nothing Then
            Dim primero As UcItemVenta = TryCast(GetItemsOrdenados().FirstOrDefault(), UcItemVenta)
            If primero IsNot Nothing Then SeleccionarItem(primero)
            Exit Sub
        End If

        Dim lista As List(Of UcItemVenta) = GetItemsOrdenados()

        Dim index As Integer = lista.IndexOf(mobj_ItemSeleccionado)
        Dim nuevoIndex As Integer = index + delta

        If nuevoIndex < 0 Then nuevoIndex = 0
        If nuevoIndex >= lista.Count Then nuevoIndex = lista.Count - 1

        Dim nuevoUC As UcItemVenta = lista(nuevoIndex)

        SeleccionarItem(nuevoUC)
        nuevoUC.EnfocarDescripcion()

    End Sub

    Private Function GetItemsOrdenados() As List(Of UcItemVenta)

        Return PanelItems.Controls.OfType(Of UcItemVenta)().Reverse().ToList()

    End Function

    Private Sub ActualizarDatosReceta()

        Dim receta As Receta = Nothing

        If mobj_ItemSeleccionado IsNot Nothing Then

            Dim item As ItemComprobante = mobj_ItemSeleccionado.ItemVenta

            If item IsNot Nothing AndAlso item.Receta IsNot Nothing Then

                receta = mobj_Recetas.FirstOrDefault(Function(r) r.IdReceta = item.Receta.IdReceta)

            End If

        End If

        UcReceta1.Receta = receta

        If receta IsNot Nothing Then
            UcReceta1.AplicarColor(mobj_ItemSeleccionado.BackColor)
        End If

    End Sub

    Private Sub SeleccionarItem(uc As UcItemVenta)

        If mobj_ItemSeleccionado Is uc Then Exit Sub

        If mobj_ItemSeleccionado IsNot Nothing Then
            mobj_ItemSeleccionado.Deseleccionar()
        End If

        mobj_ItemSeleccionado = uc

        If mobj_ItemSeleccionado IsNot Nothing Then
            mobj_ItemSeleccionado.Seleccionar()
        End If

        ActualizarDatosReceta()

    End Sub

    Private Function AgregarItemUC(item As ItemComprobante) As UcItemVenta

        Dim uc As New UcItemVenta()

        uc.Bind(item)
        uc.Dock = DockStyle.Top

        AddHandler uc.ItemEliminado, AddressOf EliminarItem
        AddHandler uc.BusquedaArticuloSolicitada, AddressOf BuscarArticuloDesdeUC
        AddHandler uc.CantidadConfirmada, AddressOf CantidadConfirmada
        AddHandler uc.PrecioConfirmado, AddressOf PrecioConfirmado
        AddHandler uc.ItemSeleccionado, AddressOf SeleccionarItem

        PanelItems.Controls.Add(uc)
        PanelItems.Controls.SetChildIndex(uc, 0)

        Return uc

    End Function

    Private Function AgregarItemVacio(Optional argReceta As Receta = Nothing) As UcItemVenta

        Dim itemNuevo As New ItemComprobante()
        itemNuevo.EsNuevo = True
        itemNuevo.Receta = argReceta

        mobj_Items.Add(itemNuevo)

        Dim uc As UcItemVenta = AgregarItemUC(itemNuevo)

        Return uc

    End Function

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

        If item.Receta IsNot Nothing Then

            item.Articulo = Nothing
            item.CodBarras = ""
            item.Descripcion = ""
            item.Cantidad = 0
            item.AlicIVA = 0
            item.PorcentajeDescuento = 0
            item.EsNuevo = True
            RenderItemsUC()

        Else

            mobj_Items.Remove(item)

            ' Eliminar filas vacías sobrantes
            For i As Integer = mobj_Items.Count - 1 To 0 Step -1

                If mobj_Items(i).Articulo Is Nothing AndAlso mobj_Items(i).Receta Is Nothing Then
                    mobj_Items.RemoveAt(i)
                End If

            Next

            ' Agregar una única fila vacía
            AgregarItemVacio()

            RenderItemsUC()
        End If

        ActualizarTotales()

    End Sub

    Private Sub BuscarArticuloDesdeUC(uc As UcItemVenta, texto As String)

        If String.IsNullOrWhiteSpace(texto) Then Exit Sub
        BuscarArticulo(uc, texto)

    End Sub

    Private Function ObtenerReceta(idReceta As Long) As Receta

        Return mobj_Recetas.FirstOrDefault(Function(r) r.IdReceta = idReceta)

    End Function

    Private Sub BuscarArticulo(uc As UcItemVenta, ByVal argTextoBuscado As String)

        Try

            If argTextoBuscado = "*" OrElse argTextoBuscado = "/" Then

                MsgBox("Artículo no encontrado", vbInformation, "SiCoFa")
                Exit Sub

            End If

            Dim AdminArticulos As New N_AdminArticulos
            Dim articulo As Articulo = Nothing
            Dim listaArticulos As New List(Of Articulo)

            Select Case Strings.Left(argTextoBuscado, 1)

                Case "*"

                    articulo = AdminArticulos.ArticuloGenericoExento(argTextoBuscado)

                    If articulo IsNot Nothing Then
                        listaArticulos.Add(articulo)
                    End If

                Case "/"

                    articulo = AdminArticulos.ArticuloGenericoGravado(argTextoBuscado)

                    If articulo IsNot Nothing Then
                        listaArticulos.Add(articulo)
                    End If

                Case Else

                    listaArticulos = AdminArticulos.ListarArticulos(argTextoBuscado)

            End Select

            If listaArticulos Is Nothing OrElse listaArticulos.Count = 0 Then

                MsgBox("Artículo no encontrado", vbInformation, "SiCoFa")
                Exit Sub

            End If

            Select Case listaArticulos.Count

                Case 1

                    articulo = listaArticulos.First()

                Case Else

                    Using f As New FrmBuscaArticulos

                        f.Articulos = listaArticulos

                        If f.ShowDialog() = DialogResult.OK Then
                            articulo = f.ArticuloSeleccionado
                        End If

                    End Using

            End Select

            If articulo Is Nothing Then

                uc.txtDescripcion.Clear()
                Exit Sub

            End If

            If uc.ItemVenta.Receta IsNot Nothing Then

                Dim receta As Receta = ObtenerReceta(uc.ItemVenta.Receta.IdReceta)

                If receta Is Nothing Then

                    MsgBox("No se encontró la receta asociada.", vbCritical, "SiCoFa")
                    Exit Sub

                End If

                Dim AdminRecetas As New N_AdminRecetas

                AdminRecetas.ObtenerCobertura(articulo, uc.ItemVenta)

                If uc.ItemVenta.DescuentoOS = 0 AndAlso uc.ItemVenta.DescuentoCS = 0 AndAlso uc.ItemVenta.Receta.Plan.Proceso <> 0 Then

                    MsgBox(articulo.Nombre & " no tiene descuento", vbInformation, "SiCoFa")

                    uc.txtDescripcion.Clear()

                    Exit Sub

                End If

            End If

            Dim item As ItemComprobante = uc.ItemVenta

            item.Articulo = articulo
            item.Cantidad = 1

            uc.Bind(item)

            uc.ModoItemCargado(articulo.Fraccionable, articulo.Seccion.EstablecerPrecio)

            If uc.ItemVenta.Articulo.Fraccionable AndAlso uc.ItemVenta.Receta Is Nothing Then
                uc.HabilitarFraccionado()
                uc.EnfocarFraccionado()

            Else
                uc.HabilitarCantidad()
                uc.EnfocarCantidad()

            End If

            ActualizarTotales()

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
        uc.Bind(uc.ItemVenta)
        ActualizarTotales()

        ' 🔥 SI ES NUEVO (flujo de carga)
        If uc.ItemVenta.EsNuevo And uc.ItemVenta.Receta Is Nothing Then

            If uc.ItemVenta.Articulo.Seccion.EstablecerPrecio Then

                uc.HabilitarPrecio()
                uc.EnfocarPrecio()
                Exit Sub

            Else

                uc.ItemVenta.EsNuevo = False
                AgregarItemVacio()
                Dim nuevoUC As UcItemVenta = CType(PanelItems.Controls(0), UcItemVenta)

            End If

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

            Dim nuevoUC As UcItemVenta = CType(PanelItems.Controls(0), UcItemVenta)

            nuevoUC.EnfocarDescripcion()

        Else
            PasarAlSiguienteItem(uc)

        End If

    End Sub

    Private Sub CalcularTotalesGlobales()

        Try
            mint_CantidadItems = 0
            mdec_ImporteCosto = 0
            mdec_ImporteSinDescuentos = 0
            mdec_ImporteDescuentos = 0
            mdec_ImporteConDescuentos = 0
            mdec_PorcentaDescuentos = 0
            mdec_ImporteExento = 0
            mdec_ImporteGravado1 = 0
            mdec_ImporteGravado2 = 0
            mdec_ImporteOS = 0
            mdec_ImporteCS = 0

            For Each i As ItemComprobante In Me.mobj_Items

                If i.Articulo Is Nothing Then Continue For

                mint_CantidadItems += 1
                mdec_ImporteCosto += (i.Articulo.PrecioCosto * i.Cantidad)
                mdec_ImporteSinDescuentos += i.ImporteSinDescuento
                mdec_ImporteDescuentos += i.ImporteDescuento
                mdec_ImporteOS += i.ImporteOS
                mdec_ImporteCS += i.ImporteCS
                mdec_ImporteConDescuentos += i.ImporteConDescuento

                Select Case i.AlicIVA
                    Case 0

                        If i.Receta Is Nothing Then
                            mdec_ImporteExento += i.ImporteConDescuento
                        Else
                            mdec_ImporteExento += i.ImporteSinDescuento
                        End If

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
            Me.lblImporteSinDescuentos.Text = mdec_ImporteSinDescuentos.ToString("$ #,##0.00")
            'Me.lblPorcentajeAplicado.Text = "- Porcentaje Descuentos: " & Format(mdec_PorcentaDescuentos, "#,##0.00") & "%"
            Me.lblDescuentos.Text = "Descuentos (" & Format(mdec_PorcentaDescuentos, "#,##0.00") & "%)"
            Me.lblImporteDescuentos.Text = mdec_ImporteDescuentos.ToString("$ #,##0.00")
            Me.lblImporteOS.Text = mdec_ImporteOS.ToString("$ #,##0.00")
            Me.lblImporteCS.Text = mdec_ImporteCS.ToString("$ #,##0.00")
            Me.lblImporteConDescuentos.Text = mdec_ImporteConDescuentos.ToString("$ #,##0.00")

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub CalcularTotalesPorReceta()

        ' Reset
        For Each r As Receta In mobj_Recetas
            r.ImporteTotal = 0
            r.ImporteOS = 0
            r.ImporteCS = 0
            r.ImporteAf = 0
        Next

        Dim dictRecetas = mobj_Recetas.ToDictionary(Function(x) x.IdReceta)

        For Each i As ItemComprobante In mobj_Items

            If i.Articulo Is Nothing Then Continue For
            If i.Receta Is Nothing Then Continue For

            Dim r As Receta = Nothing

            If dictRecetas.TryGetValue(i.Receta.IdReceta, r) Then

                r.ImporteTotal += i.ImporteSinDescuento
                r.ImporteOS += i.ImporteOS
                r.ImporteCS += i.ImporteCS
                r.ImporteAf += i.ImporteConDescuento

            End If

        Next

    End Sub

    Private Sub ActualizarTotales()
        Me.CalcularTotalesGlobales()
        Me.CalcularTotalesPorReceta()
    End Sub

    Private Sub ActualizarDatosOperacion()
        Dim NombreCliente As String
        If mobj_Cliente Is Nothing Then
            NombreCliente = "CONSUMIDOR FINAL S/IDENTIFICAR"
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

            Me.ActualizarDatosOperacion()

            For Each item As ToolStripItem In ToolStrip1.Items
                item.Overflow = ToolStripItemOverflow.Never
            Next

            AgregarItemVacio()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub FrmVentas_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode

            Case Keys.Down, Keys.Right
                MoverItemSeleccionado(1)
                e.Handled = True

            Case Keys.Up, Keys.Left
                MoverItemSeleccionado(-1)
                e.Handled = True

        End Select

    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData
            Case Keys.F10
                Me.GuardarCambios(Keys.F10)
            Case Keys.F9
                Me.GuardarCambios(Keys.F10)
            Case Keys.F8

            Case Else
                Return MyBase.ProcessCmdKey(msg, keyData)
        End Select
        Return True ' Asegúrate de devolver True para que la tecla se procese correctamente
    End Function

    Private Sub ElimininarItemSeleccionadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuEditarElimininarItemSeleccionado.Click

        If mobj_ItemSeleccionado Is Nothing Then

            Exit Sub

        End If

        Me.EliminarItem(mobj_ItemSeleccionado.ItemVenta)

    End Sub

    Private Sub AplicarDescuentoItemSeleccionadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuEditarAplicarDescuentoItemSeleccionado.Click

        Try

            If mobj_ItemSeleccionado Is Nothing Then

                MessageBox.Show("Por favor, seleccione un ítem.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub

            End If

            Dim descuentoStr As String =
            InputBox("Ingrese el porcentaje de descuento a aplicar:", "Aplicar Descuento", "0")

            If String.IsNullOrWhiteSpace(descuentoStr) Then Exit Sub

            Dim descuentoPorcentaje As Decimal

            If Not Decimal.TryParse(descuentoStr, descuentoPorcentaje) Then

                MessageBox.Show("Por favor, ingrese un valor numérico para el descuento.", "Error de Descuento", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub

            End If

            If descuentoPorcentaje < 0 OrElse descuentoPorcentaje > 100 Then

                MessageBox.Show("Por favor, ingrese un porcentaje de descuento válido (entre 0 y 100).", "Error de Descuento", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub

            End If

            mobj_ItemSeleccionado.ItemVenta.PorcentajeDescuento = descuentoPorcentaje

            ActualizarTotales()
            RenderItemsUC()

        Catch ex As Exception

            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

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

    Private Sub PegarToolStripButton_Click(sender As Object, e As EventArgs)

        Dim AdminOS As New N_AdminObraSociales
        Dim PlanOS As PlanOS = AdminOS.ObtenerPlanOSPorId(1101)

        Dim receta As New Receta(PlanOS)

        receta.IdReceta = ObtenerNuevoIdReceta()

        'Dim c As New CredencialOS("14021682880700", "")
        'receta.Credencial = c
        receta.NumReceta = "8263155276740"
        Dim adminRecetas As New N_AdminRecetas
        'adminRecetas.ConsultaRecetasBeneficiario(c, receta.Plan.OS.PValidacion)
        adminRecetas.ConsultaRecetaElectronica(receta)
        CargarRecetaEnPantalla(receta)

    End Sub

    Private Sub CargarRecetaEnPantalla(receta As Receta)

        Dim adminArticulos As New N_AdminArticulos

        If receta Is Nothing Then Exit Sub

        ' Buscar el item libre vacío
        Dim indice As Integer = mobj_Items.ToList().FindIndex(Function(i) i.Receta Is Nothing AndAlso i.Articulo Is Nothing)

        If indice = -1 Then
            indice = mobj_Items.Count
        Else
            mobj_Items.RemoveAt(indice)
        End If

        ' Guardar referencia al primer item de la receta
        Dim primerItemReceta As ItemComprobante = Nothing

        mobj_Recetas.Add(receta)

        If receta.Items IsNot Nothing Then

            For Each i As ItemComprobante In receta.Items
                Dim a As Articulo = adminArticulos.ObtenerArticuloPorId(i.IdArticulo)
                With i
                    i.Articulo = a
                    i.EsNuevo = True
                    i.Receta = receta
                End With

                If primerItemReceta Is Nothing Then
                    primerItemReceta = i
                End If

                mobj_Items.Insert(indice, i)
                indice += 1

            Next

        Else
            For i As Integer = 1 To receta.Plan.LineasRta

                Dim item As New ItemComprobante()

                item.EsNuevo = True
                item.Receta = receta

                If primerItemReceta Is Nothing Then
                    primerItemReceta = item
                End If

                mobj_Items.Insert(indice, item)

                indice += 1

            Next
        End If

        ' Nuevo item libre al final
        Dim itemLibre As New ItemComprobante()

        itemLibre.EsNuevo = True
        itemLibre.Receta = Nothing

        mobj_Items.Add(itemLibre)

        ActualizarTotales()

        RenderItemsUC()

        ' Enfocar el primer item de la receta insertada
        If primerItemReceta IsNot Nothing Then

            For Each ctrl As Control In PanelItems.Controls

                If TypeOf ctrl Is UcItemVenta Then

                    Dim uc As UcItemVenta = DirectCast(ctrl, UcItemVenta)

                    If uc.ItemVenta Is primerItemReceta Then

                        uc.EnfocarDescripcion()
                        Exit For

                    End If

                End If

            Next

        End If

    End Sub

    Private Sub EliminarRecetaEnPantalla(receta As Receta)

        If receta Is Nothing Then Exit Sub

        ' Eliminar la receta de la colección
        mobj_Recetas.Remove(receta)

        ' Eliminar todos los items asociados a la receta
        For i As Integer = mobj_Items.Count - 1 To 0 Step -1

            Dim item = mobj_Items(i)

            If item.Receta IsNot Nothing AndAlso item.Receta.IdReceta = receta.IdReceta Then
                mobj_Items.RemoveAt(i)
            End If

        Next

        ' Debe existir un único item libre
        For i As Integer = mobj_Items.Count - 1 To 0 Step -1

            Dim item = mobj_Items(i)

            If item.Receta Is Nothing AndAlso item.Articulo Is Nothing Then
                mobj_Items.RemoveAt(i)
            End If

        Next

        Dim itemLibre As New ItemComprobante()

        itemLibre.EsNuevo = True

        mobj_Items.Add(itemLibre)

        ' Limpiar la receta mostrada si era la seleccionada
        If UcReceta1.Receta IsNot Nothing AndAlso UcReceta1.Receta.IdReceta = receta.IdReceta Then
            UcReceta1.Receta = Nothing
        End If

        mobj_ItemSeleccionado = Nothing

        ActualizarTotales()

        RenderItemsUC()

    End Sub

    Private Sub AyudaToolStripButton_Click(sender As Object, e As EventArgs) Handles AyudaToolStripButton.Click

        Dim receta As Receta = Nothing

        If mobj_ItemSeleccionado IsNot Nothing Then

            Dim item As ItemComprobante = mobj_ItemSeleccionado.ItemVenta

            If item IsNot Nothing AndAlso item.Receta IsNot Nothing Then

                receta = ObtenerReceta(item.Receta.IdReceta)

            End If

        End If

        If receta IsNot Nothing Then
            Dim adminRecetas As New N_AdminRecetas
            adminRecetas.SolicitarAutorizacion(receta)
        End If

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click

        Dim receta As Receta = Nothing

        If mobj_ItemSeleccionado IsNot Nothing Then

            Dim item As ItemComprobante = mobj_ItemSeleccionado.ItemVenta

            If item IsNot Nothing AndAlso item.Receta IsNot Nothing Then

                receta = ObtenerReceta(item.Receta.IdReceta)

            End If

        End If

        If receta IsNot Nothing Then
            Dim adminRecetas As New N_AdminRecetas
            adminRecetas.SolicitarAutorizacion(receta)
        End If

    End Sub

    Private Sub btnNuevaReceta_Click(sender As Object, e As EventArgs) Handles btnNuevaReceta.Click
        Try
            Dim PlanOS As PlanOS = Nothing

            Using frm As New FrmSelectorPlanesOS

                If frm.ShowDialog() <> DialogResult.OK Then
                    Exit Sub
                End If

                PlanOS = frm.PlanSeleccionado

            End Using

            Dim receta As New Receta(PlanOS)

            receta.IdReceta = ObtenerNuevoIdReceta()

            If receta.Plan.OS.PValidacion.RecetaElectronica Then
                Using frm As New FrmDatosReceta(receta)

                    If frm.ShowDialog() = DialogResult.OK Then
                        ' receta ya fue modificada
                    End If

                End Using
            End If

            Me.CargarRecetaEnPantalla(receta)

        Catch ex As Exception

            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try
    End Sub

    Private Sub btnDatosReceta_Click(sender As Object, e As EventArgs) Handles btnDatosReceta.Click
        Try
            Dim receta As Receta = Nothing

            If mobj_ItemSeleccionado IsNot Nothing Then

                Dim item As ItemComprobante = mobj_ItemSeleccionado.ItemVenta

                If item IsNot Nothing AndAlso item.Receta IsNot Nothing Then

                    receta = ObtenerReceta(item.Receta.IdReceta)

                End If

            End If

            If receta IsNot Nothing Then

                If receta.Plan.DatosRequeridos Is Nothing Then
                    MessageBox.Show("Datos Requeridos no establecidos", "SiCoFa", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                Using frm As New FrmDatosReceta(receta)

                    If frm.ShowDialog() = DialogResult.OK Then

                    End If

                End Using

            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try
    End Sub

    Private Sub mnuElinarReceta_Click(sender As Object, e As EventArgs) Handles mnuElinarReceta.Click

        Try

            If mobj_ItemSeleccionado Is Nothing Then

                Exit Sub

            End If

            Dim receta As Receta = mobj_ItemSeleccionado.ItemVenta.Receta


        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try
    End Sub

    Private Sub btnEliminarReceta_Click(sender As Object, e As EventArgs) Handles btnEliminarReceta.Click

    End Sub

End Class
