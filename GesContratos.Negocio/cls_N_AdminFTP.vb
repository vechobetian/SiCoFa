Imports SiCoFa.Datos
Public Class cls_N_AdminFTP
    Private mobj_D_AdminFTP As New cls_D_AdminFTP
    Public Sub ListFiles(remotePath As String)
        Try
            mobj_D_AdminFTP.ListFiles(remotePath)

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ListFiles", ex.Message))

        End Try
    End Sub
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
