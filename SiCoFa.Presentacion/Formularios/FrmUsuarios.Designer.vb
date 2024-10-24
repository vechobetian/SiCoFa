<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmUsuarios
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Password = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 275)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Password:"
        '
        'Password
        '
        Me.Password.Location = New System.Drawing.Point(92, 272)
        Me.Password.Name = "Password"
        Me.Password.Size = New System.Drawing.Size(300, 20)
        Me.Password.TabIndex = 40
        '
        'FrmUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(404, 305)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Password)
        Me.Name = "FrmUsuario"
        Me.Text = "Usuario"
        Me.Controls.SetChildIndex(Me.Password, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents Password As TextBox
End Class
