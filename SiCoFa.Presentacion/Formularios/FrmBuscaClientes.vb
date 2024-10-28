Imports SiCoFa.Entidades
Public Class FrmBuscaClientes
    Property Clientes As List(Of Cliente)
    Property ClienteSeleccionado As Cliente
    Private Sub DescargarVariables()
        Clientes = Nothing
        ClienteSeleccionado = Nothing
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData
            Case Keys.Escape
                Call DescargarVariables()
                Me.Hide()
            Case Keys.Enter
                Call SeleccionarCliente()
                Me.Hide()
            Case Else
                Return MyBase.ProcessCmdKey(msg, keyData)
        End Select
    End Function
    Private Sub SeleccionarCliente()
        Dim c As New Cliente(
                            Me.DataGridView1.CurrentRow.Cells("IdCliente").Value,
                            Me.DataGridView1.CurrentRow.Cells("Nombre").Value,
                            Me.DataGridView1.CurrentRow.Cells("Domicilio").Value,
                            Me.DataGridView1.CurrentRow.Cells("Localidad").Value,
                            Me.DataGridView1.CurrentRow.Cells("Provincia").Value,
                            Me.DataGridView1.CurrentRow.Cells("Telefono").Value,
                            Me.DataGridView1.CurrentRow.Cells("Email").Value,
                            Me.DataGridView1.CurrentRow.Cells("CodiTDoc").Value,
                            Me.DataGridView1.CurrentRow.Cells("NumDoc").Value,
                            Me.DataGridView1.CurrentRow.Cells("CodIVA").Value
                            )
        Me.ClienteSeleccionado = c
    End Sub

    Private Sub FrmBuscaClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim x As Integer
        For Each c As Cliente In Me.Clientes
            With Me.DataGridView1
                .Rows.Add()
                .Rows(x).Cells("IdCliente").Value = c.Id
                .Rows(x).Cells("Nombre").Value = c.Nombre
                .Rows(x).Cells("Domicilio").Value = c.Domicilio
                .Rows(x).Cells("Localidad").Value = c.Localidad
                .Rows(x).Cells("Provincia").Value = c.Provincia
                .Rows(x).Cells("Telefono").Value = c.Telefono
                .Rows(x).Cells("Email").Value = c.Email
                .Rows(x).Cells("CodiTDoc").Value = c.Documento.TipoDoc.CodiTDoc
                .Rows(x).Cells("TipoDocumento").Value = c.Documento.TipoDoc.TipoDocumento
                .Rows(x).Cells("NumDoc").Value = c.Documento.Numero
                .Rows(x).Cells("CodIVA").Value = c.IVA.CodIVA
                .Rows(x).Cells("IVA").Value = c.IVA.TipoIVA
            End With
            x = x + 1
        Next
        Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(0).Cells(1)

    End Sub
End Class