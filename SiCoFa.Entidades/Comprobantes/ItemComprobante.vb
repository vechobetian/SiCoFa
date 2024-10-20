Public Class ItemComprobante
    Property Descripcion As String
    Property Cantidad As Decimal
    Property AlicIVA As Decimal
    Property PUnit As Decimal
    Property DUnit As Decimal
    Property PDes As Decimal
    Property OtraDescripcion As String
    Property Importe As Decimal
    Property ImporteDescuento As Decimal
    Property ImporteConDescuento As Decimal

    Public Sub New(
                  ByVal argDescripcion As String,
                  ByVal argCantidad As Decimal,
                  ByVal argPUnit As Decimal,
                  ByVal argGravado As Integer,
                  ByVal argDisIva As Boolean,
                  ByVal argDUnit As Decimal,
                  ByVal argPDes As Decimal,
                  ByVal argOtraDescripcion As String
                  )
        Try
            Me.Descripcion = argDescripcion
            Me.Cantidad = argCantidad

            Select Case argGravado
                Case 0
                    Me.AlicIVA = 0
                Case 1
                    Me.AlicIVA = 21
                Case 2
                    Me.AlicIVA = 10.5
            End Select

            If argDisIva And argGravado > 0 Then
                Me.PUnit = Math.Round(argPUnit / (1 + Me.AlicIVA / 100), 2, MidpointRounding.ToEven)
                Me.DUnit = Math.Round(argDUnit / (1 + Me.AlicIVA / 100), 2, MidpointRounding.ToEven)
            Else
                Me.PUnit = Math.Round(argPUnit, 2, MidpointRounding.ToEven)
                Me.DUnit = Math.Round(argDUnit, 2, MidpointRounding.ToEven)
            End If

            Me.Importe = Math.Round(Me.Cantidad * Me.PUnit, 2, MidpointRounding.ToEven)
            Me.PDes = argPDes
            Me.OtraDescripcion = argOtraDescripcion
            Me.ImporteDescuento = Math.Round(Me.Cantidad * Me.DUnit, 2, MidpointRounding.ToEven)
            Me.ImporteConDescuento = Me.Importe - Me.ImporteDescuento

        Catch ex As Exception
            Throw ex
        End Try

    End Sub



End Class
