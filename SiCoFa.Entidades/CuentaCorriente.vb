Public Class CuentaCorriente
    Property IdCC As Int32
    Property Cliente As Cliente
    Property Descripcion As String
    Property LimiteCredito As Decimal
    Property FechaAlta As Date
    Property Observaciones As String
    Property Baja As Boolean

    Public Sub New(
                  ByVal argIdCC As Int32,
                  ByVal argCliente As Cliente,
                  ByVal argDescripcion As String,
                  ByVal argLimiteCredito As Decimal,
                  ByVal argFechaAlta As Date,
                  ByVal argObservaciones As String,
                  ByVal argBaja As Boolean
                  )

        Me.IdCC = argIdCC
        Me.Cliente = argCliente
        Me.Descripcion = argDescripcion
        Me.LimiteCredito = argLimiteCredito
        Me.FechaAlta = argFechaAlta
        Me.Observaciones = argObservaciones
        Me.Baja = argBaja

    End Sub

End Class
