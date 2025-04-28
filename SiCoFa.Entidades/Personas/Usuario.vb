Public Class Usuario
    Inherits Persona
    Public Sub New(
                ByVal argIdUsuario As Long,
                ByVal argNombre As String,
                ByVal argDomicilio As String,
                ByVal argLocalidad As String,
                ByVal argProvincia As String,
                ByVal argTelefono As String,
                ByVal argEmail As String,
                ByVal argCodiTDoc As String,
                ByVal argNumDoc As String,
                ByVal argFechaAlta As Date,
                ByVal argEstado As String,
                ByVal argPassword As String
                )

        MyBase.New(argIdUsuario, argNombre, argDomicilio, argLocalidad, argProvincia, argTelefono, argEmail, argCodiTDoc, argNumDoc, argFechaAlta, argEstado)

    End Sub

End Class