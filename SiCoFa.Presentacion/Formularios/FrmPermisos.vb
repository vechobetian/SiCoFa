Imports SiCoFa.Negocio
Imports SiCoFa.Entidades

Public Class FrmPermisos

    Property MenuPrincipal As MenuStrip
    Property MenuCaja As MenuStrip
    Property Usuario As Usuario

    Private permisosUsuario As New HashSet(Of String)

    Private accionesCriticas As New Dictionary(Of String, String) From {
        {"SUPERUSUARIO", "Usuario Administrador"},
        {"MODIFICAR_PRECIO", "Modificar precio de productos"},
        {"MODIFICAR_STOCK", "Modificar stock"},
        {"ANULAR_COMPROBANTE", "Anular comprobante"},
        {"CIERRE_CAJA", "Realizar cierre de caja"},
        {"RETIRO_EF_CAJA", "Retiro Efectivo Caja Abierta"},
        {"NOTA_CREDITO", "Hacer Notas de Crédito"},
        {"FACTURACION_REMITOS", "Facturación Remitos"}
    }

    Private Sub FrmPermisos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim str = InputBox("Ingrese el Usuario", "SiCoFa")
        If str = "" Then Exit Sub

        Me.BuscarUsuario(str)

        If Usuario.Id = 1 Then
            MsgBox(Usuario.Nombre & " tiene todos los permisos habilitados", vbInformation, "SiCoFa")
            Me.Close()
        End If

        permisosUsuario = ObtenerPermisosUsuario(Usuario.Id)

        flpPermisos.Controls.Clear()
        CargarPermisosDesdeMenu(MenuPrincipal, "MenuPrincipal")
        'CargarPermisosDesdeMenu(MenuCaja, "MenuCaja")
        CargarPermisosAdicionales()
    End Sub

    Private Sub BuscarUsuario(ByVal argTextoBuscado As String)
        Try
            Dim AdminUsuarios As New N_AdminUsuarios
            Dim lu As List(Of Usuario) = AdminUsuarios.ListarUsuarios(argTextoBuscado)
            Dim u As Usuario = Nothing

            If lu Is Nothing OrElse lu.Count = 0 Then
                MsgBox("Usuario no encontrado", vbInformation, "SiCoFa")
                Me.Close()
                Exit Sub
            End If

            If lu.Count = 1 Then
                u = lu.First
            Else
                Using f As New FrmSelectorUniversal
                    f.Text = "Usuarios SiCoFa"
                    f.Objetos = lu
                    f.NombrePropiedadId = "Id"
                    f.NombrePropiedadDescripcion = "Nombre"
                    f.HeaderPropiedadDescripcion = "Usuario"
                    If f.ShowDialog() = DialogResult.OK Then
                        u = lu.FirstOrDefault(Function(x) x.Id = f.Valor1Seleccionado)
                    Else
                        Exit Sub
                    End If
                End Using
            End If

            Me.Usuario = u
            Me.Text = "Permisos del Usuario " & Me.Usuario.Nombre

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
        End Try
    End Sub

    Private Sub CargarPermisosDesdeMenu(menu As MenuStrip, origen As String)
        For Each item As ToolStripMenuItem In menu.Items
            Dim subMenusValidos = item.DropDownItems.
                OfType(Of ToolStripMenuItem)().
                Where(Function(s) Not String.IsNullOrWhiteSpace(s.Name)).
                ToList()

            If subMenusValidos.Count = 0 Then Continue For

            Dim nombreGrupo As String = item.Text.Replace("&", "") & $" ({origen})"

            Dim group As New GroupBox With {
                .Text = nombreGrupo,
                .AutoSize = True,
                .AutoSizeMode = AutoSizeMode.GrowAndShrink,
                .Padding = New Padding(10),
                .Margin = New Padding(10),
                .Font = New Font("Segoe UI", 10, FontStyle.Bold),
                .MinimumSize = New Size(400, 0)
            }

            Dim layout As New FlowLayoutPanel With {
                .FlowDirection = FlowDirection.TopDown,
                .AutoSize = True,
                .WrapContents = False,
                .Dock = DockStyle.Fill
            }

            For Each subItem In subMenusValidos
                Dim chk As New CheckBox With {
                    .Text = subItem.Text.Replace("&", ""),
                    .Tag = subItem.Name,
                    .AutoSize = True,
                    .Font = New Font("Segoe UI", 9, FontStyle.Regular),
                    .Checked = permisosUsuario.Contains(subItem.Name)
                }
                AddHandler chk.CheckedChanged, AddressOf CheckBox_CheckedChanged
                layout.Controls.Add(chk)
            Next

            group.Controls.Add(layout)
            flpPermisos.Controls.Add(group)
        Next
    End Sub

    Private Sub CargarPermisosAdicionales()
        Dim group As New GroupBox With {
            .Text = "Funciones del sistema",
            .AutoSize = True,
            .AutoSizeMode = AutoSizeMode.GrowAndShrink,
            .Padding = New Padding(10),
            .Margin = New Padding(10),
            .Font = New Font("Segoe UI", 10, FontStyle.Bold),
            .MinimumSize = New Size(400, 0)
        }

        Dim layout As New FlowLayoutPanel With {
            .FlowDirection = FlowDirection.TopDown,
            .AutoSize = True,
            .WrapContents = False,
            .Dock = DockStyle.Fill
        }

        For Each accion In accionesCriticas
            Dim chk As New CheckBox With {
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

    Private Sub CheckBox_CheckedChanged(sender As Object, e As EventArgs)
        Dim chk = DirectCast(sender, CheckBox)
        Dim idProceso As String = chk.Tag.ToString()
        Dim idUsuario As Integer = Usuario.Id
        Dim AdminDB As New N_AdminDB

        If chk.Checked Then
            If Not permisosUsuario.Contains(idProceso) Then
                permisosUsuario.Add(idProceso)
                Try
                    Dim valores As New Dictionary(Of String, Object) From {
                        {"IdUsuario", idUsuario},
                        {"IdProceso", idProceso}
                    }
                    AdminDB.InsertarRegistro("TblPermisos", valores)
                Catch ex As Exception
                    ' puede ser duplicado
                End Try
            End If
        Else
            If permisosUsuario.Contains(idProceso) Then
                permisosUsuario.Remove(idProceso)
                Dim sqlDelete = $"DELETE FROM TblPermisos WHERE IdUsuario = {idUsuario} AND IdProceso = '{idProceso}'"
                AdminDB.EliminarRegistros(sqlDelete)
            End If
        End If
    End Sub

    Private Function ObtenerPermisosUsuario(idUsuario As Integer) As HashSet(Of String)
        Dim permisos As New HashSet(Of String)
        Dim AdminDB As New N_AdminDB
        Dim tabla = AdminDB.ObtenerTabla($"SELECT IdProceso FROM TblPermisos WHERE IdUsuario = {idUsuario}")

        If tabla IsNot Nothing Then
            For Each fila As DataRow In tabla.Rows
                permisos.Add(fila("IdProceso").ToString())
            Next
        End If

        Return permisos
    End Function

End Class

