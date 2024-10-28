Public Class Usuario
    Inherits Persona
    Property Password As String
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
                ByVal argPassword As String
                )

        MyBase.New(argIdUsuario, argNombre, argDomicilio, argLocalidad, argProvincia, argTelefono, argEmail, argCodiTDoc, argNumDoc, "NA")
        Me.Password = argPassword

    End Sub

End Class