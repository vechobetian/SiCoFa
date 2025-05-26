Imports SiCoFa.Negocio
Imports SiCoFa.Entidades
Public Class FrmInicio
    Private Sub FacturacionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacturacionToolStripMenuItem.Click

        Dim objUsuario As Usuario = Nothing
        FrmLoginUser.ShowDialog()

        If FrmLoginUser.DialogResult = DialogResult.OK Then
            objUsuario = FrmLoginUser.Usuario
            FrmLoginUser.Close()
            FrmVentas.Usuario = objUsuario
            FrmVentas.Show()
        End If

    End Sub

    Private Sub ArticulToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArticulToolStripMenuItem.Click
        FrmArticulos.Show()
    End Sub
End Class