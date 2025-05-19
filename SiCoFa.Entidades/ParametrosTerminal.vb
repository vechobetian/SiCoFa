Public Class ParametrosTerminal
    Property MacAddress As String
    Property IdEmpresa As Integer
    Property IdPc As String
    Property PVenta As String 'Punto de venta
    Property NCaja As String
    Property MenuCaja As Boolean
    Property Impresora As String
    Property Papel As String

    Public Sub New(ByVal argMacAddress As String,
                   ByVal argIdEmpresa As Integer,
                   ByVal argIdPC As String,
                   ByVal argPVenta As String,
                   ByVal argNCaja As String,
                   ByVal argMenuCaja As Boolean,
                   ByVal argImpresora As String,
                   ByVal argPapel As String
                   )

        Me.MacAddress = argMacAddress
        Me.IdEmpresa = argIdEmpresa
        Me.IdPc = argIdPC
        Me.PVenta = argPVenta
        Me.NCaja = argNCaja
        Me.MenuCaja = argMenuCaja
        Me.Impresora = argImpresora
        Me.Papel = argPapel

    End Sub

End Class