<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmVentas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmVentas))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblImporteDescuentosEtiqueta = New System.Windows.Forms.Label()
        Me.lblImporteDescuentos = New System.Windows.Forms.Label()
        Me.lblCantidadItems = New System.Windows.Forms.Label()
        Me.lblImporteSinDescuentos = New System.Windows.Forms.Label()
        Me.lblImporteSinDescuentosEtiqueta = New System.Windows.Forms.Label()
        Me.lblImporteConDescuentos = New System.Windows.Forms.Label()
        Me.lblImporteConDescuentosEtiqueta = New System.Windows.Forms.Label()
        Me.lblDatosOperacion = New System.Windows.Forms.Label()
        Me.lblPorcentajeAplicado = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.IdItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodBarras = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AlicIVA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioUnitario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImporteSinDescuento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PorcentajeDescuento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImporteDescuento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImporteConDescuento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.NuevoToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.AbrirToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.GuardarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ImprimirToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.CopiarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.PegarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ClienteToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.DesRecToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.AyudaToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SalirToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SelectorArticulos = New System.Windows.Forms.ToolStripTextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnuArchivo = New System.Windows.Forms.ToolStripMenuItem()
        Me.AbrirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditarElimininarItemSeleccionado = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditarAplicarDescuentoItemSeleccionado = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditarModificarPrecio = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuProcesos = New System.Windows.Forms.ToolStripMenuItem()
        Me.FacturarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemitoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PresupuestoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.SystemColors.Window
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.DataGridView1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 190.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(984, 661)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.TableLayoutPanel3)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(6, 471)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(972, 184)
        Me.Panel3.TabIndex = 5
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble
        Me.TableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.90181!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.09819!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 203.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.lblImporteDescuentosEtiqueta, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.lblImporteDescuentos, 2, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.lblCantidadItems, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lblImporteSinDescuentos, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lblImporteSinDescuentosEtiqueta, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lblImporteConDescuentos, 2, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.lblImporteConDescuentosEtiqueta, 1, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.lblDatosOperacion, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.lblPorcentajeAplicado, 0, 1)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 3
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(970, 182)
        Me.TableLayoutPanel3.TabIndex = 7
        '
        'lblImporteDescuentosEtiqueta
        '
        Me.lblImporteDescuentosEtiqueta.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblImporteDescuentosEtiqueta.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteDescuentosEtiqueta.Location = New System.Drawing.Point(567, 57)
        Me.lblImporteDescuentosEtiqueta.Name = "lblImporteDescuentosEtiqueta"
        Me.lblImporteDescuentosEtiqueta.Size = New System.Drawing.Size(190, 51)
        Me.lblImporteDescuentosEtiqueta.TabIndex = 8
        Me.lblImporteDescuentosEtiqueta.Text = "Importe Descuentos:"
        Me.lblImporteDescuentosEtiqueta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblImporteDescuentos
        '
        Me.lblImporteDescuentos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImporteDescuentos.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteDescuentos.Location = New System.Drawing.Point(766, 57)
        Me.lblImporteDescuentos.Name = "lblImporteDescuentos"
        Me.lblImporteDescuentos.Size = New System.Drawing.Size(198, 51)
        Me.lblImporteDescuentos.TabIndex = 13
        Me.lblImporteDescuentos.Text = "0,00"
        Me.lblImporteDescuentos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCantidadItems
        '
        Me.lblCantidadItems.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblCantidadItems.AutoSize = True
        Me.lblCantidadItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidadItems.Location = New System.Drawing.Point(6, 18)
        Me.lblCantidadItems.Name = "lblCantidadItems"
        Me.lblCantidadItems.Size = New System.Drawing.Size(75, 20)
        Me.lblCantidadItems.TabIndex = 10
        Me.lblCantidadItems.Text = "- Items: 0"
        '
        'lblImporteSinDescuentos
        '
        Me.lblImporteSinDescuentos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImporteSinDescuentos.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteSinDescuentos.Location = New System.Drawing.Point(766, 3)
        Me.lblImporteSinDescuentos.Name = "lblImporteSinDescuentos"
        Me.lblImporteSinDescuentos.Size = New System.Drawing.Size(198, 51)
        Me.lblImporteSinDescuentos.TabIndex = 11
        Me.lblImporteSinDescuentos.Text = "0,00"
        Me.lblImporteSinDescuentos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblImporteSinDescuentosEtiqueta
        '
        Me.lblImporteSinDescuentosEtiqueta.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblImporteSinDescuentosEtiqueta.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteSinDescuentosEtiqueta.Location = New System.Drawing.Point(567, 3)
        Me.lblImporteSinDescuentosEtiqueta.Name = "lblImporteSinDescuentosEtiqueta"
        Me.lblImporteSinDescuentosEtiqueta.Size = New System.Drawing.Size(190, 51)
        Me.lblImporteSinDescuentosEtiqueta.TabIndex = 6
        Me.lblImporteSinDescuentosEtiqueta.Text = "Total sin Descuentos:"
        Me.lblImporteSinDescuentosEtiqueta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblImporteConDescuentos
        '
        Me.lblImporteConDescuentos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImporteConDescuentos.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteConDescuentos.Location = New System.Drawing.Point(766, 111)
        Me.lblImporteConDescuentos.Name = "lblImporteConDescuentos"
        Me.lblImporteConDescuentos.Size = New System.Drawing.Size(198, 68)
        Me.lblImporteConDescuentos.TabIndex = 14
        Me.lblImporteConDescuentos.Text = "0,00"
        Me.lblImporteConDescuentos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblImporteConDescuentosEtiqueta
        '
        Me.lblImporteConDescuentosEtiqueta.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblImporteConDescuentosEtiqueta.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteConDescuentosEtiqueta.Location = New System.Drawing.Point(567, 111)
        Me.lblImporteConDescuentosEtiqueta.Name = "lblImporteConDescuentosEtiqueta"
        Me.lblImporteConDescuentosEtiqueta.Size = New System.Drawing.Size(190, 68)
        Me.lblImporteConDescuentosEtiqueta.TabIndex = 9
        Me.lblImporteConDescuentosEtiqueta.Text = "Imp. a pagar:  "
        Me.lblImporteConDescuentosEtiqueta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDatosOperacion
        '
        Me.lblDatosOperacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDatosOperacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatosOperacion.Location = New System.Drawing.Point(6, 111)
        Me.lblDatosOperacion.Name = "lblDatosOperacion"
        Me.lblDatosOperacion.Size = New System.Drawing.Size(551, 68)
        Me.lblDatosOperacion.TabIndex = 17
        '
        'lblPorcentajeAplicado
        '
        Me.lblPorcentajeAplicado.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblPorcentajeAplicado.AutoSize = True
        Me.lblPorcentajeAplicado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPorcentajeAplicado.Location = New System.Drawing.Point(6, 72)
        Me.lblPorcentajeAplicado.Name = "lblPorcentajeAplicado"
        Me.lblPorcentajeAplicado.Size = New System.Drawing.Size(241, 20)
        Me.lblPorcentajeAplicado.TabIndex = 16
        Me.lblPorcentajeAplicado.Text = "- Porcentaje Descuentos: 0,00 %"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdItem, Me.CodBarras, Me.Descripcion, Me.Cantidad, Me.AlicIVA, Me.PrecioUnitario, Me.ImporteSinDescuento, Me.PorcentajeDescuento, Me.ImporteDescuento, Me.ImporteConDescuento})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(6, 77)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 20
        Me.DataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DataGridView1.Size = New System.Drawing.Size(972, 385)
        Me.DataGridView1.TabIndex = 3
        '
        'IdItem
        '
        Me.IdItem.DataPropertyName = "IdItem"
        Me.IdItem.HeaderText = "IdItem"
        Me.IdItem.Name = "IdItem"
        Me.IdItem.Visible = False
        '
        'CodBarras
        '
        Me.CodBarras.DataPropertyName = "CodBarras"
        Me.CodBarras.HeaderText = "CodBarras"
        Me.CodBarras.Name = "CodBarras"
        Me.CodBarras.ReadOnly = True
        '
        'Descripcion
        '
        Me.Descripcion.DataPropertyName = "Descripcion"
        Me.Descripcion.FillWeight = 166.103!
        Me.Descripcion.HeaderText = "Articulo"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        '
        'Cantidad
        '
        Me.Cantidad.DataPropertyName = "Cantidad"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.Cantidad.DefaultCellStyle = DataGridViewCellStyle2
        Me.Cantidad.FillWeight = 168.7203!
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        '
        'AlicIVA
        '
        Me.AlicIVA.DataPropertyName = "AlicIVA"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.AlicIVA.DefaultCellStyle = DataGridViewCellStyle3
        Me.AlicIVA.FillWeight = 174.8724!
        Me.AlicIVA.HeaderText = "IVA"
        Me.AlicIVA.Name = "AlicIVA"
        Me.AlicIVA.ReadOnly = True
        '
        'PrecioUnitario
        '
        Me.PrecioUnitario.DataPropertyName = "PrecioUnitario"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.PrecioUnitario.DefaultCellStyle = DataGridViewCellStyle4
        Me.PrecioUnitario.FillWeight = 68.81715!
        Me.PrecioUnitario.HeaderText = "P.Unitario"
        Me.PrecioUnitario.Name = "PrecioUnitario"
        Me.PrecioUnitario.ReadOnly = True
        '
        'ImporteSinDescuento
        '
        Me.ImporteSinDescuento.DataPropertyName = "ImporteSinDescuento"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.ImporteSinDescuento.DefaultCellStyle = DataGridViewCellStyle5
        Me.ImporteSinDescuento.FillWeight = 59.96484!
        Me.ImporteSinDescuento.HeaderText = "Importe"
        Me.ImporteSinDescuento.Name = "ImporteSinDescuento"
        Me.ImporteSinDescuento.ReadOnly = True
        '
        'PorcentajeDescuento
        '
        Me.PorcentajeDescuento.DataPropertyName = "PorcentajeDescuento"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.PorcentajeDescuento.DefaultCellStyle = DataGridViewCellStyle6
        Me.PorcentajeDescuento.FillWeight = 57.10529!
        Me.PorcentajeDescuento.HeaderText = "%Desc."
        Me.PorcentajeDescuento.Name = "PorcentajeDescuento"
        Me.PorcentajeDescuento.ReadOnly = True
        '
        'ImporteDescuento
        '
        Me.ImporteDescuento.DataPropertyName = "ImporteDescuento"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.ImporteDescuento.DefaultCellStyle = DataGridViewCellStyle7
        Me.ImporteDescuento.FillWeight = 54.31535!
        Me.ImporteDescuento.HeaderText = "Imp.Desc."
        Me.ImporteDescuento.Name = "ImporteDescuento"
        Me.ImporteDescuento.ReadOnly = True
        '
        'ImporteConDescuento
        '
        Me.ImporteConDescuento.DataPropertyName = "ImporteConDescuento"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.ImporteConDescuento.DefaultCellStyle = DataGridViewCellStyle8
        Me.ImporteConDescuento.FillWeight = 40.10151!
        Me.ImporteConDescuento.HeaderText = "Imp.Cliente"
        Me.ImporteConDescuento.Name = "ImporteConDescuento"
        Me.ImporteConDescuento.ReadOnly = True
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.Controls.Add(Me.ToolStrip1)
        Me.Panel1.Controls.Add(Me.MenuStrip1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(6, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(972, 62)
        Me.Panel1.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoToolStripButton, Me.AbrirToolStripButton, Me.GuardarToolStripButton, Me.ImprimirToolStripButton, Me.toolStripSeparator, Me.CopiarToolStripButton, Me.PegarToolStripButton, Me.ClienteToolStripButton, Me.DesRecToolStripButton1, Me.AyudaToolStripButton, Me.ToolStripSeparator1, Me.SalirToolStripButton, Me.SelectorArticulos})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(972, 38)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'NuevoToolStripButton
        '
        Me.NuevoToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NuevoToolStripButton.Image = CType(resources.GetObject("NuevoToolStripButton.Image"), System.Drawing.Image)
        Me.NuevoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NuevoToolStripButton.Name = "NuevoToolStripButton"
        Me.NuevoToolStripButton.Size = New System.Drawing.Size(23, 35)
        Me.NuevoToolStripButton.Text = "&Nuevo"
        '
        'AbrirToolStripButton
        '
        Me.AbrirToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AbrirToolStripButton.Image = CType(resources.GetObject("AbrirToolStripButton.Image"), System.Drawing.Image)
        Me.AbrirToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AbrirToolStripButton.Name = "AbrirToolStripButton"
        Me.AbrirToolStripButton.Size = New System.Drawing.Size(23, 35)
        Me.AbrirToolStripButton.Text = "&Abrir"
        '
        'GuardarToolStripButton
        '
        Me.GuardarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.GuardarToolStripButton.Image = CType(resources.GetObject("GuardarToolStripButton.Image"), System.Drawing.Image)
        Me.GuardarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.GuardarToolStripButton.Name = "GuardarToolStripButton"
        Me.GuardarToolStripButton.Size = New System.Drawing.Size(23, 35)
        Me.GuardarToolStripButton.Text = "&Guardar"
        '
        'ImprimirToolStripButton
        '
        Me.ImprimirToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ImprimirToolStripButton.Image = CType(resources.GetObject("ImprimirToolStripButton.Image"), System.Drawing.Image)
        Me.ImprimirToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ImprimirToolStripButton.Name = "ImprimirToolStripButton"
        Me.ImprimirToolStripButton.Size = New System.Drawing.Size(23, 35)
        Me.ImprimirToolStripButton.Text = "&Imprimir"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 38)
        '
        'CopiarToolStripButton
        '
        Me.CopiarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CopiarToolStripButton.Image = CType(resources.GetObject("CopiarToolStripButton.Image"), System.Drawing.Image)
        Me.CopiarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CopiarToolStripButton.Name = "CopiarToolStripButton"
        Me.CopiarToolStripButton.Size = New System.Drawing.Size(23, 35)
        Me.CopiarToolStripButton.Text = "&Copiar"
        '
        'PegarToolStripButton
        '
        Me.PegarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PegarToolStripButton.Image = CType(resources.GetObject("PegarToolStripButton.Image"), System.Drawing.Image)
        Me.PegarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PegarToolStripButton.Name = "PegarToolStripButton"
        Me.PegarToolStripButton.Size = New System.Drawing.Size(23, 35)
        Me.PegarToolStripButton.Text = "&Pegar"
        '
        'ClienteToolStripButton
        '
        Me.ClienteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ClienteToolStripButton.Image = CType(resources.GetObject("ClienteToolStripButton.Image"), System.Drawing.Image)
        Me.ClienteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ClienteToolStripButton.Name = "ClienteToolStripButton"
        Me.ClienteToolStripButton.Size = New System.Drawing.Size(23, 35)
        Me.ClienteToolStripButton.Text = "&Cliente"
        '
        'DesRecToolStripButton1
        '
        Me.DesRecToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.DesRecToolStripButton1.Image = CType(resources.GetObject("DesRecToolStripButton1.Image"), System.Drawing.Image)
        Me.DesRecToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DesRecToolStripButton1.Name = "DesRecToolStripButton1"
        Me.DesRecToolStripButton1.Size = New System.Drawing.Size(23, 35)
        Me.DesRecToolStripButton1.Text = "ToolStripButton1"
        '
        'AyudaToolStripButton
        '
        Me.AyudaToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AyudaToolStripButton.Image = CType(resources.GetObject("AyudaToolStripButton.Image"), System.Drawing.Image)
        Me.AyudaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AyudaToolStripButton.Name = "AyudaToolStripButton"
        Me.AyudaToolStripButton.Size = New System.Drawing.Size(23, 35)
        Me.AyudaToolStripButton.Text = "Ay&uda"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 38)
        '
        'SalirToolStripButton
        '
        Me.SalirToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SalirToolStripButton.Image = CType(resources.GetObject("SalirToolStripButton.Image"), System.Drawing.Image)
        Me.SalirToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SalirToolStripButton.Name = "SalirToolStripButton"
        Me.SalirToolStripButton.Size = New System.Drawing.Size(23, 35)
        Me.SalirToolStripButton.Text = "&Salir"
        Me.SalirToolStripButton.ToolTipText = "Salir"
        '
        'SelectorArticulos
        '
        Me.SelectorArticulos.AcceptsTab = True
        Me.SelectorArticulos.AutoSize = False
        Me.SelectorArticulos.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.SelectorArticulos.Name = "SelectorArticulos"
        Me.SelectorArticulos.Size = New System.Drawing.Size(100, 25)
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuArchivo, Me.mnuEditar, Me.mnuProcesos})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(972, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnuArchivo
        '
        Me.mnuArchivo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AbrirToolStripMenuItem, Me.GuardarToolStripMenuItem, Me.SalirToolStripMenuItem})
        Me.mnuArchivo.Name = "mnuArchivo"
        Me.mnuArchivo.Size = New System.Drawing.Size(60, 20)
        Me.mnuArchivo.Text = "&Archivo"
        '
        'AbrirToolStripMenuItem
        '
        Me.AbrirToolStripMenuItem.Image = CType(resources.GetObject("AbrirToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AbrirToolStripMenuItem.Name = "AbrirToolStripMenuItem"
        Me.AbrirToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.AbrirToolStripMenuItem.Text = "A&brir"
        '
        'GuardarToolStripMenuItem
        '
        Me.GuardarToolStripMenuItem.Image = CType(resources.GetObject("GuardarToolStripMenuItem.Image"), System.Drawing.Image)
        Me.GuardarToolStripMenuItem.Name = "GuardarToolStripMenuItem"
        Me.GuardarToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.GuardarToolStripMenuItem.Text = "&Guardar"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Image = CType(resources.GetObject("SalirToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.SalirToolStripMenuItem.Text = "&Salir"
        '
        'mnuEditar
        '
        Me.mnuEditar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuEditarElimininarItemSeleccionado, Me.mnuEditarAplicarDescuentoItemSeleccionado, Me.mnuEditarModificarPrecio})
        Me.mnuEditar.Name = "mnuEditar"
        Me.mnuEditar.Size = New System.Drawing.Size(49, 20)
        Me.mnuEditar.Text = "&Editar"
        '
        'mnuEditarElimininarItemSeleccionado
        '
        Me.mnuEditarElimininarItemSeleccionado.Image = CType(resources.GetObject("mnuEditarElimininarItemSeleccionado.Image"), System.Drawing.Image)
        Me.mnuEditarElimininarItemSeleccionado.Name = "mnuEditarElimininarItemSeleccionado"
        Me.mnuEditarElimininarItemSeleccionado.Size = New System.Drawing.Size(269, 22)
        Me.mnuEditarElimininarItemSeleccionado.Text = "&Elimininar Item seleccionado"
        '
        'mnuEditarAplicarDescuentoItemSeleccionado
        '
        Me.mnuEditarAplicarDescuentoItemSeleccionado.Image = CType(resources.GetObject("mnuEditarAplicarDescuentoItemSeleccionado.Image"), System.Drawing.Image)
        Me.mnuEditarAplicarDescuentoItemSeleccionado.Name = "mnuEditarAplicarDescuentoItemSeleccionado"
        Me.mnuEditarAplicarDescuentoItemSeleccionado.Size = New System.Drawing.Size(269, 22)
        Me.mnuEditarAplicarDescuentoItemSeleccionado.Text = "Aplicar &Descuento Item seleccionado"
        '
        'mnuEditarModificarPrecio
        '
        Me.mnuEditarModificarPrecio.Image = CType(resources.GetObject("mnuEditarModificarPrecio.Image"), System.Drawing.Image)
        Me.mnuEditarModificarPrecio.Name = "mnuEditarModificarPrecio"
        Me.mnuEditarModificarPrecio.Size = New System.Drawing.Size(269, 22)
        Me.mnuEditarModificarPrecio.Text = "&Modificar precio Item seleccionado"
        '
        'mnuProcesos
        '
        Me.mnuProcesos.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FacturarToolStripMenuItem, Me.RemitoToolStripMenuItem, Me.PresupuestoToolStripMenuItem})
        Me.mnuProcesos.Name = "mnuProcesos"
        Me.mnuProcesos.Size = New System.Drawing.Size(66, 20)
        Me.mnuProcesos.Text = "&Procesos"
        '
        'FacturarToolStripMenuItem
        '
        Me.FacturarToolStripMenuItem.Name = "FacturarToolStripMenuItem"
        Me.FacturarToolStripMenuItem.ShortcutKeyDisplayString = "F10"
        Me.FacturarToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.FacturarToolStripMenuItem.Text = "&Facturar"
        '
        'RemitoToolStripMenuItem
        '
        Me.RemitoToolStripMenuItem.Name = "RemitoToolStripMenuItem"
        Me.RemitoToolStripMenuItem.ShortcutKeyDisplayString = "F9"
        Me.RemitoToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.RemitoToolStripMenuItem.Text = "&Remito"
        '
        'PresupuestoToolStripMenuItem
        '
        Me.PresupuestoToolStripMenuItem.Name = "PresupuestoToolStripMenuItem"
        Me.PresupuestoToolStripMenuItem.ShortcutKeyDisplayString = "F8"
        Me.PresupuestoToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.PresupuestoToolStripMenuItem.Text = "&Presupuesto"
        '
        'FrmVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 661)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "FrmVentas"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents mnuArchivo As ToolStripMenuItem
    Friend WithEvents mnuEditar As ToolStripMenuItem
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents NuevoToolStripButton As ToolStripButton
    Friend WithEvents AbrirToolStripButton As ToolStripButton
    Friend WithEvents GuardarToolStripButton As ToolStripButton
    Friend WithEvents ImprimirToolStripButton As ToolStripButton
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents CopiarToolStripButton As ToolStripButton
    Friend WithEvents PegarToolStripButton As ToolStripButton
    Friend WithEvents AyudaToolStripButton As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents SelectorArticulos As ToolStripTextBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents mnuEditarElimininarItemSeleccionado As ToolStripMenuItem
    Friend WithEvents mnuEditarAplicarDescuentoItemSeleccionado As ToolStripMenuItem
    Friend WithEvents AbrirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GuardarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuEditarModificarPrecio As ToolStripMenuItem
    Friend WithEvents SalirToolStripButton As ToolStripButton
    Friend WithEvents mnuProcesos As ToolStripMenuItem
    Friend WithEvents FacturarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RemitoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PresupuestoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClienteToolStripButton As ToolStripButton
    Friend WithEvents DesRecToolStripButton1 As ToolStripButton
    Friend WithEvents IdItem As DataGridViewTextBoxColumn
    Friend WithEvents CodBarras As DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As DataGridViewTextBoxColumn
    Friend WithEvents AlicIVA As DataGridViewTextBoxColumn
    Friend WithEvents PrecioUnitario As DataGridViewTextBoxColumn
    Friend WithEvents ImporteSinDescuento As DataGridViewTextBoxColumn
    Friend WithEvents PorcentajeDescuento As DataGridViewTextBoxColumn
    Friend WithEvents ImporteDescuento As DataGridViewTextBoxColumn
    Friend WithEvents ImporteConDescuento As DataGridViewTextBoxColumn
    Friend WithEvents Panel3 As Panel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents lblImporteDescuentosEtiqueta As Label
    Friend WithEvents lblImporteDescuentos As Label
    Friend WithEvents lblCantidadItems As Label
    Friend WithEvents lblImporteSinDescuentos As Label
    Friend WithEvents lblImporteSinDescuentosEtiqueta As Label
    Friend WithEvents lblImporteConDescuentos As Label
    Friend WithEvents lblImporteConDescuentosEtiqueta As Label
    Friend WithEvents lblDatosOperacion As Label
    Friend WithEvents lblPorcentajeAplicado As Label
End Class
