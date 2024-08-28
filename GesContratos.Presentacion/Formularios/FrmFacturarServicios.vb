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
            Me.ProgressBar1.Visible = False
            Me.ObtenerComprobantesEnCola()
            Me.GenerarComprobantes()

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
    Private Function SolicitarCAE(ByRef argComprobante As Comprobante) As String

        Dim obj_N_AdminCAE As New cls_N_AdminCAE

        Try
            With argComprobante
                .Operacion = mobj_N_AdminContratos.ObtenerOperacion(argComprobante.IdOperacion)
                .Cliente = mobj_N_AdminContratos.ObtenerClientePorId(argComprobante.IdCliente)
                .Detalle = mobj_N_AdminContratos.ObtenerDetalleC(argComprobante.IdOperacion, False)
                .Locador = mobj_N_AdminContratos.ObtenerLocadorPorId(1)
            End With

            Dim CAE As CAE = obj_N_AdminCAE.ObtenerCAE(argComprobante)

            If CAE IsNot Nothing Then
                mintNumComprobanteA += 1
                argComprobante.NumComp = Format(CAE.NumComp, "00000000")
                argComprobante.CAE = CAE
                Return "A"

            Else

                mintNumcomprobanteR += 1
                mobj_N_AdminContratos.RegistrarComprobanteRechazado(argComprobante.IdOperacion)
                mobj_N_AdminContratos.RegistrarError(argComprobante.IdOperacion, obj_N_AdminCAE.Observaciones & vbCrLf & obj_N_AdminCAE.Errores & vbCrLf & obj_N_AdminCAE.Eventos)
                Return "R"

            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbInformation, "SiCoFa")
            Return "ERROR"

        End Try

    End Function
    Private Sub GenerarQR(ByRef argComprobante As Comprobante)

        Try

            Dim CUIT As Long = CLng(Replace(argComprobante.Locador.Documento.Numero, "-", ""))
            Dim PVta As Integer = CInt(argComprobante.PVenta)
            Dim NumComp As Long = CLng(argComprobante.NumComp)
            argComprobante.QR = New QRCompE(argComprobante.FechaComp, CUIT, PVta, argComprobante.TipoComprobante.CodiTC_AFIP, NumComp, argComprobante.ImpBto, argComprobante.Cliente.Documento.TipoDoc.CodiTDoc, argComprobante.Cliente.Documento.Numero, argComprobante.CAE.NumCAE)

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub
    Private Sub GenerarPdf(ByRef argComprobante As Comprobante)

        Try

            Dim objPdf As New clsReporteComprobantes
            With objPdf
                .Locador.Add(argComprobante.Locador)
                .DocumentoLocador.Add(argComprobante.Locador.Documento)
                .IVALocador.Add(argComprobante.Locador.IVA)
                .Cliente.Add(argComprobante.Cliente)
                .DocumentoCliente.Add(argComprobante.Cliente.Documento)
                .IVACliente.Add(argComprobante.Cliente.IVA)
                .TipoDocumentoCliente.Add(argComprobante.Cliente.Documento.TipoDoc)
                .Encabezado.Add(argComprobante)
                .TipoComprobante.Add(argComprobante.TipoComprobante)
                .Detalle = argComprobante.Detalle
                .CAE.Add(argComprobante.CAE)
                .QR.Add(argComprobante.QR)
                .Copia = "ORIGINAL"

                If argComprobante.CompAsoc IsNot Nothing Then
                    .CompAsoc = "Comprobante Asociado: " & argComprobante.CompAsoc.TipoComprobante.TipoComprobante & " " & argComprobante.CompAsoc.TipoComprobante.Letra & " " & argComprobante.CompAsoc.PVenta & "-" & argComprobante.CompAsoc.NumComp
                Else
                    .CompAsoc = ""
                End If

                .PathArchivo = Application.StartupPath & "\Temp\" & argComprobante.TipoComprobante.CodiTC_SiCoFa & "-" & argComprobante.PVenta & "-" & argComprobante.NumComp & ".pdf"
                .Run("PDFA4")
                .Dispose()

            End With

            objPdf.Run("PDFA4")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub GenerarComprobantes()

        If mobjComprobantes Is Nothing Then
            MsgBox("No existen comprobantes para generar", vbInformation, "SiCoFa")
            Me.Finalize()
            Exit Sub
        End If

        Dim NumComprobantes As Integer = mobjComprobantes.Count
        Dim NumComprobante As Integer
        Dim Cociente As Decimal
        Me.ProgressBar1.Value = 0
        Me.ProgressBar1.Visible = True
        Me.lblProgressBar.Visible = True
        Me.Mensaje.Text = "Generando comprobantes Aprobados....." & vbCrLf & vbCrLf & "Aguarde hasta que finalice el proceso"
        Me.Refresh()

        Try
            For Each c As Comprobante In mobjComprobantes
                NumComprobante += 1
                Cociente = NumComprobante / NumComprobantes * 100
                Me.lblProgressBar.Text = NumComprobante & " Comprobantes de " & NumComprobantes & " Comprobantes procesados"
                Me.ProgressBar1.Value = Cociente
                Me.Refresh()
                Dim Respuesta As String = Me.SolicitarCAE(c)

                Select Case Respuesta
                    Case "A"
                        Me.GenerarQR(c)
                        Me.GenerarPdf(c)
                        mobj_N_AdminContratos.ActualizarCAE(c)
                    Case "R"
                        'Aca no hago nada porque en el procedimiento solicitar CAE ya se registra el error
                    Case "ERROR"
                        If c.CAE IsNot Nothing Then
                            Me.GenerarQR(c)
                            Me.GenerarPdf(c)
                            mobj_N_AdminContratos.ActualizarCAE(c)
                        End If
                End Select
            Next

            Me.ProgressBar1.Value = 0
            Me.ProgressBar1.Visible = False
            Me.lblProgressBar.Visible = False
            Me.Mensaje.Text = "-Comprobantes Aprobados: " & mintNumComprobanteA & vbCrLf & "-Comprobantes Rechazados: " & mintNumcomprobanteR
            Me.mstrSiguienteProceso = "EnviarReportesAprobados"

        Catch ex As Exception
            MsgBox(ex.Message, vbInformation, "SiCoFa")
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
            Case "EnviarReportesAprobados"

            Case "Finalizar"
                Me.Dispose()
                Me.Finalize()
        End Select

    End Sub

End Class