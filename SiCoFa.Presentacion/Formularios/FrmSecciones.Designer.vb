<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmSecciones
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
        Dim EstablecerPrecioLabel As System.Windows.Forms.Label
        Dim IdSeccionLabel As System.Windows.Forms.Label
        Dim SeccionLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSecciones))
        Me.EstablecerPrecio = New System.Windows.Forms.ComboBox()
        Me.IdSeccion = New System.Windows.Forms.TextBox()
        Me.Seccion = New System.Windows.Forms.TextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.Guardar = New System.Windows.Forms.ToolStripButton()
        Me.Nuevo = New System.Windows.Forms.ToolStripButton()
        Me.Buscar = New System.Windows.Forms.ToolStripButton()
        Me.Limpiar = New System.Windows.Forms.ToolStripButton()
        Me.SeccionBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        EstablecerPrecioLabel = New System.Windows.Forms.Label()
        IdSeccionLabel = New System.Windows.Forms.Label()
        SeccionLabel = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.SeccionBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EstablecerPrecioLabel
        '
        EstablecerPrecioLabel.AutoSize = True
        EstablecerPrecioLabel.Location = New System.Drawing.Point(8, 83)
        EstablecerPrecioLabel.Name = "EstablecerPrecioLabel"
        EstablecerPrecioLabel.Size = New System.Drawing.Size(93, 13)
        EstablecerPrecioLabel.TabIndex = 1
        EstablecerPrecioLabel.Text = "Establecer Precio:"
        '
        'IdSeccionLabel
        '
        IdSeccionLabel.AutoSize = True
        IdSeccionLabel.Location = New System.Drawing.Point(8, 31)
        IdSeccionLabel.Name = "IdSeccionLabel"
        IdSeccionLabel.Size = New System.Drawing.Size(61, 13)
        IdSeccionLabel.TabIndex = 3
        IdSeccionLabel.Text = "Id Seccion:"
        '
        'SeccionLabel
        '
        SeccionLabel.AutoSize = True
        SeccionLabel.Location = New System.Drawing.Point(8, 58)
        SeccionLabel.Name = "SeccionLabel"
        SeccionLabel.Size = New System.Drawing.Size(49, 13)
        SeccionLabel.TabIndex = 4
        SeccionLabel.Text = "Seccion:"
        '
        'EstablecerPrecio
        '
        Me.EstablecerPrecio.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SeccionBindingSource1, "EstablecerPrecio", True))
        Me.EstablecerPrecio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.EstablecerPrecio.FormattingEnabled = True
        Me.EstablecerPrecio.ItemHeight = 13
        Me.EstablecerPrecio.Items.AddRange(New Object() {"NO", "SI"})
        Me.EstablecerPrecio.Location = New System.Drawing.Point(107, 80)
        Me.EstablecerPrecio.Name = "EstablecerPrecio"
        Me.EstablecerPrecio.Size = New System.Drawing.Size(265, 21)
        Me.EstablecerPrecio.TabIndex = 2
        '
        'IdSeccion
        '
        Me.IdSeccion.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SeccionBindingSource1, "IdSeccion", True))
        Me.IdSeccion.Location = New System.Drawing.Point(107, 28)
        Me.IdSeccion.Name = "IdSeccion"
        Me.IdSeccion.ReadOnly = True
        Me.IdSeccion.Size = New System.Drawing.Size(265, 20)
        Me.IdSeccion.TabIndex = 0
        Me.IdSeccion.TabStop = False
        '
        'Seccion
        '
        Me.Seccion.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SeccionBindingSource1, "Seccion", True))
        Me.Seccion.Location = New System.Drawing.Point(107, 55)
        Me.Seccion.Name = "Seccion"
        Me.Seccion.Size = New System.Drawing.Size(265, 20)
        Me.Seccion.TabIndex = 1
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Guardar, Me.Nuevo, Me.Buscar, Me.Limpiar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(384, 25)
        Me.ToolStrip1.TabIndex = 26
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
        'SeccionBindingSource1
        '
        Me.SeccionBindingSource1.DataSource = GetType(SiCoFa.Entidades.Seccion)
        '
        'FrmSecciones
        '
        Me.ClientSize = New System.Drawing.Size(384, 112)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(SeccionLabel)
        Me.Controls.Add(Me.Seccion)
        Me.Controls.Add(EstablecerPrecioLabel)
        Me.Controls.Add(Me.EstablecerPrecio)
        Me.Controls.Add(IdSeccionLabel)
        Me.Controls.Add(Me.IdSeccion)
        Me.Name = "FrmSecciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.SeccionBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SeccionBindingSource As BindingSource
    Friend WithEvents EstablecerPrecioComboBox As ComboBox
    Friend WithEvents IdSeccionTextBox As TextBox
    Friend WithEvents SeccionBindingSource1 As BindingSource
    Friend WithEvents EstablecerPrecio As ComboBox
    Friend WithEvents IdSeccion As TextBox
    Friend WithEvents Seccion As TextBox
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents Guardar As ToolStripButton
    Friend WithEvents Nuevo As ToolStripButton
    Friend WithEvents Buscar As ToolStripButton
    Friend WithEvents Limpiar As ToolStripButton
End Class
