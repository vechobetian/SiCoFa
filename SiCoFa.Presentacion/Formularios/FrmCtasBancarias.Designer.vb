<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCtasBancarias
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
        Dim DescripcionLabel As System.Windows.Forms.Label
        Dim FechaAltaLabel As System.Windows.Forms.Label
        Dim IdCBLabel As System.Windows.Forms.Label
        Dim NumCuentaLabel As System.Windows.Forms.Label
        Dim BajaLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCtasBancarias))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.Guardar = New System.Windows.Forms.ToolStripButton()
        Me.Nuevo = New System.Windows.Forms.ToolStripButton()
        Me.Buscar = New System.Windows.Forms.ToolStripButton()
        Me.Limpiar = New System.Windows.Forms.ToolStripButton()
        Me.DescripcionTextBox = New System.Windows.Forms.TextBox()
        Me.FechaAltaTextBox = New System.Windows.Forms.TextBox()
        Me.IdCBTextBox = New System.Windows.Forms.TextBox()
        Me.NumCuentaTextBox = New System.Windows.Forms.TextBox()
        Me.BajaComboBox = New System.Windows.Forms.ComboBox()
        DescripcionLabel = New System.Windows.Forms.Label()
        FechaAltaLabel = New System.Windows.Forms.Label()
        IdCBLabel = New System.Windows.Forms.Label()
        NumCuentaLabel = New System.Windows.Forms.Label()
        BajaLabel = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DescripcionLabel
        '
        DescripcionLabel.AutoSize = True
        DescripcionLabel.Location = New System.Drawing.Point(18, 68)
        DescripcionLabel.Name = "DescripcionLabel"
        DescripcionLabel.Size = New System.Drawing.Size(66, 13)
        DescripcionLabel.TabIndex = 29
        DescripcionLabel.Text = "Descripcion:"
        '
        'FechaAltaLabel
        '
        FechaAltaLabel.AutoSize = True
        FechaAltaLabel.Location = New System.Drawing.Point(18, 121)
        FechaAltaLabel.Name = "FechaAltaLabel"
        FechaAltaLabel.Size = New System.Drawing.Size(61, 13)
        FechaAltaLabel.TabIndex = 31
        FechaAltaLabel.Text = "Fecha Alta:"
        '
        'IdCBLabel
        '
        IdCBLabel.AutoSize = True
        IdCBLabel.Location = New System.Drawing.Point(18, 42)
        IdCBLabel.Name = "IdCBLabel"
        IdCBLabel.Size = New System.Drawing.Size(36, 13)
        IdCBLabel.TabIndex = 33
        IdCBLabel.Text = "Id CB:"
        '
        'NumCuentaLabel
        '
        NumCuentaLabel.AutoSize = True
        NumCuentaLabel.Location = New System.Drawing.Point(18, 95)
        NumCuentaLabel.Name = "NumCuentaLabel"
        NumCuentaLabel.Size = New System.Drawing.Size(69, 13)
        NumCuentaLabel.TabIndex = 35
        NumCuentaLabel.Text = "Num Cuenta:"
        '
        'BajaLabel
        '
        BajaLabel.AutoSize = True
        BajaLabel.Location = New System.Drawing.Point(18, 147)
        BajaLabel.Name = "BajaLabel"
        BajaLabel.Size = New System.Drawing.Size(31, 13)
        BajaLabel.TabIndex = 27
        BajaLabel.Text = "Baja:"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Guardar, Me.Nuevo, Me.Buscar, Me.Limpiar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(384, 25)
        Me.ToolStrip1.TabIndex = 27
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
        'DescripcionTextBox
        '
        Me.DescripcionTextBox.Location = New System.Drawing.Point(93, 65)
        Me.DescripcionTextBox.Name = "DescripcionTextBox"
        Me.DescripcionTextBox.Size = New System.Drawing.Size(265, 20)
        Me.DescripcionTextBox.TabIndex = 1
        '
        'FechaAltaTextBox
        '
        Me.FechaAltaTextBox.Location = New System.Drawing.Point(93, 118)
        Me.FechaAltaTextBox.Name = "FechaAltaTextBox"
        Me.FechaAltaTextBox.ReadOnly = True
        Me.FechaAltaTextBox.Size = New System.Drawing.Size(265, 20)
        Me.FechaAltaTextBox.TabIndex = 3
        '
        'IdCBTextBox
        '
        Me.IdCBTextBox.Enabled = False
        Me.IdCBTextBox.Location = New System.Drawing.Point(93, 39)
        Me.IdCBTextBox.Name = "IdCBTextBox"
        Me.IdCBTextBox.ReadOnly = True
        Me.IdCBTextBox.Size = New System.Drawing.Size(265, 20)
        Me.IdCBTextBox.TabIndex = 0
        Me.IdCBTextBox.TabStop = False
        '
        'NumCuentaTextBox
        '
        Me.NumCuentaTextBox.Location = New System.Drawing.Point(93, 92)
        Me.NumCuentaTextBox.Name = "NumCuentaTextBox"
        Me.NumCuentaTextBox.Size = New System.Drawing.Size(265, 20)
        Me.NumCuentaTextBox.TabIndex = 2
        '
        'BajaComboBox
        '
        Me.BajaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.BajaComboBox.FormattingEnabled = True
        Me.BajaComboBox.Items.AddRange(New Object() {"NO", "SI"})
        Me.BajaComboBox.Location = New System.Drawing.Point(93, 144)
        Me.BajaComboBox.Name = "BajaComboBox"
        Me.BajaComboBox.Size = New System.Drawing.Size(265, 21)
        Me.BajaComboBox.TabIndex = 4
        '
        'FrmCtasBancarias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 184)
        Me.Controls.Add(Me.BajaComboBox)
        Me.Controls.Add(BajaLabel)
        Me.Controls.Add(DescripcionLabel)
        Me.Controls.Add(Me.DescripcionTextBox)
        Me.Controls.Add(FechaAltaLabel)
        Me.Controls.Add(Me.FechaAltaTextBox)
        Me.Controls.Add(IdCBLabel)
        Me.Controls.Add(Me.IdCBTextBox)
        Me.Controls.Add(NumCuentaLabel)
        Me.Controls.Add(Me.NumCuentaTextBox)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrmCtasBancarias"
        Me.Text = "FrmCtasBancarias"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents Guardar As ToolStripButton
    Friend WithEvents Nuevo As ToolStripButton
    Friend WithEvents Buscar As ToolStripButton
    Friend WithEvents Limpiar As ToolStripButton
    Friend WithEvents DescripcionTextBox As TextBox
    Friend WithEvents FechaAltaTextBox As TextBox
    Friend WithEvents IdCBTextBox As TextBox
    Friend WithEvents NumCuentaTextBox As TextBox
    Friend WithEvents BajaComboBox As ComboBox
End Class
