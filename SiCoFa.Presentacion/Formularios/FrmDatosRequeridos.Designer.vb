<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDatosRequeridos
    Inherits System.Windows.Forms.Form

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
        Me.chkNumRta = New System.Windows.Forms.CheckBox()
        Me.chkNumAf = New System.Windows.Forms.CheckBox()
        Me.chkDocumentoAf = New System.Windows.Forms.CheckBox()
        Me.chkPrescriptor = New System.Windows.Forms.CheckBox()
        Me.chkToken = New System.Windows.Forms.CheckBox()
        Me.lblPlanOS = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'chkNumRta
        '
        Me.chkNumRta.AutoSize = True
        Me.chkNumRta.Location = New System.Drawing.Point(12, 45)
        Me.chkNumRta.Name = "chkNumRta"
        Me.chkNumRta.Size = New System.Drawing.Size(116, 17)
        Me.chkNumRta.TabIndex = 0
        Me.chkNumRta.Text = "Número de Receta"
        Me.chkNumRta.UseVisualStyleBackColor = True
        '
        'chkNumAf
        '
        Me.chkNumAf.AutoSize = True
        Me.chkNumAf.Location = New System.Drawing.Point(12, 68)
        Me.chkNumAf.Name = "chkNumAf"
        Me.chkNumAf.Size = New System.Drawing.Size(115, 17)
        Me.chkNumAf.TabIndex = 1
        Me.chkNumAf.Text = "Número de Afiliado"
        Me.chkNumAf.UseVisualStyleBackColor = True
        '
        'chkDocumentoAf
        '
        Me.chkDocumentoAf.AutoSize = True
        Me.chkDocumentoAf.Location = New System.Drawing.Point(12, 91)
        Me.chkDocumentoAf.Name = "chkDocumentoAf"
        Me.chkDocumentoAf.Size = New System.Drawing.Size(118, 17)
        Me.chkDocumentoAf.TabIndex = 2
        Me.chkDocumentoAf.Text = "Documento Afiliado"
        Me.chkDocumentoAf.UseVisualStyleBackColor = True
        '
        'chkPrescriptor
        '
        Me.chkPrescriptor.AutoSize = True
        Me.chkPrescriptor.Location = New System.Drawing.Point(12, 114)
        Me.chkPrescriptor.Name = "chkPrescriptor"
        Me.chkPrescriptor.Size = New System.Drawing.Size(114, 17)
        Me.chkPrescriptor.TabIndex = 3
        Me.chkPrescriptor.Text = "Prescriptor Medico"
        Me.chkPrescriptor.UseVisualStyleBackColor = True
        '
        'chkToken
        '
        Me.chkToken.AutoSize = True
        Me.chkToken.Location = New System.Drawing.Point(12, 137)
        Me.chkToken.Name = "chkToken"
        Me.chkToken.Size = New System.Drawing.Size(57, 17)
        Me.chkToken.TabIndex = 4
        Me.chkToken.Text = "Token"
        Me.chkToken.UseVisualStyleBackColor = True
        '
        'lblPlanOS
        '
        Me.lblPlanOS.AutoSize = True
        Me.lblPlanOS.Location = New System.Drawing.Point(13, 13)
        Me.lblPlanOS.Name = "lblPlanOS"
        Me.lblPlanOS.Size = New System.Drawing.Size(46, 13)
        Me.lblPlanOS.TabIndex = 5
        Me.lblPlanOS.Text = "Plan OS"
        '
        'FrmDatosRequeridos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(243, 162)
        Me.Controls.Add(Me.lblPlanOS)
        Me.Controls.Add(Me.chkToken)
        Me.Controls.Add(Me.chkPrescriptor)
        Me.Controls.Add(Me.chkDocumentoAf)
        Me.Controls.Add(Me.chkNumAf)
        Me.Controls.Add(Me.chkNumRta)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmDatosRequeridos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Datos Requeridos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents chkNumRta As CheckBox
    Friend WithEvents chkNumAf As CheckBox
    Friend WithEvents chkDocumentoAf As CheckBox
    Friend WithEvents chkPrescriptor As CheckBox
    Friend WithEvents chkToken As CheckBox
    Friend WithEvents lblPlanOS As Label
End Class
