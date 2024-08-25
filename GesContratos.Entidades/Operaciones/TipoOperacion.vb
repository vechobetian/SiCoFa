Public Class TipoOperacion
    Property CodiTO As String
    Property TipoOperacion As String

    Public Sub New(ByVal argCodiTO As String, ByVal argTipoOperacion As String)
        Me.CodiTO = argCodiTO
        Me.TipoOperacion = argTipoOperacion
    End Sub
End Class
