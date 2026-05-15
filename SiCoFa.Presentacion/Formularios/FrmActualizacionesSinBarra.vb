Imports System.IO
Imports System.Threading.Tasks
Imports SiCoFa.Negocio

Public Class FrmActualizacionesSinBarra

    Private ReadOnly mAdminActualizaciones As New N_AdminActualizaciones()

    Private Sub FrmActualizaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CrearCarpetas()
        LimpiarCarpetas()
    End Sub

    Private Sub CrearCarpetas()

        Try
            Dim rutaBase As String = "C:\SiCoFa_Server\Actualizaciones"

            Directory.CreateDirectory(Path.Combine(rutaBase, "zip"))
            Directory.CreateDirectory(Path.Combine(rutaBase, "txt"))
            Directory.CreateDirectory(Path.Combine(rutaBase, "Procesadas"))

        Catch ex As Exception
            MessageBox.Show("Error al crear carpetas: " & ex.Message)
        End Try

    End Sub

    Private Sub LimpiarCarpetas()

        Limpiar("C:\SiCoFa_Server\Actualizaciones\zip")
        Limpiar("C:\SiCoFa_Server\Actualizaciones\txt")

    End Sub


    Private Sub Limpiar(ruta As String)

        If Not Directory.Exists(ruta) Then Exit Sub

        Dim dir As New DirectoryInfo(ruta)

        Dim contador As Integer = 0

        For Each archivo As FileInfo In dir.GetFiles("*", SearchOption.AllDirectories)

            Try
                '🔥 quitar TODOS los atributos problemáticos
                archivo.Attributes = FileAttributes.Normal

                archivo.Delete()

                contador += 1

            Catch ex As Exception
                Debug.Print("NO BORRADO: " & archivo.FullName)
                Debug.Print(ex.Message)
            End Try

        Next

    End Sub

    Private Async Function ActualizarArticulos() As Task

        Try

            '==========================================
            ' TOKEN
            '==========================================
            Dim token As String = ObtenerToken()

            '==========================================
            ' PROCESOS ACTUALIZACION
            '==========================================
            Dim adminPA As New N_AdminProcesosActualizacion
            Dim procesos = adminPA.ObtenerProcesosActualizacion()

            Dim mapProcesos =
            procesos.ToDictionary(Function(x) x.CodiPA, StringComparer.OrdinalIgnoreCase)

            '==========================================
            ' LISTAR ZIP SERVIDOR
            '==========================================
            Dim archivos =
            Await mAdminActualizaciones.ListarArchivosServidorAsync(token)

            Dim archivosOrdenados =
            archivos.OrderBy(Function(a)
                                 Dim n =
                                 Path.GetFileNameWithoutExtension(a)
                                 Return CLng(n.Substring(2))
                             End Function)

            '==========================================
            ' RECORRER ZIP
            '==========================================
            For Each archivoZip In archivosOrdenados

                Dim nombreZip = Path.GetFileNameWithoutExtension(archivoZip)

                Dim nroActualizacionZip = CLng(nombreZip.Substring(2))

                '==========================================
                ' DESCARGAR ZIP
                '==========================================
                Dim rutaZip = Await mAdminActualizaciones.DescargarArchivoAsync(token, archivoZip)

                Dim errorEnZip As Boolean = False

                '==========================================
                ' DESCOMPRIMIR
                '==========================================
                Dim rutasTxt = mAdminActualizaciones.NormalizarArchivoZip(Path.GetFileName(rutaZip))

                '==========================================
                ' PROCESAR TXT
                '==========================================
                For Each rutaTxt In rutasTxt

                    Try

                        Dim nombreTxt =
                        Path.GetFileNameWithoutExtension(rutaTxt)

                        ' CodiPA = primeras 2 letras
                        Dim codigoPA = nombreTxt.Substring(0, 2)

                        If Not mapProcesos.ContainsKey(codigoPA) Then
                            Continue For
                        End If

                        Dim proceso = mapProcesos(codigoPA)

                        Dim nroActual = If(proceso.NumeroActualizacion.HasValue, proceso.NumeroActualizacion.Value, 0)

                        '==========================================
                        ' VALIDACION ACTUALIZACION
                        '==========================================
                        If nroActualizacionZip <= nroActual Then
                            Continue For
                        End If

                        '==========================================
                        ' EJECUTAR PROCESO
                        '==========================================
                        mAdminActualizaciones.ProcesarActualizacion(proceso.CodiPA, nroActualizacionZip, proceso.StoredProcedure, proceso.PorcentajeAplicado, rutaTxt)

                        '==========================================
                        ' BORRAR TXT OK
                        '==========================================
                        If File.Exists(rutaTxt) Then
                            File.Delete(rutaTxt)
                        End If

                    Catch ex As Exception

                        errorEnZip = True
                        MessageBox.Show("Error procesando archivo:" & Environment.NewLine & Path.GetFileName(rutaTxt) & Environment.NewLine & ex.Message)

                    End Try

                Next

                '==========================================
                ' BORRAR ZIP SOLO SI TODO OK
                '==========================================
                If Not errorEnZip Then

                    If File.Exists(rutaZip) Then
                        File.Delete(rutaZip)
                    End If

                End If

            Next

            MessageBox.Show("Actualización finalizada.")

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Function

    Private Async Function ActualizarArticulos1() As Task

        Try

            Dim token As String = ObtenerToken()

            Dim adminPA As New N_AdminProcesosActualizacion
            Dim procesos = adminPA.ObtenerProcesosActualizacion()

            Dim mapProcesos =
            procesos.ToDictionary(Function(x) x.CodiPA, StringComparer.OrdinalIgnoreCase)

            '==========================================
            ' LISTAR ZIP DEL SERVIDOR
            '==========================================
            Dim archivos = Await mAdminActualizaciones.ListarArchivosServidorAsync(token)
            Dim archivosOrdenados = archivos.OrderBy(Function(a) CLng(a.Substring(2, 8)))

            '==========================================
            ' RECORRER ZIP
            '==========================================
            For Each archivoZip In archivosOrdenados

                Dim nombreZip = Path.GetFileNameWithoutExtension(archivoZip)

                ' 👉 el nro SIEMPRE sale del ZIP
                Dim nroActualizacionZip =
                CLng(nombreZip.Substring(2))

                '==========================================
                ' DESCARGAR ZIP
                '==========================================
                Dim rutaZip = Await mAdminActualizaciones.DescargarArchivoAsync(token, archivoZip)

                '==========================================
                ' DESCOMPRIMIR → GENERA TXT
                '==========================================
                Dim rutasTxt = mAdminActualizaciones.NormalizarArchivoZip(rutaZip)

                '==========================================
                ' PROCESAR CADA TXT
                '==========================================
                For Each rutaTxt In rutasTxt

                    Dim nombreTxt = Path.GetFileNameWithoutExtension(rutaTxt)

                    ' 👉 CodiPA viene del TXT
                    Dim codigoPA = nombreTxt.Substring(0, 2)

                    If Not mapProcesos.ContainsKey(codigoPA) Then Continue For

                    Dim proceso = mapProcesos(codigoPA)

                    Dim nroActual = If(proceso.NumeroActualizacion.HasValue, proceso.NumeroActualizacion.Value, 0)

                    '==========================================
                    ' VALIDACIÓN REAL
                    '==========================================
                    If nroActualizacionZip < nroActual Then Continue For

                    mAdminActualizaciones.ProcesarActualizacion(proceso.CodiPA, nroActualizacionZip, proceso.StoredProcedure, proceso.PorcentajeAplicado, rutaTxt)

                Next

            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Function

    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Button1.Enabled = False

        Try
            Await ActualizarArticulos()
        Finally
            Button1.Enabled = True
        End Try

    End Sub

    Private Function ObtenerToken() As String
        Return "21036271"
    End Function

    Private Function ObtenerRutaZip() As String
        Return "C:\SiCoFa_Server\Actualizaciones\zip"
    End Function

End Class