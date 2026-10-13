Imports SiCoFa.Entidades
Public Class FrmTransaccionesTrazabilidad
    Public Sub CargarDatosEnGrilla(argTransacciones As List(Of TransaccionTrazabilidad))


        Me.dgvTransacciones.AutoGenerateColumns = False
        Me.dgvTransacciones.DataSource = argTransacciones

    End Sub

End Class