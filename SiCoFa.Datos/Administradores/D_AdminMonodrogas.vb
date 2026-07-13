Imports System.Collections.Generic
Imports MySql.Data.MySqlClient
Imports SiCoFa.Entidades

Public Class D_AdminMonodrogas
    Public Function ListarMonodrogas(ByVal argTextoBuscado As String) As List(Of Monodroga)
        Dim objConexionDB As New D_Conexion
        Dim ls As New List(Of Monodroga)
        Dim m As Monodroga

        Try
            Dim sql As String
            If argTextoBuscado = "*" Then
                sql = "SELECT CodiMon,Monodroga FROM monodrogas ORDER BY Monodroga"
            Else
                sql = "SELECT CodiMon,Monodroga FROM monodrogas WHERE Monodroga LIKE @Monodroga ORDER BY Monodroga"
            End If

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql

                    If argTextoBuscado <> "*" Then
                        cmd.Parameters.AddWithValue("@Monodroga", Replace(UCase(argTextoBuscado), " ", "%") & "%")
                    End If

                    Using datos As MySqlDataReader = cmd.ExecuteReader()

                        While datos.Read
                            m = New Monodroga(datos("CodiMon"), datos("Monodroga"))
                            ls.Add(m)
                        End While

                    End Using

                End Using

            End Using

            Return ls

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, NameOf(ListarMonodrogas), ex.Message))
            Return Nothing

        End Try

    End Function
End Class
