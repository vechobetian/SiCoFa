<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmArticulos
    'Inherits System.Windows.Forms.Form
    Inherits clsFrmBase

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
        Me.components = New System.ComponentModel.Container()
        Dim IdArticuloLabel As System.Windows.Forms.Label
        Dim CodigoLabel As System.Windows.Forms.Label
        Dim CodBarraLabel As System.Windows.Forms.Label
        Dim NombreLabel As System.Windows.Forms.Label
        Dim AlicuotaIVALabel As System.Windows.Forms.Label
        Dim FechaPrecioLabel As System.Windows.Forms.Label
        Dim PrecioCostoLabel As System.Windows.Forms.Label
        Dim PrecioVentaLabel As System.Windows.Forms.Label
        Dim BajaLabel As System.Windows.Forms.Label
        Dim SeccionLabel As System.Windows.Forms.Label
        Dim ActualizarPrecioLabel As System.Windows.Forms.Label
        Dim StockLabel As System.Windows.Forms.Label
        Dim FabricanteLabel As System.Windows.Forms.Label
        Me.IdArticulo = New System.Windows.Forms.TextBox()
        Me.ArticuloBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Codigo = New System.Windows.Forms.TextBox()
        Me.CodBarra = New System.Windows.Forms.TextBox()
        Me.Nombre = New System.Windows.Forms.TextBox()
        Me.AlicuotaIVA = New System.Windows.Forms.ComboBox()
        Me.FechaPrecio = New System.Windows.Forms.TextBox()
        Me.PrecioCosto = New System.Windows.Forms.TextBox()
        Me.PrecioVenta = New System.Windows.Forms.TextBox()
        Me.Baja = New System.Windows.Forms.ComboBox()
        Me.Seccion = New System.Windows.Forms.ComboBox()
        Me.ActualizarPrecio = New System.Windows.Forms.ComboBox()
        Me.Stock = New System.Windows.Forms.TextBox()
        Me.Fabricante = New System.Windows.Forms.TextBox()
        IdArticuloLabel = New System.Windows.Forms.Label()
        CodigoLabel = New System.Windows.Forms.Label()
        CodBarraLabel = New System.Windows.Forms.Label()
        NombreLabel = New System.Windows.Forms.Label()
        AlicuotaIVALabel = New System.Windows.Forms.Label()
        FechaPrecioLabel = New System.Windows.Forms.Label()
        PrecioCostoLabel = New System.Windows.Forms.Label()
        PrecioVentaLabel = New System.Windows.Forms.Label()
        BajaLabel = New System.Windows.Forms.Label()
        SeccionLabel = New System.Windows.Forms.Label()
        ActualizarPrecioLabel = New System.Windows.Forms.Label()
        StockLabel = New System.Windows.Forms.Label()
        FabricanteLabel = New System.Windows.Forms.Label()
        CType(Me.ArticuloBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'IdArticuloLabel
        '
        IdArticuloLabel.AutoSize = True
        IdArticuloLabel.Location = New System.Drawing.Point(12, 15)
        IdArticuloLabel.Name = "IdArticuloLabel"
        IdArticuloLabel.Size = New System.Drawing.Size(57, 13)
        IdArticuloLabel.TabIndex = 1
        IdArticuloLabel.Text = "Id Articulo:"
        '
        'CodigoLabel
        '
        CodigoLabel.AutoSize = True
        CodigoLabel.Location = New System.Drawing.Point(12, 69)
        CodigoLabel.Name = "CodigoLabel"
        CodigoLabel.Size = New System.Drawing.Size(43, 13)
        CodigoLabel.TabIndex = 2
        CodigoLabel.Text = "Codigo:"
        '
        'CodBarraLabel
        '
        CodBarraLabel.AutoSize = True
        CodBarraLabel.Location = New System.Drawing.Point(12, 93)
        CodBarraLabel.Name = "CodBarraLabel"
        CodBarraLabel.Size = New System.Drawing.Size(57, 13)
        CodBarraLabel.TabIndex = 4
        CodBarraLabel.Text = "Cod Barra:"
        '
        'NombreLabel
        '
        NombreLabel.AutoSize = True
        NombreLabel.Location = New System.Drawing.Point(12, 43)
        NombreLabel.Name = "NombreLabel"
        NombreLabel.Size = New System.Drawing.Size(47, 13)
        NombreLabel.TabIndex = 6
        NombreLabel.Text = "Nombre:"
        '
        'AlicuotaIVALabel
        '
        AlicuotaIVALabel.AutoSize = True
        AlicuotaIVALabel.Location = New System.Drawing.Point(12, 119)
        AlicuotaIVALabel.Name = "AlicuotaIVALabel"
        AlicuotaIVALabel.Size = New System.Drawing.Size(68, 13)
        AlicuotaIVALabel.TabIndex = 8
        AlicuotaIVALabel.Text = "Alicuota IVA:"
        '
        'FechaPrecioLabel
        '
        FechaPrecioLabel.AutoSize = True
        FechaPrecioLabel.Location = New System.Drawing.Point(12, 146)
        FechaPrecioLabel.Name = "FechaPrecioLabel"
        FechaPrecioLabel.Size = New System.Drawing.Size(73, 13)
        FechaPrecioLabel.TabIndex = 10
        FechaPrecioLabel.Text = "Fecha Precio:"
        '
        'PrecioCostoLabel
        '
        PrecioCostoLabel.AutoSize = True
        PrecioCostoLabel.Location = New System.Drawing.Point(12, 172)
        PrecioCostoLabel.Name = "PrecioCostoLabel"
        PrecioCostoLabel.Size = New System.Drawing.Size(70, 13)
        PrecioCostoLabel.TabIndex = 12
        PrecioCostoLabel.Text = "Precio Costo:"
        '
        'PrecioVentaLabel
        '
        PrecioVentaLabel.AutoSize = True
        PrecioVentaLabel.Location = New System.Drawing.Point(12, 198)
        PrecioVentaLabel.Name = "PrecioVentaLabel"
        PrecioVentaLabel.Size = New System.Drawing.Size(71, 13)
        PrecioVentaLabel.TabIndex = 14
        PrecioVentaLabel.Text = "Precio Venta:"
        '
        'BajaLabel
        '
        BajaLabel.AutoSize = True
        BajaLabel.Location = New System.Drawing.Point(12, 224)
        BajaLabel.Name = "BajaLabel"
        BajaLabel.Size = New System.Drawing.Size(31, 13)
        BajaLabel.TabIndex = 16
        BajaLabel.Text = "Baja:"
        '
        'SeccionLabel
        '
        SeccionLabel.AutoSize = True
        SeccionLabel.Location = New System.Drawing.Point(12, 251)
        SeccionLabel.Name = "SeccionLabel"
        SeccionLabel.Size = New System.Drawing.Size(49, 13)
        SeccionLabel.TabIndex = 18
        SeccionLabel.Text = "Seccion:"
        '
        'ActualizarPrecioLabel
        '
        ActualizarPrecioLabel.AutoSize = True
        ActualizarPrecioLabel.Location = New System.Drawing.Point(12, 278)
        ActualizarPrecioLabel.Name = "ActualizarPrecioLabel"
        ActualizarPrecioLabel.Size = New System.Drawing.Size(89, 13)
        ActualizarPrecioLabel.TabIndex = 20
        ActualizarPrecioLabel.Text = "Actualizar Precio:"
        '
        'StockLabel
        '
        StockLabel.AutoSize = True
        StockLabel.Location = New System.Drawing.Point(12, 305)
        StockLabel.Name = "StockLabel"
        StockLabel.Size = New System.Drawing.Size(38, 13)
        StockLabel.TabIndex = 22
        StockLabel.Text = "Stock:"
        '
        'FabricanteLabel
        '
        FabricanteLabel.AutoSize = True
        FabricanteLabel.Location = New System.Drawing.Point(12, 331)
        FabricanteLabel.Name = "FabricanteLabel"
        FabricanteLabel.Size = New System.Drawing.Size(60, 13)
        FabricanteLabel.TabIndex = 24
        FabricanteLabel.Text = "Fabricante:"
        '
        'IdArticulo
        '
        Me.IdArticulo.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ArticuloBindingSource, "IdArticulo", True))
        Me.IdArticulo.Location = New System.Drawing.Point(102, 12)
        Me.IdArticulo.Name = "IdArticulo"
        Me.IdArticulo.Size = New System.Drawing.Size(315, 20)
        Me.IdArticulo.TabIndex = 0
        Me.IdArticulo.TabStop = False
        '
        'ArticuloBindingSource
        '
        Me.ArticuloBindingSource.DataSource = GetType(SiCoFa.Entidades.Articulo)
        '
        'Codigo
        '
        Me.Codigo.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ArticuloBindingSource, "Codigo", True))
        Me.Codigo.Location = New System.Drawing.Point(102, 66)
        Me.Codigo.Name = "Codigo"
        Me.Codigo.Size = New System.Drawing.Size(315, 20)
        Me.Codigo.TabIndex = 2
        '
        'CodBarra
        '
        Me.CodBarra.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ArticuloBindingSource, "CodBarra", True))
        Me.CodBarra.Location = New System.Drawing.Point(102, 90)
        Me.CodBarra.Name = "CodBarra"
        Me.CodBarra.Size = New System.Drawing.Size(315, 20)
        Me.CodBarra.TabIndex = 3
        '
        'Nombre
        '
        Me.Nombre.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ArticuloBindingSource, "Nombre", True))
        Me.Nombre.Location = New System.Drawing.Point(102, 40)
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Size = New System.Drawing.Size(315, 20)
        Me.Nombre.TabIndex = 1
        '
        'AlicuotaIVA
        '
        Me.AlicuotaIVA.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ArticuloBindingSource, "AlicIVA.AlicuotaIVA", True))
        Me.AlicuotaIVA.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.ArticuloBindingSource, "AlicIVA", True))
        Me.AlicuotaIVA.FormattingEnabled = True
        Me.AlicuotaIVA.Location = New System.Drawing.Point(102, 116)
        Me.AlicuotaIVA.Name = "AlicuotaIVA"
        Me.AlicuotaIVA.Size = New System.Drawing.Size(315, 21)
        Me.AlicuotaIVA.TabIndex = 4
        '
        'FechaPrecio
        '
        Me.FechaPrecio.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ArticuloBindingSource, "FechaPrecio", True))
        Me.FechaPrecio.Location = New System.Drawing.Point(102, 143)
        Me.FechaPrecio.Name = "FechaPrecio"
        Me.FechaPrecio.Size = New System.Drawing.Size(315, 20)
        Me.FechaPrecio.TabIndex = 5
        '
        'PrecioCosto
        '
        Me.PrecioCosto.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ArticuloBindingSource, "PrecioCosto", True))
        Me.PrecioCosto.Location = New System.Drawing.Point(102, 169)
        Me.PrecioCosto.Name = "PrecioCosto"
        Me.PrecioCosto.Size = New System.Drawing.Size(315, 20)
        Me.PrecioCosto.TabIndex = 6
        '
        'PrecioVenta
        '
        Me.PrecioVenta.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ArticuloBindingSource, "PrecioVenta", True))
        Me.PrecioVenta.Location = New System.Drawing.Point(102, 195)
        Me.PrecioVenta.Name = "PrecioVenta"
        Me.PrecioVenta.Size = New System.Drawing.Size(315, 20)
        Me.PrecioVenta.TabIndex = 7
        '
        'Baja
        '
        Me.Baja.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ArticuloBindingSource, "Baja", True))
        Me.Baja.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.ArticuloBindingSource, "Baja", True))
        Me.Baja.FormattingEnabled = True
        Me.Baja.ItemHeight = 13
        Me.Baja.Items.AddRange(New Object() {"NO", "SI"})
        Me.Baja.Location = New System.Drawing.Point(102, 221)
        Me.Baja.Name = "Baja"
        Me.Baja.Size = New System.Drawing.Size(315, 21)
        Me.Baja.TabIndex = 17
        '
        'Seccion
        '
        Me.Seccion.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ArticuloBindingSource, "Seccion.Seccion", True))
        Me.Seccion.FormattingEnabled = True
        Me.Seccion.ItemHeight = 13
        Me.Seccion.Location = New System.Drawing.Point(102, 248)
        Me.Seccion.Name = "Seccion"
        Me.Seccion.Size = New System.Drawing.Size(315, 21)
        Me.Seccion.TabIndex = 19
        '
        'ActualizarPrecio
        '
        Me.ActualizarPrecio.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ArticuloBindingSource, "ActualizarPrecio", True))
        Me.ActualizarPrecio.FormattingEnabled = True
        Me.ActualizarPrecio.ItemHeight = 13
        Me.ActualizarPrecio.Location = New System.Drawing.Point(102, 275)
        Me.ActualizarPrecio.Name = "ActualizarPrecio"
        Me.ActualizarPrecio.Size = New System.Drawing.Size(315, 21)
        Me.ActualizarPrecio.TabIndex = 21
        '
        'Stock
        '
        Me.Stock.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ArticuloBindingSource, "Stock", True))
        Me.Stock.Location = New System.Drawing.Point(102, 302)
        Me.Stock.Name = "Stock"
        Me.Stock.Size = New System.Drawing.Size(315, 20)
        Me.Stock.TabIndex = 11
        '
        'Fabricante
        '
        Me.Fabricante.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ArticuloBindingSource, "Fabricante", True))
        Me.Fabricante.Location = New System.Drawing.Point(102, 328)
        Me.Fabricante.Name = "Fabricante"
        Me.Fabricante.Size = New System.Drawing.Size(315, 20)
        Me.Fabricante.TabIndex = 12
        '
        'FrmArticulos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(434, 360)
        Me.Controls.Add(FabricanteLabel)
        Me.Controls.Add(Me.Fabricante)
        Me.Controls.Add(StockLabel)
        Me.Controls.Add(Me.Stock)
        Me.Controls.Add(ActualizarPrecioLabel)
        Me.Controls.Add(Me.ActualizarPrecio)
        Me.Controls.Add(SeccionLabel)
        Me.Controls.Add(Me.Seccion)
        Me.Controls.Add(BajaLabel)
        Me.Controls.Add(Me.Baja)
        Me.Controls.Add(PrecioVentaLabel)
        Me.Controls.Add(Me.PrecioVenta)
        Me.Controls.Add(PrecioCostoLabel)
        Me.Controls.Add(Me.PrecioCosto)
        Me.Controls.Add(FechaPrecioLabel)
        Me.Controls.Add(Me.FechaPrecio)
        Me.Controls.Add(AlicuotaIVALabel)
        Me.Controls.Add(Me.AlicuotaIVA)
        Me.Controls.Add(NombreLabel)
        Me.Controls.Add(Me.Nombre)
        Me.Controls.Add(CodBarraLabel)
        Me.Controls.Add(Me.CodBarra)
        Me.Controls.Add(CodigoLabel)
        Me.Controls.Add(Me.Codigo)
        Me.Controls.Add(IdArticuloLabel)
        Me.Controls.Add(Me.IdArticulo)
        Me.Name = "FrmArticulos"
        Me.Text = "FrmArticulos"
        CType(Me.ArticuloBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ArticuloBindingSource As BindingSource
    Friend WithEvents IdArticulo As TextBox
    Friend WithEvents Codigo As TextBox
    Friend WithEvents CodBarra As TextBox
    Friend WithEvents Nombre As TextBox
    Friend WithEvents AlicuotaIVA As ComboBox
    Friend WithEvents FechaPrecio As TextBox
    Friend WithEvents PrecioCosto As TextBox
    Friend WithEvents PrecioVenta As TextBox
    Friend WithEvents Baja As ComboBox
    Friend WithEvents Seccion As ComboBox
    Friend WithEvents ActualizarPrecio As ComboBox
    Friend WithEvents Stock As TextBox
    Friend WithEvents Fabricante As TextBox
End Class
