Imports System.IO
Imports SiCoFa.Entidades
Public Class FrmInicio

    Private Sub mnuOperacionesFacturacion_Click(sender As Object, e As EventArgs) Handles mnuOperacionesFacturacion.Click

        Dim nuevaVentanaVentas As New FrmVentas()
        nuevaVentanaVentas.Usuario = ModSeguridad.ValidarUsuario(Me.mnuOperacionesFacturacion.Name)
        nuevaVentanaVentas.Show()

    End Sub

    Private Sub mnuOperacionesCompras_Click(sender As Object, e As EventArgs) Handles mnuOperacionesCompras.Click

        Dim nuevaVentanaCompras As New FrmCompras()
        nuevaVentanaCompras.Usuario = ModSeguridad.ValidarUsuario(Me.mnuOperacionesCompras.Name)
        nuevaVentanaCompras.Show()

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

    Private Sub mnuEdicionArticulos_Click(sender As Object, e As EventArgs) Handles mnuEdicionArticulos.Click

        If ModSeguridad.ValidarUsuario(Me.mnuEdicionArticulos.Name) Is Nothing Then
            Exit Sub
        End If

        Dim f As New FrmArticulos()
        f.Show()

    End Sub

    Private Sub mnuEdicionClientes_Click(sender As Object, e As EventArgs) Handles mnuEdicionClientes.Click

        If ModSeguridad.ValidarUsuario(Me.mnuEdicionClientes.Name) Is Nothing Then
            Exit Sub
        End If

        FrmPanelClientes.Show()

    End Sub

    Private Sub mnuEdicionEmpleados_Click(sender As Object, e As EventArgs) Handles mnuEdicionEmpleados.Click

    End Sub

    Private Sub mnuEdicionMedioPE_Click(sender As Object, e As EventArgs) Handles mnuEdicionMedioPE.Click

        If ModSeguridad.ValidarUsuario(Me.mnuEdicionMedioPE.Name) Is Nothing Then
            Exit Sub
        End If

        Dim f As New FrmMediosPE
        f.Show()

    End Sub

    Private Sub mnuEdicionUsuarios_Click(sender As Object, e As EventArgs) Handles mnuEdicionUsuarios.Click
        Try

            If ModSeguridad.ValidarUsuario(Me.mnuEdicionUsuarios.Name) Is Nothing Then
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
            frm.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

End Class