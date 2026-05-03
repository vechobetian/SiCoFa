Imports MySql.Data.MySqlClient
Imports System.Configuration

Public Class D_Conexion
    Private cadenaFarmacias As String
    Private cadenaContratos As String

    Public Sub New()
        cadenaFarmacias = ConfigurationManager.ConnectionStrings("Conexion_sicofaco_farmacias").ConnectionString
        cadenaFarmacias = ConfigurationManager.ConnectionStrings("Conexion_sicofaco_contratos").ConnectionString
    End Sub

    ' Método para obtener una conexión abierta (se usará dentro de Using)
    Public Function ObtenerConexionFarmacias() As MySqlConnection
        Dim conn As New MySqlConnection(cadenaFarmacias)
        conn.Open()
        Return conn
    End Function

    Public Function ObtenerConexionContratos() As MySqlConnection
        Dim conn As New MySqlConnection(cadenaFarmacias)
        conn.Open()
        Return conn
    End Function

End Class

