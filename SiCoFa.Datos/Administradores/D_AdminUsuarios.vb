Imports MySql.Data.MySqlClient
Imports SiCoFa.Entidades
Imports System.Collections.Generic

Public Class D_AdminUsuarios
    Public Function ObtenerUsuarioPorId(ByVal argIdUsuario As Integer) As Usuario
        Dim objConexionDB As New D_Conexion
        Dim objUs As Usuario = Nothing

        Try
            Dim sql As String = "SELECT IdUsuario,Nombre,Domicilio,Localidad,Provincia,Telefono,Email,CodiTDoc,NumDoc,FechaAlta,Estado FROM usuarios WHERE IdUsuario=@IdUsuario"

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql
                    cmd.Parameters.AddWithValue("@IdUsuario", argIdUsuario)

                    Using datos As MySqlDataReader = cmd.ExecuteReader()

                        If datos.Read() Then
                            Dim objDoc As New Documento(datos.GetString("CodiTDoc"), datos.GetString("NumDoc"))
                            objUs = New Usuario(
                                               datos.GetInt32("IdUsuario"),
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

            Return objUs

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, NameOf(ObtenerUsuarioPorId), ex.Message))

        End Try

    End Function

    Public Function ListarUsuarios(ByVal argTextoBuscado As String) As List(Of Usuario)
        Dim objConexionDB As New D_Conexion
        Dim lu As New List(Of Usuario)
        Dim u As Usuario

        Try
            Dim sql As String
            If argTextoBuscado = "*" Then
                sql = "SELECT IdUsuario,Nombre,Domicilio,Localidad,Provincia,Telefono,Email,CodiTDoc,NumDoc,FechaAlta,Estado,Password FROM usuarios ORDER BY Nombre"
            Else
                sql = "SELECT IdUsuario,Nombre,Domicilio,Localidad,Provincia,Telefono,Email,CodiTDoc,NumDoc,FechaAlta,Estado,Password FROM usuarios WHERE Nombre LIKE @Nombre ORDER BY Nombre"
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
                            Dim EstadoResult As String = datos.GetString(estadoOrdinal)

                            Dim d As New Documento(CodiTDocResult, NumDocResult)

                            u = New Usuario(IdUsuarioResult, NombreResult, DomicilioResult, LocalidadResult, ProvinciaResult, TelefonoResult, EmailResult, d, FechaAltaResult, EstadoResult)
                            lu.Add(u)
                        End While

                    End Using

                End Using

            End Using

            Return lu

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, NameOf(ListarUsuarios), ex.Message))

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

                Using cmd As New MySqlCommand("sp_insertar_usuario", cn) With {.CommandType = CommandType.StoredProcedure}
                    With cmd.Parameters
                        .Add("p_Nombre", MySqlDbType.VarChar).Value = argNombre
                        .Add("p_Domicilio", MySqlDbType.VarChar).Value = argDomicilio
                        .Add("p_Localidad", MySqlDbType.VarChar).Value = argLocalidad
                        .Add("p_Provincia", MySqlDbType.VarChar).Value = argProvincia
                        .Add("p_Telefono", MySqlDbType.VarChar).Value = argTelefono
                        .Add("p_Email", MySqlDbType.VarChar).Value = argEmail
                        .Add("p_CodiTDoc", MySqlDbType.VarChar).Value = argCodiTDoc
                        .Add("p_NumDoc", MySqlDbType.VarChar).Value = argNumDoc
                        .Add("p_IdUsuario", MySqlDbType.Int32)
                    End With

                    cmd.Parameters("p_IdUsuario").Direction = ParameterDirection.Output
                    cmd.ExecuteNonQuery()
                    IdUsuario = Convert.ToInt32(cmd.Parameters("p_IdUsuario").Value)
                End Using

            End Using
            Return IdUsuario

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, NameOf(InsertarUsuario), Ex.Message))

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

                Using cmd As New MySqlCommand("sp_actualizar_usuario", cn) With {.CommandType = CommandType.StoredProcedure}
                    With cmd.Parameters
                        .Add("p_IdUsuario", MySqlDbType.Int32).Value = argIdUsuario
                        .Add("p_Domicilio", MySqlDbType.VarChar).Value = argDomicilio
                        .Add("p_Localidad", MySqlDbType.VarChar).Value = argLocalidad
                        .Add("p_Provincia", MySqlDbType.VarChar).Value = argProvincia
                        .Add("p_Telefono", MySqlDbType.VarChar).Value = argTelefono
                        .Add("p_Email", MySqlDbType.VarChar).Value = argEmail
                        .Add("p_CodiTDoc", MySqlDbType.VarChar).Value = argCodiTDoc
                        .Add("p_NumDoc", MySqlDbType.VarChar).Value = argNumDoc
                        .Add("p_Estado", MySqlDbType.VarChar).Value = argEstado
                    End With

                    Dim filasAfectadas As Int32 = cmd.ExecuteNonQuery()
                    Return (filasAfectadas > 0) ' Devuelve True si se actualizó al menos una fila

                End Using

            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, NameOf(ActualizarUsuario), Ex.Message))

        End Try

    End Function

    Public Function VerificarAutorizacionProceso(ByVal argIdUsuario As Integer, ByVal argPassword As String, ByVal argIdProceso As String) As String
        Try
            Dim objConexionDB As New D_Conexion
            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("sp_verificar_autorizacion_proceso", cn) With {.CommandType = CommandType.StoredProcedure}
                    With cmd.Parameters
                        .Add("p_IdUsuario", MySqlDbType.Int32).Value = argIdUsuario
                        .Add("p_Password", MySqlDbType.VarChar).Value = argPassword
                        .Add("p_IdProceso", MySqlDbType.VarChar).Value = argIdProceso
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

End Class
