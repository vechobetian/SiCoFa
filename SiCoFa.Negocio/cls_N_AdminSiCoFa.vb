Imports SiCoFa.Datos
Imports SiCoFa.Entidades
Public Class cls_N_AdminSiCoFa

    Private mobj_D_AdminSiCoFa As New cls_D_AdminSiCoFa

#Region "Administracion de Clientes"
    Public Function ObtenerClientePorId(ByVal argIdCliente As Int32) As Cliente
        Dim objCli As Cliente
        Try
            objCli = mobj_D_AdminSiCoFa.ObtenerClientePorId(argIdCliente)
            Return objCli

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerClientePorId", ex.Message))
            Return Nothing

        End Try
    End Function
    Public Function ListarClientes(ByVal argTextoBuscado As String) As List(Of Cliente)
        Dim lc As List(Of Cliente)
        Try
            lc = mobj_D_AdminSiCoFa.ListarClientes(argTextoBuscado)
            Return lc

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ListarClientes", ex.Message))
            Return Nothing

        End Try
    End Function
    Public Function InsertarCliente(
                                    ByVal argNombre As String,
                                    ByVal argDomicilio As String,
                                    ByVal argLocalidad As String,
                                    ByVal argProvincia As String,
                                    ByVal argTelefono As String,
                                    ByVal argEmail As String,
                                    ByVal argCodiTDoc As String,
                                    ByVal argNumDoc As String,
                                    ByVal argCodIVA As String
                                    ) As Integer
        Try
            Dim IdCliente As Integer = mobj_D_AdminSiCoFa.InsertarCliente(
                                                                       UCase(argNombre),
                                                                       UCase(argDomicilio),
                                                                       UCase(argLocalidad),
                                                                       UCase(argProvincia),
                                                                       UCase(argTelefono),
                                                                       UCase(argEmail),
                                                                       UCase(argCodiTDoc),
                                                                       UCase(argNumDoc),
                                                                       UCase(argCodIVA)
                                                                       )
            Return IdCliente

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarCliente", ex.Message))
            Return 0

        End Try

    End Function
    Public Function ActualizarCliente(
                                      ByVal argIdCliente As Int32,
                                      ByVal argDomicilio As String,
                                      ByVal argLocalidad As String,
                                      ByVal argProvincia As String,
                                      ByVal argTelefono As String,
                                      ByVal argEmail As String,
                                      ByVal argCodiTDoc As String,
                                      ByVal argNumDoc As String,
                                      ByVal argCodIVA As String,
                                      ByVal argEstado As String
                                     ) As Boolean

        Try
            Dim Actualizado As Boolean = mobj_D_AdminSiCoFa.ActualizarCliente(
                                                                           argIdCliente,
                                                                           UCase(argDomicilio),
                                                                           UCase(argLocalidad),
                                                                           UCase(argProvincia),
                                                                           argTelefono,
                                                                           argEmail,
                                                                           argCodiTDoc,
                                                                           UCase(argNumDoc),
                                                                           argCodIVA,
                                                                           argEstado
                                                                           )
            Return Actualizado
        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ActualizarCliente", ex.Message))
            Return False

        End Try

    End Function

#End Region

#Region "Administracion de Cuentas Corriente"
    Public Function ObtenerCuentaCorrientePorIdCliente(ByVal argCliente As Cliente) As CuentaCorriente
        Dim objCC As CuentaCorriente
        Try
            objCC = mobj_D_AdminSiCoFa.ObtenerCuentaCorrientePorIdCliente(argCliente)
            Return objCC

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerCuentaCorrientePorIdCliente", ex.Message))
            Return Nothing

        End Try
    End Function
    Public Function InsertarCuentaCorriente(
                                            ByVal argIdCliente As Int32,
                                            ByVal argDescripcion As String,
                                            ByVal argCredito As Decimal,
                                            ByVal argObservaciones As String
                                            ) As Int16
        Try
            Dim IdCC As Int16 = mobj_D_AdminSiCoFa.InsertarCuentaCorriente(argIdCliente,
                                                                            UCase(argDescripcion),
                                                                            argCredito,
                                                                            argObservaciones
                                                                            )
            Return IdCC

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarCuentaCorriente", ex.Message))
            Return 0

        End Try

    End Function
    Public Function ActualizarCuentaCorriente(
                                              ByVal argIdCC As Int32,
                                              ByVal argCredito As Decimal,
                                              ByVal argObservaciones As String,
                                              ByVal argEstado As String
                                              ) As Boolean
        Try
            Dim Actualizado As Boolean = mobj_D_AdminSiCoFa.ActualizarCuentaCorriente(argIdCC,
                                                                                      argCredito,
                                                                                      argObservaciones,
                                                                                      argEstado
                                                                                      )
            Return Actualizado

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ActualizarCuentaCorriente", ex.Message))
            Return 0

        End Try

    End Function

