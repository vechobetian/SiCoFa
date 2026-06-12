Public Class Matricula
    Public Property CodiTMat As String
    Public Property Numero As String

    Public Sub New(ByVal argCodiTMat As String, ByVal argNumero As String)
        Me.CodiTMat = argCodiTMat.ToUpper.Trim
        Me.Numero = argNumero
    End Sub

    Public ReadOnly Property Descripcion As String
        Get
            Select Case CodiTMat
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
            Select Case CodiTMat
                Case "N", "P"
                    Return CodiTMat

                Case Else
                    Return "NO ESPECIFICADA"
            End Select
        End Get
    End Property

End Class


