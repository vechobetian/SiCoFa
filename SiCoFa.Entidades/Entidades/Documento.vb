Public Class Documento

    Property TipoDocumento As TipoDocumento
    Property Numero As String

    Public Sub New()
        TipoDocumento = New TipoDocumento
    End Sub

    Public Sub New(ByVal argCodiTDoc As String, ByVal argNumero As String)

        Me.TipoDocumento = New TipoDocumento(argCodiTDoc)
        Me.Numero = argNumero
    End Sub

End Class
