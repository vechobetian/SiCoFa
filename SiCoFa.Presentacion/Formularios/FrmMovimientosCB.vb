Imports SiCoFa.Negocio
Imports SiCoFa.Entidades

Public Class FrmMovimientosCB

    Property CuentaBancaria As CuentaBancaria = Nothing

    Property DescripcionCuentaBancaria As String = ""

    Property ResumenSeleccionado As String = ""

    Property SQL As String = ""

    Private mAdminDB As New N_AdminDB
    Private mSaldoActual As Decimal = 0

    Private Sub AjustarAnchoColumnasComprobantes()
        Try

            If DataGridView1.ColumnCount = 13 Then
                Dim totalAncho As Integer = DataGridView1.Width - 41
                Dim proporciones As Double() = {0.0R, 0.0R, 0.04R, 0.1R, 0.02R, 0.1R, 0.04R, 0.048R, 0.08R, 0.36R, 0.07R, 0.07R, 0.07R}

                For i As Integer = 0 To 12
                    DataGridView1.Columns(i).Width = CInt(totalAncho * proporciones(i))
                Next

            Else
                MessageBox.Show("El DataGridView1 no tiene 13 columnas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub FrmMovimientosCB_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try

            Dim operaciones_cb As DataTable = mAdminDB.ObtenerTabla(Me.SQL)
            Me.DataGridView1.AutoGenerateColumns = False
            Me.DataGridView1.DataSource = operaciones_cb
            Me.AjustarAnchoColumnasComprobantes()

            mSaldoActual = mAdminDB.ObtenerValor($"SELECT SaldoActual FROM cuentas_bancarias WHERE IdCB={Me.CuentaBancaria.IdCB}")

            Me.lblDescripcionCuentaBancaria.Text = "Cuenta Bancaria: " & Me.DescripcionCuentaBancaria
            Me.lblSaldoActual.Text = "Saldo Cuenta Bancaria: $" & mSaldoActual.ToString("N2")

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub FrmOperacionesCC_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        mAdminDB.ActualizarCampo("operaciones_cc", "IdOperaCancel", 0, "IdOperaCancel=-1 AND IdCC=" & Me.CuentaBancaria.IdCB)

    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged

        Try
            If Me.DataGridView1.CurrentRow Is Nothing Then
                Me.DataGridView1.DataSource = Nothing
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub ImprimirComprobante(ByVal argNumCopias As Integer)
        Try
            If Me.DataGridView1.CurrentRow Is Nothing Then Exit Sub
            Dim valor = Me.DataGridView1.CurrentRow.Cells("IdOperacion").Value
            If valor Is Nothing OrElse Not IsNumeric(valor) Then Exit Sub
            Dim idOperacion As Long = Convert.ToInt64(valor)

            Dim AdminComprobantes As New N_AdminComprobantes
            Dim objComprobante As Comprobante = AdminComprobantes.ObtenerComprobanteEmitidoPorIdOperacion(idOperacion, g_ParametrosTerminal.Empresa)

            Dim ReporteComprobantes As New ReporteComprobantes
            ReporteComprobantes.ImprimirComprobante(objComprobante, argNumCopias)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
        End Try
    End Sub

    Private Sub OriginalToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.ImprimirComprobante(-1)
    End Sub

    Private Sub mnuArchivoSalir_Click(sender As Object, e As EventArgs) Handles mnuArchivoSalir.Click
        Me.Close()
    End Sub

    Private Sub mnuOperacionesRetiroEfectivo_Click(sender As Object, e As EventArgs) Handles mnuOperacionesRetiroEfectivo.Click

        Try
            If Me.DataGridView1.CurrentRow Is Nothing Then Exit Sub
            Dim valor = Me.DataGridView1.CurrentRow.Cells("IdOperacion").Value
            If valor Is Nothing OrElse Not IsNumeric(valor) Then Exit Sub
            Dim idOperacion As Long = Convert.ToInt64(valor)

            Dim u As Usuario = ModSeguridad.ValidarUsuario("OPERACIONES_BANCARIAS")

            If u IsNot Nothing Then
                Dim f As New FrmOperacionesCB()
                f.Usuario = u
                f.RetiroEfectivo(Me.CuentaBancaria)
                f.ShowDialog()
            End If

            mSaldoActual = mAdminDB.ObtenerValor($"SELECT SaldoActual FROM cuentas_bancarias WHERE IdCB={Me.CuentaBancaria.IdCB}")
            Me.lblSaldoActual.Text = "Saldo Cuenta Bancaria: $" & mSaldoActual.ToString("N2")

            Dim operaciones_cb As DataTable = mAdminDB.ObtenerTabla(Me.SQL)
            Me.DataGridView1.DataSource = operaciones_cb

            ' Opcional: Seleccionar la fila con el idOperacion actualizado
            For Each row As DataGridViewRow In Me.DataGridView1.Rows
                If Convert.ToInt64(row.Cells("IdOperacion").Value) = idOperacion Then
                    row.Selected = True
                    Me.DataGridView1.CurrentCell = row.Cells("IdOperacion")
                    Exit For
                End If
            Next

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub mnuOperacionesDepositoEfectivo_Click(sender As Object, e As EventArgs) Handles mnuOperacionesDepositoEfectivo.Click

        Try
            If Me.DataGridView1.CurrentRow Is Nothing Then Exit Sub
            Dim valor = Me.DataGridView1.CurrentRow.Cells("IdOperacion").Value
            If valor Is Nothing OrElse Not IsNumeric(valor) Then Exit Sub
            Dim idOperacion As Long = Convert.ToInt64(valor)

            Dim u As Usuario = ModSeguridad.ValidarUsuario("OPERACIONES_BANCARIAS")

            If u IsNot Nothing Then
                Dim f As New FrmOperacionesCB()
                f.Usuario = u
                f.DepositoEfectivo(Me.CuentaBancaria)
                f.ShowDialog()
            End If

            mSaldoActual = mAdminDB.ObtenerValor($"SELECT SaldoActual FROM cuentas_bancarias WHERE IdCB={Me.CuentaBancaria.IdCB}")
            Me.lblSaldoActual.Text = "Saldo Cuenta Bancaria: $" & mSaldoActual.ToString("N2")

            Dim operaciones_cb As DataTable = mAdminDB.ObtenerTabla(Me.SQL)
            Me.DataGridView1.DataSource = operaciones_cb

            ' Opcional: Seleccionar la fila con el idOperacion actualizado
            For Each row As DataGridViewRow In Me.DataGridView1.Rows
                If Convert.ToInt64(row.Cells("IdOperacion").Value) = idOperacion Then
                    row.Selected = True
                    Me.DataGridView1.CurrentCell = row.Cells("IdOperacion")
                    Exit For
                End If
            Next

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub mnuOperacionesTransferenciaBancaria_Click(sender As Object, e As EventArgs) Handles mnuOperacionesTransferenciaBancaria.Click
        Try
            If Me.DataGridView1.CurrentRow Is Nothing Then Exit Sub
            Dim valor = Me.DataGridView1.CurrentRow.Cells("IdOperacion").Value
            If valor Is Nothing OrElse Not IsNumeric(valor) Then Exit Sub
            Dim idOperacion As Long = Convert.ToInt64(valor)

            Dim u As Usuario = ModSeguridad.ValidarUsuario("OPERACIONES_BANCARIAS")

            If u IsNot Nothing Then
                Dim f As New FrmOperacionesCB()
                f.Usuario = u
                f.TransferenciaCB(Me.CuentaBancaria)
                f.ShowDialog()
            End If

            mSaldoActual = mAdminDB.ObtenerValor($"SELECT SaldoActual FROM cuentas_bancarias WHERE IdCB={Me.CuentaBancaria.IdCB}")
            Me.lblSaldoActual.Text = "Saldo Cuenta Bancaria: $" & mSaldoActual.ToString("N2")

            Dim operaciones_cb As DataTable = mAdminDB.ObtenerTabla(Me.SQL)
            Me.DataGridView1.DataSource = operaciones_cb

            ' Opcional: Seleccionar la fila con el idOperacion actualizado
            For Each row As DataGridViewRow In Me.DataGridView1.Rows
                If Convert.ToInt64(row.Cells("IdOperacion").Value) = idOperacion Then
                    row.Selected = True
                    Me.DataGridView1.CurrentCell = row.Cells("IdOperacion")
                    Exit For
                End If
            Next

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try


    End Sub

    Private Sub mnuOperacionesNC_Click(sender As Object, e As EventArgs) Handles mnuOperacionesNC.Click
        Try

            If Me.DataGridView1.CurrentRow Is Nothing Then Exit Sub
            Dim valor = Me.DataGridView1.CurrentRow.Cells("IdOperacion").Value
            If valor Is Nothing OrElse Not IsNumeric(valor) Then Exit Sub
            Dim idOperacion As Long = Convert.ToInt64(valor)

            Dim u As Usuario = ModSeguridad.ValidarUsuario("NOTA_CREDITO")

            If u IsNot Nothing Then
                Dim f As New FrmNotaCredito()
                f.Usuario = u
                f.ObtenerComprobanteOrigen(idOperacion)
                f.ShowDialog()
            End If

            Dim operaciones_cb As DataTable = mAdminDB.ObtenerTabla(Me.SQL)
            Me.DataGridView1.DataSource = operaciones_cb

            ' Opcional: Seleccionar la fila con el idOperacion actualizado
            For Each row As DataGridViewRow In Me.DataGridView1.Rows
                If Convert.ToInt64(row.Cells("IdOperacion").Value) = idOperacion Then
                    row.Selected = True
                    Me.DataGridView1.CurrentCell = row.Cells("IdOperacion")
                    Exit For
                End If
            Next

            mSaldoActual = mAdminDB.ObtenerValor($"SELECT SaldoActual FROM cuentas_bancarias WHERE IdCB={Me.CuentaBancaria.IdCB}")
            Me.lblSaldoActual.Text = "Saldo Cuenta Bancaria: $" & mSaldoActual.ToString("N2")

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub mnuArchivoImprimir_Click(sender As Object, e As EventArgs) Handles mnuArchivoImprimir.Click
        Me.ImprimirComprobante(1)
    End Sub

End Class
