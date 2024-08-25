Imports System.Globalization
Imports SiCoFa.Entidades
Imports SiCoFa.Negocio.WSN
Public Class cls_N_AdminCAE_ConLote
    Property Observaciones As String
    Property Errores As String
    Property Eventos As String
    Private URLWsn As String
    Private mvarLogin As LoginTicket
    Private mvarAuthRequest As FEAuthRequest
    Private mstrEstadoCab As String
    Private mstrEstadoDet As String
    Public Function ProcesarComprobantes(ByVal argLocador As Locador, ByVal argCodiTC_AFIP As String, ByVal argPVenta As String, ByVal argComprobantes As List(Of Comprobante)) As List(Of Comprobante)

        If argLocador.Documento.Numero = "20210362712" Then
            URLWsn = "https://wswhomo.afip.gov.ar/wsfev1/service.asmx?WSDL" 'URL WSN Homologacion

        Else
            URLWsn = "https://servicios1.afip.gov.ar/wsfev1/service.asmx?WSDL" 'URL WSN Produccion

        End If

        Dim objN_AdminLT As New cls_N_AdminLoginTicket
        Dim NroCbte As Long

        Try

            If objN_AdminLT.AccesoAlWSN(argLocador.Documento.Numero) = False Then
                Me.Observaciones = "No se pudo Obtener Ticket de Acceso"
                Return Nothing
            End If

            mvarLogin = objN_AdminLT.TicketAcceso
            mvarAuthRequest = New FEAuthRequest()
            mvarAuthRequest.Cuit = Replace(argLocador.Documento.Numero, "-", "")
            mvarAuthRequest.Sign = mvarLogin.Sign
            mvarAuthRequest.Token = mvarLogin.Token

            Dim service As WSN.Service = getServicio()
            service.ClientCertificates.Add(objN_AdminLT.CertFirmante)

            Dim req As New FECAERequest
            Dim cab As New FECAECabRequest
            Dim dets As New List(Of FECAEDetRequest)

            cab.CantReg = argComprobantes.Count
            cab.PtoVta = argPVenta
            cab.CbteTipo = argCodiTC_AFIP

            req.FeCabReq = cab
            Dim lastRes As FERecuperaLastCbteResponse = service.FECompUltimoAutorizado(mvarAuthRequest, argPVenta, argCodiTC_AFIP)
            Dim last As Integer = lastRes.CbteNro
            Dim x As Integer

            For Each c As Comprobante In argComprobantes
                Dim det As New FECAEDetRequest
                x += 1
                With det
                    .Concepto = 1
                    .DocTipo = c.Cliente.Documento.TipoDoc.CodiTDoc
                    .DocNro = c.Cliente.Documento.Numero

                    NroCbte = last + x
                    c.NumComp = NroCbte 'A pesar de no que aun no esta aprobado le pongo el numero para encontrarlo cuando proceso la respuesta

                    .CbteDesde = last + x
                    .CbteHasta = last + x
                    .CbteFch = Now.ToString("yyyyMMdd")

                    If argCodiTC_AFIP = 3 Or argCodiTC_AFIP = 8 Or argCodiTC_AFIP = 13 Then
                        Dim cbteAsoc As New CbteAsoc
                        With cbteAsoc
                            .Tipo = c.CompAsoc.TipoComprobante.CodiTC_AFIP
                            .PtoVta = c.CompAsoc.PVenta
                            .Nro = c.CompAsoc.NumComp
                            '.Cuit = Replace(cbteOrigen.Empresa.CUIT, "-", "") por ahora no requerido
                            '.CbteFch = cbteOrigen.FechaComp por ahora no requerido
                        End With
                        .CbtesAsoc = {cbteAsoc}
                    End If

                    If argCodiTC_AFIP = 11 Or argCodiTC_AFIP = 13 Then
                        .ImpTotConc = 0
                        .ImpNeto = c.ImpEx + c.ImpGrav1 + c.ImpGrav2
                        .ImpIVA = 0
                        .ImpTotal = c.ImpEx + c.ImpGrav1 + c.ImpGrav2
                    Else
                        .ImpTotConc = c.ImpEx
                        .ImpNeto = c.ImpNeto1 + c.ImpNeto2
                        .ImpIVA = c.ImpIVA1 + c.ImpIVA2
                        .ImpTotal = c.ImpNeto1 + c.ImpNeto2 + c.ImpIVA1 + c.ImpIVA2 + c.ImpEx

                        Dim alicuota1 As New AlicIva
                        Dim alicuota2 As New AlicIva

                        If c.ImpIVA1 > 0 Then
                            With alicuota1
                                .Id = 5
                                .BaseImp = c.ImpNeto1
                                .Importe = c.ImpIVA1
                            End With

                        End If

                        If c.ImpIVA2 > 0 Then
                            With alicuota2
                                .Id = 4
                                .BaseImp = c.ImpNeto2
                                .Importe = c.ImpIVA2
                            End With

                        End If

                        If c.ImpIVA1 > 0 And c.ImpIVA2 > 0 Then
                            .Iva = {alicuota1, alicuota2}
                        ElseIf c.ImpIVA1 > 0 And c.ImpIVA2 = 0 Then
                            .Iva = {alicuota1}
                        ElseIf c.ImpIVA1 = 0 And c.ImpIVA2 > 0 Then
                            .Iva = {alicuota2}
                        End If

                    End If

                    .ImpOpEx = 0
                    .ImpTrib = 0
                    .MonId = "PES"
                    .MonCotiz = 1
                End With
                dets.Add(det)
            Next

            req.FeDetReq = dets.ToArray()
            service.Timeout = 30000
            Dim r = service.FECAESolicitar(mvarAuthRequest, req)

            mstrEstadoCab = r.FeCabResp.Resultado

            If mstrEstadoCab = "R" Then
                If r.Errors IsNot Nothing Then

                    For Each er In r.Errors
                        Errores &= String.Format("Er: {0}: {1}", er.Code, er.Msg) & vbCrLf
                    Next
                    Throw New Exception(vecho.MensajeError(Me.ToString, "ObtenerCAE", Errores))

                End If
                Exit Function
            End If

            Dim ComprobantesProcesados As New List(Of Comprobante)

            For index As Integer = 0 To x - 1

                mstrEstadoDet = r.FeDetResp(index).Resultado

                If mstrEstadoDet = "A" Then
                    Dim objCAE As New CAE(r.FeDetResp(index).CbteDesde, r.FeDetResp(index).CAE, DateTime.ParseExact(r.FeDetResp(index).CAEFchVto, "yyyyMMdd", CultureInfo.InvariantCulture))
                    For Each c As Comprobante In argComprobantes
                        If c.NumComp = r.FeDetResp(index).CbteDesde Then
                            c.Operacion.EstadoOperacion = "APROBADO"
                            c.CAE = objCAE
                            ComprobantesProcesados.Add(c)
                        End If
                    Next
                Else
                    If r.FeDetResp(index).Observaciones IsNot Nothing Then
                        For Each o In r.FeDetResp(index).Observaciones
                            Observaciones &= String.Format("Obs: {0} ({1})", o.Msg, o.Code) & vbCrLf
                        Next
                    End If

                    For Each c As Comprobante In argComprobantes
                        If c.NumComp = r.FeDetResp(index).CbteDesde Then
                            Dim objCAE As New CAE("R", "RECHAZADO", Format(Now, "yyyy-MM-dd"))
                            c.CAE = objCAE
                            c.Operacion.EstadoOperacion = "RECHAZADO"
                            c.Operacion.DesError = Observaciones
                            ComprobantesProcesados.Add(c)
                        End If
                    Next
                End If

                If r.Events IsNot Nothing Then

                    For Each ev In r.Events
                        Eventos &= String.Format("Ev: {0}: {1}", ev.Code, ev.Msg) & vbCrLf
                    Next
                    MsgBox(Eventos, vbInformation, "CompE")
                    'Throw New Exception(vecho.MensajeError(Me.ToString, "ObtenerCAE", Eventos))

                End If
            Next
            Return ComprobantesProcesados

        Catch ex As Exception
            If ex.HResult <> -2146233079 Then
                Throw New Exception(vecho.MensajeError(Me.ToString, "ObtenerCAE", ex.Message))
            End If
        End Try



    End Function

    Private Function getServicio() As Service
        Dim s As New Service
        s.Url = URLWsn
        Return s
    End Function


End Class


