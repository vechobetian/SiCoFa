Public Class RegConsumoLuz
    Property IdRegistro As Long
    Property FechaLAn As Date
    Property FechaLAc As Date
    Property Mes As String
    Property Año As String
    Property Medidor As Medidor
    Property LecturaAnterior As Integer
    Property LecturaActual As Integer
    Property Consumo As Integer
    Property ImpCalculado As Decimal
    Property ImpFactura As Decimal
    Property ImpNeto As Decimal
    Property Ley3052 As Decimal
    Property IVA As Decimal
    Property RG2123 As Decimal
    Property Observaciones As String
    Property Estado As String
    Property Detalle As List(Of ItemConsumoLuz)
    Public Sub New(
                  ByVal argIdRegistro As Long,
                  ByVal argFechaLAn As Date,
                  ByVal argFechaLAc As Date,
                  ByVal argMes As String,
                  ByVal argAño As String,
                  ByVal argMedidor As Medidor,
                  ByVal argLecturaAnterior As Integer,
                  ByVal argLecturaActual As Integer,
                  ByVal argConsumo As Integer,
                  ByVal argImpCalculado As Decimal,
                  ByVal argImpFactura As Decimal,
                  ByVal argImpNeto As Decimal,
                  ByVal argLey3052 As Decimal,
                  ByVal argIVA As Decimal,
                  ByVal argRG2123 As Decimal,
                  ByVal argObservaciones As String,
                  ByVal argEstado As String,
                  ByVal argDetalle As List(Of ItemConsumoLuz)
                  )
        Me.IdRegistro = argIdRegistro
        Me.FechaLAn = argFechaLAn
        Me.FechaLAc = argFechaLAc
        Me.Mes = argMes
        Me.Año = argAño
        Me.Medidor = argMedidor
        Me.LecturaAnterior = argLecturaAnterior
        Me.LecturaActual = argLecturaActual
        Me.Consumo = argConsumo
        Me.ImpCalculado = argImpCalculado
        Me.ImpFactura = argImpFactura
        Me.ImpNeto = argImpNeto
        Me.Ley3052 = argLey3052
        Me.IVA = argIVA
        Me.RG2123 = argRG2123
        Me.Observaciones = argObservaciones
        Me.Estado = argEstado
        Me.Detalle = argDetalle

    End Sub


End Class
