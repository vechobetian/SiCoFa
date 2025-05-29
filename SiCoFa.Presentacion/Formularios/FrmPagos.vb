Imports SiCoFa.Negocio
Imports SiCoFa.Entidades
Imports System.ComponentModel
Public Class FrmPagos

    Property FrmOrigen As FrmVentas
    Property Operacion As Operacion
    Property Cliente As Cliente
    Property ItemsComprobante As List(Of ItemComprobante)
    Property ImporteAPagar As Decimal
    Property ImporteDescuento As Decimal
    Property ImporteGravado1 As Decimal
    Property ImporteGravado2 As Decimal

    Private mobj_AdminSiCoFa As New cls_N_AdminSiCoFa
    Private mobj_TipoComprobante As TipoComprobante
    Private MediosDePago As clsMediosPagoBinding

    Private Sub ActualizarClienteMostrado()
        Me.lblNombreCliente.Text = Me.Cliente.Nombre
        Me.lblTipoContribuyente.Text = Me.Cliente.IVA.TipoIVA

        Me.lblTipoDocumento.Text = Me.Cliente.Documento.TipoDoc.TipoDocumento & ": "
        Me.lblNumeroDocumento.Text = Me.Cliente.Documento.Numero

        If Me.Cliente.CuentaCorriente Is Nothing Then
            Me.txtImporteCuentaCorriente.Enabled = False
        Else
            With Me.txtImporteCuentaCorriente
                .Enabled = True
                .Text = Convert.ToDecimal(Me.txtImporteAPagar.Text).ToString("N")
                .Select()
                .SelectAll()
            End With
        End If
    End Sub

    Private Sub ActualizarImporteEfectivo(sender As Object, e As EventArgs)
        txtImporteEfectivo.Text = MediosDePago.ImportePagoEfectivo.ToString("N2")
    End Sub

    Public Function GenerarComprobante() As Comprobante
        Try
            Dim objComprobante = mobj_AdminSiCoFa.InsertarComprobante(
                                                                        argOperacion:=Operacion,
                                                                        argCodiTC:=mobj_TipoComprobante.CodiTC_SiCoFa,
                                                                        argImpBto:=Me.ImporteAPagar,
                                                                        argImpDes:=ImporteDescuento,
                                                                        argImpEx:=0,
                                                                        argImpGrav1:=ImporteGravado1,
                                                                        argImpGrav2:=ImporteGravado2,
                                                                        argImpCB:=0,
                                                                        argImpEf:=Me.MediosDePago.ImportePagoEfectivo,
                                                                        argImpCC:=Me.MediosDePago.ImporteCuentaCorriente,
                                                                        argImpTar:=Me.MediosDePago.ImportePagoElectronico,
                                                                        argIdOperAsoc:=0,
                                                                        argCliente:=Cliente,
                                                                        argEmpresa:=g_ParametrosTerminal.Empresa,
                                                                        argDetalle:=ItemsComprobante,
                                                                        argFiscal:="E"
                                                                        )

            Dim objFE As New clsFacturaElectronica
            Dim Actualizado As Boolean = objFE.GenerarFacturaElectronica(objComprobante)
            Return objComprobante

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
            Return Nothing

        End Try

    End Function

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData
            Case Keys.Escape
                Me.DialogResult = DialogResult.Cancel
                Me.Close()

            Case Keys.F10, Keys.F9
                Me.FinalizarOperacion()

            Case Else
                Return MyBase.ProcessCmdKey(msg, keyData)
        End Select
        Return True ' Asegúrate de devolver True para que la tecla se procese correctamente
    End Function

    Private Sub FrmPagos_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Me.MediosDePago = New clsMediosPagoBinding(Me.ImporteAPagar)
        Me.mobj_TipoComprobante = mobj_AdminSiCoFa.ObtenerTipoComprobanteVenta(Me.Operacion.Empresa.IVA.CodIVA, Me.Cliente.IVA.CodIVA)
        Me.txtTipoComprobante.Text = $"{mobj_TipoComprobante.TipoComprobante} {mobj_TipoComprobante.Letra}"
        Me.txtImporteAPagar.Text = Me.ImporteAPagar.ToString("N2")
        Me.txtImporteCuentaCorriente.DataBindings.Add("Text", Me.MediosDePago, "ImporteCuentaCorriente", True, DataSourceUpdateMode.OnPropertyChanged, 0, "N2")
        Me.txtImportePagoElectronico.DataBindings.Add("Text", Me.MediosDePago, "ImportePagoElectronico", True, DataSourceUpdateMode.OnPropertyChanged, 0, "N2")
        Me.txtImporteEfectivo.DataBindings.Add("Text", Me.MediosDePago, "ImportePagoEfectivo", True, DataSourceUpdateMode.Never, 0, "N2")
        AddHandler Me.txtImporteCuentaCorriente.TextChanged, AddressOf ActualizarImporteEfectivo
        AddHandler Me.txtImportePagoElectronico.TextChanged, AddressOf ActualizarImporteEfectivo
        Me.ActualizarClienteMostrado()
        Me.ActualizarImporteEfectivo(Nothing, Nothing)

    End Sub

    Private Sub btnCuentaCorriente_Click(sender As Object, e As EventArgs) Handles btnCuentaCorriente.Click
        Try
            Dim str = InputBox("Ingrese la Persona", "SiCoFa")


            If str = "" Then
                Exit Sub
            End If

            Dim lc As List(Of Cliente) = mobj_AdminSiCoFa.ListarClientes(str)
            Dim c As Cliente = Nothing

            If lc Is Nothing Then
                MsgBox("Cliente no Encontrado", vbInformation, "SiCoFa")
                Exit Sub
            End If

            Select Case lc.Count
                Case 0
                    MsgBox("Cliente no Encontrado", vbInformation, "SiCoFa")
                    Exit Sub

                Case 1
                    c = lc.First

                Case > 1
                    Using f As New FrmBuscaPersonas
                        f.Personas = lc
                        f.ShowDialog()
                        If f.DialogResult = DialogResult.OK Then
                            Dim p As Persona = f.PersonaSeleccionado
                            c = Me.SeleccionarClienteListado(p.Id, lc)
                        End If
                        f.Close()
                    End Using

            End Select

            If c Is Nothing Then
                Exit Sub
            End If
            If c.CuentaCorriente Is Nothing Then
                MsgBox("El cliente seleccionado no tiene Cuenta Corriente", vbInformation, "SiCoFa")
                Exit Sub
            End If

            Me.Cliente = c
            FrmOrigen.Cliente = c
            Me.ActualizarClienteMostrado()
            Me.txtImporteCuentaCorriente.Enabled = True
            Me.txtImporteCuentaCorriente.Text = Convert.ToDecimal(Me.txtImporteAPagar.Text).ToString("N")
            Me.txtImporteCuentaCorriente.SelectAll()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try
    End Sub

    Private Function SeleccionarClienteListado(ByVal Id As Int32, ByVal ListaClientes As List(Of Cliente)) As Cliente

        Try
            Dim ClienteSeleccionado As Cliente = Nothing

            For Each c As Cliente In ListaClientes
                If c.Id = Id Then
                    Dim objCC As CuentaCorriente = mobj_AdminSiCoFa.ObtenerCuentaCorrientePorIdCliente(c.Id)
                    If objCC IsNot Nothing Then
                        c.CuentaCorriente = objCC
                    End If

                    ClienteSeleccionado = c

                    Exit For ' Opcional: detener la búsqueda una vez encontrado el cliente
                End If
            Next
            Return ClienteSeleccionado

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
            Return Nothing
        End Try

    End Function

    Private Sub FinalizarOperacion()

        If Convert.ToDecimal(Me.txtImporteCuentaCorriente.Text) > 0 Then

            If Me.Cliente.CuentaCorriente Is Nothing Then
                MsgBox("El cliente seleccionado no tiene Cuenta Corriente", vbCritical, "SiCoFa")
                Me.txtImporteCuentaCorriente.Text = "0,00"
                Me.txtImportePagoElectronico.Select()
                Me.txtImportePagoElectronico.SelectAll()
                Me.txtImporteCuentaCorriente.Enabled = False
                Exit Sub
            End If

            Dim Actualizado As Boolean = mobj_AdminSiCoFa.InsertarOperacionCC(Me.Operacion.IdOperacion, Me.Cliente.CuentaCorriente.IdCC, Convert.ToDecimal(Me.txtImporteCuentaCorriente.Text))
        End If

        Dim ComprobanteGenerado As Comprobante = Me.GenerarComprobante()
        mobj_AdminSiCoFa.FinalizarOperacion(g_ParametrosTerminal.MacAddress, ComprobanteGenerado.Operacion)
        If ComprobanteGenerado.CAE IsNot Nothing Then
            MsgBox($"NumComp: {ComprobanteGenerado.NumComp} CAE:{ComprobanteGenerado.CAE.NumCAE}")
        End If

        Dim nuevaVentanaVentas As New FrmVentas()
        nuevaVentanaVentas.Usuario = ComprobanteGenerado.Operacion.Usuario
        nuevaVentanaVentas.Show()

        Me.FrmOrigen.Close()
        Me.Close()

    End Sub

    Private Sub btnFinalizar_Click(sender As Object, e As EventArgs) Handles btnFinalizar.Click
        Me.FinalizarOperacion()
    End Sub

    Private Sub txtImporteCuentaCorriente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtImporteCuentaCorriente.KeyPress
        ' Verifica si se presionó el punto
        If e.KeyChar = "."c Then
            ' Reemplaza por coma
            e.KeyChar = ","c
        End If
    End Sub

    Private Sub txtImportePagoElectronico_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtImportePagoElectronico.KeyPress
        ' Verifica si se presionó el punto
        If e.KeyChar = "."c Then
            ' Reemplaza por coma
            e.KeyChar = ","c
        End If
    End Sub

    Private Sub txtImporteCuentaCorriente_Validating(sender As Object, e As CancelEventArgs) Handles txtImporteCuentaCorriente.Validating
        If Convert.ToDecimal(Me.txtImporteEfectivo.Text) < 0 Then
            MsgBox("El importe ingresado es mayor que el Importe a Pagar", vbCritical, "SiCoFa")
            Me.txtImporteCuentaCorriente.Text = Me.ImporteAPagar
            Me.txtImporteCuentaCorriente.Select()
            Me.txtImporteCuentaCorriente.SelectAll()
            e.Cancel = True
        End If
    End Sub

    Private Sub txtImportePagoElectronico_Validating(sender As Object, e As CancelEventArgs) Handles txtImportePagoElectronico.Validating
        If Convert.ToDecimal(Me.txtImporteEfectivo.Text) < 0 Then
            MsgBox("El importe ingresado es mayor que el Importe a Pagar", vbCritical, "SiCoFa")
            Me.txtImportePagoElectronico.Text = Me.ImporteAPagar
            Me.txtImportePagoElectronico.Select()
            Me.txtImportePagoElectronico.SelectAll()
            e.Cancel = True
        End If
    End Sub

End Class