Imports SiCoFa.Negocio

Public Class FrmCajas1

    Private mAdminDB As New N_AdminDB

    Private Sub AjustarAnchoColumnasProporcional()
        Try

            If DataGridView2.ColumnCount = 3 Then
                Dim totalAncho As Integer = DataGridView2.Width - 45
                Dim proporciones As Double() = {0.7R, 0.1R, 0.2R}

                For i As Integer = 0 To 2 ' Itera a través de las 9 columnas
                    DataGridView2.Columns(i).Width = CInt(totalAncho * proporciones(i))
                Next
                Me.DataGridView2.Columns("ImporteEf").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                Me.DataGridView2.Columns("CantOperacionesEf").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            Else
                MessageBox.Show("El DataGridView no tiene 3 columnas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            If DataGridView3.ColumnCount = 3 Then
                Dim totalAncho As Integer = DataGridView3.Width - 45
                Dim proporciones As Double() = {0.7R, 0.1R, 0.2R}

                For i As Integer = 0 To 2 ' Itera a través de las 9 columnas
                    DataGridView3.Columns(i).Width = CInt(totalAncho * proporciones(i))
                Next
                Me.DataGridView3.Columns("ImportePE").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                Me.DataGridView3.Columns("CantOperacionesPE").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            Else
                MessageBox.Show("El DataGridView no tiene 3 columnas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            If DataGridView4.ColumnCount = 3 Then
                Dim totalAncho As Integer = DataGridView4.Width - 45
                Dim proporciones As Double() = {0.7R, 0.1R, 0.2R}

                For i As Integer = 0 To 2 ' Itera a través de las 9 columnas
                    DataGridView4.Columns(i).Width = CInt(totalAncho * proporciones(i))
                Next
                Me.DataGridView4.Columns("ImporteCC").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                Me.DataGridView4.Columns("CantOperacionesCC").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            Else
                MessageBox.Show("El DataGridView no tiene 3 columnas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub ActualizarOperacionesEfectivo()
        If Me.DataGridView1.CurrentRow Is Nothing Then Exit Sub

        Dim valor = Me.DataGridView1.CurrentRow.Cells(0).Value

        If valor Is Nothing OrElse Not IsNumeric(valor) Then Exit Sub

        Dim idCaja As Integer = CInt(valor)
        Dim sql As String = "SELECT TipoOperacion, CantOperaciones, Importe FROM ConMoviCajaEfectivo WHERE IdCaja = " & idCaja

        Dim dt As DataTable = mAdminDB.ObtenerTabla(sql)
        Me.DataGridView2.DataSource = dt

        Me.DataGridView2.ClearSelection()
        Dim totalImporte As Decimal = 0D
        For Each row As DataRow In dt.Rows
            If Not IsDBNull(row("Importe")) Then
                totalImporte += Convert.ToDecimal(row("Importe"))
            End If
        Next

        Me.lblImporteEfectivo.Text = "Total Efectivo: $" & totalImporte.ToString("N2")
    End Sub

    Private Sub ActualizarOperacionesPE()
        If Me.DataGridView1.CurrentRow Is Nothing Then Exit Sub

        Dim valor = Me.DataGridView1.CurrentRow.Cells(0).Value

        If valor Is Nothing OrElse Not IsNumeric(valor) Then Exit Sub

        Dim idCaja As Integer = CInt(valor)
        Dim sql As String = "SELECT MedioPE, CantOperaciones, Importe FROM ConMoviCajaPE WHERE IdCaja = " & idCaja

        Dim dt As DataTable = mAdminDB.ObtenerTabla(sql)
        Me.DataGridView3.DataSource = dt

        Me.DataGridView3.ClearSelection()
        Dim totalImporte As Decimal = 0D
        For Each row As DataRow In dt.Rows
            If Not IsDBNull(row("Importe")) Then
                totalImporte += Convert.ToDecimal(row("Importe"))
            End If
        Next

        Me.lblImportePE.Text = "Total Pagos Electronicos: $" & totalImporte.ToString("N2")
    End Sub

    Private Sub ActualizarOperacionesCC()
        If Me.DataGridView1.CurrentRow Is Nothing Then Exit Sub

        Dim valor = Me.DataGridView1.CurrentRow.Cells(0).Value

        If valor Is Nothing OrElse Not IsNumeric(valor) Then Exit Sub

        Dim idCaja As Integer = CInt(valor)
        Dim sql As String = "SELECT TipoOperacion, CantOperaciones, Importe FROM ConMoviCajaCC WHERE IdCaja = " & idCaja

        Dim dt As DataTable = mAdminDB.ObtenerTabla(sql)
        Me.DataGridView4.DataSource = dt

        Me.DataGridView4.ClearSelection()
        Dim totalImporte As Decimal = 0D
        For Each row As DataRow In dt.Rows
            If Not IsDBNull(row("Importe")) Then
                totalImporte += Convert.ToDecimal(row("Importe"))
            End If
        Next

        Me.lblImporteCC.Text = "Total Cuenta Corriente: $" & totalImporte.ToString("N2")
    End Sub

    Private Sub FrmCajas_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try

            Dim sql As String = "SELECT * FROM TblCajas ORDER BY IdCaja"
            Dim TblCajas As DataTable = mAdminDB.ObtenerTabla(sql)
            Me.DataGridView1.DataSource = TblCajas

            If Me.DataGridView1.Rows.Count > 0 Then
                Dim lastRowIndex As Integer = Me.DataGridView1.Rows.Count - 1
                Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(lastRowIndex).Cells(0)
                Me.DataGridView1.FirstDisplayedScrollingRowIndex = lastRowIndex
                Me.ActualizarOperacionesEfectivo()
                Me.ActualizarOperacionesPE()
                Me.ActualizarOperacionesCC()
            End If

            Me.StartPosition = FormStartPosition.Manual
            Me.Location = Screen.PrimaryScreen.WorkingArea.Location
            Me.Size = Screen.PrimaryScreen.WorkingArea.Size

            Me.AjustarAnchoColumnasProporcional()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub dgvOperacionesIniciadas_SelectionChanged(sender As Object, e As EventArgs)

        Try
            If Me.DataGridView1.CurrentRow Is Nothing Then
                Me.DataGridView1.DataSource = Nothing
                Exit Sub
            End If

            Me.ActualizarOperacionesEfectivo()
            Me.ActualizarOperacionesPE()
            Me.ActualizarOperacionesCC()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

End Class