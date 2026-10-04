<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRankingVentas
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
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvRanking = New System.Windows.Forms.DataGridView()
        Me.Articulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Puesto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PocentajeAcumulado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Unidades = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UnidadesDia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UnidadesSemana = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UnidadesMes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvRanking, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvRanking
        '
        Me.dgvRanking.AllowUserToAddRows = False
        Me.dgvRanking.AllowUserToDeleteRows = False
        Me.dgvRanking.AllowUserToResizeColumns = False
        Me.dgvRanking.AllowUserToResizeRows = False
        Me.dgvRanking.BackgroundColor = System.Drawing.Color.White
        Me.dgvRanking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRanking.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Articulo, Me.Puesto, Me.PocentajeAcumulado, Me.Importe, Me.Unidades, Me.UnidadesDia, Me.UnidadesSemana, Me.UnidadesMes})
        Me.dgvRanking.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvRanking.Location = New System.Drawing.Point(0, 0)
        Me.dgvRanking.Name = "dgvRanking"
        Me.dgvRanking.ReadOnly = True
        Me.dgvRanking.RowHeadersVisible = False
        Me.dgvRanking.RowHeadersWidth = 20
        Me.dgvRanking.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRanking.Size = New System.Drawing.Size(800, 450)
        Me.dgvRanking.TabIndex = 4
        Me.dgvRanking.TabStop = False
        '
        'Articulo
        '
        Me.Articulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Articulo.DataPropertyName = "Articulo"
        Me.Articulo.HeaderText = "Articulo"
        Me.Articulo.Name = "Articulo"
        Me.Articulo.ReadOnly = True
        '
        'Puesto
        '
        Me.Puesto.DataPropertyName = "Puesto"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Puesto.DefaultCellStyle = DataGridViewCellStyle15
        Me.Puesto.HeaderText = "Puesto"
        Me.Puesto.Name = "Puesto"
        Me.Puesto.ReadOnly = True
        Me.Puesto.Width = 80
        '
        'PocentajeAcumulado
        '
        Me.PocentajeAcumulado.DataPropertyName = "PorcentajeAcumulado"
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.PocentajeAcumulado.DefaultCellStyle = DataGridViewCellStyle16
        Me.PocentajeAcumulado.HeaderText = "% Acum."
        Me.PocentajeAcumulado.Name = "PocentajeAcumulado"
        Me.PocentajeAcumulado.ReadOnly = True
        Me.PocentajeAcumulado.Width = 80
        '
        'Importe
        '
        Me.Importe.DataPropertyName = "Importe"
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Importe.DefaultCellStyle = DataGridViewCellStyle17
        Me.Importe.HeaderText = "Importe"
        Me.Importe.Name = "Importe"
        Me.Importe.ReadOnly = True
        Me.Importe.Width = 60
        '
        'Unidades
        '
        Me.Unidades.DataPropertyName = "Unidades"
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Unidades.DefaultCellStyle = DataGridViewCellStyle18
        Me.Unidades.HeaderText = "Unidades"
        Me.Unidades.Name = "Unidades"
        Me.Unidades.ReadOnly = True
        Me.Unidades.Width = 120
        '
        'UnidadesDia
        '
        Me.UnidadesDia.DataPropertyName = "UnidadesDia"
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.UnidadesDia.DefaultCellStyle = DataGridViewCellStyle19
        Me.UnidadesDia.HeaderText = "Unid./Dia"
        Me.UnidadesDia.Name = "UnidadesDia"
        Me.UnidadesDia.ReadOnly = True
        Me.UnidadesDia.Width = 120
        '
        'UnidadesSemana
        '
        Me.UnidadesSemana.DataPropertyName = "UnidadesSemana"
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.UnidadesSemana.DefaultCellStyle = DataGridViewCellStyle20
        Me.UnidadesSemana.HeaderText = "Unid./Semana"
        Me.UnidadesSemana.Name = "UnidadesSemana"
        Me.UnidadesSemana.ReadOnly = True
        Me.UnidadesSemana.Width = 120
        '
        'UnidadesMes
        '
        Me.UnidadesMes.DataPropertyName = "UnidadesMes"
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.UnidadesMes.DefaultCellStyle = DataGridViewCellStyle21
        Me.UnidadesMes.HeaderText = "Unid./Mes"
        Me.UnidadesMes.Name = "UnidadesMes"
        Me.UnidadesMes.ReadOnly = True
        Me.UnidadesMes.Width = 120
        '
        'FrmRankingVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.dgvRanking)
        Me.Name = "FrmRankingVentas"
        Me.Text = "Ranking de Ventas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvRanking, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvRanking As DataGridView
    Friend WithEvents Articulo As DataGridViewTextBoxColumn
    Friend WithEvents Puesto As DataGridViewTextBoxColumn
    Friend WithEvents PocentajeAcumulado As DataGridViewTextBoxColumn
    Friend WithEvents Importe As DataGridViewTextBoxColumn
    Friend WithEvents Unidades As DataGridViewTextBoxColumn
    Friend WithEvents UnidadesDia As DataGridViewTextBoxColumn
    Friend WithEvents UnidadesSemana As DataGridViewTextBoxColumn
    Friend WithEvents UnidadesMes As DataGridViewTextBoxColumn
End Class
