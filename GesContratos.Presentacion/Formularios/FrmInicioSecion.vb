Imports SiCoFa.Negocio
Imports SiCoFa.Entidades
Public Class FrmInicioSecion
    Private Function IniciarSecion() As Secion
        Dim obj_N_AdminUsuario As New cls_N_AdminUsuario
        Dim us As Usuario
        Dim s As Secion

        Try
            us = obj_N_AdminUsuario.ObtenerUsuarioPorId(CLng(Me.IdUsuario.Text), Me.Password.Text)

            If us Is Nothing Then
                Return Nothing
            Else
                s = New Secion(us)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try
        Return s

    End Function
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click

        Dim s As Secion = IniciarSecion()

        If s Is Nothing Then
            MsgBox("Usuario y/o Contraseña incorrectos",, "SiCoFa")
            Me.IdUsuario.Text = ""
            Me.Password.Text = ""
            Me.IdUsuario.Select()
            Exit Sub
        End If

        FrmMDI.Secion = s
        Me.Close()
        Me.Dispose()

    End Sub
    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
        Me.Dispose()
    End Sub


End Class
