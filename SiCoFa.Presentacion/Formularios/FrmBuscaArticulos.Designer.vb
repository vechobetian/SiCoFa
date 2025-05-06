<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBuscaArticulos
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
        Me.IdArticulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodBarra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AlicIVA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaPrecio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioCosto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioVenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Baja = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdSeccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Seccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EstablecerPrecio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ActualizarPrecio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Stock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodiLP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ListaPrecios = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fabricante = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdArticulo, Me.Codigo, Me.CodBarra, Me.Nombre, Me.AlicIVA, Me.FechaPrecio, Me.PrecioCosto, Me.PrecioVenta, Me.Baja, Me.IdSeccion, Me.Seccion, Me.EstablecerPrecio, Me.ActualizarPrecio, Me.Stock, Me.CodiLP, Me.ListaPrecios, Me.Fabricante})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(922, 450)
        Me.DataGridView1.TabIndex = 3
        '
        'IdArticulo
        '
        Me.IdArticulo.DataPropertyName = "IdArticulo"
        Me.IdArticulo.HeaderText = "IdArticulo"
        Me.IdArticulo.Name = "IdArticulo"
        Me.IdArticulo.ReadOnly = True
        Me.IdArticulo.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.IdArticulo.Visible = False
        Me.IdArticulo.Width = 5
        '
        'Codigo
        '
        Me.Codigo.DataPropertyName = "Codigo"
        Me.Codigo.HeaderText = "Codigo"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.ReadOnly = True
        Me.Codigo.Visible = False
        '
        'CodBarra
        '
        Me.CodBarra.DataPropertyName = "CodBarra"
        Me.CodBarra.FillWeight = 90.0!
        Me.CodBarra.HeaderText = "CodBarra"
        Me.CodBarra.Name = "CodBarra"
        Me.CodBarra.ReadOnly = True
        Me.CodBarra.Visible = False
        Me.CodBarra.Width = 90
        '
        'Nombre
        '
        Me.Nombre.DataPropertyName = "Nombre"
        Me.Nombre.HeaderText = "Articulo"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.ReadOnly = True
        Me.Nombre.Width = 400
        '
        'AlicIVA
        '
        Me.AlicIVA.DataPropertyName = "AlicIVA"
        Me.AlicIVA.HeaderText = "AlicIVA"
        Me.AlicIVA.Name = "AlicIVA"
        Me.AlicIVA.ReadOnly = True
        Me.AlicIVA.Visible = False
        '
        'FechaPrecio
        '
        Me.FechaPrecio.DataPropertyName = "FechaPrecio"
        Me.FechaPrecio.HeaderText = "FechaPrecio"
        Me.FechaPrecio.Name = "FechaPrecio"
        Me.FechaPrecio.ReadOnly = True
        Me.FechaPrecio.Visible = False
        '
        'PrecioCosto
        '
        Me.PrecioCosto.DataPropertyName = "PrecioCosto"
        Me.PrecioCosto.HeaderText = "PrecioCosto"
        Me.PrecioCosto.Name = "PrecioCosto"
        Me.PrecioCosto.ReadOnly = True
        Me.PrecioCosto.Visible = False
        '
        'PrecioVenta
        '
        Me.PrecioVenta.DataPropertyName = "PrecioVenta"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.PrecioVenta.DefaultCellStyle = DataGridViewCellStyle1
        Me.PrecioVenta.HeaderText = "Pcio.Venta"
        Me.PrecioVenta.Name = "PrecioVenta"
        Me.PrecioVenta.ReadOnly = True
        '
        'Baja
        '
        Me.Baja.DataPropertyName = "Baja"
        Me.Baja.HeaderText = "Baja"
        Me.Baja.Name = "Baja"
        Me.Baja.ReadOnly = True
        Me.Baja.Visible = False
        '
        'IdSeccion
        '
        Me.IdSeccion.DataPropertyName = "IdSeccion"
        Me.IdSeccion.HeaderText = "IdSeccion"
        Me.IdSeccion.Name = "IdSeccion"
        Me.IdSeccion.ReadOnly = True
        Me.IdSeccion.Visible = False
        '
        'Seccion
        '
        Me.Seccion.DataPropertyName = "Seccion"
        Me.Seccion.HeaderText = "Seccion"
        Me.Seccion.Name = "Seccion"
        Me.Seccion.ReadOnly = True
        '
        'EstablecerPrecio
        '
        Me.EstablecerPrecio.DataPropertyName = "EstablecerPrecio"
        Me.EstablecerPrecio.HeaderText = "EtablecerPrecio"
        Me.EstablecerPrecio.Name = "EstablecerPrecio"
        Me.EstablecerPrecio.ReadOnly = True
        Me.EstablecerPrecio.Visible = False
        '
        'ActualizarPrecio
        '
        Me.ActualizarPrecio.DataPropertyName = "ActualizarPrecio"
        Me.ActualizarPrecio.HeaderText = "ActualizarPrecio"
        Me.ActualizarPrecio.Name = "ActualizarPrecio"
        Me.ActualizarPrecio.ReadOnly = True
        Me.ActualizarPrecio.Visible = False
        '
        'Stock
        '
        Me.Stock.DataPropertyName = "Stock"
        Me.Stock.HeaderText = "Stock"
        Me.Stock.Name = "Stock"
        Me.Stock.ReadOnly = True
        '
        'CodiLP
        '
        Me.CodiLP.DataPropertyName = "CodiLP"
        Me.CodiLP.HeaderText = "CodiLP"
        Me.CodiLP.Name = "CodiLP"
        Me.CodiLP.ReadOnly = True
        Me.CodiLP.Visible = False
        '
        'ListaPrecios
        '
        Me.ListaPrecios.DataPropertyName = "ListaPrecios"
        Me.ListaPrecios.HeaderText = "ListaPrecios"
        Me.ListaPrecios.Name = "ListaPrecios"
        Me.ListaPrecios.ReadOnly = True
        '
        'Fabricante
        '
        Me.Fabricante.DataPropertyName = "Fabricante"
        Me.Fabricante.HeaderText = "Fabricante"
        Me.Fabricante.Name = "Fabricante"
        Me.Fabricante.ReadOnly = True
        '
        'FrmBuscaArticulos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(922, 450)
        Me.ControlBox = False
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "FrmBuscaArticulos"
        Me.Text = "Lista de Articulos"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents IdArticulo As DataGridViewTextBoxColumn
    Friend WithEvents Codigo As DataGridViewTextBoxColumn
    Friend WithEvents CodBarra As DataGridViewTextBoxColumn
    Friend WithEvents Nombre As DataGridViewTextBoxColumn
    Friend WithEvents AlicIVA As DataGridViewTextBoxColumn
    Friend WithEvents FechaPrecio As DataGridViewTextBoxColumn
    Friend WithEvents PrecioCosto As DataGridViewTextBoxColumn
    Friend WithEvents PrecioVenta As DataGridViewTextBoxColumn
    Friend WithEvents Baja As DataGridViewTextBoxColumn
    Friend WithEvents IdSeccion As DataGridViewTextBoxColumn
    Friend WithEvents Seccion As DataGridViewTextBoxColumn
    Friend WithEvents EstablecerPrecio As DataGridViewTextBoxColumn
    Friend WithEvents ActualizarPrecio As DataGridViewTextBoxColumn
    Friend WithEvents Stock As DataGridViewTextBoxColumn
    Friend WithEvents CodiLP As DataGridViewTextBoxColumn
    Friend WithEvents ListaPrecios As DataGridViewTextBoxColumn
    Friend WithEvents Fabricante As DataGridViewTextBoxColumn
End Class
