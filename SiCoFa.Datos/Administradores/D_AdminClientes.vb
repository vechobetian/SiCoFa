Imports MySql.Data.MySqlClient
Imports SiCoFa.Entidades
Imports System.Collections.Generic

Public Class D_AdminClientes
    Public Function ObtenerClientePorId(ByVal argIdCliente As Long) As Cliente

        Dim objConexionDB As New D_Conexion
        Dim objCli As Cliente = Nothing

        Try
            Dim sql As String = "SELECT IdCliente,Nombre,Domicilio,Localidad,Provincia,Telefono,Email,CodiTD,NumDoc,FechaAlta,Estado,CodIVA FROM clientes WHERE IdCliente=@IdCliente"

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql
                    cmd.Parameters.AddWithValue("@IdCliente", argIdCliente)

                    Using datos As MySqlDataReader = cmd.ExecuteReader()

                        If datos.Read() Then
                            Dim objDoc As New Documento(datos.GetString("CodiTD"), datos.GetString("NumDoc"))
                            objCli = New Cliente(
                                                datos.GetInt32("IdCliente"),
                                                datos.GetString("Nombre"),
                                                If(datos.IsDBNull(datos.GetOrdinal("Domicilio")), "", datos.GetString("Domicilio")),
                                                If(datos.IsDBNull(datos.GetOrdinal("Localidad")), "", datos.GetString("Localidad")),
                                                If(datos.IsDBNull(datos.GetOrdinal("Provincia")), "", datos.GetString("Provincia")),
                                                If(datos.IsDBNull(datos.GetOrdinal("Telefono")), "", datos.GetString("Telefono")),
                                                If(datos.IsDBNull(datos.GetOrdinal("Email")), "", datos.GetString("Email")),
                                                objDoc,
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
            Throw New Exception(Vecho.MensajeError(Me.ToString, NameOf(ObtenerClientePorId), ex.Message))

        End Try

    End Function

    Public Function ListarClientes(ByVal argTextoBuscado As String) As List(Of Cliente)
        Dim objConexionDB As New D_Conexion
        Dim lc As New List(Of Cliente)
        Dim c As Cliente

        Try
            Dim sql As String
            If argTextoBuscado = "*" Then
                sql = "SELECT IdCliente,Nombre,Domicilio,Localidad,Provincia,Telefono,Email,CodiTD,NumDoc,FechaAlta,Estado,CodIVA FROM clientes ORDER BY Nombre"
            Else
                sql = "SELECT IdCliente,Nombre,Domicilio,Localidad,Provincia,Telefono,Email,CodiTD,NumDoc,FechaAlta,Estado,CodIVA FROM clientes WHERE Nombre LIKE @Nombre ORDER BY Nombre"
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
                        Dim codiTDOrdinal As Integer = datos.GetOrdinal("CodiTD")
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
                            Dim CodiTDResult As String = datos.GetString(codiTDOrdinal)
                            Dim NumDocResult As String = datos.GetString(numDocOrdinal)
                            Dim FechaAltaResult As Date = Convert.ToDateTime(datos(fechaAltaOrdinal))
                            Dim EstadoResult As String = datos.GetString(estadoOrdinal)
                            Dim CodIVAResult As String = datos.GetString(codIVAOrdinal)
                            Dim d As New Documento(CodiTDResult, NumDocResult)
                            c = New Cliente(IdClienteResult, NombreResult, DomicilioResult, LocalidadResult, ProvinciaResult, TelefonoResult, EmailResult, d, FechaAltaResult, EstadoResult, CodIVAResult)
                            lc.Add(c)
                        End While

                    End Using

                End Using

            End Using

            Return lc

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, NameOf(ListarClientes), ex.Message))
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
                                    ByVal argCodiTD As String,
                                    ByVal argNumDoc As String,
                                    ByVal argCodIVA As String
                                    ) As Int32

        Dim IdCliente As Int32
        Try
            Dim objConexionDB As New D_Conexion

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("sp_insertar_cliente", cn) With {.CommandType = CommandType.StoredProcedure}
                    With cmd.Parameters
                        .Add("p_Nombre", MySqlDbType.VarChar).Value = argNombre
                        .Add("p_Domicilio", MySqlDbType.VarChar).Value = argDomicilio
                        .Add("p_Localidad", MySqlDbType.VarChar).Value = argLocalidad
                        .Add("p_Provincia", MySqlDbType.VarChar).Value = argProvincia
                        .Add("p_Telefono", MySqlDbType.VarChar).Value = argTelefono
                        .Add("p_Email", MySqlDbType.VarChar).Value = argEmail
                        .Add("p_CodiTD", MySqlDbType.VarChar).Value = argCodiTD
                        .Add("p_NumDoc", MySqlDbType.VarChar).Value = argNumDoc
                        .Add("p_CodIVA", MySqlDbType.VarChar).Value = argCodIVA
                        .Add("p_IdCliente", MySqlDbType.Int32)
                    End With

                    cmd.Parameters("p_IdCliente").Direction = ParameterDirection.Output
                    cmd.ExecuteNonQuery()
                    IdCliente = CInt(cmd.Parameters("p_IdCliente").Value)
                End Using

            End Using
            Return IdCliente

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, NameOf(InsertarCliente), Ex.Message))

        End Try

    End Function
    Public Function ActualizarCliente(
                                    ByVal argIdCliente As Integer,
                                    ByVal argDomicilio As String,
                                    ByVal argLocalidad As String,
                                    ByVal argProvincia As String,
                                    ByVal argTelefono As String,
                                    ByVal argEmail As String,
                                    ByVal argCodiTD As String,
                                    ByVal argNumDoc As String,
                                    ByVal argCodIVA As String,
                                    ByVal argEstado As String
                                    ) As Boolean


        Try
            Dim objConexionDB As New D_Conexion

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("sp_actualizar_cliente", cn) With {.CommandType = CommandType.StoredProcedure}
                    With cmd.Parameters
                        .Add("p_IdCliente", MySqlDbType.Int32).Value = argIdCliente
                        .Add("p_Domicilio", MySqlDbType.VarChar).Value = argDomicilio
                        .Add("p_Localidad", MySqlDbType.VarChar).Value = argLocalidad
                        .Add("p_Provincia", MySqlDbType.VarChar).Value = argProvincia
                        .Add("p_Telefono", MySqlDbType.VarChar).Value = argTelefono
                        .Add("p_Email", MySqlDbType.VarChar).Value = argEmail
                        .Add("p_CodiTD", MySqlDbType.VarChar).Value = argCodiTD
                        .Add("p_NumDoc", MySqlDbType.VarChar).Value = argNumDoc
                        .Add("p_CodIVA", MySqlDbType.VarChar).Value = argCodIVA
                        .Add("p_Estado", MySqlDbType.VarChar).Value = argEstado
                    End With

                    Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()
                    Return (filasAfectadas > 0) ' Devuelve True si se actualizó al menos una fila

                End Using

            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, NameOf(ActualizarCliente), Ex.Message))
            Return False

        End Try

    End Function

    Public Function ObtenerCuentaCorrientePorIdCliente(ByVal argIdCliente As Int32) As CuentaCorriente

        Dim objConexionDB As New D_Conexion
        Dim objCC As CuentaCorriente = Nothing

        Try
            Dim sql As String = "SELECT IdCC,IdCliente,Descripcion,Credito,FechaAlta,Observaciones,Estado,Saldo FROM vw_cuentas_corriente WHERE IdCliente=@IdCliente"

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
            Throw New Exception(Vecho.MensajeError(Me.ToString, NameOf(ObtenerCuentaCorrientePorIdCliente), ex.Message))
            Return Nothing

        End Try

    End Function

    Public Function ListarCuentasCorriente(ByVal argTextoBuscado As String) As List(Of CuentaCorriente)
        Dim objConexionDB As New D_Conexion
        Dim lc As New List(Of CuentaCorriente)
        Dim c As CuentaCorriente

        Try
            Dim sql As String
            If argTextoBuscado = "*" Then
                sql = "SELECT IdCC,IdCliente,Descripcion,Credito,FechaAlta,Observaciones,Estado,Saldo FROM vw_cuentas_corriente ORDER BY Descripcion"
            Else
                sql = "SELECT IdCC,IdCliente,Descripcion,Credito,FechaAlta,Observaciones,Estado,Saldo FROM vw_cuentas_corriente WHERE Descripcion LIKE @Descripcion ORDER BY Descripcion"
            End If

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql

                    If argTextoBuscado <> "*" Then
                        cmd.Parameters.AddWithValue("@Descripcion", Replace(UCase(argTextoBuscado), " ", "%") & "%")
                    End If

                    Using datos As MySqlDataReader = cmd.ExecuteReader()
                        Dim idCCOrdinal As Integer = datos.GetOrdinal("IdCC")
                        Dim idClienteOrdinal As Integer = datos.GetOrdinal("IdCliente")
                        Dim descripcionOrdinal As Integer = datos.GetOrdinal("Descripcion")
                        Dim creditoOrdinal As Integer = datos.GetOrdinal("Credito")
                        Dim fechaAltaOrdinal As Integer = datos.GetOrdinal("FechaAlta")
                        Dim observacionesOrdinal As Integer = datos.GetOrdinal("Observaciones")
                        Dim estadoOrdinal As Integer = datos.GetOrdinal("Estado")
                        Dim saldoOrdinal As Integer = datos.GetOrdinal("Saldo")

                        While datos.Read
                            Dim IdCCResult As Int32 = Convert.ToInt32(datos(idCCOrdinal))
                            Dim IdClienteResult As Int32 = Convert.ToInt32(datos(idClienteOrdinal))
                            Dim DescripcionResult As String = datos.GetString(descripcionOrdinal)
                            Dim CreditoResul As Decimal = Convert.ToDecimal(creditoOrdinal)
                            Dim FechaAltaResult As Date = Convert.ToDateTime(datos(fechaAltaOrdinal))
                            Dim ObservacionesResult As String = datos.GetString(observacionesOrdinal)
                            Dim EstadoResult As String = datos.GetString(estadoOrdinal)
                            Dim SaldoResult As Decimal = Convert.ToDecimal(saldoOrdinal)
                            c = New CuentaCorriente(IdCCResult, IdClienteResult, DescripcionResult, CreditoResul, FechaAltaResult, ObservacionesResult, EstadoResult, SaldoResult)
                            lc.Add(c)
                        End While

                    End Using

                End Using

            End Using

            Return lc

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, NameOf(ListarCuentasCorriente), ex.Message))
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

                Using cmd As New MySqlCommand("sp_insertar_cuenta_corriente", cn) With {.CommandType = CommandType.StoredProcedure}
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
            Throw New Exception(Vecho.MensajeError(Me.ToString, NameOf(InsertarCuentaCorriente), Ex.Message))

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

                Using cmd As New MySqlCommand("sp_actualizar_cuenta_corriente", cn) With {.CommandType = CommandType.StoredProcedure}
                    With cmd.Parameters
                        .Add("p_IdCC", MySqlDbType.Int32).Value = argIdCC
                        .Add("p_Credito", MySqlDbType.Decimal).Value = argCredito
                        .Add("p_Observaciones", MySqlDbType.Text).Value = argObservaciones
                        .Add("p_Estado", MySqlDbType.VarChar).Value = argEstado
                    End With

                    Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()
                    Return (filasAfectadas > 0) ' Devuelve True si se actualizó al menos una fila

                End Using

            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, NameOf(ActualizarCuentaCorriente), Ex.Message))
            Return False

        End Try

    End Function
End Class
