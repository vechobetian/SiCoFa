Public Class AccionFarmacologica
    Property CodiAcFa As Integer
    Property AccionFarmacologica As String

    Public Sub New(ByVal argCodiAcFa As Integer, ByVal argAccionFarmacologica As String)
        Me.CodiAcFa = argCodiAcFa
        Me.AccionFarmacologica = argAccionFarmacologica
    End Sub

End Class
