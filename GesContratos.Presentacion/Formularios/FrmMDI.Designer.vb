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
        Me.OperacionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PagoClientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsumoLuzToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContratosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ServiciosPrestadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CuadroTarifarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MedidoresDeLuzToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsumosFacturadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProcesosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DevengarServiciosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnviarMailServiciosPrestadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FacturarServiciosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActualizarUsFTPToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AduditoríaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EstadoDeCuentaGruposToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComprobantesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EstadoDeCuentaClientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistroDeActualizacionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EstadoUsFTPToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListaDeContratosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.EstadoSecion = New System.Windows.Forms.Label()
        Me.IdUsuario = New System.Windows.Forms.Label()
        Me.Usuario = New System.Windows.Forms.Label()
        Me.btnCambiarContraseña = New System.Windows.Forms.Button()
        Me.btnSeguridad = New System.Windows.Forms.Button()
        Me.ClienteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OperacionesToolStripMenuItem, Me.EditarToolStripMenuItem, Me.ProcesosToolStripMenuItem, Me.AduditoríaToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(848, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'OperacionesToolStripMenuItem
        '
        Me.OperacionesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PagoClientesToolStripMenuItem, Me.ConsumoLuzToolStripMenuItem})
        Me.OperacionesToolStripMenuItem.Name = "OperacionesToolStripMenuItem"
        Me.OperacionesToolStripMenuItem.Size = New System.Drawing.Size(85, 20)
        Me.OperacionesToolStripMenuItem.Text = "&Operaciones"
        '
        'PagoClientesToolStripMenuItem
        '
        Me.PagoClientesToolStripMenuItem.Name = "PagoClientesToolStripMenuItem"
        Me.PagoClientesToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.PagoClientesToolStripMenuItem.Text = "&Pago Clientes"
        '
        'ConsumoLuzToolStripMenuItem
        '
        Me.ConsumoLuzToolStripMenuItem.Name = "ConsumoLuzToolStripMenuItem"
        Me.ConsumoLuzToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.ConsumoLuzToolStripMenuItem.Text = "&Consumo Luz"
        '
        'EditarToolStripMenuItem
        '
        Me.EditarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContratosToolStripMenuItem, Me.ServiciosPrestadosToolStripMenuItem, Me.CuadroTarifarioToolStripMenuItem, Me.MedidoresDeLuzToolStripMenuItem, Me.ConsumosFacturadosToolStripMenuItem, Me.ClienteToolStripMenuItem})
        Me.EditarToolStripMenuItem.Name = "EditarToolStripMenuItem"
        Me.EditarToolStripMenuItem.Size = New System.Drawing.Size(49, 20)
        Me.EditarToolStripMenuItem.Text = "Editar"
        '
        'ContratosToolStripMenuItem
        '
        Me.ContratosToolStripMenuItem.Name = "ContratosToolStripMenuItem"
        Me.ContratosToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.ContratosToolStripMenuItem.Text = "&Contratos"
        '
        'ServiciosPrestadosToolStripMenuItem
        '
        Me.ServiciosPrestadosToolStripMenuItem.Name = "ServiciosPrestadosToolStripMenuItem"
        Me.ServiciosPrestadosToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.ServiciosPrestadosToolStripMenuItem.Text = "Servicios Prestados"
        '
        'CuadroTarifarioToolStripMenuItem
        '
        Me.CuadroTarifarioToolStripMenuItem.Name = "CuadroTarifarioToolStripMenuItem"
        Me.CuadroTarifarioToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.CuadroTarifarioToolStripMenuItem.Text = "Cuadro Tarifario"
        '
        'MedidoresDeLuzToolStripMenuItem
        '
        Me.MedidoresDeLuzToolStripMenuItem.Name = "MedidoresDeLuzToolStripMenuItem"
        Me.MedidoresDeLuzToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.MedidoresDeLuzToolStripMenuItem.Text = "Medidores de Luz"
        '
        'ConsumosFacturadosToolStripMenuItem
        '
        Me.ConsumosFacturadosToolStripMenuItem.Name = "ConsumosFacturadosToolStripMenuItem"
        Me.ConsumosFacturadosToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.ConsumosFacturadosToolStripMenuItem.Text = "Consumos Facturados"
        '
        'ProcesosToolStripMenuItem
        '
        Me.ProcesosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DevengarServiciosToolStripMenuItem, Me.EnviarMailServiciosPrestadosToolStripMenuItem, Me.FacturarServiciosToolStripMenuItem, Me.ActualizarUsFTPToolStripMenuItem})
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
        'FacturarServiciosToolStripMenuItem
        '
        Me.FacturarServiciosToolStripMenuItem.Name = "FacturarServiciosToolStripMenuItem"
        Me.FacturarServiciosToolStripMenuItem.Size = New System.Drawing.Size(235, 22)
        Me.FacturarServiciosToolStripMenuItem.Text = "&Facturar Servicios"
        '
        'ActualizarUsFTPToolStripMenuItem
        '
        Me.ActualizarUsFTPToolStripMenuItem.Name = "ActualizarUsFTPToolStripMenuItem"
        Me.ActualizarUsFTPToolStripMenuItem.Size = New System.Drawing.Size(235, 22)
        Me.ActualizarUsFTPToolStripMenuItem.Text = "&Actualizar UsFTP"
        '
        'AduditoríaToolStripMenuItem
        '
        Me.AduditoríaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EstadoDeCuentaGruposToolStripMenuItem, Me.ComprobantesToolStripMenuItem, Me.EstadoDeCuentaClientesToolStripMenuItem, Me.RegistroDeActualizacionesToolStripMenuItem, Me.EstadoUsFTPToolStripMenuItem, Me.ListaDeContratosToolStripMenuItem})
        Me.AduditoríaToolStripMenuItem.Name = "AduditoríaToolStripMenuItem"
        Me.AduditoríaToolStripMenuItem.Size = New System.Drawing.Size(68, 20)
        Me.AduditoríaToolStripMenuItem.Text = "Au&ditoría"
        '
        'EstadoDeCuentaGruposToolStripMenuItem
        '
        Me.EstadoDeCuentaGruposToolStripMenuItem.Name = "EstadoDeCuentaGruposToolStripMenuItem"
        Me.EstadoDeCuentaGruposToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.EstadoDeCuentaGruposToolStripMenuItem.Text = "&Estado de Cuenta Grupos"
        '
        'ComprobantesToolStripMenuItem
        '
        Me.ComprobantesToolStripMenuItem.Name = "ComprobantesToolStripMenuItem"
        Me.ComprobantesToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.ComprobantesToolStripMenuItem.Text = "&Comprobantes"
        '
        'EstadoDeCuentaClientesToolStripMenuItem
        '
        Me.EstadoDeCuentaClientesToolStripMenuItem.Name = "EstadoDeCuentaClientesToolStripMenuItem"
        Me.EstadoDeCuentaClientesToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.EstadoDeCuentaClientesToolStripMenuItem.Text = "Estado &de Cuenta Clientes"
        '
        'RegistroDeActualizacionesToolStripMenuItem
        '
        Me.RegistroDeActualizacionesToolStripMenuItem.Name = "RegistroDeActualizacionesToolStripMenuItem"
        Me.RegistroDeActualizacionesToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.RegistroDeActualizacionesToolStripMenuItem.Text = "&Registro de Actualizaciones"
        '
        'EstadoUsFTPToolStripMenuItem
        '
        Me.EstadoUsFTPToolStripMenuItem.Name = "EstadoUsFTPToolStripMenuItem"
        Me.EstadoUsFTPToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.EstadoUsFTPToolStripMenuItem.Text = "Estado &UsFTP"
        '
        'ListaDeContratosToolStripMenuItem
        '
        Me.ListaDeContratosToolStripMenuItem.Name = "ListaDeContratosToolStripMenuItem"
        Me.ListaDeContratosToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.ListaDeContratosToolStripMenuItem.Text = "Lista de Contratos"
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
        'btnCambiarContraseña
        '
        Me.btnCambiarContraseña.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnCambiarContraseña.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCambiarContraseña.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight
        Me.btnCambiarContraseña.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCambiarContraseña.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCambiarContraseña.Location = New System.Drawing.Point(673, 513)
        Me.btnCambiarContraseña.Name = "btnCambiarContraseña"
        Me.btnCambiarContraseña.Size = New System.Drawing.Size(163, 23)
        Me.btnCambiarContraseña.TabIndex = 13
        Me.btnCambiarContraseña.Text = "Mi Perfil >>"
        Me.btnCambiarContraseña.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCambiarContraseña.UseVisualStyleBackColor = False
        '
        'btnSeguridad
        '
        Me.btnSeguridad.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnSeguridad.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSeguridad.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight
        Me.btnSeguridad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSeguridad.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSeguridad.Location = New System.Drawing.Point(673, 539)
        Me.btnSeguridad.Name = "btnSeguridad"
        Me.btnSeguridad.Size = New System.Drawing.Size(163, 27)
        Me.btnSeguridad.TabIndex = 14
        Me.btnSeguridad.Text = "Cambiar Contraseña >>"
        Me.btnSeguridad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSeguridad.UseVisualStyleBackColor = False
        '
        'ClienteToolStripMenuItem
        '
        Me.ClienteToolStripMenuItem.Name = "ClienteToolStripMenuItem"
        Me.ClienteToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.ClienteToolStripMenuItem.Text = "&Cliente"
        '
        'FrmMDI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(848, 584)
        Me.Controls.Add(Me.btnSeguridad)
        Me.Controls.Add(Me.btnCambiarContraseña)
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
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents EstadoSecion As Label
    Friend WithEvents IdUsuario As Label
    Friend WithEvents Usuario As Label
    Friend WithEvents ProcesosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DevengarServiciosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EnviarMailServiciosPrestadosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AduditoríaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EstadoDeCuentaGruposToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CuadroTarifarioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MedidoresDeLuzToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ServiciosPrestadosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ComprobantesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EstadoDeCuentaClientesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FacturarServiciosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ActualizarUsFTPToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RegistroDeActualizacionesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EstadoUsFTPToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ListaDeContratosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnCambiarContraseña As Button
    Friend WithEvents btnSeguridad As Button
    Friend WithEvents OperacionesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PagoClientesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConsumoLuzToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContratosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConsumosFacturadosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClienteToolStripMenuItem As ToolStripMenuItem
End Class
