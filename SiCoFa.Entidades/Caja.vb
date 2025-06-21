Public Class Caja
    Property IdCaja As Long
    Property Apertura As Date
    Property Cierre As Date
    Property Estado As String
    Property NCaja As String

    Public Sub New(ByVal argIdCaja As Long, ByVal argApertura As Date, ByVal argCierre As Date, ByVal argEstado As String, ByVal argNCaja As String)
        Me.IdCaja = argIdCaja
        Me.Apertura = argApertura
        Me.Cierre = argCierre
        Me.Estado = argEstado
        Me.NCaja = argNCaja
    End Sub

End Class
