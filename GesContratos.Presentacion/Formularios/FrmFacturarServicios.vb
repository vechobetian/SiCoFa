Imports System.Drawing.Printing
Imports SiCoFa.Negocio
Imports SiCoFa.Entidades
Imports System.ComponentModel
Public Class FrmFacturarServicios
    Property IdUsuario As Integer

    Private mobj_N_AdminContratos As New cls_N_AdminContratos
    Private mobjComprobantes As List(Of Comprobante)
    Private mblnSuspender As Boolean
    Private mstrSiguienteProceso As String
    Private mintNumComprobanteA As Integer
    Private mintNumcomprobanteR As Integer

    Public Sub IniciarProcesos()
        Try
            Me.FacturarServicios(IdUsuario, "FAC", "0001")
            'Me.EnviarMail()
            Me.ProgressBar1.Visible = False
            Me.ObtenerComprobantesEnCola()
            Me.SolicitarCAE()
            'Me.Mensaje.Left = 75
            'Me.Mensaje.Top = 50
            'Me.Mensaje.Text = "Se enviaron " & mobjComprobantes.Count & " reportes"
            'Me.Aceptar.Visible = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Function FacturarServicios(ByVal argIdUsuario As Integer, ByVal argCodiTC As String, ByVal argPVenta As String) As Integer

        Try
            Me.Mensaje.Text = "Se estan Generando las Facturas....." & vbCrLf & vbCrLf & "Aguarde hasta que finalice el proceso"
            Me.Show()
            Me.Refresh()

            Dim NumComprobantes As Integer = mobj_N_AdminContratos.FacturarServicios(argIdUsuario, argCodiTC, argPVenta)
            Return NumComprobantes
        Catch ex As Exception

            MsgBox(ex.Message)
            Return 0

        End Try
    End Function
    Private Sub ObtenerComprobantesEnCola()

        Try
            Dim objCola As List(Of Comprobante) = mobj_N_AdminContratos.ObtenerComprobantesEnCola
            If objCola IsNot Nothing Then
                Me.mobjComprobantes = objCola
            End If
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub
    Private Sub SolicitarCAE()

        If mobjComprobantes Is Nothing Then
            MsgBox("No existen comprobantes para generar", vbInformation, "SiCoFa")
            Me.Finalize()
            Exit Sub
        End If

        Dim obj_N_AdminCAE As New cls_N_AdminCAE
        Dim NumComprobantes As Integer = mobjComprobantes.Count
        Dim NumComprobante As Integer
        Dim Cociente As Decimal

        Me.Mensaje.Text = "Solicitando CAE....." & vbCrLf & vbCrLf & "Aguarde hasta que finalice el proceso"
        Me.Refresh()

        Me.ProgressBar1.Visible = True
        Me.lblProgressBar.Visible = True

        Try
            For Each c As Comprobante In mobjComprobantes
                NumComprobante += 1
                Cociente = NumComprobante / NumComprobantes * 100
                Me.lblProgressBar.Text = NumComprobante & " Comprobantes de " & NumComprobantes & " Comprobantes"
                Me.ProgressBar1.Value = Cociente

                Me.Refresh()

                c.Operacion = mobj_N_AdminContratos.ObtenerOperacion(c.IdOperacion)
                c.Cliente = mobj_N_AdminContratos.ObtenerClientePorId(c.IdCliente)
                c.Detalle = mobj_N_AdminContratos.ObtenerDetalleC(c.IdOperacion, False)
                c.Locador = mobj_N_AdminContratos.ObtenerLocadorPorId(1)
                Dim CAE As CAE = obj_N_AdminCAE.ObtenerCAE(c)
                If CAE IsNot Nothing Then
                    mintNumComprobanteA += 1
                    c.NumComp = Format(CAE.NumComp, "00000000")
                    c.CAE = CAE
                    mobj_N_AdminContratos.ActualizarCAE(c)
                Else
                    mintNumcomprobanteR += 1
                    mobj_N_AdminContratos.RegistrarComprobanteRechazado(c.IdOperacion)
                    mobj_N_AdminContratos.RegistrarError(c.IdOperacion, obj_N_AdminCAE.Observaciones & vbCrLf & obj_N_AdminCAE.Errores & vbCrLf & obj_N_AdminCAE.Eventos)
                End If
                Application.DoEvents()
            Next
            Me.Mensaje.Text = "Num.Comprobantes Aprobados: " & mintNumComprobanteA & vbCrLf & "Num.Comprobantes Rechazados: " & mintNumcomprobanteR
            Me.Aceptar.Visible = True
            Me.ProgressBar1.Visible = False
            Me.lblProgressBar.Visible = False
            mstrSiguienteProceso = "QR"

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub
    Private Sub GenerarQR()
        Dim NumComprobante As Integer
        Dim Cociente As Decimal
        Me.ProgressBar1.Value = 0
        Me.ProgressBar1.Visible = True
        Me.lblProgressBar.Visible = True
        Me.Mensaje.Text = "Generando comprobantes Aprobados....." & vbCrLf & vbCrLf & "Aguarde hasta que finalice el proceso"
        Me.Refresh()

        Try
            For Each c As Comprobante In mobjComprobantes

                If c.CAE IsNot Nothing Then
                    NumComprobante += 1
                    Cociente = NumComprobante / mintNumComprobanteA * 100
                    Me.lblProgressBar.Text = NumComprobante & " Comprobantes de " & mintNumComprobanteA & " Comprobantes"
                    Me.ProgressBar1.Value = Cociente

                    Dim CUIT As Long = CLng(Replace(c.Locador.Documento.Numero, "-", ""))
                    Dim PVta As Integer = CInt(c.PVenta)
                    Dim NumComp As Long = CLng(c.NumComp)

                    c.QR = New QRCompE(c.FechaComp, CUIT, PVta, c.TipoComprobante.CodiTC_AFIP, NumComp, c.ImpBto, c.Cliente.Documento.TipoDoc.CodiTDoc, c.Cliente.Documento.Numero, c.CAE.NumCAE)

                End If
            Next

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError("SiCoFa_CompE_Main", "GenerarQR", ex.Message))
        End Try
    End Sub
    Private Sub GenerarPdf(ByVal argComprobante As Comprobante)

        Try
            Dim objPdf As New clsReporteComprobantes
            With objPdf
                .Operacion.Add(argComprobante.Operacion)
                .Locador.Add(argComprobante.Locador)
                .Cliente.Add(argComprobante.Cliente)
                .TipoComprobante.Add(argComprobante.TipoComprobante)
                .Encabezado.Add(argComprobante)
                .Detalle = argComprobante.Detalle
                .CAE.Add(argComprobante.CAE)
                .QR.Add(argComprobante.QR)
                .Copia = "ORIGINAL"
                '.PathReporte = mobjPater.PathServer

                If argComprobante.CompAsoc IsNot Nothing Then
                    .CompAsoc = "Comprobante Asociado: " & argComprobante.CompAsoc.TipoComprobante.TipoComprobante & " " & argComprobante.CompAsoc.TipoComprobante.Letra & " " & argComprobante.CompAsoc.PVenta & "-" & argComprobante.CompAsoc.NumComp
                Else
                    .CompAsoc = ""
                End If

            End With

            objPdf.Run("PDFA4")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub EnviarReportes()
        Dim NumComprobantes As Integer = mobjComprobantes.Count
        Dim NumComprobante As Integer
        Dim Cociente As Decimal
        Dim obj_N_AdminEmail As New cls_N_AdminEmail
        Dim Mensaje As String
        Dim Archivo As String

        Try

            Me.lblProgressBar.Text = ""
            Me.Mensaje.Text = "Enviando reportes....." & vbCrLf & vbCrLf & "Aguarde hasta que finalice el proceso"
            Me.Refresh()

            For Each c As Comprobante In mobjComprobantes
                If mblnSuspender = True Then
                    Exit Sub
                End If

                Me.lblProgressBar.Text = NumComprobante & " Reportes enviados de " & NumComprobantes & " Contratos para reportar"
                Me.ProgressBar1.Value = Cociente
                Me.Refresh()

                Archivo = c.TipoComprobante.CodiTC_SiCoFa & c.PVenta & c.NumComp
                Mensaje = "Estimado Cliente, adjunto Estado de Cuenta" & vbCrLf & vbCrLf & "Atentamente: " & c.Locador.Nombre
                obj_N_AdminEmail.EnviarMail(c.Locador.Nombre, c.Cliente.Email, "Detalle de Cuenta", Mensaje, Application.StartupPath & "\Temp\" & c.TipoComprobante.CodiTC_SiCoFa & c.PVenta & c.NumComp & ".pdf")

                NumComprobante += 1
                Cociente = NumComprobante / NumComprobantes * 100
                Application.DoEvents()
            Next

            obj_N_AdminEmail = Nothing

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub
    Private Sub FrmFacturarServicios_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        mblnSuspender = True
        Me.Dispose()
    End Sub
    Private Sub Aceptar_Click(sender As Object, e As EventArgs) Handles Aceptar.Click
        Select Case mstrSiguienteProceso
            Case "QR"
                Me.GenerarQR()
            Case "Finalizar"
                Me.Dispose()
                Me.Finalize()
        End Select

    End Sub

End Class