Public Class ItemComprobante
    Private m_IdItem As Long
    Private m_IdArticulo As String
    Private m_Articulo As Articulo ' Asumo que la clase Articulo existe
    Private m_NTroquel As String
    Private m_CodBarras As String
    Private m_Descripcion As String
    Private m_Fraccionado As Boolean
    Private m_Cantidad As Integer
    Private m_PrecioCosto As Decimal
    Private m_PrecioUnitario As Decimal ' Precio con IVA (si esa es la convención)
    Private m_DescuentoUnitario As Decimal
    Private m_AlicIVA As Decimal
    Private m_PorcentajeDescuento As Decimal
    Private m_Receta As Receta
    Private m_PorcentajeOS As Decimal
    Private m_DescuentoOS As Decimal
    Private m_PorcentajeCS As Decimal
    Private m_DescuentoCS As Decimal
    Private m_EsNuevo As Boolean = True

    Public Sub New()

    End Sub

    ' Constructor para items nuevos (hace cálculos)
    Public Sub New(
                    ByVal argArticulo As Articulo,
                    ByVal argFraccionado As Boolean,
                    ByVal argCantidad As Integer,
                    ByVal argPorcentajeDescuento As Decimal,
                    Optional argReceta As Receta = Nothing
                   )

        m_Articulo = argArticulo
        m_Fraccionado = argFraccionado
        m_Cantidad = argCantidad
        m_PorcentajeDescuento = argPorcentajeDescuento
        m_Receta = argReceta
        ' No es necesario llamar a Recalcular aqui, ya que las propiedades
        ' se calcularán en sus Getters cuando se accedan.
    End Sub

    ' Constructor para items cargados desde base de datos

    Public Sub New(
                    ByVal argIdItem As Long,
                    ByVal argIdArticulo As String,
                    ByVal argCodBarras As String,
                    ByVal argDescripcion As String,
                    ByVal argFraccionado As Boolean,
                    ByVal argCantidad As Integer,
                    ByVal argAlicIVA As Decimal,
                    ByVal argPrecioCosto As Decimal,
                    ByVal argPrecioUnitario As Decimal,
                    ByVal argDescuentoUnitario As Decimal,
                    ByVal argPorcentajeDescuento As Decimal,
                    Optional argNTroquel As String = ""
                   )

        m_IdItem = argIdItem
        m_IdArticulo = argIdArticulo
        m_CodBarras = argCodBarras
        m_Descripcion = argDescripcion
        m_Fraccionado = argFraccionado
        m_Cantidad = argCantidad
        m_AlicIVA = argAlicIVA
        m_PrecioCosto = argPrecioCosto
        m_PrecioUnitario = argPrecioUnitario
        m_DescuentoUnitario = argDescuentoUnitario
        m_PorcentajeDescuento = argPorcentajeDescuento
        m_NTroquel = argNTroquel
    End Sub

    Public Property EsNuevo() As Boolean
        Get
            Return m_EsNuevo
        End Get
        Set(value As Boolean)
            m_EsNuevo = value
        End Set
    End Property

    ' Propiedades
    Public Property IdItem() As Long
        Get
            Return m_IdItem
        End Get
        Set(value As Long)
            m_IdItem = value
        End Set
    End Property

    Public ReadOnly Property IdArticulo() As String

        Get
            Return m_IdArticulo
        End Get

    End Property

    Public Property Articulo() As Articulo
        Get
            Return m_Articulo
        End Get

        Set(a As Articulo)
            m_Articulo = a
            m_IdArticulo = a.IdArticulo
            m_CodBarras = a.CodBarras
            m_Descripcion = a.Nombre
            m_PrecioCosto = a.PrecioCosto
            m_PrecioUnitario = a.PrecioVenta
            m_AlicIVA = a.AlicIVA
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

    Public Property NTroquel() As String
        Get
            Return m_NTroquel
        End Get
        Set(value As String)
            m_NTroquel = value
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

    Public Property Fraccionado() As Boolean
        Get
            Return m_Fraccionado
        End Get
        Set(value As Boolean)
            m_Fraccionado = value
        End Set
    End Property

    Public Property Cantidad() As Integer
        Get
            Return m_Cantidad
        End Get
        Set(value As Integer)
            If m_Cantidad <> value Then ' Solo recalcula si el valor cambia
                m_Cantidad = value
                ' Aquí no necesitamos recalcular todas las propiedades
                ' porque son ReadOnly y se calcularán al accederlas.
            End If
        End Set
    End Property

    Public Property PrecioCosto() As Decimal

        Get
            Return m_PrecioCosto
        End Get
        Set(value As Decimal)
            m_PrecioCosto = value
        End Set

    End Property

    Public Property PrecioUnitario() As Decimal

        Get

            If m_Articulo Is Nothing Or m_Articulo.Seccion.EstablecerPrecio Then Return 0

            If m_Fraccionado Then
                m_PrecioUnitario = m_Articulo.PrecioVenta / m_Articulo.UDiv
            Else
                m_PrecioUnitario = m_Articulo.PrecioVenta
            End If

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

    Public Property Receta As Receta
        Get
            Return m_Receta
        End Get
        Set(value As Receta)
            m_Receta = value
        End Set
    End Property

    Public Property PorcentajeOS() As Decimal

        Get
            Return m_PorcentajeOS
        End Get
        Set(POS As Decimal)
            m_PorcentajeOS = POS
        End Set

    End Property

    Public Property DescuentoOS() As Decimal

        Get
            Return m_DescuentoOS
        End Get

        Set(DesOS As Decimal)
            m_DescuentoOS = DesOS
        End Set

    End Property

    Public Property PorcentajeCS() As Decimal

        Get
            Return m_PorcentajeCS
        End Get

        Set(PCS As Decimal)
            m_PorcentajeCS = PCS
        End Set

    End Property

    Public Property DescuentoCS() As Decimal
        Get
            Return m_DescuentoCS
        End Get

        Set(DesCS As Decimal)
            m_DescuentoCS = DesCS
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
            Return Me.ImporteSinDescuento - Me.ImporteDescuento - ImporteOS - ImporteCS
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

    Public ReadOnly Property ImporteOS() As Decimal
        Get
            Return Math.Round(m_Cantidad * m_DescuentoOS, 2, MidpointRounding.ToEven)
        End Get
    End Property

    Public ReadOnly Property ImporteCS() As Decimal
        Get
            Return Math.Round(m_Cantidad * m_DescuentoCS, 2, MidpointRounding.ToEven)
        End Get
    End Property

End Class