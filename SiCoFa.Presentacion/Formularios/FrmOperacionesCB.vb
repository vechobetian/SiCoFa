Imports SiCoFa.Negocio
Imports SiCoFa.Entidades
Imports System.ComponentModel
Public Class FrmOperacionesCB
    Property Usuario As Usuario

    Private mobjAdminDB As New N_AdminDB
    Private mobjAdminOperaciones As New N_AdminOperaciones
    Private mobjTOperacion As TipoOperacion
    Private mobjCBOrigen As CuentaBancaria
    Private mobjCBDestino As CuentaBancaria
    Private mdecSaldoActualCB As Decimal
    Private DatosOpcionales As New List(Of String) From {"txtCBDestino", "txtObservaciones"}
    Private Const WM_SYSCOMMAND As Integer = &H112
    Private Const SC_CLOSE As Integer = &HF060

    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.Msg = WM_SYSCOMMAND AndAlso (m.WParam.ToInt32() And &HFFF0) = SC_CLOSE Then
            ' El usuario hizo clic en la X → desactivamos validación
            Me.AutoValidate = AutoValidate.Disable
        End If
        MyBase.WndProc(m)
    End Sub

    Private Sub ReiniciarFormulario()
        'Me.txtResumenImputado.Enabled = True
        Me.txtImporte.Enabled = True
        Me.LimpiarFormulario()
    End Sub

    Public Sub RetiroEfectivo(Optional ByVal argCBOrigen As CuentaBancaria = Nothing)
        Try

            If argCBOrigen IsNot Nothing Then
                mobjCBOrigen = argCBOrigen
                Me.txtCBOrigen.Text = argCBOrigen.Descripcion & " Cuenta N°: " & argCBOrigen.NumCuenta
                Me.txtOperacion.Enabled = False
            End If

            If mobjCBOrigen Is Nothing Then
                MsgBox("Cuenta Bancaria no establecida", vbCritical, "SiCoFa")
                Exit Sub
            End If

            mobjTOperacion = mobjAdminOperaciones.ObtenerTipoOperacionPorCodiTO("REFCB")
            Me.txtOperacion.Text = mobjTOperacion.TipoOperacion

            mdecSaldoActualCB = Convert.ToDecimal(mobjAdminDB.ObtenerValor($"SELECT SaldoActual FROM cuentas_bancarias WHERE IdCB={mobjCBOrigen.IdCB}"))

            If mdecSaldoActualCB <= 0 Then
                MsgBox("El Saldo de la Cuenta es $0,00")
                Me.LimpiarFormulario()
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
        End Try

    End Sub

    Public Sub DepositoEfectivo(Optional ByVal argCBOrigen As CuentaBancaria = Nothing)
        Try

            If argCBOrigen IsNot Nothing Then
                mobjCBOrigen = argCBOrigen
                Me.txtCBOrigen.Text = argCBOrigen.Descripcion & " Cuenta N°: " & argCBOrigen.NumCuenta
                Me.txtOperacion.Enabled = False
            End If

            If mobjCBOrigen Is Nothing Then
                MsgBox("Cuenta Bancaria no establecida", vbCritical, "SiCoFa")
                Exit Sub
            End If

            mobjTOperacion = mobjAdminOperaciones.ObtenerTipoOperacionPorCodiTO("DEFCB")
            Me.txtOperacion.Text = mobjTOperacion.TipoOperacion

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
        End Try

    End Sub

    Public Sub TransferenciaCB(Optional ByVal argCBOrigen As CuentaBancaria = Nothing)
        Try

            If argCBOrigen IsNot Nothing Then
                mobjCBOrigen = argCBOrigen
                Me.txtCBOrigen.Text = argCBOrigen.Descripcion & " Cuenta N°: " & argCBOrigen.NumCuenta
                Me.txtOperacion.Enabled = False
            End If

            If mobjCBOrigen Is Nothing Then
                MsgBox("Cuenta Bancaria no establecida", vbCritical, "SiCoFa")
                Exit Sub
            End If

            mobjTOperacion = mobjAdminOperaciones.ObtenerTipoOperacionPorCodiTO("TCB")
            Me.txtOperacion.Text = mobjTOperacion.TipoOperacion
            Me.txtCBDestino.Enabled = True

            mdecSaldoActualCB = Convert.ToDecimal(mobjAdminDB.ObtenerValor($"SELECT SaldoActual FROM cuentas_bancarias WHERE IdCB={mobjCBOrigen.IdCB}"))

            If mdecSaldoActualCB <= 0 Then
                MsgBox("El Saldo de la Cuenta es $0,00")
                Me.LimpiarFormulario()
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
        End Try

    End Sub

    Private Function SeleccionarCuentaBancariaListado(ByVal argIdCB As String, ByVal argLista As List(Of CuentaBancaria)) As CuentaBancaria

        Try
            Dim CBSeleccionada As CuentaBancaria = Nothing

            For Each cb As CuentaBancaria In argLista
                If cb.IdCB = argIdCB Then
                    CBSeleccionada = cb
                    Exit For ' Opcional: detener la búsqueda una vez encontrado el cliente
                End If
            Next

            Return CBSeleccionada

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
            Return Nothing
        End Try

    End Function

    Private Sub BuscarCuentaBancaria(ByVal argTextoBuscado As String)
        Try

            Dim AdminCuentasBancarias As New N_AdminCuentasBancarias
            Dim lcb As List(Of CuentaBancaria) = AdminCuentasBancarias.ListarCuentasBancarias(argTextoBuscado)
            Dim cb As CuentaBancaria = Nothing

            If lcb Is Nothing Then
                MsgBox("Cuenta no Encontrada", vbInformation, "SiCoFa")
                Me.txtCBDestino.Text = ""
                Me.txtCBDestino.Select()
                Exit Sub
            End If

            Select Case lcb.Count
                Case 0
                    MsgBox("Cuenta no Encontrada", vbInformation, "SiCoFa")
                    Me.txtCBDestino.Text = ""
                    Me.txtCBDestino.Select()
                    Exit Sub

                Case 1
                    cb = lcb.First

                Case > 1
                    Using f As New FrmSelectorUniversal
                        f.Text = "Cuentas Bancarias"
                        f.Objetos = lcb
                        f.NombrePropiedadId = "IdCB"
                        f.NombrePropiedadDescripcion = "Descripcion"
                        f.HeaderPropiedadDescripcion = "Cuenta Bancaria"

                        If f.ShowDialog() = DialogResult.OK Then
                            cb = Me.SeleccionarCuentaBancariaListado(f.Valor1Seleccionado, lcb)
                        Else
                            Me.txtCBDestino.Tag = ""
                            Me.txtCBDestino.Text = ""
                            Me.txtCBDestino.Select()
                            Exit Sub

                        End If
                        f.Close()
                    End Using ' <- aquí se libera completamente
            End Select

            mobjCBDestino = cb
            Me.txtCBDestino.Text = cb.Descripcion

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub txtCBDestino_Validating(sender As Object, e As CancelEventArgs) Handles txtCBDestino.Validating
        Try

            Me.BuscarCuentaBancaria(Me.txtCBDestino.Text)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try
    End Sub

    Private Sub mtxtFechaComprobante_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles mtxtFechaComprobante.MaskInputRejected
        Try
            Dim fecha As Date

            ' Si está vacío o incompleto
            If Not mtxtFechaComprobante.MaskCompleted Then
                MsgBox("Debe ingresar una fecha completa.", vbExclamation, "Validación")
                mtxtFechaComprobante.SelectAll()
                mtxtFechaComprobante.Focus()
                Exit Sub
            End If

            ' Validación de fecha válida
            If Date.TryParseExact(mtxtFechaComprobante.Text, "dd/MM/yyyy", Nothing, Globalization.DateTimeStyles.None, fecha) Then
                mtxtFechaComprobante.Text = fecha.ToString("dd/MM/yyyy") ' Normaliza la fecha
            Else
                MsgBox("La fecha ingresada no es válida.", vbExclamation, "Validación")
                mtxtFechaComprobante.SelectAll()
                mtxtFechaComprobante.Focus()
            End If

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

    Private Sub txtImporte_Validating(sender As Object, e As CancelEventArgs) Handles txtImporte.Validating

        Try
            Dim importe As Decimal

            If Decimal.TryParse(txtImporte.Text, importe) Then
                txtImporte.Text = importe.ToString("N2") ' Formato con 2 decimales, con separador de miles
            Else
                MsgBox("Debe ingresar un valor numérico válido.", vbExclamation, "Validación")
                txtImporte.Text = ""
                txtImporte.Focus()
                e.Cancel = True
                Exit Sub
            End If

            If (mobjTOperacion.CodiTO = "REFCB" OrElse mobjTOperacion.CodiTO = "TCB") AndAlso importe > mdecSaldoActualCB Then
                MsgBox("El saldo de la cuenta es $" & mdecSaldoActualCB, vbCritical, "SiCoFa")
                Me.txtImporte.Text = mdecSaldoActualCB.ToString("N2")
                Me.txtImporte.SelectAll()
                Me.txtImporte.Focus()
                e.Cancel = True
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub FinalizarOperacion()
        Try
            Dim str As String = Strings.Replace(Me.txtNumComprobante.Text, "-", "").Trim

            If str = "" Then
                MsgBox("Num.Comprobante es un dato requerido", vbCritical, "SiCoFa")
                Me.txtNumComprobante.Focus()
                Exit Sub
            End If

            str = Strings.Replace(Me.mtxtFechaComprobante.Text, "/", "").Trim

            If str = "" Then
                MsgBox("Fecha Comprobante es un dato requerido", vbCritical, "SiCoFa")
                Me.mtxtFechaComprobante.Focus()
                Exit Sub
            End If

            Me.ValidarCampos(Me, Me.DatosOpcionales)

            If Me.ValidacionOK = False Then
                Exit Sub
            End If

            Dim AdminComprobantes As New N_AdminComprobantes
            Dim objTC As TipoComprobante = AdminComprobantes.ObtenerTipoComprobantePorCodiTC("DI")
            'Dim AfectaCajaAbierta As Boolean = False
            Dim objOperacionCBOrigen As OperacionCB = Nothing
            Dim objOperacionCBDestino As OperacionCB = Nothing
            Dim objAsCon As New AsientoContable
            Dim importe As Decimal = Convert.ToDecimal(Me.txtImporte.Text)

            Select Case mobjTOperacion.CodiTO
                Case "REFCB"
                    objOperacionCBOrigen = New OperacionCB(0, mobjCBOrigen.IdCB, "", -importe, "")

                    With objAsCon
                        .InsertarItem("1.01.01.001", importe)
                        .InsertarItem("1.01.03.001", -importe)
                    End With

                Case "DEFCB"
                    objOperacionCBOrigen = New OperacionCB(0, mobjCBOrigen.IdCB, "", importe, "")

                    With objAsCon
                        .InsertarItem("1.01.03.001", importe)
                        .InsertarItem("1.01.01.001", -importe)
                    End With

                Case "TCB"
                    objOperacionCBOrigen = New OperacionCB(0, mobjCBOrigen.IdCB, "", -importe, "")
                    objOperacionCBDestino = New OperacionCB(0, mobjCBDestino.IdCB, "", importe, "")

            End Select

            Dim objComprobante As New Comprobante(
                                                  argIdOperacion:=0,
                                                  argOperacion:=Nothing,
                                                  argTipoComprobante:=objTC,
                                                  argPVenta:="0000",
                                                  argNumComp:=Strings.Right(txtNumComprobante.Text, 8),
                                                  argFechaComp:=Convert.ToDateTime(Me.mtxtFechaComprobante.Text),
                                                  argImpBto:=Convert.ToDecimal(importe),
                                                  argImpDes:=0,
                                                  argImpNeto:=Convert.ToDecimal(importe),
                                                  argImpEx:=0,
                                                  argImpGrav1:=0,
                                                  argImpGrav2:=0,
                                                  argImpCB:=importe,
                                                  argImpEf:=importe,
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


            mobjAdminOperaciones.OperacionCBTransaccion(g_ParametrosTerminal.MacAddress, g_ParametrosTerminal.Empresa, mobjTOperacion, Me.Usuario, objOperacionCBOrigen, objOperacionCBDestino, objComprobante, objAsCon, Me.txtObservaciones.Text)
            Me.Close()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub brnFinalizar_Click(sender As Object, e As EventArgs) Handles brnFinalizar.Click
        Me.FinalizarOperacion()
    End Sub

    Private Sub FrmMovimientosCB_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.AutoValidate = AutoValidate.Disable
    End Sub

    Private Sub cmbCajaAbierta_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
End Class