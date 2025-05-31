Public Class MedioDePagoEletronico
    Property IdMPE As String
    Property Descripcion As String
    Property CuentaBancaria As CuentaBancaria
    Property Baja As Boolean

    Public Sub New(ByVal argIdMPE As String, ByVal argDescripcion As String, ByVal argCuentaBancaria As CuentaBancaria, ByVal argBaja As Boolean)
        Me.IdMPE = argIdMPE
        Me.Descripcion = argDescripcion
        Me.CuentaBancaria = argCuentaBancaria
        Me.Baja = argBaja
    End Sub

End Class
