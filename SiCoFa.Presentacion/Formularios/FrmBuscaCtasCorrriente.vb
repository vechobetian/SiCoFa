Imports SiCoFa.Entidades

Public Class FrmBuscaCtasCorrriente
    Property CuentasCorriente As IEnumerable(Of CuentaCorriente)
    Property CuentaSeleccionada As CuentaCorriente

    Private Sub SeleccionarCuenta()

        Dim c As New CuentaCorriente(
                            Me.DataGridView1.CurrentRow.Cells("IdCC").Value,
                            Me.DataGridView1.CurrentRow.Cells("IdCliente").Value,
                            Me.DataGridView1.CurrentRow.Cells("Decripcion").Value,
                            Me.DataGridView1.CurrentRow.Cells("Credito").Value,
                            Me.DataGridView1.CurrentRow.Cells("FechaAlta").Value,
                            Me.DataGridView1.CurrentRow.Cells("Observaciones").Value,
                            Me.DataGridView1.CurrentRow.Cells("Saldo").Value,
                            Me.DataGridView1.CurrentRow.Cells("Estado").Value
                            )
        Me.CuentaSeleccionada = c

    End Sub

    Private Sub CargarDatosEnDataGridView()
        Dim x As Integer
        For Each c As CuentaCorriente In Me.CuentasCorriente
            With Me.DataGridView1
                .Rows.Add()
                .Rows(x).Cells("IdCC").Value = c.IdCC
                .Rows(x).Cells("IdCliente").Value = c.IdCliente
                .Rows(x).Cells("Descripcion").Value = c.Descripcion
                .Rows(x).Cells("Credito").Value = c.Credito
                .Rows(x).Cells("Observaciones").Value = c.Observaciones
                .Rows(x).Cells("Saldo").Value = c.Saldo
                .Rows(x).Cells("CreditoDisponible").Value = c.CreditoDisponible
                .Rows(x).Cells("Estado").Value = c.Estado
            End With
            x += 1
        Next
        Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(0).Cells(1)
    End Sub

    Private Sub FrmBuscaCtasCorriente_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.CargarDatosEnDataGridView()

    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData
            Case Keys.Escape
                Me.DialogResult = DialogResult.Cancel
                Me.Close()

            Case Keys.Enter
                Call SeleccionarCuenta()
                Me.DialogResult = DialogResult.OK
                Me.Hide()

            Case Else
                Return MyBase.ProcessCmdKey(msg, keyData)
        End Select
        Return True ' Asegúrate de devolver True para que la tecla se procese correctamente
    End Function
End Class
