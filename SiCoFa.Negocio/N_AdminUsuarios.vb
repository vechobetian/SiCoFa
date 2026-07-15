Imports SiCoFa.Datos
Imports SiCoFa.Entidades

Public Class N_AdminUsuarios
    Public Function ObtenerUsuarioPorId(ByVal argIdUsuario As Int32) As Usuario
        Dim AdminUsuarios As New D_AdminUsuarios
        Dim objUs As Usuario = Nothing

        objUs = AdminUsuarios.ObtenerUsuarioPorId(argIdUsuario)
        Return objUs

    End Function

    Public Function ListarUsuarios(ByVal argTextoBuscado As String) As List(Of Usuario)
        Dim AdminUsuarios As New D_AdminUsuarios
        Dim lu As List(Of Usuario) = Nothing

        lu = AdminUsuarios.ListarUsuarios(argTextoBuscado)
        Return lu

    End Function

    Public Function InsertarUsuario(
                                    ByVal argNombre As String,
                                    ByVal argDomicilio As String,
                                    ByVal argLocalidad As String,
                                    ByVal argProvincia As String,
                                    ByVal argTelefono As String,
                                    ByVal argEmail As String,
                                    ByVal argCodiTD As String,
                                    ByVal argNumDoc As String
                                    ) As Integer
        Dim AdminUsuarios As New D_AdminUsuarios
        Dim IdUsuario As Integer = AdminUsuarios.InsertarUsuario(
                                                                     UCase(argNombre),
                                                                     UCase(argDomicilio),
                                                                     UCase(argLocalidad),
                                                                     UCase(argProvincia),
                                                                     UCase(argTelefono),
                                                                     UCase(argEmail),
                                                                     UCase(argCodiTD),
                                                                     UCase(argNumDoc)
                                                                     )
        Return IdUsuario

    End Function

    Public Function ActualizarUsuario(
                                      ByVal argIdEmpleado As Int32,
                                      ByVal argDomicilio As String,
                                      ByVal argLocalidad As String,
                                      ByVal argProvincia As String,
                                      ByVal argTelefono As String,
                                      ByVal argEmail As String,
                                      ByVal argCodiTD As String,
                                      ByVal argNumDoc As String,
                                      ByVal argEstado As String
                                     ) As Boolean


        Dim AdminUsuarios As New D_AdminUsuarios
        Dim Actualizado As Boolean = AdminUsuarios.ActualizarUsuario(
                                                                         argIdEmpleado,
                                                                         UCase(argDomicilio),
                                                                         UCase(argLocalidad),
                                                                         UCase(argProvincia),
                                                                         argTelefono,
                                                                         argEmail,
                                                                         argCodiTD,
                                                                         argNumDoc,
                                                                         argEstado
                                                                         )
        Return Actualizado

    End Function

    Public Function VerificarAutorizacionProceso(ByVal argIdUsuario As Integer, ByVal argPassword As String, ByVal argIdProceso As String) As String


        Dim AdminUsuarios As New D_AdminUsuarios
            Dim Autorizacion As String = AdminUsuarios.VerificarAutorizacionProceso(argIdUsuario, argPassword, argIdProceso)
            Return Autorizacion


    End Function

End Class
