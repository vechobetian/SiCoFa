Imports SiCoFa.Entidades
Public Class FrmInicio
    Private Sub FacturacionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacturacionToolStripMenuItem.Click
        Dim User As Usuario = Nothing

        If g_Usuario Is Nothing Then
            Using frmLogin As New FrmLoginUser
                If frmLogin.ShowDialog() = DialogResult.OK AndAlso frmLogin.Usuario IsNot Nothing Then
                    User = frmLogin.Usuario
                End If
            End Using

        Else
            User = g_Usuario

        End If

        If User Is Nothing Then
            Exit Sub
        End If

        Dim nuevaVentanaVentas As New FrmVentas()
        nuevaVentanaVentas.Usuario = User
        nuevaVentanaVentas.Show()

    End Sub

End Class