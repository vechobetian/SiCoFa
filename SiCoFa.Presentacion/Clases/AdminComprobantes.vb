Imports SiCoFa.Negocio
Imports SiCoFa.Entidades

Public Class AdminComprobantes

    Public mobj_AdminSicofa As New N_AdminSiCoFa

    Public Sub ImprimirComprobante(ByVal argComprobante As Comprobante)

        Select Case g_ParametrosTerminal.Papel
            Case "A4"
                Call ImprimirA4(argComprobante, 1)

            Case "TK"

        End Select

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
                    '.Copia = Copia
                    '.PathReporte = mobjPater.PathServer
                    '.Impresora = mobjPater.Impresora

                    'If argComprobante.CompAsoc IsNot Nothing Then
                    '.CompAsoc = "Comprobante Asociado: " & argComprobante.CompAsoc.TipoComprobante.TipoComprobante & " " & argComprobante.CompAsoc.TipoComprobante.Letra & " " & argComprobante.CompAsoc.PVenta & "-" & argComprobante.CompAsoc.NumComp
                    'Else
                    '.CompAsoc = ""
                    'End If
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
                    '.Operacion.Add(argComprobante.Operacion)
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
