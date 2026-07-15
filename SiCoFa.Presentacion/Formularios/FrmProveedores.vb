
Imports SiCoFa.Negocio
Imports System.ComponentModel
Imports SiCoFa.Entidades
Public Class FrmProveedores

    Private mAdminProveedores As New N_AdminProveedores
    Private ControlesReadOnly As New List(Of String) From {"TxtId", "TxtFechaAlta"}
    Private DatosOpcionales As New List(Of String) From {"TxtId", "TxtDomicilio", "TxtLocalidad", "UcProvincia", "TxtTelefono", "TxtEmail"}

    Private Sub BuscarProveedor(ByVal argTextoBuscado As String)

        Try

            Dim lp As List(Of Proveedor) = mAdminProveedores.ListarProveedores(argTextoBuscado)
            Dim pv As Proveedor = Nothing

            If lp Is Nothing Then
                MsgBox("Proveedor no Encontrado", vbInformation, "SiCoFa")
                Me.TxtNombre.Text = ""
                Me.TxtNombre.Select()
                Exit Sub
            End If

            Select Case lp.Count
                Case 0
                    MsgBox("Proveedor no Encontrado", vbInformation, "SiCoFa")
                    Me.TxtNombre.Text = ""
                    Me.TxtNombre.Select()
                    Exit Sub
                Case 1
                    pv = lp.First
                Case > 1
                    Using f As New FrmBuscaPersonas
                        f.Personas = lp
                        f.ShowDialog()
                        If f.DialogResult = DialogResult.OK Then
                            Dim p As Persona = f.PersonaSeleccionado
                            pv = New Proveedor(p.Id, p.Nombre, p.Domicilio, p.Localidad, p.Provincia, p.Telefono, p.Email, p.Documento, p.FechaAlta, p.Estado)
                        End If
                        f.Close()
                    End Using
            End Select

            With Me
                .LimpiarFormulario()
                .MostrarProveedor(pv)
                .TxtNombre.Select()
                .TxtNombre.SelectAll()
            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Private Sub MostrarProveedor(ByVal argProveedor As Proveedor)

        Try
            With Me
                .TxtId.Text = argProveedor.Id
                .TxtNombre.Text = argProveedor.Nombre
                .TxtDomicilio.Text = argProveedor.Domicilio
                .TxtLocalidad.Text = argProveedor.Localidad
                .UcProvincia.Descripcion = argProveedor.Provincia
                .TxtTelefono.Text = argProveedor.Telefono
                .TxtEmail.Text = argProveedor.Email
                .UcTipoDoc.Id = argProveedor.Documento.TipoDoc.CodiTD
                .TxtNumDoc.Text = argProveedor.Documento.Numero
                .TxtFechaAlta.Text = argProveedor.FechaAlta
                .UcEstado.Descripcion = argProveedor.Estado
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
                Dim Id As Integer = mAdminProveedores.InsertarProveedor(Me.TxtNombre.Text, Me.TxtDomicilio.Text, Me.TxtLocalidad.Text, Me.UcProvincia.Descripcion, Me.TxtTelefono.Text, Me.TxtEmail.Text, Me.UcTipoDoc.Id, Me.TxtNumDoc.Text)
                If Id > 0 Then
                    Me.TxtId.Text = Id
                    Me.TxtNombre.Text = UCase(Me.TxtNombre.Text)
                    MsgBox("Se dio de alta el Proveedor " & TxtNombre.Text, vbInformation, "SiCoFa")
                Else
                    MsgBox("Ocurrio un error, intente nuevamente", vbCritical, "SiCoFa")
                    Exit Sub
                End If
                Me.NuevaPersona = False
                Me.Nuevo.Checked = False
            Else
                If Me.TxtId.Text = "" Then
                    MsgBox("El Proveedor " & Me.TxtNombre.Text & " no fue dado de Alta", vbInformation, "SiCoFa")
                    Exit Sub
                End If

                Dim Actualizado As Boolean = mAdminProveedores.ActualizarProveedor(Me.TxtId.Text, Me.TxtDomicilio.Text, Me.TxtLocalidad.Text, Me.UcProvincia.Descripcion, Me.TxtTelefono.Text, Me.TxtEmail.Text, Me.UcTipoDoc.Id, Me.TxtNumDoc.Text, "", Me.UcEstado.Descripcion)

                If Actualizado = True Then
                    MsgBox("El Proveedor " & TxtNombre.Text & " se acutalizo correctamente", vbInformation, "SiCoFa")
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

            Me.BuscarProveedor(Me.TextoBuscar)

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

            Me.BuscarProveedor(Me.TxtNombre.Text)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
End Class