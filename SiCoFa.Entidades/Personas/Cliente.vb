Public Class Cliente
    Inherits Persona
    Public Sub New(
                ByVal argIdCliente As Long,
                ByVal argNombre As String,
                ByVal argDomicilio As String,
                ByVal argLocalidad As String,
                ByVal argProvincia As String,
                ByVal argTelefono As String,
                ByVal argEmail As String,
                ByVal argCodiTDoc As String,
                ByVal argNumDoc As String,
                ByVal argCodIVA As String,
                ByVal argFechaAlta As Date,
                ByVal argEstado As String
                )

        MyBase.New(argIdCliente, argNombre, argDomicilio, argLocalidad, argProvincia, argTelefono, argEmail, argCodiTDoc, argNumDoc, argCodIVA, "NA", argFechaAlta, argEstado)

    End Sub

End Class