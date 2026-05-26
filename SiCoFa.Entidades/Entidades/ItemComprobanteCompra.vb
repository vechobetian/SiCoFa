Imports SiCoFa.Entidades.Enums

Public Class ItemComprobanteCompra

    Private m_IdItem As Long
    Private m_Articulo As Articulo
    Private m_Cantidad As Integer
    Private m_PrecioCosto As Decimal
    Private m_PrecioVenta As Decimal
    Private m_PorcentajeAplicado As Decimal
    Private m_IVAIncluido As Boolean

    <Newtonsoft.Json.JsonIgnore>
    Public Property EvitarRecalculo As Boolean = False

    ' Constructor
    Public Sub New(
        ByVal argArticulo As Articulo,
        ByVal argCantidad As Integer,
        ByVal argPrecioCosto As Decimal,
        ByVal argPrecioVenta As Decimal,
        ByVal argPorcentajeAplicado As Decimal,
        ByVal argIVAIncluidoEnPrecioCosto As Boolean
    )
        m_Articulo = argArticulo
        m_Cantidad = argCantidad
        m_PrecioCosto = argPrecioCosto
        m_PrecioVenta = argPrecioVenta
        m_PorcentajeAplicado = argPorcentajeAplicado
        m_IVAIncluido = argIVAIncluidoEnPrecioCosto
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

    Public Property Cantidad() As Integer
        Get
            Return m_Cantidad
        End Get
        Set(value As Integer)
            m_Cantidad = value
        End Set
    End Property

    Public Property PrecioCosto() As Decimal
        Get
            Return m_PrecioCosto
        End Get
        Set(value As Decimal)
            If m_PrecioCosto <> value Then
                m_PrecioCosto = value
                If Not EvitarRecalculo Then
                    RecalcularPrecioVenta()
                End If
            End If
        End Set
    End Property

    Public Property PrecioVenta() As Decimal
        Get
            Return m_PrecioVenta
        End Get
        Set(value As Decimal)
            If m_PrecioVenta <> value Then
                m_PrecioVenta = value
                m_PorcentajeAplicado = Math.Round((m_PrecioVenta - m_PrecioCosto) / m_PrecioCosto * 100, 2, MidpointRounding.ToEven)
            End If
        End Set
    End Property

    Public ReadOnly Property AlicIVA() As Decimal
        Get
            Return Articulo.AlicIVA
        End Get
    End Property

    <Newtonsoft.Json.JsonIgnore>
    Public ReadOnly Property Importe() As Decimal
        Get
            Return m_Cantidad * m_PrecioCosto
        End Get
    End Property

    <Newtonsoft.Json.JsonIgnore>
    Public ReadOnly Property ImporteNeto() As Decimal
        Get
            If m_IVAIncluido Then
                Return Me.Importe / (1 + Me.Articulo.AlicIVA / 100)
            Else
                Return Me.Importe
            End If
        End Get
    End Property

    <Newtonsoft.Json.JsonIgnore>
    Public ReadOnly Property ImporteIVA() As Decimal
        Get
            Return Me.ImporteNeto * (Me.Articulo.AlicIVA / 100)
        End Get
    End Property

    <Newtonsoft.Json.JsonIgnore>
    Public ReadOnly Property ImporteTotal() As Decimal
        Get
            Return Me.ImporteNeto + Me.ImporteIVA
        End Get
    End Property

    Public ReadOnly Property ListaPrecios() As String
        Get
            Return Me.Articulo.ListaPrecios.ListaPrecios
        End Get
    End Property

    <Newtonsoft.Json.JsonIgnore>
    Public Property PorcentajeAplicado() As Decimal
        Get
            Return m_PorcentajeAplicado
        End Get
        Set(value As Decimal)
            If m_PorcentajeAplicado <> value Then
                m_PorcentajeAplicado = value
            End If
        End Set
    End Property

    Public Property IVAIncluido() As Boolean
        Get
            Return m_IVAIncluido
        End Get
        Set(value As Boolean)
            m_IVAIncluido = value
            ' Ya NO recalcula automáticamente
        End Set
    End Property

    Public Sub RecalcularPrecioVenta()
        If m_IVAIncluido Then
            m_PrecioVenta = Math.Round(m_PrecioCosto * (1 + Me.Articulo.ListaPrecios.PorcentajeAplicado / 100), 2, MidpointRounding.ToEven)
        Else
            m_PrecioVenta = Math.Round(m_PrecioCosto * (1 + Me.Articulo.AlicIVA / 100) * (1 + Me.Articulo.ListaPrecios.PorcentajeAplicado / 100), 2, MidpointRounding.ToEven)
        End If
    End Sub

End Class



