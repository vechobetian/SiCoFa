Public Class Empresa
    Inherits Persona
    Property IVA As IVA
    Property IB As String

    Public Sub New(
                ByVal argIdEmpresa As Long,
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
                ByVal argCodIVA As String,
                ByVal argIB As String
                )

        MyBase.New(argIdEmpresa, argNombre, argDomicilio, argLocalidad, argProvincia, argTelefono, argEmail, argCodiTDoc, argNumDoc, argFechaAlta, argEstado)
        Me.IVA = New IVA(argCodIVA)
        Me.IB = argIB

    End Sub

End Class