#End Region

#Region "Administracion de Proveedores"
    Public Function ObtenerProveedorPorId(ByVal argIdProveedor As Int32) As Proveedor
        Dim objProv As Proveedor
        Try
            objProv = mobj_D_AdminSiCoFa.ObtenerProveedorPorId(argIdProveedor)
            Return objProv

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerProveedorPorId", ex.Message))
            Return Nothing

        End Try
    End Function
    Public Function ListarProveedores(ByVal argTextoBuscado As String) As List(Of Proveedor)
        Dim lp As List(Of Proveedor)
        Try
            lp = mobj_D_AdminSiCoFa.ListarProveedores(argTextoBuscado)
            Return lp

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ListarProveedores", ex.Message))
            Return Nothing

        End Try
    End Function
    Public Function InsertarProveedor(
                                    ByVal argNombre As String,
                                    ByVal argDomicilio As String,
                                    ByVal argLocalidad As String,
                                    ByVal argProvincia As String,
                                    ByVal argTelefono As String,
                                    ByVal argEmail As String,
                                    ByVal argCodiTDoc As String,
                                    ByVal argNumDoc As String
                                    ) As Integer
        Try

            Dim IdProveedor As Integer = mobj_D_AdminSiCoFa.InsertarProveedor(
                                                                           UCase(argNombre),
                                                                           UCase(argDomicilio),
                                                                           UCase(argLocalidad),
                                                                           UCase(argProvincia),
                                                                           UCase(argTelefono),
                                                                           UCase(argEmail),
                                                                           UCase(argCodiTDoc),
                                                                           UCase(argNumDoc)
                                                                           )
            Return IdProveedor

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarProveedor", ex.Message))
            Return 0

        End Try

    End Function
    Public Function ActualizarProveedor(
                                      ByVal argIdProveedor As Int32,
                                      ByVal argDomicilio As String,
                                      ByVal argLocalidad As String,
                                      ByVal argProvincia As String,
                                      ByVal argTelefono As String,
                                      ByVal argEmail As String,
                                      ByVal argCodiTDoc As String,
                                      ByVal argNumDoc As String,
                                      ByVal argCodIVA As String,
                                      ByVal argEstado As String
                                     ) As Boolean

        Try

            Dim Actualizado As Boolean = mobj_D_AdminSiCoFa.ActualizarProveedor(
                                                                               argIdProveedor,
                                                                               UCase(argDomicilio),
                                                                               UCase(argLocalidad),
                                                                               UCase(argProvincia),
                                                                               argTelefono,
                                                                               argEmail,
                                                                               argCodiTDoc,
                                                                               argNumDoc,
                                                                               argCodIVA,
                                                                               argEstado
                                                                               )
            Return Actualizado

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ActualizarProveedor", ex.Message))
            Return False

        End Try

    End Function

#End Region

