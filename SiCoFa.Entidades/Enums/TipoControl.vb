Namespace Enums

    Public Class TipoControl

        Property CodiTiCo As String
        Property Descripcion As String

        Public Sub New(ByVal argCodiTiCo As String)

            Me.CodiTiCo = argCodiTiCo

            Select Case CodiTiCo.Trim().ToUpper()

                Case "0"
                    Me.Descripcion =
                        "No Controlado"

                Case "2"
                    Me.Descripcion =
                        "Psicotrópico Lista II"

                Case "3"
                    Me.Descripcion =
                        "Psicotrópico Lista III"

                Case "4"
                    Me.Descripcion =
                        "Psicotrópico Lista IV"

                Case "6"
                    Me.Descripcion =
                        "Estupefaciente Lista I"

                Case "7"
                    Me.Descripcion =
                        "Estupefaciente Lista II"

                Case "8"
                    Me.Descripcion =
                        "Estupefaciente Lista III"

                Case "9"
                    Me.Descripcion =
                        "Succinilcolina"

                Case "A"
                    Me.Descripcion =
                        "Venta Vigilada"

                Case Else
                    Me.Descripcion =
                        "Desconocido"

            End Select

        End Sub

    End Class

End Namespace

