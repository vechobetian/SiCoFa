Public Class AlicuotaIVA
    Property AlicIVA As Double
    Property AlicuotaIVA As String
    Public Sub New(ByVal argAlicIVA As Double)
        Me.AlicIVA = argAlicIVA
        Select Case argAlicIVA
            Case "10.50"
                Me.AlicuotaIVA = "10.50%"
            Case "21.00"
                Me.AlicuotaIVA = "21.00%"

        End Select
    End Sub

End Class
