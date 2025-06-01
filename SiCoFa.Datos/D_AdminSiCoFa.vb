Imports System.Collections.Generic
Imports MySql.Data.MySqlClient
Imports SiCoFa.Entidades
Public Class D_AdminSiCoFa

#Region "Administracion de Clientes"
    Public Function ObtenerClientePorId(ByVal argIdCliente As Long) As Cliente

        Dim objConexionDB As New D_Conexion
        Dim objCli As Cliente = Nothing

        Try
            Dim sql As String = "SELECT IdCliente,Nombre,Domicilio,Localidad,Provincia,Telefono,Email,CodiTDoc,NumDoc,FechaAlta,Estado,CodIVA FROM TblClientes WHERE IdCliente=@IdCliente"

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql
                    cmd.Parameters.AddWithValue("@IdCliente", argIdCliente)

                    Using datos As MySqlDataReader = cmd.ExecuteReader()

                        If datos.Read() Then
                            objCli = New Cliente(
                                                datos.GetInt32("IdCliente"),
                                                datos.GetString("Nombre"),
                                                If(datos.IsDBNull(datos.GetOrdinal("Domicilio")), "", datos.GetString("Domicilio")),
                                                If(datos.IsDBNull(datos.GetOrdinal("Localidad")), "", datos.GetString("Localidad")),
                                                If(datos.IsDBNull(datos.GetOrdinal("Provincia")), "", datos.GetString("Provincia")),
                                                If(datos.IsDBNull(datos.GetOrdinal("Telefono")), "", datos.GetString("Telefono")),
                                                If(datos.IsDBNull(datos.GetOrdinal("Email")), "", datos.GetString("Email")),
                                                datos.GetString("CodiTDoc"),
                                                datos.GetString("NumDoc"),
                                                datos.GetDateTime("FechaAlta"),
                                                datos.GetString("Estado"),
                                                datos.GetString("CodIVA")
                                                )
                            Dim objCC As CuentaCorriente = ObtenerCuentaCorrientePorIdCliente(datos("IdCliente"))

                            If objCC IsNot Nothing Then
                                objCli.CuentaCorriente = objCC
                            End If

                        End If

                    End Using

                End Using

            End Using
            Return objCli

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerClientePorId", ex.Message))

        End Try

    End Function
    Public Function ListarClientes(ByVal argTextoBuscado As String) As List(Of Cliente)
        Dim objConexionDB As New D_Conexion
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
                        Dim idClienteOrdinal As Integer = datos.GetOrdinal("IdCliente")
                        Dim nombreOrdinal As Integer = datos.GetOrdinal("Nombre")
                        Dim domicilioOrdinal As Integer = datos.GetOrdinal("Domicilio")
                        Dim localidadOrdinal As Integer = datos.GetOrdinal("Localidad")
                        Dim provinciaOrdinal As Integer = datos.GetOrdinal("Provincia")
                        Dim telefonoOrdinal As Integer = datos.GetOrdinal("Telefono")
                        Dim emailOrdinal As Integer = datos.GetOrdinal("Email")
                        Dim codiTDocOrdinal As Integer = datos.GetOrdinal("CodiTDoc")
                        Dim numDocOrdinal As Integer = datos.GetOrdinal("NumDoc")
                        Dim fechaAltaOrdinal As Integer = datos.GetOrdinal("FechaAlta")
                        Dim estadoOrdinal As Integer = datos.GetOrdinal("Estado")
                        Dim codIVAOrdinal As Integer = datos.GetOrdinal("CodIVA")

                        While datos.Read
                            Dim IdClienteResult As Int32 = Convert.ToInt32(datos(idClienteOrdinal))
                            Dim NombreResult As String = datos.GetString(nombreOrdinal)
                            Dim DomicilioResult As String = If(datos.IsDBNull(domicilioOrdinal), "", datos(domicilioOrdinal).ToString())
                            Dim LocalidadResult As String = If(datos.IsDBNull(localidadOrdinal), "", datos(localidadOrdinal).ToString())
                            Dim ProvinciaResult As String = If(datos.IsDBNull(provinciaOrdinal), "", datos(provinciaOrdinal).ToString())
                            Dim TelefonoResult As String = If(datos.IsDBNull(telefonoOrdinal), "", datos(telefonoOrdinal).ToString())
                            Dim EmailResult As String = If(datos.IsDBNull(emailOrdinal), "", datos(emailOrdinal).ToString())
                            Dim CodiTDocResult As String = datos.GetString(codiTDocOrdinal)
                            Dim NumDocResult As String = datos.GetString(numDocOrdinal)
                            Dim FechaAltaResult As Date = Convert.ToDateTime(datos(fechaAltaOrdinal))
                            Dim EstadoResult As String = datos.GetString(estadoOrdinal)
                            Dim CodIVAResult As String = datos.GetString(codIVAOrdinal)
                            c = New Cliente(IdClienteResult, NombreResult, DomicilioResult, LocalidadResult, ProvinciaResult, TelefonoResult, EmailResult, CodiTDocResult, NumDocResult, FechaAltaResult, EstadoResult, CodIVAResult)
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
                                    ) As Int32

        Dim IdCliente As Int32
        Try
            Dim objConexionDB As New D_Conexion

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("ClienteInsertar", cn) With {.CommandType = CommandType.StoredProcedure}
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
            Dim objConexionDB As New D_Conexion

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("ClienteActualizar", cn) With {.CommandType = CommandType.StoredProcedure}
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
    Public Function ObtenerCuentaCorrientePorIdCliente(ByVal argIdCliente As Int32) As CuentaCorriente

        Dim objConexionDB As New D_Conexion
        Dim objCC As CuentaCorriente = Nothing

        Try
            Dim sql As String = "SELECT IdCC,IdCliente,Descripcion,Credito,FechaAlta,Observaciones,Estado,Saldo FROM ConCtasCorriente WHERE IdCliente=@IdCliente"

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql
                    cmd.Parameters.AddWithValue("@IdCliente", argIdCliente)

                    Using datos As MySqlDataReader = cmd.ExecuteReader()

                        If datos.Read Then
                            Dim IdCC As Long = datos("IdCC")
                            Dim IdCliente As Int32 = datos("IdCliente")
                            Dim Descripcion As String = datos("Descripcion")
                            Dim Credito As String = datos("Credito")
                            Dim FechaAlta As String = datos("FechaAlta")
                            Dim Estado As String = datos("Estado")
                            Dim Observaciones As String = datos("Observaciones")
                            Dim Saldo As Decimal = datos("Saldo")
                            objCC = New CuentaCorriente(IdCC, argIdCliente, Descripcion, Credito, FechaAlta, Observaciones, Estado, Saldo)
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
            Dim objConexionDB As New D_Conexion
            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("CtaCorrienteInsertar", cn) With {.CommandType = CommandType.StoredProcedure}
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
            Dim objConexionDB As New D_Conexion
            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("CtaCorrienteActualizar", cn) With {.CommandType = CommandType.StoredProcedure}
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

        Dim objConexionDB As New D_Conexion
        Dim objProv As Proveedor = Nothing
        Try

            Dim sql As String = "SELECT IdProveedor,Nombre,Domicilio,Localidad,Provincia,Telefono,Email,CodiTDoc,NumDoc,FechaAlta,Estado FROM TblProveedores WHERE IdProveedor=@IdProveedor"
            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql
                    cmd.Parameters.AddWithValue("@IdProveedor", argIdProveedor)

                    Using datos As MySqlDataReader = cmd.ExecuteReader()
                        If datos.Read() Then

                            objProv = New Proveedor(
                                                    datos.GetInt32("IdProveedor"),
                                                    datos.GetString("Nombre"),
                                                    If(datos.IsDBNull(datos.GetOrdinal("Domicilio")), "", datos.GetString("Domicilio")),
                                                    If(datos.IsDBNull(datos.GetOrdinal("Localidad")), "", datos.GetString("Localidad")),
                                                    If(datos.IsDBNull(datos.GetOrdinal("Provincia")), "", datos.GetString("Provincia")),
                                                    If(datos.IsDBNull(datos.GetOrdinal("Telefono")), "", datos.GetString("Telefono")),
                                                    If(datos.IsDBNull(datos.GetOrdinal("Email")), "", datos.GetString("Email")),
                                                    datos.GetString("CodiTDoc"),
                                                    datos.GetString("NumDoc"),
                                                    datos.GetDateTime("FechaAlta"),
                                                    datos.GetString("Estado")
                                                    )
                        End If

                    End Using

                End Using

            End Using

            Return objProv

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerProveedorPorId", ex.Message))

        End Try

    End Function
    Public Function ListarProveedores(ByVal argTextoBuscado As String) As List(Of Proveedor)

        Dim objConexionDB As New D_Conexion
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
                        Dim idProveedorOrdinal As Integer = datos.GetOrdinal("IdProveedor")
                        Dim nombreOrdinal As Integer = datos.GetOrdinal("Nombre")
                        Dim domicilioOrdinal As Integer = datos.GetOrdinal("Domicilio")
                        Dim localidadOrdinal As Integer = datos.GetOrdinal("Localidad")
                        Dim provinciaOrdinal As Integer = datos.GetOrdinal("Provincia")
                        Dim telefonoOrdinal As Integer = datos.GetOrdinal("Telefono")
                        Dim emailOrdinal As Integer = datos.GetOrdinal("Email")
                        Dim codiTDocOrdinal As Integer = datos.GetOrdinal("CodiTDoc")
                        Dim numDocOrdinal As Integer = datos.GetOrdinal("NumDoc")
                        Dim fechaAltaOrdinal As Integer = datos.GetOrdinal("FechaAlta")
                        Dim estadoOrdinal As Integer = datos.GetOrdinal("Estado")

                        While datos.Read
                            Dim IdProveedorResult As Int32 = Convert.ToInt32(datos(idProveedorOrdinal))
                            Dim NombreResult As String = datos.GetString(nombreOrdinal)
                            Dim DomicilioResult As String = If(datos.IsDBNull(domicilioOrdinal), "", datos(domicilioOrdinal).ToString())
                            Dim LocalidadResult As String = If(datos.IsDBNull(localidadOrdinal), "", datos(localidadOrdinal).ToString())
                            Dim ProvinciaResult As String = If(datos.IsDBNull(provinciaOrdinal), "", datos(provinciaOrdinal).ToString())
                            Dim TelefonoResult As String = If(datos.IsDBNull(telefonoOrdinal), "", datos(telefonoOrdinal).ToString())
                            Dim EmailResult As String = If(datos.IsDBNull(emailOrdinal), "", datos(emailOrdinal).ToString())
                            Dim CodiTDocResult As String = datos(codiTDocOrdinal)
                            Dim NumDocResult As String = datos(numDocOrdinal)
                            Dim FechaAltaResult As Date = datos(fechaAltaOrdinal)
                            Dim EstadoResult As String = datos(estadoOrdinal)

                            p = New Proveedor(IdProveedorResult, NombreResult, DomicilioResult, LocalidadResult, ProvinciaResult, TelefonoResult, EmailResult, CodiTDocResult, NumDocResult, FechaAltaResult, EstadoResult)
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
                                    ) As Int32

        Dim IdProveedor As Int32
        Try
            Dim objConexionDB As New D_Conexion
            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("ProveedorInsertar", cn) With {.CommandType = CommandType.StoredProcedure}
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
            Dim objConexionDB As New D_Conexion
            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("ProveedorActualizar", cn) With {.CommandType = CommandType.StoredProcedure}
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

        Dim objConexionDB As New D_Conexion
        Dim objEmp As Empleado = Nothing

        Try
            Dim sql As String = "SELECT IdEmpleado,Nombre,Domicilio,Localidad,Provincia,Telefono,Email,CodiTDoc,NumDoc,FechaAlta,Estado FROM TblEmpleado WHERE IdEmpleado=@IdEmpleado"

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql
                    cmd.Parameters.AddWithValue("@IdEmpleado", argIdEmpleado)

                    Using datos As MySqlDataReader = cmd.ExecuteReader()

                        If datos.Read() Then

                            objEmp = New Empleado(
                                                  datos.GetInt32("IdUsuario"),
                                                  datos.GetString("Nombre"),
                                                  If(datos.IsDBNull(datos.GetOrdinal("Domicilio")), "", datos.GetString("Domicilio")),
                                                  If(datos.IsDBNull(datos.GetOrdinal("Localidad")), "", datos.GetString("Localidad")),
                                                  If(datos.IsDBNull(datos.GetOrdinal("Provincia")), "", datos.GetString("Provincia")),
                                                  If(datos.IsDBNull(datos.GetOrdinal("Telefono")), "", datos.GetString("Telefono")),
                                                  If(datos.IsDBNull(datos.GetOrdinal("Email")), "", datos.GetString("Email")),
                                                  datos.GetString("CodiTDoc"),
                                                  datos.GetString("NumDoc"),
                                                  datos.GetDateTime("FechaAlta"),
                                                  datos.GetString("Estado")
                                                  )
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

        Dim objConexionDB As New D_Conexion
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
                        Dim idEmpleadoOrdinal As Integer = datos.GetOrdinal("IdEmpleado")
                        Dim nombreOrdinal As Integer = datos.GetOrdinal("Nombre")
                        Dim domicilioOrdinal As Integer = datos.GetOrdinal("Domicilio")
                        Dim localidadOrdinal As Integer = datos.GetOrdinal("Localidad")
                        Dim provinciaOrdinal As Integer = datos.GetOrdinal("Provincia")
                        Dim telefonoOrdinal As Integer = datos.GetOrdinal("Telefono")
                        Dim emailOrdinal As Integer = datos.GetOrdinal("Email")
                        Dim codiTDocOrdinal As Integer = datos.GetOrdinal("CodiTDoc")
                        Dim numDocOrdinal As Integer = datos.GetOrdinal("NumDoc")
                        Dim fechaAltaOrdinal As Integer = datos.GetOrdinal("FechaAlta")
                        Dim estadoOrdinal As Integer = datos.GetOrdinal("Estado")

                        While datos.Read
                            Dim IdEmpleadoResult As Int32 = Convert.ToInt32(datos(idEmpleadoOrdinal))
                            Dim NombreResult As String = datos.GetString(nombreOrdinal)
                            Dim DomicilioResult As String = If(datos.IsDBNull(domicilioOrdinal), "", datos(domicilioOrdinal).ToString())
                            Dim LocalidadResult As String = If(datos.IsDBNull(localidadOrdinal), "", datos(localidadOrdinal).ToString())
                            Dim ProvinciaResult As String = If(datos.IsDBNull(provinciaOrdinal), "", datos(provinciaOrdinal).ToString())
                            Dim TelefonoResult As String = If(datos.IsDBNull(telefonoOrdinal), "", datos(telefonoOrdinal).ToString())
                            Dim EmailResult As String = If(datos.IsDBNull(emailOrdinal), "", datos(emailOrdinal).ToString())
                            Dim CodiTDocResult As String = datos.GetString(codiTDocOrdinal)
                            Dim NumDocResult As String = datos.GetString(numDocOrdinal)
                            Dim FechaAltaResult As Date = Convert.ToDateTime(datos(fechaAltaOrdinal))
                            Dim EstadoResult As String = datos.GetString(estadoOrdinal)

                            e = New Empleado(IdEmpleadoResult, NombreResult, DomicilioResult, LocalidadResult, ProvinciaResult, TelefonoResult, EmailResult, CodiTDocResult, NumDocResult, FechaAltaResult, EstadoResult)
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
                                    ) As Int32

        Dim IdEmpleado As Int32
        Try
            Dim objConexionDB As New D_Conexion
            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("EmpleadoInsertar", cn) With {.CommandType = CommandType.StoredProcedure}
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
                    IdEmpleado = Convert.ToInt32(cmd.Parameters("_IdEmpleado").Value)
                End Using

            End Using
            Return IdEmpleado

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
            Dim objConexionDB As New D_Conexion
            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("EmpleadoActualizar", cn) With {.CommandType = CommandType.StoredProcedure}
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
        Dim objConexionDB As New D_Conexion
        Dim objUs As Usuario = Nothing

        Try
            Dim sql As String = "SELECT IdUsuario,Nombre,Domicilio,Localidad,Provincia,Telefono,Email,CodiTDoc,NumDoc,FechaAlta,Estado FROM TblUsuarios WHERE IdUsuario=@IdUsuario"

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql
                    cmd.Parameters.AddWithValue("@IdUsuario", argIdUsuario)

                    Using datos As MySqlDataReader = cmd.ExecuteReader()

                        If datos.Read() Then

                            objUs = New Usuario(
                                               datos.GetInt32("IdUsuario"),
                                               datos.GetString("Nombre"),
                                               If(datos.IsDBNull(datos.GetOrdinal("Domicilio")), "", datos.GetString("Domicilio")),
                                               If(datos.IsDBNull(datos.GetOrdinal("Localidad")), "", datos.GetString("Localidad")),
                                               If(datos.IsDBNull(datos.GetOrdinal("Provincia")), "", datos.GetString("Provincia")),
                                               If(datos.IsDBNull(datos.GetOrdinal("Telefono")), "", datos.GetString("Telefono")),
                                               If(datos.IsDBNull(datos.GetOrdinal("Email")), "", datos.GetString("Email")),
                                               datos.GetString("CodiTDoc"),
                                               datos.GetString("NumDoc"),
                                               datos.GetDateTime("FechaAlta"),
                                               datos.GetString("Estado")
                                               )
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
        Dim objConexionDB As New D_Conexion
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
                        Dim idUsuarioOrdinal As Integer = datos.GetOrdinal("IdUsuario")
                        Dim nombreOrdinal As Integer = datos.GetOrdinal("Nombre")
                        Dim domicilioOrdinal As Integer = datos.GetOrdinal("Domicilio")
                        Dim localidadOrdinal As Integer = datos.GetOrdinal("Localidad")
                        Dim provinciaOrdinal As Integer = datos.GetOrdinal("Provincia")
                        Dim telefonoOrdinal As Integer = datos.GetOrdinal("Telefono")
                        Dim emailOrdinal As Integer = datos.GetOrdinal("Email")
                        Dim codiTDocOrdinal As Integer = datos.GetOrdinal("CodiTDoc")
                        Dim numDocOrdinal As Integer = datos.GetOrdinal("NumDoc")
                        Dim fechaAltaOrdinal As Integer = datos.GetOrdinal("FechaAlta")
                        Dim estadoOrdinal As Integer = datos.GetOrdinal("Estado")

                        While datos.Read
                            Dim IdUsuarioResult As Int32 = Convert.ToInt32(datos(idUsuarioOrdinal))
                            Dim NombreResult As String = datos.GetString(nombreOrdinal)
                            Dim DomicilioResult As String = If(datos.IsDBNull(domicilioOrdinal), "", datos(domicilioOrdinal).ToString())
                            Dim LocalidadResult As String = If(datos.IsDBNull(localidadOrdinal), "", datos(localidadOrdinal).ToString())
                            Dim ProvinciaResult As String = If(datos.IsDBNull(provinciaOrdinal), "", datos(provinciaOrdinal).ToString())
                            Dim TelefonoResult As String = If(datos.IsDBNull(telefonoOrdinal), "", datos(telefonoOrdinal).ToString())
                            Dim EmailResult As String = If(datos.IsDBNull(emailOrdinal), "", datos(emailOrdinal).ToString())
                            Dim CodiTDocResult As String = datos.GetString(codiTDocOrdinal)
                            Dim NumDocResult As String = datos.GetString(numDocOrdinal)
                            Dim FechaAltaResult As Date = Convert.ToDateTime(datos(fechaAltaOrdinal))
                            Dim EstadoResult As String = datos.ToString(estadoOrdinal)

                            u = New Usuario(IdUsuarioResult, NombreResult, DomicilioResult, LocalidadResult, ProvinciaResult, TelefonoResult, EmailResult, CodiTDocResult, NumDocResult, FechaAltaResult, EstadoResult)
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
                                    ) As Int32

        Dim IdUsuario As Int32
        Try
            Dim objConexionDB As New D_Conexion
            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("UsuarioInsertar", cn) With {.CommandType = CommandType.StoredProcedure}
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
            Dim objConexionDB As New D_Conexion
            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("UsuarioActualizar", cn) With {.CommandType = CommandType.StoredProcedure}
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

    Public Function VerificarAutorizacionProceso(ByVal argIdUsuario As Integer, ByVal argPassword As String, ByVal argIdProceso As Integer) As String
        Try
            Dim objConexionDB As New D_Conexion
            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("VerificarAutorizacionProceso", cn) With {.CommandType = CommandType.StoredProcedure}
                    With cmd.Parameters
                        .Add("p_IdUsuario", MySqlDbType.Int32).Value = argIdUsuario
                        .Add("p_Password", MySqlDbType.VarChar).Value = argPassword
                        .Add("p_IdProceso", MySqlDbType.Int32).Value = argIdProceso
                        .Add("p_Autorizacion", MySqlDbType.VarChar)
                    End With

                    cmd.Parameters("p_Autorizacion").Direction = ParameterDirection.Output
                    cmd.ExecuteNonQuery()

                    Dim Autorizacion = cmd.Parameters("p_Autorizacion").Value.ToString
                    Return Autorizacion

                End Using

            End Using

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "VerificarAutorizacionProceso", ex.Message))

        End Try
    End Function

