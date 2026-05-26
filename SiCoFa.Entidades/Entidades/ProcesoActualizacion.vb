Public Class ProcesoActualizacion
    Property CodiPA As String
    Property Descripcion As String
    Property PorcentajeAplicado As Decimal
    Property NumeroActualizacion As Long?
    Property StoredProcedure As String

    Public Sub New(ByVal argCodiPA As String, ByVal argDescripcion As String, ByVal argPorcentajeAplicado As Decimal, ByVal argNumeroActualizacion As Long, ByVal argStoredProcedure As String)
        Me.CodiPA = argCodiPA
        Me.Descripcion = argDescripcion
        Me.PorcentajeAplicado = argPorcentajeAplicado
        Me.NumeroActualizacion = argNumeroActualizacion
        Me.StoredProcedure = argStoredProcedure
    End Sub

End Class
