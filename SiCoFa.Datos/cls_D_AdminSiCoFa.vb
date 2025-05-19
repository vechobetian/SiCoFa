Imports System.Collections.Generic
Imports MySql.Data.MySqlClient
Imports SiCoFa.Entidades
Public Class cls_D_AdminSiCoFa

#Region "Administracion de Clientes"
    Public Function ObtenerClientePorId(ByVal argIdCliente As Long) As Cliente

        Dim objConexionDB As New cls_Conexion
        Dim objCli As Cliente

        Try
            Dim sql As String = "SELECT IdCliente,Nombre,Domicilio,Localidad,Provincia,Telefono,Email,CodiTDoc,NumDoc,FechaAlta,Estado,CodIVA FROM TblClientes WHERE IdCliente=@IdCliente"

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql
                    cmd.Parameters.AddWithValue("@IdCliente", argIdCliente)

                    Using datos As MySqlDataReader = cmd.ExecuteReader()

                        If datos.Read Then
                            Dim IdCliente As Long = datos("IdCliente")
                            Dim Nombre As String = datos("Nombre")
                            Dim Domicilio As String = datos("Domicilio")
                            Dim Localidad As String = datos("Localidad")
                            Dim Provincia As String = datos("Provincia")
                            Dim Telefono As String = datos("Telefono")
                            Dim Email As String = datos("Email")
                            Dim CodiTDoc As String = datos("CodiTDoc")
                            Dim NumDoc As String = datos("NumDoc")
                            Dim FechaAlta As Date = datos("FechaAlta")
                            Dim Estado As String = datos("Estado")
                            Dim CodIVA As String = datos("CodIVA")
                            objCli = New Cliente(IdCliente, Nombre, Domicilio, Localidad, Provincia, Telefono, Email, CodiTDoc, NumDoc, FechaAlta, Estado, CodIVA)
                        Else
                            objCli = Nothing
                        End If

                    End Using

                End Using

            End Using
            Return objCli

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerClientePorId", ex.Message))
            Return Nothing

        End Try

    End Function
    Public Function ListarClientes(ByVal argTextoBuscado As String) As List(Of Cliente)
        Dim objConexionDB As New cls_Conexion
        Dim lc As New List(Of Cliente)
        Dim c As Cliente

        Try
            Dim sql As String
            If argTextoBuscado = "*" Then
                sql = "SELECT IdCliente,Nombre,Domicilio,Localidad,Provincia,Telefono,Email,CodiTDoc,NumDoc,FechaAlta,Estado,CodIVA FROM TblClientes ORDER BY Nombre"
            Else
                sql = "SELECT IdCliente,Nombre,Domicilio,Localidad,Provincia,Telefono,Email,CodiTDoc,NumDoc,FechaAlta,Estado,CodIVA FROM TblClientes WHERE Nombre LIKE @Nombre ORDER BY Nombre"
            End If

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql

                    If argTextoBuscado <> "*" Then
                        cmd.Parameters.AddWithValue("@Nombre", Replace(UCase(argTextoBuscado), " ", "%") & "%")
                    End If

                    Using datos As MySqlDataReader = cmd.ExecuteReader()

                        While datos.Read
                            c = New Cliente(datos("IdCliente"), datos("Nombre"), datos("Domicilio"), datos("Localidad"), datos("Provincia"), datos("Telefono"), datos("Email"), datos("CodiTDoc"), datos("NumDoc"), datos("FechaAlta"), datos("Estado"), datos("CodIVA"))
                            lc.Add(c)
                        End While

                    End Using

                End Using

            End Using

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
                                    ByVal argEmail As String,
                                    ByVal argCodiTDoc As String,
                                    ByVal argNumDoc As String,
                                    ByVal argCodIVA As String
                                    ) As Integer

        Dim IdCliente As Integer
        Try
            Dim objConexionDB As New cls_Conexion

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("InsertarCliente", cn) With {.CommandType = CommandType.StoredProcedure}
                    With cmd.Parameters
                        .Add("_Nombre", MySqlDbType.VarChar).Value = argNombre
                        .Add("_Domicilio", MySqlDbType.VarChar).Value = argDomicilio
                        .Add("_Localidad", MySqlDbType.VarChar).Value = argLocalidad
                        .Add("_Provincia", MySqlDbType.VarChar).Value = argProvincia
                        .Add("_Telefono", MySqlDbType.VarChar).Value = argTelefono
                        .Add("_Email", MySqlDbType.VarChar).Value = argEmail
                        .Add("_CodiTDoc", MySqlDbType.VarChar).Value = argCodiTDoc
                        .Add("_NumDoc", MySqlDbType.VarChar).Value = argNumDoc
                        .Add("_CodIVA", MySqlDbType.VarChar).Value = argCodIVA
                        .Add("_IdCliente", MySqlDbType.Int32)
                    End With

                    cmd.Parameters("_IdCliente").Direction = ParameterDirection.Output
                    cmd.ExecuteNonQuery()
                    IdCliente = CInt(cmd.Parameters("_IdCliente").Value)
                End Using

            End Using
            Return IdCliente

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarCliente", Ex.Message))

        End Try

    End Function
    Public Function ActualizarCliente(
                                    ByVal argIdCliente As Integer,
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
            Dim objConexionDB As New cls_Conexion

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("ActualizarCliente", cn) With {.CommandType = CommandType.StoredProcedure}
                    With cmd.Parameters
                        .Add("_IdCliente", MySqlDbType.Int32).Value = argIdCliente
                        .Add("_Domicilio", MySqlDbType.VarChar).Value = argDomicilio
                        .Add("_Localidad", MySqlDbType.VarChar).Value = argLocalidad
                        .Add("_Provincia", MySqlDbType.VarChar).Value = argProvincia
                        .Add("_Telefono", MySqlDbType.VarChar).Value = argTelefono
                        .Add("_Email", MySqlDbType.VarChar).Value = argEmail
                        .Add("_CodiTDoc", MySqlDbType.VarChar).Value = argCodiTDoc
                        .Add("_NumDoc", MySqlDbType.VarChar).Value = argNumDoc
                        .Add("_CodIVA", MySqlDbType.VarChar).Value = argCodIVA
                        .Add("_Estado", MySqlDbType.VarChar).Value = argEstado
                    End With

                    Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()
                    Return (filasAfectadas > 0) ' Devuelve True si se actualizó al menos una fila

                End Using

            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ActualizarCliente", Ex.Message))
            Return False

        End Try

    End Function
#End Region

#Region "Administracion de Cuentas Corriente"
    Public Function ObtenerCuentaCorrientePorIdCliente(ByVal argCliente As Cliente) As CuentaCorriente

        Dim objConexionDB As New cls_Conexion
        Dim objCC As CuentaCorriente

        Try
            Dim sql As String = "SELECT IdCC,IdCliente,Descripcion,Credito,FechaAlta,Observaciones,Estado FROM TblCtasCorriente WHERE IdCliente=@IdCliente"

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql
                    cmd.Parameters.AddWithValue("@IdCliente", argCliente.Id)

                    Using datos As MySqlDataReader = cmd.ExecuteReader()

                        If datos.Read Then
                            Dim IdCC As Long = datos("IdCC")
                            Dim IdCliente As Int32 = datos("IdCliente")
                            Dim Descripcion As String = datos("Descripcion")
                            Dim Credito As String = datos("Credito")
                            Dim FechaAlta As String = datos("FechaAlta")
                            Dim Estado As String = datos("Estado")
                            Dim Observaciones As String = datos("Observaciones")
                            objCC = New CuentaCorriente(IdCC, argCliente, Descripcion, Credito, FechaAlta, Observaciones, Estado)
                        Else
                            objCC = Nothing
                        End If

                    End Using

                End Using

            End Using
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

        Dim IdCC As Int16
        Try
            Dim objConexionDB As New cls_Conexion
            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("InsertarCuentaCorriente", cn) With {.CommandType = CommandType.StoredProcedure}
                    With cmd.Parameters
                        .Add("_IdCliente", MySqlDbType.Int32).Value = argIdCliente
                        .Add("_Descripcion", MySqlDbType.VarChar).Value = argDescripcion
                        .Add("_Credito", MySqlDbType.Decimal).Value = argCredito
                        .Add("_Observaciones", MySqlDbType.Text).Value = argObservaciones
                        .Add("_IdCC", MySqlDbType.Int64)
                    End With

                    cmd.Parameters("_IdCC").Direction = ParameterDirection.Output
                    cmd.ExecuteNonQuery()
                    IdCC = Convert.ToInt16(cmd.Parameters("_IdCC").Value)
                End Using

            End Using
            Return IdCC

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarCuentaCorriente", Ex.Message))

        End Try

    End Function
    Public Function ActualizarCuentaCorriente(
                                    ByVal argIdCC As Int32,
                                    ByVal argCredito As Decimal,
                                    ByVal argObservaciones As String,
                                    ByVal argEstado As String
                                    ) As Boolean


        Try
            Dim objConexionDB As New cls_Conexion
            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("ActualizarCuentaCorriente", cn) With {.CommandType = CommandType.StoredProcedure}
                    With cmd.Parameters
                        .Add("_IdCC", MySqlDbType.Int32).Value = argIdCC
                        .Add("_Credito", MySqlDbType.Decimal).Value = argCredito
                        .Add("_Observaciones", MySqlDbType.Text).Value = argObservaciones
                        .Add("_Estado", MySqlDbType.VarChar).Value = argEstado
                    End With

                    Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()
                    Return (filasAfectadas > 0) ' Devuelve True si se actualizó al menos una fila

                End Using

            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ActualizarCuentaCorriente", Ex.Message))
            Return False

        End Try

    End Function

#End Region

#Region "Administracion de Proveedores"
    Public Function ObtenerProveedorPorId(ByVal argIdProveedor As Long) As Proveedor

        Dim objConexionDB As New cls_Conexion
        Dim objProv As Proveedor
        Try

            Dim sql As String = "SELECT IdCliente,Nombre,Domicilio,Localidad,Provincia,Telefono,Email,CodiTDoc,NumDoc,FechaAlta,Estado FROM TblProveedores WHERE IdProveedor=@IdProveedor"
            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql
                    cmd.Parameters.AddWithValue("@IdProveedor", argIdProveedor)

                    Using datos As MySqlDataReader = cmd.ExecuteReader()

                        If datos.Read Then
                            Dim IdProveedor As Long = datos("IdProveedor")
                            Dim Nombre As String = datos("Nombre")
                            Dim Domicilio As String = datos("Domicilio")
                            Dim Localidad As String = datos("Localidad")
                            Dim Provincia As String = datos("Provincia")
                            Dim Telefono As String = datos("Telefono")
                            Dim Email As String = datos("Email")
                            Dim CodiTDoc As String = datos("CodiTDoc")
                            Dim NumDoc As String = datos("NumDoc")
                            Dim FechaAlta As Date = datos("FechaAlta")
                            Dim Estado As String = datos("Estado")
                            objProv = New Proveedor(IdProveedor, Nombre, Domicilio, Localidad, Provincia, Telefono, Email, CodiTDoc, NumDoc, FechaAlta, Estado)
                        Else
                            objProv = Nothing
                        End If

                    End Using

                End Using

            End Using

            Return objProv

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerProveedorPorId", ex.Message))
            Return Nothing

        End Try

    End Function
    Public Function ListarProveedores(ByVal argTextoBuscado As String) As List(Of Proveedor)

        Dim objConexionDB As New cls_Conexion
        Dim lp As New List(Of Proveedor)
        Dim p As Proveedor

        Try
            Dim sql As String
            If argTextoBuscado = "*" Then
                sql = "SELECT IdProveedor,Nombre,Domicilio,Localidad,Provincia,Telefono,Email,CodiTDoc,NumDoc,FechaAlta,Estado FROM TblProveedores ORDER BY Nombre"
            Else
                sql = "SELECT IdProveedor,Nombre,Domicilio,Localidad,Provincia,Telefono,Email,CodiTDoc,NumDoc,FechaAlta,Estado FROM TblProveedores WHERE Nombre LIKE @Nombre ORDER BY Nombre"
            End If

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql

                    If argTextoBuscado <> "*" Then
                        cmd.Parameters.AddWithValue("@Nombre", Replace(UCase(argTextoBuscado), " ", "%") & "%")
                    End If

                    Using datos As MySqlDataReader = cmd.ExecuteReader()

                        While datos.Read
                            p = New Proveedor(datos("IdProveedor"), datos("Nombre"), datos("Domicilio"), datos("Localidad"), datos("Provincia"), datos("Telefono"), datos("Email"), datos("CodiTDoc"), datos("NumDoc"), datos("FechaAlta"), datos("Estado"))
                            lp.Add(p)
                        End While

                    End Using

                End Using

            End Using

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

        Dim IdProveedor As Int32
        Try
            Dim objConexionDB As New cls_Conexion
            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("InsertarProveedor", cn) With {.CommandType = CommandType.StoredProcedure}
                    With cmd.Parameters
                        .Add("_Nombre", MySqlDbType.VarChar).Value = argNombre
                        .Add("_Domicilio", MySqlDbType.VarChar).Value = argDomicilio
                        .Add("_Localidad", MySqlDbType.VarChar).Value = argLocalidad
                        .Add("_Provincia", MySqlDbType.VarChar).Value = argProvincia
                        .Add("_Telefono", MySqlDbType.VarChar).Value = argTelefono
                        .Add("_Email", MySqlDbType.VarChar).Value = argEmail
                        .Add("_CodiTDoc", MySqlDbType.VarChar).Value = argCodiTDoc
                        .Add("_NumDoc", MySqlDbType.VarChar).Value = argNumDoc
                        .Add("_IdProveedor", MySqlDbType.Int32)
                    End With

                    cmd.Parameters("_IdProveedor").Direction = ParameterDirection.Output
                    cmd.ExecuteNonQuery()
                    IdProveedor = Convert.ToInt32(cmd.Parameters("_IdProveedor").Value)
                End Using

            End Using

            Return IdProveedor

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarProveedor", Ex.Message))

        End Try

    End Function
    Public Function ActualizarProveedor(
                                    ByVal argIdProveedor As Integer,
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
            Dim objConexionDB As New cls_Conexion
            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("ActualizarProveedor", cn) With {.CommandType = CommandType.StoredProcedure}
                    With cmd.Parameters
                        .Add("_IdProveedor", MySqlDbType.Int32).Value = argIdProveedor
                        .Add("_Domicilio", MySqlDbType.VarChar).Value = argDomicilio
                        .Add("_Localidad", MySqlDbType.VarChar).Value = argLocalidad
                        .Add("_Provincia", MySqlDbType.VarChar).Value = argProvincia
                        .Add("_Telefono", MySqlDbType.VarChar).Value = argTelefono
                        .Add("_Email", MySqlDbType.VarChar).Value = argEmail
                        .Add("_CodiTDoc", MySqlDbType.VarChar).Value = argCodiTDoc
                        .Add("_NumDoc", MySqlDbType.VarChar).Value = argNumDoc
                        .Add("_CodIVA", MySqlDbType.VarChar).Value = argCodIVA
                        .Add("_Estado", MySqlDbType.VarChar).Value = argEstado
                    End With

                    Dim filasAfectadas As Int32 = Convert.ToInt32(cmd.ExecuteNonQuery())
                    Return (filasAfectadas > 0) ' Devuelve True si se actualizó al menos una fila

                End Using

            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ActualizarProveedor", Ex.Message))

        End Try

    End Function
#End Region

#Region "Administracion de Empleados"
    Public Function ObtenerEmpleadoPorId(ByVal argIdEmpleado As Long) As Empleado

        Dim objConexionDB As New cls_Conexion
        Dim objEmp As Empleado

        Try
            Dim sql As String = "SELECT IdEmpleado,Nombre,Domicilio,Localidad,Provincia,Telefono,Email,CodiTDoc,NumDoc,FechaAlta,Estado FROM TblEmpleado WHERE IdEmpleado=@IdEmpleado"

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql
                    cmd.Parameters.AddWithValue("@IdEmpleado", argIdEmpleado)

                    Using datos As MySqlDataReader = cmd.ExecuteReader()

                        If datos.Read Then
                            Dim IdEmpleado As Long = datos("IdEmpleado")
                            Dim Nombre As String = datos("Nombre")
                            Dim Domicilio As String = datos("Domicilio")
                            Dim Localidad As String = datos("Localidad")
                            Dim Provincia As String = datos("Provincia")
                            Dim Telefono As String = datos("Telefono")
                            Dim Email As String = datos("Email")
                            Dim CodiTDoc As String = datos("CodiTDoc")
                            Dim NumDoc As String = datos("NumDoc")
                            Dim FechaAlta As Date = datos("FechaAlta")
                            Dim Estado As String = datos("Estado")
                            objEmp = New Empleado(IdEmpleado, Nombre, Domicilio, Localidad, Provincia, Telefono, Email, CodiTDoc, NumDoc, FechaAlta, Estado)
                        Else
                            objEmp = Nothing
                        End If

                    End Using

                End Using

            End Using

            Return objEmp

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerEmpleadoPorId", ex.Message))

        End Try

    End Function
    Public Function ListarEmpleados(ByVal argTextoBuscado As String) As List(Of Empleado)

        Dim objConexionDB As New cls_Conexion
        Dim le As New List(Of Empleado)
        Dim e As Empleado

        Try
            Dim sql As String
            If argTextoBuscado = "*" Then
                sql = "SELECT IdEmpleado,Nombre,Domicilio,Localidad,Provincia,Telefono,Email,CodiTDoc,NumDoc,FechaAlta,Estado FROM TblEmpleados ORDER BY Nombre"
            Else
                sql = "SELECT IdEmpleado,Nombre,Domicilio,Localidad,Provincia,Telefono,Email,CodiTDoc,NumDoc,FechaAlta,Estado FROM TblEmpleados WHERE Nombre LIKE @Nombre ORDER BY Nombre"
            End If

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql

                    If argTextoBuscado <> "*" Then
                        cmd.Parameters.AddWithValue("@Nombre", Replace(UCase(argTextoBuscado), " ", "%") & "%")
                    End If

                    Using datos As MySqlDataReader = cmd.ExecuteReader()

                        While datos.Read
                            e = New Empleado(datos("IdEmpleado"), datos("Nombre"), datos("Domicilio"), datos("Localidad"), datos("Provincia"), datos("Telefono"), datos("Email"), datos("CodiTDoc"), datos("NumDoc"), datos("FechaAlta"), datos("Estado"))
                            le.Add(e)
                        End While

                    End Using

                End Using

            End Using

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

        Dim IdCliente As Int32
        Try
            Dim objConexionDB As New cls_Conexion
            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("InsertarEmpleado", cn) With {.CommandType = CommandType.StoredProcedure}
                    With cmd.Parameters
                        .Add("_Nombre", MySqlDbType.VarChar).Value = argNombre
                        .Add("_Domicilio", MySqlDbType.VarChar).Value = argDomicilio
                        .Add("_Localidad", MySqlDbType.VarChar).Value = argLocalidad
                        .Add("_Provincia", MySqlDbType.VarChar).Value = argProvincia
                        .Add("_Telefono", MySqlDbType.VarChar).Value = argTelefono
                        .Add("_Email", MySqlDbType.VarChar).Value = argEmail
                        .Add("_CodiTDoc", MySqlDbType.VarChar).Value = argCodiTDoc
                        .Add("_NumDoc", MySqlDbType.VarChar).Value = argNumDoc
                        .Add("_IdEmpleado", MySqlDbType.Int32)
                    End With

                    cmd.Parameters("_IdEmpleado").Direction = ParameterDirection.Output
                    cmd.ExecuteNonQuery()
                    IdCliente = Convert.ToInt32(cmd.Parameters("_IdEmpleado").Value)
                End Using

            End Using
            Return IdCliente

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarEmpleado", Ex.Message))

        End Try

    End Function
    Public Function ActualizarEmpleado(
                                    ByVal argIdEmpleado As Integer,
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
            Dim objConexionDB As New cls_Conexion
            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("ActualizarEmpleado", cn) With {.CommandType = CommandType.StoredProcedure}
                    With cmd.Parameters
                        .Add("_IdEmpleado", MySqlDbType.Int32).Value = argIdEmpleado
                        .Add("_Domicilio", MySqlDbType.VarChar).Value = argDomicilio
                        .Add("_Localidad", MySqlDbType.VarChar).Value = argLocalidad
                        .Add("_Provincia", MySqlDbType.VarChar).Value = argProvincia
                        .Add("_Telefono", MySqlDbType.VarChar).Value = argTelefono
                        .Add("_Email", MySqlDbType.VarChar).Value = argEmail
                        .Add("_CodiTDoc", MySqlDbType.VarChar).Value = argCodiTDoc
                        .Add("_NumDoc", MySqlDbType.VarChar).Value = argNumDoc
                        .Add("_Estado", MySqlDbType.VarChar).Value = argEstado
                    End With

                    Dim filasAfectadas As Int32 = cmd.ExecuteNonQuery()
                    Return (filasAfectadas > 0) ' Devuelve True si se actualizó al menos una fila

                End Using

            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ActualizarEmpleado", Ex.Message))

        End Try

    End Function
#End Region

#Region "Administracion de Usuarios"
    Public Function ObtenerUsuarioPorId(ByVal argIdUsuario As Integer) As Usuario
        Dim objConexionDB As New cls_Conexion
        Dim objUs As Usuario

        Try
            Dim sql As String = "SELECT IdUsuario,Nombre,Domicilio,Localidad,Provincia,Telefono,Email,CodiTDoc,NumDoc,FechaAlta,Estado,Password FROM TblUsuarios WHERE IdUsuario=@IdUsuario"

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql
                    cmd.Parameters.AddWithValue("@IdEmpleado", argIdUsuario)

                    Using datos As MySqlDataReader = cmd.ExecuteReader()

                        If datos.Read Then
                            Dim IdEmpleado As Long = datos("IdUsuario")
                            Dim Nombre As String = datos("Nombre")
                            Dim Domicilio As String = datos("Domicilio")
                            Dim Localidad As String = datos("Localidad")
                            Dim Provincia As String = datos("Provincia")
                            Dim Telefono As String = datos("Telefono")
                            Dim Email As String = datos("Email")
                            Dim CodiTDoc As String = datos("CodiTDoc")
                            Dim NumDoc As String = datos("NumDoc")
                            Dim FechaAlta As Date = datos("FechaAlta")
                            Dim Estado As String = datos("Estado")
                            Dim Password As String = datos("Passsword")
                            objUs = New Usuario(IdEmpleado, Nombre, Domicilio, Localidad, Provincia, Telefono, Email, CodiTDoc, NumDoc, FechaAlta, Estado)
                        Else
                            objUs = Nothing
                        End If

                    End Using

                End Using

            End Using

            Return objUs

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerUsuarioPorId", ex.Message))

        End Try

    End Function
    Public Function ListarUsuarios(ByVal argTextoBuscado As String) As List(Of Usuario)
        Dim objConexionDB As New cls_Conexion
        Dim lu As New List(Of Usuario)
        Dim u As Usuario

        Try
            Dim sql As String
            If argTextoBuscado = "*" Then
                sql = "SELECT IdUsuario,Nombre,Domicilio,Localidad,Provincia,Telefono,Email,CodiTDoc,NumDoc,FechaAlta,Estado,Password FROM TblUsuarios ORDER BY Nombre"
            Else
                sql = "SELECT IdUsuario,Nombre,Domicilio,Localidad,Provincia,Telefono,Email,CodiTDoc,NumDoc,FechaAlta,Estado,Password FROM TblUsuarios WHERE Nombre LIKE @Nombre ORDER BY Nombre"
            End If

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql

                    If argTextoBuscado <> "*" Then
                        cmd.Parameters.AddWithValue("@Nombre", Replace(UCase(argTextoBuscado), " ", "%") & "%")
                    End If

                    Using datos As MySqlDataReader = cmd.ExecuteReader()

                        While datos.Read
                            u = New Usuario(datos("IdUsuario"), datos("Nombre"), datos("Domicilio"), datos("Localidad"), datos("Provincia"), datos("Telefono"), datos("Email"), datos("CodiTDoc"), datos("NumDoc"), datos("FechaAlta"), datos("Estado"))
                            lu.Add(u)
                        End While

                    End Using

                End Using

            End Using

            Return lu

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ListarUsuario", ex.Message))

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

        Dim IdUsuario As Int32
        Try
            Dim objConexionDB As New cls_Conexion
            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("InsertarUsuario", cn) With {.CommandType = CommandType.StoredProcedure}
                    With cmd.Parameters
                        .Add("_Nombre", MySqlDbType.VarChar).Value = argNombre
                        .Add("_Domicilio", MySqlDbType.VarChar).Value = argDomicilio
                        .Add("_Localidad", MySqlDbType.VarChar).Value = argLocalidad
                        .Add("_Provincia", MySqlDbType.VarChar).Value = argProvincia
                        .Add("_Telefono", MySqlDbType.VarChar).Value = argTelefono
                        .Add("_Email", MySqlDbType.VarChar).Value = argEmail
                        .Add("_CodiTDoc", MySqlDbType.VarChar).Value = argCodiTDoc
                        .Add("_NumDoc", MySqlDbType.VarChar).Value = argNumDoc
                        .Add("_IdUsuario", MySqlDbType.Int32)
                    End With

                    cmd.Parameters("_IdUsuario").Direction = ParameterDirection.Output
                    cmd.ExecuteNonQuery()
                    IdUsuario = Convert.ToInt32(cmd.Parameters("_IdUsuario").Value)
                End Using

            End Using
            Return IdUsuario

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarUsuario", Ex.Message))

        End Try

    End Function
    Public Function ActualizarUsuario(
                                    ByVal argIdUsuario As Integer,
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
            Dim objConexionDB As New cls_Conexion
            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("ActualizarUsuario", cn) With {.CommandType = CommandType.StoredProcedure}
                    With cmd.Parameters
                        .Add("_IdUsuario", MySqlDbType.Int32).Value = argIdUsuario
                        .Add("_Domicilio", MySqlDbType.VarChar).Value = argDomicilio
                        .Add("_Localidad", MySqlDbType.VarChar).Value = argLocalidad
                        .Add("_Provincia", MySqlDbType.VarChar).Value = argProvincia
                        .Add("_Telefono", MySqlDbType.VarChar).Value = argTelefono
                        .Add("_Email", MySqlDbType.VarChar).Value = argEmail
                        .Add("_CodiTDoc", MySqlDbType.VarChar).Value = argCodiTDoc
                        .Add("_NumDoc", MySqlDbType.VarChar).Value = argNumDoc
                        .Add("_Estado", MySqlDbType.VarChar).Value = argEstado
                    End With

                    Dim filasAfectadas As Int32 = cmd.ExecuteNonQuery()
                    Return (filasAfectadas > 0) ' Devuelve True si se actualizó al menos una fila

                End Using

            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ActualizarUsuario", Ex.Message))

        End Try

    End Function
#End Region

#Region "Administracion de Empresas"
    Public Function ObtenerEmpresaPorId(ByVal argIdEmpresa As Long) As Empresa

        Dim objConexionDB As New cls_Conexion
        Dim objEmp As Empresa

        Try
            Dim sql As String = "SELECT IdEmpresa,Nombre,Domicilio,Localidad,Provincia,Telefono,Email,CodiTDoc,NumDoc,FechaAlta,Estado,CodIVA,IB FROM TblClientes WHERE IdEmpresa=@IdEmpresa"

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql
                    cmd.Parameters.AddWithValue("@IdEmpresa", argIdEmpresa)

                    Using datos As MySqlDataReader = cmd.ExecuteReader()

                        If datos.Read Then
                            Dim IdEmpresa As Long = datos("IdEmpresa")
                            Dim Nombre As String = datos("Nombre")
                            Dim Domicilio As String = datos("Domicilio")
                            Dim Localidad As String = datos("Localidad")
                            Dim Provincia As String = datos("Provincia")
                            Dim Telefono As String = datos("Telefono")
                            Dim Email As String = datos("Email")
                            Dim CodiTDoc As String = datos("CodiTDoc")
                            Dim NumDoc As String = datos("NumDoc")
                            Dim FechaAlta As Date = datos("FechaAlta")
                            Dim Estado As String = datos("Estado")
                            Dim CodIVA As String = datos("CodIVA")
                            Dim IB As String = datos("IB")
                            objEmp = New Empresa(IdEmpresa, Nombre, Domicilio, Localidad, Provincia, Telefono, Email, CodiTDoc, NumDoc, FechaAlta, Estado, CodIVA, IB)
                        Else
                            objEmp = Nothing
                        End If

                    End Using

                End Using

            End Using
            Return objEmp

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerEmpresaPorId", ex.Message))
            Return Nothing

        End Try

    End Function
    Public Function ListarEmpresas(ByVal argTextoBuscado As String) As List(Of Empresa)
        Dim objConexionDB As New cls_Conexion
        Dim le As New List(Of Empresa)
        Dim e As Empresa

        Try
            Dim sql As String
            If argTextoBuscado = "*" Then
                sql = "SELECT IdEmpresa,Nombre,Domicilio,Localidad,Provincia,Telefono,Email,CodiTDoc,NumDoc,FechaAlta,Estado,CodIVA,IB FROM TblEmpresas ORDER BY Nombre"
            Else
                sql = "SELECT IdEmpresa,Nombre,Domicilio,Localidad,Provincia,Telefono,Email,CodiTDoc,NumDoc,FechaAlta,Estado,CodIVA,IB FROM TblEmpresas WHERE Nombre LIKE @Nombre ORDER BY Nombre"
            End If

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql

                    If argTextoBuscado <> "*" Then
                        cmd.Parameters.AddWithValue("@Nombre", Replace(UCase(argTextoBuscado), " ", "%") & "%")
                    End If

                    Using datos As MySqlDataReader = cmd.ExecuteReader()

                        While datos.Read
                            e = New Empresa(datos("IdEmpresa"), datos("Nombre"), datos("Domicilio"), datos("Localidad"), datos("Provincia"), datos("Telefono"), datos("Email"), datos("CodiTDoc"), datos("NumDoc"), datos("FechaAlta"), datos("Estado"), datos("CodIVA"), datos("IB"))
                            le.Add(e)
                        End While

                    End Using

                End Using

            End Using

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

        Dim IdEmpresa As Int32
        Try
            Dim objConexionDB As New cls_Conexion
            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("InsertarEmpresa", cn) With {.CommandType = CommandType.StoredProcedure}
                    With cmd.Parameters
                        .Add("_Nombre", MySqlDbType.VarChar).Value = argNombre
                        .Add("_Domicilio", MySqlDbType.VarChar).Value = argDomicilio
                        .Add("_Localidad", MySqlDbType.VarChar).Value = argLocalidad
                        .Add("_Provincia", MySqlDbType.VarChar).Value = argProvincia
                        .Add("_Telefono", MySqlDbType.VarChar).Value = argTelefono
                        .Add("_Email", MySqlDbType.VarChar).Value = argEmail
                        .Add("_NumDoc", MySqlDbType.VarChar).Value = argNumDoc
                        .Add("_FechaAlta", MySqlDbType.Date).Value = argFechaAlta
                        .Add("_CodIVA", MySqlDbType.VarChar).Value = argCodIVA
                        .Add("_IB", MySqlDbType.VarChar).Value = argIB
                        .Add("_IdEmpresa", MySqlDbType.Int32)
                    End With

                    cmd.Parameters("_IdEmpresa").Direction = ParameterDirection.Output
                    cmd.ExecuteNonQuery()
                    IdEmpresa = Convert.ToInt32(cmd.Parameters("_IdEmpresa").Value)
                End Using

            End Using
            Return IdEmpresa

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarEmpresa", Ex.Message))

        End Try

    End Function
    Public Function ActualizarEmpresa(
                                    ByVal argIdEmpresa As Integer,
                                    ByVal argDomicilio As String,
                                    ByVal argLocalidad As String,
                                    ByVal argProvincia As String,
                                    ByVal argTelefono As String,
                                    ByVal argEmail As String,
                                    ByVal argNumDoc As String,
                                    ByVal argFechaAlta As Date,
                                    ByVal argCodIVA As String,
                                    ByVal argEstado As String,
                                    ByVal argIB As String
                                    ) As Boolean



        Try
            Dim objConexionDB As New cls_Conexion
            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("ActualizarEmpresa", cn) With {.CommandType = CommandType.StoredProcedure}
                    With cmd.Parameters
                        .Add("_IdEmpresa", MySqlDbType.Int32).Value = argIdEmpresa
                        .Add("_Domicilio", MySqlDbType.VarChar).Value = argDomicilio
                        .Add("_Localidad", MySqlDbType.VarChar).Value = argLocalidad
                        .Add("_Provincia", MySqlDbType.VarChar).Value = argProvincia
                        .Add("_Telefono", MySqlDbType.VarChar).Value = argTelefono
                        .Add("_Email", MySqlDbType.VarChar).Value = argEmail
                        .Add("_NumDoc", MySqlDbType.VarChar).Value = argNumDoc
                        .Add("_FechaAlta", MySqlDbType.Date).Value = argFechaAlta
                        .Add("_CodIVA", MySqlDbType.VarChar).Value = argCodIVA
                        .Add("_Estado", MySqlDbType.VarChar).Value = argEstado
                        .Add("_IB", MySqlDbType.VarChar).Value = argIB
                    End With

                    Dim filasAfectadas As Int32 = cmd.ExecuteNonQuery()
                    Return (filasAfectadas > 0) ' Devuelve True si se actualizó al menos una fila

                End Using

            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ActualizarEmpresa", Ex.Message))
            Return False

        End Try

    End Function
#End Region

#Region "Administracion de Operaciones"

    Public Function ListarTipoOperaciones() As List(Of TipoOperacion)
        Dim objConexionDB As New cls_Conexion
        Dim lto As New List(Of TipoOperacion)
        Dim top As TipoOperacion

        Try

            Dim sql As String = "SELECT CodiTO,TipoOperacion FROM TblTipoOperaciones ORDER BY TipoOperacion"

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion
                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql

                    Using datos As MySqlDataReader = cmd.ExecuteReader()

                        If datos.HasRows Then
                            While datos.Read()
                                top = New TipoOperacion(datos("CodiTO"), datos("TipoOperacion"))
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
    Public Function RegistrarError(ByVal argIdOpera As Long, argDescripcionError As String) As Integer
        Dim objConexionDB As New cls_Conexion
        Dim RegAfectados As Integer
        Try
            Dim sql As String = "UPDATE TblOpera SET EstadoOpera='Error',DesError='" & argDescripcionError & "' WHERE IdOperacion=" & argIdOpera

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion
                Using cmd As New MySqlCommand(sql, cn)
                    RegAfectados = cmd.ExecuteNonQuery
                End Using
            End Using
        Catch Ex As Exception
            MsgBox(Vecho.MensajeError(Me.ToString, "RegistrarError", Ex.Message))
            Return 0
        End Try
        Return RegAfectados
    End Function

    Public Function InsertarOperacion(ByVal argCodiAE As String, ByVal argCodiTO As String, ByVal argIdUsuario As Integer) As Operacion

        Try

            Dim objConexionDB As New cls_Conexion
            Dim IdOperacion As Long

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion
                Using cmd As New MySqlCommand("InsertarOperacion", cn) With {.CommandType = CommandType.StoredProcedure}
                    cmd.Parameters.AddWithValue("CodiAE", argCodiAE)
                    cmd.Parameters.AddWithValue("CodiTO", argCodiTO)
                    cmd.Parameters.AddWithValue("IdUsuario", argIdUsuario)
                    cmd.Parameters.Add("IdOperacion", MySqlDbType.Int64)
                    cmd.Parameters("IdOperacion").Direction = ParameterDirection.Output
                    cmd.ExecuteNonQuery()
                    IdOperacion = CInt(cmd.Parameters("IdOperacion").Value)
                End Using
            End Using

            Dim objOpera As New Operacion(IdOperacion, Now, argCodiAE, argCodiTO, argIdUsuario, "INGRESADO", "", "")
            Return objOpera

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarOperacion", Ex.Message))
            Return Nothing
        End Try

    End Function

    Public Function FinalizarOperacion(ByVal argIdOpera As String) As Integer
        Dim objConexionDB As New cls_Conexion
        Dim RegAfectados As Integer
        Try
            Dim sql As String = "UPDATE TblOpera SET EstadoOpera='FINALIZADO' WHERE IdOperacion=" & argIdOpera

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion
                Using cmd As New MySqlCommand(sql, cn)
                    RegAfectados = cmd.ExecuteNonQuery
                End Using
            End Using

            Return RegAfectados

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "FinalizarOperacion", Ex.Message))
            Return 0
        End Try
    End Function

    Public Function ObtenerOperacion(ByVal argIdOpera As Long) As Operacion
        Dim objConexionDB As New cls_Conexion
        Dim objOpera As Operacion

        Try

            Dim sql As String = "SELECT IdOperacion,Fecha,CodiAE,CodiTO,IdUsuario,EstadoOpera,Observaciones,DesError FROM TblOpera WHERE IdOperacion=" & argIdOpera

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion
                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql

                    Using datos As MySqlDataReader = cmd.ExecuteReader()
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

                    End Using

                End Using
            End Using

            Return objOpera

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerOperacion", ex.Message))
            Return Nothing
        End Try

    End Function

#End Region

#Region "Administracion Cuentas Email"
    Public Function ObtenerCuentaEmail() As CuentaEmail
        Dim objConexionDB As New cls_Conexion
        Dim objCEmail As CuentaEmail = Nothing

        Try

            Dim sql As String

            sql = "SELECT IdCEmail,Port,Host,User,Psw,Mail FROM TblCuentasEmail"
            Using cn As MySqlConnection = objConexionDB.ObtenerConexion
                Using cmd As MySqlCommand = cn.CreateCommand()
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql

                    Using datos As MySqlDataReader = cmd.ExecuteReader()
                        datos.Read()

                        If datos.HasRows Then
                            objCEmail = New CuentaEmail(datos("IdCEmail"), datos("Port"), datos("Host"), datos("User"), datos("Psw"), datos("Mail"))
                        End If
                    End Using

                End Using

            End Using

            Return objCEmail

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ObtenerEmailEmpresa", ex.Message))
            Return Nothing
        End Try

    End Function
#End Region

#Region "Administracion Asientos Contables"
    Public Sub EfectuarAsientoContable(ByVal argOperacion As Operacion, ByVal argAsiento As AsientoContable)
        Dim objConexionDB As New cls_Conexion
        Dim NumAsiento As Long

        Try
            Using cn As MySqlConnection = objConexionDB.ObtenerConexion
                Using cmd As New MySqlCommand("InsertarAsientoContable", cn) With {.CommandType = CommandType.StoredProcedure}
                    cmd.Parameters.AddWithValue("_IdOpera", argOperacion.IdOperacion)
                    cmd.Parameters.Add("_NumAs", MySqlDbType.Int64)
                    cmd.Parameters("_NumAs").Direction = ParameterDirection.Output
                    cmd.ExecuteNonQuery()
                    NumAsiento = cmd.Parameters("_NumAs").Value
                End Using

                For Each iac As ItemAsientoContable In argAsiento.DetalleCuentas
                    Using cmd1 As New MySqlCommand("InsertarDetCuenta", cn) With {.CommandType = CommandType.StoredProcedure}
                        With cmd1.Parameters
                            .AddWithValue("_NumAs", NumAsiento)
                            .AddWithValue("_IdAf", iac.IdAf)
                            .AddWithValue("_CodiCta", iac.CodiCta)
                            .AddWithValue("_Importe", iac.Importe)
                        End With
                        cmd1.ExecuteNonQuery()
                    End Using
                Next
            End Using
        Catch Ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "EfectuarAsientoContable", Ex.Message))

        End Try
    End Sub

