Public Class ItemComprobante
    Private m_IdDP As Long
    Private m_Articulo As Articulo
    Private m_CodBarras As String
    Private m_Descripcion As String
    Private m_Cantidad As Decimal = 0
    Private m_PrecioUnitario As Decimal = 0
    Private m_AlicIVA As Decimal = 0
    Private m_DescuentoUnitario As Decimal = 0
    Private m_PorcentajeDescuento As Decimal = 0
    Private m_ImporteSinDescuento As Decimal = 0
    Private m_ImporteDescuento As Decimal = 0
    Private m_ImporteConDescuento As Decimal = 0

    Public Property IdDP() As Long
        Get
            Return m_IdDP
        End Get
        Set(value As Long)
            m_IdDP = value
        End Set
    End Property

    Public Property Articulo() As Articulo
        Get
            Return m_Articulo
        End Get
        Set(value As Articulo)
            m_Articulo = value
        End Set
    End Property

    Public Property CodBarras() As String
        Get
            Return m_CodBarras
        End Get
        Set(value As String)
            m_CodBarras = value
        End Set
    End Property

    Public Property Descripcion() As String
        Get
            Return m_Descripcion
        End Get
        Set(value As String)
            m_Descripcion = value
        End Set
    End Property

    Public Property Cantidad() As Decimal
        Get
            Return m_Cantidad
        End Get
        Set(value As Decimal)
            m_Cantidad = value
            ' Actualizar propiedades dependientes
            m_DescuentoUnitario = Math.Round(m_PrecioUnitario * m_PorcentajeDescuento / 100, 2, MidpointRounding.ToEven)
            m_ImporteSinDescuento = Math.Round(m_Cantidad * m_PrecioUnitario, 2, MidpointRounding.ToEven)
            m_ImporteDescuento = Math.Round(m_Cantidad * m_DescuentoUnitario, 2, MidpointRounding.ToEven)
            m_ImporteConDescuento = m_ImporteSinDescuento - m_ImporteDescuento
        End Set
    End Property

    Public Property PrecioUnitario() As Decimal
        Get
            Return m_PrecioUnitario
        End Get
        Set(value As Decimal)
            m_PrecioUnitario = value
            ' Actualizar propiedades dependientes
            m_DescuentoUnitario = Math.Round(m_PrecioUnitario * m_PorcentajeDescuento / 100, 2, MidpointRounding.ToEven)
            m_ImporteSinDescuento = Math.Round(m_Cantidad * m_PrecioUnitario, 2, MidpointRounding.ToEven)
            m_ImporteDescuento = Math.Round(m_Cantidad * m_DescuentoUnitario, 2, MidpointRounding.ToEven)
            m_ImporteConDescuento = m_ImporteSinDescuento - m_ImporteDescuento
        End Set
    End Property

    Public Property AlicIVA() As Decimal
        Get
            Return m_AlicIVA
        End Get
        Set(value As Decimal)
            m_AlicIVA = value
        End Set
    End Property

    ' DescuentoUnitario ahora se calcula en los Setters y es ReadOnly
    Public ReadOnly Property DescuentoUnitario() As Decimal
        Get
            Return m_DescuentoUnitario
        End Get
    End Property

    Public Property PorcentajeDescuento() As Decimal
        Get
            Return m_PorcentajeDescuento
        End Get
        Set(value As Decimal)
            m_PorcentajeDescuento = value
            ' Actualizar propiedades dependientes
            m_DescuentoUnitario = Math.Round(m_PrecioUnitario * m_PorcentajeDescuento / 100, 2, MidpointRounding.ToEven)
            m_ImporteDescuento = Math.Round(m_Cantidad * m_DescuentoUnitario, 2, MidpointRounding.ToEven)
            m_ImporteConDescuento = m_ImporteSinDescuento - m_ImporteDescuento
        End Set
    End Property

    ' ImporteSinDescuento ahora se calcula en los Setters y es ReadOnly
    Public ReadOnly Property ImporteSinDescuento() As Decimal
        Get
            Return m_ImporteSinDescuento
        End Get
    End Property

    ' ImporteDescuento ahora se calcula en los Setters y es ReadOnly
    Public ReadOnly Property ImporteDescuento() As Decimal
        Get
            Return m_ImporteDescuento
        End Get
    End Property

    ' ImporteConDescuento ahora se calcula en los Setters y es ReadOnly
    Public ReadOnly Property ImporteConDescuento() As Decimal
        Get
            Return m_ImporteConDescuento
        End Get
    End Property


    Public Sub New(
                    ByVal argArticulo As Articulo,
                    ByVal argCodBarras As String,
                    ByVal argDescripcion As String,
                    ByVal argCantidad As Decimal,
                    ByVal argPrecioUnitario As Decimal,
                    ByVal argAlicIVA As Decimal,
                    ByVal argPorcentajeDescuento As Decimal
                    )
        m_Articulo = argArticulo
        m_CodBarras = argCodBarras
        m_Descripcion = argDescripcion
        m_Cantidad = argCantidad
        m_PrecioUnitario = argPrecioUnitario
        m_AlicIVA = argAlicIVA
        m_PorcentajeDescuento = argPorcentajeDescuento
        ' Calcular las propiedades dependientes al inicializar el objeto
        m_DescuentoUnitario = Math.Round(m_PrecioUnitario * m_PorcentajeDescuento / 100, 2, MidpointRounding.ToEven)
        m_ImporteSinDescuento = Math.Round(m_Cantidad * m_PrecioUnitario, 2, MidpointRounding.ToEven)
        m_ImporteDescuento = Math.Round(m_Cantidad * m_DescuentoUnitario, 2, MidpointRounding.ToEven)
        m_ImporteConDescuento = m_ImporteSinDescuento - m_ImporteDescuento

    End Sub

End Class
