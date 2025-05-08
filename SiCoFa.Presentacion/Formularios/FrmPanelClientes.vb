Public Class FrmPanelClientes
    Private Sub FrmPanelClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Instancia del formulario de cliente
        Dim frmClienteInstancia As New FrmClientes()
        frmClienteInstancia.TopLevel = False ' Indica que no es un formulario de nivel superior
        frmClienteInstancia.FormBorderStyle = FormBorderStyle.None ' Opcional: Quita los bordes
        frmClienteInstancia.Dock = DockStyle.Fill ' Opcional: Rellena toda la pestaña
        DatosCliente.Controls.Add(frmClienteInstancia) ' Agrega el formulario a la primera pestaña
        frmClienteInstancia.Show() ' Muestra el formulario dentro de la pestaña
    End Sub
End Class