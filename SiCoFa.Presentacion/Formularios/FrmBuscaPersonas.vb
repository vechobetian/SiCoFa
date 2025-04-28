Imports SiCoFa.Entidades

Public Class FrmBuscaPersonas
    Property Personas As IEnumerable(Of Persona)
    Property PersonaSeleccionado As Persona
    Private Sub DescargarVariables()
        Personas = Nothing
        PersonaSeleccionado = Nothing
    End Sub
    Private Sub SeleccionarPersona()

        Dim p As New Persona(
                            Me.DataGridView1.CurrentRow.Cells("Id").Value,
                            Me.DataGridView1.CurrentRow.Cells("Nombre").Value,
                            Me.DataGridView1.CurrentRow.Cells("Domicilio").Value,
                            Me.DataGridView1.CurrentRow.Cells("Localidad").Value,
                            Me.DataGridView1.CurrentRow.Cells("Provincia").Value,
                            Me.DataGridView1.CurrentRow.Cells("Telefono").Value,
                            Me.DataGridView1.CurrentRow.Cells("Email").Value,
                            Me.DataGridView1.CurrentRow.Cells("CodiTDoc").Value,
                            Me.DataGridView1.CurrentRow.Cells("NumDoc").Value,
                            Me.DataGridView1.CurrentRow.Cells("CodIVA").Value,
                            Me.DataGridView1.CurrentRow.Cells("IB").Value
                            )
        Me.PersonaSeleccionado = p

    End Sub
    Private Sub CargarDatosEnDataGridView()
        Dim x As Integer
        For Each p As Persona In Me.Personas
            With Me.DataGridView1
                .Rows.Add()
                .Rows(x).Cells("IdCliente").Value = p.Id
                .Rows(x).Cells("Nombre").Value = p.Nombre
                .Rows(x).Cells("Domicilio").Value = p.Domicilio
                .Rows(x).Cells("Localidad").Value = p.Localidad
                .Rows(x).Cells("Provincia").Value = p.Provincia
                .Rows(x).Cells("Telefono").Value = p.Telefono
                .Rows(x).Cells("Email").Value = p.Email
                .Rows(x).Cells("CodiTDoc").Value = p.Documento.TipoDoc.CodiTDoc
                .Rows(x).Cells("TipoDocumento").Value = p.Documento.TipoDoc.TipoDocumento
                .Rows(x).Cells("NumDoc").Value = p.Documento.Numero
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
                Call DescargarVariables()
                Me.Hide()
            Case Keys.Enter
                Call SeleccionarPersona()
                Me.Hide()
            Case Else
                Return MyBase.ProcessCmdKey(msg, keyData)
        End Select
        Return True ' Asegúrate de devolver True para que la tecla se procese correctamente
    End Function
End Class
