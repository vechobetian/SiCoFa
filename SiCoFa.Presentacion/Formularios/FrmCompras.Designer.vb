<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCompras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCompras))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblImporteIVAEtiqueta = New System.Windows.Forms.Label()
        Me.lblImporteIVA = New System.Windows.Forms.Label()
        Me.lblIVAIncluido = New System.Windows.Forms.Label()
        Me.lblCantidadItems = New System.Windows.Forms.Label()
        Me.lblImporteNeto = New System.Windows.Forms.Label()
        Me.lblImporteNetoEtiqueta = New System.Windows.Forms.Label()
        Me.lblImporteTotal = New System.Windows.Forms.Label()
        Me.lblImporteTotalEtiqueta = New System.Windows.Forms.Label()
        Me.lblDatosOperacion = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.NuevoToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.AbrirToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.GuardarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ImprimirToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.AyudaToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SalirToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SelectorArticulos = New System.Windows.Forms.ToolStripTextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnuArchivo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuArchivoAbrir = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuArchivoGuardar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuArchivoGuardarComo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuArchivoSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditarEliminarItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOpciones = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOpcionesIVAIncluidoEnPrecioCosto = New System.Windows.Forms.ToolStripMenuItem()
        Me.IdItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IVAIncluido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodBarras = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AlicIVA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioCosto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioVenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ListaPrecios = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PorcentajeAplicado = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 153.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(984, 661)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.TableLayoutPanel3)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(6, 508)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(972, 147)
        Me.Panel3.TabIndex = 5
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble
        Me.TableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.66019!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.33981!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 219.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.lblImporteIVAEtiqueta, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.lblImporteIVA, 2, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.lblIVAIncluido, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.lblCantidadItems, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lblImporteNeto, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lblImporteNetoEtiqueta, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lblImporteTotal, 2, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.lblImporteTotalEtiqueta, 1, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.lblDatosOperacion, 0, 2)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 3
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(970, 145)
        Me.TableLayoutPanel3.TabIndex = 7
        '
        'lblImporteIVAEtiqueta
        '
        Me.lblImporteIVAEtiqueta.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblImporteIVAEtiqueta.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteIVAEtiqueta.Location = New System.Drawing.Point(561, 45)
        Me.lblImporteIVAEtiqueta.Name = "lblImporteIVAEtiqueta"
        Me.lblImporteIVAEtiqueta.Size = New System.Drawing.Size(180, 39)
        Me.lblImporteIVAEtiqueta.TabIndex = 8
        Me.lblImporteIVAEtiqueta.Text = "Importe I.V.A:"
        Me.lblImporteIVAEtiqueta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblImporteIVA
        '
        Me.lblImporteIVA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImporteIVA.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteIVA.Location = New System.Drawing.Point(750, 45)
        Me.lblImporteIVA.Name = "lblImporteIVA"
        Me.lblImporteIVA.Size = New System.Drawing.Size(214, 39)
        Me.lblImporteIVA.TabIndex = 13
        Me.lblImporteIVA.Text = "0,00"
        Me.lblImporteIVA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblIVAIncluido
        '
        Me.lblIVAIncluido.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblIVAIncluido.AutoSize = True
        Me.lblIVAIncluido.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIVAIncluido.Location = New System.Drawing.Point(6, 54)
        Me.lblIVAIncluido.Name = "lblIVAIncluido"
        Me.lblIVAIncluido.Size = New System.Drawing.Size(220, 20)
        Me.lblIVAIncluido.TabIndex = 16
        Me.lblIVAIncluido.Text = "- IVA Incluido en Precio Costo"
        '
        'lblCantidadItems
        '
        Me.lblCantidadItems.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblCantidadItems.AutoSize = True
        Me.lblCantidadItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidadItems.Location = New System.Drawing.Point(6, 12)
        Me.lblCantidadItems.Name = "lblCantidadItems"
        Me.lblCantidadItems.Size = New System.Drawing.Size(75, 20)
        Me.lblCantidadItems.TabIndex = 10
        Me.lblCantidadItems.Text = "- Items: 0"
        '
        'lblImporteNeto
        '
        Me.lblImporteNeto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImporteNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteNeto.Location = New System.Drawing.Point(750, 3)
        Me.lblImporteNeto.Name = "lblImporteNeto"
        Me.lblImporteNeto.Size = New System.Drawing.Size(214, 39)
        Me.lblImporteNeto.TabIndex = 11
        Me.lblImporteNeto.Text = "0,00"
        Me.lblImporteNeto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblImporteNetoEtiqueta
        '
        Me.lblImporteNetoEtiqueta.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblImporteNetoEtiqueta.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteNetoEtiqueta.Location = New System.Drawing.Point(561, 3)
        Me.lblImporteNetoEtiqueta.Name = "lblImporteNetoEtiqueta"
        Me.lblImporteNetoEtiqueta.Size = New System.Drawing.Size(180, 39)
        Me.lblImporteNetoEtiqueta.TabIndex = 6
        Me.lblImporteNetoEtiqueta.Text = "Importe Neto:"
        Me.lblImporteNetoEtiqueta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblImporteTotal
        '
        Me.lblImporteTotal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImporteTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteTotal.Location = New System.Drawing.Point(750, 87)
        Me.lblImporteTotal.Name = "lblImporteTotal"
        Me.lblImporteTotal.Size = New System.Drawing.Size(214, 55)
        Me.lblImporteTotal.TabIndex = 14
        Me.lblImporteTotal.Text = "0,00"
        Me.lblImporteTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblImporteTotalEtiqueta
        '
        Me.lblImporteTotalEtiqueta.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblImporteTotalEtiqueta.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteTotalEtiqueta.Location = New System.Drawing.Point(561, 87)
        Me.lblImporteTotalEtiqueta.Name = "lblImporteTotalEtiqueta"
        Me.lblImporteTotalEtiqueta.Size = New System.Drawing.Size(180, 55)
        Me.lblImporteTotalEtiqueta.TabIndex = 9
        Me.lblImporteTotalEtiqueta.Text = "Importe Total:  "
        Me.lblImporteTotalEtiqueta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDatosOperacion
        '
        Me.lblDatosOperacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDatosOperacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatosOperacion.Location = New System.Drawing.Point(6, 87)
        Me.lblDatosOperacion.Name = "lblDatosOperacion"
        Me.lblDatosOperacion.Size = New System.Drawing.Size(545, 55)
        Me.lblDatosOperacion.TabIndex = 17
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
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdItem, Me.IVAIncluido, Me.CodBarras, Me.Descripcion, Me.Cantidad, Me.AlicIVA, Me.PrecioCosto, Me.PrecioVenta, Me.Importe, Me.ListaPrecios, Me.PorcentajeAplicado})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(6, 77)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 20
        Me.DataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DataGridView1.Size = New System.Drawing.Size(972, 422)
        Me.DataGridView1.TabIndex = 3
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
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoToolStripButton, Me.AbrirToolStripButton, Me.GuardarToolStripButton, Me.ImprimirToolStripButton, Me.toolStripSeparator, Me.AyudaToolStripButton, Me.ToolStripSeparator1, Me.SalirToolStripButton, Me.SelectorArticulos})
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
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuArchivo, Me.mnuEditar, Me.mnuOpciones})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(972, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnuArchivo
        '
        Me.mnuArchivo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuArchivoAbrir, Me.mnuArchivoGuardar, Me.mnuArchivoGuardarComo, Me.mnuArchivoSalir})
        Me.mnuArchivo.Name = "mnuArchivo"
        Me.mnuArchivo.Size = New System.Drawing.Size(60, 20)
        Me.mnuArchivo.Text = "&Archivo"
        '
        'mnuArchivoAbrir
        '
        Me.mnuArchivoAbrir.Image = CType(resources.GetObject("mnuArchivoAbrir.Image"), System.Drawing.Image)
        Me.mnuArchivoAbrir.Name = "mnuArchivoAbrir"
        Me.mnuArchivoAbrir.Size = New System.Drawing.Size(161, 22)
        Me.mnuArchivoAbrir.Text = "A&brir"
        '
        'mnuArchivoGuardar
        '
        Me.mnuArchivoGuardar.Image = CType(resources.GetObject("mnuArchivoGuardar.Image"), System.Drawing.Image)
        Me.mnuArchivoGuardar.Name = "mnuArchivoGuardar"
        Me.mnuArchivoGuardar.Size = New System.Drawing.Size(161, 22)
        Me.mnuArchivoGuardar.Text = "&Guardar"
        '
        'mnuArchivoGuardarComo
        '
        Me.mnuArchivoGuardarComo.Image = CType(resources.GetObject("mnuArchivoGuardarComo.Image"), System.Drawing.Image)
        Me.mnuArchivoGuardarComo.Name = "mnuArchivoGuardarComo"
        Me.mnuArchivoGuardarComo.Size = New System.Drawing.Size(161, 22)
        Me.mnuArchivoGuardarComo.Text = "Guardar Como..."
        '
        'mnuArchivoSalir
        '
        Me.mnuArchivoSalir.Image = CType(resources.GetObject("mnuArchivoSalir.Image"), System.Drawing.Image)
        Me.mnuArchivoSalir.Name = "mnuArchivoSalir"
        Me.mnuArchivoSalir.Size = New System.Drawing.Size(161, 22)
        Me.mnuArchivoSalir.Text = "&Salir"
        '
        'mnuEditar
        '
        Me.mnuEditar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuEditarEliminarItem})
        Me.mnuEditar.Name = "mnuEditar"
        Me.mnuEditar.Size = New System.Drawing.Size(49, 20)
        Me.mnuEditar.Text = "&Editar"
        '
        'mnuEditarEliminarItem
        '
        Me.mnuEditarEliminarItem.Image = CType(resources.GetObject("mnuEditarEliminarItem.Image"), System.Drawing.Image)
        Me.mnuEditarEliminarItem.Name = "mnuEditarEliminarItem"
        Me.mnuEditarEliminarItem.Size = New System.Drawing.Size(226, 22)
        Me.mnuEditarEliminarItem.Text = "&Elimininar Item seleccionado"
        '
        'mnuOpciones
        '
        Me.mnuOpciones.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOpcionesIVAIncluidoEnPrecioCosto})
        Me.mnuOpciones.Name = "mnuOpciones"
        Me.mnuOpciones.Size = New System.Drawing.Size(69, 20)
        Me.mnuOpciones.Text = "&Opciones"
        '
        'mnuOpcionesIVAIncluidoEnPrecioCosto
        '
        Me.mnuOpcionesIVAIncluidoEnPrecioCosto.Checked = True
        Me.mnuOpcionesIVAIncluidoEnPrecioCosto.CheckOnClick = True
        Me.mnuOpcionesIVAIncluidoEnPrecioCosto.CheckState = System.Windows.Forms.CheckState.Checked
        Me.mnuOpcionesIVAIncluidoEnPrecioCosto.Name = "mnuOpcionesIVAIncluidoEnPrecioCosto"
        Me.mnuOpcionesIVAIncluidoEnPrecioCosto.Size = New System.Drawing.Size(223, 22)
        Me.mnuOpcionesIVAIncluidoEnPrecioCosto.Text = "IVA incluido en Precio Costo"
        '
        'IdItem
        '
        Me.IdItem.DataPropertyName = "IdItem"
        Me.IdItem.HeaderText = "IdItem"
        Me.IdItem.Name = "IdItem"
        Me.IdItem.Visible = False
        '
        'IVAIncluido
        '
        Me.IVAIncluido.DataPropertyName = "IVAIncluido"
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = "0"
        Me.IVAIncluido.DefaultCellStyle = DataGridViewCellStyle2
        Me.IVAIncluido.HeaderText = "IVAIncluido"
        Me.IVAIncluido.Name = "IVAIncluido"
        Me.IVAIncluido.Visible = False
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
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.Cantidad.DefaultCellStyle = DataGridViewCellStyle3
        Me.Cantidad.FillWeight = 168.7203!
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        '
        'AlicIVA
        '
        Me.AlicIVA.DataPropertyName = "AlicIVA"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.AlicIVA.DefaultCellStyle = DataGridViewCellStyle4
        Me.AlicIVA.FillWeight = 174.8724!
        Me.AlicIVA.HeaderText = "IVA"
        Me.AlicIVA.Name = "AlicIVA"
        Me.AlicIVA.ReadOnly = True
        '
        'PrecioCosto
        '
        Me.PrecioCosto.DataPropertyName = "PrecioCosto"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.PrecioCosto.DefaultCellStyle = DataGridViewCellStyle5
        Me.PrecioCosto.FillWeight = 68.81715!
        Me.PrecioCosto.HeaderText = "P.Costo"
        Me.PrecioCosto.Name = "PrecioCosto"
        Me.PrecioCosto.ReadOnly = True
        '
        'PrecioVenta
        '
        Me.PrecioVenta.DataPropertyName = "PrecioVenta"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.PrecioVenta.DefaultCellStyle = DataGridViewCellStyle6
        Me.PrecioVenta.FillWeight = 57.10529!
        Me.PrecioVenta.HeaderText = "P.Venta"
        Me.PrecioVenta.Name = "PrecioVenta"
        Me.PrecioVenta.ReadOnly = True
        '
        'Importe
        '
        Me.Importe.DataPropertyName = "Importe"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.Importe.DefaultCellStyle = DataGridViewCellStyle7
        Me.Importe.FillWeight = 59.96484!
        Me.Importe.HeaderText = "Imp.Costo"
        Me.Importe.Name = "Importe"
        Me.Importe.ReadOnly = True
        '
        'ListaPrecios
        '
        Me.ListaPrecios.DataPropertyName = "ListaPrecios"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.NullValue = Nothing
        Me.ListaPrecios.DefaultCellStyle = DataGridViewCellStyle8
        Me.ListaPrecios.FillWeight = 54.31535!
        Me.ListaPrecios.HeaderText = "L.Precios"
        Me.ListaPrecios.Name = "ListaPrecios"
        Me.ListaPrecios.ReadOnly = True
        '
        'PorcentajeAplicado
        '
        Me.PorcentajeAplicado.DataPropertyName = "PorcentajeAplicado"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "N2"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.PorcentajeAplicado.DefaultCellStyle = DataGridViewCellStyle9
        Me.PorcentajeAplicado.FillWeight = 40.10151!
        Me.PorcentajeAplicado.HeaderText = "%Aplic."
        Me.PorcentajeAplicado.Name = "PorcentajeAplicado"
        Me.PorcentajeAplicado.ReadOnly = True
        '
        'FrmCompras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 661)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "FrmCompras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
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
    Friend WithEvents AyudaToolStripButton As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents SelectorArticulos As ToolStripTextBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents lblImporteIVAEtiqueta As Label
    Friend WithEvents mnuEditarEliminarItem As ToolStripMenuItem
    Friend WithEvents mnuArchivoAbrir As ToolStripMenuItem
    Friend WithEvents mnuArchivoGuardar As ToolStripMenuItem
    Friend WithEvents mnuArchivoSalir As ToolStripMenuItem
    Friend WithEvents lblImporteTotalEtiqueta As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents lblImporteNetoEtiqueta As Label
    Friend WithEvents lblCantidadItems As Label
    Friend WithEvents lblImporteIVA As Label
    Friend WithEvents lblImporteTotal As Label
    Friend WithEvents SalirToolStripButton As ToolStripButton
    Friend WithEvents lblIVAIncluido As Label
    Friend WithEvents lblImporteNeto As Label
    Friend WithEvents lblDatosOperacion As Label
    Friend WithEvents mnuOpciones As ToolStripMenuItem
    Friend WithEvents mnuOpcionesIVAIncluidoEnPrecioCosto As ToolStripMenuItem
    Friend WithEvents mnuArchivoGuardarComo As ToolStripMenuItem
    Friend WithEvents IdItem As DataGridViewTextBoxColumn
    Friend WithEvents IVAIncluido As DataGridViewTextBoxColumn
    Friend WithEvents CodBarras As DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As DataGridViewTextBoxColumn
    Friend WithEvents AlicIVA As DataGridViewTextBoxColumn
    Friend WithEvents PrecioCosto As DataGridViewTextBoxColumn
    Friend WithEvents PrecioVenta As DataGridViewTextBoxColumn
    Friend WithEvents Importe As DataGridViewTextBoxColumn
    Friend WithEvents ListaPrecios As DataGridViewTextBoxColumn
    Friend WithEvents PorcentajeAplicado As DataGridViewTextBoxColumn
End Class
