Imports System.ComponentModel
Imports SiCoFa.Entidades
Public Class FrmClientes

    Private ControlesReadOnly As New List(Of String) From {"Id", "FechaAlta"}
    Private DatosOpcionales As New List(Of String) From {"Id", "Domicilio", "Localidad", "Provincia", "Telefono", "Email"}
    Private Sub ObtenerTiposIVA()
        Me.IVA.DataSource = mobj_N_AdminSiCoFa.TiposIVA
        Me.IVA.ValueMember = "CodIVA"
        Me.IVA.DisplayMember = "TipoIVA"
        Me.IVA.SelectedIndex = -1
    End Sub
    Private Function SeleccionarClienteListado(ByVal Id As Long, ByVal ListaClientes As List(Of Cliente)) As Cliente
        Dim ClienteSeleccionado As Cliente = Nothing

        For Each c As Cliente In ListaClientes
            If c.Id = Id Then
                ClienteSeleccionado = c
                Exit For ' Opcional: detener la búsqueda una vez encontrado el cliente
            End If
        Next
        Return ClienteSeleccionado

    End Function
    Private Function BuscarCliente(ByVal argTextoBuscado As String) As Cliente
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
                    Dim p = FrmBuscaPersonas.PersonaSeleccionado
                    c = Me.SeleccionarClienteListado(p.Id, lc)
                End If
                FrmBuscaPersonas.Close()
        End Select

        Return c
        c = Nothing

    End Function
    Private Sub MostrarCliente(ByVal argCliente As Cliente)
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
            .FechaAlta.Text = argCliente.FechaAlta
            .Estado.Text = argCliente.Estado
            .IVA.Text = argCliente.IVA.TipoIVA
        End With
    End Sub
    Public Overrides Sub Guardar_Click(sender As Object, e As EventArgs)
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

            Dim Actualizado As Boolean = mobj_N_AdminSiCoFa.ActualizarCliente(Me.Id.Text, Me.Domicilio.Text, Me.Localidad.Text, Me.Provincia.Text, Me.Telefono.Text, Me.Email.Text, Me.TipoDoc.SelectedValue, Me.NumDoc.Text, Me.IVA.SelectedValue, Me.Estado.Text)

            If Actualizado = True Then
                MsgBox("El Cliente " & Nombre.Text & " se acutalizo correctamente",, "SiCoFa")
            Else
                MsgBox("Ocurrio un error, intente nuevamente", "SiCoFa")
                Exit Sub
            End If
        End If

        Me.LimpiarFormulario()
        Me.Nombre.Select()

    End Sub
    Public Overrides Sub Nuevo_Click(sender As Object, e As EventArgs)
        MyBase.Nuevo_Click(sender, e)
        Dim valoresDefecto As New Dictionary(Of String, Object)
        With valoresDefecto
            .Add("FechaAlta", Date.Today.ToShortDateString)
            .Add("Estado", "ACTIVO")
        End With



        EstablecerValoresPorDefecto(valoresDefecto)
    End Sub
    Public Overrides Sub Buscar_Click(sender As Object, e As EventArgs)
        MyBase.Buscar_Click(sender, e)

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

    End Sub
    Public Overrides Sub Nombre_Validating(sender As Object, e As CancelEventArgs)
        MyBase.Nombre_Validating(sender, e)

        If Me.Nombre.Text = "" Or Me.NuevaPersona = True Then
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
            .Nombre.SelectAll()
        End With

    End Sub
    Private Sub FrmClientes_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.EstablecerReadOnly(Me.ControlesReadOnly)
        Me.ObtenerTiposIVA()
    End Sub
End Class