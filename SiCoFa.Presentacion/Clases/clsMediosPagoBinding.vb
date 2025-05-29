Public Class clsMediosPagoBinding
    Public Sub New(ByVal argImpCliente As Decimal)
        Me.ImporteAPagar = argImpCliente
    End Sub
    Public Property ImporteCuentaCorriente As Decimal
    Public Property ImportePagoElectronico As Decimal

    Public ReadOnly Property ImportePagoEfectivo As Decimal
        Get
            Return ImporteAPagar - ImporteCuentaCorriente - ImportePagoElectronico
        End Get
    End Property

    Private ReadOnly ImporteAPagar As Decimal

End Class
