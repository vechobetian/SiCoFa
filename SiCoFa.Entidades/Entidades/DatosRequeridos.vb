Public Class DatosRequeridos
    Public Property IdPlan As Long
    Public Property NumRta As Boolean
    Public Property NumAf As Boolean
    Public Property NombreAf As Boolean
    Public Property DocumentoAf As Boolean
    Public Property Prescriptor As Boolean
    Public Property Token As Boolean
    Public Property Diagnostico As Boolean

    Public Sub New(
                  argIdPlan As Long,
                  argNumRta As Boolean,
                  argNumAf As Boolean,
                  argNombreAf As Boolean,
                  argDocumentoAf As Boolean,
                  argPrescriptor As Boolean,
                  argToken As Boolean,
                  argDiagnostico As Boolean
                  )
        Me.IdPlan = argIdPlan
        Me.NumRta = argNumRta
        Me.NumAf = argNumAf
        Me.NombreAf = argNombreAf
        Me.DocumentoAf = argDocumentoAf
        Me.Prescriptor = argPrescriptor
        Me.Token = argToken
        Me.Diagnostico = argDiagnostico
    End Sub

End Class
