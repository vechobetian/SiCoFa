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
        Me.TxtNTroquel = New System.Windows.Forms.TextBox()
        Me.TxtCodBarras = New System.Windows.Forms.TextBox()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.Guardar = New System.Windows.Forms.ToolStripButton()
        Me.Nuevo = New System.Windows.Forms.ToolStripButton()
        Me.Buscar = New System.Windows.Forms.ToolStripButton()
        Me.Limpiar = New System.Windows.Forms.ToolStripButton()
        Me.UcLaboratorio = New SiCoFa.Presentacion.UcSelectorUniversal()
        Me.UcMonodroga = New SiCoFa.Presentacion.UcSelectorUniversal()
        Me.UcAccionFarmacologica = New SiCoFa.Presentacion.UcSelectorUniversal()
        Me.UcSeccion = New SiCoFa.Presentacion.UcSelectorUniversal()
        Me.UcTipoVenta = New SiCoFa.Presentacion.UcSelectorUniversal()
        Me.UcTamanioEnvase = New SiCoFa.Presentacion.UcSelectorUniversal()
        Me.UcTipoControl = New SiCoFa.Presentacion.UcSelectorUniversal()
        Me.UcAlicuotaIVA = New SiCoFa.Presentacion.UcSelectorUniversal()
        Me.UcHeladera = New SiCoFa.Presentacion.UcSelectorUniversal()
        Me.UcBaja = New SiCoFa.Presentacion.UcSelectorUniversal()
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
        Me.TxtIdArticulo.Location = New System.Drawing.Point(104, 40)
        Me.TxtIdArticulo.Name = "TxtIdArticulo"
        Me.TxtIdArticulo.ReadOnly = True
        Me.TxtIdArticulo.Size = New System.Drawing.Size(315, 20)
        Me.TxtIdArticulo.TabIndex = 0
        Me.TxtIdArticulo.TabStop = False
        '
        'TxtNTroquel
        '
        Me.TxtNTroquel.Location = New System.Drawing.Point(104, 92)
        Me.TxtNTroquel.Name = "TxtNTroquel"
        Me.TxtNTroquel.Size = New System.Drawing.Size(315, 20)
        Me.TxtNTroquel.TabIndex = 2
        '
        'TxtCodBarras
        '
        Me.TxtCodBarras.Location = New System.Drawing.Point(104, 118)
        Me.TxtCodBarras.Name = "TxtCodBarras"
        Me.TxtCodBarras.Size = New System.Drawing.Size(315, 20)
        Me.TxtCodBarras.TabIndex = 3
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
        'UcLaboratorio
        '
        Me.UcLaboratorio.BuscarConTextoVacio = False
        Me.UcLaboratorio.Descripcion = ""
        Me.UcLaboratorio.HeaderDescripcion = "Descripción"
        Me.UcLaboratorio.Id = Nothing
        Me.UcLaboratorio.Location = New System.Drawing.Point(104, 225)
        Me.UcLaboratorio.Name = "UcLaboratorio"
        Me.UcLaboratorio.NombrePropiedadDescripcion = Nothing
        Me.UcLaboratorio.NombrePropiedadId = Nothing
        Me.UcLaboratorio.Objetos = Nothing
        Me.UcLaboratorio.PermitirVacio = True
        Me.UcLaboratorio.Size = New System.Drawing.Size(315, 20)
        Me.UcLaboratorio.SoloLectura = False
        Me.UcLaboratorio.TabIndex = 7
        Me.UcLaboratorio.TextoPredeterminado = ""
        Me.UcLaboratorio.TituloSelector = "Selección"
        Me.UcLaboratorio.ValorPredeterminado = Nothing
        '
        'UcMonodroga
        '
        Me.UcMonodroga.BuscarConTextoVacio = False
        Me.UcMonodroga.Descripcion = ""
        Me.UcMonodroga.HeaderDescripcion = "Descripción"
        Me.UcMonodroga.Id = Nothing
        Me.UcMonodroga.Location = New System.Drawing.Point(104, 251)
        Me.UcMonodroga.Name = "UcMonodroga"
        Me.UcMonodroga.NombrePropiedadDescripcion = Nothing
        Me.UcMonodroga.NombrePropiedadId = Nothing
        Me.UcMonodroga.Objetos = Nothing
        Me.UcMonodroga.PermitirVacio = True
        Me.UcMonodroga.Size = New System.Drawing.Size(315, 20)
        Me.UcMonodroga.SoloLectura = False
        Me.UcMonodroga.TabIndex = 8
        Me.UcMonodroga.TextoPredeterminado = ""
        Me.UcMonodroga.TituloSelector = "Selección"
        Me.UcMonodroga.ValorPredeterminado = Nothing
        '
        'UcAccionFarmacologica
        '
        Me.UcAccionFarmacologica.BuscarConTextoVacio = False
        Me.UcAccionFarmacologica.Descripcion = ""
        Me.UcAccionFarmacologica.HeaderDescripcion = "Descripción"
        Me.UcAccionFarmacologica.Id = Nothing
        Me.UcAccionFarmacologica.Location = New System.Drawing.Point(104, 277)
        Me.UcAccionFarmacologica.Name = "UcAccionFarmacologica"
        Me.UcAccionFarmacologica.NombrePropiedadDescripcion = Nothing
        Me.UcAccionFarmacologica.NombrePropiedadId = Nothing
        Me.UcAccionFarmacologica.Objetos = Nothing
        Me.UcAccionFarmacologica.PermitirVacio = True
        Me.UcAccionFarmacologica.Size = New System.Drawing.Size(315, 20)
        Me.UcAccionFarmacologica.SoloLectura = False
        Me.UcAccionFarmacologica.TabIndex = 9
        Me.UcAccionFarmacologica.TextoPredeterminado = ""
        Me.UcAccionFarmacologica.TituloSelector = "Selección"
        Me.UcAccionFarmacologica.ValorPredeterminado = Nothing
        '
        'UcSeccion
        '
        Me.UcSeccion.BuscarConTextoVacio = False
        Me.UcSeccion.Descripcion = ""
        Me.UcSeccion.HeaderDescripcion = "Descripción"
        Me.UcSeccion.Id = Nothing
        Me.UcSeccion.Location = New System.Drawing.Point(104, 387)
        Me.UcSeccion.Name = "UcSeccion"
        Me.UcSeccion.NombrePropiedadDescripcion = Nothing
        Me.UcSeccion.NombrePropiedadId = Nothing
        Me.UcSeccion.Objetos = Nothing
        Me.UcSeccion.PermitirVacio = True
        Me.UcSeccion.Size = New System.Drawing.Size(315, 20)
        Me.UcSeccion.SoloLectura = False
        Me.UcSeccion.TabIndex = 13
        Me.UcSeccion.TextoPredeterminado = ""
        Me.UcSeccion.TituloSelector = "Selección"
        Me.UcSeccion.ValorPredeterminado = Nothing
        '
        'UcTipoVenta
        '
        Me.UcTipoVenta.BuscarConTextoVacio = False
        Me.UcTipoVenta.Descripcion = ""
        Me.UcTipoVenta.HeaderDescripcion = "Descripción"
        Me.UcTipoVenta.Id = Nothing
        Me.UcTipoVenta.Location = New System.Drawing.Point(104, 144)
        Me.UcTipoVenta.Name = "UcTipoVenta"
        Me.UcTipoVenta.NombrePropiedadDescripcion = Nothing
        Me.UcTipoVenta.NombrePropiedadId = Nothing
        Me.UcTipoVenta.Objetos = Nothing
        Me.UcTipoVenta.PermitirVacio = True
        Me.UcTipoVenta.Size = New System.Drawing.Size(315, 20)
        Me.UcTipoVenta.SoloLectura = False
        Me.UcTipoVenta.TabIndex = 4
        Me.UcTipoVenta.TextoPredeterminado = ""
        Me.UcTipoVenta.TituloSelector = "Selección"
        Me.UcTipoVenta.ValorPredeterminado = Nothing
        '
        'UcTamanioEnvase
        '
        Me.UcTamanioEnvase.BuscarConTextoVacio = False
        Me.UcTamanioEnvase.Descripcion = ""
        Me.UcTamanioEnvase.HeaderDescripcion = "Descripción"
        Me.UcTamanioEnvase.Id = Nothing
        Me.UcTamanioEnvase.Location = New System.Drawing.Point(104, 198)
        Me.UcTamanioEnvase.Name = "UcTamanioEnvase"
        Me.UcTamanioEnvase.NombrePropiedadDescripcion = Nothing
        Me.UcTamanioEnvase.NombrePropiedadId = Nothing
        Me.UcTamanioEnvase.Objetos = Nothing
        Me.UcTamanioEnvase.PermitirVacio = True
        Me.UcTamanioEnvase.Size = New System.Drawing.Size(315, 20)
        Me.UcTamanioEnvase.SoloLectura = False
        Me.UcTamanioEnvase.TabIndex = 6
        Me.UcTamanioEnvase.TextoPredeterminado = ""
        Me.UcTamanioEnvase.TituloSelector = "Selección"
        Me.UcTamanioEnvase.ValorPredeterminado = Nothing
        '
        'UcTipoControl
        '
        Me.UcTipoControl.BuscarConTextoVacio = False
        Me.UcTipoControl.Descripcion = ""
        Me.UcTipoControl.HeaderDescripcion = "Descripción"
        Me.UcTipoControl.Id = Nothing
        Me.UcTipoControl.Location = New System.Drawing.Point(104, 304)
        Me.UcTipoControl.Name = "UcTipoControl"
        Me.UcTipoControl.NombrePropiedadDescripcion = Nothing
        Me.UcTipoControl.NombrePropiedadId = Nothing
        Me.UcTipoControl.Objetos = Nothing
        Me.UcTipoControl.PermitirVacio = True
        Me.UcTipoControl.Size = New System.Drawing.Size(315, 20)
        Me.UcTipoControl.SoloLectura = False
        Me.UcTipoControl.TabIndex = 10
        Me.UcTipoControl.TextoPredeterminado = ""
        Me.UcTipoControl.TituloSelector = "Selección"
        Me.UcTipoControl.ValorPredeterminado = Nothing
        '
        'UcAlicuotaIVA
        '
        Me.UcAlicuotaIVA.BuscarConTextoVacio = False
        Me.UcAlicuotaIVA.Descripcion = ""
        Me.UcAlicuotaIVA.HeaderDescripcion = "Descripción"
        Me.UcAlicuotaIVA.Id = Nothing
        Me.UcAlicuotaIVA.Location = New System.Drawing.Point(104, 172)
        Me.UcAlicuotaIVA.Name = "UcAlicuotaIVA"
        Me.UcAlicuotaIVA.NombrePropiedadDescripcion = Nothing
        Me.UcAlicuotaIVA.NombrePropiedadId = Nothing
        Me.UcAlicuotaIVA.Objetos = Nothing
        Me.UcAlicuotaIVA.PermitirVacio = True
        Me.UcAlicuotaIVA.Size = New System.Drawing.Size(315, 20)
        Me.UcAlicuotaIVA.SoloLectura = False
        Me.UcAlicuotaIVA.TabIndex = 5
        Me.UcAlicuotaIVA.TextoPredeterminado = ""
        Me.UcAlicuotaIVA.TituloSelector = "Selección"
        Me.UcAlicuotaIVA.ValorPredeterminado = Nothing
        '
        'UcHeladera
        '
        Me.UcHeladera.BuscarConTextoVacio = False
        Me.UcHeladera.Descripcion = ""
        Me.UcHeladera.HeaderDescripcion = "Descripción"
        Me.UcHeladera.Id = Nothing
        Me.UcHeladera.Location = New System.Drawing.Point(104, 330)
        Me.UcHeladera.Name = "UcHeladera"
        Me.UcHeladera.NombrePropiedadDescripcion = Nothing
        Me.UcHeladera.NombrePropiedadId = Nothing
        Me.UcHeladera.Objetos = Nothing
        Me.UcHeladera.PermitirVacio = True
        Me.UcHeladera.Size = New System.Drawing.Size(315, 20)
        Me.UcHeladera.SoloLectura = False
        Me.UcHeladera.TabIndex = 11
        Me.UcHeladera.TextoPredeterminado = ""
        Me.UcHeladera.TituloSelector = "Selección"
        Me.UcHeladera.ValorPredeterminado = Nothing
        '
        'UcBaja
        '
        Me.UcBaja.BuscarConTextoVacio = False
        Me.UcBaja.Descripcion = ""
        Me.UcBaja.HeaderDescripcion = "Descripción"
        Me.UcBaja.Id = Nothing
        Me.UcBaja.Location = New System.Drawing.Point(104, 360)
        Me.UcBaja.Name = "UcBaja"
        Me.UcBaja.NombrePropiedadDescripcion = Nothing
        Me.UcBaja.NombrePropiedadId = Nothing
        Me.UcBaja.Objetos = Nothing
        Me.UcBaja.PermitirVacio = True
        Me.UcBaja.Size = New System.Drawing.Size(315, 20)
        Me.UcBaja.SoloLectura = False
        Me.UcBaja.TabIndex = 12
        Me.UcBaja.TextoPredeterminado = ""
        Me.UcBaja.TituloSelector = "Selección"
        Me.UcBaja.ValorPredeterminado = Nothing
        '
        'FrmArticulos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(431, 420)
        Me.Controls.Add(Me.UcBaja)
        Me.Controls.Add(Me.UcHeladera)
        Me.Controls.Add(Me.UcAlicuotaIVA)
        Me.Controls.Add(Me.UcTipoControl)
        Me.Controls.Add(Me.UcTamanioEnvase)
        Me.Controls.Add(Me.UcTipoVenta)
        Me.Controls.Add(Me.UcSeccion)
        Me.Controls.Add(Me.UcAccionFarmacologica)
        Me.Controls.Add(Me.UcMonodroga)
        Me.Controls.Add(Me.UcLaboratorio)
        Me.Controls.Add(LblHeladera)
        Me.Controls.Add(LblTipoControl)
        Me.Controls.Add(LblAccionFarmacologica)
        Me.Controls.Add(LblMonodroba)
        Me.Controls.Add(LblLaborarorio)
        Me.Controls.Add(LblTipoVenta)
        Me.Controls.Add(Label1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(LblSeccion)
        Me.Controls.Add(LblBaja)
        Me.Controls.Add(LblAlicuotaIVA)
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
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtIdArticulo As TextBox
    Friend WithEvents TxtNTroquel As TextBox
    Friend WithEvents TxtCodBarras As TextBox
    Friend WithEvents TxtNombre As TextBox
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents Guardar As ToolStripButton
    Friend WithEvents Nuevo As ToolStripButton
    Friend WithEvents Buscar As ToolStripButton
    Friend WithEvents Limpiar As ToolStripButton
    Friend WithEvents UcLaboratorio As UcSelectorUniversal
    Friend WithEvents UcMonodroga As UcSelectorUniversal
    Friend WithEvents UcAccionFarmacologica As UcSelectorUniversal
    Friend WithEvents UcSeccion As UcSelectorUniversal
    Friend WithEvents UcTipoVenta As UcSelectorUniversal
    Friend WithEvents UcTamanioEnvase As UcSelectorUniversal
    Friend WithEvents UcTipoControl As UcSelectorUniversal
    Friend WithEvents UcAlicuotaIVA As UcSelectorUniversal
    Friend WithEvents UcHeladera As UcSelectorUniversal
    Friend WithEvents UcBaja As UcSelectorUniversal
End Class
