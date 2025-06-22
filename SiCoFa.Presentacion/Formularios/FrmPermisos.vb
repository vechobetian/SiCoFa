Imports SiCoFa.Negocio
Imports SiCoFa.Entidades

Public Class FrmPermisos

    Property MenuPrincipal As MenuStrip
    Property Usuario As Usuario

    Private permisosUsuario As New HashSet(Of String)

    Private accionesCriticas As Dictionary(Of String, String) = New Dictionary(Of String, String) From
    {
    {"MODIFICAR_PRECIO", "Modificar precio de productos"},
    {"MODIFICAR_STOCK", "Modificar stock"},
    {"ANULAR_COMPROBANTE", "Anular comprobante"},
    {"CIERRE_CAJA", "Realizar cierre de caja"}
    }

    Private Function SeleccionarUsuarioListado(ByVal argId As Int32, ByVal argListaUsuarios As List(Of Usuario)) As Usuario

        Try
            Dim UsuarioSeleccionado As Usuario = Nothing

            For Each u As Usuario In argListaUsuarios
                If u.Id = argId Then
                    UsuarioSeleccionado = u
                    Exit For
                End If
            Next

            Return UsuarioSeleccionado

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
            Return Nothing
        End Try

    End Function

    Private Sub BuscarUsuario(ByVal argTextoBuscado As String)

        Try

            Dim AdminUsuarios As New N_AdminUsuarios
            Dim lu As List(Of Usuario) = AdminUsuarios.ListarUsuarios(argTextoBuscado)
            Dim u As Usuario = Nothing

            If lu Is Nothing Then
                MsgBox("Usuario no Encontrado", vbInformation, "SiCoFa")
                Exit Sub
            End If

            Select Case lu.Count
                Case 0
                    MsgBox("Usuario no Enotrado", vbInformation, "SiCoFa")
                    Exit Sub

                Case 1
                    u = lu.First

                Case > 1
                    Using f As New FrmSelectorUniversal
                        f.Text = "Usuarios SiCoFa"
                        f.Objetos = lu
                        f.NombrePropiedadId = "Id"
                        f.NombrePropiedadDescripcion = "Nombre"
                        f.HeaderPropiedadDescripcion = "Usuario"
                        If f.ShowDialog() = DialogResult.OK Then
                            u = Me.SeleccionarUsuarioListado(f.Valor1Seleccionado, lu)
                        Else
                            Exit Sub

                        End If
                    End Using ' <- aquí se libera completamente
            End Select

            Me.Usuario = u
            Me.Text = "Permisos del Usuario " & Me.Usuario.Nombre

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub FrmPermisos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim str = InputBox("Ingrese el Usuario", "SiCoFa")

        If str = "" Then
            Exit Sub
        Else
            Me.BuscarUsuario(str)
        End If

        permisosUsuario = ObtenerPermisosUsuario(Usuario.Id)

        CargarPermisosComoCheckBoxes()
        CargarPermisosAdicionales()
    End Sub

    Private Sub CargarPermisosComoCheckBoxes()
        flpPermisos.Controls.Clear()

        For Each item As ToolStripMenuItem In MenuPrincipal.Items
            ' Verificar si el menú tiene al menos un submenú válido
            Dim subMenusValidos = item.DropDownItems.
                OfType(Of ToolStripMenuItem)().
                Where(Function(subItem) Not String.IsNullOrWhiteSpace(subItem.Name)).
                ToList()

            If subMenusValidos.Count = 0 Then
                Continue For ' Omitir menús sin submenús válidos
            End If

            Dim nombreGrupo As String = item.Text.Replace("&", "")
            Dim group As New GroupBox() With {
                .Text = nombreGrupo,
                .AutoSize = True,
                .AutoSizeMode = AutoSizeMode.GrowAndShrink,
                .Padding = New Padding(10),
                .Margin = New Padding(10),
                .Font = New Font("Segoe UI", 10, FontStyle.Bold)
            }

            Dim layout As New FlowLayoutPanel() With {
                .FlowDirection = FlowDirection.TopDown,
                .AutoSize = True,
                .WrapContents = False,
                .Dock = DockStyle.Fill
            }

            For Each subMenu In subMenusValidos
                Dim chk As New CheckBox() With {
                    .Text = subMenu.Text.Replace("&", ""),
                    .Tag = subMenu.Name,
                    .AutoSize = True,
                    .Font = New Font("Segoe UI", 9, FontStyle.Regular),
                    .Checked = permisosUsuario.Contains(subMenu.Name)
                }

                AddHandler chk.CheckedChanged, AddressOf CheckBox_CheckedChanged
                layout.Controls.Add(chk)
            Next

            group.Controls.Add(layout)
            flpPermisos.Controls.Add(group)
        Next
    End Sub

    Private Sub CheckBox_CheckedChanged(sender As Object, e As EventArgs)
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim idProceso As String = chk.Tag.ToString()
        Dim idUsuario As Integer = Usuario.Id
        Dim AdminDB As New N_AdminDB

        If chk.Checked Then
            If Not permisosUsuario.Contains(idProceso) Then
                permisosUsuario.Add(idProceso)
                Dim valores As New Dictionary(Of String, Object) From {
                    {"IdUsuario", idUsuario},
                    {"IdProceso", idProceso}
                }
                Try
                    AdminDB.InsertarRegistro("TblPermisos", valores)
                Catch ex As Exception
                    ' Puede ser duplicado
                End Try
            End If
        Else
            If permisosUsuario.Contains(idProceso) Then
                permisosUsuario.Remove(idProceso)
                Dim sqlDelete As String = $"DELETE FROM TblPermisos WHERE IdUsuario = {idUsuario} AND IdProceso = '{idProceso}'"
                AdminDB.EliminarRegistros(sqlDelete)
            End If
        End If
    End Sub

    Private Function ObtenerPermisosUsuario(idUsuario As Integer) As HashSet(Of String)
        Dim permisos As New HashSet(Of String)
        Dim AdminDB As New N_AdminDB
        Dim sql As String = $"SELECT IdProceso FROM TblPermisos WHERE IdUsuario = {idUsuario}"
        Dim tabla As DataTable = AdminDB.ObtenerTabla(sql)

        If tabla IsNot Nothing Then
            For Each fila As DataRow In tabla.Rows
                permisos.Add(fila("IdProceso").ToString())
            Next
        End If

        Return permisos
    End Function

    Private Sub CargarPermisosAdicionales()
        Dim group As New GroupBox() With {
            .Text = "Funciones del sistema",
            .AutoSize = True,
            .AutoSizeMode = AutoSizeMode.GrowAndShrink,
            .Padding = New Padding(10),
            .Margin = New Padding(10),
            .Font = New Font("Segoe UI", 10, FontStyle.Bold)
        }

        Dim layout As New FlowLayoutPanel() With {
            .FlowDirection = FlowDirection.TopDown,
            .AutoSize = True,
            .WrapContents = False,
            .Dock = DockStyle.Fill
        }

        For Each accion In accionesCriticas
            Dim chk As New CheckBox() With {
                .Text = accion.Value,
                .Tag = accion.Key,
                .AutoSize = True,
                .Font = New Font("Segoe UI", 9, FontStyle.Regular),
                .Checked = permisosUsuario.Contains(accion.Key)
            }

            AddHandler chk.CheckedChanged, AddressOf CheckBox_CheckedChanged

            layout.Controls.Add(chk)
        Next

        group.Controls.Add(layout)
        flpPermisos.Controls.Add(group)
    End Sub
End Class