#Region "Administracion de Empleados"
    Public Function ObtenerEmpleadoPorId(ByVal argIdEmpleado As Int32) As Empleado
        Dim objEmp As Empleado = Nothing

        Try
            objEmp = mobj_D_AdminSiCoFa.ObtenerEmpleadoPorId(argIdEmpleado)
            Return objEmp

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerEmpleadoPorId", ex.Message))

        End Try
    End Function
    Public Function ListarEmpleados(ByVal argTextoBuscado As String) As List(Of Empleado)
        Dim le As List(Of Empleado) = Nothing

        Try
            le = mobj_D_AdminSiCoFa.ListarEmpleados(argTextoBuscado)
            Return le

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ListarEmpleados", ex.Message))

        End Try
    End Function
    Public Function InsertarEmpleado(
                                    ByVal argNombre As String,
                                    ByVal argDomicilio As String,
                                    ByVal argLocalidad As String,
                                    ByVal argProvincia As String,
                                    ByVal argTelefono As String,
                                    ByVal argEmail As String,
                                    ByVal argCodiTDoc As String,
                                    ByVal argNumDoc As String
                                    ) As Integer
        Try

            Dim IdEmpleado As Integer = mobj_D_AdminSiCoFa.InsertarEmpleado(
                                                                           UCase(argNombre),
                                                                           UCase(argDomicilio),
                                                                           UCase(argLocalidad),
                                                                           UCase(argProvincia),
                                                                           UCase(argTelefono),
                                                                           UCase(argEmail),
                                                                           UCase(argCodiTDoc),
                                                                           UCase(argNumDoc)
                                                                           )
            Return IdEmpleado

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarEmpleado", ex.Message))

        End Try

    End Function
    Public Function ActualizarEmpleado(
                                      ByVal argIdEmpleado As Int32,
                                      ByVal argDomicilio As String,
                                      ByVal argLocalidad As String,
                                      ByVal argProvincia As String,
                                      ByVal argTelefono As String,
                                      ByVal argEmail As String,
                                      ByVal argCodiTDoc As String,
                                      ByVal argNumDoc As String,
                                      ByVal argEstado As String
                                     ) As Boolean

        Try

            Dim Actualizado As Boolean = mobj_D_AdminSiCoFa.ActualizarEmpleado(
                                                                               argIdEmpleado,
                                                                               UCase(argDomicilio),
                                                                               UCase(argLocalidad),
                                                                               UCase(argProvincia),
                                                                               argTelefono,
                                                                               argEmail,
                                                                               argCodiTDoc,
                                                                               argNumDoc,
                                                                               argEstado
                                                                               )
            Return Actualizado

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ActualizarEmpleado", ex.Message))

        End Try

    End Function

#End Region

#Region "Administracion de Usuarios"
    Public Function ObtenerUsuarioPorId(ByVal argIdUsuario As Int32) As Usuario
        Dim objUs As Usuario = Nothing

        Try
            objUs = mobj_D_AdminSiCoFa.ObtenerUsuarioPorId(argIdUsuario)
            Return objUs

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerUsuarioPorId", ex.Message))

        End Try
    End Function
    Public Function ListarUsuarios(ByVal argTextoBuscado As String) As List(Of Usuario)
        Dim lu As List(Of Usuario) = Nothing

        Try
            lu = mobj_D_AdminSiCoFa.ListarUsuarios(argTextoBuscado)
            Return lu

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ListarUsuarios", ex.Message))

        End Try
    End Function
    Public Function InsertarUsuario(
                                    ByVal argNombre As String,
                                    ByVal argDomicilio As String,
                                    ByVal argLocalidad As String,
                                    ByVal argProvincia As String,
                                    ByVal argTelefono As String,
                                    ByVal argEmail As String,
                                    ByVal argCodiTDoc As String,
                                    ByVal argNumDoc As String
                                    ) As Integer
        Try

            Dim IdUsuario As Integer = mobj_D_AdminSiCoFa.InsertarUsuario(
                                                                           UCase(argNombre),
                                                                           UCase(argDomicilio),
                                                                           UCase(argLocalidad),
                                                                           UCase(argProvincia),
                                                                           UCase(argTelefono),
                                                                           UCase(argEmail),
                                                                           UCase(argCodiTDoc),
                                                                           UCase(argNumDoc)
                                                                           )
            Return IdUsuario

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarUsuario", ex.Message))

        End Try

    End Function
    Public Function ActualizarUsuario(
                                      ByVal argIdEmpleado As Int32,
                                      ByVal argDomicilio As String,
                                      ByVal argLocalidad As String,
                                      ByVal argProvincia As String,
                                      ByVal argTelefono As String,
                                      ByVal argEmail As String,
                                      ByVal argCodiTDoc As String,
                                      ByVal argNumDoc As String,
                                      ByVal argEstado As String
                                     ) As Boolean

        Try

            Dim Actualizado As Boolean = mobj_D_AdminSiCoFa.ActualizarUsuario(
                                                                               argIdEmpleado,
                                                                               UCase(argDomicilio),
                                                                               UCase(argLocalidad),
                                                                               UCase(argProvincia),
                                                                               argTelefono,
                                                                               argEmail,
                                                                               argCodiTDoc,
                                                                               argNumDoc,
                                                                               argEstado
                                                                               )
            Return Actualizado

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ActualizarUsuario", ex.Message))

        End Try

    End Function

