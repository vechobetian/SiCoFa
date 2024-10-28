Public Class Proveedor
    Inherits Persona
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

        MyBase.New(argIdProveedor, argNombre, argDomicilio, argLocalidad, argProvincia, argTelefono, argEmail, argCodiTDoc, argNumDoc, argCodIVA)


    End Sub


End Class