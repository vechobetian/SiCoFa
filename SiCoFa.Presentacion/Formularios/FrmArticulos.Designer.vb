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
        Dim BajaLabel As System.Windows.Forms.Label
        Dim SeccionLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmArticulos))
        Me.IdArticulo = New System.Windows.Forms.TextBox()
        Me.ArticuloBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Codigo = New System.Windows.Forms.TextBox()
        Me.CodBarra = New System.Windows.Forms.TextBox()
        Me.Nombre = New System.Windows.Forms.TextBox()
        Me.AlicuotaIVA = New System.Windows.Forms.ComboBox()
        Me.Baja = New System.Windows.Forms.ComboBox()
        Me.Seccion = New System.Windows.Forms.ComboBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.Guardar = New System.Windows.Forms.ToolStripButton()
        Me.Nuevo = New System.Windows.Forms.ToolStripButton()
        Me.Buscar = New System.Windows.Forms.ToolStripButton()
        Me.Limpiar = New System.Windows.Forms.ToolStripButton()
        IdArticuloLabel = New System.Windows.Forms.Label()
        CodigoLabel = New System.Windows.Forms.Label()
        CodBarraLabel = New System.Windows.Forms.Label()
        NombreLabel = New System.Windows.Forms.Label()
        AlicuotaIVALabel = New System.Windows.Forms.Label()
        BajaLabel = New System.Windows.Forms.Label()
        SeccionLabel = New System.Windows.Forms.Label()
        CType(Me.ArticuloBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'IdArticuloLabel
        '
        IdArticuloLabel.AutoSize = True
        IdArticuloLabel.Location = New System.Drawing.Point(10, 43)
        IdArticuloLabel.Name = "IdArticuloLabel"
        IdArticuloLabel.Size = New System.Drawing.Size(57, 13)
        IdArticuloLabel.TabIndex = 1
        IdArticuloLabel.Text = "Id Articulo:"
        '
        'CodigoLabel
        '
        CodigoLabel.AutoSize = True
        CodigoLabel.Location = New System.Drawing.Point(10, 97)
        CodigoLabel.Name = "CodigoLabel"
        CodigoLabel.Size = New System.Drawing.Size(43, 13)
        CodigoLabel.TabIndex = 2
        CodigoLabel.Text = "Codigo:"
        '
        'CodBarraLabel
        '
        CodBarraLabel.AutoSize = True
        CodBarraLabel.Location = New System.Drawing.Point(10, 121)
        CodBarraLabel.Name = "CodBarraLabel"
        CodBarraLabel.Size = New System.Drawing.Size(57, 13)
        CodBarraLabel.TabIndex = 4
        CodBarraLabel.Text = "Cod Barra:"
        '
        'NombreLabel
        '
        NombreLabel.AutoSize = True
        NombreLabel.Location = New System.Drawing.Point(10, 71)
        NombreLabel.Name = "NombreLabel"
        NombreLabel.Size = New System.Drawing.Size(47, 13)
        NombreLabel.TabIndex = 6
        NombreLabel.Text = "Nombre:"
        '
        'AlicuotaIVALabel
        '
        AlicuotaIVALabel.AutoSize = True
        AlicuotaIVALabel.Location = New System.Drawing.Point(10, 147)
        AlicuotaIVALabel.Name = "AlicuotaIVALabel"
        AlicuotaIVALabel.Size = New System.Drawing.Size(68, 13)
        AlicuotaIVALabel.TabIndex = 8
        AlicuotaIVALabel.Text = "Alicuota IVA:"
        '
        'BajaLabel
        '
        BajaLabel.AutoSize = True
        BajaLabel.Location = New System.Drawing.Point(10, 174)
        BajaLabel.Name = "BajaLabel"
        BajaLabel.Size = New System.Drawing.Size(31, 13)
        BajaLabel.TabIndex = 16
        BajaLabel.Text = "Baja:"
        '
        'SeccionLabel
        '
        SeccionLabel.AutoSize = True
        SeccionLabel.Location = New System.Drawing.Point(10, 201)
        SeccionLabel.Name = "SeccionLabel"
        SeccionLabel.Size = New System.Drawing.Size(49, 13)
        SeccionLabel.TabIndex = 18
        SeccionLabel.Text = "Seccion:"
        '
        'IdArticulo
        '
        Me.IdArticulo.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ArticuloBindingSource, "IdArticulo", True))
        Me.IdArticulo.Location = New System.Drawing.Point(104, 40)
        Me.IdArticulo.Name = "IdArticulo"
        Me.IdArticulo.ReadOnly = True
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
        Me.Codigo.Location = New System.Drawing.Point(104, 94)
        Me.Codigo.Name = "Codigo"
        Me.Codigo.Size = New System.Drawing.Size(315, 20)
        Me.Codigo.TabIndex = 2
        '
        'CodBarra
        '
        Me.CodBarra.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ArticuloBindingSource, "CodBarra", True))
        Me.CodBarra.Location = New System.Drawing.Point(104, 118)
        Me.CodBarra.Name = "CodBarra"
        Me.CodBarra.Size = New System.Drawing.Size(315, 20)
        Me.CodBarra.TabIndex = 3
        '
        'Nombre
        '
        Me.Nombre.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ArticuloBindingSource, "Nombre", True))
        Me.Nombre.Location = New System.Drawing.Point(104, 68)
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Size = New System.Drawing.Size(315, 20)
        Me.Nombre.TabIndex = 1
        '
        'AlicuotaIVA
        '
        Me.AlicuotaIVA.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ArticuloBindingSource, "AlicIVA.AlicuotaIVA", True))
        Me.AlicuotaIVA.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.ArticuloBindingSource, "AlicIVA", True))
        Me.AlicuotaIVA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.AlicuotaIVA.FormattingEnabled = True
        Me.AlicuotaIVA.Location = New System.Drawing.Point(104, 144)
        Me.AlicuotaIVA.Name = "AlicuotaIVA"
        Me.AlicuotaIVA.Size = New System.Drawing.Size(315, 21)
        Me.AlicuotaIVA.TabIndex = 4
        '
        'Baja
        '
        Me.Baja.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ArticuloBindingSource, "Baja", True))
        Me.Baja.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.ArticuloBindingSource, "Baja", True))
        Me.Baja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Baja.FormattingEnabled = True
        Me.Baja.ItemHeight = 13
        Me.Baja.Items.AddRange(New Object() {"NO", "SI"})
        Me.Baja.Location = New System.Drawing.Point(104, 171)
        Me.Baja.Name = "Baja"
        Me.Baja.Size = New System.Drawing.Size(315, 21)
        Me.Baja.TabIndex = 5
        '
        'Seccion
        '
        Me.Seccion.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ArticuloBindingSource, "Seccion.Seccion", True))
        Me.Seccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Seccion.FormattingEnabled = True
        Me.Seccion.ItemHeight = 13
        Me.Seccion.Location = New System.Drawing.Point(104, 198)
        Me.Seccion.Name = "Seccion"
        Me.Seccion.Size = New System.Drawing.Size(315, 21)
        Me.Seccion.TabIndex = 6
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Guardar, Me.Nuevo, Me.Buscar, Me.Limpiar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(431, 25)
        Me.ToolStrip1.TabIndex = 25
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'Guardar
        '
        Me.Guardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Guardar.Image = CType(resources.GetObject("Guardar.Image"), System.Drawing.Image)
        Me.Guardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Guardar.Name = "Guardar"
        Me.Guardar.Size = New System.Drawing.Size(23, 22)
        Me.Guardar.Text = "Guardar Cambios"
        '
        'Nuevo
        '
        Me.Nuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Nuevo.Image = CType(resources.GetObject("Nuevo.Image"), System.Drawing.Image)
        Me.Nuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Nuevo.Name = "Nuevo"
        Me.Nuevo.Size = New System.Drawing.Size(23, 22)
        Me.Nuevo.Text = "Nuevo"
        '
        'Buscar
        '
        Me.Buscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Buscar.Image = CType(resources.GetObject("Buscar.Image"), System.Drawing.Image)
        Me.Buscar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Buscar.Name = "Buscar"
        Me.Buscar.Size = New System.Drawing.Size(23, 22)
        Me.Buscar.Text = "Buscar"
        '
        'Limpiar
        '
        Me.Limpiar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Limpiar.Image = CType(resources.GetObject("Limpiar.Image"), System.Drawing.Image)
        Me.Limpiar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Limpiar.Name = "Limpiar"
        Me.Limpiar.Size = New System.Drawing.Size(23, 22)
        Me.Limpiar.Text = "Limpiar"
        '
        'FrmArticulos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(431, 232)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(SeccionLabel)
        Me.Controls.Add(Me.Seccion)
        Me.Controls.Add(BajaLabel)
        Me.Controls.Add(Me.Baja)
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
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmArticulos"
        CType(Me.ArticuloBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ArticuloBindingSource As BindingSource
    Friend WithEvents IdArticulo As TextBox
    Friend WithEvents Codigo As TextBox
    Friend WithEvents CodBarra As TextBox
    Friend WithEvents Nombre As TextBox
    Friend WithEvents AlicuotaIVA As ComboBox
    Friend WithEvents Baja As ComboBox
    Friend WithEvents Seccion As ComboBox
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents Guardar As ToolStripButton
    Friend WithEvents Nuevo As ToolStripButton
    Friend WithEvents Buscar As ToolStripButton
    Friend WithEvents Limpiar As ToolStripButton
End Class
