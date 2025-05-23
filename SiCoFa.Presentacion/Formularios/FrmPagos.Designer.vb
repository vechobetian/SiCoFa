<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPagos
    'Inherits System.Windows.Forms.Form
    Inherits clsFrmBase

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.PanelDatosCliente = New System.Windows.Forms.Panel()
        Me.PagoElectronico = New System.Windows.Forms.Label()
        Me.NumeroDocumento = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NombreCliente = New System.Windows.Forms.Label()
        Me.lblPagoElectronico = New System.Windows.Forms.Label()
        Me.TipoDocumento = New System.Windows.Forms.Label()
        Me.lblTipoContribuyente = New System.Windows.Forms.Label()
        Me.lblNombreCliente = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblImpAPagar = New System.Windows.Forms.Label()
        Me.lblPVenta = New System.Windows.Forms.Label()
        Me.lblTipoComprobante = New System.Windows.Forms.Label()
        Me.lblImporteEfectivo = New System.Windows.Forms.Label()
        Me.lblImporteCuentaCorriente = New System.Windows.Forms.Label()
        Me.lblImportePagoElectronico = New System.Windows.Forms.Label()
        Me.txtImportePagoElectronico = New System.Windows.Forms.TextBox()
        Me.txtTipoComprobante = New System.Windows.Forms.TextBox()
        Me.txtPVenta = New System.Windows.Forms.TextBox()
        Me.txtImporteAPagar = New System.Windows.Forms.TextBox()
        Me.txtImporteEfectivo = New System.Windows.Forms.TextBox()
        Me.txtImporteCuentaCorriente = New System.Windows.Forms.TextBox()
        Me.PanelDatosCliente.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelDatosCliente
        '
        Me.PanelDatosCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelDatosCliente.Controls.Add(Me.PagoElectronico)
        Me.PanelDatosCliente.Controls.Add(Me.NumeroDocumento)
        Me.PanelDatosCliente.Controls.Add(Me.Label1)
        Me.PanelDatosCliente.Controls.Add(Me.NombreCliente)
        Me.PanelDatosCliente.Controls.Add(Me.lblPagoElectronico)
        Me.PanelDatosCliente.Controls.Add(Me.TipoDocumento)
        Me.PanelDatosCliente.Controls.Add(Me.lblTipoContribuyente)
        Me.PanelDatosCliente.Controls.Add(Me.lblNombreCliente)
        Me.PanelDatosCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanelDatosCliente.Location = New System.Drawing.Point(12, 12)
        Me.PanelDatosCliente.Name = "PanelDatosCliente"
        Me.PanelDatosCliente.Size = New System.Drawing.Size(830, 197)
        Me.PanelDatosCliente.TabIndex = 0
        '
        'PagoElectronico
        '
        Me.PagoElectronico.AccessibleDescription = "IVACliente"
        Me.PagoElectronico.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PagoElectronico.Location = New System.Drawing.Point(338, 153)
        Me.PagoElectronico.Name = "PagoElectronico"
        Me.PagoElectronico.Size = New System.Drawing.Size(487, 29)
        Me.PagoElectronico.TabIndex = 7
        Me.PagoElectronico.Text = "No Establecido"
        '
        'NumeroDocumento
        '
        Me.NumeroDocumento.AccessibleDescription = "IVACliente"
        Me.NumeroDocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumeroDocumento.Location = New System.Drawing.Point(172, 96)
        Me.NumeroDocumento.Name = "NumeroDocumento"
        Me.NumeroDocumento.Size = New System.Drawing.Size(653, 29)
        Me.NumeroDocumento.TabIndex = 6
        Me.NumeroDocumento.Text = "No Aplica"
        '
        'Label1
        '
        Me.Label1.AccessibleDescription = "IVACliente"
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(302, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(523, 29)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Consumidor Final"
        '
        'NombreCliente
        '
        Me.NombreCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NombreCliente.Location = New System.Drawing.Point(151, 9)
        Me.NombreCliente.Name = "NombreCliente"
        Me.NombreCliente.Size = New System.Drawing.Size(674, 37)
        Me.NombreCliente.TabIndex = 4
        Me.NombreCliente.Text = "Consumidor Final"
        '
        'lblPagoElectronico
        '
        Me.lblPagoElectronico.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPagoElectronico.Location = New System.Drawing.Point(12, 153)
        Me.lblPagoElectronico.Name = "lblPagoElectronico"
        Me.lblPagoElectronico.Size = New System.Drawing.Size(329, 29)
        Me.lblPagoElectronico.TabIndex = 3
        Me.lblPagoElectronico.Text = "Tarjeta / Pago Electronico:"
        '
        'TipoDocumento
        '
        Me.TipoDocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TipoDocumento.Location = New System.Drawing.Point(14, 96)
        Me.TipoDocumento.Name = "TipoDocumento"
        Me.TipoDocumento.Size = New System.Drawing.Size(152, 32)
        Me.TipoDocumento.TabIndex = 2
        Me.TipoDocumento.Text = "DNI / CUIT:"
        '
        'lblTipoContribuyente
        '
        Me.lblTipoContribuyente.AccessibleDescription = "IVACliente"
        Me.lblTipoContribuyente.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoContribuyente.Location = New System.Drawing.Point(12, 55)
        Me.lblTipoContribuyente.Name = "lblTipoContribuyente"
        Me.lblTipoContribuyente.Size = New System.Drawing.Size(284, 29)
        Me.lblTipoContribuyente.TabIndex = 1
        Me.lblTipoContribuyente.Text = "Tipo de Contribuyente:"
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreCliente.Location = New System.Drawing.Point(12, 9)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(133, 37)
        Me.lblNombreCliente.TabIndex = 0
        Me.lblNombreCliente.Text = "Cliente:"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtImporteCuentaCorriente)
        Me.Panel1.Controls.Add(Me.txtImporteEfectivo)
        Me.Panel1.Controls.Add(Me.txtImporteAPagar)
        Me.Panel1.Controls.Add(Me.txtPVenta)
        Me.Panel1.Controls.Add(Me.txtTipoComprobante)
        Me.Panel1.Controls.Add(Me.txtImportePagoElectronico)
        Me.Panel1.Controls.Add(Me.lblImportePagoElectronico)
        Me.Panel1.Controls.Add(Me.lblImporteCuentaCorriente)
        Me.Panel1.Controls.Add(Me.lblImporteEfectivo)
        Me.Panel1.Controls.Add(Me.lblImpAPagar)
        Me.Panel1.Controls.Add(Me.lblPVenta)
        Me.Panel1.Controls.Add(Me.lblTipoComprobante)
        Me.Panel1.Location = New System.Drawing.Point(12, 215)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(830, 270)
        Me.Panel1.TabIndex = 1
        '
        'lblImpAPagar
        '
        Me.lblImpAPagar.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImpAPagar.Location = New System.Drawing.Point(14, 98)
        Me.lblImpAPagar.Name = "lblImpAPagar"
        Me.lblImpAPagar.Size = New System.Drawing.Size(250, 30)
        Me.lblImpAPagar.TabIndex = 3
        Me.lblImpAPagar.Text = "Importe a Pagar:"
        '
        'lblPVenta
        '
        Me.lblPVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPVenta.Location = New System.Drawing.Point(14, 57)
        Me.lblPVenta.Name = "lblPVenta"
        Me.lblPVenta.Size = New System.Drawing.Size(250, 30)
        Me.lblPVenta.TabIndex = 2
        Me.lblPVenta.Text = "Punto de Venta:"
        '
        'lblTipoComprobante
        '
        Me.lblTipoComprobante.AccessibleDescription = "IVACliente"
        Me.lblTipoComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoComprobante.Location = New System.Drawing.Point(15, 16)
        Me.lblTipoComprobante.Name = "lblTipoComprobante"
        Me.lblTipoComprobante.Size = New System.Drawing.Size(250, 30)
        Me.lblTipoComprobante.TabIndex = 1
        Me.lblTipoComprobante.Text = "Comprobante:"
        '
        'lblImporteEfectivo
        '
        Me.lblImporteEfectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteEfectivo.Location = New System.Drawing.Point(14, 221)
        Me.lblImporteEfectivo.Name = "lblImporteEfectivo"
        Me.lblImporteEfectivo.Size = New System.Drawing.Size(250, 30)
        Me.lblImporteEfectivo.TabIndex = 4
        Me.lblImporteEfectivo.Text = "Importe Efectivo:"
        '
        'lblImporteCuentaCorriente
        '
        Me.lblImporteCuentaCorriente.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteCuentaCorriente.Location = New System.Drawing.Point(14, 139)
        Me.lblImporteCuentaCorriente.Name = "lblImporteCuentaCorriente"
        Me.lblImporteCuentaCorriente.Size = New System.Drawing.Size(250, 30)
        Me.lblImporteCuentaCorriente.TabIndex = 5
        Me.lblImporteCuentaCorriente.Text = "Importe Cta. Cte:"
        '
        'lblImportePagoElectronico
        '
        Me.lblImportePagoElectronico.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImportePagoElectronico.Location = New System.Drawing.Point(14, 180)
        Me.lblImportePagoElectronico.Name = "lblImportePagoElectronico"
        Me.lblImportePagoElectronico.Size = New System.Drawing.Size(250, 30)
        Me.lblImportePagoElectronico.TabIndex = 6
        Me.lblImportePagoElectronico.Text = "Tarjeta / Pago Elec:"
        '
        'txtImportePagoElectronico
        '
        Me.txtImportePagoElectronico.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImportePagoElectronico.Location = New System.Drawing.Point(270, 177)
        Me.txtImportePagoElectronico.Name = "txtImportePagoElectronico"
        Me.txtImportePagoElectronico.Size = New System.Drawing.Size(550, 35)
        Me.txtImportePagoElectronico.TabIndex = 5
        Me.txtImportePagoElectronico.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTipoComprobante
        '
        Me.txtTipoComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoComprobante.Location = New System.Drawing.Point(270, 13)
        Me.txtTipoComprobante.Name = "txtTipoComprobante"
        Me.txtTipoComprobante.Size = New System.Drawing.Size(550, 35)
        Me.txtTipoComprobante.TabIndex = 1
        Me.txtTipoComprobante.TabStop = False
        '
        'txtPVenta
        '
        Me.txtPVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPVenta.Location = New System.Drawing.Point(270, 54)
        Me.txtPVenta.Name = "txtPVenta"
        Me.txtPVenta.Size = New System.Drawing.Size(550, 35)
        Me.txtPVenta.TabIndex = 2
        Me.txtPVenta.TabStop = False
        '
        'txtImporteAPagar
        '
        Me.txtImporteAPagar.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporteAPagar.Location = New System.Drawing.Point(270, 95)
        Me.txtImporteAPagar.Name = "txtImporteAPagar"
        Me.txtImporteAPagar.Size = New System.Drawing.Size(550, 35)
        Me.txtImporteAPagar.TabIndex = 3
        Me.txtImporteAPagar.TabStop = False
        Me.txtImporteAPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtImporteEfectivo
        '
        Me.txtImporteEfectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporteEfectivo.Location = New System.Drawing.Point(270, 218)
        Me.txtImporteEfectivo.Name = "txtImporteEfectivo"
        Me.txtImporteEfectivo.Size = New System.Drawing.Size(550, 35)
        Me.txtImporteEfectivo.TabIndex = 6
        Me.txtImporteEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtImporteCuentaCorriente
        '
        Me.txtImporteCuentaCorriente.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporteCuentaCorriente.Location = New System.Drawing.Point(270, 136)
        Me.txtImporteCuentaCorriente.Name = "txtImporteCuentaCorriente"
        Me.txtImporteCuentaCorriente.Size = New System.Drawing.Size(550, 35)
        Me.txtImporteCuentaCorriente.TabIndex = 4
        Me.txtImporteCuentaCorriente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'FrmPagos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(857, 497)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PanelDatosCliente)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FrmPagos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pagos del Cliente"
        Me.PanelDatosCliente.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelDatosCliente As Panel
    Friend WithEvents lblNombreCliente As Label
    Friend WithEvents TipoDocumento As Label
    Friend WithEvents lblTipoContribuyente As Label
    Friend WithEvents lblPagoElectronico As Label
    Friend WithEvents NombreCliente As Label
    Friend WithEvents NumeroDocumento As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PagoElectronico As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblImpAPagar As Label
    Friend WithEvents lblPVenta As Label
    Friend WithEvents lblTipoComprobante As Label
    Friend WithEvents lblImportePagoElectronico As Label
    Friend WithEvents lblImporteCuentaCorriente As Label
    Friend WithEvents lblImporteEfectivo As Label
    Friend WithEvents txtImportePagoElectronico As TextBox
    Friend WithEvents txtImporteCuentaCorriente As TextBox
    Friend WithEvents txtImporteEfectivo As TextBox
    Friend WithEvents txtImporteAPagar As TextBox
    Friend WithEvents txtPVenta As TextBox
    Friend WithEvents txtTipoComprobante As TextBox
End Class
