Imports SiCoFa.Negocio
Public Class FrmResultadosMensuales

    Private strResultadosMensuales As String = "SELECT * FROM vw_resultados_mensuales"

    Private dTable As DataTable

    Private mobjAdminDB As New N_AdminDB

    Private Sub AjustarAnchoColumnasResultadosMensuales()

        Try

            If DataGridView1.ColumnCount = 8 Then
                Dim totalAncho As Integer = DataGridView1.Width - 41
                Dim proporciones As Double() = {0.1R, 0.1R, 0.131R, 0.131R, 0.131R, 0.131R, 0.131R, 0.131R}

                For i As Integer = 0 To 7
                    DataGridView1.Columns(i).Width = CInt(totalAncho * proporciones(i))
                Next

            Else
                MessageBox.Show("El DataGridView1 no tiene 8 columnas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub FrmResultadosMensuales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Me.AjustarAnchoColumnasResultadosMensuales()
            dTable = mobjAdminDB.ObtenerTabla(Me.strResultadosMensuales)

            If dTable IsNot Nothing Then
                Me.DataGridView1.DataSource = dTable
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbInformation, "SiCoFa")
        End Try

    End Sub

End Class