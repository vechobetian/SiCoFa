<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmIngresoMomientosCB
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
        Me.txtCuentaBancaria = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnMostrarComprobantes = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.txtResumen = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtCuentaBancaria
        '
        Me.txtCuentaBancaria.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuentaBancaria.Location = New System.Drawing.Point(219, 12)
        Me.txtCuentaBancaria.Name = "txtCuentaBancaria"
        Me.txtCuentaBancaria.Size = New System.Drawing.Size(519, 35)
        Me.txtCuentaBancaria.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(201, 29)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Cuenta Corriente:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(122, 29)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Resumen:"
        '
        'btnMostrarComprobantes
        '
        Me.btnMostrarComprobantes.Location = New System.Drawing.Point(593, 104)
        Me.btnMostrarComprobantes.Name = "btnMostrarComprobantes"
        Me.btnMostrarComprobantes.Size = New System.Drawing.Size(131, 23)
        Me.btnMostrarComprobantes.TabIndex = 3
        Me.btnMostrarComprobantes.Text = "&Mostrar Comprobantes"
        Me.btnMostrarComprobantes.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(30, 108)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(183, 17)
        Me.CheckBox1.TabIndex = 15
        Me.CheckBox1.Text = "Mostrar Operaciones Canceladas"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'txtResumen
        '
        Me.txtResumen.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtResumen.Location = New System.Drawing.Point(219, 53)
        Me.txtResumen.Name = "txtResumen"
        Me.txtResumen.Size = New System.Drawing.Size(519, 35)
        Me.txtResumen.TabIndex = 2
        '
        'FrmIngresoMomientosCB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(750, 143)
        Me.Controls.Add(Me.txtResumen)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.btnMostrarComprobantes)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCuentaBancaria)
        Me.Name = "FrmIngresoMomientosCB"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Comprobantes Emitidos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCuentaBancaria As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents btnMostrarComprobantes As Button
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents txtResumen As TextBox
End Class
