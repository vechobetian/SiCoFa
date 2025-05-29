Imports System.ComponentModel
Imports SiCoFa.Entidades
Imports SiCoFa.Negocio
Public Class FrmPanelClientes
    Private TextoBuscar As String
    Private NuevaPersona As Boolean
    Private NuevaCtaCte As Boolean
    Private mobj_AdminSicofa As New N_AdminSiCoFa
    Private ControlesReadOnly As New List(Of String) From {"Id", "FechaAltaCliente", "IdCC", "Descripcion", "FechaAltaCuentaCorriente"}
    Private DatosOpcionales As New List(Of String) From {"Id", "Domicilio", "Localidad", "Provincia", "Telefono", "Email", "IdCC", "Descripcion", "Observaciones"}
    Private pestanaCuentaCorriente As TabPage
    Private indiceOriginalCuentaCorriente As Integer
    Private Sub OcultarPestanaCuentaCorriente()
        Try

            If Me.PanelCliente.TabPages.Contains(pestanaCuentaCorriente) Then
                Me.PanelCliente.TabPages.Remove(pestanaCuentaCorriente)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Private Sub MostrarPestanaCuentaCorriente()
        Try

            If Not Me.PanelCliente.TabPages.Contains(pestanaCuentaCorriente) AndAlso pestanaCuentaCorriente IsNot Nothing Then
                If indiceOriginalCuentaCorriente >= 0 AndAlso indiceOriginalCuentaCorriente <= Me.PanelCliente.TabPages.Count Then
                    Me.PanelCliente.TabPages.Insert(indiceOriginalCuentaCorriente, pestanaCuentaCorriente)
                Else
                    ' Si el índice no es válido, la agrega al final (esto no debería ocurrir aquí)
                    Me.PanelCliente.TabPages.Add(pestanaCuentaCorriente)
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Private Sub ObtenerProvincias()
        Try
            With Me.Provincia
                .DataSource = mobj_AdminSicofa.Provincias
                .ValueMember = "PROVINCIA"
                .DisplayMember = "PROVINCIA"
                .SelectedIndex = -1
            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub ObtenerTiposDocumento()

        Try
            Me.TipoDoc.DataSource = mobj_AdminSicofa.TiposDocumento
            Me.TipoDoc.ValueMember = "CodiTDoc"
            Me.TipoDoc.DisplayMember = "TipoDocumento"
            Me.TipoDoc.SelectedIndex = -1

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub ObtenerTiposIVA()

        Try
            Me.IVA.DataSource = mobj_AdminSicofa.TiposIVA
            Me.IVA.ValueMember = "CodIVA"
            Me.IVA.DisplayMember = "TipoIVA"
            Me.IVA.SelectedIndex = -1
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Function SeleccionarClienteListado(ByVal Id As Int32, ByVal ListaClientes As List(Of Cliente)) As Cliente

        Try
            Dim ClienteSeleccionado As Cliente = Nothing

            For Each c As Cliente In ListaClientes
                If c.Id = Id Then
                    ClienteSeleccionado = c
                    Exit For ' Opcional: detener la búsqueda una vez encontrado el cliente
                End If
            Next
            Return ClienteSeleccionado

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
            Return Nothing
        End Try

    End Function

    Private Sub BuscarCliente(ByVal argTextoBuscado As String)

        Try

            Dim lc As List(Of Cliente) = mobj_AdminSicofa.ListarClientes(argTextoBuscado)
            Dim c As Cliente = Nothing

            If lc Is Nothing Then
                MsgBox("Cliente no Encontrado", vbInformation, "SiCoFa")
                Exit Sub
            End If

            Select Case lc.Count
                Case 0
                    MsgBox("Cliente no Encontrado", vbInformation, "SiCoFa")
                    Me.Nombre.Text = ""
                    Me.Nombre.Select()
                    Exit Sub

                Case 1
                    c = lc.First

                Case > 1
                    Using f As New FrmBuscaPersonas
                        f.Personas = lc
                        f.ShowDialog()
                        If f.DialogResult = DialogResult.OK Then
                            Dim p As Persona = f.PersonaSeleccionado
                            c = Me.SeleccionarClienteListado(p.Id, lc)
                        End If
                        f.Close()
                    End Using
            End Select

            With Me
                .LimpiarFormulario()
                .MostrarCliente(c)
                .MostrarCuentaCorriente(c.Id)
                .Nombre.ReadOnly = True
                .Nombre.Select()
                .Nombre.SelectAll()
            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
        End Try

    End Sub

    Private Sub MostrarCliente(ByVal argCliente As Cliente)

        Try
            With Me
                .Id.Text = argCliente.Id
                .Nombre.Text = argCliente.Nombre
                .Domicilio.Text = argCliente.Domicilio
                .Localidad.Text = argCliente.Localidad
                .Provincia.Text = argCliente.Provincia
                .Telefono.Text = argCliente.Telefono
                .Email.Text = argCliente.Email
                .TipoDoc.Text = argCliente.Documento.TipoDoc.TipoDocumento
                .NumDoc.Text = argCliente.Documento.Numero
                .FechaAltaCliente.Text = argCliente.FechaAlta
                .EstadoCliente.Text = argCliente.Estado
                .IVA.Text = argCliente.IVA.TipoIVA
            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub MostrarCuentaCorriente(ByVal argIdCliente As Int32)
        Try
            Dim cc As CuentaCorriente = mobj_AdminSicofa.ObtenerCuentaCorrientePorIdCliente(argIdCliente)
            If cc IsNot Nothing Then
                Me.IdCC.Text = cc.IdCC
                Me.Descripcion.Text = cc.Descripcion
                Me.Credito.Text = cc.Credito
                Me.FechaAltaCuentaCorriente.Text = cc.FechaAlta
                Me.EstadoCuentaCorriente.Text = cc.Estado
                Me.Observaciones.Text = cc.Observaciones
                Me.MostrarPestanaCuentaCorriente()
            Else
                Me.NuevaCuentaCorriente.Visible = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub Guardar_Click(sender As Object, e As EventArgs) Handles Guardar.Click

        Try
            Me.ValidarCampos(Me.Cliente, DatosOpcionales)

            If Me.ValidacionOK = False Then
                Exit Sub
            End If

            If Me.NuevaPersona = True Then

                Dim IdCliente As Integer = mobj_AdminSicofa.InsertarCliente(Me.Nombre.Text, Me.Domicilio.Text, Me.Localidad.Text, Me.Provincia.Text, Me.Telefono.Text, Me.Email.Text, Me.TipoDoc.SelectedValue, Me.NumDoc.Text, Me.IVA.SelectedValue)
                If IdCliente > 0 Then
                    Me.Id.Text = IdCliente
                    Me.Nombre.Text = UCase(Me.Nombre.Text)
                    MsgBox("Se dio de alta el Cliente " & Nombre.Text,, "SiCoFa")
                Else
                    MsgBox("Ocurrio un error, intente nuevamente",, "SiCoFa")
                    Exit Sub
                End If

                Me.NuevaPersona = False
                Me.NuevoCliente.Checked = False

            Else
                If Me.Id.Text = "" Then
                    MsgBox("El cliente " & Me.Nombre.Text & " no fue dado de Alta", vbInformation, "SiCoFa")
                    Exit Sub
                End If

                Dim Actualizado As Boolean = mobj_AdminSicofa.ActualizarCliente(Me.Id.Text, Me.Domicilio.Text, Me.Localidad.Text, Me.Provincia.Text, Me.Telefono.Text, Me.Email.Text, Me.TipoDoc.SelectedValue, Me.NumDoc.Text, Me.IVA.SelectedValue, Me.EstadoCliente.Text)

                If Actualizado = True Then
                    MsgBox("El Cliente " & Nombre.Text & " se acutalizo correctamente",, "SiCoFa")
                Else
                    MsgBox("Ocurrio un error, intente nuevamente", "SiCoFa")
                    Exit Sub
                End If
            End If

            If Me.NuevaCtaCte = True Or Me.IdCC.Text <> "" Then
                Me.ValidacionOK = False
                Me.ValidarCampos(Me.CuentaCorriente, DatosOpcionales)
            End If

            If Me.ValidacionOK = False Then
                Exit Sub
            End If

            If Me.NuevaCtaCte = True Then

                Dim IdCC As Integer = mobj_AdminSicofa.InsertarCuentaCorriente(Me.Id.Text, UCase(Me.Descripcion.Text), Convert.ToDecimal(Me.Credito.Text), Me.Observaciones.Text)
                If IdCC > 0 Then
                    Me.IdCC.Text = IdCC
                Else
                    MsgBox("No se pudo crear la cuenta corriente, intente nuevamente",, "SiCoFa")
                    Exit Sub
                End If

                Me.NuevaCtaCte = False
                Me.NuevoCliente.Checked = False

            ElseIf Me.IdCC.Text <> "" Then

                Dim Actualizado As Boolean = mobj_AdminSicofa.ActualizarCuentaCorriente(Me.IdCC.Text, Me.Credito.Text, Me.Observaciones.Text, Me.EstadoCuentaCorriente.Text)

                If Actualizado = False Then
                    MsgBox("No se pudo actualizar la cuenta corriente, intente nuevamente", "SiCoFa")
                    Exit Sub
                End If
            End If

            Me.LimpiarFormulario()
            Me.PanelCliente.SelectedTab = Me.Cliente
            Me.Nombre.Select()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try
    End Sub

    Private Sub NuevoCliente_Click(sender As Object, e As EventArgs) Handles NuevoCliente.Click
        Try
            Me.LimpiarFormulario()
            Me.NuevaPersona = True
            Me.NuevoCliente.Checked = True
            Me.Nombre.ReadOnly = False
            Me.Nombre.Select()

            Dim valoresDefecto As New Dictionary(Of String, Object)

            With valoresDefecto
                .Add("FechaAltaCliente", Date.Today.ToShortDateString)
                .Add("FechaAltaCuentaCorriente", Date.Today.ToShortDateString)
                .Add("EstadoCliente", "ACTIVO")
                .Add("EstadoCuentaCorriente", "HABILITADA")
            End With

            Me.EstablecerValoresPorDefecto(Me.Cliente, valoresDefecto)
            Me.EstablecerValoresPorDefecto(Me.CuentaCorriente, valoresDefecto)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try
    End Sub
    Private Sub Buscar_Click(sender As Object, e As EventArgs) Handles Buscar.Click

        Try
            If Me.NuevaPersona = True Then
                Exit Sub
            End If

            Dim str = InputBox("Ingrese la Persona", "SiCoFa")
            Me.TextoBuscar = ""
            If str = "" Then
                Me.Nombre.Select()
                Exit Sub
            Else
                Me.TextoBuscar = str
            End If

            If Me.TextoBuscar = "" Then
                Exit Sub
            End If

            Me.BuscarCliente(Me.TextoBuscar)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub Limpiar_Click(sender As Object, e As EventArgs) Handles Limpiar.Click
        Try

            Me.LimpiarFormulario()
            Me.NuevaPersona = False
            Me.OcultarPestanaCuentaCorriente()
            Me.Nombre.ReadOnly = False
            Me.Nombre.Select()
            Me.NuevoCliente.Checked = False

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
        End Try

    End Sub
    Private Sub NuevaCuentaCorriente_Click(sender As Object, e As EventArgs) Handles NuevaCuentaCorriente.Click
        Try
            Me.MostrarPestanaCuentaCorriente()
            Me.NuevaCtaCte = True
            Dim valoresDefecto As New Dictionary(Of String, Object)

            With valoresDefecto
                .Add("Descripcion", UCase(Me.Nombre.Text))
                .Add("FechaAltaCuentaCorriente", Date.Today.ToShortDateString)
                .Add("EstadoCuentaCorriente", "HABILITADA")
            End With

            Me.EstablecerValoresPorDefecto(Me.CuentaCorriente, valoresDefecto)

            Me.PanelCliente.SelectedTab = Me.CuentaCorriente

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub Nombre_Validating(sender As Object, e As CancelEventArgs) Handles Nombre.Validating

        Try

            If Me.Nombre.Text = "" Or Me.NuevaPersona = True Or Me.Id.Text <> "" Then
                Exit Sub
            End If

            Me.BuscarCliente(Me.Nombre.Text)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Private Sub FrmPanelClientes_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try

            Me.EstablecerReadOnly(Me.Cliente, Me.ControlesReadOnly)
            Me.EstablecerReadOnly(Me.CuentaCorriente, Me.ControlesReadOnly)
            Me.ObtenerProvincias()
            Me.ObtenerTiposDocumento()
            Me.ObtenerTiposIVA()
            pestanaCuentaCorriente = Me.PanelCliente.TabPages("CuentaCorriente")
            indiceOriginalCuentaCorriente = Me.PanelCliente.TabPages.IndexOf(pestanaCuentaCorriente)
            OcultarPestanaCuentaCorriente()
            Me.Nombre.Select()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

End Class
