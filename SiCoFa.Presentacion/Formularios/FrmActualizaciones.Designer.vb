<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmActualizaciones
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
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.dgvActualizaciones = New System.Windows.Forms.DataGridView()
        Me.btnDescargar = New System.Windows.Forms.Button()
        Me.btnProcesar = New System.Windows.Forms.Button()
        CType(Me.dgvActualizaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Location = New System.Drawing.Point(28, 9)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(39, 13)
        Me.lblEstado.TabIndex = 3
        Me.lblEstado.Text = "Label1"
        '
        'dgvActualizaciones
        '
        Me.dgvActualizaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvActualizaciones.Location = New System.Drawing.Point(31, 54)
        Me.dgvActualizaciones.Name = "dgvActualizaciones"
        Me.dgvActualizaciones.Size = New System.Drawing.Size(543, 337)
        Me.dgvActualizaciones.TabIndex = 4
        '
        'btnDescargar
        '
        Me.btnDescargar.Location = New System.Drawing.Point(454, 412)
        Me.btnDescargar.Name = "btnDescargar"
        Me.btnDescargar.Size = New System.Drawing.Size(120, 26)
        Me.btnDescargar.TabIndex = 5
        Me.btnDescargar.Text = "Descargar"
        Me.btnDescargar.UseVisualStyleBackColor = True
        '
        'btnProcesar
        '
        Me.btnProcesar.Location = New System.Drawing.Point(454, 412)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(120, 26)
        Me.btnProcesar.TabIndex = 6
        Me.btnProcesar.Text = "Procesar"
        Me.btnProcesar.UseVisualStyleBackColor = True
        '
        'FrmActualizaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(601, 450)
        Me.Controls.Add(Me.btnProcesar)
        Me.Controls.Add(Me.btnDescargar)
        Me.Controls.Add(Me.dgvActualizaciones)
        Me.Controls.Add(Me.lblEstado)
        Me.Name = "FrmActualizaciones"
        Me.Text = "FrmActualizaciones"
        CType(Me.dgvActualizaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblEstado As Label
    Friend WithEvents dgvActualizaciones As DataGridView
    Friend WithEvents btnDescargar As Button
    Friend WithEvents btnProcesar As Button
End Class
