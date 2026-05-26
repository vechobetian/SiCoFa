Imports SiCoFa.Entidades.Enums

Public Class Articulo
    Property IdArticulo As String
    Property Codigo As Long
    Property CodBarras As String
    Property NTroquel As String
    Property Nombre As String
    Property TipoVenta As TipoVenta
    Property AlicIVA As Decimal
    Property Unidades As Integer
    Property TamanioEnvase As TamanioEnvase
    Property FechaPrecio As Date
    Property PrecioCosto As Decimal
    Property PrecioVenta As Decimal
    Property PrecioOferta As Decimal
    Property Laboratorio As Laboratorio
    Property Monodroga As Monodroga
    Property AccionFarmacologica As AccionFarmacologica
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

    Public Sub New(ByVal argIdArticulo As String,
                   ByVal argCodigo As String,
                   ByVal argCodBarras As String,
                   ByVal argNombre As String,
                   ByVal argTipoVenta As TipoVenta,
                   ByVal argAlicIVA As Decimal,
                   ByVal argUnidades As Integer,
                   ByVal argTamanioEnvase As TamanioEnvase,
                   ByVal argFechaPrecio As Date,
                   ByVal argPrecioCosto As Decimal,
                   ByVal argPrecioVenta As Decimal,
                   ByVal argPrecioOferta As Decimal,
                   ByVal argLaboratorio As Laboratorio,
                   ByVal argMonodroga As Monodroga,
                   ByVal argAccionFarmacologica As AccionFarmacologica,
                   ByVal argBaja As Boolean,
                   ByVal argTipoControl As TipoControl,
                   ByVal argSeccion As Seccion,
                   ByVal argActualizarPrecio As Boolean,
                   ByVal argStockC As Integer,
                   ByVal argStockF As Integer,
                   ByVal argListaPrecios As ListaPrecios
                   )

        Me.IdArticulo = argIdArticulo
        Me.Codigo = argCodigo
        Me.CodBarras = argCodBarras
        Me.Nombre = argNombre
        Me.TipoVenta = argTipoVenta
        Me.AlicIVA = argAlicIVA
        Me.Unidades = argUnidades
        Me.TamanioEnvase = argTamanioEnvase
        Me.FechaPrecio = argFechaPrecio
        Me.PrecioCosto = argPrecioCosto
        Me.PrecioVenta = argPrecioVenta
        Me.PrecioOferta = argPrecioOferta
        Me.Laboratorio = argLaboratorio
        Me.Monodroga = argMonodroga
        Me.AccionFarmacologica = argAccionFarmacologica
        Me.Baja = argBaja
        Me.TipoControl = argTipoControl
        Me.Seccion = argSeccion
        Me.ActualizarPrecio = argActualizarPrecio
        Me.StockC = argStockC
        Me.StockF = argStockF
        Me.ListaPrecios = argListaPrecios

    End Sub

End Class
