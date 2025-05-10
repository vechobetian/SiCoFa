Imports System.ComponentModel
Imports SiCoFa.Entidades
Public Class FrmEmpleados

    Private ControlesReadOnly As New List(Of String) From {"Id", "FechaAlta"}
    Private DatosOpcionales As New List(Of String) From {"Id", "Domicilio", "Localidad", "Provincia", "Telefono", "Email"}
    Private Function BuscarEmpleado(ByVal argTextoBuscado As String) As Empleado

        Try
            Dim le As List(Of Empleado) = mobj_N_AdminSiCoFa.ListarEmpleados(argTextoBuscado)
            Dim e As Empleado = Nothing

            If le Is Nothing Then
                MsgBox("Empleado no Encontrado", vbInformation, "SiCoFa")
                Return Nothing
                Exit Function
            End If

            Select Case le.Count
                Case 0
                    MsgBox("Empleado no Encontrado", vbInformation, "SiCoFa")
                    Return Nothing
                    Exit Function
                Case 1
                    e = le.First
                Case > 1
                    FrmBuscaPersonas.Personas = le
                    FrmBuscaPersonas.ShowDialog()

                    If FrmBuscaPersonas.PersonaSeleccionado IsNot Nothing Then
                        Dim p As Persona = FrmBuscaPersonas.PersonaSeleccionado
                        e = New Empleado(p.Id, p.Nombre, p.Domicilio, p.Localidad, p.Provincia, p.Telefono, p.Email, p.Documento.TipoDoc.CodiTDoc, p.Documento.Numero, p.FechaAlta, p.Estado)
                    End If
                    FrmBuscaPersonas.Close()
            End Select

            Return e
            e = Nothing

            With Me
                .LimpiarFormulario()
                .MostrarEmpleado(e)
                .Nombre.Select()
                .Nombre.SelectAll()
            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Function
    Private Sub MostrarEmpleado(ByVal argEmpleado As Empleado)

        Try
            With Me
                .Id.Text = argEmpleado.Id
                .Nombre.Text = argEmpleado.Nombre
                .Domicilio.Text = argEmpleado.Domicilio
                .Localidad.Text = argEmpleado.Localidad
                .Provincia.Text = argEmpleado.Provincia
                .Telefono.Text = argEmpleado.Telefono
                .Email.Text = argEmpleado.Email
                .TipoDoc.Text = argEmpleado.Documento.TipoDoc.TipoDocumento
                .NumDoc.Text = argEmpleado.Documento.Numero
                .FechaAlta.Text = argEmpleado.FechaAlta
                .Estado.Text = argEmpleado.Estado
            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Public Overrides Sub Guardar_Click(sender As Object, e As EventArgs)

        Try
            Me.ValidarCampos(DatosOpcionales)

            If Me.ValidacionOK = False Then
                Exit Sub
            End If

            If Me.NuevaPersona = True Then
                Dim Id As Integer = mobj_N_AdminSiCoFa.InsertarEmpleado(Me.Nombre.Text, Me.Domicilio.Text, Me.Localidad.Text, Me.Provincia.Text, Me.Telefono.Text, Me.Email.Text, Me.TipoDoc.SelectedValue, Me.NumDoc.Text)
                If Id > 0 Then
                    Me.Id.Text = Id
                    Me.Nombre.Text = UCase(Me.Nombre.Text)
                    MsgBox("Se dio de alta el Empleado " & Nombre.Text, vbInformation, "SiCoFa")
                Else
                    MsgBox("Ocurrio un error, intente nuevamente", vbCritical, "SiCoFa")
                    Exit Sub
                End If
                Me.NuevaPersona = False
            Else
                If Me.Id.Text = "" Then
                    MsgBox("El Empleado " & Me.Nombre.Text & " no fue dado de Alta", vbInformation, "SiCoFa")
                    Exit Sub
                End If

                Dim Actualizado As Boolean = mobj_N_AdminSiCoFa.ActualizarEmpleado(Me.Id.Text, Me.Domicilio.Text, Me.Localidad.Text, Me.Provincia.Text, Me.Telefono.Text, Me.Email.Text, Me.TipoDoc.SelectedValue, Me.NumDoc.Text, Me.Estado.Text)

                If Actualizado = True Then
                    MsgBox("El Empleado " & Nombre.Text & " se acutalizo correctamente", vbInformation, "SiCoFa")
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

            Dim emp As Empleado = BuscarEmpleado(Me.TextoBuscar)

            If emp Is Nothing Then
                Exit Sub
            End If

            With Me
                .LimpiarFormulario()
                .MostrarEmpleado(emp)
                .Nombre.Select()
            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Public Overrides Sub Nombre_Validating(sender As Object, e As CancelEventArgs)

        Try
            MyBase.Nombre_Validating(sender, e)

            If Me.Nombre.Text = "" Or Me.NuevaPersona = True Or Me.Id.Text > 0 Then
                Exit Sub
            End If

            Dim emp As Empleado = Me.BuscarEmpleado(Me.Nombre.Text)

            If emp Is Nothing Then
                Me.Nombre.Select()
                Me.Nombre.Text = ""
                Exit Sub
            End If

            With Me
                .LimpiarFormulario()
                .MostrarEmpleado(emp)
                .Nombre.Select()
                .Nombre.SelectAll()
            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

End Class