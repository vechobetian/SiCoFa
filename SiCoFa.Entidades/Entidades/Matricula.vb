Public Class Matricula
    Public Property CodiTM As String
    Public Property Numero As String

    Public Sub New(ByVal argCodiTM As String, ByVal argNumero As String)
        Me.CodiTM = argCodiTM.ToUpper.Trim
        Me.Numero = argNumero
    End Sub

    Public ReadOnly Property Descripcion As String
        Get
            Select Case CodiTM
                Case "N"
                    Return "NACIONAL"

                Case "P"
                    Return "PROVINCIAL"

                Case Else
                    Return "NO ESPECIFICADA"

            End Select
        End Get
    End Property

    Public ReadOnly Property CodiTMatADESFA As String
        Get
            Select Case CodiTM
                Case "N", "P"
                    Return CodiTM

                Case Else
                    Return "NO ESPECIFICADA"
            End Select
        End Get
    End Property

End Class


