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
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.DatosCliente = New System.Windows.Forms.TabPage()
        Me.PanelCliente = New System.Windows.Forms.TabControl()
        Me.PanelCliente.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(401, 373)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Cuenta Corriente"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'DatosCliente
        '
        Me.DatosCliente.Location = New System.Drawing.Point(4, 22)
        Me.DatosCliente.Name = "DatosCliente"
        Me.DatosCliente.Padding = New System.Windows.Forms.Padding(3)
        Me.DatosCliente.Size = New System.Drawing.Size(401, 364)
        Me.DatosCliente.TabIndex = 0
        Me.DatosCliente.Text = "Datos Cliente"
        Me.DatosCliente.UseVisualStyleBackColor = True
        '
        'PanelCliente
        '
        Me.PanelCliente.Controls.Add(Me.DatosCliente)
        Me.PanelCliente.Controls.Add(Me.TabPage2)
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
        Me.PanelCliente.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents DatosCliente As TabPage
    Friend WithEvents PanelCliente As TabControl
End Class
