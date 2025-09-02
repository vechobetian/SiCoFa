Imports SiCoFa.Negocio
Imports SiCoFa.Entidades
Imports System.ComponentModel
Public Class FrmIngresoComprobantesEmitidos

    Private DatosOpcionales As New List(Of String)
    Private Const WM_SYSCOMMAND As Integer = &H112
    Private Const SC_CLOSE As Integer = &HF060

    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.Msg = WM_SYSCOMMAND AndAlso (m.WParam.ToInt32() And &HFFF0) = SC_CLOSE Then
            ' El usuario hizo clic en la X → desactivamos validación
            Me.AutoValidate = AutoValidate.Disable
        End If
        MyBase.WndProc(m)
    End Sub

    Private Function SeleccionarClienteListado(ByVal Id As Int32, ByVal ListaClientes As List(Of Cliente)) As Cliente

        Try
            Dim ClienteSeleccionado As Cliente = Nothing

            For Each c As Cliente In ListaClientes
                If c.Id = Id Then
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

    Private Sub BuscarCliente(ByVal argTextoBuscado As String)

        Try
            Dim AdminClientes As New N_AdminClientes
            Dim lc As List(Of Cliente) = AdminClientes.ListarClientes(argTextoBuscado)
            Dim c As Cliente = Nothing

            If lc Is Nothing Then
                MsgBox("Cliente no Encontrado", vbInformation, "SiCoFa")
                Me.txtCliente.Tag = ""
                Me.txtCliente.Text = ""
                Me.txtCliente.Select()
                Exit Sub
            End If

            Select Case lc.Count
                Case 0
                    MsgBox("Cliente no Encontrado", vbInformation, "SiCoFa")
                    Me.txtCliente.Tag = ""
                    Me.txtCliente.Text = ""
                    Me.txtCliente.Select()
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
                        Else
                            Me.txtCliente.Tag = ""
                            Me.txtCliente.Text = ""
                            Me.txtCliente.Select()
                            Exit Sub
                        End If
                        f.Close()
                    End Using

            End Select

            With Me
                .LimpiarFormulario()
                .txtCliente.Tag = c.Id
                .txtCliente.Text = c.Nombre
            End With
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub txtCliente_Validating(sender As Object, e As CancelEventArgs) Handles txtCliente.Validating
        Try

            If String.IsNullOrWhiteSpace(txtCliente.Text) Then
                Me.txtCliente.Tag = ""
                Me.txtCliente.Text = "TODOS"
                Exit Sub
            End If

            If UCase(Me.txtCliente.Text) = "TODOS" Then
                Me.txtCliente.Tag = ""
                Me.txtCliente.Text = "TODOS"
                Exit Sub
            End If

            Me.BuscarCliente(Me.txtCliente.Text)

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

            If String.IsNullOrWhiteSpace(txtTipoComprobante.Text) Then
                Me.txtTipoComprobante.Tag = ""
                Me.txtTipoComprobante.Text = "TODOS"
                Exit Sub
            End If

            If UCase(Me.txtTipoComprobante.Text) = "TODOS" Then
                Me.txtTipoComprobante.Tag = ""
                Me.txtTipoComprobante.Text = "TODOS"
                Exit Sub
            End If

            Me.BuscarTipoComprobante(Me.txtTipoComprobante.Text)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try
    End Sub

    Private Sub mtxtFechaDesde_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles mtxtFechaDesde.MaskInputRejected
        Try
            Dim fecha As Date

            ' Si está vacío o incompleto
            If Not mtxtFechaDesde.MaskCompleted Then
                MsgBox("Debe ingresar una fecha completa.", vbExclamation, "Validación")
                mtxtFechaDesde.SelectAll()
                mtxtFechaDesde.Focus()
                Exit Sub
            End If

            ' Validación de fecha válida
            If Date.TryParseExact(mtxtFechaDesde.Text, "dd/MM/yyyy", Nothing, Globalization.DateTimeStyles.None, fecha) Then
                mtxtFechaDesde.Text = fecha.ToString("dd/MM/yyyy") ' Normaliza la fecha
            Else
                MsgBox("La fecha ingresada no es válida.", vbExclamation, "Validación")
                mtxtFechaDesde.SelectAll()
                mtxtFechaDesde.Focus()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
        End Try
    End Sub

    Private Sub mtxtFechaHasta_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles mtxtFechaHasta.MaskInputRejected
        Try
            Dim fecha As Date

            ' Si está vacío o incompleto
            If Not mtxtFechaDesde.MaskCompleted Then
                MsgBox("Debe ingresar una fecha completa.", vbExclamation, "Validación")
                mtxtFechaHasta.SelectAll()
                mtxtFechaHasta.Focus()
                Exit Sub
            End If

            ' Validación de fecha válida
            If Date.TryParseExact(mtxtFechaHasta.Text, "dd/MM/yyyy", Nothing, Globalization.DateTimeStyles.None, fecha) Then
                mtxtFechaHasta.Text = fecha.ToString("dd/MM/yyyy") ' Normaliza la fecha
            Else
                MsgBox("La fecha ingresada no es válida.", vbExclamation, "Validación")
                mtxtFechaHasta.SelectAll()
                mtxtFechaHasta.Focus()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
        End Try
    End Sub

    Private Sub btnMostrarComprobantes_Click(sender As Object, e As EventArgs) Handles btnMostrarComprobantes.Click
        Dim str As String

        str = Strings.Replace(Me.mtxtFechaDesde.Text, "/", "").Trim

        If str = "" Then
            MsgBox("Fecha Desde es un dato requerido", vbCritical, "SiCoFa")
            Me.mtxtFechaDesde.Focus()
            Exit Sub
        End If

        str = Strings.Replace(Me.mtxtFechaHasta.Text, "/", "").Trim

        If str = "" Then
            MsgBox("Fecha Hasta es un dato requerido", vbCritical, "SiCoFa")
            Me.mtxtFechaHasta.Focus()
            Exit Sub
        End If

        Me.ValidarCampos(Me, Me.DatosOpcionales)

        If Me.ValidacionOK = False Then
            Exit Sub
        End If

        Dim sql As String = ""

        Dim desdeTexto As String = Me.mtxtFechaDesde.Text.Trim()
        Dim hastaTexto As String = Me.mtxtFechaHasta.Text.Trim()

        ' Convertir texto a Date
        Dim desdeFecha As Date = Date.ParseExact(desdeTexto, "dd/MM/yyyy", Globalization.CultureInfo.InvariantCulture)
        Dim hastaFecha As Date = Date.ParseExact(hastaTexto, "dd/MM/yyyy", Globalization.CultureInfo.InvariantCulture)

        ' Formatear fechas para SQL
        Dim desdeSql As String = desdeFecha.ToString("yyyy-MM-dd")
        Dim hastaSql As String = hastaFecha.ToString("yyyy-MM-dd")

        If Me.txtCliente.Tag.ToString = "" And Me.txtTipoComprobante.Tag.ToString = "" Then
            sql = $"SELECT IdOperacion,CodiTC,IdOperAsoc,TipoComprobante,FechaComp,PVenta,NumComp,Cliente,ImpBto,ImpDes,ImpNeto,ImpEf,ImpCC,ImpPE,ComprobanteAsociado,EstadoOperacion,DescripcionError FROM vw_comprobantes_emitidos WHERE FechaComp BETWEEN '{desdeSql}' AND '{hastaSql}' ORDER BY IdOperacion"

        ElseIf Me.txtCliente.Tag.ToString <> "" And Me.txtTipoComprobante.Tag.ToString = "" Then
            sql = $"SELECT IdOperacion,CodiTC,IdOperAsoc,TipoComprobante,FechaComp,PVenta,NumComp,Cliente,ImpBto,ImpDes,ImpNeto,ImpEf,ImpCC,ImpPE,ComprobanteAsociado,EstadoOperacion,DescripcionError FROM vw_comprobantes_emitidos WHERE IdCliente={Convert.ToInt32(Me.txtCliente.Tag)} AND FechaComp BETWEEN '{desdeSql}' AND '{hastaSql}' ORDER BY IdOperacion"

        ElseIf Me.txtCliente.Tag.ToString = "" And Me.txtTipoComprobante.Tag.ToString <> "" Then
            sql = $"SELECT IdOperacion,CodiTC,IdOperAsoc,TipoComprobante,FechaComp,PVenta,NumComp,Cliente,ImpBto,ImpDes,ImpNeto,ImpEf,ImpCC,ImpPE,ComprobanteAsociado,EstadoOperacion,DescripcionError FROM vw_comprobantes_emitidos WHERE CodiTC='{Me.txtTipoComprobante.Tag.ToString}' AND FechaComp BETWEEN '{desdeSql}' AND '{hastaSql}' ORDER BY IdOperacion"

        ElseIf Me.txtCliente.Tag.ToString <> "" And Me.txtTipoComprobante.Tag.ToString <> "" Then
            sql = $"SELECT IdOperacion,CodiTC,IdOperAsoc,TipoComprobante,FechaComp,PVenta,NumComp,Cliente,ImpBto,ImpDes,ImpNeto,ImpEf,ImpCC,ImpPE,ComprobanteAsociado,EstadoOperacion,DescripcionError FROM vw_comprobantes_emitidos WHERE CodiTC='{Me.txtTipoComprobante.Tag.ToString}' AND IdCliente={Convert.ToInt32(Me.txtCliente.Tag)} AND FechaComp BETWEEN '{desdeSql}' AND '{hastaSql}' ORDER BY IdOperacion"

        End If

        FrmComprobantesEmitidos.SQL = sql
        Me.Close()
        FrmComprobantesEmitidos.Show()
        FrmComprobantesEmitidos.BringToFront()

    End Sub

End Class