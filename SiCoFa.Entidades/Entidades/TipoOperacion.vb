Public Class TipoOperacion
    Property CodiTO As String
    Property TipoOperacion As String
    Property EfInv As Int16
    Property AfectaCajaAbierta As Boolean
    Property EfFin As Int16

    Public Sub New(ByVal argCodiTO As String, ByVal argTipoOperacion As String, ByVal argEfInv As Int16, ByVal argAfectaCajaAbierta As Boolean, ByVal argEfFin As Int16)
        Me.CodiTO = argCodiTO
        Me.TipoOperacion = argTipoOperacion
        Me.EfInv = argEfInv
        Me.AfectaCajaAbierta = argAfectaCajaAbierta
        Me.EfFin = argEfFin
    End Sub
End Class
