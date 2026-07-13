Public Class TipoPrescriptor
    Public Property CodiTPres As String

    Private m_Descripcion As String

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

    Public ReadOnly Property Descripcion As String
        Get
            Return m_Descripcion
        End Get
    End Property

    Public Shared ReadOnly Property Lista As List(Of TipoPrescriptor)
        Get
            Return New List(Of TipoPrescriptor) From {
                New TipoPrescriptor("M"),
                New TipoPrescriptor("O"),
                New TipoPrescriptor("P")
                }
        End Get
    End Property

    Public Sub New(argCodiTPres As String)

        Me.CodiTPres = argCodiTPres.Trim().ToUpper

        Select Case argCodiTPres.Trim().ToUpper
            Case "M" : m_Descripcion = "MEDICO"
            Case "O" : m_Descripcion = "ODONTOLOGO"
            Case "P" : m_Descripcion = "PSIQUIATRA"
            Case Else : m_Descripcion = "DESCONOCIDO"
        End Select

    End Sub

End Class
