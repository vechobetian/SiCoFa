Public Class AccionFarmacologica
    Property Codi_AcFa As Integer
    Property AccionFarmacologia As String

    Public Sub New(ByVal argCodi_AcFa As Integer, ByVal argAccionFarmacologica As String)
        Me.Codi_AcFa = argCodi_AcFa
        Me.AccionFarmacologia = argAccionFarmacologica
    End Sub

End Class
