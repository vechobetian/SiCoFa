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

    ' 1. Reemplazá tu función ListFiles por esta:
    Public Function ListFiles(remotePath As String) As List(Of Archivo)
        Dim fileList As New List(Of Archivo)

        Try
            ' Limpiamos barras para evitar el error de "nombre remoto no resuelto"
            Dim uri As String = ftpServer.TrimEnd("/"c) & "/" & remotePath.TrimStart("/"c)
            Dim request As FtpWebRequest = CType(WebRequest.Create(uri), FtpWebRequest)

            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails
            request.Credentials = New NetworkCredential(ftpUsername, ftpPassword)

            Using response As FtpWebResponse = CType(request.GetResponse(), FtpWebResponse)
                Using responseStream As Stream = response.GetResponseStream()
                    Using reader As New StreamReader(responseStream)
                        Dim line As String = reader.ReadLine()
                        While Not String.IsNullOrEmpty(line)
                            ' Llamamos al nuevo parseador
                            Dim objArchivo As Archivo = ParseFtpListLine(line)

                            If objArchivo IsNot Nothing Then
                                ' Filtramos puntos de directorio de Linux
                                If objArchivo.Name <> "." AndAlso objArchivo.Name <> ".." Then
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
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ListFiles", ex.Message))
        End Try
    End Function

    ' 2. Reemplazá (o agregá) este método ParseFtpListLine:
    Private Function ParseFtpListLine(line As String) As Archivo
        Try
            Dim obj As New Archivo
            ' Dividimos la línea eliminando espacios dobles
            Dim partes As String() = line.Split(New Char() {" "c}, StringSplitOptions.RemoveEmptyEntries)

            ' Estructura típica de Linux: 9 columnas (0 a 8)
            If partes.Length >= 9 Then
                ' Capturamos el nombre completo (columna 8 en adelante)
                obj.Name = String.Join(" ", partes.Skip(8))

                ' Capturamos metadatos adicionales según tu clase
                obj.Permissions = partes(0)
                obj.User = partes(2)
                obj.Group = partes(3)
                Long.TryParse(partes(4), obj.Size)

                ' Lógica de fecha: Mes=5, Día=6, Año/Hora=7
                Dim mes As String = partes(5)
                Dim dia As String = partes(6)
                Dim anioOhora As String = partes(7)

                ' Limpieza por si vienen dos años juntos (ej: "2026 2024")
                If anioOhora.Contains(" ") Then
                    anioOhora = anioOhora.Split(" "c)(0)
                End If

                Dim fechaParaParsear As String = $"{mes} {dia} {anioOhora}"

                Try
                    ' Usamos ModificationDate que es el nombre real en tu clase
                    obj.ModificationDate = DateTime.Parse(fechaParaParsear, System.Globalization.CultureInfo.InvariantCulture)
                Catch
                    ' Si la fecha falla, asignamos la fecha actual para no detener el proceso
                    obj.ModificationDate = DateTime.Now
                End Try

                Return obj
            End If
        Catch ex As Exception
            ' Si la línea es inválida, la ignoramos para que el listado continúe
            Return Nothing
        End Try
        Return Nothing
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
