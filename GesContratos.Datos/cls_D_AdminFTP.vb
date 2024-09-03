Imports System.Collections.Generic
Imports System.Net
Imports System.IO
Imports System.Linq
Imports SiCoFa.Entidades
Public Class cls_D_AdminFTP
    Private ftpServer As String
    Private ftpUsername As String
    Private ftpPassword As String

    ' Constructor para inicializar el cliente FTP
    Public Sub New()
        ftpServer = "ftp://ftp.sicofa.com.ar"
        ftpUsername = "cliente_sicofa@sicofa.com.ar"
        ftpPassword = "AKBr^8z,,tFz"
    End Sub

    ' Método para listar archivos en el directorio FTP
    Public Sub ListFiles(remotePath As String)
        Dim fileList As New List(Of Archivo)

        Try
            Dim request As FtpWebRequest = CType(WebRequest.Create(ftpServer & remotePath), FtpWebRequest)
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails
            request.Credentials = New NetworkCredential(ftpUsername, ftpPassword)

            Using response As FtpWebResponse = CType(request.GetResponse(), FtpWebResponse)
                Using responseStream As Stream = response.GetResponseStream()
                    Using reader As New StreamReader(responseStream)
                        Dim line As String = reader.ReadLine()
                        While Not String.IsNullOrEmpty(line)
                            Dim objArchivo As Archivo = ParseFtpListLine(line)
                            If objArchivo IsNot Nothing Then
                                fileList.Add(objArchivo)
                                ' Aquí puedes procesar fileInfo según tus necesidades
                                MsgBox($"Nombre: {objArchivo.Name}, Tamaño: {objArchivo.Size}, Fecha de Modificación: {objArchivo.ModificationDate}")
                            End If
                            line = reader.ReadLine()
                        End While
                    End Using
                End Using
            End Using

        Catch ex As Exception
            Console.WriteLine("Error al listar archivos: " & ex.Message)
        End Try
    End Sub

    ' Método para subir un archivo al servidor FTP
    Public Function UploadFile(remotePath As String, localFilePath As String) As Boolean
        Try
            Dim request As FtpWebRequest = CType(WebRequest.Create(ftpServer & remotePath), FtpWebRequest)
            request.Method = WebRequestMethods.Ftp.UploadFile
            request.Credentials = New NetworkCredential(ftpUsername, ftpPassword)

            ' Lee el archivo a cargar
            Dim fileContents() As Byte = File.ReadAllBytes(localFilePath)
            request.ContentLength = fileContents.Length

            ' Sube el archivo
            Using requestStream As Stream = request.GetRequestStream()
                requestStream.Write(fileContents, 0, fileContents.Length)
            End Using

            ' Obtiene la respuesta del servidor FTP
            Using response As FtpWebResponse = CType(request.GetResponse(), FtpWebResponse)
                ' Verifica si el código de estado es 226 (Transferencia exitosa)
                If response.StatusCode = FtpStatusCode.ClosingData Then
                    Return True
                Else
                    Return False
                End If
            End Using

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "UploadFile", ex.Message))

        End Try
    End Function

    ' Método para descargar un archivo desde el servidor FTP
    Public Function DownloadFile(remotePath As String, localFilePath As String) As Boolean
        Try
            Dim request As FtpWebRequest = CType(WebRequest.Create(ftpServer & remotePath), FtpWebRequest)
            request.Method = WebRequestMethods.Ftp.DownloadFile
            request.Credentials = New NetworkCredential(ftpUsername, ftpPassword)

            Using response As FtpWebResponse = CType(request.GetResponse(), FtpWebResponse)
                Using responseStream As Stream = response.GetResponseStream()
                    Using outputStream As New FileStream(localFilePath, FileMode.Create)
                        responseStream.CopyTo(outputStream)
                    End Using
                End Using
            End Using

            Return True

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "DownloadFile", ex.Message))
            Return False
        End Try
    End Function
    Private Function ParseFtpListLine(line As String) As Archivo
        Try
            ' Ejemplo de línea: -rw-r--r--   1 user  group     12345 Sep  1 12:34 file.txt
            Dim parts As String() = line.Split(New Char() {" "c}, StringSplitOptions.RemoveEmptyEntries)

            If parts.Length < 9 Then
                Throw New Exception("Formato de línea no válido: " & line)
            End If

            ' Obtener atributos de archivo
            Dim objArchivo As New Archivo
            With objArchivo
                .Permissions = parts(0) ' Permisos (ej. -rw-r--r--)
                .User = parts(2) ' Usuario
                .Group = parts(3) ' Grupo
                .Size = Long.Parse(parts(4)) ' Tamaño del archivo
                .ModificationDate = DateTime.Parse(parts(5) & " " & parts(6) & " " & parts(7)) ' Fecha y hora
                .Name = String.Join(" ", parts.Skip(8)) ' Nombre del archivo
            End With

            Return objArchivo

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ParseFtpListLine", ex.Message))
            Return Nothing
        End Try
    End Function

End Class
