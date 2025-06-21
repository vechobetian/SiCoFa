Imports System.IO
Imports SiCoFa.Entidades
Public Class FrmInicio

    Private Sub GuardarItemYSubitems(item As ToolStripMenuItem, writer As StreamWriter, nivel As Integer)
        Dim indentacion As String = New String(" "c, nivel * 2)
        writer.WriteLine($"{indentacion}Name: {item.Name}, Text: {item.Text}")

        For Each subItem As ToolStripItem In item.DropDownItems
            If TypeOf subItem Is ToolStripMenuItem Then
                GuardarItemYSubitems(DirectCast(subItem, ToolStripMenuItem), writer, nivel + 1)
            End If
        Next
    End Sub
    Private Function ValidarUsuario() As Usuario
        Try

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

            Return User

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
            Return Nothing

        End Try

    End Function

    Private Sub mnuOperacionesFacturacion_Click(sender As Object, e As EventArgs) Handles mnuOperacionesFacturacion.Click

        Dim nuevaVentanaVentas As New FrmVentas()
        nuevaVentanaVentas.Usuario = Me.ValidarUsuario
        nuevaVentanaVentas.Show()

    End Sub

    Private Sub mnuCajaMovimientos_Click(sender As Object, e As EventArgs) Handles mnuCajaMovimientos.Click

        FrmCajas.Usuario = Me.ValidarUsuario
        FrmCajas.Show()

    End Sub

    Private Sub mnuEdicionArticulos_Click(sender As Object, e As EventArgs) Handles mnuEdicionArticulos.Click
        FrmArticulos.Show()
    End Sub

    Private Sub mnuEdicionClientes_Click(sender As Object, e As EventArgs) Handles mnuEdicionClientes.Click
        FrmPanelClientes.Show()
    End Sub

End Class