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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPagos))
        Me.PanelDatosCliente = New System.Windows.Forms.Panel()
        Me.lblPagoElectronico = New System.Windows.Forms.Label()
        Me.lblNumeroDocumento = New System.Windows.Forms.Label()
        Me.lblTipoContribuyente = New System.Windows.Forms.Label()
        Me.lblNombreCliente = New System.Windows.Forms.Label()
        Me.lblPagoElectronicoEtiqueta = New System.Windows.Forms.Label()
        Me.lblTipoDocumento = New System.Windows.Forms.Label()
        Me.lblTipoContribuyenteEtiqueta = New System.Windows.Forms.Label()
        Me.lblNombreClienteEtiqueta = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnPagoElectronico = New System.Windows.Forms.Button()
        Me.btnCuentaCorriente = New System.Windows.Forms.Button()
        Me.txtImporteCuentaCorriente = New System.Windows.Forms.TextBox()
        Me.txtImporteEfectivo = New System.Windows.Forms.TextBox()
        Me.txtImporteAPagar = New System.Windows.Forms.TextBox()
        Me.txtTipoComprobante = New System.Windows.Forms.TextBox()
        Me.txtImportePagoElectronico = New System.Windows.Forms.TextBox()
        Me.lblImportePagoElectronico = New System.Windows.Forms.Label()
        Me.lblImporteCuentaCorriente = New System.Windows.Forms.Label()
        Me.lblImporteEfectivo = New System.Windows.Forms.Label()
        Me.lblImpAPagar = New System.Windows.Forms.Label()
        Me.lblTipoComprobante = New System.Windows.Forms.Label()
        Me.btnFinalizar = New System.Windows.Forms.Button()
        Me.PanelDatosCliente.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelDatosCliente
        '
        Me.PanelDatosCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelDatosCliente.Controls.Add(Me.lblPagoElectronico)
        Me.PanelDatosCliente.Controls.Add(Me.lblNumeroDocumento)
        Me.PanelDatosCliente.Controls.Add(Me.lblTipoContribuyente)
        Me.PanelDatosCliente.Controls.Add(Me.lblNombreCliente)
        Me.PanelDatosCliente.Controls.Add(Me.lblPagoElectronicoEtiqueta)
        Me.PanelDatosCliente.Controls.Add(Me.lblTipoDocumento)
        Me.PanelDatosCliente.Controls.Add(Me.lblTipoContribuyenteEtiqueta)
        Me.PanelDatosCliente.Controls.Add(Me.lblNombreClienteEtiqueta)
        Me.PanelDatosCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanelDatosCliente.Location = New System.Drawing.Point(12, 12)
        Me.PanelDatosCliente.Name = "PanelDatosCliente"
        Me.PanelDatosCliente.Size = New System.Drawing.Size(830, 197)
        Me.PanelDatosCliente.TabIndex = 0
        '
        'lblPagoElectronico
        '
        Me.lblPagoElectronico.AccessibleDescription = "IVACliente"
        Me.lblPagoElectronico.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPagoElectronico.Location = New System.Drawing.Point(338, 153)
        Me.lblPagoElectronico.Name = "lblPagoElectronico"
        Me.lblPagoElectronico.Size = New System.Drawing.Size(487, 29)
        Me.lblPagoElectronico.TabIndex = 7
        Me.lblPagoElectronico.Text = "No Establecido"
        '
        'lblNumeroDocumento
        '
        Me.lblNumeroDocumento.AccessibleDescription = "IVACliente"
        Me.lblNumeroDocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroDocumento.Location = New System.Drawing.Point(84, 96)
        Me.lblNumeroDocumento.Name = "lblNumeroDocumento"
        Me.lblNumeroDocumento.Size = New System.Drawing.Size(736, 29)
        Me.lblNumeroDocumento.TabIndex = 6
        Me.lblNumeroDocumento.Text = "No Aplica"
        '
        'lblTipoContribuyente
        '
        Me.lblTipoContribuyente.AccessibleDescription = "IVACliente"
        Me.lblTipoContribuyente.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoContribuyente.Location = New System.Drawing.Point(302, 55)
        Me.lblTipoContribuyente.Name = "lblTipoContribuyente"
        Me.lblTipoContribuyente.Size = New System.Drawing.Size(523, 29)
        Me.lblTipoContribuyente.TabIndex = 5
        Me.lblTipoContribuyente.Text = "Consumidor Final"
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreCliente.Location = New System.Drawing.Point(151, 9)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(674, 37)
        Me.lblNombreCliente.TabIndex = 4
        Me.lblNombreCliente.Text = "Consumidor Final"
        '
        'lblPagoElectronicoEtiqueta
        '
        Me.lblPagoElectronicoEtiqueta.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPagoElectronicoEtiqueta.Location = New System.Drawing.Point(12, 153)
        Me.lblPagoElectronicoEtiqueta.Name = "lblPagoElectronicoEtiqueta"
        Me.lblPagoElectronicoEtiqueta.Size = New System.Drawing.Size(327, 29)
        Me.lblPagoElectronicoEtiqueta.TabIndex = 3
        Me.lblPagoElectronicoEtiqueta.Text = "Tarjeta / Pago Electronico:"
        '
        'lblTipoDocumento
        '
        Me.lblTipoDocumento.AutoSize = True
        Me.lblTipoDocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoDocumento.Location = New System.Drawing.Point(14, 96)
        Me.lblTipoDocumento.Name = "lblTipoDocumento"
        Me.lblTipoDocumento.Size = New System.Drawing.Size(64, 29)
        Me.lblTipoDocumento.TabIndex = 2
        Me.lblTipoDocumento.Text = "DNI:"
        '
        'lblTipoContribuyenteEtiqueta
        '
        Me.lblTipoContribuyenteEtiqueta.AccessibleDescription = "IVACliente"
        Me.lblTipoContribuyenteEtiqueta.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoContribuyenteEtiqueta.Location = New System.Drawing.Point(12, 55)
        Me.lblTipoContribuyenteEtiqueta.Name = "lblTipoContribuyenteEtiqueta"
        Me.lblTipoContribuyenteEtiqueta.Size = New System.Drawing.Size(284, 29)
        Me.lblTipoContribuyenteEtiqueta.TabIndex = 1
        Me.lblTipoContribuyenteEtiqueta.Text = "Tipo de Contribuyente:"
        '
        'lblNombreClienteEtiqueta
        '
        Me.lblNombreClienteEtiqueta.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreClienteEtiqueta.Location = New System.Drawing.Point(12, 9)
        Me.lblNombreClienteEtiqueta.Name = "lblNombreClienteEtiqueta"
        Me.lblNombreClienteEtiqueta.Size = New System.Drawing.Size(133, 37)
        Me.lblNombreClienteEtiqueta.TabIndex = 0
        Me.lblNombreClienteEtiqueta.Text = "Cliente:"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.btnPagoElectronico)
        Me.Panel1.Controls.Add(Me.btnCuentaCorriente)
        Me.Panel1.Controls.Add(Me.txtImporteCuentaCorriente)
        Me.Panel1.Controls.Add(Me.txtImporteEfectivo)
        Me.Panel1.Controls.Add(Me.txtImporteAPagar)
        Me.Panel1.Controls.Add(Me.txtTipoComprobante)
        Me.Panel1.Controls.Add(Me.txtImportePagoElectronico)
        Me.Panel1.Controls.Add(Me.lblImportePagoElectronico)
        Me.Panel1.Controls.Add(Me.lblImporteCuentaCorriente)
        Me.Panel1.Controls.Add(Me.lblImporteEfectivo)
        Me.Panel1.Controls.Add(Me.lblImpAPagar)
        Me.Panel1.Controls.Add(Me.lblTipoComprobante)
        Me.Panel1.Location = New System.Drawing.Point(12, 215)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(830, 231)
        Me.Panel1.TabIndex = 1
        '
        'Button2
        '
        Me.Button2.Enabled = False
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(272, 180)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(33, 30)
        Me.Button2.TabIndex = 10
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(272, 57)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(33, 30)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "$"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnPagoElectronico
        '
        Me.btnPagoElectronico.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPagoElectronico.Image = CType(resources.GetObject("btnPagoElectronico.Image"), System.Drawing.Image)
        Me.btnPagoElectronico.Location = New System.Drawing.Point(272, 139)
        Me.btnPagoElectronico.Name = "btnPagoElectronico"
        Me.btnPagoElectronico.Size = New System.Drawing.Size(33, 30)
        Me.btnPagoElectronico.TabIndex = 8
        Me.btnPagoElectronico.TabStop = False
        Me.btnPagoElectronico.UseVisualStyleBackColor = True
        '
        'btnCuentaCorriente
        '
        Me.btnCuentaCorriente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCuentaCorriente.Image = CType(resources.GetObject("btnCuentaCorriente.Image"), System.Drawing.Image)
        Me.btnCuentaCorriente.Location = New System.Drawing.Point(272, 98)
        Me.btnCuentaCorriente.Name = "btnCuentaCorriente"
        Me.btnCuentaCorriente.Size = New System.Drawing.Size(33, 30)
        Me.btnCuentaCorriente.TabIndex = 7
        Me.btnCuentaCorriente.TabStop = False
        Me.btnCuentaCorriente.UseVisualStyleBackColor = True
        '
        'txtImporteCuentaCorriente
        '
        Me.txtImporteCuentaCorriente.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporteCuentaCorriente.Location = New System.Drawing.Point(270, 95)
        Me.txtImporteCuentaCorriente.Name = "txtImporteCuentaCorriente"
        Me.txtImporteCuentaCorriente.Size = New System.Drawing.Size(550, 35)
        Me.txtImporteCuentaCorriente.TabIndex = 4
        Me.txtImporteCuentaCorriente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtImporteEfectivo
        '
        Me.txtImporteEfectivo.BackColor = System.Drawing.Color.White
        Me.txtImporteEfectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporteEfectivo.Location = New System.Drawing.Point(270, 177)
        Me.txtImporteEfectivo.Name = "txtImporteEfectivo"
        Me.txtImporteEfectivo.ReadOnly = True
        Me.txtImporteEfectivo.Size = New System.Drawing.Size(550, 35)
        Me.txtImporteEfectivo.TabIndex = 6
        Me.txtImporteEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtImporteAPagar
        '
        Me.txtImporteAPagar.BackColor = System.Drawing.Color.White
        Me.txtImporteAPagar.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporteAPagar.Location = New System.Drawing.Point(270, 54)
        Me.txtImporteAPagar.Name = "txtImporteAPagar"
        Me.txtImporteAPagar.ReadOnly = True
        Me.txtImporteAPagar.Size = New System.Drawing.Size(550, 35)
        Me.txtImporteAPagar.TabIndex = 3
        Me.txtImporteAPagar.TabStop = False
        Me.txtImporteAPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        'txtImportePagoElectronico
        '
        Me.txtImportePagoElectronico.Enabled = False
        Me.txtImportePagoElectronico.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImportePagoElectronico.Location = New System.Drawing.Point(270, 136)
        Me.txtImportePagoElectronico.Name = "txtImportePagoElectronico"
        Me.txtImportePagoElectronico.Size = New System.Drawing.Size(550, 35)
        Me.txtImportePagoElectronico.TabIndex = 5
        Me.txtImportePagoElectronico.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblImportePagoElectronico
        '
        Me.lblImportePagoElectronico.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImportePagoElectronico.Location = New System.Drawing.Point(14, 139)
        Me.lblImportePagoElectronico.Name = "lblImportePagoElectronico"
        Me.lblImportePagoElectronico.Size = New System.Drawing.Size(250, 30)
        Me.lblImportePagoElectronico.TabIndex = 6
        Me.lblImportePagoElectronico.Text = "Tarjeta / Pago Elec:"
        '
        'lblImporteCuentaCorriente
        '
        Me.lblImporteCuentaCorriente.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteCuentaCorriente.Location = New System.Drawing.Point(14, 98)
        Me.lblImporteCuentaCorriente.Name = "lblImporteCuentaCorriente"
        Me.lblImporteCuentaCorriente.Size = New System.Drawing.Size(250, 30)
        Me.lblImporteCuentaCorriente.TabIndex = 5
        Me.lblImporteCuentaCorriente.Text = "Importe Cta. Cte:"
        '
        'lblImporteEfectivo
        '
        Me.lblImporteEfectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteEfectivo.Location = New System.Drawing.Point(14, 180)
        Me.lblImporteEfectivo.Name = "lblImporteEfectivo"
        Me.lblImporteEfectivo.Size = New System.Drawing.Size(250, 30)
        Me.lblImporteEfectivo.TabIndex = 4
        Me.lblImporteEfectivo.Text = "Importe Efectivo:"
        '
        'lblImpAPagar
        '
        Me.lblImpAPagar.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImpAPagar.Location = New System.Drawing.Point(14, 57)
        Me.lblImpAPagar.Name = "lblImpAPagar"
        Me.lblImpAPagar.Size = New System.Drawing.Size(250, 30)
        Me.lblImpAPagar.TabIndex = 3
        Me.lblImpAPagar.Text = "Importe a Pagar:"
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
        'btnFinalizar
        '
        Me.btnFinalizar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFinalizar.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnFinalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFinalizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFinalizar.ForeColor = System.Drawing.SystemColors.Highlight
        Me.btnFinalizar.Image = CType(resources.GetObject("btnFinalizar.Image"), System.Drawing.Image)
        Me.btnFinalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFinalizar.Location = New System.Drawing.Point(681, 460)
        Me.btnFinalizar.Name = "btnFinalizar"
        Me.btnFinalizar.Size = New System.Drawing.Size(161, 40)
        Me.btnFinalizar.TabIndex = 2
        Me.btnFinalizar.TabStop = False
        Me.btnFinalizar.Text = "&Finalizar (F10)"
        Me.btnFinalizar.UseVisualStyleBackColor = True
        '
        'FrmPagos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(857, 512)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnFinalizar)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PanelDatosCliente)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FrmPagos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pagos del Cliente"
        Me.PanelDatosCliente.ResumeLayout(False)
        Me.PanelDatosCliente.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelDatosCliente As Panel
    Friend WithEvents lblNombreClienteEtiqueta As Label
    Friend WithEvents lblTipoDocumento As Label
    Friend WithEvents lblTipoContribuyenteEtiqueta As Label
    Friend WithEvents lblPagoElectronicoEtiqueta As Label
    Friend WithEvents lblNombreCliente As Label
    Friend WithEvents lblNumeroDocumento As Label
    Friend WithEvents lblTipoContribuyente As Label
    Friend WithEvents lblPagoElectronico As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblImpAPagar As Label
    Friend WithEvents lblTipoComprobante As Label
    Friend WithEvents lblImportePagoElectronico As Label
    Friend WithEvents lblImporteCuentaCorriente As Label
    Friend WithEvents lblImporteEfectivo As Label
    Friend WithEvents txtImportePagoElectronico As TextBox
    Friend WithEvents txtImporteCuentaCorriente As TextBox
    Friend WithEvents txtImporteEfectivo As TextBox
    Friend WithEvents txtImporteAPagar As TextBox
    Friend WithEvents txtTipoComprobante As TextBox
    Friend WithEvents btnCuentaCorriente As Button
    Friend WithEvents btnPagoElectronico As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents btnFinalizar As Button
End Class
