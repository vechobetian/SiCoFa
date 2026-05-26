Public Class TipoComprobante
    Property CodiTC_SiCoFa As String
    Property TipoComprobanteCLetra As String
    Property Letra As String
    Property TipoComprobanteSLetra As String
    Property CodiTC_ARCA As String

    Public Sub New(ByVal argCodiTC_SiCoFa As String, ByVal argTipoComprobanteCLetra As String, ByVal argLetra As String, ByVal argTipoComprobanteSLetra As String, ByVal argCodiTCARCA As String)
        Me.CodiTC_SiCoFa = argCodiTC_SiCoFa
        Me.TipoComprobanteCLetra = argTipoComprobanteCLetra
        Me.Letra = argLetra
        Me.TipoComprobanteSLetra = argTipoComprobanteSLetra
        Me.CodiTC_ARCA = argCodiTCARCA
    End Sub

End Class
