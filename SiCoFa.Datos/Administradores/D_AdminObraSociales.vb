Imports MySql.Data.MySqlClient
Imports SiCoFa.Entidades

Public Class D_AdminObraSociales
    Public Function ObtenerPlanOSPorId(ByVal argIdPlan As Long) As PlanOS

        Dim objConexionDB As New D_Conexion

        Try

            Dim sql As String = "SELECT * FROM vw_planes_os WHERE IdPlan = @IdPlan"

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion("OS")

                Using cmd As MySqlCommand = cn.CreateCommand

                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql

                    cmd.Parameters.AddWithValue("@IdPlan", argIdPlan)

                    Using datos As MySqlDataReader = cmd.ExecuteReader()

                        If datos.Read() Then
                            Return PlanOSMapper.Map(datos)
                        End If

                    End Using

                End Using

            End Using

            Return Nothing

        Catch ex As Exception

            Throw New Exception(Vecho.MensajeError(Me.ToString(), NameOf(ObtenerPlanOSPorId), ex.Message))

        End Try

    End Function
End Class
