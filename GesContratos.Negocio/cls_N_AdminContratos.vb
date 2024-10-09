Imports System.IO
Imports SiCoFa.Datos
Imports SiCoFa.Entidades
Public Class cls_N_AdminContratos

    Private mobj_D_AdminContratos As New cls_D_AdminContratos

#Region "Administracion de Clientes"
    Public Function ObtenerClientePorId(ByVal argIdCliente As Long) As Cliente
        Dim objCli As Cliente
        Try
            objCli = mobj_D_AdminContratos.ObtenerClientePorId(argIdCliente)
            Return objCli

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ObtenerClientePorId", ex.Message))
            Return Nothing

        End Try
    End Function
    Public Function ListarClientes(ByVal argTextoBuscado As String) As List(Of Cliente)
        Dim lc As List(Of Cliente)
        Try
            lc = mobj_D_AdminContratos.ListarClientes(argTextoBuscado)
            Return lc

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ListarClientes", ex.Message))
            Return Nothing

        End Try
    End Function
    Public Function InsertarCliente(
                                    ByVal argNombre As String,
                                    ByVal argDomicilio As String,
                                    ByVal argLocalidad As String,
                                    ByVal argProvincia As String,
                                    ByVal argTelefono As String,
                                    ByVal argMovil As String,
                                    ByVal argEmail As String,
                                    ByVal argCodiTDoc As String,
                                    ByVal argNumDoc As String,
                                    ByVal argCodIVA As String
                                    ) As Integer
        Dim IdCliente As Integer = mobj_D_AdminContratos.InsertarCliente(
                                                                       UCase(argNombre),
                                                                       UCase(argDomicilio),
                                                                       UCase(argLocalidad),
                                                                       UCase(argProvincia),
                                                                       UCase(argTelefono),
                                                                       UCase(argMovil),
                                                                       UCase(argEmail),
                                                                       UCase(argCodiTDoc),
                                                                       UCase(argNumDoc),
                                                                       UCase(argCodIVA)
                                                                       )
        Return IdCliente
    End Function
    Public Function ActualizarCliente(
                                      ByVal argIdCliente As Integer,
                                      ByVal argDomicilio As String,
                                      ByVal argLocalidad As String,
                                      ByVal argProvincia As String,
                                      ByVal argTelefono As String,
                                      ByVal argMovil As String,
                                      ByVal argEmail As String,
                                      ByVal argCodiTDoc As String,
                                      ByVal argNumDoc As String,
                                      ByVal argCodIVA As String
                                     ) As Boolean

        Dim Actualizado As Boolean = mobj_D_AdminContratos.ActualizarCliente(
                                                                           argIdCliente,
                                                                           UCase(argDomicilio),
                                                                           UCase(argLocalidad),
                                                                           UCase(argProvincia),
                                                                           UCase(argTelefono),
                                                                           UCase(argMovil),
                                                                           UCase(argEmail),
                                                                           UCase(argCodiTDoc),
                                                                           UCase(argNumDoc),
                                                                           UCase(argCodIVA)
                                                                           )
        Return Actualizado
    End Function

#End Region

