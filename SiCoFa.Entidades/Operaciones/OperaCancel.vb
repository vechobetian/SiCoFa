Public Class OperaCancel
    Property IdOperacion As Long
    Property IdOperaCancel As Long
    Property IdOperaAnticipos As Long
    Property Importe As Decimal
    Public Sub New(ByVal argIdOperacion As Long, ByVal argIdOperaCancel As Long, ByVal argIdOperaAnticipos As Long, ByVal argImporte As Decimal)
        Me.IdOperacion = argIdOperacion
        Me.IdOperaCancel = argIdOperaCancel
        Me.IdOperaAnticipos = argIdOperaAnticipos
        Me.Importe = argImporte
    End Sub
End Class
