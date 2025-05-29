Public Class CuentaCorriente
    Property IdCC As Int32
    Property IdCliente As Int32
    Property Descripcion As String
    Property Credito As Decimal
    Property FechaAlta As Date
    Property Observaciones As String
    Property Estado As String
    Property Saldo As Decimal
    Property CreditoDisponible As Decimal



    Public Sub New(
                  ByVal argIdCC As Int32,
                  ByVal argIdCliente As Int32,
                  ByVal argDescripcion As String,
                  ByVal argCredito As Decimal,
                  ByVal argFechaAlta As Date,
                  ByVal argObservaciones As String,
                  ByVal argEstado As String,
                  ByVal argSaldo As Decimal
                  )

        Me.IdCC = argIdCC
        Me.IdCliente = argIdCliente
        Me.Descripcion = argDescripcion
        Me.Credito = argCredito
        Me.FechaAlta = argFechaAlta
        Me.Observaciones = argObservaciones
        Me.Estado = argEstado
        Me.Saldo = argSaldo
        Me.CreditoDisponible = Me.Credito - Me.Saldo

    End Sub

End Class
