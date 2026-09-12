Imports System.IO
Imports System.Text
Imports System.Threading.Tasks
Imports SiCoFa.Entidades
Imports SiCoFa.Negocio

Public Class FrmInicio

    ' Variables para seguimiento de progreso
    Private mActualizacionEnCurso As Boolean = False
    Private mTotalArchivos As Integer = 0
    Private mArchivosProcesados As Integer = 0
    Private mPorcentajeAvance As Integer = 0
    Private mNotifyIcon As NotifyIcon

    ' Variable para el timer declarada a nivel de formulario
    Private WithEvents mTimerActualizaciones As System.Windows.Forms.Timer

    Private Sub InicializarNotificador()
        If mNotifyIcon Is Nothing Then
            mNotifyIcon = New NotifyIcon()
            mNotifyIcon.Icon = Me.Icon ' Usa el mismo ícono del formulario principal
            mNotifyIcon.Visible = True
            mNotifyIcon.Text = "SiCoFa - Sistema de Gestión"
        End If
    End Sub

    Private Sub NotificarProgreso(ByVal titulo As String, ByVal mensaje As String)
        If mNotifyIcon IsNot Nothing Then
            mNotifyIcon.Text = $"SiCoFa: {mPorcentajeAvance}% completado"
            mNotifyIcon.BalloonTipTitle = titulo
            mNotifyIcon.BalloonTipText = mensaje
            mNotifyIcon.BalloonTipIcon = ToolTipIcon.Info
            mNotifyIcon.ShowBalloonTip(3000)
        End If
    End Sub

    Private Async Function EjecutarActualizacionAutomatica() As Task

        If g_ParametrosTerminal.Actualizar = 0 Then
            Return
        End If

        If mActualizacionEnCurso Then
            Return
        End If

        mActualizacionEnCurso = True

        Try
            Dim frmActualizaciones As New FrmActualizaciones()

            ' Suscripción al evento: SOLO se disparará cuando FrmActualizaciones 
            ' empiece a descargar o procesar archivos reales.
            frmActualizaciones.OnProgresoCambiado = Sub(porcentaje As Integer, mensaje As String)
                                                        mPorcentajeAvance = porcentaje

                                                        ' Si la actualización notifica que no hay novedades, no mostramos globo
                                                        If mensaje.Contains("No hay actualizaciones") Then
                                                            Return
                                                        End If

                                                        If Me.InvokeRequired Then
                                                            Me.Invoke(Sub() NotificarProgreso($"SiCoFa ({porcentaje}%)", mensaje))
                                                        Else
                                                            NotificarProgreso($"SiCoFa ({porcentaje}%)", mensaje)
                                                        End If
                                                    End Sub

            Try
                ' Ejecuta la búsqueda y actualización en segundo plano silenciosamente
                Await frmActualizaciones.ActualizarAutomaticamente()

            Finally
                frmActualizaciones.Dispose()
            End Try

        Catch ex As Exception
            ' Si ocurre un error real, notificamos discretamente
            If mNotifyIcon IsNot Nothing Then
                mNotifyIcon.BalloonTipTitle = "SiCoFa"
                mNotifyIcon.BalloonTipText = "No se pudo completar la actualización de datos."
                mNotifyIcon.BalloonTipIcon = ToolTipIcon.Warning
                mNotifyIcon.ShowBalloonTip(4000)
            End If
        Finally
            mActualizacionEnCurso = False
        End Try

    End Function

    Private Sub mnuOperacionesFacturacion_Click(sender As Object, e As EventArgs) Handles mnuOperacionesFacturacion.Click

        Dim u As Usuario = ModSeguridad.ValidarUsuario(mnuOperacionesFacturacion.Name)

        If u IsNot Nothing Then
            Dim nuevaVentanaVentas As New FrmVentas()
            nuevaVentanaVentas.Usuario = u
            nuevaVentanaVentas.Show()
        End If

    End Sub

    Private Sub mnuOperacionesCC_Click(sender As Object, e As EventArgs) Handles mnuOperacionesCC.Click

        Dim u As Usuario = ModSeguridad.ValidarUsuario(mnuOperacionesCC.Name)

        If u IsNot Nothing Then
            Dim nuevaVentanaOperacionesCC As New FrmOperacionesCC()
            nuevaVentanaOperacionesCC.Usuario = u
            nuevaVentanaOperacionesCC.ShowDialog()
        End If

    End Sub

    Private Sub mnuOperacionesCompras_Click(sender As Object, e As EventArgs) Handles mnuOperacionesCompras.Click

        Dim u As Usuario = ModSeguridad.ValidarUsuario(Me.mnuOperacionesCompras.Name)

        If u IsNot Nothing Then
            Dim nuevaVentanaCompras As New FrmCompras()
            nuevaVentanaCompras.Usuario = u
            nuevaVentanaCompras.Show()
        End If

    End Sub

    Private Sub mnuOperacionesPresupuestos_Click(sender As Object, e As EventArgs) Handles mnuOperacionesPresupuestos.Click
        Dim u As Usuario = ModSeguridad.ValidarUsuario(Me.mnuOperacionesPresupuestos.Name)

        If u IsNot Nothing Then
            Dim nuevoVentanaPresupuestos As New FrmPresupuestos()
            nuevoVentanaPresupuestos.Usuario = u
            nuevoVentanaPresupuestos.Show()
        End If

    End Sub

    Private Sub mnuCajaMovimientos_Click(sender As Object, e As EventArgs) Handles mnuCajaMovimientos.Click

        Dim u As Usuario = ModSeguridad.ValidarUsuario(Me.mnuCajaMovimientos.Name)

        If u Is Nothing Then
            Exit Sub
        End If

        FrmCajas.Usuario = u
        FrmCajas.Show()

    End Sub

    Private Sub mnuCajaAsientoGastos_Click(sender As Object, e As EventArgs) Handles mnuCajaAsientoGastos.Click

        Dim nuevoAsientoGastos As New FrmAsientoGastos()
        nuevoAsientoGastos.Usuario = ModSeguridad.ValidarUsuario(Me.mnuCajaAsientoGastos.Name)
        nuevoAsientoGastos.Show()

    End Sub

    Private Sub mnuContabilidadResultadosMensuales_Click(sender As Object, e As EventArgs) Handles mnuContabilidadResultadosMensuales.Click

        Try

            Dim User As Usuario = ModSeguridad.ValidarUsuario(Me.mnuContabilidadResultadosMensuales.Name)

            If User Is Nothing Then
                Exit Sub
            End If

            Dim frm As New FrmResultadosMensuales()
            frm.Show()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub mnuEditarArticulos_Click(sender As Object, e As EventArgs) Handles mnuEditarArticulos.Click

        If ModSeguridad.ValidarUsuario(Me.mnuEditarArticulos.Name) Is Nothing Then
            Exit Sub
        End If

        Dim f As New FrmArticulos()
        f.Show()

    End Sub

    Private Sub mnuEditarFraccionables_Click(sender As Object, e As EventArgs) Handles mnuEditarFraccionables.Click

        If ModSeguridad.ValidarUsuario(Me.mnuEditarFraccionables.Name) Is Nothing Then
            Exit Sub
        End If

        Dim f As New FrmFraccionables()
        f.Show()

    End Sub

    Private Sub mnuEditarClientes_Click(sender As Object, e As EventArgs) Handles mnuEditarClientes.Click

        If ModSeguridad.ValidarUsuario(Me.mnuEditarClientes.Name) Is Nothing Then
            Exit Sub
        End If

        Dim f As New FrmPanelClientes
        f.Show()

    End Sub

    Private Sub mnuEditarEmpleados_Click(sender As Object, e As EventArgs) Handles mnuEditarEmpleados.Click
        If ModSeguridad.ValidarUsuario(Me.mnuEditarEmpleados.Name) Is Nothing Then
            Exit Sub
        End If

        Dim f As New FrmEmpleados
        f.Show()

    End Sub

    Private Sub mnuEditarMedioPE_Click(sender As Object, e As EventArgs) Handles mnuEditarMedioPE.Click

        If ModSeguridad.ValidarUsuario(Me.mnuEditarMedioPE.Name) Is Nothing Then
            Exit Sub
        End If

        Dim f As New FrmMediosPE
        f.Show()

    End Sub

    Private Sub mnuEditarUsuarios_Click(sender As Object, e As EventArgs) Handles mnuEditarUsuarios.Click
        Try

            If ModSeguridad.ValidarUsuario(Me.mnuEditarUsuarios.Name) Is Nothing Then
                Exit Sub
            End If

            Dim f As New FrmUsuarios()
            f.Show()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub mnuEditarProveedores_Click(sender As Object, e As EventArgs) Handles mnuEditarProveedores.Click
        Try
            Dim User As Usuario = ModSeguridad.ValidarUsuario(Me.mnuEditarProveedores.Name)

            If User Is Nothing Then
                Exit Sub
            End If

            Dim frm As New FrmProveedores()
            frm.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try
    End Sub

    Private Sub mnuEditarPermisos_Click(sender As Object, e As EventArgs) Handles mnuEditarPermisos.Click

        Try

            Dim User As Usuario = ModSeguridad.ValidarUsuario(Me.mnuEditarPermisos.Name)

            If User Is Nothing Then
                Exit Sub
            End If

            Dim frm As New FrmPermisos()
            frm.Usuario = User
            frm.MenuPrincipal = Me.MenuStrip1
            frm.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub mnuAuditoriaCuentasCorrientes_Click(sender As Object, e As EventArgs) Handles mnuAuditoriaCuentasCorrientes.Click

        Try

            Dim User As Usuario = ModSeguridad.ValidarUsuario(Me.mnuAuditoriaCuentasCorrientes.Name)

            If User Is Nothing Then
                Exit Sub
            End If

            Dim frm As New FrmIngresoMomientosCC()
            frm.Show()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub mnuAuditoriaComprobantesEmitidos_Click(sender As Object, e As EventArgs) Handles mnuAuditoriaComprobantesEmitidos.Click
        Try

            Dim User As Usuario = ModSeguridad.ValidarUsuario(Me.mnuAuditoriaComprobantesEmitidos.Name)

            If User Is Nothing Then
                Exit Sub
            End If

            Dim frm As New FrmIngresoComprobantesEmitidos()
            frm.Show()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub mnuAuditoriaComprobantesRecibidos_Click(sender As Object, e As EventArgs) Handles mnuAuditoriaComprobantesRecibidos.Click
        Try

            Dim User As Usuario = ModSeguridad.ValidarUsuario(Me.mnuAuditoriaComprobantesEmitidos.Name)

            If User Is Nothing Then
                Exit Sub
            End If

            Dim frm As New FrmIngresoComprobantesRecibidos()
            frm.Show()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub mnuAuditoriaReporteVentas_Click(sender As Object, e As EventArgs) Handles mnuAuditoriaReporteVentas.Click

        Try

            Dim User As Usuario = ModSeguridad.ValidarUsuario(Me.mnuAuditoriaReporteVentas.Name)

            If User Is Nothing Then
                Exit Sub
            End If

            Dim frm As New FrmIngresoReporteVentas()
            frm.Show()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub CuentasBancariaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuAuditoriaCuentasBancarias.Click
        Try

            Dim User As Usuario = ModSeguridad.ValidarUsuario(Me.mnuAuditoriaCuentasBancarias.Name)

            If User Is Nothing Then
                Exit Sub
            End If

            Dim frm As New FrmIngresoMomientosCB()
            frm.Show()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub ActualizacionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActualizacionesToolStripMenuItem.Click
        FrmActualizaciones.Show()
    End Sub

    Private Sub mnuEditarSecciones_Click(sender As Object, e As EventArgs) Handles mnuEditarSecciones.Click
        If ModSeguridad.ValidarUsuario(Me.mnuEditarSecciones.Name) Is Nothing Then
            Exit Sub
        End If

        Dim f As New FrmSecciones
        f.Show()

    End Sub

    Private Sub mnuEditarCuentasBancarias_Click(sender As Object, e As EventArgs) Handles mnuEditarCuentasBancarias.Click

    End Sub

    Private Sub ConfigurarFondoMDI()
        Dim mdiClient As MdiClient = ObtenerMdiClient(Me)
        If mdiClient IsNot Nothing Then
            AddHandler mdiClient.Paint, AddressOf Mdi_Paint
            AddHandler mdiClient.Resize, AddressOf Mdi_Resize
        End If
    End Sub

    Private Async Sub FrmInicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' 1. Configuramos el fondo MDI y el notificador
        ConfigurarFondoMDI()
        InicializarNotificador()

        ' 1. Validamos si la terminal actual está autorizada (g_ParametrosTerminal.Actualizar > 0)
        If g_ParametrosTerminal IsNot Nothing AndAlso g_ParametrosTerminal.Actualizar > 0 Then

            ' 2. Ejecutar la primera comprobación al iniciar de forma asíncrona
            Await EjecutarActualizacionAutomatica()

            ' 3. Configurar e iniciar el Timer para las revisiones periódicas
            mTimerActualizaciones = New System.Windows.Forms.Timer()

            ' Convertimos el valor de la BD (asumiendo minutos) a milisegundos
            ' Si g_ParametrosTerminal.Actualizar ya viene en milisegundos, quitar "* 60 * 1000"
            Dim intervaloMs As Integer = CInt(g_ParametrosTerminal.Actualizar) * 60 * 1000

            mTimerActualizaciones.Interval = intervaloMs
            mTimerActualizaciones.Start()

        End If

    End Sub

    ' Evento que se dispara periódicamente según la configuración
    Private Async Sub mTimerActualizaciones_Tick(sender As Object, e As EventArgs) Handles mTimerActualizaciones.Tick
        Await EjecutarActualizacionAutomatica()
    End Sub

    ' Limpieza de recursos al cerrar el formulario
    Private Sub FrmInicio_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        ' Prevenimos el cierre si hay una actualización aplicando cambios en la BD
        If mActualizacionEnCurso Then
            MessageBox.Show("Hay una actualización de datos en proceso. Por favor, aguarde a que finalice.",
                        "SiCoFa", MessageBoxButtons.OK, MessageBoxIcon.Information)
            e.Cancel = True
            Return
        End If

        ' Detenemos y liberamos el timer
        If mTimerActualizaciones IsNot Nothing Then
            mTimerActualizaciones.Stop()
            mTimerActualizaciones.Dispose()
        End If

    End Sub

    Private Sub Mdi_Paint(sender As Object, e As PaintEventArgs)

        Dim mdi As MdiClient = DirectCast(sender, MdiClient)

        If My.Resources.FondoMDI IsNot Nothing Then

            e.Graphics.DrawImage(My.Resources.FondoMDI, New Rectangle(0, 0, mdi.ClientSize.Width, mdi.ClientSize.Height))

        End If

    End Sub

    Private Sub Mdi_Resize(sender As Object, e As EventArgs)

        DirectCast(sender, MdiClient).Invalidate()

    End Sub

    Private Function ObtenerMdiClient(contenedor As Control) As MdiClient

        For Each ctrl As Control In contenedor.Controls

            If TypeOf ctrl Is MdiClient Then
                Return DirectCast(ctrl, MdiClient)
            End If

            If ctrl.HasChildren Then

                Dim mdi As MdiClient = ObtenerMdiClient(ctrl)

                If mdi IsNot Nothing Then
                    Return mdi
                End If

            End If

        Next

        Return Nothing

    End Function

End Class