#Region "Administracion de Contratos"

    Public Function ListaGrupoContratosCompleta() As List(Of GrupoContratos)
        Dim lgc As List(Of GrupoContratos)
        Try
            lgc = mobj_D_AdminContratos.ListarGrupoContratos
            Return lgc

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ListaGrupoContratosCompleta", ex.Message))
            Return Nothing

        End Try

    End Function
    Public Function ObtenerGrupoContratosPorId(ByVal argIdGC As Integer) As GrupoContratos
        Dim objGC As GrupoContratos
        Try
            objGC = mobj_D_AdminContratos.ObtenerGrupoContratosPorId(argIdGC)
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try

        Return objGC

    End Function
    Public Function ObtenerContrato(ByVal Optional argIdContrato As Integer = 0, ByVal Optional argIdCliente As Integer = 0) As Contrato
        Dim objC As Contrato
        Try
            objC = mobj_D_AdminContratos.ObtenerContrato(argIdContrato, argIdCliente)
            If Not objC Is Nothing Then
                objC.GrupoContratos = Me.ObtenerGrupoContratosPorId(objC.IdGC)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try

        Return objC
    End Function
    Public Function ListarContratos(ByVal argEstadoContrato As String) As List(Of Contrato)
        Try
            Return mobj_D_AdminContratos.ListarContratos(argEstadoContrato)
        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ListarContratos", ex.Message))
            Return Nothing
        End Try
    End Function
    Public Function InsertarContrato(
                                   ByVal argIdGC As Integer,
                                   ByVal argIdLocador As Integer,
                                   ByVal argIdCliente As Integer,
                                   ByVal argUsFTP As String,
                                   ByVal argMesesT As Integer,
                                   ByVal argContacto As String,
                                   ByVal argDeposito As Decimal,
                                   ByVal argInicioContrato As Date,
                                   ByVal argFinalContrato As Date,
                                   ByVal argFacturaServicios As Boolean
                                   ) As Integer

        Dim IdContrato As Integer = mobj_D_AdminContratos.InsertarContrato(
                                                                        argIdGC,
                                                                        argIdLocador,
                                                                        argIdCliente,
                                                                        UCase(argUsFTP),
                                                                        argMesesT,
                                                                        UCase(argContacto),
                                                                        argDeposito,
                                                                        argInicioContrato,
                                                                        argFinalContrato,
                                                                        argFacturaServicios
                                                                        )
        Return IdContrato
    End Function
    Public Function ActualizarContrato(
                                      ByVal argIdContrato As Integer,
                                      ByVal argIdGC As Integer,
                                      ByVal argIdLocador As Integer,
                                      ByVal argUsFTP As String,
                                      ByVal argMesesT As Integer,
                                      ByVal argContacto As String,
                                      ByVal argDeposito As Decimal,
                                      ByVal argInicioContrato As Date,
                                      ByVal argFinalContrato As Date,
                                      ByVal argFacturaServicios As Boolean,
                                      ByVal argEstadoContrato As String
                                      ) As Boolean

        Dim Actualizado As Boolean = mobj_D_AdminContratos.ActualizarContrato(
                                                                           argIdContrato,
                                                                           argIdGC,
                                                                           argIdLocador,
                                                                           UCase(argUsFTP),
                                                                           argMesesT,
                                                                           UCase(argContacto),
                                                                           argDeposito,
                                                                           argInicioContrato,
                                                                           argFinalContrato,
                                                                           argFacturaServicios,
                                                                           UCase(argEstadoContrato)
                                                                           )
        Return Actualizado
    End Function
    Public Function ActualizarUsFTP(ByVal argPathLocal As String) As Boolean
        Try

            Dim sql As String = "SELECT UsFTP FROM ConUsFTPHabilitados"

            Dim obj_N_AdminDB As New cls_N_AdminDB
            Dim dt As DataTable = obj_N_AdminDB.ObtenerTabla(sql)

            Dim filePath As String = argPathLocal

            Using writer As New StreamWriter(filePath)
                For Each row As DataRow In dt.Rows
                    For Each column As DataColumn In dt.Columns
                        writer.Write(row(column).ToString())
                    Next
                    writer.WriteLine()
                Next
            End Using

            Dim obj_N_AdminFTP As New cls_N_AdminFTP
            Return obj_N_AdminFTP.UploadFile("/Clientes/id7.txt", argPathLocal)

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ActualizarUsFTP", ex.Message))

        End Try

    End Function

#End Region

