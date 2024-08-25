Public Class Contrato
    Property IdContrato As Integer
    Property IdGC As Integer
    Property GrupoContratos As GrupoContratos
    Property IdLocador As Integer
    Property Locador As Locador
    Property IdCliente As Integer
    Property Cliente As Cliente
    Property UsFTP As String = ""
    Property MesesT As Integer = 0
    Property Contacto As String = ""
    Property Deposito As Decimal = 0
    Property InicioContrato As Date
    Property FinalContrato As Date
    Property UltimoDev As String = "0000"
    Property FacturaServicios As Boolean
    Property EstadoContrato As String
    Property ServiciosAsociados As List(Of ServicioAsociado)
    Property OperaContratos As List(Of OperaContrato)
    Property PagosCliente As List(Of PagoCliente)
    Public Sub New(
                  ByVal argIdContrato As Integer,
                  ByVal argIdGC As Integer,
                  ByVal argIdLocador As Integer,
                  ByVal argIdCliente As Integer,
                  ByVal argUsFTP As String,
                  ByVal argMesesT As Integer,
                  ByVal argContacto As String,
                  ByVal argDeposito As Decimal,
                  ByVal argInicioContrato As Date,
                  ByVal argFinalContrato As Date,
                  ByVal argUltimoDev As String,
                  ByVal argFacturaServicios As Boolean,
                  ByVal argEstadoContrato As String
                   )

        Me.IdContrato = argIdContrato
        Me.IdGC = argIdGC
        Me.IdLocador = argIdLocador
        Me.IdCliente = argIdCliente
        Me.UsFTP = argUsFTP
        Me.MesesT = argMesesT
        Me.Contacto = argContacto
        Me.Deposito = argDeposito
        Me.InicioContrato = argInicioContrato
        Me.FinalContrato = argFinalContrato
        Me.UltimoDev = argUltimoDev
        Me.FacturaServicios = argFacturaServicios
        Me.EstadoContrato = argEstadoContrato

    End Sub
    Public Function SaldoPagoCliente(ByVal argIdOperacion As Long) As Decimal
        Dim Saldo As Decimal
        For Each a As PagoCliente In Me.PagosCliente
            If a.IdOperacion = argIdOperacion Then
                Saldo = a.ImpPagado - a.ImpAplicado
                Return Saldo
                Exit Function
            End If
        Next
        Return -1

    End Function
    Public Function SaldoOperacion(ByVal argIdOperacion As Long) As Decimal
        Dim Saldo As Decimal
        For Each o As OperaContrato In Me.OperaContratos
            If o.IdOperacion = argIdOperacion Then
                Saldo = o.ImpFacturado - o.ImpCancelado
                Return Saldo
                Exit Function
            End If
        Next
        Return -1

    End Function
    Public Function ActualizarSaldoOperacion(ByVal argIdOperacion As Long, ByVal argImpAplicado As Decimal) As Decimal
        'OJO!!!!!!!!!!! Solo Actualizo el Importe Cancelado pero no toco el Importe No Cancelado
        Dim Saldo As Decimal
        For Each o As OperaContrato In Me.OperaContratos
            If o.IdOperacion = argIdOperacion Then
                o.ImpCancelado = 0
                o.ImpCancelado = (o.ImpFacturado - o.ImpNoCancelado) + argImpAplicado
                Saldo = o.ImpFacturado - o.ImpCancelado 'OJO el saldo no es igual al ImpNoCancelado porque este dato viene de la base de datos y no contempla el argImpAplicado
                Return Saldo
                Exit Function
            End If
        Next
        Return -1
    End Function
    Public Function ActualizarSaldoPagoCliente(ByVal argIdOperacion As Long, ByVal argImpAplicado As Decimal) As Decimal
        'OJO!!!!!!!!!!! Solo Actualizo el Importe Aplicado pero no toco el Importe No aplicado
        Dim Saldo As Decimal
        For Each p As PagoCliente In Me.PagosCliente
            If p.IdOperacion = argIdOperacion Then
                p.ImpAplicado = 0
                p.ImpAplicado = (p.ImpPagado - p.ImpNoAplicado) + argImpAplicado
                Saldo = p.ImpPagado - p.ImpAplicado 'OJO el saldo no es igual al ImpNoAplicado porque este dato viene de la base de datos y no contempla el argImpAplicado
                Return Saldo
                Exit Function
            End If
        Next
        Return -1
    End Function
    Public Function ObtenerOperacion(ByVal argIdOperacion As Long) As OperaContrato
        For Each o As OperaContrato In Me.OperaContratos
            If o.IdOperacion = argIdOperacion Then
                Return o
                Exit Function
            End If
        Next
        Return Nothing
    End Function
    Public Function SiguienteOperacionConSaldo() As OperaContrato
        'OJO!!!!!!!!!!!! El saldo no es el ImpNoCancelado porque este importe es el importe de la base de datos
        'y no incluye los importes aplicados en la operacion en curso

        For Each o As OperaContrato In Me.OperaContratos
            If o.ImpFacturado - o.ImpCancelado > 0 Then
                Return o
                Exit Function
            End If
        Next
        Return Nothing
    End Function
    Public Function SiguientePagoConSaldo() As PagoCliente
        'OJO!!!!!!!!!!!! El saldo no es el ImpNoAplicado porque este importe es el importe de la base de datos
        'y no incluye los importes aplicados en la operacion en curso

        For Each a As PagoCliente In Me.PagosCliente
            If a.ImpPagado - a.ImpAplicado > 0 Then
                Return a
                Exit Function
            End If
        Next
        Return Nothing
    End Function
    Public Function TotalAdeudado() As Decimal
        Dim Importe As Decimal

        For Each o As OperaContrato In Me.OperaContratos
            Importe += o.ImpNoCancelado
        Next

        Return Importe

    End Function
    Public Function SaldoAnticipos() As Decimal
        Dim Importe As Decimal
        If Me.PagosCliente Is Nothing Then
            Return 0
            Exit Function
        End If

        For Each p As PagoCliente In Me.PagosCliente
            Importe += p.ImpNoAplicado
        Next

        Return Importe

    End Function

End Class
