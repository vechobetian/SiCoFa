<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmResultadosMensuales
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
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Año = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ingresos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ganancias = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Gastos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Perdidas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ResultadoMensual = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Utilidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DataGridView3 = New System.Windows.Forms.DataGridView()
        Me.DataGridView4 = New System.Windows.Forms.DataGridView()
        Me.DataGridView5 = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CuentaImputableIngresos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImporteIngresos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CuentaImputable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.006!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.004!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66333!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.DataGridView1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.DataGridView2, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.DataGridView3, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.DataGridView4, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.DataGridView5, 4, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1246, 774)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Año, Me.Mes, Me.Ingresos, Me.Ganancias, Me.Gastos, Me.Perdidas, Me.ResultadoMensual, Me.Utilidad})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(5, 27)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowHeadersWidth = 25
        Me.DataGridView1.Size = New System.Drawing.Size(364, 742)
        Me.DataGridView1.TabIndex = 2
        '
        'Año
        '
        Me.Año.DataPropertyName = "Anio"
        Me.Año.Frozen = True
        Me.Año.HeaderText = "Año"
        Me.Año.Name = "Año"
        Me.Año.ReadOnly = True
        Me.Año.Width = 80
        '
        'Mes
        '
        Me.Mes.DataPropertyName = "Mes"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Mes.DefaultCellStyle = DataGridViewCellStyle1
        Me.Mes.Frozen = True
        Me.Mes.HeaderText = "Mes"
        Me.Mes.Name = "Mes"
        Me.Mes.ReadOnly = True
        Me.Mes.Width = 50
        '
        'Ingresos
        '
        Me.Ingresos.DataPropertyName = "Ingresos"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.Ingresos.DefaultCellStyle = DataGridViewCellStyle2
        Me.Ingresos.Frozen = True
        Me.Ingresos.HeaderText = "Ingresos"
        Me.Ingresos.Name = "Ingresos"
        Me.Ingresos.ReadOnly = True
        Me.Ingresos.Width = 70
        '
        'Ganancias
        '
        Me.Ganancias.DataPropertyName = "Ganancias"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.Ganancias.DefaultCellStyle = DataGridViewCellStyle3
        Me.Ganancias.Frozen = True
        Me.Ganancias.HeaderText = "Ganancias"
        Me.Ganancias.Name = "Ganancias"
        Me.Ganancias.ReadOnly = True
        Me.Ganancias.Width = 70
        '
        'Gastos
        '
        Me.Gastos.DataPropertyName = "Gastos"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.Gastos.DefaultCellStyle = DataGridViewCellStyle4
        Me.Gastos.Frozen = True
        Me.Gastos.HeaderText = "Gastos"
        Me.Gastos.Name = "Gastos"
        Me.Gastos.ReadOnly = True
        Me.Gastos.Width = 70
        '
        'Perdidas
        '
        Me.Perdidas.DataPropertyName = "Perdidas"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.Perdidas.DefaultCellStyle = DataGridViewCellStyle5
        Me.Perdidas.Frozen = True
        Me.Perdidas.HeaderText = "Perdidas"
        Me.Perdidas.Name = "Perdidas"
        Me.Perdidas.ReadOnly = True
        Me.Perdidas.Width = 70
        '
        'ResultadoMensual
        '
        Me.ResultadoMensual.DataPropertyName = "Resultado"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.ResultadoMensual.DefaultCellStyle = DataGridViewCellStyle6
        Me.ResultadoMensual.HeaderText = "Resultado"
        Me.ResultadoMensual.Name = "ResultadoMensual"
        Me.ResultadoMensual.ReadOnly = True
        '
        'Utilidad
        '
        Me.Utilidad.DataPropertyName = "Utilidad"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.Utilidad.DefaultCellStyle = DataGridViewCellStyle7
        Me.Utilidad.HeaderText = "Utilidad"
        Me.Utilidad.Name = "Utilidad"
        Me.Utilidad.ReadOnly = True
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Fecha, Me.CuentaImputableIngresos, Me.ImporteIngresos})
        Me.DataGridView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView2.Location = New System.Drawing.Point(377, 27)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.RowHeadersWidth = 25
        Me.DataGridView2.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.DataGridView2.Size = New System.Drawing.Size(240, 742)
        Me.DataGridView2.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(5, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(364, 20)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Resultados Mensuales"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(377, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(240, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Detalle de Ingresos"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DataGridView3
        '
        Me.DataGridView3.AllowUserToAddRows = False
        Me.DataGridView3.AllowUserToDeleteRows = False
        Me.DataGridView3.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView3.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CuentaImputable, Me.Importe})
        Me.DataGridView3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView3.Location = New System.Drawing.Point(625, 27)
        Me.DataGridView3.Name = "DataGridView3"
        Me.DataGridView3.ReadOnly = True
        Me.DataGridView3.RowHeadersVisible = False
        Me.DataGridView3.RowHeadersWidth = 25
        Me.DataGridView3.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.DataGridView3.Size = New System.Drawing.Size(199, 742)
        Me.DataGridView3.TabIndex = 6
        '
        'DataGridView4
        '
        Me.DataGridView4.AllowUserToAddRows = False
        Me.DataGridView4.AllowUserToDeleteRows = False
        Me.DataGridView4.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView4.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2})
        Me.DataGridView4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView4.Location = New System.Drawing.Point(832, 27)
        Me.DataGridView4.Name = "DataGridView4"
        Me.DataGridView4.ReadOnly = True
        Me.DataGridView4.RowHeadersVisible = False
        Me.DataGridView4.RowHeadersWidth = 25
        Me.DataGridView4.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.DataGridView4.Size = New System.Drawing.Size(199, 742)
        Me.DataGridView4.TabIndex = 7
        '
        'DataGridView5
        '
        Me.DataGridView5.AllowUserToAddRows = False
        Me.DataGridView5.AllowUserToDeleteRows = False
        Me.DataGridView5.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView5.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4})
        Me.DataGridView5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView5.Location = New System.Drawing.Point(1039, 27)
        Me.DataGridView5.Name = "DataGridView5"
        Me.DataGridView5.ReadOnly = True
        Me.DataGridView5.RowHeadersVisible = False
        Me.DataGridView5.RowHeadersWidth = 25
        Me.DataGridView5.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.DataGridView5.Size = New System.Drawing.Size(202, 742)
        Me.DataGridView5.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Location = New System.Drawing.Point(625, 2)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(199, 20)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Detalle de Ganancias"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Location = New System.Drawing.Point(832, 2)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(199, 20)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Detalle de Gastos"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Location = New System.Drawing.Point(1039, 2)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(202, 20)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Detalle de Perdidas"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Fecha
        '
        Me.Fecha.DataPropertyName = "Fecha"
        Me.Fecha.Frozen = True
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        Me.Fecha.Width = 70
        '
        'CuentaImputableIngresos
        '
        Me.CuentaImputableIngresos.DataPropertyName = "CuentaImputable"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.NullValue = Nothing
        Me.CuentaImputableIngresos.DefaultCellStyle = DataGridViewCellStyle8
        Me.CuentaImputableIngresos.Frozen = True
        Me.CuentaImputableIngresos.HeaderText = "Cuenta Imputada"
        Me.CuentaImputableIngresos.Name = "CuentaImputableIngresos"
        Me.CuentaImputableIngresos.ReadOnly = True
        Me.CuentaImputableIngresos.Width = 150
        '
        'ImporteIngresos
        '
        Me.ImporteIngresos.DataPropertyName = "Importe"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "N2"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.ImporteIngresos.DefaultCellStyle = DataGridViewCellStyle9
        Me.ImporteIngresos.Frozen = True
        Me.ImporteIngresos.HeaderText = "Importe"
        Me.ImporteIngresos.Name = "ImporteIngresos"
        Me.ImporteIngresos.ReadOnly = True
        Me.ImporteIngresos.Width = 120
        '
        'CuentaImputable
        '
        Me.CuentaImputable.DataPropertyName = "CuentaImputable"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.CuentaImputable.DefaultCellStyle = DataGridViewCellStyle10
        Me.CuentaImputable.HeaderText = "Cuenta Imputada"
        Me.CuentaImputable.Name = "CuentaImputable"
        Me.CuentaImputable.ReadOnly = True
        Me.CuentaImputable.Width = 190
        '
        'Importe
        '
        Me.Importe.DataPropertyName = "Importe"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Format = "N2"
        DataGridViewCellStyle11.NullValue = Nothing
        Me.Importe.DefaultCellStyle = DataGridViewCellStyle11
        Me.Importe.HeaderText = "Importe"
        Me.Importe.Name = "Importe"
        Me.Importe.ReadOnly = True
        Me.Importe.Width = 90
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "CuentaImputable"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.Format = "N2"
        DataGridViewCellStyle12.NullValue = Nothing
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle12
        Me.DataGridViewTextBoxColumn1.HeaderText = "Cuenta Imputada"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 190
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Importe"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle13.Format = "N2"
        DataGridViewCellStyle13.NullValue = Nothing
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle13
        Me.DataGridViewTextBoxColumn2.HeaderText = "Importe"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 90
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "CuentaImputable"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.Format = "N2"
        DataGridViewCellStyle14.NullValue = Nothing
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle14
        Me.DataGridViewTextBoxColumn3.HeaderText = "Cuenta Imputada"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 190
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Importe"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle15.Format = "N2"
        DataGridViewCellStyle15.NullValue = Nothing
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle15
        Me.DataGridViewTextBoxColumn4.HeaderText = "Importe"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 90
        '
        'FrmResultadosMensuales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1246, 774)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FrmResultadosMensuales"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Estado de resultados Mensuales"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Año As DataGridViewTextBoxColumn
    Friend WithEvents Mes As DataGridViewTextBoxColumn
    Friend WithEvents Ingresos As DataGridViewTextBoxColumn
    Friend WithEvents Ganancias As DataGridViewTextBoxColumn
    Friend WithEvents Gastos As DataGridViewTextBoxColumn
    Friend WithEvents Perdidas As DataGridViewTextBoxColumn
    Friend WithEvents ResultadoMensual As DataGridViewTextBoxColumn
    Friend WithEvents Utilidad As DataGridViewTextBoxColumn
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents DataGridView3 As DataGridView
    Friend WithEvents DataGridView4 As DataGridView
    Friend WithEvents DataGridView5 As DataGridView
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Fecha As DataGridViewTextBoxColumn
    Friend WithEvents CuentaImputableIngresos As DataGridViewTextBoxColumn
    Friend WithEvents ImporteIngresos As DataGridViewTextBoxColumn
    Friend WithEvents CuentaImputable As DataGridViewTextBoxColumn
    Friend WithEvents Importe As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
End Class
