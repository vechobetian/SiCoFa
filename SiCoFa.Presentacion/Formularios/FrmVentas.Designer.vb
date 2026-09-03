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
        Me.lblDescuentos = New System.Windows.Forms.Label()
        Me.lblImporteDescuentos = New System.Windows.Forms.Label()
        Me.lblImporteSinDescuentos = New System.Windows.Forms.Label()
        Me.lblImporteSinDescuentosEtiqueta = New System.Windows.Forms.Label()
        Me.lblImporteConDescuentosEtiqueta = New System.Windows.Forms.Label()
        Me.lblImporteConDescuentos = New System.Windows.Forms.Label()
        Me.lblImporteOSEtiqueta = New System.Windows.Forms.Label()
        Me.lblImporteCSEtiqueda = New System.Windows.Forms.Label()
        Me.lblImporteOS = New System.Windows.Forms.Label()
        Me.lblImporteCS = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblDatosOperacion = New System.Windows.Forms.Label()
        Me.lblCantidadItems = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnNuevaReceta = New System.Windows.Forms.ToolStripButton()
        Me.btnDatosReceta = New System.Windows.Forms.ToolStripButton()
        Me.btnEliminarReceta = New System.Windows.Forms.ToolStripButton()
        Me.btnSolicitarAutorizacionReceta = New System.Windows.Forms.ToolStripButton()
        Me.btnCancelarAutorizacion = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.btnDescuentoGeneral = New System.Windows.Forms.ToolStripButton()
        Me.btnRecargoGeneral = New System.Windows.Forms.ToolStripButton()
        Me.ClienteToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.AyudaToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SalirToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnuArchivo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuGuardar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditarItemSeleccionado = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEliminarItemSeleccionado = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAplicarDescuentoItemSeleccionado = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuModificarPrecioItemSeleccionado = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPresentacionesEquivalentes = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPresentacionesConIgualAccionFarmacologica = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPresentacionesConIgualMonodroga = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuObrasSociales = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuNuevaReceta = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDatosReceta = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuElinarReceta = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAutorizarReceta = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCancelarAutorizacion = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuProcesos = New System.Windows.Forms.ToolStripMenuItem()
        Me.FacturarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemitoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PresupuestoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOpciones = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDescuentoGeneral = New System.Windows.Forms.ToolStripMenuItem()
        Me.PanelItems = New System.Windows.Forms.Panel()
        Me.UcReceta1 = New SiCoFa.Presentacion.UcReceta()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
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
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 525.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.lblDescuentos, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.lblImporteDescuentos, 2, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.lblImporteSinDescuentos, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lblImporteSinDescuentosEtiqueta, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lblImporteConDescuentosEtiqueta, 1, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.lblImporteConDescuentos, 2, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.lblImporteOSEtiqueta, 1, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.lblImporteCSEtiqueda, 1, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.lblImporteOS, 2, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.lblImporteCS, 2, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.Panel2, 0, 0)
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
        'lblDescuentos
        '
        Me.lblDescuentos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDescuentos.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescuentos.Location = New System.Drawing.Point(262, 30)
        Me.lblDescuentos.Name = "lblDescuentos"
        Me.lblDescuentos.Size = New System.Drawing.Size(174, 24)
        Me.lblDescuentos.TabIndex = 8
        Me.lblDescuentos.Text = "Descuentos:"
        Me.lblDescuentos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblImporteDescuentos
        '
        Me.lblImporteDescuentos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImporteDescuentos.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteDescuentos.Location = New System.Drawing.Point(445, 30)
        Me.lblImporteDescuentos.Name = "lblImporteDescuentos"
        Me.lblImporteDescuentos.Size = New System.Drawing.Size(519, 24)
        Me.lblImporteDescuentos.TabIndex = 13
        Me.lblImporteDescuentos.Text = "$ 0,00"
        Me.lblImporteDescuentos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblImporteSinDescuentos
        '
        Me.lblImporteSinDescuentos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImporteSinDescuentos.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteSinDescuentos.Location = New System.Drawing.Point(445, 3)
        Me.lblImporteSinDescuentos.Name = "lblImporteSinDescuentos"
        Me.lblImporteSinDescuentos.Size = New System.Drawing.Size(519, 24)
        Me.lblImporteSinDescuentos.TabIndex = 11
        Me.lblImporteSinDescuentos.Text = "$ 0,00"
        Me.lblImporteSinDescuentos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblImporteSinDescuentosEtiqueta
        '
        Me.lblImporteSinDescuentosEtiqueta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImporteSinDescuentosEtiqueta.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteSinDescuentosEtiqueta.Location = New System.Drawing.Point(262, 3)
        Me.lblImporteSinDescuentosEtiqueta.Name = "lblImporteSinDescuentosEtiqueta"
        Me.lblImporteSinDescuentosEtiqueta.Size = New System.Drawing.Size(174, 24)
        Me.lblImporteSinDescuentosEtiqueta.TabIndex = 6
        Me.lblImporteSinDescuentosEtiqueta.Text = "Importe Bruto:"
        Me.lblImporteSinDescuentosEtiqueta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblImporteConDescuentosEtiqueta
        '
        Me.lblImporteConDescuentosEtiqueta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImporteConDescuentosEtiqueta.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteConDescuentosEtiqueta.Location = New System.Drawing.Point(262, 111)
        Me.lblImporteConDescuentosEtiqueta.Name = "lblImporteConDescuentosEtiqueta"
        Me.lblImporteConDescuentosEtiqueta.Size = New System.Drawing.Size(174, 68)
        Me.lblImporteConDescuentosEtiqueta.TabIndex = 20
        Me.lblImporteConDescuentosEtiqueta.Text = "A pagar:  "
        Me.lblImporteConDescuentosEtiqueta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblImporteConDescuentos
        '
        Me.lblImporteConDescuentos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImporteConDescuentos.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteConDescuentos.Location = New System.Drawing.Point(445, 111)
        Me.lblImporteConDescuentos.Name = "lblImporteConDescuentos"
        Me.lblImporteConDescuentos.Size = New System.Drawing.Size(519, 68)
        Me.lblImporteConDescuentos.TabIndex = 14
        Me.lblImporteConDescuentos.Text = "$ 0,00"
        Me.lblImporteConDescuentos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblImporteOSEtiqueta
        '
        Me.lblImporteOSEtiqueta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImporteOSEtiqueta.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteOSEtiqueta.Location = New System.Drawing.Point(262, 57)
        Me.lblImporteOSEtiqueta.Name = "lblImporteOSEtiqueta"
        Me.lblImporteOSEtiqueta.Size = New System.Drawing.Size(174, 24)
        Me.lblImporteOSEtiqueta.TabIndex = 21
        Me.lblImporteOSEtiqueta.Text = "Obra Sociales:"
        Me.lblImporteOSEtiqueta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblImporteCSEtiqueda
        '
        Me.lblImporteCSEtiqueda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImporteCSEtiqueda.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteCSEtiqueda.Location = New System.Drawing.Point(262, 84)
        Me.lblImporteCSEtiqueda.Name = "lblImporteCSEtiqueda"
        Me.lblImporteCSEtiqueda.Size = New System.Drawing.Size(174, 24)
        Me.lblImporteCSEtiqueda.TabIndex = 22
        Me.lblImporteCSEtiqueda.Text = "Coseguros:"
        Me.lblImporteCSEtiqueda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblImporteOS
        '
        Me.lblImporteOS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImporteOS.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteOS.Location = New System.Drawing.Point(445, 57)
        Me.lblImporteOS.Name = "lblImporteOS"
        Me.lblImporteOS.Size = New System.Drawing.Size(519, 24)
        Me.lblImporteOS.TabIndex = 23
        Me.lblImporteOS.Text = "$ 0,00"
        Me.lblImporteOS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblImporteCS
        '
        Me.lblImporteCS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImporteCS.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteCS.Location = New System.Drawing.Point(445, 84)
        Me.lblImporteCS.Name = "lblImporteCS"
        Me.lblImporteCS.Size = New System.Drawing.Size(519, 24)
        Me.lblImporteCS.TabIndex = 24
        Me.lblImporteCS.Text = "$ 0,00"
        Me.lblImporteCS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.UcReceta1)
        Me.Panel2.Controls.Add(Me.lblDatosOperacion)
        Me.Panel2.Controls.Add(Me.lblCantidadItems)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.TableLayoutPanel3.SetRowSpan(Me.Panel2, 5)
        Me.Panel2.Size = New System.Drawing.Size(253, 176)
        Me.Panel2.TabIndex = 25
        '
        'lblDatosOperacion
        '
        Me.lblDatosOperacion.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatosOperacion.Location = New System.Drawing.Point(0, 59)
        Me.lblDatosOperacion.Margin = New System.Windows.Forms.Padding(0)
        Me.lblDatosOperacion.Name = "lblDatosOperacion"
        Me.lblDatosOperacion.Size = New System.Drawing.Size(595, 109)
        Me.lblDatosOperacion.TabIndex = 29
        Me.lblDatosOperacion.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lblCantidadItems
        '
        Me.lblCantidadItems.AutoSize = True
        Me.lblCantidadItems.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidadItems.Location = New System.Drawing.Point(3, 3)
        Me.lblCantidadItems.Name = "lblCantidadItems"
        Me.lblCantidadItems.Size = New System.Drawing.Size(66, 17)
        Me.lblCantidadItems.TabIndex = 30
        Me.lblCantidadItems.Text = "- Items: 0"
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
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevaReceta, Me.btnDatosReceta, Me.btnEliminarReceta, Me.btnSolicitarAutorizacionReceta, Me.btnCancelarAutorizacion, Me.toolStripSeparator, Me.btnDescuentoGeneral, Me.btnRecargoGeneral, Me.ClienteToolStripButton, Me.AyudaToolStripButton, Me.ToolStripButton1, Me.ToolStripSeparator1, Me.SalirToolStripButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(972, 38)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnNuevaReceta
        '
        Me.btnNuevaReceta.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnNuevaReceta.Image = CType(resources.GetObject("btnNuevaReceta.Image"), System.Drawing.Image)
        Me.btnNuevaReceta.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNuevaReceta.Name = "btnNuevaReceta"
        Me.btnNuevaReceta.Size = New System.Drawing.Size(23, 35)
        Me.btnNuevaReceta.Text = "&Nueva Receta"
        Me.btnNuevaReceta.ToolTipText = "Nueva Receta"
        '
        'btnDatosReceta
        '
        Me.btnDatosReceta.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnDatosReceta.Image = CType(resources.GetObject("btnDatosReceta.Image"), System.Drawing.Image)
        Me.btnDatosReceta.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDatosReceta.Name = "btnDatosReceta"
        Me.btnDatosReceta.Size = New System.Drawing.Size(23, 35)
        Me.btnDatosReceta.Text = "&Datos Receta"
        Me.btnDatosReceta.ToolTipText = "Datos Receta"
        '
        'btnEliminarReceta
        '
        Me.btnEliminarReceta.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnEliminarReceta.Image = CType(resources.GetObject("btnEliminarReceta.Image"), System.Drawing.Image)
        Me.btnEliminarReceta.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEliminarReceta.Name = "btnEliminarReceta"
        Me.btnEliminarReceta.Size = New System.Drawing.Size(23, 35)
        Me.btnEliminarReceta.Text = "&Eliminar Receta"
        '
        'btnSolicitarAutorizacionReceta
        '
        Me.btnSolicitarAutorizacionReceta.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSolicitarAutorizacionReceta.Image = CType(resources.GetObject("btnSolicitarAutorizacionReceta.Image"), System.Drawing.Image)
        Me.btnSolicitarAutorizacionReceta.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSolicitarAutorizacionReceta.Name = "btnSolicitarAutorizacionReceta"
        Me.btnSolicitarAutorizacionReceta.Size = New System.Drawing.Size(23, 35)
        Me.btnSolicitarAutorizacionReceta.Text = "&Autorizar Receta"
        '
        'btnCancelarAutorizacion
        '
        Me.btnCancelarAutorizacion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnCancelarAutorizacion.Image = CType(resources.GetObject("btnCancelarAutorizacion.Image"), System.Drawing.Image)
        Me.btnCancelarAutorizacion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancelarAutorizacion.Name = "btnCancelarAutorizacion"
        Me.btnCancelarAutorizacion.Size = New System.Drawing.Size(23, 35)
        Me.btnCancelarAutorizacion.Text = "CancelarAutorizacion"
        Me.btnCancelarAutorizacion.ToolTipText = "Cancelar Autorizacion"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 38)
        '
        'btnDescuentoGeneral
        '
        Me.btnDescuentoGeneral.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnDescuentoGeneral.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDescuentoGeneral.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDescuentoGeneral.Name = "btnDescuentoGeneral"
        Me.btnDescuentoGeneral.Size = New System.Drawing.Size(35, 35)
        Me.btnDescuentoGeneral.Text = "↓%"
        Me.btnDescuentoGeneral.ToolTipText = "Descuento General"
        '
        'btnRecargoGeneral
        '
        Me.btnRecargoGeneral.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnRecargoGeneral.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRecargoGeneral.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRecargoGeneral.Name = "btnRecargoGeneral"
        Me.btnRecargoGeneral.Size = New System.Drawing.Size(35, 35)
        Me.btnRecargoGeneral.Text = "↑%"
        Me.btnRecargoGeneral.ToolTipText = "Recargo General"
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
        'AyudaToolStripButton
        '
        Me.AyudaToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AyudaToolStripButton.Image = CType(resources.GetObject("AyudaToolStripButton.Image"), System.Drawing.Image)
        Me.AyudaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AyudaToolStripButton.Name = "AyudaToolStripButton"
        Me.AyudaToolStripButton.Size = New System.Drawing.Size(23, 35)
        Me.AyudaToolStripButton.Text = "Ay&uda"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 35)
        Me.ToolStripButton1.Text = "ToolStripButton1"
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
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuArchivo, Me.mnuEditarItemSeleccionado, Me.mnuObrasSociales, Me.mnuProcesos, Me.mnuOpciones})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(972, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnuArchivo
        '
        Me.mnuArchivo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuGuardar, Me.mnuSalir})
        Me.mnuArchivo.Name = "mnuArchivo"
        Me.mnuArchivo.Size = New System.Drawing.Size(60, 20)
        Me.mnuArchivo.Text = "&Archivo"
        '
        'mnuGuardar
        '
        Me.mnuGuardar.Image = CType(resources.GetObject("mnuGuardar.Image"), System.Drawing.Image)
        Me.mnuGuardar.Name = "mnuGuardar"
        Me.mnuGuardar.Size = New System.Drawing.Size(116, 22)
        Me.mnuGuardar.Text = "&Guardar"
        '
        'mnuSalir
        '
        Me.mnuSalir.Image = CType(resources.GetObject("mnuSalir.Image"), System.Drawing.Image)
        Me.mnuSalir.Name = "mnuSalir"
        Me.mnuSalir.Size = New System.Drawing.Size(116, 22)
        Me.mnuSalir.Text = "&Salir"
        '
        'mnuEditarItemSeleccionado
        '
        Me.mnuEditarItemSeleccionado.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuEliminarItemSeleccionado, Me.mnuAplicarDescuentoItemSeleccionado, Me.mnuModificarPrecioItemSeleccionado, Me.mnuPresentacionesEquivalentes, Me.mnuPresentacionesConIgualAccionFarmacologica, Me.mnuPresentacionesConIgualMonodroga})
        Me.mnuEditarItemSeleccionado.Name = "mnuEditarItemSeleccionado"
        Me.mnuEditarItemSeleccionado.Size = New System.Drawing.Size(76, 20)
        Me.mnuEditarItemSeleccionado.Text = "&Editar Item"
        '
        'mnuEliminarItemSeleccionado
        '
        Me.mnuEliminarItemSeleccionado.Image = CType(resources.GetObject("mnuEliminarItemSeleccionado.Image"), System.Drawing.Image)
        Me.mnuEliminarItemSeleccionado.Name = "mnuEliminarItemSeleccionado"
        Me.mnuEliminarItemSeleccionado.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.mnuEliminarItemSeleccionado.Size = New System.Drawing.Size(328, 22)
        Me.mnuEliminarItemSeleccionado.Text = "&Elimininar Item seleccionado"
        '
        'mnuAplicarDescuentoItemSeleccionado
        '
        Me.mnuAplicarDescuentoItemSeleccionado.Image = CType(resources.GetObject("mnuAplicarDescuentoItemSeleccionado.Image"), System.Drawing.Image)
        Me.mnuAplicarDescuentoItemSeleccionado.Name = "mnuAplicarDescuentoItemSeleccionado"
        Me.mnuAplicarDescuentoItemSeleccionado.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.mnuAplicarDescuentoItemSeleccionado.Size = New System.Drawing.Size(328, 22)
        Me.mnuAplicarDescuentoItemSeleccionado.Text = "Aplicar &Descuento Item seleccionado"
        '
        'mnuModificarPrecioItemSeleccionado
        '
        Me.mnuModificarPrecioItemSeleccionado.Image = CType(resources.GetObject("mnuModificarPrecioItemSeleccionado.Image"), System.Drawing.Image)
        Me.mnuModificarPrecioItemSeleccionado.Name = "mnuModificarPrecioItemSeleccionado"
        Me.mnuModificarPrecioItemSeleccionado.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.mnuModificarPrecioItemSeleccionado.Size = New System.Drawing.Size(328, 22)
        Me.mnuModificarPrecioItemSeleccionado.Text = "&Modificar precio Item seleccionado"
        '
        'mnuPresentacionesEquivalentes
        '
        Me.mnuPresentacionesEquivalentes.Image = CType(resources.GetObject("mnuPresentacionesEquivalentes.Image"), System.Drawing.Image)
        Me.mnuPresentacionesEquivalentes.Name = "mnuPresentacionesEquivalentes"
        Me.mnuPresentacionesEquivalentes.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.mnuPresentacionesEquivalentes.Size = New System.Drawing.Size(328, 22)
        Me.mnuPresentacionesEquivalentes.Text = "Presentaciones Equivalentes"
        '
        'mnuPresentacionesConIgualAccionFarmacologica
        '
        Me.mnuPresentacionesConIgualAccionFarmacologica.Image = CType(resources.GetObject("mnuPresentacionesConIgualAccionFarmacologica.Image"), System.Drawing.Image)
        Me.mnuPresentacionesConIgualAccionFarmacologica.Name = "mnuPresentacionesConIgualAccionFarmacologica"
        Me.mnuPresentacionesConIgualAccionFarmacologica.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.mnuPresentacionesConIgualAccionFarmacologica.Size = New System.Drawing.Size(328, 22)
        Me.mnuPresentacionesConIgualAccionFarmacologica.Text = "Presentaciones con igual Acc.Farmacologica"
        '
        'mnuPresentacionesConIgualMonodroga
        '
        Me.mnuPresentacionesConIgualMonodroga.Image = CType(resources.GetObject("mnuPresentacionesConIgualMonodroga.Image"), System.Drawing.Image)
        Me.mnuPresentacionesConIgualMonodroga.Name = "mnuPresentacionesConIgualMonodroga"
        Me.mnuPresentacionesConIgualMonodroga.ShortcutKeys = System.Windows.Forms.Keys.F6
        Me.mnuPresentacionesConIgualMonodroga.Size = New System.Drawing.Size(328, 22)
        Me.mnuPresentacionesConIgualMonodroga.Text = "Presentaciones con igual Monodroga"
        '
        'mnuObrasSociales
        '
        Me.mnuObrasSociales.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuNuevaReceta, Me.mnuDatosReceta, Me.mnuElinarReceta, Me.mnuAutorizarReceta, Me.mnuCancelarAutorizacion})
        Me.mnuObrasSociales.Name = "mnuObrasSociales"
        Me.mnuObrasSociales.Size = New System.Drawing.Size(95, 20)
        Me.mnuObrasSociales.Text = "&Obras Sociales"
        '
        'mnuNuevaReceta
        '
        Me.mnuNuevaReceta.Image = CType(resources.GetObject("mnuNuevaReceta.Image"), System.Drawing.Image)
        Me.mnuNuevaReceta.Name = "mnuNuevaReceta"
        Me.mnuNuevaReceta.ShortcutKeyDisplayString = ""
        Me.mnuNuevaReceta.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.mnuNuevaReceta.Size = New System.Drawing.Size(190, 22)
        Me.mnuNuevaReceta.Text = "Nueva Receta"
        '
        'mnuDatosReceta
        '
        Me.mnuDatosReceta.Image = CType(resources.GetObject("mnuDatosReceta.Image"), System.Drawing.Image)
        Me.mnuDatosReceta.Name = "mnuDatosReceta"
        Me.mnuDatosReceta.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.I), System.Windows.Forms.Keys)
        Me.mnuDatosReceta.Size = New System.Drawing.Size(190, 22)
        Me.mnuDatosReceta.Text = "Datos Receta"
        '
        'mnuElinarReceta
        '
        Me.mnuElinarReceta.Image = CType(resources.GetObject("mnuElinarReceta.Image"), System.Drawing.Image)
        Me.mnuElinarReceta.Name = "mnuElinarReceta"
        Me.mnuElinarReceta.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.T), System.Windows.Forms.Keys)
        Me.mnuElinarReceta.Size = New System.Drawing.Size(190, 22)
        Me.mnuElinarReceta.Text = "Elinar Receta"
        '
        'mnuAutorizarReceta
        '
        Me.mnuAutorizarReceta.Image = CType(resources.GetObject("mnuAutorizarReceta.Image"), System.Drawing.Image)
        Me.mnuAutorizarReceta.Name = "mnuAutorizarReceta"
        Me.mnuAutorizarReceta.ShortcutKeys = System.Windows.Forms.Keys.F12
        Me.mnuAutorizarReceta.Size = New System.Drawing.Size(190, 22)
        Me.mnuAutorizarReceta.Text = "Autorizar Receta"
        '
        'mnuCancelarAutorizacion
        '
        Me.mnuCancelarAutorizacion.Image = CType(resources.GetObject("mnuCancelarAutorizacion.Image"), System.Drawing.Image)
        Me.mnuCancelarAutorizacion.Name = "mnuCancelarAutorizacion"
        Me.mnuCancelarAutorizacion.Size = New System.Drawing.Size(190, 22)
        Me.mnuCancelarAutorizacion.Text = "Cancelar Autorizacion"
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
        'mnuOpciones
        '
        Me.mnuOpciones.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDescuentoGeneral})
        Me.mnuOpciones.Name = "mnuOpciones"
        Me.mnuOpciones.Size = New System.Drawing.Size(69, 20)
        Me.mnuOpciones.Text = "Opcio&nes"
        '
        'mnuDescuentoGeneral
        '
        Me.mnuDescuentoGeneral.Name = "mnuDescuentoGeneral"
        Me.mnuDescuentoGeneral.ShortcutKeys = System.Windows.Forms.Keys.F8
        Me.mnuDescuentoGeneral.Size = New System.Drawing.Size(211, 22)
        Me.mnuDescuentoGeneral.Text = "↓% Descuento General"
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
        'UcReceta1
        '
        Me.UcReceta1.Dock = System.Windows.Forms.DockStyle.Right
        Me.UcReceta1.Location = New System.Drawing.Point(294, 0)
        Me.UcReceta1.Margin = New System.Windows.Forms.Padding(0)
        Me.UcReceta1.Name = "UcReceta1"
        Me.UcReceta1.Receta = Nothing
        Me.UcReceta1.Size = New System.Drawing.Size(307, 176)
        Me.UcReceta1.TabIndex = 31
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
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
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
    Friend WithEvents mnuEditarItemSeleccionado As ToolStripMenuItem
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnNuevaReceta As ToolStripButton
    Friend WithEvents btnDatosReceta As ToolStripButton
    Friend WithEvents btnEliminarReceta As ToolStripButton
    Friend WithEvents btnSolicitarAutorizacionReceta As ToolStripButton
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents btnCancelarAutorizacion As ToolStripButton
    Friend WithEvents btnRecargoGeneral As ToolStripButton
    Friend WithEvents AyudaToolStripButton As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents mnuEliminarItemSeleccionado As ToolStripMenuItem
    Friend WithEvents mnuAplicarDescuentoItemSeleccionado As ToolStripMenuItem
    Friend WithEvents mnuGuardar As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents mnuModificarPrecioItemSeleccionado As ToolStripMenuItem
    Friend WithEvents SalirToolStripButton As ToolStripButton
    Friend WithEvents mnuProcesos As ToolStripMenuItem
    Friend WithEvents FacturarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RemitoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PresupuestoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClienteToolStripButton As ToolStripButton
    Friend WithEvents btnDescuentoGeneral As ToolStripButton
    Friend WithEvents Panel3 As Panel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents lblDescuentos As Label
    Friend WithEvents lblImporteDescuentos As Label
    Friend WithEvents lblImporteSinDescuentos As Label
    Friend WithEvents lblImporteConDescuentos As Label
    Friend WithEvents PanelItems As Panel
    Friend WithEvents lblImporteConDescuentosEtiqueta As Label
    Friend WithEvents lblImporteOSEtiqueta As Label
    Friend WithEvents lblImporteCSEtiqueda As Label
    Friend WithEvents lblImporteOS As Label
    Friend WithEvents lblImporteCS As Label
    Friend WithEvents lblImporteSinDescuentosEtiqueta As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents UcReceta1 As UcReceta
    Friend WithEvents lblDatosOperacion As Label
    Friend WithEvents lblCantidadItems As Label
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents mnuObrasSociales As ToolStripMenuItem
    Friend WithEvents mnuNuevaReceta As ToolStripMenuItem
    Friend WithEvents mnuDatosReceta As ToolStripMenuItem
    Friend WithEvents mnuElinarReceta As ToolStripMenuItem
    Friend WithEvents mnuAutorizarReceta As ToolStripMenuItem
    Friend WithEvents mnuCancelarAutorizacion As ToolStripMenuItem
    Friend WithEvents mnuPresentacionesConIgualAccionFarmacologica As ToolStripMenuItem
    Friend WithEvents mnuPresentacionesEquivalentes As ToolStripMenuItem
    Friend WithEvents mnuPresentacionesConIgualMonodroga As ToolStripMenuItem
    Friend WithEvents mnuOpciones As ToolStripMenuItem
    Friend WithEvents mnuDescuentoGeneral As ToolStripMenuItem
End Class
