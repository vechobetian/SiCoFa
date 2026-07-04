Imports System.Data.SqlClient
Imports SiCoFa.Datos
Imports SiCoFa.Entidades

Public Class N_AdminObraSociales
    Public Function ObtenerPlanOSPorId(ByVal argIdPlan As Long) As PlanOS

        Dim AdminOS As New D_AdminObraSociales
        Dim objPlanOS As PlanOS = AdminOS.ObtenerPlanOSPorId(argIdPlan)
        Return objPlanOS

    End Function

    Public Function GenerarIdMensajeValidador(ByVal argValidador As String) As Long

        Dim AdminOS As New D_AdminObraSociales
        Dim IdMensaje As Long = AdminOS.GenerarIdMensajeValidador(argValidador)
        Return IdMensaje

    End Function


End Class
