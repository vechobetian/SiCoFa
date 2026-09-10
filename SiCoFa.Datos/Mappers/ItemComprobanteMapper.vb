Imports MySql.Data.MySqlClient
Imports SiCoFa.Entidades

Public Module ItemComprobanteMapper

    Public Function Map(datos As MySqlDataReader) As ItemComprobante

        Dim idItemOrdinal As Integer = datos.GetOrdinal("IdItem")
        Dim idArticuloOrdinal As Integer = datos.GetOrdinal("IdArticulo")
        Dim descripcionOrdinal As Integer = datos.GetOrdinal("Descripcion")
        Dim fraccionadoOrdinal As Integer = datos.GetOrdinal("Fraccionado")
        Dim cantidadOrdinal As Integer = datos.GetOrdinal("Cantidad")
        Dim alicIVAOrdinal As Integer = datos.GetOrdinal("AlicIVA")
        Dim precioCostoOrdinal As Integer = datos.GetOrdinal("PrecioCosto")
        Dim precioUnitarioOrdinal As Integer = datos.GetOrdinal("PrecioUnitario")
        Dim porcentajeDescuentoOrdinal As Integer = datos.GetOrdinal("PorcentajeDescuento")
        Dim codBarrasOrdinal As Integer = datos.GetOrdinal("CodBarras")
        Dim porcentajeOSOrdinal As Integer = datos.GetOrdinal("PorcentajeOS")
        Dim descuentoUnitarioOSOrdinal As Integer = datos.GetOrdinal("DescuentoUnitarioOS")
        Dim porcentajeCSOrdinal As Integer = datos.GetOrdinal("PorcentajeCS")
        Dim descuentoUnitarioCSOrdinal As Integer = datos.GetOrdinal("DescuentoUnitarioCS")

        Dim idItem As Long = Convert.ToInt64(datos.GetValue(idItemOrdinal))
        Dim idArticulo As String = datos.GetString(idArticuloOrdinal)
        Dim descripcion As String = datos.GetString(descripcionOrdinal)
        Dim fraccionado As Boolean = datos.GetBoolean(fraccionadoOrdinal)
        Dim cantidad As Decimal = Convert.ToDecimal(datos.GetValue(cantidadOrdinal))
        Dim alicIVA As Decimal = Convert.ToDecimal(datos.GetValue(alicIVAOrdinal))
        Dim precioCosto As Decimal = If(datos.IsDBNull(precioCostoOrdinal), 0D, Convert.ToDecimal(datos.GetValue(precioCostoOrdinal)))
        Dim precioUnitario As Decimal = Convert.ToDecimal(datos.GetValue(precioUnitarioOrdinal))
        Dim porcentajeDescuento As Decimal = Convert.ToDecimal(datos.GetValue(porcentajeDescuentoOrdinal))
        Dim codBarras As String = datos.GetString(codBarrasOrdinal)
        Dim porcentajeOS As Decimal = If(datos.IsDBNull(porcentajeOSOrdinal), 0D, Convert.ToDecimal(datos.GetValue(porcentajeOSOrdinal)))
        Dim descuentoUnitarioOS As Decimal = If(datos.IsDBNull(descuentoUnitarioOSOrdinal), 0D, Convert.ToDecimal(datos.GetValue(descuentoUnitarioOSOrdinal)))
        Dim porcentajeCS As Decimal = If(datos.IsDBNull(porcentajeCSOrdinal), 0D, Convert.ToDecimal(datos.GetValue(porcentajeCSOrdinal)))
        Dim descuentoUnitarioCS As Decimal = If(datos.IsDBNull(descuentoUnitarioCSOrdinal), 0D, Convert.ToDecimal(datos.GetValue(descuentoUnitarioCSOrdinal)))

        Return New ItemComprobante(
                                    idItem,
                                    idArticulo,
                                    codBarras,
                                    descripcion,
                                    fraccionado,
                                    cantidad,
                                    alicIVA,
                                    precioCosto,
                                    precioUnitario,
                                    porcentajeDescuento,
                                    porcentajeOS,
                                    descuentoUnitarioOS,
                                    porcentajeCS,
                                    descuentoUnitarioCS
                                    )

    End Function

End Module
