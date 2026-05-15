Imports System.IO
Imports System.Threading.Tasks
Imports SiCoFa.Negocio

Public Class FrmActualizaciones

    Private ReadOnly mAdminActualizaciones As New N_AdminActualizaciones()

    '==============================================
    ' CLASE PROGRESO
    '==============================================
    Private Class ProgresoActualizacion
        Public Property Valor As Integer
        Public Property Mensaje As String
    End Class

    '==============================================
    ' LOAD
    '==============================================
    Private Sub FrmActualizaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        pbActualizacion.Minimum = 0
        pbActualizacion.Maximum = 100
        pbActualizacion.Value = 0

        lblEstado.Text = "Preparado..."

        CrearCarpetas()
        LimpiarCarpetas()

    End Sub

    '==============================================
    ' BOTON ACTUALIZAR
    '==============================================
    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Button1.Enabled = False

        Dim progreso =
            New Progress(Of ProgresoActualizacion)(
                Sub(p)
                    pbActualizacion.Value = p.Valor
                    lblEstado.Text = p.Mensaje
                End Sub)

        Try

            Await ActualizarArticulos(progreso)

            lblEstado.Text = "Actualización finalizada"

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Button1.Enabled = True
        End Try

    End Sub

    '==============================================
    ' ACTUALIZAR
    '==============================================
    Private Async Function ActualizarArticulos(progreso As IProgress(Of ProgresoActualizacion)) As Task

        Dim token As String = ObtenerToken()

        Dim adminPA As New N_AdminProcesosActualizacion
        Dim procesos = adminPA.ObtenerProcesosActualizacion()

        Dim mapProcesos = procesos.ToDictionary(Function(x) x.CodiPA, StringComparer.OrdinalIgnoreCase)

        progreso.Report(New ProgresoActualizacion With {.Valor = 0, .Mensaje = "Consultando servidor..."})

        '------------------------------------------
        ' LISTAR ZIP
        '------------------------------------------
        Dim archivos = Await mAdminActualizaciones.ListarArchivosServidorAsync(token)

        Dim archivosOrdenados =
        archivos.OrderBy(Function(a)
                             Dim n = Path.GetFileNameWithoutExtension(a)
                             Return CLng(n.Substring(2))
                         End Function).ToList()

        '------------------------------------------
        ' PRECALCULO TOTAL TXT
        '------------------------------------------
        Dim trabajosTotales As Integer = 0

        Dim listaProcesamiento As New List(Of (Zip As String, Txt As List(Of String), RutaZip As String))

        For Each archivoZip In archivosOrdenados

            Dim codigoPA = archivoZip.Substring(0, 2)

            If Not mapProcesos.ContainsKey(codigoPA) Then Continue For

            Dim proceso = mapProcesos(codigoPA)

            Dim nroActual = If(proceso.NumeroActualizacion.HasValue, proceso.NumeroActualizacion.Value, 0)

            Dim nombreSinExtension = Path.GetFileNameWithoutExtension(archivoZip)
            Dim numeroTexto = nombreSinExtension.Substring(2)

            Dim nroActualizacionZip As Long
            If Not Long.TryParse(numeroTexto, nroActualizacionZip) Then Continue For

            If nroActualizacionZip <= nroActual Then Continue For

            progreso.Report(New ProgresoActualizacion With {.Mensaje = "Descargando " & archivoZip})

            Dim rutaZip = Await mAdminActualizaciones.DescargarArchivoAsync(token, archivoZip)

            Dim rutasTxt = mAdminActualizaciones.NormalizarArchivoZip(Path.GetFileName(rutaZip))

            trabajosTotales += rutasTxt.Count

            listaProcesamiento.Add((archivoZip, rutasTxt, rutaZip))

        Next

        '==========================================
        ' 🚨 NO HAY NADA PARA HACER
        '==========================================
        If trabajosTotales = 0 Then

            progreso.Report(New ProgresoActualizacion With {.Valor = 0, .Mensaje = "No existen actualizaciones para procesar"})

            Return
        End If

        '------------------------------------------
        ' PROCESAMIENTO REAL
        '------------------------------------------
        Dim trabajosRealizados As Integer = 0

        For Each item In listaProcesamiento

            Dim nombreZip = Path.GetFileNameWithoutExtension(item.Zip)
            Dim nroActualizacionZip = CLng(nombreZip.Substring(2))

            Dim errorEnZip As Boolean = False

            For Each rutaTxt In item.Txt

                Try

                    Dim nombreTxt = Path.GetFileNameWithoutExtension(rutaTxt)
                    Dim codigoPA = nombreTxt.Substring(0, 2)

                    If Not mapProcesos.ContainsKey(codigoPA) Then Continue For

                    Dim proceso = mapProcesos(codigoPA)

                    Dim nroActual = If(proceso.NumeroActualizacion.HasValue, proceso.NumeroActualizacion.Value, 0)

                    If nroActualizacionZip <= nroActual Then Continue For

                    Await Task.Run(Sub()
                                       mAdminActualizaciones.ProcesarActualizacion(
                                       proceso.CodiPA,
                                       nroActualizacionZip,
                                       proceso.StoredProcedure,
                                       proceso.PorcentajeAplicado,
                                       rutaTxt)
                                   End Sub)

                    If File.Exists(rutaTxt) Then
                        File.Delete(rutaTxt)
                    End If

                Catch ex As Exception

                    errorEnZip = True

                    MessageBox.Show("Error procesando " &
                                Path.GetFileName(rutaTxt) &
                                Environment.NewLine &
                                ex.Message)

                End Try

                '------------------------------------------
                ' PROGRESO REAL
                '------------------------------------------
                trabajosRealizados += 1

                Dim porcentaje = CInt((trabajosRealizados / trabajosTotales) * 100)

                progreso.Report(New ProgresoActualizacion With {.Valor = porcentaje, .Mensaje = "Procesando " & Path.GetFileName(rutaTxt)})

            Next

            If Not errorEnZip Then
                If File.Exists(item.RutaZip) Then
                    File.Delete(item.RutaZip)
                End If
            End If

        Next

        '====================================================
        ' ⭐ FIN REAL DEL PROCESO
        '====================================================
        progreso.Report(New ProgresoActualizacion With {.Valor = 100, .Mensaje = "Actualización finalizada"})

    End Function
    '==============================================
    ' CARPETAS
    '==============================================
    Private Sub CrearCarpetas()

        Dim rutaBase As String = "C:\SiCoFa_Server\Actualizaciones"

        Directory.CreateDirectory(Path.Combine(rutaBase, "zip"))
        Directory.CreateDirectory(Path.Combine(rutaBase, "txt"))
        Directory.CreateDirectory(Path.Combine(rutaBase, "Procesadas"))

    End Sub

    Private Sub LimpiarCarpetas()

        Limpiar("C:\SiCoFa_Server\Actualizaciones\zip")
        Limpiar("C:\SiCoFa_Server\Actualizaciones\txt")

    End Sub

    Private Sub Limpiar(ruta As String)

        If Not Directory.Exists(ruta) Then Exit Sub

        Dim dir As New DirectoryInfo(ruta)

        For Each archivo In dir.GetFiles("*", SearchOption.AllDirectories)

            Try
                archivo.Attributes = FileAttributes.Normal
                archivo.Delete()
            Catch
            End Try

        Next

    End Sub

    '==============================================
    ' TOKEN
    '==============================================
    Private Function ObtenerToken() As String
        Return "21036271"
    End Function

End Class