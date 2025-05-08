Public Class FrmPanelClientes
    Private Sub AnexarPestañas()
        ' Instancia del formulario de cliente
        Dim frmClienteInstancia As New FrmClientes()
        Dim tabPageClientes As New TabPage("Datos Cliente") ' Crea una nueva pestaña

        With frmClienteInstancia
            .TopLevel = False
            .FormBorderStyle = FormBorderStyle.None
            .Dock = DockStyle.Fill
            tabPageClientes.Controls.Add(frmClienteInstancia) ' Agrega el formulario a la pestaña
            .Show()
        End With

        PanelCliente.TabPages.Add(tabPageClientes) ' Agrega la pestaña al TabControl

        ' Instancia del formulario de cuenta corriente
        Dim frmCuentaCorrienteInstancia As New FrmCuentaCorriente()
        Dim tabPageCuentaCorriente As New TabPage("Cuenta Corriente") ' Crea otra pestaña

        With frmCuentaCorrienteInstancia
            .TopLevel = False
            .FormBorderStyle = FormBorderStyle.None
            .Dock = DockStyle.Fill
            tabPageCuentaCorriente.Controls.Add(frmCuentaCorrienteInstancia) ' Agrega el formulario a la pestaña
            .Show()
        End With

        PanelCliente.TabPages.Add(tabPageCuentaCorriente) ' Agrega la segunda pestaña

    End Sub
    Private Sub FrmPanelClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.AnexarPestañas()
    End Sub

End Class