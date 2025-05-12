Public Class CuentaCorriente
    Property IdCC As Int32
    Property Cliente As Cliente
    Property Descripcion As String
    Property Credito As Decimal
    Property FechaAlta As Date
    Property Observaciones As String
    Property Estado As String

    Public Sub New(
                  ByVal argIdCC As Int32,
                  ByVal argCliente As Cliente,
                  ByVal argDescripcion As String,
                  ByVal argCredito As Decimal,
                  ByVal argFechaAlta As Date,
                  ByVal argObservaciones As String,
                  ByVal argEstado As String
                  )

        Me.IdCC = argIdCC
        Me.Cliente = argCliente
        Me.Descripcion = argDescripcion
        Me.Credito = argCredito
        Me.FechaAlta = argFechaAlta
        Me.Observaciones = argObservaciones
        Me.Estado = argEstado

    End Sub

End Class
