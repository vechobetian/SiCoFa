Public NotInheritable Class S_AdminAutorizadores
    Private Sub New()
    End Sub

    Public Shared Function Crear(nombreValidador As String) As IValidador

        Select Case nombreValidador.ToUpper()

            Case "LPAMI"
                Return New LPAMI()

            Case "FLINK"
                Return New FLINK

            Case "MISV"
                Return New MISV

            Case Else
                Throw New Exception("Validador no implementado: " & nombreValidador)

        End Select

    End Function
End Class
