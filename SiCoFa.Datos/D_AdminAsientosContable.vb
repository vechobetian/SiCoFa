Imports System.Collections.Generic
Imports MySql.Data.MySqlClient
Imports SiCoFa.Entidades

Public Class D_AdminAsientosContable

    Public Function ObtenerCuentaImputablePorCodiCta(ByVal argCodiCta As String) As CuentaImputable
        Dim objConexionDB As New D_Conexion
        Dim objCI As CuentaImputable = Nothing

        Try
            Dim Sql As String = "SELECT CodiCta,CodiCtaCol,CuentaImputable FROM cuentas_imputables WHERE CodiCta = @CodiCta"

            Using cn As MySqlConnection = objConexionDB.ObtenerConexionFarmacias

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = Sql
                    cmd.Parameters.AddWithValue("@CodiCta", argCodiCta)

                    Using datos As MySqlDataReader = cmd.ExecuteReader()

                        If datos.Read Then
                            Dim CodiCta As String = datos("CodiCta")
                            Dim CodiCtaCol As String = datos("CodiCtaCol")
                            Dim NombreCta As String = datos("CuentaImputable")
                            objCI = New CuentaImputable(CodiCta, CodiCtaCol, NombreCta)
                        End If

                    End Using

                End Using

            End Using

            Return objCI

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerCuentaImputablePorCodiCta", ex.Message))
            Return Nothing

        End Try

    End Function

    Public Function ListarCuentasImputables(ByVal argTextoBuscado As String) As List(Of CuentaImputable)

        Dim objConexionDB As New D_Conexion
        Dim lc As New List(Of CuentaImputable)
        Dim c As CuentaImputable

        Try
            Dim sql As String
            If argTextoBuscado = "*" Then
                sql = "SELECT CodiCta,CodiCtaCol,CuentaImputable FROM cuentas_imputables ORDER BY CuentaImputable"
            Else
                sql = "SELECT CodiCta,CodiCtaCol,CuentaImputable FROM cuentas_imputables WHERE CuentaImputable LIKE @CuentaImputable ORDER BY CuentaImputables"
            End If

            Using cn As MySqlConnection = objConexionDB.ObtenerConexionFarmacias

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql

                    If argTextoBuscado <> "*" Then
                        cmd.Parameters.AddWithValue("@CuentaImputable", Replace(UCase(argTextoBuscado), " ", "%") & "%")
                    End If

                    Using datos As MySqlDataReader = cmd.ExecuteReader()

                        While datos.Read
                            c = New CuentaImputable(datos("CodiCta"), datos("CodiCtaCol"), datos("CuentaImputable"))
                            lc.Add(c)
                        End While

                    End Using

                End Using

            End Using

            Return lc

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ListarCuentasImputables", ex.Message))
            Return Nothing

        End Try
    End Function

    Public Function EfectuarAsientoContable(ByVal argOperacion As Operacion, ByVal argAsiento As AsientoContable) As Boolean
        Try
            Dim objConexionDB As New D_Conexion

            Using cn As MySqlConnection = objConexionDB.ObtenerConexionFarmacias
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
            Using cmd As New MySqlCommand("sp_insertar_asiento_contable", cn, tx) With {.CommandType = CommandType.StoredProcedure}
                cmd.Parameters.AddWithValue("p_IdOperacion", argOperacion.IdOperacion)
                cmd.Parameters.Add("p_NumAsiento", MySqlDbType.Int64)
                cmd.Parameters("p_NumAsiento").Direction = ParameterDirection.Output
                cmd.ExecuteNonQuery()
                NumAsiento = cmd.Parameters("p_NumAsiento").Value
            End Using

            For Each iac As ItemAsientoContable In argAsiento.DetalleCuentas
                If iac.Importe <> 0 Then
                    Using cmd1 As New MySqlCommand("sp_insertar_cuenta_imputable", cn, tx) With {.CommandType = CommandType.StoredProcedure}
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
