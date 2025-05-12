<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPanelClientes
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
        Dim DescripcionLabel As System.Windows.Forms.Label
        Dim EstadoLabel As System.Windows.Forms.Label
        Dim FechaAltaLabel As System.Windows.Forms.Label
        Dim IdCCLabel As System.Windows.Forms.Label
        Dim LimiteCreditoLabel As System.Windows.Forms.Label
        Dim ObservacionesLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPanelClientes))
        Me.PanelCliente = New System.Windows.Forms.TabControl()
        Me.Cliente = New System.Windows.Forms.TabPage()
        Me.Provincia = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.IVA = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.EstadoCliente = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.FechaAltaCliente = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TipoDoc = New System.Windows.Forms.ComboBox()
        Me.NumDoc = New System.Windows.Forms.TextBox()
        Me.Email = New System.Windows.Forms.TextBox()
        Me.Telefono = New System.Windows.Forms.TextBox()
        Me.Localidad = New System.Windows.Forms.TextBox()
        Me.Domicilio = New System.Windows.Forms.TextBox()
        Me.Nombre = New System.Windows.Forms.TextBox()
        Me.Id = New System.Windows.Forms.TextBox()
        Me.CuentaCorriente = New System.Windows.Forms.TabPage()
        Me.Descripcion = New System.Windows.Forms.TextBox()
        Me.EstadoCuentaCorriente = New System.Windows.Forms.ComboBox()
        Me.FechaAltaCuentaCorriente = New System.Windows.Forms.TextBox()
        Me.IdCC = New System.Windows.Forms.TextBox()
        Me.Credito = New System.Windows.Forms.TextBox()
        Me.Observaciones = New System.Windows.Forms.TextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.Guardar = New System.Windows.Forms.ToolStripButton()
        Me.NuevoCliente = New System.Windows.Forms.ToolStripButton()
        Me.Buscar = New System.Windows.Forms.ToolStripButton()
        Me.Limpiar = New System.Windows.Forms.ToolStripButton()
        Me.NuevaCuentaCorriente = New System.Windows.Forms.ToolStripButton()
        DescripcionLabel = New System.Windows.Forms.Label()
        EstadoLabel = New System.Windows.Forms.Label()
        FechaAltaLabel = New System.Windows.Forms.Label()
        IdCCLabel = New System.Windows.Forms.Label()
        LimiteCreditoLabel = New System.Windows.Forms.Label()
        ObservacionesLabel = New System.Windows.Forms.Label()
        Me.PanelCliente.SuspendLayout()
        Me.Cliente.SuspendLayout()
        Me.CuentaCorriente.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DescripcionLabel
        '
        DescripcionLabel.AutoSize = True
        DescripcionLabel.Location = New System.Drawing.Point(9, 35)
        DescripcionLabel.Name = "DescripcionLabel"
        DescripcionLabel.Size = New System.Drawing.Size(66, 13)
        DescripcionLabel.TabIndex = 43
        DescripcionLabel.Text = "Descripcion:"
        '
        'EstadoLabel
        '
        EstadoLabel.AutoSize = True
        EstadoLabel.Location = New System.Drawing.Point(9, 113)
        EstadoLabel.Name = "EstadoLabel"
        EstadoLabel.Size = New System.Drawing.Size(43, 13)
        EstadoLabel.TabIndex = 44
        EstadoLabel.Text = "Estado:"
        '
        'FechaAltaLabel
        '
        FechaAltaLabel.AutoSize = True
        FechaAltaLabel.Location = New System.Drawing.Point(9, 87)
        FechaAltaLabel.Name = "FechaAltaLabel"
        FechaAltaLabel.Size = New System.Drawing.Size(61, 13)
        FechaAltaLabel.TabIndex = 46
        FechaAltaLabel.Text = "Fecha Alta:"
        '
        'IdCCLabel
        '
        IdCCLabel.AutoSize = True
        IdCCLabel.Location = New System.Drawing.Point(9, 9)
        IdCCLabel.Name = "IdCCLabel"
        IdCCLabel.Size = New System.Drawing.Size(36, 13)
        IdCCLabel.TabIndex = 47
        IdCCLabel.Text = "Id CC:"
        '
        'LimiteCreditoLabel
        '
        LimiteCreditoLabel.AutoSize = True
        LimiteCreditoLabel.Location = New System.Drawing.Point(9, 61)
        LimiteCreditoLabel.Name = "LimiteCreditoLabel"
        LimiteCreditoLabel.Size = New System.Drawing.Size(43, 13)
        LimiteCreditoLabel.TabIndex = 48
        LimiteCreditoLabel.Text = "Credito:"
        '
        'ObservacionesLabel
        '
        ObservacionesLabel.AutoSize = True
        ObservacionesLabel.Location = New System.Drawing.Point(9, 145)
        ObservacionesLabel.Name = "ObservacionesLabel"
        ObservacionesLabel.Size = New System.Drawing.Size(81, 13)
        ObservacionesLabel.TabIndex = 49
        ObservacionesLabel.Text = "Observaciones:"
        '
        'PanelCliente
        '
        Me.PanelCliente.Controls.Add(Me.Cliente)
        Me.PanelCliente.Controls.Add(Me.CuentaCorriente)
        Me.PanelCliente.Location = New System.Drawing.Point(0, 28)
        Me.PanelCliente.Name = "PanelCliente"
        Me.PanelCliente.SelectedIndex = 0
        Me.PanelCliente.Size = New System.Drawing.Size(409, 351)
        Me.PanelCliente.TabIndex = 0
        '
        'Cliente
        '
        Me.Cliente.Controls.Add(Me.Provincia)
        Me.Cliente.Controls.Add(Me.Label4)
        Me.Cliente.Controls.Add(Me.IVA)
        Me.Cliente.Controls.Add(Me.Label12)
        Me.Cliente.Controls.Add(Me.EstadoCliente)
        Me.Cliente.Controls.Add(Me.Label11)
        Me.Cliente.Controls.Add(Me.FechaAltaCliente)
        Me.Cliente.Controls.Add(Me.Label2)
        Me.Cliente.Controls.Add(Me.Label10)
        Me.Cliente.Controls.Add(Me.Label9)
        Me.Cliente.Controls.Add(Me.Label8)
        Me.Cliente.Controls.Add(Me.Label7)
        Me.Cliente.Controls.Add(Me.Label6)
        Me.Cliente.Controls.Add(Me.Label5)
        Me.Cliente.Controls.Add(Me.Label3)
        Me.Cliente.Controls.Add(Me.Label1)
        Me.Cliente.Controls.Add(Me.TipoDoc)
        Me.Cliente.Controls.Add(Me.NumDoc)
        Me.Cliente.Controls.Add(Me.Email)
        Me.Cliente.Controls.Add(Me.Telefono)
        Me.Cliente.Controls.Add(Me.Localidad)
        Me.Cliente.Controls.Add(Me.Domicilio)
        Me.Cliente.Controls.Add(Me.Nombre)
        Me.Cliente.Controls.Add(Me.Id)
        Me.Cliente.Location = New System.Drawing.Point(4, 22)
        Me.Cliente.Name = "Cliente"
        Me.Cliente.Padding = New System.Windows.Forms.Padding(3)
        Me.Cliente.Size = New System.Drawing.Size(401, 325)
        Me.Cliente.TabIndex = 0
        Me.Cliente.Text = "Datos Cliente"
        Me.Cliente.UseVisualStyleBackColor = True
        '
        'Provincia
        '
        Me.Provincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Provincia.FormattingEnabled = True
        Me.Provincia.ItemHeight = 13
        Me.Provincia.Location = New System.Drawing.Point(76, 109)
        Me.Provincia.Name = "Provincia"
        Me.Provincia.Size = New System.Drawing.Size(300, 21)
        Me.Provincia.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 296)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 13)
        Me.Label4.TabIndex = 70
        Me.Label4.Text = "IVA:"
        '
        'IVA
        '
        Me.IVA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.IVA.FormattingEnabled = True
        Me.IVA.ItemHeight = 13
        Me.IVA.Location = New System.Drawing.Point(76, 293)
        Me.IVA.Name = "IVA"
        Me.IVA.Size = New System.Drawing.Size(300, 21)
        Me.IVA.TabIndex = 11
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(9, 269)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(43, 13)
        Me.Label12.TabIndex = 68
        Me.Label12.Text = "Estado:"
        '
        'EstadoCliente
        '
        Me.EstadoCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.EstadoCliente.FormattingEnabled = True
        Me.EstadoCliente.ItemHeight = 13
        Me.EstadoCliente.Items.AddRange(New Object() {"ACTIVO", "BAJA"})
        Me.EstadoCliente.Location = New System.Drawing.Point(76, 266)
        Me.EstadoCliente.Name = "EstadoCliente"
        Me.EstadoCliente.Size = New System.Drawing.Size(300, 21)
        Me.EstadoCliente.TabIndex = 10
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(9, 243)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(61, 13)
        Me.Label11.TabIndex = 67
        Me.Label11.Text = "Fecha Alta:"
        '
        'FechaAltaCliente
        '
        Me.FechaAltaCliente.Location = New System.Drawing.Point(76, 240)
        Me.FechaAltaCliente.Name = "FechaAltaCliente"
        Me.FechaAltaCliente.Size = New System.Drawing.Size(300, 20)
        Me.FechaAltaCliente.TabIndex = 9
        Me.FechaAltaCliente.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(19, 13)
        Me.Label2.TabIndex = 66
        Me.Label2.Text = "Id:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(9, 217)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(55, 13)
        Me.Label10.TabIndex = 65
        Me.Label10.Text = "Num.Doc:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 191)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 13)
        Me.Label9.TabIndex = 64
        Me.Label9.Text = "Tipo Doc:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 165)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 13)
        Me.Label8.TabIndex = 63
        Me.Label8.Text = "Email:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 139)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 13)
        Me.Label7.TabIndex = 62
        Me.Label7.Text = "Teléfono:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 113)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 13)
        Me.Label6.TabIndex = 61
        Me.Label6.Text = "Provincia:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 87)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 60
        Me.Label5.Text = "Localidad:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 59
        Me.Label3.Text = "Domicilio:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 58
        Me.Label1.Text = "Nombre:"
        '
        'TipoDoc
        '
        Me.TipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TipoDoc.FormattingEnabled = True
        Me.TipoDoc.ItemHeight = 13
        Me.TipoDoc.Location = New System.Drawing.Point(76, 188)
        Me.TipoDoc.Name = "TipoDoc"
        Me.TipoDoc.Size = New System.Drawing.Size(300, 21)
        Me.TipoDoc.TabIndex = 7
        '
        'NumDoc
        '
        Me.NumDoc.Location = New System.Drawing.Point(76, 214)
        Me.NumDoc.Name = "NumDoc"
        Me.NumDoc.Size = New System.Drawing.Size(300, 20)
        Me.NumDoc.TabIndex = 8
        '
        'Email
        '
        Me.Email.Location = New System.Drawing.Point(76, 162)
        Me.Email.Name = "Email"
        Me.Email.Size = New System.Drawing.Size(300, 20)
        Me.Email.TabIndex = 6
        '
        'Telefono
        '
        Me.Telefono.Location = New System.Drawing.Point(76, 136)
        Me.Telefono.Name = "Telefono"
        Me.Telefono.Size = New System.Drawing.Size(300, 20)
        Me.Telefono.TabIndex = 5
        '
        'Localidad
        '
        Me.Localidad.Location = New System.Drawing.Point(76, 84)
        Me.Localidad.Name = "Localidad"
        Me.Localidad.Size = New System.Drawing.Size(300, 20)
        Me.Localidad.TabIndex = 3
        '
        'Domicilio
        '
        Me.Domicilio.Location = New System.Drawing.Point(76, 58)
        Me.Domicilio.Name = "Domicilio"
        Me.Domicilio.Size = New System.Drawing.Size(300, 20)
        Me.Domicilio.TabIndex = 2
        '
        'Nombre
        '
        Me.Nombre.Location = New System.Drawing.Point(76, 32)
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Size = New System.Drawing.Size(300, 20)
        Me.Nombre.TabIndex = 1
        '
        'Id
        '
        Me.Id.Enabled = False
        Me.Id.Location = New System.Drawing.Point(76, 6)
        Me.Id.Name = "Id"
        Me.Id.ReadOnly = True
        Me.Id.Size = New System.Drawing.Size(300, 20)
        Me.Id.TabIndex = 0
        '
        'CuentaCorriente
        '
        Me.CuentaCorriente.Controls.Add(DescripcionLabel)
        Me.CuentaCorriente.Controls.Add(Me.Descripcion)
        Me.CuentaCorriente.Controls.Add(EstadoLabel)
        Me.CuentaCorriente.Controls.Add(Me.EstadoCuentaCorriente)
        Me.CuentaCorriente.Controls.Add(FechaAltaLabel)
        Me.CuentaCorriente.Controls.Add(Me.FechaAltaCuentaCorriente)
        Me.CuentaCorriente.Controls.Add(IdCCLabel)
        Me.CuentaCorriente.Controls.Add(Me.IdCC)
        Me.CuentaCorriente.Controls.Add(LimiteCreditoLabel)
        Me.CuentaCorriente.Controls.Add(Me.Credito)
        Me.CuentaCorriente.Controls.Add(ObservacionesLabel)
        Me.CuentaCorriente.Controls.Add(Me.Observaciones)
        Me.CuentaCorriente.Location = New System.Drawing.Point(4, 22)
        Me.CuentaCorriente.Name = "CuentaCorriente"
        Me.CuentaCorriente.Padding = New System.Windows.Forms.Padding(3)
        Me.CuentaCorriente.Size = New System.Drawing.Size(401, 325)
        Me.CuentaCorriente.TabIndex = 1
        Me.CuentaCorriente.Text = "Cuenta Corriente"
        Me.CuentaCorriente.UseVisualStyleBackColor = True
        '
        'Descripcion
        '
        Me.Descripcion.Location = New System.Drawing.Point(76, 32)
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.Size = New System.Drawing.Size(300, 20)
        Me.Descripcion.TabIndex = 12
        '
        'EstadoCuentaCorriente
        '
        Me.EstadoCuentaCorriente.FormattingEnabled = True
        Me.EstadoCuentaCorriente.ItemHeight = 13
        Me.EstadoCuentaCorriente.Items.AddRange(New Object() {"HABILITADA", "SUSPENDIDA"})
        Me.EstadoCuentaCorriente.Location = New System.Drawing.Point(76, 110)
        Me.EstadoCuentaCorriente.Name = "EstadoCuentaCorriente"
        Me.EstadoCuentaCorriente.Size = New System.Drawing.Size(300, 21)
        Me.EstadoCuentaCorriente.TabIndex = 14
        '
        'FechaAltaCuentaCorriente
        '
        Me.FechaAltaCuentaCorriente.Location = New System.Drawing.Point(76, 84)
        Me.FechaAltaCuentaCorriente.Name = "FechaAltaCuentaCorriente"
        Me.FechaAltaCuentaCorriente.Size = New System.Drawing.Size(300, 20)
        Me.FechaAltaCuentaCorriente.TabIndex = 41
        Me.FechaAltaCuentaCorriente.TabStop = False
        '
        'IdCC
        '
        Me.IdCC.Location = New System.Drawing.Point(76, 6)
        Me.IdCC.Name = "IdCC"
        Me.IdCC.Size = New System.Drawing.Size(300, 20)
        Me.IdCC.TabIndex = 38
        Me.IdCC.TabStop = False
        '
        'Credito
        '
        Me.Credito.Location = New System.Drawing.Point(76, 58)
        Me.Credito.Name = "Credito"
        Me.Credito.Size = New System.Drawing.Size(300, 20)
        Me.Credito.TabIndex = 13
        '
        'Observaciones
        '
        Me.Observaciones.Location = New System.Drawing.Point(12, 170)
        Me.Observaciones.Multiline = True
        Me.Observaciones.Name = "Observaciones"
        Me.Observaciones.Size = New System.Drawing.Size(364, 139)
        Me.Observaciones.TabIndex = 15
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Guardar, Me.NuevoCliente, Me.Buscar, Me.Limpiar, Me.NuevaCuentaCorriente})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(409, 25)
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
        'NuevoCliente
        '
        Me.NuevoCliente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NuevoCliente.Image = CType(resources.GetObject("NuevoCliente.Image"), System.Drawing.Image)
        Me.NuevoCliente.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NuevoCliente.Name = "NuevoCliente"
        Me.NuevoCliente.Size = New System.Drawing.Size(23, 22)
        Me.NuevoCliente.Text = "Nuevo Cliente"
        '
        'Buscar
        '
        Me.Buscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Buscar.Image = CType(resources.GetObject("Buscar.Image"), System.Drawing.Image)
        Me.Buscar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Buscar.Name = "Buscar"
        Me.Buscar.Size = New System.Drawing.Size(23, 22)
        Me.Buscar.Text = "Buscar Cliente"
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
        'NuevaCuentaCorriente
        '
        Me.NuevaCuentaCorriente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NuevaCuentaCorriente.Image = CType(resources.GetObject("NuevaCuentaCorriente.Image"), System.Drawing.Image)
        Me.NuevaCuentaCorriente.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NuevaCuentaCorriente.Name = "NuevaCuentaCorriente"
        Me.NuevaCuentaCorriente.Size = New System.Drawing.Size(23, 22)
        Me.NuevaCuentaCorriente.Text = "Abrir Cuenta Corriente"
        Me.NuevaCuentaCorriente.Visible = False
        '
        'FrmPanelClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(409, 376)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.PanelCliente)
        Me.Name = "FrmPanelClientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmPanelClientes"
        Me.PanelCliente.ResumeLayout(False)
        Me.Cliente.ResumeLayout(False)
        Me.Cliente.PerformLayout()
        Me.CuentaCorriente.ResumeLayout(False)
        Me.CuentaCorriente.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PanelCliente As TabControl
    Friend WithEvents Cliente As TabPage
    Friend WithEvents CuentaCorriente As TabPage
    Friend WithEvents Label12 As Label
    Friend WithEvents EstadoCliente As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents FechaAltaCliente As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TipoDoc As ComboBox
    Friend WithEvents NumDoc As TextBox
    Friend WithEvents Email As TextBox
    Friend WithEvents Telefono As TextBox
    Friend WithEvents Localidad As TextBox
    Friend WithEvents Domicilio As TextBox
    Friend WithEvents Nombre As TextBox
    Friend WithEvents Id As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents IVA As ComboBox
    Friend WithEvents Descripcion As TextBox
    Friend WithEvents EstadoCuentaCorriente As ComboBox
    Friend WithEvents FechaAltaCuentaCorriente As TextBox
    Friend WithEvents IdCC As TextBox
    Friend WithEvents Credito As TextBox
    Friend WithEvents Observaciones As TextBox
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents Guardar As ToolStripButton
    Friend WithEvents NuevoCliente As ToolStripButton
    Friend WithEvents Buscar As ToolStripButton
    Friend WithEvents Limpiar As ToolStripButton
    Friend WithEvents Provincia As ComboBox
    Friend WithEvents NuevaCuentaCorriente As ToolStripButton
End Class
