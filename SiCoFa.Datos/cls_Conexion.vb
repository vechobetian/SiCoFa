Imports MySql.Data.MySqlClient
Public Class cls_Conexion
    Property Conexion As MySqlConnection
    Property Base As String
    Property Servidor As String
    Property Usuario As String
    Property Clave As String
    Property Puerto As Integer = 3306
    Public Sub New()

        Me.Base = "sicofaco_com"
        Me.Servidor = "www.sicofa.com.ar"
        Me.Usuario = "sicofaco_vecho"
        Me.Clave = "Rene158902"

        Try

            If Me.Conexion Is Nothing Then
                Me.Conexion = New MySqlConnection(CrearCadena)
                If Conexion.State = ConnectionState.Closed Then
                    Me.Conexion.Open()
                End If
            End If

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "Error de conexion", ex.Message))

        End Try

    End Sub
    Public Function CrearCadena() As String
        Dim cadena As String
        cadena = "server=" & Me.Servidor & "; database=" & Me.Base & ";user id=" & Me.Usuario & ";password=" & Me.Clave & ";port=" & Me.Puerto & ";" & "Pooling=true; Min Pool Size=0; Max Pool Size=100; Connection Lifetime=0;"
        Return cadena
    End Function
    Public Sub CerrarConexion()
        If Conexion IsNot Nothing AndAlso Conexion.State = ConnectionState.Open Then
            Conexion.Close()
        End If
    End Sub

End Class
