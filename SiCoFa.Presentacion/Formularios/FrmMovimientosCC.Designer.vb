<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMovimientosCC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMovimientosCC))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnuArchivo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuArchivoImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuArchivoImprimirOriginal = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuArchivoImprimirDuplicado = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuArchivoEmail = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuArchivoGuardarComo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuArchivoSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOperaciones = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOperacionesPagoACuenta = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOperacionesCancelarResumen = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOperacionesCancelarCuenta = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOperacionesCancelarFacturas = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOperacionesNC = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOperacionesFacturarRemito = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditarModificarResumen = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
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
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblDescripcionCuentaCorriente = New System.Windows.Forms.Label()
        Me.lblImporteAdeudadoItemsSeleccionados = New System.Windows.Forms.Label()
        Me.lblSaldoCuentaCorriente = New System.Windows.Forms.Label()
        Me.CodiTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodiTC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Seleccionar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.IdOperacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Operacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Resu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaComp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PVenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumComp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ComprobanteAsociado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Observaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EstadoOperacionCC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.MenuStrip1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.DataGridView1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.DataGridView2, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.51145!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.48855!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 181.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1554, 737)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuArchivo, Me.mnuOperaciones, Me.mnuEditar})
        Me.MenuStrip1.Location = New System.Drawing.Point(2, 2)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(202, 24)
        Me.MenuStrip1.TabIndex = 9
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnuArchivo
        '
        Me.mnuArchivo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuArchivoImprimir, Me.mnuArchivoEmail, Me.mnuArchivoGuardarComo, Me.mnuArchivoSalir})
        Me.mnuArchivo.Name = "mnuArchivo"
        Me.mnuArchivo.Size = New System.Drawing.Size(60, 20)
        Me.mnuArchivo.Text = "&Archivo"
        '
        'mnuArchivoImprimir
        '
        Me.mnuArchivoImprimir.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuArchivoImprimirOriginal, Me.mnuArchivoImprimirDuplicado})
        Me.mnuArchivoImprimir.Image = CType(resources.GetObject("mnuArchivoImprimir.Image"), System.Drawing.Image)
        Me.mnuArchivoImprimir.Name = "mnuArchivoImprimir"
        Me.mnuArchivoImprimir.Size = New System.Drawing.Size(161, 22)
        Me.mnuArchivoImprimir.Text = "&Imprimir"
        '
        'mnuArchivoImprimirOriginal
        '
        Me.mnuArchivoImprimirOriginal.Name = "mnuArchivoImprimirOriginal"
        Me.mnuArchivoImprimirOriginal.Size = New System.Drawing.Size(128, 22)
        Me.mnuArchivoImprimirOriginal.Text = "&Original"
        '
        'mnuArchivoImprimirDuplicado
        '
        Me.mnuArchivoImprimirDuplicado.Name = "mnuArchivoImprimirDuplicado"
        Me.mnuArchivoImprimirDuplicado.Size = New System.Drawing.Size(128, 22)
        Me.mnuArchivoImprimirDuplicado.Text = "&Duplicado"
        '
        'mnuArchivoEmail
        '
        Me.mnuArchivoEmail.Image = CType(resources.GetObject("mnuArchivoEmail.Image"), System.Drawing.Image)
        Me.mnuArchivoEmail.Name = "mnuArchivoEmail"
        Me.mnuArchivoEmail.Size = New System.Drawing.Size(161, 22)
        Me.mnuArchivoEmail.Text = "&Enviar Mail"
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
        'mnuOperaciones
        '
        Me.mnuOperaciones.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOperacionesPagoACuenta, Me.mnuOperacionesCancelarResumen, Me.mnuOperacionesCancelarCuenta, Me.mnuOperacionesCancelarFacturas, Me.mnuOperacionesNC, Me.mnuOperacionesFacturarRemito})
        Me.mnuOperaciones.Name = "mnuOperaciones"
        Me.mnuOperaciones.Size = New System.Drawing.Size(85, 20)
        Me.mnuOperaciones.Text = "&Operaciones"
        '
        'mnuOperacionesPagoACuenta
        '
        Me.mnuOperacionesPagoACuenta.Name = "mnuOperacionesPagoACuenta"
        Me.mnuOperacionesPagoACuenta.Size = New System.Drawing.Size(172, 22)
        Me.mnuOperacionesPagoACuenta.Text = "&Pago a Cuenta"
        '
        'mnuOperacionesCancelarResumen
        '
        Me.mnuOperacionesCancelarResumen.Name = "mnuOperacionesCancelarResumen"
        Me.mnuOperacionesCancelarResumen.Size = New System.Drawing.Size(172, 22)
        Me.mnuOperacionesCancelarResumen.Text = "Cancelar &Resumen"
        '
        'mnuOperacionesCancelarCuenta
        '
        Me.mnuOperacionesCancelarCuenta.Name = "mnuOperacionesCancelarCuenta"
        Me.mnuOperacionesCancelarCuenta.Size = New System.Drawing.Size(172, 22)
        Me.mnuOperacionesCancelarCuenta.Text = "Cancelar &Cuenta"
        '
        'mnuOperacionesCancelarFacturas
        '
        Me.mnuOperacionesCancelarFacturas.Name = "mnuOperacionesCancelarFacturas"
        Me.mnuOperacionesCancelarFacturas.Size = New System.Drawing.Size(172, 22)
        Me.mnuOperacionesCancelarFacturas.Text = "Cancelar &Facturas"
        '
        'mnuOperacionesNC
        '
        Me.mnuOperacionesNC.Image = CType(resources.GetObject("mnuOperacionesNC.Image"), System.Drawing.Image)
        Me.mnuOperacionesNC.Name = "mnuOperacionesNC"
        Me.mnuOperacionesNC.Size = New System.Drawing.Size(172, 22)
        Me.mnuOperacionesNC.Text = "&Nota de Crédito"
        '
        'mnuOperacionesFacturarRemito
        '
        Me.mnuOperacionesFacturarRemito.Name = "mnuOperacionesFacturarRemito"
        Me.mnuOperacionesFacturarRemito.Size = New System.Drawing.Size(172, 22)
        Me.mnuOperacionesFacturarRemito.Text = "Facturar &Remito"
        '
        'mnuEditar
        '
        Me.mnuEditar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuEditarModificarResumen})
        Me.mnuEditar.Name = "mnuEditar"
        Me.mnuEditar.Size = New System.Drawing.Size(49, 20)
        Me.mnuEditar.Text = "&Editar"
        '
        'mnuEditarModificarResumen
        '
        Me.mnuEditarModificarResumen.Name = "mnuEditarModificarResumen"
        Me.mnuEditarModificarResumen.Size = New System.Drawing.Size(177, 22)
        Me.mnuEditarModificarResumen.Text = "&Modificar Resumen"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodiTO, Me.CodiTC, Me.Seleccionar, Me.IdOperacion, Me.Operacion, Me.Resu, Me.TipoComprobante, Me.FechaComp, Me.PVenta, Me.NumComp, Me.ComprobanteAsociado, Me.Observaciones, Me.Importe, Me.EstadoOperacionCC})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(5, 32)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 20
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1544, 481)
        Me.DataGridView1.TabIndex = 1
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToResizeColumns = False
        Me.DataGridView2.AllowUserToResizeRows = False
        Me.DataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView2.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdItem, Me.CodBarras, Me.Descripcion, Me.Cantidad, Me.AlicIVA, Me.PrecioUnitario, Me.ImporteSinDescuento, Me.PorcentajeDescuento, Me.ImporteDescuento, Me.ImporteConDescuento})
        Me.DataGridView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView2.Location = New System.Drawing.Point(5, 556)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowHeadersWidth = 20
        Me.DataGridView2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DataGridView2.Size = New System.Drawing.Size(1544, 176)
        Me.DataGridView2.TabIndex = 11
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
        'PrecioUnitario
        '
        Me.PrecioUnitario.DataPropertyName = "PrecioUnitario"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.PrecioUnitario.DefaultCellStyle = DataGridViewCellStyle5
        Me.PrecioUnitario.FillWeight = 68.81715!
        Me.PrecioUnitario.HeaderText = "Precio Unitario"
        Me.PrecioUnitario.Name = "PrecioUnitario"
        Me.PrecioUnitario.ReadOnly = True
        '
        'ImporteSinDescuento
        '
        Me.ImporteSinDescuento.DataPropertyName = "ImporteSinDescuento"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.ImporteSinDescuento.DefaultCellStyle = DataGridViewCellStyle6
        Me.ImporteSinDescuento.FillWeight = 59.96484!
        Me.ImporteSinDescuento.HeaderText = "Importe"
        Me.ImporteSinDescuento.Name = "ImporteSinDescuento"
        Me.ImporteSinDescuento.ReadOnly = True
        '
        'PorcentajeDescuento
        '
        Me.PorcentajeDescuento.DataPropertyName = "PorcentajeDescuento"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.PorcentajeDescuento.DefaultCellStyle = DataGridViewCellStyle7
        Me.PorcentajeDescuento.FillWeight = 57.10529!
        Me.PorcentajeDescuento.HeaderText = "%Descuento"
        Me.PorcentajeDescuento.Name = "PorcentajeDescuento"
        Me.PorcentajeDescuento.ReadOnly = True
        '
        'ImporteDescuento
        '
        Me.ImporteDescuento.DataPropertyName = "ImporteDescuento"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.ImporteDescuento.DefaultCellStyle = DataGridViewCellStyle8
        Me.ImporteDescuento.FillWeight = 54.31535!
        Me.ImporteDescuento.HeaderText = "Imp.Descuento"
        Me.ImporteDescuento.Name = "ImporteDescuento"
        Me.ImporteDescuento.ReadOnly = True
        '
        'ImporteConDescuento
        '
        Me.ImporteConDescuento.DataPropertyName = "ImporteConDescuento"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "N2"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.ImporteConDescuento.DefaultCellStyle = DataGridViewCellStyle9
        Me.ImporteConDescuento.FillWeight = 40.10151!
        Me.ImporteConDescuento.HeaderText = "Imp.Cliente"
        Me.ImporteConDescuento.Name = "ImporteConDescuento"
        Me.ImporteConDescuento.ReadOnly = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(5, 521)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1544, 27)
        Me.Panel1.TabIndex = 12
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.87716!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.12284!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 496.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.lblDescripcionCuentaCorriente, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblImporteAdeudadoItemsSeleccionados, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblSaldoCuentaCorriente, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1544, 27)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'lblDescripcionCuentaCorriente
        '
        Me.lblDescripcionCuentaCorriente.AutoSize = True
        Me.lblDescripcionCuentaCorriente.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblDescripcionCuentaCorriente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescripcionCuentaCorriente.Location = New System.Drawing.Point(6, 3)
        Me.lblDescripcionCuentaCorriente.Name = "lblDescripcionCuentaCorriente"
        Me.lblDescripcionCuentaCorriente.Size = New System.Drawing.Size(134, 21)
        Me.lblDescripcionCuentaCorriente.TabIndex = 2
        Me.lblDescripcionCuentaCorriente.Text = "Cuenta Corriente:"
        Me.lblDescripcionCuentaCorriente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblImporteAdeudadoItemsSeleccionados
        '
        Me.lblImporteAdeudadoItemsSeleccionados.AutoSize = True
        Me.lblImporteAdeudadoItemsSeleccionados.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblImporteAdeudadoItemsSeleccionados.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteAdeudadoItemsSeleccionados.Location = New System.Drawing.Point(1205, 3)
        Me.lblImporteAdeudadoItemsSeleccionados.Name = "lblImporteAdeudadoItemsSeleccionados"
        Me.lblImporteAdeudadoItemsSeleccionados.Size = New System.Drawing.Size(333, 21)
        Me.lblImporteAdeudadoItemsSeleccionados.TabIndex = 1
        Me.lblImporteAdeudadoItemsSeleccionados.Text = "Importe Adeudado Items Seleccionados: 0,00"
        Me.lblImporteAdeudadoItemsSeleccionados.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSaldoCuentaCorriente
        '
        Me.lblSaldoCuentaCorriente.AutoSize = True
        Me.lblSaldoCuentaCorriente.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblSaldoCuentaCorriente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldoCuentaCorriente.Location = New System.Drawing.Point(681, 3)
        Me.lblSaldoCuentaCorriente.Name = "lblSaldoCuentaCorriente"
        Me.lblSaldoCuentaCorriente.Size = New System.Drawing.Size(214, 21)
        Me.lblSaldoCuentaCorriente.TabIndex = 0
        Me.lblSaldoCuentaCorriente.Text = "Saldo Cuenta Corriente: 0,00"
        Me.lblSaldoCuentaCorriente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CodiTO
        '
        Me.CodiTO.DataPropertyName = "CodiTO"
        Me.CodiTO.HeaderText = "CodiTO"
        Me.CodiTO.Name = "CodiTO"
        Me.CodiTO.Visible = False
        '
        'CodiTC
        '
        Me.CodiTC.DataPropertyName = "CodiTC"
        Me.CodiTC.HeaderText = "CodiTC"
        Me.CodiTC.Name = "CodiTC"
        Me.CodiTC.Visible = False
        '
        'Seleccionar
        '
        Me.Seleccionar.HeaderText = ""
        Me.Seleccionar.Name = "Seleccionar"
        Me.Seleccionar.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Seleccionar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'IdOperacion
        '
        Me.IdOperacion.DataPropertyName = "IdOperacion"
        Me.IdOperacion.HeaderText = "IdOperacion"
        Me.IdOperacion.Name = "IdOperacion"
        Me.IdOperacion.ReadOnly = True
        '
        'Operacion
        '
        Me.Operacion.DataPropertyName = "Operacion"
        Me.Operacion.HeaderText = "Operacion"
        Me.Operacion.Name = "Operacion"
        '
        'Resu
        '
        Me.Resu.DataPropertyName = "Resu"
        Me.Resu.HeaderText = "Resu"
        Me.Resu.Name = "Resu"
        Me.Resu.ReadOnly = True
        '
        'TipoComprobante
        '
        Me.TipoComprobante.DataPropertyName = "TipoComprobante"
        Me.TipoComprobante.HeaderText = "Comprobante"
        Me.TipoComprobante.Name = "TipoComprobante"
        Me.TipoComprobante.ReadOnly = True
        '
        'FechaComp
        '
        Me.FechaComp.DataPropertyName = "FechaComp"
        Me.FechaComp.HeaderText = "Fecha"
        Me.FechaComp.Name = "FechaComp"
        Me.FechaComp.ReadOnly = True
        '
        'PVenta
        '
        Me.PVenta.DataPropertyName = "PVenta"
        Me.PVenta.HeaderText = "P.Venta"
        Me.PVenta.Name = "PVenta"
        Me.PVenta.ReadOnly = True
        '
        'NumComp
        '
        Me.NumComp.DataPropertyName = "NumComp"
        Me.NumComp.HeaderText = "Num.Comp."
        Me.NumComp.Name = "NumComp"
        Me.NumComp.ReadOnly = True
        '
        'ComprobanteAsociado
        '
        Me.ComprobanteAsociado.DataPropertyName = "ComprobanteAsociado"
        Me.ComprobanteAsociado.HeaderText = "Comp. Asociado"
        Me.ComprobanteAsociado.Name = "ComprobanteAsociado"
        Me.ComprobanteAsociado.ReadOnly = True
        Me.ComprobanteAsociado.Width = 150
        '
        'Observaciones
        '
        Me.Observaciones.DataPropertyName = "Observaciones"
        Me.Observaciones.HeaderText = "Observaciones"
        Me.Observaciones.Name = "Observaciones"
        Me.Observaciones.ReadOnly = True
        '
        'Importe
        '
        Me.Importe.DataPropertyName = "Importe"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.Importe.DefaultCellStyle = DataGridViewCellStyle1
        Me.Importe.HeaderText = "Importe"
        Me.Importe.Name = "Importe"
        Me.Importe.ReadOnly = True
        '
        'EstadoOperacionCC
        '
        Me.EstadoOperacionCC.DataPropertyName = "EstadoOperacionCC"
        Me.EstadoOperacionCC.HeaderText = "Estado"
        Me.EstadoOperacionCC.Name = "EstadoOperacionCC"
        Me.EstadoOperacionCC.ReadOnly = True
        '
        'FrmMovimientosCC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1554, 737)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FrmMovimientosCC"
        Me.Text = "Movimientos Cuenta Corriente"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents mnuArchivo As ToolStripMenuItem
    Friend WithEvents mnuArchivoImprimir As ToolStripMenuItem
    Friend WithEvents mnuArchivoEmail As ToolStripMenuItem
    Friend WithEvents mnuArchivoGuardarComo As ToolStripMenuItem
    Friend WithEvents mnuArchivoSalir As ToolStripMenuItem
    Friend WithEvents mnuOperaciones As ToolStripMenuItem
    Friend WithEvents mnuOperacionesNC As ToolStripMenuItem
    Friend WithEvents mnuArchivoImprimirOriginal As ToolStripMenuItem
    Friend WithEvents mnuArchivoImprimirDuplicado As ToolStripMenuItem
    Friend WithEvents mnuOperacionesFacturarRemito As ToolStripMenuItem
    Friend WithEvents DataGridView2 As DataGridView
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
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents lblImporteAdeudadoItemsSeleccionados As Label
    Friend WithEvents lblSaldoCuentaCorriente As Label
    Friend WithEvents lblDescripcionCuentaCorriente As Label
    Friend WithEvents mnuOperacionesCancelarFacturas As ToolStripMenuItem
    Friend WithEvents mnuOperacionesPagoACuenta As ToolStripMenuItem
    Friend WithEvents mnuOperacionesCancelarResumen As ToolStripMenuItem
    Friend WithEvents mnuOperacionesCancelarCuenta As ToolStripMenuItem
    Friend WithEvents mnuEditar As ToolStripMenuItem
    Friend WithEvents mnuEditarModificarResumen As ToolStripMenuItem
    Friend WithEvents CodiTO As DataGridViewTextBoxColumn
    Friend WithEvents CodiTC As DataGridViewTextBoxColumn
    Friend WithEvents Seleccionar As DataGridViewCheckBoxColumn
    Friend WithEvents IdOperacion As DataGridViewTextBoxColumn
    Friend WithEvents Operacion As DataGridViewTextBoxColumn
    Friend WithEvents Resu As DataGridViewTextBoxColumn
    Friend WithEvents TipoComprobante As DataGridViewTextBoxColumn
    Friend WithEvents FechaComp As DataGridViewTextBoxColumn
    Friend WithEvents PVenta As DataGridViewTextBoxColumn
    Friend WithEvents NumComp As DataGridViewTextBoxColumn
    Friend WithEvents ComprobanteAsociado As DataGridViewTextBoxColumn
    Friend WithEvents Observaciones As DataGridViewTextBoxColumn
    Friend WithEvents Importe As DataGridViewTextBoxColumn
    Friend WithEvents EstadoOperacionCC As DataGridViewTextBoxColumn
End Class