#Region "Administracion de Locadores"
    Public Function ObtenerLocadorPorId(ByVal argIdLocador As Long) As Locador
        Dim objLoc As Locador
        Try
            objLoc = mobj_D_AdminContratos.ObtenerLocadorPorId(argIdLocador)
            Return objLoc

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ObtenerLocadorPorId", ex.Message))
            Return Nothing

        End Try
    End Function
    Public Function LocadoresVigentes() As List(Of Locador)
        Dim list As List(Of Locador)
        Try
            list = mobj_D_AdminContratos.LocadoresVigentes
            Return list
        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "LocadoresVigentes", ex.Message))
            Return Nothing

        End Try

    End Function

#End Region

#Region "AFIP"
    Public Function TiposDocumento() As List(Of TipoDocumento)
        Dim TDocs As New List(Of TipoDocumento)
        TDocs.Add(New TipoDocumento("80"))
        TDocs.Add(New TipoDocumento("86"))
        TDocs.Add(New TipoDocumento("90"))
        TDocs.Add(New TipoDocumento("96"))
        Return TDocs.OrderBy(Function(x) x.TipoDocumento).ToList()
    End Function
    Public Function TiposIVA() As List(Of IVA)
        Dim TIVAS As New List(Of IVA)
        TIVAS.Add(New IVA("CF"))
        TIVAS.Add(New IVA("RI"))
        TIVAS.Add(New IVA("MT"))
        TIVAS.Add(New IVA("EX"))
        Return TIVAS.OrderBy(Function(x) x.TipoIVA).ToList()
    End Function

#End Region

