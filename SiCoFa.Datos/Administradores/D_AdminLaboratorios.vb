Imports System.Collections.Generic
Imports MySql.Data.MySqlClient
Imports SiCoFa.Entidades

Public Class D_AdminLaboratorios

    Public Function ListarLaboratorios(ByVal argTextoBuscado As String) As List(Of Laboratorio)
        Dim objConexionDB As New D_Conexion
        Dim ls As New List(Of Laboratorio)
        Dim l As Laboratorio

        Try
            Dim sql As String
            If argTextoBuscado = "*" Then
                sql = "SELECT CodiLabora,Laboratorio FROM laboratorios ORDER BY Laboratorio"
            Else
                sql = "SELECT CodiLabora,Laboratorio FROM laboratorios WHERE Laboratorio LIKE @Laboratorio ORDER BY Laboratorio"
            End If

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql

                    If argTextoBuscado <> "*" Then
                        cmd.Parameters.AddWithValue("@Laboratorio", Replace(UCase(argTextoBuscado), " ", "%") & "%")
                    End If

                    Using datos As MySqlDataReader = cmd.ExecuteReader()

                        While datos.Read
                            l = New Laboratorio(datos("CodiLabora"), datos("Laboratorio"))
                            ls.Add(l)
                        End While

                    End Using

                End Using

            End Using

            Return ls

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, NameOf(ListarLaboratorios), ex.Message))
            Return Nothing

        End Try

    End Function

End Class
