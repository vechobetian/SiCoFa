Public Class Empleado
    Inherits Persona
    Public Sub New(
                ByVal argIdEmpleado As Long,
                ByVal argNombre As String,
                ByVal argDomicilio As String,
                ByVal argLocalidad As String,
                ByVal argProvincia As String,
                ByVal argTelefono As String,
                ByVal argEmail As String,
                ByVal argCodiTDoc As String,
                ByVal argNumDoc As String,
                ByVal argFechaAlta As Date,
                ByVal argEstado As String
                )

        MyBase.New(argIdEmpleado, argNombre, argDomicilio, argLocalidad, argProvincia, argTelefono, argEmail, argCodiTDoc, argNumDoc, "NA", "NA", argFechaAlta, argEstado)

    End Sub


End Class