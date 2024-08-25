Module Mod_D_Admin
    Private mobjConexionDB As cls_Conexion
    Public Function ConexionDB() As cls_Conexion
        If mobjConexionDB Is Nothing Then
            mobjConexionDB = New cls_Conexion
        End If

        Return mobjConexionDB

    End Function

End Module