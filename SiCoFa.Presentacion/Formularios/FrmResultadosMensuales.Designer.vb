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
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.00963!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.83788!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.15249!))
        Me.TableLayoutPanel1.Controls.Add(Me.DataGridView1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.DataGridView2, 1, 1)
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
        Me.DataGridView1.Location = New System.Drawing.Point(3, 23)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 25
        Me.DataGridView1.Size = New System.Drawing.Size(343, 591)
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
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Fecha, Me.NOperac, Me.ImpMedioTiket, Me.ImpBto, Me.ImpDes, Me.ImpNeto, Me.ImpEf, Me.ImpCC, Me.ImpPE})
        Me.DataGridView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView2.Location = New System.Drawing.Point(352, 23)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.RowHeadersWidth = 25
        Me.DataGridView2.Size = New System.Drawing.Size(453, 591)
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
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.NOperac.DefaultCellStyle = DataGridViewCellStyle8
        Me.NOperac.Frozen = True
        Me.NOperac.HeaderText = "N°Oper"
        Me.NOperac.Name = "NOperac"
        Me.NOperac.ReadOnly = True
        Me.NOperac.Width = 50
        '
        'ImpMedioTiket
        '
        Me.ImpMedioTiket.DataPropertyName = "ImpMedioTiket"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "N2"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.ImpMedioTiket.DefaultCellStyle = DataGridViewCellStyle9
        Me.ImpMedioTiket.Frozen = True
        Me.ImpMedioTiket.HeaderText = "Imp.Tk"
        Me.ImpMedioTiket.Name = "ImpMedioTiket"
        Me.ImpMedioTiket.ReadOnly = True
        Me.ImpMedioTiket.Width = 70
        '
        'ImpBto
        '
        Me.ImpBto.DataPropertyName = "ImpBto"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.ImpBto.DefaultCellStyle = DataGridViewCellStyle10
        Me.ImpBto.Frozen = True
        Me.ImpBto.HeaderText = "Imp.Bto."
        Me.ImpBto.Name = "ImpBto"
        Me.ImpBto.ReadOnly = True
        Me.ImpBto.Width = 70
        '
        'ImpDes
        '
        Me.ImpDes.DataPropertyName = "ImpDes"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Format = "N2"
        DataGridViewCellStyle11.NullValue = Nothing
        Me.ImpDes.DefaultCellStyle = DataGridViewCellStyle11
        Me.ImpDes.Frozen = True
        Me.ImpDes.HeaderText = "Imp.Des."
        Me.ImpDes.Name = "ImpDes"
        Me.ImpDes.ReadOnly = True
        Me.ImpDes.Width = 70
        '
        'ImpNeto
        '
        Me.ImpNeto.DataPropertyName = "ImpNeto"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.Format = "N2"
        DataGridViewCellStyle12.NullValue = Nothing
        Me.ImpNeto.DefaultCellStyle = DataGridViewCellStyle12
        Me.ImpNeto.Frozen = True
        Me.ImpNeto.HeaderText = "Imp.Neto"
        Me.ImpNeto.Name = "ImpNeto"
        Me.ImpNeto.ReadOnly = True
        Me.ImpNeto.Width = 70
        '
        'ImpEf
        '
        Me.ImpEf.DataPropertyName = "ImpEf"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle13.Format = "N2"
        DataGridViewCellStyle13.NullValue = Nothing
        Me.ImpEf.DefaultCellStyle = DataGridViewCellStyle13
        Me.ImpEf.HeaderText = "Imp.Ef."
        Me.ImpEf.Name = "ImpEf"
        Me.ImpEf.ReadOnly = True
        '
        'ImpCC
        '
        Me.ImpCC.DataPropertyName = "ImpCC"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle14.Format = "N2"
        DataGridViewCellStyle14.NullValue = Nothing
        Me.ImpCC.DefaultCellStyle = DataGridViewCellStyle14
        Me.ImpCC.HeaderText = "Imp.CC."
        Me.ImpCC.Name = "ImpCC"
        Me.ImpCC.ReadOnly = True
        '
        'ImpPE
        '
        Me.ImpPE.DataPropertyName = "ImpPE"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle15.Format = "N2"
        DataGridViewCellStyle15.NullValue = Nothing
        Me.ImpPE.DefaultCellStyle = DataGridViewCellStyle15
        Me.ImpPE.HeaderText = "Imp.PE."
        Me.ImpPE.Name = "ImpPE"
        Me.ImpPE.ReadOnly = True
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
End Class
