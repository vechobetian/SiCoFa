Imports SiCoFa.Entidades
Imports SiCoFa.Negocio

Public Class FrmCajas

    Property Usuario As Usuario

    Private mdecImporteEf As Decimal
    Private mdecImportePE As Decimal
    Private mdecImporteCC As Decimal
    Private mAdminDB As New N_AdminDB

    Private Sub AjustarAnchoColumnasProporcional()
        Try

            If DataGridView2.ColumnCount = 3 Then
                Dim totalAncho As Integer = DataGridView2.Width - 45
                Dim proporciones As Double() = {0.7R, 0.1R, 0.2R}

                For i As Integer = 0 To 2
                    DataGridView2.Columns(i).Width = CInt(totalAncho * proporciones(i))
                Next
                Me.DataGridView2.Columns("ImporteEf").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                Me.DataGridView2.Columns("CantOperacionesEf").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            Else
                MessageBox.Show("El DataGridEfectivo no tiene 3 columnas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            If DataGridView3.ColumnCount = 4 Then
                Dim totalAncho As Integer = DataGridView3.Width - 45
                Dim proporciones As Double() = {0.5R, 0.1R, 0.2R, 0.2R}

                For i As Integer = 0 To 3
                    DataGridView3.Columns(i).Width = CInt(totalAncho * proporciones(i))
                Next
                Me.DataGridView3.Columns("ImportePE").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                Me.DataGridView3.Columns("CantOperacionesPE").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            Else
                MessageBox.Show("El DataGridOperacionesPE no tiene 4 columnas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            If DataGridView4.ColumnCount = 3 Then
                Dim totalAncho As Integer = DataGridView4.Width - 45
                Dim proporciones As Double() = {0.7R, 0.1R, 0.2R}

                For i As Integer = 0 To 2
                    DataGridView4.Columns(i).Width = CInt(totalAncho * proporciones(i))
                Next
                Me.DataGridView4.Columns("ImporteCC").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                Me.DataGridView4.Columns("CantOperacionesCC").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            Else
                MessageBox.Show("El DataGridOperacoinesCC no tiene 3 columnas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

        Me.mdecImporteEf = totalImporte
        Me.lblImporteEfectivo.Text = "Total Efectivo: $" & totalImporte.ToString("N2")
    End Sub

    Private Sub ActualizarOperacionesPE()
        If Me.DataGridView1.CurrentRow Is Nothing Then Exit Sub

        Dim valor = Me.DataGridView1.CurrentRow.Cells(0).Value

        If valor Is Nothing OrElse Not IsNumeric(valor) Then Exit Sub

        Dim idCaja As Integer = CInt(valor)
        Dim sql As String = "SELECT MedioPE, CantOperaciones, Importe,EstadoTransaccion FROM ConMoviCajaPE WHERE IdCaja = " & idCaja

        Dim dt As DataTable = mAdminDB.ObtenerTabla(sql)
        Me.DataGridView3.DataSource = dt

        Me.DataGridView3.ClearSelection()
        Dim totalImporte As Decimal = 0D
        Dim totalImporteAnulados As Decimal = 0D
        For Each row As DataRow In dt.Rows
            If Not IsDBNull(row("Importe")) And row("EstadoTransaccion") = "EN CAJA" Then
                totalImporte += Convert.ToDecimal(row("Importe"))

            ElseIf Not IsDBNull(row("Importe")) And row("EstadoTransaccion") = "ANULADO" Then
                totalImporteAnulados += Convert.ToDecimal(row("Importe"))

            End If
        Next

        Me.mdecImportePE = totalImporte
        Me.lblImportePE.Text = "Total Pagos Electronicos Anulados: $" & totalImporteAnulados.ToString("N2") &
                               "  |  " &
                               "Total Pagos Electronicos No Anulados: $" & totalImporte.ToString("N2")
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

        Me.mdecImporteCC = totalImporte
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

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged

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

    Private Sub DetalleOperacionesEfectivoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DetalleOperacionesEfectivoToolStripMenuItem.Click
        If Me.DataGridView1.CurrentRow Is Nothing Then Exit Sub

        Dim valor = Me.DataGridView1.CurrentRow.Cells(0).Value

        If valor Is Nothing OrElse Not IsNumeric(valor) Then Exit Sub

        Dim idCaja As Integer = CInt(valor)
        FrmMoviCajaEfectivoDetalle.IdCaja = idCaja
        FrmMoviCajaEfectivoDetalle.Show()

    End Sub

    Private Sub DetallePagoElectronicoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DetallePagoElectronicoToolStripMenuItem.Click

        If Me.DataGridView1.CurrentRow Is Nothing Then Exit Sub

        Dim valor = Me.DataGridView1.CurrentRow.Cells(0).Value

        If valor Is Nothing OrElse Not IsNumeric(valor) Then Exit Sub

        Dim idCaja As Integer = CInt(valor)
        FrmMoviCajaPEDetalle.IdCaja = idCaja
        FrmMoviCajaPEDetalle.Show()

    End Sub

    Private Sub DetalleCuentaCorrienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DetalleCuentaCorrienteToolStripMenuItem.Click

        If Me.DataGridView1.CurrentRow Is Nothing Then Exit Sub

        Dim valor = Me.DataGridView1.CurrentRow.Cells(0).Value

        If valor Is Nothing OrElse Not IsNumeric(valor) Then Exit Sub

        Dim idCaja As Integer = CInt(valor)
        FrmMoviCajaCCDetalle.IdCaja = idCaja
        FrmMoviCajaCCDetalle.Show()

    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Try

            If Me.DataGridView1.CurrentRow.Cells("Estado").Value = "CERRADA" Then
                MsgBox("La caja seleccionada esta cerrada", vbInformation, "SiCoFa")
                Exit Sub
            End If

            Dim objCliente As New Cliente(0, "", "", "", "", "", "", "", "", Date.Now, "", "")
            Dim objComprobante As New Comprobante(
                                              0,
                                              Nothing,
                                              "DI",
                                              "",
                                              "",
                                              Nothing,
                                              mdecImporteEf + mdecImportePE + mdecImporteCC,
                                              0, 0, 0, 0, 0, mdecImporteEf, mdecImporteCC, mdecImportePE, Nothing, 0, objCliente, 0,
                                              Nothing, Nothing, Nothing)


            Dim IdCaja As Long = Me.DataGridView1.CurrentRow.Cells(0).Value
            Dim Apertura As Date = Me.DataGridView1.CurrentRow.Cells(1).Value
            Dim Cierre As Date = Date.MinValue
            Dim Estado As String = Me.DataGridView1.CurrentRow.Cells(3).Value
            Dim NCaja As String = Me.DataGridView1.CurrentRow.Cells(4).Value
            Dim objCaja As New Caja(IdCaja, Apertura, Cierre, Estado, NCaja)
            Dim AdminCajas As New N_AdminCajas
            AdminCajas.CierreCajaTransaccion(g_ParametrosTerminal.MacAddress, objCaja, g_ParametrosTerminal.Empresa, Me.Usuario, objComprobante)

            Dim sql As String = "SELECT * FROM TblCajas ORDER BY IdCaja"
            Dim TblCajas As DataTable = mAdminDB.ObtenerTabla(sql)
            Me.DataGridView1.DataSource = TblCajas

            ' Opcional: Seleccionar la última caja (la recién abierta)
            If Me.DataGridView1.Rows.Count > 0 Then
                Dim lastRowIndex As Integer = Me.DataGridView1.Rows.Count - 1
                Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(lastRowIndex).Cells(0)
                Me.DataGridView1.FirstDisplayedScrollingRowIndex = lastRowIndex
            End If

            Me.ActualizarOperacionesEfectivo()
            MsgBox("Caja cerrada y nueva caja abierta exitosamente.", vbInformation, "SiCoFa")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Class