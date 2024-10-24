Module Mod_D_Admin
    Private mobjConexionDB As cls_Conexion
    Public Function ConexionDB() As cls_Conexion
        If mobjConexionDB Is Nothing Then
            mobjConexionDB = New cls_Conexion
        End If

        Return mobjConexionDB

    End Function
    Public Function strConexionDB() As String

        Dim Base As String = "sicofaco_com"
        Dim Servidor As String = "www.sicofa.com.ar"
        Dim Usuario As String = "sicofaco_vecho"
        Dim Clave As String = "Rene158902"
        Dim Puerto As Integer = 3306

        Dim cadena As String = "server=" & Servidor & "; database=" & Base & ";user id=" & Usuario & ";password=" & Clave & ";port=" & Puerto & ";" & "Pooling=true; Min Pool Size=0; Max Pool Size=100; Connection Lifetime=0;"
        Return cadena

    End Function

End Module