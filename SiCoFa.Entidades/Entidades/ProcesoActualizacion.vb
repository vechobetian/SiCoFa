Public Class ProcesoActualizacion
    Property CodiPA As String
    Property Descripcion As String

    'Property PorcentajeAplicado As Decimal
    Property NumeroActualizacion As Long?
    Property StoredProcedure As String
    Property ListaPrecios As ListaPrecios

    Public Sub New(argCodiPA As String, argDescripcion As String, argNumeroActualizacion As Long, argStoredProcedure As String, argListaPrecios As ListaPrecios)
        Me.CodiPA = argCodiPA
        Me.Descripcion = argDescripcion
        'Me.PorcentajeAplicado = argPorcentajeAplicado
        Me.NumeroActualizacion = argNumeroActualizacion
        Me.StoredProcedure = argStoredProcedure
        Me.ListaPrecios = argListaPrecios
    End Sub

End Class
