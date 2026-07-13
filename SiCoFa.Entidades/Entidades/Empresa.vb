Public Class Empresa
    Inherits Persona
    Property IVA As TipoIVA
    Property IB As String

    Public Sub New(
                ByVal argIdEmpresa As Int32,
                ByVal argNombre As String,
                ByVal argDomicilio As String,
                ByVal argLocalidad As String,
                ByVal argProvincia As String,
                ByVal argTelefono As String,
                ByVal argEmail As String,
                ByVal argDocumento As Documento,
                ByVal argFechaAlta As Date,
                ByVal argEstado As String,
                ByVal argCodIVA As String,
                ByVal argIB As String
                )

        MyBase.New(argIdEmpresa, argNombre, argDomicilio, argLocalidad, argProvincia, argTelefono, argEmail, argDocumento, argFechaAlta, argEstado)
        Me.IVA = New TipoIVA(argCodIVA)
        Me.IB = argIB

    End Sub

End Class