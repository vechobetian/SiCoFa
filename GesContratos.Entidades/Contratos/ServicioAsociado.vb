Public Class ServicioAsociado
    Property IdDS As Long
    Property CodiS As String
    Property Servicio As Servicio
    Property Cantidad As Integer
    Property Importe As Decimal
    Public Sub New(ByVal argIdDS As Long, ByVal argCodiS As String, ByVal argCantidad As Integer)
        Me.IdDS = argIdDS
        Me.CodiS = argCodiS
        Me.Cantidad = argCantidad
    End Sub

End Class
