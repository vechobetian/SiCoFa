Imports System.IO
Imports System.Text
Imports SiCoFa.Entidades
Imports SiCoFa.Negocio

Public Class FrmInicio
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

        If ModSeguridad.ValidarUsuario(Me.mnuCajaMovimientos.Name) Is Nothing Then
            Exit Sub
        End If

        FrmCajas.Usuario = ModSeguridad.ValidarUsuario(Me.mnuCajaMovimientos.Name)
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

    Private Sub mnuEditarClientes_Click(sender As Object, e As EventArgs) Handles mnuEditarClientes.Click

        If ModSeguridad.ValidarUsuario(Me.mnuEditarClientes.Name) Is Nothing Then
            Exit Sub
        End If

        FrmPanelClientes.Show()

    End Sub

    Private Sub mnuEditarEmpleados_Click(sender As Object, e As EventArgs) Handles mnuEditarEmpleados.Click

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

            Dim frm As New FrmUsuarios()
            frm.ShowDialog()

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

    Private Sub mnuSistemaPTerminal_Click(sender As Object, e As EventArgs) Handles mnuSistemaPTerminal.Click

        ' 1. Configuramos el buscador de archivos para que solo vea .txt
        Dim buscador As New OpenFileDialog()
        buscador.Filter = "Manual Farmacéutico (*.txt)|*.txt"
        buscador.Title = "Seleccionar archivo del Manual"

        ' 2. Si el usuario elige un archivo
        If buscador.ShowDialog() = DialogResult.OK Then

            ' Cambiamos el cursor a "Espera" porque son más de 50.000 líneas
            Me.Cursor = Cursors.WaitCursor

            Try
                ' 3. Instanciamos la Capa de Negocio
                Dim objNegocio As New N_AdminArticulos

                ' 4. Llamamos a la función que creamos en Negocio
                Dim resultado As String = objNegocio.ImportarAStaging(buscador.FileName)

                ' 5. Mostramos el resultado
                If resultado.StartsWith("OK") Then
                    MessageBox.Show(resultado, "Proceso Terminado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show(resultado, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            Catch ex As Exception
                MessageBox.Show("Hubo un error en la interfaz: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                ' 7. Pase lo que pase, devolvemos el cursor a la normalidad
                Me.Cursor = Cursors.Default
            End Try
        End If

    End Sub

    Private Sub ActualizacionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActualizacionesToolStripMenuItem.Click
        FrmActualizaciones.Show()
    End Sub
End Class