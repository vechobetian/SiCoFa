Public Class TipoPromocion

    Public Property CodiPro As String

    Private m_Descripcion As String

    Public ReadOnly Property Descripcion As String
        Get
            Return m_Descripcion
        End Get
    End Property

    Public Property CantidadPredeterminada As Integer

    Public Shared ReadOnly Property Lista As List(Of TipoPromocion)
        Get
            Return New List(Of TipoPromocion) From {
                New TipoPromocion("2X1"),
                New TipoPromocion("3X2"),
                New TipoPromocion("D1U"),
                New TipoPromocion("D2U")
            }
        End Get
    End Property

    Public Sub New(ByVal argCodiPro As String)

        Me.CodiPro = argCodiPro.Trim().ToUpper()

        Select Case Me.CodiPro

            Case "2X1"
                m_Descripcion = "DOS POR UNO"
                CantidadPredeterminada = 2

            Case "3X2"
                m_Descripcion = "TRES POR DOS"
                CantidadPredeterminada = 3

            Case "D1U"
                m_Descripcion = "DESCUENTO OFERTA"
                CantidadPredeterminada = 1

            Case "D2U"
                m_Descripcion = "DESCUENTO SEGUNDA UNIDAD"
                CantidadPredeterminada = 2

            Case Else
                m_Descripcion = "DESCONOCIDA"
                CantidadPredeterminada = 1

        End Select

    End Sub

End Class
