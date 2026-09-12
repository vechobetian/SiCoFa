Option Strict On

Public Class AlicuotaIVA

    Property CodIVA As Integer

    Public Sub New(argCodIVA As Integer)

        CodIVA = argCodIVA

    End Sub

    Public ReadOnly Property Descripcion As String
        Get
            Select Case CodIVA
                Case 0 : Return "IVA 0%"
                Case 1 : Return "IVA 21%"
                Case 2 : Return "IVA 10,5%"
                Case Else : Return "DESCONOCIDO"
            End Select
        End Get
    End Property

    Public ReadOnly Property AlicIva As Decimal
        Get
            Select Case CodIVA
                Case 0 : Return 0D
                Case 1 : Return 21D
                Case 2 : Return 10.5D
                Case Else : Return 21D
            End Select
        End Get
    End Property

    Public Shared ReadOnly Property Lista As List(Of AlicuotaIVA)
        Get
            Return New List(Of AlicuotaIVA) From {
                New AlicuotaIVA(0),
                New AlicuotaIVA(1),
                New AlicuotaIVA(2)
                }
        End Get

    End Property


End Class
