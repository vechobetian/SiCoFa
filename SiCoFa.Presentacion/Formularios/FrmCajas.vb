Imports System.Globalization
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

            Dim sql As String = "SELECT * FROM cajas ORDER BY IdCaja"
            Dim cajas As DataTable = mAdminDB.ObtenerTabla(sql)
            Me.DataGridView1.DataSource = cajas

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

    Private Sub DetalleEF_Click(sender As Object, e As EventArgs) Handles mnuDetalleEF.Click

        If Me.DataGridView1.CurrentRow Is Nothing Then Exit Sub

        Dim valor = Me.DataGridView1.CurrentRow.Cells(0).Value

        If valor Is Nothing OrElse Not IsNumeric(valor) Then Exit Sub

        Dim idCaja As Integer = CInt(valor)
        FrmMoviCajaEFDetalle.IdCaja = idCaja
        FrmMoviCajaEFDetalle.Show()

    End Sub

    Private Sub DetallePE_Click(sender As Object, e As EventArgs) Handles mnuDetallePE.Click

        If Me.DataGridView1.CurrentRow Is Nothing Then Exit Sub

        Dim valor = Me.DataGridView1.CurrentRow.Cells(0).Value

        If valor Is Nothing OrElse Not IsNumeric(valor) Then Exit Sub

        Dim idCaja As Integer = CInt(valor)
        FrmMoviCajaPEDetalle.IdCaja = idCaja
        FrmMoviCajaPEDetalle.Show()

    End Sub

    Private Sub DetalleCC_Click(sender As Object, e As EventArgs) Handles mnuDetalleCC.Click

        If Me.DataGridView1.CurrentRow Is Nothing Then Exit Sub

        Dim valor = Me.DataGridView1.CurrentRow.Cells(0).Value

        If valor Is Nothing OrElse Not IsNumeric(valor) Then Exit Sub

        Dim idCaja As Integer = CInt(valor)
        FrmMoviCajaCCDetalle.IdCaja = idCaja
        FrmMoviCajaCCDetalle.Show()

    End Sub

    Private Sub mnuCierreCaja_Click(sender As Object, e As EventArgs) Handles mnuCierreCaja.Click
        Try

            Dim User As Usuario = ModSeguridad.ValidarUsuario("CIERRE_CAJA")
            If User Is Nothing Then
                Exit Sub
            End If

            If Me.DataGridView1.CurrentRow.Cells("Estado").Value = "CERRADA" Then
                MsgBox("La caja seleccionada esta cerrada", vbInformation, "SiCoFa")
                Exit Sub
            End If

            Dim objCliente As New Cliente(0, "", "", "", "", "", "", "", "", Date.Now, "", "")
            Dim AdminComprobantes As New N_AdminComprobantes
            Dim objTC As TipoComprobante = AdminComprobantes.ObtenerTipoComprobantePorCodiTC("DI")
            Dim objComprobante As New Comprobante(argIdOperacion:=0,
                                                  argOperacion:=Nothing,
                                                  argTipoComprobante:=objTC,
                                                  argPVenta:="",
                                                  argNumComp:="",
                                                  argFechaComp:=Nothing,
                                                  argImpBto:=mdecImporteEf + mdecImportePE + mdecImporteCC,
                                                  argImpDes:=0,
                                                  argImpNeto:=0,
                                                  argImpEx:=0,
                                                  argImpGrav1:=0,
                                                  argImpNeto1:=0,
                                                  argImpIVA1:=0,
                                                  argImpGrav2:=0,
                                                  argImpNeto2:=0,
                                                  argImpIVA2:=0,
                                                  argImpCB:=0,
                                                  argImpEf:=mdecImporteEf,
                                                  argImpCC:=mdecImporteCC,
                                                  argImpPE:=mdecImportePE,
                                                  argCAE:=Nothing,
                                                  argIdCliente:=0,
                                                  argCliente:=objCliente,
                                                  argIdOperAsoc:=0,
                                                  argCompAsoc:=Nothing,
                                                  argEmpresa:=Nothing,
                                                  argDetalle:=Nothing)


            Dim IdCaja As Long = Me.DataGridView1.CurrentRow.Cells(0).Value
            Dim Apertura As Date = Me.DataGridView1.CurrentRow.Cells(1).Value
            Dim Cierre As Date = Date.MinValue
            Dim Estado As String = Me.DataGridView1.CurrentRow.Cells(3).Value
            Dim NCaja As String = Me.DataGridView1.CurrentRow.Cells(4).Value
            Dim objCaja As New Caja(IdCaja, Apertura, Cierre, Estado, NCaja)
            Dim AdminCajas As New N_AdminCajas
            AdminCajas.CierreCajaTransaccion(g_ParametrosTerminal.MacAddress, objCaja, g_ParametrosTerminal.Empresa, Me.Usuario, objComprobante)

            Dim sql As String = "SELECT * FROM cajas ORDER BY IdCaja"
            Dim cajas As DataTable = mAdminDB.ObtenerTabla(sql)
            Me.DataGridView1.DataSource = cajas

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

    Private Sub mnuRetiroEfectivo_Click(sender As Object, e As EventArgs) Handles mnuRetiroEfectivo.Click
        Try

            Dim User As Usuario = ModSeguridad.ValidarUsuario("RETIRO_EF_CAJA")
            If User Is Nothing Then
                Exit Sub
            End If

            If Me.DataGridView1.CurrentRow.Cells("Estado").Value = "CERRADA" Then
                MsgBox("La caja seleccionada esta cerrada", vbInformation, "SiCoFa")
                Exit Sub
            End If

            Dim strImporte As String = ""
            Dim Importe As Decimal = 0

            Do
                strImporte = InputBox("Saldo Caja Abierta: $" & Format(mdecImporteEf, "Standard") & vbCrLf & vbCrLf & "Ingrese el Importe a Retirar", "SiCoFa").Trim()

                ' Cancelado o vacío
                If strImporte = "" Then
                    MsgBox("Operación cancelada.", vbInformation, "SiCoFa")
                    Exit Sub
                End If

                ' Convertir punto decimal a coma si corresponde
                If CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator = "," Then
                    strImporte = strImporte.Replace(".", ",")
                End If

                ' Intentar convertir usando configuración local
                If Not Decimal.TryParse(strImporte, NumberStyles.Number, CultureInfo.CurrentCulture, Importe) Then
                    MsgBox("Ingrese un importe numérico válido.", vbCritical, "SiCoFa")
                    Continue Do
                End If

                If Importe <= 0 Then
                    MsgBox("El importe debe ser mayor que cero.", vbCritical, "SiCoFa")
                    Continue Do
                End If

                If Importe > mdecImporteEf Then
                    MsgBox("El importe ingresado es mayor que el saldo en caja.", vbCritical, "SiCoFa")
                    Continue Do
                End If

                Exit Do
            Loop

            If MsgBox("Se registrará un Retiro de Efectivo por un importe de $" & Format(Importe, "Standard"), vbOKCancel + vbDefaultButton2 + vbQuestion, "SiCoFa") = vbCancel Then
                MsgBox("Operación cancelada", vbInformation, "SiCoFa")
                Exit Sub
            End If

            Dim objCliente As New Cliente(0, "", "", "", "", "", "", "", "", Date.Now, "", "")
            Dim AdminComprobantes As New N_AdminComprobantes
            Dim objTC As TipoComprobante = AdminComprobantes.ObtenerTipoComprobantePorCodiTC("DI")

            Dim objComprobante As New Comprobante(
                                                  argIdOperacion:=0,
                                                  argOperacion:=Nothing,
                                                  argTipoComprobante:=objTC,
                                                  argPVenta:="",
                                                  argNumComp:="",
                                                  argFechaComp:=Nothing,
                                                  argImpBto:=Convert.ToDecimal(strImporte),
                                                  argImpDes:=0,
                                                  argImpNeto:=Convert.ToDecimal(strImporte),
                                                  argImpEx:=0,
                                                  argImpGrav1:=0,
                                                  argImpGrav2:=0,
                                                  argImpCB:=0,
                                                  argImpEf:=Convert.ToDecimal(strImporte),
                                                  argImpCC:=0,
                                                  argImpPE:=0,
                                                  argCAE:=Nothing,
                                                  argIdCliente:=objCliente.Id,
                                                  argCliente:=objCliente,
                                                  argIdOperAsoc:=0,
                                                  argCompAsoc:=Nothing,
                                                  argEmpresa:=g_ParametrosTerminal.Empresa,
                                                  argDetalle:=Nothing
                                                  )


            Dim AdminCajas As New N_AdminCajas
            AdminCajas.RetiroEfectivoCajaAbiertaTransaccion(g_ParametrosTerminal.MacAddress, g_ParametrosTerminal.Empresa, Me.Usuario, objComprobante)
            Me.ActualizarOperacionesEfectivo()
            MsgBox("Retiro de efectivo registrado correctamente.", vbInformation, "SiCoFa")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

End Class