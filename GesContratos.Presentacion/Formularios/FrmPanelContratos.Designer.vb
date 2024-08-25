<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPanelContratos
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Movil = New System.Windows.Forms.TextBox()
        Me.IVA = New System.Windows.Forms.ComboBox()
        Me.TipoDoc = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NumDoc = New System.Windows.Forms.TextBox()
        Me.Email = New System.Windows.Forms.TextBox()
        Me.Telefono = New System.Windows.Forms.TextBox()
        Me.Provincia = New System.Windows.Forms.TextBox()
        Me.Localidad = New System.Windows.Forms.TextBox()
        Me.Domicilio = New System.Windows.Forms.TextBox()
        Me.Nombre = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.IdCliente = New System.Windows.Forms.TextBox()
        Me.Limpiar = New System.Windows.Forms.Button()
        Me.Buscar = New System.Windows.Forms.Button()
        Me.Guardar = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.FacturaServicios = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Locador = New System.Windows.Forms.ComboBox()
        Me.FinalContrato = New System.Windows.Forms.MaskedTextBox()
        Me.InicioContrato = New System.Windows.Forms.MaskedTextBox()
        Me.GuardarContrato = New System.Windows.Forms.Button()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.EstadoContrato = New System.Windows.Forms.ComboBox()
        Me.UltimoDev = New System.Windows.Forms.TextBox()
        Me.GrupoContratos = New System.Windows.Forms.ComboBox()
        Me.Deposito = New System.Windows.Forms.TextBox()
        Me.Contacto = New System.Windows.Forms.TextBox()
        Me.MesesT = New System.Windows.Forms.TextBox()
        Me.UsFTP = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.IdContrato = New System.Windows.Forms.TextBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.IdDS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodiS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescripcionServicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PUnit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImpServ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(514, 379)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.Movil)
        Me.TabPage1.Controls.Add(Me.IVA)
        Me.TabPage1.Controls.Add(Me.TipoDoc)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.NumDoc)
        Me.TabPage1.Controls.Add(Me.Email)
        Me.TabPage1.Controls.Add(Me.Telefono)
        Me.TabPage1.Controls.Add(Me.Provincia)
        Me.TabPage1.Controls.Add(Me.Localidad)
        Me.TabPage1.Controls.Add(Me.Domicilio)
        Me.TabPage1.Controls.Add(Me.Nombre)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.IdCliente)
        Me.TabPage1.Controls.Add(Me.Limpiar)
        Me.TabPage1.Controls.Add(Me.Buscar)
        Me.TabPage1.Controls.Add(Me.Guardar)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(506, 353)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Cliente"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(10, 180)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(35, 13)
        Me.Label12.TabIndex = 57
        Me.Label12.Text = "Movil:"
        '
        'Movil
        '
        Me.Movil.Location = New System.Drawing.Point(90, 177)
        Me.Movil.Name = "Movil"
        Me.Movil.Size = New System.Drawing.Size(300, 20)
        Me.Movil.TabIndex = 8
        '
        'IVA
        '
        Me.IVA.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.IVA.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.IVA.FormattingEnabled = True
        Me.IVA.ItemHeight = 13
        Me.IVA.Location = New System.Drawing.Point(90, 282)
        Me.IVA.Name = "IVA"
        Me.IVA.Size = New System.Drawing.Size(300, 21)
        Me.IVA.TabIndex = 12
        '
        'TipoDoc
        '
        Me.TipoDoc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TipoDoc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TipoDoc.FormattingEnabled = True
        Me.TipoDoc.ItemHeight = 13
        Me.TipoDoc.Location = New System.Drawing.Point(90, 230)
        Me.TipoDoc.Name = "TipoDoc"
        Me.TipoDoc.Size = New System.Drawing.Size(300, 21)
        Me.TipoDoc.TabIndex = 10
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(10, 282)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(27, 13)
        Me.Label11.TabIndex = 53
        Me.Label11.Text = "IVA:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(10, 256)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(55, 13)
        Me.Label10.TabIndex = 52
        Me.Label10.Text = "Num.Doc:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(10, 233)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 13)
        Me.Label9.TabIndex = 51
        Me.Label9.Text = "Tipo Doc:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 204)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 13)
        Me.Label8.TabIndex = 50
        Me.Label8.Text = "Email:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 151)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 13)
        Me.Label7.TabIndex = 49
        Me.Label7.Text = "Teléfono:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 125)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 13)
        Me.Label6.TabIndex = 48
        Me.Label6.Text = "Provincia:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 99)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 47
        Me.Label5.Text = "Localidad:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "Domicilio:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "IdCliente:"
        '
        'NumDoc
        '
        Me.NumDoc.Location = New System.Drawing.Point(90, 256)
        Me.NumDoc.Name = "NumDoc"
        Me.NumDoc.Size = New System.Drawing.Size(300, 20)
        Me.NumDoc.TabIndex = 11
        '
        'Email
        '
        Me.Email.Location = New System.Drawing.Point(90, 204)
        Me.Email.Name = "Email"
        Me.Email.Size = New System.Drawing.Size(300, 20)
        Me.Email.TabIndex = 9
        '
        'Telefono
        '
        Me.Telefono.Location = New System.Drawing.Point(90, 151)
        Me.Telefono.Name = "Telefono"
        Me.Telefono.Size = New System.Drawing.Size(300, 20)
        Me.Telefono.TabIndex = 7
        '
        'Provincia
        '
        Me.Provincia.Location = New System.Drawing.Point(90, 125)
        Me.Provincia.Name = "Provincia"
        Me.Provincia.Size = New System.Drawing.Size(300, 20)
        Me.Provincia.TabIndex = 6
        '
        'Localidad
        '
        Me.Localidad.Location = New System.Drawing.Point(90, 99)
        Me.Localidad.Name = "Localidad"
        Me.Localidad.Size = New System.Drawing.Size(300, 20)
        Me.Localidad.TabIndex = 5
        '
        'Domicilio
        '
        Me.Domicilio.Location = New System.Drawing.Point(90, 73)
        Me.Domicilio.Name = "Domicilio"
        Me.Domicilio.Size = New System.Drawing.Size(300, 20)
        Me.Domicilio.TabIndex = 3
        '
        'Nombre
        '
        Me.Nombre.Location = New System.Drawing.Point(90, 47)
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Size = New System.Drawing.Size(300, 20)
        Me.Nombre.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Nombre:"
        '
        'IdCliente
        '
        Me.IdCliente.Enabled = False
        Me.IdCliente.Location = New System.Drawing.Point(90, 21)
        Me.IdCliente.Name = "IdCliente"
        Me.IdCliente.ReadOnly = True
        Me.IdCliente.Size = New System.Drawing.Size(300, 20)
        Me.IdCliente.TabIndex = 1
        '
        'Limpiar
        '
        Me.Limpiar.Location = New System.Drawing.Point(417, 24)
        Me.Limpiar.Name = "Limpiar"
        Me.Limpiar.Size = New System.Drawing.Size(66, 29)
        Me.Limpiar.TabIndex = 54
        Me.Limpiar.TabStop = False
        Me.Limpiar.Text = "&Limpiar"
        Me.Limpiar.UseVisualStyleBackColor = True
        '
        'Buscar
        '
        Me.Buscar.Location = New System.Drawing.Point(417, 64)
        Me.Buscar.Name = "Buscar"
        Me.Buscar.Size = New System.Drawing.Size(66, 29)
        Me.Buscar.TabIndex = 56
        Me.Buscar.TabStop = False
        Me.Buscar.Text = "&Buscar"
        Me.Buscar.UseVisualStyleBackColor = True
        '
        'Guardar
        '
        Me.Guardar.Location = New System.Drawing.Point(417, 109)
        Me.Guardar.Name = "Guardar"
        Me.Guardar.Size = New System.Drawing.Size(66, 29)
        Me.Guardar.TabIndex = 43
        Me.Guardar.TabStop = False
        Me.Guardar.Text = "&Guardar"
        Me.Guardar.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.FacturaServicios)
        Me.TabPage2.Controls.Add(Me.Label18)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.Locador)
        Me.TabPage2.Controls.Add(Me.FinalContrato)
        Me.TabPage2.Controls.Add(Me.InicioContrato)
        Me.TabPage2.Controls.Add(Me.GuardarContrato)
        Me.TabPage2.Controls.Add(Me.Label24)
        Me.TabPage2.Controls.Add(Me.Label22)
        Me.TabPage2.Controls.Add(Me.Label21)
        Me.TabPage2.Controls.Add(Me.Label20)
        Me.TabPage2.Controls.Add(Me.Label19)
        Me.TabPage2.Controls.Add(Me.Label17)
        Me.TabPage2.Controls.Add(Me.Label16)
        Me.TabPage2.Controls.Add(Me.Label15)
        Me.TabPage2.Controls.Add(Me.Label14)
        Me.TabPage2.Controls.Add(Me.EstadoContrato)
        Me.TabPage2.Controls.Add(Me.UltimoDev)
        Me.TabPage2.Controls.Add(Me.GrupoContratos)
        Me.TabPage2.Controls.Add(Me.Deposito)
        Me.TabPage2.Controls.Add(Me.Contacto)
        Me.TabPage2.Controls.Add(Me.MesesT)
        Me.TabPage2.Controls.Add(Me.UsFTP)
        Me.TabPage2.Controls.Add(Me.Label13)
        Me.TabPage2.Controls.Add(Me.IdContrato)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(506, 353)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Contrato"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'FacturaServicios
        '
        Me.FacturaServicios.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.FacturaServicios.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.FacturaServicios.FormattingEnabled = True
        Me.FacturaServicios.ItemHeight = 13
        Me.FacturaServicios.Items.AddRange(New Object() {"NO", "SI"})
        Me.FacturaServicios.Location = New System.Drawing.Point(90, 283)
        Me.FacturaServicios.Name = "FacturaServicios"
        Me.FacturaServicios.Size = New System.Drawing.Size(300, 21)
        Me.FacturaServicios.TabIndex = 23
        Me.FacturaServicios.Text = "NO"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(10, 286)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(74, 13)
        Me.Label18.TabIndex = 73
        Me.Label18.Text = "Factura Serv.:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 71
        Me.Label4.Text = "Locador:"
        '
        'Locador
        '
        Me.Locador.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Locador.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Locador.FormattingEnabled = True
        Me.Locador.ItemHeight = 13
        Me.Locador.Location = New System.Drawing.Point(90, 74)
        Me.Locador.Name = "Locador"
        Me.Locador.Size = New System.Drawing.Size(300, 21)
        Me.Locador.TabIndex = 15
        '
        'FinalContrato
        '
        Me.FinalContrato.Location = New System.Drawing.Point(90, 231)
        Me.FinalContrato.Mask = "00/00/0000"
        Me.FinalContrato.Name = "FinalContrato"
        Me.FinalContrato.Size = New System.Drawing.Size(300, 20)
        Me.FinalContrato.TabIndex = 21
        Me.FinalContrato.ValidatingType = GetType(Date)
        '
        'InicioContrato
        '
        Me.InicioContrato.Location = New System.Drawing.Point(90, 205)
        Me.InicioContrato.Mask = "00/00/0000"
        Me.InicioContrato.Name = "InicioContrato"
        Me.InicioContrato.Size = New System.Drawing.Size(300, 20)
        Me.InicioContrato.TabIndex = 20
        Me.InicioContrato.ValidatingType = GetType(Date)
        '
        'GuardarContrato
        '
        Me.GuardarContrato.Location = New System.Drawing.Point(416, 21)
        Me.GuardarContrato.Name = "GuardarContrato"
        Me.GuardarContrato.Size = New System.Drawing.Size(66, 29)
        Me.GuardarContrato.TabIndex = 70
        Me.GuardarContrato.TabStop = False
        Me.GuardarContrato.Text = "&Guardar"
        Me.GuardarContrato.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(10, 313)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(68, 13)
        Me.Label24.TabIndex = 69
        Me.Label24.Text = "Estado Cont:"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(10, 257)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(62, 13)
        Me.Label22.TabIndex = 67
        Me.Label22.Text = "Ultimo Dev:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(10, 234)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(32, 13)
        Me.Label21.TabIndex = 66
        Me.Label21.Text = "Final:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(10, 208)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(35, 13)
        Me.Label20.TabIndex = 65
        Me.Label20.Text = "Inicio:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(10, 182)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(52, 13)
        Me.Label19.TabIndex = 64
        Me.Label19.Text = "Deposito:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(10, 153)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(53, 13)
        Me.Label17.TabIndex = 62
        Me.Label17.Text = "Contacto:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(10, 127)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(51, 13)
        Me.Label16.TabIndex = 61
        Me.Label16.Text = "Meses T:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(10, 101)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(43, 13)
        Me.Label15.TabIndex = 60
        Me.Label15.Text = "UsFTP:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(10, 50)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(55, 13)
        Me.Label14.TabIndex = 59
        Me.Label14.Text = "Gpo.Cont:"
        '
        'EstadoContrato
        '
        Me.EstadoContrato.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.EstadoContrato.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.EstadoContrato.FormattingEnabled = True
        Me.EstadoContrato.ItemHeight = 13
        Me.EstadoContrato.Items.AddRange(New Object() {"RECINDIDO", "VENCIDO", "VIGENTE"})
        Me.EstadoContrato.Location = New System.Drawing.Point(90, 310)
        Me.EstadoContrato.Name = "EstadoContrato"
        Me.EstadoContrato.Size = New System.Drawing.Size(300, 21)
        Me.EstadoContrato.TabIndex = 24
        Me.EstadoContrato.Text = "VIGENTE"
        '
        'UltimoDev
        '
        Me.UltimoDev.Location = New System.Drawing.Point(90, 257)
        Me.UltimoDev.Name = "UltimoDev"
        Me.UltimoDev.ReadOnly = True
        Me.UltimoDev.Size = New System.Drawing.Size(300, 20)
        Me.UltimoDev.TabIndex = 22
        '
        'GrupoContratos
        '
        Me.GrupoContratos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.GrupoContratos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.GrupoContratos.FormattingEnabled = True
        Me.GrupoContratos.ItemHeight = 13
        Me.GrupoContratos.Location = New System.Drawing.Point(90, 47)
        Me.GrupoContratos.Name = "GrupoContratos"
        Me.GrupoContratos.Size = New System.Drawing.Size(300, 21)
        Me.GrupoContratos.TabIndex = 14
        '
        'Deposito
        '
        Me.Deposito.Location = New System.Drawing.Point(90, 179)
        Me.Deposito.Name = "Deposito"
        Me.Deposito.Size = New System.Drawing.Size(300, 20)
        Me.Deposito.TabIndex = 19
        '
        'Contacto
        '
        Me.Contacto.Location = New System.Drawing.Point(90, 153)
        Me.Contacto.Name = "Contacto"
        Me.Contacto.Size = New System.Drawing.Size(300, 20)
        Me.Contacto.TabIndex = 18
        '
        'MesesT
        '
        Me.MesesT.Location = New System.Drawing.Point(90, 127)
        Me.MesesT.Name = "MesesT"
        Me.MesesT.Size = New System.Drawing.Size(300, 20)
        Me.MesesT.TabIndex = 17
        '
        'UsFTP
        '
        Me.UsFTP.Location = New System.Drawing.Point(90, 101)
        Me.UsFTP.Name = "UsFTP"
        Me.UsFTP.Size = New System.Drawing.Size(300, 20)
        Me.UsFTP.TabIndex = 16
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(10, 24)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(59, 13)
        Me.Label13.TabIndex = 46
        Me.Label13.Text = "IdContrato:"
        '
        'IdContrato
        '
        Me.IdContrato.Enabled = False
        Me.IdContrato.Location = New System.Drawing.Point(90, 21)
        Me.IdContrato.Name = "IdContrato"
        Me.IdContrato.ReadOnly = True
        Me.IdContrato.Size = New System.Drawing.Size(300, 20)
        Me.IdContrato.TabIndex = 13
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.DataGridView1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(506, 353)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Servicios"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdDS, Me.CodiS, Me.DescripcionServicio, Me.Cantidad, Me.PUnit, Me.ImpServ})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(3, 3)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(500, 347)
        Me.DataGridView1.TabIndex = 0
        '
        'IdDS
        '
        Me.IdDS.HeaderText = "IdDS"
        Me.IdDS.Name = "IdDS"
        Me.IdDS.Visible = False
        '
        'CodiS
        '
        Me.CodiS.HeaderText = "CodiS"
        Me.CodiS.Name = "CodiS"
        Me.CodiS.Visible = False
        '
        'DescripcionServicio
        '
        Me.DescripcionServicio.HeaderText = "Descripcion"
        Me.DescripcionServicio.Name = "DescripcionServicio"
        Me.DescripcionServicio.ReadOnly = True
        Me.DescripcionServicio.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DescripcionServicio.Width = 200
        '
        'Cantidad
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.Cantidad.DefaultCellStyle = DataGridViewCellStyle1
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.Width = 60
        '
        'PUnit
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "C2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.PUnit.DefaultCellStyle = DataGridViewCellStyle2
        Me.PUnit.HeaderText = "PUnit"
        Me.PUnit.Name = "PUnit"
        Me.PUnit.ReadOnly = True
        Me.PUnit.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'ImpServ
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "C2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.ImpServ.DefaultCellStyle = DataGridViewCellStyle3
        Me.ImpServ.HeaderText = "ImpServ"
        Me.ImpServ.Name = "ImpServ"
        Me.ImpServ.ReadOnly = True
        Me.ImpServ.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ImpServ.Width = 96
        '
        'FrmPanelContratos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(514, 379)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "FrmPanelContratos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmPanelContratos"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Label12 As Label
    Friend WithEvents Movil As TextBox
    Friend WithEvents IVA As ComboBox
    Friend WithEvents TipoDoc As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents NumDoc As TextBox
    Friend WithEvents Email As TextBox
    Friend WithEvents Telefono As TextBox
    Friend WithEvents Provincia As TextBox
    Friend WithEvents Localidad As TextBox
    Friend WithEvents Domicilio As TextBox
    Friend WithEvents Nombre As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents IdCliente As TextBox
    Friend WithEvents Limpiar As Button
    Friend WithEvents Buscar As Button
    Friend WithEvents Guardar As Button
    Friend WithEvents GrupoContratos As ComboBox
    Friend WithEvents Deposito As TextBox
    Friend WithEvents Contacto As TextBox
    Friend WithEvents MesesT As TextBox
    Friend WithEvents UsFTP As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents IdContrato As TextBox
    Friend WithEvents EstadoContrato As ComboBox
    Friend WithEvents UltimoDev As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents GuardarContrato As Button
    Friend WithEvents InicioContrato As MaskedTextBox
    Friend WithEvents FinalContrato As MaskedTextBox
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents IdDS As DataGridViewTextBoxColumn
    Friend WithEvents CodiS As DataGridViewTextBoxColumn
    Friend WithEvents DescripcionServicio As DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As DataGridViewTextBoxColumn
    Friend WithEvents PUnit As DataGridViewTextBoxColumn
    Friend WithEvents ImpServ As DataGridViewTextBoxColumn
    Friend WithEvents Label4 As Label
    Friend WithEvents Locador As ComboBox
    Friend WithEvents Label18 As Label
    Friend WithEvents FacturaServicios As ComboBox
End Class
