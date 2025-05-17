<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmFacturacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFacturacion))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.IdDP = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.CortarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.CopiarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.PegarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.AyudaToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SelectorArticulos = New System.Windows.Forms.ToolStripTextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EdicionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblImporteDescuentos = New System.Windows.Forms.Label()
        Me.lblPorcentajeAplicado = New System.Windows.Forms.Label()
        Me.lblImporteSinDescuentos = New System.Windows.Forms.Label()
        Me.lblCantidadItems = New System.Windows.Forms.Label()
        Me.lblImporteConDescuentos = New System.Windows.Forms.Label()
        Me.ElimininarItemSeleccionadoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AplicarDescuentoItemSeleccionadoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.SystemColors.Window
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.DataGridView1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1359, 545)
        Me.TableLayoutPanel1.TabIndex = 0
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
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdDP, Me.CodBarras, Me.Descripcion, Me.Cantidad, Me.AlicIVA, Me.PrecioUnitario, Me.ImporteSinDescuento, Me.PorcentajeDescuento, Me.ImporteDescuento, Me.ImporteConDescuento})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(3, 58)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 20
        Me.DataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DataGridView1.Size = New System.Drawing.Size(1353, 427)
        Me.DataGridView1.TabIndex = 3
        '
        'IdDP
        '
        Me.IdDP.DataPropertyName = "IdDP"
        Me.IdDP.HeaderText = "IdDP"
        Me.IdDP.Name = "IdDP"
        Me.IdDP.Visible = False
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
        Me.PrecioUnitario.HeaderText = "Precio Unitario"
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
        Me.PorcentajeDescuento.HeaderText = "%Descuento"
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
        Me.ImporteDescuento.HeaderText = "Imp.Descuento"
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
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1353, 49)
        Me.Panel1.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoToolStripButton, Me.AbrirToolStripButton, Me.GuardarToolStripButton, Me.ImprimirToolStripButton, Me.toolStripSeparator, Me.CortarToolStripButton, Me.CopiarToolStripButton, Me.PegarToolStripButton, Me.AyudaToolStripButton, Me.ToolStripSeparator1, Me.SelectorArticulos})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1353, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'NuevoToolStripButton
        '
        Me.NuevoToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NuevoToolStripButton.Image = CType(resources.GetObject("NuevoToolStripButton.Image"), System.Drawing.Image)
        Me.NuevoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NuevoToolStripButton.Name = "NuevoToolStripButton"
        Me.NuevoToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.NuevoToolStripButton.Text = "&Nuevo"
        '
        'AbrirToolStripButton
        '
        Me.AbrirToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AbrirToolStripButton.Image = CType(resources.GetObject("AbrirToolStripButton.Image"), System.Drawing.Image)
        Me.AbrirToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AbrirToolStripButton.Name = "AbrirToolStripButton"
        Me.AbrirToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.AbrirToolStripButton.Text = "&Abrir"
        '
        'GuardarToolStripButton
        '
        Me.GuardarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.GuardarToolStripButton.Image = CType(resources.GetObject("GuardarToolStripButton.Image"), System.Drawing.Image)
        Me.GuardarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.GuardarToolStripButton.Name = "GuardarToolStripButton"
        Me.GuardarToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.GuardarToolStripButton.Text = "&Guardar"
        '
        'ImprimirToolStripButton
        '
        Me.ImprimirToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ImprimirToolStripButton.Image = CType(resources.GetObject("ImprimirToolStripButton.Image"), System.Drawing.Image)
        Me.ImprimirToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ImprimirToolStripButton.Name = "ImprimirToolStripButton"
        Me.ImprimirToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.ImprimirToolStripButton.Text = "&Imprimir"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'CortarToolStripButton
        '
        Me.CortarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CortarToolStripButton.Image = CType(resources.GetObject("CortarToolStripButton.Image"), System.Drawing.Image)
        Me.CortarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CortarToolStripButton.Name = "CortarToolStripButton"
        Me.CortarToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.CortarToolStripButton.Text = "Cort&ar"
        '
        'CopiarToolStripButton
        '
        Me.CopiarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CopiarToolStripButton.Image = CType(resources.GetObject("CopiarToolStripButton.Image"), System.Drawing.Image)
        Me.CopiarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CopiarToolStripButton.Name = "CopiarToolStripButton"
        Me.CopiarToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.CopiarToolStripButton.Text = "&Copiar"
        '
        'PegarToolStripButton
        '
        Me.PegarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PegarToolStripButton.Image = CType(resources.GetObject("PegarToolStripButton.Image"), System.Drawing.Image)
        Me.PegarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PegarToolStripButton.Name = "PegarToolStripButton"
        Me.PegarToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PegarToolStripButton.Text = "&Pegar"
        '
        'AyudaToolStripButton
        '
        Me.AyudaToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AyudaToolStripButton.Image = CType(resources.GetObject("AyudaToolStripButton.Image"), System.Drawing.Image)
        Me.AyudaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AyudaToolStripButton.Name = "AyudaToolStripButton"
        Me.AyudaToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.AyudaToolStripButton.Text = "Ay&uda"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
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
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.EdicionToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1353, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ArchivoToolStripMenuItem
        '
        Me.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
        Me.ArchivoToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.ArchivoToolStripMenuItem.Text = "&Archivo"
        '
        'EdicionToolStripMenuItem
        '
        Me.EdicionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ElimininarItemSeleccionadoToolStripMenuItem, Me.AplicarDescuentoItemSeleccionadoToolStripMenuItem})
        Me.EdicionToolStripMenuItem.Name = "EdicionToolStripMenuItem"
        Me.EdicionToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.EdicionToolStripMenuItem.Text = "&Edicion"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 491)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1353, 51)
        Me.Panel2.TabIndex = 4
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 5
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22222!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22222!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22222!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22222!))
        Me.TableLayoutPanel2.Controls.Add(Me.lblImporteDescuentos, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblPorcentajeAplicado, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblImporteSinDescuentos, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblCantidadItems, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblImporteConDescuentos, 4, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1351, 49)
        Me.TableLayoutPanel2.TabIndex = 7
        '
        'lblImporteDescuentos
        '
        Me.lblImporteDescuentos.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblImporteDescuentos.AutoSize = True
        Me.lblImporteDescuentos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteDescuentos.Location = New System.Drawing.Point(753, 14)
        Me.lblImporteDescuentos.Name = "lblImporteDescuentos"
        Me.lblImporteDescuentos.Size = New System.Drawing.Size(206, 20)
        Me.lblImporteDescuentos.TabIndex = 8
        Me.lblImporteDescuentos.Text = "Importe Descuentos: $ 0,00"
        '
        'lblPorcentajeAplicado
        '
        Me.lblPorcentajeAplicado.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblPorcentajeAplicado.AutoSize = True
        Me.lblPorcentajeAplicado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPorcentajeAplicado.Location = New System.Drawing.Point(453, 14)
        Me.lblPorcentajeAplicado.Name = "lblPorcentajeAplicado"
        Me.lblPorcentajeAplicado.Size = New System.Drawing.Size(189, 20)
        Me.lblPorcentajeAplicado.TabIndex = 7
        Me.lblPorcentajeAplicado.Text = "Porcentaje Aplicado: 0,00"
        '
        'lblImporteSinDescuentos
        '
        Me.lblImporteSinDescuentos.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblImporteSinDescuentos.AutoSize = True
        Me.lblImporteSinDescuentos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteSinDescuentos.Location = New System.Drawing.Point(153, 14)
        Me.lblImporteSinDescuentos.Name = "lblImporteSinDescuentos"
        Me.lblImporteSinDescuentos.Size = New System.Drawing.Size(210, 20)
        Me.lblImporteSinDescuentos.TabIndex = 6
        Me.lblImporteSinDescuentos.Text = "Total sin Descuentos: $ 0,00"
        '
        'lblCantidadItems
        '
        Me.lblCantidadItems.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblCantidadItems.AutoSize = True
        Me.lblCantidadItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidadItems.Location = New System.Drawing.Point(3, 14)
        Me.lblCantidadItems.Name = "lblCantidadItems"
        Me.lblCantidadItems.Size = New System.Drawing.Size(66, 20)
        Me.lblCantidadItems.TabIndex = 5
        Me.lblCantidadItems.Text = "Items: 0"
        '
        'lblImporteConDescuentos
        '
        Me.lblImporteConDescuentos.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblImporteConDescuentos.AutoSize = True
        Me.lblImporteConDescuentos.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteConDescuentos.Location = New System.Drawing.Point(1170, 12)
        Me.lblImporteConDescuentos.Name = "lblImporteConDescuentos"
        Me.lblImporteConDescuentos.Size = New System.Drawing.Size(178, 24)
        Me.lblImporteConDescuentos.TabIndex = 9
        Me.lblImporteConDescuentos.Text = "Importe Neto: $ 0,00"
        '
        'ElimininarItemSeleccionadoToolStripMenuItem
        '
        Me.ElimininarItemSeleccionadoToolStripMenuItem.Image = CType(resources.GetObject("ElimininarItemSeleccionadoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ElimininarItemSeleccionadoToolStripMenuItem.Name = "ElimininarItemSeleccionadoToolStripMenuItem"
        Me.ElimininarItemSeleccionadoToolStripMenuItem.Size = New System.Drawing.Size(268, 22)
        Me.ElimininarItemSeleccionadoToolStripMenuItem.Text = "&Elimininar item seleccionado"
        '
        'AplicarDescuentoItemSeleccionadoToolStripMenuItem
        '
        Me.AplicarDescuentoItemSeleccionadoToolStripMenuItem.Name = "AplicarDescuentoItemSeleccionadoToolStripMenuItem"
        Me.AplicarDescuentoItemSeleccionadoToolStripMenuItem.Size = New System.Drawing.Size(268, 22)
        Me.AplicarDescuentoItemSeleccionadoToolStripMenuItem.Text = "Aplicar descuento item seleccionado"
        '
        'FrmFacturacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1359, 545)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FrmFacturacion"
        Me.Text = "Form1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EdicionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents NuevoToolStripButton As ToolStripButton
    Friend WithEvents AbrirToolStripButton As ToolStripButton
    Friend WithEvents GuardarToolStripButton As ToolStripButton
    Friend WithEvents ImprimirToolStripButton As ToolStripButton
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents CortarToolStripButton As ToolStripButton
    Friend WithEvents CopiarToolStripButton As ToolStripButton
    Friend WithEvents PegarToolStripButton As ToolStripButton
    Friend WithEvents AyudaToolStripButton As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents SelectorArticulos As ToolStripTextBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents IdDP As DataGridViewTextBoxColumn
    Friend WithEvents CodBarras As DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As DataGridViewTextBoxColumn
    Friend WithEvents AlicIVA As DataGridViewTextBoxColumn
    Friend WithEvents PrecioUnitario As DataGridViewTextBoxColumn
    Friend WithEvents ImporteSinDescuento As DataGridViewTextBoxColumn
    Friend WithEvents PorcentajeDescuento As DataGridViewTextBoxColumn
    Friend WithEvents ImporteDescuento As DataGridViewTextBoxColumn
    Friend WithEvents ImporteConDescuento As DataGridViewTextBoxColumn
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents lblImporteDescuentos As Label
    Friend WithEvents lblPorcentajeAplicado As Label
    Friend WithEvents lblImporteSinDescuentos As Label
    Friend WithEvents lblCantidadItems As Label
    Friend WithEvents lblImporteConDescuentos As Label
    Friend WithEvents ElimininarItemSeleccionadoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AplicarDescuentoItemSeleccionadoToolStripMenuItem As ToolStripMenuItem
End Class
