Public Class TipoDocumento

    Public Property CodiTDoc As String

    Public Sub New(codiTDoc As String)
        Me.CodiTDoc = codiTDoc.ToUpper.Trim
    End Sub

    Public ReadOnly Property Descripcion As String
        Get
            Select Case CodiTDoc
                Case "DNI"
                    Return "Documento Nacional de Identidad"

                Case "CUIT"
                    Return "Clave Única de Identificación Tributaria"

                Case "CUIL"
                    Return "Código Único de Identificación Laboral"

                Case "LC"
                    Return "Libreta Cívica"

                Case "LE"
                    Return "Libreta de Enrolamiento"

                Case "CI"
                    Return "Cédula de Identidad"

                Case "PAS"
                    Return "Pasaporte"

                Case "SI"
                    Return "Sin Identificacion"

                Case Else
                    Return "Sin Informar"

            End Select
        End Get
    End Property

    Public ReadOnly Property CodiTDocAFIP As String
        Get
            Select Case CodiTDoc
                Case "CUIT"
                    Return "80"

                Case "CUIL"
                    Return "86"

                Case "LC"
                    Return "90"

                Case "DNI"
                    Return "96"

                Case "SI"
                    Return "99"

                Case Else
                    Return "99"
            End Select
        End Get
    End Property

    Public ReadOnly Property CodiTDocADESFA As String
        Get
            Select Case CodiTDoc
                Case "DNI", "CUIL", "LC", "LE", "CI", "PAS", "CUIT", "SI"
                    Return CodiTDoc

                Case Else
                    Return ""
            End Select
        End Get
    End Property

End Class