<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOperacionesCC
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
        Me.txtCuentaCorriente = New System.Windows.Forms.TextBox()
        Me.txtResumenImputado = New System.Windows.Forms.TextBox()
        Me.txtImporte = New System.Windows.Forms.TextBox()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.lblOperacion = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.brnFinalizar = New System.Windows.Forms.Button()
        Me.txtOperacion = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtCuentaCorriente
        '
        Me.txtCuentaCorriente.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuentaCorriente.Location = New System.Drawing.Point(256, 53)
        Me.txtCuentaCorriente.Name = "txtCuentaCorriente"
        Me.txtCuentaCorriente.Size = New System.Drawing.Size(519, 35)
        Me.txtCuentaCorriente.TabIndex = 2
        '
        'txtResumenImputado
        '
        Me.txtResumenImputado.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtResumenImputado.Location = New System.Drawing.Point(256, 94)
        Me.txtResumenImputado.Name = "txtResumenImputado"
        Me.txtResumenImputado.Size = New System.Drawing.Size(519, 35)
        Me.txtResumenImputado.TabIndex = 3
        '
        'txtImporte
        '
        Me.txtImporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporte.Location = New System.Drawing.Point(256, 135)
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.Size = New System.Drawing.Size(519, 35)
        Me.txtImporte.TabIndex = 6
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservaciones.Location = New System.Drawing.Point(256, 302)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(519, 110)
        Me.txtObservaciones.TabIndex = 8
        '
        'lblOperacion
        '
        Me.lblOperacion.AutoSize = True
        Me.lblOperacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOperacion.Location = New System.Drawing.Point(12, 13)
        Me.lblOperacion.Name = "lblOperacion"
        Me.lblOperacion.Size = New System.Drawing.Size(132, 29)
        Me.lblOperacion.TabIndex = 10
        Me.lblOperacion.Text = "Operación:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(201, 29)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Cuenta Corriente:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 97)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(228, 29)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Resumen Imputado:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 138)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(101, 29)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Importe:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(12, 302)
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
        'txtOperacion
        '
        Me.txtOperacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOperacion.Location = New System.Drawing.Point(256, 12)
        Me.txtOperacion.Name = "txtOperacion"
        Me.txtOperacion.Size = New System.Drawing.Size(519, 35)
        Me.txtOperacion.TabIndex = 1
        '
        'FrmOperacionesCC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(787, 500)
        Me.Controls.Add(Me.brnFinalizar)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblOperacion)
        Me.Controls.Add(Me.txtObservaciones)
        Me.Controls.Add(Me.txtImporte)
        Me.Controls.Add(Me.txtResumenImputado)
        Me.Controls.Add(Me.txtCuentaCorriente)
        Me.Controls.Add(Me.txtOperacion)
        Me.Name = "FrmOperacionesCC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmAsientoGastos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCuentaCorriente As TextBox
    Friend WithEvents txtResumenImputado As TextBox
    Friend WithEvents txtImporte As TextBox
    Friend WithEvents txtObservaciones As TextBox
    Friend WithEvents lblOperacion As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents brnFinalizar As Button
    Friend WithEvents txtOperacion As TextBox
End Class
