<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmFraccionables
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
        Dim LblIdArticulo As System.Windows.Forms.Label
        Dim LblNombre As System.Windows.Forms.Label
        Dim LblFraccionable As System.Windows.Forms.Label
        Dim LblRegargo As System.Windows.Forms.Label
        Dim LblUnidades As System.Windows.Forms.Label
        Dim LblDFrac As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFraccionables))
        Me.TxtIdArticulo = New System.Windows.Forms.TextBox()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.Guardar = New System.Windows.Forms.ToolStripButton()
        Me.Buscar = New System.Windows.Forms.ToolStripButton()
        Me.Limpiar = New System.Windows.Forms.ToolStripButton()
        Me.UcFraccionable = New SiCoFa.Presentacion.UcSelectorUniversal()
        Me.TxtRecargo = New System.Windows.Forms.TextBox()
        Me.TxtUDiv = New System.Windows.Forms.TextBox()
        Me.TxtDFrac = New System.Windows.Forms.TextBox()
        LblIdArticulo = New System.Windows.Forms.Label()
        LblNombre = New System.Windows.Forms.Label()
        LblFraccionable = New System.Windows.Forms.Label()
        LblRegargo = New System.Windows.Forms.Label()
        LblUnidades = New System.Windows.Forms.Label()
        LblDFrac = New System.Windows.Forms.Label()
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
        'LblNombre
        '
        LblNombre.AutoSize = True
        LblNombre.Location = New System.Drawing.Point(10, 69)
        LblNombre.Name = "LblNombre"
        LblNombre.Size = New System.Drawing.Size(47, 13)
        LblNombre.TabIndex = 6
        LblNombre.Text = "Nombre:"
        '
        'LblFraccionable
        '
        LblFraccionable.AutoSize = True
        LblFraccionable.Location = New System.Drawing.Point(10, 95)
        LblFraccionable.Name = "LblFraccionable"
        LblFraccionable.Size = New System.Drawing.Size(71, 13)
        LblFraccionable.TabIndex = 39
        LblFraccionable.Text = "Fraccionable:"
        '
        'LblRegargo
        '
        LblRegargo.AutoSize = True
        LblRegargo.Location = New System.Drawing.Point(10, 171)
        LblRegargo.Name = "LblRegargo"
        LblRegargo.Size = New System.Drawing.Size(51, 13)
        LblRegargo.TabIndex = 4
        LblRegargo.Text = "Recargo:"
        '
        'LblUnidades
        '
        LblUnidades.AutoSize = True
        LblUnidades.Location = New System.Drawing.Point(10, 121)
        LblUnidades.Name = "LblUnidades"
        LblUnidades.Size = New System.Drawing.Size(55, 13)
        LblUnidades.TabIndex = 2
        LblUnidades.Text = "Unidades:"
        '
        'LblDFrac
        '
        LblDFrac.AutoSize = True
        LblDFrac.Location = New System.Drawing.Point(10, 147)
        LblDFrac.Name = "LblDFrac"
        LblDFrac.Size = New System.Drawing.Size(66, 13)
        LblDFrac.TabIndex = 40
        LblDFrac.Text = "Descripcion:"
        '
        'TxtIdArticulo
        '
        Me.TxtIdArticulo.Location = New System.Drawing.Point(104, 40)
        Me.TxtIdArticulo.Name = "TxtIdArticulo"
        Me.TxtIdArticulo.ReadOnly = True
        Me.TxtIdArticulo.Size = New System.Drawing.Size(315, 20)
        Me.TxtIdArticulo.TabIndex = 0
        Me.TxtIdArticulo.TabStop = False
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(104, 66)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(315, 20)
        Me.TxtNombre.TabIndex = 1
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Guardar, Me.Buscar, Me.Limpiar})
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
        'UcFraccionable
        '
        Me.UcFraccionable.BuscarConTextoVacio = False
        Me.UcFraccionable.Descripcion = ""
        Me.UcFraccionable.HeaderDescripcion = "Descripción"
        Me.UcFraccionable.Id = Nothing
        Me.UcFraccionable.IdNuevo = Nothing
        Me.UcFraccionable.Location = New System.Drawing.Point(104, 92)
        Me.UcFraccionable.Name = "UcFraccionable"
        Me.UcFraccionable.NombrePropiedadDescripcion = Nothing
        Me.UcFraccionable.NombrePropiedadId = Nothing
        Me.UcFraccionable.Objetos = Nothing
        Me.UcFraccionable.PermitirNuevo = False
        Me.UcFraccionable.PermitirVacio = True
        Me.UcFraccionable.Size = New System.Drawing.Size(315, 20)
        Me.UcFraccionable.SoloLectura = False
        Me.UcFraccionable.TabIndex = 2
        Me.UcFraccionable.TextoPredeterminado = ""
        Me.UcFraccionable.TituloSelector = "Selección"
        Me.UcFraccionable.ValorPredeterminado = Nothing
        '
        'TxtRecargo
        '
        Me.TxtRecargo.Location = New System.Drawing.Point(104, 168)
        Me.TxtRecargo.Name = "TxtRecargo"
        Me.TxtRecargo.Size = New System.Drawing.Size(315, 20)
        Me.TxtRecargo.TabIndex = 5
        '
        'TxtUDiv
        '
        Me.TxtUDiv.Location = New System.Drawing.Point(104, 118)
        Me.TxtUDiv.Name = "TxtUDiv"
        Me.TxtUDiv.Size = New System.Drawing.Size(315, 20)
        Me.TxtUDiv.TabIndex = 3
        '
        'TxtDFrac
        '
        Me.TxtDFrac.Location = New System.Drawing.Point(104, 144)
        Me.TxtDFrac.Name = "TxtDFrac"
        Me.TxtDFrac.Size = New System.Drawing.Size(315, 20)
        Me.TxtDFrac.TabIndex = 4
        '
        'FrmFraccionables
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(431, 204)
        Me.Controls.Add(LblDFrac)
        Me.Controls.Add(Me.TxtDFrac)
        Me.Controls.Add(Me.UcFraccionable)
        Me.Controls.Add(LblFraccionable)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(LblNombre)
        Me.Controls.Add(Me.TxtNombre)
        Me.Controls.Add(LblRegargo)
        Me.Controls.Add(Me.TxtRecargo)
        Me.Controls.Add(LblUnidades)
        Me.Controls.Add(Me.TxtUDiv)
        Me.Controls.Add(LblIdArticulo)
        Me.Controls.Add(Me.TxtIdArticulo)
        Me.Name = "FrmFraccionables"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmArticulos"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtIdArticulo As TextBox
    Friend WithEvents TxtNombre As TextBox
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents Guardar As ToolStripButton
    Friend WithEvents Buscar As ToolStripButton
    Friend WithEvents Limpiar As ToolStripButton
    Friend WithEvents UcFraccionable As UcSelectorUniversal
    Friend WithEvents TxtRecargo As TextBox
    Friend WithEvents TxtUDiv As TextBox
    Friend WithEvents TxtDFrac As TextBox
End Class
