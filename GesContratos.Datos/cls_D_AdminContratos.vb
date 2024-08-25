Imports System.Collections.Generic
Imports MySql.Data.MySqlClient
Imports SiCoFa.Entidades
Public Class cls_D_AdminContratos

#Region "Administracion de Clientes"
    Public Function ObtenerClientePorId(ByVal argIdCliente As Long) As Cliente
        Dim objCli As Cliente
        Try

            Dim sql As String = "SELECT IdCliente,Nombre,Domicilio,Localidad,Provincia,Telefono,Movil,Email,CodiTDoc,NumDoc,CodIVA FROM TblClientes WHERE IdCliente=" & argIdCliente
            Dim cmd As MySqlCommand = Mod_D_Admin.ConexionDB.Conexion.CreateCommand
            cmd.CommandType = CommandType.Text
            cmd.CommandText = sql
            Dim datos As MySqlDataReader = cmd.ExecuteReader()
            datos.Read()

            If datos.HasRows Then
                Dim IdCliente As Long = datos("IdCliente")
                Dim Nombre As String = datos("Nombre")
                Dim Domicilio As String = datos("Domicilio")
                Dim Localidad As String = datos("Localidad")
                Dim Provincia As String = datos("Provincia")
                Dim Telefono As String = datos("Telefono")
                Dim Movil As String = datos("Movil")
                Dim Email As String = datos("Email")
                Dim CodiTDoc As String = datos("CodiTDoc")
                Dim NumDoc As String = datos("NumDoc")
                Dim CodIVA As String = datos("CodIVA")
                objCli = New Cliente(IdCliente, Nombre, Domicilio, Localidad, Provincia, Telefono, Movil, Email, CodiTDoc, NumDoc, CodIVA)
            Else
                objCli = Nothing
            End If

            datos.Close()
            cmd.Dispose()
            Return objCli

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ObtenerClientePorId", ex.Message))
            Return Nothing
        End Try

    End Function
    Public Function ListarClientes(ByVal argTextoBuscado As String) As List(Of Cliente)
        Dim lc As New List(Of Cliente)
        Dim c As Cliente

        Try
            Dim sql As String
            If argTextoBuscado = "*" Then
                sql = "SELECT IdCliente,Nombre,Domicilio,Localidad,Provincia,Telefono,Movil,Email,CodiTDoc,NumDoc,CodIVA FROM TblClientes ORDER BY Nombre"
            Else
                sql = "SELECT IdCliente,Nombre,Domicilio,Localidad,Provincia,Telefono,Movil,Email,CodiTDoc,NumDoc,CodIVA FROM TblClientes WHERE Nombre LIKE '" & Replace(UCase(argTextoBuscado), " ", "%") & "%' ORDER BY Nombre"
            End If

            Dim cmd As MySqlCommand = Mod_D_Admin.ConexionDB.Conexion.CreateCommand
            cmd.CommandType = CommandType.Text
            cmd.CommandText = sql
            Dim datos As MySqlDataReader = cmd.ExecuteReader()

            If datos.HasRows Then

                While datos.Read()
                    c = New Cliente(datos("IdCliente"), datos("Nombre"), datos("Domicilio"), datos("Localidad"), datos("Provincia"), datos("Telefono"), datos("Movil"), datos("Email"), datos("CodiTDoc"), datos("NumDoc"), datos("CodIVA"))
                    lc.Add(c)
                End While
                datos.Close()
                cmd.Dispose()
                Return lc
            Else
                datos.Close()
                cmd.Dispose()
                Return Nothing
            End If

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

        Dim IdCliente As Integer
        Try

            Dim cmd As New MySqlCommand("InsertarCliente", Mod_D_Admin.ConexionDB.Conexion) With {.CommandType = CommandType.StoredProcedure}
            cmd.Parameters.AddWithValue("_Nombre", argNombre)
            cmd.Parameters.AddWithValue("_Domicilio", argDomicilio)
            cmd.Parameters.AddWithValue("_Localidad", argLocalidad)
            cmd.Parameters.AddWithValue("_Provincia", argProvincia)
            cmd.Parameters.AddWithValue("_Telefono", argTelefono)
            cmd.Parameters.AddWithValue("_Movil", argMovil)
            cmd.Parameters.AddWithValue("_Email", argEmail)
            cmd.Parameters.AddWithValue("_CodiTDoc", argCodiTDoc)
            cmd.Parameters.AddWithValue("_NumDoc", argNumDoc)
            cmd.Parameters.AddWithValue("_CodIVA", argCodIVA)
            cmd.Parameters.Add("_IdCliente", MySqlDbType.Int32)
            cmd.Parameters("_IdCliente").Direction = ParameterDirection.Output
            cmd.ExecuteNonQuery()
            IdCliente = CInt(cmd.Parameters("_IdCliente").Value)
            cmd.Dispose()
            Return IdCliente

        Catch Ex As Exception
            MsgBox(vecho.MensajeError(Me.ToString, "InsertarCliente", Ex.Message))
            Return 0
        End Try

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



        Try

            Dim cmd As New MySqlCommand("ActualizarCliente", Mod_D_Admin.ConexionDB.Conexion) With {.CommandType = CommandType.StoredProcedure}
            cmd.Parameters.AddWithValue("_IdCliente", argIdCliente)
            cmd.Parameters.AddWithValue("_Domicilio", argDomicilio)
            cmd.Parameters.AddWithValue("_Localidad", argLocalidad)
            cmd.Parameters.AddWithValue("_Provincia", argProvincia)
            cmd.Parameters.AddWithValue("_Telefono", argTelefono)
            cmd.Parameters.AddWithValue("_Movil", argMovil)
            cmd.Parameters.AddWithValue("_Email", argEmail)
            cmd.Parameters.AddWithValue("_CodiTDoc", argCodiTDoc)
            cmd.Parameters.AddWithValue("_NumDoc", argNumDoc)
            cmd.Parameters.AddWithValue("_CodIVA", argCodIVA)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            Return True

        Catch Ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ActualizarCliente", Ex.Message))
            Return False
        End Try

    End Function
#End Region

