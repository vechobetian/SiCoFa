Imports MySql.Data.MySqlClient
Imports SiCoFa.Entidades
Imports SiCoFa.Entidades.Enums

Public Module ArticuloMapper

    Public Function Map(datos As MySqlDataReader) As Articulo

        Dim TipoVenta As TipoVenta = TipoVentaHelper.FromManualDat(datos("CodiTV").ToString())
        Dim TamanioEnvase As TamanioEnvase = TamanioEnvaseHelper.FromManualDat(datos("CodiTE").ToString())
        Dim TipoControlResult As New TipoControl(datos("CodiTiCo").ToString())
        Dim Laboratorio As New Laboratorio(Convert.ToInt32(datos("CodiLabora")), datos("Laboratorio").ToString())
        Dim Monodroga As New Monodroga(Convert.ToInt32(datos("CodiMon")), datos("Monodroga").ToString())
        Dim AccionFarmacologica As New AccionFarmacologica(Convert.ToInt32(datos("CodiAcFa")), datos("AccionFarmacologica").ToString())
        Dim Seccion As New Seccion(datos("IdSeccion").ToString(), datos("Seccion").ToString(), Convert.ToBoolean(datos("EstablecerPrecio")))
        Dim ListaPrecios As New ListaPrecios(datos("CodiLP").ToString, datos("ListaPrecios"))


        Return New Articulo(
                            datos("IdArticulo").ToString(),
                            datos("Codigo").ToString(),
                            datos("CodBarras").ToString(),
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
                            Seccion,
                            Convert.ToBoolean(datos("ActualizarPrecio")),
                            Convert.ToInt32(datos("StockC")),
                            Convert.ToInt32(datos("StockF")),
                            ListaPrecios
                            )

    End Function

End Module