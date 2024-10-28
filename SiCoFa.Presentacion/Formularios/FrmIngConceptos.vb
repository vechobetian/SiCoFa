Imports System.IO
Imports SiCoFa.Negocio
Imports SiCoFa.Entidades
'Imports System.ComponentModel
Public Class FrmIngConceptos

    Property IdUsuario As Long

    Private mobj_N_AdminContratos As New cls_N_AdminSiCoFa

    Private mobjContrato As Contrato
    Private mobjOperacion As Operacion

    Private Sub LimpiarTodo()
        With Me
            .mobjContrato = Nothing
            .mobjOperacion = Nothing
            .Cliente.ReadOnly = False
            .Cliente.Text = ""
            .Cliente.Tag = ""
            .ImpPago.Text = ""
            .ImpAnticipos.Text = ""
            .ImpTotalCancelado.Text = ""
            .DataGridView1.Rows.Clear()
        End With
    End Sub
    Private Sub ObtenerContrato(ByVal argIdCliente As Integer)
        Dim c As Contrato = mobj_N_AdminContratos.ObtenerContrato(0, argIdCliente)
        If c Is Nothing Then
            Exit Sub
        End If

        c.Locador = mobj_N_AdminContratos.ObtenerLocadorPorId(c.IdLocador)
        c.OperaContratos = mobj_N_AdminContratos.ListaOperaContratos(0, 0, c.IdContrato, "", "DEBE")
        c.PagosCliente = mobj_N_AdminContratos.ListaPagosCliente(0, c.IdContrato, "ABIERTO")
        Me.mobjContrato = c

    End Sub
    Private Function BuscarCliente(ByVal argTextoBuscado As String) As Cliente
        Dim lc As List(Of Cliente) = mobj_N_AdminContratos.ListarClientes(argTextoBuscado)
        Dim c As Cliente = Nothing

        If lc Is Nothing Then
            MsgBox("Cliente no Encontrado", vbInformation, "SiCoFa")
            Return Nothing
            Exit Function
        End If

        Select Case lc.Count
            Case 0
                MsgBox("No se encontro el Cliente",, "SiCoFa")
                Return Nothing
                Exit Function
            Case 1
                c = lc.First
            Case > 1
                FrmBuscaClientes.Clientes = lc
                FrmBuscaClientes.ShowDialog()

                If FrmBuscaClientes.ClienteSeleccionado Is Nothing Then
                    FrmBuscaClientes.Close()
                    Return Nothing
                    Exit Function
                End If

                c = FrmBuscaClientes.ClienteSeleccionado
                FrmBuscaClientes.Close()
        End Select

        Return c
        c = Nothing

    End Function
    Private Sub DetalleCancelacion()
        Dim ImpDisponible As Decimal = CDec(Me.ImpPago.Text)
        Dim x As Integer
        Me.DataGridView1.Rows.Clear()

        If Me.mobjContrato.OperaContratos Is Nothing Then
            Me.ActualizarTotales()
            Exit Sub
        End If

        Try
            For Each oc In mobjContrato.OperaContratos
                If ImpDisponible > 0 Then
                    If oc.ImpNoCancelado > 0 Then
                        Me.DataGridView1.Rows.Add()
                        With Me.DataGridView1.Rows(x)
                            .Cells(0).Value = oc.IdOperacion
                            .Cells(1).Value = oc.Resu
                            .Cells(2).Value = Format(oc.ImpFacturado, "Standard")

                            If ImpDisponible > oc.ImpNoCancelado Then
                                .Cells(3).Value = Format(oc.ImpNoCancelado, "Standard")
                            Else
                                .Cells(3).Value = Format(ImpDisponible, "Standard")
                            End If

                            ImpDisponible -= .Cells(3).Value

                            mobjContrato.ActualizarSaldoOperacion(oc.IdOperacion, .Cells(3).Value)

                            .Cells(4).Value = Format(mobjContrato.SaldoOperacion(.Cells(0).Value), "Standard")
                        End With
                        x += 1
                    Else
                        Exit For
                    End If
                End If
            Next

            Me.DataGridView1.ClearSelection()
            Me.ActualizarTotales()
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub
    Private Sub ActualizarTotales()
        Dim ImpA As Decimal = Me.ImpPago.Text
        Dim ImpT As Decimal

        For Each dgr As DataGridViewRow In Me.DataGridView1.Rows
            If dgr.Cells(0).Value > 0 Then
                ImpA -= dgr.Cells(3).Value
                ImpT += dgr.Cells(3).Value
            End If
        Next

        Me.ImpAnticipos.Text = Format(ImpA, "Standard")
        Me.ImpTotalCancelado.Text = Format(ImpT, "Standard")
    End Sub
    Private Sub FrmIngPagoClientes_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.ImpAnticipos.Text = Format(0, "Standard")
        Me.ImpTotalCancelado.Text = Format(0, "Standard")
    End Sub
    Private Sub FrmIngPagoClientes_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        e.Cancel = False

    End Sub
    Private Sub Cliente_KeyUp(sender As Object, e As KeyEventArgs) Handles Cliente.KeyUp

        If e.KeyCode = 13 Then
            If Vecho.CCero(Me.Cliente.Tag) > 0 Or Me.Cliente.Text = "" Then
                Exit Sub
            End If

            Dim c As Cliente = BuscarCliente(Me.Cliente.Text)

            If c Is Nothing Then
                Me.Cliente.Text = ""
                Exit Sub
            End If

            Me.Cliente.Tag = c.Id
            Me.Cliente.Text = c.Nombre
            Call ObtenerContrato(c.Id)
            Me.ImpPago.Text = Format(mobjContrato.TotalAdeudado, "Standard")
            Me.ImpPago.Select()
            Me.Cliente.ReadOnly = True

        End If
    End Sub
    Private Sub ImpPago_KeyUp(sender As Object, e As KeyEventArgs) Handles ImpPago.KeyUp
        If e.KeyCode <> 13 Then
            Exit Sub
        End If

        If Me.Cliente.Tag > 0 Then

            Dim e1 As New System.ComponentModel.CancelEventArgs
            Dim s1 As String = Me.ImpPago.Text
            Me.ImpPago_Validating(s1, e1)

        End If

    End Sub
    Private Sub ImpPago_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ImpPago.Validating

        If mobjContrato Is Nothing Then
            Exit Sub
        End If

        If IsNumeric(Me.ImpPago.Text) = False And Me.ImpPago.Text <> "" Then
            MsgBox("El importe ingresado no es correcto", vbCritical, "SiCoFa")
            Me.ImpPago.Select()
            Me.ImpPago.SelectionLength = Len(Me.ImpPago.Text)
            e.Cancel = True
            Exit Sub
        ElseIf Me.ImpPago.Text = "" And mobjContrato.TotalAdeudado > 0 Then
            Me.ImpPago.Text = mobjContrato.TotalAdeudado
        ElseIf Me.ImpPago.Text = "" And mobjContrato.TotalAdeudado = 0 Then
            e.Cancel = True
            Exit Sub
        End If

        Me.ImpPago.Text = Vecho.CDecimal(Me.ImpPago.Text)
        Me.ImpPago.SelectionStart = 0
        Me.ImpPago.SelectionLength = Len(Me.ImpPago.Text)
        Me.DetalleCancelacion()

    End Sub
    Private Sub ActualizarSaldoOperaContrato(ByVal argIdOperacion As Long)
        Dim ImpAplicado As Decimal
        For Each dgr As DataGridViewRow In Me.DataGridView1.Rows
            If dgr.Cells(0).Value = argIdOperacion Then
                ImpAplicado += dgr.Cells(2).Value
            End If
        Next
        mobjContrato.ActualizarSaldoOperacion(argIdOperacion, ImpAplicado)

    End Sub
    Private Sub ActualizarSaldoPago(ByVal argIdOperacion As Long)
        Dim ImpAplicado As Decimal
        For Each Fila As DataGridViewRow In Me.DataGridView1.Rows
            If Fila.Cells(1).Value = argIdOperacion Then
                ImpAplicado += Fila.Cells(2).Value
            End If
        Next
        mobjContrato.ActualizarSaldoPagoCliente(argIdOperacion, ImpAplicado)

    End Sub
    Private Sub Finalizar_Click(sender As Object, e As EventArgs) Handles Finalizar.Click

        Try

            If IsNumeric(Me.ImpPago.Text) = False Then
                MsgBox("El importe ingresado no es correcto",, "SiCoFa")
                Me.ImpPago.Focus()
                Exit Sub
            End If

            Dim objOperaCancel As OperaCancel = mobj_N_AdminContratos.AplicarPagoCliente(Me.IdUsuario, mobjContrato.IdContrato, mobjContrato.GrupoContratos.CodiAE, Me.ImpPago.Text)
            Dim objOpera = New Operacion(objOperaCancel.IdOperacion, Now, mobjContrato.GrupoContratos.CodiAE, "CCC", Me.IdUsuario, "Finalizado", "", "")

            If objOperaCancel.Importe <> CDec(Me.ImpAnticipos.Text) Then
                MsgBox("Existe un error", vbCritical, "SiCoFa")
            End If

            Dim objComp As Comprobante = mobj_N_AdminContratos.InsertarComprobante(objOpera, "REC", Me.ImpPago.Text, 0, 0, 0, 0, 0, 0, 0, 0, Me.ImpPago.Text, 0, 0, 0, mobjContrato.Cliente, mobjContrato.Locador, Nothing, False)
            Dim obj_N_AdminEmail As New cls_N_AdminEmail
            Dim Archivo = "REC-" & objComp.PVenta & "-" & objComp.NumComp & ".pdf"
            Dim Mensaje = "Estimado Cliente, adjunto Recibo de Pago" & vbCrLf & vbCrLf & "Atentamente: " & mobjContrato.Locador.Nombre
            obj_N_AdminEmail.EnviarMail(mobjContrato.Locador.Nombre, mobjContrato.Cliente.Email, "Recibo de Pago", Mensaje, Application.StartupPath & "\Temp\" & Archivo)


            Dim objAsCon As New AsientoContable
            With objAsCon
                .InsertarItem("1.01.01.001", Me.ImpPago.Text)
                If Me.ImpAnticipos.Text > 0 Then
                    .InsertarItem("2.06.01.001", Me.ImpAnticipos.Text)
                End If

                If Me.ImpTotalCancelado.Text > 0 Then
                    .InsertarItem("1.03.01.001", -Me.ImpTotalCancelado.Text)
                End If
            End With
            mobj_N_AdminContratos.EfectuarAsientoContable(objOpera, objAsCon)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

        Me.LimpiarTodo()
        Me.Cliente.Select()

    End Sub

End Class