Imports System.Collections.Generic
Imports MySql.Data.MySqlClient
Imports SiCoFa.Entidades
Public Class cls_D_AdminSiCoFa

#Region "Administracion de Clientes"
    Public Function ObtenerClientePorId(ByVal argIdCliente As Long) As Cliente

        Dim objCli As Cliente

        Try
            Dim sql As String = "SELECT IdCliente,Nombre,Domicilio,Localidad,Provincia,Telefono,Email,CodiTDoc,NumDoc,FechaAlta,Estado,CodIVA FROM TblClientes WHERE IdCliente=@IdCliente"

            Using cn As New MySqlConnection(Mod_D_Admin.strConexionDB)
                cn.Open()

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql
                    cmd.Parameters.AddWithValue("@IdCliente", argIdCliente)

                    Using datos As MySqlDataReader = cmd.ExecuteReader()
                        datos.Read()

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
        Dim lc As New List(Of Cliente)
        Dim c As Cliente

        Try
            Dim sql As String
            If argTextoBuscado = "*" Then
                sql = "SELECT IdCliente,Nombre,Domicilio,Localidad,Provincia,Telefono,Email,CodiTDoc,NumDoc,FechaAlta,Estado,CodIVA FROM TblClientes ORDER BY Nombre"
            Else
                sql = "SELECT IdCliente,Nombre,Domicilio,Localidad,Provincia,Telefono,Email,CodiTDoc,NumDoc,FechaAlta,Estado,CodIVA FROM TblClientes WHERE Nombre LIKE @Nombre ORDER BY Nombre"
            End If

            Using cn As New MySqlConnection(Mod_D_Admin.strConexionDB)
                cn.Open()

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
            Using cn As New MySqlConnection(Mod_D_Admin.strConexionDB)
                cn.Open()

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
            Using cn As New MySqlConnection(Mod_D_Admin.strConexionDB)
                cn.Open()

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
                    cmd.ExecuteNonQuery()
                End Using

            End Using

            Return True

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ActualizarCliente", Ex.Message))
            Return False

        End Try

    End Function
#End Region

#Region "Administracion de Proveedores"
    Public Function ObtenerProveedorPorId(ByVal argIdProveedor As Long) As Proveedor
        Dim objProv As Proveedor
        Try

            Dim sql As String = "SELECT IdCliente,Nombre,Domicilio,Localidad,Provincia,Telefono,Email,CodiTDoc,NumDoc,FechaAlta,Estado FROM TblProveedores WHERE IdProveedor=@IdProveedor"
            Using cn As New MySqlConnection(Mod_D_Admin.strConexionDB)
                cn.Open()

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
        Dim lp As New List(Of Proveedor)
        Dim p As Proveedor

        Try
            Dim sql As String
            If argTextoBuscado = "*" Then
                sql = "SELECT IdProveedor,Nombre,Domicilio,Localidad,Provincia,Telefono,Email,CodiTDoc,NumDoc,FechaAlta,Estado FROM TblProveedores ORDER BY Nombre"
            Else
                sql = "SELECT IdProveedor,Nombre,Domicilio,Localidad,Provincia,Telefono,Email,CodiTDoc,NumDoc,FechaAlta,Estado FROM TblProveedores WHERE Nombre LIKE @Nombre ORDER BY Nombre"
            End If

            Using cn As New MySqlConnection(Mod_D_Admin.strConexionDB)
                cn.Open()

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

        Dim IdProveedor As Integer
        Try
            Using cn As New MySqlConnection(Mod_D_Admin.strConexionDB)
                cn.Open()

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
                    IdProveedor = CInt(cmd.Parameters("_IdProveedor").Value)
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
            Using cn As New MySqlConnection(Mod_D_Admin.strConexionDB)
                cn.Open()

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
                    cmd.ExecuteNonQuery()
                End Using

            End Using

            Return True

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ActualizarProveedor", Ex.Message))

        End Try

    End Function
#End Region

