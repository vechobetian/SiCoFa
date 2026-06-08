Public Class PlanOS
    Public Property IdPlan As Long
    Public Property Descripcion As String
    Public Property OS As ObraSocial
    Public Property CS As ObraSocial
    Public Property Proceso As Integer
    Public Property CodiLabora As Integer
    Public Property IdVdm1 As Integer
    Public Property DesGeneral1 As Decimal
    Public Property IdVdm2 As Integer
    Public Property DesGeneral2 As Decimal
    Public Property AtbMonoD As Integer
    Public Property AtbMultiD As Integer
    Public Property UnidRpChico As Integer
    Public Property UnidRpGrande As Integer
    Public Property LineasRta As Integer
    Public Property EnvGrandeRta As Integer
    Public Property IncluyeVL As Boolean
    Public Property DiasVencimientoRta As Integer
    Public Property Display As Boolean
    Public Property Observaciones As String
    Public Property PlanValidacion As String

    Public Sub New(
                  ByVal argIdPlan As Long,
                  ByVal argDescripcion As String,
                  ByVal argOS As ObraSocial,
                  ByVal argCS As ObraSocial,
                  ByVal argProceso As Integer,
                  ByVal argCodiLabora As Integer,
                  ByVal argIdVdm1 As Integer,
                  ByVal argDesGeneral1 As Decimal,
                  ByVal argIdVdm2 As Integer,
                  ByVal argDesGeneral2 As Decimal,
                  ByVal argAtbMonoD As Integer,
                  ByVal argAtbMultiD As Integer,
                  ByVal argUnidRpChico As Integer,
                  ByVal argUnidRpGrande As Integer,
                  ByVal argLineasRta As Integer,
                  ByVal argEnvGrandeRta As Integer,
                  ByVal argIncluyeVL As Boolean,
                  ByVal argDiasVencimientoRta As Integer,
                  ByVal argDisplay As Boolean,
                  ByVal argObservaciones As String,
                  ByVal argPlanValidacion As String
                  )

        Me.IdPlan = argIdPlan
        Me.Descripcion = argDescripcion
        Me.OS = argOS
        Me.CS = argCS
        Me.Proceso = argProceso
        Me.CodiLabora = argCodiLabora
        Me.IdVdm1 = argIdVdm1
        Me.DesGeneral1 = argDesGeneral1
        Me.IdVdm2 = argIdVdm2
        Me.DesGeneral2 = argDesGeneral2
        Me.AtbMonoD = argAtbMonoD
        Me.AtbMultiD = argAtbMultiD
        Me.UnidRpChico = argUnidRpChico
        Me.UnidRpGrande = argUnidRpGrande
        Me.LineasRta = argLineasRta
        Me.EnvGrandeRta = argEnvGrandeRta
        Me.IncluyeVL = argIncluyeVL
        Me.DiasVencimientoRta = argDiasVencimientoRta
        Me.Display = argDisplay
        Me.Observaciones = argObservaciones
        Me.PlanValidacion = argPlanValidacion

    End Sub



End Class