#End Region

#Region "Administracion de Empresas"
    Public Function ObtenerEmpresaPorId(ByVal argIdEmpresa As Int32) As Empresa
        Dim objEmp As Empresa
        Try
            objEmp = mobj_D_AdminSiCoFa.ObtenerEmpresaPorId(argIdEmpresa)
            Return objEmp

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerEmpresaPorId", ex.Message))
            Return Nothing

        End Try
    End Function
    Public Function ListarEmpresas(ByVal argTextoBuscado As String) As List(Of Empresa)
        Dim le As List(Of Empresa)
        Try
            le = mobj_D_AdminSiCoFa.ListarEmpresas(argTextoBuscado)
            Return le

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ListarEmpresas", ex.Message))
            Return Nothing

        End Try
    End Function
    Public Function InsertarEmpresa(
                                    ByVal argNombre As String,
                                    ByVal argDomicilio As String,
                                    ByVal argLocalidad As String,
                                    ByVal argProvincia As String,
                                    ByVal argTelefono As String,
                                    ByVal argEmail As String,
                                    ByVal argNumDoc As String,
                                    ByVal argFechaAlta As Date,
                                    ByVal argCodIVA As String,
                                    ByVal argIB As String
                                    ) As Integer
        Try
            Dim IdEmpresa As Integer = mobj_D_AdminSiCoFa.InsertarEmpresa(
                                                                       UCase(argNombre),
                                                                       UCase(argDomicilio),
                                                                       UCase(argLocalidad),
                                                                       UCase(argProvincia),
                                                                       UCase(argTelefono),
                                                                       UCase(argEmail),
                                                                       UCase(argNumDoc),
                                                                       argFechaAlta,
                                                                       UCase(argCodIVA),
                                                                       UCase(argIB)
                                                                       )
            Return IdEmpresa

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarEmpresa", ex.Message))
            Return 0

        End Try

    End Function
    Public Function ActualizarEmpresa(
                                      ByVal argIdCliente As Int32,
                                      ByVal argDomicilio As String,
                                      ByVal argLocalidad As String,
                                      ByVal argProvincia As String,
                                      ByVal argTelefono As String,
                                      ByVal argEmail As String,
                                      ByVal argNumDoc As String,
                                      ByVal argFechaAlta As Date,
                                      ByVal argEstado As String,
                                      ByVal argCodIVA As String,
                                      ByVal argIB As String
                                     ) As Boolean

        Try
            Dim Actualizado As Boolean = mobj_D_AdminSiCoFa.ActualizarEmpresa(
                                                                           argIdCliente,
                                                                           UCase(argDomicilio),
                                                                           UCase(argLocalidad),
                                                                           UCase(argProvincia),
                                                                           argTelefono,
                                                                           argEmail,
                                                                           argNumDoc,
                                                                           argFechaAlta,
                                                                           argEstado,
                                                                           argCodIVA,
                                                                           argIB
                                                                           )
            Return Actualizado
        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ActualizarEmpresa", ex.Message))
            Return False

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
    Public Function AlicuotasIVA() As List(Of AlicuotaIVA)
        Dim ALIVAS As New List(Of AlicuotaIVA)
        ALIVAS.Add(New AlicuotaIVA(Convert.ToDecimal(10.5)))
        ALIVAS.Add(New AlicuotaIVA(Convert.ToDecimal(21)))
        Return ALIVAS.OrderBy(Function(x) x.AlicuotaIVA).ToList
    End Function

#End Region

