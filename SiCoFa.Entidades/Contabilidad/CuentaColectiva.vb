Public Class CuentaColectiva
    Property CodiCtaCol As String
    Property CodiSubRub As String
    Property NombreCtaCol As String

    Public Sub New(ByVal argCodiCtaCol As String, ByVal argCodiSubRub As String, ByVal argNombreCtaCol As String)
        Me.CodiCtaCol = argCodiCtaCol
        Me.CodiSubRub = argCodiSubRub
        Me.NombreCtaCol = argNombreCtaCol
    End Sub

End Class
