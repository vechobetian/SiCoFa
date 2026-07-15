Imports SiCoFa.Negocio
Imports System.ComponentModel
Imports SiCoFa.Entidades
Public Class FrmEmpleados

    Private mAdminEmpleados As New N_AdminEmpleados
    Private ControlesReadOnly As New List(Of String) From {"TxtId", "TxtFechaAlta"}
    Private DatosOpcionales As New List(Of String) From {"TxtId", "TxtDomicilio", "TxtLocalidad", "UcProvincia", "TxtTelefono", "TxtEmail"}
    Private Sub BuscarEmpleado(ByVal argTextoBuscado As String)

        Try
            Dim le As List(Of Empleado) = mAdminEmpleados.ListarEmpleados(argTextoBuscado)
            Dim e As Empleado = Nothing

            If le Is Nothing Then
                MsgBox("Empleado no Encontrado", vbInformation, "SiCoFa")
                Me.TxtNombre.Text = ""
                Me.TxtNombre.Select()
                Exit Sub
            End If

            Select Case le.Count
                Case 0
                    MsgBox("Empleado no Encontrado", vbInformation, "SiCoFa")
                    Me.TxtNombre.Text = ""
                    Me.TxtNombre.Select()
                    Exit Sub

                Case 1
                    e = le.First

                Case > 1
                    Using f As New FrmBuscaPersonas
                        f.Personas = le
                        f.ShowDialog()
                        If f.DialogResult = DialogResult.OK Then
                            Dim p As Persona = f.PersonaSeleccionado
                            e = New Empleado(p.Id, p.Nombre, p.Domicilio, p.Localidad, p.Provincia, p.Telefono, p.Email, p.Documento, p.FechaAlta, p.Estado)
                        End If
                        f.Close()
                    End Using
            End Select

            With Me
                .LimpiarFormulario()
                .MostrarEmpleado(e)
                .TxtNombre.Select()
                .TxtNombre.SelectAll()
            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Private Sub MostrarEmpleado(ByVal argEmpleado As Empleado)

        Try
            With Me
                .TxtId.Text = argEmpleado.Id
                .TxtNombre.Text = argEmpleado.Nombre
                .TxtDomicilio.Text = argEmpleado.Domicilio
                .TxtLocalidad.Text = argEmpleado.Localidad
                .UcProvincia.Descripcion = argEmpleado.Provincia
                .TxtTelefono.Text = argEmpleado.Telefono
                .TxtEmail.Text = argEmpleado.Email
                .UcTipoDoc.Id = argEmpleado.Documento.TipoDoc.CodiTD
                .TxtNumDoc.Text = argEmpleado.Documento.Numero
                .TxtFechaAlta.Text = argEmpleado.FechaAlta
                .UcEstado.Descripcion = argEmpleado.Estado
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
                Dim Id As Integer = mAdminEmpleados.InsertarEmpleado(Me.TxtNombre.Text, Me.TxtDomicilio.Text, Me.TxtLocalidad.Text, Me.UcProvincia.Descripcion, Me.TxtTelefono.Text, Me.TxtEmail.Text, Me.UcTipoDoc.Id, Me.TxtNumDoc.Text)
                If Id > 0 Then
                    Me.TxtId.Text = Id
                    Me.TxtNombre.Text = UCase(Me.TxtNombre.Text)
                    MsgBox("Se dio de alta el Empleado " & TxtNombre.Text, vbInformation, "SiCoFa")
                Else
                    MsgBox("Ocurrio un error, intente nuevamente", vbCritical, "SiCoFa")
                    Exit Sub
                End If
                Me.NuevaPersona = False
                Me.Nuevo.Checked = False
            Else
                If Me.TxtId.Text = "" Then
                    MsgBox("El Empleado " & Me.TxtNombre.Text & " no fue dado de Alta", vbInformation, "SiCoFa")
                    Exit Sub
                End If

                Dim Actualizado As Boolean = mAdminEmpleados.ActualizarEmpleado(Me.TxtId.Text, Me.TxtDomicilio.Text, Me.TxtLocalidad.Text, Me.UcProvincia.Descripcion, Me.TxtTelefono.Text, Me.TxtEmail.Text, Me.UcTipoDoc.Id, Me.TxtNumDoc.Text, Me.UcEstado.Descripcion)

                If Actualizado = True Then
                    MsgBox("El Empleado " & TxtNombre.Text & " se acutalizo correctamente", vbInformation, "SiCoFa")
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
                .Add("TxtFechaAlta", Date.Today.ToShortDateString)
                .Add("UcEstado", "A")
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

            Me.BuscarEmpleado(Me.TextoBuscar)

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

            Me.BuscarEmpleado(Me.TxtNombre.Text)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

End Class