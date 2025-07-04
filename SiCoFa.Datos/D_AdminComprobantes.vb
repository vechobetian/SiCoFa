Imports MySql.Data.MySqlClient
Imports SiCoFa.Entidades
Imports System.Collections.Generic

Public Class D_AdminComprobantes
    Public Function ObtenerTipoComprobantePorCodiTC(ByVal argCodiTC As String) As TipoComprobante
        Dim objConexionDB As New D_Conexion
        Dim objTC As TipoComprobante = Nothing

        Try
            Dim Sql As String = "SELECT CodiTC,TipoComprobanteCLetra,Letra,TipoComprobanteSLetra,CodiTCARCA FROM TblTipoComprobantes WHERE CodiTC = @CodiTC"

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = Sql
                    cmd.Parameters.AddWithValue("@CodiTC", argCodiTC)

                    Using datos As MySqlDataReader = cmd.ExecuteReader()

                        If datos.Read Then
                            Dim CodiTC As String = datos("CodiTC")
                            Dim TipoComprobanteCLetra As String = datos("TipoComprobanteCLetra")
                            Dim Letra As String = datos("Letra")
                            Dim TipoComprobanteSLetra = datos("TipoComprobanteSLetra")
                            Dim CodiTCARCA As String = datos("CodiTCARCA")
                            objTC = New TipoComprobante(CodiTC, TipoComprobanteCLetra, Letra, TipoComprobanteSLetra, CodiTCARCA)
                        End If

                    End Using

                End Using

            End Using

            Return objTC

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerTipoComprobantePorCodiTC", ex.Message))
            Return Nothing

        End Try

    End Function

    Public Function ListarTipoComprobantes(ByVal argTextoBuscado As String) As List(Of TipoComprobante)

        Dim objConexionDB As New D_Conexion
        Dim ltc As New List(Of TipoComprobante)
        Dim tc As TipoComprobante

        Try
            Dim sql As String
            If argTextoBuscado = "*" Then
                sql = "SELECT CodiTC,TipoComprobanteCLetra,Letra,TipoComprobanteSLetra,CodiTCARCA FROM TblTipoComprobantes ORDER BY TipoComprobanteCLetra"
            Else
                sql = "SELECT CodiTC,TipoComprobanteCLetra,Letra,TipoComprobanteSLetra,CodiTCARCA FROM TblTipoComprobantes WHERE TipoComprobanteCLetra LIKE @TipoComprobante ORDER BY TipoComprobanteCLetra"
            End If

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql

                    If argTextoBuscado <> "*" Then
                        cmd.Parameters.AddWithValue("@TipoComprobante", Replace(UCase(argTextoBuscado), " ", "%") & "%")
                    End If

                    Using datos As MySqlDataReader = cmd.ExecuteReader()

                        While datos.Read
                            tc = New TipoComprobante(datos("CodiTC"), datos("TipoComprobanteCLetra"), datos("Letra"), datos("TipoComprobanteSLetra"), datos("CodiTCARCA"))
                            ltc.Add(tc)
                        End While

                    End Using

                End Using

            End Using

            Return ltc

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ListarTipoComprobantes", ex.Message))
            Return Nothing

        End Try
    End Function

    Public Function EmitirComprobante(ByRef argComprobante As Comprobante) As Boolean
        Try
            Dim objConexionDB As New D_Conexion

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion
                cn.Open()
                Return EmitirComprobante(argComprobante, cn, Nothing)
            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarOperacionCC", Ex.Message))

        End Try

    End Function

    Friend Function EmitirComprobante(ByRef argComprobante As Comprobante, ByVal cn As MySqlConnection, ByVal tx As MySqlTransaction) As Boolean

        Try

            Using cmd As New MySqlCommand("ComprobanteEmitir", cn, tx) With {.CommandType = CommandType.StoredProcedure}

                With cmd.Parameters
                    .AddWithValue("p_IdOpera", argComprobante.Operacion.IdOperacion)
                    .AddWithValue("p_CodiTC", argComprobante.TipoComprobante.CodiTC_SiCoFa)
                    .AddWithValue("p_IdCliente", argComprobante.Cliente.Id)
                    .AddWithValue("p_ImpBto", argComprobante.ImpBto)
                    .AddWithValue("p_ImpDes", argComprobante.ImpDes)
                    .AddWithValue("p_ImpEx", argComprobante.ImpEx)
                    .AddWithValue("p_ImpGrav1", argComprobante.ImpGrav1)
                    .AddWithValue("p_ImpNeto1", argComprobante.ImpNeto1)
                    .AddWithValue("p_ImpIVA1", argComprobante.ImpIVA1)
                    .AddWithValue("p_ImpGrav2", argComprobante.ImpGrav2)
                    .AddWithValue("p_ImpNeto2", argComprobante.ImpNeto2)
                    .AddWithValue("p_ImpIVA2", argComprobante.ImpIVA2)
                    .AddWithValue("p_ImpCB", argComprobante.ImpCB)
                    .AddWithValue("p_ImpEf", argComprobante.ImpEf)
                    .AddWithValue("p_ImpCC", argComprobante.ImpCC)
                    .AddWithValue("p_ImpPE", argComprobante.ImpPE)
                    .AddWithValue("p_IdOperAsoc", argComprobante.IdOperAsoc)
                    .AddWithValue("p_TipoDoc", argComprobante.Cliente.Documento.TipoDoc.CodiTDoc)
                    .AddWithValue("p_NumDoc", argComprobante.Cliente.Documento.Numero)
                    .AddWithValue("p_Cliente", argComprobante.Cliente.Nombre)


                    cmd.Parameters.Add("p_PVenta", MySqlDbType.VarChar)
                    cmd.Parameters("p_PVenta").Direction = ParameterDirection.Output
                    cmd.Parameters.Add("p_NumComp", MySqlDbType.VarChar)
                    cmd.Parameters("p_NumComp").Direction = ParameterDirection.Output
                    cmd.Parameters.Add("p_FechaComp", MySqlDbType.VarChar)
                    cmd.Parameters("p_FechaComp").Direction = ParameterDirection.Output

                    Dim Insertado As Boolean = cmd.ExecuteNonQuery()

                    argComprobante.PVenta = cmd.Parameters("p_PVenta").Value
                    argComprobante.NumComp = cmd.Parameters("p_NumComp").Value
                    argComprobante.FechaComp = cmd.Parameters("p_FechaComp").Value
                    Return Insertado
                End With

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

    Public Function RecibirComprobante(ByRef argComprobante As Comprobante) As Boolean
        Try
            Dim objConexionDB As New D_Conexion

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion
                cn.Open()
                Return RecibirComprobante(argComprobante, cn, Nothing)
            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "RecibirOperacionCC", Ex.Message))

        End Try

    End Function

    Friend Function RecibirComprobante(ByRef argComprobante As Comprobante, ByVal cn As MySqlConnection, ByVal tx As MySqlTransaction) As Boolean

        Try

            Using cmd As New MySqlCommand("ComprobanteRecibir", cn, tx) With {.CommandType = CommandType.StoredProcedure}

                With cmd.Parameters
                    .AddWithValue("p_IdOpera", argComprobante.Operacion.IdOperacion)
                    .AddWithValue("p_CodiTC", argComprobante.TipoComprobante.CodiTC_SiCoFa)
                    .AddWithValue("p_FechaComp", argComprobante.FechaComp)
                    .AddWithValue("p_PVenta", argComprobante.PVenta)
                    .AddWithValue("p_NumComp", argComprobante.NumComp)
                    .AddWithValue("p_ImpBto", argComprobante.ImpBto)
                    .AddWithValue("p_ImpDes", argComprobante.ImpDes)
                    .AddWithValue("p_ImpEx", argComprobante.ImpEx)
                    .AddWithValue("p_ImpGrav1", argComprobante.ImpGrav1)
                    .AddWithValue("p_ImpNeto1", argComprobante.ImpNeto1)
                    .AddWithValue("p_ImpIVA1", argComprobante.ImpIVA1)
                    .AddWithValue("p_ImpGrav2", argComprobante.ImpGrav2)
                    .AddWithValue("p_ImpNeto2", argComprobante.ImpNeto2)
                    .AddWithValue("p_ImpIVA2", argComprobante.ImpIVA2)
                    .AddWithValue("p_ImpCB", argComprobante.ImpCB)
                    .AddWithValue("p_ImpEf", argComprobante.ImpEf)
                    .AddWithValue("p_ImpCC", argComprobante.ImpCC)
                    .AddWithValue("p_ImpPE", argComprobante.ImpPE)

                    Dim Insertado As Boolean = cmd.ExecuteNonQuery()

                    Return Insertado
                End With

            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "RecibirComprobante", Ex.Message))
            Return Nothing
        End Try

    End Function

End Class