Namespace Enums

    Public Class TipoPromocion

        Public Property CodiPro As String
        Private m_Descripcion As String

        Public ReadOnly Property Descripcion As String
            Get
                Return m_Descripcion
            End Get
        End Property

        Public Shared ReadOnly Property Lista As List(Of TipoPromocion)
            Get
                Return New List(Of TipoPromocion) From {
                    New TipoPromocion("0"),
                    New TipoPromocion("2X1"),
                    New TipoPromocion("3X2"),
                    New TipoPromocion("D1U"),
                    New TipoPromocion("D2U")
                    }
            End Get

        End Property

        Public Sub New(ByVal argCodiPro As String)

            Me.CodiPro = argCodiPro.Trim().ToUpper

            Select Case CodiPro.Trim().ToUpper()
                Case "0" : m_Descripcion = "NO ESTABLECIDA"
                Case "2X1" : m_Descripcion = "DOS POR UNO"
                Case "3X2" : m_Descripcion = "TRES POR DOS"
                Case "D1U" : m_Descripcion = "DESCUENTO OFERTA"
                Case "D2U" : m_Descripcion = "DESCUENTO SEGUNDA UNIDAD"
                Case Else : m_Descripcion = "DESCONOCIDA"
            End Select
        End Sub


    End Class

End Namespace

