<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCajas
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.IdCaja = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Apertura = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cierre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NCaja = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DetalleOperacionesEfectivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DetallePagoElectronicoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DetalleCuentaCorrienteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblImporteCC = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblImportePE = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblImporteEfectivo = New System.Windows.Forms.Label()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.TipoOperacionEf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantOperacionesEf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImporteEf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridView4 = New System.Windows.Forms.DataGridView()
        Me.TipoOperacionCC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantOperacionesCC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImporteCC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridView3 = New System.Windows.Forms.DataGridView()
        Me.MedioPE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantOperacionesPE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImportePE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EstadoTransaccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TableLayoutPanel2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1262, 773)
        Me.SplitContainer1.SplitterDistance = 629
        Me.SplitContainer1.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.DataGridView1, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.MenuStrip1, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.786546!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95.21346!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(629, 773)
        Me.TableLayoutPanel2.TabIndex = 0
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
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(6, 45)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(617, 722)
        Me.DataGridView1.TabIndex = 4
        '
        'IdCaja
        '
        Me.IdCaja.DataPropertyName = "IdCaja"
        Me.IdCaja.HeaderText = "IdCaja"
        Me.IdCaja.Name = "IdCaja"
        Me.IdCaja.ReadOnly = True
        Me.IdCaja.Width = 70
        '
        'Apertura
        '
        Me.Apertura.DataPropertyName = "Apertura"
        Me.Apertura.HeaderText = "Apertura"
        Me.Apertura.Name = "Apertura"
        Me.Apertura.ReadOnly = True
        Me.Apertura.Width = 150
        '
        'Cierre
        '
        Me.Cierre.DataPropertyName = "Cierre"
        Me.Cierre.HeaderText = "Cierre"
        Me.Cierre.Name = "Cierre"
        Me.Cierre.ReadOnly = True
        Me.Cierre.Width = 150
        '
        'Estado
        '
        Me.Estado.DataPropertyName = "Estado"
        Me.Estado.HeaderText = "Estado"
        Me.Estado.Name = "Estado"
        Me.Estado.ReadOnly = True
        '
        'NCaja
        '
        Me.NCaja.DataPropertyName = "NCaja"
        Me.NCaja.HeaderText = "NCaja"
        Me.NCaja.Name = "NCaja"
        Me.NCaja.ReadOnly = True
        Me.NCaja.Width = 80
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.VerToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(3, 3)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(623, 24)
        Me.MenuStrip1.TabIndex = 5
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(92, 20)
        Me.ToolStripMenuItem1.Text = "&Cierre de Caja"
        '
        'VerToolStripMenuItem
        '
        Me.VerToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DetalleOperacionesEfectivoToolStripMenuItem, Me.DetallePagoElectronicoToolStripMenuItem, Me.DetalleCuentaCorrienteToolStripMenuItem})
        Me.VerToolStripMenuItem.Name = "VerToolStripMenuItem"
        Me.VerToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.VerToolStripMenuItem.Text = "Ver"
        '
        'DetalleOperacionesEfectivoToolStripMenuItem
        '
        Me.DetalleOperacionesEfectivoToolStripMenuItem.Name = "DetalleOperacionesEfectivoToolStripMenuItem"
        Me.DetalleOperacionesEfectivoToolStripMenuItem.Size = New System.Drawing.Size(224, 22)
        Me.DetalleOperacionesEfectivoToolStripMenuItem.Text = "Detalle Operaciones Efectivo"
        '
        'DetallePagoElectronicoToolStripMenuItem
        '
        Me.DetallePagoElectronicoToolStripMenuItem.Name = "DetallePagoElectronicoToolStripMenuItem"
        Me.DetallePagoElectronicoToolStripMenuItem.Size = New System.Drawing.Size(224, 22)
        Me.DetallePagoElectronicoToolStripMenuItem.Text = "Detalle Pago Electronico"
        '
        'DetalleCuentaCorrienteToolStripMenuItem
        '
        Me.DetalleCuentaCorrienteToolStripMenuItem.Name = "DetalleCuentaCorrienteToolStripMenuItem"
        Me.DetalleCuentaCorrienteToolStripMenuItem.Size = New System.Drawing.Size(224, 22)
        Me.DetalleCuentaCorrienteToolStripMenuItem.Text = "Detalle Cuenta Corriente"
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
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
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
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(629, 773)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'lblImporteCC
        '
        Me.lblImporteCC.AutoSize = True
        Me.lblImporteCC.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblImporteCC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteCC.Location = New System.Drawing.Point(564, 730)
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
        Me.Label5.Location = New System.Drawing.Point(6, 513)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(617, 35)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Cuenta Corriente"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblImportePE
        '
        Me.lblImportePE.AutoSize = True
        Me.lblImportePE.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblImportePE.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImportePE.Location = New System.Drawing.Point(564, 475)
        Me.lblImportePE.Name = "lblImportePE"
        Me.lblImportePE.Size = New System.Drawing.Size(59, 35)
        Me.lblImportePE.TabIndex = 7
        Me.lblImportePE.Text = "$ 0,00"
        Me.lblImportePE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 258)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(617, 35)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Medios de Pago Electrónico"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblImporteEfectivo
        '
        Me.lblImporteEfectivo.AutoSize = True
        Me.lblImporteEfectivo.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblImporteEfectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteEfectivo.Location = New System.Drawing.Point(564, 220)
        Me.lblImporteEfectivo.Name = "lblImporteEfectivo"
        Me.lblImporteEfectivo.Size = New System.Drawing.Size(59, 35)
        Me.lblImporteEfectivo.TabIndex = 5
        Me.lblImporteEfectivo.Text = "$ 0,00"
        Me.lblImporteEfectivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.DataGridView2.Location = New System.Drawing.Point(6, 44)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView2.Size = New System.Drawing.Size(617, 170)
        Me.DataGridView2.TabIndex = 1
        '
        'TipoOperacionEf
        '
        Me.TipoOperacionEf.DataPropertyName = "TipoOperacion"
        Me.TipoOperacionEf.HeaderText = "TipoOperacion"
        Me.TipoOperacionEf.Name = "TipoOperacionEf"
        Me.TipoOperacionEf.ReadOnly = True
        Me.TipoOperacionEf.Width = 300
        '
        'CantOperacionesEf
        '
        Me.CantOperacionesEf.DataPropertyName = "CantOperaciones"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.CantOperacionesEf.DefaultCellStyle = DataGridViewCellStyle1
        Me.CantOperacionesEf.HeaderText = "Operaciones"
        Me.CantOperacionesEf.Name = "CantOperacionesEf"
        Me.CantOperacionesEf.ReadOnly = True
        '
        'ImporteEf
        '
        Me.ImporteEf.DataPropertyName = "Importe"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.ImporteEf.DefaultCellStyle = DataGridViewCellStyle2
        Me.ImporteEf.HeaderText = "Importe"
        Me.ImporteEf.Name = "ImporteEf"
        Me.ImporteEf.ReadOnly = True
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
        Me.DataGridView4.Location = New System.Drawing.Point(6, 554)
        Me.DataGridView4.Name = "DataGridView4"
        Me.DataGridView4.ReadOnly = True
        Me.DataGridView4.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView4.Size = New System.Drawing.Size(617, 170)
        Me.DataGridView4.TabIndex = 3
        '
        'TipoOperacionCC
        '
        Me.TipoOperacionCC.DataPropertyName = "TipoOperacion"
        Me.TipoOperacionCC.HeaderText = "TipoOperacion"
        Me.TipoOperacionCC.Name = "TipoOperacionCC"
        Me.TipoOperacionCC.ReadOnly = True
        Me.TipoOperacionCC.Width = 300
        '
        'CantOperacionesCC
        '
        Me.CantOperacionesCC.DataPropertyName = "CantOperaciones"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.CantOperacionesCC.DefaultCellStyle = DataGridViewCellStyle3
        Me.CantOperacionesCC.HeaderText = "Operaciones"
        Me.CantOperacionesCC.Name = "CantOperacionesCC"
        Me.CantOperacionesCC.ReadOnly = True
        '
        'ImporteCC
        '
        Me.ImporteCC.DataPropertyName = "Importe"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.ImporteCC.DefaultCellStyle = DataGridViewCellStyle4
        Me.ImporteCC.HeaderText = "Importe"
        Me.ImporteCC.Name = "ImporteCC"
        Me.ImporteCC.ReadOnly = True
        '
        'DataGridView3
        '
        Me.DataGridView3.AllowUserToAddRows = False
        Me.DataGridView3.AllowUserToDeleteRows = False
        Me.DataGridView3.AllowUserToResizeColumns = False
        Me.DataGridView3.AllowUserToResizeRows = False
        Me.DataGridView3.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView3.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MedioPE, Me.CantOperacionesPE, Me.ImportePE, Me.EstadoTransaccion})
        Me.DataGridView3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView3.Location = New System.Drawing.Point(6, 299)
        Me.DataGridView3.Name = "DataGridView3"
        Me.DataGridView3.ReadOnly = True
        Me.DataGridView3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView3.Size = New System.Drawing.Size(617, 170)
        Me.DataGridView3.TabIndex = 2
        '
        'MedioPE
        '
        Me.MedioPE.DataPropertyName = "MedioPE"
        Me.MedioPE.HeaderText = "Medio de Pago"
        Me.MedioPE.Name = "MedioPE"
        Me.MedioPE.ReadOnly = True
        Me.MedioPE.Width = 300
        '
        'CantOperacionesPE
        '
        Me.CantOperacionesPE.DataPropertyName = "CantOperaciones"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.CantOperacionesPE.DefaultCellStyle = DataGridViewCellStyle5
        Me.CantOperacionesPE.HeaderText = "Operaciones"
        Me.CantOperacionesPE.Name = "CantOperacionesPE"
        Me.CantOperacionesPE.ReadOnly = True
        '
        'ImportePE
        '
        Me.ImportePE.DataPropertyName = "Importe"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.ImportePE.DefaultCellStyle = DataGridViewCellStyle6
        Me.ImportePE.HeaderText = "Importe"
        Me.ImportePE.Name = "ImportePE"
        Me.ImportePE.ReadOnly = True
        '
        'EstadoTransaccion
        '
        Me.EstadoTransaccion.DataPropertyName = "EstadoTransaccion"
        Me.EstadoTransaccion.HeaderText = "EstadoTransaccion"
        Me.EstadoTransaccion.Name = "EstadoTransaccion"
        Me.EstadoTransaccion.ReadOnly = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(617, 35)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Operaciones en Efectivo"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmCajas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1262, 773)
        Me.Controls.Add(Me.SplitContainer1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FrmCajas"
        Me.Text = "Movimiento de Cajas"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents lblImporteCC As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblImportePE As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblImporteEfectivo As Label
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents TipoOperacionEf As DataGridViewTextBoxColumn
    Friend WithEvents CantOperacionesEf As DataGridViewTextBoxColumn
    Friend WithEvents ImporteEf As DataGridViewTextBoxColumn
    Friend WithEvents DataGridView4 As DataGridView
    Friend WithEvents TipoOperacionCC As DataGridViewTextBoxColumn
    Friend WithEvents CantOperacionesCC As DataGridViewTextBoxColumn
    Friend WithEvents ImporteCC As DataGridViewTextBoxColumn
    Friend WithEvents DataGridView3 As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents IdCaja As DataGridViewTextBoxColumn
    Friend WithEvents Apertura As DataGridViewTextBoxColumn
    Friend WithEvents Cierre As DataGridViewTextBoxColumn
    Friend WithEvents Estado As DataGridViewTextBoxColumn
    Friend WithEvents NCaja As DataGridViewTextBoxColumn
    Friend WithEvents MedioPE As DataGridViewTextBoxColumn
    Friend WithEvents CantOperacionesPE As DataGridViewTextBoxColumn
    Friend WithEvents ImportePE As DataGridViewTextBoxColumn
    Friend WithEvents EstadoTransaccion As DataGridViewTextBoxColumn
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents VerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DetalleOperacionesEfectivoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DetallePagoElectronicoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DetalleCuentaCorrienteToolStripMenuItem As ToolStripMenuItem
End Class
