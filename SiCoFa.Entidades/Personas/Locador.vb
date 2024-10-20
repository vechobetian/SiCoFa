Public Class Locador
    Inherits Persona
    Property IdLocador As Long
    Property IB As String
    Property InicioActividad As String
    Property IVA As IVA
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

        Me.IdLocador = argIdLocador
        Me.Nombre = argNombre
        Me.Domicilio = argDomicilio
        Me.Localidad = argLocalidad
        Me.Provincia = argProvincia
        Me.Telefono = argTelefono
        Me.Movil = ""
        Me.Email = ""
        Me.Documento = New Documento(80, argCUIT)
        Me.IB = argIB
        Me.IVA = New IVA(argIVA)
        Me.InicioActividad = argIniActiv
    End Sub

End Class