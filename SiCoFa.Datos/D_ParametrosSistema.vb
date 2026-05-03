Imports System.Collections.Generic
Imports MySql.Data.MySqlClient
Imports SiCoFa.Entidades

Public Class D_ParametrosSistema
    Public Function ObtenerParametrosSistema() As List(Of ParametrosSistema)

        Try

            Dim objConexionDB As New D_Conexion
            Dim lista As New List(Of ParametrosSistema)

            Using cn As MySqlConnection = objConexionDB.ObtenerConexionFarmacias

                Dim cmd As New MySqlCommand("SELECT CodiParam, Parametro, Valor, Mostrar FROM parametros_sistema", cn)
                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    While dr.Read()
                        lista.Add(New ParametrosSistema With {
                        .CodiParam = dr("CodiParam").ToString(),
                        .Parametro = dr("Parametro").ToString(),
                        .Valor = dr("Valor").ToString(),
                        .Mostrar = CBool(dr("Mostrar"))
                    })
                    End While
                End Using
            End Using

            Return lista

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerTodos", ex.Message))

        End Try

    End Function
End Class