#Region "Administracion de Contratos"
    Public Function ListarGrupoContratos() As List(Of GrupoContratos)
        Dim lg As New List(Of GrupoContratos)
        Dim gc As GrupoContratos

        Try

            Dim sql As String = "SELECT IdGC,Descripcion,CodiAE,CuentaIngresos,CuentaActivos FROM TblGrupoContratos ORDER BY Descripcion"

            Dim cmd As MySqlCommand = Mod_D_Admin.ConexionDB.Conexion.CreateCommand
            cmd.CommandType = CommandType.Text
            cmd.CommandText = sql
            Dim datos As MySqlDataReader = cmd.ExecuteReader()

            If datos.HasRows Then
                While datos.Read()
                    Dim IdGC As Integer = datos("IdGC")
                    Dim Descripcion As String = datos("Descripcion")
                    Dim CodiAE As String = datos("CodiAE")
                    Dim CuentaIngresos = datos("CuentaIngresos")
                    Dim CuentaActivos = datos("CuentaActivos")

                    gc = New GrupoContratos(IdGC, Descripcion, CodiAE, CuentaIngresos, CuentaActivos)
                    lg.Add(gc)
                End While
            Else
                lg = Nothing

            End If

            datos.Close()
            cmd.Dispose()
            Return lg

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ListarGrupos", ex.Message))
            Return Nothing
        End Try


    End Function
    Public Function ObtenerGrupoContratosPorId(ByVal argIdGrupoContratos As Integer) As GrupoContratos
        Dim objGC As GrupoContratos
        Try

            Dim sql As String = "SELECT IdGC,Descripcion,CodiAE,CuentaIngresos,CuentaActivos FROM TblGrupoContratos WHERE IdGC=" & argIdGrupoContratos

            Dim cmd As MySqlCommand = Mod_D_Admin.ConexionDB.Conexion.CreateCommand
            cmd.CommandType = CommandType.Text
            cmd.CommandText = sql
            Dim datos As MySqlDataReader = cmd.ExecuteReader()
            datos.Read()

            If datos.HasRows = False Then
                datos.Close()
                cmd.Dispose()
                Return Nothing
                Exit Function
            End If

            objGC = New GrupoContratos(
                                       datos("IdGC"),
                                       datos("Descripcion"),
                                       datos("CodiAE"),
                                       datos("CuentaIngresos"),
                                       datos("CuentaActivos")
                                        )
            datos.Close()
            cmd.Dispose()
            Return objGC

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ObtenerGrupoContratosPorId", ex.Message))
            Return Nothing
        End Try

    End Function
    Public Function ObtenerContrato(ByVal Optional argIdContrato As Integer = 0, ByVal Optional argIdCliente As Long = 0) As Contrato
        Dim objC As Contrato
        Try

            Dim sql As String

            If argIdContrato > 0 Then
                sql = "SELECT IdContrato,IdGC,IdLocador,IdCliente,UsFTP,MesesT,Contacto,Deposito,InicioContrato,FinalContrato,UltimoDev,Factura,EstadoContrato FROM TblContratos WHERE IdContrato=" & argIdContrato
            ElseIf argIdCliente > 0 Then
                sql = "SELECT IdContrato,IdGC,IdLocador,IdCliente,UsFTP,MesesT,Contacto,Deposito,InicioContrato,FinalContrato,UltimoDev,Factura,EstadoContrato FROM TblContratos WHERE IdCliente=" & argIdCliente
            End If

            Dim cmd As MySqlCommand = Mod_D_Admin.ConexionDB.Conexion.CreateCommand
            cmd.CommandType = CommandType.Text
            cmd.CommandText = sql
            Dim datos As MySqlDataReader = cmd.ExecuteReader()
            datos.Read()

            If datos.HasRows Then

                objC = New Contrato(
                                 datos("IdContrato"),
                                 datos("IdGC"),
                                 datos("IdLocador"),
                                 datos("IdCliente"),
                                 datos("UsFTP"),
                                 datos("MesesT"),
                                 datos("Contacto"),
                                 datos("Deposito"),
                                 datos("InicioContrato"),
                                 datos("FinalContrato"),
                                 datos("UltimoDev"),
                                 datos("Factura"),
                                 datos("EstadoContrato")
                                 )

            Else
                objC = Nothing
                datos.Close()
                cmd.Dispose()
                Exit Function
            End If

            datos.Close()
            cmd.Dispose()
            objC.Cliente = Me.ObtenerClientePorId(argIdCliente)
            Return objC

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ObtenerContrato", ex.Message))
            Return Nothing
        End Try

    End Function
    Public Function ListarContratos(ByVal argEstadoContrato As String) As List(Of Contrato)
        Dim lc As New List(Of Contrato)
        Dim c As Contrato

        Try
            Dim sql As String = "SELECT IdContrato,IdGC,IdLocador,IdCliente,UsFTP,MesesT,Contacto,Deposito,InicioContrato,FinalContrato,UltimoDev,Factura,EstadoContrato FROM TblContratos WHERE EstadoContrato='" & argEstadoContrato & "'"
            Dim cmd As MySqlCommand = Mod_D_Admin.ConexionDB.Conexion.CreateCommand
            cmd.CommandType = CommandType.Text
            cmd.CommandText = sql
            Dim datos As MySqlDataReader = cmd.ExecuteReader()

            If datos.HasRows Then

                While datos.Read()
                    c = New Contrato(datos("IdContrato"), datos("IdGC"), datos("IdLocador"), datos("IdCliente"), datos("UsFTP"), datos("MesesT"), datos("Contacto"), datos("Deposito"), datos("InicioContrato"), datos("FinalContrato"), datos("UltimoDev"), datos("Factura"), datos("EstadoContrato"))
                    lc.Add(c)
                End While
                datos.Close()
                cmd.Dispose()
                Return lc
            Else
                datos.Close()
                cmd.Dispose()
                Return Nothing
            End If

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ListarClientes", ex.Message))
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

        Dim IdContrato As Integer
        Try

            Dim cmd As New MySqlCommand("InsertarContrato", Mod_D_Admin.ConexionDB.Conexion) With {.CommandType = CommandType.StoredProcedure}
            cmd.Parameters.AddWithValue("_IdGC", argIdGC)
            cmd.Parameters.AddWithValue("_IdLocador", argIdLocador)
            cmd.Parameters.AddWithValue("_IdCliente", argIdCliente)
            cmd.Parameters.AddWithValue("_UsFTP", argUsFTP)
            cmd.Parameters.AddWithValue("_MesesT", argMesesT)
            cmd.Parameters.AddWithValue("_Contacto", argContacto)
            cmd.Parameters.AddWithValue("_Deposito", argDeposito)
            cmd.Parameters.AddWithValue("_InicioContrato", argInicioContrato)
            cmd.Parameters.AddWithValue("_FinalContrato", argFinalContrato)
            cmd.Parameters.AddWithValue("_Factura", argFacturaServicios)
            cmd.Parameters.Add("_IdContrato", MySqlDbType.Int32)
            cmd.Parameters("_IdContrato").Direction = ParameterDirection.Output
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            IdContrato = CInt(cmd.Parameters("_IdContrato").Value)

        Catch Ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "InsertarContrato", Ex.Message))
            Return 0
        End Try
        Return IdContrato

    End Function
    Public Function ActualizarContrato(
                                        ByVal argIdContrato As Integer,
                                        ByVal argIdGC As Integer,
                                        ByVal argUsFTP As String,
                                        ByVal argMesesT As Integer,
                                        ByVal argContacto As String,
                                        ByVal argDeposito As Decimal,
                                        ByVal argInicioContrato As Date,
                                        ByVal argFinalContrato As Date,
                                        ByVal argFacturaServicios As Boolean,
                                        ByVal argEstadoContrato As String
                                        ) As Boolean



        Try

            Dim cmd As New MySqlCommand("ActualizarContrato", Mod_D_Admin.ConexionDB.Conexion) With {.CommandType = CommandType.StoredProcedure}
            cmd.Parameters.AddWithValue("_IdContrato", argIdContrato)
            cmd.Parameters.AddWithValue("_IdGC", argIdGC)
            cmd.Parameters.AddWithValue("_UsFTP", argUsFTP)
            cmd.Parameters.AddWithValue("_MesesT", argMesesT)
            cmd.Parameters.AddWithValue("_Contacto", argContacto)
            cmd.Parameters.AddWithValue("_Deposito", argDeposito)
            cmd.Parameters.AddWithValue("_InicioContrato", argInicioContrato)
            cmd.Parameters.AddWithValue("_FinalContrato", argFinalContrato)
            cmd.Parameters.AddWithValue("_Factura", argFacturaServicios)
            cmd.Parameters.AddWithValue("_EstadoContrato", argEstadoContrato)
            cmd.ExecuteNonQuery()

        Catch Ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ActualizarContrato", Ex.Message))
            Return False
        End Try
        Return True

    End Function

#End Region

#Region "Administracion de Locadores"
    Public Function ObtenerLocadorPorId(ByVal argIdLocador As Integer) As Locador
        Dim objEmp As Locador
        Try

            Dim sql As String = "SELECT IdLocador,Nombre,Domicilio,Localidad,Provincia,Telefono,CUIT,IB,IVA,InicActiv FROM TblLocadores WHERE IdLocador=" & argIdLocador
            Dim cmd As MySqlCommand = Mod_D_Admin.ConexionDB.Conexion.CreateCommand
            cmd.CommandType = CommandType.Text
            cmd.CommandText = sql
            Dim datos As MySqlDataReader = cmd.ExecuteReader()
            datos.Read()

            If datos.HasRows Then
                Dim IdLocador As Long = datos("IdLocador")
                Dim Nombre As String = datos("Nombre")
                Dim Domicilio As String = datos("Domicilio")
                Dim Localidad As String = datos("Localidad")
                Dim Provincia As String = datos("Provincia")
                Dim Telefono As String = datos("Telefono")
                Dim CUIT As String = datos("CUIT")
                Dim IB As String = datos("IB")
                Dim IVA As String = datos("IVA")
                Dim InicActiv As String = datos("InicActiv")
                objEmp = New Locador(IdLocador, Nombre, Domicilio, Localidad, Provincia, Telefono, CUIT, IB, IVA, InicActiv)
            Else
                objEmp = Nothing
            End If

            datos.Close()
            cmd.Dispose()
            Return objEmp

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ObtenerEmpresaPorId", ex.Message))
            Return Nothing
        End Try

    End Function
    Public Function LocadoresVigentes() As List(Of Locador)
        Dim list As New List(Of Locador)
        Dim l As Locador

        Try
            Dim sql As String = "SELECT IdLocador,Nombre,Domicilio,Localidad,Provincia,Telefono,CUIT,IB,IVA,InicActiv FROM TblLocadores ORDER BY Nombre"
            Dim cmd As MySqlCommand = Mod_D_Admin.ConexionDB.Conexion.CreateCommand
            cmd.CommandType = CommandType.Text
            cmd.CommandText = sql
            Dim datos As MySqlDataReader = cmd.ExecuteReader()

            If datos.HasRows Then

                While datos.Read()
                    l = New Locador(datos("IdLocador"), datos("Nombre"), datos("Domicilio"), datos("Localidad"), datos("Provincia"), datos("Telefono"), datos("CUIT"), datos("IB"), datos("IVA"), datos("InicActiv"))
                    list.Add(l)
                End While
                datos.Close()
                cmd.Dispose()
                Return list
            Else
                datos.Close()
                cmd.Dispose()
                Return Nothing
            End If

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ListarEmpresa", ex.Message))
            Return Nothing
        End Try

    End Function

