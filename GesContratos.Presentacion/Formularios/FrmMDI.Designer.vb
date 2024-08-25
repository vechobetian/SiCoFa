<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMDI
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMDI))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.PagoDeClientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContratoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistroCLuzToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAbrir = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAbrirContrato = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ServiciosPrestadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CuadroTarifarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MedidoresDeLuzToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProcesosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DevengarServiciosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnviarMailServiciosPrestadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AduditoríaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EstadoDeCuentaGruposToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComprobantesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.EstadoSecion = New System.Windows.Forms.Label()
        Me.IdUsuario = New System.Windows.Forms.Label()
        Me.Usuario = New System.Windows.Forms.Label()
        Me.EstadoDeCuentaClientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.EditarToolStripMenuItem, Me.ProcesosToolStripMenuItem, Me.AduditoríaToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(848, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ArchivoToolStripMenuItem
        '
        Me.ArchivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuNuevo, Me.mnuAbrir, Me.SalirToolStripMenuItem})
        Me.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
        Me.ArchivoToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.ArchivoToolStripMenuItem.Text = "&Archivo"
        '
        'mnuNuevo
        '
        Me.mnuNuevo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PagoDeClientesToolStripMenuItem, Me.ContratoToolStripMenuItem, Me.RegistroCLuzToolStripMenuItem})
        Me.mnuNuevo.Name = "mnuNuevo"
        Me.mnuNuevo.Size = New System.Drawing.Size(109, 22)
        Me.mnuNuevo.Text = "&Nuevo"
        '
        'PagoDeClientesToolStripMenuItem
        '
        Me.PagoDeClientesToolStripMenuItem.Name = "PagoDeClientesToolStripMenuItem"
        Me.PagoDeClientesToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.PagoDeClientesToolStripMenuItem.Text = "&Pago de Clientes"
        '
        'ContratoToolStripMenuItem
        '
        Me.ContratoToolStripMenuItem.Name = "ContratoToolStripMenuItem"
        Me.ContratoToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.ContratoToolStripMenuItem.Text = "&Contrato"
        '
        'RegistroCLuzToolStripMenuItem
        '
        Me.RegistroCLuzToolStripMenuItem.Name = "RegistroCLuzToolStripMenuItem"
        Me.RegistroCLuzToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.RegistroCLuzToolStripMenuItem.Text = "Registro C.Luz"
        '
        'mnuAbrir
        '
        Me.mnuAbrir.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAbrirContrato})
        Me.mnuAbrir.Name = "mnuAbrir"
        Me.mnuAbrir.Size = New System.Drawing.Size(109, 22)
        Me.mnuAbrir.Text = "&Abrir"
        '
        'mnuAbrirContrato
        '
        Me.mnuAbrirContrato.Name = "mnuAbrirContrato"
        Me.mnuAbrirContrato.Size = New System.Drawing.Size(126, 22)
        Me.mnuAbrirContrato.Text = "&Contratos"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(109, 22)
        Me.SalirToolStripMenuItem.Text = "&Salir"
        '
        'EditarToolStripMenuItem
        '
        Me.EditarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ServiciosPrestadosToolStripMenuItem, Me.CuadroTarifarioToolStripMenuItem, Me.MedidoresDeLuzToolStripMenuItem})
        Me.EditarToolStripMenuItem.Name = "EditarToolStripMenuItem"
        Me.EditarToolStripMenuItem.Size = New System.Drawing.Size(49, 20)
        Me.EditarToolStripMenuItem.Text = "Editar"
        '
        'ServiciosPrestadosToolStripMenuItem
        '
        Me.ServiciosPrestadosToolStripMenuItem.Name = "ServiciosPrestadosToolStripMenuItem"
        Me.ServiciosPrestadosToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.ServiciosPrestadosToolStripMenuItem.Text = "Servicios Prestados"
        '
        'CuadroTarifarioToolStripMenuItem
        '
        Me.CuadroTarifarioToolStripMenuItem.Name = "CuadroTarifarioToolStripMenuItem"
        Me.CuadroTarifarioToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.CuadroTarifarioToolStripMenuItem.Text = "Cuadro Tarifario"
        '
        'MedidoresDeLuzToolStripMenuItem
        '
        Me.MedidoresDeLuzToolStripMenuItem.Name = "MedidoresDeLuzToolStripMenuItem"
        Me.MedidoresDeLuzToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.MedidoresDeLuzToolStripMenuItem.Text = "Medidores de Luz"
        '
        'ProcesosToolStripMenuItem
        '
        Me.ProcesosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DevengarServiciosToolStripMenuItem, Me.EnviarMailServiciosPrestadosToolStripMenuItem})
        Me.ProcesosToolStripMenuItem.Name = "ProcesosToolStripMenuItem"
        Me.ProcesosToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.ProcesosToolStripMenuItem.Text = "&Procesos"
        '
        'DevengarServiciosToolStripMenuItem
        '
        Me.DevengarServiciosToolStripMenuItem.Name = "DevengarServiciosToolStripMenuItem"
        Me.DevengarServiciosToolStripMenuItem.Size = New System.Drawing.Size(235, 22)
        Me.DevengarServiciosToolStripMenuItem.Text = "&Devengar Servicios Prestados"
        '
        'EnviarMailServiciosPrestadosToolStripMenuItem
        '
        Me.EnviarMailServiciosPrestadosToolStripMenuItem.Name = "EnviarMailServiciosPrestadosToolStripMenuItem"
        Me.EnviarMailServiciosPrestadosToolStripMenuItem.Size = New System.Drawing.Size(235, 22)
        Me.EnviarMailServiciosPrestadosToolStripMenuItem.Text = "&Enviar Mail Servicios Prestados"
        '
        'AduditoríaToolStripMenuItem
        '
        Me.AduditoríaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EstadoDeCuentaGruposToolStripMenuItem, Me.ComprobantesToolStripMenuItem, Me.EstadoDeCuentaClientesToolStripMenuItem})
        Me.AduditoríaToolStripMenuItem.Name = "AduditoríaToolStripMenuItem"
        Me.AduditoríaToolStripMenuItem.Size = New System.Drawing.Size(68, 20)
        Me.AduditoríaToolStripMenuItem.Text = "Au&ditoría"
        '
        'EstadoDeCuentaGruposToolStripMenuItem
        '
        Me.EstadoDeCuentaGruposToolStripMenuItem.Name = "EstadoDeCuentaGruposToolStripMenuItem"
        Me.EstadoDeCuentaGruposToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.EstadoDeCuentaGruposToolStripMenuItem.Text = "&Estado de Cuenta Grupos"
        '
        'ComprobantesToolStripMenuItem
        '
        Me.ComprobantesToolStripMenuItem.Name = "ComprobantesToolStripMenuItem"
        Me.ComprobantesToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.ComprobantesToolStripMenuItem.Text = "&Comprobantes"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Blue
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(0, 24)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(848, 560)
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.SystemColors.Highlight
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(204, 24)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(643, 559)
        Me.PictureBox2.TabIndex = 4
        Me.PictureBox2.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.Label1.Location = New System.Drawing.Point(222, 124)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(131, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "GENESIS SOFTWARE DESIGN"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label2.Font = New System.Drawing.Font("Calibri", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.InfoText
        Me.Label2.Location = New System.Drawing.Point(699, 397)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(127, 49)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "SiCoFa"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label3.Location = New System.Drawing.Point(693, 458)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(143, 19)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Gestión de Contratos"
        '
        'EstadoSecion
        '
        Me.EstadoSecion.AutoSize = True
        Me.EstadoSecion.BackColor = System.Drawing.SystemColors.Highlight
        Me.EstadoSecion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.EstadoSecion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EstadoSecion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.EstadoSecion.Location = New System.Drawing.Point(210, 513)
        Me.EstadoSecion.Name = "EstadoSecion"
        Me.EstadoSecion.Size = New System.Drawing.Size(114, 16)
        Me.EstadoSecion.TabIndex = 9
        Me.EstadoSecion.Text = "Secion no Iniciada"
        '
        'IdUsuario
        '
        Me.IdUsuario.AutoSize = True
        Me.IdUsuario.BackColor = System.Drawing.SystemColors.Highlight
        Me.IdUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IdUsuario.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IdUsuario.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.IdUsuario.Location = New System.Drawing.Point(210, 534)
        Me.IdUsuario.Name = "IdUsuario"
        Me.IdUsuario.Size = New System.Drawing.Size(62, 16)
        Me.IdUsuario.TabIndex = 10
        Me.IdUsuario.Text = "IdUsuario"
        '
        'Usuario
        '
        Me.Usuario.AutoSize = True
        Me.Usuario.BackColor = System.Drawing.SystemColors.Highlight
        Me.Usuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Usuario.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Usuario.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Usuario.Location = New System.Drawing.Point(210, 555)
        Me.Usuario.Name = "Usuario"
        Me.Usuario.Size = New System.Drawing.Size(52, 16)
        Me.Usuario.TabIndex = 11
        Me.Usuario.Text = "Usuario"
        '
        'EstadoDeCuentaClientesToolStripMenuItem
        '
        Me.EstadoDeCuentaClientesToolStripMenuItem.Name = "EstadoDeCuentaClientesToolStripMenuItem"
        Me.EstadoDeCuentaClientesToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.EstadoDeCuentaClientesToolStripMenuItem.Text = "Estado de Cuenta Clientes"
        '
        'FrmMDI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(848, 584)
        Me.Controls.Add(Me.Usuario)
        Me.Controls.Add(Me.IdUsuario)
        Me.Controls.Add(Me.EstadoSecion)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FrmMDI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gestión de Contratos"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuNuevo As ToolStripMenuItem
    Friend WithEvents mnuAbrir As ToolStripMenuItem
    Friend WithEvents mnuAbrirContrato As ToolStripMenuItem
    Friend WithEvents PagoDeClientesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents EstadoSecion As Label
    Friend WithEvents IdUsuario As Label
    Friend WithEvents Usuario As Label
    Friend WithEvents ContratoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProcesosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DevengarServiciosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EnviarMailServiciosPrestadosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AduditoríaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EstadoDeCuentaGruposToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegistroCLuzToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CuadroTarifarioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MedidoresDeLuzToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ServiciosPrestadosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ComprobantesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EstadoDeCuentaClientesToolStripMenuItem As ToolStripMenuItem
End Class
