Imports SiCoFa.Negocio
Imports SiCoFa.Entidades
Imports System.ComponentModel
Public Class FrmIngresoMomientosCC

    Private Const WM_SYSCOMMAND As Integer = &H112
    Private Const SC_CLOSE As Integer = &HF060

    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.Msg = WM_SYSCOMMAND AndAlso (m.WParam.ToInt32() And &HFFF0) = SC_CLOSE Then
            ' El usuario hizo clic en la X → desactivamos validación
            Me.AutoValidate = AutoValidate.Disable
        End If
        MyBase.WndProc(m)
    End Sub

    Private Sub BuscarCuentaCorriente(ByVal argTextoBuscado As String)

        Try
            Dim AdminClientes As New N_AdminClientes
            Dim lc As List(Of CuentaCorriente) = AdminClientes.ListarCuentasCorriente(argTextoBuscado)
            Dim c As CuentaCorriente = Nothing

            If lc Is Nothing Then
                MsgBox("Cuenta no Encontrada", vbInformation, "SiCoFa")
                Me.txtCuentaCorriente.Tag = Nothing
                Me.txtCuentaCorriente.Text = ""
                Me.txtCuentaCorriente.Select()
                Exit Sub
            End If

            Select Case lc.Count
                Case 0
                    MsgBox("Cuenta no Encontrada", vbInformation, "SiCoFa")
                    Me.txtCuentaCorriente.Tag = Nothing
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
                            Me.txtCuentaCorriente.Tag = Nothing
                            Me.txtCuentaCorriente.Text = ""
                            Me.txtCuentaCorriente.Select()
                            Exit Sub
                        End If
                        f.Close()
                    End Using

            End Select

            With Me
                .LimpiarFormulario()
                .txtCuentaCorriente.Tag = c
                .txtCuentaCorriente.Text = c.Descripcion
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

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try
    End Sub

    Private Sub BuscarResumen(ByVal argTextoBuscado As String)
        Try

            Dim AdminDB As New N_AdminDB
            Dim cc As CuentaCorriente
            Dim resu As String

            If Me.txtCuentaCorriente.Tag Is Nothing Then
                MsgBox("Cuenta Corriente no establecida", vbCritical, "SiCoFa")
                Me.txtCuentaCorriente.Select()
                Exit Sub

            Else
                cc = DirectCast(txtCuentaCorriente.Tag, CuentaCorriente)

            End If

            Dim sql As String = ""

            If argTextoBuscado = "*" Then
                sql = $"SELECT Resu, CONCAT(Resu, '  | ', LPAD(FORMAT(Saldo, 2, 'es_AR'), 12, ' ')) AS ResuImporte From ConSaldosIdCCResu WHERE IdCC={cc.IdCC}"

            Else
                sql = $"SELECT Resu, CONCAT(Resu, '  | ', LPAD(FORMAT(Saldo, 2, 'es_AR'), 12, ' ')) AS ResuImporte From ConSaldosIdCCResu WHERE IdCC={cc.IdCC} AND Resu LIKE '" & Replace(argTextoBuscado, " ", "%") & "%'"

            End If

            Dim dt As DataTable = AdminDB.ObtenerTabla(sql)

            Select Case dt.Rows.Count
                Case 0
                    MsgBox("Resumen no Encontrada", vbInformation, "SiCoFa")
                    Me.txtResumen.Text = ""
                    Me.txtResumen.Focus()
                    Exit Sub

                Case 1
                    Dim fila As DataRow = dt.Rows(0)
                    resu = fila("Resu").ToString

                Case > 1

                    Using f As New FrmSelectorUniversal
                        f.Text = "Períodos con Saldo"
                        f.Objetos = dt.DefaultView
                        f.NombrePropiedadId = "Resu"
                        f.NombrePropiedadDescripcion = "ResuImporte"
                        f.HeaderPropiedadDescripcion = "Resumen   |                        Importe"

                        If f.ShowDialog() = DialogResult.OK Then
                            resu = f.Valor1Seleccionado.ToString

                        Else
                            Me.txtResumen.Text = ""
                            Me.txtResumen.Select()
                            Exit Sub
                        End If
                        f.Close()
                    End Using

            End Select

            With Me
                .txtResumen.Text = resu
            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub txtResumen_Validating(sender As Object, e As CancelEventArgs) Handles txtResumen.Validating
        Try

            If String.IsNullOrEmpty(Me.txtResumen.Text) Then
                Exit Sub
            End If

            Me.BuscarResumen(Me.txtResumen.Text)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try
    End Sub

    Private Sub btnMostrarComprobantes_Click(sender As Object, e As EventArgs) Handles btnMostrarComprobantes.Click

        If Me.txtCuentaCorriente.Tag Is Nothing Then
            MsgBox("No se estableció ninguna Cuenta Corriente válida", vbCritical, "SiCoFa")
            Exit Sub
        End If

        Dim resu As String = Me.txtResumen.Text

        Dim sql As String = ""
        Dim cc As CuentaCorriente = Nothing

        If txtCuentaCorriente.Tag IsNot Nothing Then
            cc = DirectCast(txtCuentaCorriente.Tag, CuentaCorriente)
        Else
            MsgBox("No se pudo establecer la cuenta corriente", vbCritical, "SiCoFa")
            Me.txtCuentaCorriente.Text = ""
        End If

        If resu = "" Then

            If CheckBox1.Checked Then
                sql = $"SELECT IdOperacion,Operacion,CodiTO, CodiTC,  Resu, TipoComprobante, FechaComp, PVenta, NumComp, Importe, ComprobanteAsociado, EstadoOperacionCC, Observaciones FROM ConMovimientosCC WHERE IdCC={cc.IdCC}"
            Else
                sql = $"SELECT IdOperacion,Operacion,CodiTO, CodiTC,  Resu, TipoComprobante, FechaComp, PVenta, NumComp, Importe, ComprobanteAsociado, EstadoOperacionCC, Observaciones FROM ConMovimientosCC WHERE IdCC={cc.IdCC} AND EstadoOperacionCC='NO CANCELADO'"
            End If

        Else

            If CheckBox1.Checked Then
                sql = $"SELECT IdOperacion,CodiTO, CodiTC,  Resu, TipoComprobante, FechaComp, PVenta, NumComp, Importe, ComprobanteAsociado, EstadoOperacionCC, Observaciones FROM ConMovimientosCC WHERE IdCC={cc.IdCC} AND Resu='{resu}'"
            Else
                sql = $"SELECT IdOperacion,CodiTO, CodiTC,  Resu, TipoComprobante, FechaComp, PVenta, NumComp, Importe, ComprobanteAsociado, EstadoOperacionCC, Observaciones FROM ConMovimientosCC WHERE IdCC={cc.IdCC} AND Resu='{resu}' AND EstadoOperacionCC='NO CANCELADO'"
            End If

        End If

        With FrmMovimientosCC
            .SQL = sql
            .ResumenSeleccionado = resu
            .CuentaCorriente = cc
            .DescripcionCuentaCorriente = Me.txtCuentaCorriente.Text
        End With

        Me.Close()
        FrmMovimientosCC.Show()
        FrmMovimientosCC.BringToFront()

    End Sub

End Class