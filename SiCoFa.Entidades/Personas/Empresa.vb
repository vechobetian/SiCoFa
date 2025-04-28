Public Class Empresa
    Inherits Persona
    Public Sub New(
                ByVal argIdEmpresa As Long,
                ByVal argNombre As String,
                ByVal argDomicilio As String,
                ByVal argLocalidad As String,
                ByVal argProvincia As String,
                ByVal argTelefono As String,
                ByVal argEmail As String,
                ByVal argCUIT As String,
                ByVal argCodIVA As String,
                ByVal argIB As String,
                ByVal argInicioActividades As String,
                ByVal argEstado As String
                )

        MyBase.New(argIdEmpresa, argNombre, argDomicilio, argLocalidad, argProvincia, argTelefono, argEmail, "CUIT", argCUIT, "01/01/01", argEstado)

    End Sub

End Class