Imports SiCoFa.Negocio
Imports SiCoFa.Entidades
Public Class FrmPanelContratos

    Private mobj_N_AdminContratos As New cls_N_AdminContratos
    Private Sub LimpiarFormularioCliente()
        With Me
            .IdCliente.Clear()
            .Nombre.Clear()
            .Domicilio.Clear()
            .Localidad.Clear()
            .Provincia.Clear()
            .Telefono.Clear()
            .Movil.Clear()
            .Email.Clear()
            .TipoDoc.SelectedIndex = -1
            .NumDoc.Clear()
            .IVA.SelectedIndex = -1
        End With
    End Sub
    Private Sub LimpiarFormularioContrato()
        With Me
            .IdContrato.Clear()
            .GrupoContratos.SelectedIndex = -1
            .UsFTP.Clear()
            .MesesT.Clear()
            .Contacto.Clear()
            .Deposito.Clear()
            .InicioContrato.Clear()
            .FinalContrato.Clear()
            .UltimoDev.Clear()
            .EstadoContrato.SelectedIndex = -1
        End With

    End Sub
    Private Sub LimpiarFormularioServiciosAsoc()
        Me.DataGridView1.Rows.Clear()
    End Sub
    Private Function BuscarCliente(ByVal argTextoBuscado As String) As Cliente
        Dim lc As List(Of Cliente) = mobj_N_AdminContratos.ListarClientes(argTextoBuscado)
        Dim c As Cliente = Nothing

        If lc Is Nothing Then
            MsgBox("Cliente no Encontrado", vbInformation, "SiCoFa")
            Return Nothing
            Exit Function
        End If

        Select Case lc.Count
            Case 0
                MsgBox("No se encontro el Cliente",, "SiCoFa")
                Return Nothing
                Exit Function
            Case 1
                c = lc.First
            Case > 1
                FrmBuscaClientes.Clientes = lc
                FrmBuscaClientes.ShowDialog()

                If FrmBuscaClientes.ClienteSeleccionado Is Nothing Then
                    FrmBuscaClientes.Close()
                    Return Nothing
                    Exit Function
                End If

                c = FrmBuscaClientes.ClienteSeleccionado
                FrmBuscaClientes.Close()
        End Select

        Return c
        c = Nothing

    End Function
    Private Sub MostrarCliente(ByVal argCliente As Cliente)
        With Me
            .IdCliente.Text = argCliente.IdCliente
            .Nombre.Text = argCliente.Nombre
            .Domicilio.Text = argCliente.Domicilio
            .Localidad.Text = argCliente.Localidad
            .Provincia.Text = argCliente.Provincia
            .Telefono.Text = argCliente.Telefono
            .Movil.Text = argCliente.Movil
            .Email.Text = argCliente.Email
            .TipoDoc.Text = argCliente.Documento.TipoDoc.TipoDocumento
            .NumDoc.Text = argCliente.Documento.Numero
            .IVA.Text = argCliente.IVA.TipoIVA
        End With
    End Sub
    Private Sub MostrarContrato(ByVal argContrato As Contrato)
        With Me
            .IdContrato.Text = argContrato.IdContrato
            .GrupoContratos.Text = argContrato.GrupoContratos.Descripcion
            .UsFTP.Text = argContrato.UsFTP
            .MesesT.Text = argContrato.MesesT
            .Contacto.Text = argContrato.Contacto
            .Deposito.Text = Format(argContrato.Deposito, "Standard")
            .InicioContrato.Text = argContrato.InicioContrato
            .FinalContrato.Text = argContrato.FinalContrato
            .UltimoDev.Text = argContrato.UltimoDev
            If argContrato.FacturaServicios = False Then
                .FacturaServicios.Text = "NO"
            Else
                .FacturaServicios.Text = "SI"
            End If
            .EstadoContrato.Text = argContrato.EstadoContrato

        End With
    End Sub
    Private Sub MostrarServiciosAsociados(ByVal argContrato As Contrato)
        Dim x As Integer

        If argContrato.ServiciosAsociados Is Nothing Then
            Exit Sub
        End If

        For Each sa As ServicioAsociado In argContrato.ServiciosAsociados
            With Me.DataGridView1
                .Rows.Add()
                .Rows(x).Cells("IdDS").Value = sa.IdDS
                .Rows(x).Cells("CodiS").Value = sa.CodiS
                .Rows(x).Cells("DescripcionServicio").Value = sa.Servicio.DescripcionServicio
                .Rows(x).Cells("Cantidad").Value = sa.Cantidad
                .Rows(x).Cells("PUnit").Value = sa.Servicio.PUnit
                .Rows(x).Cells("ImpServ").Value = sa.Importe
            End With
            x = x + 1
        Next
    End Sub
    Private Sub ObtenerTiposDocumento()
        With Me.TipoDoc
            .DataSource = mobj_N_AdminContratos.TiposDocumento
            .ValueMember = "CodiTDoc"
            .DisplayMember = "TipoDocumento"
        End With
    End Sub
    Private Sub ObtenerTiposIVA()
        With Me.IVA
            .DataSource = mobj_N_AdminContratos.TiposIVA
            .ValueMember = "CodIVA"
            .DisplayMember = "TipoIVA"
        End With
    End Sub
    Private Sub ObtenerGruposContrato()
        With Me.GrupoContratos
            .DataSource = mobj_N_AdminContratos.ListaGrupoContratosCompleta
            .ValueMember = "IdGC"
            .DisplayMember = "Descripcion"
        End With
    End Sub
    Private Sub ObtenerLocadores()
        With Me.Locador
            .DataSource = mobj_N_AdminContratos.LocadoresVigentes
            .ValueMember = "IdLocador"
            .DisplayMember = "Nombre"
        End With
    End Sub
    Private Sub ObtenerContrato(ByVal argIdCliente As Integer)
        Dim c As Contrato = mobj_N_AdminContratos.ObtenerContrato(0, argIdCliente)
        If c Is Nothing Then
            Call LimpiarFormularioContrato()
            Exit Sub
        End If

        c.GrupoContratos = mobj_N_AdminContratos.ObtenerGrupoContratosPorId(c.IdGC)
        c.ServiciosAsociados = mobj_N_AdminContratos.ObtenerServiciosAsociados(c.IdContrato)
        MostrarContrato(c)
        MostrarServiciosAsociados(c)
    End Sub
    Private Sub FrmPanelContatos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With Me
            .ObtenerGruposContrato()
            .ObtenerLocadores()
            .ObtenerTiposDocumento()
            .ObtenerTiposIVA()
            .LimpiarFormularioCliente()
            .LimpiarFormularioContrato()
            .Nombre.Select()
        End With
    End Sub
    Private Sub Nombre_KeyUp(sender As Object, e As KeyEventArgs) Handles Nombre.KeyUp
        If e.KeyCode = 13 Then
            Dim c As Cliente = Me.BuscarCliente(Me.Nombre.Text)

            If c Is Nothing Then
                'Me.Nombre.Text = ""
                Exit Sub
            End If

            With Me
                .LimpiarFormularioCliente()
                .LimpiarFormularioContrato()
                .LimpiarFormularioServiciosAsoc()
                .MostrarCliente(c)
                .ObtenerContrato(c.IdCliente)
                .Nombre.SelectAll()
            End With
        End If
    End Sub
    Private Sub Buscar_Click(sender As Object, e As EventArgs) Handles Buscar.Click
        Dim str = InputBox("Ingrese el Cliente", "SiCoFa")
        If str = "" Then
            Me.Nombre.Select()
            Exit Sub
        End If

        Dim c As Cliente = BuscarCliente(str)

        With Me
            .LimpiarFormularioCliente()
            .LimpiarFormularioContrato()
            .LimpiarFormularioServiciosAsoc()
            .MostrarCliente(c)
            .ObtenerContrato(c.IdCliente)
            .Nombre.Select()
        End With

    End Sub
    Private Sub Limpiar_Click(sender As Object, e As EventArgs) Handles Limpiar.Click
        With Me
            .LimpiarFormularioCliente()
            .LimpiarFormularioContrato()
            .LimpiarFormularioServiciosAsoc()
            .Nombre.Select()
        End With
    End Sub
    Private Sub Guardar_Click(sender As Object, e As EventArgs) Handles Guardar.Click

        If Me.IdCliente.Text = "" Then
            If Me.Nombre.Text = "" Then
                MsgBox("Nombre es un dato requerido para dar de alta un Cliente",, "SiCoFa")
                Me.Nombre.Focus()
                Exit Sub
            End If

            Dim Id As Integer = mobj_N_AdminContratos.InsertarCliente(Me.Nombre.Text, Me.Domicilio.Text, Me.Localidad.Text, Me.Provincia.Text, Me.Telefono.Text, Me.Movil.Text, LCase(Me.Email.Text), Me.TipoDoc.SelectedValue, Me.NumDoc.Text, Me.IVA.SelectedValue)
            If Id > 0 Then
                Me.IdCliente.Text = Id
                Me.Nombre.Text = UCase(Me.Nombre.Text)
                MsgBox("Se dio de alta el Cliente " & Nombre.Text,, "SiCoFa")
            Else
                MsgBox("Ocurrio un error, intente nuevamente",, "SiCoFa")
                Exit Sub
            End If
        Else
            If Me.IdCliente.Text = "" Then
                MsgBox("El cliente " & Me.Nombre.Text & " no fue dado de Alta",, "SiCoFa")
                Exit Sub
            End If

            Dim Actualizado As Boolean = mobj_N_AdminContratos.ActualizarCliente(Me.IdCliente.Text, Me.Domicilio.Text, Me.Localidad.Text, Me.Provincia.Text, Me.Telefono.Text, Me.Movil.Text, LCase(Me.Email.Text), Me.TipoDoc.SelectedValue, Me.NumDoc.Text, Me.IVA.SelectedValue)

            If Actualizado = True Then
                MsgBox("El Cliente " & Nombre.Text & " se acutalizo correctamente",, "SiCoFa")
            Else
                MsgBox("Ocurrio un error, intente nuevamente", "SiCoFa")
                Exit Sub
            End If
        End If
    End Sub
    Private Sub TabPage2_Enter(sender As Object, e As EventArgs) Handles TabPage2.Enter

        If Me.IdCliente.Text = "" Then
            Me.TabPage2.Enabled = False
        Else
            Me.TabPage2.Enabled = True
        End If

    End Sub
    Private Sub TabPage3_Enter(sender As Object, e As EventArgs) Handles TabPage3.Enter

        If Me.IdContrato.Text = "" Then
            Me.TabPage3.Enabled = False
        Else
            Me.TabPage3.Enabled = True
        End If

    End Sub
    Private Sub GuardarContrato_Click(sender As Object, e As EventArgs) Handles GuardarContrato.Click

        Dim IdGC As Integer = Me.GrupoContratos.SelectedValue
        Dim IdLoc As Integer = Me.Locador.SelectedValue
        Dim IdCli As Integer = Me.IdCliente.Text
        Dim FTP As String = Me.UsFTP.Text
        Dim Meses As Integer = vecho.CCero(Me.MesesT.Text)
        Dim ImpD As Decimal = vecho.CCero(Me.Deposito.Text)
        Dim Inicio As String = Mid(Me.InicioContrato.Text, 7, 4) & "/" & Mid(Me.InicioContrato.Text, 4, 2) & "/" & Mid(Me.InicioContrato.Text, 1, 2)
        Dim Final As String = Mid(Me.FinalContrato.Text, 7, 4) & "/" & Mid(Me.FinalContrato.Text, 4, 2) & "/" & Mid(Me.FinalContrato.Text, 1, 2)
        Dim FacturaServicios As Boolean
        If Me.FacturaServicios.Text = "NO" Then
            FacturaServicios = False
        Else
            FacturaServicios = True
        End If

        Try
            If Me.IdContrato.Text = "" Then
                Dim id As Integer = mobj_N_AdminContratos.InsertarContrato(IdGC, IdLoc, IdCli, FTP, Meses, Me.Contacto.Text, ImpD, Inicio, Final, FacturaServicios)
                If id > 0 Then
                    Me.IdContrato.Text = id
                    MsgBox("La Actualizacion se realizo correctamente",, "SiCoFa")
                End If
            Else
                If mobj_N_AdminContratos.ActualizarContrato(Me.IdContrato.Text, Me.GrupoContratos.SelectedValue, IdLoc, Me.UsFTP.Text, Meses, Me.Contacto.Text, ImpD, Me.InicioContrato.Text, Me.FinalContrato.Text, FacturaServicios, Me.EstadoContrato.Text) Then
                    MsgBox("La Actualizacion se realizo correctamente",, "SiCoFa")
                End If
            End If

        Catch ex As Exception
            MsgBox(vecho.MensajeError(Me.ToString, "GuardarContrato", ex.Message))
        End Try

    End Sub
    Private Sub GrupoContratos_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles GrupoContratos.Validating
        If Me.GrupoContratos.Text = "" Then
            MsgBox("Grupo de Contratos es un datos requerido",, "SiCoFa")
            e.Cancel = True
        End If
    End Sub
    Private Sub MesesT_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Buscar.Validating
        If IsNumeric(Me.UsFTP) = False Then
            Me.MesesT.Text = 0
        End If
    End Sub
    Private Sub Deposito_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Deposito.Validating
        If IsNumeric(Me.Deposito.Text) = False Then
            MsgBox("El importe ingresado no es correcto",, "SiCoFa")
            e.Cancel = True
        End If
        Me.Deposito.Text = Format(Replace(Me.Deposito.Text, ".", ","), "Standard")
    End Sub
    Private Sub InicioContrato_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles InicioContrato.Validating
        If IsDate(Me.InicioContrato.Text) = False Then
            MsgBox("La fecha ingresada no es correcta",, "SiCoFa")
            e.Cancel = True
        End If
    End Sub
    Private Sub FinalContrato_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles FinalContrato.Validating
        If IsDate(Me.FinalContrato.Text) = False Then
            MsgBox("La fecha ingresada no es correcta",, "SiCoFa")
            e.Cancel = True
        End If
    End Sub
    Private Sub EstadoContrato_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles EstadoContrato.Validating
        If Me.EstadoContrato.Text = "" Then
            MsgBox("Estado Contrato es un dato requerido",, "SiCoFa")
            e.Cancel = True
        End If
    End Sub
    Private Sub DataGridView1_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles DataGridView1.UserDeletingRow
        If mobj_N_AdminContratos.EliminarServicioAsociado(Me.DataGridView1.CurrentRow.Cells(0).Value) > 0 Then
            MsgBox("El servicio asociado se eliminó con éxito",, "SiCoFa")
        Else
            MsgBox("El servicio asociado no se eliminó",, "SiCoFa")
        End If
    End Sub
    Private Sub DataGridView1_KeyUp(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyUp
        If Me.DataGridView1.CurrentRow.Cells("IdDS").Value > 0 Then
            Exit Sub
        End If

        Select Case e.KeyCode
            Case 45
                Dim str As String = UCase(InputBox("Ingrese el servicio", "SiCoFa", "*"))
                Dim ls As List(Of Servicio)

                If str = "*" Then
                    ls = mobj_N_AdminContratos.ListaServiciosCompleta
                Else
                    ls = mobj_N_AdminContratos.ListarServiciosBuscados(str)
                End If

                Dim s As Servicio

                Select Case ls.Count
                    Case 0
                        MsgBox("No se encontro el Servicio",, "SiCoFa")
                        Exit Sub
                    Case 1
                        s = ls.First
                    Case > 1
                        FrmBuscaServicios.Servicios = ls
                        FrmBuscaServicios.ShowDialog()

                        If FrmBuscaServicios.ServicioSeleccionado Is Nothing Then
                            FrmBuscaServicios.Close()
                            Exit Sub
                        End If

                        s = FrmBuscaServicios.ServicioSeleccionado
                        FrmBuscaServicios.Close()
                End Select

                Dim Id As Integer = mobj_N_AdminContratos.InsertarServicioAsociado(Me.IdContrato.Text, s.CodiS)
                If Id > 0 Then
                    Dim x As Integer = Me.DataGridView1.CurrentRow.Index
                    With Me.DataGridView1
                        .Rows.Add()
                        .Rows(x).Cells("IdDS").Value = Id
                        .Rows(x).Cells("CodiS").Value = s.CodiS
                        .Rows(x).Cells("DescripcionServicio").Value = s.DescripcionServicio
                        .Rows(x).Cells("Cantidad").Value = 1
                        .Rows(x).Cells("PUnit").Value = s.PUnit
                        .Rows(x).Cells("ImpServ").Value = Format(s.PUnit, "Standard")
                        .CurrentCell = .Rows(x).Cells("Cantidad")
                    End With

                End If
            Case 13

                If Me.DataGridView1.CurrentCell.ColumnIndex = 3 Then
                    Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(Me.DataGridView1.CurrentRow.Index).Cells("DescripcionServicio")
                End If
        End Select
    End Sub
    Private Sub DataGridView1_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DataGridView1.RowValidating
        Dim Id As Integer = Me.DataGridView1.CurrentRow.Cells("IdDS").Value

        If Id = 0 Then
            Exit Sub
        End If

        Dim PUn As Decimal = Me.DataGridView1.CurrentRow.Cells("PUnit").Value
        Dim Cant As Integer = Me.DataGridView1.CurrentRow.Cells("Cantidad").Value
        Dim Imp As Decimal = PUn * Cant

        Me.DataGridView1.CurrentRow.Cells("ImpServ").Value = Format(Imp, "Standard")

        If mobj_N_AdminContratos.ActualizarServicioAsociado(Id, Cant) = 0 Then
            e.Cancel = True
            MsgBox("No se pudo actualizar la cantidad", "SiCoFa")
        End If
    End Sub

End Class