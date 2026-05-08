Imports System.Collections.Generic
Imports System.Threading.Tasks
Imports System.Net.Http
Imports System.IO

Public Class D_AdminActualizaciones
    Public Async Function ListarArchivosServidorAsync(token As String) _
    As Task(Of List(Of String))

        Dim lista As New List(Of String)

        Dim url As String =
        $"https://www.sicofa.com.ar/listar.php?token={token}"

        Using client As New HttpClient()

            Dim texto As String =
            Await client.GetStringAsync(url)

            For Each linea In texto.Split({vbCrLf, vbLf},
                                     StringSplitOptions.RemoveEmptyEntries)

                lista.Add(linea.Trim())

            Next
        End Using

        Return lista

    End Function

    Public Async Function DescargarArchivoAsync(token As String,
                                            nombreArchivo As String,
                                            rutaDestino As String) As Task

        If String.IsNullOrWhiteSpace(token) OrElse String.IsNullOrWhiteSpace(nombreArchivo) Then
            Throw New ArgumentException("Token o nombre de archivo inválido")
        End If

        Dim url As String =
        $"https://www.sicofa.com.ar/descargar.php?token={Uri.EscapeDataString(token)}&archivo={Uri.EscapeDataString(nombreArchivo)}"

        Try
            Using client As New HttpClient()

                Dim bytes = Await client.GetByteArrayAsync(url)

                ' detectar si vino HTML
                If bytes.Length < 5000 Then
                    Dim texto = Text.Encoding.UTF8.GetString(bytes)
                    If texto.Contains("<") Then
                        Throw New Exception("El servidor devolvió un mensaje en lugar del archivo: " & texto)
                    End If
                End If

                File.WriteAllBytes(rutaDestino, bytes)

            End Using

        Catch ex As Exception
            Throw New Exception("Error descargando archivo: " & ex.Message, ex)
        End Try

    End Function

End Class
