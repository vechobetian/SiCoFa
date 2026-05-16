Imports MySql.Data.MySqlClient
Imports System.Configuration

Public Class D_Conexion
    Private cadenaFarmacias As String
    Private cadenaOS As String
    Private cadenaContratos As String

    Public Sub New()
        cadenaFarmacias = ConfigurationManager.ConnectionStrings("Conexion_sicofaco_farmacias").ConnectionString
        cadenaOS = ConfigurationManager.ConnectionStrings("Conexion_sicofaco_os").ConnectionString
        cadenaContratos = ConfigurationManager.ConnectionStrings("Conexion_sicofaco_contratos").ConnectionString
    End Sub
    Public Function ObtenerConexion(Optional ByVal argDataBase As String = "FARMACIAS") As MySqlConnection

        Dim cadena As String

        Select Case argDataBase.ToUpper

            Case "FARMACIAS"
                cadena = cadenaFarmacias

            Case "CONTRATOS"
                cadena = cadenaContratos

            Case "OS"
                cadena = cadenaOS

            Case Else
                Throw New Exception("Base de datos inválida")

        End Select

        Dim cn As New MySqlConnection(cadena)
        cn.Open()

        Return cn

    End Function
    ' Método para obtener una conexión abierta (se usará dentro de Using)

End Class

