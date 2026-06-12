Public Class CredencialOS
    Public Property Numero As String
    Public Property Afiliado As String
    Public Property Token As String

    Public Sub New(ByVal argNumero As String, ByVal argAfiliado As String)
        Me.Numero = argNumero
        Me.Afiliado = argAfiliado
    End Sub

End Class
