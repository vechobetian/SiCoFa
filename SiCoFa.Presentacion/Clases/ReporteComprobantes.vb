Imports SiCoFa.Negocio
Imports SiCoFa.Entidades

Public Class ReporteComprobantes

    Public mobj_AdminSicofa As New N_AdminSiCoFa

    Public Sub ImprimirComprobante(ByVal argComprobante As Comprobante, ByVal argNumCopias As Int16)

        Select Case g_ParametrosTerminal.Papel
            Case "A4"
                Call ImprimirA4(argComprobante, argNumCopias)

            Case "TK80"
                Me.ImprimirTK80(argComprobante, argNumCopias)

            Case "TK58"
                Me.ImprimirTK58(argComprobante, argNumCopias)


        End Select

    End Sub

    Private Sub pdfA4(ByVal argPath As String, ByVal argComprobante As Comprobante)

        Try
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ImprimirA4(ByVal argComprobante As Comprobante, ByVal argNumCopias As Integer)
        Dim objRC As New ComprobantesRdlc
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
                        .CompAsoc = "Comprobante Asociado: " & argComprobante.CompAsoc.TipoComprobante.TipoComprobanteCLetra & " " & argComprobante.CompAsoc.PVenta & "-" & argComprobante.CompAsoc.NumComp
                    Else
                        .CompAsoc = ""
                    End If

                End With

                objRC.Run("IMPA4")
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
                        .CompAsoc = "Comprobante Asociado: " & argComprobante.CompAsoc.TipoComprobante.TipoComprobanteCLetra & " " & argComprobante.CompAsoc.PVenta & "-" & argComprobante.CompAsoc.NumComp
                    Else
                        .CompAsoc = ""
                    End If
                End With

                objRC.Run("IMPA4")
            Next
            objRC.Dispose()

        Catch ex As Exception
            Throw ex
        End Try

        objRC.Dispose()

    End Sub

    Private Sub ImprimirTK80(ByVal argComprobante As Comprobante, ByVal argNumCopias As Integer)

        Try
            Dim objTkt80 As New Ticket80
            Dim Copia As String = ""
            objTkt80.Comprobante = argComprobante
            'objTkt80.Impresora = mobjPater.Impresora

            If argNumCopias < 0 Then
                Select Case Math.Abs(argNumCopias)
                    Case 1
                        Copia = "                ORIGINAL                 "
                    Case 2
                        Copia = "               DUPLICADO                 "
                    Case 3
                        Copia = "               TRIPLICADO                "
                End Select

                objTkt80.Imprimir(Copia)
            End If

            For x = 1 To argNumCopias
                Select Case x
                    Case 1
                        Copia = "                ORIGINAL                 "
                    Case 2
                        Copia = "               DUPLICADO                 "
                    Case 3
                        Copia = "               TRIPLICADO                "
                End Select

                objTkt80.Imprimir(Copia)
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ImprimirTK58(ByVal argComprobante As Comprobante, ByVal argNumCopias As Integer)

        Try
            Dim objTkt58 As New Ticket58
            Dim Copia As String = ""
            objTkt58.Comprobante = argComprobante
            'objTkt80.Impresora = mobjPater.Impresora

            If argNumCopias < 0 Then
                Select Case Math.Abs(argNumCopias)
                    Case 1
                        Copia = "                ORIGINAL                 "
                    Case 2
                        Copia = "               DUPLICADO                 "
                    Case 3
                        Copia = "               TRIPLICADO                "
                End Select

                objTkt58.Imprimir(Copia)
            End If

            For x = 1 To argNumCopias
                Select Case x
                    Case 1
                        Copia = "                ORIGINAL                 "
                    Case 2
                        Copia = "               DUPLICADO                 "
                    Case 3
                        Copia = "               TRIPLICADO                "
                End Select

                objTkt58.Imprimir(Copia)
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
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