#Region "Administracion de Empleados"
    Public Function ObtenerEmpleadoPorId(ByVal argIdEmpleado As Long) As Empleado

        Dim objEmp As Empleado

        Try
            Dim sql As String = "SELECT IdEmpleado,Nombre,Domicilio,Localidad,Provincia,Telefono,Email,CodiTDoc,NumDoc,FechaAlta,Estado FROM TblEmpleado WHERE IdEmpleado=@IdEmpleado"

            Using cn As New MySqlConnection(Mod_D_Admin.strConexionDB)
                cn.Open()

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql
                    cmd.Parameters.AddWithValue("@IdEmpleado", argIdEmpleado)

                    Using datos As MySqlDataReader = cmd.ExecuteReader()
                        datos.Read()

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
        Dim le As New List(Of Empleado)
        Dim e As Empleado

        Try
            Dim sql As String
            If argTextoBuscado = "*" Then
                sql = "SELECT IdEmpleado,Nombre,Domicilio,Localidad,Provincia,Telefono,Email,CodiTDoc,NumDoc,FechaAlta,Estado FROM TblEmpleados ORDER BY Nombre"
            Else
                sql = "SELECT IdEmpleado,Nombre,Domicilio,Localidad,Provincia,Telefono,Email,CodiTDoc,NumDoc,FechaAlta,Estado FROM TblEmpleados WHERE Nombre LIKE @Nombre ORDER BY Nombre"
            End If

            Using cn As New MySqlConnection(Mod_D_Admin.strConexionDB)
                cn.Open()

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

        Dim IdCliente As Integer
        Try
            Using cn As New MySqlConnection(Mod_D_Admin.strConexionDB)
                cn.Open()

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
                    IdCliente = CInt(cmd.Parameters("_IdEmpleado").Value)
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
            Using cn As New MySqlConnection(Mod_D_Admin.strConexionDB)
                cn.Open()

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
                    cmd.ExecuteNonQuery()
                End Using

            End Using

            Return True

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ActualizarEmpleado", Ex.Message))

        End Try

    End Function
#End Region

#Region "Administracion de Usuarios"
    Public Function ObtenerUsuarioPorId(ByVal argIdUsuario As Integer) As Usuario

        Dim objUs As Usuario

        Try
            Dim sql As String = "SELECT IdUsuario,Nombre,Domicilio,Localidad,Provincia,Telefono,Email,CodiTDoc,NumDoc,FechaAlta,Estado,Password FROM TblUsuarios WHERE IdUsuario=@IdUsuario"

            Using cn As New MySqlConnection(Mod_D_Admin.strConexionDB)
                cn.Open()

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql
                    cmd.Parameters.AddWithValue("@IdEmpleado", argIdUsuario)

                    Using datos As MySqlDataReader = cmd.ExecuteReader()
                        datos.Read()

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
        Dim lu As New List(Of Usuario)
        Dim u As Usuario

        Try
            Dim sql As String
            If argTextoBuscado = "*" Then
                sql = "SELECT IdUsuario,Nombre,Domicilio,Localidad,Provincia,Telefono,Email,CodiTDoc,NumDoc,FechaAlta,Estado,Password FROM TblUsuarios ORDER BY Nombre"
            Else
                sql = "SELECT IdUsuario,Nombre,Domicilio,Localidad,Provincia,Telefono,Email,CodiTDoc,NumDoc,FechaAlta,Estado,Password FROM TblUsuarios WHERE Nombre LIKE @Nombre ORDER BY Nombre"
            End If

            Using cn As New MySqlConnection(Mod_D_Admin.strConexionDB)
                cn.Open()

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

        Dim IdCliente As Integer
        Try
            Using cn As New MySqlConnection(Mod_D_Admin.strConexionDB)
                cn.Open()

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
                    IdCliente = CInt(cmd.Parameters("_IdUsuario").Value)
                End Using

            End Using
            Return IdCliente

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
            Using cn As New MySqlConnection(Mod_D_Admin.strConexionDB)
                cn.Open()

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
                    cmd.ExecuteNonQuery()
                End Using

            End Using

            Return True

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ActualizarUsuario", Ex.Message))

        End Try

    End Function
#End Region