#End Region

#Region "Admnistracion de Secciones"
    Public Function ObtenerSeccionPorId(ByVal argIdSeccion As String) As Seccion

        Dim objConexionDB As New cls_Conexion
        Dim objSec As Seccion

        Try
            Dim sql As String = "SELECT IdSeccion,Seccion,EstablecerPrecio FROM TblSecciones WHERE IdSeccion=@IdSeccion"

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql
                    cmd.Parameters.AddWithValue("@IdSeccion", argIdSeccion)

                    Using datos As MySqlDataReader = cmd.ExecuteReader()

                        If datos.Read Then
                            Dim IdSeccion As String = datos("IdSeccion")
                            Dim Seccion As String = datos("Seccion")
                            Dim EstablecerPrecio As String = datos("EstablecerPrecio")
                            objSec = New Seccion(IdSeccion, Seccion, EstablecerPrecio)
                        Else
                            objSec = Nothing
                        End If

                    End Using

                End Using

            End Using
            Return objSec

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerSeccionPorId", ex.Message))
            Return Nothing

        End Try

    End Function
    Public Function ListarSecciones(ByVal argTextoBuscado As String) As List(Of Seccion)
        Dim objConexionDB As New cls_Conexion
        Dim ls As New List(Of Seccion)
        Dim s As Seccion

        Try
            Dim sql As String
            If argTextoBuscado = "*" Then
                sql = "SELECT IdSeccion,Seccion,EstablecerPrecio FROM TblSecciones ORDER BY Seccion"
            Else
                sql = "SELECT IdSeccion,Seccion,EstablecerPrecio FROM TblSecciones WHERE Seccion LIKE @Seccion ORDER BY Seccion"
            End If

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql

                    If argTextoBuscado <> "*" Then
                        cmd.Parameters.AddWithValue("@Seccion", Replace(UCase(argTextoBuscado), " ", "%") & "%")
                    End If

                    Using datos As MySqlDataReader = cmd.ExecuteReader()

                        While datos.Read
                            s = New Seccion(datos("IdSeccion"), datos("Seccion"), datos("EstablecerPrecio"))
                            ls.Add(s)
                        End While

                    End Using

                End Using

            End Using

            Return ls

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ListarSecciones", ex.Message))
            Return Nothing

        End Try

    End Function
    Public Function InsertarSeccion(
                                    ByVal argSeccion As String,
                                    ByVal argEstablecerPrecio As Boolean
                                    ) As String

        Dim objConexionDB As New cls_Conexion
        Dim IdSeccion As String
        Try
            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("InsertarSeccion", cn) With {.CommandType = CommandType.StoredProcedure}
                    With cmd.Parameters
                        .Add("_Seccion", MySqlDbType.VarChar).Value = argSeccion
                        .Add("_EstablecerPrecio", MySqlDbType.Bit).Value = argEstablecerPrecio
                        .Add("_IdSeccion", MySqlDbType.VarChar)
                    End With

                    cmd.Parameters("_IdSeccion").Direction = ParameterDirection.Output
                    cmd.ExecuteNonQuery()
                    IdSeccion = cmd.Parameters("_IdSeccion").ToString
                End Using

            End Using
            Return IdSeccion

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarSeccion", Ex.Message))
            Return ""

        End Try

    End Function
    Public Function ActualizarSeccion(
                                    ByVal argIdSeccion As String,
                                    ByVal argSeccion As String,
                                    ByVal argEstablecerPrecio As Boolean
                                    ) As Boolean



        Try
            Dim objConexionDB As New cls_Conexion
            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("ActualizarSeccion", cn) With {.CommandType = CommandType.StoredProcedure}
                    With cmd.Parameters
                        .Add("_IdSeccion", MySqlDbType.VarChar).Value = argIdSeccion
                        .Add("_Seccion", MySqlDbType.VarChar).Value = argSeccion
                        .Add("_EstablecerPrecio", MySqlDbType.Bit).Value = argEstablecerPrecio
                    End With

                    Dim filasAfectadas As Integer = Convert.ToInt32(cmd.ExecuteNonQuery())
                    Return (filasAfectadas > 0) ' Devuelve True si se actualizó al menos una fila

                End Using

            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ActualizarSeccion", Ex.Message))
            Return False

        End Try

    End Function


