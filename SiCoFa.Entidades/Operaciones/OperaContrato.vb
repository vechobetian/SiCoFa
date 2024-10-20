Public Class OperaContrato
    Property IdOperacion As Long
    Property IdContrato As Integer
    Property Resu As String
    Property ImpFacturado As Decimal
    Property ImpCancelado As Decimal
    Property ImpNoCancelado As Decimal
    Property EstadoOperaContrato As String
    Public Sub New(ByVal argIdOperacion As Long, ByVal argIdContrato As Integer, ByVal argResu As String, ByVal argImpFacturado As Decimal, ByVal argImpCancelado As Decimal, ByVal argImpNoCancelado As Decimal, ByVal argEstadoOperaContrato As String)
        Me.IdOperacion = argIdOperacion
        Me.IdContrato = argIdContrato
        Me.Resu = Left(argResu, 2) & "-" & Right(argResu, 2)
        Me.ImpFacturado = argImpFacturado
        Me.ImpCancelado = argImpCancelado
        Me.ImpNoCancelado = argImpNoCancelado
        Me.EstadoOperaContrato = argEstadoOperaContrato
    End Sub

End Class
