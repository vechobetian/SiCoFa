Public Class ItemVademecum
    Public Property IdVdm As Integer
    Public Property Codigo As Integer
    Public Property Descuento As Decimal

    Public Sub New(ByVal argIdVdm As Integer, ByVal argCodigo As Integer, ByVal argDescuento As Decimal)
        Me.IdVdm = argIdVdm
        Me.Codigo = argCodigo
        Me.Descuento = argDescuento
    End Sub

End Class
