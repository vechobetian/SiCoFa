Imports SiCoFa.Datos
Imports SiCoFa.Entidades

Public Class N_AdminComprobantes

    Public Function ObtenerTipoComprobantePorCodiTC(ByVal argCodiTC As String) As TipoComprobante

        Dim AdminComprobantes As New D_AdminComprobantes
        Dim tc As TipoComprobante

        Try

            tc = AdminComprobantes.ObtenerTipoComprobantePorCodiTC(argCodiTC)
            Return tc

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerTipoComprobantePorCodiTC", ex.Message))
            Return Nothing

        End Try

    End Function

    Public Function ListarTipoComprobantes(ByVal argTextoBuscado As String) As List(Of TipoComprobante)
        Dim AdminComprobantes As New D_AdminComprobantes
        Dim ltc As List(Of TipoComprobante)

        Try
            ltc = AdminComprobantes.ListarTipoComprobantes(argTextoBuscado)
            Return ltc

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ListarTipoComprobantes", ex.Message))
            Return Nothing

        End Try
    End Function

    Public Function GenerarFacturaElectronica(ByRef argComprobante As Comprobante) As Boolean

        Try
            If SolicitarCAE(argComprobante) = True Then
                GenerarQR(argComprobante)
                Dim obj_D_AdminComprobantes As New D_AdminComprobantes
                Dim Actualizado As Boolean = obj_D_AdminComprobantes.ActualizarCAE(argComprobante)
                Return Actualizado

            Else
                Return False
            End If

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "GenerarFacturaElectronica", ex.Message))
            Return False
        End Try

    End Function

    Private Function SolicitarCAE(ByRef argComprobante As Comprobante) As Boolean

        Try

            Dim obj_N_AdminCAE As New N_AdminCAE
            argComprobante.CAE = obj_N_AdminCAE.ObtenerCAE(argComprobante)

            If argComprobante.CAE Is Nothing Then
                Return False
                Exit Function
            End If

            argComprobante.NumComp = Format(argComprobante.CAE.NumComp, "00000000")

            Return True

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "SolicitarCAE", ex.Message))
            Return False

        End Try

    End Function

    Private Sub GenerarQR(ByRef argComprobante As Comprobante)

        Try
            If argComprobante.CAE IsNot Nothing Then
                Dim CUIT As Long = CLng(argComprobante.Empresa.Documento.Numero)
                Dim PVta As Integer = CInt(argComprobante.PVenta)
                Dim NumComp As Long = CLng(argComprobante.NumComp)

                argComprobante.QR = New QRCompE(argComprobante.FechaComp, CUIT, PVta, argComprobante.TipoComprobante.CodiTC_ARCA, NumComp, argComprobante.ImpBto, argComprobante.Cliente.Documento.TipoDoc.CodiTDoc, argComprobante.Cliente.Documento.Numero, argComprobante.CAE.NumCAE)

            End If

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "GenerarQR", ex.Message))
        End Try
    End Sub

End Class
