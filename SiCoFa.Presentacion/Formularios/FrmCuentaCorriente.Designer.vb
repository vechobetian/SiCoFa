<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCuentaCorriente
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCuentaCorriente))
        Dim DescripcionLabel As System.Windows.Forms.Label
        Dim EstadoLabel As System.Windows.Forms.Label
        Dim FechaAltaLabel As System.Windows.Forms.Label
        Dim IdCCLabel As System.Windows.Forms.Label
        Dim LimiteCreditoLabel As System.Windows.Forms.Label
        Dim ObservacionesLabel As System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.Guardar = New System.Windows.Forms.ToolStripButton()
        Me.Nuevo = New System.Windows.Forms.ToolStripButton()
        Me.Descripcion = New System.Windows.Forms.TextBox()
        Me.Estado = New System.Windows.Forms.ComboBox()
        Me.FechaAlta = New System.Windows.Forms.TextBox()
        Me.IdCC = New System.Windows.Forms.TextBox()
        Me.LimiteCredito = New System.Windows.Forms.TextBox()
        Me.Observaciones = New System.Windows.Forms.TextBox()
        Me.CuentaCorrienteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        DescripcionLabel = New System.Windows.Forms.Label()
        EstadoLabel = New System.Windows.Forms.Label()
        FechaAltaLabel = New System.Windows.Forms.Label()
        IdCCLabel = New System.Windows.Forms.Label()
        LimiteCreditoLabel = New System.Windows.Forms.Label()
        ObservacionesLabel = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.CuentaCorrienteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Guardar, Me.Nuevo})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(394, 25)
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
        'DescripcionLabel
        '
        DescripcionLabel.AutoSize = True
        DescripcionLabel.Location = New System.Drawing.Point(16, 57)
        DescripcionLabel.Name = "DescripcionLabel"
        DescripcionLabel.Size = New System.Drawing.Size(66, 13)
        DescripcionLabel.TabIndex = 27
        DescripcionLabel.Text = "Descripcion:"
        '
        'Descripcion
        '
        Me.Descripcion.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CuentaCorrienteBindingSource, "Descripcion", True))
        Me.Descripcion.Location = New System.Drawing.Point(103, 54)
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.Size = New System.Drawing.Size(121, 20)
        Me.Descripcion.TabIndex = 28
        '
        'EstadoLabel
        '
        EstadoLabel.AutoSize = True
        EstadoLabel.Location = New System.Drawing.Point(16, 135)
        EstadoLabel.Name = "EstadoLabel"
        EstadoLabel.Size = New System.Drawing.Size(43, 13)
        EstadoLabel.TabIndex = 29
        EstadoLabel.Text = "Estado:"
        '
        'Estado
        '
        Me.Estado.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CuentaCorrienteBindingSource, "Estado", True))
        Me.Estado.FormattingEnabled = True
        Me.Estado.Location = New System.Drawing.Point(103, 132)
        Me.Estado.Name = "Estado"
        Me.Estado.Size = New System.Drawing.Size(121, 21)
        Me.Estado.TabIndex = 30
        '
        'FechaAltaLabel
        '
        FechaAltaLabel.AutoSize = True
        FechaAltaLabel.Location = New System.Drawing.Point(16, 109)
        FechaAltaLabel.Name = "FechaAltaLabel"
        FechaAltaLabel.Size = New System.Drawing.Size(61, 13)
        FechaAltaLabel.TabIndex = 31
        FechaAltaLabel.Text = "Fecha Alta:"
        '
        'FechaAlta
        '
        Me.FechaAlta.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CuentaCorrienteBindingSource, "FechaAlta", True))
        Me.FechaAlta.Location = New System.Drawing.Point(103, 106)
        Me.FechaAlta.Name = "FechaAlta"
        Me.FechaAlta.Size = New System.Drawing.Size(121, 20)
        Me.FechaAlta.TabIndex = 32
        '
        'IdCCLabel
        '
        IdCCLabel.AutoSize = True
        IdCCLabel.Location = New System.Drawing.Point(16, 31)
        IdCCLabel.Name = "IdCCLabel"
        IdCCLabel.Size = New System.Drawing.Size(36, 13)
        IdCCLabel.TabIndex = 33
        IdCCLabel.Text = "Id CC:"
        '
        'IdCC
        '
        Me.IdCC.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CuentaCorrienteBindingSource, "IdCC", True))
        Me.IdCC.Location = New System.Drawing.Point(103, 28)
        Me.IdCC.Name = "IdCC"
        Me.IdCC.Size = New System.Drawing.Size(121, 20)
        Me.IdCC.TabIndex = 34
        '
        'LimiteCreditoLabel
        '
        LimiteCreditoLabel.AutoSize = True
        LimiteCreditoLabel.Location = New System.Drawing.Point(16, 83)
        LimiteCreditoLabel.Name = "LimiteCreditoLabel"
        LimiteCreditoLabel.Size = New System.Drawing.Size(73, 13)
        LimiteCreditoLabel.TabIndex = 35
        LimiteCreditoLabel.Text = "Limite Credito:"
        '
        'LimiteCredito
        '
        Me.LimiteCredito.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CuentaCorrienteBindingSource, "LimiteCredito", True))
        Me.LimiteCredito.Location = New System.Drawing.Point(103, 80)
        Me.LimiteCredito.Name = "LimiteCredito"
        Me.LimiteCredito.Size = New System.Drawing.Size(121, 20)
        Me.LimiteCredito.TabIndex = 36
        '
        'ObservacionesLabel
        '
        ObservacionesLabel.AutoSize = True
        ObservacionesLabel.Location = New System.Drawing.Point(16, 162)
        ObservacionesLabel.Name = "ObservacionesLabel"
        ObservacionesLabel.Size = New System.Drawing.Size(81, 13)
        ObservacionesLabel.TabIndex = 37
        ObservacionesLabel.Text = "Observaciones:"
        '
        'Observaciones
        '
        Me.Observaciones.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CuentaCorrienteBindingSource, "Observaciones", True))
        Me.Observaciones.Location = New System.Drawing.Point(103, 159)
        Me.Observaciones.Name = "Observaciones"
        Me.Observaciones.Size = New System.Drawing.Size(121, 20)
        Me.Observaciones.TabIndex = 38
        '
        'CuentaCorrienteBindingSource
        '
        Me.CuentaCorrienteBindingSource.DataSource = GetType(SiCoFa.Entidades.CuentaCorriente)
        '
        'FrmCuentaCorriente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(394, 356)
        Me.Controls.Add(DescripcionLabel)
        Me.Controls.Add(Me.Descripcion)
        Me.Controls.Add(EstadoLabel)
        Me.Controls.Add(Me.Estado)
        Me.Controls.Add(FechaAltaLabel)
        Me.Controls.Add(Me.FechaAlta)
        Me.Controls.Add(IdCCLabel)
        Me.Controls.Add(Me.IdCC)
        Me.Controls.Add(LimiteCreditoLabel)
        Me.Controls.Add(Me.LimiteCredito)
        Me.Controls.Add(ObservacionesLabel)
        Me.Controls.Add(Me.Observaciones)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrmCuentaCorriente"
        Me.Text = "FrmCuentaCorriente"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.CuentaCorrienteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents Guardar As ToolStripButton
    Friend WithEvents Nuevo As ToolStripButton
    Friend WithEvents CuentaCorrienteBindingSource As BindingSource
    Friend WithEvents Descripcion As TextBox
    Friend WithEvents Estado As ComboBox
    Friend WithEvents FechaAlta As TextBox
    Friend WithEvents IdCC As TextBox
    Friend WithEvents LimiteCredito As TextBox
    Friend WithEvents Observaciones As TextBox
End Class
