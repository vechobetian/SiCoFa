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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.lblAccionFarmacologica = New System.Windows.Forms.Label()
        Me.lblMonodroga = New System.Windows.Forms.Label()
        Me.lblTrazabilidad = New System.Windows.Forms.Label()
        Me.lblTipoControl = New System.Windows.Forms.Label()
        Me.lblTipoVenta = New System.Windows.Forms.Label()
        Me.lblViaAdministracion = New System.Windows.Forms.Label()
        Me.Monodroga = New System.Windows.Forms.Label()
        Me.AccionFarmacologica = New System.Windows.Forms.Label()
        Me.Trazabilidad = New System.Windows.Forms.Label()
        Me.TipoControl = New System.Windows.Forms.Label()
        Me.TipoVenta = New System.Windows.Forms.Label()
        Me.ViaAdministracion = New System.Windows.Forms.Label()
        Me.lblHeladera = New System.Windows.Forms.Label()
        Me.Heladera = New System.Windows.Forms.Label()
        Me.IdArticulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodBarras = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fraccionable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AlicIVA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaPrecio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioCosto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioVenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioOferta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Baja = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdSeccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Seccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EstablecerPrecio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ActualizarPrecio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StockC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StockF = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodiLP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ListaPrecios = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Laboratorio = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdArticulo, Me.Codigo, Me.CodBarras, Me.Nombre, Me.Fraccionable, Me.AlicIVA, Me.FechaPrecio, Me.PrecioCosto, Me.PrecioVenta, Me.PrecioOferta, Me.Baja, Me.IdSeccion, Me.Seccion, Me.EstablecerPrecio, Me.ActualizarPrecio, Me.StockC, Me.StockF, Me.CodiLP, Me.ListaPrecios, Me.Laboratorio})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Top
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1187, 508)
        Me.DataGridView1.TabIndex = 3
        '
        'lblAccionFarmacologica
        '
        Me.lblAccionFarmacologica.AutoSize = True
        Me.lblAccionFarmacologica.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccionFarmacologica.Location = New System.Drawing.Point(12, 564)
        Me.lblAccionFarmacologica.Name = "lblAccionFarmacologica"
        Me.lblAccionFarmacologica.Size = New System.Drawing.Size(166, 16)
        Me.lblAccionFarmacologica.TabIndex = 4
        Me.lblAccionFarmacologica.Text = "Acción Farmacologica:"
        '
        'lblMonodroga
        '
        Me.lblMonodroga.AutoSize = True
        Me.lblMonodroga.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonodroga.Location = New System.Drawing.Point(12, 532)
        Me.lblMonodroga.Name = "lblMonodroga"
        Me.lblMonodroga.Size = New System.Drawing.Size(90, 16)
        Me.lblMonodroga.TabIndex = 5
        Me.lblMonodroga.Text = "Monodroga:"
        '
        'lblTrazabilidad
        '
        Me.lblTrazabilidad.AutoSize = True
        Me.lblTrazabilidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTrazabilidad.Location = New System.Drawing.Point(12, 598)
        Me.lblTrazabilidad.Name = "lblTrazabilidad"
        Me.lblTrazabilidad.Size = New System.Drawing.Size(99, 16)
        Me.lblTrazabilidad.TabIndex = 6
        Me.lblTrazabilidad.Text = "Trazabilidad:"
        '
        'lblTipoControl
        '
        Me.lblTipoControl.AutoSize = True
        Me.lblTipoControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoControl.Location = New System.Drawing.Point(471, 532)
        Me.lblTipoControl.Name = "lblTipoControl"
        Me.lblTipoControl.Size = New System.Drawing.Size(118, 16)
        Me.lblTipoControl.TabIndex = 7
        Me.lblTipoControl.Text = "Tipo de Control:"
        '
        'lblTipoVenta
        '
        Me.lblTipoVenta.AutoSize = True
        Me.lblTipoVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoVenta.Location = New System.Drawing.Point(471, 564)
        Me.lblTipoVenta.Name = "lblTipoVenta"
        Me.lblTipoVenta.Size = New System.Drawing.Size(109, 16)
        Me.lblTipoVenta.TabIndex = 8
        Me.lblTipoVenta.Text = "Tipo de Venta:"
        '
        'lblViaAdministracion
        '
        Me.lblViaAdministracion.AutoSize = True
        Me.lblViaAdministracion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblViaAdministracion.Location = New System.Drawing.Point(471, 598)
        Me.lblViaAdministracion.Name = "lblViaAdministracion"
        Me.lblViaAdministracion.Size = New System.Drawing.Size(162, 16)
        Me.lblViaAdministracion.TabIndex = 9
        Me.lblViaAdministracion.Text = "Via de Administración:"
        '
        'Monodroga
        '
        Me.Monodroga.AutoSize = True
        Me.Monodroga.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Monodroga.Location = New System.Drawing.Point(108, 532)
        Me.Monodroga.Name = "Monodroga"
        Me.Monodroga.Size = New System.Drawing.Size(80, 17)
        Me.Monodroga.TabIndex = 10
        Me.Monodroga.Text = "Monodroga"
        '
        'AccionFarmacologica
        '
        Me.AccionFarmacologica.AutoSize = True
        Me.AccionFarmacologica.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AccionFarmacologica.Location = New System.Drawing.Point(184, 564)
        Me.AccionFarmacologica.Name = "AccionFarmacologica"
        Me.AccionFarmacologica.Size = New System.Drawing.Size(146, 17)
        Me.AccionFarmacologica.TabIndex = 11
        Me.AccionFarmacologica.Text = "Acción Farmacologica"
        '
        'Trazabilidad
        '
        Me.Trazabilidad.AutoSize = True
        Me.Trazabilidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Trazabilidad.Location = New System.Drawing.Point(117, 598)
        Me.Trazabilidad.Name = "Trazabilidad"
        Me.Trazabilidad.Size = New System.Drawing.Size(86, 17)
        Me.Trazabilidad.TabIndex = 12
        Me.Trazabilidad.Text = "Trazabilidad"
        '
        'TipoControl
        '
        Me.TipoControl.AutoSize = True
        Me.TipoControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TipoControl.Location = New System.Drawing.Point(595, 531)
        Me.TipoControl.Name = "TipoControl"
        Me.TipoControl.Size = New System.Drawing.Size(105, 17)
        Me.TipoControl.TabIndex = 13
        Me.TipoControl.Text = "Tipo de Control"
        '
        'TipoVenta
        '
        Me.TipoVenta.AutoSize = True
        Me.TipoVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TipoVenta.Location = New System.Drawing.Point(586, 564)
        Me.TipoVenta.Name = "TipoVenta"
        Me.TipoVenta.Size = New System.Drawing.Size(97, 17)
        Me.TipoVenta.TabIndex = 14
        Me.TipoVenta.Text = "Tipo de Venta"
        '
        'ViaAdministracion
        '
        Me.ViaAdministracion.AutoSize = True
        Me.ViaAdministracion.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ViaAdministracion.Location = New System.Drawing.Point(639, 597)
        Me.ViaAdministracion.Name = "ViaAdministracion"
        Me.ViaAdministracion.Size = New System.Drawing.Size(144, 17)
        Me.ViaAdministracion.TabIndex = 15
        Me.ViaAdministracion.Text = "Via de Administración"
        '
        'lblHeladera
        '
        Me.lblHeladera.AutoSize = True
        Me.lblHeladera.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeladera.Location = New System.Drawing.Point(891, 532)
        Me.lblHeladera.Name = "lblHeladera"
        Me.lblHeladera.Size = New System.Drawing.Size(76, 16)
        Me.lblHeladera.TabIndex = 16
        Me.lblHeladera.Text = "Heladera:"
        '
        'Heladera
        '
        Me.Heladera.AutoSize = True
        Me.Heladera.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Heladera.Location = New System.Drawing.Point(973, 531)
        Me.Heladera.Name = "Heladera"
        Me.Heladera.Size = New System.Drawing.Size(66, 17)
        Me.Heladera.TabIndex = 17
        Me.Heladera.Text = "Heladera"
        '
        'IdArticulo
        '
        Me.IdArticulo.DataPropertyName = "IdArticulo"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.IdArticulo.DefaultCellStyle = DataGridViewCellStyle1
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
        'CodBarras
        '
        Me.CodBarras.DataPropertyName = "CodBarras"
        Me.CodBarras.FillWeight = 90.0!
        Me.CodBarras.HeaderText = "CodBarras"
        Me.CodBarras.Name = "CodBarras"
        Me.CodBarras.ReadOnly = True
        Me.CodBarras.Visible = False
        Me.CodBarras.Width = 90
        '
        'Nombre
        '
        Me.Nombre.DataPropertyName = "Nombre"
        Me.Nombre.HeaderText = "Articulo"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.ReadOnly = True
        Me.Nombre.Width = 400
        '
        'Fraccionable
        '
        Me.Fraccionable.DataPropertyName = "Fraccionable"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Fraccionable.DefaultCellStyle = DataGridViewCellStyle2
        Me.Fraccionable.HeaderText = "Fraccionable"
        Me.Fraccionable.Name = "Fraccionable"
        Me.Fraccionable.ReadOnly = True
        Me.Fraccionable.Width = 80
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
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.PrecioVenta.DefaultCellStyle = DataGridViewCellStyle3
        Me.PrecioVenta.HeaderText = "Pcio.Venta"
        Me.PrecioVenta.Name = "PrecioVenta"
        Me.PrecioVenta.ReadOnly = True
        '
        'PrecioOferta
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        Me.PrecioOferta.DefaultCellStyle = DataGridViewCellStyle4
        Me.PrecioOferta.HeaderText = "Pcio.Oferta"
        Me.PrecioOferta.Name = "PrecioOferta"
        Me.PrecioOferta.ReadOnly = True
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
        'StockC
        '
        Me.StockC.DataPropertyName = "StockC"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.StockC.DefaultCellStyle = DataGridViewCellStyle5
        Me.StockC.HeaderText = "Stock C"
        Me.StockC.Name = "StockC"
        Me.StockC.ReadOnly = True
        Me.StockC.Width = 70
        '
        'StockF
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.StockF.DefaultCellStyle = DataGridViewCellStyle6
        Me.StockF.HeaderText = "Stock F"
        Me.StockF.Name = "StockF"
        Me.StockF.ReadOnly = True
        Me.StockF.Width = 70
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
        'Laboratorio
        '
        Me.Laboratorio.DataPropertyName = "Laboratorio"
        Me.Laboratorio.HeaderText = "Laboratorio"
        Me.Laboratorio.Name = "Laboratorio"
        Me.Laboratorio.ReadOnly = True
        Me.Laboratorio.Width = 200
        '
        'FrmBuscaArticulos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1187, 631)
        Me.ControlBox = False
        Me.Controls.Add(Me.Heladera)
        Me.Controls.Add(Me.lblHeladera)
        Me.Controls.Add(Me.ViaAdministracion)
        Me.Controls.Add(Me.TipoVenta)
        Me.Controls.Add(Me.TipoControl)
        Me.Controls.Add(Me.Trazabilidad)
        Me.Controls.Add(Me.AccionFarmacologica)
        Me.Controls.Add(Me.Monodroga)
        Me.Controls.Add(Me.lblViaAdministracion)
        Me.Controls.Add(Me.lblTipoVenta)
        Me.Controls.Add(Me.lblTipoControl)
        Me.Controls.Add(Me.lblTrazabilidad)
        Me.Controls.Add(Me.lblMonodroga)
        Me.Controls.Add(Me.lblAccionFarmacologica)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "FrmBuscaArticulos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lista de Articulos"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents lblAccionFarmacologica As Label
    Friend WithEvents lblMonodroga As Label
    Friend WithEvents lblTrazabilidad As Label
    Friend WithEvents lblTipoControl As Label
    Friend WithEvents lblTipoVenta As Label
    Friend WithEvents lblViaAdministracion As Label
    Friend WithEvents Monodroga As Label
    Friend WithEvents AccionFarmacologica As Label
    Friend WithEvents Trazabilidad As Label
    Friend WithEvents TipoControl As Label
    Friend WithEvents TipoVenta As Label
    Friend WithEvents ViaAdministracion As Label
    Friend WithEvents lblHeladera As Label
    Friend WithEvents Heladera As Label
    Friend WithEvents IdArticulo As DataGridViewTextBoxColumn
    Friend WithEvents Codigo As DataGridViewTextBoxColumn
    Friend WithEvents CodBarras As DataGridViewTextBoxColumn
    Friend WithEvents Nombre As DataGridViewTextBoxColumn
    Friend WithEvents Fraccionable As DataGridViewTextBoxColumn
    Friend WithEvents AlicIVA As DataGridViewTextBoxColumn
    Friend WithEvents FechaPrecio As DataGridViewTextBoxColumn
    Friend WithEvents PrecioCosto As DataGridViewTextBoxColumn
    Friend WithEvents PrecioVenta As DataGridViewTextBoxColumn
    Friend WithEvents PrecioOferta As DataGridViewTextBoxColumn
    Friend WithEvents Baja As DataGridViewTextBoxColumn
    Friend WithEvents IdSeccion As DataGridViewTextBoxColumn
    Friend WithEvents Seccion As DataGridViewTextBoxColumn
    Friend WithEvents EstablecerPrecio As DataGridViewTextBoxColumn
    Friend WithEvents ActualizarPrecio As DataGridViewTextBoxColumn
    Friend WithEvents StockC As DataGridViewTextBoxColumn
    Friend WithEvents StockF As DataGridViewTextBoxColumn
    Friend WithEvents CodiLP As DataGridViewTextBoxColumn
    Friend WithEvents ListaPrecios As DataGridViewTextBoxColumn
    Friend WithEvents Laboratorio As DataGridViewTextBoxColumn
End Class
