Imports System.ComponentModel
Imports SiCoFa.Negocio

Public Class FrmEdicionPersonas
    Property TextoBuscar As String
    Property NuevaPersona As Boolean

    Public mobj_N_AdminSiCoFa As New cls_N_AdminSiCoFa
    Private Sub ObtenerProvincias()
        Try
            With Me.Provincia
                .DataSource = mobj_N_AdminSiCoFa.Provincias
                .ValueMember = "PROVINCIA"
                .DisplayMember = "PROVINCIA"
                .SelectedIndex = -1
            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
        End Try

    End Sub
    Private Sub ObtenerTiposDocumento()

        Try
            With Me.TipoDoc
                .DataSource = mobj_N_AdminSiCoFa.TiposDocumento
                .ValueMember = "CodiTDoc"
                .DisplayMember = "TipoDocumento"
                .SelectedIndex = -1
            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Private Sub FrmEdicionPersonas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ObtenerTiposDocumento()
    End Sub
    Public Overridable Sub Guardar_Click(sender As Object, e As EventArgs) Handles Guardar.Click

    End Sub
    Public Overridable Sub Nuevo_Click(sender As Object, e As EventArgs) Handles Nuevo.Click
        Me.LimpiarFormulario()
        Me.NuevaPersona = True
        Me.Nombre.Select()
        Me.Nuevo.Checked = True
    End Sub
    Public Overridable Sub Buscar_Click(sender As Object, e As EventArgs) Handles Buscar.Click
        If NuevaPersona = True Then
            Exit Sub
        End If

        Dim str = InputBox("Ingrese la Persona", "SiCoFa")
        Me.TextoBuscar = ""
        If str = "" Then
            Me.Nombre.Select()
            Exit Sub
        Else
            Me.TextoBuscar = str
        End If

    End Sub
    Private Sub Limpiar_Click(sender As Object, e As EventArgs) Handles Limpiar.Click
        Me.LimpiarFormulario()
        Me.NuevaPersona = False
        Me.Nombre.Select()
        Me.Nuevo.Checked = False
    End Sub
    Public Overridable Sub Nombre_Validating(sender As Object, e As CancelEventArgs) Handles Nombre.Validating

    End Sub

End Class