#Region "Administracion de Empresas"
    Public Function ObtenerEmpresaPorId(ByVal argIdEmpresa As Long) As Empresa

        Dim objEmp As Empresa

        Try
            Dim sql As String = "SELECT IdEmpresa,Nombre,Domicilio,Localidad,Provincia,Telefono,Email,CodiTDoc,NumDoc,FechaAlta,Estado,CodIVA,IB FROM TblClientes WHERE IdEmpresa=@IdEmpresa"

            Using cn As New MySqlConnection(Mod_D_Admin.strConexionDB)
                cn.Open()

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql
                    cmd.Parameters.AddWithValue("@IdEmpresa", argIdEmpresa)

                    Using datos As MySqlDataReader = cmd.ExecuteReader()
                        datos.Read()

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
        Dim le As New List(Of Empresa)
        Dim e As Empresa

        Try
            Dim sql As String
            If argTextoBuscado = "*" Then
                sql = "SELECT IdEmpresa,Nombre,Domicilio,Localidad,Provincia,Telefono,Email,CodiTDoc,NumDoc,FechaAlta,Estado,CodIVA,IB FROM TblEmpresas ORDER BY Nombre"
            Else
                sql = "SELECT IdEmpresa,Nombre,Domicilio,Localidad,Provincia,Telefono,Email,CodiTDoc,NumDoc,FechaAlta,Estado,CodIVA,IB FROM TblEmpresas WHERE Nombre LIKE @Nombre ORDER BY Nombre"
            End If

            Using cn As New MySqlConnection(Mod_D_Admin.strConexionDB)
                cn.Open()

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

        Dim IdEmpresa As Integer
        Try
            Using cn As New MySqlConnection(Mod_D_Admin.strConexionDB)
                cn.Open()

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
                    IdEmpresa = CInt(cmd.Parameters("_IdEmpresa").Value)
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
            Using cn As New MySqlConnection(Mod_D_Admin.strConexionDB)
                cn.Open()

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
                    cmd.ExecuteNonQuery()
                End Using

            End Using

            Return True

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ActualizarEmpresa", Ex.Message))
            Return False

        End Try

    End Function
#End Region

