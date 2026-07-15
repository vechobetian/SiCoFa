Imports MySql.Data.MySqlClient
Imports SiCoFa.Entidades
Imports System.Collections.Generic

Public Class D_AdminProveedores
    Public Function ObtenerProveedorPorId(ByVal argIdProveedor As Long) As Proveedor

        Dim objConexionDB As New D_Conexion
        Dim objProv As Proveedor = Nothing
        Try

            Dim sql As String = "SELECT IdProveedor,Nombre,Domicilio,Localidad,Provincia,Telefono,Email,CodiTD,NumDoc,FechaAlta,Estado FROM proveedores WHERE IdProveedor=@IdProveedor"
            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql
                    cmd.Parameters.AddWithValue("@IdProveedor", argIdProveedor)

                    Using datos As MySqlDataReader = cmd.ExecuteReader()
                        If datos.Read() Then

                            Dim objDoc As New Documento(datos.GetString("CodiTD"), datos.GetString("NumDoc"))
                            objProv = New Proveedor(
                                                    datos.GetInt32("IdProveedor"),
                                                    datos.GetString("Nombre"),
                                                    If(datos.IsDBNull(datos.GetOrdinal("Domicilio")), "", datos.GetString("Domicilio")),
                                                    If(datos.IsDBNull(datos.GetOrdinal("Localidad")), "", datos.GetString("Localidad")),
                                                    If(datos.IsDBNull(datos.GetOrdinal("Provincia")), "", datos.GetString("Provincia")),
                                                    If(datos.IsDBNull(datos.GetOrdinal("Telefono")), "", datos.GetString("Telefono")),
                                                    If(datos.IsDBNull(datos.GetOrdinal("Email")), "", datos.GetString("Email")),
                                                    objDoc,
                                                    datos.GetDateTime("FechaAlta"),
                                                    datos.GetString("Estado")
                                                    )
                        End If

                    End Using

                End Using

            End Using

            Return objProv

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, NameOf(ObtenerProveedorPorId), ex.Message))

        End Try

    End Function
    Public Function ListarProveedores(ByVal argTextoBuscado As String) As List(Of Proveedor)

        Dim objConexionDB As New D_Conexion
        Dim lp As New List(Of Proveedor)
        Dim p As Proveedor

        Try
            Dim sql As String
            If argTextoBuscado = "*" Then
                sql = "SELECT IdProveedor,Nombre,Domicilio,Localidad,Provincia,Telefono,Email,CodiTD,NumDoc,FechaAlta,Estado FROM proveedores ORDER BY Nombre"
            Else
                sql = "SELECT IdProveedor,Nombre,Domicilio,Localidad,Provincia,Telefono,Email,CodiTD,NumDoc,FechaAlta,Estado FROM proveedores WHERE Nombre LIKE @Nombre ORDER BY Nombre"
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
                        Dim codiTDOrdinal As Integer = datos.GetOrdinal("CodiTD")
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
                            Dim CodiTDResult As String = datos(codiTDOrdinal)
                            Dim NumDocResult As String = datos(numDocOrdinal)
                            Dim FechaAltaResult As Date = datos(fechaAltaOrdinal)
                            Dim EstadoResult As String = datos(estadoOrdinal)

                            Dim d As New Documento(CodiTDResult, NumDocResult)
                            p = New Proveedor(IdProveedorResult, NombreResult, DomicilioResult, LocalidadResult, ProvinciaResult, TelefonoResult, EmailResult, d, FechaAltaResult, EstadoResult)
                            lp.Add(p)
                        End While

                    End Using

                End Using

            End Using

            Return lp

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, NameOf(ListarProveedores), ex.Message))
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
                                    ByVal argCodiTD As String,
                                    ByVal argNumDoc As String
                                    ) As Int32

        Dim IdProveedor As Int32
        Try
            Dim objConexionDB As New D_Conexion
            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("sp_insertar_proveedor", cn) With {.CommandType = CommandType.StoredProcedure}
                    With cmd.Parameters
                        .Add("p_Nombre", MySqlDbType.VarChar).Value = argNombre
                        .Add("p_Domicilio", MySqlDbType.VarChar).Value = argDomicilio
                        .Add("p_Localidad", MySqlDbType.VarChar).Value = argLocalidad
                        .Add("p_Provincia", MySqlDbType.VarChar).Value = argProvincia
                        .Add("p_Telefono", MySqlDbType.VarChar).Value = argTelefono
                        .Add("p_Email", MySqlDbType.VarChar).Value = argEmail
                        .Add("p_CodiTD", MySqlDbType.VarChar).Value = argCodiTD
                        .Add("p_NumDoc", MySqlDbType.VarChar).Value = argNumDoc
                        .Add("p_IdProveedor", MySqlDbType.Int32)
                    End With

                    cmd.Parameters("p_IdProveedor").Direction = ParameterDirection.Output
                    cmd.ExecuteNonQuery()
                    IdProveedor = Convert.ToInt32(cmd.Parameters("p_IdProveedor").Value)
                End Using

            End Using

            Return IdProveedor

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, NameOf(InsertarProveedor), Ex.Message))

        End Try

    End Function
    Public Function ActualizarProveedor(
                                    ByVal argIdProveedor As Integer,
                                    ByVal argDomicilio As String,
                                    ByVal argLocalidad As String,
                                    ByVal argProvincia As String,
                                    ByVal argTelefono As String,
                                    ByVal argEmail As String,
                                    ByVal argCodiTD As String,
                                    ByVal argNumDoc As String,
                                    ByVal argEstado As String
                                    ) As Boolean



        Try
            Dim objConexionDB As New D_Conexion
            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("sp_actualizar_proveedor", cn) With {.CommandType = CommandType.StoredProcedure}
                    With cmd.Parameters
                        .Add("p_IdProveedor", MySqlDbType.Int32).Value = argIdProveedor
                        .Add("p_Domicilio", MySqlDbType.VarChar).Value = argDomicilio
                        .Add("p_Localidad", MySqlDbType.VarChar).Value = argLocalidad
                        .Add("p_Provincia", MySqlDbType.VarChar).Value = argProvincia
                        .Add("p_Telefono", MySqlDbType.VarChar).Value = argTelefono
                        .Add("p_Email", MySqlDbType.VarChar).Value = argEmail
                        .Add("p_CodiTD", MySqlDbType.VarChar).Value = argCodiTD
                        .Add("p_NumDoc", MySqlDbType.VarChar).Value = argNumDoc
                        .Add("p_Estado", MySqlDbType.VarChar).Value = argEstado
                    End With

                    Dim filasAfectadas As Int32 = Convert.ToInt32(cmd.ExecuteNonQuery())
                    Return (filasAfectadas > 0) ' Devuelve True si se actualizó al menos una fila

                End Using

            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, NameOf(ActualizarProveedor), Ex.Message))

        End Try

    End Function
End Class
