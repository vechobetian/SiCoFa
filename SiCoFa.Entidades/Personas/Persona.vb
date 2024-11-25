Public Class Persona
    Property Id As Long
    Property Nombre As String
    Property Domicilio As String = ""
    Property Localidad As String = ""
    Property Provincia As String = ""
    Property Telefono As String = ""
    Property Email As String = ""
    Property Documento As Documento
    Property IVA As IVA
    Property IB As String
    Property Fecha As Date
    Property Estado As String
    Property Pasword As String

    Public Sub New(
                ByVal argId As Long,
                ByVal argNombre As String,
                ByVal argDomicilio As String,
                ByVal argLocalidad As String,
                ByVal argProvincia As String,
                ByVal argTelefono As String,
                ByVal argEmail As String,
                ByVal argCodiTDoc As String,
                ByVal argNumDoc As String,
                ByVal argCodIVA As String,
                ByVal argIB As String,
                ByVal argFecha As Date,
                ByVal argEstado As String,
                Optional ByVal argPasword As String = ""
                )

        Me.Id = argId
        Me.Nombre = argNombre
        Me.Domicilio = argDomicilio
        Me.Localidad = argLocalidad
        Me.Provincia = argProvincia
        Me.Telefono = argTelefono
        Me.Email = argEmail
        Me.Documento = New Documento(argCodiTDoc, argNumDoc)
        Me.IVA = New IVA(argCodIVA)
        Me.IB = argIB
        Me.Fecha = argFecha
        Me.Estado = argEstado
        Me.Pasword = argPasword
    End Sub

End Class
