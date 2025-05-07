Imports System.ComponentModel
Imports SiCoFa.Negocio

Public Class FrmEdicionPersonas
    Property TextoBuscar As String
    Property NuevaPersona As Boolean

    Public mobj_N_AdminSiCoFa As New cls_N_AdminSiCoFa
    Private Sub ObtenerTiposDocumento()
        Me.TipoDoc.DataSource = mobj_N_AdminSiCoFa.TiposDocumento
        Me.TipoDoc.ValueMember = "CodiTDoc"
        Me.TipoDoc.DisplayMember = "TipoDocumento"
        Me.TipoDoc.SelectedIndex = -1
    End Sub
    Private Sub FrmEdicionPersonas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ObtenerTiposDocumento()
    End Sub
    Public Overridable Sub Guardar_Click(sender As Object, e As EventArgs) Handles Guardar.Click

    End Sub
    Public Overridable Sub Nuevo_Click(sender As Object, e As EventArgs) Handles Nuevo.Click
        Me.NuevaPersona = True
        Me.Nombre.Select()
    End Sub
    Public Overridable Sub Buscar_Click(sender As Object, e As EventArgs) Handles Buscar.Click
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
        Me.Nombre.Select()
    End Sub
    Public Overridable Sub Nombre_Validating(sender As Object, e As CancelEventArgs) Handles Nombre.Validating

    End Sub

End Class