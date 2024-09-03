Imports System.Collections.Generic
Imports MySql.Data.MySqlClient
Imports SiCoFa.Entidades
Public Class cls_D_AdminConsumoLuz
    Public Function ObtenerRegConsumoLuzPorId(ByVal argIdRegistro As Long) As RegConsumoLuz

        Try
            Dim objRegCL As RegConsumoLuz
            Dim objDetCL As List(Of ItemConsumoLuz)
            Dim objMedidor As Medidor
            Dim IdRegistro As Long
            Dim FechaLAn As Date
            Dim FechaLAc As Date
            Dim Mes As Integer
            Dim Año As Integer
            Dim IdMedidor As Integer
            Dim LecturaAnterior As Integer
            Dim LecturaActual As Integer
            Dim Consumo As Integer
            Dim ImpCalculado As Decimal
            Dim ImpFactura As Decimal
            Dim ImpNeto As Decimal
            Dim Ley3052 As Decimal
            Dim IVA As Decimal
            Dim RG2123 As Decimal
            Dim Observaciones As String
            Dim Estado As String

            Dim sql As String = "SELECT IdRegistro,FechaLAn,FechaLAc,Mes,Ano,IdMedidor,LecturaAnterior,LecturaActual,Consumo,ImpCalculado,ImpFactura,ImpNeto,Ley3052,IVA,RG2123,Observaciones,Estado FROM TblRegConsumoLuz WHERE IdRegistro=" & argIdRegistro

            Using cmd As MySqlCommand = Mod_D_Admin.ConexionDB.Conexion.CreateCommand
                cmd.CommandType = CommandType.Text
                cmd.CommandText = sql

                Using datos As MySqlDataReader = cmd.ExecuteReader()
                    datos.Read()

                    If datos.HasRows = False Then
                        datos.Close()
                        cmd.Dispose()
                        Return Nothing
                        Exit Function
                    End If

                    IdRegistro = datos("IdRegistro")
                    FechaLAn = datos("FechaLAn")
                    FechaLAc = datos("FechaLAc")
                    Mes = datos("Mes")
                    Año = datos("Ano")
                    IdMedidor = datos("IdMedidor")
                    LecturaAnterior = datos("LecturaAnterior")
                    LecturaActual = datos("LecturaActual")
                    Consumo = datos("Consumo")
                    ImpCalculado = datos("ImpCalculado")
                    ImpFactura = datos("ImpFactura")
                    ImpNeto = datos("ImpNeto")
                    Ley3052 = datos("Ley3052")
                    IVA = datos("IVA")
                    RG2123 = datos("RG2123")
                    'Observaciones = datos("Observaciones")
                    Estado = datos("Estado")

                End Using

            End Using

            objMedidor = Me.ObtenerMedidorPorId(IdMedidor)
            objDetCL = Me.ObtenerDetConsumoLuz(IdRegistro)
            objRegCL = New RegConsumoLuz(IdRegistro, FechaLAn, FechaLAc, Mes, Año, objMedidor, LecturaAnterior, LecturaActual, Consumo, ImpCalculado, ImpFactura, ImpNeto, Ley3052, IVA, RG2123, Observaciones, Estado, objDetCL)

            Return objRegCL

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ObtenerRegistroConsumoLuzPorId", ex.Message))
            Return Nothing

        End Try

    End Function
    Public Function ObtenerRegConsumoLuzIniciado(ByVal argEstado As String, Optional ByVal argIdMedidor As Integer = 0, Optional ByVal argIdRegistro As Long = 0) As RegConsumoLuz

        Try
            Dim objRegCL As RegConsumoLuz
            Dim objDetCL As List(Of ItemConsumoLuz)
            Dim objMedidor As Medidor
            Dim IdRegistro As Long
            Dim FechaLAn As Date
            Dim FechaLAc As Date
            Dim Mes As String
            Dim Año As String
            Dim IdMedidor As Integer
            Dim LecturaAnterior As Integer
            Dim LecturaActual As Integer
            Dim Consumo As Integer
            Dim ImpCalculado As Decimal
            Dim ImpFactura As Decimal
            Dim ImpNeto As Decimal
            Dim Ley3052 As Decimal
            Dim IVA As Decimal
            Dim RG2123 As Decimal
            Dim Observaciones As String
            Dim Estado As String
            Dim sql As String

            If argIdMedidor = 0 And argIdRegistro = 0 Then
                sql = "SELECT IdRegistro,FechaLAn,FechaLAc,Mes,Ano,IdMedidor,LecturaAnterior,LecturaActual,Consumo,ImpCalculado,ImpFactura,ImpNeto,Ley3052,IVA,RG2123,Observaciones,Estado FROM TblRegConsumoLuz WHERE Estado='" & argEstado & "'"
            ElseIf argIdMedidor > 0 Then
                sql = "SELECT IdRegistro,FechaLAn,FechaLAc,Mes,Ano,IdMedidor,LecturaAnterior,LecturaActual,Consumo,ImpCalculado,ImpFactura,ImpNeto,Ley3052,IVA,RG2123,Observaciones,Estado FROM TblRegConsumoLuz WHERE IdMedidor=" & argIdMedidor & " AND Estado='" & argEstado & "'"
            ElseIf argIdRegistro > 0 Then
                sql = "SELECT IdRegistro,FechaLAn,FechaLAc,Mes,Ano,IdMedidor,LecturaAnterior,LecturaActual,Consumo,ImpCalculado,ImpFactura,ImpNeto,Ley3052,IVA,RG2123,Observaciones,Estado FROM TblRegConsumoLuz WHERE IdRegistro=" & argIdRegistro & " AND Estado='" & argEstado & "'"
            End If

            Using cmd As MySqlCommand = Mod_D_Admin.ConexionDB.Conexion.CreateCommand
                cmd.CommandType = CommandType.Text
                cmd.CommandText = sql

                Using datos As MySqlDataReader = cmd.ExecuteReader()
                    datos.Read()

                    If datos.HasRows = False Then
                        datos.Close()
                        cmd.Dispose()
                        Return Nothing
                        Exit Function
                    End If

                    IdRegistro = datos("IdRegistro")
                    FechaLAn = datos("FechaLAn")
                    FechaLAc = datos("FechaLAc")
                    Mes = datos("Mes")
                    Año = datos("Ano")
                    IdMedidor = datos("IdMedidor")
                    LecturaAnterior = datos("LecturaAnterior")
                    LecturaActual = datos("LecturaActual")
                    Consumo = datos("Consumo")
                    ImpCalculado = datos("ImpCalculado")
                    ImpFactura = datos("ImpFactura")
                    ImpNeto = datos("ImpNeto")
                    Ley3052 = datos("Ley3052")
                    IVA = datos("IVA")
                    RG2123 = datos("RG2123")
                    'Observaciones = if datos("Observaciones")
                    Estado = datos("Estado")

                End Using

            End Using

            objMedidor = Me.ObtenerMedidorPorId(IdMedidor)
            objDetCL = Me.ObtenerDetConsumoLuz(IdRegistro)
            objRegCL = New RegConsumoLuz(IdRegistro, FechaLAn, FechaLAc, Mes, Año, objMedidor, LecturaAnterior, LecturaActual, Consumo, ImpCalculado, ImpFactura, ImpNeto, Ley3052, IVA, RG2123, Observaciones, Estado, objDetCL)

            Return objRegCL

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ObtenerRegistroConsumoIniciado", ex.Message))
            Return Nothing

        End Try

    End Function
    Public Function InsertarRegConsumoLuz(
                                        ByVal argFechaUL As Date,
                                        ByVal argMes As String,
                                        ByVal argAño As String,
                                        ByVal argIdMedidor As Integer,
                                        ByVal argKWLAn As Integer,
                                        ByVal argKWLAc As Integer,
                                        ByVal argObservaciones As String
                                        ) As Long

        Dim IdRegistro As Long
        Try

            Using cmd As New MySqlCommand("InsertarRegistroCLuz", Mod_D_Admin.ConexionDB.Conexion) With {.CommandType = CommandType.StoredProcedure}

                cmd.Parameters.AddWithValue("FechaUL", argFechaUL)
                cmd.Parameters.AddWithValue("Mes", argMes)
                cmd.Parameters.AddWithValue("Año", argAño)
                cmd.Parameters.AddWithValue("IdMed", argIdMedidor)
                cmd.Parameters.AddWithValue("KWLAn", argKWLAn)
                cmd.Parameters.AddWithValue("KWLAc", argKWLAc)
                cmd.Parameters.AddWithValue("Obser", argObservaciones)
                cmd.Parameters.Add("IdReg", MySqlDbType.Int64)
                cmd.Parameters("IdReg").Direction = ParameterDirection.Output
                cmd.ExecuteNonQuery()
                IdRegistro = CInt(cmd.Parameters("IdReg").Value)

            End Using
            Return IdRegistro

        Catch Ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "InsertarRegistroConsumoLuz", Ex.Message))
            Return 0
        End Try

    End Function
    Public Function EliminarRegConsumoLuz(ByVal argIdRegistro As Long) As Integer
        Dim RegistrosAfectados As Integer
        Try

            Using cmd As New MySqlCommand("EliminarRegistroCluz", Mod_D_Admin.ConexionDB.Conexion) With {.CommandType = CommandType.StoredProcedure}
                cmd.Parameters.AddWithValue("_IdRegistro", argIdRegistro)
                RegistrosAfectados = cmd.ExecuteNonQuery()

            End Using
            Return RegistrosAfectados

        Catch Ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "EliminarRegConsumoLuz", Ex.Message))
            Return 0
        End Try

    End Function
    Public Function ActualizarTotalesConsumoLuz(ByVal argIdRegistro As Long) As Integer
        Dim RegistrosAfectados As Integer
        Try

            Using cmd As New MySqlCommand("ActualizarTotalesConsumoLuz", Mod_D_Admin.ConexionDB.Conexion) With {.CommandType = CommandType.StoredProcedure}
                cmd.Parameters.AddWithValue("_IdRegistro", argIdRegistro)
                RegistrosAfectados = cmd.ExecuteNonQuery()

            End Using

            Return RegistrosAfectados

        Catch Ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ActualizarTotalesConsumoLuz", Ex.Message))
            Return 0
        End Try

    End Function
    Public Function ActualizarEstadoRegistroConsumoLuz(ByVal argIdRegistro As Long, ByVal argEstadoNuevo As String) As Integer

        Dim RegAfectados As Integer
        Try
            Dim sql As String = "UPDATE TblRegConsumoLuz SET Estado='" & argEstadoNuevo & "' WHERE IdRegistro=" & argIdRegistro

            Using cmd As New MySqlCommand(sql, Mod_D_Admin.ConexionDB.Conexion)
                RegAfectados = cmd.ExecuteNonQuery
            End Using

        Catch Ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ActualizarEstadoRegistroConsumoLuz", Ex.Message))
            Return 0
        End Try
        Return RegAfectados
    End Function
    Public Function ObtenerMedidorPorId(ByVal argIdMedidor As Long) As Medidor
        Dim m As Medidor
        Try

            Dim sql As String = "SELECT IdMedidor,Descripcion,Categoria,Suministro,NumCliente,IVA,RG2123,IdContrato,FechaUL,UltimaLectura FROM TblMedidoresLuz WHERE IdMedidor=" & argIdMedidor

            Using cmd As MySqlCommand = Mod_D_Admin.ConexionDB.Conexion.CreateCommand
                cmd.CommandType = CommandType.Text
                cmd.CommandText = sql

                Using datos As MySqlDataReader = cmd.ExecuteReader()
                    datos.Read()

                    If datos.HasRows Then
                        m = New Medidor(datos("IdMedidor"), datos("Descripcion"), datos("Categoria"), datos("NumCliente"), datos("Suministro"), datos("IVA"), datos("RG2123"), datos("IdContrato"), datos("FechaUL"), datos("UltimaLectura"))
                    Else
                        m = Nothing
                    End If

                End Using

            End Using
                Return m

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ObtenerMedidorPorId", ex.Message))
            Return Nothing
        End Try

    End Function
    Public Function ListarMedidores() As List(Of Medidor)
        Dim lm As New List(Of Medidor)
        Dim m As Medidor

        Try

            Dim sql As String = "SELECT IdMedidor,Descripcion,Categoria,Suministro,NumCliente,IVA,RG2123,IdContrato,FechaUL,UltimaLectura FROM TblMedidoresLuz ORDER BY Descripcion"

            Dim cmd As MySqlCommand = Mod_D_Admin.ConexionDB.Conexion.CreateCommand
            cmd.CommandType = CommandType.Text
            cmd.CommandText = sql
            Dim datos As MySqlDataReader = cmd.ExecuteReader()

            If datos.HasRows Then
                While datos.Read()
                    m = New Medidor(datos("IdMedidor"), datos("Descripcion"), datos("Categoria"), datos("NumCliente"), datos("Suministro"), datos("IVA"), datos("RG2123"), datos("IdContrato"), datos("FechaUL"), datos("UltimaLectura"))
                    lm.Add(m)
                End While
            Else
                lm = Nothing
            End If

            datos.Close()
            cmd.Dispose()
            Return lm

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ListarMedidores", ex.Message))
            Return Nothing
        End Try

    End Function
    Public Function ObtenerDetConsumoLuz(argIdRegistro As Long) As List(Of ItemConsumoLuz)
        Dim objDetI As New List(Of ItemConsumoLuz)

        Try

            Dim sql As String = "SELECT IdRegistro,Item,Descripcion,Cantidad,PUnit FROM TblDetConsumoLuz WHERE IdRegistro=" & argIdRegistro

            Dim cmd As MySqlCommand = Mod_D_Admin.ConexionDB.Conexion.CreateCommand
            cmd.CommandType = CommandType.Text
            cmd.CommandText = sql
            Dim datos As MySqlDataReader = cmd.ExecuteReader()
            Dim objItemCL As ItemConsumoLuz = Nothing

            If datos.HasRows Then
                While datos.Read()
                    objItemCL = New ItemConsumoLuz(datos("Item"), datos("Descripcion"), datos("Cantidad"), datos("Punit"))
                    objDetI.Add(objItemCL)
                End While
            Else
                objDetI = Nothing
            End If

            datos.Close()
            cmd.Dispose()
            Return objDetI

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ObtenerDetalle", ex.Message))
            Return Nothing
        End Try

    End Function

    Public Function InsertarDetConsumoLuz(ByVal argIdReg As Integer, ByVal argCategoria As String, ByVal argKWConsumo As Integer) As Integer

        Dim RegistrosInsertados As Integer
        Try

            Dim cmd As New MySqlCommand("InsertarDetalleCLuz", Mod_D_Admin.ConexionDB.Conexion) With {.CommandType = CommandType.StoredProcedure}
            cmd.Parameters.AddWithValue("IdReg", argIdReg)
            cmd.Parameters.AddWithValue("Cat", argCategoria)
            cmd.Parameters.AddWithValue("KWC", argKWConsumo)
            RegistrosInsertados = cmd.ExecuteNonQuery()
            cmd.Dispose()
            Return RegistrosInsertados

        Catch Ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "InsertarRegistroConsumoLuz", Ex.Message))
            Return 0
        End Try

    End Function

End Class