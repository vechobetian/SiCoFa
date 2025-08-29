<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAnalisisVentas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAnalisisVentas))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOperac = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImpMedioTiket = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImpBto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImpDes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImpNeto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImpEf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImpCC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImpPE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.MenuStrip1, 0, 0)
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
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
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
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Fecha, Me.NOperac, Me.ImpMedioTiket, Me.ImpBto, Me.ImpDes, Me.ImpNeto, Me.ImpEf, Me.ImpCC, Me.ImpPE})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(5, 32)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 20
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1349, 512)
        Me.DataGridView1.TabIndex = 1
        '
        'Fecha
        '
        Me.Fecha.DataPropertyName = "Fecha"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Fecha.DefaultCellStyle = DataGridViewCellStyle2
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        '
        'NOperac
        '
        Me.NOperac.DataPropertyName = "NOperac"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.NOperac.DefaultCellStyle = DataGridViewCellStyle3
        Me.NOperac.HeaderText = "N° Operaciones"
        Me.NOperac.Name = "NOperac"
        Me.NOperac.ReadOnly = True
        '
        'ImpMedioTiket
        '
        Me.ImpMedioTiket.DataPropertyName = "ImpMedioTiket"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.ImpMedioTiket.DefaultCellStyle = DataGridViewCellStyle4
        Me.ImpMedioTiket.HeaderText = "Ticket Promedio"
        Me.ImpMedioTiket.Name = "ImpMedioTiket"
        Me.ImpMedioTiket.ReadOnly = True
        '
        'ImpBto
        '
        Me.ImpBto.DataPropertyName = "ImpBto"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.ImpBto.DefaultCellStyle = DataGridViewCellStyle5
        Me.ImpBto.HeaderText = "Importe Bruto"
        Me.ImpBto.Name = "ImpBto"
        Me.ImpBto.ReadOnly = True
        '
        'ImpDes
        '
        Me.ImpDes.DataPropertyName = "ImpDes"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.ImpDes.DefaultCellStyle = DataGridViewCellStyle6
        Me.ImpDes.HeaderText = "Descuentos"
        Me.ImpDes.Name = "ImpDes"
        Me.ImpDes.ReadOnly = True
        '
        'ImpNeto
        '
        Me.ImpNeto.DataPropertyName = "ImpNeto"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.ImpNeto.DefaultCellStyle = DataGridViewCellStyle7
        Me.ImpNeto.HeaderText = "Importe Neto"
        Me.ImpNeto.Name = "ImpNeto"
        Me.ImpNeto.ReadOnly = True
        Me.ImpNeto.Width = 150
        '
        'ImpEf
        '
        Me.ImpEf.DataPropertyName = "ImpEf"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.ImpEf.DefaultCellStyle = DataGridViewCellStyle8
        Me.ImpEf.HeaderText = "Efectivo"
        Me.ImpEf.Name = "ImpEf"
        Me.ImpEf.ReadOnly = True
        '
        'ImpCC
        '
        Me.ImpCC.DataPropertyName = "ImpCC"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "N2"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.ImpCC.DefaultCellStyle = DataGridViewCellStyle9
        Me.ImpCC.HeaderText = "Cuenta Corriente"
        Me.ImpCC.Name = "ImpCC"
        Me.ImpCC.ReadOnly = True
        '
        'ImpPE
        '
        Me.ImpPE.DataPropertyName = "ImpPE"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.ImpPE.DefaultCellStyle = DataGridViewCellStyle10
        Me.ImpPE.HeaderText = "Pago Electronico"
        Me.ImpPE.Name = "ImpPE"
        Me.ImpPE.ReadOnly = True
        Me.ImpPE.Width = 120
        '
        'FrmAnalisisVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1359, 737)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FrmAnalisisVentas"
        Me.Text = "FrmComprobantes"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents mnuOpciones As ToolStripMenuItem
    Friend WithEvents mnuOpcionesIVAIncluidoEnPrecioCosto As ToolStripMenuItem
    Friend WithEvents RecuperarComprobanteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuArchivoImprimirOriginal As ToolStripMenuItem
    Friend WithEvents mnuArchivoImprimirDuplicado As ToolStripMenuItem
    Friend WithEvents Fecha As DataGridViewTextBoxColumn
    Friend WithEvents NOperac As DataGridViewTextBoxColumn
    Friend WithEvents ImpMedioTiket As DataGridViewTextBoxColumn
    Friend WithEvents ImpBto As DataGridViewTextBoxColumn
    Friend WithEvents ImpDes As DataGridViewTextBoxColumn
    Friend WithEvents ImpNeto As DataGridViewTextBoxColumn
    Friend WithEvents ImpEf As DataGridViewTextBoxColumn
    Friend WithEvents ImpCC As DataGridViewTextBoxColumn
    Friend WithEvents ImpPE As DataGridViewTextBoxColumn
End Class
