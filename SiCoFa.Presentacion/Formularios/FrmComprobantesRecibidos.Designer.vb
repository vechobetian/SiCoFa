<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmComprobantesRecibidos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmComprobantesRecibidos))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.mnuOperacionesNC = New System.Windows.Forms.ToolStripMenuItem()
        Me.RecuperarComprobanteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOpciones = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOpcionesIVAIncluidoEnPrecioCosto = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.IdOperacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodiTC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdOperAsoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaComp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PVenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumComp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Proveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImpBto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImpDes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImpEf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImpCC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImpPE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ComprobanteAsociado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodBarras = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AlicIVA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioUnitario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImporteNeto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImporteIVA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.MenuStrip1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.DataGridView2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.DataGridView1, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 73.68421!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.31579!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1359, 737)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuArchivo, Me.mnuOperaciones, Me.mnuOpciones})
        Me.MenuStrip1.Location = New System.Drawing.Point(2, 2)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1355, 24)
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
        Me.mnuOperaciones.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOperacionesNC, Me.RecuperarComprobanteToolStripMenuItem})
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
        'RecuperarComprobanteToolStripMenuItem
        '
        Me.RecuperarComprobanteToolStripMenuItem.Name = "RecuperarComprobanteToolStripMenuItem"
        Me.RecuperarComprobanteToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.RecuperarComprobanteToolStripMenuItem.Text = "&Recuperar Comprobante"
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
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdItem, Me.CodBarras, Me.Descripcion, Me.Cantidad, Me.AlicIVA, Me.PrecioUnitario, Me.ImporteNeto, Me.ImporteIVA, Me.Importe})
        Me.DataGridView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView2.Location = New System.Drawing.Point(5, 552)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowHeadersWidth = 20
        Me.DataGridView2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DataGridView2.Size = New System.Drawing.Size(1349, 180)
        Me.DataGridView2.TabIndex = 8
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdOperacion, Me.CodiTC, Me.IdOperAsoc, Me.TipoComprobante, Me.FechaComp, Me.PVenta, Me.NumComp, Me.Proveedor, Me.ImpBto, Me.ImpDes, Me.ImpEf, Me.ImpCC, Me.ImpPE, Me.ComprobanteAsociado})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(5, 32)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 20
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1349, 512)
        Me.DataGridView1.TabIndex = 1
        '
        'IdOperacion
        '
        Me.IdOperacion.DataPropertyName = "IdOperacion"
        Me.IdOperacion.HeaderText = "IdOperacion"
        Me.IdOperacion.Name = "IdOperacion"
        Me.IdOperacion.ReadOnly = True
        Me.IdOperacion.Visible = False
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
        'Proveedor
        '
        Me.Proveedor.DataPropertyName = "Proveedor"
        Me.Proveedor.HeaderText = "Proveedor"
        Me.Proveedor.Name = "Proveedor"
        Me.Proveedor.ReadOnly = True
        '
        'ImpBto
        '
        Me.ImpBto.DataPropertyName = "ImpBto"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.ImpBto.DefaultCellStyle = DataGridViewCellStyle8
        Me.ImpBto.HeaderText = "Importe"
        Me.ImpBto.Name = "ImpBto"
        Me.ImpBto.ReadOnly = True
        '
        'ImpDes
        '
        Me.ImpDes.DataPropertyName = "ImpDes"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "N2"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.ImpDes.DefaultCellStyle = DataGridViewCellStyle9
        Me.ImpDes.HeaderText = "Descuento"
        Me.ImpDes.Name = "ImpDes"
        Me.ImpDes.ReadOnly = True
        '
        'ImpEf
        '
        Me.ImpEf.DataPropertyName = "ImpEf"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.ImpEf.DefaultCellStyle = DataGridViewCellStyle10
        Me.ImpEf.HeaderText = "Efectivo"
        Me.ImpEf.Name = "ImpEf"
        Me.ImpEf.ReadOnly = True
        '
        'ImpCC
        '
        Me.ImpCC.DataPropertyName = "ImpCC"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Format = "N2"
        DataGridViewCellStyle11.NullValue = Nothing
        Me.ImpCC.DefaultCellStyle = DataGridViewCellStyle11
        Me.ImpCC.HeaderText = "Cta. Cte."
        Me.ImpCC.Name = "ImpCC"
        Me.ImpCC.ReadOnly = True
        '
        'ImpPE
        '
        Me.ImpPE.DataPropertyName = "ImpPE"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.Format = "N2"
        DataGridViewCellStyle12.NullValue = Nothing
        Me.ImpPE.DefaultCellStyle = DataGridViewCellStyle12
        Me.ImpPE.HeaderText = "Pago Electronico"
        Me.ImpPE.Name = "ImpPE"
        Me.ImpPE.ReadOnly = True
        Me.ImpPE.Width = 120
        '
        'ComprobanteAsociado
        '
        Me.ComprobanteAsociado.DataPropertyName = "ComprobanteAsociado"
        Me.ComprobanteAsociado.HeaderText = "Comp. Asociado"
        Me.ComprobanteAsociado.Name = "ComprobanteAsociado"
        Me.ComprobanteAsociado.ReadOnly = True
        Me.ComprobanteAsociado.Width = 150
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
        Me.PrecioUnitario.DataPropertyName = "PrecioCosto"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.PrecioUnitario.DefaultCellStyle = DataGridViewCellStyle4
        Me.PrecioUnitario.FillWeight = 68.81715!
        Me.PrecioUnitario.HeaderText = "Precio Costo + IVA"
        Me.PrecioUnitario.Name = "PrecioUnitario"
        Me.PrecioUnitario.ReadOnly = True
        '
        'ImporteNeto
        '
        Me.ImporteNeto.DataPropertyName = "ImporteNeto"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.ImporteNeto.DefaultCellStyle = DataGridViewCellStyle5
        Me.ImporteNeto.FillWeight = 59.96484!
        Me.ImporteNeto.HeaderText = "Importe Neto"
        Me.ImporteNeto.Name = "ImporteNeto"
        Me.ImporteNeto.ReadOnly = True
        '
        'ImporteIVA
        '
        Me.ImporteIVA.DataPropertyName = "ImporteIVA"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.ImporteIVA.DefaultCellStyle = DataGridViewCellStyle6
        Me.ImporteIVA.FillWeight = 57.10529!
        Me.ImporteIVA.HeaderText = "Importe IVA"
        Me.ImporteIVA.Name = "ImporteIVA"
        Me.ImporteIVA.ReadOnly = True
        '
        'Importe
        '
        Me.Importe.DataPropertyName = "Importe"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.Importe.DefaultCellStyle = DataGridViewCellStyle7
        Me.Importe.FillWeight = 54.31535!
        Me.Importe.HeaderText = "Importe"
        Me.Importe.Name = "Importe"
        Me.Importe.ReadOnly = True
        '
        'FrmComprobantesRecibidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1359, 737)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FrmComprobantesRecibidos"
        Me.Text = "FrmComprobantes"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents mnuArchivo As ToolStripMenuItem
    Friend WithEvents mnuArchivoImprimir As ToolStripMenuItem
    Friend WithEvents mnuArchivoEmail As ToolStripMenuItem
    Friend WithEvents mnuArchivoGuardarComo As ToolStripMenuItem
    Friend WithEvents mnuArchivoSalir As ToolStripMenuItem
    Friend WithEvents mnuOperaciones As ToolStripMenuItem
    Friend WithEvents mnuOperacionesNC As ToolStripMenuItem
    Friend WithEvents mnuOpciones As ToolStripMenuItem
    Friend WithEvents mnuOpcionesIVAIncluidoEnPrecioCosto As ToolStripMenuItem
    Friend WithEvents RecuperarComprobanteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuArchivoImprimirOriginal As ToolStripMenuItem
    Friend WithEvents mnuArchivoImprimirDuplicado As ToolStripMenuItem
    Friend WithEvents IdOperacion As DataGridViewTextBoxColumn
    Friend WithEvents CodiTC As DataGridViewTextBoxColumn
    Friend WithEvents IdOperAsoc As DataGridViewTextBoxColumn
    Friend WithEvents TipoComprobante As DataGridViewTextBoxColumn
    Friend WithEvents FechaComp As DataGridViewTextBoxColumn
    Friend WithEvents PVenta As DataGridViewTextBoxColumn
    Friend WithEvents NumComp As DataGridViewTextBoxColumn
    Friend WithEvents Proveedor As DataGridViewTextBoxColumn
    Friend WithEvents ImpBto As DataGridViewTextBoxColumn
    Friend WithEvents ImpDes As DataGridViewTextBoxColumn
    Friend WithEvents ImpEf As DataGridViewTextBoxColumn
    Friend WithEvents ImpCC As DataGridViewTextBoxColumn
    Friend WithEvents ImpPE As DataGridViewTextBoxColumn
    Friend WithEvents ComprobanteAsociado As DataGridViewTextBoxColumn
    Friend WithEvents IdItem As DataGridViewTextBoxColumn
    Friend WithEvents CodBarras As DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As DataGridViewTextBoxColumn
    Friend WithEvents AlicIVA As DataGridViewTextBoxColumn
    Friend WithEvents PrecioUnitario As DataGridViewTextBoxColumn
    Friend WithEvents ImporteNeto As DataGridViewTextBoxColumn
    Friend WithEvents ImporteIVA As DataGridViewTextBoxColumn
    Friend WithEvents Importe As DataGridViewTextBoxColumn
End Class
