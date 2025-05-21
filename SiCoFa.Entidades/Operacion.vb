
Public Class Operacion
    Property IdOperacion() As Long
    Property Inicio() As DateTime
    Property Fin As DateTime
    Property Empresa As Empresa
    Property IdPC As String
    Property IdCaja As Int32
    Property Usuario As Usuario
    Property TipoOperacion As TipoOperacion
    Property EstadoOperacion As String
    Property Observaciones() As String
    Property DesError As String
    Public Sub New(
                    ByVal argIdOperacion As Long,
                    ByVal argInicio As DateTime,
                    ByVal argFin As DateTime,
                    ByVal argEmpresa As Empresa,
                    ByVal argIdPC As String,
                    ByVal argIdCaja As Int32,
                    ByVal argUsuario As Usuario,
                    ByVal argTipoOperacion As TipoOperacion,
                    ByVal argEstadoOperacion As String,
                    ByVal argObservaciones As String,
                    ByVal argDesError As String
                    )

        Me.IdOperacion = argIdOperacion
        Me.Inicio = argInicio
        Me.Fin = argFin
        Me.Empresa = argEmpresa
        Me.IdPC = argIdPC
        Me.IdCaja = argIdCaja
        Me.Usuario = argUsuario
        Me.TipoOperacion = argTipoOperacion
        Me.EstadoOperacion = argEstadoOperacion
        Me.Observaciones = argObservaciones
        Me.DesError = argDesError
    End Sub

End Class