#End Region

#Region "Administracion de Operaciones"
    Public Function ListarTipoOperaciones() As List(Of TipoOperacion)
        Dim lto As New List(Of TipoOperacion)
        Dim top As TipoOperacion

        Try

            Dim sql As String = "SELECT CodiTO,TipoOperacion FROM TblTipoOperaciones ORDER BY TipoOperacion"

            Dim cmd As MySqlCommand = Mod_D_Admin.ConexionDB.Conexion.CreateCommand
            cmd.CommandType = CommandType.Text
            cmd.CommandText = sql
            Dim datos As MySqlDataReader = cmd.ExecuteReader()

            If datos.HasRows Then
                While datos.Read()
                    top = New TipoOperacion(datos("CodiTO"), datos("TipoOperacion"))
                    lto.Add(top)
                End While
            Else
                lto = Nothing
            End If

            datos.Close()
            cmd.Dispose()
            Return lto

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ListarTipoOperaciones", ex.Message))
            Return Nothing
        End Try

    End Function
    Public Function RegistrarError(ByVal argIdOpera As String, argDescripcionError As String) As Integer
        Dim RegAfectados As Integer
        Try
            Dim sql As String = "UPDATE TblOpera SET EstadoOpera='Error',DesError='" & argDescripcionError & "' WHERE IdOperacion=" & argIdOpera

            Dim cmd As New MySqlCommand(sql, Mod_D_Admin.ConexionDB.Conexion)
            RegAfectados = cmd.ExecuteNonQuery
            cmd.Dispose()

        Catch Ex As Exception
            MsgBox(vecho.MensajeError(Me.ToString, "RegistrarError", Ex.Message))
            Return 0
        End Try
        Return RegAfectados
    End Function
    Public Function DevengarServicios(ByVal argIdUsuario As Integer) As Integer
        Try
            Dim RegAfectados As Integer
            Dim cmd1 As New MySqlCommand("DevengarServicios", Mod_D_Admin.ConexionDB.Conexion) With {.CommandType = CommandType.StoredProcedure}
            cmd1.Parameters.AddWithValue("_IdUsuario", argIdUsuario)
            cmd1.Parameters.Add("_NumRegistros", MySqlDbType.Int32)
            cmd1.Parameters("_NumRegistros").Direction = ParameterDirection.Output
            cmd1.ExecuteNonQuery()
            RegAfectados = CInt(cmd1.Parameters("_NumRegistros").Value)
            cmd1.Dispose()

            Dim cmd2 As New MySqlCommand("InsertarDetServicios", Mod_D_Admin.ConexionDB.Conexion) With {.CommandType = CommandType.StoredProcedure}
            cmd2.ExecuteNonQuery()
            cmd2.Dispose()

            Return RegAfectados

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "DevengarServicios", ex.Message))
            Return 0
        End Try

    End Function
    Public Sub AplicarPagosAbiertos(ByVal argIdUsuario As Integer)
        Try

            Dim cmd As New MySqlCommand("AplicarPagosAbiertos", Mod_D_Admin.ConexionDB.Conexion) With {.CommandType = CommandType.StoredProcedure}
            cmd.Parameters.AddWithValue("_IdUsuario", argIdUsuario)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "AplicarPagosAbiertos", ex.Message))

        End Try

    End Sub
    Public Function AplicarPagoCliente(ByVal argIdUsuario As Integer, ByVal argIdContrato As Integer, ByVal argCodiAE As String, ByVal argImporte As Decimal) As OperaCancel
        Try

            Dim cmd As New MySqlCommand("AplicarPagoCliente", Mod_D_Admin.ConexionDB.Conexion) With {.CommandType = CommandType.StoredProcedure}
            With cmd.Parameters
                .AddWithValue("_IdUsuario", argIdUsuario)
                .AddWithValue("_IdContrato", argIdContrato)
                .AddWithValue("_CodiAE", argCodiAE)
                .AddWithValue("_Importe", argImporte)
            End With

            cmd.Parameters.Add("_IdOperacion", MySqlDbType.Int64)
            cmd.Parameters("_IdOperacion").Direction = ParameterDirection.Output
            cmd.Parameters.Add("_SaldoPago", MySqlDbType.VarChar)
            cmd.Parameters("_SaldoPago").Direction = ParameterDirection.Output
            cmd.ExecuteNonQuery()
            Dim oc As New OperaCancel(cmd.Parameters("_IdOperacion").Value, 0, 0, cmd.Parameters("_SaldoPago").Value)
            cmd.Dispose()
            Return oc

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "AplicarPagoCliente", ex.Message))
            Return Nothing

        End Try
    End Function
    Public Function FacturarServicios(ByVal argIdUsuario As Integer, ByVal argCodiTC As String, ByVal argPVenta As String) As Integer
        Try
            Dim NumComprobantes As Integer
            Dim cmd As New MySqlCommand("FacturarServicios", Mod_D_Admin.ConexionDB.Conexion) With {.CommandType = CommandType.StoredProcedure}
            With cmd.Parameters
                .AddWithValue("_IdUsuario", argIdUsuario)
                .AddWithValue("_CodiTC", argCodiTC)
                .AddWithValue("_PVenta", argPVenta)
            End With

            cmd.Parameters.Add("_NumComprobantes", MySqlDbType.Int16)
            cmd.Parameters("_NumComprobantes").Direction = ParameterDirection.Output
            cmd.ExecuteNonQuery()
            If cmd.Parameters("_NumComprobantes").Value IsNot DBNull.Value Then
                NumComprobantes = cmd.Parameters("_NumComprobantes").Value
            End If

            cmd.Dispose()
            Return NumComprobantes

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "FacturarServicios", ex.Message))
            Return 0

        End Try
    End Function
    Public Function InsertarOperacion(ByVal argCodiAE As String, ByVal argCodiTO As String, ByVal argIdUsuario As Integer) As Operacion

        Try
            Dim IdOperacion As Long
            Dim cmd As New MySqlCommand("InsertarOperacion", Mod_D_Admin.ConexionDB.Conexion) With {.CommandType = CommandType.StoredProcedure}
            cmd.Parameters.AddWithValue("CodiAE", argCodiAE)
            cmd.Parameters.AddWithValue("CodiTO", argCodiTO)
            cmd.Parameters.AddWithValue("IdUsuario", argIdUsuario)
            cmd.Parameters.Add("IdOperacion", MySqlDbType.Int64)
            cmd.Parameters("IdOperacion").Direction = ParameterDirection.Output
            cmd.ExecuteNonQuery()
            IdOperacion = CInt(cmd.Parameters("IdOperacion").Value)
            cmd.Dispose()

            Dim objOpera As New Operacion(IdOperacion, Now, argCodiAE, argCodiTO, argIdUsuario, "INGRESADO", "", "")
            Return objOpera

        Catch Ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "InsertarOperacion", Ex.Message))
            Return Nothing
        End Try

    End Function
    Public Function FinalizarOperacion(ByVal argIdOpera As String) As Integer
        Dim RegAfectados As Integer
        Try
            Dim sql As String = "UPDATE TblOpera SET EstadoOpera='FINALIZADO' WHERE IdOperacion=" & argIdOpera

            Dim cmd As New MySqlCommand(sql, Mod_D_Admin.ConexionDB.Conexion)
            RegAfectados = cmd.ExecuteNonQuery
            cmd.Dispose()

            Return RegAfectados

        Catch Ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "FinalizarOperacion", Ex.Message))
            Return 0
        End Try
    End Function
    Public Function InsertarOperaCancel(ByVal argIdOperacion As Long, ByVal argIdOperaCancel As Long, ByVal argIdOperaPago As Long, ByVal argImporte As Decimal, ByVal argSaldoOperacion As Decimal, ByVal argSaldoPago As Decimal) As Long

        Dim IdOC As Long

        Try
            Dim cmd As New MySqlCommand("InsertarOperaCancel", Mod_D_Admin.ConexionDB.Conexion) With {.CommandType = CommandType.StoredProcedure}
            cmd.Parameters.AddWithValue("_IdOpera", argIdOperacion)
            cmd.Parameters.AddWithValue("_IdOperaC", argIdOperaCancel)
            cmd.Parameters.AddWithValue("_IdOperaP", argIdOperaPago)
            cmd.Parameters.AddWithValue("_Importe", argImporte)
            cmd.Parameters.AddWithValue("_SaldoO", argSaldoOperacion)
            cmd.Parameters.AddWithValue("_SaldoP", argSaldoPago)
            cmd.Parameters.Add("_IdOC", MySqlDbType.Int64)
            cmd.Parameters("_IdOC").Direction = ParameterDirection.Output
            cmd.ExecuteNonQuery()
            IdOC = CInt(cmd.Parameters("_IdOC").Value)
            cmd.Dispose()
            Return IdOC

        Catch Ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "InsertarOperaCancel", Ex.Message))
            Return 0
        End Try

    End Function
    Public Function InsertarOperaContrato(ByVal argIdOperacion As Long, ByVal argIdContrato As Integer, ByVal argResumen As String, ByVal argImporte As Decimal, ByVal argEstado As String) As Long

        Dim IdOC As Long

        Try
            Dim cmd As New MySqlCommand("InsertarOperaContrato", Mod_D_Admin.ConexionDB.Conexion) With {.CommandType = CommandType.StoredProcedure}
            cmd.Parameters.AddWithValue("_IdOpera", argIdOperacion)
            cmd.Parameters.AddWithValue("_IdContrato", argIdContrato)
            cmd.Parameters.AddWithValue("_Resu", argResumen)
            cmd.Parameters.AddWithValue("_Importe", argImporte)
            cmd.Parameters.AddWithValue("_Estado", argEstado)
            cmd.Parameters.Add("_IdOC", MySqlDbType.Int64)
            cmd.Parameters("_IdOC").Direction = ParameterDirection.Output
            cmd.ExecuteNonQuery()
            IdOC = CInt(cmd.Parameters("_IdOC").Value)
            cmd.Dispose()
            Return IdOC

        Catch Ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "InsertarOperaContrato", Ex.Message))
            Return 0
        End Try

    End Function
    Public Function ObtenerOperacion(ByVal argIdOpera As Long) As Operacion
        Dim objOpera As Operacion
        Try

            Dim sql As String = "SELECT IdOperacion,Fecha,CodiAE,CodiTO,IdUsuario,EstadoOpera,Observaciones,DesError FROM TblOpera WHERE IdOperacion=" & argIdOpera

            Dim cmd As MySqlCommand = Mod_D_Admin.ConexionDB.Conexion.CreateCommand
            cmd.CommandType = CommandType.Text
            cmd.CommandText = sql
            Dim datos As MySqlDataReader = cmd.ExecuteReader()
            datos.Read()

            If datos.HasRows Then
                objOpera = New Operacion(
                                        datos("IdOperacion"),
                                        datos("Fecha"),
                                        datos("CodiAE"),
                                        datos("CodiTO"),
                                        datos("IdUsuario"),
                                        datos("EstadoOpera"),
                                        datos("Observaciones").ToString,
                                        datos("DesError").ToString
                                        )

            Else
                objOpera = Nothing
            End If

            datos.Close()
            cmd.Dispose()
            Return objOpera

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ObtenerOperacion", ex.Message))
            Return Nothing
        End Try

    End Function
    Public Function ListaOperaContratos(ByVal Optional argIdOperacion As Long = 0, ByVal Optional argIdGC As Integer = 0, ByVal Optional argIdContrato As Integer = 0, ByVal Optional argResu As String = "", ByVal Optional argEstadoOpera As String = "") As List(Of OperaContrato)

        Dim loc As New List(Of OperaContrato)
        Dim oc As OperaContrato
        Try

            Dim sql As String = ""
            If argIdOperacion > 0 Then
                sql = "SELECT IdOperacion,IdContrato,Resu,ImpFacturado,ImpCancelado,ImpNoCancelado,EstadoOperaContrato FROM ConOperaContratos WHERE IdOperacion=" & argIdOperacion
                'Desde aca busco con IdGC

            ElseIf argIdGC > 0 And argResu = "" And argEstadoOpera = "" Then
                sql = "SELECT IdOperacion,IdContrato,Resu,ImpFacturado,ImpCancelado,ImpNoCancelado,EstadoOperaContrato FROM ConOperaContratos WHERE IdGC=" & argIdGC & " ORDER BY IdOperacion"
            ElseIf argIdGC > 0 And argResu <> "" And argEstadoOpera = "" Then
                sql = "SELECT IdOperacion,IdContrato,Resu,ImpFacturado,ImpCancelado,ImpNoCancelado,EstadoOperaContrato FROM ConOperaContratos WHERE IdGC=" & argIdGC & " AND Resu='" & argResu & "' ORDER BY IdOperacion"
            ElseIf argIdGC > 0 And argResu <> "" And argEstadoOpera <> "" Then
                sql = "SELECT IdOperacion,IdContrato,Resu,ImpFacturado,ImpCancelado,ImpNoCancelado,EstadoOperaContrato FROM ConOperaContratos WHERE IdGC=" & argIdGC & " AND Resu='" & argResu & "' AND EstadoOperaContrato='" & argEstadoOpera & "' ORDER BY IdOperacion"
            ElseIf argIdGC > 0 And argResu = "" And argEstadoOpera <> "" Then
                sql = "SELECT IdOperacion,IdContrato,Resu,ImpFacturado,ImpCancelado,ImpNoCancelado,EstadoOperaContrato FROM ConOperaContratos WHERE IdGC=" & argIdGC & " AND EstadoOperaContrato='" & argEstadoOpera & "' ORDER BY IdOperacion"

                'Desde aca busco con IdContrato no considero el IdOperacion
            ElseIf argIdContrato > 0 And argResu = "" And argEstadoOpera = "" Then
                sql = "SELECT IdOperacion,IdContrato,Resu,ImpFacturado,ImpCancelado,ImpNoCancelado,EstadoOperaContrato FROM ConOperaContratos WHERE IdContrato=" & argIdContrato & " ORDER BY IdOperacion"
            ElseIf argIdContrato > 0 And argResu <> "" And argEstadoOpera = "" Then
                sql = "SELECT IdOperacion,IdContrato,Resu,ImpFacturado,ImpCancelado,ImpNoCancelado,EstadoOperaContrato FROM ConOperaContratos WHERE IdContrato=" & argIdContrato & " AND Resu='" & argResu & "' ORDER BY IdOperacion"
            ElseIf argIdContrato > 0 And argResu <> "" And argEstadoOpera <> "" Then
                sql = "SELECT IdOperacion,IdContrato,Resu,ImpFacturado,ImpCancelado,ImpNoCancelado,EstadoOperaContrato FROM ConOperaContratos WHERE IdContrato=" & argIdContrato & " AND Resu='" & argResu & "' AND EstadoOperaContrato='" & argEstadoOpera & "' ORDER BY IdOperacion"
            ElseIf argIdContrato > 0 And argResu = "" And argEstadoOpera <> "" Then
                sql = "SELECT IdOperacion,IdContrato,Resu,ImpFacturado,ImpCancelado,ImpNoCancelado,EstadoOperaContrato FROM ConOperaContratos WHERE IdContrato=" & argIdContrato & " AND EstadoOperaContrato='" & argEstadoOpera & "' ORDER BY IdOperacion"

                'Desde aca no considero IdOperacion=0 ni el IdContrato=0 solo Resu y EstadoOpera
            ElseIf argIdOperacion = 0 And argIdContrato = 0 And argResu = "" And argEstadoOpera <> "" Then
                sql = "SELECT IdOperacion,IdContrato,Resu,ImpFacturado,ImpCancelado,ImpNoCancelado,EstadoOperaContrato FROM ConOperaContratos WHERE EstadoOperaContrato='" & argEstadoOpera & "' ORDER BY IdOperacion"
            End If

            Dim cmd As MySqlCommand = Mod_D_Admin.ConexionDB.Conexion.CreateCommand
            cmd.CommandType = CommandType.Text
            cmd.CommandText = sql
            Dim datos As MySqlDataReader = cmd.ExecuteReader()
            While datos.Read()
                oc = New OperaContrato(datos("IdOperacion"), datos("IdContrato"), datos("Resu"), datos("ImpFacturado"), datos("ImpCancelado"), datos("ImpNoCancelado"), datos("EstadoOperaContrato"))
                loc.Add(oc)
            End While
            datos.Close()
            cmd.Dispose()
            Return loc

        Catch ex As Exception
            Return Nothing
            Throw New Exception(vecho.MensajeError(Me.ToString, "OperaContratos", ex.Message))
        End Try

    End Function
    Public Function ListaPagosCliente(ByVal Optional argIdOperacion As Long = 0, ByVal Optional argIdContrato As Integer = 0, ByVal Optional argEstadoPago As String = "") As List(Of PagoCliente)

        Dim lpc As New List(Of PagoCliente)
        Dim pc As PagoCliente
        Try

            Dim sql As String = ""
            If argIdOperacion = 0 And argIdContrato = 0 And argEstadoPago = "" Then
                sql = "SELECT IdOperacion,IdContrato,ImpPagado,ImpAplicado,ImpNoAplicado,EstadoPago FROM ConPagoClientes ORDER BY IdOperacion"
            ElseIf argIdOperacion > 0 Then
                sql = "SELECT IdOperacion,IdContrato,ImpPagado,ImpAplicado,ImpNoAplicado,EstadoPago FROM ConPagoClientes WHERE IdOperacion=" & argIdOperacion & " ORDER BY IdOperacion"
            ElseIf argIdContrato > 0 And argEstadoPago = "" Then
                sql = "SELECT IdOperacion,IdContrato,ImpPagado,ImpAplicado,ImpNoAplicado,EstadoPago FROM ConPagoClientes WHERE IdContrato=" & argIdContrato & " ORDER BY IdOperacion"
            ElseIf argIdContrato > 0 And argEstadoPago <> "" Then
                sql = "SELECT IdOperacion,IdContrato,ImpPagado,ImpAplicado,ImpNoAplicado,EstadoPago FROM ConPagoClientes WHERE IdContrato=" & argIdContrato & " AND EstadoPago='" & argEstadoPago & "' ORDER BY IdOperacion"
            ElseIf argIdContrato = 0 And argEstadoPago <> "" Then
                sql = "SELECT IdOperacion,IdContrato,ImpPagado,ImpAplicado,ImpNoAplicado,EstadoPago FROM ConPagoClientes WHERE EstadoOperaContrato='" & argEstadoPago & "' ORDER BY IdOperacion"
            End If

            Dim cmd As MySqlCommand = Mod_D_Admin.ConexionDB.Conexion.CreateCommand
            cmd.CommandType = CommandType.Text
            cmd.CommandText = sql

            Dim datos As MySqlDataReader = cmd.ExecuteReader()

            If datos.HasRows Then
                While datos.Read()
                    pc = New PagoCliente(datos("IdOperacion"), datos("IdContrato"), datos("ImpPagado"), datos("ImpAplicado"), datos("ImpNoAplicado"), datos("EstadoPago"))
                    lpc.Add(pc)
                End While
            End If

            datos.Close()
            cmd.Dispose()
            Return lpc

        Catch ex As Exception
            Return Nothing
            Throw New Exception(vecho.MensajeError(Me.ToString, "ListaPagosCliente", ex.Message))
        End Try
    End Function


