Imports System.ComponentModel
Imports SiCoFa.Negocio

Public Class FrmEdicionPersonas
    Property TextoBuscar As String
    Property NuevaPersona As Boolean
    Property ValidacionOK As Boolean

    Public mobj_N_AdminSiCoFa As New cls_N_AdminSiCoFa
    Private Sub ObtenerTiposDocumento()
        Me.TipoDoc.DataSource = mobj_N_AdminSiCoFa.TiposDocumento
        Me.TipoDoc.ValueMember = "CodiTDoc"
        Me.TipoDoc.DisplayMember = "TipoDocumento"
        Me.TipoDoc.SelectedIndex = -1
    End Sub
    Private Sub ObtenerTiposIVA()
        Me.IVA.DataSource = mobj_N_AdminSiCoFa.TiposIVA
        Me.IVA.ValueMember = "CodIVA"
        Me.IVA.DisplayMember = "TipoIVA"
        Me.IVA.SelectedIndex = -1
    End Sub
    Private Sub ValidarCampos()
        Me.ValidacionOK = False

        For Each control As Control In Me.Controls
            If TypeOf control Is TextBox Then
                If String.IsNullOrWhiteSpace(control.Text) And control.Name <> "Id" Then
                    MsgBox(control.Name & " es un dato requerido", vbCritical, "SiCoFa")
                    control.Focus()
                    Me.ValidacionOK = False
                    Exit Sub
                End If
            End If
        Next

        Me.ValidacionOK = True

    End Sub
    Private Sub FrmEdicionPersonas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ObtenerTiposDocumento()
        Me.ObtenerTiposIVA()
    End Sub
    Public Overridable Sub Guardar_Click(sender As Object, e As EventArgs) Handles Guardar.Click
        Me.ValidarCampos()

    End Sub
    Private Sub Nuevo_Click(sender As Object, e As EventArgs) Handles Nuevo.Click
        Me.NuevaPersona = True
        Me.Nombre.Select()
    End Sub
    Public Overridable Sub Buscar_Click(sender As Object, e As EventArgs) Handles Buscar.Click
        Dim str = InputBox("Ingrese el Cliente", "SiCoFa")
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