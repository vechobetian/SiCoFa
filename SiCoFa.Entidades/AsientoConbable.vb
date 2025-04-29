Public Class AsientoContable
    ReadOnly Property NumAsiento As Long
    ReadOnly Property IdEjercicio As Integer
    ReadOnly Property FechaAsiento As Date
    ReadOnly Property DetalleCuentas As New List(Of ItemAsientoContable)
    Public Sub InsertarItem(ByVal argCodiCta As String, ByVal argImporte As Decimal)
        Static IdAf As Integer
        IdAf += 1
        Dim ic As ItemAsientoContable
        ic = New ItemAsientoContable(argCodiCta, argImporte, IdAf)
        Me.DetalleCuentas.Add(ic)
    End Sub

End Class
