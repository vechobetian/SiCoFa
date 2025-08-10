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

    Public Function ObtenerComprobanteEmitidoPorIdOperacion(ByVal argIdOperacion As Long, ByVal argEmpresa As Empresa, Optional ByVal visitados As HashSet(Of Long) = Nothing) As Comprobante
        Dim objC As Comprobante = Nothing

        Try
            If visitados Is Nothing Then
                visitados = New HashSet(Of Long)
            End If

            If visitados.Contains(argIdOperacion) Then
                Return Nothing
            End If
            visitados.Add(argIdOperacion)

            Dim objConexionDB As New D_Conexion
            Dim sql As String = "SELECT IdOperacion, CodiTC, FechaComp, PVenta, NumComp, IdCliente, ImpBto, ImpDes,ImpNeto, ImpEx, ImpGrav1, ImpNeto1, ImpIVA1,
                        ImpGrav2, ImpNeto2, ImpIVA2, ImpCB, ImpEf, ImpCC, ImpPE, IdOperAsoc, CAE, VtoCAE, TipoDoc, NumDoc, Cliente, ComprobanteAsociado
                        FROM ConComprobantesEmitidos
                        WHERE IdOperacion=@IdOperacion"

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion
                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql
                    cmd.Parameters.AddWithValue("@IdOperacion", argIdOperacion)

                    Using datos As MySqlDataReader = cmd.ExecuteReader()
                        If datos.Read() Then
                            Dim AdminOperaciones As New D_AdminOperaciones
                            Dim objO As Operacion = AdminOperaciones.ObtenerOperacion(argIdOperacion)

                            Dim objTC As TipoComprobante = Me.ObtenerTipoComprobantePorCodiTC(Convert.ToString(datos("CodiTC")))

                            ' Manejo del CAE
                            Dim objCAE As CAE = Nothing
                            If Not IsDBNull(datos("CAE")) AndAlso Not String.IsNullOrWhiteSpace(Convert.ToString(datos("CAE"))) Then
                                objCAE = New CAE(
                                Convert.ToInt64(datos("NumComp")),
                                Convert.ToString(datos("CAE")),
                                Convert.ToDateTime(datos("VtoCAE"))
                            )
                            End If

                            Dim AdminClientes As New D_AdminClientes
                            Dim objCliente As Cliente = AdminClientes.ObtenerClientePorId(Convert.ToInt32(datos("IdCliente")))

                            Dim AdminItems As New D_AdminItemsComprobante
                            Dim objItems As List(Of ItemComprobante) = AdminItems.ListarItemsPorIdOperacion(argIdOperacion)

                            ' Comprobante asociado
                            Dim idOperAsoc As Long = If(IsDBNull(datos("IdOperAsoc")), 0, Convert.ToInt64(datos("IdOperAsoc")))
                            Dim objCompAsoc As Comprobante = Nothing
                            If idOperAsoc > 0 Then
                                objCompAsoc = ObtenerComprobanteEmitidoPorIdOperacion(idOperAsoc, argEmpresa, visitados)
                            End If

                            ' Construcción final del comprobante
                            objC = New Comprobante(
                            argIdOperacion:=argIdOperacion,
                            argOperacion:=objO,
                            argTipoComprobante:=objTC,
                            argPVenta:=Convert.ToString(datos("PVenta")),
                            argNumComp:=Convert.ToString(datos("NumComp")),
                            argFechaComp:=Convert.ToDateTime(datos("FechaComp")),
                            argImpBto:=Convert.ToDecimal(datos("ImpBto")),
                            argImpDes:=Convert.ToDecimal(datos("ImpDes")),
                            argImpNeto:=Convert.ToDecimal(datos("ImpNeto")),
                            argImpEx:=Convert.ToDecimal(datos("ImpEx")),
                            argImpGrav1:=Convert.ToDecimal(datos("ImpGrav1")),
                            argImpNeto1:=Convert.ToDecimal(datos("ImpNeto1")),
                            argImpIVA1:=Convert.ToDecimal(datos("ImpIVA1")),
                            argImpGrav2:=Convert.ToDecimal(datos("ImpGrav2")),
                            argImpNeto2:=Convert.ToDecimal(datos("ImpNeto2")),
                            argImpIVA2:=Convert.ToDecimal(datos("ImpIVA2")),
                            argImpCB:=Convert.ToDecimal(datos("ImpCB")),
                            argImpEf:=Convert.ToDecimal(datos("ImpEf")),
                            argImpCC:=Convert.ToDecimal(datos("ImpCC")),
                            argImpPE:=Convert.ToDecimal(datos("ImpPE")),
                            argCAE:=objCAE,
                            argIdCliente:=Convert.ToInt32(datos("IdCliente")),
                            argCliente:=objCliente,
                            argIdOperAsoc:=idOperAsoc,
                            argCompAsoc:=objCompAsoc,
                            argEmpresa:=argEmpresa,
                            argDetalle:=objItems
                        )
                        End If
                    End Using
                End Using
            End Using

            Return objC

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerComprobantePorIdOperacion", ex.Message))

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
                    .AddWithValue("p_ImpNeto", argComprobante.ImpNeto)
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