#End Region

#Region "Administracion de Empresas"
    Public Function ObtenerEmpresaPorId(ByVal argIdEmpresa As Long) As Empresa

        Dim objConexionDB As New D_Conexion
        Dim objEmp As Empresa = Nothing

        Try
            Dim sql As String = "SELECT IdEmpresa,Nombre,Domicilio,Localidad,Provincia,Telefono,Email,CodiTDoc,NumDoc,FechaAlta,Estado,CodIVA,IB FROM TblEmpresas WHERE IdEmpresa=@IdEmpresa"

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql
                    cmd.Parameters.AddWithValue("@IdEmpresa", argIdEmpresa)

                    Using datos As MySqlDataReader = cmd.ExecuteReader()

                        If datos.Read() Then

                            objEmp = New Empresa(
                                                  datos.GetInt32("IdEmpresa"),
                                                  datos.GetString("Nombre"),
                                                  If(datos.IsDBNull(datos.GetOrdinal("Domicilio")), "", datos.GetString("Domicilio")),
                                                  If(datos.IsDBNull(datos.GetOrdinal("Localidad")), "", datos.GetString("Localidad")),
                                                  If(datos.IsDBNull(datos.GetOrdinal("Provincia")), "", datos.GetString("Provincia")),
                                                  If(datos.IsDBNull(datos.GetOrdinal("Telefono")), "", datos.GetString("Telefono")),
                                                  If(datos.IsDBNull(datos.GetOrdinal("Email")), "", datos.GetString("Email")),
                                                  datos.GetString("CodiTDoc"),
                                                  datos.GetString("NumDoc"),
                                                  datos.GetDateTime("FechaAlta"),
                                                  datos.GetString("Estado"),
                                                  datos.GetString("CodIVA"),
                                                  datos.GetString("IB")
                                                  )

                        End If

                    End Using

                End Using

            End Using

            Return objEmp

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerEmpresaPorId", ex.Message))

        End Try

    End Function

    Public Function ListarEmpresas(ByVal argTextoBuscado As String) As List(Of Empresa)
        Dim objConexionDB As New D_Conexion
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
                        Dim idEmpresaOrdinal As Integer = datos.GetOrdinal("IdEmpleado")
                        Dim nombreOrdinal As Integer = datos.GetOrdinal("Nombre")
                        Dim domicilioOrdinal As Integer = datos.GetOrdinal("Domicilio")
                        Dim localidadOrdinal As Integer = datos.GetOrdinal("Localidad")
                        Dim provinciaOrdinal As Integer = datos.GetOrdinal("Provincia")
                        Dim telefonoOrdinal As Integer = datos.GetOrdinal("Telefono")
                        Dim emailOrdinal As Integer = datos.GetOrdinal("Email")
                        Dim codiTDocOrdinal As Integer = datos.GetOrdinal("CodiTDoc")
                        Dim numDocOrdinal As Integer = datos.GetOrdinal("NumDoc")
                        Dim fechaAltaOrdinal As Integer = datos.GetOrdinal("FechaAlta")
                        Dim estadoOrdinal As Integer = datos.GetOrdinal("Estado")
                        Dim codIvaOrdinal As Integer = datos.GetOrdinal("CodIVA")
                        Dim IBOrdinal As Integer = datos.GetOrdinal("IB")

                        While datos.Read
                            Dim IdEmpresaResult As Int32 = Convert.ToInt32(datos(idEmpresaOrdinal))
                            Dim NombreResult As String = datos.GetString(nombreOrdinal)
                            Dim DomicilioResult As String = If(datos.IsDBNull(domicilioOrdinal), "", datos(domicilioOrdinal).ToString())
                            Dim LocalidadResult As String = If(datos.IsDBNull(localidadOrdinal), "", datos(localidadOrdinal).ToString())
                            Dim ProvinciaResult As String = If(datos.IsDBNull(provinciaOrdinal), "", datos(provinciaOrdinal).ToString())
                            Dim TelefonoResult As String = If(datos.IsDBNull(telefonoOrdinal), "", datos(telefonoOrdinal).ToString())
                            Dim EmailResult As String = If(datos.IsDBNull(emailOrdinal), "", datos(emailOrdinal).ToString())
                            Dim CodiTDocResult As String = datos.GetString(codiTDocOrdinal)
                            Dim NumDocResult As String = datos.GetString(numDocOrdinal)
                            Dim FechaAltaResult As Date = Convert.ToDateTime(datos(fechaAltaOrdinal))
                            Dim EstadoResult As String = datos.GetString(estadoOrdinal)
                            Dim CodIVAResult As String = datos.GetString(codIvaOrdinal)
                            Dim IBResult As String = datos.GetString(IBOrdinal)

                            e = New Empresa(IdEmpresaResult, NombreResult, DomicilioResult, LocalidadResult, ProvinciaResult, TelefonoResult, EmailResult, CodiTDocResult, NumDocResult, FechaAltaResult, EstadoResult, CodIVAResult, IBResult)
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
                                    ) As Int32

        Dim IdEmpresa As Int32
        Try
            Dim objConexionDB As New D_Conexion
            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("EmpresaInsertar", cn) With {.CommandType = CommandType.StoredProcedure}
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
            Dim objConexionDB As New D_Conexion
            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("EmpresaActualizar", cn) With {.CommandType = CommandType.StoredProcedure}
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

