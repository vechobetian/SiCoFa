Imports SiCoFa.Negocio
Imports SiCoFa.Entidades
Public Class FrmPermisos

    Property MenuPrincipal As MenuStrip
    Property Usuario As Usuario

    Private Sub FrmPermisos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If MenuPrincipal Is Nothing OrElse Usuario Is Nothing Then
            MessageBox.Show("Faltan datos para cargar los permisos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
            Exit Sub
        End If

        Dim permisos = ObtenerPermisosUsuario(1)
        CargarTreeViewPermisos(MenuPrincipal, tvPermisos, permisos)

    End Sub

    Private Sub CargarTreeViewPermisos(menu As MenuStrip, treeView As TreeView, permisosUsuario As List(Of String))
        treeView.Nodes.Clear()
        treeView.CheckBoxes = True

        For Each item As ToolStripMenuItem In menu.Items
            Dim nodoPadre As TreeNode = treeView.Nodes.Add(item.Text.Replace("&", ""))
            nodoPadre.Tag = item.Name
            nodoPadre.Checked = False

            For Each subItem As ToolStripItem In item.DropDownItems
                If TypeOf subItem Is ToolStripMenuItem Then
                    Dim subMenu = DirectCast(subItem, ToolStripMenuItem)
                    Dim nodoHijo As TreeNode = nodoPadre.Nodes.Add(subMenu.Text.Replace("&", ""))
                    nodoHijo.Tag = subMenu.Name
                    nodoHijo.Checked = permisosUsuario.Contains(subMenu.Name)
                End If
            Next
        Next

        treeView.ExpandAll()
    End Sub

    Private Function ObtenerPermisosUsuario(ByVal argIdUsuario As Integer) As List(Of String)
        Dim permisos As New List(Of String)
        Dim AdminDB As New N_AdminDB
        Dim sql As String = $"SELECT IdProceso FROM TblPermisos WHERE IdUsuario= {argIdUsuario}"
        Dim dTable As DataTable = AdminDB.ObtenerTabla(sql)

        If dTable IsNot Nothing AndAlso dTable.Rows.Count > 0 Then
            For Each row As DataRow In dTable.Rows
                permisos.Add(row("IdProceso").ToString())
            Next
        End If

        Return permisos ' Devuelve una lista vacía si no hay permisos
    End Function

End Class