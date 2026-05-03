Imports MySql.Data.MySqlClient
Imports SiCoFa.Entidades
Imports System.Collections.Generic

Public Class D_AdminEmpresas

    Public Function ObtenerEmpresaPorId(ByVal argIdEmpresa As Long) As Empresa

        Dim objConexionDB As New D_Conexion
        Dim objEmp As Empresa = Nothing

        Try
            Dim sql As String = "SELECT IdEmpresa,Nombre,Domicilio,Localidad,Provincia,Telefono,Email,CodiTDoc,NumDoc,FechaAlta,Estado,CodIVA,IB FROM empresas WHERE IdEmpresa=@IdEmpresa"

            Using cn As MySqlConnection = objConexionDB.ObtenerConexionFarmacias

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
                sql = "SELECT IdEmpresa,Nombre,Domicilio,Localidad,Provincia,Telefono,Email,CodiTDoc,NumDoc,FechaAlta,Estado,CodIVA,IB FROM empresas ORDER BY Nombre"
            Else
                sql = "SELECT IdEmpresa,Nombre,Domicilio,Localidad,Provincia,Telefono,Email,CodiTDoc,NumDoc,FechaAlta,Estado,CodIVA,IB FROM empresas WHERE Nombre LIKE @Nombre ORDER BY Nombre"
            End If

            Using cn As MySqlConnection = objConexionDB.ObtenerConexionFarmacias

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
            Using cn As MySqlConnection = objConexionDB.ObtenerConexionFarmacias

                Using cmd As New MySqlCommand("sp_insertar_empresa", cn) With {.CommandType = CommandType.StoredProcedure}
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
            Using cn As MySqlConnection = objConexionDB.ObtenerConexionFarmacias

                Using cmd As New MySqlCommand("sp_actualizar_empresa", cn) With {.CommandType = CommandType.StoredProcedure}
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


End Class
