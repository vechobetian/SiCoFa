Imports System.ComponentModel
Imports SiCoFa.Entidades
Imports SiCoFa.Negocio
Public Class FrmPanelClientes
    Property TextoBuscar As String
    Property NuevaPersona As Boolean

    Private mobj_N_AdminSiCoFa As New cls_N_AdminSiCoFa
    Private ControlesReadOnly As New List(Of String) From {"Id", "FechaAlta"}
    Private DatosOpcionales As New List(Of String) From {"Id", "Domicilio", "Localidad", "Provincia", "Telefono", "Email"}

    Private Sub ObtenerTiposDocumento()

        Try
            Me.TipoDoc.DataSource = mobj_N_AdminSiCoFa.TiposDocumento
            Me.TipoDoc.ValueMember = "CodiTDoc"
            Me.TipoDoc.DisplayMember = "TipoDocumento"
            Me.TipoDoc.SelectedIndex = -1

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub ObtenerTiposIVA()

        Try
            Me.IVA.DataSource = mobj_N_AdminSiCoFa.TiposIVA
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

    Private Function BuscarCliente(ByVal argTextoBuscado As String) As Cliente

        Try
            Dim lc As List(Of Cliente) = mobj_N_AdminSiCoFa.ListarClientes(argTextoBuscado)
            Dim c As Cliente = Nothing

            If lc Is Nothing Then
                MsgBox("Cliente no Encontrado", vbInformation, "SiCoFa")
                Return Nothing
                Exit Function
            End If

            Select Case lc.Count
                Case 0
                    MsgBox("Cliente no Encontrado", vbInformation, "SiCoFa")
                    Return Nothing
                    Exit Function
                Case 1
                    c = lc.First
                Case > 1
                    FrmBuscaPersonas.Personas = lc
                    FrmBuscaPersonas.ShowDialog()

                    If FrmBuscaPersonas.PersonaSeleccionado IsNot Nothing Then
                        Dim p As Persona = FrmBuscaPersonas.PersonaSeleccionado
                        c = Me.SeleccionarClienteListado(p.Id, lc)
                    End If
                    FrmBuscaPersonas.Close()
            End Select

            Return c
            c = Nothing
            With Me
                .LimpiarFormulario()
                .MostrarCliente(c)
                .Nombre.Select()
                .Nombre.SelectAll()
            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
            Return Nothing
        End Try

    End Function

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

    Public Sub Guardar_Click(sender As Object, e As EventArgs) Handles Guardar.Click

        Try
            Me.ValidarCampos(DatosOpcionales)

            If Me.ValidacionOK = False Then
                Exit Sub
            End If

            If Me.NuevaPersona = True Then
                Dim Id As Integer = mobj_N_AdminSiCoFa.InsertarCliente(Me.Nombre.Text, Me.Domicilio.Text, Me.Localidad.Text, Me.Provincia.Text, Me.Telefono.Text, Me.Email.Text, Me.TipoDoc.SelectedValue, Me.NumDoc.Text, Me.IVA.SelectedValue)
                If Id > 0 Then
                    Me.Id.Text = Id
                    Me.Nombre.Text = UCase(Me.Nombre.Text)
                    MsgBox("Se dio de alta el Cliente " & Nombre.Text,, "SiCoFa")
                Else
                    MsgBox("Ocurrio un error, intente nuevamente",, "SiCoFa")
                    Exit Sub
                End If
                Me.NuevaPersona = False
            Else
                If Me.Id.Text = "" Then
                    MsgBox("El cliente " & Me.Nombre.Text & " no fue dado de Alta", vbInformation, "SiCoFa")
                    Exit Sub
                End If

                Dim Actualizado As Boolean = mobj_N_AdminSiCoFa.ActualizarCliente(Me.Id.Text, Me.Domicilio.Text, Me.Localidad.Text, Me.Provincia.Text, Me.Telefono.Text, Me.Email.Text, Me.TipoDoc.SelectedValue, Me.NumDoc.Text, Me.IVA.SelectedValue, Me.EstadoCliente.Text)

                If Actualizado = True Then
                    MsgBox("El Cliente " & Nombre.Text & " se acutalizo correctamente",, "SiCoFa")
                Else
                    MsgBox("Ocurrio un error, intente nuevamente", "SiCoFa")
                    Exit Sub
                End If
            End If

            Me.LimpiarFormulario()
            Me.Nombre.Select()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try
    End Sub

    Public Sub Nuevo_Click(sender As Object, e As EventArgs) Handles Nuevo.Click
        Try
            Me.LimpiarFormulario()
            Me.NuevaPersona = True
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
    Public Sub Buscar_Click(sender As Object, e As EventArgs) Handles Buscar.Click

        Try
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

            Dim c As Cliente = BuscarCliente(Me.TextoBuscar)

            If c Is Nothing Then
                Exit Sub
            End If

            With Me
                .LimpiarFormulario()
                .MostrarCliente(c)
                .Nombre.Select()
            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub Limpiar_Click(sender As Object, e As EventArgs) Handles Limpiar.Click
        Me.LimpiarFormulario()
        Me.NuevaPersona = False
        Me.Nombre.Select()
    End Sub

    Public Sub Nombre_Validating(sender As Object, e As CancelEventArgs)

        Try
            'MyBase.Nombre_Validating(sender, e)

            If Me.Nombre.Text = "" Or Me.NuevaPersona = True Or Me.Id.Text <> "" Then
                Exit Sub
            End If

            Dim c As Cliente = Me.BuscarCliente(Me.Nombre.Text)

            If c Is Nothing Then
                Me.Nombre.Select()
                Me.Nombre.Text = ""
                Exit Sub
            End If

            With Me
                .LimpiarFormulario()
                .MostrarCliente(c)
                .Nombre.Select()
                .Nombre.SelectAll()
            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Private Sub FrmPanelClientes_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.EstablecerReadOnly(Me.ControlesReadOnly)
        Me.ObtenerTiposDocumento()
        Me.ObtenerTiposIVA()
    End Sub

End Class
