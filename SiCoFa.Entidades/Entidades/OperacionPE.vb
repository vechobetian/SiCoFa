Public Class OperacionPE
    Property IdOperacion As Long
    Property NumTransaccion As String
    Property Cuotas As Integer
    Property IdMPE As Integer
    Property Importe As Decimal
    Property EstadoTransaccion As String

    Public Sub New(ByVal argIdOperacion As Long, ByVal argNumTransaccion As String, ByVal argCuotas As Integer, ByVal argIdMPE As Integer, ByVal argImporte As Decimal, ByVal argEstadoTransaccion As String)
        Me.IdOperacion = argIdOperacion
        Me.NumTransaccion = argNumTransaccion
        Me.Cuotas = argCuotas
        Me.IdMPE = argIdMPE
        Me.Importe = argImporte
        Me.EstadoTransaccion = argEstadoTransaccion
    End Sub

End Class
