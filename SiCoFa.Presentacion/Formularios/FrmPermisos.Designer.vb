<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPermisos
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
        Me.tvPermisos = New System.Windows.Forms.TreeView()
        Me.SuspendLayout()
        '
        'tvPermisos
        '
        Me.tvPermisos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvPermisos.Location = New System.Drawing.Point(0, 0)
        Me.tvPermisos.Name = "tvPermisos"
        Me.tvPermisos.Size = New System.Drawing.Size(800, 504)
        Me.tvPermisos.TabIndex = 0
        '
        'FrmPermisos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 504)
        Me.Controls.Add(Me.tvPermisos)
        Me.Name = "FrmPermisos"
        Me.Text = "FrmPermisos"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tvPermisos As TreeView
End Class
