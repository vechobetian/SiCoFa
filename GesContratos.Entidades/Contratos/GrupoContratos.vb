Public Class GrupoContratos
    Property IdGC As Integer
    Property Descripcion As String
    Property CodiAE As String
    Property CuentaIngresos As String
    Property CuentaActivos As String
    Public Sub New(ByVal argIdGC As Integer, ByVal argDescripcion As String, ByVal argCodiAE As String, ByVal argCuentaIngresos As String, ByVal argCuentaActivos As String)

        Me.IdGC = argIdGC
        Me.Descripcion = argDescripcion
        Me.CodiAE = argCodiAE
        Me.CuentaIngresos = argCuentaIngresos
        Me.CuentaActivos = argCuentaActivos

    End Sub

End Class