#Region "Administracion de Operaciones"
    Public Function ObtenerTipoOperacion(ByVal argCodiTO As String) As TipoOperacion

        Dim TipoOperaciones As List(Of TipoOperacion) = mobj_D_AdminContratos.ListarTipoOperaciones

        Try

            For Each top As TipoOperacion In TipoOperaciones
                If top.CodiTO = argCodiTO Then
                    Return top
                    Exit For
                End If
            Next
            Return Nothing

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "FinalizarOperacion", ex.Message))
            Return Nothing
        End Try

    End Function
    Public Function RegistrarError(ByVal argIdOperacion As Long, argDescripcionError As String) As Integer

        Dim RegAfectados As Integer

        Try
            RegAfectados = mobj_D_AdminContratos.RegistrarError(argIdOperacion, argDescripcionError)
            Return RegAfectados
        Catch ex As Exception
            MsgBox(vecho.MensajeError(Me.ToString, "RegistrarError", ex.Message))
            Return 0
        End Try
    End Function
    Public Function DevengarServicios(ByVal argIdUsuario As Integer) As Integer
        Try
            Dim RegAfectados As Integer
            RegAfectados = mobj_D_AdminContratos.DevengarServicios(argIdUsuario)
            Return RegAfectados

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "DevengarServicios", ex.Message))
            Return 0
        End Try

    End Function
    Public Sub AplicarPagosAbiertos(ByVal argIdUsuario As Integer)

        Try
            mobj_D_AdminContratos.AplicarPagosAbiertos(argIdUsuario)

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "DevengarServicios", ex.Message))

        End Try

    End Sub
    Public Function EstablecerOrdenP(ByVal argIdOpera As Long, argOrdenP As Integer) As Integer

        Dim RegAfectados As Integer

        Try
            RegAfectados = mobj_D_AdminContratos.EstablecerOrdenP(argIdOpera, argOrdenP)
            Return RegAfectados

        Catch Ex As Exception
            MsgBox(Vecho.MensajeError(Me.ToString, "EstablcerOrdenP", Ex.Message))
            Return 0
        End Try

        Return RegAfectados

    End Function
    Public Function AplicarPagoCliente(ByVal argIdUsuario As Integer, ByVal argIdContrato As Integer, ByVal argCodiAE As String, ByVal argImporte As Decimal) As OperaCancel
        Try
            Dim oc As OperaCancel = mobj_D_AdminContratos.AplicarPagoCliente(argIdUsuario, argIdContrato, argCodiAE, argImporte)
            Return oc

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "AplicarPagoCliente", ex.Message))
            Return Nothing

        End Try
    End Function
    Public Function FacturarServicios(ByVal argIdUsuario As Integer, ByVal argCodiTC As String, ByVal argPVenta As String) As Integer
        Try
            Dim NumComprobantes As Integer = mobj_D_AdminContratos.FacturarServicios(argIdUsuario, argCodiTC, argPVenta)
            Return NumComprobantes

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "FacturarServicios", ex.Message))
            Return 0

        End Try
    End Function
    Public Function InsertarOperacion(ByVal argCodiAE As String, ByVal argCodiTO As String, ByVal argIdUsuario As Integer) As Operacion
        Dim objOpera As Operacion

        Try
            objOpera = mobj_D_AdminContratos.InsertarOperacion(argCodiAE, argCodiTO, argIdUsuario)
            Return objOpera

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "InsertarOperacion", ex.Message))
            Return Nothing
        End Try

    End Function
    Public Function FinalizarOperacion(ByVal argIdOperacion As Long) As Integer

        Dim RegAfectados As Integer

        Try
            RegAfectados = mobj_D_AdminContratos.FinalizarOperacion(argIdOperacion)
            Return RegAfectados
        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "FinalizarOperacion", ex.Message))
            Return 0
        End Try

    End Function
    Public Function ObtenerOperacion(ByVal argIdOpera As Long) As Operacion

        Try
            Dim objOpera As Operacion = mobj_D_AdminContratos.ObtenerOperacion(argIdOpera)
            Return objOpera

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ObtenerOperacion", ex.Message))
            Return Nothing
        End Try

    End Function
    Public Function InsertarOperaCancel(ByVal argIdOperacion As Long, ByVal argIdOperaCancel As Long, ByVal argIdOperaAntic As Long, ByVal argImporte As Decimal, ByVal argSaldoOperacion As Decimal, ByVal argSaldoAnticipo As Decimal) As Long
        Dim IdOC As Long

        Try
            IdOC = mobj_D_AdminContratos.InsertarOperaCancel(argIdOperacion, argIdOperaCancel, argIdOperaAntic, argImporte, argSaldoOperacion, argSaldoAnticipo)
            Return IdOC
        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "InsertarOperaCancel", ex.Message))
            Return 0
        End Try

    End Function
    Public Function InsertarOperaContrato(ByVal argIdOperacion As Long, ByVal argIdContrato As Integer, ByVal argResumen As String, ByVal argImporte As Decimal, ByVal argEstado As String) As Long
        Dim IdOC As Long

        Try
            IdOC = mobj_D_AdminContratos.InsertarOperaContrato(argIdOperacion, argIdContrato, argResumen, argImporte, argEstado)
            Return IdOC
        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "InsertarOperaContratos", ex.Message))
            Return 0
        End Try

    End Function
    Public Function ListaOperaContratos(ByVal Optional argIdOperacion As Long = 0, ByVal Optional argIdGC As Integer = 0, ByVal Optional argIdContrato As Integer = 0, ByVal Optional argResu As String = "", ByVal Optional argEstadoOpera As String = "") As List(Of OperaContrato)
        Dim LOC As List(Of OperaContrato)

        Try
            LOC = mobj_D_AdminContratos.ListaOperaContratos(argIdOperacion, argIdGC, argIdContrato, argResu, argEstadoOpera)
            Return LOC

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ListaOperaContratos", ex.Message))
            Return Nothing
        End Try

    End Function
    Public Function ListaPagosCliente(Optional ByVal argIdOperacion As Long = 0, Optional ByVal argIdContrato As Integer = 0, Optional ByVal argEstadoPago As String = "") As List(Of PagoCliente)
        Return mobj_D_AdminContratos.ListaPagosCliente(argIdOperacion, argIdContrato, argEstadoPago)
    End Function

#End Region

