<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBuscaVentasIniciadas
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
        Me.dgvItemsOperacion = New System.Windows.Forms.DataGridView()
        Me.IdItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioUnitario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvOperacionesIniciadas = New System.Windows.Forms.DataGridView()
        Me.IdOperacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Inicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvItemsOperacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvOperacionesIniciadas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvItemsOperacion
        '
        Me.dgvItemsOperacion.AllowUserToAddRows = False
        Me.dgvItemsOperacion.AllowUserToDeleteRows = False
        Me.dgvItemsOperacion.AllowUserToResizeColumns = False
        Me.dgvItemsOperacion.AllowUserToResizeRows = False
        Me.dgvItemsOperacion.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvItemsOperacion.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvItemsOperacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvItemsOperacion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdItem, Me.Descripcion, Me.Cantidad, Me.PrecioUnitario, Me.Importe})
        Me.dgvItemsOperacion.Dock = System.Windows.Forms.DockStyle.Right
        Me.dgvItemsOperacion.Location = New System.Drawing.Point(460, 0)
        Me.dgvItemsOperacion.Name = "dgvItemsOperacion"
        Me.dgvItemsOperacion.RowHeadersVisible = False
        Me.dgvItemsOperacion.RowHeadersWidth = 20
        Me.dgvItemsOperacion.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.dgvItemsOperacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvItemsOperacion.Size = New System.Drawing.Size(626, 532)
        Me.dgvItemsOperacion.TabIndex = 4
        Me.dgvItemsOperacion.TabStop = False
        '
        'IdItem
        '
        Me.IdItem.DataPropertyName = "IdItem"
        Me.IdItem.HeaderText = "IdItem"
        Me.IdItem.Name = "IdItem"
        Me.IdItem.Visible = False
        Me.IdItem.Width = 70
        '
        'Descripcion
        '
        Me.Descripcion.DataPropertyName = "Descripcion"
        Me.Descripcion.FillWeight = 100.9181!
        Me.Descripcion.HeaderText = "Articulo"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.Width = 300
        '
        'Cantidad
        '
        Me.Cantidad.DataPropertyName = "Cantidad"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.Cantidad.DefaultCellStyle = DataGridViewCellStyle2
        Me.Cantidad.FillWeight = 451.7766!
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.Width = 80
        '
        'PrecioUnitario
        '
        Me.PrecioUnitario.DataPropertyName = "PrecioUnitario"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.PrecioUnitario.DefaultCellStyle = DataGridViewCellStyle3
        Me.PrecioUnitario.FillWeight = 41.8108!
        Me.PrecioUnitario.HeaderText = "Precio Unitario"
        Me.PrecioUnitario.Name = "PrecioUnitario"
        Me.PrecioUnitario.ReadOnly = True
        Me.PrecioUnitario.Width = 120
        '
        'Importe
        '
        Me.Importe.DataPropertyName = "Importe"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.Importe.DefaultCellStyle = DataGridViewCellStyle4
        Me.Importe.FillWeight = 24.36422!
        Me.Importe.HeaderText = "Importe"
        Me.Importe.Name = "Importe"
        Me.Importe.ReadOnly = True
        Me.Importe.Width = 120
        '
        'dgvOperacionesIniciadas
        '
        Me.dgvOperacionesIniciadas.AllowUserToAddRows = False
        Me.dgvOperacionesIniciadas.AllowUserToResizeColumns = False
        Me.dgvOperacionesIniciadas.AllowUserToResizeRows = False
        Me.dgvOperacionesIniciadas.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOperacionesIniciadas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvOperacionesIniciadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOperacionesIniciadas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdOperacion, Me.Inicio, Me.Cliente})
        Me.dgvOperacionesIniciadas.Dock = System.Windows.Forms.DockStyle.Left
        Me.dgvOperacionesIniciadas.Location = New System.Drawing.Point(0, 0)
        Me.dgvOperacionesIniciadas.Name = "dgvOperacionesIniciadas"
        Me.dgvOperacionesIniciadas.RowHeadersWidth = 20
        Me.dgvOperacionesIniciadas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvOperacionesIniciadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvOperacionesIniciadas.Size = New System.Drawing.Size(459, 532)
        Me.dgvOperacionesIniciadas.TabIndex = 5
        '
        'IdOperacion
        '
        Me.IdOperacion.DataPropertyName = "IdOperacion"
        Me.IdOperacion.HeaderText = "IdOperacion"
        Me.IdOperacion.Name = "IdOperacion"
        Me.IdOperacion.Visible = False
        Me.IdOperacion.Width = 70
        '
        'Inicio
        '
        Me.Inicio.DataPropertyName = "Inicio"
        Me.Inicio.FillWeight = 60.75637!
        Me.Inicio.HeaderText = "Fecha"
        Me.Inicio.Name = "Inicio"
        Me.Inicio.ReadOnly = True
        Me.Inicio.Width = 135
        '
        'Cliente
        '
        Me.Cliente.DataPropertyName = "Nombre"
        Me.Cliente.FillWeight = 100.9181!
        Me.Cliente.HeaderText = "Cliente"
        Me.Cliente.Name = "Cliente"
        Me.Cliente.ReadOnly = True
        Me.Cliente.Width = 300
        '
        'FrmBuscaVentasIniciadas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1086, 532)
        Me.ControlBox = False
        Me.Controls.Add(Me.dgvOperacionesIniciadas)
        Me.Controls.Add(Me.dgvItemsOperacion)
        Me.Name = "FrmBuscaVentasIniciadas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmBuscaVentasIniciadas"
        CType(Me.dgvItemsOperacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvOperacionesIniciadas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvItemsOperacion As DataGridView
    Friend WithEvents dgvOperacionesIniciadas As DataGridView
    Friend WithEvents IdOperacion As DataGridViewTextBoxColumn
    Friend WithEvents Inicio As DataGridViewTextBoxColumn
    Friend WithEvents Cliente As DataGridViewTextBoxColumn
    Friend WithEvents IdItem As DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As DataGridViewTextBoxColumn
    Friend WithEvents PrecioUnitario As DataGridViewTextBoxColumn
    Friend WithEvents Importe As DataGridViewTextBoxColumn
End Class