#Region "Administracion de Cuenta Bancarias"
    Public Function ObtenerCuentaBancariaPorId(ByVal argIdCB As Int32) As CuentaBancaria

        Dim objConexionDB As New D_Conexion
        Dim objCB As CuentaBancaria = Nothing

        Try
            Dim sql As String = "SELECT IdCB,Descripcion,NumCuenta,FechaAlta,Baja FROM TblCtasBancarias WHERE IdCB=@IdCB"

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql
                    cmd.Parameters.AddWithValue("@IdCB", argIdCB)

                    Using datos As MySqlDataReader = cmd.ExecuteReader()

                        If datos.Read() Then
                            Dim IdCB As Int32 = datos.GetInt32("IdCB")
                            Dim Descripcion As String = datos.GetString("Descripcion")
                            Dim NumCuenta As String = datos.GetString("NumCuenta")
                            Dim FechaAlta As String = datos.GetDateTime("FechaAlta")
                            Dim Baja As Boolean = datos.GetBoolean("Baja")

                            objCB = New CuentaBancaria(
                                                       IdCB,
                                                       Descripcion,
                                                       NumCuenta,
                                                       FechaAlta,
                                                       Baja
                                                       )

                        End If

                    End Using

                End Using

            End Using

            Return objCB

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerCuentaBancariaPorId", ex.Message))

        End Try

    End Function

    Public Function ListarCuentasBancarias(ByVal argTextoBuscado As String) As List(Of CuentaBancaria)
        Dim objConexionDB As New D_Conexion
        Dim lcb As New List(Of CuentaBancaria)
        Dim cb As CuentaBancaria

        Try
            Dim sql As String
            If argTextoBuscado = "*" Then
                sql = "SELECT IdCB,Descripcion,NumCuenta,FechaAlta,Baja FROM TblCtasBancarias ORDER BY Descripcion"
            Else
                sql = "SELECT IdCB,Descripcion,NumCuenta,FechaAlta,Baja FROM TblCtasBancarias WHERE Descripcion LIKE @Descripcion ORDER BY Descripcion"
            End If

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql

                    If argTextoBuscado <> "*" Then
                        cmd.Parameters.AddWithValue("@Descripcion", Replace(UCase(argTextoBuscado), " ", "%") & "%")
                    End If

                    Using datos As MySqlDataReader = cmd.ExecuteReader()
                        Dim idCBOrdinal As Integer = datos.GetOrdinal("IdCB")
                        Dim desciprionOrdinal As Integer = datos.GetOrdinal("Descripcion")
                        Dim numCuentaOrdinal As Integer = datos.GetOrdinal("NumCuenta")
                        Dim fechaAltaOrdinal As Integer = datos.GetOrdinal("FechaAlta")
                        Dim bajaOrdinal As Integer = datos.GetOrdinal("Baja")

                        While datos.Read
                            Dim IdCBResult As Int32 = Convert.ToInt32(datos(idCBOrdinal))
                            Dim DescripcionResult As String = datos.GetString(desciprionOrdinal)
                            Dim NumCuentaResult As String = datos.GetString(numCuentaOrdinal)
                            Dim FechaAltaResult As Date = Convert.ToDateTime(datos(fechaAltaOrdinal))
                            Dim BajaResult As Boolean = datos.GetBoolean(bajaOrdinal)

                            cb = New CuentaBancaria(IdCBResult, DescripcionResult, NumCuentaResult, FechaAltaResult, BajaResult)
                            lcb.Add(cb)
                        End While

                    End Using
                End Using

            End Using

            Return lcb

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ListarCuentasBancarias", ex.Message))
            Return Nothing

        End Try

    End Function
    Public Function InsertarCuentaBancaria(ByVal argDescripcion As String, ByVal argNumCuenta As String) As Int32

        Try
            Dim objConexionDB As New D_Conexion
            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("CtaBancariaInsertar", cn) With {.CommandType = CommandType.StoredProcedure}
                    With cmd.Parameters
                        .Add("p_Descripcion", MySqlDbType.VarChar).Value = argDescripcion
                        .Add("p_NumCuenta", MySqlDbType.VarChar).Value = argNumCuenta
                        .Add("p_IdCB", MySqlDbType.Int32)
                    End With

                    cmd.Parameters("p_IdCB").Direction = ParameterDirection.Output
                    cmd.ExecuteNonQuery()
                    Dim IdCB As Int32 = Convert.ToInt32(cmd.Parameters("p_IdCB").Value)
                    Return IdCB

                End Using

            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarCuentaBancaria", Ex.Message))

        End Try

    End Function
    Public Function ActualizarCuentaBancaria(ByVal argIdCB As Int32, ByVal argBaja As Boolean) As Boolean

        Try
            Dim objConexionDB As New D_Conexion
            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("CtaBancariaActualizar", cn) With {.CommandType = CommandType.StoredProcedure}
                    With cmd.Parameters
                        .Add("p_IdCB", MySqlDbType.Int32).Value = argIdCB
                        .Add("p_Baja", MySqlDbType.Bit).Value = argBaja
                    End With

                    Dim filasAfectadas As Int32 = cmd.ExecuteNonQuery()
                    Return (filasAfectadas > 0) ' Devuelve True si se actualizó al menos una fila

                End Using

            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ActualizarCuentaBancaria", Ex.Message))
            Return False

        End Try

    End Function

