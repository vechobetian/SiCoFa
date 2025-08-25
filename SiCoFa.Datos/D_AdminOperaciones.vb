Imports MySql.Data.MySqlClient
Imports SiCoFa.Entidades
Imports System.Collections.Generic

Public Class D_AdminOperaciones
    Public Function ObtenerTipoOperacionPorCodiTO(ByVal argCodiTO As String) As TipoOperacion

        Dim objConexionDB As New D_Conexion
        Dim objTO As TipoOperacion = Nothing

        Try
            Dim sql As String = "SELECT CodiTO,TipoOperacion,EfInv,AfectaCajaAbierta,EfFin FROM TblTipoOperaciones WHERE CodiTO=@CodiTO"

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql
                    cmd.Parameters.AddWithValue("@CodiTO", argCodiTO)

                    Using datos As MySqlDataReader = cmd.ExecuteReader()

                        If datos.Read() Then

                            objTO = New TipoOperacion(
                                                      datos.GetString("CodiTO"),
                                                      datos.GetString("TipoOperacion"),
                                                      Convert.ToInt16(datos("EfInv")),
                                                      Convert.ToBoolean(datos("AfectaCajaAbierta")),
                                                      Convert.ToInt16(datos("EfFin"))
                                                      )

                        End If

                    End Using

                End Using

            End Using

            Return objTO

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerTipoOperacionPorCodiTO", ex.Message))

        End Try

    End Function

    Public Function ListarTipoOperaciones() As List(Of TipoOperacion)
        Dim objConexionDB As New D_Conexion
        Dim lto As New List(Of TipoOperacion)
        Dim top As TipoOperacion

        Try

            Dim sql As String = "SELECT CodiTO,TipoOperacion,EfInv,AfectaCajaAbierta,EfFin FROM TblTipoOperaciones ORDER BY TipoOperacion"

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion
                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql

                    Using datos As MySqlDataReader = cmd.ExecuteReader()

                        If datos.HasRows Then
                            While datos.Read()
                                top = New TipoOperacion(datos.ToString("CodiTO"), datos.ToString("TipoOperacion"), Convert.ToInt16(datos("EfFin")), Convert.ToBoolean(datos("AfectaCajaAbierta")), Convert.ToInt16(datos("EfFin")))
                                lto.Add(top)
                            End While
                        Else
                            lto = Nothing
                        End If

                    End Using

                End Using
            End Using

            Return lto

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ListarTipoOperaciones", ex.Message))
            Return Nothing
        End Try

    End Function

    Public Function RegistrarError(ByVal argIdOpera As Long, ByVal argDescripcionError As String) As Integer
        Dim objConexionDB As New D_Conexion
        Dim RegAfectados As Integer = 0 ' Inicializar a 0

        Try
            ' **CRÍTICO: Usar parámetros SQL para evitar la inyección SQL**
            Dim sql As String = "UPDATE TblOperaciones SET EstadoOperacion='Error', DesError=@descripcionError WHERE IdOperacion=@idOperacion"

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand(sql, cn)
                    ' Agregar los parámetros
                    cmd.Parameters.AddWithValue("@descripcionError", argDescripcionError)
                    cmd.Parameters.AddWithValue("@idOperacion", argIdOpera)

                    RegAfectados = cmd.ExecuteNonQuery

                End Using

            End Using
        Catch Ex As Exception
            Return 0 ' Indica que no se pudo registrar el error en la BD.
        End Try
        Return RegAfectados
    End Function

    Public Function IniciarOperacion(ByVal argEmpresa As Empresa, ByVal argUsuario As Usuario, ByVal argTipoOperacion As TipoOperacion, ByVal argObservaciones As String, ByVal argEstadoOperacion As String) As Operacion

        Try
            Dim objConexionDB As New D_Conexion

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion
                Dim objOperacion As Operacion = IniciarOperacion(argEmpresa, argUsuario, argTipoOperacion, argObservaciones, argEstadoOperacion, cn, Nothing)
                Return objOperacion
            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "IniciarOperacion", Ex.Message))
        End Try

    End Function

    Friend Function IniciarOperacion(ByVal argEmpresa As Empresa, ByVal argUsuario As Usuario, ByVal argTipoOperacion As TipoOperacion, ByVal argObservaciones As String, ByVal argEstadoOperacion As String, ByVal cn As MySqlConnection, ByVal tx As MySqlTransaction) As Operacion

        Try

            Dim objOperacion As Operacion = Nothing

            Using cmd As New MySqlCommand("OperacionIniciar", cn, tx) With {.CommandType = CommandType.StoredProcedure}
                With cmd.Parameters
                    .Add("p_IdEmpresa", MySqlDbType.Int32).Value = argEmpresa.Id
                    .Add("p_IdUsuario", MySqlDbType.Int32).Value = argUsuario.Id
                    .Add("p_CodiTO", MySqlDbType.VarChar).Value = argTipoOperacion.CodiTO
                    .Add("p_Observaciones", MySqlDbType.Text).Value = argObservaciones
                    .Add("p_EstadoOperacion", MySqlDbType.VarChar, 15).Value = argEstadoOperacion
                    .Add("p_IdOperacion", MySqlDbType.Int64)

                End With

                cmd.Parameters("p_IdOperacion").Direction = ParameterDirection.Output
                cmd.ExecuteNonQuery()

                Dim IdOperacion As Long = CLng(cmd.Parameters("p_IdOperacion").Value)

                If IdOperacion > 0 Then
                    objOperacion = New Operacion(
                                                     argIdOperacion:=IdOperacion,
                                                     argInicio:=Now,
                                                     argFin:=Now,
                                                     argEmpresa:=argEmpresa,
                                                     argIdPC:=0,
                                                     argIdCaja:=0,
                                                     argUsuario:=argUsuario,
                                                     argTipoOperacion:=argTipoOperacion,
                                                     argEstadoOperacion:=argEstadoOperacion,
                                                     argObservaciones:=Convert.ToString(argObservaciones),
                                                     argDesError:=""
                                                     )

                End If

            End Using

            Return objOperacion

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "IniciarOperacion", Ex.Message))

        End Try

    End Function

    Public Function ActualizarOperacion(ByVal argOperacion As Operacion) As Boolean
        Try
            Dim objConexionDB As New D_Conexion
            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("OperacionActualizar", cn) With {.CommandType = CommandType.StoredProcedure}
                    With cmd.Parameters
                        .Add("p_IdOperacion", MySqlDbType.Int64).Value = argOperacion.IdOperacion
                        .Add("p_Inicio", MySqlDbType.DateTime).Value = argOperacion.Inicio
                        .Add("p_Observaciones", MySqlDbType.Text).Value = argOperacion.Observaciones
                        .Add("p_EstadoOperacion", MySqlDbType.VarChar, 15).Value = argOperacion.EstadoOperacion
                    End With

                    Dim filasAfectadas As Int32 = cmd.ExecuteNonQuery()
                    Return (filasAfectadas > 0) ' Devuelve True si se actualizó al menos una fila

                End Using

            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ActualizarOperacion", Ex.Message))
            Return False

        End Try

    End Function

    Public Function FinalizarOperacion(ByVal argMacAddress As String, ByVal argOperacion As Operacion, ByVal argCajaAbierta As Boolean) As Boolean
        Try
            Dim objConexionDB As New D_Conexion

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion
                Return FinalizarOperacion(argMacAddress, argOperacion, argCajaAbierta, cn, Nothing)
            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "FinalizarOperacion", Ex.Message))
        End Try

    End Function

    Friend Function FinalizarOperacion(ByVal argMacAddress As String, ByVal argOperacion As Operacion, ByVal argCajaAbierta As Boolean, ByVal cn As MySqlConnection, ByVal tx As MySqlTransaction) As Boolean
        Try

            Using cmd As New MySqlCommand("OperacionFinalizar", cn, tx) With {.CommandType = CommandType.StoredProcedure}
                With cmd.Parameters
                    .Add("p_MacAddress", MySqlDbType.VarChar).Value = argMacAddress
                    .Add("p_Observaciones", MySqlDbType.VarChar).Value = argOperacion.Observaciones
                    .Add("p_IdOperacion", MySqlDbType.Int64).Value = argOperacion.IdOperacion
                    .Add("p_CajaAbierta", MySqlDbType.Bit).Value = argCajaAbierta
                End With

                Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()
                Return (filasAfectadas > 0) ' Devuelve True si se actualizó al menos una fila

            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "IniciarOperacion", Ex.Message))

        End Try
    End Function

    Public Function ObtenerOperacion(ByVal argIdOperacion As Long) As Operacion
        Dim objConexionDB As New D_Conexion
        Dim objOpera As Operacion = Nothing

        Try

            Dim sql As String = "SELECT IdOperacion,Inicio,Fin,IdEmpresa,IdPC,IdCaja,IdUsuario,CodiTO,EstadoOperacion,Observaciones,DesError FROM TblOperaciones WHERE IdOperacion=@IdOperacion"

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql
                    cmd.Parameters.AddWithValue("@IdOperacion", argIdOperacion)

                    Using datos As MySqlDataReader = cmd.ExecuteReader()

                        If datos.Read() Then
                            ' Obtener valores manejando posibles DBNull
                            Dim idOperacion As Long = datos.GetInt64("IdOperacion")
                            Dim inicio As DateTime = datos.GetDateTime("Inicio")
                            Dim fin As DateTime = If(datos.IsDBNull(datos.GetOrdinal("Fin")), Now, datos.GetDateTime("Fin"))
                            Dim idPC As String = datos.GetString("IdPC")
                            Dim idCaja As Integer = datos.GetInt32("IdCaja")
                            Dim codiTO As String = datos.GetString("CodiTO")
                            Dim estado As String = datos.GetString("EstadoOperacion")
                            Dim observaciones As String = datos.GetString("Observaciones")
                            Dim desError As String = If(datos.IsDBNull(datos.GetOrdinal("DesError")), "", datos.GetString("DesError"))

                            'Dim objEmpresa As Empresa = Me.ObtenerEmpresaPorId(datos.GetInt32("IdEmpresa"))
                            'Dim objUsuario As Usuario = Me.ObtenerUsuarioPorId(datos.GetInt32("IdUsuario"))
                            Dim objTOp As TipoOperacion = Me.ObtenerTipoOperacionPorCodiTO(codiTO)

                            ' Si luego vas a completar Empresa, Usuario, TipoOperacion, lo dejás en Nothing o los instanciás aparte.
                            objOpera = New Operacion(idOperacion, inicio, fin, Nothing, idPC, idCaja, Nothing, objTOp, estado, observaciones, desError)
                        End If

                    End Using

                End Using
            End Using

            Return objOpera

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerOperacion", ex.Message))
            Return Nothing
        End Try

    End Function

    Public Function ObtenerOperacionCL(ByVal argIdOperacion As Long) As Cliente
        Dim objConexionDB As New D_Conexion
        Dim objCliente As Cliente = Nothing

        Try

            Dim sql As String = "SELECT IdOperacion,IdCliente FROM TblOperacionesCL WHERE IdOperacion=@IdOperacion"

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql
                    cmd.Parameters.AddWithValue("@IdOperacion", argIdOperacion)


                    Using datos As MySqlDataReader = cmd.ExecuteReader()

                        If datos.Read() Then
                            Dim idOperacion As Long = datos.GetInt64("IdOperacion")
                            Dim idCliente As Int32 = datos.GetInt32("IdCliente")
                            Dim AdminClientes As New D_AdminClientes
                            objCliente = AdminClientes.ObtenerClientePorId(idCliente)
                        End If

                    End Using

                End Using

            End Using

            Return objCliente

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerOperacionCL", ex.Message))
            Return Nothing
        End Try

    End Function

    Public Function InsertarOperacionCB(ByVal argIdOperacion As Long, ByVal argIdCB As Int32, ByVal argImporte As Decimal) As Boolean
        Try
            Dim objConexionDB As New D_Conexion

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion
                Return InsertarOperacionCB(argIdOperacion, argIdCB, argImporte, cn, Nothing)
            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarOperacionCB", Ex.Message))
        End Try
    End Function

    Friend Function InsertarOperacionCB(ByVal argIdOperacion As Long, ByVal argIdCB As Int32, ByVal argImporte As Decimal, ByVal cn As MySqlConnection, ByVal tx As MySqlTransaction) As Boolean

        Try

            Using cmd As New MySqlCommand("OperacionCBInsertar", cn, tx) With {.CommandType = CommandType.StoredProcedure}

                With cmd.Parameters
                    .Add("p_IdOperacion", MySqlDbType.Int64).Value = argIdOperacion
                    .Add("p_IdCB", MySqlDbType.Int32).Value = argIdCB
                    .Add("p_Importe", MySqlDbType.Decimal).Value = argImporte
                End With

                Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()
                Return (filasAfectadas > 0) ' Devuelve True si se actualizó al menos una fila

            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarOperacionCB", Ex.Message))

        End Try

    End Function

    Public Function InsertarOperacionCL(ByVal argIdOperacion As Long, ByVal argIdCliente As Int32) As Boolean
        Try
            Dim objConexionDB As New D_Conexion

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion
                Return InsertarOperacionCL(argIdOperacion, argIdCliente, cn, Nothing)
            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarOperacionCL", Ex.Message))
        End Try
    End Function

    Friend Function InsertarOperacionCL(ByVal argIdOperacion As Long, ByVal argIdCliente As Int32, ByVal cn As MySqlConnection, ByVal tx As MySqlTransaction) As Boolean

        Try
            Dim objConexionDB As New D_Conexion

            Using cmd As New MySqlCommand("OperacionCLInsertar", cn, tx) With {.CommandType = CommandType.StoredProcedure}
                With cmd.Parameters
                    .Add("p_IdOperacion", MySqlDbType.Int64).Value = argIdOperacion
                    .Add("p_IdCliente", MySqlDbType.Int32).Value = argIdCliente
                End With

                Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()
                Return (filasAfectadas > 0) ' Devuelve True si se actualizó al menos una fila

            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarOperacionCL", Ex.Message))

        End Try

    End Function

    Public Function ActualizarOperacionCL(ByVal argIdOperacion As Long, ByVal argIdCliente As Int32) As Boolean
        Try
            Dim objConexionDB As New D_Conexion

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("OperacionCLActualizar", cn) With {.CommandType = CommandType.StoredProcedure}
                    With cmd.Parameters
                        .Add("p_IdOperacion", MySqlDbType.Int64).Value = argIdOperacion
                        .Add("p_IdCliente", MySqlDbType.Int32).Value = argIdCliente
                    End With

                    Dim filasAfectadas As Int32 = cmd.ExecuteNonQuery()
                    Return (filasAfectadas > 0) ' Devuelve True si se actualizó al menos una fila

                End Using

            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ActualizarOperacionCL", Ex.Message))
            Return False

        End Try

    End Function

    Public Function InsertarOperacionCC(ByVal argIdOperacion As Long, ByVal argIdCC As Int32, ByVal argImporte As Decimal) As Boolean
        Try
            Dim objConexionDB As New D_Conexion

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion
                Return InsertarOperacionCC(argIdOperacion, argIdCC, argImporte, cn, Nothing)
            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarOperacionCC", Ex.Message))
        End Try
    End Function

    Friend Function InsertarOperacionCC(ByVal argIdOperacion As Long, ByVal argIdCC As Int32, ByVal argImporte As Decimal, ByVal cn As MySqlConnection, ByVal tx As MySqlTransaction) As Boolean

        Try

            Using cmd As New MySqlCommand("OperacionCCInsertar", cn, tx) With {.CommandType = CommandType.StoredProcedure}

                With cmd.Parameters
                    .Add("p_IdOperacion", MySqlDbType.Int64).Value = argIdOperacion
                    .Add("p_IdCC", MySqlDbType.Int32).Value = argIdCC
                    .Add("p_Importe", MySqlDbType.Decimal).Value = argImporte
                End With

                Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()
                Return (filasAfectadas > 0) ' Devuelve True si se actualizó al menos una fila

            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarOperacionCC", Ex.Message))

        End Try

    End Function

    Friend Function InsertarOperacionCP(ByVal argIdOperacion As Long, ByVal argIdProveedor As Int32, ByVal argImporte As Decimal, ByVal argEstado As String, ByVal cn As MySqlConnection, ByVal tx As MySqlTransaction) As Boolean

        Try

            Using cmd As New MySqlCommand("OperacionCPInsertar", cn, tx) With {.CommandType = CommandType.StoredProcedure}

                With cmd.Parameters
                    .Add("p_IdOperacion", MySqlDbType.Int64).Value = argIdOperacion
                    .Add("p_IdProveedor", MySqlDbType.Int32).Value = argIdProveedor
                    .Add("p_Importe", MySqlDbType.Decimal).Value = argImporte
                    .Add("p_EstadoOperacionCP", MySqlDbType.VarChar).Value = argEstado
                End With

                Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()
                Return (filasAfectadas > 0) ' Devuelve True si se actualizó al menos una fila

            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarOperacionCP", Ex.Message))

        End Try

    End Function

    Public Function InsertarOperacionPE(ByVal argIdOperacion As Long, ByVal argIdCC As Int32, ByVal argImporte As Decimal) As Boolean
        Try
            Dim objConexionDB As New D_Conexion

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion
                Return InsertarOperacionPE(argIdOperacion, argIdCC, argImporte, cn, Nothing)
            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarOperacionPE", Ex.Message))
        End Try
    End Function

    Friend Function InsertarOperacionPE(ByVal argIdOperacion As Long, ByVal argIdMPE As Int32, ByVal argImporte As Decimal, ByVal cn As MySqlConnection, ByVal tx As MySqlTransaction) As Boolean

        Try

            Using cmd As New MySqlCommand("OperacionPEInsertar", cn, tx) With {.CommandType = CommandType.StoredProcedure}
                With cmd.Parameters
                    .Add("p_IdOperacion", MySqlDbType.Int64).Value = argIdOperacion
                    .Add("p_IdMPE", MySqlDbType.Int32).Value = argIdMPE
                    .Add("p_Importe", MySqlDbType.Decimal).Value = argImporte
                End With

                Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()
                Return (filasAfectadas > 0) ' Devuelve True si se actualizó al menos una fila

            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarOperacionPE", Ex.Message))

        End Try

    End Function

    Friend Function AnularOperacionPE(ByVal argIdOperacion As Long, ByVal cn As MySqlConnection, ByVal tx As MySqlTransaction) As Boolean

        Try

            Dim sql As String = "UPDATE TblOperacionesPE SET EstadoTransaccion = 'ANULADO' WHERE IdOperacion = @IdOperacion"

            Using cmd As New MySqlCommand(sql, cn, tx)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@IdOperacion", argIdOperacion)

                Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()
                Return (filasAfectadas > 0) ' Devuelve True si se actualizó al menos una fila
            End Using


        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarOperacionPE", Ex.Message))

        End Try

    End Function

    Public Function FinalizarVentaTransaccion(ByVal argMacAddress As String, ByVal argOperacion As Operacion, ByVal argOperacionCC As OperacionCC, ByVal argOperacionPE As OperacionPE, ByRef argComprobante As Comprobante, ByVal argAsiento As AsientoContable) As Boolean

        Dim objConexionDB As New D_Conexion

        Using cn As MySqlConnection = objConexionDB.ObtenerConexion()

            Using tx As MySqlTransaction = cn.BeginTransaction()

                Try

                    If argOperacionCC IsNot Nothing Then
                        Me.InsertarOperacionCC(argOperacionCC.IdOperacion, argOperacionCC.IdCC, argOperacionCC.Importe, cn, tx)
                    End If

                    If argOperacionPE IsNot Nothing Then
                        Me.InsertarOperacionPE(argOperacionPE.IdOperacion, argOperacionPE.IdMPE, argOperacionPE.Importe, cn, tx)
                    End If

                    Dim AdminComprobantes As New D_AdminComprobantes
                    AdminComprobantes.EmitirComprobante(argComprobante, cn, tx)

                    Dim AdminAsientoContable As New D_AdminAsientosContable
                    AdminAsientoContable.EfectuarAsientoContable(argOperacion, argAsiento, cn, tx)

                    Dim AdminArticulos As New D_AdminArticulos
                    AdminArticulos.ActualizarStock(argOperacion.IdOperacion, -1, cn, tx)

                    Me.FinalizarOperacion(argMacAddress, argOperacion, True, cn, tx)

                    tx.Commit()
                    Return True

                Catch ex As Exception
                    tx.Rollback()
                    Throw New Exception(Vecho.MensajeError(Me.ToString, "FinalizarVentaTransaccion", ex.Message), ex)

                End Try

            End Using

        End Using

    End Function

    Public Function FinalizarPresupuestoTransaccion(ByVal argMacAddress As String, ByVal argOperacion As Operacion, ByRef argComprobante As Comprobante) As Boolean

        Dim objConexionDB As New D_Conexion

        Using cn As MySqlConnection = objConexionDB.ObtenerConexion()

            Using tx As MySqlTransaction = cn.BeginTransaction()

                Try

                    Dim AdminComprobantes As New D_AdminComprobantes
                    AdminComprobantes.EmitirComprobante(argComprobante, cn, tx)

                    Me.FinalizarOperacion(argMacAddress, argOperacion, True, cn, tx)

                    tx.Commit()
                    Return True

                Catch ex As Exception
                    tx.Rollback()
                    Throw New Exception(Vecho.MensajeError(Me.ToString, "FinalizarPresupuestoTransaccion", ex.Message), ex)

                End Try

            End Using

        End Using

    End Function

    Public Function AsientoGastoTransaccion(ByVal argCajaAbierta As Boolean, ByVal argMacAddress As String, ByVal argEmpresa As Empresa, ByVal argUsuario As Usuario, ByVal argOperacionCP As OperacionCP, ByVal argOperacionCB As OperacionCB, ByRef argComprobante As Comprobante, ByVal argAsiento As AsientoContable, ByVal argObservacion As String) As Boolean

        Dim objConexionDB As New D_Conexion

        Using cn As MySqlConnection = objConexionDB.ObtenerConexion()

            Using tx As MySqlTransaction = cn.BeginTransaction()

                Try
                    Dim AdminOperaciones As New D_AdminOperaciones
                    Dim objTipoOperacion As TipoOperacion = AdminOperaciones.ObtenerTipoOperacionPorCodiTO("ASGAS")
                    Dim objOperacion As Operacion = AdminOperaciones.IniciarOperacion(argEmpresa, argUsuario, objTipoOperacion, argObservacion, "INICIADO", cn, tx)

                    Me.InsertarOperacionCP(objOperacion.IdOperacion, argOperacionCP.IdProveedor, argOperacionCP.Importe, argOperacionCP.EstadoOperacionCP, cn, tx)

                    If argOperacionCB IsNot Nothing Then
                        Me.InsertarOperacionCB(objOperacion.IdOperacion, argOperacionCB.IdCB, argOperacionCB.Importe, cn, tx)
                    End If

                    Dim AdminComprobantes As New D_AdminComprobantes
                    argComprobante.Operacion = objOperacion
                    AdminComprobantes.RecibirComprobante(argComprobante, cn, tx)

                    Dim AdminAsientoContable As New D_AdminAsientosContable
                    AdminAsientoContable.EfectuarAsientoContable(objOperacion, argAsiento, cn, tx)

                    Me.FinalizarOperacion(argMacAddress, objOperacion, argCajaAbierta, cn, tx)

                    tx.Commit()
                    Return True

                Catch ex As Exception
                    tx.Rollback()
                    Throw New Exception(Vecho.MensajeError(Me.ToString, "FinalizarOperacionConTransaccion", ex.Message), ex)

                End Try

            End Using

        End Using

    End Function

    Public Function FinalizarCompraTransaccion(ByVal argCajaAbierta As Boolean, ByVal argMacAddress As String, ByVal argOperacion As Operacion, ByVal argOperacionCP As OperacionCP, ByVal argOperacionCB As OperacionCB, ByRef argComprobante As Comprobante, ByVal argAsiento As AsientoContable, ByVal argObservacion As String) As Boolean

        Dim objConexionDB As New D_Conexion

        Using cn As MySqlConnection = objConexionDB.ObtenerConexion()

            Using tx As MySqlTransaction = cn.BeginTransaction()

                Try

                    Me.InsertarOperacionCP(argOperacion.IdOperacion, argOperacionCP.IdProveedor, argOperacionCP.Importe, argOperacionCP.EstadoOperacionCP, cn, tx)

                    If argOperacionCB IsNot Nothing Then
                        Me.InsertarOperacionCB(argOperacion.IdOperacion, argOperacionCB.IdCB, argOperacionCB.Importe, cn, tx)
                    End If

                    Dim AdminComprobantes As New D_AdminComprobantes
                    argComprobante.Operacion = argOperacion
                    AdminComprobantes.RecibirComprobante(argComprobante, cn, tx)

                    Dim AdminAsientoContable As New D_AdminAsientosContable
                    AdminAsientoContable.EfectuarAsientoContable(argOperacion, argAsiento, cn, tx)

                    Dim AdminArticulos As New D_AdminArticulos
                    AdminArticulos.ActualizarStock(argOperacion.IdOperacion, 1, cn, tx)

                    Me.FinalizarOperacion(argMacAddress, argOperacion, argCajaAbierta, cn, tx)

                    tx.Commit()
                    Return True

                Catch ex As Exception
                    tx.Rollback()
                    Throw New Exception(Vecho.MensajeError(Me.ToString, "FinalizarOperacionConTransaccion", ex.Message), ex)

                End Try

            End Using

        End Using

    End Function

    Public Function NotaCreditoTransaccion(ByVal argTipoOperacion As TipoOperacion, ByVal argMacAddress As String, ByVal argEmpresa As Empresa, ByVal argUsuario As Usuario, ByVal argOperacionCC As OperacionCC, ByVal argOperacionPE As OperacionPE, ByRef argComprobante As Comprobante, ByVal argAsiento As AsientoContable, ByVal argObservacion As String) As Boolean

        Dim objConexionDB As New D_Conexion

        Using cn As MySqlConnection = objConexionDB.ObtenerConexion()

            Using tx As MySqlTransaction = cn.BeginTransaction()

                Try
                    Dim AdminOperaciones As New D_AdminOperaciones
                    Dim objOperacion As Operacion = AdminOperaciones.IniciarOperacion(argEmpresa, argUsuario, argTipoOperacion, argObservacion, "INICIADO", cn, tx)

                    Dim AdminItems As New D_AdminItemsComprobante

                    For Each i As ItemComprobante In argComprobante.Detalle
                        AdminItems.InsertarItemComprobanteNC(objOperacion.IdOperacion, i, cn, tx)
                    Next

                    Me.InsertarOperacionCL(objOperacion.IdOperacion, argComprobante.IdCliente, cn, tx)

                    If argOperacionCC IsNot Nothing Then
                        Me.InsertarOperacionCC(objOperacion.IdOperacion, argOperacionCC.IdCC, argOperacionCC.Importe, cn, tx)
                    End If

                    If argOperacionPE IsNot Nothing Then
                        Me.InsertarOperacionPE(objOperacion.IdOperacion, argOperacionPE.IdMPE, argOperacionPE.Importe, cn, tx)
                    End If

                    Dim AdminComprobantes As New D_AdminComprobantes
                    argComprobante.IdOperacion = objOperacion.IdOperacion
                    argComprobante.Operacion = objOperacion
                    AdminComprobantes.EmitirComprobante(argComprobante, cn, tx)

                    Dim AdminAsientoContable As New D_AdminAsientosContable
                    AdminAsientoContable.EfectuarAsientoContable(objOperacion, argAsiento, cn, tx)

                    Dim AdminArticulos As New D_AdminArticulos
                    AdminArticulos.ActualizarStock(objOperacion.IdOperacion, 1, cn, tx)

                    Me.FinalizarOperacion(argMacAddress, objOperacion, True, cn, tx)

                    tx.Commit()
                    Return True

                Catch ex As Exception
                    tx.Rollback()
                    Throw New Exception(Vecho.MensajeError(Me.ToString, "FinalizarNCTransaccion", ex.Message), ex)

                End Try

            End Using

        End Using

    End Function

    Public Function FacturacionRemitoTransaccion(ByVal argMacAddress As String, ByVal argEmpresa As Empresa, ByVal argUsuario As Usuario, ByRef argComprobante As Comprobante, ByVal argObservacion As String) As Boolean

        Dim objConexionDB As New D_Conexion

        Using cn As MySqlConnection = objConexionDB.ObtenerConexion()

            Using tx As MySqlTransaction = cn.BeginTransaction()

                Try
                    Dim AdminOperaciones As New D_AdminOperaciones
                    Dim objTOperacion As TipoOperacion = AdminOperaciones.ObtenerTipoOperacionPorCodiTO("FACR")
                    Dim objOperacion As Operacion = AdminOperaciones.IniciarOperacion(argEmpresa, argUsuario, objTOperacion, argObservacion, "INICIADO", cn, tx)

                    Dim AdminItems As New D_AdminItemsComprobante

                    For Each i As ItemComprobante In argComprobante.Detalle
                        AdminItems.InsertarItemComprobante(objOperacion.IdOperacion, i, cn, tx)
                    Next

                    Me.InsertarOperacionCL(objOperacion.IdOperacion, argComprobante.IdCliente, cn, tx)

                    Dim AdminComprobantes As New D_AdminComprobantes
                    argComprobante.IdOperacion = objOperacion.IdOperacion
                    argComprobante.Operacion = objOperacion

                    AdminComprobantes.EmitirComprobante(argComprobante, cn, tx)

                    Me.FinalizarOperacion(argMacAddress, objOperacion, True, cn, tx)

                    tx.Commit()
                    Return True

                Catch ex As Exception
                    tx.Rollback()
                    Throw New Exception(Vecho.MensajeError(Me.ToString, "FinalizarNCTransaccion", ex.Message), ex)

                End Try

            End Using

        End Using

    End Function

    Public Function OperacionCCTransaccion(ByVal argMacAddress As String, ByVal argEmpresa As Empresa, ByVal argUsuario As Usuario, ByVal argOperacion As Operacion, ByVal argOperacionPE As OperacionPE, ByRef argComprobante As Comprobante, ByVal argObservacion As String) As Boolean
        Dim objConexionDB As New D_Conexion

        Using cn As MySqlConnection = objConexionDB.ObtenerConexion()

            Using tx As MySqlTransaction = cn.BeginTransaction()

                Try
                    Dim AdminOperaciones As New D_AdminOperaciones
                    Dim objOperacion As Operacion = AdminOperaciones.IniciarOperacion(argEmpresa, argUsuario, argOperacion.TipoOperacion, argObservacion, "INICIADO", cn, tx)

                    If argOperacionPE IsNot Nothing Then
                        Me.InsertarOperacionPE(objOperacion.IdOperacion, argOperacionPE.IdMPE, argOperacionPE.Importe, cn, tx)
                    End If

                    Me.InsertarOperacionCC(objOperacion.IdOperacion, argComprobante.Cliente.CuentaCorriente.IdCC, argComprobante.ImpBto, cn, tx)

                    Dim AdminComprobantes As New D_AdminComprobantes
                    argComprobante.IdOperacion = objOperacion.IdOperacion
                    argComprobante.Operacion = objOperacion

                    AdminComprobantes.EmitirComprobante(argComprobante, cn, tx)

                    Me.FinalizarOperacion(argMacAddress, objOperacion, True, cn, tx)

                    tx.Commit()
                    Return True

                Catch ex As Exception
                    tx.Rollback()
                    Throw New Exception(Vecho.MensajeError(Me.ToString, "OperacionCCTransaccion", ex.Message), ex)

                End Try

            End Using

        End Using

    End Function

End Class
