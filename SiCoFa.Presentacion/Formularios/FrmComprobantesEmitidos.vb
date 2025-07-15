Imports SiCoFa.Negocio

Public Class FrmComprobantesEmitidos
    Property SQL As String

    Private mAdminDB As New N_AdminDB

    Private Sub AjustarAnchoColumnasProporcional()
        Try

            If DataGridView1.ColumnCount = 13 Then
                Dim totalAncho As Integer = DataGridView1.Width - 45
                Dim proporciones As Double() = {0.0R, 0.0R, 0.0R, 0.1R, 0.1R, 0.05R, 0.05R, 0.1R, 0.1R, 0.1R, 0.1R, 0.1R, 0.19R}

                For i As Integer = 0 To 12
                    DataGridView1.Columns(i).Width = CInt(totalAncho * proporciones(i))
                Next

            Else
                MessageBox.Show("El DataGridEfectivo no tiene 13 columnas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub FrmCajas_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try

            'Dim sql As String = "SELECT IdOperacion,CodiTC,IdOperAsoc,TipoComprobante,FechaComp,PVenta,NumComp,ImpBto,ImpDes,ImpEf,ImpCC,ImpPE,ComprobanteAsociado FROM ConComprobantes ORDER BY IdOperacion"
            Dim TblComprobantes As DataTable = mAdminDB.ObtenerTabla(Me.SQL)
            Me.DataGridView1.DataSource = TblComprobantes

            Me.StartPosition = FormStartPosition.Manual
            Me.Location = Screen.PrimaryScreen.WorkingArea.Location
            Me.Size = Screen.PrimaryScreen.WorkingArea.Size

            Me.AjustarAnchoColumnasProporcional()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

End Class