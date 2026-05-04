Imports SiCoFa.Negocio
Public Class FrmActualizaciones
    Private mAdminDB As New N_AdminDB
    Private Function VerificarCliente() As Boolean

        Dim UsFTP As String = mAdminDB.ObtenerValor("SELECT Id FROM parametros_actualizacion")
        Dim Estado As String = mAdminDB.ObtenerValor("SELECT EstadoContrato FROM TblContratos", "CONTRATOS")
        Stop
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.VerificarCliente()
    End Sub
End Class