Imports MySql.Data.MySqlClient
Imports SiCoFa.Entidades
Imports System.Collections.Generic

Public Class D_AdminCuentasBancarias

    Public Function ObtenerCuentaBancariaPorId(ByVal argIdCB As Int32) As CuentaBancaria

        Dim objConexionDB As New D_Conexion
        Dim objCB As CuentaBancaria = Nothing

        Try
            Dim sql As String = "SELECT IdCB,Descripcion,NumCuenta,FechaAlta,Baja FROM cuentas_bancarias WHERE IdCB=@IdCB"

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql
                    cmd.Parameters.AddWithValue("@IdCB", argIdCB)

                    Using datos As MySqlDataReader = cmd.ExecuteReader()

                        If datos.Read() Then
                            Dim IdCB As Int32 = datos.GetInt32("IdCB")
                            Dim Descripcion As String = datos.GetString("Descripcion")
                            Dim NumCuenta As String = datos.GetString("NumCuenta")
                            Dim FechaAlta As String = datos.GetDateTime("FechaAlta")
                            Dim Baja As Boolean = datos.GetBoolean("Baja")

                            objCB = New CuentaBancaria(
                                                       IdCB,
                                                       Descripcion,
                                                       NumCuenta,
                                                       FechaAlta,
                                                       Baja
                                                       )

                        End If

                    End Using

                End Using

            End Using

            Return objCB

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerCuentaBancariaPorId", ex.Message))

        End Try

    End Function

    Public Function ListarCuentasBancarias(ByVal argTextoBuscado As String) As List(Of CuentaBancaria)
        Dim objConexionDB As New D_Conexion
        Dim lcb As New List(Of CuentaBancaria)
        Dim cb As CuentaBancaria

        Try
            Dim sql As String
            If argTextoBuscado = "*" Then
                sql = "SELECT IdCB,Descripcion,NumCuenta,FechaAlta,Baja FROM cuentas_bancarias ORDER BY Descripcion"
            Else
                sql = "SELECT IdCB,Descripcion,NumCuenta,FechaAlta,Baja FROM cuentas_bancarias WHERE Descripcion LIKE @Descripcion ORDER BY Descripcion"
            End If

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql

                    If argTextoBuscado <> "*" Then
                        cmd.Parameters.AddWithValue("@Descripcion", Replace(UCase(argTextoBuscado), " ", "%") & "%")
                    End If

                    Using datos As MySqlDataReader = cmd.ExecuteReader()
                        Dim idCBOrdinal As Integer = datos.GetOrdinal("IdCB")
                        Dim desciprionOrdinal As Integer = datos.GetOrdinal("Descripcion")
                        Dim numCuentaOrdinal As Integer = datos.GetOrdinal("NumCuenta")
                        Dim fechaAltaOrdinal As Integer = datos.GetOrdinal("FechaAlta")
                        Dim bajaOrdinal As Integer = datos.GetOrdinal("Baja")

                        While datos.Read
                            Dim IdCBResult As Int32 = Convert.ToInt32(datos(idCBOrdinal))
                            Dim DescripcionResult As String = datos.GetString(desciprionOrdinal)
                            Dim NumCuentaResult As String = datos.GetString(numCuentaOrdinal)
                            Dim FechaAltaResult As Date = Convert.ToDateTime(datos(fechaAltaOrdinal))
                            Dim BajaResult As Boolean = datos.GetBoolean(bajaOrdinal)

                            cb = New CuentaBancaria(IdCBResult, DescripcionResult, NumCuentaResult, FechaAltaResult, BajaResult)
                            lcb.Add(cb)
                        End While

                    End Using
                End Using

            End Using

            Return lcb

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ListarCuentasBancarias", ex.Message))
            Return Nothing

        End Try

    End Function
    Public Function InsertarCuentaBancaria(ByVal argDescripcion As String, ByVal argNumCuenta As String) As Int32

        Try
            Dim objConexionDB As New D_Conexion
            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("CtaBancariaInsertar", cn) With {.CommandType = CommandType.StoredProcedure}
                    With cmd.Parameters
                        .Add("p_Descripcion", MySqlDbType.VarChar).Value = argDescripcion
                        .Add("p_NumCuenta", MySqlDbType.VarChar).Value = argNumCuenta
                        .Add("p_IdCB", MySqlDbType.Int32)
                    End With

                    cmd.Parameters("p_IdCB").Direction = ParameterDirection.Output
                    cmd.ExecuteNonQuery()
                    Dim IdCB As Int32 = Convert.ToInt32(cmd.Parameters("p_IdCB").Value)
                    Return IdCB

                End Using

            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarCuentaBancaria", Ex.Message))

        End Try

    End Function
    Public Function ActualizarCuentaBancaria(ByVal argIdCB As Int32, ByVal argBaja As Boolean) As Boolean

        Try
            Dim objConexionDB As New D_Conexion
            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("CtaBancariaActualizar", cn) With {.CommandType = CommandType.StoredProcedure}
                    With cmd.Parameters
                        .Add("p_IdCB", MySqlDbType.Int32).Value = argIdCB
                        .Add("p_Baja", MySqlDbType.Bit).Value = argBaja
                    End With

                    Dim filasAfectadas As Int32 = cmd.ExecuteNonQuery()
                    Return (filasAfectadas > 0) ' Devuelve True si se actualizó al menos una fila

                End Using

            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ActualizarCuentaBancaria", Ex.Message))
            Return False

        End Try

    End Function

End Class
