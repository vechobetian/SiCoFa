Public Class ProcesoActualizacion
    Property CodiPA As String
    Property Descripcion As String
    Property PorcentajeAplicado As Decimal
    Property NumeroActualizacion As Long?
    Property StoredProcedure As String
    Property CodiLP As Integer

    Public Sub New(argCodiPA As String, argDescripcion As String, argPorcentajeAplicado As Decimal, argNumeroActualizacion As Long, argStoredProcedure As String, argCodiLP As Integer)
        Me.CodiPA = argCodiPA
        Me.Descripcion = argDescripcion
        Me.PorcentajeAplicado = argPorcentajeAplicado
        Me.NumeroActualizacion = argNumeroActualizacion
        Me.StoredProcedure = argStoredProcedure
        Me.CodiLP = argCodiLP
    End Sub

End Class
