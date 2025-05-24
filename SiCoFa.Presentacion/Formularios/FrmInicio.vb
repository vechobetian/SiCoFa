Public Class FrmInicio
    Private Sub FacturacionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacturacionToolStripMenuItem.Click

        With FrmLoginUser
            .ShowDialog()
            If .DialogResult = DialogResult.OK Then
                FrmVentas.Usuario = .Usuario
                FrmVentas.Show()
                .Close()
            End If
        End With

    End Sub

    Private Sub ArticulToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArticulToolStripMenuItem.Click
        FrmArticulos.Show()
    End Sub
End Class