Imports System.IO
Imports SiCoFa.Entidades
Public Class FrmInicio

    Public Class MenuRegistro
        Public Property NombreMenu As String
        Public Property NombreSubMenu As String
        Public Property TextoMenu As String
        Public Property TextoSubMenu As String
    End Class

    Private Function ObtenerMenuYSubmenu(menu As MenuStrip) As List(Of MenuRegistro)
        Dim lista As New List(Of MenuRegistro)

        For Each item As ToolStripMenuItem In menu.Items
            Dim nombreMenu As String = item.Name
            Dim textoMenu As String = item.Text.Replace("&", "")

            If item.DropDownItems.Count = 0 Then
                lista.Add(New MenuRegistro With {
                .NombreMenu = nombreMenu,
                .NombreSubMenu = Nothing,
                .TextoMenu = textoMenu,
                .TextoSubMenu = Nothing
            })
            Else
                For Each subItem As ToolStripItem In item.DropDownItems
                    If TypeOf subItem Is ToolStripMenuItem Then
                        Dim subMenu = DirectCast(subItem, ToolStripMenuItem)
                        lista.Add(New MenuRegistro With {
                        .NombreMenu = nombreMenu,
                        .NombreSubMenu = subMenu.Name,
                        .TextoMenu = textoMenu,
                        .TextoSubMenu = subMenu.Text.Replace("&", "")
                    })
                    End If
                Next
            End If
        Next

        Return lista
    End Function

    Private Sub ExportarMenuATxt(menu As MenuStrip, rutaArchivo As String)
        Dim lista = ObtenerMenuYSubmenu(menu)
        Using writer As New StreamWriter(rutaArchivo, False)
            writer.WriteLine("NombreMenu;NombreSubmenu;TextoMenu;TextoSubmenu") ' encabezado
            For Each item In lista
                writer.WriteLine($"{item.NombreMenu};{item.NombreSubMenu};{item.TextoMenu};{item.TextoSubMenu}")
            Next
        End Using
    End Sub

    Private Function ValidarUsuario() As Usuario
        Try

            Dim User As Usuario = Nothing

            If g_Usuario Is Nothing Then
                Using frmLogin As New FrmLoginUser
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
        nuevaVentanaVentas.Usuario = Me.ValidarUsuario
        nuevaVentanaVentas.Show()

    End Sub

    Private Sub mnuCajaMovimientos_Click(sender As Object, e As EventArgs) Handles mnuCajaMovimientos.Click

        FrmCajas.Usuario = Me.ValidarUsuario
        FrmCajas.Show()

    End Sub

    Private Sub mnuEdicionArticulos_Click(sender As Object, e As EventArgs) Handles mnuEdicionArticulos.Click
        FrmArticulos.Show()
    End Sub

    Private Sub mnuEdicionClientes_Click(sender As Object, e As EventArgs) Handles mnuEdicionClientes.Click
        FrmPanelClientes.Show()
    End Sub

    Private Sub mnuAyuda_Click(sender As Object, e As EventArgs) Handles mnuAyuda.Click
        Me.ExportarMenuATxt(Me.MenuStrip1, "C:\SiCoFaCom\Menu.txt")

    End Sub
End Class