Public Class ItemComprobanteCompra
    Private m_IdItem As Long
    Private m_Articulo As Articulo
    Private m_Cantidad As Decimal
    Private m_PrecioCosto As Decimal

    ' Constructor
    Public Sub New(
        ByVal argArticulo As Articulo,
        ByVal argCantidad As Decimal,
        ByVal argPrecioCosto As Decimal
    )
        m_Articulo = argArticulo
        m_Cantidad = argCantidad
        m_PrecioCosto = argPrecioCosto

    End Sub

    Public Property IdItem() As Long
        Get
            Return m_IdItem
        End Get
        Set(value As Long)
            m_IdItem = value
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

    Public ReadOnly Property CodBarras() As String

        Get
            Return Articulo.CodBarras
        End Get

    End Property

    Public ReadOnly Property Descripcion() As String
        Get
            Return Articulo.Nombre
        End Get

    End Property

    Public Property Cantidad() As Decimal

        Get
            Return m_Cantidad
        End Get

        Set(value As Decimal)
            If m_Cantidad <> value Then ' Solo recalcula si el valor cambia
                m_Cantidad = value
            End If
        End Set

    End Property

    Public Property PrecioCosto() As Decimal
        Get
            Return Articulo.PrecioCosto
        End Get

        Set(value As Decimal)
            If m_PrecioCosto <> value Then
                m_PrecioCosto = value
            End If
        End Set

    End Property

    Public ReadOnly Property PrecioVenta() As Decimal
        Get
            Return Math.Round(m_PrecioCosto * (1 + Articulo.ListaPrecios.PorcentajeAplicado / 100), 2, MidpointRounding.ToEven)
        End Get
    End Property

    Public ReadOnly Property AlicIVA() As Decimal
        Get
            Return Articulo.AlicuotaIVA.AlicIVA
        End Get
    End Property

    Public ReadOnly Property Importe() As Decimal

        Get
            Return Math.Round(m_Cantidad * m_PrecioCosto, 2, MidpointRounding.ToEven)
        End Get

    End Property

    Public ReadOnly Property ImporteIVA() As Decimal

        Get
            Return Math.Round(Me.Importe * (Me.AlicIVA / 100), 2, MidpointRounding.ToEven)
        End Get

    End Property

    Public ReadOnly Property ImporteTotal() As Decimal

        Get
            Return Me.Importe + Me.ImporteIVA
        End Get

    End Property

    Public ReadOnly Property ListaPrecios() As String

        Get
            Return Me.Articulo.ListaPrecios.ListaPrecios
        End Get

    End Property

    Public ReadOnly Property PorcentajeAplicado() As Decimal

        Get
            Return Me.Articulo.ListaPrecios.PorcentajeAplicado
        End Get

    End Property

End Class
