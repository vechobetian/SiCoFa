Public Class ItemComprobante
    Private m_IdItem As Long
    Private m_Articulo As Articulo ' Asumo que la clase Articulo existe
    Private m_CodBarras As String
    Private m_Descripcion As String
    Private m_Cantidad As Decimal
    Private m_PrecioUnitario As Decimal ' Precio con IVA (si esa es la convención)
    Private m_AlicIVA As Decimal
    Private m_PorcentajeDescuento As Decimal

    ' Constructor
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
        ' No es necesario llamar a Recalcular aqui, ya que las propiedades
        ' se calcularán en sus Getters cuando se accedan.
    End Sub

    ' Propiedades
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
            If m_Cantidad <> value Then ' Solo recalcula si el valor cambia
                m_Cantidad = value
                ' Aquí no necesitamos recalcular todas las propiedades
                ' porque son ReadOnly y se calcularán al accederlas.
            End If
        End Set
    End Property

    Public Property PrecioUnitario() As Decimal
        Get
            Return m_PrecioUnitario
        End Get
        Set(value As Decimal)
            If m_PrecioUnitario <> value Then ' Solo recalcula si el valor cambia
                m_PrecioUnitario = value
            End If
        End Set
    End Property

    Public Property AlicIVA() As Decimal
        Get
            Return m_AlicIVA
        End Get
        Set(value As Decimal)
            If m_AlicIVA <> value Then ' Solo recalcula si el valor cambia
                m_AlicIVA = value
            End If
        End Set
    End Property

    Public Property PorcentajeDescuento() As Decimal
        Get
            Return m_PorcentajeDescuento
        End Get
        Set(value As Decimal)
            If m_PorcentajeDescuento <> value Then ' Solo recalcula si el valor cambia
                m_PorcentajeDescuento = value
            End If
        End Set
    End Property

    ' --- Propiedades ReadOnly que se calculan directamente ---

    ' Si PrecioUnitario ya incluye IVA, este es el precio antes de IVA
    Public ReadOnly Property PrecioNeto() As Decimal
        Get
            If m_AlicIVA = 0 Then
                Return m_PrecioUnitario
            Else
                ' Asumiendo que PrecioUnitario es el precio final con IVA
                Return Math.Round(m_PrecioUnitario / (1 + m_AlicIVA / 100), 2, MidpointRounding.ToEven)
            End If
        End Get
    End Property

    Public ReadOnly Property DescuentoUnitario() As Decimal
        Get
            Return Math.Round(m_PrecioUnitario * m_PorcentajeDescuento / 100, 2, MidpointRounding.ToEven)
        End Get
    End Property

    Public ReadOnly Property DescuentoNetoUnitario() As Decimal
        Get
            Return Math.Round(Me.PrecioNeto * m_PorcentajeDescuento / 100, 2, MidpointRounding.ToEven)
        End Get
    End Property

    Public ReadOnly Property ImporteSinDescuento() As Decimal
        Get
            Return Math.Round(m_Cantidad * m_PrecioUnitario, 2, MidpointRounding.ToEven)
        End Get
    End Property

    Public ReadOnly Property ImporteNetoSinDescuento() As Decimal
        Get
            Return Math.Round(m_Cantidad * Me.PrecioNeto, 2, MidpointRounding.ToEven)
        End Get
    End Property

    Public ReadOnly Property ImporteDescuento() As Decimal
        Get
            Return Math.Round(m_Cantidad * Me.DescuentoUnitario, 2, MidpointRounding.ToEven)
        End Get
    End Property

    Public ReadOnly Property ImporteNetoDescuento() As Decimal
        Get
            Return Math.Round(m_Cantidad * Me.DescuentoNetoUnitario, 2, MidpointRounding.ToEven)
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

    ' Propiedad para el cálculo del IVA específico de este ítem
    Public ReadOnly Property ImporteIVA() As Decimal
        Get
            ' IVA se calcula sobre el importe neto con descuento
            Return Math.Round(Me.ImporteNetoConDescuento * (Me.AlicIVA / 100), 2, MidpointRounding.ToEven)
        End Get
    End Property

    ' Propiedad para el total final del ítem (neto + IVA)
    Public ReadOnly Property ImporteTotal() As Decimal
        Get
            Return Me.ImporteNetoConDescuento + Me.ImporteIVA
        End Get
    End Property

End Class