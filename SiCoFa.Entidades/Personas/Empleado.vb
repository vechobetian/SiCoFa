Public Class Empleado
    Inherits Persona
    Property IdEmpleado As Long
    Public Sub New(
                ByVal argIdEmpleado As Long,
                ByVal argNombre As String,
                ByVal argDomicilio As String,
                ByVal argLocalidad As String,
                ByVal argProvincia As String,
                ByVal argTelefono As String,
                ByVal argEmail As String,
                ByVal argCodiTDoc As String,
                ByVal argNumDoc As String
                )

        Me.IdEmpleado = argIdEmpleado
        Me.Nombre = argNombre
        Me.Domicilio = argDomicilio
        Me.Localidad = argLocalidad
        Me.Provincia = argProvincia
        Me.Telefono = argTelefono
        Me.Email = argEmail
        Me.Documento = New Documento(argCodiTDoc, argNumDoc)
    End Sub


End Class