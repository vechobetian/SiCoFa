Public Class MediosPagoElectronico
    Property IdMPE As String
    Property Descripcion As String
    Property IdCB As Int32
    Property Baja As Boolean

    Public Sub New(ByVal argIdMPE As String, ByVal argDescripcion As String, ByVal argIdCB As Int32, ByVal argBaja As Boolean)
        Me.IdMPE = argIdMPE
        Me.Descripcion = argDescripcion
        Me.IdCB = argIdCB
        Me.Baja = argBaja
    End Sub

End Class
