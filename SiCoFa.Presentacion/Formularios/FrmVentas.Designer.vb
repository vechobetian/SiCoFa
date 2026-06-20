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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmVentas))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblPorcentajeAplicado = New System.Windows.Forms.Label()
        Me.lblImporteDescuentosEtiqueta = New System.Windows.Forms.Label()
        Me.lblImporteDescuentos = New System.Windows.Forms.Label()
        Me.lblImporteSinDescuentos = New System.Windows.Forms.Label()
        Me.lblImporteSinDescuentosEtiqueta = New System.Windows.Forms.Label()
        Me.lblImporteConDescuentosEtiqueta = New System.Windows.Forms.Label()
        Me.lblImporteConDescuentos = New System.Windows.Forms.Label()
        Me.lblImporteOSEtiqueta = New System.Windows.Forms.Label()
        Me.lblImporteCSEtiqueda = New System.Windows.Forms.Label()
        Me.lblImporteOS = New System.Windows.Forms.Label()
        Me.lblImporteCS = New System.Windows.Forms.Label()
        Me.lblCantidadItems = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblImporteAfRecetaEtiqueta = New System.Windows.Forms.Label()
        Me.lblPlanOSEtiqueta = New System.Windows.Forms.Label()
        Me.lblImporteCSRecetaEtiqueta = New System.Windows.Forms.Label()
        Me.lblImporteOSRecetaEtiqueta = New System.Windows.Forms.Label()
        Me.lblDatosOperacion = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.NuevoToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.AbrirToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.GuardarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ImprimirToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.InsertRecetaToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.PegarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ClienteToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.DesRecToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.AyudaToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SalirToolStripButton = New System.Windows.Forms.ToolStripButton()
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
        Me.PanelItems = New System.Windows.Forms.Panel()
        Me.lblIdRecetaEtiqueta = New System.Windows.Forms.Label()
        Me.lblIdReceta = New System.Windows.Forms.Label()
        Me.lblPlanOS = New System.Windows.Forms.Label()
        Me.lblImporteOSReceta = New System.Windows.Forms.Label()
        Me.lblmporteCSReceta = New System.Windows.Forms.Label()
        Me.lblImporteAFReceta = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
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
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.PanelItems, 0, 1)
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
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 183.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.lblPorcentajeAplicado, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.lblImporteDescuentosEtiqueta, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.lblImporteDescuentos, 2, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.lblImporteSinDescuentos, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lblImporteSinDescuentosEtiqueta, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lblImporteConDescuentosEtiqueta, 1, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.lblImporteConDescuentos, 2, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.lblImporteOSEtiqueta, 1, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.lblImporteCSEtiqueda, 1, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.lblImporteOS, 2, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.lblImporteCS, 2, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.lblCantidadItems, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Panel2, 0, 2)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 5
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(970, 182)
        Me.TableLayoutPanel3.TabIndex = 7
        '
        'lblPorcentajeAplicado
        '
        Me.lblPorcentajeAplicado.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblPorcentajeAplicado.AutoSize = True
        Me.lblPorcentajeAplicado.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPorcentajeAplicado.Location = New System.Drawing.Point(6, 31)
        Me.lblPorcentajeAplicado.Name = "lblPorcentajeAplicado"
        Me.lblPorcentajeAplicado.Size = New System.Drawing.Size(230, 21)
        Me.lblPorcentajeAplicado.TabIndex = 27
        Me.lblPorcentajeAplicado.Text = "- Porcentaje Descuentos: 0,00 %"
        '
        'lblImporteDescuentosEtiqueta
        '
        Me.lblImporteDescuentosEtiqueta.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblImporteDescuentosEtiqueta.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteDescuentosEtiqueta.Location = New System.Drawing.Point(641, 30)
        Me.lblImporteDescuentosEtiqueta.Name = "lblImporteDescuentosEtiqueta"
        Me.lblImporteDescuentosEtiqueta.Size = New System.Drawing.Size(137, 24)
        Me.lblImporteDescuentosEtiqueta.TabIndex = 8
        Me.lblImporteDescuentosEtiqueta.Text = "Descuentos:"
        Me.lblImporteDescuentosEtiqueta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblImporteDescuentos
        '
        Me.lblImporteDescuentos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImporteDescuentos.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteDescuentos.Location = New System.Drawing.Point(787, 30)
        Me.lblImporteDescuentos.Name = "lblImporteDescuentos"
        Me.lblImporteDescuentos.Size = New System.Drawing.Size(177, 24)
        Me.lblImporteDescuentos.TabIndex = 13
        Me.lblImporteDescuentos.Text = "$ 0,00"
        Me.lblImporteDescuentos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblImporteSinDescuentos
        '
        Me.lblImporteSinDescuentos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImporteSinDescuentos.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteSinDescuentos.Location = New System.Drawing.Point(787, 3)
        Me.lblImporteSinDescuentos.Name = "lblImporteSinDescuentos"
        Me.lblImporteSinDescuentos.Size = New System.Drawing.Size(177, 24)
        Me.lblImporteSinDescuentos.TabIndex = 11
        Me.lblImporteSinDescuentos.Text = "$ 0,00"
        Me.lblImporteSinDescuentos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblImporteSinDescuentosEtiqueta
        '
        Me.lblImporteSinDescuentosEtiqueta.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblImporteSinDescuentosEtiqueta.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteSinDescuentosEtiqueta.Location = New System.Drawing.Point(641, 3)
        Me.lblImporteSinDescuentosEtiqueta.Name = "lblImporteSinDescuentosEtiqueta"
        Me.lblImporteSinDescuentosEtiqueta.Size = New System.Drawing.Size(137, 24)
        Me.lblImporteSinDescuentosEtiqueta.TabIndex = 6
        Me.lblImporteSinDescuentosEtiqueta.Text = "Importe Bruto:"
        Me.lblImporteSinDescuentosEtiqueta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblImporteConDescuentosEtiqueta
        '
        Me.lblImporteConDescuentosEtiqueta.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblImporteConDescuentosEtiqueta.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteConDescuentosEtiqueta.Location = New System.Drawing.Point(641, 111)
        Me.lblImporteConDescuentosEtiqueta.Name = "lblImporteConDescuentosEtiqueta"
        Me.lblImporteConDescuentosEtiqueta.Size = New System.Drawing.Size(137, 68)
        Me.lblImporteConDescuentosEtiqueta.TabIndex = 20
        Me.lblImporteConDescuentosEtiqueta.Text = "A pagar:  "
        Me.lblImporteConDescuentosEtiqueta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblImporteConDescuentos
        '
        Me.lblImporteConDescuentos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImporteConDescuentos.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteConDescuentos.Location = New System.Drawing.Point(787, 111)
        Me.lblImporteConDescuentos.Name = "lblImporteConDescuentos"
        Me.lblImporteConDescuentos.Size = New System.Drawing.Size(177, 68)
        Me.lblImporteConDescuentos.TabIndex = 14
        Me.lblImporteConDescuentos.Text = "$ 0,00"
        Me.lblImporteConDescuentos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblImporteOSEtiqueta
        '
        Me.lblImporteOSEtiqueta.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblImporteOSEtiqueta.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteOSEtiqueta.Location = New System.Drawing.Point(641, 57)
        Me.lblImporteOSEtiqueta.Name = "lblImporteOSEtiqueta"
        Me.lblImporteOSEtiqueta.Size = New System.Drawing.Size(137, 24)
        Me.lblImporteOSEtiqueta.TabIndex = 21
        Me.lblImporteOSEtiqueta.Text = "Obra Sociales:"
        Me.lblImporteOSEtiqueta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblImporteCSEtiqueda
        '
        Me.lblImporteCSEtiqueda.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblImporteCSEtiqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteCSEtiqueda.Location = New System.Drawing.Point(641, 84)
        Me.lblImporteCSEtiqueda.Name = "lblImporteCSEtiqueda"
        Me.lblImporteCSEtiqueda.Size = New System.Drawing.Size(137, 24)
        Me.lblImporteCSEtiqueda.TabIndex = 22
        Me.lblImporteCSEtiqueda.Text = "Coseguros:"
        Me.lblImporteCSEtiqueda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblImporteOS
        '
        Me.lblImporteOS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImporteOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteOS.Location = New System.Drawing.Point(787, 57)
        Me.lblImporteOS.Name = "lblImporteOS"
        Me.lblImporteOS.Size = New System.Drawing.Size(177, 24)
        Me.lblImporteOS.TabIndex = 23
        Me.lblImporteOS.Text = "$ 0,00"
        Me.lblImporteOS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblImporteCS
        '
        Me.lblImporteCS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImporteCS.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteCS.Location = New System.Drawing.Point(787, 84)
        Me.lblImporteCS.Name = "lblImporteCS"
        Me.lblImporteCS.Size = New System.Drawing.Size(177, 24)
        Me.lblImporteCS.TabIndex = 24
        Me.lblImporteCS.Text = "$ 0,00"
        Me.lblImporteCS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCantidadItems
        '
        Me.lblCantidadItems.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblCantidadItems.AutoSize = True
        Me.lblCantidadItems.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidadItems.Location = New System.Drawing.Point(6, 4)
        Me.lblCantidadItems.Name = "lblCantidadItems"
        Me.lblCantidadItems.Size = New System.Drawing.Size(74, 21)
        Me.lblCantidadItems.TabIndex = 26
        Me.lblCantidadItems.Text = "- Items: 0"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 57)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.TableLayoutPanel3.SetRowSpan(Me.Panel2, 3)
        Me.Panel2.Size = New System.Drawing.Size(625, 122)
        Me.Panel2.TabIndex = 28
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.lblImporteAFReceta, 2, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.lblmporteCSReceta, 2, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.lblImporteOSReceta, 2, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.lblPlanOS, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblIdReceta, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblIdRecetaEtiqueta, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblPlanOSEtiqueta, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblImporteOSRecetaEtiqueta, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.lblImporteCSRecetaEtiqueta, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.lblImporteAfRecetaEtiqueta, 1, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.lblDatosOperacion, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 5
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(625, 122)
        Me.TableLayoutPanel2.TabIndex = 6
        '
        'lblImporteAfRecetaEtiqueta
        '
        Me.lblImporteAfRecetaEtiqueta.AutoSize = True
        Me.lblImporteAfRecetaEtiqueta.BackColor = System.Drawing.SystemColors.Window
        Me.lblImporteAfRecetaEtiqueta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImporteAfRecetaEtiqueta.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteAfRecetaEtiqueta.Location = New System.Drawing.Point(269, 95)
        Me.lblImporteAfRecetaEtiqueta.Margin = New System.Windows.Forms.Padding(0)
        Me.lblImporteAfRecetaEtiqueta.Name = "lblImporteAfRecetaEtiqueta"
        Me.lblImporteAfRecetaEtiqueta.Size = New System.Drawing.Size(100, 24)
        Me.lblImporteAfRecetaEtiqueta.TabIndex = 5
        Me.lblImporteAfRecetaEtiqueta.Text = "Importe AF:"
        '
        'lblPlanOSEtiqueta
        '
        Me.lblPlanOSEtiqueta.AutoSize = True
        Me.lblPlanOSEtiqueta.BackColor = System.Drawing.SystemColors.Window
        Me.lblPlanOSEtiqueta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPlanOSEtiqueta.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlanOSEtiqueta.Location = New System.Drawing.Point(269, 26)
        Me.lblPlanOSEtiqueta.Margin = New System.Windows.Forms.Padding(0)
        Me.lblPlanOSEtiqueta.Name = "lblPlanOSEtiqueta"
        Me.lblPlanOSEtiqueta.Size = New System.Drawing.Size(100, 20)
        Me.lblPlanOSEtiqueta.TabIndex = 2
        Me.lblPlanOSEtiqueta.Text = "Plan:"
        '
        'lblImporteCSRecetaEtiqueta
        '
        Me.lblImporteCSRecetaEtiqueta.AutoSize = True
        Me.lblImporteCSRecetaEtiqueta.BackColor = System.Drawing.SystemColors.Window
        Me.lblImporteCSRecetaEtiqueta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImporteCSRecetaEtiqueta.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteCSRecetaEtiqueta.Location = New System.Drawing.Point(269, 72)
        Me.lblImporteCSRecetaEtiqueta.Margin = New System.Windows.Forms.Padding(0)
        Me.lblImporteCSRecetaEtiqueta.Name = "lblImporteCSRecetaEtiqueta"
        Me.lblImporteCSRecetaEtiqueta.Size = New System.Drawing.Size(100, 20)
        Me.lblImporteCSRecetaEtiqueta.TabIndex = 4
        Me.lblImporteCSRecetaEtiqueta.Text = "Importe CS:"
        '
        'lblImporteOSRecetaEtiqueta
        '
        Me.lblImporteOSRecetaEtiqueta.AutoSize = True
        Me.lblImporteOSRecetaEtiqueta.BackColor = System.Drawing.SystemColors.Window
        Me.lblImporteOSRecetaEtiqueta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImporteOSRecetaEtiqueta.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteOSRecetaEtiqueta.Location = New System.Drawing.Point(269, 49)
        Me.lblImporteOSRecetaEtiqueta.Margin = New System.Windows.Forms.Padding(0)
        Me.lblImporteOSRecetaEtiqueta.Name = "lblImporteOSRecetaEtiqueta"
        Me.lblImporteOSRecetaEtiqueta.Size = New System.Drawing.Size(100, 20)
        Me.lblImporteOSRecetaEtiqueta.TabIndex = 3
        Me.lblImporteOSRecetaEtiqueta.Text = "Importe OS:"
        '
        'lblDatosOperacion
        '
        Me.lblDatosOperacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDatosOperacion.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatosOperacion.Location = New System.Drawing.Point(3, 3)
        Me.lblDatosOperacion.Margin = New System.Windows.Forms.Padding(0)
        Me.lblDatosOperacion.Name = "lblDatosOperacion"
        Me.TableLayoutPanel2.SetRowSpan(Me.lblDatosOperacion, 5)
        Me.lblDatosOperacion.Size = New System.Drawing.Size(263, 116)
        Me.lblDatosOperacion.TabIndex = 0
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
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoToolStripButton, Me.AbrirToolStripButton, Me.GuardarToolStripButton, Me.ImprimirToolStripButton, Me.toolStripSeparator, Me.InsertRecetaToolStripButton, Me.PegarToolStripButton, Me.ClienteToolStripButton, Me.DesRecToolStripButton1, Me.AyudaToolStripButton, Me.ToolStripSeparator1, Me.SalirToolStripButton})
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
        'InsertRecetaToolStripButton
        '
        Me.InsertRecetaToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.InsertRecetaToolStripButton.Image = CType(resources.GetObject("InsertRecetaToolStripButton.Image"), System.Drawing.Image)
        Me.InsertRecetaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.InsertRecetaToolStripButton.Name = "InsertRecetaToolStripButton"
        Me.InsertRecetaToolStripButton.Size = New System.Drawing.Size(23, 35)
        Me.InsertRecetaToolStripButton.Text = "&Copiar"
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
        'PanelItems
        '
        Me.PanelItems.BackColor = System.Drawing.SystemColors.Window
        Me.PanelItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelItems.Location = New System.Drawing.Point(6, 77)
        Me.PanelItems.Name = "PanelItems"
        Me.PanelItems.Size = New System.Drawing.Size(972, 385)
        Me.PanelItems.TabIndex = 6
        '
        'lblIdRecetaEtiqueta
        '
        Me.lblIdRecetaEtiqueta.AutoSize = True
        Me.lblIdRecetaEtiqueta.BackColor = System.Drawing.SystemColors.Window
        Me.lblIdRecetaEtiqueta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblIdRecetaEtiqueta.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdRecetaEtiqueta.Location = New System.Drawing.Point(269, 3)
        Me.lblIdRecetaEtiqueta.Margin = New System.Windows.Forms.Padding(0)
        Me.lblIdRecetaEtiqueta.Name = "lblIdRecetaEtiqueta"
        Me.lblIdRecetaEtiqueta.Size = New System.Drawing.Size(100, 20)
        Me.lblIdRecetaEtiqueta.TabIndex = 6
        Me.lblIdRecetaEtiqueta.Text = "IdReceta:"
        '
        'lblIdReceta
        '
        Me.lblIdReceta.AutoSize = True
        Me.lblIdReceta.BackColor = System.Drawing.SystemColors.Window
        Me.lblIdReceta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblIdReceta.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdReceta.Location = New System.Drawing.Point(372, 3)
        Me.lblIdReceta.Margin = New System.Windows.Forms.Padding(0)
        Me.lblIdReceta.Name = "lblIdReceta"
        Me.lblIdReceta.Size = New System.Drawing.Size(250, 20)
        Me.lblIdReceta.TabIndex = 7
        Me.lblIdReceta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPlanOS
        '
        Me.lblPlanOS.AutoSize = True
        Me.lblPlanOS.BackColor = System.Drawing.SystemColors.Window
        Me.lblPlanOS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPlanOS.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlanOS.Location = New System.Drawing.Point(372, 26)
        Me.lblPlanOS.Margin = New System.Windows.Forms.Padding(0)
        Me.lblPlanOS.Name = "lblPlanOS"
        Me.lblPlanOS.Size = New System.Drawing.Size(250, 20)
        Me.lblPlanOS.TabIndex = 8
        Me.lblPlanOS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblImporteOSReceta
        '
        Me.lblImporteOSReceta.AutoSize = True
        Me.lblImporteOSReceta.BackColor = System.Drawing.SystemColors.Window
        Me.lblImporteOSReceta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImporteOSReceta.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteOSReceta.Location = New System.Drawing.Point(372, 49)
        Me.lblImporteOSReceta.Margin = New System.Windows.Forms.Padding(0)
        Me.lblImporteOSReceta.Name = "lblImporteOSReceta"
        Me.lblImporteOSReceta.Size = New System.Drawing.Size(250, 20)
        Me.lblImporteOSReceta.TabIndex = 9
        Me.lblImporteOSReceta.Text = "$ 0,00"
        Me.lblImporteOSReceta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblmporteCSReceta
        '
        Me.lblmporteCSReceta.AutoSize = True
        Me.lblmporteCSReceta.BackColor = System.Drawing.SystemColors.Window
        Me.lblmporteCSReceta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblmporteCSReceta.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmporteCSReceta.Location = New System.Drawing.Point(372, 72)
        Me.lblmporteCSReceta.Margin = New System.Windows.Forms.Padding(0)
        Me.lblmporteCSReceta.Name = "lblmporteCSReceta"
        Me.lblmporteCSReceta.Size = New System.Drawing.Size(250, 20)
        Me.lblmporteCSReceta.TabIndex = 10
        Me.lblmporteCSReceta.Text = "$ 0,00"
        Me.lblmporteCSReceta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblImporteAFReceta
        '
        Me.lblImporteAFReceta.AutoSize = True
        Me.lblImporteAFReceta.BackColor = System.Drawing.SystemColors.Window
        Me.lblImporteAFReceta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImporteAFReceta.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteAFReceta.Location = New System.Drawing.Point(372, 95)
        Me.lblImporteAFReceta.Margin = New System.Windows.Forms.Padding(0)
        Me.lblImporteAFReceta.Name = "lblImporteAFReceta"
        Me.lblImporteAFReceta.Size = New System.Drawing.Size(250, 24)
        Me.lblImporteAFReceta.TabIndex = 11
        Me.lblImporteAFReceta.Text = "$ 0,00"
        Me.lblImporteAFReceta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FrmVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 661)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "FrmVentas"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
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
    Friend WithEvents InsertRecetaToolStripButton As ToolStripButton
    Friend WithEvents PegarToolStripButton As ToolStripButton
    Friend WithEvents AyudaToolStripButton As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
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
    Friend WithEvents Panel3 As Panel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents lblImporteDescuentosEtiqueta As Label
    Friend WithEvents lblImporteDescuentos As Label
    Friend WithEvents lblImporteSinDescuentos As Label
    Friend WithEvents lblImporteSinDescuentosEtiqueta As Label
    Friend WithEvents lblImporteConDescuentos As Label
    Friend WithEvents PanelItems As Panel
    Friend WithEvents lblImporteConDescuentosEtiqueta As Label
    Friend WithEvents lblImporteOSEtiqueta As Label
    Friend WithEvents lblImporteCSEtiqueda As Label
    Friend WithEvents lblImporteOS As Label
    Friend WithEvents lblImporteCS As Label
    Friend WithEvents lblPorcentajeAplicado As Label
    Friend WithEvents lblCantidadItems As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblDatosOperacion As Label
    Friend WithEvents lblImporteCSRecetaEtiqueta As Label
    Friend WithEvents lblImporteOSRecetaEtiqueta As Label
    Friend WithEvents lblPlanOSEtiqueta As Label
    Friend WithEvents lblImporteAfRecetaEtiqueta As Label
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents lblIdRecetaEtiqueta As Label
    Friend WithEvents lblImporteAFReceta As Label
    Friend WithEvents lblmporteCSReceta As Label
    Friend WithEvents lblImporteOSReceta As Label
    Friend WithEvents lblPlanOS As Label
    Friend WithEvents lblIdReceta As Label
End Class