#End Region

#Region "Administracion de Servicios"
    Public Function ObtenerServicio(ByVal argCodiS As String) As Servicio
        Dim objSer As Servicio
        Try

            Dim sql As String = "SELECT CodiS,DescripcionServicio,Gravado,PUnit FROM TblServicios WHERE CodiS='" & argCodiS & "'"
            Dim cmd As MySqlCommand = Mod_D_Admin.ConexionDB.Conexion.CreateCommand
            cmd.CommandType = CommandType.Text
            cmd.CommandText = sql
            Dim datos As MySqlDataReader = cmd.ExecuteReader()
            datos.Read()

            If datos.HasRows Then
                objSer = New Servicio(datos("CodiS"), datos("DescripcionServicio"), datos("PUnit"))
            Else
                objSer = Nothing
            End If

            datos.Close()
            cmd.Dispose()
            Return objSer

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ObtenerServicio", ex.Message))
            Return Nothing
        End Try
    End Function
    Public Function ListarServicios() As List(Of Servicio)
        Dim ls As New List(Of Servicio)
        Dim sv As Servicio

        Try

            Dim sql As String = "SELECT CodiS,DescripcionServicio,PUnit FROM TblServicios ORDER BY DescripcionServicio"

            Dim cmd As MySqlCommand = Mod_D_Admin.ConexionDB.Conexion.CreateCommand
            cmd.CommandType = CommandType.Text
            cmd.CommandText = sql
            Dim datos As MySqlDataReader = cmd.ExecuteReader()

            If datos.HasRows Then
                While datos.Read()
                    sv = New Servicio(datos("CodiS"), datos("DescripcionServicio"), datos("PUnit"))
                    ls.Add(sv)
                End While
            Else
                ls = Nothing
            End If

            datos.Close()
            cmd.Dispose()
            Return ls

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ListarServicios", ex.Message))
            Return Nothing
        End Try

    End Function
    Public Function ListaServiciosAsociados(ByVal argIdContrato As Integer) As List(Of ServicioAsociado)
        Dim lsa As New List(Of ServicioAsociado)
        Dim sva As ServicioAsociado

        Try

            Dim sql As String = "SELECT IdDS,IdContrato,CodiS,Cantidad FROM TblSerAsociados WHERE IdContrato=" & argIdContrato

            Dim cmd As MySqlCommand = Mod_D_Admin.ConexionDB.Conexion.CreateCommand
            cmd.CommandType = CommandType.Text
            cmd.CommandText = sql
            Dim datos As MySqlDataReader = cmd.ExecuteReader()

            If datos.HasRows Then
                While datos.Read()
                    sva = New ServicioAsociado(datos("IdDS"), datos("CodiS"), datos("Cantidad"))
                    lsa.Add(sva)
                End While
            Else
                lsa = Nothing
            End If

            datos.Close()
            cmd.Dispose()

            If lsa IsNot Nothing Then
                For Each sa As ServicioAsociado In lsa
                    sa.Servicio = Me.ObtenerServicio(sa.CodiS)
                Next
            End If

            Return lsa

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ListaServiciosAsociados", ex.Message))
            Return Nothing
        End Try

    End Function
    Public Function EliminarServicioAsociado(ByVal argIdDS As Integer) As Integer
        Dim RegistrosAfectados As Integer
        Try

            Dim cmd As New MySqlCommand("EliminarServicioAsociado", Mod_D_Admin.ConexionDB.Conexion) With {.CommandType = CommandType.StoredProcedure}
            cmd.Parameters.AddWithValue("_IdDS", argIdDS)
            RegistrosAfectados = cmd.ExecuteNonQuery()
            cmd.Dispose()

        Catch Ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "EliminarServicioAsociado", Ex.Message))
            Return 0
        End Try
        Return RegistrosAfectados
    End Function
    Public Function InsertarServicioAsociado(ByVal argIdContrato As Integer, ByVal argCodiS As String) As Integer
        Dim IdDS As Integer
        Try

            Dim cmd As New MySqlCommand("InsertarServicioAsociado", Mod_D_Admin.ConexionDB.Conexion) With {.CommandType = CommandType.StoredProcedure}
            cmd.Parameters.AddWithValue("_IdContrato", argIdContrato)
            cmd.Parameters.AddWithValue("_CodiS", argCodiS)
            cmd.Parameters.Add("_IdDS", MySqlDbType.Int32)
            cmd.Parameters("_IdDS").Direction = ParameterDirection.Output
            cmd.ExecuteNonQuery()
            IdDS = CInt(cmd.Parameters("_IdDS").Value)
            cmd.Dispose()

        Catch Ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "InsertarServicioAsociado", Ex.Message))
            Return 0
        End Try
        Return IdDS
    End Function
    Public Function ActualizarServicioAsociado(ByVal argIdDS As Integer, ByVal argCantidad As Integer) As Integer
        Dim RegistrosAfectados As Integer
        Try

            Dim cmd As New MySqlCommand("ActualizarServicioAsociado", Mod_D_Admin.ConexionDB.Conexion) With {.CommandType = CommandType.StoredProcedure}
            cmd.Parameters.AddWithValue("_IdDS", argIdDS)
            cmd.Parameters.AddWithValue("_Cantidad", argCantidad)
            RegistrosAfectados = cmd.ExecuteNonQuery()
            cmd.Dispose()

        Catch Ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "D_AdminServicios", Ex.Message))
            Return 0
        End Try
        Return RegistrosAfectados
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

        Try

            Dim cmd As New MySqlCommand("InsertarComprobante", Mod_D_Admin.ConexionDB.Conexion) With {.CommandType = CommandType.StoredProcedure}
            With cmd.Parameters
                .AddWithValue("_IdOpera", argOperacion.IdOperacion)
                .AddWithValue("_CodiTC", argCodiTC)
                .AddWithValue("_IdCliente", argCliente.IdCliente)
                .AddWithValue("_ImpBto", argImpBto)
                .AddWithValue("_ImpEx", argImpEx)
                .AddWithValue("_ImpGrav1", argImpGrav1)
                .AddWithValue("_ImpNeto1", argImpNeto1)
                .AddWithValue("_ImpIVA1", argImpIVA1)
                .AddWithValue("_ImpGrav2", argImpGrav2)
                .AddWithValue("_ImpNeto2", argImpNeto2)
                .AddWithValue("_ImpIVA2", argImpIVA2)
                .AddWithValue("_ImpCB", argImpCB)
                .AddWithValue("_ImpEf", argImpEf)
                .AddWithValue("_ImpCC", argImpCC)
                .AddWithValue("_ImpTar", argImpTar)
                .AddWithValue("_IdOperAsoc", argIdOperAsoc)
                .AddWithValue("_TipoDoc", argCliente.Documento.TipoDoc.CodiTDoc)
                .AddWithValue("_NumDoc", argCliente.Documento.Numero)
                .AddWithValue("_Cliente", argCliente.Nombre)
                .AddWithValue("_Fiscal", argFiscal)
            End With

            cmd.Parameters.Add("_PVenta", MySqlDbType.VarChar)
            cmd.Parameters("_PVenta").Direction = ParameterDirection.Output
            cmd.Parameters.Add("_NumComp", MySqlDbType.VarChar)
            cmd.Parameters("_NumComp").Direction = ParameterDirection.Output
            cmd.Parameters.Add("_FechaComp", MySqlDbType.VarChar)
            cmd.Parameters("_FechaComp").Direction = ParameterDirection.Output
            cmd.ExecuteNonQuery()

            Dim objComp As New Comprobante(argOperacion.IdOperacion,
                                           argOperacion,
                                           argCodiTC,
                                           cmd.Parameters("_PVenta").Value,
                                           cmd.Parameters("_NumComp").Value,
                                           cmd.Parameters("_FechaComp").Value,
                                           argImpBto,
                                           argImpEx,
                                           argImpGrav1,
                                           argImpNeto1,
                                           argImpIVA1,
                                           argImpGrav2,
                                           argImpNeto2,
                                           argImpIVA2,
                                           argImpCB,
                                           argImpEf,
                                           argImpCC,
                                           argImpTar,
                                           Nothing,
                                           argCliente.IdCliente,
                                           argCliente,
                                           argIdOperAsoc,
                                           Nothing,
                                           argLocador,
                                           Nothing
                                           )

            cmd.Dispose()

            Return objComp

        Catch Ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "InsertarComprobante", Ex.Message))
            Return Nothing
        End Try
    End Function
    Public Sub ActualizarCAE(ByVal argCbte As Comprobante)

        Try
            Dim cmd As New MySqlCommand("ActualizarFE", Mod_D_Admin.ConexionDB.Conexion) With {.CommandType = CommandType.StoredProcedure}
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("_IdOpera", argCbte.Operacion.IdOperacion)
            cmd.Parameters.AddWithValue("_NumComp", argCbte.NumComp)
            cmd.Parameters.AddWithValue("_CAE", argCbte.CAE.NumCAE)
            cmd.Parameters.AddWithValue("_VtoCAE", argCbte.CAE.VtoCAE)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

        Catch Ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ActualizarCAE", Ex.Message))

        End Try

    End Sub
    Public Sub RegistrarComprobanteRechazado(ByVal argIdOpera As String)
        Try
            Dim sql As String = "UPDATE TblComprobantes SET NumComp='R' WHERE IdOperacion=" & argIdOpera

            Dim cmd As New MySqlCommand(sql, Mod_D_Admin.ConexionDB.Conexion)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

        Catch Ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "RegistrarComprobanteRechazado", Ex.Message))

        End Try

    End Sub
    Public Function ObtenerComprobante(ByVal argOperacion As Operacion) As Comprobante

        Try
            Dim objCbte As Comprobante
            Dim objCli As Cliente
            Dim objLoc As Locador
            Dim objCAE As CAE = Nothing
            Dim objDetalleC As List(Of ItemComprobante)
            Dim CodiTC As String
            Dim PrefComp As String
            Dim NumComp As String
            Dim IdCliente As Long
            Dim FechaComp As Date
            Dim ImpBto As Decimal
            Dim ImpEx As Decimal
            Dim ImpGrav1 As Decimal
            Dim ImpNeto1 As Decimal
            Dim ImpIVA1 As Decimal
            Dim ImpGrav2 As Decimal
            Dim ImpNeto2 As Decimal
            Dim ImpIVA2 As Decimal
            Dim ImpCB As Decimal
            Dim ImpEf As Decimal
            Dim ImpCC As Decimal
            Dim ImpTar As Decimal
            Dim IdOperAsoc As Long
            Dim CAE As String
            Dim VtoCAE As Date

            objLoc = Me.ObtenerLocadorPorId(1)
            Dim sql As String = "SELECT IdOperación,CodiTC,PrefComp,NumComp,FechaComp,IdCliente,ImpBto,ImpEx,ImpGrav1,ImpNeto1,ImpIVA1,ImpGrav2,ImpNeto2,ImpIVA2,ImpCB,ImpEf,ImpCC,ImpTar,IdOperAsoc,CAE,VtoCAE FROM TblComprobantes WHERE IdOperación=" & argOperacion.IdOperacion

            Dim cmd As MySqlCommand = Mod_D_Admin.ConexionDB.Conexion.CreateCommand
            cmd.CommandType = CommandType.Text
            cmd.CommandText = sql
            Dim datosC As MySqlDataReader = cmd.ExecuteReader()
            datosC.Read()

            If datosC.HasRows = False Then
                datosC.Close()
                cmd.Dispose()
                Throw New Exception("Comprobante no Encontrado")
            End If

            CodiTC = datosC("CodiTC")
            PrefComp = datosC("PrefComp")
            NumComp = datosC("NumComp").ToString
            IdCliente = datosC("IdCliente")
            FechaComp = datosC("FechaComp")
            ImpBto = datosC("ImpBto")
            ImpEx = datosC("ImpEx")
            ImpGrav1 = datosC("ImpGrav1")
            ImpNeto1 = datosC("ImpNeto1")
            ImpIVA1 = datosC("ImpIVA1")
            ImpGrav2 = datosC("ImpGrav2")
            ImpNeto2 = datosC("ImpNeto2")
            ImpIVA2 = datosC("ImpIVA2")
            ImpCB = datosC("ImpCB")
            ImpEf = datosC("ImpEf")
            ImpCC = datosC("ImpCC")
            ImpTar = datosC("ImpTar")
            IdOperAsoc = datosC("IdOperAsoc")
            CAE = datosC("CAE").ToString

            If datosC("VtoCAE") IsNot DBNull.Value Then
                VtoCAE = datosC("VtoCAE")
            End If

            datosC.Close()
            cmd.Dispose()

            objCli = Me.ObtenerClientePorId(IdCliente)

            objDetalleC = Me.ObtenerDetalleC(argOperacion.IdOperacion, Me.DisIva(CodiTC))

            If CAE <> "" Then
                objCAE = New CAE(NumComp, CAE, VtoCAE)
            End If

            If IdOperAsoc > 0 Then
                Dim objCompAsoc As Comprobante = ObtenerComprobanteAsoc(IdOperAsoc)
                objCbte = New Comprobante(argOperacion.IdOperacion, argOperacion, CodiTC, PrefComp, NumComp, FechaComp, ImpBto, ImpEx, ImpGrav1, ImpNeto1, ImpIVA1, ImpGrav2, ImpNeto2, ImpIVA2, ImpCB, ImpEf, ImpCC, ImpTar, objCAE, IdCliente, objCli, IdOperAsoc, objCompAsoc, objLoc, objDetalleC)
            Else
                objCbte = New Comprobante(argOperacion.IdOperacion, argOperacion, CodiTC, PrefComp, NumComp, FechaComp, ImpBto, ImpEx, ImpGrav1, ImpNeto1, ImpIVA1, ImpGrav2, ImpNeto2, ImpIVA2, ImpCB, ImpEf, ImpCC, ImpTar, objCAE, IdCliente, objCli, IdOperAsoc, Nothing, objLoc, objDetalleC)
            End If

            Return objCbte

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ObtenerComprobante", ex.Message))
            Return Nothing

        End Try

    End Function
    Private Function ObtenerComprobanteAsoc(ByVal argIdOperAsoc As Long) As Comprobante

        Try
            Dim objD_AdminOpera As New cls_D_AdminContratos
            Dim objOperaAsoc As Operacion = objD_AdminOpera.ObtenerOperacion(argIdOperAsoc)
            Dim objCbte As Comprobante
            Dim objCli As Cliente
            Dim objLoc As Locador
            Dim objCAE As CAE = Nothing
            'Dim objDetalleC As List(Of ItemComprobante)
            Dim CodiTC As String
            Dim PrefComp As String
            Dim NumComp As String
            Dim IdCliente As Long
            Dim FechaComp As Date
            Dim ImpBto As Decimal
            Dim ImpEx As Decimal
            Dim ImpGrav1 As Decimal
            Dim ImpNeto1 As Decimal
            Dim ImpIVA1 As Decimal
            Dim ImpGrav2 As Decimal
            Dim ImpNeto2 As Decimal
            Dim ImpIVA2 As Decimal
            Dim ImpCB As Decimal
            Dim ImpEf As Decimal
            Dim ImpCC As Decimal
            Dim ImpTar As Decimal
            Dim IdOperAsoc As Long
            Dim CAE As String
            Dim VtoCAE As Date

            objLoc = Me.ObtenerLocadorPorId(1)
            Dim sql As String = "SELECT IdOperación,CodiTC,PrefComp,NumComp,FechaComp,IdCliente,ImpBto,ImpEx,ImpGrav1,ImpNeto1,ImpIVA1,ImpGrav2,ImpNeto2,ImpIVA2,ImpCB,ImpEf,ImpCC,ImpTar,IdOperAsoc,CAE,VtoCAE FROM TblComprobantes WHERE IdOperación=" & argIdOperAsoc

            Dim cmd As MySqlCommand = Mod_D_Admin.ConexionDB.Conexion.CreateCommand
            cmd.CommandType = CommandType.Text
            cmd.CommandText = sql
            Dim datosC As MySqlDataReader = cmd.ExecuteReader()
            datosC.Read()

            If datosC.HasRows = False Then
                datosC.Close()
                cmd.Dispose()
                Throw New Exception("Comprobante no Encontrado")
            End If

            CodiTC = datosC("CodiTC")
            PrefComp = datosC("PrefComp")
            NumComp = datosC("NumComp").ToString
            IdCliente = datosC("IdCliente")
            FechaComp = datosC("FechaComp")
            ImpBto = datosC("ImpBto")
            ImpEx = datosC("ImpEx")
            ImpGrav1 = datosC("ImpGrav1")
            ImpNeto1 = datosC("ImpNeto1")
            ImpIVA1 = datosC("ImpIVA1")
            ImpGrav2 = datosC("ImpGrav2")
            ImpNeto2 = datosC("ImpNeto2")
            ImpIVA2 = datosC("ImpIVA2")
            ImpCB = datosC("ImpCB")
            ImpEf = datosC("ImpEf")
            ImpCC = datosC("ImpCC")
            ImpTar = datosC("ImpTar")
            IdOperAsoc = datosC("IdOperAsoc")
            CAE = datosC("CAE").ToString

            If datosC("VtoCAE") IsNot DBNull.Value Then
                VtoCAE = datosC("VtoCAE")
            End If

            datosC.Close()
            cmd.Dispose()

            objCli = Me.ObtenerClientePorId(IdCliente)

            'If CodiTC = "REC" Then
            'objDetalleC = Me.ObtenerDetalleR(argIdOperAsoc, Me.DisIva(CodiTC))
            'Else
            'objDetalleC = Me.ObtenerDetalleC(ar, Me.DisIva(CodiTC))
            'End If

            If CAE <> "" Then
                objCAE = New CAE(NumComp, CAE, VtoCAE)
            End If
            objCbte = New Comprobante(objOperaAsoc.IdOperacion, objOperaAsoc, CodiTC, PrefComp, NumComp, FechaComp, ImpBto, ImpEx, ImpGrav1, ImpNeto1, ImpIVA1, ImpGrav2, ImpNeto2, ImpIVA2, ImpCB, ImpEf, ImpCC, ImpTar, objCAE, IdCliente, objCli, IdOperAsoc, Nothing, objLoc, Nothing)
            Return objCbte

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ObtenerComprobanteAsoc", ex.Message))
            Return Nothing

        End Try

    End Function
    Public Function ObtenerComprobantesEnCola() As List(Of Comprobante)

        Dim objCola As New List(Of Comprobante)

        Try
            Dim objCbte As Comprobante
            Dim objLoc As Locador
            Dim objCAE As CAE = Nothing
            Dim IdOperacion As Long
            Dim CodiTC As String
            Dim PVenta As String
            Dim NumComp As String
            Dim IdCliente As Long
            Dim FechaComp As Date
            Dim ImpBto As Decimal
            Dim ImpEx As Decimal
            Dim ImpGrav1 As Decimal
            Dim ImpNeto1 As Decimal
            Dim ImpIVA1 As Decimal
            Dim ImpGrav2 As Decimal
            Dim ImpNeto2 As Decimal
            Dim ImpIVA2 As Decimal
            Dim ImpCB As Decimal
            Dim ImpEf As Decimal
            Dim ImpCC As Decimal
            Dim ImpTar As Decimal
            Dim IdOperAsoc As Long
            Dim CAE As String
            Dim VtoCAE As Date

            objLoc = Me.ObtenerLocadorPorId(1)
            Dim sql As String = "SELECT IdOperacion,CodiTC,PVenta,NumComp,FechaComp,IdCliente,ImpBto,ImpEx,ImpGrav1,ImpNeto1,ImpIVA1,ImpGrav2,ImpNeto2,ImpIVA2,ImpCB,ImpEf,ImpCC,ImpTar,IdOperAsoc,CAE,VtoCAE FROM TblComprobantes WHERE NumComp='E'"

            Dim cmd As MySqlCommand = Mod_D_Admin.ConexionDB.Conexion.CreateCommand
            cmd.CommandType = CommandType.Text
            cmd.CommandText = sql
            Dim datos As MySqlDataReader = cmd.ExecuteReader()
            'datos.Read()

            If datos.HasRows = False Then
                datos.Close()
                cmd.Dispose()
                Return Nothing
                Exit Function
            End If

            While datos.Read
                IdOperacion = datos("IdOperacion")
                CodiTC = datos("CodiTC")
                PVenta = datos("PVenta")
                NumComp = datos("NumComp").ToString
                IdCliente = datos("IdCliente")
                FechaComp = datos("FechaComp")
                ImpBto = datos("ImpBto")
                ImpEx = datos("ImpEx")
                ImpGrav1 = datos("ImpGrav1")
                ImpNeto1 = datos("ImpNeto1")
                ImpIVA1 = datos("ImpIVA1")
                ImpGrav2 = datos("ImpGrav2")
                ImpNeto2 = datos("ImpNeto2")
                ImpIVA2 = datos("ImpIVA2")
                ImpCB = datos("ImpCB")
                ImpEf = datos("ImpEf")
                ImpCC = datos("ImpCC")
                ImpTar = datos("ImpTar")
                IdOperAsoc = datos("IdOperAsoc")
                CAE = datos("CAE").ToString

                If datos("VtoCAE") IsNot DBNull.Value Then
                    VtoCAE = datos("VtoCAE")
                End If

                If CAE <> "" Then
                    objCAE = New CAE(NumComp, CAE, VtoCAE)
                End If

                objCbte = New Comprobante(IdOperacion, Nothing, CodiTC, PVenta, NumComp, FechaComp, ImpBto, ImpEx, ImpGrav1, ImpNeto1, ImpIVA1, ImpGrav2, ImpNeto2, ImpIVA2, ImpCB, ImpEf, ImpCC, ImpTar, objCAE, IdCliente, Nothing, IdOperAsoc, Nothing, objLoc, Nothing)
                objCola.Add(objCbte)
            End While

            datos.Close()
            cmd.Dispose()
            Return objCola

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ObtenerComprobantesEnCola", ex.Message))
            Return Nothing

        End Try

    End Function
    Public Function ObtenerComprobantes(ByVal argIdCliente As Integer, ByVal argCodiTC As String, ByVal argFechaDesde As String, ByVal argFechaHasta As String) As List(Of Comprobante)

        Dim objCola As New List(Of Comprobante)

        Try
            Dim objCbte As Comprobante
            Dim objCAE As CAE = Nothing
            Dim IdOperacion As Long
            Dim CodiTC As String
            Dim PVenta As String
            Dim NumComp As String
            Dim IdCliente As Long
            Dim FechaComp As Date
            Dim ImpBto As Decimal
            Dim ImpEx As Decimal
            Dim ImpGrav1 As Decimal
            Dim ImpNeto1 As Decimal
            Dim ImpIVA1 As Decimal
            Dim ImpGrav2 As Decimal
            Dim ImpNeto2 As Decimal
            Dim ImpIVA2 As Decimal
            Dim ImpCB As Decimal
            Dim ImpEf As Decimal
            Dim ImpCC As Decimal
            Dim ImpTar As Decimal
            Dim IdOperAsoc As Long
            Dim CAE As String
            Dim VtoCAE As Date

            Dim sql As String

            If argIdCliente = 0 And argCodiTC = "0" Then
                sql = "SELECT IdOperacion,CodiTC,PVenta,NumComp,FechaComp,IdCliente,ImpBto,ImpEx,ImpGrav1,ImpNeto1,ImpIVA1,ImpGrav2,ImpNeto2,ImpIVA2,ImpCB,ImpEf,ImpCC,ImpTar,IdOperAsoc,CAE,VtoCAE FROM TblComprobantes WHERE FechaComp BETWEEN '" & argFechaDesde & "' AND '" & argFechaHasta & "'"
            ElseIf argIdCliente > 0 And argCodiTC <> "0" Then
                sql = "SELECT IdOperacion,CodiTC,PVenta,NumComp,FechaComp,IdCliente,ImpBto,ImpEx,ImpGrav1,ImpNeto1,ImpIVA1,ImpGrav2,ImpNeto2,ImpIVA2,ImpCB,ImpEf,ImpCC,ImpTar,IdOperAsoc,CAE,VtoCAE FROM TblComprobantes WHERE CodiTC='" & argCodiTC & "' AND IdCliente=" & argIdCliente & " AND FechaComp BETWEEN '" & argFechaDesde & "' AND '" & argFechaHasta & "'"
            ElseIf argIdCliente = 0 And argCodiTC <> "0" Then
                sql = "SELECT IdOperacion,CodiTC,PVenta,NumComp,FechaComp,IdCliente,ImpBto,ImpEx,ImpGrav1,ImpNeto1,ImpIVA1,ImpGrav2,ImpNeto2,ImpIVA2,ImpCB,ImpEf,ImpCC,ImpTar,IdOperAsoc,CAE,VtoCAE FROM TblComprobantes WHERE CodiTC='" & argCodiTC & "' AND FechaComp BETWEEN '" & argFechaDesde & "' AND '" & argFechaHasta & "'"
            ElseIf argIdCliente > 0 And argCodiTC = "0" Then
                sql = "SELECT IdOperacion,CodiTC,PVenta,NumComp,FechaComp,IdCliente,ImpBto,ImpEx,ImpGrav1,ImpNeto1,ImpIVA1,ImpGrav2,ImpNeto2,ImpIVA2,ImpCB,ImpEf,ImpCC,ImpTar,IdOperAsoc,CAE,VtoCAE FROM TblComprobantes WHERE IdCliente=" & argIdCliente & " AND FechaComp BETWEEN '" & argFechaDesde & "' AND '" & argFechaHasta & "'"
            End If

            Dim cmd As MySqlCommand = Mod_D_Admin.ConexionDB.Conexion.CreateCommand
            cmd.CommandType = CommandType.Text
            cmd.CommandText = sql
            Dim datos As MySqlDataReader = cmd.ExecuteReader()

            If datos.HasRows = False Then
                datos.Close()
                cmd.Dispose()
                Return Nothing
                Exit Function
            End If

            While datos.Read
                IdOperacion = datos("IdOperacion")
                CodiTC = datos("CodiTC")
                PVenta = datos("PVenta")
                NumComp = datos("NumComp").ToString
                IdCliente = datos("IdCliente")
                FechaComp = datos("FechaComp")
                ImpBto = datos("ImpBto")
                ImpEx = datos("ImpEx")
                ImpGrav1 = datos("ImpGrav1")
                ImpNeto1 = datos("ImpNeto1")
                ImpIVA1 = datos("ImpIVA1")
                ImpGrav2 = datos("ImpGrav2")
                ImpNeto2 = datos("ImpNeto2")
                ImpIVA2 = datos("ImpIVA2")
                ImpCB = datos("ImpCB")
                ImpEf = datos("ImpEf")
                ImpCC = datos("ImpCC")
                ImpTar = datos("ImpTar")
                IdOperAsoc = datos("IdOperAsoc")
                CAE = datos("CAE").ToString

                If datos("VtoCAE") IsNot DBNull.Value Then
                    VtoCAE = datos("VtoCAE")
                End If

                If CAE <> "" Then
                    objCAE = New CAE(NumComp, CAE, VtoCAE)
                End If

                objCbte = New Comprobante(IdOperacion, Nothing, CodiTC, PVenta, NumComp, FechaComp, ImpBto, ImpEx, ImpGrav1, ImpNeto1, ImpIVA1, ImpGrav2, ImpNeto2, ImpIVA2, ImpCB, ImpEf, ImpCC, ImpTar, objCAE, IdCliente, Nothing, IdOperAsoc, Nothing, Nothing, Nothing)
                objCola.Add(objCbte)
            End While

            datos.Close()
            cmd.Dispose()
            Return objCola

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ObtenerComprobantesEnCola", ex.Message))
            Return Nothing

        End Try

    End Function
    Private Function DisIva(argCodiTC_SiCoFa As String) As Boolean
        Select Case argCodiTC_SiCoFa
            Case "FAA", "NCA", "FAM", "NCM"
                Return True
            Case Else
                Return False
        End Select
    End Function
    Public Function ObtenerDetalleC(ByVal argIdOperacion As Long, ByVal argDisIva As Boolean) As List(Of ItemComprobante)
        Dim objDetC As New List(Of ItemComprobante)

        Try
            Dim Sql As String = "SELECT IdOperaFactura,Descripcion,Cantidad,PUnit,Gravado FROM TblDetServicios WHERE IdOperaFactura=" & argIdOperacion

            Dim cmd As MySqlCommand = Mod_D_Admin.ConexionDB.Conexion.CreateCommand
            cmd.CommandType = CommandType.Text
            cmd.CommandText = Sql
            Dim datos As MySqlDataReader = cmd.ExecuteReader()
            Dim objItemC As ItemComprobante = Nothing

            If datos.HasRows = False Then
                datos.Close()
                cmd.Dispose()
                Return Nothing
                Exit Function
            End If

            While datos.Read()
                Dim Descripcion As String = datos("Descripcion")
                Dim Cantidad As Decimal = datos("Cantidad")
                Dim PUnit As Decimal = datos("PUnit")
                Dim Gravado As Integer = datos("Gravado")
                Dim Descuento As Decimal = 0
                Dim PDes As Decimal = 0
                Dim MotivoDes As String = ""

                objItemC = New ItemComprobante(Descripcion, Cantidad, PUnit, Gravado, argDisIva, Descuento, PDes, MotivoDes)

                objDetC.Add(objItemC)
            End While

            datos.Close()
            cmd.Dispose()
            Return objDetC

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ObtenerDetalleC", ex.Message))
            Return Nothing
        End Try
    End Function
    Public Function ListarTipoComprobantes() As List(Of TipoComprobante)
        Dim ltc As New List(Of TipoComprobante)
        Dim tc As TipoComprobante

        Try

            Dim sql As String = "SELECT CodiTC,TipoComp FROM TblTipoComp ORDER BY TipoComp"

            Dim cmd As MySqlCommand = Mod_D_Admin.ConexionDB.Conexion.CreateCommand
            cmd.CommandType = CommandType.Text
            cmd.CommandText = sql
            Dim datos As MySqlDataReader = cmd.ExecuteReader()

            If datos.HasRows Then
                While datos.Read()
                    tc = New TipoComprobante(datos("CodiTC"))
                    ltc.Add(tc)
                End While
            Else
                ltc = Nothing
            End If

            datos.Close()
            cmd.Dispose()
            Return ltc

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ListarTipoComprobantes", ex.Message))
            Return Nothing
        End Try
    End Function

