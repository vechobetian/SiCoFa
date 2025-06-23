Public Class Comprobante
    Property IdOperacion As Long
    Property Operacion As Operacion
    Property TipoComprobante As TipoComprobante
    Property PVenta As String
    Property NumComp As String
    Property FechaComp As Date
    Property ImpBto As Decimal
    Property ImpDes As Decimal
    Property ImpEx As Decimal
    Property ImpGrav1 As Decimal
    Property ImpNeto1 As Decimal
    Property ImpIVA1 As Decimal
    Property ImpGrav2 As Decimal
    Property ImpNeto2 As Decimal
    Property ImpIVA2 As Decimal
    Property ImpEf As Decimal
    Property ImpCC As Decimal
    Property ImpPE As Decimal
    Property ImpCB As Decimal
    Property CAE As CAE
    Property IdCliente As Long
    Property Cliente As Cliente
    Property IdOperAsoc As Long
    Property CompAsoc As Comprobante
    Property Empresa As Empresa
    Property Detalle As List(Of ItemComprobante)
    Property QR As QRCompE

    Public Sub New(
                  ByVal argIdOperacion As Long,
                  ByVal argOperacion As Operacion,
                  ByVal argTipoComprobante As TipoComprobante,
                  ByVal argPVenta As String,
                  ByVal argNumComp As String,
                  ByVal argFechaComp As Date,
                  ByVal argImpBto As Decimal,
                  ByVal argImpDes As Decimal,
                  ByVal argImpEx As Decimal,
                  ByVal argImpGrav1 As Decimal,
                  ByVal argImpGrav2 As Decimal,
                  ByVal argImpCB As Decimal,
                  ByVal argImpEf As Decimal,
                  ByVal argImpCC As Decimal,
                  ByVal argImpPE As Decimal,
                  ByVal argCAE As CAE,
                  ByVal argIdCliente As Long,
                  ByVal argCliente As Cliente,
                  ByVal argIdOperAsoc As Long,
                  ByVal argCompAsoc As Comprobante,
                  ByVal argEmpresa As Empresa,
                  ByVal argDetalle As List(Of ItemComprobante)
                  )

        Dim ImpNeto1 As Decimal = Math.Round(argImpGrav1 / 1.105, 2, MidpointRounding.ToEven)
        Dim ImpIVA1 As Decimal = Math.Round(ImpNeto1 * 10.5 / 100, 2, MidpointRounding.ToEven)
        Dim ImpNeto2 As Decimal = Math.Round(argImpGrav2 / 1.21, 2, MidpointRounding.ToEven)
        Dim ImpIVA2 As Decimal = Math.Round(ImpNeto2 * 21 / 100, 2, MidpointRounding.ToEven)

        Me.IdOperacion = argIdOperacion
        Me.Operacion = argOperacion
        Me.TipoComprobante = argTipoComprobante
        Me.PVenta = argPVenta
        Me.NumComp = argNumComp
        Me.FechaComp = argFechaComp
        Me.ImpBto = Math.Round(argImpBto, 2)
        Me.ImpDes = Math.Round(argImpDes, 2)
        Me.ImpEx = Math.Round(argImpEx, 2)
        Me.ImpGrav1 = Math.Round(argImpGrav1, 2)
        Me.ImpNeto1 = ImpNeto1
        Me.ImpIVA1 = ImpIVA1
        Me.ImpGrav2 = Math.Round(argImpGrav2, 2)
        Me.ImpNeto2 = ImpNeto2
        Me.ImpIVA2 = ImpIVA2
        Me.ImpCB = Math.Round(argImpCB, 2)
        Me.ImpEf = Math.Round(argImpEf, 2)
        Me.ImpCC = Math.Round(argImpCC, 2)
        Me.ImpPE = Math.Round(argImpPE, 2)
        Me.CAE = argCAE
        Me.IdCliente = argIdCliente
        Me.Cliente = argCliente
        Me.IdOperAsoc = argIdOperAsoc
        Me.CompAsoc = argCompAsoc
        Me.Empresa = argEmpresa
        Me.Detalle = argDetalle

    End Sub

End Class