#Region "Administracion de Operaciones"
    Public Function ListarTipoOperaciones() As List(Of TipoOperacion)
        Dim lto As New List(Of TipoOperacion)
        Dim top As TipoOperacion

        Try

            Dim sql As String = "SELECT CodiTO,TipoOperacion FROM TblTipoOperaciones ORDER BY TipoOperacion"

            Using cmd As MySqlCommand = Mod_D_Admin.ConexionDB.Conexion.CreateCommand
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

            Return lto

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ListarTipoOperaciones", ex.Message))
            Return Nothing
        End Try

    End Function
    Public Function RegistrarError(ByVal argIdOpera As Long, argDescripcionError As String) As Integer
        Dim RegAfectados As Integer
        Try
            Dim sql As String = "UPDATE TblOpera SET EstadoOpera='Error',DesError='" & argDescripcionError & "' WHERE IdOperacion=" & argIdOpera

            Using cmd As New MySqlCommand(sql, Mod_D_Admin.ConexionDB.Conexion)
                RegAfectados = cmd.ExecuteNonQuery
            End Using

        Catch Ex As Exception
            MsgBox(Vecho.MensajeError(Me.ToString, "RegistrarError", Ex.Message))
            Return 0
        End Try
        Return RegAfectados
    End Function
    Public Function DevengarServicios(ByVal argIdUsuario As Integer) As Integer
        Try
            Dim RegAfectados As Integer

            Using cmd1 As New MySqlCommand("DevengarServicios", Mod_D_Admin.ConexionDB.Conexion) With {.CommandType = CommandType.StoredProcedure}
                cmd1.Parameters.AddWithValue("_IdUsuario", argIdUsuario)
                cmd1.Parameters.Add("_NumRegistros", MySqlDbType.Int32)
                cmd1.Parameters("_NumRegistros").Direction = ParameterDirection.Output
                cmd1.ExecuteNonQuery()
                RegAfectados = CInt(cmd1.Parameters("_NumRegistros").Value)
            End Using

            Using cmd2 As New MySqlCommand("InsertarDetServicios", Mod_D_Admin.ConexionDB.Conexion) With {.CommandType = CommandType.StoredProcedure}
                cmd2.ExecuteNonQuery()
            End Using

            Return RegAfectados

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "DevengarServicios", ex.Message))
            Return 0
        End Try

    End Function
    Public Sub AplicarPagosAbiertos(ByVal argIdUsuario As Integer)
        Try

            Using cmd As New MySqlCommand("AplicarPagosAbiertos", Mod_D_Admin.ConexionDB.Conexion) With {.CommandType = CommandType.StoredProcedure}
                cmd.Parameters.AddWithValue("_IdUsuario", argIdUsuario)
                cmd.ExecuteNonQuery()
            End Using

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "AplicarPagosAbiertos", ex.Message))

        End Try

    End Sub
    Public Sub EstablecerItemsPago(ByVal argIdOpera As Long)

        Try

            Using cmd As New MySqlCommand("EstablecerItemsPago", Mod_D_Admin.ConexionDB.Conexion) With {.CommandType = CommandType.StoredProcedure}
                cmd.Parameters.AddWithValue("_IdOperacion", argIdOpera)
                cmd.ExecuteNonQuery()
            End Using

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "EstablecerItemsPago", ex.Message))

        End Try

    End Sub
    Public Function FacturarServicios(ByVal argIdUsuario As Integer, ByVal argCodiTC As String, ByVal argPVenta As String) As Integer
        Try
            Dim NumComprobantes As Integer

            Using cmd As New MySqlCommand("FacturarServicios", Mod_D_Admin.ConexionDB.Conexion) With {.CommandType = CommandType.StoredProcedure}

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

            End Using

            Return NumComprobantes

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "FacturarServicios", ex.Message))
            Return 0

        End Try
    End Function
    Public Function InsertarOperacion(ByVal argCodiAE As String, ByVal argCodiTO As String, ByVal argIdUsuario As Integer) As Operacion

        Try
            Dim IdOperacion As Long

            Using cmd As New MySqlCommand("InsertarOperacion", Mod_D_Admin.ConexionDB.Conexion) With {.CommandType = CommandType.StoredProcedure}
                cmd.Parameters.AddWithValue("CodiAE", argCodiAE)
                cmd.Parameters.AddWithValue("CodiTO", argCodiTO)
                cmd.Parameters.AddWithValue("IdUsuario", argIdUsuario)
                cmd.Parameters.Add("IdOperacion", MySqlDbType.Int64)
                cmd.Parameters("IdOperacion").Direction = ParameterDirection.Output
                cmd.ExecuteNonQuery()
                IdOperacion = CInt(cmd.Parameters("IdOperacion").Value)
            End Using

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

            Using cmd As New MySqlCommand(sql, Mod_D_Admin.ConexionDB.Conexion)
                RegAfectados = cmd.ExecuteNonQuery
            End Using

            Return RegAfectados

        Catch Ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "FinalizarOperacion", Ex.Message))
            Return 0
        End Try
    End Function
    Public Function InsertarOperaCancel(ByVal argIdOperacion As Long, ByVal argIdOperaCancel As Long, ByVal argIdOperaPago As Long, ByVal argImporte As Decimal, ByVal argSaldoOperacion As Decimal, ByVal argSaldoPago As Decimal) As Long

        Dim IdOC As Long

        Try
            Using cmd As New MySqlCommand("InsertarOperaCancel", Mod_D_Admin.ConexionDB.Conexion) With {.CommandType = CommandType.StoredProcedure}
                cmd.Parameters.AddWithValue("_IdOpera", argIdOperacion)
                cmd.Parameters.AddWithValue("_IdOperaC", argIdOperaCancel)
                cmd.Parameters.AddWithValue("_IdOperaP", argIdOperaPago)
                cmd.Parameters.AddWithValue("_Importe", argImporte)
                cmd.Parameters.AddWithValue("_SaldoO", argSaldoOperacion)
                cmd.Parameters.AddWithValue("_SaldoP", argSaldoPago)
                cmd.Parameters.Add("_IdOC", MySqlDbType.Int64)
                cmd.Parameters("_IdOC").Direction = ParameterDirection.Output
                cmd.ExecuteNonQuery()

                IdOC = CLng(cmd.Parameters("_IdOC").Value)

            End Using

            Return IdOC

        Catch Ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "InsertarOperaCancel", Ex.Message))
            Return 0
        End Try

    End Function
    Public Function InsertarOperaContrato(ByVal argIdOperacion As Long, ByVal argIdContrato As Integer, ByVal argResumen As String, ByVal argImporte As Decimal, ByVal argEstado As String) As Long

        Dim IdOC As Long

        Try
            Using cmd As New MySqlCommand("InsertarOperaContrato", Mod_D_Admin.ConexionDB.Conexion) With {.CommandType = CommandType.StoredProcedure}
                cmd.Parameters.AddWithValue("_IdOpera", argIdOperacion)
                cmd.Parameters.AddWithValue("_IdContrato", argIdContrato)
                cmd.Parameters.AddWithValue("_Resu", argResumen)
                cmd.Parameters.AddWithValue("_Importe", argImporte)
                cmd.Parameters.AddWithValue("_Estado", argEstado)
                cmd.Parameters.Add("_IdOC", MySqlDbType.Int64)
                cmd.Parameters("_IdOC").Direction = ParameterDirection.Output
                cmd.ExecuteNonQuery()

                IdOC = CLng(cmd.Parameters("_IdOC").Value)
            End Using

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

            Using cmd As MySqlCommand = Mod_D_Admin.ConexionDB.Conexion.CreateCommand
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

            Return objOpera

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ObtenerOperacion", ex.Message))
            Return Nothing
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

            Using cmd As MySqlCommand = Mod_D_Admin.ConexionDB.Conexion.CreateCommand
                cmd.CommandType = CommandType.Text
                cmd.CommandText = sql

                Using datos As MySqlDataReader = cmd.ExecuteReader()

                    If datos.HasRows Then
                        While datos.Read()
                            pc = New PagoCliente(datos("IdOperacion"), datos("IdContrato"), datos("ImpPagado"), datos("ImpAplicado"), datos("ImpNoAplicado"), datos("EstadoPago"))
                            lpc.Add(pc)
                        End While

                    Else
                        lpc = Nothing

                    End If

                End Using

            End Using

            Return lpc

        Catch ex As Exception
            Return Nothing
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ListaPagosCliente", ex.Message))
        End Try
    End Function


