<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmOperaContratos
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btnExpandir = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.IdGC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Grupo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImpFacturado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImpCancelado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImpNoCancelado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.btnExpandir, Me.IdGC, Me.Grupo, Me.ImpFacturado, Me.ImpCancelado, Me.ImpNoCancelado})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(814, 197)
        Me.DataGridView1.TabIndex = 0
        '
        'btnExpandir
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        Me.btnExpandir.DefaultCellStyle = DataGridViewCellStyle1
        Me.btnExpandir.HeaderText = ""
        Me.btnExpandir.Name = "btnExpandir"
        Me.btnExpandir.ReadOnly = True
        Me.btnExpandir.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.btnExpandir.Text = "+"
        Me.btnExpandir.UseColumnTextForButtonValue = True
        Me.btnExpandir.Width = 24
        '
        'IdGC
        '
        Me.IdGC.DataPropertyName = "IdGC"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.IdGC.DefaultCellStyle = DataGridViewCellStyle2
        Me.IdGC.HeaderText = "IdGC"
        Me.IdGC.Name = "IdGC"
        Me.IdGC.ReadOnly = True
        Me.IdGC.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.IdGC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.IdGC.Width = 70
        '
        'Grupo
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        Me.Grupo.DefaultCellStyle = DataGridViewCellStyle3
        Me.Grupo.HeaderText = "Grupo"
        Me.Grupo.Name = "Grupo"
        Me.Grupo.ReadOnly = True
        Me.Grupo.Width = 250
        '
        'ImpFacturado
        '
        Me.ImpFacturado.DataPropertyName = "ImpFacturado"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.ImpFacturado.DefaultCellStyle = DataGridViewCellStyle4
        Me.ImpFacturado.HeaderText = "ImpFacturado"
        Me.ImpFacturado.Name = "ImpFacturado"
        Me.ImpFacturado.ReadOnly = True
        Me.ImpFacturado.Width = 150
        '
        'ImpCancelado
        '
        Me.ImpCancelado.DataPropertyName = "ImpCancelado"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.ImpCancelado.DefaultCellStyle = DataGridViewCellStyle5
        Me.ImpCancelado.HeaderText = "ImpCancelado"
        Me.ImpCancelado.Name = "ImpCancelado"
        Me.ImpCancelado.ReadOnly = True
        Me.ImpCancelado.Width = 150
        '
        'ImpNoCancelado
        '
        Me.ImpNoCancelado.DataPropertyName = "ImpNoCancelado"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.ImpNoCancelado.DefaultCellStyle = DataGridViewCellStyle6
        Me.ImpNoCancelado.HeaderText = "ImpNoCancelado"
        Me.ImpNoCancelado.Name = "ImpNoCancelado"
        Me.ImpNoCancelado.ReadOnly = True
        Me.ImpNoCancelado.Width = 150
        '
        'FrmOperaContratos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(814, 197)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "FrmOperaContratos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Estado de Cuenta Grupo de Contratos"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents btnExpandir As DataGridViewButtonColumn
    Friend WithEvents IdGC As DataGridViewTextBoxColumn
    Friend WithEvents Grupo As DataGridViewTextBoxColumn
    Friend WithEvents ImpFacturado As DataGridViewTextBoxColumn
    Friend WithEvents ImpCancelado As DataGridViewTextBoxColumn
    Friend WithEvents ImpNoCancelado As DataGridViewTextBoxColumn
End Class
