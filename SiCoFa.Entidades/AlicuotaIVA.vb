Public Class AlicuotaIVA
    Property AlicIVA As Decimal
    Property AlicuotaIVA As String
    Public Sub New(ByVal argAlicIVA As Decimal)
        Me.AlicIVA = argAlicIVA
        Select Case argAlicIVA
            Case 10.5
                Me.AlicuotaIVA = "10.50%"
            Case 21
                Me.AlicuotaIVA = "21.00%"

        End Select
    End Sub

End Class
