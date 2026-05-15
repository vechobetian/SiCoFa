Imports System.IO
Imports System.IO.Compression
Imports SiCoFa.Datos
Imports SiCoFa.Entidades

Public Class N_AdminActualizaciones

    Private ReadOnly mAdminActualizaciones As New D_AdminActualizaciones()

    Public Async Function ListarArchivosServidorAsync(token As String) As Task(Of List(Of String))

        If String.IsNullOrWhiteSpace(token) Then
            Throw New ArgumentException("Token inválido")
        End If

        Try
            Return Await mAdminActualizaciones.
                     ListarArchivosServidorAsync(token)

        Catch ex As Exception
            Throw New Exception(
            Vecho.MensajeError(Me.ToString(), NameOf(ListarArchivosServidorAsync), ex.Message), ex)
        End Try

    End Function

    Public Async Function DescargarArchivoAsync(token As String, nombreArchivo As String) As Task(Of String)

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

            Await mAdminActualizaciones.DescargarArchivoAsync(
            token,
            nombreArchivo,
            rutaDestino
        )

            Return rutaDestino

        Catch ex As Exception
            Throw New Exception(
            Vecho.MensajeError(Me.ToString(), NameOf(DescargarArchivoAsync), ex.Message), ex)
        End Try

    End Function

    Public Function NormalizarArchivoZip(nombreZip As String) As List(Of String)

        Dim rutaZip As String = "C:\SiCoFa_Server\Actualizaciones\zip"
        Dim rutaTxt As String = "C:\SiCoFa_Server\Actualizaciones\txt"

        Dim archivoZip As String = Path.Combine(rutaZip, nombreZip)

        If Not File.Exists(archivoZip) Then
            Throw New Exception("No existe el ZIP: " & archivoZip)
        End If

        Dim archivosGenerados As New List(Of String)

        Dim nombreSinExt As String =
        Path.GetFileNameWithoutExtension(nombreZip)

        If nombreSinExt.Length < 3 Then
            Throw New Exception("Nombre ZIP inválido")
        End If

        ' me26051101.zip
        Dim codigoZip As String = nombreSinExt.Substring(0, 2)
        Dim nroActualizacion As String = nombreSinExt.Substring(2)

        Using zip As ZipArchive = ZipFile.OpenRead(archivoZip)

            Dim entries = zip.Entries.
            Where(Function(e)
                      Dim n = e.Name.ToLower()
                      Return (n.EndsWith(".txt") OrElse n.EndsWith(".dat")) _
                             AndAlso e.Length > 0
                  End Function).ToList()

            If entries.Count = 0 Then
                Throw New Exception("ZIP sin TXT/DAT válidos")
            End If

            For Each entry As ZipArchiveEntry In entries

                Dim nombreBase =
                Path.GetFileNameWithoutExtension(entry.Name)

                Dim extension =
                Path.GetExtension(entry.Name).ToLower()

                Dim extensionFinal =
                If(extension = ".dat", ".txt", extension)

                Dim nombreFinal As String

                '====================================
                ' SI SOLO HAY UN ARCHIVO → usar CodiLP del ZIP
                '====================================
                If entries.Count = 1 Then

                    nombreFinal =
                    codigoZip &
                    nroActualizacion &
                    extensionFinal

                Else
                    ' múltiples → usar nombre del archivo
                    nombreFinal =
                    nombreBase &
                    nroActualizacion &
                    extensionFinal
                End If

                Dim destino As String =
                Path.Combine(rutaTxt, nombreFinal)

                If File.Exists(destino) Then
                    File.Delete(destino)
                End If

                entry.ExtractToFile(destino, True)

                archivosGenerados.Add(destino)

            Next

        End Using

        Return archivosGenerados

    End Function

    Public Sub ProcesarActualizacion(argCodiPA As String, argNumeroActualizacion As Long, argStoredProcedure As String, argPorcentaje As Decimal, argRutaArchivo As String)
        Dim AdminActualizaciones As New D_AdminActualizaciones

        Try
            AdminActualizaciones.ProcesarActualizacion(argCodiPA, argNumeroActualizacion, argStoredProcedure, argPorcentaje, argRutaArchivo)

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "PrcesarActualizacion", ex.Message))

        End Try

    End Sub

End Class