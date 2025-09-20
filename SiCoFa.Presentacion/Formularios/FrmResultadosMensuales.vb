Imports SiCoFa.Negocio
Public Class FrmResultadosMensuales

    Private strResultadosMensuales As String = "SELECT * FROM vw_resultados_mensuales"

    Private dTable As DataTable

    Private mobjAdminDB As New N_AdminDB

    Private Sub ActualizarVentas()
        If DataGridView1.CurrentRow Is Nothing Then Exit Sub

        Dim anio As Integer
        Dim mes As Integer

        ' Intentar convertir los valores directamente
        If Not Integer.TryParse(Convert.ToString(DataGridView1.CurrentRow.Cells("Año").Value), anio) Then Exit Sub
        If Not Integer.TryParse(Convert.ToString(DataGridView1.CurrentRow.Cells("Mes").Value), mes) Then Exit Sub

        Dim desde As New Date(anio, mes, 1)
        ' Primer día del mes siguiente (exclusivo)
        Dim hasta As Date = desde.AddMonths(1)

        Dim sql As String = $"SELECT * FROM vw_reporte_ventas WHERE Fecha>='{desde:yyyy-MM-dd}' AND Fecha<'{hasta:yyyy-MM-dd}'"

        Dim dt As DataTable = mobjAdminDB.ObtenerTabla(sql)
        Me.DataGridView2.DataSource = dt

        Me.DataGridView2.ClearSelection()

    End Sub

    Private Sub AjustarAnchoColumnasResultadosMensuales()

        Try

            If DataGridView1.ColumnCount = 8 Then
                Dim totalAncho As Integer = DataGridView1.Width - 41
                Dim proporciones As Double() = {0.08R, 0.05R, 0.19R, 0.13R, 0.16R, 0.13R, 0.15R, 0.1R}

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

    Private Sub AjustarAnchoColumnasVentas()
        Try
            If DataGridView2.ColumnCount = 9 Then
                Dim totalAncho As Integer = DataGridView2.Width - 42
                Dim proporciones As Double() = {0.1R, 0.07R, 0.09R, 0.13R, 0.08R, 0.13R, 0.13R, 0.13R, 0.13R}
                For i As Integer = 0 To 8
                    DataGridView2.Columns(i).Width = CInt(totalAncho * proporciones(i))
                Next
            Else
                MessageBox.Show("El DataGridView2 no tiene 9 columnas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
        End Try
    End Sub

    Private Sub FrmResultadosMensuales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Me.AjustarAnchoColumnasResultadosMensuales()
            Me.AjustarAnchoColumnasVentas()

            dTable = mobjAdminDB.ObtenerTabla(Me.strResultadosMensuales)

            If dTable IsNot Nothing Then
                Me.DataGridView1.DataSource = dTable
            End If

            Me.ActualizarVentas()

        Catch ex As Exception
            MsgBox(ex.Message, vbInformation, "SiCoFa")
        End Try

    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged

        Try
            If Me.DataGridView1.CurrentRow Is Nothing Then
                Me.DataGridView1.DataSource = Nothing
                Exit Sub
            End If

            Me.ActualizarVentas()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub


End Class