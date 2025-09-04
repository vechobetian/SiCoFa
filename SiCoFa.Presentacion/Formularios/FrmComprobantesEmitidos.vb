Imports SiCoFa.Negocio
Imports SiCoFa.Entidades

Public Class FrmComprobantesEmitidos
    Property SQL As String

    Private mAdminDB As New N_AdminDB

    Private Sub ActualizarMenus()

        If Me.DataGridView1.CurrentRow Is Nothing Then Exit Sub

        Dim celda = DataGridView1.CurrentRow?.Cells("NumComp")

        If celda Is Nothing OrElse celda.Value Is Nothing OrElse String.IsNullOrEmpty(celda.Value.ToString().Trim()) Then
            Me.mnuOperacionesRecuperarComprobante.Visible = True
        Else
            Me.mnuOperacionesRecuperarComprobante.Visible = False
        End If

        If Me.DataGridView1.CurrentRow.Cells("CodiTO").Value = "VTAM" Then
            Me.mnuOperacionesNC.Visible = True
        Else
            Me.mnuOperacionesNC.Visible = False
        End If

        If Me.DataGridView1.CurrentRow.Cells("CodiTC").Value = "RTOX" Then
            Me.mnuOperacionesFacturarRemito.Visible = True
        Else
            Me.mnuOperacionesFacturarRemito.Visible = False
        End If

        If Me.DataGridView1.CurrentRow.Cells("CodiTC").Value = "PRESU" Then
            Me.mnuOperacionesFacturarPresupuesto.Visible = True
        Else
            Me.mnuOperacionesFacturarPresupuesto.Visible = False
        End If

        If Me.DataGridView1.CurrentRow.Cells("CodiTC").Value = "REC" Then
            Me.mnuOperacionesAnularReciboDePago.Visible = True
        Else
            Me.mnuOperacionesAnularReciboDePago.Visible = False
        End If

    End Sub

    Private Sub ActualizarDetalle()
        Try
            If Me.DataGridView1.CurrentRow Is Nothing Then Exit Sub
            Dim valor = Me.DataGridView1.CurrentRow.Cells(2).Value
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

            If DataGridView1.ColumnCount = 21 Then
                Dim totalAncho As Integer = DataGridView1.Width - 41
                Dim proporciones As Double() = {0.0R, 0.0R, 0.04R, 0.08R, 0.03R, 0.08R, 0.04R, 0.03R, 0.04R, 0.14R, 0.06R, 0.04R, 0.05R, 0.05R, 0.05R, 0.05R, 0.07R, 0.05R, 0.1R, 0.0R, 0.0R}

                For i As Integer = 0 To 20
                    DataGridView1.Columns(i).Width = CInt(totalAncho * proporciones(i))
                Next

            Else
                MessageBox.Show("El DataGridView1 no tiene 21 columnas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

            Dim comprobantes As DataTable = mAdminDB.ObtenerTabla(Me.SQL)
            Me.DataGridView1.AutoGenerateColumns = False
            Me.DataGridView1.DataSource = comprobantes
            Me.ActualizarDetalle()
            Me.ActualizarMenus()
            Me.AjustarAnchoColumnasComprobantes()
            Me.AjustarAnchoColumnasDetalle()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = Keys.F1 Then
            ' Verificar si hay fila seleccionada
            Dim dgv = Me.DataGridView1
            If dgv.CurrentRow IsNot Nothing Then
                Dim estado = dgv.CurrentRow.Cells("EstadoOperacion").Value?.ToString()
                If estado = "Error" Then
                    Dim descError = dgv.CurrentRow.Cells("DescripcionError").Value?.ToString()
                    If String.IsNullOrEmpty(descError) Then
                        descError = "Error sin descripción"
                    End If
                    MessageBox.Show(descError, "Detalle de Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
            Return True ' Procesamos la tecla
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

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

    Private Sub mnuOperacionesNC_Click(sender As Object, e As EventArgs) Handles mnuOperacionesNC.Click
        Try

            If Me.DataGridView1.CurrentRow Is Nothing Then Exit Sub
            Dim valor = Me.DataGridView1.CurrentRow.Cells(2).Value
            If valor Is Nothing OrElse Not IsNumeric(valor) Then Exit Sub
            Dim idOperacion As Long = Convert.ToInt64(valor)

            Dim u As Usuario = ModSeguridad.ValidarUsuario("NOTA_CREDITO")

            If u IsNot Nothing Then
                Dim f As New FrmNotaCredito()
                f.Usuario = u
                f.ObtenerComprobanteOrigen(idOperacion)
                f.Show()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub mnuOperacionesRecuperarComprobante_Click(sender As Object, e As EventArgs) Handles mnuOperacionesRecuperarComprobante.Click

        If Me.DataGridView1.CurrentRow Is Nothing Then Exit Sub

        Dim celda = DataGridView1.CurrentRow?.Cells("NumComp")

        If celda IsNot Nothing AndAlso celda.Value IsNot Nothing AndAlso Not String.IsNullOrEmpty(celda.Value.ToString().Trim()) Then
            ' La celda tiene valor (no es null ni cadena vacía)
            Exit Sub
        End If

        Dim valor = Me.DataGridView1.CurrentRow.Cells("IdOperacion").Value
        If valor Is Nothing OrElse Not IsNumeric(valor) Then Exit Sub

        Dim idOperacion As Long = Convert.ToInt64(valor)
        Dim AdminOperaciones As New N_AdminOperaciones

        Dim AdminComprobantes As New N_AdminComprobantes
        Dim objCb As Comprobante = AdminComprobantes.ObtenerComprobanteEmitidoPorIdOperacion(idOperacion, g_ParametrosTerminal.Empresa)

        Try

            If objCb.TipoComprobante.CodiTC_ARCA <> "00" Then
                Dim obj_N_AdminComprobantes As New N_AdminComprobantes
                If obj_N_AdminComprobantes.GenerarFacturaElectronica(objCb) = False Then
                    Throw New Exception("Error al generar la factura electrónica.")
                End If
            Else
                Exit Sub
            End If

            Dim objAdminReporteComprobantes As New ReporteComprobantes
            objAdminReporteComprobantes.ImprimirComprobante(objCb, 1)

            AdminOperaciones.FinalizarOperacion(g_ParametrosTerminal.MacAddress, objCb.Operacion, True)

            Dim comprobantes As DataTable = mAdminDB.ObtenerTabla(Me.SQL)
            Me.DataGridView1.DataSource = comprobantes

        Catch ex As Exception
            AdminOperaciones.RegistrarError(objCb.Operacion.IdOperacion, ex.ToString)
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

    Private Sub FacturarPresupuesto(ByVal argTecla As Keys)
        If Me.DataGridView1.CurrentRow Is Nothing Then Exit Sub

        Dim User As Usuario = ModSeguridad.ValidarUsuario("FACTURACION_REMITOS")
        If User Is Nothing Then
            Exit Sub
        End If

        Dim celda = DataGridView1.CurrentRow?.Cells("ComprobanteAsociado")

        If celda IsNot Nothing AndAlso celda.Value IsNot Nothing AndAlso Not String.IsNullOrEmpty(celda.Value.ToString().Trim()) Then
            MsgBox("El comprobante seleccionado tiene un comprobante asociado", vbCritical, "SiCoFa")
            Exit Sub
        End If

        Dim valor = Me.DataGridView1.CurrentRow.Cells(2).Value
        If valor Is Nothing OrElse Not IsNumeric(valor) Then Exit Sub

        Dim idOperacion As Long = Convert.ToInt64(valor)
        Dim AdminOperaciones As New N_AdminOperaciones
        Dim objTipoOperacion As TipoOperacion = AdminOperaciones.ObtenerTipoOperacionPorCodiTO("VTAM")
        Dim objOperacion As Operacion = AdminOperaciones.IniciarOperacion(g_ParametrosTerminal.Empresa, User, objTipoOperacion, "INICIADA", "")

        Try
            Dim AdminComprobantes As New N_AdminComprobantes
            Dim objCb As Comprobante = AdminComprobantes.ObtenerComprobanteEmitidoPorIdOperacion(idOperacion, g_ParametrosTerminal.Empresa)

            Using FPagos As New FrmPagos
                With FPagos
                    '.FrmOrigen = Me
                    .ComprobanteOrigen = objCb
                    .Operacion = objOperacion
                    .Cliente = objCb.Cliente

                    If argTecla = Keys.F9 Then
                        Dim tc As TipoComprobante = AdminComprobantes.ObtenerTipoComprobantePorCodiTC("RTOX")
                        .TipoComprobante = tc
                    ElseIf argTecla = Keys.F10 AndAlso g_ParametrosSistema.GetValor("SFISCAL") = "FE" Then
                        .TipoComprobante = Nothing
                    Else
                        Dim tc As TipoComprobante = AdminComprobantes.ObtenerTipoComprobantePorCodiTC("RTOX")
                        .TipoComprobante = tc
                    End If

                    .ImporteBruto = objCb.ImpBto
                    .ImporteDescuento = objCb.ImpDes 'mdec_ImporteDescuentos
                    .ImporteAPagar = objCb.ImpNeto 'mdec_ImporteConDescuentos
                    .ImporteGravado1 = objCb.ImpGrav1 'mdec_ImporteGravado1
                    .ImporteGravado2 = objCb.ImpGrav2 'mdec_ImporteGravado2
                    .ItemsComprobante = objCb.Detalle 'mobj_Items.ToList
                    .ShowDialog()
                End With
            End Using

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
            AdminOperaciones.RegistrarError(objOperacion.IdOperacion, ex.ToString)
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try
    End Sub

    Private Sub mnuFacturarPresupuestoEmitirFactura_Click(sender As Object, e As EventArgs) Handles mnuFacturarPresupuestoEmitirFactura.Click
        Me.FacturarPresupuesto(Keys.F10)
    End Sub

    Private Sub mnuFacturarPresupuestoEmitirRemito_Click(sender As Object, e As EventArgs) Handles mnuFacturarPresupuestoEmitirRemito.Click
        Me.FacturarPresupuesto(Keys.F9)
    End Sub

    Private Sub mnuOperacionesAnularReciboDePago_Click(sender As Object, e As EventArgs) Handles mnuOperacionesAnularReciboDePago.Click
        If Me.DataGridView1.CurrentRow Is Nothing Then Exit Sub

        Dim estadoOperacion As String = Me.DataGridView1.CurrentRow.Cells("EstadoOperacion").Value

        If estadoOperacion <> "FINALIZADO" Then
            MsgBox("Solo se puede anular pagos con estado FINALIZADO", vbInformation, "SiCoFa")
            Exit Sub
        End If

        Dim User As Usuario = ModSeguridad.ValidarUsuario("ANULAR_COMPROBANTE")
        If User Is Nothing Then
            Exit Sub
        End If

        Dim valor = Me.DataGridView1.CurrentRow.Cells("IdOperacion").Value
        If valor Is Nothing OrElse Not IsNumeric(valor) Then Exit Sub

        Dim idOperacion As Long = Convert.ToInt64(valor)
        Dim AdminOperaciones As New N_AdminOperaciones

        Try
            Dim codiTO As String = Me.DataGridView1.CurrentRow.Cells("CodiTO").Value

            AdminOperaciones.AnularPagoTransaccion(idOperacion, User, codiTO)

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
End Class