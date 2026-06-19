Public Class UcFooterReceta
    Private Sub UcFooterReceta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.BackColor = Color.Khaki
        Me.TableLayoutPanel1.BackColor = Color.Khaki

    End Sub

    Public Sub Bind(ByVal argImporteTotalReceta As Decimal, ByVal argImporteOS As Decimal, ByVal argImporteCS As Decimal, ByVal argImporteBeneficiario As Decimal)

        lblImporteTotalReceta.Text = argImporteTotalReceta.ToString("0.00")
        lblImporteObraSocial.Text = argImporteOS.ToString("0.00")
        lblImporteCoseguro.Text = argImporteCS.ToString("0.00")
        lblImporteBeneficiario.Text = argImporteBeneficiario.ToString("0.00")

    End Sub

End Class
