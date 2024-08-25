Imports MySql.Data.MySqlClient
Public Class cls_D_AdminDB
    Public Function ObtenerTabla(ByVal argSql As String) As DataTable

        Try

            Dim adapter = New MySqlDataAdapter(argSql, Mod_D_Admin.ConexionDB.Conexion)
            Dim tbl As New DataTable

            adapter.Fill(tbl)
            adapter.Dispose()
            Return tbl

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ObtenerTabla", ex.Message))
            Return Nothing
        End Try
    End Function
    Public Sub ActualizarTabla(ByVal argSql As String, ByVal argTbl As DataTable)
        Try

            Dim adapter = New MySqlDataAdapter(argSql, Mod_D_Admin.ConexionDB.Conexion)
            Dim builder As New MySqlCommandBuilder(adapter)
            adapter.Update(argTbl)
            adapter.Dispose()

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ActualizarTabla", ex.Message))
        End Try

    End Sub
End Class