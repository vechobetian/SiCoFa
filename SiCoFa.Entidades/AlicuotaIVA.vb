Public Class AlicuotaIVA
    Property CodiAI As Integer
    Property Descripcion As String
    Property AlicIVA As Decimal

    Public Sub New(ByVal argCodiAI As Integer, ByVal argDescripcion As String, ByVal argAlicIVA As Decimal)
        Me.CodiAI = argCodiAI
        Me.Descripcion = argDescripcion
        Me.AlicIVA = argAlicIVA
    End Sub

End Class
