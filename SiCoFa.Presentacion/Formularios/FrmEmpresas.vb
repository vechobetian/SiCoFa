Imports SiCoFa.Negocio
Imports System.ComponentModel
Imports SiCoFa.Entidades
Public Class FrmEmpresas

    Private mAdminEmpresas As New N_AdminEmpresas
    Private ControlesReadOnly As New List(Of String) From {"Id", "TipoDoc"}
    Private Sub ObtenerTiposIVA()

        Try
            Me.IVA.DataSource = TipoIVA.Lista
            Me.IVA.ValueMember = "CodIVA"
            Me.IVA.DisplayMember = "TipoIVA"
            Me.IVA.SelectedIndex = -1

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Private Function SeleccionarEmpresaListado(ByVal Id As Int32, ByVal ListaEmpresas As List(Of Empresa)) As Empresa
        Try
            Dim EmpresaSeleccionada As Empresa = Nothing

            For Each e As Empresa In ListaEmpresas
                If e.Id = Id Then
                    EmpresaSeleccionada = e
                    Exit For ' Opcional: detener la búsqueda una vez encontrado el cliente
                End If
            Next
            Return EmpresaSeleccionada

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
            Return Nothing

        End Try

    End Function
    Private Sub BuscarEmpresa(ByVal argTextoBuscado As String)

        Try
            Dim le As List(Of Empresa) = mAdminEmpresas.ListarEmpresas(argTextoBuscado)
            Dim e As Empresa = Nothing

            If le Is Nothing Then
                MsgBox("Empresa no Encontrada", vbInformation, "SiCoFa")
                Me.TxtNombre.Text = ""
                Me.TxtNombre.Select()
                Exit Sub
            End If

            Select Case le.Count
                Case 0
                    MsgBox("Empresa no Encontrada", vbInformation, "SiCoFa")
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
                            e = Me.SeleccionarEmpresaListado(p.Id, le)
                        End If
                        f.Close()
                    End Using
            End Select

            With Me
                .LimpiarFormulario()
                .MostrarEmpresa(e)
                .TxtNombre.Select()
                .TxtNombre.SelectAll()
            End With
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Private Sub MostrarEmpresa(ByVal argEmpresa As Empresa)

        Try
            With Me
                .TxtId.Text = argEmpresa.Id
                .TxtNombre.Text = argEmpresa.Nombre
                .TxtDomicilio.Text = argEmpresa.Domicilio
                .TxtLocalidad.Text = argEmpresa.Localidad
                .UcProvincia.Descripcion = argEmpresa.Provincia
                .TxtTelefono.Text = argEmpresa.Telefono
                .TxtEmail.Text = argEmpresa.Email
                .UcTipoDoc.Text = argEmpresa.Documento.TipoDocumento.CodiTD
                .TxtNumDoc.Text = argEmpresa.Documento.Numero
                .TxtFechaAlta.Text = argEmpresa.FechaAlta
                .UcEstado.Descripcion = argEmpresa.Estado
                .IVA.Text = argEmpresa.IVA.Descripcion
                .IB.Text = argEmpresa.IB
            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Public Overrides Sub Guardar_Click(sender As Object, e As EventArgs)

        Try
            Me.ValidarCampos(Me, ControlesReadOnly)

            If Me.ValidacionOK = False Then
                Exit Sub
            End If

            If Me.NuevaPersona = True Then
                Dim Id As Integer = mAdminEmpresas.InsertarEmpresa(Me.TxtNombre.Text, Me.TxtDomicilio.Text, Me.TxtLocalidad.Text, Me.UcProvincia.Descripcion, Me.TxtTelefono.Text, Me.TxtEmail.Text, Me.TxtNumDoc.Text, Me.TxtFechaAlta.Text, Me.IVA.SelectedValue, Me.IB.Text)
                If Id > 0 Then
                    Me.TxtId.Text = Id
                    Me.TxtNombre.Text = UCase(Me.TxtNombre.Text)
                    MsgBox("Se dio de alta la Empresa " & TxtNombre.Text,, "SiCoFa")
                Else
                    MsgBox("Ocurrio un error, intente nuevamente",, "SiCoFa")
                    Exit Sub
                End If
                Me.NuevaPersona = False
                Me.Nuevo.Checked = False
            Else
                If Me.TxtId.Text = "" Then
                    MsgBox("La Empresa " & Me.TxtNombre.Text & " no fue dada de Alta", vbInformation, "SiCoFa")
                    Exit Sub
                End If

                Dim Actualizado As Boolean = mAdminEmpresas.ActualizarEmpresa(Me.TxtId.Text, Me.TxtDomicilio.Text, Me.TxtLocalidad.Text, Me.UcProvincia.Descripcion, Me.TxtTelefono.Text, Me.TxtEmail.Text, Me.TxtNumDoc.Text, Me.TxtFechaAlta.Text, Me.IVA.SelectedValue, Me.UcEstado.Descripcion, Me.IB.Text)

                If Actualizado = True Then
                    MsgBox("La Empresa " & TxtNombre.Text & " se acutalizo correctamente",, "SiCoFa")
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
                .Add("TipoDoc", "80")
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

            Me.BuscarEmpresa(Me.TextoBuscar)

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

            Me.BuscarEmpresa(Me.TxtNombre.Text)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Private Sub FrmEmpresas_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.EstablecerReadOnly(Me, Me.ControlesReadOnly)
        Me.ObtenerTiposIVA()
    End Sub
End Class