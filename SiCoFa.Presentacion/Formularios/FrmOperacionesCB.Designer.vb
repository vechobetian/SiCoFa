<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOperacionesCB
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
        Me.mtxtFechaComprobante = New System.Windows.Forms.MaskedTextBox()
        Me.txtImporte = New System.Windows.Forms.TextBox()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.lblCBDestino = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.brnFinalizar = New System.Windows.Forms.Button()
        Me.lblOperacion = New System.Windows.Forms.Label()
        Me.txtOperacion = New System.Windows.Forms.TextBox()
        Me.lblCBOrigen = New System.Windows.Forms.Label()
        Me.txtCBOrigen = New System.Windows.Forms.TextBox()
        Me.txtNumComprobante = New System.Windows.Forms.TextBox()
        Me.txtCBDestino = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'mtxtFechaComprobante
        '
        Me.mtxtFechaComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtxtFechaComprobante.Location = New System.Drawing.Point(257, 175)
        Me.mtxtFechaComprobante.Mask = "00/00/0000"
        Me.mtxtFechaComprobante.Name = "mtxtFechaComprobante"
        Me.mtxtFechaComprobante.Size = New System.Drawing.Size(519, 35)
        Me.mtxtFechaComprobante.TabIndex = 6
        '
        'txtImporte
        '
        Me.txtImporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporte.Location = New System.Drawing.Point(257, 216)
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.Size = New System.Drawing.Size(519, 35)
        Me.txtImporte.TabIndex = 7
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservaciones.Location = New System.Drawing.Point(257, 257)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(519, 110)
        Me.txtObservaciones.TabIndex = 9
        '
        'lblCBDestino
        '
        Me.lblCBDestino.AutoSize = True
        Me.lblCBDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCBDestino.Location = New System.Drawing.Point(15, 96)
        Me.lblCBDestino.Name = "lblCBDestino"
        Me.lblCBDestino.Size = New System.Drawing.Size(183, 29)
        Me.lblCBDestino.TabIndex = 10
        Me.lblCBDestino.Text = "Cuenta Destino:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(15, 137)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(198, 29)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "N° Comprobante:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(15, 178)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(239, 29)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Fecha Comprobante:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(15, 219)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(101, 29)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Importe:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(15, 262)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(147, 29)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Descripción:"
        '
        'brnFinalizar
        '
        Me.brnFinalizar.Location = New System.Drawing.Point(674, 378)
        Me.brnFinalizar.Name = "brnFinalizar"
        Me.brnFinalizar.Size = New System.Drawing.Size(101, 23)
        Me.brnFinalizar.TabIndex = 10
        Me.brnFinalizar.TabStop = False
        Me.brnFinalizar.Text = "&Finalizar"
        Me.brnFinalizar.UseVisualStyleBackColor = True
        '
        'lblOperacion
        '
        Me.lblOperacion.AutoSize = True
        Me.lblOperacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOperacion.Location = New System.Drawing.Point(15, 15)
        Me.lblOperacion.Name = "lblOperacion"
        Me.lblOperacion.Size = New System.Drawing.Size(132, 29)
        Me.lblOperacion.TabIndex = 20
        Me.lblOperacion.Text = "Operación:"
        '
        'txtOperacion
        '
        Me.txtOperacion.Enabled = False
        Me.txtOperacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOperacion.Location = New System.Drawing.Point(256, 12)
        Me.txtOperacion.Name = "txtOperacion"
        Me.txtOperacion.Size = New System.Drawing.Size(519, 35)
        Me.txtOperacion.TabIndex = 0
        '
        'lblCBOrigen
        '
        Me.lblCBOrigen.AutoSize = True
        Me.lblCBOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCBOrigen.Location = New System.Drawing.Point(15, 56)
        Me.lblCBOrigen.Name = "lblCBOrigen"
        Me.lblCBOrigen.Size = New System.Drawing.Size(195, 29)
        Me.lblCBOrigen.TabIndex = 22
        Me.lblCBOrigen.Text = "Cuenta Bancaria:"
        '
        'txtCBOrigen
        '
        Me.txtCBOrigen.Enabled = False
        Me.txtCBOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCBOrigen.Location = New System.Drawing.Point(256, 53)
        Me.txtCBOrigen.Name = "txtCBOrigen"
        Me.txtCBOrigen.Size = New System.Drawing.Size(519, 35)
        Me.txtCBOrigen.TabIndex = 1
        Me.txtCBOrigen.TabStop = False
        '
        'txtNumComprobante
        '
        Me.txtNumComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumComprobante.Location = New System.Drawing.Point(256, 134)
        Me.txtNumComprobante.Name = "txtNumComprobante"
        Me.txtNumComprobante.Size = New System.Drawing.Size(519, 35)
        Me.txtNumComprobante.TabIndex = 5
        '
        'txtCBDestino
        '
        Me.txtCBDestino.Enabled = False
        Me.txtCBDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCBDestino.Location = New System.Drawing.Point(256, 93)
        Me.txtCBDestino.Name = "txtCBDestino"
        Me.txtCBDestino.Size = New System.Drawing.Size(519, 35)
        Me.txtCBDestino.TabIndex = 2
        '
        'FrmOperacionesCB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(787, 409)
        Me.Controls.Add(Me.txtNumComprobante)
        Me.Controls.Add(Me.lblCBOrigen)
        Me.Controls.Add(Me.txtCBOrigen)
        Me.Controls.Add(Me.lblOperacion)
        Me.Controls.Add(Me.txtOperacion)
        Me.Controls.Add(Me.brnFinalizar)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblCBDestino)
        Me.Controls.Add(Me.txtObservaciones)
        Me.Controls.Add(Me.txtImporte)
        Me.Controls.Add(Me.mtxtFechaComprobante)
        Me.Controls.Add(Me.txtCBDestino)
        Me.Name = "FrmOperacionesCB"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmAsientoGastos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mtxtFechaComprobante As MaskedTextBox
    Friend WithEvents txtImporte As TextBox
    Friend WithEvents txtObservaciones As TextBox
    Friend WithEvents lblCBDestino As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents brnFinalizar As Button
    Friend WithEvents lblOperacion As Label
    Friend WithEvents txtOperacion As TextBox
    Friend WithEvents lblCBOrigen As Label
    Friend WithEvents txtCBOrigen As TextBox
    Friend WithEvents txtNumComprobante As TextBox
    Friend WithEvents txtCBDestino As TextBox
End Class
