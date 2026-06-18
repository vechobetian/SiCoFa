Imports System.Collections.Generic
Imports MySql.Data.MySqlClient
Imports SiCoFa.Entidades

Public Class D_AdminObraSociales
    Public Function ObtenerPlanOSPorId(ByVal argIdPlan As Long) As PlanOS

        Dim objConexionDB As New D_Conexion

        Try

            Dim plan As PlanOS = Nothing

            Dim sql As String = "SELECT * FROM vw_planes_os WHERE IdPlan = @IdPlan"

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion("OS")

                Using cmd As MySqlCommand = cn.CreateCommand

                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql

                    cmd.Parameters.AddWithValue("@IdPlan", argIdPlan)

                    Using datos As MySqlDataReader = cmd.ExecuteReader()

                        If datos.Read() Then
                            plan = PlanOSMapper.Map(datos)
                        End If

                    End Using

                End Using

            End Using

            If plan IsNot Nothing Then

                If plan.IdVdm1 > 0 Then
                    plan.Vademecum1 = ListarItemsVademecum(plan.IdVdm1)
                End If

                If plan.IdVdm2 > 0 Then
                    plan.Vademecum2 = ListarItemsVademecum(plan.IdVdm2)
                End If

            End If

            Return plan

        Catch ex As Exception

            Throw New Exception(Vecho.MensajeError(Me.ToString(), NameOf(ObtenerPlanOSPorId), ex.Message))

        End Try

    End Function

    Public Function ListarItemsVademecum(ByVal argIdVdm As Integer) As List(Of ItemVademecum)

        Dim objConexionDB As New D_Conexion

        Try

            Dim lista As New List(Of ItemVademecum)

            Dim sql As String = "SELECT IdVdm, Codigo, Descuento FROM vademecum WHERE IdVdm = @IdVdm"

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion("OS")

                Using cmd As MySqlCommand = cn.CreateCommand

                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql

                    cmd.Parameters.AddWithValue("@IdVdm", argIdVdm)

                    Using datos As MySqlDataReader = cmd.ExecuteReader()

                        While datos.Read()

                            lista.Add(New ItemVademecum(CInt(datos("IdVdm")), CInt(datos("Codigo")), CDec(datos("Descuento"))))

                        End While

                    End Using

                End Using

            End Using

            Return lista

        Catch ex As Exception

            Throw New Exception(Vecho.MensajeError(Me.ToString(), NameOf(ListarItemsVademecum), ex.Message))

        End Try

    End Function

End Class
