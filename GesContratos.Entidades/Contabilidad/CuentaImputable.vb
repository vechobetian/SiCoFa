Public Class CuentaImputable
    Property CodiCta As String
    Property CodiCtaCol As String
    Property NombreCta As String

    Public Sub New(ByVal argCodiCta As String, ByVal argCodiCtaCol As String, ByVal argNombreCta As String)
        Me.CodiCta = argCodiCta
        Me.CodiCtaCol = argCodiCtaCol
        Me.NombreCta = argNombreCta
    End Sub

End Class
