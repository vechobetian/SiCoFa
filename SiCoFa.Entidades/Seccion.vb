Public Class Seccion
    Property IdSeccion As String
    Property Seccion As String
    Property EstablecerPrecio As Boolean
    Public Sub New(ByVal argIdSeccion As String, ByVal argSeccion As String, ByVal argEstablecerPrecio As Boolean)
        Me.IdSeccion = argIdSeccion
        Me.Seccion = argSeccion
        Me.EstablecerPrecio = argEstablecerPrecio
    End Sub

End Class
