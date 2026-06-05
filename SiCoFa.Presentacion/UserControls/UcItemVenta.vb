Imports SiCoFa.Entidades

Public Class UcItemVenta

    Public Property ItemVenta As ItemComprobante

    Public Event ItemChanged()
    Public Event OnEliminar(item As ItemComprobante)
    Public Event BuscarArticuloRequest(uc As UcItemVenta, texto As String)
    Public Event CantidadConfirmada(uc As UcItemVenta)
    Public Event PrecioConfirmado(uc As UcItemVenta)

    Public Sub Bind(item As ItemComprobante)

        Me.ItemVenta = item

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
        txtPorcentajeDescuento.Text = item.PorcentajeDescuento.ToString("0.00")
        txtImporteDescuento.Text = item.ImporteDescuento.ToString("0.00")
        txtImporteConDescuento.Text = item.ImporteConDescuento.ToString("0.00")

    End Sub

    Public Sub ModoBusqueda()


        txtDescripcion.ReadOnly = False

        txtCantidad.ReadOnly = True
        txtPrecioUnitario.ReadOnly = True

        txtCantidad.TabStop = False
        txtPrecioUnitario.TabStop = False

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

        If ItemVenta IsNot Nothing Then
            RaiseEvent OnEliminar(ItemVenta)
        End If

    End Sub

    Private Sub txtDescripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescripcion.KeyDown

        If e.KeyCode = Keys.Enter Then

            RaiseEvent BuscarArticuloRequest(Me, txtDescripcion.Text)

            e.SuppressKeyPress = True

        End If

    End Sub

    Private Sub txtCantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidad.KeyDown

        If e.KeyCode = Keys.Enter Then

            ItemVenta.Cantidad = Val(txtCantidad.Text)

            RaiseEvent CantidadConfirmada(Me)

            e.SuppressKeyPress = True

        End If

    End Sub

    Private Sub txtPrecioUnitario_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecioUnitario.KeyDown

        If e.KeyCode = Keys.Enter Then

            ItemVenta.PrecioUnitario = Val(txtPrecioUnitario.Text)

            txtPrecioUnitario.Text = ItemVenta.PrecioUnitario.ToString("0.00")

            RaiseEvent PrecioConfirmado(Me)

            e.SuppressKeyPress = True


        End If

    End Sub

End Class