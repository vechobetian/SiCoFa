<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmArticulos
    'Inherits System.Windows.Forms.Form
    Inherits clsFrmBase

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
        Me.components = New System.ComponentModel.Container()
        Dim IdArticuloLabel As System.Windows.Forms.Label
        Dim NTroquelLabel As System.Windows.Forms.Label
        Dim CodBarrasLabel As System.Windows.Forms.Label
        Dim NombreLabel As System.Windows.Forms.Label
        Dim AlicuotaIVALabel As System.Windows.Forms.Label
        Dim BajaLabel As System.Windows.Forms.Label
        Dim SeccionLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmArticulos))
        Me.TxtIdArticulo = New System.Windows.Forms.TextBox()
        Me.ArticuloBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TxtNTroquel = New System.Windows.Forms.TextBox()
        Me.TxtCodBarras = New System.Windows.Forms.TextBox()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.CmbAlicuotaIVA = New System.Windows.Forms.ComboBox()
        Me.CmbSeccion = New System.Windows.Forms.ComboBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.Guardar = New System.Windows.Forms.ToolStripButton()
        Me.Nuevo = New System.Windows.Forms.ToolStripButton()
        Me.Buscar = New System.Windows.Forms.ToolStripButton()
        Me.Limpiar = New System.Windows.Forms.ToolStripButton()
        Me.CmdBaja = New System.Windows.Forms.ComboBox()
        Me.CmbTipoVenta = New System.Windows.Forms.ComboBox()
        Me.CmbTamanioEnvase = New System.Windows.Forms.ComboBox()
        Me.TxtLaboratorio = New System.Windows.Forms.TextBox()
        Me.TxtMonodroga = New System.Windows.Forms.TextBox()
        Me.TxtAccionFarmacologica = New System.Windows.Forms.TextBox()
        Me.CmbTipoControl = New System.Windows.Forms.ComboBox()
        Me.CmbHeladera = New System.Windows.Forms.ComboBox()
        IdArticuloLabel = New System.Windows.Forms.Label()
        NTroquelLabel = New System.Windows.Forms.Label()
        CodBarrasLabel = New System.Windows.Forms.Label()
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
        'NTroquelLabel
        '
        NTroquelLabel.AutoSize = True
        NTroquelLabel.Location = New System.Drawing.Point(10, 97)
        NTroquelLabel.Name = "NTroquelLabel"
        NTroquelLabel.Size = New System.Drawing.Size(46, 13)
        NTroquelLabel.TabIndex = 2
        NTroquelLabel.Text = "Troquel:"
        '
        'CodBarrasLabel
        '
        CodBarrasLabel.AutoSize = True
        CodBarrasLabel.Location = New System.Drawing.Point(10, 121)
        CodBarrasLabel.Name = "CodBarrasLabel"
        CodBarrasLabel.Size = New System.Drawing.Size(62, 13)
        CodBarrasLabel.TabIndex = 4
        CodBarrasLabel.Text = "Cod Barras:"
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
        AlicuotaIVALabel.Location = New System.Drawing.Point(10, 174)
        AlicuotaIVALabel.Name = "AlicuotaIVALabel"
        AlicuotaIVALabel.Size = New System.Drawing.Size(68, 13)
        AlicuotaIVALabel.TabIndex = 8
        AlicuotaIVALabel.Text = "Alicuota IVA:"
        '
        'BajaLabel
        '
        BajaLabel.AutoSize = True
        BajaLabel.Location = New System.Drawing.Point(10, 360)
        BajaLabel.Name = "BajaLabel"
        BajaLabel.Size = New System.Drawing.Size(31, 13)
        BajaLabel.TabIndex = 16
        BajaLabel.Text = "Baja:"
        '
        'SeccionLabel
        '
        SeccionLabel.AutoSize = True
        SeccionLabel.Location = New System.Drawing.Point(10, 387)
        SeccionLabel.Name = "SeccionLabel"
        SeccionLabel.Size = New System.Drawing.Size(49, 13)
        SeccionLabel.TabIndex = 18
        SeccionLabel.Text = "Seccion:"
        '
        'TxtIdArticulo
        '
        Me.TxtIdArticulo.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ArticuloBindingSource, "IdArticulo", True))
        Me.TxtIdArticulo.Location = New System.Drawing.Point(104, 40)
        Me.TxtIdArticulo.Name = "TxtIdArticulo"
        Me.TxtIdArticulo.ReadOnly = True
        Me.TxtIdArticulo.Size = New System.Drawing.Size(315, 20)
        Me.TxtIdArticulo.TabIndex = 0
        Me.TxtIdArticulo.TabStop = False
        '
        'ArticuloBindingSource
        '
        Me.ArticuloBindingSource.DataSource = GetType(SiCoFa.Entidades.Articulo)
        '
        'TxtNTroquel
        '
        Me.TxtNTroquel.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ArticuloBindingSource, "Codigo", True))
        Me.TxtNTroquel.Location = New System.Drawing.Point(104, 94)
        Me.TxtNTroquel.Name = "TxtNTroquel"
        Me.TxtNTroquel.Size = New System.Drawing.Size(315, 20)
        Me.TxtNTroquel.TabIndex = 2
        '
        'TxtCodBarras
        '
        Me.TxtCodBarras.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ArticuloBindingSource, "CodBarras", True))
        Me.TxtCodBarras.Location = New System.Drawing.Point(104, 118)
        Me.TxtCodBarras.Name = "TxtCodBarras"
        Me.TxtCodBarras.Size = New System.Drawing.Size(315, 20)
        Me.TxtCodBarras.TabIndex = 3
        '
        'TxtNombre
        '
        Me.TxtNombre.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ArticuloBindingSource, "Nombre", True))
        Me.TxtNombre.Location = New System.Drawing.Point(104, 68)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(315, 20)
        Me.TxtNombre.TabIndex = 1
        '
        'CmbAlicuotaIVA
        '
        Me.CmbAlicuotaIVA.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ArticuloBindingSource, "AlicuotaIVA", True))
        Me.CmbAlicuotaIVA.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.ArticuloBindingSource, "AlicuotaIVA", True))
        Me.CmbAlicuotaIVA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbAlicuotaIVA.FormattingEnabled = True
        Me.CmbAlicuotaIVA.Location = New System.Drawing.Point(104, 171)
        Me.CmbAlicuotaIVA.Name = "CmbAlicuotaIVA"
        Me.CmbAlicuotaIVA.Size = New System.Drawing.Size(315, 21)
        Me.CmbAlicuotaIVA.TabIndex = 4
        '
        'CmbSeccion
        '
        Me.CmbSeccion.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ArticuloBindingSource, "Seccion.Seccion", True))
        Me.CmbSeccion.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.ArticuloBindingSource, "Seccion", True))
        Me.CmbSeccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbSeccion.FormattingEnabled = True
        Me.CmbSeccion.ItemHeight = 13
        Me.CmbSeccion.Location = New System.Drawing.Point(104, 384)
        Me.CmbSeccion.Name = "CmbSeccion"
        Me.CmbSeccion.Size = New System.Drawing.Size(315, 21)
        Me.CmbSeccion.TabIndex = 6
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
        'CmdBaja
        '
        Me.CmdBaja.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ArticuloBindingSource, "Baja", True))
        Me.CmdBaja.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.ArticuloBindingSource, "Baja", True))
        Me.CmdBaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmdBaja.FormattingEnabled = True
        Me.CmdBaja.Items.AddRange(New Object() {"NO", "SI"})
        Me.CmdBaja.Location = New System.Drawing.Point(104, 357)
        Me.CmdBaja.Name = "CmdBaja"
        Me.CmdBaja.Size = New System.Drawing.Size(315, 21)
        Me.CmdBaja.TabIndex = 5
        '
        'CmbTipoVenta
        '
        Me.CmbTipoVenta.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ArticuloBindingSource, "AlicuotaIVA", True))
        Me.CmbTipoVenta.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.ArticuloBindingSource, "AlicuotaIVA", True))
        Me.CmbTipoVenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbTipoVenta.FormattingEnabled = True
        Me.CmbTipoVenta.Location = New System.Drawing.Point(104, 144)
        Me.CmbTipoVenta.Name = "CmbTipoVenta"
        Me.CmbTipoVenta.Size = New System.Drawing.Size(315, 21)
        Me.CmbTipoVenta.TabIndex = 26
        '
        'CmbTamanioEnvase
        '
        Me.CmbTamanioEnvase.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ArticuloBindingSource, "AlicuotaIVA", True))
        Me.CmbTamanioEnvase.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.ArticuloBindingSource, "AlicuotaIVA", True))
        Me.CmbTamanioEnvase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbTamanioEnvase.FormattingEnabled = True
        Me.CmbTamanioEnvase.Location = New System.Drawing.Point(104, 198)
        Me.CmbTamanioEnvase.Name = "CmbTamanioEnvase"
        Me.CmbTamanioEnvase.Size = New System.Drawing.Size(315, 21)
        Me.CmbTamanioEnvase.TabIndex = 27
        '
        'TxtLaboratorio
        '
        Me.TxtLaboratorio.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ArticuloBindingSource, "Nombre", True))
        Me.TxtLaboratorio.Location = New System.Drawing.Point(104, 225)
        Me.TxtLaboratorio.Name = "TxtLaboratorio"
        Me.TxtLaboratorio.Size = New System.Drawing.Size(315, 20)
        Me.TxtLaboratorio.TabIndex = 28
        '
        'TxtMonodroga
        '
        Me.TxtMonodroga.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ArticuloBindingSource, "Nombre", True))
        Me.TxtMonodroga.Location = New System.Drawing.Point(104, 251)
        Me.TxtMonodroga.Name = "TxtMonodroga"
        Me.TxtMonodroga.Size = New System.Drawing.Size(315, 20)
        Me.TxtMonodroga.TabIndex = 29
        '
        'TxtAccionFarmacologica
        '
        Me.TxtAccionFarmacologica.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ArticuloBindingSource, "Nombre", True))
        Me.TxtAccionFarmacologica.Location = New System.Drawing.Point(104, 277)
        Me.TxtAccionFarmacologica.Name = "TxtAccionFarmacologica"
        Me.TxtAccionFarmacologica.Size = New System.Drawing.Size(315, 20)
        Me.TxtAccionFarmacologica.TabIndex = 30
        '
        'CmbTipoControl
        '
        Me.CmbTipoControl.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ArticuloBindingSource, "AlicuotaIVA", True))
        Me.CmbTipoControl.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.ArticuloBindingSource, "AlicuotaIVA", True))
        Me.CmbTipoControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbTipoControl.FormattingEnabled = True
        Me.CmbTipoControl.Location = New System.Drawing.Point(104, 303)
        Me.CmbTipoControl.Name = "CmbTipoControl"
        Me.CmbTipoControl.Size = New System.Drawing.Size(315, 21)
        Me.CmbTipoControl.TabIndex = 31
        '
        'CmbHeladera
        '
        Me.CmbHeladera.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ArticuloBindingSource, "AlicuotaIVA", True))
        Me.CmbHeladera.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.ArticuloBindingSource, "AlicuotaIVA", True))
        Me.CmbHeladera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbHeladera.FormattingEnabled = True
        Me.CmbHeladera.Location = New System.Drawing.Point(104, 330)
        Me.CmbHeladera.Name = "CmbHeladera"
        Me.CmbHeladera.Size = New System.Drawing.Size(315, 21)
        Me.CmbHeladera.TabIndex = 32
        '
        'FrmArticulos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(431, 416)
        Me.Controls.Add(Me.CmbHeladera)
        Me.Controls.Add(Me.CmbTipoControl)
        Me.Controls.Add(Me.TxtAccionFarmacologica)
        Me.Controls.Add(Me.TxtMonodroga)
        Me.Controls.Add(Me.TxtLaboratorio)
        Me.Controls.Add(Me.CmbTamanioEnvase)
        Me.Controls.Add(Me.CmbTipoVenta)
        Me.Controls.Add(Me.CmdBaja)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(SeccionLabel)
        Me.Controls.Add(Me.CmbSeccion)
        Me.Controls.Add(BajaLabel)
        Me.Controls.Add(AlicuotaIVALabel)
        Me.Controls.Add(Me.CmbAlicuotaIVA)
        Me.Controls.Add(NombreLabel)
        Me.Controls.Add(Me.TxtNombre)
        Me.Controls.Add(CodBarrasLabel)
        Me.Controls.Add(Me.TxtCodBarras)
        Me.Controls.Add(NTroquelLabel)
        Me.Controls.Add(Me.TxtNTroquel)
        Me.Controls.Add(IdArticuloLabel)
        Me.Controls.Add(Me.TxtIdArticulo)
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
    Friend WithEvents TxtIdArticulo As TextBox
    Friend WithEvents TxtNTroquel As TextBox
    Friend WithEvents TxtCodBarras As TextBox
    Friend WithEvents TxtNombre As TextBox
    Friend WithEvents CmbAlicuotaIVA As ComboBox
    Friend WithEvents CmbSeccion As ComboBox
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents Guardar As ToolStripButton
    Friend WithEvents Nuevo As ToolStripButton
    Friend WithEvents Buscar As ToolStripButton
    Friend WithEvents Limpiar As ToolStripButton
    Friend WithEvents CmdBaja As ComboBox
    Friend WithEvents CmbTipoVenta As ComboBox
    Friend WithEvents CmbTamanioEnvase As ComboBox
    Friend WithEvents TxtLaboratorio As TextBox
    Friend WithEvents TxtMonodroga As TextBox
    Friend WithEvents TxtAccionFarmacologica As TextBox
    Friend WithEvents CmbTipoControl As ComboBox
    Friend WithEvents CmbHeladera As ComboBox
End Class
