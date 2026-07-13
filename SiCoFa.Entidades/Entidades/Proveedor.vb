Public Class Proveedor
    Inherits Persona
    Public Sub New(
                ByVal argIdProveedor As Int32,
                ByVal argNombre As String,
                ByVal argDomicilio As String,
                ByVal argLocalidad As String,
                ByVal argProvincia As String,
                ByVal argTelefono As String,
                ByVal argEmail As String,
                ByVal argDocumento As Documento,
                ByVal argFechaAlta As Date,
                ByVal argEstado As String
                )

        MyBase.New(argIdProveedor, argNombre, argDomicilio, argLocalidad, argProvincia, argTelefono, argEmail, argDocumento, argFechaAlta, argEstado)

    End Sub

End Class