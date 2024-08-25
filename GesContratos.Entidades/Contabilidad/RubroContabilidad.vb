Public Class RubroContabilidad
    Property CodiRub As String
    Property NombreRub As String
    Property SubRubros As List(Of SubRubroContabilidad)

    Public Sub New(ByVal argCodiRub As String, ByVal argNombreRub As String)
        Me.CodiRub = argCodiRub
        Me.NombreRub = argNombreRub
    End Sub

End Class
