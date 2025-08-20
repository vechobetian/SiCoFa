Imports SiCoFa.Negocio
Imports SiCoFa.Entidades
Imports System.ComponentModel
Public Class FrmOperacionesCC
    Property Usuario As Usuario

    Private mAdminDB As New N_AdminDB
    Private mTOperacion As TipoOperacion
    Private mIdCC As Int32 = 0
    Private mSaldoCC As Decimal = 0
    Private mSaldoResumen As Decimal = 0
    Private DatosOpcionales As New List(Of String)
    Private Const WM_SYSCOMMAND As Integer = &H112
    Private Const SC_CLOSE As Integer = &HF060

    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.Msg = WM_SYSCOMMAND AndAlso (m.WParam.ToInt32() And &HFFF0) = SC_CLOSE Then
            ' El usuario hizo clic en la X → desactivamos validación
            Me.AutoValidate = AutoValidate.Disable
        End If
        MyBase.WndProc(m)
    End Sub

    Private Sub BuscarOperacion(ByVal argTextoBuscado As String)
        Try

            Dim sql As String = "SELECT CodiTO,TipoOperacion,EfInv,AfectaCajaAbierta,EfFin FROM TblTipoOperaciones WHERE (CodiTO='CCC' OR CodiTO='CRC' OR CodiTO='PCC') AND TipoOperacion LIKE '" & Replace(argTextoBuscado, " ", "%") & "%'"
            Dim dt As DataTable = mAdminDB.ObtenerTabla(sql)

            Select Case dt.Rows.Count
                Case 0
                    MsgBox("Operación no Encontrada", vbInformation, "SiCoFa")
                    Me.txtOperacion.Text = ""
                    Me.txtOperacion.Select()
                    Exit Sub

                Case 1
                    Dim AdminOperaciones As New N_AdminOperaciones
                    Dim fila As DataRow = dt.Rows(0)
                    Dim codiTO As String = fila("CodiTO").ToString
                    Dim top As TipoOperacion = AdminOperaciones.ObtenerTipoOperacionPorCodiTO(codiTO)
                    Me.txtOperacion.Tag = top.CodiTO
                    Me.txtOperacion.Text = top.TipoOperacion
                    Exit Sub

                Case > 1

                    Using f As New FrmSelectorUniversal
                        f.Text = "Operaciones"
                        f.Objetos = dt.DefaultView
                        f.NombrePropiedadId = "CodiTO"
                        f.NombrePropiedadDescripcion = "TipoOperacion"
                        f.HeaderPropiedadDescripcion = "Operacion"

                        If f.ShowDialog() = DialogResult.OK Then
                            Dim AdminOperaciones As New N_AdminOperaciones
                            Dim codiTO As String = f.Valor1Seleccionado.ToString
                            Dim top As TipoOperacion = AdminOperaciones.ObtenerTipoOperacionPorCodiTO(codiTO)
                            Me.txtOperacion.Tag = top.CodiTO
                            Me.txtOperacion.Text = top.TipoOperacion
                            Exit Sub
                        Else
                            Me.txtOperacion.Tag = ""
                            Me.txtOperacion.Text = ""
                            Me.txtOperacion.Select()

                        End If
                        f.Close()

                    End Using

            End Select

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub txtOperacion_Validating(sender As Object, e As CancelEventArgs) Handles txtOperacion.Validating
        Try

            If String.IsNullOrWhiteSpace(Me.txtOperacion.Text) Then
                MsgBox("Operación es una dato requerido", vbCritical, "SiCoFa")
                e.Cancel = True
                Exit Sub
            End If

            Me.BuscarOperacion(Me.txtOperacion.Text)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try
    End Sub

    Private Sub BuscarCuentaCorriente(ByVal argTextoBuscado As String)

        Try
            Dim AdminClientes As New N_AdminClientes
            Dim lc As List(Of CuentaCorriente) = AdminClientes.ListarCuentasCorriente(argTextoBuscado)
            Dim c As CuentaCorriente = Nothing

            If lc Is Nothing Then
                MsgBox("Cuenta no Encontrada", vbInformation, "SiCoFa")
                Me.txtCuentaCorriente.Tag = ""
                Me.txtCuentaCorriente.Text = ""
                Me.txtCuentaCorriente.Select()
                Exit Sub
            End If

            Select Case lc.Count
                Case 0
                    MsgBox("Cuenta no Encontrada", vbInformation, "SiCoFa")
                    Me.txtCuentaCorriente.Tag = ""
                    Me.txtCuentaCorriente.Text = ""
                    Me.txtCuentaCorriente.Select()
                    Exit Sub

                Case 1
                    c = lc.First

                Case > 1
                    Using f As New FrmBuscaCtasCorrriente
                        f.CuentasCorriente = lc
                        f.ShowDialog()

                        If f.DialogResult = DialogResult.OK Then
                            c = f.CuentaSeleccionada

                        Else
                            Me.txtCuentaCorriente.Tag = ""
                            Me.txtCuentaCorriente.Text = ""
                            Me.txtCuentaCorriente.Select()
                            Exit Sub
                        End If
                        f.Close()
                    End Using

            End Select

            With Me
                .txtCuentaCorriente.Tag = c.IdCC
                .txtCuentaCorriente.Text = c.Descripcion
                .mIdCC = c.IdCC
                .mSaldoCC = mAdminDB.ObtenerValor($"SELECT Saldo FROM ConSaldosIdCC WHERE IdCC={c.IdCC}")
            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub txtCuentaCorriente_Validating(sender As Object, e As CancelEventArgs) Handles txtCuentaCorriente.Validating
        Try

            If String.IsNullOrWhiteSpace(Me.txtCuentaCorriente.Text) Then
                MsgBox("Cuenta Corriente es una dato requerido", vbCritical, "SiCoFa")
                e.Cancel = True
                Exit Sub
            End If

            Me.BuscarCuentaCorriente(Me.txtCuentaCorriente.Text)

            Select Case Me.txtOperacion.Tag
                Case "CCC"
                    Me.txtResumenImputado.Text = "0000"
                    Me.txtResumenImputado.Enabled = False
                    Me.txtImporte.Text = Me.mSaldoCC.ToString("N2")
                    Me.txtImporte.Enabled = False

                Case Else
                    Me.txtResumenImputado.Enabled = True
                    Me.txtResumenImputado.Text = ""
                    Me.txtImporte.Enabled = True
                    Me.txtImporte.Text = ""

            End Select

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try
    End Sub

    Private Sub BuscarResumen(ByVal argTextoBuscado As String)
        Try

            Dim idCC As Int32 = 0

            If String.IsNullOrWhiteSpace(Me.txtCuentaCorriente.Text) OrElse String.IsNullOrWhiteSpace(Me.txtCuentaCorriente.Tag) Then
                MsgBox("Cuenta Corriente no establecida", vbCritical, "SiCoFa")
                Me.txtCuentaCorriente.Select()
                Exit Sub

            Else
                idCC = Convert.ToInt32(Me.txtCuentaCorriente.Tag)

            End If

            Dim sql As String = ""

            If argTextoBuscado = "*" Then
                sql = $"SELECT Resu, CONCAT(Resu, ' | ', LPAD(FORMAT(Saldo, 2, 'es_AR'), 12, ' ')) AS ResuImporte From ConSaldosIdCCResu WHERE IdCC={idCC}"

            Else
                sql = $"SELECT Resu, CONCAT(Resu, ' | ', LPAD(FORMAT(Saldo, 2, 'es_AR'), 12, ' ')) AS ResuImporte From ConSaldosIdCCResu WHERE IdCC={idCC} AND Resu LIKE '" & Replace(argTextoBuscado, " ", "%") & "%'"

            End If

            Dim dt As DataTable = mAdminDB.ObtenerTabla(sql)

            Select Case dt.Rows.Count
                Case 0
                    MsgBox("Resumen no Encontrada", vbInformation, "SiCoFa")
                    Me.txtResumenImputado.Text = ""
                    Me.txtResumenImputado.Select()
                    Exit Sub

                Case 1
                    Dim fila As DataRow = dt.Rows(0)
                    Dim resu As String = fila("Resu").ToString
                    Me.txtResumenImputado.Text = resu
                    Exit Sub

                Case > 1

                    Using f As New FrmSelectorUniversal
                        f.Text = "Períodos con Saldo"
                        f.Objetos = dt.DefaultView
                        f.NombrePropiedadId = "Resu"
                        f.NombrePropiedadDescripcion = "ResuImporte"
                        f.HeaderPropiedadDescripcion = "Resumen        Importe"

                        If f.ShowDialog() = DialogResult.OK Then
                            Dim resu As String = f.Valor1Seleccionado.ToString
                            Me.txtResumenImputado.Text = resu

                            Exit Sub
                        Else
                            Me.txtResumenImputado.Text = ""
                            Me.txtResumenImputado.Select()
                        End If
                        f.Close()

                    End Using

            End Select

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub txtResumenImputado_Validating(sender As Object, e As CancelEventArgs) Handles txtResumenImputado.Validating
        Try

            If Me.txtResumenImputado.Enabled = False Then Exit Sub

            If String.IsNullOrWhiteSpace(Me.txtResumenImputado.Text) Then
                MsgBox("Resumen Imputado es una dato requerido", vbCritical, "SiCoFa")
                e.Cancel = True
                Exit Sub
            End If

            Me.BuscarResumen(Me.txtResumenImputado.Text)

            msaldoResumen = mAdminDB.ObtenerValor($"SELECT Saldo FROM ConSaldosIdCCResu WHERE IdCC={mIdCC} AND Resu='{Me.txtResumenImputado.Text}'")

            Select Case Me.txtOperacion.Tag
                Case "CRC"
                    Me.txtImporte.Text = mSaldoResumen
                    Me.txtImporte.Enabled = False

                Case "PCC"
                    Me.txtImporte.Enabled = True
                    Me.txtImporte.Text = ""

            End Select


        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try
    End Sub

    Private Sub txtImporte_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtImporte.KeyPress
        ' Verifica si se presionó el punto
        If e.KeyChar = "."c Then
            ' Reemplaza por coma
            e.KeyChar = ","c
        End If
    End Sub

    Private Sub txtImporte_Validated(sender As Object, e As EventArgs) Handles txtImporte.Validated

        Try

            If txtImporte.Enabled = False Then Exit Sub

            Dim importe As Decimal = 0

            If Decimal.TryParse(txtImporte.Text, importe) Then
                txtImporte.Text = importe.ToString("N2") ' Formato con 2 decimales, con separador de miles

            Else
                MsgBox("Debe ingresar un valor numérico válido.", vbExclamation, "Validación")
                txtImporte.SelectAll()
                txtImporte.Focus()
                Exit Sub
            End If

            If importe > mSaldoCC Then
                MsgBox("El importe ingresado es mayor que el Importe total adeudado", vbInformation, "SiCoFa")
                Me.txtImporte.Text = ""
                Me.txtImporte.Focus()
                Exit Sub

            ElseIf importe > mSaldoResumen Then
                MsgBox("El importe ingresado es mayor que el importe del resumen " & Me.txtResumenImputado.Text, vbInformation, "SiCoFa")
                Me.txtImporte.Text = ""
                Me.txtImporte.Focus()
                Exit Sub

            ElseIf importe = mSaldoCC Then
                Me.txtOperacion.Text = ""

            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub FinalizarOperacion()
        Try


            Me.ValidarCampos(Me, Me.DatosOpcionales)

            If Me.ValidacionOK = False Then
                Exit Sub
            End If

            Dim AdminComprobantes As New N_AdminComprobantes
            Dim objTC As TipoComprobante = AdminComprobantes.ObtenerTipoComprobantePorCodiTC(Me.txtResumenImputado.Tag.ToString)
            Dim AfectaCajaAbierta As Boolean = False
            Dim objOperacionCB As OperacionCB = Nothing
            Dim objOperacionCP As OperacionCP = Nothing
            Dim objAsCon As New AsientoContable
            Dim impCB As Decimal = 0
            Dim impEF As Decimal = 0

            'objAsCon.InsertarItem(Me.txtCuentaImputable.Tag, Convert.ToDecimal(Me.txtImporte.Text))

            'If Me.cmbFPago.Text = "TRANSFERENCIA" Then
            'impCB = Convert.ToDecimal(Me.txtImporte.Text)
            'objOperacionCB = New OperacionCB(0, Me.cmbCajaAbierta.SelectedValue, "", impCB, "INICIADO")
            'objAsCon.InsertarItem("1.01.03.001", -impCB)
            'End If

            'If Me.cmbFPago.Text = "CONTADO" Then
            'AfectaCajaAbierta = Me.cmbCajaAbierta.SelectedValue
            'impEF = Convert.ToDecimal(Me.txtImporte.Text)
            'objAsCon.InsertarItem("1.01.01.001", -impEF)
            'End If

            'If Me.cmbFPago.Text = "CREDITO" Then
            'objOperacionCP = New OperacionCP(0, Me.txtCuentaCorriente.Tag, "", Convert.ToDecimal(Me.txtImporte.Text), "NO CANCELADO", 0)
            'objAsCon.InsertarItem("2.01.01.001", Convert.ToDecimal(Me.txtImporte.Text))
            'Else
            'objOperacionCP = New OperacionCP(0, Me.txtCuentaCorriente.Tag, "", Convert.ToDecimal(Me.txtImporte.Text), "CANCELADO", 0)
            'End If

            Dim objComprobante As New Comprobante(
                                                  argIdOperacion:=0,
                                                  argOperacion:=Nothing,
                                                  argTipoComprobante:=objTC,
                                                  argPVenta:="",
                                                  argNumComp:="",
                                                  argFechaComp:=Now.Date,
                                                  argImpBto:=Convert.ToDecimal(Me.txtImporte.Text),
                                                  argImpDes:=0,
                                                  argImpNeto:=Convert.ToDecimal(Me.txtImporte.Text),
                                                  argImpEx:=0,
                                                  argImpGrav1:=0,
                                                  argImpGrav2:=0,
                                                  argImpCB:=impCB,
                                                  argImpEf:=impEF,
                                                  argImpCC:=0,
                                                  argImpPE:=0,
                                                  argCAE:=Nothing,
                                                  argIdCliente:=Nothing,
                                                  argCliente:=Nothing,
                                                  argIdOperAsoc:=0,
                                                  argCompAsoc:=Nothing,
                                                  argEmpresa:=g_ParametrosTerminal.Empresa,
                                                  argDetalle:=Nothing
                                                  )

            Dim AdminOperacion As New N_AdminOperaciones
            'AdminOperacion.AsientoGastoTransaccion(Me.cmbCajaAbierta.SelectedValue, g_ParametrosTerminal.MacAddress, g_ParametrosTerminal.Empresa, Me.Usuario, objOperacionCP, objOperacionCB, objComprobante, objAsCon, Me.txtObservaciones.Text)

            Dim nuevoAsientoGastos As New FrmOperacionesCC
            nuevoAsientoGastos.Usuario = Me.Usuario
            nuevoAsientoGastos.Show()

            Me.Close()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub brnFinalizar_Click(sender As Object, e As EventArgs) Handles brnFinalizar.Click
        Me.FinalizarOperacion()
    End Sub


    Private Sub FrmAsientoGastos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.AutoValidate = AutoValidate.Disable
    End Sub

End Class