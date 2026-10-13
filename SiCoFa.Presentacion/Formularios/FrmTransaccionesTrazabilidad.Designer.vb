<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTransaccionesTrazabilidad
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvTransacciones = New System.Windows.Forms.DataGridView()
        Me.IdTransaccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaEvento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescripcionEvento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GlnOrigen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RazonSocialOrigen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Comprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdUsuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Gtin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Serie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lote = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Vencimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvTransacciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvTransacciones
        '
        Me.dgvTransacciones.AllowUserToAddRows = False
        Me.dgvTransacciones.AllowUserToDeleteRows = False
        Me.dgvTransacciones.AllowUserToResizeColumns = False
        Me.dgvTransacciones.AllowUserToResizeRows = False
        Me.dgvTransacciones.BackgroundColor = System.Drawing.Color.White
        Me.dgvTransacciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTransacciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdTransaccion, Me.FechaEvento, Me.DescripcionEvento, Me.GlnOrigen, Me.RazonSocialOrigen, Me.Comprobante, Me.IdUsuario, Me.Nombre, Me.Gtin, Me.Serie, Me.Lote, Me.Vencimiento, Me.Estado})
        Me.dgvTransacciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvTransacciones.Location = New System.Drawing.Point(0, 0)
        Me.dgvTransacciones.Name = "dgvTransacciones"
        Me.dgvTransacciones.ReadOnly = True
        Me.dgvTransacciones.RowHeadersVisible = False
        Me.dgvTransacciones.RowHeadersWidth = 20
        Me.dgvTransacciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTransacciones.Size = New System.Drawing.Size(800, 450)
        Me.dgvTransacciones.TabIndex = 4
        Me.dgvTransacciones.TabStop = False
        '
        'IdTransaccion
        '
        Me.IdTransaccion.DataPropertyName = "IdTransaccion"
        Me.IdTransaccion.HeaderText = "IdTransaccion"
        Me.IdTransaccion.Name = "IdTransaccion"
        Me.IdTransaccion.ReadOnly = True
        Me.IdTransaccion.Width = 80
        '
        'FechaEvento
        '
        Me.FechaEvento.DataPropertyName = "FechaEvento"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.FechaEvento.DefaultCellStyle = DataGridViewCellStyle1
        Me.FechaEvento.HeaderText = "Fecha Evento"
        Me.FechaEvento.Name = "FechaEvento"
        Me.FechaEvento.ReadOnly = True
        '
        'DescripcionEvento
        '
        Me.DescripcionEvento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DescripcionEvento.DataPropertyName = "DescripcionEvento"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        Me.DescripcionEvento.DefaultCellStyle = DataGridViewCellStyle2
        Me.DescripcionEvento.HeaderText = "Evento"
        Me.DescripcionEvento.Name = "DescripcionEvento"
        Me.DescripcionEvento.ReadOnly = True
        '
        'GlnOrigen
        '
        Me.GlnOrigen.DataPropertyName = "GlnOrigen"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.GlnOrigen.DefaultCellStyle = DataGridViewCellStyle3
        Me.GlnOrigen.HeaderText = "GlnOrigen"
        Me.GlnOrigen.Name = "GlnOrigen"
        Me.GlnOrigen.ReadOnly = True
        '
        'RazonSocialOrigen
        '
        Me.RazonSocialOrigen.DataPropertyName = "RazonSocialOrigen"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        Me.RazonSocialOrigen.DefaultCellStyle = DataGridViewCellStyle4
        Me.RazonSocialOrigen.HeaderText = "Razon Social Origen"
        Me.RazonSocialOrigen.Name = "RazonSocialOrigen"
        Me.RazonSocialOrigen.ReadOnly = True
        Me.RazonSocialOrigen.Width = 200
        '
        'Comprobante
        '
        Me.Comprobante.DataPropertyName = "Comprobante"
        Me.Comprobante.HeaderText = "Comprobante"
        Me.Comprobante.Name = "Comprobante"
        Me.Comprobante.ReadOnly = True
        '
        'IdUsuario
        '
        Me.IdUsuario.DataPropertyName = "IdUsuario"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.IdUsuario.DefaultCellStyle = DataGridViewCellStyle5
        Me.IdUsuario.HeaderText = "IdUsuario"
        Me.IdUsuario.Name = "IdUsuario"
        Me.IdUsuario.ReadOnly = True
        Me.IdUsuario.Width = 55
        '
        'Nombre
        '
        Me.Nombre.DataPropertyName = "Nombre"
        Me.Nombre.HeaderText = "Articulo"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.ReadOnly = True
        Me.Nombre.Width = 250
        '
        'Gtin
        '
        Me.Gtin.DataPropertyName = "Gtin"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Gtin.DefaultCellStyle = DataGridViewCellStyle6
        Me.Gtin.HeaderText = "Gtin"
        Me.Gtin.Name = "Gtin"
        Me.Gtin.ReadOnly = True
        '
        'Serie
        '
        Me.Serie.DataPropertyName = "Serie"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Serie.DefaultCellStyle = DataGridViewCellStyle7
        Me.Serie.HeaderText = "Serie"
        Me.Serie.Name = "Serie"
        Me.Serie.ReadOnly = True
        Me.Serie.Width = 150
        '
        'Lote
        '
        Me.Lote.DataPropertyName = "Lote"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Lote.DefaultCellStyle = DataGridViewCellStyle8
        Me.Lote.HeaderText = "Lote"
        Me.Lote.Name = "Lote"
        Me.Lote.ReadOnly = True
        Me.Lote.Width = 120
        '
        'Vencimiento
        '
        Me.Vencimiento.DataPropertyName = "Vencimiento"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Vencimiento.DefaultCellStyle = DataGridViewCellStyle9
        Me.Vencimiento.HeaderText = "Vencimiento"
        Me.Vencimiento.Name = "Vencimiento"
        Me.Vencimiento.ReadOnly = True
        '
        'Estado
        '
        Me.Estado.DataPropertyName = "Estado"
        Me.Estado.HeaderText = "Estado"
        Me.Estado.Name = "Estado"
        Me.Estado.ReadOnly = True
        '
        'FrmTransaccionesTrazabilidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.dgvTransacciones)
        Me.Name = "FrmTransaccionesTrazabilidad"
        Me.Text = "FrmTransaccionesTrazabilidad"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvTransacciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvTransacciones As DataGridView
    Friend WithEvents IdTransaccion As DataGridViewTextBoxColumn
    Friend WithEvents FechaEvento As DataGridViewTextBoxColumn
    Friend WithEvents DescripcionEvento As DataGridViewTextBoxColumn
    Friend WithEvents GlnOrigen As DataGridViewTextBoxColumn
    Friend WithEvents RazonSocialOrigen As DataGridViewTextBoxColumn
    Friend WithEvents Comprobante As DataGridViewTextBoxColumn
    Friend WithEvents IdUsuario As DataGridViewTextBoxColumn
    Friend WithEvents Nombre As DataGridViewTextBoxColumn
    Friend WithEvents Gtin As DataGridViewTextBoxColumn
    Friend WithEvents Serie As DataGridViewTextBoxColumn
    Friend WithEvents Lote As DataGridViewTextBoxColumn
    Friend WithEvents Vencimiento As DataGridViewTextBoxColumn
    Friend WithEvents Estado As DataGridViewTextBoxColumn
End Class
