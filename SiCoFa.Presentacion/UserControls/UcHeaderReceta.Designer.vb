<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UcHeaderReceta
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
        Me.lblPlanReceta = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblPlanReceta
        '
        Me.lblPlanReceta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPlanReceta.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlanReceta.Location = New System.Drawing.Point(0, 0)
        Me.lblPlanReceta.Name = "lblPlanReceta"
        Me.lblPlanReceta.Size = New System.Drawing.Size(1178, 25)
        Me.lblPlanReceta.TabIndex = 0
        Me.lblPlanReceta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UcHeaderReceta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblPlanReceta)
        Me.Name = "UcHeaderReceta"
        Me.Size = New System.Drawing.Size(1178, 25)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblPlanReceta As Label
End Class
