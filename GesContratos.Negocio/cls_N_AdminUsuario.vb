Imports SiCoFa.Datos
Imports SiCoFa.Entidades
Public Class cls_N_AdminUsuario
    Private mobjD_AdminUsuarios As New cls_D_AdminUsuarios
    Public Function ObtenerUsuarioPorId(ByVal argIdUsuario As Long, ByVal argPassword As String) As Usuario
        Dim objUs As Usuario
        Try
            objUs = mobjD_AdminUsuarios.ObtenerUsuarioPorId(argIdUsuario, argPassword)
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing

        End Try
        Return objUs
    End Function
End Class
