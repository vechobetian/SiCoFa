Public Class ObraSocial
    Property IdOS As Integer
    Property NombreOS As String
    Property Validador As String
    Property PValidacion As ParametrosValidacion
    Property ComprobanteFiscal As Boolean
    Property NumeroActualizacion As Long?

    Public Sub New(ByVal argIdOS As Integer, ByVal argNombreOS As String, ByVal argValidador As String, ByVal argPValidacion As ParametrosValidacion, ByVal argComprobanteFiscal As Boolean, ByVal argNumeroActualizacion As Long)
        Me.IdOS = argIdOS
        Me.NombreOS = argNombreOS
        Me.Validador = argValidador
        Me.PValidacion = argPValidacion
        Me.ComprobanteFiscal = argComprobanteFiscal
        Me.NumeroActualizacion = argNumeroActualizacion
    End Sub

End Class
