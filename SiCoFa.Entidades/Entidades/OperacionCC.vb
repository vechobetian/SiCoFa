Public Class OperacionCC
    Property IdOperacion As Long
    Property IdCC As Int32
    Property Resu As String
    Property Importe As Decimal
    Property EstadoOperacionCC As String
    Property IdOperaCancel As Long

    Public Sub New(ByVal argIdOperacion As Long, ByVal argIdCC As Int32, argResu As String, ByVal argImporte As Decimal, ByVal argEstadoOperacionCC As String, ByVal argIdOperaCancel As Long)
        Me.IdOperacion = argIdOperacion
        Me.IdCC = argIdCC
        Me.Resu = argResu
        Me.Importe = argImporte
        Me.EstadoOperacionCC = argEstadoOperacionCC
        Me.IdOperaCancel = argIdOperaCancel
    End Sub

End Class
