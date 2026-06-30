Public Class ItemReceta
    Public Property ItemComprobante As ItemComprobante
    Public Property IdReceta As Long
    Public Property POS As Decimal
    Public Property ACargoOS As Decimal
    Public Property NumAutorItem As String

    Public Sub New(
                  ByVal argItemComprobante As ItemComprobante,
                  ByVal argIdReceta As Long,
                  ByVal argPOS As Decimal,
                  ByVal argACargoOS As Decimal,
                  ByVal argNumAutorItem As String
                  )

        Me.ItemComprobante = argItemComprobante
        Me.IdReceta = argIdReceta
        Me.POS = argPOS
        Me.ACargoOS = argACargoOS

    End Sub

End Class
