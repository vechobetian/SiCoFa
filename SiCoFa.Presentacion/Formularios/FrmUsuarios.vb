Imports System.ComponentModel
Imports SiCoFa.Entidades
Public Class FrmUsuarios

    Private ControlesReadOnly As New List(Of String) From {"Id", "FechaAlta"}
    Private DatosOpcionales As New List(Of String) From {"Id", "Domicilio", "Localidad", "Provincia", "Telefono", "Email"}
    Private Sub BuscarUsuario(ByVal argTextoBuscado As String)

        Try
            Dim lu As List(Of Usuario) = mobj_N_AdminSiCoFa.ListarUsuarios(argTextoBuscado)
            Dim u As Usuario = Nothing

            If lu Is Nothing Then
                MsgBox("Usuario no Encontrado", vbInformation, "SiCoFa")
                Me.Nombre.Text = ""
                Me.Nombre.Select()
                Exit Sub
            End If

            Select Case lu.Count
                Case 0
                    MsgBox("Usuario no Encontrado", vbInformation, "SiCoFa")
                    Me.Nombre.Text = ""
                    Me.Nombre.Select()
                    Exit Sub
                Case 1
                    u = lu.First
                Case > 1
                    Using f As New FrmBuscaPersonas
                        f.Personas = lu
                        f.ShowDialog()
                        If f.DialogResult = DialogResult.OK Then
                            Dim p As Persona = f.PersonaSeleccionado
                            u = New Usuario(p.Id, p.Nombre, p.Domicilio, p.Localidad, p.Provincia, p.Telefono, p.Email, p.Documento.TipoDoc.CodiTDoc, p.Documento.Numero, p.FechaAlta, p.Estado)
                        End If
                        f.Close()
                    End Using
            End Select

            With Me
                .LimpiarFormulario()
                .MostrarUsuario(u)
                .Nombre.Select()
                .Nombre.SelectAll()
            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Private Sub MostrarUsuario(ByVal argUsuario As Usuario)

        Try
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
                Me.Nuevo.Checked = False
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

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Public Overrides Sub Nuevo_Click(sender As Object, e As EventArgs)

        Try
            MyBase.Nuevo_Click(sender, e)
            Dim valoresDefecto As New Dictionary(Of String, Object)
            valoresDefecto.Add("FechaAlta", Date.Today.ToShortDateString) ' Año, Mes, Día
            valoresDefecto.Add("Estado", "ACTIVO") ' O el ValueMember si aplica
            ' Agrega aquí los nombres de todos los controles y sus valores por defecto

            ' Llama al procedimiento para establecer los valores por defecto
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

            Me.BuscarUsuario(Me.TextoBuscar)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Public Overrides Sub Nombre_Validating(sender As Object, e As CancelEventArgs)

        Try
            MyBase.Nombre_Validating(sender, e)

            If Me.Nombre.Text = "" Or Me.NuevaPersona = True Or Me.Id.Text <> "" Then
                Exit Sub
            End If

            Me.BuscarUsuario(Me.Nombre.Text)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

End Class