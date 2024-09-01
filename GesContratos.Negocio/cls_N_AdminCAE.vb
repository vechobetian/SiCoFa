Imports SiCoFa.Datos
Imports SiCoFa.Entidades
Public Class cls_N_AdminCAE
    Private mobj_D_AdminCAE As New cls_D_AdminCAE
    Public Function ObtenerCAE(ByVal argComprobante As Comprobante) As CAE
        Try
            Dim objCAE As CAE = mobj_D_AdminCAE.ObtenerCAE(argComprobante)
            Return objCAE

        Catch ex As Exception

            Throw New Exception(vecho.MensajeError(Me.ToString, "ObtenerCAE", ex.Message))
            Return Nothing

        End Try
    End Function

End Class


