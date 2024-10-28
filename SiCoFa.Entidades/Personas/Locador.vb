Public Class Locador
    Inherits Persona
    Property IB As String
    Property InicioActividad As String
    Public Sub New(
                ByVal argIdLocador As Long,
                ByVal argNombre As String,
                ByVal argDomicilio As String,
                ByVal argLocalidad As String,
                ByVal argProvincia As String,
                ByVal argTelefono As String,
                ByVal argCUIT As String,
                ByVal argIB As String,
                ByVal argIVA As String,
                ByVal argIniActiv As String
                )

        MyBase.New(argIdLocador, argNombre, argDomicilio, argLocalidad, argProvincia, argTelefono, "", "", "", "NA")

        Me.IB = argIB
        Me.InicioActividad = argIniActiv
    End Sub

End Class