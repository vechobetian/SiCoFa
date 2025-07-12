Imports MySql.Data.MySqlClient
Imports SiCoFa.Entidades
Imports System.Collections.Generic

Public Class D_AdminItemsComprobante
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
                                            ByVal argPrecioCosto As Decimal,
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
                        .Add("p_PrecioCosto", MySqlDbType.Decimal).Value = argPrecioCosto
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

    Public Function ListarItemsCompraPorIdOperacion(ByVal argIdOperacion As Long) As List(Of ItemComprobanteCompra)
        Dim objConexionDB As New D_Conexion
        Dim objLI As New List(Of ItemComprobanteCompra)

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
                            Dim AdminArticulos As New D_AdminArticulos
                            Dim objArticulo As Articulo = AdminArticulos.ObtenerArticuloPorId(IdArticuloResult)

                            Dim objIC As New ItemComprobanteCompra(objArticulo, CantidadResult, PrecioCostoResult, PrecioUnitarioResult, objArticulo.ListaPrecios.PorcentajeAplicado, True)
                            objIC.IdItem = IdItemResult
                            objLI.Add(objIC)
                        End While
                    End Using
                End Using
            End Using

            Return objLI

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ListarItemsCompraPorIdOperacion", ex.Message))
            Return New List(Of ItemComprobanteCompra)

        End Try
    End Function

    Public Function InsertarItemComprobanteCompra(ByVal argIdOperacion As Long, ByVal argItemComprobante As ItemComprobanteCompra) As Long

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
                        .Add("p_PrecioUnitario", MySqlDbType.Decimal).Value = argItemComprobante.PrecioVenta
                        .Add("p_Descuento", MySqlDbType.Decimal).Value = 0
                        .Add("p_IdItem", MySqlDbType.Int64)
                    End With

                    cmd.Parameters("p_IdItem").Direction = ParameterDirection.Output
                    cmd.ExecuteNonQuery()
                    IdItem = CLng(cmd.Parameters("p_IdItem").Value)
                    Return IdItem
                End Using

            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarItemComprobanteComrpa", Ex.Message))
            Return 0

        End Try

    End Function

End Class
