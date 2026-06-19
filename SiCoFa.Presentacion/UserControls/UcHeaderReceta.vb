
Public Class UcHeaderReceta
    Private Sub UcHeaderReceta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.BackColor = Color.Khaki

    End Sub

    Public Sub Bind(receta As String)

        lblPlanReceta.Text = receta

    End Sub

End Class
