Public Class Persona
    Property Id As Int32
    Property Nombre As String
    Property Domicilio As String = ""
    Property Localidad As String = ""
    Property Provincia As String = ""
    Property Telefono As String = ""
    Property Email As String = ""
    Property Documento As Documento
    Property FechaAlta As Date
    Property Estado As String

    Public Sub New(
                ByVal argId As Int32,
                ByVal argNombre As String,
                ByVal argDomicilio As String,
                ByVal argLocalidad As String,
                ByVal argProvincia As String,
                ByVal argTelefono As String,
                ByVal argEmail As String,
                ByVal argCodiTDoc As String,
                ByVal argNumDoc As String,
                ByVal argFechaAlta As Date,
                ByVal argEstado As String
                )

        Me.Id = argId
        Me.Nombre = argNombre
        Me.Domicilio = argDomicilio
        Me.Localidad = argLocalidad
        Me.Provincia = argProvincia
        Me.Telefono = argTelefono
        Me.Email = argEmail
        Me.Documento = New Documento(argCodiTDoc, argNumDoc)
        Me.FechaAlta = argFechaAlta
        Me.Estado = argEstado
    End Sub

End Class