#Region "Administracion de Operaciones"

    Public Function ObtenerTipoOperacion(ByVal argCodiTO As String) As TipoOperacion

        Dim TipoOperaciones As List(Of TipoOperacion) = mobj_D_AdminSiCoFa.ListarTipoOperaciones

        Try

            For Each top As TipoOperacion In TipoOperaciones
                If top.CodiTO = argCodiTO Then
                    Return top
                    Exit For
                End If
            Next
            Return Nothing

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "FinalizarOperacion", ex.Message))
            Return Nothing
        End Try

    End Function

    Public Function RegistrarError(ByVal argIdOperacion As Long, argDescripcionError As String) As Integer

        Dim RegAfectados As Integer

        Try
            RegAfectados = mobj_D_AdminSiCoFa.RegistrarError(argIdOperacion, argDescripcionError)
            Return RegAfectados
        Catch ex As Exception
            MsgBox(Vecho.MensajeError(Me.ToString, "RegistrarError", ex.Message))
            Return 0
        End Try
    End Function

    Public Function IniciarOperacion(ByVal argMacAddress As String, ByVal argIdUsuario As Int32, ByVal argCodiTO As String, ByVal argObservaciones As String) As Long


        Try
            Dim IdOperacion = mobj_D_AdminSiCoFa.IniciarOperacion(argMacAddress, argIdUsuario, argCodiTO, argObservaciones)
            Return IdOperacion

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "IniciarOperacion", ex.Message))
            Return 0
        End Try

    End Function

    Public Function FinalizarOperacion(ByVal argMacAddress As String, ByVal argObservaciones As String, ByVal argIdOperacion As String) As Boolean

        Try
            Dim Actualizado As Boolean = mobj_D_AdminSiCoFa.FinalizarOperacion(argMacAddress, argObservaciones, argIdOperacion)
            Return Actualizado

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "FinalizarOperacion", ex.Message))
            Return False
        End Try

    End Function

    Public Function ObtenerOperacion(ByVal argIdOpera As Long) As Operacion

        Try
            Dim objOpera As Operacion = mobj_D_AdminSiCoFa.ObtenerOperacion(argIdOpera)
            Return objOpera

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerOperacion", ex.Message))
            Return Nothing
        End Try

    End Function

#End Region

#Region "Administracion Asientos Contables"
    Public Sub EfectuarAsientoContable(ByVal argOperacion As Operacion, ByVal argAsiento As AsientoContable)
        mobj_D_AdminSiCoFa.EfectuarAsientoContable(argOperacion, argAsiento)
    End Sub
#End Region

#Region "Administracion de Secciones"
    Public Function ObtenerSeccionPorId(ByVal argIdSeccion As Int32) As Seccion
        Dim objSec As Seccion
        Try
            objSec = mobj_D_AdminSiCoFa.ObtenerSeccionPorId(argIdSeccion)
            Return objSec

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerSeccionPorId", ex.Message))
            Return Nothing

        End Try
    End Function
    Public Function ListarSecciones(ByVal argTextoBuscado As String) As List(Of Seccion)
        Dim ls As List(Of Seccion)
        Try
            ls = mobj_D_AdminSiCoFa.ListarSecciones(argTextoBuscado)
            Return ls

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ListarSecciones", ex.Message))
            Return Nothing

        End Try
    End Function
    Public Function InsertarSecciones(
                                    ByVal argSeccion As String,
                                    ByVal argEstablecerPrecio As Boolean
                                    ) As String
        Try
            Dim SeccionInsertada As String = mobj_D_AdminSiCoFa.InsertarSeccion(
                                                                                 UCase(argSeccion),
                                                                                 argEstablecerPrecio
                                                                                 )
            Return SeccionInsertada

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarSeccion", ex.Message))
            Return ""

        End Try

    End Function
    Public Function ActualizarSeccion(
                                      ByVal argIdSeccion As String,
                                      ByVal argSeccion As String,
                                      ByVal argEstablecerPrecio As Boolean
                                      ) As Boolean

        Try
            Dim Actualizado As Boolean = mobj_D_AdminSiCoFa.ActualizarSeccion(
                                                                              argIdSeccion,
                                                                              UCase(argSeccion),
                                                                              argEstablecerPrecio
                                                                              )
            Return Actualizado
        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ActualizarSeccion", ex.Message))
            Return False

        End Try

    End Function
#End Region

