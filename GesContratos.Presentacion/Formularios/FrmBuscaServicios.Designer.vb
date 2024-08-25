<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBuscaServicios
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.CodiS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescripcionServicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PUnit = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodiS, Me.DescripcionServicio, Me.PUnit})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(404, 288)
        Me.DataGridView1.TabIndex = 2
        '
        'CodiS
        '
        Me.CodiS.HeaderText = "CodiS"
        Me.CodiS.Name = "CodiS"
        Me.CodiS.ReadOnly = True
        Me.CodiS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CodiS.Visible = False
        Me.CodiS.Width = 5
        '
        'DescripcionServicio
        '
        Me.DescripcionServicio.HeaderText = "Servicio"
        Me.DescripcionServicio.Name = "DescripcionServicio"
        Me.DescripcionServicio.ReadOnly = True
        Me.DescripcionServicio.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DescripcionServicio.Width = 300
        '
        'PUnit
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "C2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.PUnit.DefaultCellStyle = DataGridViewCellStyle1
        Me.PUnit.HeaderText = "P.Unit."
        Me.PUnit.Name = "PUnit"
        Me.PUnit.ReadOnly = True
        Me.PUnit.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'FrmBuscaServicios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(404, 288)
        Me.ControlBox = False
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "FrmBuscaServicios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Servicios"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents CodiS As DataGridViewTextBoxColumn
    Friend WithEvents DescripcionServicio As DataGridViewTextBoxColumn
    Friend WithEvents PUnit As DataGridViewTextBoxColumn
End Class
