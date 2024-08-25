Imports MySql.Data.MySqlClient
Imports SiCoFa.Entidades
Public Class cls_Conexion
    Property Conexion As MySqlConnection
    Property Base As String
    Property Servidor As String
    Property Usuario As String
    Property Clave As String
    Property Puerto As Integer = 3306
    Public Sub New()

        Me.Base = "sicofaco_contratos"
        Me.Servidor = "www.sicofa.com.ar"
        Me.Usuario = "sicofaco_vecho"
        Me.Clave = "Rene158902"

        If Me.Conexion Is Nothing Then
            Me.Conexion = New MySqlConnection(CrearCadena)
            If Conexion.State = ConnectionState.Closed Then
                Me.Conexion.Open()
            End If
        End If

    End Sub
    Public Function CrearCadena() As String
        Dim cadena As String
        cadena = "server=" & Me.Servidor & "; database=" & Me.Base & ";user id=" & Me.Usuario & ";password=" & Me.Clave & ";port=" & Me.Puerto & ";"
        Return cadena
    End Function


End Class
