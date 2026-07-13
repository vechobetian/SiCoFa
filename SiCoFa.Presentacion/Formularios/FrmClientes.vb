Imports SiCoFa.Negocio
Imports System.ComponentModel
Imports SiCoFa.Entidades
Public Class FrmClientes

    Private mAdminClientes As New N_AdminClientes
    Private ControlesReadOnly As New List(Of String) From {"TxtId", "TxtFechaAlta"}
    Private DatosOpcionales As New List(Of String) From {"TxtId", "TxtDomicilio", "TxtLocalidad", "UcProvincia", "TxtTelefono", "TxtEmail"}

    Private Sub CargarComboTipoIVA()

        Try
            IVA.DataSource = Nothing
            IVA.DisplayMember = "Descripcion"
            IVA.ValueMember = "CodIVA"
            IVA.DataSource = TipoIVA.Lista
            IVA.SelectedIndex = -1
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
            Dim lc As List(Of Cliente) = mAdminClientes.ListarClientes(argTextoBuscado)
            Dim c As Cliente = Nothing

            If lc Is Nothing Then
                MsgBox("Cliente no Encontrado", vbInformation, "SiCoFa")
                Exit Sub
            End If

            Select Case lc.Count
                Case 0
                    MsgBox("Cliente no Encontrado", vbInformation, "SiCoFa")
                    Me.TxtNombre.Text = ""
                    Me.TxtNombre.Select()
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
                .TxtNombre.Select()
                .TxtNombre.SelectAll()
            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Private Sub MostrarCliente(ByVal argCliente As Cliente)

        If argCliente Is Nothing Then
            Exit Sub
        End If

        Try
            With Me
                .TxtId.Text = argCliente.Id
                .TxtNombre.Text = argCliente.Nombre
                .TxtDomicilio.Text = argCliente.Domicilio
                .TxtLocalidad.Text = argCliente.Localidad
                .UcProvincia.Descripcion = argCliente.Provincia
                .TxtTelefono.Text = argCliente.Telefono
                .TxtEmail.Text = argCliente.Email
                .UcTipoDoc.Asignar(argCliente.Documento.TipoDoc.CodiTDoc, argCliente.Documento.TipoDoc.Descripcion)
                .TxtNumDoc.Text = argCliente.Documento.Numero
                .TxtFechaAlta.Text = argCliente.FechaAlta
                .UcEstado.Descripcion = argCliente.Estado
                .IVA.Text = argCliente.IVA.Descripcion
            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Public Overrides Sub Guardar_Click(sender As Object, e As EventArgs)

        Try
            Me.ValidarCampos(Me, DatosOpcionales)

            If Me.ValidacionOK = False Then
                Exit Sub
            End If

            If Me.NuevaPersona = True Then

                Dim Id As Integer = mAdminClientes.InsertarCliente(Me.TxtNombre.Text, Me.TxtDomicilio.Text, Me.TxtLocalidad.Text, Me.UcProvincia.Descripcion, Me.TxtTelefono.Text, Me.TxtEmail.Text, Me.UcTipoDoc.Id, Me.TxtNumDoc.Text, Me.IVA.SelectedValue)
                If Id > 0 Then
                    Me.TxtId.Text = Id
                    Me.TxtNombre.Text = UCase(Me.TxtNombre.Text)
                    MsgBox("Se dio de alta el Cliente " & TxtNombre.Text,, "SiCoFa")
                Else
                    MsgBox("Ocurrio un error, intente nuevamente",, "SiCoFa")
                    Exit Sub
                End If
                Me.NuevaPersona = False
                Me.Nuevo.Checked = False
            Else
                If Me.TxtId.Text = "" Then
                    MsgBox("El cliente " & Me.TxtNombre.Text & " no fue dado de Alta", vbInformation, "SiCoFa")
                    Exit Sub
                End If

                Dim Actualizado As Boolean = mAdminClientes.ActualizarCliente(Me.TxtId.Text, Me.TxtDomicilio.Text, Me.TxtLocalidad.Text, Me.UcProvincia.Descripcion, Me.TxtTelefono.Text, Me.TxtEmail.Text, Me.UcTipoDoc.Id, Me.TxtNumDoc.Text, Me.IVA.SelectedValue, Me.UcEstado.Descripcion)

                If Actualizado = True Then
                    MsgBox("El Cliente " & TxtNombre.Text & " se acutalizo correctamente",, "SiCoFa")
                Else
                    MsgBox("Ocurrio un error, intente nuevamente", "SiCoFa")
                    Exit Sub
                End If
            End If

            Me.LimpiarFormulario()
            Me.TxtNombre.Select()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Public Overrides Sub Nuevo_Click(sender As Object, e As EventArgs)

        Try
            MyBase.Nuevo_Click(sender, e)
            Dim valoresDefecto As New Dictionary(Of String, Object)
            With valoresDefecto
                .Add("FechaAlta", Date.Today.ToShortDateString)
                .Add("Estado", "ACTIVO")
            End With

            EstablecerValoresPorDefecto(Me, valoresDefecto)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Public Overrides Sub Buscar_Click(sender As Object, e As EventArgs)

        Try
            MyBase.Buscar_Click(sender, e)

            If Me.TextoBuscar = "" Then
                Exit Sub
            End If

            Me.BuscarCliente(Me.TextoBuscar)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Public Overrides Sub Nombre_Validating(sender As Object, e As CancelEventArgs)

        Try
            MyBase.Nombre_Validating(sender, e)

            If Me.TxtNombre.Text = "" Or Me.NuevaPersona = True Or Me.TxtId.Text <> "" Then
                Exit Sub
            End If

            Me.BuscarCliente(Me.TxtNombre.Text)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Private Sub FrmClientes_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.EstablecerReadOnly(Me, Me.ControlesReadOnly)
        Me.CargarComboTipoIVA()
    End Sub
End Class