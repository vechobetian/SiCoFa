<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmComprobantesEmitidos
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
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.IdOperacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodiTC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdOperAsoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaComp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PVenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumComp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImpBto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImpDes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImpEf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImpCC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImpPE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ComprobanteAsociado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdOperacion, Me.CodiTC, Me.IdOperAsoc, Me.TipoComprobante, Me.FechaComp, Me.PVenta, Me.NumComp, Me.ImpBto, Me.ImpDes, Me.ImpEf, Me.ImpCC, Me.ImpPE, Me.ComprobanteAsociado})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1211, 450)
        Me.DataGridView1.TabIndex = 0
        '
        'IdOperacion
        '
        Me.IdOperacion.DataPropertyName = "IdOperacion"
        Me.IdOperacion.HeaderText = "IdOperacion"
        Me.IdOperacion.Name = "IdOperacion"
        Me.IdOperacion.Visible = False
        '
        'CodiTC
        '
        Me.CodiTC.DataPropertyName = "CodiTC"
        Me.CodiTC.HeaderText = "CodiTC"
        Me.CodiTC.Name = "CodiTC"
        Me.CodiTC.Visible = False
        '
        'IdOperAsoc
        '
        Me.IdOperAsoc.DataPropertyName = "IdOperAsoc"
        Me.IdOperAsoc.HeaderText = "IdOperAsoc"
        Me.IdOperAsoc.Name = "IdOperAsoc"
        Me.IdOperAsoc.Visible = False
        '
        'TipoComprobante
        '
        Me.TipoComprobante.DataPropertyName = "TipoComprobante"
        Me.TipoComprobante.HeaderText = "Comprobante"
        Me.TipoComprobante.Name = "TipoComprobante"
        '
        'FechaComp
        '
        Me.FechaComp.DataPropertyName = "FechaComp"
        Me.FechaComp.HeaderText = "Fecha"
        Me.FechaComp.Name = "FechaComp"
        '
        'PVenta
        '
        Me.PVenta.DataPropertyName = "PVenta"
        Me.PVenta.HeaderText = "P.Venta"
        Me.PVenta.Name = "PVenta"
        '
        'NumComp
        '
        Me.NumComp.DataPropertyName = "NumComp"
        Me.NumComp.HeaderText = "Num.Comp."
        Me.NumComp.Name = "NumComp"
        '
        'ImpBto
        '
        Me.ImpBto.DataPropertyName = "ImpBto"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Format = "N2"
        DataGridViewCellStyle11.NullValue = Nothing
        Me.ImpBto.DefaultCellStyle = DataGridViewCellStyle11
        Me.ImpBto.HeaderText = "Importe"
        Me.ImpBto.Name = "ImpBto"
        Me.ImpBto.ReadOnly = True
        '
        'ImpDes
        '
        Me.ImpDes.DataPropertyName = "ImpDes"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.Format = "N2"
        DataGridViewCellStyle12.NullValue = Nothing
        Me.ImpDes.DefaultCellStyle = DataGridViewCellStyle12
        Me.ImpDes.HeaderText = "Descuento"
        Me.ImpDes.Name = "ImpDes"
        Me.ImpDes.ReadOnly = True
        '
        'ImpEf
        '
        Me.ImpEf.DataPropertyName = "ImpEf"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle13.Format = "N2"
        DataGridViewCellStyle13.NullValue = Nothing
        Me.ImpEf.DefaultCellStyle = DataGridViewCellStyle13
        Me.ImpEf.HeaderText = "Efectivo"
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
        Me.ImpCC.HeaderText = "Cta. Cte."
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
        Me.ImpPE.HeaderText = "Pago Electronico"
        Me.ImpPE.Name = "ImpPE"
        Me.ImpPE.ReadOnly = True
        '
        'ComprobanteAsociado
        '
        Me.ComprobanteAsociado.DataPropertyName = "ComprobanteAsociado"
        Me.ComprobanteAsociado.HeaderText = "Comp. Asociado"
        Me.ComprobanteAsociado.Name = "ComprobanteAsociado"
        '
        'FrmComprobantes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1211, 450)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "FrmComprobantes"
        Me.Text = "FrmComprobantes"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents IdOperacion As DataGridViewTextBoxColumn
    Friend WithEvents CodiTC As DataGridViewTextBoxColumn
    Friend WithEvents IdOperAsoc As DataGridViewTextBoxColumn
    Friend WithEvents TipoComprobante As DataGridViewTextBoxColumn
    Friend WithEvents FechaComp As DataGridViewTextBoxColumn
    Friend WithEvents PVenta As DataGridViewTextBoxColumn
    Friend WithEvents NumComp As DataGridViewTextBoxColumn
    Friend WithEvents ImpBto As DataGridViewTextBoxColumn
    Friend WithEvents ImpDes As DataGridViewTextBoxColumn
    Friend WithEvents ImpEf As DataGridViewTextBoxColumn
    Friend WithEvents ImpCC As DataGridViewTextBoxColumn
    Friend WithEvents ImpPE As DataGridViewTextBoxColumn
    Friend WithEvents ComprobanteAsociado As DataGridViewTextBoxColumn
End Class
