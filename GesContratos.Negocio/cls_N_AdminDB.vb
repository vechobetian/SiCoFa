Imports SiCoFa.Datos
Public Class cls_N_AdminDB

    Dim mobj_D_AdminDB As New cls_D_AdminDB
    Public Function ObtenerTabla(ByVal argSql As String) As DataTable
        Try

            Dim tbl As DataTable = mobj_D_AdminDB.ObtenerTabla(argSql)
            Return tbl

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ObtenerTabla", ex.Message))
            Return Nothing
        End Try

    End Function
    Public Sub ActualizarTabla(ByVal argSql As String, ByVal argTbl As DataTable)
        Try

            mobj_D_AdminDB.ActualizarTabla(argSql, argTbl)

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ActualizarTabla", ex.Message))
        End Try

    End Sub

End Class
