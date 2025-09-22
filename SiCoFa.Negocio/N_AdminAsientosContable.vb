Imports SiCoFa.Datos
Imports SiCoFa.Entidades

Public Class N_AdminAsientosContable

    Public Function ObtenerCuentaImputablePorCodiCta(ByVal argCodiCta) As CuentaImputable
        Dim AdminAsientosContable As New D_AdminAsientosContable

        Try
            Dim ci As CuentaImputable = AdminAsientosContable.ObtenerCuentaImputablePorCodiCta(argCodiCta)
            Return ci

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerCuentaImputablePorCodiCta", ex.Message))
            Return Nothing

        End Try

    End Function

    Public Function ListarCuentasImputables(ByVal argTextoBuscado As String) As List(Of CuentaImputable)
        Dim AdminAsientosContable As New D_AdminAsientosContable
        Dim lc As List(Of CuentaImputable)

        Try
            lc = AdminAsientosContable.ListarCuentasImputables(argTextoBuscado)
            Return lc

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ListarCuentasImputables", ex.Message))
            Return Nothing

        End Try
    End Function

End Class
