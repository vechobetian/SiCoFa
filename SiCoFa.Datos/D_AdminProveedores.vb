Imports MySql.Data.MySqlClient
Imports SiCoFa.Entidades
Imports System.Collections.Generic

Public Class D_AdminProveedores
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
End Class
