<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCajas1
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
        Dim DataGridViewCellStyle37 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle38 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle39 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle40 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle41 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle42 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.TipoOperacionEf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantOperacionesEf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImporteEf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblImporteCC = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblImportePE = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblImporteEfectivo = New System.Windows.Forms.Label()
        Me.DataGridView4 = New System.Windows.Forms.DataGridView()
        Me.TipoOperacionCC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantOperacionesCC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImporteCC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridView3 = New System.Windows.Forms.DataGridView()
        Me.MedioPE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantOperacionesPE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImportePE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.NCaja = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cierre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Apertura = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdCaja = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.DataGridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.AllowUserToResizeColumns = False
        Me.DataGridView2.AllowUserToResizeRows = False
        Me.DataGridView2.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TipoOperacionEf, Me.CantOperacionesEf, Me.ImporteEf})
        Me.DataGridView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView2.Location = New System.Drawing.Point(6, 45)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(620, 175)
        Me.DataGridView2.TabIndex = 1
        '
        'TipoOperacionEf
        '
        Me.TipoOperacionEf.DataPropertyName = "TipoOperacion"
        Me.TipoOperacionEf.HeaderText = "TipoOperacion"
        Me.TipoOperacionEf.Name = "TipoOperacionEf"
        Me.TipoOperacionEf.Width = 300
        '
        'CantOperacionesEf
        '
        Me.CantOperacionesEf.DataPropertyName = "CantOperaciones"
        DataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.CantOperacionesEf.DefaultCellStyle = DataGridViewCellStyle37
        Me.CantOperacionesEf.HeaderText = "Operaciones"
        Me.CantOperacionesEf.Name = "CantOperacionesEf"
        '
        'ImporteEf
        '
        Me.ImporteEf.DataPropertyName = "Importe"
        DataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle38.Format = "N2"
        DataGridViewCellStyle38.NullValue = Nothing
        Me.ImporteEf.DefaultCellStyle = DataGridViewCellStyle38
        Me.ImporteEf.HeaderText = "Importe"
        Me.ImporteEf.Name = "ImporteEf"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1245, 793)
        Me.Panel2.TabIndex = 1
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblImporteCC, 0, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.lblImportePE, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblImporteEfectivo, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.DataGridView2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.DataGridView4, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.DataGridView3, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(613, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 9
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761905!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.80952!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761905!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761905!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.80952!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761905!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761905!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.80952!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761905!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(632, 793)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'lblImporteCC
        '
        Me.lblImporteCC.AutoSize = True
        Me.lblImporteCC.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblImporteCC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteCC.Location = New System.Drawing.Point(567, 750)
        Me.lblImporteCC.Name = "lblImporteCC"
        Me.lblImporteCC.Size = New System.Drawing.Size(59, 40)
        Me.lblImporteCC.TabIndex = 9
        Me.lblImporteCC.Text = "$ 0,00"
        Me.lblImporteCC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 527)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(620, 36)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Cuenta Corriente"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblImportePE
        '
        Me.lblImportePE.AutoSize = True
        Me.lblImportePE.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblImportePE.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImportePE.Location = New System.Drawing.Point(567, 488)
        Me.lblImportePE.Name = "lblImportePE"
        Me.lblImportePE.Size = New System.Drawing.Size(59, 36)
        Me.lblImportePE.TabIndex = 7
        Me.lblImportePE.Text = "$ 0,00"
        Me.lblImportePE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 265)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(620, 36)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Medios de Pago Electrónico"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblImporteEfectivo
        '
        Me.lblImporteEfectivo.AutoSize = True
        Me.lblImporteEfectivo.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblImporteEfectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteEfectivo.Location = New System.Drawing.Point(567, 226)
        Me.lblImporteEfectivo.Name = "lblImporteEfectivo"
        Me.lblImporteEfectivo.Size = New System.Drawing.Size(59, 36)
        Me.lblImporteEfectivo.TabIndex = 5
        Me.lblImporteEfectivo.Text = "$ 0,00"
        Me.lblImporteEfectivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DataGridView4
        '
        Me.DataGridView4.AllowUserToAddRows = False
        Me.DataGridView4.AllowUserToDeleteRows = False
        Me.DataGridView4.AllowUserToResizeColumns = False
        Me.DataGridView4.AllowUserToResizeRows = False
        Me.DataGridView4.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView4.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TipoOperacionCC, Me.CantOperacionesCC, Me.ImporteCC})
        Me.DataGridView4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView4.Location = New System.Drawing.Point(6, 569)
        Me.DataGridView4.Name = "DataGridView4"
        Me.DataGridView4.Size = New System.Drawing.Size(620, 175)
        Me.DataGridView4.TabIndex = 3
        '
        'TipoOperacionCC
        '
        Me.TipoOperacionCC.DataPropertyName = "TipoOperacion"
        Me.TipoOperacionCC.HeaderText = "TipoOperacion"
        Me.TipoOperacionCC.Name = "TipoOperacionCC"
        Me.TipoOperacionCC.Width = 300
        '
        'CantOperacionesCC
        '
        Me.CantOperacionesCC.DataPropertyName = "CantOperaciones"
        DataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.CantOperacionesCC.DefaultCellStyle = DataGridViewCellStyle39
        Me.CantOperacionesCC.HeaderText = "Operaciones"
        Me.CantOperacionesCC.Name = "CantOperacionesCC"
        '
        'ImporteCC
        '
        Me.ImporteCC.DataPropertyName = "Importe"
        DataGridViewCellStyle40.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle40.Format = "N2"
        DataGridViewCellStyle40.NullValue = Nothing
        Me.ImporteCC.DefaultCellStyle = DataGridViewCellStyle40
        Me.ImporteCC.HeaderText = "Importe"
        Me.ImporteCC.Name = "ImporteCC"
        '
        'DataGridView3
        '
        Me.DataGridView3.AllowUserToAddRows = False
        Me.DataGridView3.AllowUserToDeleteRows = False
        Me.DataGridView3.AllowUserToResizeColumns = False
        Me.DataGridView3.AllowUserToResizeRows = False
        Me.DataGridView3.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView3.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MedioPE, Me.CantOperacionesPE, Me.ImportePE})
        Me.DataGridView3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView3.Location = New System.Drawing.Point(6, 307)
        Me.DataGridView3.Name = "DataGridView3"
        Me.DataGridView3.Size = New System.Drawing.Size(620, 175)
        Me.DataGridView3.TabIndex = 2
        '
        'MedioPE
        '
        Me.MedioPE.DataPropertyName = "MedioPE"
        Me.MedioPE.HeaderText = "Medio de Pago"
        Me.MedioPE.Name = "MedioPE"
        Me.MedioPE.Width = 300
        '
        'CantOperacionesPE
        '
        Me.CantOperacionesPE.DataPropertyName = "CantOperaciones"
        DataGridViewCellStyle41.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.CantOperacionesPE.DefaultCellStyle = DataGridViewCellStyle41
        Me.CantOperacionesPE.HeaderText = "Operaciones"
        Me.CantOperacionesPE.Name = "CantOperacionesPE"
        '
        'ImportePE
        '
        Me.ImportePE.DataPropertyName = "Importe"
        DataGridViewCellStyle42.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle42.Format = "N2"
        DataGridViewCellStyle42.NullValue = Nothing
        Me.ImportePE.DefaultCellStyle = DataGridViewCellStyle42
        Me.ImportePE.HeaderText = "Importe"
        Me.ImportePE.Name = "ImportePE"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(620, 36)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Operaciones en Efectivo"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.DataGridView1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(607, 793)
        Me.Panel1.TabIndex = 2
        '
        'NCaja
        '
        Me.NCaja.DataPropertyName = "NCaja"
        Me.NCaja.HeaderText = "NCaja"
        Me.NCaja.Name = "NCaja"
        Me.NCaja.Width = 80
        '
        'Estado
        '
        Me.Estado.DataPropertyName = "Estado"
        Me.Estado.HeaderText = "Estado"
        Me.Estado.Name = "Estado"
        '
        'Cierre
        '
        Me.Cierre.DataPropertyName = "Cierre"
        Me.Cierre.HeaderText = "Cierre"
        Me.Cierre.Name = "Cierre"
        Me.Cierre.Width = 150
        '
        'Apertura
        '
        Me.Apertura.DataPropertyName = "Apertura"
        Me.Apertura.HeaderText = "Apertura"
        Me.Apertura.Name = "Apertura"
        Me.Apertura.Width = 150
        '
        'IdCaja
        '
        Me.IdCaja.DataPropertyName = "IdCaja"
        Me.IdCaja.HeaderText = "IdCaja"
        Me.IdCaja.Name = "IdCaja"
        Me.IdCaja.Width = 70
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdCaja, Me.Apertura, Me.Cierre, Me.Estado, Me.NCaja})
        Me.DataGridView1.Location = New System.Drawing.Point(0, 45)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(607, 722)
        Me.DataGridView1.TabIndex = 2
        '
        'FrmCajas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1245, 793)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.MaximizeBox = False
        Me.Name = "FrmCajas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Movimientos de Caja"
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.DataGridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents DataGridView3 As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridView4 As DataGridView
    Friend WithEvents lblImporteCC As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblImportePE As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblImporteEfectivo As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TipoOperacionEf As DataGridViewTextBoxColumn
    Friend WithEvents CantOperacionesEf As DataGridViewTextBoxColumn
    Friend WithEvents ImporteEf As DataGridViewTextBoxColumn
    Friend WithEvents TipoOperacionCC As DataGridViewTextBoxColumn
    Friend WithEvents CantOperacionesCC As DataGridViewTextBoxColumn
    Friend WithEvents ImporteCC As DataGridViewTextBoxColumn
    Friend WithEvents MedioPE As DataGridViewTextBoxColumn
    Friend WithEvents CantOperacionesPE As DataGridViewTextBoxColumn
    Friend WithEvents ImportePE As DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As Panel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents IdCaja As DataGridViewTextBoxColumn
    Friend WithEvents Apertura As DataGridViewTextBoxColumn
    Friend WithEvents Cierre As DataGridViewTextBoxColumn
    Friend WithEvents Estado As DataGridViewTextBoxColumn
    Friend WithEvents NCaja As DataGridViewTextBoxColumn
End Class
