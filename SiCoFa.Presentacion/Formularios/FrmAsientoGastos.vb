Imports SiCoFa.Negocio
Imports SiCoFa.Entidades
Imports System.ComponentModel
Public Class FrmAsientoGastos
    Property Usuario As Usuario

    Private Sub ObtenerOpcionesBoolean()
        Dim listaBooleanos As New List(Of OpcionBoolean) From {
            New OpcionBoolean("No", False),
            New OpcionBoolean("Sí", True)
        }

        CargarCombo(ComboBox1, listaBooleanos, "Texto", "Valor", "Caja Abierta")
    End Sub

    Private Sub ObtenerCuentasBancarias()
        Try
            Dim AdminCuentasBancarias As New N_AdminCuentasBancarias
            Dim lista = AdminCuentasBancarias.ListarCuentasBancarias("*")
            CargarCombo(ComboBox1, lista, "Descripcion", "IdCB", "Cuenta Bancaria")
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
        End Try
    End Sub

    Private Sub CargarCombo(cmb As ComboBox, dataSource As Object, display As String, value As String, etiqueta As String)
        With cmb
            .DataSource = Nothing
            .DisplayMember = display
            .ValueMember = value
            .DataSource = dataSource
            .SelectedIndex = -1
        End With
        lblComboBox1.Text = etiqueta
        cmb.Enabled = True

        ' Desplegar luego de asignación
        BeginInvoke(New MethodInvoker(Sub()
                                          cmb.DroppedDown = True
                                      End Sub))
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
                    ObtenerOpcionesBoolean()

                Case "CREDITO"
                    ComboBox1.DataSource = Nothing
                    ComboBox1.Enabled = False
                    lblComboBox1.Text = ""

                Case "TRANSFERENCIA"
                    ObtenerCuentasBancarias()
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
        End Try
    End Sub

    Private Sub ComboBox1_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ComboBox1.Validating
        If ComboBox1.Enabled AndAlso ComboBox1.SelectedIndex = -1 Then
            MessageBox.Show("Debe seleccionar un elemento de la lista.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            e.Cancel = True
        End If
    End Sub

    Private Sub ComboBox1_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles ComboBox1.PreviewKeyDown
        If e.KeyCode = Keys.Up OrElse e.KeyCode = Keys.Down Then
            e.IsInputKey = True
        End If
    End Sub

    Private Sub ComboBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox1.KeyDown
        Dim cmb As ComboBox = CType(sender, ComboBox)

        If cmb.Items.Count = 0 Then Exit Sub

        Select Case e.KeyCode
            Case Keys.Down
                If Not cmb.DroppedDown Then
                    cmb.DroppedDown = True
                ElseIf cmb.SelectedIndex < cmb.Items.Count - 1 Then
                    cmb.SelectedIndex += 1
                End If
                e.Handled = True

            Case Keys.Up
                If cmb.SelectedIndex > 0 Then
                    cmb.SelectedIndex -= 1
                    e.Handled = True
                End If
        End Select
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
                        f.NombrePropiedadId = "CodiTC"
                        f.NombrePropiedadDescripcion = "TipoComprobante"
                        f.HeaderPropiedadDescripcion = "Comprobante"
                        If f.ShowDialog() = DialogResult.OK Then
                            tc = Me.SeleccionarTipoComprobanteListado(f.Valor1Seleccionado, ltc)
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


End Class