#End Region

#Region "Administracion de MediosPE"
    Public Function ObtenerMedioPEPorId(ByVal argIdMPE As Int32) As MedioPE

        Dim objConexionDB As New D_Conexion
        Dim objMPE As MedioPE = Nothing

        Try
            Dim sql As String = "SELECT IdMPE,Descripcion,IdCB,Baja FROM TblMediosPE WHERE IdMPE=@IdMPE"

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql
                    cmd.Parameters.AddWithValue("@IdMPE", argIdMPE)

                    Using datos As MySqlDataReader = cmd.ExecuteReader()

                        If datos.Read() Then

                            Dim objCB As CuentaBancaria = ObtenerCuentaBancariaPorId(datos.GetInt32("IdCB"))

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
                sql = "SELECT IdMPE,Descripcion,IdCB,Baja FROM TblMediosPE ORDER BY Descripcion"
            Else
                sql = "SELECT IdMPE,Descripcion,IdCB,Baja FROM TblMediosPE WHERE Descripcion LIKE @Descripcion ORDER BY Descripcion"
            End If

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

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
                            Dim objCB As CuentaBancaria = ObtenerCuentaBancariaPorId(IdCBResult)

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
            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("MedioPEInsertar", cn) With {.CommandType = CommandType.StoredProcedure}
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
            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("MedioPEActualizar", cn) With {.CommandType = CommandType.StoredProcedure}
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

