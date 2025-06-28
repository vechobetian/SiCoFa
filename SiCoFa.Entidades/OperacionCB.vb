Public Class OperacionCB
    Property IdOperacion As Long
    Property IdCB As Int32
    Property Resu As String
    Property Importe As Decimal
    Property EstadoOperacionCB As String

    Public Sub New(ByVal argIdOperacion As Long, ByVal argIdCB As Int32, argResu As String, ByVal argImporte As Decimal, ByVal argEstadoOperacionCb As String)
        Me.IdOperacion = argIdOperacion
        Me.IdCB = argIdCB
        Me.Resu = argResu
        Me.Importe = argImporte
        Me.EstadoOperacionCB = argEstadoOperacionCb
    End Sub
End Class
