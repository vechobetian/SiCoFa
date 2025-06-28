Public Class OperacionCP
    Property IdOperacion As Long
    Property IdProveedor As Int32
    Property Resu As String
    Property Importe As Decimal
    Property EstadoOperacionCP As String
    Property IdOperaCancel As Long

    Public Sub New(ByVal argIdOperacion As Long, ByVal argIdProveedor As Int32, argResu As String, ByVal argImporte As Decimal, ByVal argEstadoOperacionCP As String, ByVal argIdOperaCancel As Long)
        Me.IdOperacion = argIdOperacion
        Me.IdProveedor = argIdProveedor
        Me.Resu = argResu
        Me.Importe = argImporte
        Me.EstadoOperacionCP = argEstadoOperacionCP
        Me.IdOperaCancel = argIdOperaCancel
    End Sub

End Class
