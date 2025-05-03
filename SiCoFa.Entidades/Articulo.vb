Public Class Articulo
    Property IdArticulo As String
    Property Codigo As String
    Property CodBarra As Long
    Property Nombre As String
    Property AlicIVA As AlicuotaIVA
    Property FechaPrecio As Date
    Property PrecioCosto As Decimal
    Property PrecioVenta As Decimal
    Property Baja As Boolean
    Property Seccion As Seccion
    Property ActualizarPrecio As Boolean
    Property Stock As Decimal
    Property ListaPrecios As ListaPrecios
    Property Fabricante As String

    Public Sub New(ByVal argIdArticulo As String,
                   ByVal argCodigo As String,
                   ByVal argCodBarra As Long,
                   ByVal argNombre As String,
                   ByVal argAlicIVA As AlicuotaIVA,
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
        Me.CodBarra = argCodBarra
        Me.Nombre = argNombre
        Me.AlicIVA = argAlicIVA
        Me.FechaPrecio = argFechaPrecio
        Me.PrecioCosto = argPrecioCosto
        Me.PrecioVenta = argPrecioVenta
        Me.Baja = argBaja
        Me.Seccion = argSeccion
        Me.ActualizarPrecio = argActualizarPrecio
        Me.Stock = argStock
        Me.ListaPrecios = argListaPrecios
        Me.Fabricante = argFabricante

    End Sub

End Class
