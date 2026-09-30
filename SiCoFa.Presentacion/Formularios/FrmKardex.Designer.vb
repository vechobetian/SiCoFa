<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmKardex
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.dgvKardex = New System.Windows.Forms.DataGridView()
        Me.IdOperacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Operacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaOperacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdUsuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Comprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaComp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fraccionado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StockFA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SockFP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StockCA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StockCP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtSelectorArticulo = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.dgvKardex, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.dgvKardex, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtSelectorArticulo, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1180, 700)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'dgvKardex
        '
        Me.dgvKardex.AllowUserToAddRows = False
        Me.dgvKardex.AllowUserToDeleteRows = False
        Me.dgvKardex.AllowUserToResizeColumns = False
        Me.dgvKardex.AllowUserToResizeRows = False
        Me.dgvKardex.BackgroundColor = System.Drawing.Color.White
        Me.dgvKardex.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvKardex.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdOperacion, Me.Operacion, Me.FechaOperacion, Me.IdUsuario, Me.Comprobante, Me.FechaComp, Me.Fraccionado, Me.StockFA, Me.SockFP, Me.StockCA, Me.StockCP})
        Me.dgvKardex.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvKardex.Location = New System.Drawing.Point(3, 3)
        Me.dgvKardex.Name = "dgvKardex"
        Me.dgvKardex.ReadOnly = True
        Me.dgvKardex.RowHeadersVisible = False
        Me.dgvKardex.RowHeadersWidth = 20
        Me.dgvKardex.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvKardex.Size = New System.Drawing.Size(1174, 660)
        Me.dgvKardex.TabIndex = 3
        Me.dgvKardex.TabStop = False
        '
        'IdOperacion
        '
        Me.IdOperacion.DataPropertyName = "IdOperacion"
        Me.IdOperacion.HeaderText = "IdOperacion"
        Me.IdOperacion.Name = "IdOperacion"
        Me.IdOperacion.ReadOnly = True
        Me.IdOperacion.Width = 70
        '
        'Operacion
        '
        Me.Operacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Operacion.DataPropertyName = "Operacion"
        Me.Operacion.HeaderText = "Operacion"
        Me.Operacion.Name = "Operacion"
        Me.Operacion.ReadOnly = True
        '
        'FechaOperacion
        '
        Me.FechaOperacion.DataPropertyName = "FechaOperacion"
        Me.FechaOperacion.HeaderText = "Fecha Operación"
        Me.FechaOperacion.Name = "FechaOperacion"
        Me.FechaOperacion.ReadOnly = True
        Me.FechaOperacion.Width = 130
        '
        'IdUsuario
        '
        Me.IdUsuario.DataPropertyName = "IdUsuario"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.IdUsuario.DefaultCellStyle = DataGridViewCellStyle1
        Me.IdUsuario.HeaderText = "IdUsuario"
        Me.IdUsuario.Name = "IdUsuario"
        Me.IdUsuario.ReadOnly = True
        Me.IdUsuario.Width = 55
        '
        'Comprobante
        '
        Me.Comprobante.DataPropertyName = "Comprobante"
        Me.Comprobante.HeaderText = "Comprobante"
        Me.Comprobante.Name = "Comprobante"
        Me.Comprobante.ReadOnly = True
        Me.Comprobante.Width = 130
        '
        'FechaComp
        '
        Me.FechaComp.DataPropertyName = "FechaComp"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.FechaComp.DefaultCellStyle = DataGridViewCellStyle2
        Me.FechaComp.HeaderText = "Fecha Comprobante"
        Me.FechaComp.Name = "FechaComp"
        Me.FechaComp.ReadOnly = True
        Me.FechaComp.Width = 130
        '
        'Fraccionado
        '
        Me.Fraccionado.DataPropertyName = "Fraccionado"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Fraccionado.DefaultCellStyle = DataGridViewCellStyle3
        Me.Fraccionado.HeaderText = "Fraccionado"
        Me.Fraccionado.Name = "Fraccionado"
        Me.Fraccionado.ReadOnly = True
        Me.Fraccionado.Width = 80
        '
        'StockFA
        '
        Me.StockFA.DataPropertyName = "StockFA"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.StockFA.DefaultCellStyle = DataGridViewCellStyle4
        Me.StockFA.HeaderText = "Stock Frac.Ant."
        Me.StockFA.Name = "StockFA"
        Me.StockFA.ReadOnly = True
        Me.StockFA.Width = 120
        '
        'SockFP
        '
        Me.SockFP.DataPropertyName = "StockFP"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.SockFP.DefaultCellStyle = DataGridViewCellStyle5
        Me.SockFP.HeaderText = "Stock Frac.Post."
        Me.SockFP.Name = "SockFP"
        Me.SockFP.ReadOnly = True
        Me.SockFP.Width = 120
        '
        'StockCA
        '
        Me.StockCA.DataPropertyName = "StockCA"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.StockCA.DefaultCellStyle = DataGridViewCellStyle6
        Me.StockCA.HeaderText = "Stock Cerr.Ant."
        Me.StockCA.Name = "StockCA"
        Me.StockCA.ReadOnly = True
        Me.StockCA.Width = 120
        '
        'StockCP
        '
        Me.StockCP.DataPropertyName = "StockCP"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.StockCP.DefaultCellStyle = DataGridViewCellStyle7
        Me.StockCP.HeaderText = "Stock Cerr.Post."
        Me.StockCP.Name = "StockCP"
        Me.StockCP.ReadOnly = True
        Me.StockCP.Width = 120
        '
        'txtSelectorArticulo
        '
        Me.txtSelectorArticulo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSelectorArticulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSelectorArticulo.Location = New System.Drawing.Point(3, 669)
        Me.txtSelectorArticulo.Name = "txtSelectorArticulo"
        Me.txtSelectorArticulo.Size = New System.Drawing.Size(1174, 29)
        Me.txtSelectorArticulo.TabIndex = 4
        '
        'FrmKardex
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1180, 700)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FrmKardex"
        Me.Text = "Form1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.dgvKardex, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents dgvKardex As DataGridView
    Friend WithEvents IdOperacion As DataGridViewTextBoxColumn
    Friend WithEvents Operacion As DataGridViewTextBoxColumn
    Friend WithEvents FechaOperacion As DataGridViewTextBoxColumn
    Friend WithEvents IdUsuario As DataGridViewTextBoxColumn
    Friend WithEvents Comprobante As DataGridViewTextBoxColumn
    Friend WithEvents FechaComp As DataGridViewTextBoxColumn
    Friend WithEvents Fraccionado As DataGridViewTextBoxColumn
    Friend WithEvents StockFA As DataGridViewTextBoxColumn
    Friend WithEvents SockFP As DataGridViewTextBoxColumn
    Friend WithEvents StockCA As DataGridViewTextBoxColumn
    Friend WithEvents StockCP As DataGridViewTextBoxColumn
    Friend WithEvents txtSelectorArticulo As TextBox
End Class
