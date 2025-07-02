Imports MySql.Data.MySqlClient
Imports SiCoFa.Entidades

Public Class D_AdminCajas

    Public Function CierreCajaTransaccion(ByVal argMacAddress As String, ByVal argCaja As Caja, ByVal argEmpresa As Empresa, ByVal argUsuario As Usuario, ByVal argComprobante As Comprobante) As Boolean

        Dim objConexionDB As New D_Conexion

        Using cn As MySqlConnection = objConexionDB.ObtenerConexion()

            Using tx As MySqlTransaction = cn.BeginTransaction()

                Try
                    Dim AdminOperaciones As New D_AdminOperaciones
                    Dim objTipoOperacion As TipoOperacion = AdminOperaciones.ObtenerTipoOperacionPorCodiTO("CIECA")
                    Dim objOperacion As Operacion = AdminOperaciones.IniciarOperacion(argEmpresa, argUsuario, objTipoOperacion, "", "INICIADO", cn, tx)

                    Dim AdminDB As New D_AdminDB
                    Dim sql As String = $"SELECT IdCB,Importe FROM ConMoviCajaPE WHERE IdCaja={argCaja.IdCaja} AND EstadoTransaccion='EN CAJA'"
                    Dim dTable As DataTable = AdminDB.ObtenerTabla(sql)

                    For Each row As DataRow In dTable.Rows
                        Dim idCB As Integer = Convert.ToInt32(row("IdCB"))
                        Dim importe As Decimal = Convert.ToDecimal(row("Importe"))

                        AdminOperaciones.InsertarOperacionCB(objOperacion.IdOperacion, idCB, importe, cn, tx)
                    Next

                    Dim AdminComprobantes As New D_AdminComprobantes
                    argComprobante.IdOperacion = objOperacion.IdOperacion
                    argComprobante.Operacion = objOperacion
                    AdminComprobantes.InsertarComprobante(argComprobante, cn, tx)

                    Dim AdminAsientoContable As New D_AdminAsientosContable
                    Dim objAsientoContable As New AsientoContable

                    With objAsientoContable
                        .InsertarItem("1.01.03.001", argComprobante.ImpPE)
                        .InsertarItem("1.03.02.001", -argComprobante.ImpPE)
                    End With

                    AdminAsientoContable.EfectuarAsientoContable(objOperacion, objAsientoContable, cn, tx)

                    Me.CerrarMediosPE(cn, tx)

                    AdminOperaciones.FinalizarOperacion(argMacAddress, objOperacion, True, cn, tx)

                    Me.CierreCaja(argCaja.NCaja, cn, tx)

                    objTipoOperacion = AdminOperaciones.ObtenerTipoOperacionPorCodiTO("APECA")
                    objOperacion = AdminOperaciones.IniciarOperacion(argEmpresa, argUsuario, objTipoOperacion, "", "INICIADO", cn, tx)

                    With argComprobante
                        .IdOperacion = objOperacion.IdOperacion
                        .Operacion = objOperacion
                        .ImpBto = .ImpEf
                        .ImpPE = 0
                        .ImpCC = 0
                    End With

                    AdminComprobantes.InsertarComprobante(argComprobante, cn, tx)
                    AdminOperaciones.FinalizarOperacion(argMacAddress, objOperacion, True, cn, tx)

                    tx.Commit()
                    Return True

                Catch ex As Exception
                    tx.Rollback()
                    Throw New Exception(Vecho.MensajeError(Me.ToString, "CierreCaja", ex.Message), ex)

                End Try

            End Using

        End Using

    End Function

    Friend Function CierreCaja(ByVal argNCaja As String, ByVal cn As MySqlConnection, ByVal tx As MySqlTransaction) As Long

        Dim IdCaja As Long
        Try

            Using cmd As New MySqlCommand("CajaCerrar", cn, tx) With {.CommandType = CommandType.StoredProcedure}
                With cmd.Parameters
                    .Add("p_NCaja", MySqlDbType.VarChar).Value = argNCaja
                    .Add("p_IdCaja", MySqlDbType.Int64)
                End With

                cmd.Parameters("p_IdCaja").Direction = ParameterDirection.Output
                cmd.ExecuteNonQuery()
                IdCaja = Convert.ToInt64(cmd.Parameters("p_IdCaja").Value)
            End Using

            Return IdCaja

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "CierreCaja", Ex.Message))

        End Try

    End Function

    Friend Function CerrarMediosPE(ByVal cn As MySqlConnection, ByVal tx As MySqlTransaction) As Boolean

        Try

            Dim sql As String = "UPDATE TblOperacionesPE SET EstadoTransaccion='CERRADO' WHERE EstadoTransaccion='EN CAJA'"

            Using cmd As New MySqlCommand(sql, cn, tx)
                Dim filasAfectadas As Int32 = cmd.ExecuteNonQuery()
                Return (filasAfectadas > 0) ' Devuelve True si se actualizó al menos una fila
            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "CerrarMediosPE", Ex.Message))
            Return False

        End Try

    End Function

    Public Function RetiroEfectivoCajaAbiertaTransaccion(ByVal argMacAddress As String, ByVal argEmpresa As Empresa, ByVal argUsuario As Usuario, ByVal argComprobante As Comprobante) As Boolean

        Dim objConexionDB As New D_Conexion

        Using cn As MySqlConnection = objConexionDB.ObtenerConexion()

            Using tx As MySqlTransaction = cn.BeginTransaction()

                Try
                    Dim AdminOperaciones As New D_AdminOperaciones
                    Dim objTipoOperacion As TipoOperacion = AdminOperaciones.ObtenerTipoOperacionPorCodiTO("REFCA")
                    Dim objOperacion As Operacion = AdminOperaciones.IniciarOperacion(argEmpresa, argUsuario, objTipoOperacion, "", "INICIADO", cn, tx)
                    Dim AdminComprobantes As New D_AdminComprobantes
                    argComprobante.IdOperacion = objOperacion.IdOperacion
                    argComprobante.Operacion = objOperacion
                    AdminComprobantes.InsertarComprobante(argComprobante, cn, tx)
                    AdminOperaciones.FinalizarOperacion(argMacAddress, objOperacion, True, cn, tx)

                    tx.Commit()
                    Return True

                Catch ex As Exception
                    tx.Rollback()
                    Throw New Exception(Vecho.MensajeError(Me.ToString, "CierreCaja", ex.Message), ex)

                End Try

            End Using

        End Using

    End Function

End Class
