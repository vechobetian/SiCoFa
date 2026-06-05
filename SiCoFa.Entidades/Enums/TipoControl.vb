Namespace Enums

    Public Class TipoControl

        Property CodiTiCo As String
        Property Descripcion As String

        Public Sub New(ByVal argCodiTiCo As String)

            Me.CodiTiCo = argCodiTiCo

            Select Case CodiTiCo.Trim().ToUpper()

                Case "0"
                    Me.Descripcion =
                        "NO CONTROLADO"

                Case "2"
                    Me.Descripcion =
                        "PSICOTROTIPO LISTA II"

                Case "3"
                    Me.Descripcion =
                        "PSICOTROPICO LISTA III"

                Case "4"
                    Me.Descripcion =
                        "PSICOTROPICO LISTA IV"

                Case "6"
                    Me.Descripcion =
                        "ESTUPEFACIENTE LISTA I"

                Case "7"
                    Me.Descripcion =
                        "ESTUPEFACIENTE LISTA II"

                Case "8"
                    Me.Descripcion =
                        "ESTUPEFACIENTE LISTA III"

                Case "9"
                    Me.Descripcion =
                        "SUCCINILCOLINA"

                Case "A"
                    Me.Descripcion =
                        "VENTA VIGILADA"

                Case Else
                    Me.Descripcion =
                        "DESCONOCIDO"

            End Select

        End Sub

    End Class

End Namespace

