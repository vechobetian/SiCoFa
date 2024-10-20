Public Class ItemConsumoLuz
    Property Item As Integer
    Property Descripcion As String
    Property Cantidad As Integer
    Property PUnit As Decimal
    Property Importe As Decimal
    Public Sub New(
                  ByVal argItem As Integer,
                  ByVal argDescripcion As String,
                  ByVal argCantidad As Integer,
                  ByVal argPUnit As Decimal
                  )
        Me.Item = argItem
        Me.Descripcion = argDescripcion
        Me.Cantidad = argCantidad
        Me.PUnit = argPUnit
        Me.Importe = Math.Round(Me.Cantidad * Me.PUnit, 2, MidpointRounding.ToEven)
    End Sub

End Class
