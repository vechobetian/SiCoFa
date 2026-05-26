Public Class Comprobante
    Property IdOperacion As Long
    Property Operacion As Operacion
    Property TipoComprobante As TipoComprobante
    Property PVenta As String
    Property NumComp As String
    Property FechaComp As Date
    Property ImpBto As Decimal
    Property ImpDes As Decimal
    Property ImpNeto As Decimal
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

    ' Constructor para comprobantes nuevos (hace cálculos)
    Public Sub New(
        ByVal argIdOperacion As Long,
        ByVal argOperacion As Operacion,
        ByVal argTipoComprobante As TipoComprobante,
        ByVal argPVenta As String,
        ByVal argNumComp As String,
        ByVal argFechaComp As Date,
        ByVal argImpBto As Decimal,
        ByVal argImpDes As Decimal,
        ByVal argImpNeto As Decimal,
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

        Dim neto1 As Decimal = Math.Round(argImpGrav1 / 1.105D, 2, MidpointRounding.ToEven)
        Dim iva1 As Decimal = Math.Round(neto1 * 10.5D / 100D, 2, MidpointRounding.ToEven)
        Dim neto2 As Decimal = Math.Round(argImpGrav2 / 1.21D, 2, MidpointRounding.ToEven)
        Dim iva2 As Decimal = Math.Round(neto2 * 21D / 100D, 2, MidpointRounding.ToEven)

        Inicializar(argIdOperacion, argOperacion, argTipoComprobante, argPVenta, argNumComp, argFechaComp,
                    argImpBto, argImpDes, argImpNeto, argImpEx, argImpGrav1, neto1, iva1,
                    argImpGrav2, neto2, iva2, argImpCB, argImpEf, argImpCC, argImpPE,
                    argCAE, argIdCliente, argCliente, argIdOperAsoc, argCompAsoc, argEmpresa, argDetalle)
    End Sub

    ' Constructor para comprobantes cargados desde base de datos
    Public Sub New(
        ByVal argIdOperacion As Long,
        ByVal argOperacion As Operacion,
        ByVal argTipoComprobante As TipoComprobante,
        ByVal argPVenta As String,
        ByVal argNumComp As String,
        ByVal argFechaComp As Date,
        ByVal argImpBto As Decimal,
        ByVal argImpDes As Decimal,
        ByVal argImpNeto As Decimal,
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
        ByVal argImpPE As Decimal,
        ByVal argCAE As CAE,
        ByVal argIdCliente As Long,
        ByVal argCliente As Cliente,
        ByVal argIdOperAsoc As Long,
        ByVal argCompAsoc As Comprobante,
        ByVal argEmpresa As Empresa,
        ByVal argDetalle As List(Of ItemComprobante)
    )

        Inicializar(argIdOperacion, argOperacion, argTipoComprobante, argPVenta, argNumComp, argFechaComp,
                    argImpBto, argImpDes, argImpNeto, argImpEx, argImpGrav1, argImpNeto1, argImpIVA1,
                    argImpGrav2, argImpNeto2, argImpIVA2, argImpCB, argImpEf, argImpCC, argImpPE,
                    argCAE, argIdCliente, argCliente, argIdOperAsoc, argCompAsoc, argEmpresa, argDetalle)
    End Sub

    ' Método privado común para evitar duplicar código
    Private Sub Inicializar(
        ByVal idOperacion As Long,
        ByVal operacion As Operacion,
        ByVal tipoComprobante As TipoComprobante,
        ByVal pVenta As String,
        ByVal numComp As String,
        ByVal fechaComp As Date,
        ByVal impBto As Decimal,
        ByVal impDes As Decimal,
        ByVal impNeto As Decimal,
        ByVal impEx As Decimal,
        ByVal impGrav1 As Decimal,
        ByVal impNeto1 As Decimal,
        ByVal impIVA1 As Decimal,
        ByVal impGrav2 As Decimal,
        ByVal impNeto2 As Decimal,
        ByVal impIVA2 As Decimal,
        ByVal impCB As Decimal,
        ByVal impEf As Decimal,
        ByVal impCC As Decimal,
        ByVal impPE As Decimal,
        ByVal cae As CAE,
        ByVal idCliente As Long,
        ByVal cliente As Cliente,
        ByVal idOperAsoc As Long,
        ByVal compAsoc As Comprobante,
        ByVal empresa As Empresa,
        ByVal detalle As List(Of ItemComprobante)
    )

        Me.IdOperacion = idOperacion
        Me.Operacion = operacion
        Me.TipoComprobante = tipoComprobante
        Me.PVenta = pVenta
        Me.NumComp = numComp
        Me.FechaComp = fechaComp
        Me.ImpBto = Math.Round(impBto, 2)
        Me.ImpDes = Math.Round(impDes, 2)
        Me.ImpNeto = Math.Round(impNeto, 2)
        Me.ImpEx = Math.Round(impEx, 2)
        Me.ImpGrav1 = Math.Round(impGrav1, 2)
        Me.ImpNeto1 = Math.Round(impNeto1, 2)
        Me.ImpIVA1 = Math.Round(impIVA1, 2)
        Me.ImpGrav2 = Math.Round(impGrav2, 2)
        Me.ImpNeto2 = Math.Round(impNeto2, 2)
        Me.ImpIVA2 = Math.Round(impIVA2, 2)
        Me.ImpCB = Math.Round(impCB, 2)
        Me.ImpEf = Math.Round(impEf, 2)
        Me.ImpCC = Math.Round(impCC, 2)
        Me.ImpPE = Math.Round(impPE, 2)
        Me.CAE = cae
        Me.IdCliente = idCliente
        Me.Cliente = cliente
        Me.IdOperAsoc = idOperAsoc
        Me.CompAsoc = compAsoc
        Me.Empresa = empresa
        Me.Detalle = detalle

    End Sub
End Class

