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
        Dim DataGridViewCellStyle31 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle32 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle33 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle34 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle35 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle36 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle37 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle38 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle39 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle40 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle41 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle42 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle43 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle44 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle45 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOperac = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImpMedioTiket = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImpBto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImpDes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImpNeto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImpEf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImpCC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImpPE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.00963!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.83788!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.15249!))
        Me.TableLayoutPanel1.Controls.Add(Me.DataGridView1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.DataGridView2, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1246, 617)
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
        Me.DataGridView1.RowHeadersWidth = 25
        Me.DataGridView1.Size = New System.Drawing.Size(340, 585)
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
        DataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Mes.DefaultCellStyle = DataGridViewCellStyle31
        Me.Mes.Frozen = True
        Me.Mes.HeaderText = "Mes"
        Me.Mes.Name = "Mes"
        Me.Mes.ReadOnly = True
        Me.Mes.Width = 50
        '
        'Ingresos
        '
        Me.Ingresos.DataPropertyName = "Ingresos"
        DataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle32.Format = "N2"
        DataGridViewCellStyle32.NullValue = Nothing
        Me.Ingresos.DefaultCellStyle = DataGridViewCellStyle32
        Me.Ingresos.Frozen = True
        Me.Ingresos.HeaderText = "Ingresos"
        Me.Ingresos.Name = "Ingresos"
        Me.Ingresos.ReadOnly = True
        Me.Ingresos.Width = 70
        '
        'Ganancias
        '
        Me.Ganancias.DataPropertyName = "Ganancias"
        DataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle33.Format = "N2"
        DataGridViewCellStyle33.NullValue = Nothing
        Me.Ganancias.DefaultCellStyle = DataGridViewCellStyle33
        Me.Ganancias.Frozen = True
        Me.Ganancias.HeaderText = "Ganancias"
        Me.Ganancias.Name = "Ganancias"
        Me.Ganancias.ReadOnly = True
        Me.Ganancias.Width = 70
        '
        'Gastos
        '
        Me.Gastos.DataPropertyName = "Gastos"
        DataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle34.Format = "N2"
        DataGridViewCellStyle34.NullValue = Nothing
        Me.Gastos.DefaultCellStyle = DataGridViewCellStyle34
        Me.Gastos.Frozen = True
        Me.Gastos.HeaderText = "Gastos"
        Me.Gastos.Name = "Gastos"
        Me.Gastos.ReadOnly = True
        Me.Gastos.Width = 70
        '
        'Perdidas
        '
        Me.Perdidas.DataPropertyName = "Perdidas"
        DataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle35.Format = "N2"
        DataGridViewCellStyle35.NullValue = Nothing
        Me.Perdidas.DefaultCellStyle = DataGridViewCellStyle35
        Me.Perdidas.Frozen = True
        Me.Perdidas.HeaderText = "Perdidas"
        Me.Perdidas.Name = "Perdidas"
        Me.Perdidas.ReadOnly = True
        Me.Perdidas.Width = 70
        '
        'ResultadoMensual
        '
        Me.ResultadoMensual.DataPropertyName = "Resultado"
        DataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle36.Format = "N2"
        DataGridViewCellStyle36.NullValue = Nothing
        Me.ResultadoMensual.DefaultCellStyle = DataGridViewCellStyle36
        Me.ResultadoMensual.HeaderText = "Resultado"
        Me.ResultadoMensual.Name = "ResultadoMensual"
        Me.ResultadoMensual.ReadOnly = True
        '
        'Utilidad
        '
        Me.Utilidad.DataPropertyName = "Utilidad"
        DataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle37.Format = "N2"
        DataGridViewCellStyle37.NullValue = Nothing
        Me.Utilidad.DefaultCellStyle = DataGridViewCellStyle37
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
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Fecha, Me.NOperac, Me.ImpMedioTiket, Me.ImpBto, Me.ImpDes, Me.ImpNeto, Me.ImpEf, Me.ImpCC, Me.ImpPE})
        Me.DataGridView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView2.Location = New System.Drawing.Point(353, 27)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.RowHeadersWidth = 25
        Me.DataGridView2.Size = New System.Drawing.Size(450, 585)
        Me.DataGridView2.TabIndex = 3
        '
        'Fecha
        '
        Me.Fecha.DataPropertyName = "Fecha"
        Me.Fecha.Frozen = True
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        Me.Fecha.Width = 80
        '
        'NOperac
        '
        Me.NOperac.DataPropertyName = "NOperac"
        DataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.NOperac.DefaultCellStyle = DataGridViewCellStyle38
        Me.NOperac.Frozen = True
        Me.NOperac.HeaderText = "N°Oper"
        Me.NOperac.Name = "NOperac"
        Me.NOperac.ReadOnly = True
        Me.NOperac.Width = 50
        '
        'ImpMedioTiket
        '
        Me.ImpMedioTiket.DataPropertyName = "ImpMedioTiket"
        DataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle39.Format = "N2"
        DataGridViewCellStyle39.NullValue = Nothing
        Me.ImpMedioTiket.DefaultCellStyle = DataGridViewCellStyle39
        Me.ImpMedioTiket.Frozen = True
        Me.ImpMedioTiket.HeaderText = "Imp.Tk"
        Me.ImpMedioTiket.Name = "ImpMedioTiket"
        Me.ImpMedioTiket.ReadOnly = True
        Me.ImpMedioTiket.Width = 70
        '
        'ImpBto
        '
        Me.ImpBto.DataPropertyName = "ImpBto"
        DataGridViewCellStyle40.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle40.Format = "N2"
        DataGridViewCellStyle40.NullValue = Nothing
        Me.ImpBto.DefaultCellStyle = DataGridViewCellStyle40
        Me.ImpBto.Frozen = True
        Me.ImpBto.HeaderText = "Imp.Bto."
        Me.ImpBto.Name = "ImpBto"
        Me.ImpBto.ReadOnly = True
        Me.ImpBto.Width = 70
        '
        'ImpDes
        '
        Me.ImpDes.DataPropertyName = "ImpDes"
        DataGridViewCellStyle41.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle41.Format = "N2"
        DataGridViewCellStyle41.NullValue = Nothing
        Me.ImpDes.DefaultCellStyle = DataGridViewCellStyle41
        Me.ImpDes.Frozen = True
        Me.ImpDes.HeaderText = "Imp.Des."
        Me.ImpDes.Name = "ImpDes"
        Me.ImpDes.ReadOnly = True
        Me.ImpDes.Width = 70
        '
        'ImpNeto
        '
        Me.ImpNeto.DataPropertyName = "ImpNeto"
        DataGridViewCellStyle42.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle42.Format = "N2"
        DataGridViewCellStyle42.NullValue = Nothing
        Me.ImpNeto.DefaultCellStyle = DataGridViewCellStyle42
        Me.ImpNeto.Frozen = True
        Me.ImpNeto.HeaderText = "Imp.Neto"
        Me.ImpNeto.Name = "ImpNeto"
        Me.ImpNeto.ReadOnly = True
        Me.ImpNeto.Width = 70
        '
        'ImpEf
        '
        Me.ImpEf.DataPropertyName = "ImpEf"
        DataGridViewCellStyle43.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle43.Format = "N2"
        DataGridViewCellStyle43.NullValue = Nothing
        Me.ImpEf.DefaultCellStyle = DataGridViewCellStyle43
        Me.ImpEf.HeaderText = "Imp.Ef."
        Me.ImpEf.Name = "ImpEf"
        Me.ImpEf.ReadOnly = True
        '
        'ImpCC
        '
        Me.ImpCC.DataPropertyName = "ImpCC"
        DataGridViewCellStyle44.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle44.Format = "N2"
        DataGridViewCellStyle44.NullValue = Nothing
        Me.ImpCC.DefaultCellStyle = DataGridViewCellStyle44
        Me.ImpCC.HeaderText = "Imp.CC."
        Me.ImpCC.Name = "ImpCC"
        Me.ImpCC.ReadOnly = True
        '
        'ImpPE
        '
        Me.ImpPE.DataPropertyName = "ImpPE"
        DataGridViewCellStyle45.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle45.Format = "N2"
        DataGridViewCellStyle45.NullValue = Nothing
        Me.ImpPE.DefaultCellStyle = DataGridViewCellStyle45
        Me.ImpPE.HeaderText = "Imp.PE."
        Me.ImpPE.Name = "ImpPE"
        Me.ImpPE.ReadOnly = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(5, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(340, 20)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Resultados Mensuales"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(353, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(450, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Ingresos"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmResultadosMensuales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1246, 617)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FrmResultadosMensuales"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Estado de resultados Mensuales"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Fecha As DataGridViewTextBoxColumn
    Friend WithEvents NOperac As DataGridViewTextBoxColumn
    Friend WithEvents ImpMedioTiket As DataGridViewTextBoxColumn
    Friend WithEvents ImpBto As DataGridViewTextBoxColumn
    Friend WithEvents ImpDes As DataGridViewTextBoxColumn
    Friend WithEvents ImpNeto As DataGridViewTextBoxColumn
    Friend WithEvents ImpEf As DataGridViewTextBoxColumn
    Friend WithEvents ImpCC As DataGridViewTextBoxColumn
    Friend WithEvents ImpPE As DataGridViewTextBoxColumn
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
