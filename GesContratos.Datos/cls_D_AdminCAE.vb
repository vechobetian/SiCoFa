Imports System.Globalization
Imports SiCoFa.Entidades
Imports SiCoFa.Datos.WSN
Public Class cls_D_AdminCAE
    Property Observaciones As String
    Property Errores As String
    Property Eventos As String
    Private URLWsn As String
    Private mvarLogin As LoginTicket
    Private mvarAuthRequest As FEAuthRequest
    Private mstrEstadoCab As String
    Private mstrEstadoDet As String
    Public Function ObtenerCAE(ByVal argComprobante As Comprobante) As CAE

        If argComprobante.Locador.Documento.Numero = "20210362712" Then
            URLWsn = "https://wswhomo.afip.gov.ar/wsfev1/service.asmx?WSDL" 'URL WSN Homologacion

        Else
            URLWsn = "https://servicios1.afip.gov.ar/wsfev1/service.asmx?WSDL" 'URL WSN Produccion

        End If

        Dim objN_AdminLT As New cls_D_AdminLoginTicket
        Dim objCAE As CAE = Nothing
        Dim NroCbteAutorizado As Long
        Me.Observaciones = ""
        Me.Errores = ""
        Me.Eventos = ""

        Try

            If objN_AdminLT.AccesoAlWSN(argComprobante.Locador.Documento.Numero) = False Then
                Me.Observaciones = "No se pudo Obtener Ticket de Acceso"
                Return Nothing
            End If

            mvarLogin = objN_AdminLT.TicketAcceso
            mvarAuthRequest = New FEAuthRequest()
            mvarAuthRequest.Cuit = Replace(argComprobante.Locador.Documento.Numero, "-", "")
            mvarAuthRequest.Sign = mvarLogin.Sign
            mvarAuthRequest.Token = mvarLogin.Token

            Dim service As WSN.Service = getServicio()
            service.ClientCertificates.Add(objN_AdminLT.CertFirmante)

            Dim req As New FECAERequest
            Dim cab As New FECAECabRequest
            Dim det As New FECAEDetRequest

            cab.CantReg = 1
            cab.PtoVta = argComprobante.PVenta
            cab.CbteTipo = argComprobante.TipoComprobante.CodiTC_AFIP

            req.FeCabReq = cab

            With det
                .Concepto = 1
                .DocTipo = argComprobante.Cliente.Documento.TipoDoc.CodiTDoc
                .DocNro = argComprobante.Cliente.Documento.Numero

                Dim lastRes As FERecuperaLastCbteResponse = service.FECompUltimoAutorizado(mvarAuthRequest, CInt(argComprobante.PVenta), argComprobante.TipoComprobante.CodiTC_AFIP)
                Dim last As Integer = lastRes.CbteNro

                NroCbteAutorizado = last + 1

                .CbteDesde = last + 1
                .CbteHasta = last + 1
                .CbteFch = Now.ToString("yyyyMMdd")

                If argComprobante.TipoComprobante.TipoComprobante = "NOTA DE CREDITO" Then
                    Dim cbteAsoc As New CbteAsoc
                    With cbteAsoc
                        .Tipo = argComprobante.CompAsoc.TipoComprobante.CodiTC_AFIP
                        .PtoVta = argComprobante.CompAsoc.PVenta
                        .Nro = argComprobante.CompAsoc.NumComp
                        '.Cuit = Replace(cbteOrigen.Empresa.CUIT, "-", "") por ahora no requerido
                        '.CbteFch = cbteOrigen.FechaComp por ahora no requerido
                    End With
                    .CbtesAsoc = {cbteAsoc}
                End If

                If argComprobante.TipoComprobante.CodiTC_AFIP = 11 Or argComprobante.TipoComprobante.CodiTC_AFIP = 13 Then
                    .ImpTotConc = 0
                    .ImpNeto = argComprobante.ImpEx + argComprobante.ImpGrav1 + argComprobante.ImpGrav2
                    .ImpIVA = 0
                    .ImpTotal = argComprobante.ImpEx + argComprobante.ImpGrav1 + argComprobante.ImpGrav2
                Else
                    .ImpTotConc = argComprobante.ImpEx
                    .ImpNeto = argComprobante.ImpNeto1 + argComprobante.ImpNeto2
                    .ImpIVA = argComprobante.ImpIVA1 + argComprobante.ImpIVA2
                    .ImpTotal = argComprobante.ImpNeto1 + argComprobante.ImpNeto2 + argComprobante.ImpIVA1 + argComprobante.ImpIVA2 + argComprobante.ImpEx

                    Dim alicuota1 As New AlicIva
                    Dim alicuota2 As New AlicIva

                    If argComprobante.ImpIVA1 > 0 Then
                        With alicuota1
                            .Id = 5
                            .BaseImp = argComprobante.ImpNeto1
                            .Importe = argComprobante.ImpIVA1
                        End With

                    End If

                    If argComprobante.ImpIVA2 > 0 Then
                        With alicuota2
                            .Id = 4
                            .BaseImp = argComprobante.ImpNeto2
                            .Importe = argComprobante.ImpIVA2
                        End With

                    End If

                    If argComprobante.ImpIVA1 > 0 And argComprobante.ImpIVA2 > 0 Then
                        .Iva = {alicuota1, alicuota2}
                    ElseIf argComprobante.ImpIVA1 > 0 And argComprobante.ImpIVA2 = 0 Then
                        .Iva = {alicuota1}
                    ElseIf argComprobante.ImpIVA1 = 0 And argComprobante.ImpIVA2 > 0 Then
                        .Iva = {alicuota2}
                    End If

                End If

                .ImpOpEx = 0
                .ImpTrib = 0
                .MonId = "PES"
                .MonCotiz = 1
            End With

            req.FeDetReq = {det}
            service.Timeout = 30000
            Dim r = service.FECAESolicitar(mvarAuthRequest, req)

            mstrEstadoCab = r.FeCabResp.Resultado
            mstrEstadoDet = r.FeDetResp(0).Resultado

            If mstrEstadoCab = "A" And mstrEstadoDet = "A" Then
                objCAE = New CAE(NroCbteAutorizado, r.FeDetResp(0).CAE, DateTime.ParseExact(r.FeDetResp(0).CAEFchVto, "yyyyMMdd", CultureInfo.InvariantCulture))
            End If

            If r.FeDetResp(0).Observaciones IsNot Nothing Then
                For Each o In r.FeDetResp(0).Observaciones
                    Me.Observaciones &= String.Format("Obs: {0} ({1})", o.Msg, o.Code) & vbCrLf
                Next
                'Throw New Exception(vecho.MensajeError(Me.ToString, "ObtenerCAE", Observaciones))
                MsgBox(vecho.MensajeError(Me.ToString, "ObtenerCAE", Observaciones))
            End If

            If r.Errors IsNot Nothing Then

                For Each er In r.Errors
                    Me.Errores &= String.Format("Er: {0}: {1}", er.Code, er.Msg) & vbCrLf
                Next
                Throw New Exception(vecho.MensajeError(Me.ToString, "ObtenerCAE", Errores))

            End If

            If r.Events IsNot Nothing Then

                For Each ev In r.Events
                    Me.Eventos &= String.Format("Ev: {0}: {1}", ev.Code, ev.Msg) & vbCrLf
                Next
                'Throw New Exception(vecho.MensajeError(Me.ToString, "ObtenerCAE", Eventos))

            End If
            Return objCAE

        Catch ex As Exception
            'If ex.HResult <> -2146233079 Then
            Throw New Exception(vecho.MensajeError(Me.ToString, "ObtenerCAE", ex.Message))
            Return Nothing
            'End If

        End Try

    End Function

    Private Function getServicio() As Service
        Dim s As New Service
        s.Url = URLWsn
        Return s
    End Function


End Class


