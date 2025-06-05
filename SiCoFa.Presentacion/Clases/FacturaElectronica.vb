Imports SiCoFa.Negocio
Imports SiCoFa.Entidades

Public Class FacturaElectronica

    Public mobj_AdminSicofa As New N_AdminSiCoFa

    Public Function GenerarFacturaElectronica(ByRef argComprobante As Comprobante) As Boolean

        Try
            If SolicitarCAE(argComprobante) = True Then
                GenerarQR(argComprobante)
                Dim Actualizado As Boolean = mobj_AdminSicofa.ActualizarCAE(argComprobante)
                Call ImprimirA4(argComprobante, 1)
                Return True

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

            Dim objN_AdminCAE As New N_AdminCAE
            argComprobante.CAE = objN_AdminCAE.ObtenerCAE(argComprobante)

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

                argComprobante.QR = New QRCompE(argComprobante.FechaComp, CUIT, PVta, argComprobante.TipoComprobante.CodiTC_AFIP, NumComp, argComprobante.ImpBto, argComprobante.Cliente.Documento.TipoDoc.CodiTDoc, argComprobante.Cliente.Documento.Numero, argComprobante.CAE.NumCAE)

            End If

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "GenerarQR", ex.Message))
        End Try
    End Sub

    Private Sub pdfA4(ByVal argPath As String, ByVal argComprobante As Comprobante)

        Try
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ImprimirA4(ByVal argComprobante As Comprobante, ByVal argNumCopias As Integer)
        Dim objRC As New ReporteComprobantes
        Dim Copia As String = ""

        Try
            If argNumCopias < 0 Then
                Select Case Math.Abs(argNumCopias)
                    Case 1
                        Copia = "ORIGINAL"
                    Case 2
                        Copia = "DUPLICADO"
                    Case 3
                        Copia = "TRIPLICADO"
                End Select

                With objRC
                    .Operacion.Add(argComprobante.Operacion)
                    .Empresa.Add(argComprobante.Empresa)
                    .DocumentoEmpresa.Add(argComprobante.Empresa.Documento)
                    .IVAEmpresa.Add(argComprobante.Empresa.IVA)
                    .Cliente.Add(argComprobante.Cliente)
                    .DocumentoCliente.Add(argComprobante.Cliente.Documento)
                    .IVACliente.Add(argComprobante.Cliente.IVA)
                    .TipoDocumentoCliente.Add(argComprobante.Cliente.Documento.TipoDoc)
                    .Encabezado.Add(argComprobante)
                    .TipoComprobante.Add(argComprobante.TipoComprobante)
                    .Detalle = argComprobante.Detalle
                    .CAE.Add(argComprobante.CAE)
                    .QR.Add(argComprobante.QR)
                    .Copia = Copia
                    '.PathReporte = mobjPater.PathServer
                    '.Impresora = mobjPater.Impresora

                    If argComprobante.CompAsoc IsNot Nothing Then
                        .CompAsoc = "Comprobante Asociado: " & argComprobante.CompAsoc.TipoComprobante.TipoComprobante & " " & argComprobante.CompAsoc.TipoComprobante.Letra & " " & argComprobante.CompAsoc.PVenta & "-" & argComprobante.CompAsoc.NumComp
                    Else
                        .CompAsoc = ""
                    End If
                End With

                objRC.Run()
                argNumCopias = 0
            End If

            For x = 1 To argNumCopias
                Select Case x
                    Case 1
                        Copia = "ORIGINAL"
                    Case 2
                        Copia = "DUPLICADO"
                    Case 3
                        Copia = "TRIPLICADO"
                End Select

                With objRC
                    .Operacion.Add(argComprobante.Operacion)
                    .Empresa.Add(argComprobante.Empresa)
                    .DocumentoEmpresa.Add(argComprobante.Empresa.Documento)
                    .IVAEmpresa.Add(argComprobante.Empresa.IVA)
                    .Cliente.Add(argComprobante.Cliente)
                    .DocumentoCliente.Add(argComprobante.Cliente.Documento)
                    .IVACliente.Add(argComprobante.Cliente.IVA)
                    .TipoDocumentoCliente.Add(argComprobante.Cliente.Documento.TipoDoc)
                    .Encabezado.Add(argComprobante)
                    .TipoComprobante.Add(argComprobante.TipoComprobante)
                    .Detalle = argComprobante.Detalle
                    .CAE.Add(argComprobante.CAE)
                    .QR.Add(argComprobante.QR)
                    .Copia = Copia
                    '.PathReporte = mobjPater.PathServer
                    '.Impresora = mobjPater.Impresora

                    If argComprobante.CompAsoc IsNot Nothing Then
                        .CompAsoc = "Comprobante Asociado: " & argComprobante.CompAsoc.TipoComprobante.TipoComprobante & " " & argComprobante.CompAsoc.TipoComprobante.Letra & " " & argComprobante.CompAsoc.PVenta & "-" & argComprobante.CompAsoc.NumComp
                    Else
                        .CompAsoc = ""
                    End If
                End With

                objRC.Run()
            Next
            objRC.Dispose()

        Catch ex As Exception
            Throw ex
        End Try

        objRC.Dispose()

    End Sub

    Private Sub ImprimirTK(ByVal argNumCopias As Integer)

        Try

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ImprimirTK58(ByVal argNumCopias As Integer)

        Try

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EnviarMail()


        Try


        Catch ex As Exception
            MsgBox(ex.Message) 'no hago Throw ex porque me registra error en la base de datos

        End Try

    End Sub

    Private Sub GuardarComo()

        Try

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

End Class