#End Region

#Region "Administracion Cuentas Email"
    Public Function ObtenerCuentaEmail() As CuentaEmail

        Dim objCEmail As CuentaEmail = Nothing

        Try

            Dim sql As String

            sql = "SELECT IdCEmail,Port,Host,User,Psw,Mail FROM TblCuentasEmail"

            Using cmd As MySqlCommand = Mod_D_Admin.ConexionDB.Conexion.CreateCommand()
                cmd.CommandType = CommandType.Text
                cmd.CommandText = sql

                Using datos As MySqlDataReader = cmd.ExecuteReader()
                    datos.Read()

                    If datos.HasRows Then
                        objCEmail = New CuentaEmail(datos("IdCEmail"), datos("Port"), datos("Host"), datos("User"), datos("Psw"), datos("Mail"))
                    End If
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

        Dim NumAsiento As Long

        Try

            Using cmd As New MySqlCommand("InsertarAsientoContable", Mod_D_Admin.ConexionDB.Conexion) With {.CommandType = CommandType.StoredProcedure}
                cmd.Parameters.AddWithValue("_IdOpera", argOperacion.IdOperacion)
                cmd.Parameters.Add("_NumAs", MySqlDbType.Int64)
                cmd.Parameters("_NumAs").Direction = ParameterDirection.Output
                cmd.ExecuteNonQuery()
                NumAsiento = cmd.Parameters("_NumAs").Value
            End Using

            For Each iac As ItemAsientoContable In argAsiento.DetalleCuentas
                Using cmd1 As New MySqlCommand("InsertarDetCuenta", Mod_D_Admin.ConexionDB.Conexion) With {.CommandType = CommandType.StoredProcedure}
                    With cmd1.Parameters
                        .AddWithValue("_NumAs", NumAsiento)
                        .AddWithValue("_IdAf", iac.IdAf)
                        .AddWithValue("_CodiCta", iac.CodiCta)
                        .AddWithValue("_Importe", iac.Importe)
                    End With
                    cmd1.ExecuteNonQuery()
                End Using
            Next

        Catch Ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "EfectuarAsientoContable", Ex.Message))

        End Try
    End Sub

#End Region

End Class
