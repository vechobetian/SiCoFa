Public Class TipoPromocion

    Public Property CodiPro As String

    Private m_Descripcion As String
    Private m_PorcentajeDescuento As Decimal

    Public ReadOnly Property Descripcion As String
        Get
            Return m_Descripcion
        End Get
    End Property

    Public Property PorcentajeDescuento As Decimal
        Get
            Return m_PorcentajeDescuento
        End Get
        Set(value As Decimal)
            m_PorcentajeDescuento = value
        End Set

    End Property

    Public Property UnidadesCombo As Integer

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

    Public Sub New(argCodiPro As String, Optional argPorcentajeDescuento As Decimal = 0)

        Me.CodiPro = argCodiPro.Trim().ToUpper()

        Select Case Me.CodiPro

            Case "2X1"
                m_PorcentajeDescuento = argPorcentajeDescuento
                m_Descripcion = "DOS POR UNO"
                UnidadesCombo = 2

            Case "3X2"
                m_PorcentajeDescuento = argPorcentajeDescuento
                m_Descripcion = "TRES POR DOS"
                UnidadesCombo = 3

            Case "D1U"
                m_PorcentajeDescuento = argPorcentajeDescuento
                m_Descripcion = m_PorcentajeDescuento & "% DESC.OFERTA"
                UnidadesCombo = 1

            Case "D2U"
                m_PorcentajeDescuento = argPorcentajeDescuento
                m_Descripcion = m_PorcentajeDescuento & "% DESC.2° UNIDAD"
                UnidadesCombo = 2

            Case Else
                m_PorcentajeDescuento = argPorcentajeDescuento
                m_Descripcion = "DESCONOCIDA"
                UnidadesCombo = 1

        End Select

    End Sub

End Class
