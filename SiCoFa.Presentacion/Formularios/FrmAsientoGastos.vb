Imports SiCoFa.Negocio
Imports SiCoFa.Entidades
Imports System.ComponentModel
Public Class FrmAsientoGastos
    Property Usuario As Usuario
    Private DatosOpcionales As New List(Of String)

    Private Sub ObtenerOpcionesBoolean()

        Dim listaBooleanos As New List(Of OpcionBoolean) From {
            New OpcionBoolean("No", False),
            New OpcionBoolean("Sí", True)
        }

        cmbCajaAbierta.DataSource = listaBooleanos
        cmbCajaAbierta.DisplayMember = "Texto"
        cmbCajaAbierta.ValueMember = "Valor"
        cmbCajaAbierta.SelectedIndex = -1

    End Sub

    Private Sub cmbFPago_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbFPago.Validating
        If cmbFPago.SelectedIndex = -1 Then
            MessageBox.Show("Debe seleccionar un elemento de la lista.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            e.Cancel = True
        End If
    End Sub

    Private Sub cmbFPago_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFPago.SelectedIndexChanged
        Try
            Select Case cmbFPago.Text
                Case "CONTADO"
                    Me.DatosOpcionales.Clear()
                    Me.DatosOpcionales.Add("txtObservaciones")
                    Me.DatosOpcionales.Add("txtCuentaBancaria")
                    Me.txtCuentaBancaria.Text = ""
                    Me.txtCuentaBancaria.Tag = ""
                    Me.txtCuentaBancaria.Visible = False
                    Me.lblVariable.Text = "Caja Abierta"
                    Me.cmbCajaAbierta.Visible = True
                    Me.cmbCajaAbierta.Enabled = True
                    Me.cmbCajaAbierta.Focus() ' <- Aquí pongo el foco luego de cargar

                Case "CREDITO"
                    Me.DatosOpcionales.Clear()
                    Me.DatosOpcionales.Add("txtObservaciones")
                    Me.DatosOpcionales.Add("cmbCajaAbierta")
                    Me.cmbCajaAbierta.SelectedIndex = -1
                    Me.cmbCajaAbierta.Visible = True
                    Me.cmbCajaAbierta.Enabled = False
                    Me.txtCuentaBancaria.Text = ""
                    Me.txtCuentaBancaria.Tag = ""
                    Me.txtCuentaBancaria.Visible = False
                    lblVariable.Text = "Caja Abierta"

                Case "TRANSFERENCIA"
                    Me.DatosOpcionales.Clear()
                    Me.DatosOpcionales.Add("txtObservaciones")
                    Me.DatosOpcionales.Add("cmbCajaAbierta")
                    Me.cmbCajaAbierta.SelectedIndex = -1
                    Me.cmbCajaAbierta.Visible = False
                    Me.txtCuentaBancaria.Visible = True
                    lblVariable.Text = "Cuenta Bancaria"

            End Select
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
        End Try
    End Sub

    Private Sub cmbCajaAbierta_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbCajaAbierta.Validating
        If Not cmbCajaAbierta.Visible OrElse Not cmbCajaAbierta.Enabled Then Exit Sub

        If cmbCajaAbierta.SelectedIndex = -1 Then
            MessageBox.Show("Debe seleccionar un elemento de la lista.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            e.Cancel = True
        End If
    End Sub

    Private Sub cmbCajaAbierta_Enter(sender As Object, e As EventArgs) Handles cmbCajaAbierta.Enter
        cmbCajaAbierta.FlatStyle = FlatStyle.Popup ' Muestra un borde más marcado
    End Sub

    Private Sub cmbCajaAbierta_Leave(sender As Object, e As EventArgs) Handles cmbCajaAbierta.Leave
        cmbCajaAbierta.FlatStyle = FlatStyle.Standard ' Vuelve al borde estándar
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
                    Me.txtTipoComprobante.Text = ""
                    Me.txtTipoComprobante.Select()
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

    Private Sub BuscarProveedor(ByVal argTextoBuscado As String)

        Try

            Dim AdminProveedores As New N_AdminProveedores
            Dim lp As List(Of Proveedor) = AdminProveedores.ListarProveedores(argTextoBuscado)
            Dim pv As Proveedor = Nothing

            If lp Is Nothing Then
                MsgBox("Proveedor no Encontrado", vbInformation, "SiCoFa")
                Me.txtProveedor.Text = ""
                Me.txtProveedor.Select()
                Exit Sub
            End If

            Select Case lp.Count
                Case 0
                    MsgBox("Proveedor no Encontrado", vbInformation, "SiCoFa")
                    Me.txtProveedor.Text = ""
                    Me.txtProveedor.Select()
                    Exit Sub
                Case 1
                    pv = lp.First
                Case > 1
                    Using f As New FrmBuscaPersonas
                        f.Personas = lp
                        f.ShowDialog()
                        If f.DialogResult = DialogResult.OK Then
                            Dim p As Persona = f.PersonaSeleccionado
                            pv = New Proveedor(p.Id, p.Nombre, p.Domicilio, p.Localidad, p.Provincia, p.Telefono, p.Email, p.Documento.TipoDoc.CodiTDoc, p.Documento.Numero, p.FechaAlta, p.Estado)
                        Else
                            Me.txtProveedor.Tag = ""
                            Me.txtProveedor.Text = ""
                            Me.txtProveedor.Select()
                            Exit Sub
                        End If
                        f.Close()
                    End Using
            End Select

            Me.txtProveedor.Tag = pv.Id
            Me.txtProveedor.Text = pv.Nombre

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub txtProveedor_Validating(sender As Object, e As CancelEventArgs) Handles txtProveedor.Validating
        Try

            Me.BuscarProveedor(Me.txtProveedor.Text)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try
    End Sub

    Private Function SeleccionarTipoComprobanteListado(ByVal argCodiTC As String, ByVal argLista As List(Of TipoComprobante)) As TipoComprobante

        Try
            Dim TCSeleccionado As TipoComprobante = Nothing

            For Each tc As TipoComprobante In argLista
                If tc.CodiTC_SiCoFa = argCodiTC Then
                    TCSeleccionado = tc
                    Exit For ' Opcional: detener la búsqueda una vez encontrado el cliente
                End If
            Next

            Return TCSeleccionado

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
            Return Nothing
        End Try

    End Function

    Private Sub BuscarTipoComprobante(ByVal argTextoBuscado As String)
        Try

            Dim AdminComprobantes As New N_AdminComprobantes
            Dim ltc As List(Of TipoComprobante) = AdminComprobantes.ListarTipoComprobantes(argTextoBuscado)
            Dim tc As TipoComprobante = Nothing

            If ltc Is Nothing Then
                MsgBox("Tipo de Comprobante no Encontrado", vbInformation, "SiCoFa")
                Me.txtTipoComprobante.Text = ""
                Me.txtTipoComprobante.Select()
                Exit Sub
            End If

            Select Case ltc.Count
                Case 0
                    MsgBox("Tipo de Comprobante no Encontrado", vbInformation, "SiCoFa")
                    Me.txtTipoComprobante.Text = ""
                    Me.txtTipoComprobante.Select()
                    Exit Sub

                Case 1
                    tc = ltc.First

                Case > 1
                    Using f As New FrmSelectorUniversal
                        f.Text = "Tipos de Comprobante"
                        f.Objetos = ltc
                        f.NombrePropiedadId = "CodiTC_SiCoFa"
                        f.NombrePropiedadDescripcion = "TipoComprobanteCLetra"
                        f.HeaderPropiedadDescripcion = "Comprobante"

                        If f.ShowDialog() = DialogResult.OK Then
                            tc = Me.SeleccionarTipoComprobanteListado(f.Valor1Seleccionado, ltc)
                        Else
                            Me.txtTipoComprobante.Tag = ""
                            Me.txtTipoComprobante.Text = ""
                            Me.txtTipoComprobante.Select()
                            Exit Sub

                        End If
                        f.Close()
                    End Using ' <- aquí se libera completamente
            End Select

            Me.txtTipoComprobante.Tag = tc.CodiTC_SiCoFa
            Me.txtTipoComprobante.Text = tc.TipoComprobanteCLetra

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub txtTipoComprobante_Validating(sender As Object, e As CancelEventArgs) Handles txtTipoComprobante.Validating
        Try

            Me.BuscarTipoComprobante(Me.txtTipoComprobante.Text)

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

    Private Sub BuscarCuentaImputable(ByVal argTextoBuscado As String)
        Try

            Dim AdminDB As New N_AdminDB
            Dim sql As String = "SELECT * FROM TblCtasImputables WHERE (LEFT(CodiCta,4)='6.02' OR LEFT(CodiCta,4)='6.04' OR LEFT(CodiCta,4)='6.05')  AND NombreCta LIKE '" & Replace(argTextoBuscado, " ", "%") & "%'"
            Dim dt As DataTable = AdminDB.ObtenerTabla(sql)

            Select Case dt.Rows.Count
                Case 0
                    MsgBox("Cuenta no Encontrada", vbInformation, "SiCoFa")
                    Me.txtCuentaImputable.Text = ""
                    Me.txtCuentaImputable.Select()
                    Exit Sub

                Case 1
                    Dim AdminAsientosContables As New N_AdminAsientosContable
                    Dim fila As DataRow = dt.Rows(0)
                    Dim codiCta As String = fila("CodiCta").ToString
                    Dim ci As CuentaImputable = AdminAsientosContables.ObtenerCuentaImputablePorCodiCta(codiCta)
                    Me.txtCuentaImputable.Tag = ci.CodiCta
                    Me.txtCuentaImputable.Text = ci.NombreCta
                    Exit Sub

                Case > 1

                    Using f As New FrmSelectorUniversal
                        f.Text = "Cuentas de Gasto"
                        f.Objetos = dt.DefaultView
                        f.NombrePropiedadId = "CodiCta"
                        f.NombrePropiedadDescripcion = "NombreCta"
                        f.HeaderPropiedadDescripcion = "Cuenta"

                        If f.ShowDialog() = DialogResult.OK Then
                            Dim AdminAsientosContables As New N_AdminAsientosContable
                            Dim codiCta As String = f.Valor1Seleccionado.ToString
                            Dim ci As CuentaImputable = AdminAsientosContables.ObtenerCuentaImputablePorCodiCta(codiCta)
                            Me.txtCuentaImputable.Tag = ci.CodiCta
                            Me.txtCuentaImputable.Text = ci.NombreCta
                            Exit Sub
                        Else
                            Me.txtCuentaImputable.Tag = ""
                            Me.txtCuentaImputable.Text = ""
                            Me.txtCuentaImputable.Select()
                        End If
                        f.Close()

                    End Using

            End Select

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub txtCuentaImputable_Validating(sender As Object, e As CancelEventArgs) Handles txtCuentaImputable.Validating
        Try

            Me.BuscarCuentaImputable(Me.txtCuentaImputable.Text)

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
            Dim importe As Decimal

            If Decimal.TryParse(txtImporte.Text, importe) Then
                txtImporte.Text = importe.ToString("N2") ' Formato con 2 decimales, con separador de miles
            Else
                MsgBox("Debe ingresar un valor numérico válido.", vbExclamation, "Validación")
                txtImporte.SelectAll()
                txtImporte.Focus()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub FinalizarOperacion()
        Try
            Dim str As String = Strings.Replace(Me.mtxtNumComprobante.Text, "-", "").Trim

            If str = "" Then
                MsgBox("Num.Comprobante es un dato requerido", vbCritical, "SiCoFa")
                Me.mtxtNumComprobante.Focus()
                Exit Sub
            End If

            If Len(str) <> 12 Then
                MsgBox("Formato invalido para el tipo de comprobante", vbCritical, "SiCoFa")
                mtxtNumComprobante.Text = "-"
                Me.mtxtNumComprobante.Focus()
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

            Dim objCliente As New Cliente(0, "", "", "", "", "", "", "", "", Date.Now, "", "")
            Dim AdminComprobantes As New N_AdminComprobantes
            Dim objTC As TipoComprobante = AdminComprobantes.ObtenerTipoComprobantePorCodiTC(Me.txtTipoComprobante.Tag.ToString)
            Dim AfectaCajaAbierta As Boolean = False
            Dim objOperacionCB As OperacionCB = Nothing
            Dim objOperacionCP As OperacionCP = Nothing
            Dim objAsCon As New AsientoContable
            Dim impCB As Decimal = 0
            Dim impEF As Decimal = 0

            objAsCon.InsertarItem(Me.txtCuentaImputable.Tag, Convert.ToDecimal(Me.txtImporte.Text))

            If Me.cmbFPago.Text = "TRANSFERENCIA" Then
                impCB = Convert.ToDecimal(Me.txtImporte.Text)
                objOperacionCB = New OperacionCB(0, Me.cmbCajaAbierta.SelectedValue, "", impCB, "INICIADO")
                objAsCon.InsertarItem("1.01.03.001", -impCB)
            End If

            If Me.cmbFPago.Text = "CONTADO" Then
                AfectaCajaAbierta = Me.cmbCajaAbierta.SelectedValue
                impEF = Convert.ToDecimal(Me.txtImporte.Text)
                objAsCon.InsertarItem("1.01.01.001", -impEF)
            End If

            If Me.cmbFPago.Text = "CREDITO" Then
                objOperacionCP = New OperacionCP(0, Me.txtProveedor.Tag, "", Convert.ToDecimal(Me.txtImporte.Text), "INICIADO", 0)
                objAsCon.InsertarItem("2.01.01.001", Convert.ToDecimal(Me.txtImporte.Text))
            End If

            Dim objComprobante As New Comprobante(
                                                  argIdOperacion:=0,
                                                  argOperacion:=Nothing,
                                                  argTipoComprobante:=objTC,
                                                  argPVenta:=Strings.Left(mtxtNumComprobante.Text, 4),
                                                  argNumComp:=Strings.Right(mtxtNumComprobante.Text, 8),
                                                  argFechaComp:=Convert.ToDateTime(Me.mtxtFechaComprobante.Text),
                                                  argImpBto:=Convert.ToDecimal(Me.txtImporte.Text),
                                                  argImpDes:=0,
                                                  argImpEx:=0,
                                                  argImpGrav1:=0,
                                                  argImpGrav2:=0,
                                                  argImpCB:=impCB,
                                                  argImpEf:=impEF,
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





            Dim AdminOperacion As New N_AdminOperaciones
            AdminOperacion.AsientoGastoTransaccion(g_ParametrosTerminal.MacAddress, g_ParametrosTerminal.Empresa, Me.Usuario, objOperacionCP, objOperacionCB, objComprobante, objAsCon)

            Dim nuevoAsientoGastos As New FrmAsientoGastos
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

    Private Sub FrmAsientoGastos_Load(sender As Object, e As EventArgs) Handles Me.Load
        ObtenerOpcionesBoolean()
    End Sub
End Class