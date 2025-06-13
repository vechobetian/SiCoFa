Imports SiCoFa.Negocio
Imports SiCoFa.Entidades
Imports System.ComponentModel
Public Class FrmPagos

    Property FrmOrigen As FrmVentas
    Property Operacion As Operacion
    Property Cliente As Cliente
    Property MedioPE As MedioPE
    Property TipoComprobante As TipoComprobante
    Property ItemsComprobante As List(Of ItemComprobante)
    Property ImporteAPagar As Decimal
    Property ImporteDescuento As Decimal
    Property ImporteGravado1 As Decimal
    Property ImporteGravado2 As Decimal

    Private mobj_AdminSiCoFa As New N_AdminSiCoFa
    Private MediosDePago As MediosPagoBinding

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
                .Text = Convert.ToDecimal(Me.txtImporteAPagar.Text).ToString("N2")
                .Select()
                .SelectAll()
            End With
        End If
    End Sub

    Private Sub ActualizarImporteEfectivo(sender As Object, e As EventArgs)
        txtImporteEfectivo.Text = MediosDePago.ImportePagoEfectivo.ToString("N2")
    End Sub

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

        Me.MediosDePago = New MediosPagoBinding(Me.ImporteAPagar)

        If Me.TipoComprobante Is Nothing Then
            Me.TipoComprobante = mobj_AdminSiCoFa.ObtenerTipoComprobanteVenta(Me.Operacion.Empresa.IVA.CodIVA, Me.Cliente.IVA.CodIVA)
        End If

        Me.txtTipoComprobante.Text = $"{Me.TipoComprobante.TipoComprobante} {Me.TipoComprobante.Letra}"
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
                Me.txtImporteCuentaCorriente.Text = "0,00"
                Me.txtImporteCuentaCorriente.Enabled = False
                Me.txtImporteEfectivo.Select()
                Me.txtImporteEfectivo.SelectAll()
                Exit Sub
            End If

            Me.Cliente = c
            FrmOrigen.Cliente = c
            Me.ActualizarClienteMostrado()
            Me.TipoComprobante = mobj_AdminSiCoFa.ObtenerTipoComprobanteVenta(Me.Operacion.Empresa.IVA.CodIVA, Me.Cliente.IVA.CodIVA)
            Me.txtImporteCuentaCorriente.Enabled = True
            Me.txtImporteCuentaCorriente.Text = Convert.ToDecimal(Me.MediosDePago.ImportePagoEfectivo).ToString("N")
            Me.txtImporteCuentaCorriente.Select()
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

    Private Sub btnPagoElectronico_Click(sender As Object, e As EventArgs) Handles btnPagoElectronico.Click

        Try
            If Me.MediosDePago.ImportePagoEfectivo = 0 Then
                MsgBox("No tiene saldo para ingresar otro pago", vbInformation, "SiCoFa")
                Exit Sub
            End If

            Dim str = InputBox("Medios de pago", "SiCoFa")

            If str = "" Then
                Exit Sub
            End If

            Dim lmpe As List(Of MedioPE) = mobj_AdminSiCoFa.ListarMedioPE(str)
            Dim mpe As MedioPE = Nothing

            If lmpe Is Nothing Then
                MsgBox("Medio de pago no encontrado", vbInformation, "SiCoFa")
                Exit Sub
            End If

            Select Case lmpe.Count
                Case 0
                    MsgBox("Medio de pago no Encontrado", vbInformation, "SiCoFa")
                    Exit Sub

                Case 1
                    mpe = lmpe.First

                Case > 1
                    Using f As New FrmSelectorUniversal
                        f.Text = "Medio de Pago Electronico"
                        f.Objetos = lmpe
                        f.NombrePropiedadId = "IdMPE"
                        f.NombrePropiedadDescripcion = "Descripcion"
                        f.HeaderPropiedadDescripcion = "Descripcion"
                        If f.ShowDialog() = DialogResult.OK Then
                            mpe = Me.SeleccionarMedioPE(f.Valor1Seleccionado, lmpe)
                        End If
                        f.Close()
                    End Using ' <- aquí se libera completamente
            End Select

            Me.MedioPE = mpe
            Me.lblPagoElectronico.Text = mpe.Descripcion
            Me.txtImportePagoElectronico.Enabled = True
            Me.txtImportePagoElectronico.Text = Convert.ToDecimal(Me.MediosDePago.ImportePagoEfectivo).ToString("N")
            Me.txtImportePagoElectronico.Select()
            Me.txtImportePagoElectronico.SelectAll()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

            End Try

    End Sub

    Private Function SeleccionarMedioPE(ByVal IdMPE As String, ByVal ListaMedioPE As List(Of MedioPE)) As MedioPE

        Try
            Dim MedioPESeleccionado As MedioPE = Nothing

            For Each mpe As MedioPE In ListaMedioPE
                If mpe.IdMPE = IdMPE Then
                    MedioPESeleccionado = mpe
                    Exit For ' Opcional: detener la búsqueda una vez encontrado el cliente
                End If
            Next
            Return MedioPESeleccionado

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
            Return Nothing
        End Try

    End Function

    Private Sub FinalizarOperacion()

        Try

            Dim objCC As OperacionCC = Nothing
            Dim objPE As OperacionPE = Nothing
            Dim objCb As Comprobante = Nothing
            Dim objAC As AsientoContable = Nothing

            Dim importeCC As Decimal = 0
            If Decimal.TryParse(Me.txtImporteCuentaCorriente.Text, importeCC) AndAlso importeCC > 0 Then

                If Me.Cliente.CuentaCorriente Is Nothing Then
                    MsgBox("El cliente seleccionado no tiene Cuenta Corriente", vbCritical, "SiCoFa")
                    Me.txtImporteCuentaCorriente.Text = "0,00"
                    Me.txtImportePagoElectronico.Select()
                    Me.txtImportePagoElectronico.SelectAll()
                    Me.txtImporteCuentaCorriente.Enabled = False
                    Exit Sub
                End If

                objCC = New OperacionCC(Me.Operacion.IdOperacion, Me.Cliente.CuentaCorriente.IdCC, "", importeCC, "NO CANCELADO", 0)
            End If

            Dim importePE As Decimal = 0
            If MedioPE IsNot Nothing AndAlso Decimal.TryParse(Me.txtImportePagoElectronico.Text, importePE) AndAlso importePE > 0 Then
                objPE = New OperacionPE(Me.Operacion.IdOperacion, 0, 1, Me.MedioPE.IdMPE, importePE, "EN CAJA")
            End If

            objCb = New Comprobante(
                                    argIdOperacion:=Me.Operacion.IdOperacion,
                                    argOperacion:=Me.Operacion,
                                    argCodiTC_SiCoFa:=Me.TipoComprobante.CodiTC_SiCoFa,
                                    argPVenta:=g_ParametrosTerminal.PVenta,
                                    argNumComp:="",
                                    argFechaComp:=Now.Date,
                                    argImpBto:=Me.ImporteAPagar,
                                    argImpDes:=0,
                                    argImpEx:=0,
                                    argImpGrav1:=Me.ImporteGravado1,
                                    argImpGrav2:=Me.ImporteGravado2,
                                    argImpCB:=0,
                                    argImpEf:=Me.MediosDePago.ImportePagoEfectivo,
                                    argImpCC:=Me.MediosDePago.ImporteCuentaCorriente,
                                    argImpPE:=Me.MediosDePago.ImportePagoElectronico,
                                    argCAE:=Nothing,
                                    argIdCliente:=Me.Cliente.Id,
                                    argCliente:=Me.Cliente,
                                    argIdOperAsoc:=0,
                                    argCompAsoc:=Nothing,
                                    argEmpresa:=g_ParametrosTerminal.Empresa,
                                    argDetalle:=ItemsComprobante
                                    )

            objAC = New AsientoContable
            With objAC
                .InsertarItem("1.01.01.001", MediosDePago.ImportePagoEfectivo)
                .InsertarItem("1.03.01.001", MediosDePago.ImporteCuentaCorriente)
                .InsertarItem("1.03.02.001", MediosDePago.ImportePagoElectronico)
                .InsertarItem("4.01.01.001", ImporteAPagar)
            End With

            mobj_AdminSiCoFa.FinalizarOperacionConTransaccion(g_ParametrosTerminal.MacAddress, Me.Operacion, objCC, objPE, objCb, objAC)

            If objCb.TipoComprobante.CodiTC_AFIP <> "00" Then
                Dim obj_N_AdminComprobants As New N_AdminComprobantes
                If obj_N_AdminComprobants.GenerarFacturaElectronica(objCb) = False Then
                    'aca hay que cambiar el estado de la operacion y salir
                End If

            End If

            Dim objAdminReporteComprobantes As New ReporteComprobantes
            objAdminReporteComprobantes.ImprimirComprobante(objCb)

            Dim nuevaVentanaVentas As New FrmVentas()
            nuevaVentanaVentas.Usuario = Me.Operacion.Usuario
            nuevaVentanaVentas.Show()

            Me.FrmOrigen.Close()
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

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
            Me.txtImporteCuentaCorriente.Text = Me.ImporteAPagar - Me.MediosDePago.ImportePagoElectronico
            Me.txtImporteCuentaCorriente.Select()
            Me.txtImporteCuentaCorriente.SelectAll()
            e.Cancel = True
        End If


    End Sub

    Private Sub txtImportePagoElectronico_Validating(sender As Object, e As CancelEventArgs) Handles txtImportePagoElectronico.Validating
        If Convert.ToDecimal(Me.txtImporteEfectivo.Text) < 0 Then
            MsgBox("El importe ingresado es mayor que el Importe a Pagar", vbCritical, "SiCoFa")
            Me.txtImportePagoElectronico.Text = Me.ImporteAPagar - Me.MediosDePago.ImporteCuentaCorriente
            Me.txtImportePagoElectronico.Select()
            Me.txtImportePagoElectronico.SelectAll()
            e.Cancel = True

        ElseIf Convert.ToDecimal(Me.txtImportePagoElectronico.Text) = 0 Then
            Me.MedioPE = Nothing
            Me.lblPagoElectronico.Text = "No Establecido"
            Me.txtImportePagoElectronico.Text = "0,00"
            Me.txtImportePagoElectronico.Enabled = False
            Me.txtImporteEfectivo.Select()
            Me.txtImporteEfectivo.SelectAll()

        End If
    End Sub

End Class