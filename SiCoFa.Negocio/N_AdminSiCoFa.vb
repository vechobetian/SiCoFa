Imports SiCoFa.Entidades
Public Class N_AdminSiCoFa

#Region "AFIP"

    Public Function TiposDocumento() As List(Of TipoDocumento)
        Dim TDocs As New List(Of TipoDocumento)
        TDocs.Add(New TipoDocumento("80"))
        TDocs.Add(New TipoDocumento("86"))
        TDocs.Add(New TipoDocumento("90"))
        TDocs.Add(New TipoDocumento("96"))
        Return TDocs.OrderBy(Function(x) x.TipoDocumento).ToList()
    End Function

    Public Function TiposIVA() As List(Of IVA)
        Dim TIVAS As New List(Of IVA)
        TIVAS.Add(New IVA("CF"))
        TIVAS.Add(New IVA("RI"))
        TIVAS.Add(New IVA("MT"))
        TIVAS.Add(New IVA("EX"))
        Return TIVAS.OrderBy(Function(x) x.TipoIVA).ToList()
    End Function

    Public Function AlicuotasIVA() As List(Of AlicuotaIVA)
        Dim ALIVAS As New List(Of AlicuotaIVA)
        ALIVAS.Add(New AlicuotaIVA(Convert.ToDecimal(10.5)))
        ALIVAS.Add(New AlicuotaIVA(Convert.ToDecimal(21)))
        Return ALIVAS.OrderBy(Function(x) x.AlicuotaIVA).ToList
    End Function

    Public Function ObtenerTipoComprobanteVenta(ByVal argCodIVAEmpresa As String, ByVal argCodIVACliente As String) As TipoComprobante

        Dim AdminComprobantes As New N_AdminComprobantes
        Dim objTC As TipoComprobante = Nothing

        Select Case argCodIVAEmpresa

            Case "RI"
                Select Case argCodIVACliente
                    Case "CF", "MT", "EX"
                        objTC = AdminComprobantes.ObtenerTipoComprobantePorCodiTC("FAB")
                    Case "RI"
                        objTC = AdminComprobantes.ObtenerTipoComprobantePorCodiTC("FAA")
                End Select
            Case "MT"
                objTC = AdminComprobantes.ObtenerTipoComprobantePorCodiTC("FAC")

        End Select

        Return objTC

    End Function

#End Region

#Region "Procesos del Negocio Generales"
    Public Function Provincias() As List(Of Provincia)
        Dim p As New List(Of Provincia)
        With p
            .Add(New Provincia("A", "NEUQUEN"))
            .Add(New Provincia("B", "BUENOS AIRES"))
            .Add(New Provincia("C", "CABA"))
            .Add(New Provincia("D", "LA RIOJA"))
            .Add(New Provincia("E", "ENTRE RIOS"))
            .Add(New Provincia("F", "FORMOSA"))
            .Add(New Provincia("G", "SANTIAGO DEL ESTERO"))
            .Add(New Provincia("H", "CHACO"))
            .Add(New Provincia("I", "MISIONES"))
            .Add(New Provincia("J", "CORRIENTES"))
            .Add(New Provincia("K", "SAN JUAN"))
            .Add(New Provincia("L", "LA PAMPA"))
            .Add(New Provincia("M", "MENDOZA"))
            .Add(New Provincia("N", "CATAMARCA"))
            .Add(New Provincia("O", "SAN LUIS"))
            .Add(New Provincia("P", "TUCUMAN"))
            .Add(New Provincia("Q", "TIERRA DEL FUEGO"))
            .Add(New Provincia("R", "RIO NEGRO"))
            .Add(New Provincia("S", "SANTA FE"))
            .Add(New Provincia("T", "SALTA"))
            .Add(New Provincia("U", "CHUBUT"))
            .Add(New Provincia("X", "CORDOBA"))
            .Add(New Provincia("Y", "JUJUY"))
            .Add(New Provincia("Z", "SANTA CRUZ"))
        End With

        Return p.OrderBy(Function(x) x.Provincia).ToList()

    End Function

#End Region

End Class
