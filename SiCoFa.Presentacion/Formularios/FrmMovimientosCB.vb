Imports SiCoFa.Negocio
Imports SiCoFa.Entidades

Public Class FrmMovimientosCB

    Property CuentaBancaria As CuentaBancaria = Nothing

    Property DescripcionCuentaBancaria As String = ""

    Property ResumenSeleccionado As String = ""

    Property SQL As String = ""

    Private mAdminDB As New N_AdminDB
    Private mSaldoAdeudadoCuentaCorriente As Decimal = 0
    Private mSaldoAdeudadoItemsSeleccinados As Decimal = 0

    Private Sub ActualizarMenus()

        If Me.DataGridView1.CurrentRow Is Nothing Then Exit Sub

        If Me.DataGridView1.CurrentRow.Cells("CodiTC").Value = "RTOX" Then
            Me.mnuOperacionesFacturarRemito.Visible = True
        Else
            Me.mnuOperacionesFacturarRemito.Visible = False
        End If

    End Sub


    Private Sub AjustarAnchoColumnasComprobantes()
        Try

            If DataGridView1.ColumnCount = 14 Then
                Dim totalAncho As Integer = DataGridView1.Width - 41
                Dim proporciones As Double() = {0.0R, 0.0R, 0.01R, 0.05R, 0.1R, 0.04R, 0.1R, 0.04R, 0.03R, 0.04R, 0.07R, 0.4R, 0.05R, 0.07R}

                For i As Integer = 0 To 13
                    DataGridView1.Columns(i).Width = CInt(totalAncho * proporciones(i))
                Next

            Else
                MessageBox.Show("El DataGridView1 no tiene 14 columnas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub FrmMovimientosCB_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try

            Dim operaciones_cc As DataTable = mAdminDB.ObtenerTabla(Me.SQL)
            Me.DataGridView1.AutoGenerateColumns = False
            Me.DataGridView1.DataSource = operaciones_cc
            Me.ActualizarMenus()
            Me.AjustarAnchoColumnasComprobantes()

            mSaldoAdeudadoCuentaCorriente = mAdminDB.ObtenerValor($"SELECT Saldo FROM vw_saldos_idcc WHERE IdCC={Me.CuentaBancaria.IdCB}")
            mSaldoAdeudadoItemsSeleccinados = 0

            If String.IsNullOrWhiteSpace(Me.ResumenSeleccionado) Then
                mSaldoAdeudadoItemsSeleccinados = mSaldoAdeudadoCuentaCorriente

            Else
                mSaldoAdeudadoItemsSeleccinados = mAdminDB.ObtenerValor($"SELECT Saldo FROM vw_saldos_idcc_resu WHERE IdCC={Me.CuentaBancaria.IdCB} AND Resu='{Me.ResumenSeleccionado}'")

            End If

            Me.lblDescripcionCuentaCorriente.Text = "Cuenta Corriente: " & Me.DescripcionCuentaBancaria
            Me.lblSaldoCuentaCorriente.Text = "Saldo Cuenta Corriente: " & mSaldoAdeudadoCuentaCorriente.ToString("N2")
            Me.lblImporteAdeudadoItemsSeleccionados.Text = "Importe Adeudado Items Seleccionados: " & mSaldoAdeudadoItemsSeleccinados.ToString("N2")

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub FrmOperacionesCC_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        mAdminDB.ActualizarCampo("operaciones_cc", "IdOperaCancel", 0, "IdOperaCancel=-1 AND IdCC=" & Me.CuentaBancaria.IdCB)

    End Sub

    ' 1) Bloquea la edición del check si no es VTAM o si EstadoOperacionCC<>'NO CANCELADO' (evita que llegue a marcarse)
    Private Sub DataGridView1_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DataGridView1.CellBeginEdit
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = DataGridView1.Columns("Seleccionar").Index Then
            Dim fila As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim codiTO As String = Convert.ToString(fila.Cells("CodiTO").Value)
            Dim estado As String = Convert.ToString(fila.Cells("EstadoOperacionCC").Value)

            ' Cancelar edición si no es VTAM o si no es NO CANCELADO
            If codiTO <> "VTAM" OrElse estado <> "NO CANCELADO" Then
                e.Cancel = True
            End If
        End If
    End Sub


    ' 2) Solo confirmar el cambio del check si es VTAM; si no, cancelar la edición
    Private Sub DataGridView1_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DataGridView1.CurrentCellDirtyStateChanged
        If DataGridView1.IsCurrentCellDirty AndAlso DataGridView1.CurrentCell.ColumnIndex = DataGridView1.Columns("Seleccionar").Index Then
            Dim fila As DataGridViewRow = DataGridView1.CurrentRow
            Dim codiTO As String = Convert.ToString(fila.Cells("CodiTO").Value)

            If codiTO = "VTAM" Then
                DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
            Else
                DataGridView1.CancelEdit() ' evita que se vea tildado
            End If
        End If
    End Sub

    ' 3) Procesa solo si pasó el filtro (VTAM)
    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = DataGridView1.Columns("Seleccionar").Index Then
            Dim fila As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            If Convert.ToString(fila.Cells("CodiTO").Value) <> "VTAM" Then Exit Sub

            Dim checkValue As Boolean = Convert.ToBoolean(fila.Cells("Seleccionar").Value)
            Dim valorBD As Integer = If(checkValue, -1, 0)
            Dim idOperacion As Int64 = Convert.ToInt64(fila.Cells("IdOperacion").Value)
            Dim valorResu As String = Convert.ToString(fila.Cells("Resu").Value)

            mAdminDB.ActualizarCampo("operaciones_cc", "IdOperaCancel", valorBD, "IdOperacion=" & idOperacion)
            Me.MarcarPorResu(valorResu, checkValue)
        End If
    End Sub

    ' 4) Marca relacionados (mismo Resu y CodiTO = PCC o NC) y actualiza BD
    Private Sub MarcarPorResu(valorResu As String, checkValue As Boolean)
        Dim valorBD As Integer = If(checkValue, -1, 0)

        RemoveHandler DataGridView1.CellValueChanged, AddressOf DataGridView1_CellValueChanged
        For Each fila As DataGridViewRow In DataGridView1.Rows
            Dim resuFila As String = Convert.ToString(fila.Cells("Resu").Value)
            Dim codiTO As String = Convert.ToString(fila.Cells("CodiTO").Value)

            If resuFila = valorResu AndAlso (codiTO = "PCC" OrElse codiTO = "NC") Then
                fila.Cells("Seleccionar").Value = checkValue
                fila.Cells("Seleccionar").ReadOnly = True

                Dim idOperacion As Int64 = Convert.ToInt64(fila.Cells("IdOperacion").Value)
                mAdminDB.ActualizarCampo("operaciones_cc", "IdOperaCancel", valorBD, "IdOperacion=" & idOperacion)
            End If
        Next
        AddHandler DataGridView1.CellValueChanged, AddressOf DataGridView1_CellValueChanged
    End Sub

    'Dejar no editables los checks que no sean VTAM al cargar/refrescar datos
    Private Sub DataGridView1_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles DataGridView1.DataBindingComplete
        For Each fila As DataGridViewRow In DataGridView1.Rows
            Dim codiTO As String = Convert.ToString(fila.Cells("CodiTO").Value)
            Dim estado As String = Convert.ToString(fila.Cells("EstadoOperacionCC").Value)

            ' Solo editable si CodiTO = VTAM y EstadoOperacionCC = NO CANCELADO
            fila.Cells("Seleccionar").ReadOnly = Not (codiTO = "VTAM" AndAlso estado = "NO CANCELADO")
        Next
    End Sub

    Private Function CalcularImporteTotalTildados() As Decimal
        Dim total As Decimal = 0D

        For Each fila As DataGridViewRow In DataGridView1.Rows
            ' Solo sumamos los registros tildados
            Dim estaTildado As Boolean = Convert.ToBoolean(fila.Cells("Seleccionar").Value)
            If estaTildado Then
                ' Sumamos la columna Importe
                Dim importe As Decimal = 0D
                Decimal.TryParse(fila.Cells("Importe").Value.ToString(), importe)
                total += importe
            End If
        Next

        Return total
    End Function

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged

        Try
            If Me.DataGridView1.CurrentRow Is Nothing Then
                Me.DataGridView1.DataSource = Nothing
                Exit Sub
            End If

            Me.ActualizarMenus()

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

    Private Sub OriginalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuArchivoImprimirOriginal.Click
        Me.ImprimirComprobante(-1)
    End Sub

    Private Sub mnuArchivoImprimirDuplicado_Click(sender As Object, e As EventArgs) Handles mnuArchivoImprimirDuplicado.Click
        Me.ImprimirComprobante(-2)
    End Sub

    Private Sub mnuArchivoGuardarComo_Click(sender As Object, e As EventArgs) Handles mnuArchivoGuardarComo.Click
        Try

            If Me.DataGridView1.CurrentRow Is Nothing Then Exit Sub
            Dim valor = Me.DataGridView1.CurrentRow.Cells("IdOperacion").Value
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

    Private Sub mnuArchivoSalir_Click(sender As Object, e As EventArgs) Handles mnuArchivoSalir.Click
        Me.Close()
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

            Dim comprobantes As DataTable = mAdminDB.ObtenerTabla(Me.SQL)
            Me.DataGridView1.DataSource = comprobantes

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

            Dim comprobantes As DataTable = mAdminDB.ObtenerTabla(Me.SQL)
            Me.DataGridView1.DataSource = comprobantes

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

    Private Sub mnuEditarModificarResumen_Click(sender As Object, e As EventArgs) Handles mnuEditarModificarResumen.Click

        If Me.DataGridView1.CurrentRow Is Nothing Then Exit Sub
        Dim valor = Me.DataGridView1.CurrentRow.Cells(3).Value
        If valor Is Nothing OrElse Not IsNumeric(valor) Then Exit Sub
        Dim idOperacion As Long = Convert.ToInt64(valor)
        Dim resu = InputBox("Ingrese el nuevo Resumen", "SiCoFa")

        If String.IsNullOrEmpty(resu) OrElse Strings.Len(resu) <> 4 Then
            MsgBox("La longitud del Resumen debe ser de 4 caracteres", vbCritical, "SiCoFa")
            Exit Sub
        End If

        Dim AdminDB As New N_AdminDB
        AdminDB.ActualizarCampo("operaciones_cc", "Resu", resu, "IdOperacion=" & idOperacion)

        Dim operaciones_cc As DataTable = mAdminDB.ObtenerTabla(Me.SQL)
        Me.DataGridView1.DataSource = operaciones_cc

        ' Opcional: Seleccionar la fila con el idOperacion actualizado
        For Each row As DataGridViewRow In Me.DataGridView1.Rows
            If Convert.ToInt64(row.Cells(2).Value) = idOperacion Then
                row.Selected = True
                Me.DataGridView1.CurrentCell = row.Cells(2)
                Exit For
            End If
        Next
    End Sub

End Class
