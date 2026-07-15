Imports SiCoFa.Negocio
Imports System.ComponentModel
Imports SiCoFa.Entidades
Public Class FrmUsuarios

    Private mAdminUsuarios As New N_AdminUsuarios
    Private ControlesReadOnly As New List(Of String) From {"TxtId", "TxtFechaAlta"}
    Private DatosOpcionales As New List(Of String) From {"TxtId", "TxtDomicilio", "TxtLocalidad", "UcProvincia", "TxtTelefono", "TxtEmail", "TxtFechaAlta", "CmbEstado"}

    Private Sub BuscarUsuario(ByVal argTextoBuscado As String)

        Try
            Dim lu As List(Of Usuario) = mAdminUsuarios.ListarUsuarios(argTextoBuscado)
            Dim u As Usuario = Nothing

            If lu Is Nothing Then
                MsgBox("Usuario no Encontrado", vbInformation, "SiCoFa")
                Me.TxtNombre.Text = ""
                Me.TxtNombre.Select()
                Exit Sub
            End If

            Select Case lu.Count
                Case 0
                    MsgBox("Usuario no Encontrado", vbInformation, "SiCoFa")
                    Me.TxtNombre.Text = ""
                    Me.TxtNombre.Select()
                    Exit Sub
                Case 1
                    u = lu.First
                Case > 1
                    Using f As New FrmBuscaPersonas
                        f.Personas = lu
                        f.ShowDialog()
                        If f.DialogResult = DialogResult.OK Then
                            Dim p As Persona = f.PersonaSeleccionado
                            u = New Usuario(p.Id, p.Nombre, p.Domicilio, p.Localidad, p.Provincia, p.Telefono, p.Email, p.Documento, p.FechaAlta, p.Estado)
                        End If
                        f.Close()
                    End Using
            End Select

            With Me
                .LimpiarFormulario()
                .MostrarUsuario(u)
                .TxtNombre.Select()
                .TxtNombre.SelectAll()
            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub MostrarUsuario(ByVal argUsuario As Usuario)

        Try
            With Me
                .TxtId.Text = argUsuario.Id
                .TxtNombre.Text = argUsuario.Nombre
                .TxtDomicilio.Text = argUsuario.Domicilio
                .TxtLocalidad.Text = argUsuario.Localidad
                .UcProvincia.Descripcion = argUsuario.Provincia
                .TxtTelefono.Text = argUsuario.Telefono
                .TxtEmail.Text = argUsuario.Email
                .UcTipoDoc.Asignar(argUsuario.Documento.TipoDoc.CodiTD, argUsuario.Documento.TipoDoc.Descripcion)
                .TxtNumDoc.Text = argUsuario.Documento.Numero
                .TxtFechaAlta.Text = argUsuario.FechaAlta
                .UcEstado.Descripcion = argUsuario.Estado
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
                Dim Id As Integer = mAdminUsuarios.InsertarUsuario(Me.TxtNombre.Text, Me.TxtDomicilio.Text, Me.TxtLocalidad.Text, Me.UcProvincia.Descripcion, Me.TxtTelefono.Text, Me.TxtEmail.Text, Me.UcTipoDoc.Id, Me.TxtNumDoc.Text)
                If Id > 0 Then
                    Me.TxtId.Text = Id
                    Me.TxtNombre.Text = UCase(Me.TxtNombre.Text)
                    MsgBox("Se dio de alta el Usuario " & TxtNombre.Text, vbInformation, "SiCoFa")
                Else
                    MsgBox("Ocurrio un error, intente nuevamente", vbCritical, "SiCoFa")
                    Exit Sub
                End If
                Me.NuevaPersona = False
                Me.Nuevo.Checked = False
            Else
                If Me.TxtId.Text = "" Then
                    MsgBox("El Usuario " & Me.TxtNombre.Text & " no fue dado de Alta", vbInformation, "SiCoFa")
                    Exit Sub
                End If

                Dim Actualizado As Boolean = mAdminUsuarios.ActualizarUsuario(Me.TxtId.Text, Me.TxtDomicilio.Text, Me.TxtLocalidad.Text, Me.UcProvincia.Descripcion, Me.TxtTelefono.Text, Me.TxtEmail.Text, Me.UcTipoDoc.Id, Me.TxtNumDoc.Text, Me.UcEstado.Descripcion)

                If Actualizado = True Then
                    MsgBox("El Usuario " & TxtNombre.Text & " se acutalizo correctamente", vbInformation, "SiCoFa")
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

            If Me.TxtNombre.Text = "" Or Me.NuevaPersona = True Or Me.TxtId.Text <> "" Then
                Exit Sub
            End If

            Me.BuscarUsuario(Me.TxtNombre.Text)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

End Class