Imports SiCoFa.Datos
Imports SiCoFa.Entidades
Public Class N_AdminPlanCuentas
    Private mobjD_AdminPlanCuentas As New D_AdminPlanCuentas
    Public Function Rubros() As List(Of RubroContabilidad)
        Return mobjD_AdminPlanCuentas.Rubros
    End Function

    Public Function SubRubros(ByVal argCodiRub As String) As List(Of SubRubroContabilidad)
        Return mobjD_AdminPlanCuentas.SubRubros(argCodiRub)
    End Function

    Public Function CuentasColectivas(ByVal argCodiSubRub As String) As List(Of CuentaColectiva)
        Return mobjD_AdminPlanCuentas.CuentasColectivas(argCodiSubRub)
    End Function
    Public Function CuentasImputables(ByVal argCodiCtaCol As String) As List(Of CuentaImputable)
        Return mobjD_AdminPlanCuentas.CuentasImputables(argCodiCtaCol)
    End Function

End Class
