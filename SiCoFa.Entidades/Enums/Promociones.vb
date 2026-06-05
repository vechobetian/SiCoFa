Namespace Enums

    Public Class Promocion

        Property CodiPro As String
        Property Descripcion As String

        Public Sub New(ByVal argCodiPro As String)

            Me.CodiPro = argCodiPro

            Select Case CodiPro.Trim().ToUpper()

                Case "0"
                    Me.Descripcion = "NO ESTABLECIDA"

                Case "2X1"
                    Me.Descripcion = "DOS POR UNO"

                Case "3X2"
                    Me.Descripcion = "TRES POR DOS"

                Case "D1U"
                    Me.Descripcion = "DESCUENTO OFERTA"

                Case "D2U"
                    Me.Descripcion = "DESCUENTO SEGUNDA UNIDAD"

                Case Else
                    Me.Descripcion = "DESCONOCIDA"

            End Select

        End Sub

    End Class

End Namespace

