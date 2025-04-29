Public Class IVA
    Property CodIVA As String
    Property TipoIVA As String

    Public Sub New(ByVal argCodIVA As String)
        Me.CodIVA = argCodIVA
        Select Case argCodIVA
            Case "CF"
                TipoIVA = "CONSUMIDOR FINAL"
            Case "RI"
                TipoIVA = "RESPONSABLE INSCRIPTO"
            Case "MT"
                TipoIVA = "RESPONSABLE MONOTRIBUTO"
            Case "EX"
                TipoIVA = "SUJETO EXENTO"
            Case Else
                TipoIVA = "NO IDENTIFICADO"
        End Select

    End Sub

End Class
