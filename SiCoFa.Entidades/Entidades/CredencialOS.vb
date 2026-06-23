Public Class CredencialOS
    Public Property Numero As String
    Public Property Nombre As String
    Public Property Token As String

    Public Sub New(ByVal argNumero As String, ByVal argNombre As String)
        Me.Numero = argNumero
        Me.Nombre = argNombre
    End Sub

End Class
