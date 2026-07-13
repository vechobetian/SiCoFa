Public Class Buleano

    Public Property Valor As Boolean
    Public Property Descripcion As String

    Public Sub New(valor As Boolean)

        Me.Valor = valor
        Me.Descripcion = If(valor, "SI", "NO")

    End Sub

    Public Shared Function Lista() As List(Of Buleano)

        Return New List(Of Buleano) From {
            New Buleano(True),
            New Buleano(False)
        }

    End Function

    Public Shared ReadOnly Property Predeterminado As Boolean
        Get
            Return False
        End Get
    End Property

End Class
