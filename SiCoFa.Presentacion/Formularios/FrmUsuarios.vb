Imports System.ComponentModel
Imports SiCoFa.Entidades
Public Class FrmUsuarios

    Private ControlesReadOnly As New List(Of String) From {"Id", "FechaAlta"}
    Private DatosOpcionales As New List(Of String) From {"Id", "Domicilio", "Localidad", "Provincia", "Telefono", "Email"}
    Private Function BuscarUsuario(ByVal argTextoBuscado As String) As Usuario
        Dim lu As List(Of Usuario) = mobj_N_AdminSiCoFa.ListarUsuarios(argTextoBuscado)
        Dim u As Usuario = Nothing

        If lu Is Nothing Then
            MsgBox("Usuario no Encontrado", vbInformation, "SiCoFa")
            Return Nothing
            Exit Function
        End If

        Select Case lu.Count
            Case 0
                MsgBox("Usuario no Encontrado", vbInformation, "SiCoFa")
                Return Nothing
                Exit Function
            Case 1
                u = lu.First
            Case > 1
                FrmBuscaPersonas.Personas = lu
                FrmBuscaPersonas.ShowDialog()

                If FrmBuscaPersonas.PersonaSeleccionado IsNot Nothing Then
                    Dim p = FrmBuscaPersonas.PersonaSeleccionado
                    u = New Usuario(p.Id, p.Nombre, p.Domicilio, p.Localidad, p.Provincia, p.Telefono, p.Email, p.Documento.TipoDoc.CodiTDoc, p.Documento.Numero, p.FechaAlta, p.Estado)
                End If
                FrmBuscaPersonas.Close()
        End Select

        Return u
        u = Nothing

    End Function
    Private Sub MostrarUsuario(ByVal argUsuario As Usuario)
        With Me
            .Id.Text = argUsuario.Id
            .Nombre.Text = argUsuario.Nombre
            .Domicilio.Text = argUsuario.Domicilio
            .Localidad.Text = argUsuario.Localidad
            .Provincia.Text = argUsuario.Provincia
            .Telefono.Text = argUsuario.Telefono
            .Email.Text = argUsuario.Email
            .TipoDoc.Text = argUsuario.Documento.TipoDoc.TipoDocumento
            .NumDoc.Text = argUsuario.Documento.Numero
            .FechaAlta.Text = argUsuario.FechaAlta
            .Estado.Text = argUsuario.Estado
        End With
    End Sub
    Public Overrides Sub Guardar_Click(sender As Object, e As EventArgs)
        Me.ValidarCampos(DatosOpcionales)

        If Me.ValidacionOK = False Then
            Exit Sub
        End If

        If Me.NuevaPersona = True Then
            Dim Id As Integer = mobj_N_AdminSiCoFa.InsertarUsuario(Me.Nombre.Text, Me.Domicilio.Text, Me.Localidad.Text, Me.Provincia.Text, Me.Telefono.Text, Me.Email.Text, Me.TipoDoc.SelectedValue, Me.NumDoc.Text)
            If Id > 0 Then
                Me.Id.Text = Id
                Me.Nombre.Text = UCase(Me.Nombre.Text)
                MsgBox("Se dio de alta el Usuario " & Nombre.Text, vbInformation, "SiCoFa")
            Else
                MsgBox("Ocurrio un error, intente nuevamente", vbCritical, "SiCoFa")
                Exit Sub
            End If
            Me.NuevaPersona = False
        Else
            If Me.Id.Text = "" Then
                MsgBox("El Usuario " & Me.Nombre.Text & " no fue dado de Alta", vbInformation, "SiCoFa")
                Exit Sub
            End If

            Dim Actualizado As Boolean = mobj_N_AdminSiCoFa.ActualizarEmpleado(Me.Id.Text, Me.Domicilio.Text, Me.Localidad.Text, Me.Provincia.Text, Me.Telefono.Text, Me.Email.Text, Me.TipoDoc.SelectedValue, Me.NumDoc.Text, Me.Estado.SelectedValue)

            If Actualizado = True Then
                MsgBox("El Usuario " & Nombre.Text & " se acutalizo correctamente", vbInformation, "SiCoFa")
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
        valoresDefecto.Add("FechaAlta", Date.Today.ToShortDateString) ' Año, Mes, Día
        valoresDefecto.Add("Estado", "ACTIVO") ' O el ValueMember si aplica
        ' Agrega aquí los nombres de todos los controles y sus valores por defecto

        ' Llama al procedimiento para establecer los valores por defecto
        EstablecerValoresPorDefecto(valoresDefecto)
    End Sub
    Public Overrides Sub Buscar_Click(sender As Object, e As EventArgs)
        MyBase.Buscar_Click(sender, e)

        If Me.TextoBuscar = "" Then
            Exit Sub
        End If

        Dim u As Usuario = BuscarUsuario(Me.TextoBuscar)

        If u Is Nothing Then
            Exit Sub
        End If

        With Me
            .LimpiarFormulario()
            .MostrarUsuario(u)
            .Nombre.Select()
        End With

    End Sub
    Public Overrides Sub Nombre_Validating(sender As Object, e As CancelEventArgs)
        MyBase.Nombre_Validating(sender, e)

        If Me.Nombre.Text = "" Or Me.NuevaPersona = True Then
            Exit Sub
        End If

        Dim u As Usuario = Me.BuscarUsuario(Me.Nombre.Text)

        If u Is Nothing Then
            Me.Nombre.Select()
            Me.Nombre.Text = ""
            Exit Sub
        End If

        With Me
            .LimpiarFormulario()
            .MostrarUsuario(u)
            .Nombre.SelectAll()
        End With

    End Sub

End Class