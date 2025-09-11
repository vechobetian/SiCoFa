Imports SiCoFa.Datos
Imports SiCoFa.Entidades

Public Class N_AdminOperaciones

    Public Function ObtenerTipoOperacionPorCodiTO(ByVal argCodiTO As String) As TipoOperacion

        Dim objTO As TipoOperacion = Nothing

        Try
            Dim AdminOperaciones As New D_AdminOperaciones
            objTO = AdminOperaciones.ObtenerTipoOperacionPorCodiTO(argCodiTO)
            Return objTO

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerEmpresaPorId", ex.Message))

        End Try

    End Function

    Public Function RegistrarError(ByVal argIdOperacion As Long, argDescripcionError As String) As Integer

        Dim AdminOperaciones As New D_AdminOperaciones
        Dim RegAfectados As Integer

        Try
            RegAfectados = AdminOperaciones.RegistrarError(argIdOperacion, argDescripcionError)
            Return RegAfectados
        Catch ex As Exception
            MsgBox(Vecho.MensajeError(Me.ToString, "RegistrarError", ex.Message))
            Return 0
        End Try
    End Function

    Public Function IniciarOperacion(ByVal argEmpresa As Empresa, ByVal argUsuario As Usuario, ByVal argTipoOperacion As TipoOperacion, ByVal argObservaciones As String, ByVal argEstadoOperacion As String) As Operacion


        Try

            Dim AdminOperaciones As New D_AdminOperaciones
            Dim objOperacion = AdminOperaciones.IniciarOperacion(
                                                                  argEmpresa:=argEmpresa,
                                                                  argUsuario:=argUsuario,
                                                                  argTipoOperacion:=argTipoOperacion,
                                                                  argObservaciones,
                                                                  argEstadoOperacion
                                                                  )
            Return objOperacion

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "IniciarOperacion", ex.Message))
            Return Nothing
        End Try

    End Function

    Public Function ActualizarOperacion(ByVal argOperacion As Operacion) As Boolean
        Try

            Dim AdminOperaciones As New D_AdminOperaciones
            Dim Actualizado As Boolean = AdminOperaciones.ActualizarOperacion(argOperacion)

            Return Actualizado

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ActualizarOperacion", ex.Message))
            Return False

        End Try

    End Function

    Public Function FinalizarOperacion(ByVal argMacAddress As String, ByVal argOperacion As Operacion, ByVal argCajaAbierta As Boolean) As Boolean

        Try

            Dim AdminOperaciones As New D_AdminOperaciones
            Dim Actualizado As Boolean = AdminOperaciones.FinalizarOperacion(
                                                                             argMacAddress:=argMacAddress,
                                                                             argOperacion:=argOperacion,
                                                                             argCajaAbierta:=argCajaAbierta
                                                                             )

            Return Actualizado

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "FinalizarOperacion", ex.Message))
            Return False
        End Try

    End Function

    Public Function ObtenerOperacion(ByVal argIdOpera As Long) As Operacion

        Try

            Dim AdminOperaciones As New D_AdminOperaciones
            Dim objOpera As Operacion = AdminOperaciones.ObtenerOperacion(argIdOpera)
            Return objOpera

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerOperacion", ex.Message))
            Return Nothing
        End Try

    End Function

    Public Function ObtenerOperacionCL(ByVal argIdOpera As Long) As Cliente

        Try

            Dim AdminOperaciones As New D_AdminOperaciones
            Dim objCliente As Cliente = AdminOperaciones.ObtenerOperacionCL(argIdOpera)
            Return objCliente

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerOperacionCL", ex.Message))
            Return Nothing
        End Try

    End Function

    Public Function InsertarOperacionCL(ByVal argIdOperacion As Long, ByVal argIdCliente As Int32) As Boolean
        Try

            Dim AdminOperaciones As New D_AdminOperaciones
            Dim Insertado As Boolean = AdminOperaciones.InsertarOperacionCL(argIdOperacion, argIdCliente)

            Return Insertado

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarOperacionCL", ex.Message))
            Return False

        End Try

    End Function

    Public Function ActualizarOperacionCL(ByVal argIdOperacion As Long, ByVal argIdCliente As Int32) As Boolean
        Try

            Dim AdminOperaciones As New D_AdminOperaciones
            Dim Actualizado As Boolean = AdminOperaciones.ActualizarOperacionCL(argIdOperacion, argIdCliente)

            Return Actualizado

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ActualizarOperacionCL", ex.Message))
            Return False

        End Try

    End Function

    Public Function InsertarOperacionCC(ByVal argIdOperacion As Long, ByVal argIdCC As Int32, ByVal argResu As String, ByVal argImporte As Decimal, ByVal argEstadoOperacionCC As String, ByVal argIdOperaCancel As Int64) As Boolean

        Try

            Dim AdminOperaciones As New D_AdminOperaciones
            Dim Insertado As Boolean = AdminOperaciones.InsertarOperacionCC(argIdOperacion, argIdCC, argResu, argImporte, argEstadoOperacionCC, argIdOperaCancel)

            Return Insertado

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarOperacionCC", Ex.Message))

        End Try

    End Function

    Public Function InsertarOperacionPE(ByVal argIdOperacion As Long, ByVal argIdMPE As Int32, ByVal argImporte As Decimal) As Boolean

        Try

            Dim AdminOperaciones As New D_AdminOperaciones
            Dim Insertado As Boolean = AdminOperaciones.InsertarOperacionPE(argIdOperacion, argIdMPE, argImporte)

            Return Insertado

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarOperacionPE", Ex.Message))

        End Try

    End Function

    Public Function FinalizarVentaTransaccion(ByVal argMacAddress As String, ByVal argOperacion As Operacion, ByVal argOperacionCC As OperacionCC, ByVal argOperacionPE As OperacionPE, ByRef argComprobante As Comprobante, ByVal argAsiento As AsientoContable) As Boolean

        Try

            Dim AdminOperaciones As New D_AdminOperaciones
            Dim Finalizado As Boolean = AdminOperaciones.FinalizarVentaTransaccion(argMacAddress, argOperacion, argOperacionCC, argOperacionPE, argComprobante, argAsiento)
            Return Finalizado

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "FinalizarVentaTransaccion", ex.Message))

        End Try

    End Function

    Public Function FinalizarPresupuestoTransaccion(ByVal argMacAddress As String, ByVal argOperacion As Operacion, ByRef argComprobante As Comprobante) As Boolean

        Try

            Dim AdminOperaciones As New D_AdminOperaciones
            Dim Finalizado As Boolean = AdminOperaciones.FinalizarPresupuestoTransaccion(argMacAddress, argOperacion, argComprobante)
            Return Finalizado

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "FinalizarPresupuestoTransaccion", ex.Message))

        End Try

    End Function

    Public Function AsientoGastoTransaccion(ByVal argCajaAbierta As Boolean, ByVal argMacAddress As String, ByVal argEmpresa As Empresa, ByVal argUsuario As Usuario, ByVal argOperacionCP As OperacionCP, ByVal argOperacionCB As OperacionCB, ByRef argComprobante As Comprobante, ByVal argAsiento As AsientoContable, ByVal argObservacion As String) As Boolean

        Try

            Dim AdminOperaciones As New D_AdminOperaciones
            Dim Finalizado As Boolean = AdminOperaciones.AsientoGastoTransaccion(argCajaAbierta, argMacAddress, argEmpresa, argUsuario, argOperacionCP, argOperacionCB, argComprobante, argAsiento, argObservacion)
            Return Finalizado

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "FinalizarOperacionConTransaccion", ex.Message))

        End Try

    End Function

    Public Function FinalizarCompraTransaccion(ByVal argCajaAbierta As Boolean, ByVal argMacAddress As String, ByVal argOperacion As Operacion, ByVal argOperacionCP As OperacionCP, ByVal argOperacionCB As OperacionCB, ByRef argComprobante As Comprobante, ByVal argAsiento As AsientoContable, ByVal argObservacion As String) As Boolean
        Try

            Dim AdminOperaciones As New D_AdminOperaciones
            Dim Finalizado As Boolean = AdminOperaciones.FinalizarCompraTransaccion(argCajaAbierta, argMacAddress, argOperacion, argOperacionCP, argOperacionCB, argComprobante, argAsiento, argObservacion)
            Return Finalizado

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "FinalizarOperacionConTransaccion", ex.Message))

        End Try

    End Function

    Public Function NotaCreditoTransaccion(ByVal argTipoOperacion As TipoOperacion, ByVal argMacAddress As String, ByVal argEmpresa As Empresa, ByVal argUsuario As Usuario, ByVal argOperacionCC As OperacionCC, ByVal argOperacionPE As OperacionPE, ByRef argComprobante As Comprobante, ByVal argAsiento As AsientoContable, ByVal argObservacion As String) As Boolean
        Try

            Dim AdminOperaciones As New D_AdminOperaciones
            Dim Finalizado As Boolean = AdminOperaciones.NotaCreditoTransaccion(argTipoOperacion, argMacAddress, argEmpresa, argUsuario, argOperacionCC, argOperacionPE, argComprobante, argAsiento, argObservacion)
            Return Finalizado

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "FinalizarOperacionConTransaccion", ex.Message))

        End Try

    End Function

    Public Function FacturacionRemitoTransaccion(ByVal argMacAddress As String, ByVal argEmpresa As Empresa, ByVal argUsuario As Usuario, ByRef argComprobante As Comprobante, ByVal argObservacion As String) As Boolean

        Try

            Dim AdminOperaciones As New D_AdminOperaciones
            Dim Finalizado As Boolean = AdminOperaciones.FacturacionRemitoTransaccion(argMacAddress, argEmpresa, argUsuario, argComprobante, argObservacion)
            Return Finalizado

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "FinalizarOperacionConTransaccion", ex.Message))

        End Try

    End Function

    Public Function OperacionCCTransaccion(ByVal argMacAddress As String, ByVal argEmpresa As Empresa, ByVal argUsuario As Usuario, ByVal argOperacion As Operacion, ByVal argOperacionCC As OperacionCC, ByVal argOperacionPE As OperacionPE, ByRef argComprobante As Comprobante, ByVal argAsiento As AsientoContable, ByVal argObservacion As String) As Boolean
        Try

            Dim AdminOperaciones As New D_AdminOperaciones
            Dim Finalizado As Boolean = AdminOperaciones.OperacionCCTransaccion(argMacAddress, argEmpresa, argUsuario, argOperacion, argOperacionCC, argOperacionPE, argComprobante, argAsiento, argObservacion)
            Return Finalizado

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "FinalizarOperacionConTransaccion", ex.Message))

        End Try

    End Function

    Public Function AnularPagoTransaccion(ByVal argIdOperacion As Long, ByVal argUsuario As Usuario, ByVal argCodiTO As String) As Boolean
        Try
            Dim AdminOperaciones As New D_AdminOperaciones
            Dim Finalizado As Boolean = AdminOperaciones.AnularPagoTransaccion(argIdOperacion, argUsuario, argCodiTO)
            Return Finalizado

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "AnularPagoTransaccion", ex.Message))

        End Try
    End Function

    Public Function OperacionCBTransaccion(ByVal argMacAddress As String, ByVal argEmpresa As Empresa, ByVal argTipoOperacion As TipoOperacion, ByVal argUsuario As Usuario, ByVal argOperacionCBOrigen As OperacionCB, ByVal argOperacionCBDestino As OperacionCB, ByRef argComprobante As Comprobante, ByVal argAsiento As AsientoContable, ByVal argObservacion As String) As Boolean
        Try
            Dim AdminOperaciones As New D_AdminOperaciones
            Dim Finalizado As Boolean = AdminOperaciones.OperacionCBTransaccion(argMacAddress, argEmpresa, argTipoOperacion, argUsuario, argOperacionCBOrigen, argOperacionCBDestino, argComprobante, argAsiento, argObservacion)
            Return Finalizado

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "OperacionCBTransaccion", ex.Message))

        End Try

    End Function

End Class
