Imports MySql.Data.MySqlClient
Imports SiCoFa.Entidades

Public Class D_AdminCuentasEmail
    Public Function ObtenerCuentaEmail() As CuentaEmail
        Dim objConexionDB As New D_Conexion
        Dim objCEmail As CuentaEmail = Nothing

        Try

            Dim sql As String

            sql = "SELECT IdCEmail,Port,Host,User,Psw,Mail FROM TblCuentasEmail"
            Using cn As MySqlConnection = objConexionDB.ObtenerConexion
                Using cmd As MySqlCommand = cn.CreateCommand()
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql

                    Using datos As MySqlDataReader = cmd.ExecuteReader()
                        datos.Read()

                        If datos.HasRows Then
                            objCEmail = New CuentaEmail(datos("IdCEmail"), datos("Port"), datos("Host"), datos("User"), datos("Psw"), datos("Mail"))
                        End If
                    End Using

                End Using

            End Using

            Return objCEmail

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerEmailEmpresa", ex.Message))
            Return Nothing
        End Try

    End Function
End Class
