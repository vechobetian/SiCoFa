Imports MySql.Data.MySqlClient
Imports SiCoFa.Entidades

Public Module ArticuloMapper

    Public Function Map(datos As MySqlDataReader) As Articulo

        Dim tipoVenta As New TipoVenta(datos("CodiTV").ToString())
        Dim alicuotaIVA As New AlicuotaIVA(CInt(datos("CodIVA")))
        Dim tamanioEnvase As New TamanioEnvase(datos("CodiTE").ToString)
        Dim tipoControlResult As New TipoControl(datos("CodiTiCo").ToString())
        Dim laboratorio As New Laboratorio(datos("CodiLabora").ToString, datos("Laboratorio").ToString())
        Dim monodroga As New Monodroga(CInt(datos("CodiMon")), datos("Monodroga").ToString())
        Dim accionFarmacologica As New AccionFarmacologica(CInt(datos("CodiAcFa")), datos("AccionFarmacologica").ToString())
        Dim seccion As New Seccion(datos("IdSeccion").ToString(), datos("Seccion").ToString(), Convert.ToBoolean(datos("EstablecerPrecio")))
        Dim viaAdministracion As ViaAdministracion = New ViaAdministracion(CInt(datos("CodiVia")), datos("ViaAdministracion").ToString)
        Dim tipoPromocion As New TipoPromocion(datos("CodiPro").ToString, CDec(datos("DesOferta")))
        Dim listaPrecios As New ListaPrecios(datos("CodiLP").ToString, datos("ListaPrecios").ToString)

        Return New Articulo(
                            datos("IdArticulo").ToString(),
                            CInt(datos("Codigo").ToString()),
                            datos("CodBarras").ToString(),
                            datos("NTroquel").ToString,
                            datos("Nombre").ToString(),
                            tipoVenta,
                            alicuotaIVA,
                            Convert.ToInt32(datos("Unidades")),
                            tamanioEnvase,
                            Convert.ToDateTime(datos("FechaPrecio")),
                            Convert.ToDecimal(datos("PrecioCosto")),
                            Convert.ToDecimal(datos("PrecioVenta")),
                            Convert.ToDecimal(datos("PrecioOferta")),
                            laboratorio,
                            monodroga,
                            accionFarmacologica,
                            Convert.ToBoolean(datos("Baja")),
                            tipoControlResult,
                            Convert.ToBoolean(datos("Heladera")),
                            seccion,
                            Convert.ToBoolean(datos("ActualizarPrecio")),
                            Convert.ToInt32(datos("StockC")),
                            Convert.ToInt32(datos("StockF")),
                            datos("GTIN").ToString,
                            viaAdministracion,
                            Convert.ToDecimal(datos("DesOferta")),
                            tipoPromocion,
                            CBool(datos("Fraccionable")),
                            datos("DFrac").ToString,
                            Convert.ToInt32(datos("UDiv")),
                            Convert.ToDecimal(datos("RFrac")),
                            Convert.ToBoolean(datos("Gravamen")),
                            Convert.ToInt32(datos("CodiFF")),
                            datos("Potencia").ToString,
                            Convert.ToInt32(datos("CodiUP")),
                            Convert.ToInt32(datos("CodiTU")),
                            listaPrecios
                            )

    End Function

End Module