Public Class TipoIVA
    Property CodIVA As String

    Private m_Descripcion As String

    Public ReadOnly Property Descripcion As String
        Get
            Return m_Descripcion
        End Get
    End Property

    Public Shared ReadOnly Property Predeterminado As TipoIVA
        Get
            Return New TipoIVA("CF")
        End Get
    End Property

    Public Shared ReadOnly Property Lista As List(Of TipoIVA)
        Get
            Return New List(Of TipoIVA) From {
                New TipoIVA("CF"),
                New TipoIVA("RI"),
                New TipoIVA("MT"),
                New TipoIVA("EX")
                }
        End Get
    End Property

    Public Sub New(ByVal argCodIVA As String)

        Me.CodIVA = argCodIVA.Trim().ToUpper

        Select Case argCodIVA.Trim().ToUpper
            Case "CF" : m_Descripcion = "CONSUMIDOR FINAL"
            Case "RI" : m_Descripcion = "RESPONSABLE INSCRIPTO"
            Case "MT" : m_Descripcion = "RESPONSABLE MONOTRIBUTO"
            Case "EX" : m_Descripcion = "SUJETO EXENTO"
            Case Else : m_Descripcion = "DESCONOCIDO"
        End Select

    End Sub

End Class
