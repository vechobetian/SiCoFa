Public Class TipoTratamiento
    Public Property CodiTT As String
    Private m_Descripcion As String

    Public ReadOnly Property Descripcion As String
        Get
            Return m_Descripcion
        End Get
    End Property

    Public Shared ReadOnly Property Predeterminado As TipoTratamiento
        Get
            Return New TipoTratamiento("N")
        End Get
    End Property

    Public Shared ReadOnly Property Lista As List(Of TipoTratamiento)
        Get
            Return New List(Of TipoTratamiento) From {
                New TipoTratamiento("N"),
                New TipoTratamiento("P")
            }
        End Get
    End Property

    Public Sub New(argCodiTT As String)

        Me.CodiTT = argCodiTT.Trim().ToUpper

        Select Case argCodiTT.Trim().ToUpper()
            Case "N" : m_Descripcion = "NORMAL"
            Case "P" : m_Descripcion = "PROLONGADO"
            Case Else : m_Descripcion = "DESCONOCIDO"
        End Select

    End Sub
End Class
