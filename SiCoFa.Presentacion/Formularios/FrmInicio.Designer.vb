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
        Me.mnuOperacionesCC = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOperacionesCompras = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOperacionesPresupuestos = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCaja = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCajaMovimientos = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCajaAsientoGastos = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFiscal = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFiscalLibroIVA = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFiscalIVADigital = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFiscalIVAExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContabilidad = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResultadosMensualesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaldoCuentaPatrimonialesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AsientoContableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CancelarCuentasIncobraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CierreEjercicioAbiertoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAuditoria = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAuditoriaCuentasCorrientes = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAuditoriaComprobantes = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAuditoriaComprobantesEmitidos = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAuditoriaComprobantesRecibidos = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAuditoriaReporteVentas = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAuditoriaCuentasProveedores = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAuditoriaCuentasBancarias = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAuditoriaCuentasEmpleados = New System.Windows.Forms.ToolStripMenuItem()
        Me.MovimientoDeProductosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RankingDeVentaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditarArticulos = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditarClientes = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditarEmpleados = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditarUsuarios = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditarProveedores = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditarSecciones = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditarCuentasBancarias = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditarMedioPE = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditarPermisos = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHerramientas = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSistema = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSistemaPTerminal = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSistemaPSistema = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAyuda = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOperaciones, Me.mnuCaja, Me.mnuFiscal, Me.mnuContabilidad, Me.mnuAuditoria, Me.mnuEditar, Me.mnuHerramientas, Me.mnuSistema, Me.mnuAyuda})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnuOperaciones
        '
        Me.mnuOperaciones.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOperacionesFacturacion, Me.mnuOperacionesCC, Me.mnuOperacionesCompras, Me.mnuOperacionesPresupuestos})
        Me.mnuOperaciones.Name = "mnuOperaciones"
        Me.mnuOperaciones.Size = New System.Drawing.Size(85, 20)
        Me.mnuOperaciones.Text = "&Operaciones"
        '
        'mnuOperacionesFacturacion
        '
        Me.mnuOperacionesFacturacion.Name = "mnuOperacionesFacturacion"
        Me.mnuOperacionesFacturacion.Size = New System.Drawing.Size(233, 22)
        Me.mnuOperacionesFacturacion.Text = "&Facturacion"
        '
        'mnuOperacionesCC
        '
        Me.mnuOperacionesCC.Name = "mnuOperacionesCC"
        Me.mnuOperacionesCC.Size = New System.Drawing.Size(233, 22)
        Me.mnuOperacionesCC.Text = "&Operaciones Cuenta Corriente"
        '
        'mnuOperacionesCompras
        '
        Me.mnuOperacionesCompras.Name = "mnuOperacionesCompras"
        Me.mnuOperacionesCompras.Size = New System.Drawing.Size(233, 22)
        Me.mnuOperacionesCompras.Text = "Com&pras"
        '
        'mnuOperacionesPresupuestos
        '
        Me.mnuOperacionesPresupuestos.Name = "mnuOperacionesPresupuestos"
        Me.mnuOperacionesPresupuestos.Size = New System.Drawing.Size(233, 22)
        Me.mnuOperacionesPresupuestos.Text = "Pre&supuestos"
        '
        'mnuCaja
        '
        Me.mnuCaja.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCajaMovimientos, Me.mnuCajaAsientoGastos})
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
        'mnuCajaAsientoGastos
        '
        Me.mnuCajaAsientoGastos.Name = "mnuCajaAsientoGastos"
        Me.mnuCajaAsientoGastos.Size = New System.Drawing.Size(186, 22)
        Me.mnuCajaAsientoGastos.Text = "&Asiendo de Gastos"
        '
        'mnuFiscal
        '
        Me.mnuFiscal.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFiscalLibroIVA, Me.mnuFiscalIVADigital, Me.mnuFiscalIVAExcel})
        Me.mnuFiscal.Name = "mnuFiscal"
        Me.mnuFiscal.Size = New System.Drawing.Size(48, 20)
        Me.mnuFiscal.Text = "&Fiscal"
        '
        'mnuFiscalLibroIVA
        '
        Me.mnuFiscalLibroIVA.Name = "mnuFiscalLibroIVA"
        Me.mnuFiscalLibroIVA.Size = New System.Drawing.Size(158, 22)
        Me.mnuFiscalLibroIVA.Text = "&Libro IVA"
        '
        'mnuFiscalIVADigital
        '
        Me.mnuFiscalIVADigital.Name = "mnuFiscalIVADigital"
        Me.mnuFiscalIVADigital.Size = New System.Drawing.Size(158, 22)
        Me.mnuFiscalIVADigital.Text = "Libro IVA &Digital"
        '
        'mnuFiscalIVAExcel
        '
        Me.mnuFiscalIVAExcel.Name = "mnuFiscalIVAExcel"
        Me.mnuFiscalIVAExcel.Size = New System.Drawing.Size(158, 22)
        Me.mnuFiscalIVAExcel.Text = "Libro IVA &Excel"
        '
        'mnuContabilidad
        '
        Me.mnuContabilidad.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ResultadosMensualesToolStripMenuItem, Me.SaldoCuentaPatrimonialesToolStripMenuItem, Me.AsientoContableToolStripMenuItem, Me.CancelarCuentasIncobraToolStripMenuItem, Me.CierreEjercicioAbiertoToolStripMenuItem})
        Me.mnuContabilidad.Name = "mnuContabilidad"
        Me.mnuContabilidad.Size = New System.Drawing.Size(87, 20)
        Me.mnuContabilidad.Text = "Con&tabilidad"
        '
        'ResultadosMensualesToolStripMenuItem
        '
        Me.ResultadosMensualesToolStripMenuItem.Name = "ResultadosMensualesToolStripMenuItem"
        Me.ResultadosMensualesToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.ResultadosMensualesToolStripMenuItem.Text = "&Resultados Mensuales"
        '
        'SaldoCuentaPatrimonialesToolStripMenuItem
        '
        Me.SaldoCuentaPatrimonialesToolStripMenuItem.Name = "SaldoCuentaPatrimonialesToolStripMenuItem"
        Me.SaldoCuentaPatrimonialesToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.SaldoCuentaPatrimonialesToolStripMenuItem.Text = "&Saldo Cuenta Patrimoniales"
        '
        'AsientoContableToolStripMenuItem
        '
        Me.AsientoContableToolStripMenuItem.Name = "AsientoContableToolStripMenuItem"
        Me.AsientoContableToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.AsientoContableToolStripMenuItem.Text = "&Asiento Contable"
        '
        'CancelarCuentasIncobraToolStripMenuItem
        '
        Me.CancelarCuentasIncobraToolStripMenuItem.Name = "CancelarCuentasIncobraToolStripMenuItem"
        Me.CancelarCuentasIncobraToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.CancelarCuentasIncobraToolStripMenuItem.Text = "&Cancelar Cuentas Incobrables"
        '
        'CierreEjercicioAbiertoToolStripMenuItem
        '
        Me.CierreEjercicioAbiertoToolStripMenuItem.Name = "CierreEjercicioAbiertoToolStripMenuItem"
        Me.CierreEjercicioAbiertoToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.CierreEjercicioAbiertoToolStripMenuItem.Text = "Cierre &Ejercicio Abierto"
        '
        'mnuAuditoria
        '
        Me.mnuAuditoria.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAuditoriaCuentasCorrientes, Me.mnuAuditoriaComprobantes, Me.mnuAuditoriaReporteVentas, Me.mnuAuditoriaCuentasProveedores, Me.mnuAuditoriaCuentasBancarias, Me.mnuAuditoriaCuentasEmpleados, Me.MovimientoDeProductosToolStripMenuItem, Me.RankingDeVentaToolStripMenuItem})
        Me.mnuAuditoria.Name = "mnuAuditoria"
        Me.mnuAuditoria.Size = New System.Drawing.Size(68, 20)
        Me.mnuAuditoria.Text = "&Auditoría"
        '
        'mnuAuditoriaCuentasCorrientes
        '
        Me.mnuAuditoriaCuentasCorrientes.Name = "mnuAuditoriaCuentasCorrientes"
        Me.mnuAuditoriaCuentasCorrientes.Size = New System.Drawing.Size(205, 22)
        Me.mnuAuditoriaCuentasCorrientes.Text = "&Cuentas Corrientes"
        '
        'mnuAuditoriaComprobantes
        '
        Me.mnuAuditoriaComprobantes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAuditoriaComprobantesEmitidos, Me.mnuAuditoriaComprobantesRecibidos})
        Me.mnuAuditoriaComprobantes.Name = "mnuAuditoriaComprobantes"
        Me.mnuAuditoriaComprobantes.Size = New System.Drawing.Size(205, 22)
        Me.mnuAuditoriaComprobantes.Text = "Com&probantes"
        '
        'mnuAuditoriaComprobantesEmitidos
        '
        Me.mnuAuditoriaComprobantesEmitidos.Name = "mnuAuditoriaComprobantesEmitidos"
        Me.mnuAuditoriaComprobantesEmitidos.Size = New System.Drawing.Size(207, 22)
        Me.mnuAuditoriaComprobantesEmitidos.Text = "Comprobantes &Emitidos"
        '
        'mnuAuditoriaComprobantesRecibidos
        '
        Me.mnuAuditoriaComprobantesRecibidos.Name = "mnuAuditoriaComprobantesRecibidos"
        Me.mnuAuditoriaComprobantesRecibidos.Size = New System.Drawing.Size(207, 22)
        Me.mnuAuditoriaComprobantesRecibidos.Text = "Comprobantes &Recibidos"
        '
        'mnuAuditoriaReporteVentas
        '
        Me.mnuAuditoriaReporteVentas.Name = "mnuAuditoriaReporteVentas"
        Me.mnuAuditoriaReporteVentas.Size = New System.Drawing.Size(205, 22)
        Me.mnuAuditoriaReporteVentas.Text = "Reporte de &Ventas"
        '
        'mnuAuditoriaCuentasProveedores
        '
        Me.mnuAuditoriaCuentasProveedores.Name = "mnuAuditoriaCuentasProveedores"
        Me.mnuAuditoriaCuentasProveedores.Size = New System.Drawing.Size(205, 22)
        Me.mnuAuditoriaCuentasProveedores.Text = "Cuenta Provee&dores"
        '
        'mnuAuditoriaCuentasBancarias
        '
        Me.mnuAuditoriaCuentasBancarias.Name = "mnuAuditoriaCuentasBancarias"
        Me.mnuAuditoriaCuentasBancarias.Size = New System.Drawing.Size(205, 22)
        Me.mnuAuditoriaCuentasBancarias.Text = "Cuentas &Bancarias"
        '
        'mnuAuditoriaCuentasEmpleados
        '
        Me.mnuAuditoriaCuentasEmpleados.Name = "mnuAuditoriaCuentasEmpleados"
        Me.mnuAuditoriaCuentasEmpleados.Size = New System.Drawing.Size(205, 22)
        Me.mnuAuditoriaCuentasEmpleados.Text = "Cuenta &Empleados"
        '
        'MovimientoDeProductosToolStripMenuItem
        '
        Me.MovimientoDeProductosToolStripMenuItem.Name = "MovimientoDeProductosToolStripMenuItem"
        Me.MovimientoDeProductosToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.MovimientoDeProductosToolStripMenuItem.Text = "Movimiento de &Articulos"
        '
        'RankingDeVentaToolStripMenuItem
        '
        Me.RankingDeVentaToolStripMenuItem.Name = "RankingDeVentaToolStripMenuItem"
        Me.RankingDeVentaToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.RankingDeVentaToolStripMenuItem.Text = "Ranking de &Venta"
        '
        'mnuEditar
        '
        Me.mnuEditar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuEditarArticulos, Me.mnuEditarClientes, Me.mnuEditarEmpleados, Me.mnuEditarUsuarios, Me.mnuEditarProveedores, Me.mnuEditarSecciones, Me.mnuEditarCuentasBancarias, Me.mnuEditarMedioPE, Me.mnuEditarPermisos})
        Me.mnuEditar.Name = "mnuEditar"
        Me.mnuEditar.Size = New System.Drawing.Size(49, 20)
        Me.mnuEditar.Text = "&Editar"
        '
        'mnuEditarArticulos
        '
        Me.mnuEditarArticulos.Name = "mnuEditarArticulos"
        Me.mnuEditarArticulos.Size = New System.Drawing.Size(159, 22)
        Me.mnuEditarArticulos.Text = "Artículos"
        '
        'mnuEditarClientes
        '
        Me.mnuEditarClientes.Name = "mnuEditarClientes"
        Me.mnuEditarClientes.Size = New System.Drawing.Size(159, 22)
        Me.mnuEditarClientes.Text = "Clientes"
        '
        'mnuEditarEmpleados
        '
        Me.mnuEditarEmpleados.Name = "mnuEditarEmpleados"
        Me.mnuEditarEmpleados.Size = New System.Drawing.Size(159, 22)
        Me.mnuEditarEmpleados.Text = "Empleados"
        '
        'mnuEditarUsuarios
        '
        Me.mnuEditarUsuarios.Name = "mnuEditarUsuarios"
        Me.mnuEditarUsuarios.Size = New System.Drawing.Size(159, 22)
        Me.mnuEditarUsuarios.Text = "Usuarios"
        '
        'mnuEditarProveedores
        '
        Me.mnuEditarProveedores.Name = "mnuEditarProveedores"
        Me.mnuEditarProveedores.Size = New System.Drawing.Size(159, 22)
        Me.mnuEditarProveedores.Text = "Proveedores"
        '
        'mnuEditarSecciones
        '
        Me.mnuEditarSecciones.Name = "mnuEditarSecciones"
        Me.mnuEditarSecciones.Size = New System.Drawing.Size(159, 22)
        Me.mnuEditarSecciones.Text = "Secciones"
        '
        'mnuEditarCuentasBancarias
        '
        Me.mnuEditarCuentasBancarias.Name = "mnuEditarCuentasBancarias"
        Me.mnuEditarCuentasBancarias.Size = New System.Drawing.Size(159, 22)
        Me.mnuEditarCuentasBancarias.Text = "Cuentas Banco"
        '
        'mnuEditarMedioPE
        '
        Me.mnuEditarMedioPE.Name = "mnuEditarMedioPE"
        Me.mnuEditarMedioPE.Size = New System.Drawing.Size(159, 22)
        Me.mnuEditarMedioPE.Text = "Medios de Pago"
        '
        'mnuEditarPermisos
        '
        Me.mnuEditarPermisos.Name = "mnuEditarPermisos"
        Me.mnuEditarPermisos.Size = New System.Drawing.Size(159, 22)
        Me.mnuEditarPermisos.Text = "Permisos"
        '
        'mnuHerramientas
        '
        Me.mnuHerramientas.Name = "mnuHerramientas"
        Me.mnuHerramientas.Size = New System.Drawing.Size(90, 20)
        Me.mnuHerramientas.Text = "&Herramientas"
        '
        'mnuSistema
        '
        Me.mnuSistema.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSistemaPTerminal, Me.mnuSistemaPSistema})
        Me.mnuSistema.Name = "mnuSistema"
        Me.mnuSistema.Size = New System.Drawing.Size(60, 20)
        Me.mnuSistema.Text = "&Sistema"
        '
        'mnuSistemaPTerminal
        '
        Me.mnuSistemaPTerminal.Name = "mnuSistemaPTerminal"
        Me.mnuSistemaPTerminal.Size = New System.Drawing.Size(194, 22)
        Me.mnuSistemaPTerminal.Text = "Parametros &Terminal"
        '
        'mnuSistemaPSistema
        '
        Me.mnuSistemaPSistema.Name = "mnuSistemaPSistema"
        Me.mnuSistemaPSistema.Size = New System.Drawing.Size(194, 22)
        Me.mnuSistemaPSistema.Text = "Parametros de &Sistema"
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
    Friend WithEvents mnuEditar As ToolStripMenuItem
    Friend WithEvents mnuHerramientas As ToolStripMenuItem
    Friend WithEvents mnuSistema As ToolStripMenuItem
    Friend WithEvents mnuAyuda As ToolStripMenuItem
    Friend WithEvents mnuOperacionesFacturacion As ToolStripMenuItem
    Friend WithEvents mnuEditarArticulos As ToolStripMenuItem
    Friend WithEvents mnuEditarClientes As ToolStripMenuItem
    Friend WithEvents mnuEditarEmpleados As ToolStripMenuItem
    Friend WithEvents mnuEditarUsuarios As ToolStripMenuItem
    Friend WithEvents mnuEditarProveedores As ToolStripMenuItem
    Friend WithEvents mnuEditarSecciones As ToolStripMenuItem
    Friend WithEvents mnuEditarCuentasBancarias As ToolStripMenuItem
    Friend WithEvents mnuEditarMedioPE As ToolStripMenuItem
    Friend WithEvents mnuCajaMovimientos As ToolStripMenuItem
    Friend WithEvents mnuOperacionesCC As ToolStripMenuItem
    Friend WithEvents mnuOperacionesCompras As ToolStripMenuItem
    Friend WithEvents mnuCajaAsientoGastos As ToolStripMenuItem
    Friend WithEvents mnuFiscalLibroIVA As ToolStripMenuItem
    Friend WithEvents mnuFiscalIVADigital As ToolStripMenuItem
    Friend WithEvents mnuFiscalIVAExcel As ToolStripMenuItem
    Friend WithEvents mnuContabilidad As ToolStripMenuItem
    Friend WithEvents ResultadosMensualesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaldoCuentaPatrimonialesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AsientoContableToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CancelarCuentasIncobraToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CierreEjercicioAbiertoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuAuditoriaCuentasCorrientes As ToolStripMenuItem
    Friend WithEvents mnuAuditoriaComprobantes As ToolStripMenuItem
    Friend WithEvents mnuAuditoriaReporteVentas As ToolStripMenuItem
    Friend WithEvents mnuAuditoriaCuentasProveedores As ToolStripMenuItem
    Friend WithEvents mnuAuditoriaCuentasBancarias As ToolStripMenuItem
    Friend WithEvents mnuAuditoriaCuentasEmpleados As ToolStripMenuItem
    Friend WithEvents MovimientoDeProductosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RankingDeVentaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuSistemaPTerminal As ToolStripMenuItem
    Friend WithEvents mnuSistemaPSistema As ToolStripMenuItem
    Friend WithEvents mnuEditarPermisos As ToolStripMenuItem
    Friend WithEvents mnuAuditoriaComprobantesEmitidos As ToolStripMenuItem
    Friend WithEvents mnuAuditoriaComprobantesRecibidos As ToolStripMenuItem
    Friend WithEvents mnuOperacionesPresupuestos As ToolStripMenuItem
End Class