#Region "Administracion de Servicios"

    Public Function ObtenerServicio(ByVal argCodiS As String) As Servicio
        Dim ListaServicios As List(Of Servicio) = mobj_D_AdminContratos.ListarServicios

        Try

            For Each sv As Servicio In ListaServicios
                If sv.CodiS = argCodiS Then
                    Return sv
                    Exit For
                End If
            Next
            Return Nothing

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ObtenerServicio", ex.Message))
            Return Nothing

        End Try

    End Function
    Public Function ObtenerServiciosAsociados(ByVal argIdContrato As Integer) As List(Of ServicioAsociado)
        Dim lsa As List(Of ServicioAsociado) = mobj_D_AdminContratos.ListaServiciosAsociados(argIdContrato)

        Try

            If lsa Is Nothing Then
                Return Nothing
                Exit Function
            End If

            For Each sa As ServicioAsociado In lsa
                sa.Servicio = ObtenerServicio(sa.CodiS)
                sa.Importe = sa.Cantidad * sa.Servicio.PUnit
            Next

            Return lsa
        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ObtenerServiciosAsociados", ex.Message))
            Return Nothing

        End Try

    End Function
    Public Function EliminarServicioAsociado(ByVal argIdDS As Integer) As Integer
        Dim RegistrosAfectados As Integer

        Try
            RegistrosAfectados = mobj_D_AdminContratos.EliminarServicioAsociado(argIdDS)
            Return RegistrosAfectados

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "EliminarServicioAsociado", ex.Message))
            Return 0

        End Try
    End Function
    Public Function InsertarServicioAsociado(ByVal argIdContrato As Integer, ByVal argCodiS As String) As Integer
        Dim RegistrosAfectados As Integer

        Try
            RegistrosAfectados = mobj_D_AdminContratos.InsertarServicioAsociado(argIdContrato, argCodiS)
            Return RegistrosAfectados

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "InsertarServicioAsociado", ex.Message))
            Return 0

        End Try

    End Function
    Public Function ActualizarServicioAsociado(ByVal ArgIdDS As Integer, ByVal argCantidad As Integer) As Integer
        Dim RegistrosAfectados As Integer

        Try
            RegistrosAfectados = mobj_D_AdminContratos.ActualizarServicioAsociado(ArgIdDS, argCantidad)
            Return RegistrosAfectados

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "InsertarServicioAsociado", ex.Message))
            Return 0

        End Try

    End Function
    Public Function ListarServiciosBuscados(ByVal argTextoBuscado As String) As List(Of Servicio)
        Dim ListaCompletaServicios As List(Of Servicio) = mobj_D_AdminContratos.ListarServicios
        Dim ls As New List(Of Servicio)

        Try

            For Each s As Servicio In ListaCompletaServicios
                If s.DescripcionServicio.IndexOf(argTextoBuscado) >= 0 Then
                    ls.Add(s)
                End If
            Next
            Return ls

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ListarServiciosBuscados", ex.Message))
            Return Nothing
        End Try

    End Function
    Public Function ListaServiciosCompleta() As List(Of Servicio)
        Dim ListaCompletaServicios As List(Of Servicio)

        Try
            ListaCompletaServicios = mobj_D_AdminContratos.ListarServicios
            Return ListaCompletaServicios

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ListarServiciosBuscados", ex.Message))
            Return Nothing
        End Try

    End Function


#End Region

