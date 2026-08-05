<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRecetasBeneficiario
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DgvRecetas = New System.Windows.Forms.DataGridView()
        Me.NumReceta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaPrescripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Medicamentos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DgvRecetas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DgvRecetas
        '
        Me.DgvRecetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvRecetas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NumReceta, Me.FechaPrescripcion, Me.Medicamentos})
        Me.DgvRecetas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvRecetas.Location = New System.Drawing.Point(0, 0)
        Me.DgvRecetas.Name = "DgvRecetas"
        Me.DgvRecetas.Size = New System.Drawing.Size(800, 528)
        Me.DgvRecetas.TabIndex = 0
        '
        'NumReceta
        '
        Me.NumReceta.HeaderText = "Num.Receta"
        Me.NumReceta.Name = "NumReceta"
        Me.NumReceta.Width = 150
        '
        'FechaPrescripcion
        '
        DataGridViewCellStyle1.Format = "d"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.FechaPrescripcion.DefaultCellStyle = DataGridViewCellStyle1
        Me.FechaPrescripcion.HeaderText = "Fecha Receta"
        Me.FechaPrescripcion.Name = "FechaPrescripcion"
        '
        'Medicamentos
        '
        Me.Medicamentos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Medicamentos.HeaderText = "Medicamentos"
        Me.Medicamentos.Name = "Medicamentos"
        '
        'FrmRecetasBeneficiario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 528)
        Me.Controls.Add(Me.DgvRecetas)
        Me.Name = "FrmRecetasBeneficiario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Recetas Beneficiario"
        CType(Me.DgvRecetas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DgvRecetas As DataGridView
    Friend WithEvents NumReceta As DataGridViewTextBoxColumn
    Friend WithEvents FechaPrescripcion As DataGridViewTextBoxColumn
    Friend WithEvents Medicamentos As DataGridViewTextBoxColumn
End Class
