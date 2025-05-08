Public Class AlicuotaIVA
    Property AlicIVA As Int16
    Property AlicuotaIVA As String
    Public Sub New(ByVal argAlicIVA As Int16)
        Me.AlicIVA = argAlicIVA
        Select Case argAlicIVA
            Case "1"
                Me.AlicuotaIVA = "10.50%"
            Case "2"
                Me.AlicuotaIVA = "21.00%"

        End Select
    End Sub

End Class