#End Region

#Region "Administracion de Operaciones"

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

    Public Function RegistrarError(ByVal argIdOpera As Long, argDescripcionError As String) As Integer
        Dim objConexionDB As New D_Conexion
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

    Public Function IniciarOperacion(ByVal argEmpresa As Empresa, ByVal argUsuario As Usuario, ByVal argTipoOperacion As TipoOperacion, ByVal argObservaciones As String, ByVal argEstadoOperacion As String) As Operacion

        Try

            Dim objConexionDB As New D_Conexion
            Dim objOperacion As Operacion = Nothing

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("OperacionIniciar", cn) With {.CommandType = CommandType.StoredProcedure}
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

    Public Function FinalizarOperacion(ByVal argMacAddress As String, ByVal argOperacion As Operacion) As Integer
        Try

            Dim objConexionDB As New D_Conexion

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("OperacionFinalizar", cn) With {.CommandType = CommandType.StoredProcedure}
                    With cmd.Parameters
                        .Add("p_MacAddress", MySqlDbType.VarChar).Value = argMacAddress
                        .Add("p_Observaciones", MySqlDbType.VarChar).Value = argOperacion.Observaciones
                        .Add("p_IdOperacion", MySqlDbType.Int64).Value = argOperacion.IdOperacion
                    End With

                    Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()
                    Return (filasAfectadas > 0) ' Devuelve True si se actualizó al menos una fila

                End Using

            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "IniciarOperacion", Ex.Message))
            Return False
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
                        'Dim objEmpresa As Empresa = Me.ObtenerEmpresaPorId(datos.GetInt32("IdEmpresa"))
                        'Dim objUsuario As Usuario = Me.ObtenerUsuarioPorId(datos.GetInt32("IdUsuario"))
                        'Dim objTOp As TipoOperacion = Me.ObtenerTipoOperacionPorCodiTO(datos.ToString("CodiTO"))

                        If datos.Read() Then
                            ' Obtener valores manejando posibles DBNull
                            Dim idOperacion As Long = datos.GetInt64("IdOperacion")
                            Dim inicio As DateTime = datos.GetDateTime("Inicio")
                            Dim fin As DateTime = If(datos.IsDBNull(datos.GetOrdinal("Fin")), Now, datos.GetDateTime("Fin"))
                            Dim idPC As String = datos.GetString("IdPC")
                            Dim idCaja As Integer = datos.GetInt32("IdCaja")
                            Dim estado As String = datos.GetString("EstadoOperacion")
                            Dim observaciones As String = datos.GetString("Observaciones")
                            Dim desError As String = If(datos.IsDBNull(datos.GetOrdinal("DesError")), "", datos.GetString("DesError"))

                            ' Si luego vas a completar Empresa, Usuario, TipoOperacion, lo dejás en Nothing o los instanciás aparte.
                            objOpera = New Operacion(idOperacion, inicio, fin, Nothing, idPC, idCaja, Nothing, Nothing, estado, observaciones, desError)
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
                            objCliente = ObtenerClientePorId(idCliente)
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

    Public Function InsertarOperacionCL(ByVal argIdOperacion As Long, ByVal argIdCliente As Int32) As Boolean

        Try
            Dim objConexionDB As New D_Conexion

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("OperacionCLInsertar", cn) With {.CommandType = CommandType.StoredProcedure}
                    With cmd.Parameters
                        .Add("p_IdOperacion", MySqlDbType.Int64).Value = argIdOperacion
                        .Add("p_IdCliente", MySqlDbType.Int32).Value = argIdCliente
                    End With

                    Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()
                    Return (filasAfectadas > 0) ' Devuelve True si se actualizó al menos una fila

                End Using

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

                Using cmd As New MySqlCommand("OperacionCCInsertar", cn) With {.CommandType = CommandType.StoredProcedure}
                    With cmd.Parameters
                        .Add("p_IdOperacion", MySqlDbType.Int64).Value = argIdOperacion
                        .Add("p_IdCC", MySqlDbType.Int32).Value = argIdCC
                        .Add("p_Importe", MySqlDbType.Decimal).Value = argImporte
                    End With

                    Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()
                    Return (filasAfectadas > 0) ' Devuelve True si se actualizó al menos una fila

                End Using

            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarOperacionCC", Ex.Message))

        End Try

    End Function

    Public Function InsertarOperacionPE(ByVal argIdOperacion As Long, ByVal argIdMPE As Int32, ByVal argImporte As Decimal) As Boolean

        Try
            Dim objConexionDB As New D_Conexion

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("OperacionPEInsertar", cn) With {.CommandType = CommandType.StoredProcedure}
                    With cmd.Parameters
                        .Add("p_IdOperacion", MySqlDbType.Int64).Value = argIdOperacion
                        .Add("p_IdMPE", MySqlDbType.Int32).Value = argIdMPE
                        .Add("p_Importe", MySqlDbType.Decimal).Value = argImporte
                    End With

                    Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()
                    Return (filasAfectadas > 0) ' Devuelve True si se actualizó al menos una fila

                End Using

            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarOperacionPE", Ex.Message))

        End Try

    End Function

    Public Sub FinalizarOperacionConTransaccion()

    End Sub

