Imports SiCoFa.Negocio
Imports SiCoFa.Entidades
Imports System.ComponentModel
Public Class FrmOperacionesCC
    Property Usuario As Usuario
    Property Resumen As String

    Private mobjAdminDB As New N_AdminDB
    Private mobjAdminOperaciones As New N_AdminOperaciones
    Private mobjTOperacion As TipoOperacion
    Private mobjCuentaCorriente As CuentaCorriente
    Private mdecSaldoCC As Decimal = 0
    Private mdecSaldoResumen As Decimal = 0
    Private DatosOpcionales As New List(Of String) From {"txtObservaciones"}
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
        Me.txtResumenImputado.Enabled = True
        Me.txtImporte.Enabled = True
        Me.LimpiarFormulario()
    End Sub

    Public Sub IniciarCancelacionCuentaCorriente(Optional ByVal argCuentaCorriente As CuentaCorriente = Nothing)
        If argCuentaCorriente IsNot Nothing Then
            mobjCuentaCorriente = argCuentaCorriente
            Me.txtCuentaCorriente.Tag = argCuentaCorriente.IdCC
            Me.txtCuentaCorriente.Text = argCuentaCorriente.Descripcion
            Me.txtOperacion.Enabled = False
            Me.txtCuentaCorriente.Enabled = False
        End If

        If mobjCuentaCorriente Is Nothing Then
            MsgBox("Cuenta Corriente no establecida", vbCritical, "SiCoFa")
            Exit Sub
        End If

        mobjTOperacion = mobjAdminOperaciones.ObtenerTipoOperacionPorCodiTO("CCC")
        Me.txtOperacion.Tag = "CCC"
        Me.txtOperacion.Text = mobjTOperacion.TipoOperacion
        mdecSaldoCC = mobjAdminDB.ObtenerValor($"SELECT Saldo FROM ConSaldosIdCC WHERE IdCC={mobjCuentaCorriente.IdCC}")

        If mdecSaldoCC = 0 Then
            MsgBox("El Saldo de la Cuenta es $0,00")
            Me.LimpiarFormulario()
            Exit Sub
        End If

        Me.txtResumenImputado.Text = "0000"
        Me.txtResumenImputado.Enabled = False
        Me.txtImporte.Text = mdecSaldoCC.ToString("N2")
        Me.txtImporte.Enabled = False

    End Sub

    Public Sub IniciarCancelacionResumen()

        If mobjCuentaCorriente Is Nothing Then
            MsgBox("Cuenta Corriente no establecida", vbCritical, "SiCoFa")
            Exit Sub
        End If

        If Me.Resumen = "" Then
            MsgBox("Resumen no establecido", vbCritical, "SiCoFa")
            Exit Sub
        End If

        mobjTOperacion = mobjAdminOperaciones.ObtenerTipoOperacionPorCodiTO("CRC")
        Me.txtOperacion.Tag = "CRC"
        Me.txtOperacion.Text = mobjTOperacion.TipoOperacion
        mdecSaldoCC = mobjAdminDB.ObtenerValor($"SELECT Saldo FROM ConSaldosIdCC WHERE IdCC={mobjCuentaCorriente.IdCC}")
        mdecSaldoResumen = mobjAdminDB.ObtenerValor($"SELECT Saldo FROM ConSaldosIdCCResu WHERE IdCC={mobjCuentaCorriente.IdCC} And Resu='{Me.Resumen}'")

        If Me.Resumen <> "" AndAlso mdecSaldoResumen <= 0 Then
            MsgBox("El saldo del resumen ingresado es $" & mdecSaldoResumen, vbInformation, "SiCoFa")
            Me.txtResumenImputado.Text = ""
            Me.Resumen = ""
            Me.txtResumenImputado.Focus()
            Exit Sub
        End If

        Me.txtResumenImputado.Text = Me.Resumen
        Me.txtImporte.Text = mdecSaldoResumen.ToString("N2")
        Me.txtImporte.Enabled = False

    End Sub

    Private Sub BuscarOperacion(ByVal argTextoBuscado As String)
        Try

            Dim sql As String = "SELECT CodiTO,TipoOperacion,EfInv,AfectaCajaAbierta,EfFin FROM TblTipoOperaciones WHERE (CodiTO='CCC' OR CodiTO='CRC' OR CodiTO='PCC') AND TipoOperacion LIKE '" & Replace(argTextoBuscado, " ", "%") & "%'"
            Dim dt As DataTable = mobjAdminDB.ObtenerTabla(sql)
            Me.ReiniciarFormulario()

            Select Case dt.Rows.Count
                Case 0
                    MsgBox("Operación no Encontrada", vbInformation, "SiCoFa")
                    mobjTOperacion = Nothing
                    txtOperacion.Text = ""
                    txtOperacion.Focus()

                Case 1
                    Dim fila As DataRow = dt.Rows(0)
                    Dim codiTO As String = fila("CodiTO").ToString
                    mobjTOperacion = mobjAdminOperaciones.ObtenerTipoOperacionPorCodiTO(codiTO)

                Case > 1

                    Using f As New FrmSelectorUniversal
                        f.Text = "Operaciones"
                        f.Objetos = dt.DefaultView
                        f.NombrePropiedadId = "CodiTO"
                        f.NombrePropiedadDescripcion = "TipoOperacion"
                        f.HeaderPropiedadDescripcion = "Operacion"

                        If f.ShowDialog() = DialogResult.OK Then
                            Dim codiTO As String = f.Valor1Seleccionado.ToString
                            mobjTOperacion = mobjAdminOperaciones.ObtenerTipoOperacionPorCodiTO(codiTO)

                        Else
                            Me.txtOperacion.Tag = ""
                            Me.txtOperacion.Text = ""
                            Me.txtOperacion.Select()
                            mobjTOperacion = Nothing

                        End If

                        f.Close()

                    End Using

            End Select

            If mobjTOperacion IsNot Nothing Then
                Me.txtOperacion.Tag = mobjTOperacion.CodiTO
                Me.txtOperacion.Text = mobjTOperacion.TipoOperacion
            Else
                Me.ReiniciarFormulario()
            End If

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

            If lc Is Nothing Then
                MsgBox("Cuenta no Encontrada", vbInformation, "SiCoFa")
                Me.txtCuentaCorriente.Tag = ""
                Me.txtCuentaCorriente.Text = ""
                Me.txtCuentaCorriente.Select()
                mobjCuentaCorriente = Nothing
                Exit Sub
            End If

            Select Case lc.Count
                Case 0
                    MsgBox("Cuenta no Encontrada", vbInformation, "SiCoFa")
                    Me.txtCuentaCorriente.Tag = ""
                    Me.txtCuentaCorriente.Text = ""
                    Me.txtCuentaCorriente.Select()
                    mobjCuentaCorriente = Nothing
                    Exit Sub

                Case 1
                    mobjCuentaCorriente = lc.First

                Case > 1
                    Using f As New FrmBuscaCtasCorrriente
                        f.CuentasCorriente = lc
                        f.ShowDialog()

                        If f.DialogResult = DialogResult.OK Then
                            mobjCuentaCorriente = f.CuentaSeleccionada

                        Else
                            Me.txtCuentaCorriente.Tag = ""
                            Me.txtCuentaCorriente.Text = ""
                            Me.txtCuentaCorriente.Select()
                            mobjCuentaCorriente = Nothing
                            Exit Sub
                        End If
                        f.Close()
                    End Using

            End Select

            With Me
                .txtCuentaCorriente.Tag = mobjCuentaCorriente.IdCC
                .txtCuentaCorriente.Text = mobjCuentaCorriente.Descripcion
                .mdecSaldoCC = mobjAdminDB.ObtenerValor($"SELECT Saldo FROM ConSaldosIdCC WHERE IdCC={mobjCuentaCorriente.IdCC}")
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
                    Me.txtImporte.Text = mdecSaldoCC.ToString("N2")
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

            Dim dt As DataTable = mobjAdminDB.ObtenerTabla(sql)

            Select Case dt.Rows.Count
                Case 0
                    MsgBox("Resumen no Encontrada", vbInformation, "SiCoFa")
                    Me.txtResumenImputado.Text = ""
                    Me.txtResumenImputado.Focus()
                    Me.Resumen = ""
                    Exit Sub

                Case 1
                    Dim fila As DataRow = dt.Rows(0)
                    Dim resu As String = fila("Resu").ToString
                    Me.Resumen = resu

                Case > 1

                    Using f As New FrmSelectorUniversal
                        f.Text = "Períodos con Saldo"
                        f.Objetos = dt.DefaultView
                        f.NombrePropiedadId = "Resu"
                        f.NombrePropiedadDescripcion = "ResuImporte"
                        f.HeaderPropiedadDescripcion = "Resumen        Importe"

                        If f.ShowDialog() = DialogResult.OK Then
                            Dim resu As String = f.Valor1Seleccionado.ToString
                            Me.Resumen = resu

                        Else
                            Me.txtResumenImputado.Text = ""
                            Me.Resumen = ""
                            Me.txtResumenImputado.Select()
                            Exit Sub
                        End If
                        f.Close()
                    End Using

            End Select

            With Me
                .txtResumenImputado.Text = Me.Resumen
            End With

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

            mdecSaldoResumen = mobjAdminDB.ObtenerValor($"SELECT Saldo FROM ConSaldosIdCCResu WHERE IdCC={mobjCuentaCorriente.IdCC} AND Resu='{Me.Resumen}'")

            If Me.Resumen <> "" AndAlso mdecSaldoResumen <= 0 Then
                MsgBox("El saldo del resumen ingresado es $" & mdecSaldoResumen, vbInformation, "SiCoFa")
                Me.txtResumenImputado.Text = ""
                Me.Resumen = ""
                Me.txtResumenImputado.Focus()
                Exit Sub
            End If

            Select Case Me.txtOperacion.Tag
                Case "CRC"
                    Me.txtImporte.Text = mdecSaldoResumen
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

    Private Sub txtImporte_Validating(sender As Object, e As CancelEventArgs) Handles txtImporte.Validating

        Try

            Dim importe As Decimal = 0

            If Decimal.TryParse(txtImporte.Text, importe) Then
                Me.txtImporte.Text = importe.ToString("N2") ' Formato con 2 decimales, con separador de miles
            End If

            If importe = 0 Then
                MsgBox("Debe ingresar un valor numérico válido.", vbExclamation, "Validación")
                Me.txtImporte.Text = ""
                Me.txtImporte.Focus()
                Exit Sub
            End If

            If importe >= mdecSaldoCC Then

                If MsgBox("El Importe Total adeudado es $ " & mdecSaldoCC.ToString("N2") & vbCrLf & "¿Desea Realizar una Cancelacion Total de la Cuenta Corriente?", vbYesNo, "SiCoFa") = vbYes Then
                    Me.IniciarCancelacionCuentaCorriente()
                    Exit Sub
                Else
                    Me.txtImporte.Text = ""
                    Me.txtImporte.Focus()
                    Exit Sub
                End If

            ElseIf importe > mdecSaldoResumen Then

                If MsgBox("El importe ingresado es mayor que el Importe del Resumen" & vbCrLf & "¿Desea Cancelar el Resumen " & Me.txtResumenImputado.Text & "?", vbYesNo, "SiCoFa") = vbYes Then
                    mobjTOperacion = mobjAdminOperaciones.ObtenerTipoOperacionPorCodiTO("CRC")
                    Me.txtOperacion.Tag = "CRC"
                    Me.txtOperacion.Text = mobjTOperacion.TipoOperacion
                    importe = mdecSaldoResumen
                    Me.txtImporte.Text = importe.ToString("N2")
                    Me.txtImporte.Enabled = False
                    Exit Sub

                Else
                    Me.txtImporte.Text = ""
                    Me.txtImporte.Focus()
                    Exit Sub
                End If

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

            Using FPagos As New FrmPagos
                Dim AdminComprobantes As New N_AdminComprobantes
                With FPagos
                    .Operacion = New Operacion(0, Now, Now, Nothing, "", 0, Me.Usuario, mobjTOperacion, "", Me.txtObservaciones.Text, "")

                    Dim AdminClientes As New N_AdminClientes
                    .Cliente = AdminClientes.ObtenerClientePorId(mobjCuentaCorriente.IdCliente)

                    Dim tc As TipoComprobante = AdminComprobantes.ObtenerTipoComprobantePorCodiTC("REC")
                    .TipoComprobante = tc

                    Dim importe As Decimal = Convert.ToDecimal(Me.txtImporte.Text)

                    .OperacionCC = New OperacionCC(0, mobjCuentaCorriente.IdCC, Me.Resumen, importe, "", 0)
                    .ImporteBruto = Convert.ToDecimal(importe)
                    .ImporteDescuento = 0
                    .ImporteAPagar = importe
                    .ImporteGravado1 = 0
                    .ImporteGravado2 = 0
                    .ItemsComprobante = Nothing
                    .ShowDialog()
                End With
            End Using

            Me.ReiniciarFormulario()

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