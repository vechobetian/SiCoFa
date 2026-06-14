Imports SiCoFa.Datos
Imports SiCoFa.Entidades

Public Class N_AdminObraSociales
    Public Function ObtenerPlanOSPorId(ByVal argIdPlan As Long) As PlanOS
        Dim AdminOS As New D_AdminObraSociales
        Dim objPlanOS As PlanOS
        Try
            objPlanOS = AdminOS.ObtenerPlanOSPorId(argIdPlan)
            Return objPlanOS

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerPlanOSPorId", ex.Message))
            Return Nothing

        End Try
    End Function


End Class
