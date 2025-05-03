Public Class ListaPrecios
    Property CodiLP As String
    Property ListaPrecios As String
    Property PRef As String
    Property PAplic As Decimal
    Property NumAc As Long
    Property Estado As String

    Public Sub New(ByVal argCodiLP As String, ByVal argListaPrecios As String, ByVal argPRef As String, ByVal argPAplic As Decimal, ByVal argNumAc As Long, ByVal argEstado As String)
        Me.CodiLP = argCodiLP
        Me.ListaPrecios = argListaPrecios
        Me.PRef = argPRef
        Me.PAplic = argPAplic
        Me.NumAc = argNumAc
        Me.Estado = argEstado
    End Sub

End Class
