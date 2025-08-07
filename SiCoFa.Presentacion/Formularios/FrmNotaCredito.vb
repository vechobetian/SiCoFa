Imports System.ComponentModel
Imports HasarArgentina
Imports SiCoFa.Entidades
Imports SiCoFa.Negocio

Public Class FrmNotaCredito
    Property Usuario As Usuario

    Private mobj_ComprobanteOrigen As Comprobante
    Private mobj_ItemsComprobanteOrigen As New BindingList(Of ItemComprobanteNC)
    Private mobj_ItemsComprobante As New List(Of ItemComprobante) 'Esta lista es para el objeto comprobante
    Private mint_CantidadItems As Integer = 0
    Private mdec_CantidadFacturado As Decimal = 0
    Private mdec_CantidadAcreditado As Decimal = 0
    Private mdec_ImporteCosto As Decimal = 0
    Private mdec_ImporteSinDescuentos As Decimal = 0
    Private mdec_ImporteDescuentos As Decimal = 0
    Private mdec_ImporteConDescuentos As Decimal = 0
    Private mdec_PorcentaDescuentos As Decimal = 0
    Private mdec_ImporteGravado1 As Decimal = 0
    Private mdec_ImporteGravado2 As Decimal = 0

    Public Sub ObtenerComprobanteOrigen(ByVal argIdOperacion As Long)
        Try

            Dim AdminComprobantes As New N_AdminComprobantes
            mobj_ComprobanteOrigen = AdminComprobantes.ObtenerComprobantePorIdOperacion(argIdOperacion, g_ParametrosTerminal.Empresa)

            Dim AdminItems As New N_AdminItemsComprobante
            Dim objItems As List(Of ItemComprobanteNC) = AdminItems.ListarItemsNCPorIdOperacion(argIdOperacion)
            mobj_ItemsComprobanteOrigen = New BindingList(Of ItemComprobanteNC)(objItems)

            If mobj_ComprobanteOrigen.IdOperAsoc > 0 Then
                Me.chkAcreditarTodo.Checked = False
                Me.chkAcreditarTodo.Enabled = False
            End If

            If mobj_ComprobanteOrigen.ImpPE > 0 OrElse (mobj_ComprobanteOrigen.ImpCC > 0 AndAlso mobj_ComprobanteOrigen.ImpEf > 0) Then
                Me.AcreditacionCompleta()
                Me.chkAcreditarTodo.Checked = True
                Me.chkAcreditarTodo.Enabled = False
                Me.DataGridView1.ReadOnly = True
            Else
                Me.chkAcreditarTodo.Checked = False
                Me.chkAcreditarTodo.Enabled = True
                Me.DataGridView1.ReadOnly = False
            End If

            Me.ActualizarTotales()
            Me.ActualizarDatosOperacion()

            Me.DataGridView1.AutoGenerateColumns = False
            Me.DataGridView1.DataSource = Me.mobj_ItemsComprobanteOrigen
            Me.DataGridView1.ClearSelection()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try
    End Sub

    Private Sub AcreditacionCompleta()
        Try
            mint_CantidadItems = 0
            mdec_ImporteCosto = 0
            mdec_ImporteSinDescuentos = 0
            mdec_ImporteDescuentos = 0
            mdec_ImporteConDescuentos = 0
            mdec_PorcentaDescuentos = 0
            mdec_ImporteGravado1 = 0
            mdec_ImporteGravado2 = 0

            For Each i As ItemComprobanteNC In Me.mobj_ItemsComprobanteOrigen
                i.CantidadNC = i.CantidadF - i.CantidadA

                If i.CantidadNC > 0 Then
                    mint_CantidadItems += 1
                End If

                mdec_ImporteCosto += (i.PrecioCosto * i.CantidadA)
                mdec_ImporteSinDescuentos += i.ImporteSinDescuento
                mdec_ImporteDescuentos += i.ImporteDescuento
                mdec_ImporteConDescuentos += i.ImporteConDescuento

                Select Case i.AlicIVA
                    Case 10.5
                        mdec_ImporteGravado1 += i.ImporteConDescuento
                    Case 21
                        mdec_ImporteGravado2 += i.ImporteConDescuento
                End Select
            Next

            If mdec_ImporteSinDescuentos > 0 Then
                mdec_PorcentaDescuentos = Math.Round(mdec_ImporteDescuentos / mdec_ImporteSinDescuentos * 100, 2, MidpointRounding.ToEven)
            Else
                mdec_PorcentaDescuentos = 0
            End If

            Me.lblCantidadItems.Text = "- Items Nota de Crédito: " & mint_CantidadItems
            Me.lblImporteSinDescuentos.Text = "$ " & Format(mdec_ImporteSinDescuentos, "#,##0.00")
            Me.lblPorcentajeAplicado.Text = "- Porcentaje Descuentos: " & Format(mdec_PorcentaDescuentos, "#,##0.00") & "%"
            Me.lblImporteDescuentos.Text = "$ " & Format(mdec_ImporteDescuentos, "#,##0.00")
            Me.lblImporteConDescuentos.Text = "$ " & Format(mdec_ImporteConDescuentos, "#,##0.00")
            Me.DataGridView1.Refresh()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
        End Try
    End Sub

    Private Sub PonerEnCeroCantNC()
        Try
            mint_CantidadItems = 0
            mdec_ImporteCosto = 0
            mdec_ImporteSinDescuentos = 0
            mdec_ImporteDescuentos = 0
            mdec_ImporteConDescuentos = 0
            mdec_PorcentaDescuentos = 0
            mdec_ImporteGravado1 = 0
            mdec_ImporteGravado2 = 0

            For Each i As ItemComprobanteNC In Me.mobj_ItemsComprobanteOrigen
                mint_CantidadItems = 0
                i.CantidadNC = 0
                mdec_ImporteCosto += (i.PrecioCosto * i.CantidadA)
                mdec_ImporteSinDescuentos += i.ImporteSinDescuento
                mdec_ImporteDescuentos += i.ImporteDescuento
                mdec_ImporteConDescuentos += i.ImporteConDescuento

                Select Case i.AlicIVA
                    Case 10.5
                        mdec_ImporteGravado1 += i.ImporteConDescuento
                    Case 21
                        mdec_ImporteGravado2 += i.ImporteConDescuento
                End Select
            Next

            If mdec_ImporteSinDescuentos > 0 Then
                mdec_PorcentaDescuentos = Math.Round(mdec_ImporteDescuentos / mdec_ImporteSinDescuentos * 100, 2, MidpointRounding.ToEven)
            Else
                mdec_PorcentaDescuentos = 0
            End If

            Me.lblCantidadItems.Text = "- Items Nota de Crédito: " & mint_CantidadItems
            Me.lblImporteSinDescuentos.Text = "$ " & Format(mdec_ImporteSinDescuentos, "#,##0.00")
            Me.lblPorcentajeAplicado.Text = "- Porcentaje Descuentos: " & Format(mdec_PorcentaDescuentos, "#,##0.00") & "%"
            Me.lblImporteDescuentos.Text = "$ " & Format(mdec_ImporteDescuentos, "#,##0.00")
            Me.lblImporteConDescuentos.Text = "$ " & Format(mdec_ImporteConDescuentos, "#,##0.00")
            Me.DataGridView1.Refresh()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
        End Try
    End Sub

    Private Sub Guardar()
        Try

            If Me.mdec_ImporteSinDescuentos = 0 Then
                Exit Sub
            End If

            Dim objCC As OperacionCC = Nothing
            Dim objPE As OperacionPE = Nothing
            Dim objCb As Comprobante = Nothing
            Dim objAC As AsientoContable = Nothing
            Dim impEf As Decimal
            Dim impCC As Decimal
            Dim impPE As Decimal

            Dim AdminOperacion As New N_AdminOperaciones
            Dim objTipoOperacion As TipoOperacion = Nothing

            Select Case mobj_ComprobanteOrigen.Operacion.TipoOperacion.CodiTO
                Case "VTAM"
                    objTipoOperacion = AdminOperacion.ObtenerTipoOperacionPorCodiTO("NC")

                Case "F_R"
                    objTipoOperacion = AdminOperacion.ObtenerTipoOperacionPorCodiTO("N_C")
            End Select

            Me.InsertarItems()

            If Me.chkAcreditarTodo.Checked Then
                impEf = mobj_ComprobanteOrigen.ImpEf
                impCC = mobj_ComprobanteOrigen.ImpCC
                impPE = mobj_ComprobanteOrigen.ImpPE
            End If

            If mobj_ComprobanteOrigen.ImpEf > 0 And Me.chkAcreditarTodo.Checked = False Then 'Esta situación deberia darse solamente cuando la unica forma de pago es Efectivo
                impEf = mdec_ImporteConDescuentos
            End If

            If mobj_ComprobanteOrigen.ImpCC > 0 And Me.chkAcreditarTodo.Checked = False Then 'Esta situación deberia darse solamente cuando la unica forma de pago es Cuenta Corriente
                impCC = mdec_ImporteConDescuentos
            End If

            If impCC > 0 Then
                objCC = New OperacionCC(0, mobj_ComprobanteOrigen.Cliente.CuentaCorriente.IdCC, "", -impCC, "NO CANCELADO", 0)
            End If

            If impPE > 0 Then
                objPE = New OperacionPE(0, 0, 1, 0, 0, "ANULADO")
            End If

            Dim CodiTC As String = ""

            Select Case mobj_ComprobanteOrigen.TipoComprobante.CodiTC_SiCoFa
                Case "FAA"
                    CodiTC = "NCA"
                Case "FAB"
                    CodiTC = "NCB"
                Case "FAC"
                    CodiTC = "NCC"
                Case "RTOX"
                    CodiTC = "NCX"
            End Select

            Dim AdminComprobantes As New N_AdminComprobantes
            Dim objTipoComprobante As TipoComprobante = AdminComprobantes.ObtenerTipoComprobantePorCodiTC(CodiTC)

            objCb = New Comprobante(
            argIdOperacion:=0,
            argOperacion:=Nothing,
            argTipoComprobante:=objTipoComprobante,
            argPVenta:=g_ParametrosTerminal.PVenta,
            argNumComp:="",
            argFechaComp:=Now.Date,
            argImpBto:=Me.mdec_ImporteConDescuentos,
            argImpDes:=0,
            argImpEx:=0,
            argImpGrav1:=Me.mdec_ImporteGravado1,
            argImpGrav2:=Me.mdec_ImporteGravado2,
            argImpCB:=0,
            argImpEf:=impEf,
            argImpCC:=impCC,
            argImpPE:=impPE,
            argCAE:=Nothing,
            argIdCliente:=mobj_ComprobanteOrigen.Cliente.Id,
            argCliente:=mobj_ComprobanteOrigen.Cliente,
            argIdOperAsoc:=mobj_ComprobanteOrigen.IdOperacion,
            argCompAsoc:=mobj_ComprobanteOrigen,
            argEmpresa:=g_ParametrosTerminal.Empresa,
            argDetalle:=mobj_ItemsComprobante
            )

            objAC = New AsientoContable
            With objAC
                .InsertarItem("4.01.01.001", -mdec_ImporteConDescuentos)
                .InsertarItem("1.01.01.001", -impEf)
                .InsertarItem("1.03.01.001", -impCC)
                .InsertarItem("1.03.02.001", -impPE)
            End With

            AdminOperacion.FinalizarNCTransaccion(objTipoOperacion, g_ParametrosTerminal.MacAddress, g_ParametrosTerminal.Empresa, Me.Usuario, objCC, objPE, objCb, objAC, "")

            If objCb.TipoComprobante.CodiTC_ARCA <> "00" Then
                Dim AdminComprobants As New N_AdminComprobantes
                If AdminComprobants.GenerarFacturaElectronica(objCb) = False Then
                    'aca hay que cambiar el estado de la operacion y salir
                End If
            End If

            Dim objAdminReporteComprobantes As New ReporteComprobantes
            objAdminReporteComprobantes.ImprimirComprobante(objCb, 1)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
        End Try
    End Sub

    Private Sub InsertarItems()
        Try
            Dim AdminArticulos As New N_AdminArticulos

            For Each i As ItemComprobanteNC In mobj_ItemsComprobanteOrigen
                If i.CantidadNC > 0 Then
                    Dim objArticulo As Articulo = AdminArticulos.ObtenerArticuloPorId(i.IdArticulo)
                    Dim objItemComprobante As New ItemComprobante(objArticulo, objArticulo.CodBarras, i.Descripcion, i.CantidadNC, i.PrecioUnitario, i.AlicIVA, i.PorcentajeDescuento)
                    objItemComprobante.IdItem = i.IdItem
                    objItemComprobante.Articulo.PrecioCosto = i.PrecioCosto
                    mobj_ItemsComprobante.Add(objItemComprobante)
                End If
            Next

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try
    End Sub

    Private Sub AjustarAnchoColumnasProporcional()
        Try

            If DataGridView1.ColumnCount = 12 Then
                Dim totalAncho As Integer = DataGridView1.Width
                Dim proporciones As Double() = {0.0R, 0.08R, 0.3R, 0.05R, 0.05R, 0.05R, 0.05R, 0.08R, 0.08R, 0.05R, 0.08R, 0.08R}

                For i As Integer = 0 To 11 ' Itera a través de las 9 columnas
                    DataGridView1.Columns(i).Width = CInt(totalAncho * proporciones(i))
                Next
            Else
                MessageBox.Show("El DataGridView no tiene 12 columnas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub ActualizarTotales()

        Try
            mint_CantidadItems = 0
            mdec_ImporteCosto = 0
            mdec_ImporteSinDescuentos = 0
            mdec_ImporteDescuentos = 0
            mdec_ImporteConDescuentos = 0
            mdec_PorcentaDescuentos = 0
            mdec_ImporteGravado1 = 0
            mdec_ImporteGravado2 = 0

            For Each i As ItemComprobanteNC In Me.mobj_ItemsComprobanteOrigen

                If i.CantidadNC > 0 Then
                    mint_CantidadItems += 1
                End If

                mdec_CantidadAcreditado += i.CantidadA
                mdec_CantidadFacturado += i.CantidadF
                mdec_ImporteCosto += (i.PrecioCosto * i.CantidadA)
                mdec_ImporteSinDescuentos += i.ImporteSinDescuento
                mdec_ImporteDescuentos += i.ImporteDescuento
                mdec_ImporteConDescuentos += i.ImporteConDescuento

                Select Case i.AlicIVA
                    Case 10.5
                        mdec_ImporteGravado1 += i.ImporteConDescuento
                    Case 21
                        mdec_ImporteGravado2 += i.ImporteConDescuento
                End Select
            Next

            If mdec_ImporteSinDescuentos > 0 Then
                mdec_PorcentaDescuentos = Math.Round(mdec_ImporteDescuentos / mdec_ImporteSinDescuentos * 100, 2, MidpointRounding.ToEven)
            Else
                mdec_PorcentaDescuentos = 0
            End If

            Me.lblCantidadItems.Text = "- Items Nota de Crédito: " & mint_CantidadItems
            Me.lblImporteSinDescuentos.Text = "$ " & Format(mdec_ImporteSinDescuentos, "#,##0.00")
            Me.lblPorcentajeAplicado.Text = "- Porcentaje Descuentos: " & Format(mdec_PorcentaDescuentos, "#,##0.00") & "%"
            Me.lblImporteDescuentos.Text = "$ " & Format(mdec_ImporteDescuentos, "#,##0.00")
            Me.lblImporteConDescuentos.Text = "$ " & Format(mdec_ImporteConDescuentos, "#,##0.00")

            If mdec_CantidadFacturado - mdec_CantidadAcreditado = 0 Then
                Me.chkAcreditarTodo.Checked = False
                Me.chkAcreditarTodo.Enabled = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub ActualizarDatosOperacion()

        Dim Datos As String = "- Comprobante Origen: " & mobj_ComprobanteOrigen.TipoComprobante.CodiTC_SiCoFa & "-" & mobj_ComprobanteOrigen.PVenta & "-" & mobj_ComprobanteOrigen.NumComp & vbCrLf &
                              "- Usuario: " & Me.Usuario.Nombre & vbCrLf &
                              "- Cliente: " & mobj_ComprobanteOrigen.Cliente.Nombre
        Me.lblDatosOperacion.Text = Datos

    End Sub

    Private Sub FrmNotaCredito_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Me.ActualizarDatosOperacion()
            Me.DataGridView1.AutoGenerateColumns = False
            Me.DataGridView1.DataSource = Me.mobj_ItemsComprobanteOrigen
            Me.DataGridView1.ClearSelection()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub FrmNotaCredito_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Try
            Me.AjustarAnchoColumnasProporcional()


        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData

            Case Keys.F10
                Me.Guardar()

            Case Else
                Return MyBase.ProcessCmdKey(msg, keyData)

        End Select

        Return True ' Asegúrate de devolver True para que la tecla se procese correctamente

    End Function

    Private Sub FrmNotaCredito_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.AjustarAnchoColumnasProporcional()
    End Sub

    ' Variable de control para no mostrar MsgBox repetidos
    Private ajustarCantidad As Boolean = False
    Private valorMaximo As Decimal = 0

    Private Sub DataGridView1_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles DataGridView1.CellValidating
        Try
            If DataGridView1.Columns(e.ColumnIndex).Name.Equals("CantidadNC", StringComparison.OrdinalIgnoreCase) Then
                Dim valorIngresado As String = e.FormattedValue.ToString().Trim()
                Dim cantidadNC As Decimal

                ' Validación básica
                If String.IsNullOrWhiteSpace(valorIngresado) OrElse Not Decimal.TryParse(valorIngresado, cantidadNC) OrElse cantidadNC < 0 Then
                    MsgBox("Cantidad debe ser un valor mayor que cero", vbCritical, "SiCoFa")
                    e.Cancel = True
                    Exit Sub
                End If

                ' Obtener cantidades
                Dim fila As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
                Dim cantidadA As Decimal = 0
                Dim cantidadF As Decimal = 0

                Decimal.TryParse(fila.Cells("CantidadA").Value?.ToString(), cantidadA)
                Decimal.TryParse(fila.Cells("CantidadF").Value?.ToString(), cantidadF)

                Dim maxPermitido As Decimal = cantidadF - cantidadA

                ' Si excede el máximo, marcar para corrección
                If cantidadNC > maxPermitido Then
                    MsgBox("La cantidad NC no puede ser mayor que " & maxPermitido, vbCritical, "SiCoFa")
                    ajustarCantidad = True
                    valorMaximo = maxPermitido
                Else
                    ajustarCantidad = False
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
        End Try
    End Sub

    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        Try
            If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
                Dim nombreColumnaEditada As String = DataGridView1.Columns(e.ColumnIndex).Name

                If nombreColumnaEditada.Equals("CantidadNC", StringComparison.OrdinalIgnoreCase) Then
                    ' ✅ Aplicar corrección acá (NO en CellValidating)
                    If ajustarCantidad Then
                        DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = valorMaximo
                        ajustarCantidad = False
                    End If

                    ' Actualizar totales
                    If String.IsNullOrEmpty(DataGridView1.Rows(e.RowIndex).ErrorText) Then
                        Dim itemComprobante As ItemComprobanteNC = mobj_ItemsComprobanteOrigen(e.RowIndex)
                        Me.DataGridView1.Refresh()
                        Me.ActualizarTotales()
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
        End Try
    End Sub

    Private Sub FinalizarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuFinalizar.Click

        Me.Guardar()

    End Sub

    Private Sub chkAcreditarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chkAcreditarTodo.CheckedChanged

        If chkAcreditarTodo.Checked Then
            Me.AcreditacionCompleta()
        Else
            Me.PonerEnCeroCantNC()
        End If
    End Sub

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub
End Class
