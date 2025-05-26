Imports SiCoFa.Negocio
Imports SiCoFa.Entidades
Public Class FrmPagos

    Property Operacion As Operacion
    Property Cliente As Cliente
    Property ImporteAPagar As Decimal
    Property ImporteDescuento As Decimal
    Property ImporteGravado1 As Decimal
    Property ImporteGravado2 As Decimal
    Property ItemsComprobante As List(Of ItemComprobante)

    Private mobj_AdminSicofa As New cls_N_AdminSiCoFa
    Public Sub GenerarComprobante()
        Try
            Dim objComprobante = mobj_AdminSicofa.InsertarComprobante(
                                                                        argOperacion:=Operacion,
                                                                        argCodiTC:="FAB",
                                                                        argImpBto:=ImporteAPagar,
                                                                        argImpDes:=ImporteDescuento,
                                                                        argImpEx:=0,
                                                                        argImpGrav1:=ImporteGravado1,
                                                                        argImpGrav2:=ImporteGravado2,
                                                                        argImpCB:=0,
                                                                        argImpEf:=ImporteAPagar,
                                                                        argImpCC:=0,
                                                                        argImpTar:=0,
                                                                        argIdOperAsoc:=0,
                                                                        argCliente:=Cliente,
                                                                        argEmpresa:=g_ParametrosTerminal.Empresa,
                                                                        argDetalle:=ItemsComprobante,
                                                                        argFiscal:="E"
                                                                        )
            Dim obj_AdminCAE As New cls_N_AdminCAE
            Dim result_CAE As CAE = obj_AdminCAE.ObtenerCAE(objComprobante)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData
            Case Keys.Escape
                Me.DialogResult = DialogResult.Cancel
                Me.Close()

            Case Keys.Enter

                Me.DialogResult = DialogResult.OK
                Me.Hide()
            Case Else
                Return MyBase.ProcessCmdKey(msg, keyData)
        End Select
        Return True ' Asegúrate de devolver True para que la tecla se procese correctamente
    End Function
End Class