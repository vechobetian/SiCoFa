Public Class ListaPrecios
    Property CodiLP As String
    Property ListaPrecios As String
    Property PrecioReferencia As String
    Property PorcentajeAplicadp As Decimal?
    Property NumeroActualizacion As Long?
    Property Baja As Boolean?

    Public Sub New()
        ' Este constructor puede estar vacío. Newtonsoft.Json lo usará para crear una instancia vacía
        ' y luego rellenará las propiedades públicas directamente desde el JSON.
    End Sub

    Public Sub New(ByVal argCodiLP As String, ByVal argListaPrecios As String, ByVal argPrecioReferencia As String, ByVal argPorcentajeAplicado As Decimal?, ByVal argNumeroActualizacion As Long?, ByVal argBaja As Boolean?)
        Me.CodiLP = argCodiLP
        Me.ListaPrecios = argListaPrecios
        Me.PrecioReferencia = argPrecioReferencia
        Me.PorcentajeAplicadp = argPorcentajeAplicado
        Me.NumeroActualizacion = argNumeroActualizacion
        Me.Baja = argBaja
    End Sub
    Public Sub New(ByVal argCodiLP As String, ByVal argListaPrecios As String)
        Me.CodiLP = argCodiLP
        Me.ListaPrecios = argListaPrecios
        Me.PrecioReferencia = Nothing
        Me.PorcentajeAplicadp = Nothing
        Me.NumeroActualizacion = Nothing
        Me.Baja = Nothing
    End Sub

End Class
