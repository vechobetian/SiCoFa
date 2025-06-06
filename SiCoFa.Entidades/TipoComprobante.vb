Public Class TipoComprobante
    Property CodiTC_SiCoFa As String
    Property CodiTC_AFIP As String
    Property TipoComprobante As String
    Property Letra As String
    Public Sub New(ByVal argCodiTC_SiCoFa As String)
        Me.CodiTC_SiCoFa = argCodiTC_SiCoFa
        Me.CodiTC_AFIP = Me.ObtenerCodiTC_AFIP
        Me.TipoComprobante = Me.ObtenerTipoComprobante
        Me.Letra = Me.ObtenerLetra(argCodiTC_SiCoFa)
    End Sub
    Private Function ObtenerCodiTC_AFIP() As String
        Select Case Me.CodiTC_SiCoFa
            Case "FAA"
                Return "01"
            Case "FAB"
                Return "06"
            Case "FAC"
                Return "11"
            Case "NCA"
                Return "03"
            Case "NCB"
                Return "08"
            Case "NCC"
                Return "13"
            Case Else
                Return 0
        End Select

    End Function
    Private Function ObtenerTipoComprobante() As String
        Select Case Me.CodiTC_SiCoFa
            Case "FAA", "FAB", "FAC"
                Return "FACTURA"

            Case "NCA", "NCB", "NCC"
                Return "NOTA DE CREDITO"

            Case "REC"
                Return "RECIBO"

            Case "RTO"
                Return "REMITO"

            Case "DI"
                Return "Comp.Interno"

            Case Else
                Return "DESCONOCIDO"
        End Select

    End Function
    Private Function ObtenerLetra(ByVal argCodiTC_SiCoFa As String) As String
        Select Case argCodiTC_SiCoFa
            Case "REC", "MCC", "RTO"
                Return "X"
            Case Else
                Return Right(argCodiTC_SiCoFa, 1)
        End Select
    End Function

End Class
