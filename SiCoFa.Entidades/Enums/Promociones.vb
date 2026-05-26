Namespace Enums

    Public Class Promocion

        Property CodiPro As String
        Property Descripcion As String

        Public Sub New(ByVal argCodiPro As String)

            Me.CodiPro = argCodiPro

            Select Case CodiPro.Trim().ToUpper()

                Case "0"
                    Me.Descripcion =
                        "No Establecida"

                Case "2X1"
                    Me.Descripcion =
                        "Dos por Uno"

                Case "3X2"
                    Me.Descripcion =
                        "Tres por Dos"

                Case "D1U"
                    Me.Descripcion =
                        "Descuento Oferta"

                Case "D2U"
                    Me.Descripcion =
                        "Descuento segunda Unidad"

                Case Else
                    Me.Descripcion =
                        "Desconocida"

            End Select

        End Sub

    End Class

End Namespace

