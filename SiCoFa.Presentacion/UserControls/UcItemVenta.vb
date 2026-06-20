Imports SiCoFa.Entidades

Public Class UcItemVenta

    Public Property ItemVenta As ItemComprobante

    Public Event ItemEliminado(item As ItemComprobante)
    Public Event BusquedaArticuloSolicitada(uc As UcItemVenta, texto As String)
    Public Event CantidadConfirmada(uc As UcItemVenta)
    Public Event PrecioConfirmado(uc As UcItemVenta)
    Public Event ItemSeleccionado(uc As UcItemVenta)

    Protected Overridable Sub OnItemEliminado()

        If ItemVenta IsNot Nothing Then
            RaiseEvent ItemEliminado(ItemVenta)
        End If

    End Sub

    Protected Overridable Sub OnBusquedaArticuloSolicitada()

        Dim texto As String = txtDescripcion.Text.Trim()

        If texto = "" Then Exit Sub

        RaiseEvent BusquedaArticuloSolicitada(Me, txtDescripcion.Text)

    End Sub

    Protected Overridable Sub OnCantidadConfirmada()

        If ItemVenta IsNot Nothing Then
            ItemVenta.Cantidad = Val(txtCantidad.Text)
            RaiseEvent CantidadConfirmada(Me)
        End If

    End Sub

    Protected Overridable Sub OnPrecioConfirmado()

        If ItemVenta IsNot Nothing Then
            ItemVenta.PrecioUnitario = Val(txtPrecioUnitario.Text)
            txtPrecioUnitario.Text = ItemVenta.PrecioUnitario.ToString("0.00")
            RaiseEvent PrecioConfirmado(Me)
        End If

    End Sub

    Protected Overridable Sub OnItemSeleccionado()

        If ItemVenta IsNot Nothing Then

            RaiseEvent ItemSeleccionado(Me)

        End If

    End Sub

    Protected Overrides Sub OnControlAdded(e As ControlEventArgs)
        MyBase.OnControlAdded(e)

        AddFocusHandler(e.Control)
    End Sub

    Private Sub AddFocusHandler(ctrl As Control)

        AddHandler ctrl.GotFocus, AddressOf Control_GotFocus

        If ctrl.HasChildren Then
            For Each c As Control In ctrl.Controls
                AddFocusHandler(c)
            Next
        End If

    End Sub

    Private Sub Control_GotFocus(sender As Object, e As EventArgs)

        RaiseEvent ItemSeleccionado(Me)

    End Sub

    Public Sub Bind(item As ItemComprobante)

        Me.ItemVenta = item
        AplicarColor(ObtenerColorBase())

        txtCodBarra.Text = item.CodBarras
        txtDescripcion.Text = item.Descripcion

        If item.Articulo Is Nothing Then
            btnEliminarItem.Visible = False
            txtCantidad.Text = ""
            txtAlicIVA.Text = ""
            txtPrecioUnitario.Text = ""
            txtImporteSinDescuento.Text = ""
            txtPorcentajeDescuento.Text = ""
            txtImporteDescuento.Text = ""
            txtImporteConDescuento.Text = ""
            Exit Sub

        End If

        btnEliminarItem.Visible = True
        txtCantidad.Text = item.Cantidad.ToString()
        txtAlicIVA.Text = item.AlicIVA.ToString("0.00")
        txtPrecioUnitario.Text = item.PrecioUnitario.ToString("0.00")
        txtImporteSinDescuento.Text = item.ImporteSinDescuento.ToString("0.00")

        If item.PorcentajeOS > 0 Then
            txtPorcentajeDescuento.Text = item.PorcentajeOS.ToString("0.00")
        Else
            txtPorcentajeDescuento.Text = item.PorcentajeDescuento.ToString("0.00")
        End If

        If item.ImporteOS > 0 OrElse item.ImporteCS > 0 Then
            txtImporteDescuento.Text = (item.ImporteOS + item.ImporteCS).ToString("0.00")
        Else
            txtImporteDescuento.Text = item.ImporteDescuento.ToString("0.00")
        End If

        txtImporteConDescuento.Text = item.ImporteConDescuento.ToString("0.00")

    End Sub

    Private Shared ReadOnly ColoresReceta As Color() =
    {
        Color.Khaki,
        Color.Honeydew,
        Color.AliceBlue,
        Color.MistyRose,
        Color.Lavender,
        Color.LemonChiffon
    }

    Private Function ObtenerColorReceta(idReceta As Long) As Color

        Return ColoresReceta((idReceta - 1) Mod ColoresReceta.Length)

    End Function

    Private Function ObtenerColorBase() As Color

        If ItemVenta IsNot Nothing AndAlso ItemVenta.IdReceta > 0 Then

            Return ObtenerColorReceta(ItemVenta.IdReceta)

        End If

        Return Color.White

    End Function

    Private Sub AplicarColor(color As Color)

        Me.BackColor = color

        btnEliminarItem.BackColor = color
        txtCodBarra.BackColor = color
        txtDescripcion.BackColor = color
        txtCantidad.BackColor = color
        txtAlicIVA.BackColor = color
        txtPrecioUnitario.BackColor = color
        txtImporteSinDescuento.BackColor = color
        txtPorcentajeDescuento.BackColor = color
        txtImporteDescuento.BackColor = color
        txtImporteConDescuento.BackColor = color

    End Sub

    Public Sub Seleccionar()

        If ObtenerColorBase() <> Color.White Then Exit Sub

        AplicarColor(Color.LightBlue)

    End Sub

    Public Sub Deseleccionar()

        AplicarColor(ObtenerColorBase())

    End Sub

    Private Sub UcItemVenta_Click(sender As Object, e As EventArgs) Handles Me.Click

        OnItemSeleccionado()

    End Sub

    Public Sub ModoBusqueda()

        txtDescripcion.ReadOnly = False

        txtCantidad.ReadOnly = True
        txtPrecioUnitario.ReadOnly = True

        txtCantidad.TabStop = False
        txtPrecioUnitario.TabStop = False

        txtCantidad.BackColor = ObtenerColorBase()
        txtPrecioUnitario.BackColor = ObtenerColorBase()

    End Sub

    Public Sub ModoItemCargado(permiteEditarPrecio As Boolean)

        txtDescripcion.ReadOnly = True

        txtCantidad.ReadOnly = False
        txtCantidad.TabStop = True

        txtPrecioUnitario.ReadOnly = Not permiteEditarPrecio
        txtPrecioUnitario.TabStop = permiteEditarPrecio

    End Sub

    Public Sub EnfocarDescripcion()

        txtDescripcion.Focus()
        txtDescripcion.SelectAll()

    End Sub

    Public Sub EnfocarCantidad()

        txtCantidad.Focus()
        txtCantidad.SelectAll()

    End Sub

    Public Sub EnfocarPrecio()

        txtPrecioUnitario.Focus()
        txtPrecioUnitario.SelectAll()

    End Sub

    Public Sub HabilitarCantidad()

        txtCantidad.ReadOnly = False
        txtCantidad.TabStop = True

    End Sub

    Public Sub HabilitarPrecio()

        txtPrecioUnitario.ReadOnly = False
        txtPrecioUnitario.TabStop = True

    End Sub

    Private Sub btnEliminarItem_Click(sender As Object, e As EventArgs) Handles btnEliminarItem.Click

        OnItemEliminado()

    End Sub

    Private Sub txtDescripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescripcion.KeyDown

        If e.KeyCode = Keys.Enter Then

            OnBusquedaArticuloSolicitada()
            e.SuppressKeyPress = True

        End If

    End Sub

    Private Sub txtCantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidad.KeyDown

        If e.KeyCode = Keys.Enter Then

            OnCantidadConfirmada()
            e.SuppressKeyPress = True

        End If

    End Sub

    Private Sub txtPrecioUnitario_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecioUnitario.KeyDown

        If e.KeyCode = Keys.Enter Then

            OnPrecioConfirmado()
            e.SuppressKeyPress = True

        End If

    End Sub

End Class