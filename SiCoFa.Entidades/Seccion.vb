Public Class Seccion
    Property IdSeccion As Int32
    Property Seccion As String
    Property EstablecerPrecio As Boolean
    Public Sub New(ByVal argIdSeccion As Int32, ByVal argSeccion As String, ByVal argEstablecerPrecio As Boolean)
        Me.IdSeccion = argIdSeccion
        Me.Seccion = argSeccion
        Me.EstablecerPrecio = argEstablecerPrecio
    End Sub

End Class
