Public Class Receta
    Public Property IdReceta As Long
    Public Property IdOperacion As Long
    Public Property Plan As PlanOS
    Public Property Tratamiento As String
    Public Property FechaPrescripcion As Date
    Public Property FechaDispensacion As Date
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

    Public Sub New()
        Documento = New Documento
        Credencial = New CredencialOS
        Prescriptor = New Prescriptor
        'Items = New List(Of ItemComprobante)
    End Sub

    Public Sub New(ByVal argPlanOS As PlanOS)

        Me.Plan = argPlanOS

    End Sub

End Class
