Imports System.Collections.Generic
Imports System.Threading.Tasks
Imports System.Net.Http
Imports System.IO

Public Class D_AdminActualizaciones

    ' HttpClient único para toda la aplicación
    Private Shared ReadOnly http As New HttpClient()

    Shared Sub New()
        http.Timeout = TimeSpan.FromSeconds(60)
    End Sub

    '====================================================
    ' LISTAR ARCHIVOS DEL SERVIDOR
    '====================================================
    Public Async Function ListarArchivosServidorAsync(token As String) _
        As Task(Of List(Of String))

        If String.IsNullOrWhiteSpace(token) Then
            Throw New ArgumentException("Token inválido")
        End If

        Dim lista As New List(Of String)

        Dim url As String =
            $"https://www.sicofa.com.ar/listar.php?token={Uri.EscapeDataString(token)}"

        Dim texto As String = Await http.GetStringAsync(url)

        For Each linea In texto.Split({vbCrLf, vbLf},
                                      StringSplitOptions.RemoveEmptyEntries)

            lista.Add(linea.Trim())

        Next

        Return lista

    End Function

    '====================================================
    ' DESCARGAR ARCHIVO (STREAMING - PROFESIONAL)
    '====================================================
    Public Async Function DescargarArchivoAsync(token As String,
                                                nombreArchivo As String,
                                                rutaDestino As String) As Task

        If String.IsNullOrWhiteSpace(token) _
        OrElse String.IsNullOrWhiteSpace(nombreArchivo) Then

            Throw New ArgumentException("Token o archivo inválido")
        End If

        Dim url As String =
            $"https://www.sicofa.com.ar/descargar.php?token={Uri.EscapeDataString(token)}&archivo={Uri.EscapeDataString(nombreArchivo)}"

        Try

            Using response =
                Await http.GetAsync(url, HttpCompletionOption.ResponseHeadersRead)

                response.EnsureSuccessStatusCode()

                Using stream = Await response.Content.ReadAsStreamAsync()

                    Using fs As New FileStream(
                        rutaDestino,
                        FileMode.Create,
                        FileAccess.Write,
                        FileShare.None)

                        Await stream.CopyToAsync(fs)

                    End Using

                End Using

            End Using

        Catch ex As Exception
            Throw New Exception($"Error descargando {nombreArchivo}: {ex.Message}", ex)
        End Try

    End Function

End Class