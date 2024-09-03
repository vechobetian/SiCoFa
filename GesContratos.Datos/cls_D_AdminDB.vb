Imports MySql.Data.MySqlClient
Public Class cls_D_AdminDB
    Public Function ObtenerTabla(ByVal argSql As String) As DataTable

        Try
            Dim tbl As New DataTable

            Using adapter = New MySqlDataAdapter(argSql, Mod_D_Admin.ConexionDB.Conexion)
                adapter.Fill(tbl)
            End Using

            Return tbl

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ObtenerTabla", ex.Message))
            Return Nothing

        End Try

    End Function
    Public Sub ActualizarTabla(ByVal argSql As String, ByVal argTbl As DataTable)
        Try

            Using adapter = New MySqlDataAdapter(argSql, Mod_D_Admin.ConexionDB.Conexion)

                Using builder As New MySqlCommandBuilder(adapter)
                    adapter.Update(argTbl)

                End Using

            End Using

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ActualizarTabla", ex.Message))

        End Try

    End Sub

End Class