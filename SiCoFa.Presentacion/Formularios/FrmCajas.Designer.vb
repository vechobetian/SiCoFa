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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.tlpCajas = New System.Windows.Forms.TableLayoutPanel()
        Me.dgvCajas = New System.Windows.Forms.DataGridView()
        Me.IdCaja = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Apertura = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cierre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NCaja = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnuOperaciones = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCierreCaja = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRetiroEfectivo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuVer = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDetalleEF = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDetallePE = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDetalleCC = New System.Windows.Forms.ToolStripMenuItem()
        Me.tlpDetalleCaja = New System.Windows.Forms.TableLayoutPanel()
        Me.lblImporteRecetas = New System.Windows.Forms.Label()
        Me.dgvOperacionesObraSociales = New System.Windows.Forms.DataGridView()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantRecetas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImporteTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImporteOS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImporteAf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblTituloRecetas = New System.Windows.Forms.Label()
        Me.lblImporteCC = New System.Windows.Forms.Label()
        Me.lblTituloOperacionesCuentaCorriente = New System.Windows.Forms.Label()
        Me.lblImportePE = New System.Windows.Forms.Label()
        Me.lblTituloOperacionesMediosPagoElectronico = New System.Windows.Forms.Label()
        Me.lblImporteEfectivo = New System.Windows.Forms.Label()
        Me.dgvOperacionesEfectivo = New System.Windows.Forms.DataGridView()
        Me.TipoOperacionEf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantOperacionesEf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImporteEf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvOperacionesCuentaCorriente = New System.Windows.Forms.DataGridView()
        Me.TipoOperacionCC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantOperacionesCC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImporteCC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvOperacionesMediosPagoElectronico = New System.Windows.Forms.DataGridView()
        Me.MedioPE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantOperacionesPE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImportePE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EstadoTransaccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblTituloOperacionesEfectivo = New System.Windows.Forms.Label()
        Me.mnuDetalleOS = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.tlpCajas.SuspendLayout()
        CType(Me.dgvCajas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.tlpDetalleCaja.SuspendLayout()
        CType(Me.dgvOperacionesObraSociales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvOperacionesEfectivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvOperacionesCuentaCorriente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvOperacionesMediosPagoElectronico, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.tlpCajas)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.tlpDetalleCaja)
        Me.SplitContainer1.Size = New System.Drawing.Size(1221, 867)
        Me.SplitContainer1.SplitterDistance = 584
        Me.SplitContainer1.TabIndex = 0
        '
        'tlpCajas
        '
        Me.tlpCajas.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble
        Me.tlpCajas.ColumnCount = 1
        Me.tlpCajas.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpCajas.Controls.Add(Me.dgvCajas, 0, 1)
        Me.tlpCajas.Controls.Add(Me.MenuStrip1, 0, 0)
        Me.tlpCajas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpCajas.Location = New System.Drawing.Point(0, 0)
        Me.tlpCajas.Name = "tlpCajas"
        Me.tlpCajas.RowCount = 2
        Me.tlpCajas.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.786546!))
        Me.tlpCajas.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95.21346!))
        Me.tlpCajas.Size = New System.Drawing.Size(584, 867)
        Me.tlpCajas.TabIndex = 0
        '
        'dgvCajas
        '
        Me.dgvCajas.AllowUserToAddRows = False
        Me.dgvCajas.AllowUserToDeleteRows = False
        Me.dgvCajas.AllowUserToResizeColumns = False
        Me.dgvCajas.AllowUserToResizeRows = False
        Me.dgvCajas.BackgroundColor = System.Drawing.Color.White
        Me.dgvCajas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCajas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdCaja, Me.Apertura, Me.Cierre, Me.Estado, Me.NCaja})
        Me.dgvCajas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCajas.Location = New System.Drawing.Point(6, 50)
        Me.dgvCajas.Name = "dgvCajas"
        Me.dgvCajas.ReadOnly = True
        Me.dgvCajas.RowHeadersVisible = False
        Me.dgvCajas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCajas.Size = New System.Drawing.Size(572, 811)
        Me.dgvCajas.TabIndex = 4
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
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOperaciones, Me.mnuVer})
        Me.MenuStrip1.Location = New System.Drawing.Point(3, 3)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(578, 24)
        Me.MenuStrip1.TabIndex = 5
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnuOperaciones
        '
        Me.mnuOperaciones.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCierreCaja, Me.mnuRetiroEfectivo})
        Me.mnuOperaciones.Name = "mnuOperaciones"
        Me.mnuOperaciones.Size = New System.Drawing.Size(85, 20)
        Me.mnuOperaciones.Text = "&Operaciones"
        '
        'mnuCierreCaja
        '
        Me.mnuCierreCaja.Name = "mnuCierreCaja"
        Me.mnuCierreCaja.Size = New System.Drawing.Size(150, 22)
        Me.mnuCierreCaja.Text = "&Cierre de Caja"
        '
        'mnuRetiroEfectivo
        '
        Me.mnuRetiroEfectivo.Name = "mnuRetiroEfectivo"
        Me.mnuRetiroEfectivo.Size = New System.Drawing.Size(150, 22)
        Me.mnuRetiroEfectivo.Text = "&Retiro Efectivo"
        '
        'mnuVer
        '
        Me.mnuVer.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDetalleEF, Me.mnuDetallePE, Me.mnuDetalleCC, Me.mnuDetalleOS})
        Me.mnuVer.Name = "mnuVer"
        Me.mnuVer.Size = New System.Drawing.Size(35, 20)
        Me.mnuVer.Text = "Ver"
        '
        'mnuDetalleEF
        '
        Me.mnuDetalleEF.Name = "mnuDetalleEF"
        Me.mnuDetalleEF.Size = New System.Drawing.Size(224, 22)
        Me.mnuDetalleEF.Text = "Detalle Operaciones Efectivo"
        '
        'mnuDetallePE
        '
        Me.mnuDetallePE.Name = "mnuDetallePE"
        Me.mnuDetallePE.Size = New System.Drawing.Size(224, 22)
        Me.mnuDetallePE.Text = "Detalle Pago Electronico"
        '
        'mnuDetalleCC
        '
        Me.mnuDetalleCC.Name = "mnuDetalleCC"
        Me.mnuDetalleCC.Size = New System.Drawing.Size(224, 22)
        Me.mnuDetalleCC.Text = "Detalle Cuenta Corriente"
        '
        'tlpDetalleCaja
        '
        Me.tlpDetalleCaja.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble
        Me.tlpDetalleCaja.ColumnCount = 1
        Me.tlpDetalleCaja.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpDetalleCaja.Controls.Add(Me.lblImporteRecetas, 0, 11)
        Me.tlpDetalleCaja.Controls.Add(Me.dgvOperacionesObraSociales, 0, 10)
        Me.tlpDetalleCaja.Controls.Add(Me.lblTituloRecetas, 0, 9)
        Me.tlpDetalleCaja.Controls.Add(Me.lblImporteCC, 0, 8)
        Me.tlpDetalleCaja.Controls.Add(Me.lblTituloOperacionesCuentaCorriente, 0, 6)
        Me.tlpDetalleCaja.Controls.Add(Me.lblImportePE, 0, 5)
        Me.tlpDetalleCaja.Controls.Add(Me.lblTituloOperacionesMediosPagoElectronico, 0, 3)
        Me.tlpDetalleCaja.Controls.Add(Me.lblImporteEfectivo, 0, 2)
        Me.tlpDetalleCaja.Controls.Add(Me.dgvOperacionesEfectivo, 0, 1)
        Me.tlpDetalleCaja.Controls.Add(Me.dgvOperacionesCuentaCorriente, 0, 7)
        Me.tlpDetalleCaja.Controls.Add(Me.dgvOperacionesMediosPagoElectronico, 0, 4)
        Me.tlpDetalleCaja.Controls.Add(Me.lblTituloOperacionesEfectivo, 0, 0)
        Me.tlpDetalleCaja.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpDetalleCaja.Location = New System.Drawing.Point(0, 0)
        Me.tlpDetalleCaja.Name = "tlpDetalleCaja"
        Me.tlpDetalleCaja.RowCount = 12
        Me.tlpDetalleCaja.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpDetalleCaja.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpDetalleCaja.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpDetalleCaja.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpDetalleCaja.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpDetalleCaja.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpDetalleCaja.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpDetalleCaja.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpDetalleCaja.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpDetalleCaja.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpDetalleCaja.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpDetalleCaja.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpDetalleCaja.Size = New System.Drawing.Size(633, 867)
        Me.tlpDetalleCaja.TabIndex = 1
        '
        'lblImporteRecetas
        '
        Me.lblImporteRecetas.AutoSize = True
        Me.lblImporteRecetas.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblImporteRecetas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteRecetas.Location = New System.Drawing.Point(568, 839)
        Me.lblImporteRecetas.Name = "lblImporteRecetas"
        Me.lblImporteRecetas.Size = New System.Drawing.Size(59, 25)
        Me.lblImporteRecetas.TabIndex = 12
        Me.lblImporteRecetas.Text = "$ 0,00"
        Me.lblImporteRecetas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgvOperacionesObraSociales
        '
        Me.dgvOperacionesObraSociales.AllowUserToAddRows = False
        Me.dgvOperacionesObraSociales.AllowUserToDeleteRows = False
        Me.dgvOperacionesObraSociales.AllowUserToResizeColumns = False
        Me.dgvOperacionesObraSociales.AllowUserToResizeRows = False
        Me.dgvOperacionesObraSociales.BackgroundColor = System.Drawing.Color.White
        Me.dgvOperacionesObraSociales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOperacionesObraSociales.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Descripcion, Me.CantRecetas, Me.ImporteTotal, Me.ImporteOS, Me.ImporteAf})
        Me.dgvOperacionesObraSociales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvOperacionesObraSociales.Location = New System.Drawing.Point(6, 682)
        Me.dgvOperacionesObraSociales.Name = "dgvOperacionesObraSociales"
        Me.dgvOperacionesObraSociales.ReadOnly = True
        Me.dgvOperacionesObraSociales.RowHeadersVisible = False
        Me.dgvOperacionesObraSociales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvOperacionesObraSociales.Size = New System.Drawing.Size(621, 151)
        Me.dgvOperacionesObraSociales.TabIndex = 11
        '
        'Descripcion
        '
        Me.Descripcion.DataPropertyName = "Descripcion"
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.Width = 300
        '
        'CantRecetas
        '
        Me.CantRecetas.DataPropertyName = "CantRecetas"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.CantRecetas.DefaultCellStyle = DataGridViewCellStyle1
        Me.CantRecetas.HeaderText = "Recetas"
        Me.CantRecetas.Name = "CantRecetas"
        Me.CantRecetas.ReadOnly = True
        Me.CantRecetas.Width = 50
        '
        'ImporteTotal
        '
        Me.ImporteTotal.DataPropertyName = "ImporteTotal"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.ImporteTotal.DefaultCellStyle = DataGridViewCellStyle2
        Me.ImporteTotal.HeaderText = "Imp.Total"
        Me.ImporteTotal.Name = "ImporteTotal"
        Me.ImporteTotal.ReadOnly = True
        Me.ImporteTotal.Width = 80
        '
        'ImporteOS
        '
        Me.ImporteOS.DataPropertyName = "ImporteOS"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        Me.ImporteOS.DefaultCellStyle = DataGridViewCellStyle3
        Me.ImporteOS.HeaderText = "Imp. OS."
        Me.ImporteOS.Name = "ImporteOS"
        Me.ImporteOS.ReadOnly = True
        Me.ImporteOS.Width = 80
        '
        'ImporteAf
        '
        Me.ImporteAf.DataPropertyName = "ImporteAf"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        Me.ImporteAf.DefaultCellStyle = DataGridViewCellStyle4
        Me.ImporteAf.HeaderText = "Imp. Af."
        Me.ImporteAf.Name = "ImporteAf"
        Me.ImporteAf.ReadOnly = True
        Me.ImporteAf.Width = 80
        '
        'lblTituloRecetas
        '
        Me.lblTituloRecetas.AutoSize = True
        Me.lblTituloRecetas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTituloRecetas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloRecetas.Location = New System.Drawing.Point(6, 651)
        Me.lblTituloRecetas.Name = "lblTituloRecetas"
        Me.lblTituloRecetas.Size = New System.Drawing.Size(621, 25)
        Me.lblTituloRecetas.TabIndex = 10
        Me.lblTituloRecetas.Text = "Recetas"
        Me.lblTituloRecetas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblImporteCC
        '
        Me.lblImporteCC.AutoSize = True
        Me.lblImporteCC.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblImporteCC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteCC.Location = New System.Drawing.Point(568, 623)
        Me.lblImporteCC.Name = "lblImporteCC"
        Me.lblImporteCC.Size = New System.Drawing.Size(59, 25)
        Me.lblImporteCC.TabIndex = 9
        Me.lblImporteCC.Text = "$ 0,00"
        Me.lblImporteCC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTituloOperacionesCuentaCorriente
        '
        Me.lblTituloOperacionesCuentaCorriente.AutoSize = True
        Me.lblTituloOperacionesCuentaCorriente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTituloOperacionesCuentaCorriente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloOperacionesCuentaCorriente.Location = New System.Drawing.Point(6, 435)
        Me.lblTituloOperacionesCuentaCorriente.Name = "lblTituloOperacionesCuentaCorriente"
        Me.lblTituloOperacionesCuentaCorriente.Size = New System.Drawing.Size(621, 25)
        Me.lblTituloOperacionesCuentaCorriente.TabIndex = 8
        Me.lblTituloOperacionesCuentaCorriente.Text = "Cuenta Corriente"
        Me.lblTituloOperacionesCuentaCorriente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblImportePE
        '
        Me.lblImportePE.AutoSize = True
        Me.lblImportePE.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblImportePE.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImportePE.Location = New System.Drawing.Point(568, 407)
        Me.lblImportePE.Name = "lblImportePE"
        Me.lblImportePE.Size = New System.Drawing.Size(59, 25)
        Me.lblImportePE.TabIndex = 7
        Me.lblImportePE.Text = "$ 0,00"
        Me.lblImportePE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTituloOperacionesMediosPagoElectronico
        '
        Me.lblTituloOperacionesMediosPagoElectronico.AutoSize = True
        Me.lblTituloOperacionesMediosPagoElectronico.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTituloOperacionesMediosPagoElectronico.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloOperacionesMediosPagoElectronico.Location = New System.Drawing.Point(6, 219)
        Me.lblTituloOperacionesMediosPagoElectronico.Name = "lblTituloOperacionesMediosPagoElectronico"
        Me.lblTituloOperacionesMediosPagoElectronico.Size = New System.Drawing.Size(621, 25)
        Me.lblTituloOperacionesMediosPagoElectronico.TabIndex = 6
        Me.lblTituloOperacionesMediosPagoElectronico.Text = "Medios de Pago Electrónico"
        Me.lblTituloOperacionesMediosPagoElectronico.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblImporteEfectivo
        '
        Me.lblImporteEfectivo.AutoSize = True
        Me.lblImporteEfectivo.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblImporteEfectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteEfectivo.Location = New System.Drawing.Point(568, 191)
        Me.lblImporteEfectivo.Name = "lblImporteEfectivo"
        Me.lblImporteEfectivo.Size = New System.Drawing.Size(59, 25)
        Me.lblImporteEfectivo.TabIndex = 5
        Me.lblImporteEfectivo.Text = "$ 0,00"
        Me.lblImporteEfectivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgvOperacionesEfectivo
        '
        Me.dgvOperacionesEfectivo.AllowUserToAddRows = False
        Me.dgvOperacionesEfectivo.AllowUserToDeleteRows = False
        Me.dgvOperacionesEfectivo.AllowUserToResizeColumns = False
        Me.dgvOperacionesEfectivo.AllowUserToResizeRows = False
        Me.dgvOperacionesEfectivo.BackgroundColor = System.Drawing.Color.White
        Me.dgvOperacionesEfectivo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOperacionesEfectivo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TipoOperacionEf, Me.CantOperacionesEf, Me.ImporteEf})
        Me.dgvOperacionesEfectivo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvOperacionesEfectivo.Location = New System.Drawing.Point(6, 34)
        Me.dgvOperacionesEfectivo.Name = "dgvOperacionesEfectivo"
        Me.dgvOperacionesEfectivo.ReadOnly = True
        Me.dgvOperacionesEfectivo.RowHeadersVisible = False
        Me.dgvOperacionesEfectivo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvOperacionesEfectivo.Size = New System.Drawing.Size(621, 151)
        Me.dgvOperacionesEfectivo.TabIndex = 1
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
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.CantOperacionesEf.DefaultCellStyle = DataGridViewCellStyle5
        Me.CantOperacionesEf.HeaderText = "Operaciones"
        Me.CantOperacionesEf.Name = "CantOperacionesEf"
        Me.CantOperacionesEf.ReadOnly = True
        '
        'ImporteEf
        '
        Me.ImporteEf.DataPropertyName = "Importe"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.ImporteEf.DefaultCellStyle = DataGridViewCellStyle6
        Me.ImporteEf.HeaderText = "Importe"
        Me.ImporteEf.Name = "ImporteEf"
        Me.ImporteEf.ReadOnly = True
        '
        'dgvOperacionesCuentaCorriente
        '
        Me.dgvOperacionesCuentaCorriente.AllowUserToAddRows = False
        Me.dgvOperacionesCuentaCorriente.AllowUserToDeleteRows = False
        Me.dgvOperacionesCuentaCorriente.AllowUserToResizeColumns = False
        Me.dgvOperacionesCuentaCorriente.AllowUserToResizeRows = False
        Me.dgvOperacionesCuentaCorriente.BackgroundColor = System.Drawing.Color.White
        Me.dgvOperacionesCuentaCorriente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOperacionesCuentaCorriente.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TipoOperacionCC, Me.CantOperacionesCC, Me.ImporteCC})
        Me.dgvOperacionesCuentaCorriente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvOperacionesCuentaCorriente.Location = New System.Drawing.Point(6, 466)
        Me.dgvOperacionesCuentaCorriente.Name = "dgvOperacionesCuentaCorriente"
        Me.dgvOperacionesCuentaCorriente.ReadOnly = True
        Me.dgvOperacionesCuentaCorriente.RowHeadersVisible = False
        Me.dgvOperacionesCuentaCorriente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvOperacionesCuentaCorriente.Size = New System.Drawing.Size(621, 151)
        Me.dgvOperacionesCuentaCorriente.TabIndex = 3
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
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.CantOperacionesCC.DefaultCellStyle = DataGridViewCellStyle7
        Me.CantOperacionesCC.HeaderText = "Operaciones"
        Me.CantOperacionesCC.Name = "CantOperacionesCC"
        Me.CantOperacionesCC.ReadOnly = True
        '
        'ImporteCC
        '
        Me.ImporteCC.DataPropertyName = "Importe"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.ImporteCC.DefaultCellStyle = DataGridViewCellStyle8
        Me.ImporteCC.HeaderText = "Importe"
        Me.ImporteCC.Name = "ImporteCC"
        Me.ImporteCC.ReadOnly = True
        '
        'dgvOperacionesMediosPagoElectronico
        '
        Me.dgvOperacionesMediosPagoElectronico.AllowUserToAddRows = False
        Me.dgvOperacionesMediosPagoElectronico.AllowUserToDeleteRows = False
        Me.dgvOperacionesMediosPagoElectronico.AllowUserToResizeColumns = False
        Me.dgvOperacionesMediosPagoElectronico.AllowUserToResizeRows = False
        Me.dgvOperacionesMediosPagoElectronico.BackgroundColor = System.Drawing.Color.White
        Me.dgvOperacionesMediosPagoElectronico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOperacionesMediosPagoElectronico.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MedioPE, Me.CantOperacionesPE, Me.ImportePE, Me.EstadoTransaccion})
        Me.dgvOperacionesMediosPagoElectronico.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvOperacionesMediosPagoElectronico.Location = New System.Drawing.Point(6, 250)
        Me.dgvOperacionesMediosPagoElectronico.Name = "dgvOperacionesMediosPagoElectronico"
        Me.dgvOperacionesMediosPagoElectronico.ReadOnly = True
        Me.dgvOperacionesMediosPagoElectronico.RowHeadersVisible = False
        Me.dgvOperacionesMediosPagoElectronico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvOperacionesMediosPagoElectronico.Size = New System.Drawing.Size(621, 151)
        Me.dgvOperacionesMediosPagoElectronico.TabIndex = 2
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
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.CantOperacionesPE.DefaultCellStyle = DataGridViewCellStyle9
        Me.CantOperacionesPE.HeaderText = "Operaciones"
        Me.CantOperacionesPE.Name = "CantOperacionesPE"
        Me.CantOperacionesPE.ReadOnly = True
        '
        'ImportePE
        '
        Me.ImportePE.DataPropertyName = "Importe"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.ImportePE.DefaultCellStyle = DataGridViewCellStyle10
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
        'lblTituloOperacionesEfectivo
        '
        Me.lblTituloOperacionesEfectivo.AutoSize = True
        Me.lblTituloOperacionesEfectivo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTituloOperacionesEfectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloOperacionesEfectivo.Location = New System.Drawing.Point(6, 3)
        Me.lblTituloOperacionesEfectivo.Name = "lblTituloOperacionesEfectivo"
        Me.lblTituloOperacionesEfectivo.Size = New System.Drawing.Size(621, 25)
        Me.lblTituloOperacionesEfectivo.TabIndex = 4
        Me.lblTituloOperacionesEfectivo.Text = "Operaciones en Efectivo"
        Me.lblTituloOperacionesEfectivo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'mnuDetalleOS
        '
        Me.mnuDetalleOS.Name = "mnuDetalleOS"
        Me.mnuDetalleOS.Size = New System.Drawing.Size(224, 22)
        Me.mnuDetalleOS.Text = "Detalle Recetas"
        '
        'FrmCajas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1221, 867)
        Me.Controls.Add(Me.SplitContainer1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FrmCajas"
        Me.Text = "Movimiento de Cajas"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.tlpCajas.ResumeLayout(False)
        Me.tlpCajas.PerformLayout()
        CType(Me.dgvCajas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.tlpDetalleCaja.ResumeLayout(False)
        Me.tlpDetalleCaja.PerformLayout()
        CType(Me.dgvOperacionesObraSociales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvOperacionesEfectivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvOperacionesCuentaCorriente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvOperacionesMediosPagoElectronico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents tlpDetalleCaja As TableLayoutPanel
    Friend WithEvents lblImporteCC As Label
    Friend WithEvents lblTituloOperacionesCuentaCorriente As Label
    Friend WithEvents lblImportePE As Label
    Friend WithEvents lblTituloOperacionesMediosPagoElectronico As Label
    Friend WithEvents lblImporteEfectivo As Label
    Friend WithEvents dgvOperacionesEfectivo As DataGridView
    Friend WithEvents TipoOperacionEf As DataGridViewTextBoxColumn
    Friend WithEvents CantOperacionesEf As DataGridViewTextBoxColumn
    Friend WithEvents ImporteEf As DataGridViewTextBoxColumn
    Friend WithEvents dgvOperacionesCuentaCorriente As DataGridView
    Friend WithEvents TipoOperacionCC As DataGridViewTextBoxColumn
    Friend WithEvents CantOperacionesCC As DataGridViewTextBoxColumn
    Friend WithEvents ImporteCC As DataGridViewTextBoxColumn
    Friend WithEvents dgvOperacionesMediosPagoElectronico As DataGridView
    Friend WithEvents lblTituloOperacionesEfectivo As Label
    Friend WithEvents tlpCajas As TableLayoutPanel
    Friend WithEvents dgvCajas As DataGridView
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
    Friend WithEvents mnuVer As ToolStripMenuItem
    Friend WithEvents mnuDetalleEF As ToolStripMenuItem
    Friend WithEvents mnuDetallePE As ToolStripMenuItem
    Friend WithEvents mnuDetalleCC As ToolStripMenuItem
    Friend WithEvents mnuOperaciones As ToolStripMenuItem
    Friend WithEvents mnuCierreCaja As ToolStripMenuItem
    Friend WithEvents mnuRetiroEfectivo As ToolStripMenuItem
    Friend WithEvents lblTituloRecetas As Label
    Friend WithEvents lblImporteRecetas As Label
    Friend WithEvents dgvOperacionesObraSociales As DataGridView
    Friend WithEvents Descripcion As DataGridViewTextBoxColumn
    Friend WithEvents CantRecetas As DataGridViewTextBoxColumn
    Friend WithEvents ImporteTotal As DataGridViewTextBoxColumn
    Friend WithEvents ImporteOS As DataGridViewTextBoxColumn
    Friend WithEvents ImporteAf As DataGridViewTextBoxColumn
    Friend WithEvents mnuDetalleOS As ToolStripMenuItem
End Class
