Imports SiCoFa.Negocio
Imports SiCoFa.Entidades
Public Class FrmIngConsumoLuz
    Private mobj_N_AdminConsumoLuz As New cls_N_AdminConsumoLuz

    Private mobjRegistroActivo As RegConsumoLuz
    Private mobjMedidorSeleccionado As Medidor
    Private mobjDetalleCL As List(Of ItemConsumoLuz)
    Private Function CategoriaSubcidio(ByVal argIdCategoria As String) As String

        Select Case argIdCategoria
            Case "R1"
                Return "Nivel 1 Usuarios Residenciales"
            Case "R2"
                Return "Nivel 2 Usuarios Residenciales"
            Case "R3"
                Return "Nivel 1 Usuarios Residenciales"
            Case "C"
                Return "Actividad Comercial"
        End Select

    End Function
    Private Sub EnviarMail()
        Try
            If mobjMedidorSeleccionado Is Nothing And Me.Medidor.SelectedValue IsNot Nothing Then
                mobjMedidorSeleccionado = Me.ObtenerMedidor(Me.Medidor.SelectedValue)
            ElseIf Me.Medidor.SelectedValue Is Nothing Then
                MsgBox("Seleccione un medidor", vbCritical, "SiCoFa")
                Exit Sub
            End If

            Dim obj_N_AdminContratos As New cls_N_AdminContratos
            Dim obj_N_AdminEmail As New cls_N_AdminEmail
            Dim cto As Contrato = obj_N_AdminContratos.ObtenerContrato(mobjMedidorSeleccionado.IdContrato)
            obj_N_AdminEmail.EnviarMail("NELSON BETIAN", cto.Cliente.Email, "Consumo Electrico", Me.DetalleConsumoElectrico(cto.Cliente.Nombre))

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
        End Try

    End Sub
    Private Function DetalleConsumoElectrico(ByVal argCliente As String) As String

        Try

            Dim Mensaje As String =
                "Cliente: " & argCliente & vbCrLf &
                "Subsicio: " & Me.CategoriaSubcidio(mobjRegistroActivo.Medidor.Categoria) & vbCrLf &
                "Período: " & mobjRegistroActivo.Mes & "-" & mobjRegistroActivo.Año & vbCrLf &
                "Fecha Lectura Anterior: " & mobjRegistroActivo.FechaLAn & vbCrLf &
                "Fecha Lectura Actual: " & mobjRegistroActivo.FechaLAc & vbCrLf &
                "Lectura Anterior: " & mobjRegistroActivo.LecturaAnterior & "Kwh" & vbCrLf &
                "Lectura Actual: " & mobjRegistroActivo.LecturaActual & "Kwh" & vbCrLf &
                "Consumo: " & mobjRegistroActivo.Consumo & "Kwh" & vbCrLf &
                "---------------------------------------------------------"

            For Each i As ItemConsumoLuz In mobjRegistroActivo.Detalle
                Mensaje = Mensaje & vbCrLf &
            i.Descripcion & ": $" & Format(i.Importe, "Standard")
                If i.Cantidad > 1 Then
                    Mensaje = Mensaje & vbCrLf &
                "Prec.Unit: $" & Format(i.PUnit, "Standard") & vbCrLf &
                "Cantidad: " & i.Cantidad
                End If
                Mensaje = Mensaje & vbCrLf &
                "---------------------------------------------------------"
            Next

            Mensaje = Mensaje & vbCrLf &
            "Imp.Neto: $" & Format(mobjRegistroActivo.ImpNeto, "Standard") & vbCrLf &
            "Ley 3052: $" & Format(mobjRegistroActivo.Ley3052, "Standard") & vbCrLf &
            "IVA: $" & Format(mobjRegistroActivo.IVA, "Standard") & vbCrLf &
            "RG2123: $" & Format(mobjRegistroActivo.RG2123, "Standard") & vbCrLf &
            "Total: $" & Format(mobjRegistroActivo.ImpCalculado, "Standard")
            Return Mensaje

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Function
    Private Sub ObtenerMedidores()
        Try
            mobj_N_AdminConsumoLuz.ListarMedidores()
            With Me.Medidor
                .DataSource = mobj_N_AdminConsumoLuz.ListaMedidores
                .ValueMember = "IdMedidor"
                .DisplayMember = "Descripcion"
                .SelectedIndex = -1
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Function ObtenerMedidor(ByVal argIdMedidor As Integer) As Medidor
        Try
            Dim objM As Medidor = Nothing
            For Each m As Medidor In mobj_N_AdminConsumoLuz.ListaMedidores

                If m.IdMedidor = argIdMedidor Then
                    objM = m
                    Exit For
                End If
            Next
            Return objM
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function
    Private Sub LimpiarTodo()
        With Me
            .IdRegistro.Text = ""
            .Medidor.SelectedIndex = -1
            .Mes.Text = ""
            .Año.Text = ""
            .LecturaAnterior.Text = ""
            .LecturaActual.Text = ""
            .Consumo.Text = ""
            .ImpNeto.Text = ""
            .Ley3052.Text = ""
            .IVA.Text = ""
            .RG2123.Text = ""
            .ImpCalculado.Text = ""
            .DataGridView1.Rows.Clear()
        End With
        mobjRegistroActivo = Nothing
        mobjMedidorSeleccionado = Nothing
        mobjDetalleCL = Nothing

    End Sub
    Private Sub MostrarDetalle()

        Try

            If mobjDetalleCL Is Nothing Then
                mobjDetalleCL = mobj_N_AdminConsumoLuz.ObtenerDetConsumoLuz(CLng(Me.IdRegistro.Text))
            End If

            Dim x As Integer
            For Each ItemCL As ItemConsumoLuz In mobjDetalleCL
                With Me.DataGridView1
                    .Rows.Add()
                    .Rows(x).Cells("Item").Value = ItemCL.Item
                    .Rows(x).Cells("Descripcion").Value = ItemCL.Descripcion
                    .Rows(x).Cells("Cantidad").Value = ItemCL.Cantidad
                    .Rows(x).Cells("PUnit").Value = ItemCL.PUnit
                    .Rows(x).Cells("Importe").Value = ItemCL.Importe
                End With
                x = x + 1
            Next

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
        End Try

    End Sub
    Private Sub ActualizarTotales()
        Dim ImpNeto As Decimal
        Dim ImponibleLey3052 As Decimal

        For Each I As ItemConsumoLuz In mobjDetalleCL
            ImpNeto = ImpNeto + I.Importe
            If I.Item < 12 Then
                ImponibleLey3052 = ImponibleLey3052 + I.Importe
            End If
        Next
        Dim IVA As Decimal = ImpNeto * mobjMedidorSeleccionado.IVA / 100
        Dim ImpLey3052 As Decimal = ImponibleLey3052 * 10.74 / 100
        Dim RG2123 As Decimal = ImpNeto * mobjMedidorSeleccionado.RG2123 / 100
        Me.ImpNeto.Text = Format(ImpNeto, "Standard")
        Me.Ley3052.Text = Format(ImpLey3052, "Standard")
        Me.IVA.Text = Format(IVA, "Standard")
        Me.RG2123.Text = Format(RG2123, "Standard")
        Me.ImpCalculado.Text = Format(ImpNeto + ImpLey3052 + IVA + RG2123, "Standard")

    End Sub
    Private Sub GuardarRegistro()

        If Me.IdRegistro.Text <> "" Then
            Exit Sub
        End If

        If Me.Medidor.Text = "" Then
            MsgBox("Medidor es un dato requerido", vbCritical, "SiCoFa")
            Exit Sub
        End If

        If Me.FechaLAc.Text = "" Then
            MsgBox("Fecha es un dato requerido", vbCritical, "SiCoFa")
            Exit Sub
        End If

        If Me.Mes.Text = "" Then
            MsgBox("Mes es un dato requerido", vbCritical, "SiCoFa")
            Exit Sub

        End If

        If Me.Año.Text = "" Then
            MsgBox("Año es un dato requerido", vbCritical, "SiCoFa")
            Exit Sub
        End If

        If Me.LecturaActual.Text = "" Then
            MsgBox("Lectura Actual es un dato requerido", vbCritical, "SiCoFa")
            Exit Sub
        End If

        If Me.LecturaAnterior.Text = "" Then
            MsgBox("Lectura Anterior es un dato requerido", vbCritical, "SiCoFa")
            Exit Sub
        End If

        If Me.Consumo.Text = "" Then
            MsgBox("Consumo es un dato requerido", vbCritical, "SiCoFa")
            Exit Sub
        End If

        Dim Fecha As String = Mid(mobjMedidorSeleccionado.FechaUL.ToString, 7, 4) & "/" & Mid(Me.mobjMedidorSeleccionado.FechaUL.ToString, 4, 2) & "/" & Mid(Me.mobjMedidorSeleccionado.FechaUL.ToString, 1, 2)
        Me.IdRegistro.Text = mobj_N_AdminConsumoLuz.InsertarRegConsumoLuz(mobjMedidorSeleccionado.IdContrato, Fecha, Me.Mes.Text, Me.Año.Text, mobjMedidorSeleccionado.IdMedidor, mobjMedidorSeleccionado.UltimaLectura, CInt(Me.LecturaActual.Text), "")

        'Dim x As Integer
        'Do While Me.IdRegistro.Text = ""
        'x = x + 1
        'If x = 50 Then
        'Exit Do
        'End If
        'Loop

        If Me.IdRegistro.Text <> "" Then
            mobj_N_AdminConsumoLuz.InsertarDetConsumoLuz(CLng(Me.IdRegistro.Text), mobjMedidorSeleccionado.Categoria, CLng(Me.Consumo.Text))
            mobj_N_AdminConsumoLuz.ActualizarTotalesConsumoLuz(CLng(Me.IdRegistro.Text))
            mobjRegistroActivo = mobj_N_AdminConsumoLuz.ObtenerRegConsumoLuzIniciado("INICIADO", 0, CLng(Me.IdRegistro.Text))
            Me.MostrarRegistroActivo()
        End If

    End Sub
    Private Sub HabilitarControles()
        With Me
            .Medidor.Enabled = True
            .FechaLAc.Enabled = True
            .Mes.Enabled = True
            .Año.Enabled = True
            .LecturaActual.Enabled = True
        End With
    End Sub
    Private Sub DesabilitarControles()
        With Me
            .Medidor.Enabled = False
            .FechaLAc.Enabled = False
            .Mes.Enabled = False
            .Año.Enabled = False
            .LecturaActual.Enabled = False
        End With
    End Sub
    Private Sub MostrarRegistroActivo()
        If mobjRegistroActivo IsNot Nothing Then

            With mobjRegistroActivo
                Me.IdRegistro.Text = .IdRegistro
                Me.Medidor.Text = .Medidor.Descripcion
                Me.FechaLAc.Text = .FechaLAc
                Me.Mes.Text = .Mes
                Me.Año.Text = .Año
                Me.LecturaAnterior.Text = .LecturaAnterior
                Me.LecturaActual.Text = .LecturaActual
                Me.Consumo.Text = .Consumo
                Me.ImpNeto.Text = Format(.ImpNeto, "Standard")
                Me.Ley3052.Text = Format(.Ley3052, "Standard")
                Me.IVA.Text = Format(.IVA, "Standard")
                Me.RG2123.Text = Format(.RG2123, "Standard")
                Me.ImpCalculado.Text = Format(.ImpCalculado, "Standard")
                Me.mobjDetalleCL = .Detalle
            End With

            Me.MostrarDetalle()
            Me.DesabilitarControles()
        End If

    End Sub
    Private Sub FrmIngConsumoLuz_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try
            Me.ObtenerMedidores()
            Me.FechaLAc.Text = Date.Now.ToString("d")
            mobjRegistroActivo = mobj_N_AdminConsumoLuz.ObtenerRegConsumoLuzIniciado("INICIADO")
            Me.MostrarRegistroActivo()

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub
    Private Sub Medidor_KeyUp(sender As Object, e As KeyEventArgs) Handles Medidor.KeyUp
        If e.KeyCode = 13 Then

            mobjMedidorSeleccionado = Me.ObtenerMedidor(Me.Medidor.SelectedValue)

            If mobjMedidorSeleccionado Is Nothing Then
                mobjMedidorSeleccionado = Nothing
                Exit Sub
            Else
                mobjRegistroActivo = mobj_N_AdminConsumoLuz.ObtenerRegConsumoLuzIniciado("EP", mobjMedidorSeleccionado.IdMedidor)
            End If

            If mobjRegistroActivo IsNot Nothing Then
                Me.MostrarRegistroActivo()
                Exit Sub
            End If

            Me.LecturaAnterior.Text = mobjMedidorSeleccionado.UltimaLectura
            Me.FechaLAc.Focus()
        End If
    End Sub
    Private Sub FechaLAc_Enter(sender As Object, e As EventArgs) Handles FechaLAc.Enter
        Me.FechaLAc.SelectionStart = 0
        Me.FechaLAc.SelectionLength = Len(Me.FechaLAc.Text)
    End Sub
    Private Sub FechaLAc_KeyUp(sender As Object, e As KeyEventArgs) Handles FechaLAc.KeyUp
        If e.KeyCode = 13 Then
            Me.Mes.Focus()
        End If
    End Sub
    Private Sub Mes_Enter(sender As Object, e As EventArgs) Handles Mes.Enter
        Me.Mes.SelectionStart = 0
        Me.Mes.SelectionLength = Len(Me.Mes.Text)
    End Sub
    Private Sub Mes_KeyUp(sender As Object, e As KeyEventArgs) Handles Mes.KeyUp
        If e.KeyCode = 13 Then
            Me.Año.Focus()
        End If
    End Sub
    Private Sub Año_Enter(sender As Object, e As EventArgs) Handles Año.Enter
        Me.Año.SelectionStart = 0
        Me.Año.SelectionLength = Len(Me.Año.Text)
    End Sub
    Private Sub Año_KeyUp(sender As Object, e As KeyEventArgs) Handles Año.KeyUp
        If e.KeyCode = 13 Then
            Me.LecturaActual.Focus()
        End If
    End Sub
    Private Sub LecuturaActual_KeyUp(sender As Object, e As KeyEventArgs) Handles LecturaActual.KeyUp
        If e.KeyCode = 13 Then
            If IsNumeric(Me.LecturaActual.Text) = False Then
                MsgBox("Ingrese un valor numerico mayor que cero", vbCritical, "SiCoFa")
                Me.LecturaActual.Text = ""
                Exit Sub
            Else
                Dim KWLAc As Long = CLng(Me.LecturaActual.Text)
                Dim KWLAn As Long = CLng(Me.LecturaAnterior.Text)
                Dim KWCons As Long = KWLAc - KWLAn
                Me.Consumo.Text = KWCons
                Me.GuardarRegistro()
                Me.DesabilitarControles()
            End If
        End If
    End Sub
    Private Sub Borrar_Click(sender As Object, e As EventArgs) Handles Borrar.Click
        Try
            If Me.IdRegistro.Text = "" Then
                Me.LimpiarTodo()
                Me.HabilitarControles()
                Me.Medidor.Select()
                Exit Sub
            End If

            If mobjRegistroActivo IsNot Nothing Then
                If mobjRegistroActivo.Estado = "INICIADO" Then
                    mobj_N_AdminConsumoLuz.EliminarRegConsumoLuz(Me.IdRegistro.Text)
                End If
            End If

            Me.LimpiarTodo()
            Me.HabilitarControles()
            Me.Medidor.Select()

        Catch ex As Exception

        End Try
    End Sub
    Private Sub Guardar_Click(sender As Object, e As EventArgs) Handles Guardar.Click

        Try
            If Me.IdRegistro.Text = "" Then
                Exit Sub
            End If

            Me.EnviarMail()
            mobj_N_AdminConsumoLuz.ActualizarEstadoRegistroConsumoLuz(CLng(Me.IdRegistro.Text), "EP")
            Me.LimpiarTodo()
            Me.HabilitarControles()
            Me.Medidor.Select()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try
    End Sub

End Class