Public Class Servicio
    Property CodiS As String
    Property DescripcionServicio As String
    Property PUnit As Decimal

    Public Sub New(ByVal argCodiS As String, ByVal argDescripcionServicio As String, ByVal argPUnit As Decimal)
        Me.CodiS = argCodiS
        Me.DescripcionServicio = argDescripcionServicio
        Me.PUnit = argPUnit
    End Sub

End Class
