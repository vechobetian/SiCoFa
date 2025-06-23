Imports System.IO
Imports SiCoFa.Entidades
Public Class FrmInicio

    Private Function ValidarUsuario(ByVal argIdProceso As String) As Usuario
        Try

            Dim User As Usuario = Nothing

            If g_Usuario Is Nothing Then
                Using frmLogin As New FrmLoginUser
                    frmLogin.IdProceso = argIdProceso

                    If frmLogin.ShowDialog() = DialogResult.OK AndAlso frmLogin.Usuario IsNot Nothing Then
                        User = frmLogin.Usuario
                    End If
                End Using

            Else
                User = g_Usuario

            End If

            Return User

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
            Return Nothing

        End Try

    End Function

    Private Sub mnuOperacionesFacturacion_Click(sender As Object, e As EventArgs) Handles mnuOperacionesFacturacion.Click

        Dim nuevaVentanaVentas As New FrmVentas()
        nuevaVentanaVentas.Usuario = Me.ValidarUsuario(Me.mnuOperacionesFacturacion.Name)
        nuevaVentanaVentas.Show()

    End Sub

    Private Sub mnuCajaMovimientos_Click(sender As Object, e As EventArgs) Handles mnuCajaMovimientos.Click

        FrmCajas.Usuario = Me.ValidarUsuario(Me.mnuCajaMovimientos.Name)
        FrmCajas.Show()

    End Sub

    Private Sub mnuCajaAsientoGastos_Click(sender As Object, e As EventArgs) Handles mnuCajaAsientoGastos.Click
        FrmAsientoGastos.Usuario = Me.ValidarUsuario(Me.mnuCajaAsientoGastos.Name)
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
        Dim user As Usuario = Me.ValidarUsuario(Me.mnuEdicionMedioPE.Name)
        If user Is Nothing Then
            Exit Sub
        End If
        FrmMediosPE.ShowDialog()
    End Sub

    Private Sub mnuEdicionUsuarios_Click(sender As Object, e As EventArgs) Handles mnuEdicionUsuarios.Click
        Try

            Dim User As Usuario = Me.ValidarUsuario(Me.mnuEdicionUsuarios.Name)
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
            Dim User As Usuario = Me.ValidarUsuario(Me.mnuEdicionProveedores.Name)
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

            Dim User As Usuario = Me.ValidarUsuario(Me.mnuEdicionPermisos.Name)
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