Imports SiCoFa.Negocio
Public Class FrmResultadosMensuales

    Private strResultadosMensuales As String = "SELECT * FROM vw_contabilidad_resultados_mensuales"

    Private dTable As DataTable

    Private mobjAdminDB As New N_AdminDB

    Private Sub ActualizarIngresos()
        If DataGridView1.CurrentRow Is Nothing Then Exit Sub

        Dim anio As Integer
        Dim mes As Integer

        ' Intentar convertir los valores directamente
        If Not Integer.TryParse(Convert.ToString(DataGridView1.CurrentRow.Cells("Año").Value), anio) Then Exit Sub
        If Not Integer.TryParse(Convert.ToString(DataGridView1.CurrentRow.Cells("Mes").Value), mes) Then Exit Sub

        Dim desde As New Date(anio, mes, 1)
        ' Primer día del mes siguiente (exclusivo)
        Dim hasta As Date = desde.AddMonths(1)

        Dim sql As String = $"SELECT Fecha,CuentaImputable,Importe FROM vw_contabilidad_ingresos_mensuales WHERE Fecha>='{desde:yyyy-MM-dd}' AND Fecha<'{hasta:yyyy-MM-dd}'"

        Dim dt As DataTable = mobjAdminDB.ObtenerTabla(sql)
        Me.DataGridView2.DataSource = dt

        Me.DataGridView2.ClearSelection()

    End Sub

    Private Sub ActualizarGanancias()
        If DataGridView1.CurrentRow Is Nothing Then Exit Sub

        Dim anio As Integer
        Dim mes As Integer

        ' Intentar convertir los valores directamente
        If Not Integer.TryParse(Convert.ToString(DataGridView1.CurrentRow.Cells("Año").Value), anio) Then Exit Sub
        If Not Integer.TryParse(Convert.ToString(DataGridView1.CurrentRow.Cells("Mes").Value), mes) Then Exit Sub


        Dim sql As String = $"SELECT CuentaImputable,Importe FROM vw_contabilidad_ganancias_mensuales WHERE anio={anio} AND mes={mes}"

        Dim dt As DataTable = mobjAdminDB.ObtenerTabla(sql)
        Me.DataGridView3.DataSource = dt

        Me.DataGridView3.ClearSelection()

    End Sub

    Private Sub ActualizarGastos()
        If DataGridView1.CurrentRow Is Nothing Then Exit Sub

        Dim anio As Integer
        Dim mes As Integer

        ' Intentar convertir los valores directamente
        If Not Integer.TryParse(Convert.ToString(DataGridView1.CurrentRow.Cells("Año").Value), anio) Then Exit Sub
        If Not Integer.TryParse(Convert.ToString(DataGridView1.CurrentRow.Cells("Mes").Value), mes) Then Exit Sub


        Dim sql As String = $"SELECT CuentaImputable,Importe FROM vw_contabilidad_gastos_mensuales WHERE anio={anio} AND mes={mes}"

        Dim dt As DataTable = mobjAdminDB.ObtenerTabla(sql)
        Me.DataGridView4.DataSource = dt

        Me.DataGridView4.ClearSelection()

    End Sub

    Private Sub ActualizarPerdidas()
        If DataGridView1.CurrentRow Is Nothing Then Exit Sub

        Dim anio As Integer
        Dim mes As Integer

        ' Intentar convertir los valores directamente
        If Not Integer.TryParse(Convert.ToString(DataGridView1.CurrentRow.Cells("Año").Value), anio) Then Exit Sub
        If Not Integer.TryParse(Convert.ToString(DataGridView1.CurrentRow.Cells("Mes").Value), mes) Then Exit Sub


        Dim sql As String = $"SELECT CuentaImputable,Importe FROM vw_contabilidad_perdidas_mensuales WHERE anio={anio} AND mes={mes}"

        Dim dt As DataTable = mobjAdminDB.ObtenerTabla(sql)
        Me.DataGridView5.DataSource = dt

        Me.DataGridView5.ClearSelection()

    End Sub

    Private Sub AjustarAnchoColumnasResultadosMensuales()

        Try

            If DataGridView1.ColumnCount = 8 Then
                Dim totalAncho As Integer = DataGridView1.Width - 41
                Dim proporciones As Double() = {0.08R, 0.055R, 0.2R, 0.142R, 0.2R, 0.142R, 0.15R, 0.1R}

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

    Private Sub AjustarAnchoColumnasIngresos()

        Try

            If DataGridView2.ColumnCount = 3 Then
                Dim totalAncho As Integer = DataGridView1.Width
                Dim proporciones As Double() = {0.14R, 0.32R, 0.2R}

                For i As Integer = 0 To 2
                    DataGridView2.Columns(i).Width = CInt(totalAncho * proporciones(i))
                Next

            Else
                MessageBox.Show("El DataGridView1 no tiene 3 columnas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub AjustarAnchoColumnasGanancias()

        Try

            If DataGridView3.ColumnCount = 2 Then
                Dim totalAncho As Integer = DataGridView1.Width
                Dim proporciones As Double() = {0.395R, 0.15R}

                For i As Integer = 0 To 1
                    DataGridView3.Columns(i).Width = CInt(totalAncho * proporciones(i))
                Next

            Else
                MessageBox.Show("El DataGridView3 no tiene 2 columnas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub AjustarAnchoColumnasGastos()

        Try

            If DataGridView4.ColumnCount = 2 Then
                Dim totalAncho As Integer = DataGridView1.Width
                Dim proporciones As Double() = {0.395R, 0.15R}

                For i As Integer = 0 To 1
                    DataGridView4.Columns(i).Width = CInt(totalAncho * proporciones(i))
                Next

            Else
                MessageBox.Show("El DataGridView4 no tiene 2 columnas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub AjustarAnchoColumnasPerdidas()

        Try

            If DataGridView5.ColumnCount = 2 Then
                Dim totalAncho As Integer = DataGridView1.Width
                Dim proporciones As Double() = {0.395R, 0.15R}

                For i As Integer = 0 To 1
                    DataGridView5.Columns(i).Width = CInt(totalAncho * proporciones(i))
                Next

            Else
                MessageBox.Show("El DataGridView4 no tiene 2 columnas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub FrmResultadosMensuales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Me.AjustarAnchoColumnasResultadosMensuales()
            Me.AjustarAnchoColumnasIngresos()
            Me.AjustarAnchoColumnasGanancias()
            Me.AjustarAnchoColumnasGastos()
            Me.AjustarAnchoColumnasPerdidas()

            dTable = mobjAdminDB.ObtenerTabla(Me.strResultadosMensuales)

            If dTable IsNot Nothing Then
                Me.DataGridView1.DataSource = dTable
            End If

            Me.ActualizarIngresos()
            Me.ActualizarGastos()

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

            Me.ActualizarIngresos()
            Me.ActualizarGastos()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub


End Class