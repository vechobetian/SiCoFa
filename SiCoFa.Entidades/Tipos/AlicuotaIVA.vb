Namespace Enums
    Public Class AlicuotaIVA

        Property AlicIVA As Decimal
        Private m_Descripcion As String

        Public ReadOnly Property Descripcion As String
            Get
                Return m_Descripcion
            End Get
        End Property

        Public Shared ReadOnly Property Lista As List(Of AlicuotaIVA)

            Get
                Return New List(Of AlicuotaIVA) From {
                New AlicuotaIVA(0),
                New AlicuotaIVA(10.5),
                New AlicuotaIVA(21)
            }
            End Get
        End Property

        Public Sub New(ByVal argAlicIVA As Decimal)

            Me.AlicIVA = argAlicIVA

            Select Case argAlicIVA
                Case 0 : m_Descripcion = "0.00%"
                Case 10.5 : m_Descripcion = "10.50%"
                Case 21 : m_Descripcion = "21.00%"

            End Select
        End Sub

    End Class

End Namespace