<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UcSelectorUniversal
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.TxtSelector = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'TxtSelector
        '
        Me.TxtSelector.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtSelector.Location = New System.Drawing.Point(0, 0)
        Me.TxtSelector.Margin = New System.Windows.Forms.Padding(0)
        Me.TxtSelector.Name = "TxtSelector"
        Me.TxtSelector.Size = New System.Drawing.Size(318, 20)
        Me.TxtSelector.TabIndex = 0
        '
        'UcSelectorUniversal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TxtSelector)
        Me.Name = "UcSelectorUniversal"
        Me.Size = New System.Drawing.Size(318, 20)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtSelector As TextBox
End Class
