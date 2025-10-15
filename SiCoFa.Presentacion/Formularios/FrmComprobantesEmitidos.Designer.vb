<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmComprobantesEmitidos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmComprobantesEmitidos))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnuArchivo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuArchivoImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuArchivoImprimirOriginal = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuArchivoImprimirDuplicado = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuArchivoEmail = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuArchivoGuardarComo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuArchivoSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOperaciones = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOperacionesNC = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOperacionesRecuperarComprobante = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOperacionesFacturarRemito = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOperacionesFacturarPresupuesto = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFacturarPresupuestoEmitirFactura = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFacturarPresupuestoEmitirRemito = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOperacionesAnularReciboDePago = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.CodiTC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdOperAsoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdOperacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Operacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdUsuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaComp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PVenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumComp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ComprobanteAsociado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EstadoOperacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Observaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescripcionError = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodiTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImpBto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImpDes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImpNeto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImpEf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImpCC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImpPE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblImpPEEtiqueta = New System.Windows.Forms.Label()
        Me.lblImpCCEtiqueta = New System.Windows.Forms.Label()
        Me.lblImpEfEtiqueta = New System.Windows.Forms.Label()
        Me.lblImpNetoEtiqueta = New System.Windows.Forms.Label()
        Me.lblImpDesEtiqueta = New System.Windows.Forms.Label()
        Me.lblImpBtoEtiqueta = New System.Windows.Forms.Label()
        Me.lblImpBto = New System.Windows.Forms.Label()
        Me.lblImpDes = New System.Windows.Forms.Label()
        Me.lblImpNeto = New System.Windows.Forms.Label()
        Me.lblImpEf = New System.Windows.Forms.Label()
        Me.lblImpCC = New System.Windows.Forms.Label()
        Me.lblImpPE = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 395.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.DataGridView2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.MenuStrip1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.DataGridView1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 1, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1010, 737)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToResizeColumns = False
        Me.DataGridView2.AllowUserToResizeRows = False
        Me.DataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView2.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdItem, Me.CodBarras, Me.Descripcion, Me.Cantidad, Me.AlicIVA, Me.PrecioUnitario, Me.ImporteSinDescuento, Me.PorcentajeDescuento, Me.ImporteDescuento, Me.ImporteConDescuento})
        Me.DataGridView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView2.Location = New System.Drawing.Point(5, 533)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.RowHeadersWidth = 20
        Me.DataGridView2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView2.Size = New System.Drawing.Size(603, 199)
        Me.DataGridView2.TabIndex = 10
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
        Me.CodBarras.FillWeight = 46.31689!
        Me.CodBarras.HeaderText = "CodBarras"
        Me.CodBarras.Name = "CodBarras"
        Me.CodBarras.ReadOnly = True
        '
        'Descripcion
        '
        Me.Descripcion.DataPropertyName = "Descripcion"
        Me.Descripcion.FillWeight = 84.50518!
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
        Me.Cantidad.FillWeight = 45.17765!
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
        Me.AlicIVA.FillWeight = 49.05295!
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
        Me.PrecioUnitario.FillWeight = 163.2504!
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
        Me.ImporteSinDescuento.FillWeight = 142.2507!
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
        Me.PorcentajeDescuento.FillWeight = 135.4671!
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
        Me.ImporteDescuento.FillWeight = 128.8487!
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
        Me.ImporteConDescuento.FillWeight = 95.13017!
        Me.ImporteConDescuento.HeaderText = "Imp.Cliente"
        Me.ImporteConDescuento.Name = "ImporteConDescuento"
        Me.ImporteConDescuento.ReadOnly = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuArchivo, Me.mnuOperaciones})
        Me.MenuStrip1.Location = New System.Drawing.Point(2, 2)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(609, 24)
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
        Me.mnuOperaciones.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOperacionesNC, Me.mnuOperacionesRecuperarComprobante, Me.mnuOperacionesFacturarRemito, Me.mnuOperacionesFacturarPresupuesto, Me.mnuOperacionesAnularReciboDePago})
        Me.mnuOperaciones.Name = "mnuOperaciones"
        Me.mnuOperaciones.Size = New System.Drawing.Size(85, 20)
        Me.mnuOperaciones.Text = "&Operaciones"
        '
        'mnuOperacionesNC
        '
        Me.mnuOperacionesNC.Image = CType(resources.GetObject("mnuOperacionesNC.Image"), System.Drawing.Image)
        Me.mnuOperacionesNC.Name = "mnuOperacionesNC"
        Me.mnuOperacionesNC.Size = New System.Drawing.Size(204, 22)
        Me.mnuOperacionesNC.Text = "&Nota de Crédito"
        '
        'mnuOperacionesRecuperarComprobante
        '
        Me.mnuOperacionesRecuperarComprobante.Name = "mnuOperacionesRecuperarComprobante"
        Me.mnuOperacionesRecuperarComprobante.Size = New System.Drawing.Size(204, 22)
        Me.mnuOperacionesRecuperarComprobante.Text = "&Recuperar Comprobante"
        '
        'mnuOperacionesFacturarRemito
        '
        Me.mnuOperacionesFacturarRemito.Name = "mnuOperacionesFacturarRemito"
        Me.mnuOperacionesFacturarRemito.Size = New System.Drawing.Size(204, 22)
        Me.mnuOperacionesFacturarRemito.Text = "&Facturar Remito"
        '
        'mnuOperacionesFacturarPresupuesto
        '
        Me.mnuOperacionesFacturarPresupuesto.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFacturarPresupuestoEmitirFactura, Me.mnuFacturarPresupuestoEmitirRemito})
        Me.mnuOperacionesFacturarPresupuesto.Name = "mnuOperacionesFacturarPresupuesto"
        Me.mnuOperacionesFacturarPresupuesto.Size = New System.Drawing.Size(204, 22)
        Me.mnuOperacionesFacturarPresupuesto.Text = "Facturar &Presupuesto"
        '
        'mnuFacturarPresupuestoEmitirFactura
        '
        Me.mnuFacturarPresupuestoEmitirFactura.Name = "mnuFacturarPresupuestoEmitirFactura"
        Me.mnuFacturarPresupuestoEmitirFactura.Size = New System.Drawing.Size(147, 22)
        Me.mnuFacturarPresupuestoEmitirFactura.Text = "Emitir &Factura"
        '
        'mnuFacturarPresupuestoEmitirRemito
        '
        Me.mnuFacturarPresupuestoEmitirRemito.Name = "mnuFacturarPresupuestoEmitirRemito"
        Me.mnuFacturarPresupuestoEmitirRemito.Size = New System.Drawing.Size(147, 22)
        Me.mnuFacturarPresupuestoEmitirRemito.Text = "Emitir &Remito"
        '
        'mnuOperacionesAnularReciboDePago
        '
        Me.mnuOperacionesAnularReciboDePago.Name = "mnuOperacionesAnularReciboDePago"
        Me.mnuOperacionesAnularReciboDePago.Size = New System.Drawing.Size(204, 22)
        Me.mnuOperacionesAnularReciboDePago.Text = "&Anular Recibo de Pago"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodiTC, Me.IdOperAsoc, Me.IdOperacion, Me.Operacion, Me.IdUsuario, Me.TipoComprobante, Me.FechaComp, Me.PVenta, Me.NumComp, Me.Cliente, Me.ComprobanteAsociado, Me.EstadoOperacion, Me.Observaciones, Me.DescripcionError, Me.CodiTO, Me.ImpBto, Me.ImpDes, Me.ImpNeto, Me.ImpEf, Me.ImpCC, Me.ImpPE})
        Me.TableLayoutPanel1.SetColumnSpan(Me.DataGridView1, 2)
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(5, 32)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowHeadersWidth = 20
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1000, 493)
        Me.DataGridView1.TabIndex = 1
        '
        'CodiTC
        '
        Me.CodiTC.DataPropertyName = "CodiTC"
        Me.CodiTC.HeaderText = "CodiTC"
        Me.CodiTC.Name = "CodiTC"
        Me.CodiTC.ReadOnly = True
        Me.CodiTC.Visible = False
        '
        'IdOperAsoc
        '
        Me.IdOperAsoc.DataPropertyName = "IdOperAsoc"
        Me.IdOperAsoc.HeaderText = "IdOperAsoc"
        Me.IdOperAsoc.Name = "IdOperAsoc"
        Me.IdOperAsoc.ReadOnly = True
        Me.IdOperAsoc.Visible = False
        '
        'IdOperacion
        '
        Me.IdOperacion.DataPropertyName = "IdOperacion"
        Me.IdOperacion.HeaderText = "IdOperacion"
        Me.IdOperacion.Name = "IdOperacion"
        Me.IdOperacion.ReadOnly = True
        Me.IdOperacion.Width = 70
        '
        'Operacion
        '
        Me.Operacion.DataPropertyName = "Operacion"
        Me.Operacion.HeaderText = "Operacion"
        Me.Operacion.Name = "Operacion"
        Me.Operacion.ReadOnly = True
        '
        'IdUsuario
        '
        Me.IdUsuario.DataPropertyName = "IdUsuario"
        Me.IdUsuario.HeaderText = "IdUsuario"
        Me.IdUsuario.Name = "IdUsuario"
        Me.IdUsuario.ReadOnly = True
        Me.IdUsuario.Width = 55
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
        Me.FechaComp.Width = 80
        '
        'PVenta
        '
        Me.PVenta.DataPropertyName = "PVenta"
        Me.PVenta.HeaderText = "P.Venta"
        Me.PVenta.Name = "PVenta"
        Me.PVenta.ReadOnly = True
        Me.PVenta.Width = 60
        '
        'NumComp
        '
        Me.NumComp.DataPropertyName = "NumComp"
        Me.NumComp.HeaderText = "Num.Comp."
        Me.NumComp.Name = "NumComp"
        Me.NumComp.ReadOnly = True
        Me.NumComp.Width = 80
        '
        'Cliente
        '
        Me.Cliente.DataPropertyName = "Cliente"
        Me.Cliente.HeaderText = "Cliente"
        Me.Cliente.Name = "Cliente"
        Me.Cliente.ReadOnly = True
        '
        'ComprobanteAsociado
        '
        Me.ComprobanteAsociado.DataPropertyName = "ComprobanteAsociado"
        Me.ComprobanteAsociado.HeaderText = "Comp.Asoc."
        Me.ComprobanteAsociado.Name = "ComprobanteAsociado"
        Me.ComprobanteAsociado.ReadOnly = True
        Me.ComprobanteAsociado.Width = 80
        '
        'EstadoOperacion
        '
        Me.EstadoOperacion.DataPropertyName = "EstadoOperacion"
        Me.EstadoOperacion.HeaderText = "Estado"
        Me.EstadoOperacion.Name = "EstadoOperacion"
        Me.EstadoOperacion.ReadOnly = True
        Me.EstadoOperacion.Width = 80
        '
        'Observaciones
        '
        Me.Observaciones.DataPropertyName = "Observaciones"
        Me.Observaciones.HeaderText = "Observaciones"
        Me.Observaciones.Name = "Observaciones"
        Me.Observaciones.ReadOnly = True
        Me.Observaciones.Visible = False
        '
        'DescripcionError
        '
        Me.DescripcionError.DataPropertyName = "DescripcionError"
        Me.DescripcionError.HeaderText = "DescripcionError"
        Me.DescripcionError.Name = "DescripcionError"
        Me.DescripcionError.ReadOnly = True
        Me.DescripcionError.Visible = False
        '
        'CodiTO
        '
        Me.CodiTO.DataPropertyName = "CodiTO"
        Me.CodiTO.HeaderText = "CodiTO"
        Me.CodiTO.Name = "CodiTO"
        Me.CodiTO.ReadOnly = True
        Me.CodiTO.Visible = False
        '
        'ImpBto
        '
        Me.ImpBto.DataPropertyName = "ImpBto"
        Me.ImpBto.HeaderText = "ImpBto"
        Me.ImpBto.Name = "ImpBto"
        Me.ImpBto.ReadOnly = True
        Me.ImpBto.Visible = False
        '
        'ImpDes
        '
        Me.ImpDes.DataPropertyName = "ImpDes"
        Me.ImpDes.HeaderText = "ImpDes"
        Me.ImpDes.Name = "ImpDes"
        Me.ImpDes.ReadOnly = True
        Me.ImpDes.Visible = False
        '
        'ImpNeto
        '
        Me.ImpNeto.DataPropertyName = "ImpNeto"
        Me.ImpNeto.HeaderText = "ImpNeto"
        Me.ImpNeto.Name = "ImpNeto"
        Me.ImpNeto.ReadOnly = True
        Me.ImpNeto.Visible = False
        '
        'ImpEf
        '
        Me.ImpEf.DataPropertyName = "ImpEf"
        Me.ImpEf.HeaderText = "ImpEf"
        Me.ImpEf.Name = "ImpEf"
        Me.ImpEf.ReadOnly = True
        Me.ImpEf.Visible = False
        '
        'ImpCC
        '
        Me.ImpCC.DataPropertyName = "ImpCC"
        Me.ImpCC.HeaderText = "ImpCC"
        Me.ImpCC.Name = "ImpCC"
        Me.ImpCC.ReadOnly = True
        Me.ImpCC.Visible = False
        '
        'ImpPE
        '
        Me.ImpPE.DataPropertyName = "ImpPE"
        Me.ImpPE.HeaderText = "ImpPE"
        Me.ImpPE.Name = "ImpPE"
        Me.ImpPE.ReadOnly = True
        Me.ImpPE.Visible = False
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.97351!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.02649!))
        Me.TableLayoutPanel2.Controls.Add(Me.lblImpPEEtiqueta, 0, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.lblImpCCEtiqueta, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.lblImpEfEtiqueta, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.lblImpNetoEtiqueta, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.lblImpDesEtiqueta, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblImpBtoEtiqueta, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblImpBto, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblImpDes, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblImpNeto, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.lblImpEf, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.lblImpCC, 1, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.lblImpPE, 1, 5)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(616, 533)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 6
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(389, 199)
        Me.TableLayoutPanel2.TabIndex = 11
        '
        'lblImpPEEtiqueta
        '
        Me.lblImpPEEtiqueta.AutoSize = True
        Me.lblImpPEEtiqueta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImpPEEtiqueta.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImpPEEtiqueta.Location = New System.Drawing.Point(5, 162)
        Me.lblImpPEEtiqueta.Name = "lblImpPEEtiqueta"
        Me.lblImpPEEtiqueta.Size = New System.Drawing.Size(200, 35)
        Me.lblImpPEEtiqueta.TabIndex = 11
        Me.lblImpPEEtiqueta.Text = "Importe Pago Electronico:"
        Me.lblImpPEEtiqueta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblImpCCEtiqueta
        '
        Me.lblImpCCEtiqueta.AutoSize = True
        Me.lblImpCCEtiqueta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImpCCEtiqueta.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImpCCEtiqueta.Location = New System.Drawing.Point(5, 130)
        Me.lblImpCCEtiqueta.Name = "lblImpCCEtiqueta"
        Me.lblImpCCEtiqueta.Size = New System.Drawing.Size(200, 30)
        Me.lblImpCCEtiqueta.TabIndex = 10
        Me.lblImpCCEtiqueta.Text = "Importe Cuenta Corriente:"
        Me.lblImpCCEtiqueta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblImpEfEtiqueta
        '
        Me.lblImpEfEtiqueta.AutoSize = True
        Me.lblImpEfEtiqueta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImpEfEtiqueta.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImpEfEtiqueta.Location = New System.Drawing.Point(5, 98)
        Me.lblImpEfEtiqueta.Name = "lblImpEfEtiqueta"
        Me.lblImpEfEtiqueta.Size = New System.Drawing.Size(200, 30)
        Me.lblImpEfEtiqueta.TabIndex = 9
        Me.lblImpEfEtiqueta.Text = "Importe Efectivo:"
        Me.lblImpEfEtiqueta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblImpNetoEtiqueta
        '
        Me.lblImpNetoEtiqueta.AutoSize = True
        Me.lblImpNetoEtiqueta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImpNetoEtiqueta.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImpNetoEtiqueta.Location = New System.Drawing.Point(5, 66)
        Me.lblImpNetoEtiqueta.Name = "lblImpNetoEtiqueta"
        Me.lblImpNetoEtiqueta.Size = New System.Drawing.Size(200, 30)
        Me.lblImpNetoEtiqueta.TabIndex = 8
        Me.lblImpNetoEtiqueta.Text = "Importe Neto:"
        Me.lblImpNetoEtiqueta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblImpDesEtiqueta
        '
        Me.lblImpDesEtiqueta.AutoSize = True
        Me.lblImpDesEtiqueta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImpDesEtiqueta.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImpDesEtiqueta.Location = New System.Drawing.Point(5, 34)
        Me.lblImpDesEtiqueta.Name = "lblImpDesEtiqueta"
        Me.lblImpDesEtiqueta.Size = New System.Drawing.Size(200, 30)
        Me.lblImpDesEtiqueta.TabIndex = 7
        Me.lblImpDesEtiqueta.Text = "Importe Descuento:"
        Me.lblImpDesEtiqueta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblImpBtoEtiqueta
        '
        Me.lblImpBtoEtiqueta.AutoSize = True
        Me.lblImpBtoEtiqueta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImpBtoEtiqueta.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImpBtoEtiqueta.Location = New System.Drawing.Point(5, 2)
        Me.lblImpBtoEtiqueta.Name = "lblImpBtoEtiqueta"
        Me.lblImpBtoEtiqueta.Size = New System.Drawing.Size(200, 30)
        Me.lblImpBtoEtiqueta.TabIndex = 6
        Me.lblImpBtoEtiqueta.Text = "Importe Bruto:"
        Me.lblImpBtoEtiqueta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblImpBto
        '
        Me.lblImpBto.AutoSize = True
        Me.lblImpBto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImpBto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImpBto.Location = New System.Drawing.Point(213, 2)
        Me.lblImpBto.Name = "lblImpBto"
        Me.lblImpBto.Size = New System.Drawing.Size(171, 30)
        Me.lblImpBto.TabIndex = 0
        Me.lblImpBto.Text = "0,00"
        Me.lblImpBto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblImpDes
        '
        Me.lblImpDes.AutoSize = True
        Me.lblImpDes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImpDes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImpDes.Location = New System.Drawing.Point(213, 34)
        Me.lblImpDes.Name = "lblImpDes"
        Me.lblImpDes.Size = New System.Drawing.Size(171, 30)
        Me.lblImpDes.TabIndex = 1
        Me.lblImpDes.Text = "0,00"
        Me.lblImpDes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblImpNeto
        '
        Me.lblImpNeto.AutoSize = True
        Me.lblImpNeto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImpNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImpNeto.Location = New System.Drawing.Point(213, 66)
        Me.lblImpNeto.Name = "lblImpNeto"
        Me.lblImpNeto.Size = New System.Drawing.Size(171, 30)
        Me.lblImpNeto.TabIndex = 2
        Me.lblImpNeto.Text = "0,00"
        Me.lblImpNeto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblImpEf
        '
        Me.lblImpEf.AutoSize = True
        Me.lblImpEf.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImpEf.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImpEf.Location = New System.Drawing.Point(213, 98)
        Me.lblImpEf.Name = "lblImpEf"
        Me.lblImpEf.Size = New System.Drawing.Size(171, 30)
        Me.lblImpEf.TabIndex = 3
        Me.lblImpEf.Text = "0,00"
        Me.lblImpEf.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblImpCC
        '
        Me.lblImpCC.AutoSize = True
        Me.lblImpCC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImpCC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImpCC.Location = New System.Drawing.Point(213, 130)
        Me.lblImpCC.Name = "lblImpCC"
        Me.lblImpCC.Size = New System.Drawing.Size(171, 30)
        Me.lblImpCC.TabIndex = 4
        Me.lblImpCC.Text = "0,00"
        Me.lblImpCC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblImpPE
        '
        Me.lblImpPE.AutoSize = True
        Me.lblImpPE.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImpPE.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImpPE.Location = New System.Drawing.Point(213, 162)
        Me.lblImpPE.Name = "lblImpPE"
        Me.lblImpPE.Size = New System.Drawing.Size(171, 35)
        Me.lblImpPE.TabIndex = 5
        Me.lblImpPE.Text = "0,00"
        Me.lblImpPE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FrmComprobantesEmitidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1010, 737)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FrmComprobantesEmitidos"
        Me.Text = "FrmComprobantes"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents mnuOperacionesRecuperarComprobante As ToolStripMenuItem
    Friend WithEvents mnuArchivoImprimirOriginal As ToolStripMenuItem
    Friend WithEvents mnuArchivoImprimirDuplicado As ToolStripMenuItem
    Friend WithEvents mnuOperacionesFacturarRemito As ToolStripMenuItem
    Friend WithEvents mnuOperacionesFacturarPresupuesto As ToolStripMenuItem
    Friend WithEvents mnuFacturarPresupuestoEmitirFactura As ToolStripMenuItem
    Friend WithEvents mnuFacturarPresupuestoEmitirRemito As ToolStripMenuItem
    Friend WithEvents mnuOperacionesAnularReciboDePago As ToolStripMenuItem
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
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents lblImpPEEtiqueta As Label
    Friend WithEvents lblImpCCEtiqueta As Label
    Friend WithEvents lblImpEfEtiqueta As Label
    Friend WithEvents lblImpNetoEtiqueta As Label
    Friend WithEvents lblImpDesEtiqueta As Label
    Friend WithEvents lblImpBtoEtiqueta As Label
    Friend WithEvents lblImpBto As Label
    Friend WithEvents lblImpDes As Label
    Friend WithEvents lblImpNeto As Label
    Friend WithEvents lblImpEf As Label
    Friend WithEvents lblImpCC As Label
    Friend WithEvents lblImpPE As Label
    Friend WithEvents CodiTC As DataGridViewTextBoxColumn
    Friend WithEvents IdOperAsoc As DataGridViewTextBoxColumn
    Friend WithEvents IdOperacion As DataGridViewTextBoxColumn
    Friend WithEvents Operacion As DataGridViewTextBoxColumn
    Friend WithEvents IdUsuario As DataGridViewTextBoxColumn
    Friend WithEvents TipoComprobante As DataGridViewTextBoxColumn
    Friend WithEvents FechaComp As DataGridViewTextBoxColumn
    Friend WithEvents PVenta As DataGridViewTextBoxColumn
    Friend WithEvents NumComp As DataGridViewTextBoxColumn
    Friend WithEvents Cliente As DataGridViewTextBoxColumn
    Friend WithEvents ComprobanteAsociado As DataGridViewTextBoxColumn
    Friend WithEvents EstadoOperacion As DataGridViewTextBoxColumn
    Friend WithEvents Observaciones As DataGridViewTextBoxColumn
    Friend WithEvents DescripcionError As DataGridViewTextBoxColumn
    Friend WithEvents CodiTO As DataGridViewTextBoxColumn
    Friend WithEvents ImpBto As DataGridViewTextBoxColumn
    Friend WithEvents ImpDes As DataGridViewTextBoxColumn
    Friend WithEvents ImpNeto As DataGridViewTextBoxColumn
    Friend WithEvents ImpEf As DataGridViewTextBoxColumn
    Friend WithEvents ImpCC As DataGridViewTextBoxColumn
    Friend WithEvents ImpPE As DataGridViewTextBoxColumn
End Class
