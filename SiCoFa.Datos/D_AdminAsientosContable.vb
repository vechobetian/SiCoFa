Imports MySql.Data.MySqlClient
Imports SiCoFa.Entidades

Public Class D_AdminAsientosContable
    Public Function EfectuarAsientoContable(ByVal argOperacion As Operacion, ByVal argAsiento As AsientoContable) As Boolean
        Try
            Dim objConexionDB As New D_Conexion

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion
                cn.Open()
                Return EfectuarAsientoContable(argOperacion, argAsiento, cn, Nothing)
            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "EfectuarAsientoContable", Ex.Message))
        End Try
    End Function

    Friend Function EfectuarAsientoContable(ByVal argOperacion As Operacion, ByVal argAsiento As AsientoContable, ByVal cn As MySqlConnection, ByVal tx As MySqlTransaction) As Boolean
        Dim NumAsiento As Long

        Try
            Using cmd As New MySqlCommand("AsientoContableInsertarAsiento", cn, tx) With {.CommandType = CommandType.StoredProcedure}
                cmd.Parameters.AddWithValue("p_IdOperacion", argOperacion.IdOperacion)
                cmd.Parameters.Add("p_NumAsiento", MySqlDbType.Int64)
                cmd.Parameters("p_NumAsiento").Direction = ParameterDirection.Output
                cmd.ExecuteNonQuery()
                NumAsiento = cmd.Parameters("p_NumAsiento").Value
            End Using

            For Each iac As ItemAsientoContable In argAsiento.DetalleCuentas
                If iac.Importe <> 0 Then
                    Using cmd1 As New MySqlCommand("AsientoContableInsertarCuenta", cn, tx) With {.CommandType = CommandType.StoredProcedure}
                        With cmd1.Parameters
                            .AddWithValue("p_NumAsiento", NumAsiento)
                            .AddWithValue("p_IdAf", iac.IdAf)
                            .AddWithValue("p_CodiCta", iac.CodiCta)
                            .AddWithValue("p_Importe", iac.Importe)
                        End With
                        cmd1.ExecuteNonQuery()
                    End Using
                End If
            Next

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "EfectuarAsientoContable", Ex.Message))

        End Try
    End Function
End Class
