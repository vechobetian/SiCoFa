
Public Class Operacion
    Property IdOperacion() As Long
    Property Inicio() As DateTime
    Property Fin As DateTime
    Property IdEmpresa As Int32
    Property IdPC As String
    Property IdCaja As Int32
    Property IdUsuario As Int32
    Property CodiTO As String
    Property EstadoOperacion As String
    Property Observaciones() As String
    Property DesError As String
    Public Sub New(
                    ByVal argIdOperacion As Long,
                    ByVal argInicio As DateTime,
                    ByVal argFin As DateTime,
                    ByVal argIdEmpresa As Int32,
                    ByVal argIdPC As String,
                    ByVal argIdCaja As Int32,
                    ByVal argIdUsuario As Int32,
                    ByVal argCodiTO As String,
                    ByVal argEstadoOperacion As String,
                    ByVal argObservaciones As String,
                    ByVal argDesError As String
                    )

        Me.IdOperacion = argIdOperacion
        Me.Inicio = argInicio
        Me.Fin = argFin
        Me.IdEmpresa = argIdEmpresa
        Me.IdPC = argIdPC
        Me.IdCaja = argIdCaja
        Me.IdUsuario = argIdUsuario
        Me.CodiTO = argCodiTO
        Me.EstadoOperacion = argEstadoOperacion
        Me.Observaciones = argObservaciones
        Me.DesError = argDesError
    End Sub

End Class
