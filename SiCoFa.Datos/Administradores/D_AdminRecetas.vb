Imports MySql.Data.MySqlClient
Imports SiCoFa.Entidades

Public Class D_AdminRecetas


    Friend Function InsertReceta(ByVal argIdOperacion As Long, ByVal argPlanOS As PlanOS, ByVal cn As MySqlConnection, ByVal tx As MySqlTransaction) As Receta

        Try

            Dim objReceta As Receta = Nothing

            Using cmd As New MySqlCommand("sp_insertar_receta", cn, tx) With {.CommandType = CommandType.StoredProcedure}
                With cmd.Parameters
                    .Add("p_IdOperacion", MySqlDbType.Int64).Value = argIdOperacion
                    .Add("p_IdReceta", MySqlDbType.Int64)

                End With

                cmd.Parameters("p_IdReceta").Direction = ParameterDirection.Output
                cmd.ExecuteNonQuery()

                Dim IdReceta As Long = CLng(cmd.Parameters("p_IdReceta").Value)

                If IdReceta > 0 Then
                    objReceta = New Receta(argPlanOS)
                    objReceta.IdOperacion = argIdOperacion
                    objReceta.IdReceta = IdReceta
                End If

            End Using

            Return objReceta

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertReceta", Ex.Message))

        End Try

    End Function

End Class
