Public Class Secion
    Property Usuario As Usuario
    Property Inicio As DateTime
    Property Estado As String = "NO_INIC"

    Public Sub New(ByVal argUsuario As Usuario)
        Me.Usuario = argUsuario
        Me.Inicio = Now
        Me.Estado = "INIC"
    End Sub


End Class
