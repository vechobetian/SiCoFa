Public NotInheritable Class S_AdminValidadores
    Private Sub New()

    End Sub

    Public Shared Function ObtenerValidador(Validador As String) As IValidador

        Select Case Validador.ToUpper()

            Case "LPAMI"
                Return New LPAMI()

            Case "FLINK"
                Return New FLINK

            Case "MISV"
                Return New MISV

            Case "SIMED"
                Return New SIMED

            Case "ITCS"
                Return New ITC

            Case "COMPA"
                Return New COMPA

            Case Else
                Throw New Exception("Validador no implementado: " & Validador)

        End Select

    End Function
End Class
