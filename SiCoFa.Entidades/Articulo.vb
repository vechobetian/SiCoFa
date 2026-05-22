Imports SiCoFa.Entidades.Enums

Public Class Articulo
    Property IdArticulo As String
    Property Codigo As Long
    Property CodBarras As String
    Property NTroquel As String
    Property Nombre As String
    Property TipoVenta As TipoVenta
    Property AlicuotaIVA As AlicuotaIVA
    Property Unidades As Integer
    Property TamanioEnvase As TamanioEnvase
    Property FechaPrecio As Date
    Property PrecioCosto As Decimal
    Property PrecioVenta As Decimal
    Property PrecioOferta As Decimal
    Property Laboratorio As Laboratorio
    Property AccionFarmacologica As AccionFarmacologica
    Property Monodroga As Monodroga
    Property Baja As Boolean
    Property TipoControl As TipoControl
    Property Heladera As Boolean
    Property Seccion As Seccion
    Property ActualizarPrecio As Boolean
    Property StockF As Integer
    Property StockC As Integer
    Property GTIN As String
    Property ViaAdministracoin As ViaAdministracion
    Property DesOferta As Decimal
    Property DFrac As String
    Property CodiPro As String
    Property UDiv As Integer
    Property RFrac As Decimal
    Property Gravamen As Boolean
    Property CodiFF As Integer
    Property Potencia As String
    Property CodiUP As Integer
    Property CodiTU As Integer
    Property ListaPrecios As ListaPrecios
    Property Fabricante As String

    Public Sub New(ByVal argIdArticulo As String,
                   ByVal argCodigo As String,
                   ByVal argCodBarras As String,
                   ByVal argNombre As String,
                   ByVal argAlicuotaIVA As AlicuotaIVA,
                   ByVal argFechaPrecio As Date,
                   ByVal argPrecioCosto As Decimal,
                   ByVal argPrecioVenta As Decimal,
                   ByVal argBaja As Boolean,
                   ByVal argSeccion As Seccion,
                   ByVal argActualizarPrecio As Boolean,
                   ByVal argStock As Decimal,
                   ByVal argListaPrecios As ListaPrecios,
                   ByVal argFabricante As String
                   )

        Me.IdArticulo = argIdArticulo
        Me.Codigo = argCodigo
        Me.CodBarras = argCodBarras
        Me.Nombre = argNombre
        Me.AlicuotaIVA = argAlicuotaIVA
        Me.FechaPrecio = argFechaPrecio
        Me.PrecioCosto = argPrecioCosto
        Me.PrecioVenta = argPrecioVenta
        Me.Baja = argBaja
        Me.Seccion = argSeccion
        Me.ActualizarPrecio = argActualizarPrecio
        Me.StockF = argStock
        Me.ListaPrecios = argListaPrecios
        Me.Fabricante = argFabricante

    End Sub

End Class
