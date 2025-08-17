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
                .LimpiarFormulario()
                .txtCuentaCorriente.Tag = c.IdCC
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

    Private Sub btnMostrarComprobantes_Click(sender As Object, e As EventArgs) Handles btnMostrarComprobantes.Click

        If String.IsNullOrWhiteSpace(Me.txtCuentaCorriente.Tag) Then
            MsgBox("No se estableció ninguna Cuenta Corriente válida", vbCritical, "SiCoFa")
            Exit Sub
        End If

        Dim resu As String

        resu = Strings.Replace(Me.mtxtResu.Text, "/", "").Trim

        Dim sql As String = ""
        Dim idCC As Int32 = 0

        If txtCuentaCorriente.Tag IsNot Nothing AndAlso IsNumeric(txtCuentaCorriente.Tag) Then
            IdCC = Convert.ToInt32(txtCuentaCorriente.Tag)
        End If

        If resu = "" Then
            sql = $"SELECT IdOperacion, CodiTC, IdOperAsoc, Resu, TipoComprobante, FechaComp, PVenta, NumComp, Importe, ComprobanteAsociado, EstadoOperacionCC, Observaciones FROM ConMovimientosCC WHERE IdCC={idCC}"

        Else
            sql = $"SELECT IdOperacion, CodiTC, IdOperAsoc, Resu, TipoComprobante, FechaComp, PVenta, NumComp, Importe, ComprobanteAsociado, EstadoOperacionCC, Observaciones FROM ConMovimientosCC WHERE IdCC={idCC} AND Resu='{resu}'"

        End If

        With FrmMovimientosCC
            .SQL = sql
            .ResuSeleccionado = resu
            .IdCC = idCC
            .DescripcionCuentaCorriente = Me.txtCuentaCorriente.Text
        End With

        Me.Close()
        FrmMovimientosCC.Show()
        FrmMovimientosCC.BringToFront()

    End Sub

End Class