<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmComprobantes
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.IdOperacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaComp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PVenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumComp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Locador = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CompAsoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImpBto = New System.Windows.Forms.TextBox()
        Me.ImpEf = New System.Windows.Forms.TextBox()
        Me.ImpCC = New System.Windows.Forms.TextBox()
        Me.ImpCB = New System.Windows.Forms.TextBox()
        Me.ImpTar = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PUnit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImprimirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarComoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnviarMailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NotaDeCréditoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RecuperarComprobanteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataGridView3 = New System.Windows.Forms.DataGridView()
        Me.btnExpandir = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.IdPago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImpPagado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImpAplicado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImpNoAplicado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EstadoPago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip2.SuspendLayout()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdOperacion, Me.FechaComp, Me.TipoComprobante, Me.PVenta, Me.NumComp, Me.Locador, Me.Cliente, Me.CompAsoc})
        Me.DataGridView1.Location = New System.Drawing.Point(0, 27)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1004, 422)
        Me.DataGridView1.TabIndex = 0
        '
        'IdOperacion
        '
        Me.IdOperacion.HeaderText = "IdOperacion"
        Me.IdOperacion.Name = "IdOperacion"
        Me.IdOperacion.ReadOnly = True
        Me.IdOperacion.Width = 70
        '
        'FechaComp
        '
        DataGridViewCellStyle1.Format = "d"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.FechaComp.DefaultCellStyle = DataGridViewCellStyle1
        Me.FechaComp.HeaderText = "Fecha Comp."
        Me.FechaComp.Name = "FechaComp"
        Me.FechaComp.ReadOnly = True
        '
        'TipoComprobante
        '
        Me.TipoComprobante.HeaderText = "Tipo Comp"
        Me.TipoComprobante.Name = "TipoComprobante"
        Me.TipoComprobante.ReadOnly = True
        '
        'PVenta
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.PVenta.DefaultCellStyle = DataGridViewCellStyle2
        Me.PVenta.HeaderText = "P.Venta"
        Me.PVenta.Name = "PVenta"
        Me.PVenta.ReadOnly = True
        Me.PVenta.Width = 50
        '
        'NumComp
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.NumComp.DefaultCellStyle = DataGridViewCellStyle3
        Me.NumComp.HeaderText = "Num.Comp."
        Me.NumComp.Name = "NumComp"
        Me.NumComp.ReadOnly = True
        Me.NumComp.Width = 70
        '
        'Locador
        '
        Me.Locador.HeaderText = "Locador"
        Me.Locador.Name = "Locador"
        Me.Locador.ReadOnly = True
        Me.Locador.Width = 200
        '
        'Cliente
        '
        Me.Cliente.HeaderText = "Cliente"
        Me.Cliente.Name = "Cliente"
        Me.Cliente.ReadOnly = True
        Me.Cliente.Width = 200
        '
        'CompAsoc
        '
        Me.CompAsoc.HeaderText = "Comp.Asoc."
        Me.CompAsoc.Name = "CompAsoc"
        Me.CompAsoc.ReadOnly = True
        Me.CompAsoc.Width = 150
        '
        'ImpBto
        '
        Me.ImpBto.Location = New System.Drawing.Point(885, 487)
        Me.ImpBto.Name = "ImpBto"
        Me.ImpBto.ReadOnly = True
        Me.ImpBto.Size = New System.Drawing.Size(100, 20)
        Me.ImpBto.TabIndex = 1
        Me.ImpBto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ImpEf
        '
        Me.ImpEf.Location = New System.Drawing.Point(885, 513)
        Me.ImpEf.Name = "ImpEf"
        Me.ImpEf.ReadOnly = True
        Me.ImpEf.Size = New System.Drawing.Size(100, 20)
        Me.ImpEf.TabIndex = 2
        Me.ImpEf.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ImpCC
        '
        Me.ImpCC.Location = New System.Drawing.Point(885, 539)
        Me.ImpCC.Name = "ImpCC"
        Me.ImpCC.ReadOnly = True
        Me.ImpCC.Size = New System.Drawing.Size(100, 20)
        Me.ImpCC.TabIndex = 3
        Me.ImpCC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ImpCB
        '
        Me.ImpCB.Location = New System.Drawing.Point(885, 565)
        Me.ImpCB.Name = "ImpCB"
        Me.ImpCB.ReadOnly = True
        Me.ImpCB.Size = New System.Drawing.Size(100, 20)
        Me.ImpCB.TabIndex = 4
        Me.ImpCB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ImpTar
        '
        Me.ImpTar.Location = New System.Drawing.Point(885, 591)
        Me.ImpTar.Name = "ImpTar"
        Me.ImpTar.ReadOnly = True
        Me.ImpTar.Size = New System.Drawing.Size(100, 20)
        Me.ImpTar.TabIndex = 5
        Me.ImpTar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(777, 490)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Importe Bruto:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(777, 516)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Importe Efectivo:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(777, 542)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Importe Cta.Cte:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(777, 568)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Importe Trans.Elec :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(777, 594)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Importe Tarjeta:"
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.AllowUserToResizeColumns = False
        Me.DataGridView2.AllowUserToResizeRows = False
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Descripcion, Me.Cantidad, Me.PUnit, Me.Importe})
        Me.DataGridView2.Location = New System.Drawing.Point(0, 452)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.Size = New System.Drawing.Size(664, 159)
        Me.DataGridView2.TabIndex = 11
        '
        'Descripcion
        '
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.Width = 300
        '
        'Cantidad
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Cantidad.DefaultCellStyle = DataGridViewCellStyle4
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.ReadOnly = True
        Me.Cantidad.Width = 80
        '
        'PUnit
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.PUnit.DefaultCellStyle = DataGridViewCellStyle5
        Me.PUnit.HeaderText = "Prec.Unit."
        Me.PUnit.Name = "PUnit"
        Me.PUnit.ReadOnly = True
        Me.PUnit.Width = 120
        '
        'Importe
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.Importe.DefaultCellStyle = DataGridViewCellStyle6
        Me.Importe.HeaderText = "Importe"
        Me.Importe.Name = "Importe"
        Me.Importe.ReadOnly = True
        Me.Importe.Width = 120
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 24)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1004, 24)
        Me.MenuStrip1.TabIndex = 12
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.NotaDeCréditoToolStripMenuItem, Me.RecuperarComprobanteToolStripMenuItem})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(1004, 24)
        Me.MenuStrip2.TabIndex = 13
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'ArchivoToolStripMenuItem
        '
        Me.ArchivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImprimirToolStripMenuItem, Me.GuardarComoToolStripMenuItem, Me.EnviarMailToolStripMenuItem})
        Me.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
        Me.ArchivoToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.ArchivoToolStripMenuItem.Text = "&Archivo"
        '
        'ImprimirToolStripMenuItem
        '
        Me.ImprimirToolStripMenuItem.Name = "ImprimirToolStripMenuItem"
        Me.ImprimirToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ImprimirToolStripMenuItem.Text = "&Imprimir"
        '
        'GuardarComoToolStripMenuItem
        '
        Me.GuardarComoToolStripMenuItem.Name = "GuardarComoToolStripMenuItem"
        Me.GuardarComoToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.GuardarComoToolStripMenuItem.Text = "&Guardar Como"
        '
        'EnviarMailToolStripMenuItem
        '
        Me.EnviarMailToolStripMenuItem.Name = "EnviarMailToolStripMenuItem"
        Me.EnviarMailToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.EnviarMailToolStripMenuItem.Text = "&Enviar Mail"
        '
        'NotaDeCréditoToolStripMenuItem
        '
        Me.NotaDeCréditoToolStripMenuItem.Name = "NotaDeCréditoToolStripMenuItem"
        Me.NotaDeCréditoToolStripMenuItem.Size = New System.Drawing.Size(103, 20)
        Me.NotaDeCréditoToolStripMenuItem.Text = "&Nota de Crédito"
        '
        'RecuperarComprobanteToolStripMenuItem
        '
        Me.RecuperarComprobanteToolStripMenuItem.Name = "RecuperarComprobanteToolStripMenuItem"
        Me.RecuperarComprobanteToolStripMenuItem.Size = New System.Drawing.Size(149, 20)
        Me.RecuperarComprobanteToolStripMenuItem.Text = "&Recuperar Comprobante"
        '
        'DataGridView3
        '
        Me.DataGridView3.AllowUserToAddRows = False
        Me.DataGridView3.AllowUserToDeleteRows = False
        Me.DataGridView3.AllowUserToResizeColumns = False
        Me.DataGridView3.AllowUserToResizeRows = False
        Me.DataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView3.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.btnExpandir, Me.IdPago, Me.ImpPagado, Me.ImpAplicado, Me.ImpNoAplicado, Me.EstadoPago})
        Me.DataGridView3.Location = New System.Drawing.Point(0, 452)
        Me.DataGridView3.Name = "DataGridView3"
        Me.DataGridView3.RowHeadersVisible = False
        Me.DataGridView3.Size = New System.Drawing.Size(639, 159)
        Me.DataGridView3.TabIndex = 14
        '
        'btnExpandir
        '
        Me.btnExpandir.HeaderText = ""
        Me.btnExpandir.Name = "btnExpandir"
        Me.btnExpandir.Text = "+"
        Me.btnExpandir.UseColumnTextForButtonValue = True
        Me.btnExpandir.Width = 24
        '
        'IdPago
        '
        Me.IdPago.DataPropertyName = "IdPago"
        Me.IdPago.HeaderText = "IdPago"
        Me.IdPago.Name = "IdPago"
        '
        'ImpPagado
        '
        Me.ImpPagado.DataPropertyName = "ImpPagado"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.ImpPagado.DefaultCellStyle = DataGridViewCellStyle7
        Me.ImpPagado.HeaderText = "Imp.Pagado"
        Me.ImpPagado.Name = "ImpPagado"
        Me.ImpPagado.Width = 120
        '
        'ImpAplicado
        '
        Me.ImpAplicado.DataPropertyName = "ImpAplicado"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.ImpAplicado.DefaultCellStyle = DataGridViewCellStyle8
        Me.ImpAplicado.HeaderText = "Imp.Aplicado"
        Me.ImpAplicado.Name = "ImpAplicado"
        Me.ImpAplicado.Width = 120
        '
        'ImpNoAplicado
        '
        Me.ImpNoAplicado.DataPropertyName = "ImpNoAplicado"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "N2"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.ImpNoAplicado.DefaultCellStyle = DataGridViewCellStyle9
        Me.ImpNoAplicado.HeaderText = "Imp.No Aplicado"
        Me.ImpNoAplicado.Name = "ImpNoAplicado"
        Me.ImpNoAplicado.Width = 120
        '
        'EstadoPago
        '
        Me.EstadoPago.DataPropertyName = "EstadoPago"
        Me.EstadoPago.HeaderText = "Estado Pago"
        Me.EstadoPago.Name = "EstadoPago"
        Me.EstadoPago.Width = 150
        '
        'FrmComprobantes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1004, 613)
        Me.Controls.Add(Me.DataGridView3)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ImpTar)
        Me.Controls.Add(Me.ImpCB)
        Me.Controls.Add(Me.ImpCC)
        Me.Controls.Add(Me.ImpEf)
        Me.Controls.Add(Me.ImpBto)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.MenuStrip2)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FrmComprobantes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Comprobantes"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents ImpBto As TextBox
    Friend WithEvents ImpEf As TextBox
    Friend WithEvents ImpCC As TextBox
    Friend WithEvents ImpCB As TextBox
    Friend WithEvents ImpTar As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents Descripcion As DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As DataGridViewTextBoxColumn
    Friend WithEvents PUnit As DataGridViewTextBoxColumn
    Friend WithEvents Importe As DataGridViewTextBoxColumn
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents MenuStrip2 As MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImprimirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GuardarComoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EnviarMailToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NotaDeCréditoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RecuperarComprobanteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DataGridView3 As DataGridView
    Friend WithEvents btnExpandir As DataGridViewButtonColumn
    Friend WithEvents IdPago As DataGridViewTextBoxColumn
    Friend WithEvents ImpPagado As DataGridViewTextBoxColumn
    Friend WithEvents ImpAplicado As DataGridViewTextBoxColumn
    Friend WithEvents ImpNoAplicado As DataGridViewTextBoxColumn
    Friend WithEvents EstadoPago As DataGridViewTextBoxColumn
    Friend WithEvents IdOperacion As DataGridViewTextBoxColumn
    Friend WithEvents FechaComp As DataGridViewTextBoxColumn
    Friend WithEvents TipoComprobante As DataGridViewTextBoxColumn
    Friend WithEvents PVenta As DataGridViewTextBoxColumn
    Friend WithEvents NumComp As DataGridViewTextBoxColumn
    Friend WithEvents Locador As DataGridViewTextBoxColumn
    Friend WithEvents Cliente As DataGridViewTextBoxColumn
    Friend WithEvents CompAsoc As DataGridViewTextBoxColumn
End Class
