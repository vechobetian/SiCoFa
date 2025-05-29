Public Class TipoDocumento
    Property CodiTDoc As String
    Property TipoDocumento As String
    Public Sub New(ByVal argCodiTDoc As String)
        Me.CodiTDoc = argCodiTDoc
        Select Case argCodiTDoc
            Case "80"
                Me.TipoDocumento = "CUIT"
            Case "86"
                Me.TipoDocumento = "CUIL"
            Case "90"
                Me.TipoDocumento = "LC"
            Case "96"
                Me.TipoDocumento = "DNI"
            Case "99"
                Me.TipoDocumento = "S/I"
        End Select

    End Sub
End Class
