Imports SiCoFa.Entidades

Public Class UcHeaderReceta
    Private Sub UcHeaderReceta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.BackColor = Color.Khaki
        Me.TableLayoutPanel1.BackColor = Color.Khaki

    End Sub

    Public Sub Bind(ByVal argReceta As Receta)

        lblPlanReceta.Text = argReceta.Plan.Descripcion
        lblImporteTotalReceta.Text = argReceta.ImporteTotal.ToString("$ #,##0.00")
        lblImporteObraSocial.Text = argReceta.ImporteOS.ToString("$ #,##0.00")
        lblImporteCoseguro.Text = argReceta.ImporteCS.ToString("$ #,##0.00")
        lblImporteBeneficiario.Text = argReceta.ImporteAf.ToString("$ #,##0.00")

    End Sub

End Class