#Region "Administracion de Articulos"
    Public Function ObtenerArticuloPorId(ByVal argIdArticulo As String) As Articulo
        Dim objArt As Articulo
        Try
            objArt = mobj_D_AdminSiCoFa.ObtenerArticuloPorId(argIdArticulo)
            Return objArt

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerArticuloPorId", ex.Message))
            Return Nothing

        End Try
    End Function
    Public Function ListarArticulos(ByVal argTextoBuscado As String) As List(Of Articulo)
        Dim la As List(Of Articulo)
        Try
            la = mobj_D_AdminSiCoFa.ListarArticulos(argTextoBuscado)
            Return la

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ListarArticulos", ex.Message))
            Return Nothing

        End Try
    End Function
    Public Function InsertarArticulo(
                                    ByVal argCodigo As String,
                                    ByVal argCodBarras As String,
                                    ByVal argNombre As String,
                                    ByVal argAlicIVA As Decimal,
                                    ByVal argIdSeccion As String
                                    ) As String
        Try
            Dim IdArticulo As String = mobj_D_AdminSiCoFa.InsertarArticulo(
                                                                           UCase(argCodigo),
                                                                           UCase(argCodBarras),
                                                                           UCase(argNombre),
                                                                           argAlicIVA,
                                                                           argIdSeccion
                                                                           )
            Return IdArticulo

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarArticulo", ex.Message))
            Return ""

        End Try

    End Function
    Public Function ActualizarArticulo(
                                        ByVal argIdArticulo As String,
                                        ByVal argCodigo As String,
                                        ByVal argCodBarras As String,
                                        ByVal argNombre As String,
                                        ByVal argAlicIVA As Decimal,
                                        ByVal argBaja As Boolean,
                                        ByVal argIdSeccion As String
                                        ) As Boolean

        Try
            Dim Actualizado As Boolean = mobj_D_AdminSiCoFa.ActualizarArticulo(
                                                                             argIdArticulo,
                                                                             UCase(argCodigo),
                                                                             UCase(argCodBarras),
                                                                             UCase(argNombre),
                                                                             argAlicIVA,
                                                                             argBaja,
                                                                             argIdSeccion
                                                                             )
            Return Actualizado
        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ActualizarArticulo", ex.Message))
            Return False

        End Try

    End Function

#End Region

#Region "Administracion de Comprobantes"
    Public Function InsertarItemComprobante(
                                            ByVal argIdOperacion As Long,
                                            ByVal argIdArticulo As String,
                                            ByVal argDescripcion As String,
                                            ByVal argCantidad As Decimal,
                                            ByVal argAlicIVA As Decimal,
                                            ByVal argPrecioCosto As Decimal,
                                            ByVal argPrecioUnitario As Decimal,
                                            ByVal argDescuento As Decimal
                                            ) As Long


        Try
            Dim IdItem As Long = mobj_D_AdminSiCoFa.InsertarItemComprobante(
                                                                            argIdOperacion,
                                                                            argIdArticulo,
                                                                            argDescripcion,
                                                                            argCantidad,
                                                                            argAlicIVA,
                                                                            argPrecioCosto,
                                                                            argPrecioUnitario,
                                                                            argDescuento
                                                                            )
            Return IdItem

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarItemComprobante", ex.Message))
            Return 0
        End Try

    End Function

#End Region

#Region "Procesos del Negocio Generales"
    Public Function Provincias() As List(Of Provincia)
        Dim p As New List(Of Provincia)
        With p
            .Add(New Provincia("A", "NEUQUEN"))
            .Add(New Provincia("B", "BUENOS AIRES"))
            .Add(New Provincia("C", "CABA"))
            .Add(New Provincia("D", "LA RIOJA"))
            .Add(New Provincia("E", "ENTRE RIOS"))
            .Add(New Provincia("F", "FORMOSA"))
            .Add(New Provincia("G", "SANTIAGO DEL ESTERO"))
            .Add(New Provincia("H", "CHACO"))
            .Add(New Provincia("I", "MISIONES"))
            .Add(New Provincia("J", "CORRIENTES"))
            .Add(New Provincia("K", "SAN JUAN"))
            .Add(New Provincia("L", "LA PAMPA"))
            .Add(New Provincia("M", "MENDOZA"))
            .Add(New Provincia("N", "CATAMARCA"))
            .Add(New Provincia("O", "SAN LUIS"))
            .Add(New Provincia("P", "TUCUMAN"))
            .Add(New Provincia("Q", "TIERRA DEL FUEGO"))
            .Add(New Provincia("R", "RIO NEGRO"))
            .Add(New Provincia("S", "SANTA FE"))
            .Add(New Provincia("T", "SALTA"))
            .Add(New Provincia("U", "CHUBUT"))
            .Add(New Provincia("X", "CORDOBA"))
            .Add(New Provincia("Y", "JUJUY"))
            .Add(New Provincia("Z", "SANTA CRUZ"))
        End With

        Return p.OrderBy(Function(x) x.Provincia).ToList()

    End Function

#End Region

End Class
