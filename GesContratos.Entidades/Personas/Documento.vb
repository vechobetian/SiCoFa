Public Class Documento

    Property TipoDoc As TipoDocumento
    Property Numero As String

    Public Sub New(ByVal argCodiTDoc As String,
                   ByVal argNumero As String
                  )

        Me.TipoDoc = New TipoDocumento(argCodiTDoc)
        Me.Numero = argNumero
    End Sub

End Class
