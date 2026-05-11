Imports SiCoFa.Datos
Imports SiCoFa.Entidades

Public Class N_AdminProcesosActualizacion

    Public Function ObtenerProcesosActualizacion() As List(Of ProcesoActualizacion)

        Try

            Dim AdminProcesoActualizacion As New D_AdminProcesosActualizacion

            Return AdminProcesoActualizacion.ObtenerProcesosActualizacion()

        Catch ex As Exception

            Throw New Exception(
            Vecho.MensajeError(Me.ToString, NameOf(ObtenerProcesosActualizacion), ex.Message))
        End Try

    End Function

End Class
