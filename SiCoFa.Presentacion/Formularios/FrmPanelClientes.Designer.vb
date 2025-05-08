<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPanelClientes
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
        Me.PanelCliente = New System.Windows.Forms.TabControl()
        Me.SuspendLayout()
        '
        'PanelCliente
        '
        Me.PanelCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelCliente.Location = New System.Drawing.Point(0, 0)
        Me.PanelCliente.Name = "PanelCliente"
        Me.PanelCliente.SelectedIndex = 0
        Me.PanelCliente.Size = New System.Drawing.Size(409, 390)
        Me.PanelCliente.TabIndex = 0
        '
        'FrmPanelClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(409, 390)
        Me.Controls.Add(Me.PanelCliente)
        Me.Name = "FrmPanelClientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmPanelClientes"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelCliente As TabControl
End Class
