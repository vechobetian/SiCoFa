Imports SiCoFa.Negocio
Imports SiCoFa.Entidades
Public Class FrmInicioSecion
    ' Sobreescribimos el método ProcessCmdKey para capturar la tecla Enter
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        ' Verifica si la tecla presionada es Enter
        If keyData = Keys.Enter Then
            ' Si el control activo es el campo de Password, ejecuta el evento OK_Click
            If Me.ActiveControl Is Password Then
                OK_Click(Me, EventArgs.Empty)
                Return True ' Indica que el evento ha sido manejado
            End If
            ' Mueve el enfoque al siguiente control si no es el campo de Password
            Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
            Return True ' Indica que el evento ha sido manejado
        End If
        ' Si no es Enter, ejecuta el comportamiento predeterminado
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    ' Función para iniciar sesión
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

    ' Evento para manejar el botón OK
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

    ' Evento para manejar el botón Cancelar
    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
        Me.Dispose()
    End Sub

End Class
