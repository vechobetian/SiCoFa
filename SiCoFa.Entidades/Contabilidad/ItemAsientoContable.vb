Public Class ItemAsientoContable
    Property CodiCta As String
    Property Importe As Decimal
    Property IdAf As Integer
    Property Columna As String
    Public Sub New(
                  ByVal argCodiCta As String,
                  ByVal argImporte As Decimal,
                  ByVal argIdAf As Integer
                  )
        Me.CodiCta = argCodiCta
        Me.Importe = argImporte
        Me.IdAf = argIdAf
    End Sub

End Class
