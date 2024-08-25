Imports System.Collections.Generic
Imports MySql.Data.MySqlClient
Imports SiCoFa.Entidades
Public Class cls_D_AdminEmail
    Public Function ObtenerCuentaEmail() As CuentaEmail
        Dim objCEmail As CuentaEmail = Nothing
        Try

            Dim sql As String

            sql = "SELECT IdCEmail,Port,Host,User,Psw,Mail FROM TblCuentasEmail"

            Dim cmd As MySqlCommand = Mod_D_Admin.ConexionDB.Conexion.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = sql
            Dim datos As MySqlDataReader = cmd.ExecuteReader()
            datos.Read()

            If datos.HasRows Then
                objCEmail = New CuentaEmail(datos("IdCEmail"), datos("Port"), datos("Host"), datos("User"), datos("Psw"), datos("Mail"))
            End If

            datos.Close()
            cmd.Dispose()
            Return objCEmail

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ObtenerEmailEmpresa", ex.Message))
            Return Nothing
        End Try

    End Function
End Class