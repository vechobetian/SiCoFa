Imports SiCoFa.Datos
Imports SiCoFa.Entidades

Public Class N_AdminFTP
    Private mobj_D_AdminFTP As New D_AdminFTP


    Public Function UploadFile(remotePath As String, localFilePath As String) As String
        Try
            Return mobj_D_AdminFTP.UploadFile(remotePath, localFilePath)

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "UploadFile", ex.Message))
            Return "ERROR"
        End Try

    End Function

    Public Function DownloadFile(remotePath As String, localFilePath As String) As Boolean
        Try
            Return mobj_D_AdminFTP.DownloadFile(remotePath, localFilePath)

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "DownloadFile", ex.Message))
            Return False
        End Try
    End Function

End Class
