Public Class PagoCliente
    Property IdOperacion As Long
    Property IdContrato As Integer
    Property ImpPagado As Decimal
    Property ImpAplicado As Decimal
    Property ImpNoAplicado As Decimal
    Property EstadoPago As String

    Public Sub New(ByVal argIdOperacion As Long, ByVal argIdContrato As Integer, ByVal argImpPagado As Decimal, ByVal argImpAplicado As Decimal, ByVal argImpNoAplicado As Decimal, ByVal argEstadoPago As String)
        Me.IdOperacion = argIdOperacion
        Me.IdContrato = argIdContrato
        Me.ImpPagado = argImpPagado
        Me.ImpAplicado = argImpAplicado
        Me.ImpNoAplicado = argImpNoAplicado
        Me.EstadoPago = argEstadoPago
    End Sub

End Class
