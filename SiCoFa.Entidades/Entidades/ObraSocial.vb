Public Class ObraSocial
    Property IdOS As Integer
    Property NombreOS As String
    Property Validador As String
    Property Financiador As String
    Property ComprobanteFiscal As Boolean
    Property NumeroActualizacion As Long?

    Public Sub New(ByVal argIdIOS As Integer, ByVal argNombreOS As String, ByVal argValidador As String, ByVal argFinanciador As String, ByVal argComprobanteFiscal As Boolean, ByVal argNumeroActualizacion As Long)
        Me.IdOS = argIdIOS
        Me.NombreOS = argNombreOS
        Me.Validador = argValidador
        Me.Financiador = argFinanciador
        Me.ComprobanteFiscal = argComprobanteFiscal
        Me.NumeroActualizacion = argNumeroActualizacion
    End Sub

End Class
