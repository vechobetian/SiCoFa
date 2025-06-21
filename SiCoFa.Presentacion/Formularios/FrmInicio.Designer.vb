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
        Me.mnuOperacionesCancelaCC = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOperacionesNC = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOperacionesCompras = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCajaAsientoGastos = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCajaRetiroEfCA = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCajaRetiroEfCB = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFiscalLibroIVA = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFiscalIVADigital = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFiscalIVAExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContabilidad = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResultadosMensualesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaldoCuentaPatrimonialesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AsientoContableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CancelarCuentasIncobraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CierreEjercicioAbiertoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CuentasCorrientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComprobantesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReporteDeVentasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CuentaProveedoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CuentasBancariaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CuentaEmpleadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MovimientoDeProductosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RankingDeVentaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSistemaPTerminal = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSistemaPSistema = New System.Windows.Forms.ToolStripMenuItem()
        Me.PermisosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOperaciones, Me.mnuCaja, Me.mnuFiscal, Me.mnuContabilidad, Me.mnuAuditoria, Me.mnuEdicion, Me.mnuHerramientas, Me.mnuSistema, Me.mnuAyuda})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnuOperaciones
        '
        Me.mnuOperaciones.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOperacionesFacturacion, Me.mnuOperacionesCancelaCC, Me.mnuOperacionesNC, Me.mnuOperacionesCompras})
        Me.mnuOperaciones.Name = "mnuOperaciones"
        Me.mnuOperaciones.Size = New System.Drawing.Size(85, 20)
        Me.mnuOperaciones.Text = "&Operaciones"
        '
        'mnuOperacionesFacturacion
        '
        Me.mnuOperacionesFacturacion.Name = "mnuOperacionesFacturacion"
        Me.mnuOperacionesFacturacion.Size = New System.Drawing.Size(237, 22)
        Me.mnuOperacionesFacturacion.Text = "&Facturacion"
        '
        'mnuCaja
        '
        Me.mnuCaja.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCajaMovimientos, Me.mnuCajaAsientoGastos, Me.mnuCajaRetiroEfCA, Me.mnuCajaRetiroEfCB})
        Me.mnuCaja.Name = "mnuCaja"
        Me.mnuCaja.Size = New System.Drawing.Size(42, 20)
        Me.mnuCaja.Text = "&Caja"
        '
        'mnuCajaMovimientos
        '
        Me.mnuCajaMovimientos.Name = "mnuCajaMovimientos"
        Me.mnuCajaMovimientos.Size = New System.Drawing.Size(239, 22)
        Me.mnuCajaMovimientos.Text = "&Movimientos de Caja"
        '
        'mnuFiscal
        '
        Me.mnuFiscal.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFiscalLibroIVA, Me.mnuFiscalIVADigital, Me.mnuFiscalIVAExcel})
        Me.mnuFiscal.Name = "mnuFiscal"
        Me.mnuFiscal.Size = New System.Drawing.Size(48, 20)
        Me.mnuFiscal.Text = "&Fiscal"
        '
        'mnuAuditoria
        '
        Me.mnuAuditoria.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CuentasCorrientesToolStripMenuItem, Me.ComprobantesToolStripMenuItem, Me.ReporteDeVentasToolStripMenuItem, Me.CuentaProveedoresToolStripMenuItem, Me.CuentasBancariaToolStripMenuItem, Me.CuentaEmpleadosToolStripMenuItem, Me.MovimientoDeProductosToolStripMenuItem, Me.RankingDeVentaToolStripMenuItem})
        Me.mnuAuditoria.Name = "mnuAuditoria"
        Me.mnuAuditoria.Size = New System.Drawing.Size(68, 20)
        Me.mnuAuditoria.Text = "&Auditoría"
        '
        'mnuEdicion
        '
        Me.mnuEdicion.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuEdicionArticulos, Me.mnuEdicionClientes, Me.mnuEdicionEmpleados, Me.mnuEdicionUsuarios, Me.mnuEdicionProveedores, Me.mnuEdicionSecciones, Me.mnuEdicionCuentasBancarias, Me.mnuEdicionMedioPE, Me.PermisosToolStripMenuItem})
        Me.mnuEdicion.Name = "mnuEdicion"
        Me.mnuEdicion.Size = New System.Drawing.Size(58, 20)
        Me.mnuEdicion.Text = "&Edición"
        '
        'mnuEdicionArticulos
        '
        Me.mnuEdicionArticulos.Name = "mnuEdicionArticulos"
        Me.mnuEdicionArticulos.Size = New System.Drawing.Size(180, 22)
        Me.mnuEdicionArticulos.Text = "Artículos"
        '
        'mnuEdicionClientes
        '
        Me.mnuEdicionClientes.Name = "mnuEdicionClientes"
        Me.mnuEdicionClientes.Size = New System.Drawing.Size(180, 22)
        Me.mnuEdicionClientes.Text = "Clientes"
        '
        'mnuEdicionEmpleados
        '
        Me.mnuEdicionEmpleados.Name = "mnuEdicionEmpleados"
        Me.mnuEdicionEmpleados.Size = New System.Drawing.Size(180, 22)
        Me.mnuEdicionEmpleados.Text = "Empleados"
        '
        'mnuEdicionUsuarios
        '
        Me.mnuEdicionUsuarios.Name = "mnuEdicionUsuarios"
        Me.mnuEdicionUsuarios.Size = New System.Drawing.Size(180, 22)
        Me.mnuEdicionUsuarios.Text = "Usuarios"
        '
        'mnuEdicionProveedores
        '
        Me.mnuEdicionProveedores.Name = "mnuEdicionProveedores"
        Me.mnuEdicionProveedores.Size = New System.Drawing.Size(180, 22)
        Me.mnuEdicionProveedores.Text = "Proveedores"
        '
        'mnuEdicionSecciones
        '
        Me.mnuEdicionSecciones.Name = "mnuEdicionSecciones"
        Me.mnuEdicionSecciones.Size = New System.Drawing.Size(180, 22)
        Me.mnuEdicionSecciones.Text = "Secciones"
        '
        'mnuEdicionCuentasBancarias
        '
        Me.mnuEdicionCuentasBancarias.Name = "mnuEdicionCuentasBancarias"
        Me.mnuEdicionCuentasBancarias.Size = New System.Drawing.Size(180, 22)
        Me.mnuEdicionCuentasBancarias.Text = "Cuentas Banco"
        '
        'mnuEdicionMedioPE
        '
        Me.mnuEdicionMedioPE.Name = "mnuEdicionMedioPE"
        Me.mnuEdicionMedioPE.Size = New System.Drawing.Size(180, 22)
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
        Me.mnuSistema.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSistemaPTerminal, Me.mnuSistemaPSistema})
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
        'mnuOperacionesCancelaCC
        '
        Me.mnuOperacionesCancelaCC.Name = "mnuOperacionesCancelaCC"
        Me.mnuOperacionesCancelaCC.Size = New System.Drawing.Size(237, 22)
        Me.mnuOperacionesCancelaCC.Text = "&Cancelacion Cuentas Corriente"
        '
        'mnuOperacionesNC
        '
        Me.mnuOperacionesNC.Name = "mnuOperacionesNC"
        Me.mnuOperacionesNC.Size = New System.Drawing.Size(237, 22)
        Me.mnuOperacionesNC.Text = "&Notas de Credito"
        '
        'mnuOperacionesCompras
        '
        Me.mnuOperacionesCompras.Name = "mnuOperacionesCompras"
        Me.mnuOperacionesCompras.Size = New System.Drawing.Size(237, 22)
        Me.mnuOperacionesCompras.Text = "Com&pras"
        '
        'mnuCajaAsientoGastos
        '
        Me.mnuCajaAsientoGastos.Name = "mnuCajaAsientoGastos"
        Me.mnuCajaAsientoGastos.Size = New System.Drawing.Size(239, 22)
        Me.mnuCajaAsientoGastos.Text = "&Asiendo de Gastos"
        '
        'mnuCajaRetiroEfCA
        '
        Me.mnuCajaRetiroEfCA.Name = "mnuCajaRetiroEfCA"
        Me.mnuCajaRetiroEfCA.Size = New System.Drawing.Size(239, 22)
        Me.mnuCajaRetiroEfCA.Text = "&Retiro Efectivo Caja Abierta"
        '
        'mnuCajaRetiroEfCB
        '
        Me.mnuCajaRetiroEfCB.Name = "mnuCajaRetiroEfCB"
        Me.mnuCajaRetiroEfCB.Size = New System.Drawing.Size(239, 22)
        Me.mnuCajaRetiroEfCB.Text = "Retiro Efectivo Cuenta &Bancaria"
        '
        'mnuFiscalLibroIVA
        '
        Me.mnuFiscalLibroIVA.Name = "mnuFiscalLibroIVA"
        Me.mnuFiscalLibroIVA.Size = New System.Drawing.Size(180, 22)
        Me.mnuFiscalLibroIVA.Text = "&Libro IVA"
        '
        'mnuFiscalIVADigital
        '
        Me.mnuFiscalIVADigital.Name = "mnuFiscalIVADigital"
        Me.mnuFiscalIVADigital.Size = New System.Drawing.Size(180, 22)
        Me.mnuFiscalIVADigital.Text = "Libro IVA &Digital"
        '
        'mnuFiscalIVAExcel
        '
        Me.mnuFiscalIVAExcel.Name = "mnuFiscalIVAExcel"
        Me.mnuFiscalIVAExcel.Size = New System.Drawing.Size(180, 22)
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
        'CuentasCorrientesToolStripMenuItem
        '
        Me.CuentasCorrientesToolStripMenuItem.Name = "CuentasCorrientesToolStripMenuItem"
        Me.CuentasCorrientesToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.CuentasCorrientesToolStripMenuItem.Text = "&Cuentas Corrientes"
        '
        'ComprobantesToolStripMenuItem
        '
        Me.ComprobantesToolStripMenuItem.Name = "ComprobantesToolStripMenuItem"
        Me.ComprobantesToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.ComprobantesToolStripMenuItem.Text = "Com&probantes"
        '
        'ReporteDeVentasToolStripMenuItem
        '
        Me.ReporteDeVentasToolStripMenuItem.Name = "ReporteDeVentasToolStripMenuItem"
        Me.ReporteDeVentasToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.ReporteDeVentasToolStripMenuItem.Text = "Reporte de &Ventas"
        '
        'CuentaProveedoresToolStripMenuItem
        '
        Me.CuentaProveedoresToolStripMenuItem.Name = "CuentaProveedoresToolStripMenuItem"
        Me.CuentaProveedoresToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.CuentaProveedoresToolStripMenuItem.Text = "Cuenta Provee&dores"
        '
        'CuentasBancariaToolStripMenuItem
        '
        Me.CuentasBancariaToolStripMenuItem.Name = "CuentasBancariaToolStripMenuItem"
        Me.CuentasBancariaToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.CuentasBancariaToolStripMenuItem.Text = "Cuentas &Bancarias"
        '
        'CuentaEmpleadosToolStripMenuItem
        '
        Me.CuentaEmpleadosToolStripMenuItem.Name = "CuentaEmpleadosToolStripMenuItem"
        Me.CuentaEmpleadosToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.CuentaEmpleadosToolStripMenuItem.Text = "Cuenta &Empleados"
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
        'PermisosToolStripMenuItem
        '
        Me.PermisosToolStripMenuItem.Name = "PermisosToolStripMenuItem"
        Me.PermisosToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.PermisosToolStripMenuItem.Text = "Permisos"
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
    Friend WithEvents mnuOperacionesCancelaCC As ToolStripMenuItem
    Friend WithEvents mnuOperacionesNC As ToolStripMenuItem
    Friend WithEvents mnuOperacionesCompras As ToolStripMenuItem
    Friend WithEvents mnuCajaAsientoGastos As ToolStripMenuItem
    Friend WithEvents mnuCajaRetiroEfCA As ToolStripMenuItem
    Friend WithEvents mnuCajaRetiroEfCB As ToolStripMenuItem
    Friend WithEvents mnuFiscalLibroIVA As ToolStripMenuItem
    Friend WithEvents mnuFiscalIVADigital As ToolStripMenuItem
    Friend WithEvents mnuFiscalIVAExcel As ToolStripMenuItem
    Friend WithEvents mnuContabilidad As ToolStripMenuItem
    Friend WithEvents ResultadosMensualesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaldoCuentaPatrimonialesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AsientoContableToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CancelarCuentasIncobraToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CierreEjercicioAbiertoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CuentasCorrientesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ComprobantesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReporteDeVentasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CuentaProveedoresToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CuentasBancariaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CuentaEmpleadosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MovimientoDeProductosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RankingDeVentaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuSistemaPTerminal As ToolStripMenuItem
    Friend WithEvents mnuSistemaPSistema As ToolStripMenuItem
    Friend WithEvents PermisosToolStripMenuItem As ToolStripMenuItem
End Class
