Public Class Usuario
    Inherits Persona
    Property IdUsuario As Long
    Property Password As String

    Public Sub New(
                ByVal argIdUsuario As Long,
                ByVal argNombre As String,
                ByVal argDomicilio As String,
                ByVal argLocalidad As String,
                ByVal argProvincia As String,
                ByVal argTelefono As String,
                ByVal argMovil As String,
                ByVal argEmail As String,
                ByVal argCodiTDoc As String,
                ByVal argNumDoc As String,
                ByVal argPassword As String
                )

        Me.IdUsuario = argIdUsuario
        Me.Nombre = argNombre
        Me.Domicilio = argDomicilio
        Me.Localidad = argLocalidad
        Me.Provincia = argProvincia
        Me.Telefono = argTelefono
        Me.Movil = argMovil
        Me.Email = argEmail
        Me.Documento = New Documento(argCodiTDoc, argNumDoc)
        Me.Password = argPassword

    End Sub


End Class