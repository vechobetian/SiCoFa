Imports MySql.Data.MySqlClient
Imports SiCoFa.Entidades
Imports System.Collections.Generic

Public Class D_AdminMediosPE

    Public Function ObtenerMedioPEPorId(ByVal argIdMPE As Int32) As MedioPE

        Dim objConexionDB As New D_Conexion
        Dim objMPE As MedioPE = Nothing

        Try
            Dim sql As String = "SELECT IdMPE,Descripcion,IdCB,Baja FROM medios_pe WHERE IdMPE=@IdMPE"

            Using cn As MySqlConnection = objConexionDB.ObtenerConexionFarmacias

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql
                    cmd.Parameters.AddWithValue("@IdMPE", argIdMPE)

                    Using datos As MySqlDataReader = cmd.ExecuteReader()

                        If datos.Read() Then

                            Dim AdminCuentasBancarias As New D_AdminCuentasBancarias
                            Dim objCB As CuentaBancaria = AdminCuentasBancarias.ObtenerCuentaBancariaPorId(datos.GetInt32("IdCB"))

                            objMPE = New MedioPE(
                                                 datos.GetInt32("IdMPE"),
                                                 datos.GetString("Descripcion"),
                                                 objCB,
                                                 datos.GetString("Baja")
                                                 )

                        End If

                        Return objMPE

                    End Using

                End Using

            End Using

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerMedioPEPorId", ex.Message))

        End Try

    End Function

    Public Function ListarMedioPE(ByVal argTextoBuscado As String) As List(Of MedioPE)
        Dim objConexionDB As New D_Conexion
        Dim lmpe As New List(Of MedioPE)
        Dim mpe As MedioPE

        Try
            Dim sql As String
            If argTextoBuscado = "*" Then
                sql = "SELECT IdMPE,Descripcion,IdCB,Baja FROM medios_pe ORDER BY Descripcion"
            Else
                sql = "SELECT IdMPE,Descripcion,IdCB,Baja FROM medios_pe WHERE Descripcion LIKE @Descripcion ORDER BY Descripcion"
            End If

            Using cn As MySqlConnection = objConexionDB.ObtenerConexionFarmacias

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql

                    If argTextoBuscado <> "*" Then
                        cmd.Parameters.AddWithValue("@Descripcion", Replace(UCase(argTextoBuscado), " ", "%") & "%")
                    End If

                    Using datos As MySqlDataReader = cmd.ExecuteReader()
                        Dim idMPEOrdinal As Integer = datos.GetOrdinal("IdMPE")
                        Dim desciprionOrdinal As Integer = datos.GetOrdinal("Descripcion")
                        Dim idCBOrdinal As Integer = datos.GetOrdinal("IdCB")
                        Dim bajaOrdinal As Integer = datos.GetOrdinal("Baja")

                        While datos.Read
                            Dim IdMPEResult As Int32 = datos.GetInt32(idMPEOrdinal)
                            Dim DescripcionResult As String = UCase(datos.GetString(desciprionOrdinal))
                            Dim IdCBResult As Int32 = datos.GetInt32(idCBOrdinal)
                            Dim BajaResult As Boolean = datos.GetBoolean(bajaOrdinal)
                            Dim AdminCuentasBancarias As New D_AdminCuentasBancarias
                            Dim objCB As CuentaBancaria = AdminCuentasBancarias.ObtenerCuentaBancariaPorId(IdCBResult)

                            mpe = New MedioPE(IdMPEResult, DescripcionResult, objCB, BajaResult)
                            lmpe.Add(mpe)
                        End While

                    End Using

                End Using

            End Using

            Return lmpe

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ListarMedioPE", ex.Message))
            Return Nothing

        End Try

    End Function
    Public Function InsertarMedioPE(ByVal argDescripcion As String, ByVal argIdCB As Int32) As Int32

        Try
            Dim objConexionDB As New D_Conexion
            Using cn As MySqlConnection = objConexionDB.ObtenerConexionFarmacias

                Using cmd As New MySqlCommand("sp_insertar_medio_pe", cn) With {.CommandType = CommandType.StoredProcedure}
                    With cmd.Parameters
                        .Add("p_Descripcion", MySqlDbType.VarChar).Value = argDescripcion
                        .Add("p_IdCB", MySqlDbType.Int32).Value = argIdCB
                        .Add("p_IdMPE", MySqlDbType.Int32)
                    End With

                    cmd.Parameters("p_IdMPE").Direction = ParameterDirection.Output
                    cmd.ExecuteNonQuery()
                    Dim IdMPE As Int32 = Convert.ToInt32(cmd.Parameters("p_IdMPE").Value)
                    Return IdMPE

                End Using

            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarMedioPE", Ex.Message))

        End Try

    End Function

    Public Function ActualizarMedioPE(ByVal argIdMPE As Int32, ByVal argIdCB As Int32, ByVal argBaja As Boolean) As Boolean

        Try
            Dim objConexionDB As New D_Conexion
            Using cn As MySqlConnection = objConexionDB.ObtenerConexionFarmacias

                Using cmd As New MySqlCommand("sp_actualizar_medio_pe", cn) With {.CommandType = CommandType.StoredProcedure}
                    With cmd.Parameters
                        .Add("p_IdMPE", MySqlDbType.Int32).Value = argIdMPE
                        .Add("p_IdCB", MySqlDbType.Int32).Value = argIdCB
                        .Add("p_Baja", MySqlDbType.Bit).Value = argBaja
                    End With

                    Dim filasAfectadas As Int32 = cmd.ExecuteNonQuery()
                    Return (filasAfectadas > 0) ' Devuelve True si se actualizó al menos una fila

                End Using

            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ActualizarMedioPE", Ex.Message))
            Return False

        End Try

    End Function

End Class