#End Region

#Region "Administracion de Articulos"
    Public Function ObtenerArticuloPorId(ByVal argIdArticulo As String) As Articulo
        Dim objConexionDB As New cls_Conexion
        Dim objArt As Articulo

        Try
            Dim sql As String = "SELECT IdArticulo,Codigo,CodBarras,Nombre,AlicIVA,FechaPrecio,PrecioCosto,PrecioVenta,Baja,IdSeccion,Seccion,EstablecerPrecio,ActualizarPrecio,Stock,CodiLP,ListaPrecios,Fabricante FROM ConArticulos WHERE IdArticulo=@IdArticulo"

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql
                    cmd.Parameters.AddWithValue("@IdArticulo", argIdArticulo)

                    Using datos As MySqlDataReader = cmd.ExecuteReader()

                        If datos.Read Then
                            ' Obtener ordinales de las columnas
                            Dim idArticuloOrdinal As Integer = datos.GetOrdinal("IdArticulo")
                            Dim codigoOrdinal As Integer = datos.GetOrdinal("Codigo")
                            Dim codBarrasOrdinal As Integer = datos.GetOrdinal("CodBarras")
                            Dim nombreOrdinal As Integer = datos.GetOrdinal("Nombre")
                            Dim alicIVAOrdinal As Integer = datos.GetOrdinal("AlicIVA")
                            Dim fechaPrecioOrdinal As Integer = datos.GetOrdinal("FechaPrecio")
                            Dim precioCostoOrdinal As Integer = datos.GetOrdinal("PrecioCosto")
                            Dim precioVentaOrdinal As Integer = datos.GetOrdinal("PrecioVenta")
                            Dim bajaOrdinal As Integer = datos.GetOrdinal("Baja")
                            Dim idSeccionOrdinal As Integer = datos.GetOrdinal("IdSeccion")
                            Dim seccionNombreOrdinal As Integer = datos.GetOrdinal("Seccion")
                            Dim establecerPrecioOrdinal As Integer = datos.GetOrdinal("EstablecerPrecio")
                            Dim actualizarPrecioOrdinal As Integer = datos.GetOrdinal("ActualizarPrecio")
                            Dim stockOrdinal As Integer = datos.GetOrdinal("Stock")
                            Dim codiLPOrdinal As Integer = datos.GetOrdinal("CodiLP")
                            Dim listaPreciosNombreOrdinal As Integer = datos.GetOrdinal("ListaPrecios")
                            Dim fabricanteOrdinal As Integer = datos.GetOrdinal("Fabricante")

                            Dim IdArticuloResult As String = datos.GetString(idArticuloOrdinal)
                            Dim CodigoResult As String = datos.GetString(codigoOrdinal)
                            Dim CodBarrasResult As String = datos.GetString(codBarrasOrdinal)
                            Dim NombreResult As String = datos.GetString(nombreOrdinal)
                            Dim AlicIVA As Decimal = If(datos.IsDBNull(alicIVAOrdinal), 0.0, Convert.ToDecimal(datos.GetValue(alicIVAOrdinal)))
                            Dim FechaPrecioResult As Date = If(datos.IsDBNull(fechaPrecioOrdinal), Date.MinValue, Convert.ToDateTime(datos.GetValue(fechaPrecioOrdinal)))
                            Dim PrecioCostoResult As Decimal = If(datos.IsDBNull(precioCostoOrdinal), 0, Convert.ToDecimal(datos.GetValue(precioCostoOrdinal)))
                            Dim PrecioVentaResult As Decimal = If(datos.IsDBNull(precioVentaOrdinal), 0, Convert.ToDecimal(datos.GetValue(precioVentaOrdinal)))
                            Dim BajaResult As Boolean = datos.GetBoolean(bajaOrdinal)
                            Dim IdSeccionResult As String = datos.GetString(idSeccionOrdinal)
                            Dim SeccionResult As String = datos.GetString(seccionNombreOrdinal)
                            Dim EstablecerPrecioResult As Boolean = datos.GetBoolean(establecerPrecioOrdinal)
                            Dim ActualizarPrecioResult As Boolean = datos.GetBoolean(actualizarPrecioOrdinal)
                            Dim StockResult As Decimal = If(datos.IsDBNull(stockOrdinal), 0, Convert.ToDecimal(datos.GetValue(stockOrdinal)))
                            Dim CodiLPResult As String = datos.GetString(codiLPOrdinal)
                            Dim ListaPreciosResult As String = datos.GetString(listaPreciosNombreOrdinal)
                            Dim FabricanteResult As String = datos.GetString(fabricanteOrdinal)

                            Dim objAlicuotaIVAResult As AlicuotaIVA = New AlicuotaIVA(AlicIVA)
                            Dim objSeccionResult As Seccion = New Seccion(IdSeccionResult, SeccionResult, EstablecerPrecioResult)
                            Dim objListaPreciosResult As ListaPrecios = New ListaPrecios(CodiLPResult, ListaPreciosResult)

                            objArt = New Articulo(IdArticuloResult, CodigoResult, CodBarrasResult, NombreResult, objAlicuotaIVAResult, FechaPrecioResult, PrecioCostoResult, PrecioVentaResult, BajaResult, objSeccionResult, ActualizarPrecioResult, StockResult, objListaPreciosResult, FabricanteResult)
                        Else
                            ' No se encontró ningún artículo con el ID especificado.
                            objArt = Nothing
                        End If

                    End Using

                End Using

            End Using
            Return objArt

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerArticuloPorId", ex.Message))
            Return Nothing

        End Try

    End Function
    Public Function ListarArticulos(ByVal argTextoBuscado As String) As List(Of Articulo)
        Dim objConexionDB As New cls_Conexion
        Dim objLA As New List(Of Articulo)

        Try
            Dim sql As String = "SELECT IdArticulo, Codigo, CodBarras, Nombre, AlicIVA, FechaPrecio, PrecioCosto, PrecioVenta, Baja, IdSeccion, Seccion, EstablecerPrecio, ActualizarPrecio, Stock, CodiLP, ListaPrecios, Fabricante FROM ConArticulos WHERE Nombre LIKE @Nombre OR Codigo = @Codigo OR CodBarras = @CodBarras ORDER BY Nombre"

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql

                    If argTextoBuscado <> "*" Then
                        ' Separamos los parámetros para Nombre y CodBarras
                        cmd.Parameters.AddWithValue("@Nombre", Replace(UCase(argTextoBuscado), " ", "%") & "%")
                        cmd.Parameters.AddWithValue("@Codigo", argTextoBuscado)
                        cmd.Parameters.AddWithValue("@CodBarras", argTextoBuscado)
                    End If

                    Using datos As MySqlDataReader = cmd.ExecuteReader()
                        Dim idArticuloOrdinal As Integer = datos.GetOrdinal("IdArticulo")
                        Dim codigoOrdinal As Integer = datos.GetOrdinal("Codigo")
                        Dim codBarrasOrdinal As Integer = datos.GetOrdinal("CodBarras")
                        Dim nombreOrdinal As Integer = datos.GetOrdinal("Nombre")
                        Dim alicIVAOrdinal As Integer = datos.GetOrdinal("AlicIVA")
                        Dim fechaPrecioOrdinal As Integer = datos.GetOrdinal("FechaPrecio")
                        Dim precioCostoOrdinal As Integer = datos.GetOrdinal("PrecioCosto")
                        Dim precioVentaOrdinal As Integer = datos.GetOrdinal("PrecioVenta")
                        Dim bajaOrdinal As Integer = datos.GetOrdinal("Baja")
                        Dim idSeccionOrdinal As Integer = datos.GetOrdinal("IdSeccion")
                        Dim seccionNombreOrdinal As Integer = datos.GetOrdinal("Seccion")
                        Dim establecerPrecioOrdinal As Integer = datos.GetOrdinal("EstablecerPrecio")
                        Dim actualizarPrecioOrdinal As Integer = datos.GetOrdinal("ActualizarPrecio")
                        Dim stockOrdinal As Integer = datos.GetOrdinal("Stock")
                        Dim codiLPOrdinal As Integer = datos.GetOrdinal("CodiLP")
                        Dim listaPreciosNombreOrdinal As Integer = datos.GetOrdinal("ListaPrecios")
                        Dim fabricanteOrdinal As Integer = datos.GetOrdinal("Fabricante")

                        While datos.Read
                            ' Manejo explícito de DBNull y conversión a tipos de datos .NET
                            Dim IdArticuloResult As String = datos.GetString(idArticuloOrdinal)
                            Dim CodigoResult As String = datos.GetString(codigoOrdinal)
                            Dim CodBarrasResult As String = datos.GetString(codBarrasOrdinal)
                            Dim NombreResult As String = datos.GetString(nombreOrdinal)
                            Dim AlicIVA As Decimal = If(datos.IsDBNull(alicIVAOrdinal), 0.0, Convert.ToDecimal(datos.GetValue(alicIVAOrdinal)))
                            Dim FechaPrecioResult As Date = If(datos.IsDBNull(fechaPrecioOrdinal), Date.MinValue, Convert.ToDateTime(datos.GetValue(fechaPrecioOrdinal)))
                            Dim PrecioCostoResult As Decimal = If(datos.IsDBNull(precioCostoOrdinal), 0, Convert.ToDecimal(datos.GetValue(precioCostoOrdinal)))
                            Dim PrecioVentaResult As Decimal = If(datos.IsDBNull(precioVentaOrdinal), 0, Convert.ToDecimal(datos.GetValue(precioVentaOrdinal)))
                            Dim BajaResult As Boolean = datos.GetBoolean(bajaOrdinal)
                            Dim IdSeccionResult As String = datos.GetString(idSeccionOrdinal)
                            Dim SeccionResult As String = datos.GetString(seccionNombreOrdinal)
                            Dim EstablecerPrecioResult As Boolean = datos.GetBoolean(establecerPrecioOrdinal)
                            Dim ActualizarPrecioResult As Boolean = datos.GetBoolean(actualizarPrecioOrdinal)
                            Dim StockResult As Decimal = If(datos.IsDBNull(stockOrdinal), 0, Convert.ToDecimal(datos.GetValue(stockOrdinal)))
                            Dim CodiLPResult As String = datos.GetString(codiLPOrdinal)
                            Dim ListaPreciosResult As String = datos.GetString(listaPreciosNombreOrdinal)
                            Dim FabricanteResult As String = datos.GetString(fabricanteOrdinal)

                            ' Crear objetos anidados
                            Dim objAlicuotaIVAResult As AlicuotaIVA = New AlicuotaIVA(AlicIVA)
                            Dim objSeccionResult As Seccion = New Seccion(IdSeccionResult, SeccionResult, EstablecerPrecioResult)
                            Dim objListaPreciosResult As ListaPrecios = New ListaPrecios(CodiLPResult, ListaPreciosResult)

                            Dim objArt = New Articulo(IdArticuloResult, CodigoResult, CodBarrasResult, NombreResult, objAlicuotaIVAResult, FechaPrecioResult, PrecioCostoResult, PrecioVentaResult, BajaResult, objSeccionResult, ActualizarPrecioResult, StockResult, objListaPreciosResult, FabricanteResult)
                            objLA.Add(objArt)
                        End While
                    End Using
                End Using
            End Using

            Return objLA

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ListarArticulos", ex.Message))
            Return New List(Of Articulo)

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
            Dim objConexionDB As New cls_Conexion
            Dim IdArticulo As String

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("InsertarArticulo", cn) With {.CommandType = CommandType.StoredProcedure}
                    With cmd.Parameters
                        .Add("_Codigo", MySqlDbType.VarChar).Value = argCodigo
                        .Add("_CodBarras", MySqlDbType.VarChar).Value = argCodBarras
                        .Add("_Nombre", MySqlDbType.VarChar).Value = argNombre
                        .Add("_AlicIVA", MySqlDbType.Decimal).Value = argAlicIVA
                        .Add("_IdSeccion", MySqlDbType.VarChar).Value = argIdSeccion
                        .Add("_IdArticulo", MySqlDbType.VarChar, 10)
                    End With

                    cmd.Parameters("_IdArticulo").Direction = ParameterDirection.Output
                    cmd.ExecuteNonQuery()
                    IdArticulo = cmd.Parameters("_IdArticulo").Value.ToString
                    Return IdArticulo
                End Using

            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarArticulo", Ex.Message))
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
            Dim objConexionDB As New cls_Conexion

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("ActualizarArticulo", cn) With {.CommandType = CommandType.StoredProcedure}
                    With cmd.Parameters
                        .Add("_IdArticulo", MySqlDbType.VarChar).Value = argIdArticulo
                        .Add("_Codigo", MySqlDbType.VarChar).Value = argCodigo
                        .Add("_CodBarras", MySqlDbType.VarChar).Value = argCodBarras
                        .Add("_Nombre", MySqlDbType.VarChar).Value = argNombre
                        .Add("_AlicIVA", MySqlDbType.Decimal).Value = argAlicIVA
                        .Add("_Baja", MySqlDbType.Bit).Value = argBaja
                        .Add("_IdSeccion", MySqlDbType.VarChar).Value = argIdSeccion
                    End With

                    Dim FilasAfectadas As Int32 = Convert.ToInt32(cmd.ExecuteNonQuery())
                    Return (FilasAfectadas > 0) ' Devuelve True si se actualizó al menos una fila

                End Using

            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ActualizarArticulo", Ex.Message))

        End Try

    End Function
#End Region


End Class
