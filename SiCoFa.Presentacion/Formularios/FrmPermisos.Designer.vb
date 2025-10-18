<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPermisos
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
        Me.flpPermisos = New System.Windows.Forms.FlowLayoutPanel()
        Me.SuspendLayout()
        '
        'flpPermisos
        '
        Me.flpPermisos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpPermisos.Location = New System.Drawing.Point(0, 0)
        Me.flpPermisos.Name = "flpPermisos"
        Me.flpPermisos.Size = New System.Drawing.Size(800, 661)
        Me.flpPermisos.TabIndex = 0
        '
        'FrmPermisos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 661)
        Me.Controls.Add(Me.flpPermisos)
        Me.Name = "FrmPermisos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmPermisos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents flpPermisos As FlowLayoutPanel
End Class
