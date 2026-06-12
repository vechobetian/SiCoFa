Public Class TipoPrescriptor
    Public Property CodiTPres As String

    Public Sub New(argCodiTPres As String)
        Me.CodiTPres = argCodiTPres.ToUpper.Trim
    End Sub

    Public ReadOnly Property Descripcion As String
        Get
            Select Case CodiTPres
                Case "M"
                    Return "MEDICO"

                Case "O"
                    Return "ODONTOLOGO"

                Case "P"
                    Return "PSIQUIATRA"

                Case Else
                    Return "NO RECONOCIDO"

            End Select
        End Get
    End Property

    Public ReadOnly Property CodiTPresOsde As String
        Get
            Select Case CodiTPres
                Case "M"
                    Return "1"

                Case "O"
                    Return "86"

                Case "P"
                    Return "90"

                Case Else
                    Return "99"

            End Select
        End Get
    End Property

    Public ReadOnly Property CodiTPresADESFA As String
        Get
            Select Case CodiTPres
                Case "M", "O", "P"
                    Return CodiTPres

                Case Else
                    Return ""
            End Select
        End Get
    End Property
End Class
