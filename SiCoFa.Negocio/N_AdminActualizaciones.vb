Imports SiCoFa.Datos

Public Class N_AdminActualizaciones

    Private ReadOnly AdminActualizaciones As New D_AdminActualizaciones()

    Public Async Function ListarArchivosServidorAsync(token As String) _
    As Task(Of List(Of String))

        If String.IsNullOrWhiteSpace(token) Then
            Throw New ArgumentException("Token inválido")
        End If

        Try
            Return Await AdminActualizaciones.
                     ListarArchivosServidorAsync(token)

        Catch ex As Exception
            Throw New Exception(
            Vecho.MensajeError(Me.ToString(),
                               NameOf(ListarArchivosServidorAsync),
                               ex.Message),
            ex)
        End Try

    End Function

    Public Async Function DescargarArchivoAsync(token As String,
                                            nombreArchivo As String) As Task(Of String)

        If String.IsNullOrWhiteSpace(token) Then
            Throw New ArgumentException("Token inválido")
        End If

        If String.IsNullOrWhiteSpace(nombreArchivo) Then
            Throw New ArgumentException("Archivo inválido")
        End If

        Try
            ' 📌 Ruta fija del sistema
            Dim carpetaDestino As String = "C:\SiCoFa_Server\Actualizaciones\zip"

            If Not IO.Directory.Exists(carpetaDestino) Then
                IO.Directory.CreateDirectory(carpetaDestino)
            End If

            Dim rutaDestino As String =
            IO.Path.Combine(carpetaDestino, nombreArchivo)

            Await AdminActualizaciones.DescargarArchivoAsync(
            token,
            nombreArchivo,
            rutaDestino
        )

            Return rutaDestino

        Catch ex As Exception
            Throw New Exception(
            Vecho.MensajeError(Me.ToString(),
                               NameOf(DescargarArchivoAsync),
                               ex.Message),
            ex)
        End Try

    End Function


End Class