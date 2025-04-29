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
        Me.IVA.TabIndex = 47
        '
        'FrmClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(394, 356)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.IVA)
        Me.KeyPreview = True
        Me.Name = "FrmClientes"
        Me.Text = "Cliente"
        Me.Controls.SetChildIndex(Me.IVA, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label4 As Label
    Friend WithEvents IVA As ComboBox
End Class
