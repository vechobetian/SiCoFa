Imports System.Collections.Generic
Imports System.Globalization
Imports System.Net
Imports System.IO
Imports System.Linq
Imports SiCoFa.Entidades
Public Class D_AdminFTP
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
    Public Function ListFiles(remotePath As String) As List(Of Archivo)
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

                                If objArchivo.Name <> "." And objArchivo.Name <> ".." Then '. es el directorio actual, .. es el directorio padre
                                    fileList.Add(objArchivo)
                                End If

                            End If
                            line = reader.ReadLine()
                        End While
                    End Using
                End Using
            End Using

            Return fileList

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "UploadFile", ex.Message))

        End Try

    End Function

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

                Dim fechaStr As String = parts(5) & " " & parts(6) & " " & parts(7)
                .ModificationDate = Me.ObtenerFecha(fechaStr)
                .Name = String.Join(" ", parts.Skip(8)) ' Nombre del archivo
            End With

            Return objArchivo

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ParseFtpListLine", ex.Message))
            Return Nothing
        End Try
    End Function

    Public Function ObtenerFecha(fechaStr As String) As String

        Dim fechaConAnio As DateTime
        Dim formatoEntrada As String = "MMM d H:mm" ' Formato de entrada sin el año
        Dim formatoSalida As String = "MMM d yyyy H:mm" ' Formato de salida con el año
        Dim anioActual As Integer = DateTime.Now.Year ' Año actual

        Try
            ' Divide la fecha original en partes
            Dim partes As String() = fechaStr.Split(New Char() {" "c}, StringSplitOptions.RemoveEmptyEntries)

            ' Verifica que partes contenga al menos 3 elementos
            If partes.Length < 3 Then
                Throw New FormatException("El formato de la fecha no es válido.")
            End If

            ' Construye la fecha con el año interpuesto
            Dim fechaConAnioStr As String = $"{partes(0)} {partes(1)} {anioActual} {partes(2)}"

            ' Intenta analizar la fecha con el año añadido
            If DateTime.TryParseExact(fechaConAnioStr, formatoSalida, CultureInfo.InvariantCulture, DateTimeStyles.None, fechaConAnio) Then
                ' Devuelve la fecha en el formato deseado
                Return fechaConAnio.ToString("yyyy-MM-dd HH:mm")
            Else
                Throw New FormatException($"No se pudo convertir la fecha: {fechaConAnioStr}")
            End If
        Catch ex As FormatException
            ' Muestra un mensaje de error en caso de formato no válido
            MsgBox($"Error al analizar la fecha: {fechaStr}. Error: {ex.Message}")
            Return "Fecha no válida"
        End Try
    End Function


End Class