#End Region

#Region "Administracion Asientos Contables"
    Public Sub EfectuarAsientoContable(ByVal argOperacion As Operacion, ByVal argAsiento As AsientoContable)

        Try

            Dim cmd As New MySqlCommand("InsertarAsientoContable", Mod_D_Admin.ConexionDB.Conexion) With {.CommandType = CommandType.StoredProcedure}
            cmd.Parameters.AddWithValue("_IdOpera", argOperacion.IdOperacion)
            cmd.Parameters.Add("_NumAs", MySqlDbType.Int64)
            cmd.Parameters("_NumAs").Direction = ParameterDirection.Output
            cmd.ExecuteNonQuery()

            Dim NumAsiento As Long = cmd.Parameters("_NumAs").Value
            cmd.Dispose()

            For Each iac As ItemAsientoContable In argAsiento.DetalleCuentas
                Dim cmd1 As New MySqlCommand("InsertarDetCuenta", Mod_D_Admin.ConexionDB.Conexion) With {.CommandType = CommandType.StoredProcedure}
                With cmd1.Parameters
                    .AddWithValue("_NumAs", NumAsiento)
                    .AddWithValue("_IdAf", iac.IdAf)
                    .AddWithValue("_CodiCta", iac.CodiCta)
                    .AddWithValue("_Importe", iac.Importe)
                End With
                cmd1.ExecuteNonQuery()

            Next

        Catch Ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "EfectuarAsientoContable", Ex.Message))

        End Try
    End Sub

#End Region

End Class
