Imports SiCoFa.Datos
Imports SiCoFa.Entidades

Public Class N_AdminSecciones
#Region "Administracion de Secciones"
    Public Function ObtenerSeccionPorId(ByVal argIdSeccion As Int32) As Seccion

        Dim AdminSecciones As New D_AdminSecciones
        Dim objSec As Seccion
        Try
            objSec = AdminSecciones.ObtenerSeccionPorId(argIdSeccion)
            Return objSec

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerSeccionPorId", ex.Message))
            Return Nothing

        End Try
    End Function
    Public Function ListarSecciones(ByVal argTextoBuscado As String) As List(Of Seccion)
        Dim AdminSecciones As New D_AdminSecciones
        Dim ls As List(Of Seccion)

        Try
            ls = AdminSecciones.ListarSecciones(argTextoBuscado)
            Return ls

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ListarSecciones", ex.Message))
            Return Nothing

        End Try
    End Function
    Public Function InsertarSecciones(
                                    ByVal argSeccion As String,
                                    ByVal argEstablecerPrecio As Boolean
                                    ) As String
        Try
            Dim AdminSecciones As New D_AdminSecciones
            Dim SeccionInsertada As String = AdminSecciones.InsertarSeccion(
                                                                                 UCase(argSeccion),
                                                                                 argEstablecerPrecio
                                                                                 )
            Return SeccionInsertada

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarSeccion", ex.Message))
            Return ""

        End Try

    End Function
    Public Function ActualizarSeccion(
                                      ByVal argIdSeccion As String,
                                      ByVal argSeccion As String,
                                      ByVal argEstablecerPrecio As Boolean
                                      ) As Boolean

        Try

            Dim AdminSecciones As New D_AdminSecciones
            Dim Actualizado As Boolean = AdminSecciones.ActualizarSeccion(
                                                                              argIdSeccion,
                                                                              UCase(argSeccion),
                                                                              argEstablecerPrecio
                                                                              )
            Return Actualizado
        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ActualizarSeccion", ex.Message))
            Return False

        End Try

    End Function
#End Region

End Class
