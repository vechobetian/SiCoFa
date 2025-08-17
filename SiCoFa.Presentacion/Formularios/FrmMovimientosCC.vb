Imports SiCoFa.Negocio
Imports SiCoFa.Entidades

Public Class FrmMovimientosCC

    Property IdCC As Int32 = 0

    Property DescripcionCuentaCorriente As String = ""

    Property ResuSeleccionado As String = ""

    Property SQL As String = ""

    Private mAdminDB As New N_AdminDB

    Private Sub ActualizarMenus()

        If Me.DataGridView1.CurrentRow Is Nothing Then Exit Sub

        If Me.DataGridView1.CurrentRow.Cells("CodiTC").Value = "RTOX" Then
            Me.mnuOperacionesFacturarRemito.Visible = True
        Else
            Me.mnuOperacionesFacturarRemito.Visible = False
        End If

    End Sub

    Private Sub ActualizarDetalle()
        Try
            If Me.DataGridView1.CurrentRow Is Nothing Then Exit Sub
            Dim valor = Me.DataGridView1.CurrentRow.Cells(3).Value
            If valor Is Nothing OrElse Not IsNumeric(valor) Then Exit Sub
            Dim idOperacion As Long = Convert.ToInt64(valor)

            Dim AdminItems As New N_AdminItemsComprobante
            Dim objItems As List(Of ItemComprobante) = AdminItems.ListarItemsPorIdOperacion(idOperacion)

            Me.DataGridView2.AutoGenerateColumns = False
            Me.DataGridView2.DataSource = objItems
            Me.DataGridView2.ClearSelection()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
        End Try

    End Sub

    Private Sub AjustarAnchoColumnasComprobantes()
        Try

            If DataGridView1.ColumnCount = 13 Then
                Dim totalAncho As Integer = DataGridView1.Width - 41
                Dim proporciones As Double() = {0.0R, 0.0R, 0.01R, 0.05R, 0.04R, 0.1R, 0.04R, 0.03R, 0.04R, 0.07R, 0.5R, 0.05R, 0.07R}

                For i As Integer = 0 To 12
                    DataGridView1.Columns(i).Width = CInt(totalAncho * proporciones(i))
                Next

            Else
                MessageBox.Show("El DataGridView1 no tiene 10 columnas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub AjustarAnchoColumnasDetalle()
        Try

            If DataGridView2.ColumnCount = 10 Then
                Dim totalAncho As Integer = DataGridView1.Width
                Dim proporciones As Double() = {0.0R, 0.08R, 0.5R, 0.05R, 0.05R, 0.08R, 0.08R, 0.05R, 0.08R, 0.08R}

                For i As Integer = 0 To 9 ' Itera a través de las 9 columnas
                    DataGridView2.Columns(i).Width = CInt(totalAncho * proporciones(i))
                Next
            Else
                MessageBox.Show("El DataGridView2 no tiene 9 columnas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub FrmComprobantesEmitidos_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try

            Dim TblComprobantes As DataTable = mAdminDB.ObtenerTabla(Me.SQL)
            Me.DataGridView1.AutoGenerateColumns = False
            Me.DataGridView1.DataSource = TblComprobantes
            Me.ActualizarDetalle()
            Me.ActualizarMenus()
            Me.AjustarAnchoColumnasComprobantes()
            Me.AjustarAnchoColumnasDetalle()

            Dim SaldoAdeudadoCuentaCorriente As Decimal = mAdminDB.ObtenerValor($"SELECT Saldo FROM ConSaldosIdCC WHERE IdCC={Me.IdCC}")
            Dim SaldoAdeudadoItemsSeleccinados As Decimal = 0

            If String.IsNullOrWhiteSpace(Me.ResuSeleccionado) Then
                SaldoAdeudadoItemsSeleccinados = SaldoAdeudadoCuentaCorriente

            Else
                SaldoAdeudadoItemsSeleccinados = mAdminDB.ObtenerValor($"SELECT Saldo FROM ConSaldosIdCCResu WHERE IdCC={Me.IdCC} AND Resu='{Me.ResuSeleccionado}'")

            End If

            Me.lblDescripcionCuentaCorriente.Text = "Cuenta Corriente: " & Me.DescripcionCuentaCorriente
            Me.lblSaldoCuentaCorriente.Text = "Saldo Cuenta Corriente: " & SaldoAdeudadoCuentaCorriente.ToString("N2")
            Me.lblImporteAdeudadoItemsSeleccionados.Text = "Importe Adeudado Items Seleccionados: " & SaldoAdeudadoItemsSeleccinados

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub DataGridView1_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DataGridView1.CurrentCellDirtyStateChanged
        If DataGridView1.IsCurrentCellDirty AndAlso
           DataGridView1.CurrentCell.ColumnIndex = DataGridView1.Columns("Seleccionar").Index Then
            DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged

        Try
            If Me.DataGridView1.CurrentRow Is Nothing Then
                Me.DataGridView1.DataSource = Nothing
                Exit Sub
            End If

            Me.ActualizarDetalle()
            Me.ActualizarMenus()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub ImprimirComprobante(ByVal argNumCopias As Integer)
        Try
            If Me.DataGridView1.CurrentRow Is Nothing Then Exit Sub
            Dim valor = Me.DataGridView1.CurrentRow.Cells(3).Value
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

    Private Sub OriginalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuArchivoImprimirOriginal.Click
        Me.ImprimirComprobante(-1)
    End Sub

    Private Sub mnuArchivoImprimirDuplicado_Click(sender As Object, e As EventArgs) Handles mnuArchivoImprimirDuplicado.Click
        Me.ImprimirComprobante(-2)
    End Sub

    Private Sub mnuArchivoGuardarComo_Click(sender As Object, e As EventArgs) Handles mnuArchivoGuardarComo.Click
        Try

            If Me.DataGridView1.CurrentRow Is Nothing Then Exit Sub
            Dim valor = Me.DataGridView1.CurrentRow.Cells(3).Value
            If valor Is Nothing OrElse Not IsNumeric(valor) Then Exit Sub
            Dim idOperacion As Long = Convert.ToInt64(valor)

            Dim AdminComprobantes As New N_AdminComprobantes
            Dim objComprobante As Comprobante = AdminComprobantes.ObtenerComprobanteEmitidoPorIdOperacion(idOperacion, g_ParametrosTerminal.Empresa)

            Dim saveFileDialog1 As New SaveFileDialog()
            With saveFileDialog1
                .Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
                .FilterIndex = 2
                .FileName = objComprobante.TipoComprobante.CodiTC_SiCoFa & "-" & objComprobante.PVenta & "-" & objComprobante.NumComp
                .DefaultExt = ".pdf"
                .RestoreDirectory = True
            End With

            If saveFileDialog1.ShowDialog() = DialogResult.OK Then
                Dim ReporteComprobantes As New ReporteComprobantes
                ReporteComprobantes.PdfA4(saveFileDialog1.FileName, objComprobante)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub mnuOperacionesNC_Click(sender As Object, e As EventArgs) Handles mnuOperacionesNC.Click
        Try

            If Me.DataGridView1.CurrentRow Is Nothing Then Exit Sub
            Dim valor = Me.DataGridView1.CurrentRow.Cells(3).Value
            If valor Is Nothing OrElse Not IsNumeric(valor) Then Exit Sub
            Dim idOperacion As Long = Convert.ToInt64(valor)

            Dim u As Usuario = ModSeguridad.ValidarUsuario("NOTA_CREDITO")

            If u IsNot Nothing Then
                Dim f As New FrmNotaCredito()
                f.Usuario = u
                f.ObtenerComprobanteOrigen(idOperacion)
                f.ShowDialog()
            End If

            Dim TblComprobantes As DataTable = mAdminDB.ObtenerTabla(Me.SQL)
            Me.DataGridView1.DataSource = TblComprobantes

            ' Opcional: Seleccionar la fila con el idOperacion actualizado
            For Each row As DataGridViewRow In Me.DataGridView1.Rows
                If Convert.ToInt64(row.Cells(2).Value) = idOperacion Then
                    row.Selected = True
                    Me.DataGridView1.CurrentCell = row.Cells(2)
                    Exit For
                End If
            Next

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub mnuOperacionesFacturarRemito_Click(sender As Object, e As EventArgs) Handles mnuOperacionesFacturarRemito.Click
        If Me.DataGridView1.CurrentRow Is Nothing Then Exit Sub

        Dim User As Usuario = ModSeguridad.ValidarUsuario("FACTURACION_REMITOS")
        If User Is Nothing Then
            Exit Sub
        End If

        Dim valor = Me.DataGridView1.CurrentRow.Cells(2).Value
        If valor Is Nothing OrElse Not IsNumeric(valor) Then Exit Sub

        Dim idOperacion As Long = Convert.ToInt64(valor)
        Dim AdminOperaciones As New N_AdminOperaciones

        Dim AdminComprobantes As New N_AdminComprobantes
        Dim objCb As Comprobante = AdminComprobantes.ObtenerComprobanteEmitidoPorIdOperacion(idOperacion, g_ParametrosTerminal.Empresa)

        If objCb.IdOperAsoc > 0 Then
            MsgBox("El comprobante seleccionado tiene un comprobante asociado", vbCritical, "SiCoFa")
            Exit Sub
        End If

        objCb.IdOperAsoc = objCb.IdOperacion

        Dim AdminSiCoFa As New N_AdminSiCoFa
        objCb.TipoComprobante = AdminSiCoFa.ObtenerTipoComprobanteVenta(g_ParametrosTerminal.Empresa.IVA.CodIVA, objCb.Cliente.IVA.CodIVA)

        Try
            AdminOperaciones.FacturacionRemitoTransaccion(g_ParametrosTerminal.MacAddress, g_ParametrosTerminal.Empresa, User, objCb, "")

            If objCb.TipoComprobante.CodiTC_ARCA <> "00" Then
                Dim AdminComprobants As New N_AdminComprobantes
                If AdminComprobants.GenerarFacturaElectronica(objCb) = False Then
                    'aca hay que cambiar el estado de la operacion y salir
                End If
            End If

            Dim objAdminReporteComprobantes As New ReporteComprobantes
            objAdminReporteComprobantes.ImprimirComprobante(objCb, 1)

            Dim TblComprobantes As DataTable = mAdminDB.ObtenerTabla(Me.SQL)
            Me.DataGridView1.DataSource = TblComprobantes

            ' Opcional: Seleccionar la fila con el idOperacion actualizado
            For Each row As DataGridViewRow In Me.DataGridView1.Rows
                If Convert.ToInt64(row.Cells(2).Value) = idOperacion Then
                    row.Selected = True
                    Me.DataGridView1.CurrentCell = row.Cells(2)
                    Exit For
                End If
            Next

        Catch ex As Exception
            AdminOperaciones.RegistrarError(objCb.Operacion.IdOperacion, ex.ToString)
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try
    End Sub

End Class