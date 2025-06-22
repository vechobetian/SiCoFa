Imports SiCoFa.Datos
Imports SiCoFa.Entidades

Public Class N_AdminUsuarios
    Public Function ObtenerUsuarioPorId(ByVal argIdUsuario As Int32) As Usuario
        Dim AdminUsuarios As New D_AdminUsuarios
        Dim objUs As Usuario = Nothing

        Try
            objUs = AdminUsuarios.ObtenerUsuarioPorId(argIdUsuario)
            Return objUs

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerUsuarioPorId", ex.Message))

        End Try
    End Function

    Public Function ListarUsuarios(ByVal argTextoBuscado As String) As List(Of Usuario)
        Dim AdminUsuarios As New D_AdminUsuarios
        Dim lu As List(Of Usuario) = Nothing

        Try
            lu = AdminUsuarios.ListarUsuarios(argTextoBuscado)
            Return lu

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ListarUsuarios", ex.Message))

        End Try
    End Function

    Public Function InsertarUsuario(
                                    ByVal argNombre As String,
                                    ByVal argDomicilio As String,
                                    ByVal argLocalidad As String,
                                    ByVal argProvincia As String,
                                    ByVal argTelefono As String,
                                    ByVal argEmail As String,
                                    ByVal argCodiTDoc As String,
                                    ByVal argNumDoc As String
                                    ) As Integer
        Try
            Dim AdminUsuarios As New D_AdminUsuarios
            Dim IdUsuario As Integer = AdminUsuarios.InsertarUsuario(
                                                                           UCase(argNombre),
                                                                           UCase(argDomicilio),
                                                                           UCase(argLocalidad),
                                                                           UCase(argProvincia),
                                                                           UCase(argTelefono),
                                                                           UCase(argEmail),
                                                                           UCase(argCodiTDoc),
                                                                           UCase(argNumDoc)
                                                                           )
            Return IdUsuario

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarUsuario", ex.Message))

        End Try

    End Function

    Public Function ActualizarUsuario(
                                      ByVal argIdEmpleado As Int32,
                                      ByVal argDomicilio As String,
                                      ByVal argLocalidad As String,
                                      ByVal argProvincia As String,
                                      ByVal argTelefono As String,
                                      ByVal argEmail As String,
                                      ByVal argCodiTDoc As String,
                                      ByVal argNumDoc As String,
                                      ByVal argEstado As String
                                     ) As Boolean

        Try

            Dim AdminUsuarios As New D_AdminUsuarios
            Dim Actualizado As Boolean = AdminUsuarios.ActualizarUsuario(
                                                                               argIdEmpleado,
                                                                               UCase(argDomicilio),
                                                                               UCase(argLocalidad),
                                                                               UCase(argProvincia),
                                                                               argTelefono,
                                                                               argEmail,
                                                                               argCodiTDoc,
                                                                               argNumDoc,
                                                                               argEstado
                                                                               )
            Return Actualizado

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ActualizarUsuario", ex.Message))

        End Try

    End Function

    Public Function VerificarAutorizacionProceso(ByVal argIdUsuario As Integer, ByVal argPassword As String, ByVal argIdProceso As String) As String

        Try

            Dim AdminUsuarios As New D_AdminUsuarios
            Dim Autorizacion As String = AdminUsuarios.VerificarAutorizacionProceso(argIdUsuario, argPassword, argIdProceso)
            Return Autorizacion

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "VerificarAutorizacionProceso", ex.Message))

        End Try

    End Function

End Class
