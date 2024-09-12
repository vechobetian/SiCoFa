Imports System.IO
Imports SiCoFa.Negocio
Imports SiCoFa.Entidades
Imports System.ComponentModel
Public Class FrmEnviarMailServicios
    Private mobj_N_AdminContratos As New cls_N_AdminContratos
    Private mobjContratos As List(Of Contrato)
    Private mblnSuspender As Boolean
    Public Sub IniciarProcesos()
        Try
            Me.ProgressBar1.Visible = True
            Me.lblProgressBar.Visible = True
            Me.RevisarContratos()
            Me.GenerarPdfs()
            Me.EnviarReportes()
            Me.ProgressBar1.Visible = False
            Me.lblProgressBar.Visible = False
            Me.Mensaje.Left = 75
            Me.Mensaje.Top = 50
            Me.Mensaje.Text = "Se enviaron " & mobjContratos.Count & " reportes"
            Me.Aceptar.Visible = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub RevisarContratos()
        Try

            Me.lblProgressBar.Text = ""
            Me.Mensaje.Text = "Revisando Contratos....." & vbCrLf & vbCrLf & "Aguarde hasta que finalice el proceso"
            Me.Show()
            Me.Refresh()

            Dim lc As List(Of Contrato) = mobj_N_AdminContratos.ListarContratos("VIGENTE")
            Dim lc_con_saldo As New List(Of Contrato)
            Dim NumContratosVigentes As Integer = lc.Count
            Dim NumContratosRevisados As Integer
            Dim Cociente As Decimal

            For Each c As Contrato In lc
                If mblnSuspender = True Then
                    Exit Sub
                End If

                Me.lblProgressBar.Text = NumContratosRevisados & " Contratos revisados de " & NumContratosVigentes & " Contratos Vigentes"
                Me.ProgressBar1.Value = Cociente
                Me.Refresh()

                c.Locador = mobj_N_AdminContratos.ObtenerLocadorPorId(c.IdLocador)
                c.Cliente = mobj_N_AdminContratos.ObtenerClientePorId(c.IdCliente)
                c.ServiciosAsociados = mobj_N_AdminContratos.ObtenerServiciosAsociados(c.IdContrato)
                c.OperaContratos = mobj_N_AdminContratos.ListaOperaContratos(0, 0, c.IdContrato, "", "DEBE")
                c.PagosCliente = mobj_N_AdminContratos.ListaPagosCliente(0, c.IdContrato, "ABIERTO")
                If c.EstadoContrato = "VIGENTE" Then
                    lc_con_saldo.Add(c)
                End If
                NumContratosRevisados += 1
                Cociente = NumContratosRevisados / NumContratosVigentes * 100
                Application.DoEvents()
            Next

            mobjContratos = lc_con_saldo
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub GenerarPdfs()
        Dim NumContratos As Integer = mobjContratos.Count
        Dim NumReporte As Integer
        Dim Cociente As Decimal
        Try

            Me.lblProgressBar.Text = ""
            Me.Mensaje.Text = "Generando reportes....." & vbCrLf & vbCrLf & "Aguarde hasta que finalice el proceso"
            Me.Refresh()

            For Each c As Contrato In mobjContratos
                Dim pdf As New clsEstadoCuentaPDF

                If mblnSuspender = True Then
                    Exit Sub
                End If

                Me.lblProgressBar.Text = NumReporte & " Reportes generados de " & NumContratos & " Contratos para reportar"
                Me.ProgressBar1.Value = Cociente
                Me.Refresh()

                With pdf
                    .Locador.Add(c.Locador)
                    .DocumentoLocador.Add(c.Locador.Documento)
                    .IVALocador.Add(c.Locador.IVA)
                    .Cliente.Add(c.Cliente)
                    .DocumentoCliente.Add(c.Cliente.Documento)
                    .IVACliente.Add(c.Cliente.IVA)
                    .TipoDocumentoCliente.Add(c.Cliente.Documento.TipoDoc)
                    .DetalleServicios = Me.DetalleServicios(c.ServiciosAsociados)
                    If c.TotalAdeudado > 0 Then
                        .DetalleCuenta = Me.DetalleCuenta(c.OperaContratos)
                    Else
                        .DetalleCuenta = "No se registran Resúmenes adeudados"
                    End If

                    .TotalAdeudado = "Total Adeudado a la fecha:" & Space(68 - Len(Format(c.TotalAdeudado, "Standard"))) & Format(c.TotalAdeudado, "Standard")
                    .SaldoAnticipos = "Saldo Anticipos:" & Space(78 - Len(Format(c.SaldoAnticipos, "Standard"))) & Format(c.SaldoAnticipos, "Standard")
                    .PathArchivo = Application.StartupPath & "\Temp\" & "DC" & Format(c.IdContrato, "0000") & c.UltimoDev
                    .Run()
                    .Dispose()
                End With

                pdf = Nothing
                NumReporte += 1
                Cociente = NumReporte / NumContratos * 100
                Application.DoEvents()
            Next
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub
    Private Sub EnviarReportes()
        Dim NumContratos As Integer = mobjContratos.Count
        Dim NumReporte As Integer
        Dim Cociente As Decimal
        Dim obj_N_AdminEmail As New cls_N_AdminEmail
        Dim Mensaje As String
        Dim Archivo As String

        Try

            Me.lblProgressBar.Text = ""
            Me.Mensaje.Text = "Enviando reportes....." & vbCrLf & vbCrLf & "Aguarde hasta que finalice el proceso"
            Me.Refresh()

            For Each c As Contrato In mobjContratos
                If mblnSuspender = True Then
                    Exit Sub
                End If

                Me.lblProgressBar.Text = NumReporte & " Reportes enviados de " & NumContratos & " Contratos para reportar"
                Me.ProgressBar1.Value = Cociente
                Me.Refresh()

                Archivo = "DC" & Format(c.IdContrato, "0000") & c.UltimoDev & ".pdf"
                Mensaje = "Estimado Cliente, adjunto Estado de Cuenta" & vbCrLf & vbCrLf & "Atentamente: " & c.Locador.Nombre
                obj_N_AdminEmail.EnviarMail(c.Locador.Nombre, c.Cliente.Email, "Detalle de Cuenta", Mensaje, Application.StartupPath & "\Temp\" & Archivo)

                NumReporte += 1
                Cociente = NumReporte / NumContratos * 100
                Application.DoEvents()
            Next

            obj_N_AdminEmail = Nothing

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub
    Private Function DetalleCuenta(ByVal loc As List(Of OperaContrato)) As String
        Dim linea As String
        Dim str As String = ""
        Try

            For Each oc As OperaContrato In loc
                linea = "Resumen " & Strings.Left(oc.Resu, 2) & "/" & Strings.Right(oc.Resu, 2) & Space(32 - Len(Format(oc.ImpFacturado, "Standard"))) & Format(oc.ImpFacturado, "Standard") & Space(26 - Len(Format(oc.ImpCancelado, "Standard"))) & Format(oc.ImpCancelado, "Standard") & Space(23 - Len(Format(oc.ImpNoCancelado, "Standard"))) & Format(oc.ImpNoCancelado, "Standard") & vbCrLf
                str &= linea
            Next
            Return str

        Catch ex As Exception
            MsgBox(ex.Message)
            Return ""

        End Try

    End Function
    Private Function DetalleServicios(ByVal lsa As List(Of ServicioAsociado)) As String
        Dim linea As String
        Dim str As String = ""
        Try
            For Each sa As ServicioAsociado In lsa
                linea = sa.Servicio.DescripcionServicio & Space(40 - Len(sa.Servicio.DescripcionServicio)) & sa.Cantidad & Space(30 - Len(Format(sa.Servicio.PUnit, "Standard"))) & Format(sa.Servicio.PUnit, "Standard") & Space(23 - Len(Format(sa.Importe, "Standard"))) & Format(sa.Importe, "Standard") & vbCrLf
                str &= linea
            Next
            Return str

        Catch ex As Exception
            MsgBox(ex.Message)
            Return ""

        End Try

    End Function
    Private Sub FrmEnviarMailServiciosPrestados_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        mblnSuspender = True
        Me.Dispose()
    End Sub
    Private Sub Aceptar_Click(sender As Object, e As EventArgs) Handles Aceptar.Click
        Me.Dispose()
        Me.Finalize()
    End Sub
End Class