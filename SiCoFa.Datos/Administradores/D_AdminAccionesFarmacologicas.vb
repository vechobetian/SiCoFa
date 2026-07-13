Imports System.Collections.Generic
Imports MySql.Data.MySqlClient
Imports SiCoFa.Entidades

Public Class D_AdminAccionesFarmacologicas
    Public Function ListarAccionesFarmacologicas(ByVal argTextoBuscado As String) As List(Of AccionFarmacologica)
        Dim objConexionDB As New D_Conexion
        Dim ls As New List(Of AccionFarmacologica)
        Dim a As AccionFarmacologica

        Try
            Dim sql As String
            If argTextoBuscado = "*" Then
                sql = "SELECT CodiAcFa,AccionFarmacologica FROM acciones_farmacologicas ORDER BY AccionFarmacologica"
            Else
                sql = "SELECT CodiAcFa,AccionFarmacologica FROM acciones_farmacologicas WHERE AccionFarmacologica LIKE @AccionFarmacologica ORDER BY AccionFarmacologica"
            End If

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql

                    If argTextoBuscado <> "*" Then
                        cmd.Parameters.AddWithValue("@AccionFarmacologica", Replace(UCase(argTextoBuscado), " ", "%") & "%")
                    End If

                    Using datos As MySqlDataReader = cmd.ExecuteReader()

                        While datos.Read
                            a = New AccionFarmacologica(datos("CodiAcFa"), datos("AccionFarmacologica"))
                            ls.Add(a)
                        End While

                    End Using

                End Using

            End Using

            Return ls

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, NameOf(ListarAccionesFarmacologicas), ex.Message))
            Return Nothing

        End Try

    End Function
End Class
