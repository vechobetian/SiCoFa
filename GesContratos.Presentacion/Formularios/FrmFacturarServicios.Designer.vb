<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmFacturarServicios
    Inherits System.Windows.Forms.Form

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
        Me.Aceptar = New System.Windows.Forms.Button()
        Me.Mensaje = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.lblProgressBar = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Aceptar
        '
        Me.Aceptar.Location = New System.Drawing.Point(224, 175)
        Me.Aceptar.Name = "Aceptar"
        Me.Aceptar.Size = New System.Drawing.Size(75, 23)
        Me.Aceptar.TabIndex = 36
        Me.Aceptar.TabStop = False
        Me.Aceptar.Text = "&Aceptar"
        Me.Aceptar.UseVisualStyleBackColor = True
        Me.Aceptar.Visible = False
        '
        'Mensaje
        '
        Me.Mensaje.AutoSize = True
        Me.Mensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Mensaje.Location = New System.Drawing.Point(12, 9)
        Me.Mensaje.Name = "Mensaje"
        Me.Mensaje.Size = New System.Drawing.Size(219, 60)
        Me.Mensaje.TabIndex = 37
        Me.Mensaje.Text = "Iniciando procesos....." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Aguarde un instante por favor" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 122)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(302, 23)
        Me.ProgressBar1.TabIndex = 38
        Me.ProgressBar1.Visible = False
        '
        'lblProgressBar
        '
        Me.lblProgressBar.AutoSize = True
        Me.lblProgressBar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProgressBar.Location = New System.Drawing.Point(42, 148)
        Me.lblProgressBar.Name = "lblProgressBar"
        Me.lblProgressBar.Size = New System.Drawing.Size(39, 13)
        Me.lblProgressBar.TabIndex = 39
        Me.lblProgressBar.Text = "Label1"
        Me.lblProgressBar.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblProgressBar.Visible = False
        '
        'FrmFacturarServicios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(334, 220)
        Me.Controls.Add(Me.lblProgressBar)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Mensaje)
        Me.Controls.Add(Me.Aceptar)
        Me.MaximizeBox = False
        Me.Name = "FrmFacturarServicios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Correo Electronico"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Aceptar As Button
    Friend WithEvents Mensaje As Label
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents lblProgressBar As Label
End Class