#End Region

#Region "Administracion Cuentas Email"
    Public Function ObtenerCuentaEmail() As CuentaEmail
        Dim objConexionDB As New D_Conexion
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
        Dim objConexionDB As New D_Conexion
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

        Dim objConexionDB As New D_Conexion
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
        Dim objConexionDB As New D_Conexion
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

        Dim objConexionDB As New D_Conexion
        Dim IdSeccion As String
        Try
            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("SeccionInsertar", cn) With {.CommandType = CommandType.StoredProcedure}
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
            Dim objConexionDB As New D_Conexion
            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("SeccionActualizar", cn) With {.CommandType = CommandType.StoredProcedure}
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
        Dim objConexionDB As New D_Conexion
        Dim objArt As Articulo = Nothing

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
                            Dim AlicIVA As Decimal = Convert.ToDecimal(datos.GetValue(alicIVAOrdinal))
                            Dim FechaPrecioResult As Date = Convert.ToDateTime(datos.GetValue(fechaPrecioOrdinal))
                            Dim PrecioCostoResult As Decimal = Convert.ToDecimal(datos.GetValue(precioCostoOrdinal))
                            Dim PrecioVentaResult As Decimal = Convert.ToDecimal(datos.GetValue(precioVentaOrdinal))
                            Dim BajaResult As Boolean = datos.GetBoolean(bajaOrdinal)
                            Dim IdSeccionResult As String = datos.GetString(idSeccionOrdinal)
                            Dim SeccionResult As String = datos.GetString(seccionNombreOrdinal)
                            Dim EstablecerPrecioResult As Boolean = datos.GetBoolean(establecerPrecioOrdinal)
                            Dim ActualizarPrecioResult As Boolean = datos.GetBoolean(actualizarPrecioOrdinal)
                            Dim StockResult As Decimal = Convert.ToDecimal(datos.GetValue(stockOrdinal))
                            Dim CodiLPResult As String = datos.GetString(codiLPOrdinal)
                            Dim ListaPreciosResult As String = datos.GetString(listaPreciosNombreOrdinal)
                            Dim FabricanteResult As String = datos.GetString(fabricanteOrdinal)

                            Dim objAlicuotaIVAResult As AlicuotaIVA = New AlicuotaIVA(AlicIVA)
                            Dim objSeccionResult As Seccion = New Seccion(IdSeccionResult, SeccionResult, EstablecerPrecioResult)
                            Dim objListaPreciosResult As ListaPrecios = New ListaPrecios(CodiLPResult, ListaPreciosResult)

                            objArt = New Articulo(IdArticuloResult, CodigoResult, CodBarrasResult, NombreResult, objAlicuotaIVAResult, FechaPrecioResult, PrecioCostoResult, PrecioVentaResult, BajaResult, objSeccionResult, ActualizarPrecioResult, StockResult, objListaPreciosResult, FabricanteResult)
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
        Dim objConexionDB As New D_Conexion
        Dim objLA As New List(Of Articulo)

        Try
            Dim sql As String = "SELECT IdArticulo, Codigo, CodBarras, Nombre, AlicIVA, FechaPrecio, PrecioCosto, PrecioVenta, Baja, IdSeccion, Seccion, EstablecerPrecio, ActualizarPrecio, Stock, CodiLP, ListaPrecios, Fabricante FROM ConArticulos WHERE Nombre LIKE @Nombre OR Codigo = @Codigo OR CodBarras = @CodBarras ORDER BY Nombre"

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql

                    ' Separamos los parámetros para Nombre y CodBarras
                    cmd.Parameters.AddWithValue("@Nombre", Replace(UCase(argTextoBuscado), " ", "%") & "%")
                    cmd.Parameters.AddWithValue("@Codigo", argTextoBuscado)
                    cmd.Parameters.AddWithValue("@CodBarras", argTextoBuscado)

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
            Dim objConexionDB As New D_Conexion
            Dim IdArticulo As String

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("ArticuloInsertar", cn) With {.CommandType = CommandType.StoredProcedure}
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
            Dim objConexionDB As New D_Conexion

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("ArticuloActualizar", cn) With {.CommandType = CommandType.StoredProcedure}
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

