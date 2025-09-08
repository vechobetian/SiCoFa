Imports SiCoFa.Negocio
Imports SiCoFa.Entidades
Imports System.ComponentModel
Public Class FrmIngresoMomientosCB

    Private Const WM_SYSCOMMAND As Integer = &H112
    Private Const SC_CLOSE As Integer = &HF060

    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.Msg = WM_SYSCOMMAND AndAlso (m.WParam.ToInt32() And &HFFF0) = SC_CLOSE Then
            ' El usuario hizo clic en la X → desactivamos validación
            Me.AutoValidate = AutoValidate.Disable
        End If
        MyBase.WndProc(m)
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
                Me.txtCuentaBancaria.Text = ""
                Me.txtCuentaBancaria.Select()
                Exit Sub
            End If

            Select Case lcb.Count
                Case 0
                    MsgBox("Cuenta no Encontrada", vbInformation, "SiCoFa")
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
                            Me.txtCuentaBancaria.Tag = ""
                            Me.txtCuentaBancaria.Text = ""
                            Me.txtCuentaBancaria.Select()
                            Exit Sub

                        End If
                        f.Close()
                    End Using ' <- aquí se libera completamente
            End Select

            Me.txtCuentaBancaria.Tag = cb.IdCB
            Me.txtCuentaBancaria.Text = cb.Descripcion

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub txtCuenaBancaria_Validating(sender As Object, e As CancelEventArgs) Handles txtCuentaBancaria.Validating
        Try

            Me.BuscarCuentaBancaria(Me.txtCuentaBancaria.Text)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try
    End Sub

    Private Sub txtResumen_Validating(sender As Object, e As CancelEventArgs) Handles txtResumen.Validating
        Try

            If String.IsNullOrEmpty(Me.txtResumen.Text) Then
                Exit Sub
            End If

            If Strings.Len(Me.txtResumen.Text) <> 4 Then
                MsgBox("Formato incorrecto para Resumen", vbCritical, "SiCoFa")
                Me.txtResumen.Text = ""
                Me.txtResumen.Focus()
                e.Cancel = True
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try
    End Sub

    Private Sub btnMostrarComprobantes_Click(sender As Object, e As EventArgs) Handles btnMostrarComprobantes.Click

        If Me.txtCuentaBancaria.Tag Is Nothing Then
            MsgBox("No se estableció ninguna Cuenta Corriente válida", vbCritical, "SiCoFa")
            Exit Sub
        End If

        Dim resu As String = Me.txtResumen.Text

        Dim sql As String = ""
        Dim cc As CuentaCorriente = Nothing

        If txtCuentaBancaria.Tag IsNot Nothing Then
            cc = DirectCast(txtCuentaBancaria.Tag, CuentaCorriente)
        Else
            MsgBox("No se pudo establecer la cuenta corriente", vbCritical, "SiCoFa")
            Me.txtCuentaBancaria.Text = ""
        End If

        If resu = "" Then

            If CheckBox1.Checked Then
                sql = $"SELECT IdOperacion,Operacion,CodiTO, CodiTC,  Resu, Comprobante, FechaComp, NumComp, Importe, ComprobanteAsociado, EstadoOperacionCC, Observaciones FROM vw_movimientos_cc WHERE IdCC={cc.IdCC}"
            Else
                sql = $"SELECT IdOperacion,Operacion,CodiTO, CodiTC,  Resu, Comprobante, FechaComp,  NumComp, Importe, ComprobanteAsociado, EstadoOperacionCC, Observaciones FROM vw_movimientos_cc WHERE IdCC={cc.IdCC} AND EstadoOperacionCC='NO CANCELADO'"
            End If

        Else

            If CheckBox1.Checked Then
                sql = $"SELECT IdOperacion,CodiTO, CodiTC,  Resu, Comprobante, FechaComp,  NumComp, Importe, ComprobanteAsociado, EstadoOperacionCC, Observaciones FROM vw_movimientos_cc WHERE IdCC={cc.IdCC} AND Resu='{resu}'"
            Else
                sql = $"SELECT IdOperacion,CodiTO, CodiTC,  Resu, Comprobante, FechaComp,  NumComp, Importe, ComprobanteAsociado, EstadoOperacionCC, Observaciones FROM vw_movimientos_cc WHERE IdCC={cc.IdCC} AND Resu='{resu}' AND EstadoOperacionCC='NO CANCELADO'"
            End If

        End If

        With FrmMovimientosCC
            .SQL = sql
            .ResumenSeleccionado = resu
            .CuentaCorriente = cc
            .DescripcionCuentaCorriente = Me.txtCuentaBancaria.Text
        End With

        Me.Close()
        FrmMovimientosCC.Show()
        FrmMovimientosCC.BringToFront()

    End Sub

End Class