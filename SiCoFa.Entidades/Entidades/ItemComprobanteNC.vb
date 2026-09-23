Public Class ItemComprobanteNC
    Private ReadOnly m_IdItem As Long
    Private ReadOnly m_IdArticulo As String
    Private ReadOnly m_Descripcion As String
    Private ReadOnly m_Fraccionado As Boolean
    Private ReadOnly m_CantidadF As Integer
    Private ReadOnly m_CantidadA As Integer
    Private m_CantidadNC As Integer
    Private ReadOnly m_PrecioCosto As Decimal
    Private ReadOnly m_PrecioUnitario As Decimal
    Private ReadOnly m_AlicIVA As Decimal
    Private ReadOnly m_PorcentajeDescuento As Decimal
    Private ReadOnly m_DescuentoUnitario As Decimal
    Private ReadOnly m_CodiPro As String
    Private ReadOnly m_DescuentoUnitarioOS As Decimal
    Private ReadOnly m_DescuentoUnitarioCS As Decimal
    Private ReadOnly m_PlanOS As String

    Public Sub New(
        ByVal argIdItem As Long,
        ByVal argIdArticulo As String,
        ByVal argDescripcion As String,
        ByVal argFraccionado As Boolean,
        ByVal argCantidadF As Integer,
        ByVal argCantidadA As Integer,
        ByVal argPrecioCosto As Decimal,
        ByVal argPrecioUnitario As Decimal,
        ByVal argAlicIVA As Decimal,
        ByVal argPorcentajeDescuento As Decimal,
        ByVal argDescuentoUnitario As Decimal,
        ByVal argCodiPro As String,
        ByVal argDescuentoUnitarioOS As Decimal,
        ByVal argDescuentoUnitarioCS As Decimal,
        ByVal argPlanOS As String
    )
        m_IdItem = argIdItem
        m_IdArticulo = argIdArticulo
        m_Descripcion = argDescripcion
        m_Fraccionado = argFraccionado
        m_CantidadF = argCantidadF
        m_CantidadA = argCantidadA
        m_PrecioCosto = argPrecioCosto
        m_PrecioUnitario = argPrecioUnitario
        m_AlicIVA = argAlicIVA
        m_PorcentajeDescuento = argPorcentajeDescuento
        m_DescuentoUnitario = argDescuentoUnitario
        m_CodiPro = argCodiPro
        m_DescuentoUnitarioOS = argDescuentoUnitarioOS
        m_DescuentoUnitarioCS = argDescuentoUnitarioCS
        m_PlanOS = argPlanOS
    End Sub

    Public ReadOnly Property IdItem() As Long
        Get
            Return m_IdItem
        End Get
    End Property

    Public ReadOnly Property IdArticulo() As String
        Get
            Return m_IdArticulo
        End Get
    End Property

    Public ReadOnly Property Descripcion() As String
        Get
            Return m_Descripcion
        End Get
    End Property

    Public ReadOnly Property Fraccionado() As Boolean
        Get
            Return m_Fraccionado
        End Get
    End Property

    Public ReadOnly Property CantidadF() As Integer
        Get
            Return m_CantidadF
        End Get
    End Property

    Public ReadOnly Property CantidadA() As Integer
        Get
            Return m_CantidadA
        End Get
    End Property

    Public Property CantidadNC() As Integer
        Get
            Return m_CantidadNC
        End Get
        Set(value As Integer)
            m_CantidadNC = value
        End Set
    End Property

    Public ReadOnly Property PrecioCosto() As Decimal
        Get
            Return m_PrecioCosto
        End Get
    End Property

    Public ReadOnly Property PrecioUnitario() As Decimal
        Get
            Return m_PrecioUnitario
        End Get
    End Property

    Public ReadOnly Property AlicIVA() As Decimal
        Get
            Return m_AlicIVA
        End Get
    End Property

    Public ReadOnly Property PorcentajeDescuento() As Decimal
        Get
            Return m_PorcentajeDescuento
        End Get
    End Property

    Public ReadOnly Property PrecioNeto() As Decimal
        Get
            If m_AlicIVA = 0 Then
                Return m_PrecioUnitario
            Else
                Return Math.Round(m_PrecioUnitario / (1 + m_AlicIVA / 100), 2, MidpointRounding.ToEven)
            End If
        End Get
    End Property

    Public ReadOnly Property DescuentoUnitario() As Decimal
        Get
            Return m_DescuentoUnitario
        End Get
    End Property

    Public ReadOnly Property DescuentoNetoUnitario() As Decimal
        Get
            Return Math.Round(Me.PrecioNeto * Me.PorcentajeDescuento / 100, 2, MidpointRounding.ToEven)
        End Get
    End Property

    Public ReadOnly Property ImporteSinDescuento() As Decimal
        Get
            Return Math.Round(m_CantidadNC * m_PrecioUnitario, 2, MidpointRounding.ToEven)
        End Get
    End Property

    Public ReadOnly Property ImporteNetoSinDescuento() As Decimal
        Get
            Return Math.Round(m_CantidadNC * Me.PrecioNeto, 2, MidpointRounding.ToEven)
        End Get
    End Property

    Public ReadOnly Property ImporteDescuento() As Decimal
        Get
            Return Math.Round(m_CantidadNC * Me.DescuentoUnitario, 2, MidpointRounding.ToEven)
        End Get
    End Property

    Public ReadOnly Property ImporteNetoDescuento() As Decimal
        Get
            Return Math.Round(m_CantidadNC * Me.DescuentoNetoUnitario, 2, MidpointRounding.ToEven)
        End Get
    End Property

    Public ReadOnly Property ImporteConDescuento() As Decimal
        Get
            Return Me.ImporteSinDescuento - Me.ImporteDescuento
        End Get
    End Property

    Public ReadOnly Property ImporteNetoConDescuento() As Decimal
        Get
            Return Me.ImporteNetoSinDescuento - Me.ImporteNetoDescuento
        End Get
    End Property

    Public ReadOnly Property ImporteIVA() As Decimal
        Get
            Return Math.Round(Me.ImporteNetoConDescuento * (Me.AlicIVA / 100), 2, MidpointRounding.ToEven)
        End Get
    End Property

    Public ReadOnly Property ImporteTotal() As Decimal
        Get
            Return Me.ImporteNetoConDescuento + Me.ImporteIVA
        End Get
    End Property

    Public ReadOnly Property CodiPro() As String
        Get
            Return m_CodiPro
        End Get
    End Property

    Public ReadOnly Property ImporteOS As Decimal
        Get
            Return Math.Round(m_CantidadNC * m_DescuentoUnitarioOS, 2, MidpointRounding.ToEven)
        End Get
    End Property

    Public ReadOnly Property ImporteCS As Decimal
        Get
            Return Math.Round(m_CantidadNC * m_DescuentoUnitarioCS, 2, MidpointRounding.ToEven)
        End Get
    End Property

    Public ReadOnly Property PlanOS As String
        Get
            Return m_PlanOS
        End Get
    End Property

End Class
