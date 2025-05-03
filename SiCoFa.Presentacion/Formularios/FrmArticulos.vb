Imports SiCoFa.Negocio
Public Class FrmArticulos
    Property TextoBuscar As String
    Property NuevoArticulo As Boolean

    Private mobj_N_AdminSiCoFa As New cls_N_AdminSiCoFa
    Private Sub ObtenerAlicuotasIVA()
        With Me.AlicuotaIVA
            .DataSource = mobj_N_AdminSiCoFa.AlicuotasIVA
            .ValueMember = "AlicIVA"
            .DisplayMember = "AlicuotaIVA"
            .SelectedIndex = -1
        End With
    End Sub
    Private Sub ObtenerSecciones()
        With Me.Seccion

        End With

    End Sub
    Private Sub FrmArticulos_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub
End Class