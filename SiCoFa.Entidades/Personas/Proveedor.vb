Public Class Proveedor
    Inherits Persona
    Property IdProveedor As Long
    Property IVA As IVA

    Public Sub New(
                ByVal argIdProveedor As Long,
                ByVal argNombre As String,
                ByVal argDomicilio As String,
                ByVal argLocalidad As String,
                ByVal argProvincia As String,
                ByVal argTelefono As String,
                ByVal argEmail As String,
                ByVal argCodiTDoc As String,
                ByVal argNumDoc As String,
                ByVal argCodIVA As String
                )

        Me.IdProveedor = argIdProveedor
        Me.Nombre = argNombre
        Me.Domicilio = argDomicilio
        Me.Localidad = argLocalidad
        Me.Provincia = argProvincia
        Me.Telefono = argTelefono
        Me.Email = argEmail
        Me.Documento = New Documento(argCodiTDoc, argNumDoc)
        Me.IVA = New IVA(argCodIVA)
    End Sub


End Class