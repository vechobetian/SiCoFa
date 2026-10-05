Option Strict On

Public Class ListaPrecios
    Property CodiLP As String
    Property ListaPrecios As String
    Property PrecioReferencia As String
    ' CORREGIDO: Se cambia a Decimal? para permitir valores Nothing/NULL
    Property PorcentajeAplicado As Decimal?
    Property NumeroActualizacion As Long?
    Property Baja As Boolean?
    Property Prioridad As Integer?

    Public Sub New()
        ' Constructor vacío para Newtonsoft.Json
    End Sub

    Public Sub New(ByVal argCodiLP As String,
                   ByVal argListaPrecios As String,
                   ByVal argPrecioReferencia As String,
                   ByVal argPorcentajeAplicado As Decimal?,
                   ByVal argNumeroActualizacion As Long?,
                   ByVal argBaja As Boolean?,
                   ByVal argPrioridad As Integer?)
        Me.CodiLP = argCodiLP
        Me.ListaPrecios = argListaPrecios
        Me.PrecioReferencia = argPrecioReferencia
        Me.PorcentajeAplicado = argPorcentajeAplicado
        Me.NumeroActualizacion = argNumeroActualizacion
        Me.Baja = argBaja
        Me.Prioridad = argPrioridad
    End Sub

    Public Sub New(ByVal argCodiLP As String, ByVal argListaPrecios As String)
        Me.CodiLP = argCodiLP
        Me.ListaPrecios = argListaPrecios
        Me.PrecioReferencia = Nothing
        Me.PorcentajeAplicado = Nothing
        Me.NumeroActualizacion = Nothing
        Me.Baja = Nothing
        Me.Prioridad = Nothing
    End Sub

End Class