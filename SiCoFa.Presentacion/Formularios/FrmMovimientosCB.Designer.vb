<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMovimientosCB
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMovimientosCB))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnuArchivo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuArchivoImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuArchivoSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOperaciones = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOperacionesRetiroEfectivo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOperacionesDepositoEfectivo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOperacionesTransferenciaBancaria = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOperacionesAnularOperacion = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuVerCuenta = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.CodiTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodiTC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdOperacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Operacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Resu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaComp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumComp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ComprobanteAsociado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Observaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SaldoP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EstadoOperacionCB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblDescripcionCuentaBancaria = New System.Windows.Forms.Label()
        Me.lblSaldoActual = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.51145!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.48855!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(984, 661)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuArchivo, Me.mnuOperaciones, Me.mnuVerCuenta})
        Me.MenuStrip1.Location = New System.Drawing.Point(2, 2)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(272, 24)
        Me.MenuStrip1.TabIndex = 9
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnuArchivo
        '
        Me.mnuArchivo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuArchivoImprimir, Me.mnuArchivoSalir})
        Me.mnuArchivo.Name = "mnuArchivo"
        Me.mnuArchivo.Size = New System.Drawing.Size(60, 20)
        Me.mnuArchivo.Text = "&Archivo"
        '
        'mnuArchivoImprimir
        '
        Me.mnuArchivoImprimir.Image = CType(resources.GetObject("mnuArchivoImprimir.Image"), System.Drawing.Image)
        Me.mnuArchivoImprimir.Name = "mnuArchivoImprimir"
        Me.mnuArchivoImprimir.Size = New System.Drawing.Size(120, 22)
        Me.mnuArchivoImprimir.Text = "&Imprimir"
        '
        'mnuArchivoSalir
        '
        Me.mnuArchivoSalir.Image = CType(resources.GetObject("mnuArchivoSalir.Image"), System.Drawing.Image)
        Me.mnuArchivoSalir.Name = "mnuArchivoSalir"
        Me.mnuArchivoSalir.Size = New System.Drawing.Size(120, 22)
        Me.mnuArchivoSalir.Text = "&Salir"
        '
        'mnuOperaciones
        '
        Me.mnuOperaciones.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOperacionesRetiroEfectivo, Me.mnuOperacionesDepositoEfectivo, Me.mnuOperacionesTransferenciaBancaria, Me.mnuOperacionesAnularOperacion})
        Me.mnuOperaciones.Name = "mnuOperaciones"
        Me.mnuOperaciones.Size = New System.Drawing.Size(85, 20)
        Me.mnuOperaciones.Text = "&Operaciones"
        '
        'mnuOperacionesRetiroEfectivo
        '
        Me.mnuOperacionesRetiroEfectivo.Image = Global.SiCoFa.Presentacion.My.Resources.Resources.bundle
        Me.mnuOperacionesRetiroEfectivo.Name = "mnuOperacionesRetiroEfectivo"
        Me.mnuOperacionesRetiroEfectivo.Size = New System.Drawing.Size(191, 22)
        Me.mnuOperacionesRetiroEfectivo.Text = "&Retiro Efectivo"
        '
        'mnuOperacionesDepositoEfectivo
        '
        Me.mnuOperacionesDepositoEfectivo.Image = Global.SiCoFa.Presentacion.My.Resources.Resources.BILL00E
        Me.mnuOperacionesDepositoEfectivo.Name = "mnuOperacionesDepositoEfectivo"
        Me.mnuOperacionesDepositoEfectivo.Size = New System.Drawing.Size(191, 22)
        Me.mnuOperacionesDepositoEfectivo.Text = "&Deposito Efectivo"
        '
        'mnuOperacionesTransferenciaBancaria
        '
        Me.mnuOperacionesTransferenciaBancaria.Image = Global.SiCoFa.Presentacion.My.Resources.Resources.BANK00A1
        Me.mnuOperacionesTransferenciaBancaria.Name = "mnuOperacionesTransferenciaBancaria"
        Me.mnuOperacionesTransferenciaBancaria.Size = New System.Drawing.Size(191, 22)
        Me.mnuOperacionesTransferenciaBancaria.Text = "&Transferencia Bancaria"
        '
        'mnuOperacionesAnularOperacion
        '
        Me.mnuOperacionesAnularOperacion.Image = CType(resources.GetObject("mnuOperacionesAnularOperacion.Image"), System.Drawing.Image)
        Me.mnuOperacionesAnularOperacion.Name = "mnuOperacionesAnularOperacion"
        Me.mnuOperacionesAnularOperacion.Size = New System.Drawing.Size(191, 22)
        Me.mnuOperacionesAnularOperacion.Text = "&Anular Operacion"
        '
        'mnuVerCuenta
        '
        Me.mnuVerCuenta.Name = "mnuVerCuenta"
        Me.mnuVerCuenta.Size = New System.Drawing.Size(119, 20)
        Me.mnuVerCuenta.Text = "&Ver Cuenta Destino"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodiTO, Me.CodiTC, Me.IdOperacion, Me.Operacion, Me.Resu, Me.TipoComprobante, Me.FechaComp, Me.NumComp, Me.ComprobanteAsociado, Me.Observaciones, Me.Importe, Me.SaldoP, Me.EstadoOperacionCB})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(5, 32)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowHeadersWidth = 20
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(974, 581)
        Me.DataGridView1.TabIndex = 1
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
        'IdOperacion
        '
        Me.IdOperacion.DataPropertyName = "IdOperacion"
        Me.IdOperacion.HeaderText = "IdOperacion"
        Me.IdOperacion.Name = "IdOperacion"
        Me.IdOperacion.ReadOnly = True
        Me.IdOperacion.Width = 80
        '
        'Operacion
        '
        Me.Operacion.DataPropertyName = "Operacion"
        Me.Operacion.HeaderText = "Operacion"
        Me.Operacion.Name = "Operacion"
        Me.Operacion.ReadOnly = True
        '
        'Resu
        '
        Me.Resu.DataPropertyName = "Resu"
        Me.Resu.HeaderText = "Resu"
        Me.Resu.Name = "Resu"
        Me.Resu.ReadOnly = True
        Me.Resu.Width = 60
        '
        'TipoComprobante
        '
        Me.TipoComprobante.DataPropertyName = "Comprobante"
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
        'NumComp
        '
        Me.NumComp.DataPropertyName = "NumComp"
        Me.NumComp.HeaderText = "Num.Comp."
        Me.NumComp.Name = "NumComp"
        Me.NumComp.ReadOnly = True
        Me.NumComp.Width = 80
        '
        'ComprobanteAsociado
        '
        Me.ComprobanteAsociado.DataPropertyName = "ComprobanteAsociado"
        Me.ComprobanteAsociado.HeaderText = "Comp.Asoc."
        Me.ComprobanteAsociado.Name = "ComprobanteAsociado"
        Me.ComprobanteAsociado.ReadOnly = True
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
        Me.Importe.HeaderText = "Imp.Operacion"
        Me.Importe.Name = "Importe"
        Me.Importe.ReadOnly = True
        Me.Importe.Width = 80
        '
        'SaldoP
        '
        Me.SaldoP.DataPropertyName = "SaldoP"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.SaldoP.DefaultCellStyle = DataGridViewCellStyle2
        Me.SaldoP.HeaderText = "Saldo"
        Me.SaldoP.Name = "SaldoP"
        Me.SaldoP.ReadOnly = True
        Me.SaldoP.Width = 80
        '
        'EstadoOperacionCB
        '
        Me.EstadoOperacionCB.DataPropertyName = "EstadoOperacionCB"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.EstadoOperacionCB.DefaultCellStyle = DataGridViewCellStyle3
        Me.EstadoOperacionCB.HeaderText = "Estado"
        Me.EstadoOperacionCB.Name = "EstadoOperacionCB"
        Me.EstadoOperacionCB.ReadOnly = True
        Me.EstadoOperacionCB.Width = 80
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(5, 621)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(974, 35)
        Me.Panel1.TabIndex = 12
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 473.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.lblDescripcionCuentaBancaria, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblSaldoActual, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(974, 35)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'lblDescripcionCuentaBancaria
        '
        Me.lblDescripcionCuentaBancaria.AutoSize = True
        Me.lblDescripcionCuentaBancaria.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblDescripcionCuentaBancaria.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescripcionCuentaBancaria.Location = New System.Drawing.Point(6, 3)
        Me.lblDescripcionCuentaBancaria.Name = "lblDescripcionCuentaBancaria"
        Me.lblDescripcionCuentaBancaria.Size = New System.Drawing.Size(132, 29)
        Me.lblDescripcionCuentaBancaria.TabIndex = 2
        Me.lblDescripcionCuentaBancaria.Text = "Cuenta Bancaria:"
        Me.lblDescripcionCuentaBancaria.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSaldoActual
        '
        Me.lblSaldoActual.AutoSize = True
        Me.lblSaldoActual.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblSaldoActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldoActual.Location = New System.Drawing.Point(747, 3)
        Me.lblSaldoActual.Name = "lblSaldoActual"
        Me.lblSaldoActual.Size = New System.Drawing.Size(221, 29)
        Me.lblSaldoActual.TabIndex = 1
        Me.lblSaldoActual.Text = "Saldo Cuenta Bancaria: $0,00"
        Me.lblSaldoActual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmMovimientosCB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 661)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FrmMovimientosCB"
        Me.Text = "Movimientos Cuenta Corriente"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents mnuArchivoSalir As ToolStripMenuItem
    Friend WithEvents mnuOperaciones As ToolStripMenuItem
    Friend WithEvents mnuOperacionesAnularOperacion As ToolStripMenuItem
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents lblSaldoActual As Label
    Friend WithEvents lblDescripcionCuentaBancaria As Label
    Friend WithEvents mnuOperacionesRetiroEfectivo As ToolStripMenuItem
    Friend WithEvents mnuOperacionesDepositoEfectivo As ToolStripMenuItem
    Friend WithEvents mnuOperacionesTransferenciaBancaria As ToolStripMenuItem
    Friend WithEvents mnuVerCuenta As ToolStripMenuItem
    Friend WithEvents CodiTO As DataGridViewTextBoxColumn
    Friend WithEvents CodiTC As DataGridViewTextBoxColumn
    Friend WithEvents IdOperacion As DataGridViewTextBoxColumn
    Friend WithEvents Operacion As DataGridViewTextBoxColumn
    Friend WithEvents Resu As DataGridViewTextBoxColumn
    Friend WithEvents TipoComprobante As DataGridViewTextBoxColumn
    Friend WithEvents FechaComp As DataGridViewTextBoxColumn
    Friend WithEvents NumComp As DataGridViewTextBoxColumn
    Friend WithEvents ComprobanteAsociado As DataGridViewTextBoxColumn
    Friend WithEvents Observaciones As DataGridViewTextBoxColumn
    Friend WithEvents Importe As DataGridViewTextBoxColumn
    Friend WithEvents SaldoP As DataGridViewTextBoxColumn
    Friend WithEvents EstadoOperacionCB As DataGridViewTextBoxColumn
End Class
