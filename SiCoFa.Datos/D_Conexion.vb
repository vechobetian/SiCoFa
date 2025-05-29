Imports MySql.Data.MySqlClient
Imports System.Configuration

Public Class D_Conexion
    Private cadenaConexion As String

    Public Sub New()
        cadenaConexion = ConfigurationManager.ConnectionStrings("Conexion_sicofaco_comercios").ConnectionString
    End Sub

    ' Método para obtener una conexión abierta (se usará dentro de Using)
    Public Function ObtenerConexion() As MySqlConnection
        Dim conn As New MySqlConnection(cadenaConexion)
        conn.Open()
        Return conn
    End Function
End Class

