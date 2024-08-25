<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmEstadCuentaClientes
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
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btnExpandir = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.IdOperacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Resu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImpFacturado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImpCancelado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImpNoCancelado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EstadoOperaContrato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImpTotalAnticipos = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImprimirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OperacionesCanceladasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OperacionesNoCanceladasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TodasLasOperacionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ImpTotalNoCancelado = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PagosAbiertosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.btnExpandir, Me.IdOperacion, Me.Resu, Me.ImpFacturado, Me.ImpCancelado, Me.ImpNoCancelado, Me.EstadoOperaContrato})
        Me.DataGridView1.Location = New System.Drawing.Point(0, 27)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(749, 385)
        Me.DataGridView1.TabIndex = 1
        '
        'btnExpandir
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.btnExpandir.DefaultCellStyle = DataGridViewCellStyle13
        Me.btnExpandir.HeaderText = ""
        Me.btnExpandir.Name = "btnExpandir"
        Me.btnExpandir.ReadOnly = True
        Me.btnExpandir.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.btnExpandir.Text = "+"
        Me.btnExpandir.UseColumnTextForButtonValue = True
        Me.btnExpandir.Width = 24
        '
        'IdOperacion
        '
        Me.IdOperacion.DataPropertyName = "IdOperacion"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        Me.IdOperacion.DefaultCellStyle = DataGridViewCellStyle14
        Me.IdOperacion.HeaderText = "IdOperacion"
        Me.IdOperacion.Name = "IdOperacion"
        Me.IdOperacion.ReadOnly = True
        Me.IdOperacion.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.IdOperacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.IdOperacion.Width = 70
        '
        'Resu
        '
        Me.Resu.DataPropertyName = "Resu"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.Resu.DefaultCellStyle = DataGridViewCellStyle15
        Me.Resu.HeaderText = "Resumen"
        Me.Resu.Name = "Resu"
        Me.Resu.ReadOnly = True
        Me.Resu.Width = 60
        '
        'ImpFacturado
        '
        Me.ImpFacturado.DataPropertyName = "ImpFacturado"
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle16.Format = "N2"
        DataGridViewCellStyle16.NullValue = Nothing
        Me.ImpFacturado.DefaultCellStyle = DataGridViewCellStyle16
        Me.ImpFacturado.HeaderText = "ImpFacturado"
        Me.ImpFacturado.Name = "ImpFacturado"
        Me.ImpFacturado.ReadOnly = True
        Me.ImpFacturado.Width = 150
        '
        'ImpCancelado
        '
        Me.ImpCancelado.DataPropertyName = "ImpCancelado"
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle17.Format = "N2"
        DataGridViewCellStyle17.NullValue = Nothing
        Me.ImpCancelado.DefaultCellStyle = DataGridViewCellStyle17
        Me.ImpCancelado.HeaderText = "ImpCancelado"
        Me.ImpCancelado.Name = "ImpCancelado"
        Me.ImpCancelado.ReadOnly = True
        Me.ImpCancelado.Width = 150
        '
        'ImpNoCancelado
        '
        Me.ImpNoCancelado.DataPropertyName = "ImpNoCancelado"
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle18.Format = "N2"
        DataGridViewCellStyle18.NullValue = Nothing
        Me.ImpNoCancelado.DefaultCellStyle = DataGridViewCellStyle18
        Me.ImpNoCancelado.HeaderText = "ImpNoCancelado"
        Me.ImpNoCancelado.Name = "ImpNoCancelado"
        Me.ImpNoCancelado.ReadOnly = True
        Me.ImpNoCancelado.Width = 150
        '
        'EstadoOperaContrato
        '
        Me.EstadoOperaContrato.DataPropertyName = "EstadoOperaContrato"
        Me.EstadoOperaContrato.HeaderText = "Estado Resumen"
        Me.EstadoOperaContrato.Name = "EstadoOperaContrato"
        Me.EstadoOperaContrato.ReadOnly = True
        Me.EstadoOperaContrato.Width = 120
        '
        'ImpTotalAnticipos
        '
        Me.ImpTotalAnticipos.Location = New System.Drawing.Point(640, 453)
        Me.ImpTotalAnticipos.Name = "ImpTotalAnticipos"
        Me.ImpTotalAnticipos.ReadOnly = True
        Me.ImpTotalAnticipos.Size = New System.Drawing.Size(97, 20)
        Me.ImpTotalAnticipos.TabIndex = 3
        Me.ImpTotalAnticipos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.VerToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(749, 24)
        Me.MenuStrip1.TabIndex = 5
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ArchivoToolStripMenuItem
        '
        Me.ArchivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImprimirToolStripMenuItem, Me.SalirToolStripMenuItem})
        Me.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
        Me.ArchivoToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.ArchivoToolStripMenuItem.Text = "&Archivo"
        '
        'ImprimirToolStripMenuItem
        '
        Me.ImprimirToolStripMenuItem.Name = "ImprimirToolStripMenuItem"
        Me.ImprimirToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.ImprimirToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.ImprimirToolStripMenuItem.Text = "&Imprimir"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.SalirToolStripMenuItem.Text = "&Salir"
        '
        'VerToolStripMenuItem
        '
        Me.VerToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OperacionesCanceladasToolStripMenuItem, Me.OperacionesNoCanceladasToolStripMenuItem, Me.TodasLasOperacionesToolStripMenuItem, Me.PagosAbiertosToolStripMenuItem})
        Me.VerToolStripMenuItem.Name = "VerToolStripMenuItem"
        Me.VerToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.VerToolStripMenuItem.Text = "&Ver"
        '
        'OperacionesCanceladasToolStripMenuItem
        '
        Me.OperacionesCanceladasToolStripMenuItem.Name = "OperacionesCanceladasToolStripMenuItem"
        Me.OperacionesCanceladasToolStripMenuItem.Size = New System.Drawing.Size(222, 22)
        Me.OperacionesCanceladasToolStripMenuItem.Text = "Operaciones &Canceladas"
        '
        'OperacionesNoCanceladasToolStripMenuItem
        '
        Me.OperacionesNoCanceladasToolStripMenuItem.Name = "OperacionesNoCanceladasToolStripMenuItem"
        Me.OperacionesNoCanceladasToolStripMenuItem.Size = New System.Drawing.Size(222, 22)
        Me.OperacionesNoCanceladasToolStripMenuItem.Text = "Operaciones &No Canceladas"
        '
        'TodasLasOperacionesToolStripMenuItem
        '
        Me.TodasLasOperacionesToolStripMenuItem.Name = "TodasLasOperacionesToolStripMenuItem"
        Me.TodasLasOperacionesToolStripMenuItem.Size = New System.Drawing.Size(222, 22)
        Me.TodasLasOperacionesToolStripMenuItem.Text = "&Todas las Operaciones"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 430)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Label1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 456)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Label2"
        '
        'ImpTotalNoCancelado
        '
        Me.ImpTotalNoCancelado.Location = New System.Drawing.Point(640, 423)
        Me.ImpTotalNoCancelado.Name = "ImpTotalNoCancelado"
        Me.ImpTotalNoCancelado.ReadOnly = True
        Me.ImpTotalNoCancelado.Size = New System.Drawing.Size(97, 20)
        Me.ImpTotalNoCancelado.TabIndex = 8
        Me.ImpTotalNoCancelado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(526, 456)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Imp.Total Anticipos:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(525, 426)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(106, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Imp.Total Adeudado:"
        '
        'PagosAbiertosToolStripMenuItem
        '
        Me.PagosAbiertosToolStripMenuItem.Name = "PagosAbiertosToolStripMenuItem"
        Me.PagosAbiertosToolStripMenuItem.Size = New System.Drawing.Size(222, 22)
        Me.PagosAbiertosToolStripMenuItem.Text = "&Pagos Abiertos"
        '
        'FrmEstadCuentaClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(749, 504)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ImpTotalNoCancelado)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ImpTotalAnticipos)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "FrmEstadCuentaClientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Estado de Cuenta"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents ImpTotalAnticipos As TextBox
    Friend WithEvents btnExpandir As DataGridViewButtonColumn
    Friend WithEvents IdOperacion As DataGridViewTextBoxColumn
    Friend WithEvents Resu As DataGridViewTextBoxColumn
    Friend WithEvents ImpFacturado As DataGridViewTextBoxColumn
    Friend WithEvents ImpCancelado As DataGridViewTextBoxColumn
    Friend WithEvents ImpNoCancelado As DataGridViewTextBoxColumn
    Friend WithEvents EstadoOperaContrato As DataGridViewTextBoxColumn
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImprimirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OperacionesCanceladasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OperacionesNoCanceladasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TodasLasOperacionesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ImpTotalNoCancelado As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents PagosAbiertosToolStripMenuItem As ToolStripMenuItem
End Class
