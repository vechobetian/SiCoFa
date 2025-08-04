<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmNotaCredito
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
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblImporteDescuentosEtiqueta = New System.Windows.Forms.Label()
        Me.lblImporteDescuentos = New System.Windows.Forms.Label()
        Me.lblPorcentajeAplicado = New System.Windows.Forms.Label()
        Me.lblCantidadItems = New System.Windows.Forms.Label()
        Me.lblImporteSinDescuentos = New System.Windows.Forms.Label()
        Me.lblImporteSinDescuentosEtiqueta = New System.Windows.Forms.Label()
        Me.lblImporteConDescuentos = New System.Windows.Forms.Label()
        Me.lblImporteConDescuentosEtiqueta = New System.Windows.Forms.Label()
        Me.lblDatosOperacion = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.IdItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodBarras = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantidadF = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantidadA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantidadNC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AlicIVA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioUnitario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImporteSinDescuento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PorcentajeDescuento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImporteDescuento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImporteConDescuento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkAcreditarTodo = New System.Windows.Forms.CheckBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFinalizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
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
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 236.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1369, 739)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.TableLayoutPanel3)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(6, 503)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1357, 189)
        Me.Panel3.TabIndex = 5
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble
        Me.TableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.43767!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.56233!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 318.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.lblImporteDescuentosEtiqueta, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.lblImporteDescuentos, 2, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.lblPorcentajeAplicado, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.lblCantidadItems, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lblImporteSinDescuentos, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lblImporteSinDescuentosEtiqueta, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.lblImporteConDescuentos, 2, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.lblImporteConDescuentosEtiqueta, 1, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.lblDatosOperacion, 0, 2)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 3
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1355, 187)
        Me.TableLayoutPanel3.TabIndex = 7
        '
        'lblImporteDescuentosEtiqueta
        '
        Me.lblImporteDescuentosEtiqueta.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblImporteDescuentosEtiqueta.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteDescuentosEtiqueta.Location = New System.Drawing.Point(843, 58)
        Me.lblImporteDescuentosEtiqueta.Name = "lblImporteDescuentosEtiqueta"
        Me.lblImporteDescuentosEtiqueta.Size = New System.Drawing.Size(184, 52)
        Me.lblImporteDescuentosEtiqueta.TabIndex = 8
        Me.lblImporteDescuentosEtiqueta.Text = "Importe Descuentos:"
        Me.lblImporteDescuentosEtiqueta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblImporteDescuentos
        '
        Me.lblImporteDescuentos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImporteDescuentos.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteDescuentos.Location = New System.Drawing.Point(1036, 58)
        Me.lblImporteDescuentos.Name = "lblImporteDescuentos"
        Me.lblImporteDescuentos.Size = New System.Drawing.Size(313, 52)
        Me.lblImporteDescuentos.TabIndex = 13
        Me.lblImporteDescuentos.Text = "0,00"
        Me.lblImporteDescuentos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPorcentajeAplicado
        '
        Me.lblPorcentajeAplicado.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblPorcentajeAplicado.AutoSize = True
        Me.lblPorcentajeAplicado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPorcentajeAplicado.Location = New System.Drawing.Point(6, 74)
        Me.lblPorcentajeAplicado.Name = "lblPorcentajeAplicado"
        Me.lblPorcentajeAplicado.Size = New System.Drawing.Size(241, 20)
        Me.lblPorcentajeAplicado.TabIndex = 16
        Me.lblPorcentajeAplicado.Text = "- Porcentaje Descuentos: 0,00 %"
        '
        'lblCantidadItems
        '
        Me.lblCantidadItems.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblCantidadItems.AutoSize = True
        Me.lblCantidadItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidadItems.Location = New System.Drawing.Point(6, 19)
        Me.lblCantidadItems.Name = "lblCantidadItems"
        Me.lblCantidadItems.Size = New System.Drawing.Size(75, 20)
        Me.lblCantidadItems.TabIndex = 10
        Me.lblCantidadItems.Text = "- Items: 0"
        '
        'lblImporteSinDescuentos
        '
        Me.lblImporteSinDescuentos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImporteSinDescuentos.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteSinDescuentos.Location = New System.Drawing.Point(1036, 3)
        Me.lblImporteSinDescuentos.Name = "lblImporteSinDescuentos"
        Me.lblImporteSinDescuentos.Size = New System.Drawing.Size(313, 52)
        Me.lblImporteSinDescuentos.TabIndex = 11
        Me.lblImporteSinDescuentos.Text = "0,00"
        Me.lblImporteSinDescuentos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblImporteSinDescuentosEtiqueta
        '
        Me.lblImporteSinDescuentosEtiqueta.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblImporteSinDescuentosEtiqueta.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteSinDescuentosEtiqueta.Location = New System.Drawing.Point(843, 3)
        Me.lblImporteSinDescuentosEtiqueta.Name = "lblImporteSinDescuentosEtiqueta"
        Me.lblImporteSinDescuentosEtiqueta.Size = New System.Drawing.Size(184, 52)
        Me.lblImporteSinDescuentosEtiqueta.TabIndex = 6
        Me.lblImporteSinDescuentosEtiqueta.Text = "Total sin Descuentos:"
        Me.lblImporteSinDescuentosEtiqueta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblImporteConDescuentos
        '
        Me.lblImporteConDescuentos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImporteConDescuentos.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteConDescuentos.Location = New System.Drawing.Point(1036, 113)
        Me.lblImporteConDescuentos.Name = "lblImporteConDescuentos"
        Me.lblImporteConDescuentos.Size = New System.Drawing.Size(313, 71)
        Me.lblImporteConDescuentos.TabIndex = 14
        Me.lblImporteConDescuentos.Text = "0,00"
        Me.lblImporteConDescuentos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblImporteConDescuentosEtiqueta
        '
        Me.lblImporteConDescuentosEtiqueta.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblImporteConDescuentosEtiqueta.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteConDescuentosEtiqueta.Location = New System.Drawing.Point(843, 113)
        Me.lblImporteConDescuentosEtiqueta.Name = "lblImporteConDescuentosEtiqueta"
        Me.lblImporteConDescuentosEtiqueta.Size = New System.Drawing.Size(184, 71)
        Me.lblImporteConDescuentosEtiqueta.TabIndex = 9
        Me.lblImporteConDescuentosEtiqueta.Text = "Imp. a pagar:  "
        Me.lblImporteConDescuentosEtiqueta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDatosOperacion
        '
        Me.lblDatosOperacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDatosOperacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatosOperacion.Location = New System.Drawing.Point(6, 113)
        Me.lblDatosOperacion.Name = "lblDatosOperacion"
        Me.lblDatosOperacion.Size = New System.Drawing.Size(828, 71)
        Me.lblDatosOperacion.TabIndex = 17
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdItem, Me.CodBarras, Me.Descripcion, Me.CantidadF, Me.CantidadA, Me.CantidadNC, Me.AlicIVA, Me.PrecioUnitario, Me.ImporteSinDescuento, Me.PorcentajeDescuento, Me.ImporteDescuento, Me.ImporteConDescuento})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(6, 39)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 20
        Me.DataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DataGridView1.Size = New System.Drawing.Size(1357, 455)
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
        'CantidadF
        '
        Me.CantidadF.DataPropertyName = "CantidadF"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.Format = "N3"
        DataGridViewCellStyle12.NullValue = Nothing
        Me.CantidadF.DefaultCellStyle = DataGridViewCellStyle12
        Me.CantidadF.FillWeight = 168.7203!
        Me.CantidadF.HeaderText = "Cant.Facturada"
        Me.CantidadF.Name = "CantidadF"
        Me.CantidadF.ReadOnly = True
        '
        'CantidadA
        '
        Me.CantidadA.DataPropertyName = "CantidadA"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle13.Format = "N3"
        DataGridViewCellStyle13.NullValue = Nothing
        Me.CantidadA.DefaultCellStyle = DataGridViewCellStyle13
        Me.CantidadA.HeaderText = "Cant.Acreditada"
        Me.CantidadA.Name = "CantidadA"
        Me.CantidadA.ReadOnly = True
        '
        'CantidadNC
        '
        Me.CantidadNC.DataPropertyName = "CantidadNC"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle14.Format = "N3"
        DataGridViewCellStyle14.NullValue = Nothing
        Me.CantidadNC.DefaultCellStyle = DataGridViewCellStyle14
        Me.CantidadNC.HeaderText = "Cant.N.Cred."
        Me.CantidadNC.Name = "CantidadNC"
        '
        'AlicIVA
        '
        Me.AlicIVA.DataPropertyName = "AlicIVA"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle15.Format = "N2"
        DataGridViewCellStyle15.NullValue = Nothing
        Me.AlicIVA.DefaultCellStyle = DataGridViewCellStyle15
        Me.AlicIVA.FillWeight = 174.8724!
        Me.AlicIVA.HeaderText = "IVA"
        Me.AlicIVA.Name = "AlicIVA"
        Me.AlicIVA.ReadOnly = True
        '
        'PrecioUnitario
        '
        Me.PrecioUnitario.DataPropertyName = "PrecioUnitario"
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle16.Format = "N2"
        DataGridViewCellStyle16.NullValue = Nothing
        Me.PrecioUnitario.DefaultCellStyle = DataGridViewCellStyle16
        Me.PrecioUnitario.FillWeight = 68.81715!
        Me.PrecioUnitario.HeaderText = "Precio Unitario"
        Me.PrecioUnitario.Name = "PrecioUnitario"
        Me.PrecioUnitario.ReadOnly = True
        '
        'ImporteSinDescuento
        '
        Me.ImporteSinDescuento.DataPropertyName = "ImporteSinDescuento"
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle17.Format = "N2"
        DataGridViewCellStyle17.NullValue = Nothing
        Me.ImporteSinDescuento.DefaultCellStyle = DataGridViewCellStyle17
        Me.ImporteSinDescuento.FillWeight = 59.96484!
        Me.ImporteSinDescuento.HeaderText = "Importe"
        Me.ImporteSinDescuento.Name = "ImporteSinDescuento"
        Me.ImporteSinDescuento.ReadOnly = True
        '
        'PorcentajeDescuento
        '
        Me.PorcentajeDescuento.DataPropertyName = "PorcentajeDescuento"
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle18.Format = "N2"
        DataGridViewCellStyle18.NullValue = Nothing
        Me.PorcentajeDescuento.DefaultCellStyle = DataGridViewCellStyle18
        Me.PorcentajeDescuento.FillWeight = 57.10529!
        Me.PorcentajeDescuento.HeaderText = "%Descuento"
        Me.PorcentajeDescuento.Name = "PorcentajeDescuento"
        Me.PorcentajeDescuento.ReadOnly = True
        '
        'ImporteDescuento
        '
        Me.ImporteDescuento.DataPropertyName = "ImporteDescuento"
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle19.Format = "N2"
        DataGridViewCellStyle19.NullValue = Nothing
        Me.ImporteDescuento.DefaultCellStyle = DataGridViewCellStyle19
        Me.ImporteDescuento.FillWeight = 54.31535!
        Me.ImporteDescuento.HeaderText = "Imp.Descuento"
        Me.ImporteDescuento.Name = "ImporteDescuento"
        Me.ImporteDescuento.ReadOnly = True
        '
        'ImporteConDescuento
        '
        Me.ImporteConDescuento.DataPropertyName = "ImporteConDescuento"
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle20.Format = "N2"
        DataGridViewCellStyle20.NullValue = Nothing
        Me.ImporteConDescuento.DefaultCellStyle = DataGridViewCellStyle20
        Me.ImporteConDescuento.FillWeight = 40.10151!
        Me.ImporteConDescuento.HeaderText = "Imp.Cliente"
        Me.ImporteConDescuento.Name = "ImporteConDescuento"
        Me.ImporteConDescuento.ReadOnly = True
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.Controls.Add(Me.chkAcreditarTodo)
        Me.Panel1.Controls.Add(Me.MenuStrip1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(6, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1357, 24)
        Me.Panel1.TabIndex = 0
        '
        'chkAcreditarTodo
        '
        Me.chkAcreditarTodo.AutoSize = True
        Me.chkAcreditarTodo.Dock = System.Windows.Forms.DockStyle.Right
        Me.chkAcreditarTodo.Location = New System.Drawing.Point(1261, 0)
        Me.chkAcreditarTodo.Name = "chkAcreditarTodo"
        Me.chkAcreditarTodo.Size = New System.Drawing.Size(96, 24)
        Me.chkAcreditarTodo.TabIndex = 1
        Me.chkAcreditarTodo.Text = "Acreditar Todo"
        Me.chkAcreditarTodo.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.mnuFinalizar, Me.mnuSalir})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(123, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(12, 20)
        '
        'mnuFinalizar
        '
        Me.mnuFinalizar.Name = "mnuFinalizar"
        Me.mnuFinalizar.Size = New System.Drawing.Size(62, 20)
        Me.mnuFinalizar.Text = "&Finalizar"
        '
        'mnuSalir
        '
        Me.mnuSalir.Name = "mnuSalir"
        Me.mnuSalir.Size = New System.Drawing.Size(41, 20)
        Me.mnuSalir.Text = "&Salir"
        '
        'FrmNotaCredito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1369, 739)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "FrmNotaCredito"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Nota de Crédito"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents lblImporteDescuentosEtiqueta As Label
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents lblImporteConDescuentosEtiqueta As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents lblImporteSinDescuentosEtiqueta As Label
    Friend WithEvents lblCantidadItems As Label
    Friend WithEvents lblImporteDescuentos As Label
    Friend WithEvents lblImporteConDescuentos As Label
    Friend WithEvents lblPorcentajeAplicado As Label
    Friend WithEvents lblImporteSinDescuentos As Label
    Friend WithEvents lblDatosOperacion As Label
    Friend WithEvents IdItem As DataGridViewTextBoxColumn
    Friend WithEvents CodBarras As DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As DataGridViewTextBoxColumn
    Friend WithEvents CantidadF As DataGridViewTextBoxColumn
    Friend WithEvents CantidadA As DataGridViewTextBoxColumn
    Friend WithEvents CantidadNC As DataGridViewTextBoxColumn
    Friend WithEvents AlicIVA As DataGridViewTextBoxColumn
    Friend WithEvents PrecioUnitario As DataGridViewTextBoxColumn
    Friend WithEvents ImporteSinDescuento As DataGridViewTextBoxColumn
    Friend WithEvents PorcentajeDescuento As DataGridViewTextBoxColumn
    Friend WithEvents ImporteDescuento As DataGridViewTextBoxColumn
    Friend WithEvents ImporteConDescuento As DataGridViewTextBoxColumn
    Friend WithEvents mnuFinalizar As ToolStripMenuItem
    Friend WithEvents mnuSalir As ToolStripMenuItem
    Friend WithEvents chkAcreditarTodo As CheckBox
End Class
