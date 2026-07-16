Public Class Matricula

    Public Property TipoMatricula As TipoMatricula
    Public Property Numero As String

    Public Sub New()

        Me.TipoMatricula = New TipoMatricula

    End Sub

    Public Sub New(ByVal argCodiTM As String, ByVal argNumero As String)

        Me.TipoMatricula = New TipoMatricula(argCodiTM)
        Me.Numero = argNumero

    End Sub

End Class
