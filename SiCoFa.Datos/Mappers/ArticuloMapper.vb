Imports MySql.Data.MySqlClient
Imports SiCoFa.Entidades
Imports SiCoFa.Entidades.Enums

Public Module ArticuloMapper

    Public Function Map(datos As MySqlDataReader) As Articulo

        Dim TipoVenta As New TipoVenta(datos("CodiTV").ToString())
        Dim TamanioEnvase As New TamanioEnvase(datos("CodiTE").ToString)
        Dim TipoControlResult As New TipoControl(datos("CodiTiCo").ToString())
        Dim Laboratorio As New Laboratorio(Convert.ToInt32(datos("CodiLabora")), datos("Laboratorio").ToString())
        Dim Monodroga As New Monodroga(Convert.ToInt32(datos("CodiMon")), datos("Monodroga").ToString())
        Dim AccionFarmacologica As New AccionFarmacologica(Convert.ToInt32(datos("CodiAcFa")), datos("AccionFarmacologica").ToString())
        Dim Seccion As New Seccion(datos("IdSeccion").ToString(), datos("Seccion").ToString(), Convert.ToBoolean(datos("EstablecerPrecio")))
        Dim ViaAdministracion As ViaAdministracion = New ViaAdministracion(Convert.ToInt32(datos("CodiVia")), datos("ViaAdministracion").ToString)
        Dim TipoPromocion As New TipoPromocion(datos("CodiPro").ToString)
        Dim ListaPrecios As New ListaPrecios(datos("CodiLP").ToString, datos("ListaPrecios"))


        Return New Articulo(
                            datos("IdArticulo").ToString(),
                            datos("Codigo").ToString(),
                            datos("CodBarras").ToString(),
                            datos("NTroquel").ToString,
                            datos("Nombre").ToString(),
                            TipoVenta,
                            Convert.ToDecimal(datos("AlicIVA")),
                            Convert.ToInt32(datos("Unidades")),
                            TamanioEnvase,
                            Convert.ToDateTime(datos("FechaPrecio")),
                            Convert.ToDecimal(datos("PrecioCosto")),
                            Convert.ToDecimal(datos("PrecioVenta")),
                            Convert.ToDecimal(datos("PrecioOferta")),
                            Laboratorio,
                            Monodroga,
                            AccionFarmacologica,
                            Convert.ToBoolean(datos("Baja")),
                            TipoControlResult,
                            Convert.ToBoolean(datos("Heladera")),
                            Seccion,
                            Convert.ToBoolean(datos("ActualizarPrecio")),
                            Convert.ToInt32(datos("StockC")),
                            Convert.ToInt32(datos("StockF")),
                            datos("GTIN").ToString,
                            ViaAdministracion,
                            Convert.ToDecimal(datos("DesOferta")),
                            TipoPromocion,
                            datos("Fraccionable"),
                            datos("DFrac").ToString,
                            Convert.ToInt32(datos("UDiv")),
                            Convert.ToDecimal(datos("RFrac")),
                            Convert.ToBoolean(datos("Gravamen")),
                            Convert.ToInt32(datos("CodiFF")),
                            datos("Potencia").ToString,
                            Convert.ToInt32(datos("CodiUP")),
                            Convert.ToInt32(datos("CodiTU")),
                            ListaPrecios
                            )

    End Function

End Module