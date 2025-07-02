Imports System.IO
Imports SiCoFa.Entidades
Public Class FrmInicio

    Private Sub mnuOperacionesFacturacion_Click(sender As Object, e As EventArgs) Handles mnuOperacionesFacturacion.Click

        Dim nuevaVentanaVentas As New FrmVentas()
        nuevaVentanaVentas.Usuario = ModSeguridad.ValidarUsuario(Me.mnuOperacionesFacturacion.Name)
        nuevaVentanaVentas.Show()

    End Sub

    Private Sub mnuCajaMovimientos_Click(sender As Object, e As EventArgs) Handles mnuCajaMovimientos.Click

        FrmCajas.Usuario = ModSeguridad.ValidarUsuario(Me.mnuCajaMovimientos.Name)
        FrmCajas.Show()

    End Sub

    Private Sub mnuCajaAsientoGastos_Click(sender As Object, e As EventArgs) Handles mnuCajaAsientoGastos.Click
        FrmAsientoGastos.Usuario = ModSeguridad.ValidarUsuario(Me.mnuCajaAsientoGastos.Name)
        FrmAsientoGastos.ShowDialog()
    End Sub

    Private Sub mnuEdicionArticulos_Click(sender As Object, e As EventArgs) Handles mnuEdicionArticulos.Click
        FrmArticulos.Show()
    End Sub

    Private Sub mnuEdicionClientes_Click(sender As Object, e As EventArgs) Handles mnuEdicionClientes.Click
        FrmPanelClientes.Show()
    End Sub

    Private Sub mnuEdicionEmpleados_Click(sender As Object, e As EventArgs) Handles mnuEdicionEmpleados.Click

    End Sub

    Private Sub mnuEdicionMedioPE_Click(sender As Object, e As EventArgs) Handles mnuEdicionMedioPE.Click
        Dim user As Usuario = ModSeguridad.ValidarUsuario(Me.mnuEdicionMedioPE.Name)
        If user Is Nothing Then
            Exit Sub
        End If
        FrmMediosPE.ShowDialog()
    End Sub

    Private Sub mnuEdicionUsuarios_Click(sender As Object, e As EventArgs) Handles mnuEdicionUsuarios.Click
        Try

            Dim User As Usuario = ModSeguridad.ValidarUsuario(Me.mnuEdicionUsuarios.Name)
            If User Is Nothing Then
                Exit Sub
            End If

            Dim frm As New FrmUsuarios()
            frm.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub mnuEdicionProveedores_Click(sender As Object, e As EventArgs) Handles mnuEdicionProveedores.Click
        Try
            Dim User As Usuario = ModSeguridad.ValidarUsuario(Me.mnuEdicionProveedores.Name)
            If User Is Nothing Then
                Exit Sub
            End If

            Dim frm As New FrmProveedores()
            frm.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try
    End Sub

    Private Sub mnuEdicionPermisos_Click(sender As Object, e As EventArgs) Handles mnuEdicionPermisos.Click

        Try

            Dim User As Usuario = ModSeguridad.ValidarUsuario(Me.mnuEdicionPermisos.Name)
            If User Is Nothing Then
                Exit Sub
            End If

            Dim frm As New FrmPermisos()
            frm.Usuario = User
            frm.MenuPrincipal = Me.MenuStrip1
            'frm.MenuCaja = FrmCajas.MenuStrip1
            frm.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

End Class