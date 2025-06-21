Imports SiCoFa.Datos
Imports SiCoFa.Entidades
Public Class N_AdminCajas
    Public Function CierreCajaTransaccion(ByVal argMacAddress As String, ByVal argCaja As Caja, ByVal argEmpresa As Empresa, ByVal argUsuario As Usuario, ByVal argComprobante As Comprobante) As Boolean
        Dim AdmiCajas As New D_AdminCajas
        Dim Finalizado As Boolean = AdmiCajas.CierreCajaTransaccion(argMacAddress, argCaja, argEmpresa, argUsuario, argComprobante)

        Return Finalizado
    End Function
End Class
