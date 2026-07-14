Public Class DatosRequeridos
    Public Property IdPlan As Long
    Public Property NumeroReceta As Boolean
    Public Property NumeroAfiliado As Boolean
    Public Property NombreAfiliado As Boolean
    Public Property DocumentoAfiliado As Boolean
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
        Me.NumeroReceta = argNumRta
        Me.NumeroAfiliado = argNumAf
        Me.NombreAfiliado = argNombreAf
        Me.DocumentoAfiliado = argDocumentoAf
        Me.Prescriptor = argPrescriptor
        Me.Token = argToken
        Me.Diagnostico = argDiagnostico
    End Sub

End Class
