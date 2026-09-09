Imports MySql.Data.MySqlClient
Imports SiCoFa.Entidades
Imports System.Collections.Generic

Public Class D_AdminItemsReceta

    Public Function InsertarItemReceta(ByVal argIdItem As Long, ByVal argIdOperacion As Long, ByVal argItemComprobante As ItemComprobante) As Long

        Try
            Dim objConexionDB As New D_Conexion

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion
                Dim IdItem As Long = Me.InsertarItemReceta(argIdItem, argIdOperacion, argItemComprobante, cn, Nothing)
                Return IdItem
            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, NameOf(InsertarItemReceta), Ex.Message))
        End Try

    End Function

    Friend Function InsertarItemReceta(ByVal argIdItem As Long, ByVal argIdOperacion As Long, ByVal argItemComprobante As ItemComprobante, ByVal cn As MySqlConnection, ByVal tx As MySqlTransaction) As Long

        Try
            Dim objConexionDB As New D_Conexion
            Dim IdItem As Long

            Using cmd As New MySqlCommand("sp_insertar_item_receta", cn, tx) With {.CommandType = CommandType.StoredProcedure}
                With cmd.Parameters
                    .Add("p_IdItem", MySqlDbType.Int64).Value = argIdItem
                    .Add("p_IdOperacion", MySqlDbType.Int64).Value = argIdOperacion
                    .Add("p_IdReceta", MySqlDbType.Int64).Value = argItemComprobante.Receta.IdReceta
                    .Add("p_IdArticulo", MySqlDbType.VarChar).Value = argItemComprobante.Articulo.IdArticulo
                    .Add("p_Descripcion", MySqlDbType.VarChar).Value = argItemComprobante.Descripcion
                    .Add("p_Cantidad", MySqlDbType.Decimal).Value = argItemComprobante.Cantidad
                    .Add("p_PrecioUnitario", MySqlDbType.Decimal).Value = argItemComprobante.PrecioUnitario
                    .Add("p_PorcentajeOS", MySqlDbType.Decimal).Value = argItemComprobante.PorcentajeOS
                    .Add("p_DescuentoUnitarioOS", MySqlDbType.Decimal).Value = argItemComprobante.DescuentoUnitarioOS
                    .Add("p_PorcentajeCS", MySqlDbType.Decimal).Value = argItemComprobante.PorcentajeCS
                    .Add("p_DescuentoUnitarioCS", MySqlDbType.Decimal).Value = argItemComprobante.DescuentoUnitarioCS
                End With

                cmd.ExecuteNonQuery()
                IdItem = CLng(cmd.Parameters("p_IdItem").Value)
                Return IdItem
            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, NameOf(InsertarItemReceta), Ex.Message))
            Return 0

        End Try

    End Function

    Public Function ActualizarItemReceta(ByVal argIdItem As Long, ByVal argCantidad As Decimal, ByVal argPrecioCosto As Decimal, ByVal argPrecioUnitario As Decimal, ByVal argDescuento As Decimal) As Boolean

        Try
            Dim objConexionDB As New D_Conexion

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("sp_actualizar_item_comprobante", cn) With {.CommandType = CommandType.StoredProcedure}
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
            Throw New Exception(Vecho.MensajeError(Me.ToString, NameOf(ActualizarItemReceta), Ex.Message))

        End Try

    End Function

End Class

