Namespace Enums
    Public Class AlicuotaIVA

        Property AlicIVA As Decimal
        Property Descripcion As String

        Public Sub New(ByVal argAlicIVA As Decimal)

            Me.AlicIVA = argAlicIVA

            Select Case argAlicIVA
                Case 0 : Descripcion = "0.00%"
                Case 10.5 : Descripcion = "10.50%"
                Case 21 : Descripcion = "21.00%"

            End Select
        End Sub

        Public Shared ReadOnly Property Lista As List(Of AlicuotaIVA)

            Get
                Return New List(Of AlicuotaIVA) From {
                New AlicuotaIVA("0.00"),
                New AlicuotaIVA("10.50"),
                New AlicuotaIVA("21.00")
            }
            End Get
        End Property

    End Class

End Namespace