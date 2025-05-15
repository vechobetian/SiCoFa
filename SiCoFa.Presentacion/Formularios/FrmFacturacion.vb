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
    Private Sub AjustarAnchoColumnasProporcional()
        If DataGridView1.ColumnCount = 10 Then
            Dim totalAncho As Integer = DataGridView1.Width
            ' Define las proporciones para las 9 columnas (la primera es invisible y tiene ancho 0)
            Dim proporciones As Double() = {0.0R, 0.08R, 0.5R, 0.05R, 0.05R, 0.08R, 0.08R, 0.05R, 0.08R, 0.08R}
            ' Suma de las proporciones (excluyendo la primera): 0.1 + 0.15 + 0.1 + 0.2 + 0.05 + 0.15 + 0.1 + 0.05 = 0.9 (ajusta según necesites)

            For i As Integer = 0 To 9 ' Itera a través de las 9 columnas
                DataGridView1.Columns(i).Width = CInt(totalAncho * proporciones(i))
            Next
        Else
            MessageBox.Show("El DataGridView no tiene 9 columnas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub FrmFacturacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Evita que los controles se muevan al área de desbordamiento
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

End Class
