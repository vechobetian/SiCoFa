Imports SiCoFa.Negocio
Imports SiCoFa.Entidades

Public Class FrmMovimientosCB

    Property CuentaBancaria As CuentaBancaria = Nothing

    Property DescripcionCuentaBancaria As String = ""

    Property ResumenSeleccionado As String = ""

    Property SQL As String = ""

    Private mAdminDB As New N_AdminDB
    Private mSaldoActual As Decimal = 0

    Private Sub ActualizarMenus()

        If Me.DataGridView1.CurrentRow Is Nothing Then Exit Sub
        Dim importe As Decimal = Me.DataGridView1.CurrentRow.Cells("Importe").Value

        If Me.DataGridView1.CurrentRow.Cells("CodiTO").Value = "TCB" Then
            If Importe < 0 Then
                Me.mnuVerCuenta.Text = "&Ver Cuenta Destino"
            Else
                Me.mnuVerCuenta.Text = "&Ver Cuenta Origen"
            End If

            Me.mnuVerCuenta.Visible = True
        Else

            Me.mnuVerCuenta.Visible = False

        End If

        Dim codiTO As String = Me.DataGridView1.CurrentRow.Cells("CodiTO").Value

        Dim comprobanteAsociado As String = ""
        Dim valor = Me.DataGridView1.CurrentRow.Cells("ComprobanteAsociado").Value

        If valor IsNot Nothing AndAlso Not IsDBNull(valor) Then
            comprobanteAsociado = valor.ToString()
            comprobanteAsociado = Strings.Left(comprobanteAsociado, "5")
        End If

        If comprobanteAsociado <> "ANUOP" AndAlso (codiTO = "REFCB" OrElse codiTO = "DEFCB" OrElse (codiTO = "TCB" And importe < 0)) Then
            Me.mnuOperacionesAnularOperacion.Visible = True
        Else
            Me.mnuOperacionesAnularOperacion.Visible = False
        End If

    End Sub

    Private Sub AjustarAnchoColumnasComprobantes()
        Try

            If DataGridView1.ColumnCount = 13 Then
                Dim totalAncho As Integer = DataGridView1.Width - 41
                Dim proporciones As Double() = {0.0R, 0.0R, 0.04R, 0.1R, 0.02R, 0.1R, 0.04R, 0.048R, 0.08R, 0.37R, 0.07R, 0.07R, 0.07R}

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
            Me.ActualizarMenus()
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

    Private Sub mnuOperacionesAnularOperacion_Click(sender As Object, e As EventArgs) Handles mnuOperacionesAnularOperacion.Click
        Try

            Dim u As Usuario = ModSeguridad.ValidarUsuario("OPERACIONES_BANCARIAS")

            If u Is Nothing Then
                Exit Sub
            End If

            If Me.DataGridView1.CurrentRow Is Nothing Then Exit Sub
            Dim valor = Me.DataGridView1.CurrentRow.Cells("IdOperacion").Value
            If valor Is Nothing OrElse Not IsNumeric(valor) Then Exit Sub
            Dim idOperacion As Long = Convert.ToInt64(valor)
            Dim codiTO As String = Convert.ToString(Me.DataGridView1.CurrentRow.Cells("CodiTO").Value)
            Dim importe As Decimal = Convert.ToDecimal(Me.DataGridView1.CurrentRow.Cells("Importe").Value)
            Dim objOperacionCBOrigen As OperacionCB = Nothing
            Dim objOperacionCBDestino As OperacionCB = Nothing
            Dim objAsCon As New AsientoContable

            Select Case codiTO
                Case "REFCB"
                    objOperacionCBOrigen = New OperacionCB(0, Me.CuentaBancaria.IdCB, "", -importe, "")

                    With objAsCon
                        .InsertarItem("1.01.03.001", -importe)
                        .InsertarItem("1.01.01.001", importe)
                    End With

                Case "DEFCB"
                    objOperacionCBOrigen = New OperacionCB(0, Me.CuentaBancaria.IdCB, "", -importe, "")

                    With objAsCon
                        .InsertarItem("1.01.01.001", importe)
                        .InsertarItem("1.01.03.001", -importe)
                    End With

                Case "TCB"

                    Dim idCB As Int32 = mAdminDB.ObtenerValor($"SELECT IdCB FROM operaciones_cb WHERE IdOperacion={idOperacion} AND IdCB<>{Me.CuentaBancaria.IdCB}")

                    objOperacionCBOrigen = New OperacionCB(0, Me.CuentaBancaria.IdCB, "", -importe, "")
                    objOperacionCBDestino = New OperacionCB(0, idCB, "", importe, "")

            End Select

            Dim AdminOperaciones As New N_AdminOperaciones
            Dim objTO As TipoOperacion = AdminOperaciones.ObtenerTipoOperacionPorCodiTO("ANUOP")
            Dim AdminComprobantes As New N_AdminComprobantes
            Dim objTC As TipoComprobante = AdminComprobantes.ObtenerTipoComprobantePorCodiTC("ANUOP")
            Dim objCliente As New Cliente(0, "", "", "", "", "", "", "", "", Date.Now, "", "")

            Dim objComprobante As New Comprobante(
                                                  argIdOperacion:=0,
                                                  argOperacion:=Nothing,
                                                  argTipoComprobante:=objTC,
                                                  argPVenta:="",
                                                  argNumComp:="",
                                                  argFechaComp:=Now.Date,
                                                  argImpBto:=importe,
                                                  argImpDes:=0,
                                                  argImpNeto:=importe,
                                                  argImpEx:=0,
                                                  argImpGrav1:=0,
                                                  argImpGrav2:=0,
                                                  argImpCB:=importe,
                                                  argImpEf:=importe,
                                                  argImpCC:=0,
                                                  argImpPE:=0,
                                                  argCAE:=Nothing,
                                                  argIdCliente:=objCliente.Id,
                                                  argCliente:=objCliente,
                                                  argIdOperAsoc:=idOperacion,
                                                  argCompAsoc:=Nothing,
                                                  argEmpresa:=g_ParametrosTerminal.Empresa,
                                                  argDetalle:=Nothing
                                                  )


            AdminOperaciones.OperacionCBTransaccion(g_ParametrosTerminal.MacAddress, g_ParametrosTerminal.Empresa, objTO, u, objOperacionCBOrigen, objOperacionCBDestino, objComprobante, objAsCon, "")

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

    Private Sub mnuArchivoImprimir_Click(sender As Object, e As EventArgs) Handles mnuArchivoImprimir.Click
        Me.ImprimirComprobante(1)
    End Sub

    Private Sub mnuVerCuenta_Click(sender As Object, e As EventArgs) Handles mnuVerCuenta.Click
        If Me.DataGridView1.CurrentRow Is Nothing Then Exit Sub
        Dim valor = Me.DataGridView1.CurrentRow.Cells("IdOperacion").Value
        If valor Is Nothing OrElse Not IsNumeric(valor) Then Exit Sub
        Dim idOperacion As Long = Convert.ToInt64(valor)
        Dim idCB As Int32 = mAdminDB.ObtenerValor($"SELECT IdCB FROM operaciones_cb WHERE IdOperacion={idOperacion} AND IdCB<>{Me.CuentaBancaria.IdCB}")
        Dim AdminCB As New N_AdminCuentasBancarias
        Dim CB As CuentaBancaria = AdminCB.ObtenerCuentaBancariaPorId(idCB)
        MsgBox("Entidad: " & CB.Descripcion & vbCrLf & "N° Cuenta: " & CB.NumCuenta, vbInformation, "SiCoFa")
    End Sub

End Class
