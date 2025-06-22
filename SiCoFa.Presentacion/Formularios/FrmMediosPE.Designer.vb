<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMediosPE
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
        Dim IdMPELabel As System.Windows.Forms.Label
        Dim BajaLabel As System.Windows.Forms.Label
        Dim DescripcionLabel As System.Windows.Forms.Label
        Dim CuentaBancariaLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMediosPE))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.Guardar = New System.Windows.Forms.ToolStripButton()
        Me.Nuevo = New System.Windows.Forms.ToolStripButton()
        Me.Buscar = New System.Windows.Forms.ToolStripButton()
        Me.Limpiar = New System.Windows.Forms.ToolStripButton()
        Me.txtIdMPE = New System.Windows.Forms.TextBox()
        Me.cmbBaja = New System.Windows.Forms.ComboBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.cmbCuentaBancaria = New System.Windows.Forms.ComboBox()
        IdMPELabel = New System.Windows.Forms.Label()
        BajaLabel = New System.Windows.Forms.Label()
        DescripcionLabel = New System.Windows.Forms.Label()
        CuentaBancariaLabel = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'IdMPELabel
        '
        IdMPELabel.AutoSize = True
        IdMPELabel.Location = New System.Drawing.Point(20, 31)
        IdMPELabel.Name = "IdMPELabel"
        IdMPELabel.Size = New System.Drawing.Size(45, 13)
        IdMPELabel.TabIndex = 32
        IdMPELabel.Text = "Id MPE:"
        '
        'BajaLabel
        '
        BajaLabel.AutoSize = True
        BajaLabel.Location = New System.Drawing.Point(20, 110)
        BajaLabel.Name = "BajaLabel"
        BajaLabel.Size = New System.Drawing.Size(31, 13)
        BajaLabel.TabIndex = 35
        BajaLabel.Text = "Baja:"
        '
        'DescripcionLabel
        '
        DescripcionLabel.AutoSize = True
        DescripcionLabel.Location = New System.Drawing.Point(20, 57)
        DescripcionLabel.Name = "DescripcionLabel"
        DescripcionLabel.Size = New System.Drawing.Size(66, 13)
        DescripcionLabel.TabIndex = 36
        DescripcionLabel.Text = "Descripcion:"
        '
        'CuentaBancariaLabel
        '
        CuentaBancariaLabel.AutoSize = True
        CuentaBancariaLabel.Location = New System.Drawing.Point(20, 83)
        CuentaBancariaLabel.Name = "CuentaBancariaLabel"
        CuentaBancariaLabel.Size = New System.Drawing.Size(71, 13)
        CuentaBancariaLabel.TabIndex = 38
        CuentaBancariaLabel.Text = "Cta.Bancaria:"
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
        'txtIdMPE
        '
        Me.txtIdMPE.Location = New System.Drawing.Point(95, 28)
        Me.txtIdMPE.Name = "txtIdMPE"
        Me.txtIdMPE.ReadOnly = True
        Me.txtIdMPE.Size = New System.Drawing.Size(265, 20)
        Me.txtIdMPE.TabIndex = 0
        Me.txtIdMPE.TabStop = False
        '
        'cmbBaja
        '
        Me.cmbBaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBaja.FormattingEnabled = True
        Me.cmbBaja.Items.AddRange(New Object() {"NO", "SI"})
        Me.cmbBaja.Location = New System.Drawing.Point(95, 107)
        Me.cmbBaja.Name = "cmbBaja"
        Me.cmbBaja.Size = New System.Drawing.Size(265, 21)
        Me.cmbBaja.TabIndex = 3
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(95, 54)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(265, 20)
        Me.txtDescripcion.TabIndex = 1
        '
        'cmbCuentaBancaria
        '
        Me.cmbCuentaBancaria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCuentaBancaria.FormattingEnabled = True
        Me.cmbCuentaBancaria.ItemHeight = 13
        Me.cmbCuentaBancaria.Location = New System.Drawing.Point(95, 80)
        Me.cmbCuentaBancaria.Name = "cmbCuentaBancaria"
        Me.cmbCuentaBancaria.Size = New System.Drawing.Size(265, 21)
        Me.cmbCuentaBancaria.TabIndex = 2
        '
        'FrmMediosPE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 153)
        Me.Controls.Add(CuentaBancariaLabel)
        Me.Controls.Add(Me.cmbCuentaBancaria)
        Me.Controls.Add(Me.cmbBaja)
        Me.Controls.Add(BajaLabel)
        Me.Controls.Add(DescripcionLabel)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(IdMPELabel)
        Me.Controls.Add(Me.txtIdMPE)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrmMediosPE"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Medios de Pago Electronico"
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
    Friend WithEvents txtIdMPE As TextBox
    Friend WithEvents cmbBaja As ComboBox
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents cmbCuentaBancaria As ComboBox
End Class
