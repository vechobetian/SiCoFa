Public Class Comprobante
    Property IdOperacion As Long
    Property Operacion As Operacion
    Property TipoComprobante As TipoComprobante
    Property PVenta As String
    Property NumComp As String
    Property FechaComp As Date
    Property ImpBto As Decimal
    Property ImpEx As Decimal
    Property ImpGrav1 As Decimal
    Property ImpNeto1 As Decimal
    Property ImpIVA1 As Decimal
    Property ImpGrav2 As Decimal
    Property ImpNeto2 As Decimal
    Property ImpIVA2 As Decimal
    Property ImpEf As Decimal
    Property ImpCC As Decimal
    Property ImpTar As Decimal
    Property ImpCB As Decimal
    Property CAE As CAE
    Property IdCliente As Long
    Property Cliente As Cliente
    Property IdOperAsoc As Long
    Property CompAsoc As Comprobante
    Property Locador As Locador
    Property Detalle As List(Of ItemComprobante)
    Property QR As QRCompE

    Public Sub New(
                  ByVal argIdOperacion As Long,
                  ByVal argOpera As Operacion,
                  ByVal argCodiTC_SiCoFa As String,
                  ByVal argPVenta As String,
                  ByVal argNumComp As String,
                  ByVal argFechaComp As Date,
                  ByVal argImpBto As Decimal,
                  ByVal argImpEx As Decimal,
                  ByVal argImpGrav1 As Decimal,
                  ByVal argImpNeto1 As Decimal,
                  ByVal argImpIVA1 As Decimal,
                  ByVal argImpGrav2 As Decimal,
                  ByVal argImpNeto2 As Decimal,
                  ByVal argImpIVA2 As Decimal,
                  ByVal argImpCB As Decimal,
                  ByVal argImpEf As Decimal,
                  ByVal argImpCC As Decimal,
                  ByVal argImpTar As Decimal,
                  ByVal argCAE As CAE,
                  ByVal argIdCliente As Long,
                  ByVal argCliente As Cliente,
                  ByVal argIdOperAsoc As Long,
                  ByVal argCompAsoc As Comprobante,
                  ByVal argLocador As Locador,
                  ByVal argDetalle As List(Of ItemComprobante)
                  )
        Me.IdOperacion = argIdOperacion
        Me.Operacion = argOpera
        Me.TipoComprobante = New TipoComprobante(argCodiTC_SiCoFa)
        Me.PVenta = argPVenta
        Me.NumComp = argNumComp
        Me.FechaComp = argFechaComp
        Me.ImpBto = Math.Round(argImpBto, 2)
        Me.ImpEx = Math.Round(argImpEx, 2)
        Me.ImpGrav1 = Math.Round(argImpGrav1, 2)
        Me.ImpNeto1 = Math.Round(argImpNeto1, 2)
        Me.ImpIVA1 = Math.Round(argImpIVA1, 2)
        Me.ImpGrav2 = Math.Round(argImpGrav2, 2)
        Me.ImpNeto2 = Math.Round(argImpNeto2, 2)
        Me.ImpIVA2 = Math.Round(argImpIVA2, 2)
        Me.ImpCB = Math.Round(argImpCB, 2)
        Me.ImpEf = Math.Round(argImpEf, 2)
        Me.ImpCC = Math.Round(argImpCC, 2)
        Me.ImpTar = Math.Round(argImpTar, 2)
        Me.CAE = argCAE
        Me.IdCliente = argIdCliente
        Me.Cliente = argCliente
        Me.IdOperAsoc = argIdOperAsoc
        Me.CompAsoc = argCompAsoc
        Me.Locador = argLocador
        Me.Detalle = argDetalle

    End Sub

End Class
