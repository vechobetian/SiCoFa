Imports SiCoFa.Datos
Imports SiCoFa.Entidades

Public Class N_AdminItemsComprobante
    Public Function ListarItemsPorIdOperacion(ByVal argIdOperacion As Long) As List(Of ItemComprobante)
        Try
            Dim AdminItems As New D_AdminItemsComprobante
            Dim objLI As List(Of ItemComprobante) = AdminItems.ListarItemsPorIdOperacion(argIdOperacion)
            Return objLI

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ListarItemsPorIdOperacion", ex.Message))

        End Try

    End Function

    Public Function InsertarItemComprobante(ByVal argIdOperacion As Long, ByVal argItemComprobante As ItemComprobante) As Long


        Try
            Dim AdminItems As New D_AdminItemsComprobante
            Dim IdItem As Long = AdminItems.InsertarItemComprobante(argIdOperacion, argItemComprobante)

            Return IdItem

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarItemComprobante", ex.Message))
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

            Dim AdminItems As New D_AdminItemsComprobante
            Dim Actualizado As Boolean = AdminItems.ActualizarItemComprobante(
                                                                              argIdItem,
                                                                              argCantidad,
                                                                              argPrecioCosto,
                                                                              argPrecioUnitario,
                                                                              argDescuento
                                                                              )
            Return Actualizado

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ActualizarItemComprobante", ex.Message))
            Return False

        End Try

    End Function

    Public Function EliminarItemComprobante(ByVal argIdItem As Long) As Boolean

        Try

            Dim AdminItems As New D_AdminItemsComprobante
            Dim Actualizado As Boolean = AdminItems.EliminarItemComprobante(argIdItem)
            Return Actualizado

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "EliminarItemComprobante", ex.Message))
            Return False

        End Try

    End Function

    Public Function ListarItemsCompraPorIdOperacion(ByVal argIdOperacion As Long) As List(Of ItemComprobanteCompra)
        Try
            Dim AdminItems As New D_AdminItemsComprobante
            Dim objLI As List(Of ItemComprobanteCompra) = AdminItems.ListarItemsCompraPorIdOperacion(argIdOperacion)
            Return objLI

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ListarItemsCompraPorIdOperacion", ex.Message))

        End Try

    End Function

    Public Function InsertarItemComprobanteCompra(ByVal argIdOperacion As Long, ByVal argItemComprobante As ItemComprobanteCompra) As Long


        Try
            Dim AdminItems As New D_AdminItemsComprobante
            Dim IdItem As Long = AdminItems.InsertarItemComprobanteCompra(argIdOperacion, argItemComprobante)

            Return IdItem

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarItemComprobanteCompra", ex.Message))
            Return 0
        End Try

    End Function

    Public Function ActualizarItemComprobanteCompra(
                                                    ByVal argIdItem As Long,
                                                    ByVal argCantidad As Decimal,
                                                    ByVal argPrecioCosto As Decimal,
                                                    ByVal argPrecioVenta As Decimal
                                                    ) As Boolean

        Try

            Dim AdminItems As New D_AdminItemsComprobante
            Dim Actualizado As Boolean = AdminItems.ActualizarItemComprobante(
                                                                              argIdItem,
                                                                              argCantidad,
                                                                              argPrecioCosto,
                                                                              argPrecioVenta,
                                                                              0
                                                                              )
            Return Actualizado

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ActualizarItemComprobanteCompra", ex.Message))
            Return False

        End Try

    End Function

    Public Function ListarItemsNCPorIdOperacion(ByVal argIdOperacion As Long) As List(Of ItemComprobanteNC)
        Try
            Dim AdminItems As New D_AdminItemsComprobante
            Dim objLI As List(Of ItemComprobanteNC) = AdminItems.ListarItemsNCPorIdOperacion(argIdOperacion)
            Return objLI

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ListarItemsNCPorIdOperacion", ex.Message))

        End Try
    End Function

End Class
