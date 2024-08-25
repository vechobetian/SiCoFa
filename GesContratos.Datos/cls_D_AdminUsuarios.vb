Imports MySql.Data.MySqlClient
Imports SiCoFa.Entidades
Public Class cls_D_AdminUsuarios
    Public Function ObtenerUsuarioPorId(ByVal argIdUsuario As Long, ByVal argPassword As String) As Usuario
        Dim objUs As Usuario
        Try

            Dim sql As String = "SELECT IdUsuario,Nombre,Domicilio,Localidad,Provincia,Telefono,Movil,Email,CodiTDoc,NumDoc,Password FROM TblUsuarios WHERE IdUsuario=" & argIdUsuario & " AND Password='" & argPassword & "'"

            Dim cmd As MySqlCommand = Mod_D_Admin.ConexionDB.Conexion.CreateCommand
            cmd.CommandType = CommandType.Text
            cmd.CommandText = sql
            Dim datos As MySqlDataReader = cmd.ExecuteReader()
            datos.Read()

            If datos.HasRows Then
                objUs = New Usuario(
                            datos("IdUsuario"),
                            datos("Nombre"),
                            datos("Domicilio"),
                            datos("Localidad"),
                            datos("Provincia"),
                            datos("Telefono"),
                            datos("Movil"),
                            datos("Email"),
                            datos("CodiTDoc"),
                            datos("NumDoc"),
                            datos("Password")
                            )
            Else
                objUs = Nothing
            End If

            datos.Close()
            cmd.Dispose()
            Return objUs

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ObtenerUsuarioPorId", ex.Message))
            Return Nothing

        End Try

    End Function
End Class
