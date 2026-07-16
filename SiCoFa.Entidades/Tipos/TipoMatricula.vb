Public Class TipoMatricula
    Public Property CodiTM As String

    Public Sub New()

        CodiTM = "P"

    End Sub

    Public Sub New(argCodiTM As String)

        CodiTM = If(argCodiTM, "").Trim().ToUpper()

    End Sub

    Public ReadOnly Property Descripcion As String
        Get
            Select Case CodiTM
                Case "N" : Return "NACIONAL"
                Case "P" : Return "PROVINCIAL"
                Case Else : Return "DESCONOCIDA"
            End Select
        End Get
    End Property

    Public ReadOnly Property CodiTMADESFA As String
        Get
            Select Case CodiTM
                Case "N", "P"
                    Return CodiTM
                Case Else
                    Return ""
            End Select
        End Get
    End Property

    Public Shared ReadOnly Property Predeterminado As TipoMatricula
        Get
            Return New TipoMatricula("P")
        End Get
    End Property

    Public Shared ReadOnly Property Lista As List(Of TipoMatricula)
        Get
            Return New List(Of TipoMatricula) From {
                New TipoMatricula("N"),
                New TipoMatricula("P")
            }
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return Descripcion
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean

        Dim otro = TryCast(obj, TipoMatricula)

        If otro Is Nothing Then Return False

        Return String.Equals(CodiTM, otro.CodiTM, StringComparison.OrdinalIgnoreCase)

    End Function

    Public Overrides Function GetHashCode() As Integer

        Return If(CodiTM, "").ToUpperInvariant().GetHashCode()

    End Function
End Class