#Region "Administracion Comprobantes"
    Public Function InsertarComprobante(ByVal argOperacion As Operacion,
                                        ByVal argCodiTC As String,
                                        ByVal argImpBto As Decimal,
                                        ByVal argImpDes As Decimal,
                                        ByVal argImpEx As Decimal,
                                        ByVal argImpGrav1 As Decimal,
                                        ByVal argImpGrav2 As Decimal,
                                        ByVal argImpCB As Decimal,
                                        ByVal argImpEf As Decimal,
                                        ByVal argImpCC As Decimal,
                                        ByVal argImpTar As Decimal,
                                        ByVal argIdOperAsoc As Long,
                                        ByVal argCliente As Cliente,
                                        ByVal argEmpresa As Empresa,
                                        ByVal argDetalle As List(Of ItemComprobante),
                                        ByVal argFiscal As String
                                        ) As Comprobante

        Dim objConexionDB As New D_Conexion


        Try
            Dim ImpNeto1 As Decimal = Math.Round(argImpGrav1 / 1.105, 2, MidpointRounding.ToEven)
            Dim ImpIVA1 As Decimal = Math.Round(ImpNeto1 * 10.5 / 100, 2, MidpointRounding.ToEven)
            Dim ImpNeto2 As Decimal = Math.Round(argImpGrav2 / 1.21, 2, MidpointRounding.ToEven)
            Dim ImpIVA2 As Decimal = Math.Round(ImpNeto2 * 21 / 100, 2, MidpointRounding.ToEven)

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("ComprobanteInsertar", cn) With {.CommandType = CommandType.StoredProcedure}

                    With cmd.Parameters
                        .AddWithValue("p_IdOpera", argOperacion.IdOperacion)
                        .AddWithValue("p_CodiTC", argCodiTC)
                        .AddWithValue("p_IdCliente", argCliente.Id)
                        .AddWithValue("p_ImpBto", argImpBto)
                        .AddWithValue("p_ImpDes", argImpDes)
                        .AddWithValue("p_ImpEx", argImpEx)
                        .AddWithValue("p_ImpGrav1", argImpGrav1)
                        .AddWithValue("p_ImpNeto1", ImpNeto1)
                        .AddWithValue("p_ImpIVA1", ImpIVA1)
                        .AddWithValue("p_ImpGrav2", argImpGrav2)
                        .AddWithValue("p_ImpNeto2", ImpNeto2)
                        .AddWithValue("p_ImpIVA2", ImpIVA2)
                        .AddWithValue("p_ImpCB", argImpCB)
                        .AddWithValue("p_ImpEf", argImpEf)
                        .AddWithValue("p_ImpCC", argImpCC)
                        .AddWithValue("p_ImpTar", argImpTar)
                        .AddWithValue("p_IdOperAsoc", argIdOperAsoc)
                        .AddWithValue("p_TipoDoc", argCliente.Documento.TipoDoc.CodiTDoc)
                        .AddWithValue("p_NumDoc", argCliente.Documento.Numero)
                        .AddWithValue("p_Cliente", argCliente.Nombre)
                        .AddWithValue("p_Fiscal", argFiscal)
                    End With

                    cmd.Parameters.Add("p_PVenta", MySqlDbType.VarChar)
                    cmd.Parameters("p_PVenta").Direction = ParameterDirection.Output
                    cmd.Parameters.Add("p_NumComp", MySqlDbType.VarChar)
                    cmd.Parameters("p_NumComp").Direction = ParameterDirection.Output
                    cmd.Parameters.Add("p_FechaComp", MySqlDbType.VarChar)
                    cmd.Parameters("p_FechaComp").Direction = ParameterDirection.Output
                    cmd.ExecuteNonQuery()

                    Dim objComp As New Comprobante(
                                                argIdOperacion:=Convert.ToInt64(argOperacion.IdOperacion),
                                                argOperacion:=argOperacion,
                                                argCodiTC_SiCoFa:=argCodiTC,
                                                argPVenta:=cmd.Parameters("p_PVenta").Value,
                                                argNumComp:=cmd.Parameters("p_NumComp").Value,
                                                argFechaComp:=cmd.Parameters("p_FechaComp").Value,
                                                argImpBto:=argImpBto,
                                                argImpEx:=argImpEx,
                                                argImpGrav1:=argImpGrav1,
                                                argImpNeto1:=ImpNeto1,
                                                argImpIVA1:=ImpIVA1,
                                                argImpGrav2:=argImpGrav2,
                                                argImpNeto2:=ImpNeto2,
                                                argImpIVA2:=ImpIVA2,
                                                argImpCB:=argImpCB,
                                                argImpEf:=argImpEf,
                                                argImpCC:=argImpCC,
                                                argImpTar:=argImpTar,
                                                argCAE:=Nothing,
                                                argIdCliente:=argCliente.Id,
                                                argCliente:=argCliente,
                                                argIdOperAsoc:=argIdOperAsoc,
                                                argCompAsoc:=Nothing,
                                                argEmpresa:=argEmpresa,
                                                argDetalle:=argDetalle
                                               )

                    If objComp IsNot Nothing Then
                        Return objComp
                    Else
                        Return Nothing
                    End If

                End Using

            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarComprobante", Ex.Message))
            Return Nothing
        End Try

    End Function

    Public Function ActualizarCAE(ByVal argComprobante As Comprobante) As Boolean

        Try
            Dim objConexionDB As New D_Conexion

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("CAEActualizar", cn) With {.CommandType = CommandType.StoredProcedure}
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("p_IdOperacion", argComprobante.Operacion.IdOperacion)
                    cmd.Parameters.AddWithValue("p_NumComp", argComprobante.NumComp)
                    cmd.Parameters.AddWithValue("p_CAE", argComprobante.CAE.NumCAE)
                    cmd.Parameters.AddWithValue("p_VtoCAE", argComprobante.CAE.VtoCAE)

                    Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()
                    Return (filasAfectadas > 0) ' Devuelve True si se actualizó al menos una fila

                End Using
            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ActualizarCAE", Ex.Message))

        End Try

    End Function

#End Region

