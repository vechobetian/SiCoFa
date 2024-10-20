Imports SiCoFa.Entidades
Public Class FrmBuscaServicios
    Property Servicios As List(Of Servicio)
    Property ServicioSeleccionado As Servicio
    Private Sub DescargarVariables()
        Servicios = Nothing
        ServicioSeleccionado = Nothing
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData
            Case Keys.Escape
                Call DescargarVariables()
                Me.Hide()
            Case Keys.Enter
                Call SeleccionarServicio()
                Me.Hide()
            Case Else
                Return MyBase.ProcessCmdKey(msg, keyData)
        End Select
    End Function

    Private Sub SeleccionarServicio()
        Dim s As New Servicio(
                              Me.DataGridView1.CurrentRow.Cells("CodiS").Value,
                              Me.DataGridView1.CurrentRow.Cells("DescripcionServicio").Value,
                              Me.DataGridView1.CurrentRow.Cells("PUnit").Value
                              )
        Me.ServicioSeleccionado = s
    End Sub

    Private Sub FrmBuscaServicios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim x As Integer
        For Each s As Servicio In Me.Servicios
            With Me.DataGridView1
                .Rows.Add()
                .Rows(x).Cells("CodiS").Value = s.CodiS
                .Rows(x).Cells("DescripcionServicio").Value = s.DescripcionServicio
                .Rows(x).Cells("PUnit").Value = s.PUnit
            End With
            x = x + 1
        Next
        Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(0).Cells(1)

    End Sub
End Class