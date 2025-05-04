Public Class Cliente
    Inherits Persona
    Property IVA As IVA
    Public Sub New(
                ByVal argIdCliente As Int32,
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
                ByVal argCodIVA As String
               )

        MyBase.New(argIdCliente, argNombre, argDomicilio, argLocalidad, argProvincia, argTelefono, argEmail, argCodiTDoc, argNumDoc, argFechaAlta, argEstado)
        Me.IVA = New IVA(argCodIVA)

    End Sub

End Class