#Region "Administracion Items Comprobante"
    Public Function ListarItemsPorIdOperacion(ByVal argIdOperacion As Long) As List(Of ItemComprobante)
        Dim objConexionDB As New D_Conexion
        Dim objLI As New List(Of ItemComprobante)

        Try
            Dim sql As String = "SELECT IdItem, IdOperacion, IdArticulo, Descripcion,Cantidad, AlicIVA, PrecioCosto,PrecioUnitario,Descuento,CodBarras, PrecioVenta,IdSeccion,Seccion,EstablecerPrecio FROM ConItemsComprobante WHERE IdOperacion = @IdOperacion ORDER BY IdItem"

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql

                    cmd.Parameters.AddWithValue("@IdOperacion", argIdOperacion)

                    Using datos As MySqlDataReader = cmd.ExecuteReader()
                        Dim idItemOrdinal As Integer = datos.GetOrdinal("IdItem")
                        Dim idArticuloOrdinal As Integer = datos.GetOrdinal("Idarticulo")
                        Dim descripcionOrdinal As Integer = datos.GetOrdinal("Descripcion")
                        Dim cantidadOrdinal As Integer = datos.GetOrdinal("Cantidad")
                        Dim alicIVAOrdinal As Integer = datos.GetOrdinal("AlicIVA")
                        Dim precioCostoOrdinal As Integer = datos.GetOrdinal("PrecioCosto")
                        Dim precioUnitarioOrdinal As Integer = datos.GetOrdinal("PrecioUnitario")
                        Dim descuentoOrdinal As Integer = datos.GetOrdinal("Descuento")
                        Dim codBarrasOrdinal As Integer = datos.GetOrdinal("CodBarras")
                        Dim precioVentaOrdinal As Integer = datos.GetOrdinal("PrecioVenta")
                        Dim idSeccionOrdinal As Integer = datos.GetOrdinal("IdSeccion")
                        Dim seccionNombreOrdinal As Integer = datos.GetOrdinal("Seccion")
                        Dim establecerPrecioOrdinal As Integer = datos.GetOrdinal("EstablecerPrecio")

                        While datos.Read
                            ' Manejo explícito de DBNull y conversión a tipos de datos .NET
                            Dim IdItemResult As Long = Convert.ToInt64(datos.GetValue(idItemOrdinal))
                            Dim IdArticuloResult As String = datos.GetString(idArticuloOrdinal)
                            Dim DescripcionResult As String = datos.GetString(descripcionOrdinal)
                            Dim CantidadResult As Decimal = Convert.ToDecimal(datos.GetValue(cantidadOrdinal))
                            Dim AlicIVA As Decimal = Convert.ToDecimal(datos.GetValue(alicIVAOrdinal))
                            Dim PrecioCostoResult As Decimal = If(datos.IsDBNull(precioCostoOrdinal), 0, Convert.ToDecimal(datos.GetValue(precioCostoOrdinal)))
                            Dim PrecioUnitarioResult As Decimal = If(datos.IsDBNull(precioUnitarioOrdinal), 0, Convert.ToDecimal(datos.GetValue(precioUnitarioOrdinal)))
                            Dim DescuentoResult As Decimal = If(datos.IsDBNull(descuentoOrdinal), 0, Convert.ToDecimal(datos.GetValue(descuentoOrdinal)))
                            Dim CodBarrasResult As String = datos.GetString(codBarrasOrdinal)
                            Dim PrecioVentaResult As Decimal = If(datos.IsDBNull(precioVentaOrdinal), 0, Convert.ToDecimal(datos.GetValue(precioVentaOrdinal)))
                            Dim IdSeccionResult As String = datos.GetString(idSeccionOrdinal)
                            Dim SeccionResult As String = datos.GetString(seccionNombreOrdinal)
                            Dim EstablecerPrecioResult As Boolean = datos.GetBoolean(establecerPrecioOrdinal)
                            Dim PorcentajeDescuento = Math.Round(DescuentoResult / PrecioUnitarioResult * 100, 2, MidpointRounding.ToEven)

                            ' Crear objetos anidados
                            Dim objAlicuotaIVAResult As AlicuotaIVA = New AlicuotaIVA(AlicIVA)
                            Dim objSeccionResult As Seccion = New Seccion(IdSeccionResult, SeccionResult, EstablecerPrecioResult)
                            Dim objArticuloResult As Articulo = New Articulo(IdArticuloResult, 0, CodBarrasResult, DescripcionResult, objAlicuotaIVAResult, Now.Date, PrecioCostoResult, PrecioVentaResult, 0, objSeccionResult, 0, 0, Nothing, "")

                            Dim objIC As New ItemComprobante(objArticuloResult, CodBarrasResult, DescripcionResult, CantidadResult, PrecioUnitarioResult, objAlicuotaIVAResult.AlicIVA, PorcentajeDescuento)
                            objIC.IdItem = IdItemResult
                            objLI.Add(objIC)
                        End While
                    End Using
                End Using
            End Using

            Return objLI

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ListarItemsPorIdOperacion", ex.Message))
            Return New List(Of ItemComprobante)

        End Try
    End Function

    Public Function InsertarItemComprobante(ByVal argIdOperacion As Long, ByVal argItemComprobante As ItemComprobante) As Long

        Try
            Dim objConexionDB As New D_Conexion
            Dim IdItem As Long

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("ItemComprobanteInsertar", cn) With {.CommandType = CommandType.StoredProcedure}
                    With cmd.Parameters
                        .Add("p_IdOperacion", MySqlDbType.Int64).Value = argIdOperacion
                        .Add("p_IdArticulo", MySqlDbType.VarChar).Value = argItemComprobante.Articulo.IdArticulo
                        .Add("p_Descripcion", MySqlDbType.VarChar).Value = argItemComprobante.Descripcion
                        .Add("p_Cantidad", MySqlDbType.Decimal).Value = argItemComprobante.Cantidad
                        .Add("p_AlicIVA", MySqlDbType.Decimal).Value = argItemComprobante.AlicIVA
                        .Add("p_PrecioCosto", MySqlDbType.Decimal).Value = argItemComprobante.Articulo.PrecioCosto
                        .Add("p_PrecioUnitario", MySqlDbType.Decimal).Value = argItemComprobante.PrecioUnitario
                        .Add("p_Descuento", MySqlDbType.Decimal).Value = argItemComprobante.DescuentoUnitario
                        .Add("p_IdItem", MySqlDbType.Int64)
                    End With

                    cmd.Parameters("p_IdItem").Direction = ParameterDirection.Output
                    cmd.ExecuteNonQuery()
                    IdItem = CLng(cmd.Parameters("p_IdItem").Value)
                    Return IdItem
                End Using

            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarItemComprobante", Ex.Message))
            Return 0

        End Try

    End Function

    Public Function ActualizarItemComprobante(
                                            ByVal argIdItem As Long,
                                            ByVal argCantidad As Decimal,
                                            ByVal argPrecioUnitario As Decimal,
                                            ByVal argDescuento As Decimal
                                            ) As Boolean


        Try
            Dim objConexionDB As New D_Conexion

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("ItemComprobanteActualizar", cn) With {.CommandType = CommandType.StoredProcedure}
                    With cmd.Parameters
                        .Add("p_IdItem", MySqlDbType.Int64).Value = argIdItem
                        .Add("p_Cantidad", MySqlDbType.Decimal).Value = argCantidad
                        .Add("p_PrecioUnitario", MySqlDbType.Decimal).Value = argPrecioUnitario
                        .Add("p_Descuento", MySqlDbType.Decimal).Value = argDescuento
                    End With

                    Dim FilasAfectadas As Int32 = Convert.ToInt32(cmd.ExecuteNonQuery())
                    Return (FilasAfectadas > 0) ' Devuelve True si se actualizó al menos una fila

                End Using

            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ActualizarArticulo", Ex.Message))

        End Try

    End Function

    Public Function EliminarItemComprobante(ByVal argIdItem As Long) As Boolean
        Try
            Dim objConexionDB As New D_Conexion

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("ItemComprobanteEliminar", cn) With {.CommandType = CommandType.StoredProcedure}
                    With cmd.Parameters
                        .Add("p_IdItem", MySqlDbType.Int64).Value = argIdItem
                    End With

                    Dim FilasAfectadas As Int32 = Convert.ToInt32(cmd.ExecuteNonQuery())
                    Return (FilasAfectadas > 0) ' Devuelve True si se actualizó al menos una fila

                End Using

            End Using

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "EliminarItemComprobante", ex.Message))
        End Try
    End Function

#End Region

End Class
