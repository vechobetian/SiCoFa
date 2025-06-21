<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmInicio
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnuOperaciones = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOperacionesFacturacion = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCaja = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCajaMovimientos = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFiscal = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAuditoria = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEdicion = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEdicionArticulos = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEdicionClientes = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEdicionEmpleados = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEdicionUsuarios = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEdicionProveedores = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEdicionSecciones = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEdicionCuentasBancarias = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEdicionMedioPE = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHerramientas = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSistema = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAyuda = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOperaciones, Me.mnuCaja, Me.mnuFiscal, Me.mnuAuditoria, Me.mnuEdicion, Me.mnuHerramientas, Me.mnuSistema, Me.mnuAyuda})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnuOperaciones
        '
        Me.mnuOperaciones.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOperacionesFacturacion})
        Me.mnuOperaciones.Name = "mnuOperaciones"
        Me.mnuOperaciones.Size = New System.Drawing.Size(85, 20)
        Me.mnuOperaciones.Text = "&Operaciones"
        '
        'mnuOperacionesFacturacion
        '
        Me.mnuOperacionesFacturacion.Name = "mnuOperacionesFacturacion"
        Me.mnuOperacionesFacturacion.Size = New System.Drawing.Size(136, 22)
        Me.mnuOperacionesFacturacion.Text = "Facturacion"
        '
        'mnuCaja
        '
        Me.mnuCaja.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCajaMovimientos})
        Me.mnuCaja.Name = "mnuCaja"
        Me.mnuCaja.Size = New System.Drawing.Size(42, 20)
        Me.mnuCaja.Text = "&Caja"
        '
        'mnuCajaMovimientos
        '
        Me.mnuCajaMovimientos.Name = "mnuCajaMovimientos"
        Me.mnuCajaMovimientos.Size = New System.Drawing.Size(186, 22)
        Me.mnuCajaMovimientos.Text = "&Movimientos de Caja"
        '
        'mnuFiscal
        '
        Me.mnuFiscal.Name = "mnuFiscal"
        Me.mnuFiscal.Size = New System.Drawing.Size(48, 20)
        Me.mnuFiscal.Text = "&Fiscal"
        '
        'mnuAuditoria
        '
        Me.mnuAuditoria.Name = "mnuAuditoria"
        Me.mnuAuditoria.Size = New System.Drawing.Size(68, 20)
        Me.mnuAuditoria.Text = "&Auditoría"
        '
        'mnuEdicion
        '
        Me.mnuEdicion.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuEdicionArticulos, Me.mnuEdicionClientes, Me.mnuEdicionEmpleados, Me.mnuEdicionUsuarios, Me.mnuEdicionProveedores, Me.mnuEdicionSecciones, Me.mnuEdicionCuentasBancarias, Me.mnuEdicionMedioPE})
        Me.mnuEdicion.Name = "mnuEdicion"
        Me.mnuEdicion.Size = New System.Drawing.Size(58, 20)
        Me.mnuEdicion.Text = "&Edición"
        '
        'mnuEdicionArticulos
        '
        Me.mnuEdicionArticulos.Name = "mnuEdicionArticulos"
        Me.mnuEdicionArticulos.Size = New System.Drawing.Size(159, 22)
        Me.mnuEdicionArticulos.Text = "Artículos"
        '
        'mnuEdicionClientes
        '
        Me.mnuEdicionClientes.Name = "mnuEdicionClientes"
        Me.mnuEdicionClientes.Size = New System.Drawing.Size(159, 22)
        Me.mnuEdicionClientes.Text = "Clientes"
        '
        'mnuEdicionEmpleados
        '
        Me.mnuEdicionEmpleados.Name = "mnuEdicionEmpleados"
        Me.mnuEdicionEmpleados.Size = New System.Drawing.Size(159, 22)
        Me.mnuEdicionEmpleados.Text = "Empleados"
        '
        'mnuEdicionUsuarios
        '
        Me.mnuEdicionUsuarios.Name = "mnuEdicionUsuarios"
        Me.mnuEdicionUsuarios.Size = New System.Drawing.Size(159, 22)
        Me.mnuEdicionUsuarios.Text = "Usuarios"
        '
        'mnuEdicionProveedores
        '
        Me.mnuEdicionProveedores.Name = "mnuEdicionProveedores"
        Me.mnuEdicionProveedores.Size = New System.Drawing.Size(159, 22)
        Me.mnuEdicionProveedores.Text = "Proveedores"
        '
        'mnuEdicionSecciones
        '
        Me.mnuEdicionSecciones.Name = "mnuEdicionSecciones"
        Me.mnuEdicionSecciones.Size = New System.Drawing.Size(159, 22)
        Me.mnuEdicionSecciones.Text = "Secciones"
        '
        'mnuEdicionCuentasBancarias
        '
        Me.mnuEdicionCuentasBancarias.Name = "mnuEdicionCuentasBancarias"
        Me.mnuEdicionCuentasBancarias.Size = New System.Drawing.Size(159, 22)
        Me.mnuEdicionCuentasBancarias.Text = "Cuentas Banco"
        '
        'mnuEdicionMedioPE
        '
        Me.mnuEdicionMedioPE.Name = "mnuEdicionMedioPE"
        Me.mnuEdicionMedioPE.Size = New System.Drawing.Size(159, 22)
        Me.mnuEdicionMedioPE.Text = "Medios de Pago"
        '
        'mnuHerramientas
        '
        Me.mnuHerramientas.Name = "mnuHerramientas"
        Me.mnuHerramientas.Size = New System.Drawing.Size(90, 20)
        Me.mnuHerramientas.Text = "&Herramientas"
        '
        'mnuSistema
        '
        Me.mnuSistema.Name = "mnuSistema"
        Me.mnuSistema.Size = New System.Drawing.Size(60, 20)
        Me.mnuSistema.Text = "&Sistema"
        '
        'mnuAyuda
        '
        Me.mnuAyuda.Name = "mnuAyuda"
        Me.mnuAyuda.Size = New System.Drawing.Size(53, 20)
        Me.mnuAyuda.Text = "Ay&uda"
        '
        'FrmInicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FrmInicio"
        Me.Text = "Gestión SiCoFa"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents mnuOperaciones As ToolStripMenuItem
    Friend WithEvents mnuCaja As ToolStripMenuItem
    Friend WithEvents mnuFiscal As ToolStripMenuItem
    Friend WithEvents mnuAuditoria As ToolStripMenuItem
    Friend WithEvents mnuEdicion As ToolStripMenuItem
    Friend WithEvents mnuHerramientas As ToolStripMenuItem
    Friend WithEvents mnuSistema As ToolStripMenuItem
    Friend WithEvents mnuAyuda As ToolStripMenuItem
    Friend WithEvents mnuOperacionesFacturacion As ToolStripMenuItem
    Friend WithEvents mnuEdicionArticulos As ToolStripMenuItem
    Friend WithEvents mnuEdicionClientes As ToolStripMenuItem
    Friend WithEvents mnuEdicionEmpleados As ToolStripMenuItem
    Friend WithEvents mnuEdicionUsuarios As ToolStripMenuItem
    Friend WithEvents mnuEdicionProveedores As ToolStripMenuItem
    Friend WithEvents mnuEdicionSecciones As ToolStripMenuItem
    Friend WithEvents mnuEdicionCuentasBancarias As ToolStripMenuItem
    Friend WithEvents mnuEdicionMedioPE As ToolStripMenuItem
    Friend WithEvents mnuCajaMovimientos As ToolStripMenuItem
End Class
