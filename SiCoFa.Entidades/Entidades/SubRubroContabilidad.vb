Public Class SubRubroContabilidad
    Property CodiSubRub As String
    Property CodiRub As String
    Property NombreSubRubro As String

    Public Sub New(ByVal argCodiSubRub As String, ByVal argCodiRub As String, ByVal argNombreSubRubro As String)
        Me.CodiSubRub = argCodiSubRub
        Me.CodiRub = argCodiRub
        Me.NombreSubRubro = argNombreSubRubro
    End Sub

End Class
