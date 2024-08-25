
Public Class Operacion
    Property IdOperacion() As Long
    Property Fecha() As Date
    Property CodiAE As String
    Property CodiTO As String
    Property TipoOperacion As TipoOperacion
    Property IdUsuario As Long
    Property Usuario As Usuario
    Property EstadoOperacion() As String
    Property Observaciones() As String
    Property DesError As String
    Public Sub New(
                    ByVal argIdOperacion As Long,
                    ByVal argFecha As Date,
                    ByVal argCodiAE As String,
                    ByVal argCodiTO As String,
                    ByVal argIdUsuario As Long,
                    ByVal argEstadoOperacion As String,
                    ByVal argObservaciones As String,
                    ByVal argDesError As String
                    )

        Me.IdOperacion = argIdOperacion
        Me.Fecha = argFecha
        Me.CodiAE = argCodiAE
        Me.CodiTO = argCodiTO
        Me.IdUsuario = argIdUsuario
        Me.EstadoOperacion = argEstadoOperacion
        Me.Observaciones = argObservaciones
        Me.DesError = argDesError
    End Sub

End Class
