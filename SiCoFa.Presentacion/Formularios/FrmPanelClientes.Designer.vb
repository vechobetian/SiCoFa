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
        Me.UcIVA = New SiCoFa.Presentacion.UcSelectorUniversal()
        Me.UcEstado = New SiCoFa.Presentacion.UcSelectorUniversal()
        Me.UcTipoDoc = New SiCoFa.Presentacion.UcSelectorUniversal()
        Me.UcProvincia = New SiCoFa.Presentacion.UcSelectorUniversal()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TxtFechaAltaCliente = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtNumDoc = New System.Windows.Forms.TextBox()
        Me.TxtEmail = New System.Windows.Forms.TextBox()
        Me.TxtTelefono = New System.Windows.Forms.TextBox()
        Me.TxtLocalidad = New System.Windows.Forms.TextBox()
        Me.TxtDomicilio = New System.Windows.Forms.TextBox()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.TxtId = New System.Windows.Forms.TextBox()
        Me.CuentaCorriente = New System.Windows.Forms.TabPage()
        Me.UcEstadoCC = New SiCoFa.Presentacion.UcSelectorUniversal()
        Me.TxtDescripcion = New System.Windows.Forms.TextBox()
        Me.TxtFechaAltaCuentaCorriente = New System.Windows.Forms.TextBox()
        Me.TxtIdCC = New System.Windows.Forms.TextBox()
        Me.TxtCredito = New System.Windows.Forms.TextBox()
        Me.TxtObservaciones = New System.Windows.Forms.TextBox()
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
        Me.Cliente.Controls.Add(Me.UcIVA)
        Me.Cliente.Controls.Add(Me.UcEstado)
        Me.Cliente.Controls.Add(Me.UcTipoDoc)
        Me.Cliente.Controls.Add(Me.UcProvincia)
        Me.Cliente.Controls.Add(Me.Label4)
        Me.Cliente.Controls.Add(Me.Label12)
        Me.Cliente.Controls.Add(Me.Label11)
        Me.Cliente.Controls.Add(Me.TxtFechaAltaCliente)
        Me.Cliente.Controls.Add(Me.Label2)
        Me.Cliente.Controls.Add(Me.Label10)
        Me.Cliente.Controls.Add(Me.Label9)
        Me.Cliente.Controls.Add(Me.Label8)
        Me.Cliente.Controls.Add(Me.Label7)
        Me.Cliente.Controls.Add(Me.Label6)
        Me.Cliente.Controls.Add(Me.Label5)
        Me.Cliente.Controls.Add(Me.Label3)
        Me.Cliente.Controls.Add(Me.Label1)
        Me.Cliente.Controls.Add(Me.TxtNumDoc)
        Me.Cliente.Controls.Add(Me.TxtEmail)
        Me.Cliente.Controls.Add(Me.TxtTelefono)
        Me.Cliente.Controls.Add(Me.TxtLocalidad)
        Me.Cliente.Controls.Add(Me.TxtDomicilio)
        Me.Cliente.Controls.Add(Me.TxtNombre)
        Me.Cliente.Controls.Add(Me.TxtId)
        Me.Cliente.Location = New System.Drawing.Point(4, 22)
        Me.Cliente.Name = "Cliente"
        Me.Cliente.Padding = New System.Windows.Forms.Padding(3)
        Me.Cliente.Size = New System.Drawing.Size(401, 325)
        Me.Cliente.TabIndex = 0
        Me.Cliente.Text = "Datos Cliente"
        Me.Cliente.UseVisualStyleBackColor = True
        '
        'UcIVA
        '
        Me.UcIVA.BuscarConTextoVacio = False
        Me.UcIVA.Descripcion = ""
        Me.UcIVA.HeaderDescripcion = "Descripción"
        Me.UcIVA.Id = Nothing
        Me.UcIVA.Location = New System.Drawing.Point(76, 292)
        Me.UcIVA.Name = "UcIVA"
        Me.UcIVA.NombrePropiedadDescripcion = Nothing
        Me.UcIVA.NombrePropiedadId = Nothing
        Me.UcIVA.Objetos = Nothing
        Me.UcIVA.PermitirVacio = True
        Me.UcIVA.Size = New System.Drawing.Size(300, 20)
        Me.UcIVA.SoloLectura = False
        Me.UcIVA.TabIndex = 11
        Me.UcIVA.TextoPredeterminado = ""
        Me.UcIVA.TituloSelector = "Selección"
        Me.UcIVA.ValorPredeterminado = Nothing
        '
        'UcEstado
        '
        Me.UcEstado.BuscarConTextoVacio = False
        Me.UcEstado.Descripcion = ""
        Me.UcEstado.HeaderDescripcion = "Descripción"
        Me.UcEstado.Id = Nothing
        Me.UcEstado.Location = New System.Drawing.Point(76, 266)
        Me.UcEstado.Name = "UcEstado"
        Me.UcEstado.NombrePropiedadDescripcion = Nothing
        Me.UcEstado.NombrePropiedadId = Nothing
        Me.UcEstado.Objetos = Nothing
        Me.UcEstado.PermitirVacio = True
        Me.UcEstado.Size = New System.Drawing.Size(300, 20)
        Me.UcEstado.SoloLectura = False
        Me.UcEstado.TabIndex = 10
        Me.UcEstado.TextoPredeterminado = ""
        Me.UcEstado.TituloSelector = "Selección"
        Me.UcEstado.ValorPredeterminado = Nothing
        '
        'UcTipoDoc
        '
        Me.UcTipoDoc.BuscarConTextoVacio = False
        Me.UcTipoDoc.Descripcion = ""
        Me.UcTipoDoc.HeaderDescripcion = "Descripción"
        Me.UcTipoDoc.Id = Nothing
        Me.UcTipoDoc.Location = New System.Drawing.Point(76, 188)
        Me.UcTipoDoc.Name = "UcTipoDoc"
        Me.UcTipoDoc.NombrePropiedadDescripcion = Nothing
        Me.UcTipoDoc.NombrePropiedadId = Nothing
        Me.UcTipoDoc.Objetos = Nothing
        Me.UcTipoDoc.PermitirVacio = True
        Me.UcTipoDoc.Size = New System.Drawing.Size(300, 20)
        Me.UcTipoDoc.SoloLectura = False
        Me.UcTipoDoc.TabIndex = 7
        Me.UcTipoDoc.TextoPredeterminado = ""
        Me.UcTipoDoc.TituloSelector = "Selección"
        Me.UcTipoDoc.ValorPredeterminado = Nothing
        '
        'UcProvincia
        '
        Me.UcProvincia.BuscarConTextoVacio = False
        Me.UcProvincia.Descripcion = ""
        Me.UcProvincia.HeaderDescripcion = "Descripción"
        Me.UcProvincia.Id = Nothing
        Me.UcProvincia.Location = New System.Drawing.Point(76, 110)
        Me.UcProvincia.Name = "UcProvincia"
        Me.UcProvincia.NombrePropiedadDescripcion = Nothing
        Me.UcProvincia.NombrePropiedadId = Nothing
        Me.UcProvincia.Objetos = Nothing
        Me.UcProvincia.PermitirVacio = True
        Me.UcProvincia.Size = New System.Drawing.Size(300, 20)
        Me.UcProvincia.SoloLectura = False
        Me.UcProvincia.TabIndex = 4
        Me.UcProvincia.TextoPredeterminado = ""
        Me.UcProvincia.TituloSelector = "Selección"
        Me.UcProvincia.ValorPredeterminado = Nothing
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
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(9, 269)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(43, 13)
        Me.Label12.TabIndex = 68
        Me.Label12.Text = "Estado:"
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
        'TxtFechaAltaCliente
        '
        Me.TxtFechaAltaCliente.Location = New System.Drawing.Point(76, 240)
        Me.TxtFechaAltaCliente.Name = "TxtFechaAltaCliente"
        Me.TxtFechaAltaCliente.Size = New System.Drawing.Size(300, 20)
        Me.TxtFechaAltaCliente.TabIndex = 9
        Me.TxtFechaAltaCliente.TabStop = False
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
        'TxtNumDoc
        '
        Me.TxtNumDoc.Location = New System.Drawing.Point(76, 214)
        Me.TxtNumDoc.Name = "TxtNumDoc"
        Me.TxtNumDoc.Size = New System.Drawing.Size(300, 20)
        Me.TxtNumDoc.TabIndex = 8
        '
        'TxtEmail
        '
        Me.TxtEmail.Location = New System.Drawing.Point(76, 162)
        Me.TxtEmail.Name = "TxtEmail"
        Me.TxtEmail.Size = New System.Drawing.Size(300, 20)
        Me.TxtEmail.TabIndex = 6
        '
        'TxtTelefono
        '
        Me.TxtTelefono.Location = New System.Drawing.Point(76, 136)
        Me.TxtTelefono.Name = "TxtTelefono"
        Me.TxtTelefono.Size = New System.Drawing.Size(300, 20)
        Me.TxtTelefono.TabIndex = 5
        '
        'TxtLocalidad
        '
        Me.TxtLocalidad.Location = New System.Drawing.Point(76, 84)
        Me.TxtLocalidad.Name = "TxtLocalidad"
        Me.TxtLocalidad.Size = New System.Drawing.Size(300, 20)
        Me.TxtLocalidad.TabIndex = 3
        '
        'TxtDomicilio
        '
        Me.TxtDomicilio.Location = New System.Drawing.Point(76, 58)
        Me.TxtDomicilio.Name = "TxtDomicilio"
        Me.TxtDomicilio.Size = New System.Drawing.Size(300, 20)
        Me.TxtDomicilio.TabIndex = 2
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(76, 32)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(300, 20)
        Me.TxtNombre.TabIndex = 1
        '
        'TxtId
        '
        Me.TxtId.Enabled = False
        Me.TxtId.Location = New System.Drawing.Point(76, 6)
        Me.TxtId.Name = "TxtId"
        Me.TxtId.ReadOnly = True
        Me.TxtId.Size = New System.Drawing.Size(300, 20)
        Me.TxtId.TabIndex = 0
        '
        'CuentaCorriente
        '
        Me.CuentaCorriente.Controls.Add(Me.UcEstadoCC)
        Me.CuentaCorriente.Controls.Add(DescripcionLabel)
        Me.CuentaCorriente.Controls.Add(Me.TxtDescripcion)
        Me.CuentaCorriente.Controls.Add(EstadoLabel)
        Me.CuentaCorriente.Controls.Add(FechaAltaLabel)
        Me.CuentaCorriente.Controls.Add(Me.TxtFechaAltaCuentaCorriente)
        Me.CuentaCorriente.Controls.Add(IdCCLabel)
        Me.CuentaCorriente.Controls.Add(Me.TxtIdCC)
        Me.CuentaCorriente.Controls.Add(LimiteCreditoLabel)
        Me.CuentaCorriente.Controls.Add(Me.TxtCredito)
        Me.CuentaCorriente.Controls.Add(ObservacionesLabel)
        Me.CuentaCorriente.Controls.Add(Me.TxtObservaciones)
        Me.CuentaCorriente.Location = New System.Drawing.Point(4, 22)
        Me.CuentaCorriente.Name = "CuentaCorriente"
        Me.CuentaCorriente.Padding = New System.Windows.Forms.Padding(3)
        Me.CuentaCorriente.Size = New System.Drawing.Size(401, 325)
        Me.CuentaCorriente.TabIndex = 1
        Me.CuentaCorriente.Text = "Cuenta Corriente"
        Me.CuentaCorriente.UseVisualStyleBackColor = True
        '
        'UcEstadoCC
        '
        Me.UcEstadoCC.BuscarConTextoVacio = False
        Me.UcEstadoCC.Descripcion = ""
        Me.UcEstadoCC.HeaderDescripcion = "Descripción"
        Me.UcEstadoCC.Id = Nothing
        Me.UcEstadoCC.Location = New System.Drawing.Point(76, 110)
        Me.UcEstadoCC.Name = "UcEstadoCC"
        Me.UcEstadoCC.NombrePropiedadDescripcion = Nothing
        Me.UcEstadoCC.NombrePropiedadId = Nothing
        Me.UcEstadoCC.Objetos = Nothing
        Me.UcEstadoCC.PermitirVacio = True
        Me.UcEstadoCC.Size = New System.Drawing.Size(300, 20)
        Me.UcEstadoCC.SoloLectura = False
        Me.UcEstadoCC.TabIndex = 15
        Me.UcEstadoCC.TextoPredeterminado = ""
        Me.UcEstadoCC.TituloSelector = "Selección"
        Me.UcEstadoCC.ValorPredeterminado = Nothing
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.Location = New System.Drawing.Point(76, 32)
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.Size = New System.Drawing.Size(300, 20)
        Me.TxtDescripcion.TabIndex = 13
        '
        'TxtFechaAltaCuentaCorriente
        '
        Me.TxtFechaAltaCuentaCorriente.Location = New System.Drawing.Point(76, 84)
        Me.TxtFechaAltaCuentaCorriente.Name = "TxtFechaAltaCuentaCorriente"
        Me.TxtFechaAltaCuentaCorriente.Size = New System.Drawing.Size(300, 20)
        Me.TxtFechaAltaCuentaCorriente.TabIndex = 15
        Me.TxtFechaAltaCuentaCorriente.TabStop = False
        '
        'TxtIdCC
        '
        Me.TxtIdCC.Location = New System.Drawing.Point(76, 6)
        Me.TxtIdCC.Name = "TxtIdCC"
        Me.TxtIdCC.Size = New System.Drawing.Size(300, 20)
        Me.TxtIdCC.TabIndex = 12
        Me.TxtIdCC.TabStop = False
        '
        'TxtCredito
        '
        Me.TxtCredito.Location = New System.Drawing.Point(76, 58)
        Me.TxtCredito.Name = "TxtCredito"
        Me.TxtCredito.Size = New System.Drawing.Size(300, 20)
        Me.TxtCredito.TabIndex = 14
        '
        'TxtObservaciones
        '
        Me.TxtObservaciones.Location = New System.Drawing.Point(12, 170)
        Me.TxtObservaciones.Multiline = True
        Me.TxtObservaciones.Name = "TxtObservaciones"
        Me.TxtObservaciones.Size = New System.Drawing.Size(364, 139)
        Me.TxtObservaciones.TabIndex = 17
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
    Friend WithEvents Label11 As Label
    Friend WithEvents TxtFechaAltaCliente As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtNumDoc As TextBox
    Friend WithEvents TxtEmail As TextBox
    Friend WithEvents TxtTelefono As TextBox
    Friend WithEvents TxtLocalidad As TextBox
    Friend WithEvents TxtDomicilio As TextBox
    Friend WithEvents TxtNombre As TextBox
    Friend WithEvents TxtId As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtDescripcion As TextBox
    Friend WithEvents TxtFechaAltaCuentaCorriente As TextBox
    Friend WithEvents TxtIdCC As TextBox
    Friend WithEvents TxtCredito As TextBox
    Friend WithEvents TxtObservaciones As TextBox
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents Guardar As ToolStripButton
    Friend WithEvents NuevoCliente As ToolStripButton
    Friend WithEvents Buscar As ToolStripButton
    Friend WithEvents Limpiar As ToolStripButton
    Friend WithEvents NuevaCuentaCorriente As ToolStripButton
    Friend WithEvents UcProvincia As UcSelectorUniversal
    Friend WithEvents UcTipoDoc As UcSelectorUniversal
    Friend WithEvents UcIVA As UcSelectorUniversal
    Friend WithEvents UcEstado As UcSelectorUniversal
    Friend WithEvents UcEstadoCC As UcSelectorUniversal
End Class
