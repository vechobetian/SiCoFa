Public Class FrmInicio
    Private Sub FacturacionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacturacionToolStripMenuItem.Click
        Using frmLogin As New FrmLoginUser
            If frmLogin.ShowDialog() = DialogResult.OK AndAlso frmLogin.Usuario IsNot Nothing Then
                Dim nuevaVentanaVentas As New FrmVentas()
                nuevaVentanaVentas.Usuario = frmLogin.Usuario
                nuevaVentanaVentas.Show()
            End If
        End Using
    End Sub
    Private Sub ArticulToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArticulToolStripMenuItem.Click
        FrmArticulos.Show()
    End Sub

End Class