#Region "Administracion de Comprobantes"
    Public Function InsertarComprobante(ByVal argOperacion As Operacion,
                                        ByVal argCodiTC As String,
                                        ByVal argImpBto As Decimal,
                                        ByVal argImpEx As Decimal,
                                        ByVal argImpGrav1 As Decimal,
                                        ByVal argImpNeto1 As Decimal,
                                        ByVal argImpIVA1 As Decimal,
                                        ByVal argImpGrav2 As Decimal,
                                        ByVal argImpNeto2 As Decimal,
                                        ByVal argImpIVA2 As Decimal,
                                        ByVal argImpCB As Decimal,
                                        ByVal argImpEf As Decimal,
                                        ByVal argImpCC As Decimal,
                                        ByVal argImpTar As Decimal,
                                        ByVal argIdOperAsoc As Long,
                                        ByVal argCliente As Cliente,
                                        ByVal argLocador As Locador,
                                        ByVal argDetalle As List(Of ItemComprobante),
                                        ByVal argFiscal As Boolean
                                        ) As Comprobante
        Dim objComp As Comprobante
        Try
            objComp = mobj_D_AdminContratos.InsertarComprobante(argOperacion, argCodiTC, argImpBto, argImpEx, argImpGrav1, argImpNeto1, argImpIVA1, argImpGrav2, argImpNeto2, argImpIVA2, argImpCB, argImpEf, argImpCC, argImpTar, argIdOperAsoc, argCliente, argLocador, argDetalle, argFiscal)
            Return objComp

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ObtenerServicio", ex.Message))
            Return Nothing
        End Try
    End Function

    Public Function ObtenerComprobante(ByVal argOperacion As Operacion) As Comprobante
        Try
            Dim c As Comprobante = mobj_D_AdminContratos.ObtenerComprobante(argOperacion)
            Return c

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ObtenerComprobante", ex.Message))
            Return Nothing

        End Try
    End Function
    Public Function ObtenerComprobantesEnCola() As List(Of Comprobante)
        Dim objCola As List(Of Comprobante)
        Try
            objCola = mobj_D_AdminContratos.ObtenerComprobantesEnCola
            Return objCola

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ObtenerComprobantesEnCola", ex.Message))
            Return Nothing

        End Try

    End Function
    Public Function ObtenerComprobantes(ByVal argIdCliente As Integer, ByVal argCodiTC As String, ByVal argFechaDesde As String, ByVal argFechaHasta As String) As List(Of Comprobante)
        Dim objCola As List(Of Comprobante)
        Try
            objCola = mobj_D_AdminContratos.ObtenerComprobantes(argIdCliente, argCodiTC, argFechaDesde, argFechaHasta)
            Return objCola

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ObtenerComprobantes", ex.Message))
            Return Nothing

        End Try

    End Function
    Public Function ObtenerDetalleC(ByVal argIdOperacion As Long, ByVal argDisIva As Boolean) As List(Of ItemComprobante)
        Dim objDetC As List(Of ItemComprobante)

        Try
            objDetC = mobj_D_AdminContratos.ObtenerDetalleC(argIdOperacion, argDisIva)
            Return objDetC

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ObtenerDetalleC", ex.Message))
            Return Nothing
        End Try
    End Function

    Public Sub ActualizarCAE(ByVal argCbte As Comprobante)

        Try
            mobj_D_AdminContratos.ActualizarCAE(argCbte)
        Catch Ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ActualizarCAE", Ex.Message))

        End Try

    End Sub
    Public Sub RegistrarComprobanteRechazado(ByVal argIdOpera As String)
        Try
            mobj_D_AdminContratos.RegistrarComprobanteRechazado(argIdOpera)

        Catch Ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "RegistrarComprobanteRechazado", Ex.Message))

        End Try

    End Sub
    Public Function ListarTipoComprobantes() As List(Of TipoComprobante)
        Dim ListaCompletaTipoComprobantes As List(Of TipoComprobante)

        Try
            ListaCompletaTipoComprobantes = mobj_D_AdminContratos.ListarTipoComprobantes
            Return ListaCompletaTipoComprobantes

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ListarTipoComprobantes", ex.Message))
            Return Nothing
        End Try
    End Function

#End Region

#Region "Administracion Asientos Contables"
    Public Sub EfectuarAsientoContable(ByVal argOperacion As Operacion, ByVal argAsiento As AsientoContable)
        mobj_D_AdminContratos.EfectuarAsientoContable(argOperacion, argAsiento)
    End Sub
#End Region

End Class
