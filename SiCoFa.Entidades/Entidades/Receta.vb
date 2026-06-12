Public Class Receta
    Public Property IdReceta As Long
    Public Property IdOperacion As Long
    Public Property Plan As PlanOS
    Public Property FechaPrescripcion As Date
    Public Property FechaDispensacion As Date
    Public Property NumReceta As String
    Public Property Documento As Documento
    Public Property Credencial As CredencialOS
    Public Property Prescriptor As Prescriptor
    Public Property ImporteTotal As Decimal
    Public Property ImporteOS As Decimal
    Public Property ImporteAf As Decimal
    Public Property NumAutorizacion As String
    Public Property EstadoReceta As String

    Public Sub New(
                  ByVal argPlanOS As PlanOS,
                  ByVal argFechaPrescripcion As Date,
                  ByVal argNumReceta As String,
                  ByVal argDodumento As Documento,
                  ByVal argCredencial As CredencialOS,
                  ByVal argPrescriptor As Prescriptor
                  )

        Me.Plan = argPlanOS
        Me.FechaPrescripcion = argFechaPrescripcion
        Me.NumReceta = argNumReceta
        Me.Documento = argDodumento
        Me.Credencial = argCredencial
        Me.Prescriptor = argPrescriptor

    End Sub

End Class
