Imports SiCoFa.Negocio
Imports System.ComponentModel
Imports SiCoFa.Entidades
Public Class FrmProveedores

    Private mAdminProveedores As New N_AdminProveedores
    Private ControlesReadOnly As New List(Of String) From {"Id", "FechaAlta"}
    Private DatosOpcionales As New List(Of String) From {"Id", "Domicilio", "Localidad", "Provincia", "Telefono", "Email"}
    Private Sub BuscarProveedor(ByVal argTextoBuscado As String)

        Try

            Dim lp As List(Of Proveedor) = mAdminProveedores.ListarProveedores(argTextoBuscado)
            Dim pv As Proveedor = Nothing

            If lp Is Nothing Then
                MsgBox("Proveedor no Encontrado", vbInformation, "SiCoFa")
                Me.Nombre.Text = ""
                Me.Nombre.Select()
                Exit Sub
            End If

            Select Case lp.Count
                Case 0
                    MsgBox("Proveedor no Encontrado", vbInformation, "SiCoFa")
                    Me.Nombre.Text = ""
                    Me.Nombre.Select()
                    Exit Sub
                Case 1
                    pv = lp.First
                Case > 1
                    Using f As New FrmBuscaPersonas
                        f.Personas = lp
                        f.ShowDialog()
                        If f.DialogResult = DialogResult.OK Then
                            Dim p As Persona = f.PersonaSeleccionado
                            pv = New Proveedor(p.Id, p.Nombre, p.Domicilio, p.Localidad, p.Provincia, p.Telefono, p.Email, p.Documento.TipoDoc.CodiTDoc, p.Documento.Numero, p.FechaAlta, p.Estado)
                        End If
                        f.Close()
                    End Using
            End Select

            With Me
                .LimpiarFormulario()
                .MostrarProveedor(pv)
                .Nombre.Select()
                .Nombre.SelectAll()
            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Private Sub MostrarProveedor(ByVal argProveedor As Proveedor)

        Try
            With Me
                .Id.Text = argProveedor.Id
                .Nombre.Text = argProveedor.Nombre
                .Domicilio.Text = argProveedor.Domicilio
                .Localidad.Text = argProveedor.Localidad
                .Provincia.Text = argProveedor.Provincia
                .Telefono.Text = argProveedor.Telefono
                .Email.Text = argProveedor.Email
                .TipoDoc.Text = argProveedor.Documento.TipoDoc.TipoDocumento
                .NumDoc.Text = argProveedor.Documento.Numero
                .FechaAlta.Text = argProveedor.FechaAlta
                .Estado.Text = argProveedor.Estado
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
                Dim Id As Integer = mAdminProveedores.InsertarProveedor(Me.Nombre.Text, Me.Domicilio.Text, Me.Localidad.Text, Me.Provincia.Text, Me.Telefono.Text, Me.Email.Text, Me.TipoDoc.SelectedValue, Me.NumDoc.Text)
                If Id > 0 Then
                    Me.Id.Text = Id
                    Me.Nombre.Text = UCase(Me.Nombre.Text)
                    MsgBox("Se dio de alta el Proveedor " & Nombre.Text, vbInformation, "SiCoFa")
                Else
                    MsgBox("Ocurrio un error, intente nuevamente", vbCritical, "SiCoFa")
                    Exit Sub
                End If
                Me.NuevaPersona = False
                Me.Nuevo.Checked = False
            Else
                If Me.Id.Text = "" Then
                    MsgBox("El Proveedor " & Me.Nombre.Text & " no fue dado de Alta", vbInformation, "SiCoFa")
                    Exit Sub
                End If

                Dim Actualizado As Boolean = mAdminProveedores.ActualizarProveedor(Me.Id.Text, Me.Domicilio.Text, Me.Localidad.Text, Me.Provincia.Text, Me.Telefono.Text, Me.Email.Text, Me.TipoDoc.SelectedValue, Me.NumDoc.Text, "", Me.Estado.SelectedValue)

                If Actualizado = True Then
                    MsgBox("El Proveedor " & Nombre.Text & " se acutalizo correctamente", vbInformation, "SiCoFa")
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

            Me.BuscarProveedor(Me.TextoBuscar)

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

            Me.BuscarProveedor(Me.Nombre.Text)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
End Class