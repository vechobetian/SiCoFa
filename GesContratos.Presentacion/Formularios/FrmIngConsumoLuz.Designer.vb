<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmIngConsumoLuz
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Medidor = New System.Windows.Forms.ComboBox()
        Me.LecturaAnterior = New System.Windows.Forms.TextBox()
        Me.LecturaActual = New System.Windows.Forms.TextBox()
        Me.Consumo = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PUnit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FechaLAc = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.IdRegistro = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Mes = New System.Windows.Forms.MaskedTextBox()
        Me.Año = New System.Windows.Forms.MaskedTextBox()
        Me.Ley3052 = New System.Windows.Forms.TextBox()
        Me.IVA = New System.Windows.Forms.TextBox()
        Me.ImpCalculado = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ImpNeto = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.RG2123 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Guardar = New System.Windows.Forms.Button()
        Me.Borrar = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Medidor
        '
        Me.Medidor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Medidor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Medidor.FormattingEnabled = True
        Me.Medidor.ItemHeight = 13
        Me.Medidor.Location = New System.Drawing.Point(148, 36)
        Me.Medidor.Name = "Medidor"
        Me.Medidor.Size = New System.Drawing.Size(119, 21)
        Me.Medidor.TabIndex = 1
        '
        'LecturaAnterior
        '
        Me.LecturaAnterior.Enabled = False
        Me.LecturaAnterior.Location = New System.Drawing.Point(148, 141)
        Me.LecturaAnterior.Name = "LecturaAnterior"
        Me.LecturaAnterior.Size = New System.Drawing.Size(119, 20)
        Me.LecturaAnterior.TabIndex = 5
        Me.LecturaAnterior.TabStop = False
        '
        'LecturaActual
        '
        Me.LecturaActual.Location = New System.Drawing.Point(148, 169)
        Me.LecturaActual.Name = "LecturaActual"
        Me.LecturaActual.Size = New System.Drawing.Size(119, 20)
        Me.LecturaActual.TabIndex = 6
        Me.LecturaActual.TabStop = False
        '
        'Consumo
        '
        Me.Consumo.Enabled = False
        Me.Consumo.Location = New System.Drawing.Point(392, 37)
        Me.Consumo.Name = "Consumo"
        Me.Consumo.Size = New System.Drawing.Size(119, 20)
        Me.Consumo.TabIndex = 7
        Me.Consumo.TabStop = False
        Me.Consumo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DataGridView1
        '
        Me.DataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Item, Me.Descripcion, Me.Cantidad, Me.PUnit, Me.Importe})
        Me.DataGridView1.Enabled = False
        Me.DataGridView1.Location = New System.Drawing.Point(12, 211)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(500, 240)
        Me.DataGridView1.TabIndex = 7
        Me.DataGridView1.TabStop = False
        '
        'Item
        '
        Me.Item.HeaderText = "Item"
        Me.Item.Name = "Item"
        Me.Item.ReadOnly = True
        Me.Item.Visible = False
        '
        'Descripcion
        '
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Descripcion.Width = 200
        '
        'Cantidad
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.Cantidad.DefaultCellStyle = DataGridViewCellStyle1
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.Width = 60
        '
        'PUnit
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "C4"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.PUnit.DefaultCellStyle = DataGridViewCellStyle2
        Me.PUnit.HeaderText = "PUnit"
        Me.PUnit.Name = "PUnit"
        Me.PUnit.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'Importe
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "C2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.Importe.DefaultCellStyle = DataGridViewCellStyle3
        Me.Importe.HeaderText = "Importe"
        Me.Importe.Name = "Importe"
        Me.Importe.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Importe.Width = 96
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Medidor:"
        '
        'FechaLAc
        '
        Me.FechaLAc.Location = New System.Drawing.Point(148, 63)
        Me.FechaLAc.Mask = "00/00/0000"
        Me.FechaLAc.Name = "FechaLAc"
        Me.FechaLAc.Size = New System.Drawing.Size(119, 20)
        Me.FechaLAc.TabIndex = 2
        Me.FechaLAc.TabStop = False
        Me.FechaLAc.ValidatingType = GetType(Date)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 13)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Fecha Lectura Actual:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 13)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "Período (Mes):"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 118)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 13)
        Me.Label4.TabIndex = 37
        Me.Label4.Text = "Período (Año):"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 144)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(118, 13)
        Me.Label5.TabIndex = 38
        Me.Label5.Text = "Lectura Anterior (KWh):"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 176)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 13)
        Me.Label6.TabIndex = 39
        Me.Label6.Text = "Lectura Actual (KWh):"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(292, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 13)
        Me.Label7.TabIndex = 40
        Me.Label7.Text = "Consumo (KWh):"
        '
        'IdRegistro
        '
        Me.IdRegistro.BackColor = System.Drawing.SystemColors.Window
        Me.IdRegistro.Enabled = False
        Me.IdRegistro.Location = New System.Drawing.Point(148, 10)
        Me.IdRegistro.Name = "IdRegistro"
        Me.IdRegistro.Size = New System.Drawing.Size(119, 20)
        Me.IdRegistro.TabIndex = 0
        Me.IdRegistro.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 13)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 13)
        Me.Label8.TabIndex = 42
        Me.Label8.Text = "IdRegistro:"
        '
        'Mes
        '
        Me.Mes.Location = New System.Drawing.Point(148, 89)
        Me.Mes.Mask = "99"
        Me.Mes.Name = "Mes"
        Me.Mes.Size = New System.Drawing.Size(119, 20)
        Me.Mes.TabIndex = 3
        Me.Mes.TabStop = False
        Me.Mes.ValidatingType = GetType(Integer)
        '
        'Año
        '
        Me.Año.Location = New System.Drawing.Point(148, 115)
        Me.Año.Mask = "99"
        Me.Año.Name = "Año"
        Me.Año.Size = New System.Drawing.Size(119, 20)
        Me.Año.TabIndex = 43
        Me.Año.TabStop = False
        Me.Año.ValidatingType = GetType(Integer)
        '
        'Ley3052
        '
        Me.Ley3052.Enabled = False
        Me.Ley3052.Location = New System.Drawing.Point(392, 89)
        Me.Ley3052.Name = "Ley3052"
        Me.Ley3052.Size = New System.Drawing.Size(119, 20)
        Me.Ley3052.TabIndex = 44
        Me.Ley3052.TabStop = False
        Me.Ley3052.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'IVA
        '
        Me.IVA.Enabled = False
        Me.IVA.Location = New System.Drawing.Point(392, 115)
        Me.IVA.Name = "IVA"
        Me.IVA.Size = New System.Drawing.Size(119, 20)
        Me.IVA.TabIndex = 45
        Me.IVA.TabStop = False
        Me.IVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ImpCalculado
        '
        Me.ImpCalculado.Enabled = False
        Me.ImpCalculado.Location = New System.Drawing.Point(392, 169)
        Me.ImpCalculado.Name = "ImpCalculado"
        Me.ImpCalculado.Size = New System.Drawing.Size(119, 20)
        Me.ImpCalculado.TabIndex = 46
        Me.ImpCalculado.TabStop = False
        Me.ImpCalculado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(293, 92)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 13)
        Me.Label9.TabIndex = 47
        Me.Label9.Text = "Ley 3052:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(292, 118)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(27, 13)
        Me.Label10.TabIndex = 48
        Me.Label10.Text = "IVA:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(294, 172)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(77, 13)
        Me.Label11.TabIndex = 49
        Me.Label11.Text = "Imp.Calculado:"
        '
        'ImpNeto
        '
        Me.ImpNeto.Enabled = False
        Me.ImpNeto.Location = New System.Drawing.Point(392, 63)
        Me.ImpNeto.Name = "ImpNeto"
        Me.ImpNeto.Size = New System.Drawing.Size(119, 20)
        Me.ImpNeto.TabIndex = 50
        Me.ImpNeto.TabStop = False
        Me.ImpNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(293, 66)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(53, 13)
        Me.Label12.TabIndex = 51
        Me.Label12.Text = "Imp.Neto:"
        '
        'RG2123
        '
        Me.RG2123.Enabled = False
        Me.RG2123.Location = New System.Drawing.Point(392, 141)
        Me.RG2123.Name = "RG2123"
        Me.RG2123.Size = New System.Drawing.Size(119, 20)
        Me.RG2123.TabIndex = 52
        Me.RG2123.TabStop = False
        Me.RG2123.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(293, 144)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(78, 13)
        Me.Label13.TabIndex = 53
        Me.Label13.Text = "Res.Gral.2123:"
        '
        'Guardar
        '
        Me.Guardar.Location = New System.Drawing.Point(445, 466)
        Me.Guardar.Name = "Guardar"
        Me.Guardar.Size = New System.Drawing.Size(66, 29)
        Me.Guardar.TabIndex = 54
        Me.Guardar.TabStop = False
        Me.Guardar.Text = "&Guardar"
        Me.Guardar.UseVisualStyleBackColor = True
        '
        'Borrar
        '
        Me.Borrar.Location = New System.Drawing.Point(373, 466)
        Me.Borrar.Name = "Borrar"
        Me.Borrar.Size = New System.Drawing.Size(66, 29)
        Me.Borrar.TabIndex = 55
        Me.Borrar.TabStop = False
        Me.Borrar.Text = "&Borrar"
        Me.Borrar.UseVisualStyleBackColor = True
        '
        'FrmIngConsumoLuz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(523, 511)
        Me.Controls.Add(Me.Borrar)
        Me.Controls.Add(Me.Guardar)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.RG2123)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.ImpNeto)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.ImpCalculado)
        Me.Controls.Add(Me.IVA)
        Me.Controls.Add(Me.Ley3052)
        Me.Controls.Add(Me.Año)
        Me.Controls.Add(Me.Mes)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.IdRegistro)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.FechaLAc)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Consumo)
        Me.Controls.Add(Me.LecturaActual)
        Me.Controls.Add(Me.LecturaAnterior)
        Me.Controls.Add(Me.Medidor)
        Me.Name = "FrmIngConsumoLuz"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registro Consumo Luz por Medidor"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Medidor As ComboBox
    Friend WithEvents LecturaAnterior As TextBox
    Friend WithEvents LecturaActual As TextBox
    Friend WithEvents Consumo As TextBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents FechaLAc As MaskedTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents IdRegistro As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Mes As MaskedTextBox
    Friend WithEvents Año As MaskedTextBox
    Friend WithEvents Ley3052 As TextBox
    Friend WithEvents IVA As TextBox
    Friend WithEvents ImpCalculado As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents ImpNeto As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents RG2123 As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Guardar As Button
    Friend WithEvents Borrar As Button
    Friend WithEvents Item As DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As DataGridViewTextBoxColumn
    Friend WithEvents PUnit As DataGridViewTextBoxColumn
    Friend WithEvents Importe As DataGridViewTextBoxColumn
End Class
