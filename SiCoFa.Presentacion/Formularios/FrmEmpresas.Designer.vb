<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmEmpresas
    'Inherits System.Windows.Forms.Form
    Inherits FrmEdicionPersonas

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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.IVA = New System.Windows.Forms.ComboBox()
        Me.IB = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 328)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 13)
        Me.Label4.TabIndex = 48
        Me.Label4.Text = "IVA:"
        '
        'IVA
        '
        Me.IVA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.IVA.FormattingEnabled = True
        Me.IVA.ItemHeight = 13
        Me.IVA.Location = New System.Drawing.Point(79, 325)
        Me.IVA.Name = "IVA"
        Me.IVA.Size = New System.Drawing.Size(300, 21)
        Me.IVA.TabIndex = 12
        '
        'IB
        '
        Me.IB.Location = New System.Drawing.Point(79, 352)
        Me.IB.Name = "IB"
        Me.IB.Size = New System.Drawing.Size(300, 20)
        Me.IB.TabIndex = 13
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(11, 355)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(58, 13)
        Me.Label13.TabIndex = 50
        Me.Label13.Text = "Ing.Brutos:"
        '
        'FrmEmpresas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(394, 381)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.IB)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.IVA)
        Me.KeyPreview = True
        Me.Name = "FrmEmpresas"
        Me.Text = "Empresa"
        Me.Controls.SetChildIndex(Me.IVA, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.IB, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label4 As Label
    Friend WithEvents IVA As ComboBox
    Friend WithEvents IB As TextBox
    Friend WithEvents Label13 As Label
End Class
