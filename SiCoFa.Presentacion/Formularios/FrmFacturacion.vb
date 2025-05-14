Public Class FrmFacturacion
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
    Private Sub AjustarAnchoColumnas()
        DataGridView1.Columns(0).FillWeight = 50  ' Producto
        DataGridView1.Columns(1).FillWeight = 5   ' Cant
        DataGridView1.Columns(2).FillWeight = 5   ' U
        DataGridView1.Columns(3).FillWeight = 10  ' Precio
        DataGridView1.Columns(4).FillWeight = 15  ' Subtotal
        DataGridView1.Columns(5).FillWeight = 5   ' Descuento
        DataGridView1.Columns(6).FillWeight = 10  ' Total
        DataGridView1.Columns(7).FillWeight = 5   ' Stock
    End Sub
    Private Sub FrmFacturacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Evita que los controles se muevan al área de desbordamiento
        For Each item As ToolStripItem In ToolStrip1.Items
            item.Overflow = ToolStripItemOverflow.Never
        Next
    End Sub
    Private Sub FrmFacturacion_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.AjustarAnchoColumnas()
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
        Me.AjustarAnchoColumnas()
        Me.AjustarAnchoToolStripTextBox()
    End Sub

End Class
