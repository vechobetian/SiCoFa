Imports SiCoFa.Entidades

Public Class FrmBuscaPersonas
    Property Personas As IEnumerable(Of Persona)
    Property PersonaSeleccionado As Persona
    Private Sub SeleccionarPersona()

        Dim d As New Documento(Me.DataGridView1.CurrentRow.Cells("CodiTD").Value.ToString, Me.DataGridView1.CurrentRow.Cells("NumDoc").Value.ToString)
        Dim p As New Persona(
                            CInt(Me.DataGridView1.CurrentRow.Cells("Id").Value),
                            Me.DataGridView1.CurrentRow.Cells("Nombre").Value.ToString,
                            Me.DataGridView1.CurrentRow.Cells("Domicilio").Value.ToString,
                            Me.DataGridView1.CurrentRow.Cells("Localidad").Value.ToString,
                            Me.DataGridView1.CurrentRow.Cells("Provincia").Value.ToString,
                            Me.DataGridView1.CurrentRow.Cells("Telefono").Value.ToString,
                            Me.DataGridView1.CurrentRow.Cells("Email").Value.ToString,
                            d,
                            CDate(Me.DataGridView1.CurrentRow.Cells("FechaAlta").Value),
                            Me.DataGridView1.CurrentRow.Cells("Estado").Value.ToString
                            )
        Me.PersonaSeleccionado = p

    End Sub
    Private Sub CargarDatosEnDataGridView()
        Dim x As Integer
        For Each p As Persona In Me.Personas
            With Me.DataGridView1
                .Rows.Add()
                .Rows(x).Cells("Id").Value = p.Id
                .Rows(x).Cells("Nombre").Value = p.Nombre
                .Rows(x).Cells("Domicilio").Value = p.Domicilio
                .Rows(x).Cells("Localidad").Value = p.Localidad
                .Rows(x).Cells("Provincia").Value = p.Provincia
                .Rows(x).Cells("Telefono").Value = p.Telefono
                .Rows(x).Cells("Email").Value = p.Email
                .Rows(x).Cells("CodiTD").Value = p.Documento.TipoDocumento.CodiTD
                .Rows(x).Cells("TipoDocumento").Value = p.Documento.TipoDocumento.Descripcion
                .Rows(x).Cells("NumDoc").Value = p.Documento.Numero
                .Rows(x).Cells("FechaAlta").Value = p.FechaAlta
                .Rows(x).Cells("Estado").Value = p.Estado
            End With
            x += 1
        Next
        Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(0).Cells(1)
    End Sub
    Private Sub FrmBuscaPersonas_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.CargarDatosEnDataGridView()

    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData
            Case Keys.Escape
                Me.DialogResult = DialogResult.Cancel
                Me.Close()

            Case Keys.Enter
                Call SeleccionarPersona()
                Me.DialogResult = DialogResult.OK
                Me.Hide()

            Case Else
                Return MyBase.ProcessCmdKey(msg, keyData)
        End Select
        Return True ' Asegúrate de devolver True para que la tecla se procese correctamente
    End Function
End Class
