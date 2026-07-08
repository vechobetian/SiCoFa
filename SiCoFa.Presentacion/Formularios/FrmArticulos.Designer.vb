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
        Dim LblIdArticulo As System.Windows.Forms.Label
        Dim LblNTroquel As System.Windows.Forms.Label
        Dim LblCodBarras As System.Windows.Forms.Label
        Dim LblNombre As System.Windows.Forms.Label
        Dim LblAlicuotaIVA As System.Windows.Forms.Label
        Dim LblBaja As System.Windows.Forms.Label
        Dim LblSeccion As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim LblTipoVenta As System.Windows.Forms.Label
        Dim LblLaborarorio As System.Windows.Forms.Label
        Dim LblMonodroba As System.Windows.Forms.Label
        Dim LblAccionFarmacologica As System.Windows.Forms.Label
        Dim LblTipoControl As System.Windows.Forms.Label
        Dim LblHeladera As System.Windows.Forms.Label
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
        LblIdArticulo = New System.Windows.Forms.Label()
        LblNTroquel = New System.Windows.Forms.Label()
        LblCodBarras = New System.Windows.Forms.Label()
        LblNombre = New System.Windows.Forms.Label()
        LblAlicuotaIVA = New System.Windows.Forms.Label()
        LblBaja = New System.Windows.Forms.Label()
        LblSeccion = New System.Windows.Forms.Label()
        Label1 = New System.Windows.Forms.Label()
        LblTipoVenta = New System.Windows.Forms.Label()
        LblLaborarorio = New System.Windows.Forms.Label()
        LblMonodroba = New System.Windows.Forms.Label()
        LblAccionFarmacologica = New System.Windows.Forms.Label()
        LblTipoControl = New System.Windows.Forms.Label()
        LblHeladera = New System.Windows.Forms.Label()
        CType(Me.ArticuloBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblIdArticulo
        '
        LblIdArticulo.AutoSize = True
        LblIdArticulo.Location = New System.Drawing.Point(10, 43)
        LblIdArticulo.Name = "LblIdArticulo"
        LblIdArticulo.Size = New System.Drawing.Size(57, 13)
        LblIdArticulo.TabIndex = 1
        LblIdArticulo.Text = "Id Articulo:"
        '
        'LblNTroquel
        '
        LblNTroquel.AutoSize = True
        LblNTroquel.Location = New System.Drawing.Point(10, 95)
        LblNTroquel.Name = "LblNTroquel"
        LblNTroquel.Size = New System.Drawing.Size(46, 13)
        LblNTroquel.TabIndex = 2
        LblNTroquel.Text = "Troquel:"
        '
        'LblCodBarras
        '
        LblCodBarras.AutoSize = True
        LblCodBarras.Location = New System.Drawing.Point(10, 121)
        LblCodBarras.Name = "LblCodBarras"
        LblCodBarras.Size = New System.Drawing.Size(62, 13)
        LblCodBarras.TabIndex = 4
        LblCodBarras.Text = "Cod Barras:"
        '
        'LblNombre
        '
        LblNombre.AutoSize = True
        LblNombre.Location = New System.Drawing.Point(10, 69)
        LblNombre.Name = "LblNombre"
        LblNombre.Size = New System.Drawing.Size(47, 13)
        LblNombre.TabIndex = 6
        LblNombre.Text = "Nombre:"
        '
        'LblAlicuotaIVA
        '
        LblAlicuotaIVA.AutoSize = True
        LblAlicuotaIVA.Location = New System.Drawing.Point(10, 174)
        LblAlicuotaIVA.Name = "LblAlicuotaIVA"
        LblAlicuotaIVA.Size = New System.Drawing.Size(68, 13)
        LblAlicuotaIVA.TabIndex = 8
        LblAlicuotaIVA.Text = "Alicuota IVA:"
        '
        'LblBaja
        '
        LblBaja.AutoSize = True
        LblBaja.Location = New System.Drawing.Point(12, 360)
        LblBaja.Name = "LblBaja"
        LblBaja.Size = New System.Drawing.Size(31, 13)
        LblBaja.TabIndex = 16
        LblBaja.Text = "Baja:"
        '
        'LblSeccion
        '
        LblSeccion.AutoSize = True
        LblSeccion.Location = New System.Drawing.Point(10, 387)
        LblSeccion.Name = "LblSeccion"
        LblSeccion.Size = New System.Drawing.Size(49, 13)
        LblSeccion.TabIndex = 18
        LblSeccion.Text = "Seccion:"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(10, 147)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(62, 13)
        Label1.TabIndex = 33
        Label1.Text = "Tipo Venta:"
        '
        'LblTipoVenta
        '
        LblTipoVenta.AutoSize = True
        LblTipoVenta.Location = New System.Drawing.Point(10, 201)
        LblTipoVenta.Name = "LblTipoVenta"
        LblTipoVenta.Size = New System.Drawing.Size(88, 13)
        LblTipoVenta.TabIndex = 34
        LblTipoVenta.Text = "Tamaño Envase:"
        '
        'LblLaborarorio
        '
        LblLaborarorio.AutoSize = True
        LblLaborarorio.Location = New System.Drawing.Point(10, 228)
        LblLaborarorio.Name = "LblLaborarorio"
        LblLaborarorio.Size = New System.Drawing.Size(63, 13)
        LblLaborarorio.TabIndex = 35
        LblLaborarorio.Text = "Laboratorio:"
        '
        'LblMonodroba
        '
        LblMonodroba.AutoSize = True
        LblMonodroba.Location = New System.Drawing.Point(10, 254)
        LblMonodroba.Name = "LblMonodroba"
        LblMonodroba.Size = New System.Drawing.Size(64, 13)
        LblMonodroba.TabIndex = 36
        LblMonodroba.Text = "Monodroga:"
        '
        'LblAccionFarmacologica
        '
        LblAccionFarmacologica.AutoSize = True
        LblAccionFarmacologica.Location = New System.Drawing.Point(10, 280)
        LblAccionFarmacologica.Name = "LblAccionFarmacologica"
        LblAccionFarmacologica.Size = New System.Drawing.Size(75, 13)
        LblAccionFarmacologica.TabIndex = 37
        LblAccionFarmacologica.Text = "Acción Farma:"
        '
        'LblTipoControl
        '
        LblTipoControl.AutoSize = True
        LblTipoControl.Location = New System.Drawing.Point(11, 306)
        LblTipoControl.Name = "LblTipoControl"
        LblTipoControl.Size = New System.Drawing.Size(67, 13)
        LblTipoControl.TabIndex = 38
        LblTipoControl.Text = "Tipo Control:"
        '
        'LblHeladera
        '
        LblHeladera.AutoSize = True
        LblHeladera.Location = New System.Drawing.Point(10, 333)
        LblHeladera.Name = "LblHeladera"
        LblHeladera.Size = New System.Drawing.Size(53, 13)
        LblHeladera.TabIndex = 39
        LblHeladera.Text = "Heladera:"
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
        Me.TxtNTroquel.Location = New System.Drawing.Point(104, 92)
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
        Me.TxtNombre.Location = New System.Drawing.Point(104, 66)
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
        Me.CmbAlicuotaIVA.TabIndex = 5
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
        Me.CmbSeccion.TabIndex = 13
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
        Me.CmdBaja.TabIndex = 12
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
        Me.CmbTipoVenta.TabIndex = 4
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
        Me.CmbTamanioEnvase.TabIndex = 6
        '
        'TxtLaboratorio
        '
        Me.TxtLaboratorio.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ArticuloBindingSource, "Nombre", True))
        Me.TxtLaboratorio.Location = New System.Drawing.Point(104, 225)
        Me.TxtLaboratorio.Name = "TxtLaboratorio"
        Me.TxtLaboratorio.Size = New System.Drawing.Size(315, 20)
        Me.TxtLaboratorio.TabIndex = 7
        '
        'TxtMonodroga
        '
        Me.TxtMonodroga.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ArticuloBindingSource, "Nombre", True))
        Me.TxtMonodroga.Location = New System.Drawing.Point(104, 251)
        Me.TxtMonodroga.Name = "TxtMonodroga"
        Me.TxtMonodroga.Size = New System.Drawing.Size(315, 20)
        Me.TxtMonodroga.TabIndex = 8
        '
        'TxtAccionFarmacologica
        '
        Me.TxtAccionFarmacologica.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ArticuloBindingSource, "Nombre", True))
        Me.TxtAccionFarmacologica.Location = New System.Drawing.Point(104, 277)
        Me.TxtAccionFarmacologica.Name = "TxtAccionFarmacologica"
        Me.TxtAccionFarmacologica.Size = New System.Drawing.Size(315, 20)
        Me.TxtAccionFarmacologica.TabIndex = 9
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
        Me.CmbTipoControl.TabIndex = 10
        '
        'CmbHeladera
        '
        Me.CmbHeladera.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ArticuloBindingSource, "AlicuotaIVA", True))
        Me.CmbHeladera.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.ArticuloBindingSource, "AlicuotaIVA", True))
        Me.CmbHeladera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbHeladera.FormattingEnabled = True
        Me.CmbHeladera.Items.AddRange(New Object() {"NO", "SI"})
        Me.CmbHeladera.Location = New System.Drawing.Point(104, 330)
        Me.CmbHeladera.Name = "CmbHeladera"
        Me.CmbHeladera.Size = New System.Drawing.Size(315, 21)
        Me.CmbHeladera.TabIndex = 11
        '
        'FrmArticulos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(431, 416)
        Me.Controls.Add(LblHeladera)
        Me.Controls.Add(LblTipoControl)
        Me.Controls.Add(LblAccionFarmacologica)
        Me.Controls.Add(LblMonodroba)
        Me.Controls.Add(LblLaborarorio)
        Me.Controls.Add(LblTipoVenta)
        Me.Controls.Add(Label1)
        Me.Controls.Add(Me.CmbHeladera)
        Me.Controls.Add(Me.CmbTipoControl)
        Me.Controls.Add(Me.TxtAccionFarmacologica)
        Me.Controls.Add(Me.TxtMonodroga)
        Me.Controls.Add(Me.TxtLaboratorio)
        Me.Controls.Add(Me.CmbTamanioEnvase)
        Me.Controls.Add(Me.CmbTipoVenta)
        Me.Controls.Add(Me.CmdBaja)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(LblSeccion)
        Me.Controls.Add(Me.CmbSeccion)
        Me.Controls.Add(LblBaja)
        Me.Controls.Add(LblAlicuotaIVA)
        Me.Controls.Add(Me.CmbAlicuotaIVA)
        Me.Controls.Add(LblNombre)
        Me.Controls.Add(Me.TxtNombre)
        Me.Controls.Add(LblCodBarras)
        Me.Controls.Add(Me.TxtCodBarras)
        Me.Controls.Add(LblNTroquel)
        Me.Controls.Add(Me.TxtNTroquel)
        Me.Controls.Add(LblIdArticulo)
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
