Imports SiCoFa.Entidades

Module ModSeguridad
    Public Function ValidarUsuario(ByVal argIdProceso As String) As Usuario
        Try

            Dim User As Usuario = Nothing

            If g_Usuario Is Nothing Then
                Using frmLogin As New FrmLoginUser
                    frmLogin.IdProceso = argIdProceso

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
End Module
