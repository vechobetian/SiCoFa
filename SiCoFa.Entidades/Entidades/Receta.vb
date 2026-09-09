Public Class Receta
    Public Property IdReceta As Long
    Public Property IdOperacion As Long
    Public Property Plan As PlanOS
    Public Property Tratamiento As String
    Public Property FechaPrescripcion As Date?
    Public Property FechaDispensacion As Date?
    Public Property NumReceta As String
    Public Property Documento As Documento
    Public Property Credencial As CredencialOS
    Public Property Prescriptor As Prescriptor
    Public Property Diagnostico As String
    Public Property ImporteTotal As Decimal
    Public Property ImporteOS As Decimal
    Public Property ImporteCS As Decimal
    Public Property ImporteAf As Decimal
    Public Property NumAutorizacion As String
    Public Property EstadoReceta As String
    Public Property Items As List(Of ItemComprobante)
    Public Property Reporte As Byte()

    Public Sub New(
                  argIdReceta As Long,
                  argIdoperacion As Long,
                  argPlan As PlanOS,
                  argFechaPrescripcion As Date,
                  argFechaDispensacion As Date,
                  argNumReceta As String,
                  argDocumento As Documento,
                  argCredencial As CredencialOS,
                  argImporteTotal As Decimal,
                  argImporteOS As Decimal,
                  argImporteCS As Decimal,
                  argImporteAf As Decimal,
                  argNumAutorizacion As String,
                  argEstadoReceta As String
                  )
        Me.IdReceta = argIdReceta
        Me.IdOperacion = argIdoperacion
        Me.Plan = argPlan
        Me.FechaPrescripcion = argFechaPrescripcion
        Me.FechaDispensacion = argFechaDispensacion
        Me.NumReceta = argNumReceta
        Me.Documento = argDocumento
        Me.Credencial = argCredencial
        Me.ImporteTotal = argImporteTotal
        Me.ImporteOS = argImporteOS
        Me.ImporteCS = argImporteCS
        Me.ImporteAf = argImporteAf
        Me.NumAutorizacion = argNumAutorizacion
        Me.EstadoReceta = argEstadoReceta
    End Sub

    Public Sub New()
        Documento = New Documento
        Credencial = New CredencialOS
        Prescriptor = New Prescriptor
    End Sub

    Public Sub New(ByVal argPlanOS As PlanOS)

        Me.Plan = argPlanOS

    End Sub

End Class
