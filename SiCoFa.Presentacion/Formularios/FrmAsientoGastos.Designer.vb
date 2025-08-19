<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAsientoGastos
    'Inherits System.Windows.Forms.Form
    Inherits clsFrmBase

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cmbFPago = New System.Windows.Forms.ComboBox()
        Me.cmbCajaAbierta = New System.Windows.Forms.ComboBox()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.txtTipoComprobante = New System.Windows.Forms.TextBox()
        Me.mtxtNumComprobante = New System.Windows.Forms.MaskedTextBox()
        Me.mtxtFechaComprobante = New System.Windows.Forms.MaskedTextBox()
        Me.txtImporte = New System.Windows.Forms.TextBox()
        Me.txtCuentaImputable = New System.Windows.Forms.TextBox()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblVariable = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.brnFinalizar = New System.Windows.Forms.Button()
        Me.txtCuentaBancaria = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'cmbFPago
        '
        Me.cmbFPago.BackColor = System.Drawing.Color.White
        Me.cmbFPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFPago.FormattingEnabled = True
        Me.cmbFPago.Items.AddRange(New Object() {"CONTADO", "CREDITO", "TRANSFERENCIA"})
        Me.cmbFPago.Location = New System.Drawing.Point(256, 12)
        Me.cmbFPago.Name = "cmbFPago"
        Me.cmbFPago.Size = New System.Drawing.Size(519, 37)
        Me.cmbFPago.TabIndex = 0
        '
        'cmbCajaAbierta
        '
        Me.cmbCajaAbierta.BackColor = System.Drawing.Color.White
        Me.cmbCajaAbierta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCajaAbierta.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCajaAbierta.FormattingEnabled = True
        Me.cmbCajaAbierta.Location = New System.Drawing.Point(256, 55)
        Me.cmbCajaAbierta.Name = "cmbCajaAbierta"
        Me.cmbCajaAbierta.Size = New System.Drawing.Size(519, 37)
        Me.cmbCajaAbierta.TabIndex = 1
        '
        'txtProveedor
        '
        Me.txtProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProveedor.Location = New System.Drawing.Point(256, 98)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Size = New System.Drawing.Size(519, 35)
        Me.txtProveedor.TabIndex = 2
        '
        'txtTipoComprobante
        '
        Me.txtTipoComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoComprobante.Location = New System.Drawing.Point(256, 139)
        Me.txtTipoComprobante.Name = "txtTipoComprobante"
        Me.txtTipoComprobante.Size = New System.Drawing.Size(519, 35)
        Me.txtTipoComprobante.TabIndex = 3
        '
        'mtxtNumComprobante
        '
        Me.mtxtNumComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtxtNumComprobante.Location = New System.Drawing.Point(256, 180)
        Me.mtxtNumComprobante.Mask = "0000-00000000"
        Me.mtxtNumComprobante.Name = "mtxtNumComprobante"
        Me.mtxtNumComprobante.Size = New System.Drawing.Size(519, 35)
        Me.mtxtNumComprobante.TabIndex = 4
        '
        'mtxtFechaComprobante
        '
        Me.mtxtFechaComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtxtFechaComprobante.Location = New System.Drawing.Point(256, 221)
        Me.mtxtFechaComprobante.Mask = "00/00/0000"
        Me.mtxtFechaComprobante.Name = "mtxtFechaComprobante"
        Me.mtxtFechaComprobante.Size = New System.Drawing.Size(519, 35)
        Me.mtxtFechaComprobante.TabIndex = 5
        '
        'txtImporte
        '
        Me.txtImporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporte.Location = New System.Drawing.Point(256, 262)
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.Size = New System.Drawing.Size(519, 35)
        Me.txtImporte.TabIndex = 6
        '
        'txtCuentaImputable
        '
        Me.txtCuentaImputable.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuentaImputable.Location = New System.Drawing.Point(256, 303)
        Me.txtCuentaImputable.Name = "txtCuentaImputable"
        Me.txtCuentaImputable.Size = New System.Drawing.Size(519, 35)
        Me.txtCuentaImputable.TabIndex = 7
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservaciones.Location = New System.Drawing.Point(256, 347)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(519, 110)
        Me.txtObservaciones.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(186, 29)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Forma de Pago:"
        '
        'lblVariable
        '
        Me.lblVariable.AutoSize = True
        Me.lblVariable.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVariable.Location = New System.Drawing.Point(12, 58)
        Me.lblVariable.Name = "lblVariable"
        Me.lblVariable.Size = New System.Drawing.Size(150, 29)
        Me.lblVariable.TabIndex = 10
        Me.lblVariable.Text = "Caja Abierta:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(132, 29)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Proveedor:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 142)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(166, 29)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Comprobante:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 183)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(198, 29)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "N° Comprobante:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 224)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(239, 29)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Fecha Comprobante:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 265)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(101, 29)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Importe:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 306)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(200, 29)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Cuenta Imputada:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(12, 347)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(147, 29)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Descripción:"
        '
        'brnFinalizar
        '
        Me.brnFinalizar.Location = New System.Drawing.Point(674, 463)
        Me.brnFinalizar.Name = "brnFinalizar"
        Me.brnFinalizar.Size = New System.Drawing.Size(101, 23)
        Me.brnFinalizar.TabIndex = 18
        Me.brnFinalizar.TabStop = False
        Me.brnFinalizar.Text = "&Finalizar"
        Me.brnFinalizar.UseVisualStyleBackColor = True
        '
        'txtCuentaBancaria
        '
        Me.txtCuentaBancaria.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuentaBancaria.Location = New System.Drawing.Point(256, 57)
        Me.txtCuentaBancaria.Name = "txtCuentaBancaria"
        Me.txtCuentaBancaria.Size = New System.Drawing.Size(519, 35)
        Me.txtCuentaBancaria.TabIndex = 1
        '
        'FrmAsientoGastos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(787, 500)
        Me.Controls.Add(Me.brnFinalizar)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblVariable)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtObservaciones)
        Me.Controls.Add(Me.txtCuentaImputable)
        Me.Controls.Add(Me.txtImporte)
        Me.Controls.Add(Me.mtxtFechaComprobante)
        Me.Controls.Add(Me.mtxtNumComprobante)
        Me.Controls.Add(Me.txtTipoComprobante)
        Me.Controls.Add(Me.txtProveedor)
        Me.Controls.Add(Me.cmbFPago)
        Me.Controls.Add(Me.txtCuentaBancaria)
        Me.Controls.Add(Me.cmbCajaAbierta)
        Me.Name = "FrmAsientoGastos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmAsientoGastos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbFPago As ComboBox
    Friend WithEvents cmbCajaAbierta As ComboBox
    Friend WithEvents txtProveedor As TextBox
    Friend WithEvents txtTipoComprobante As TextBox
    Friend WithEvents mtxtNumComprobante As MaskedTextBox
    Friend WithEvents mtxtFechaComprobante As MaskedTextBox
    Friend WithEvents txtImporte As TextBox
    Friend WithEvents txtCuentaImputable As TextBox
    Friend WithEvents txtObservaciones As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblVariable As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents brnFinalizar As Button
    Friend WithEvents txtCuentaBancaria As TextBox
End Class
