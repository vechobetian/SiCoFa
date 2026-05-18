Imports System.IO
Imports System.Threading.Tasks
Imports SiCoFa.Negocio
Imports SiCoFa.Entidades

Public Class FrmActualizaciones

    Private ReadOnly mAdminActualizaciones As New N_AdminActualizaciones()
    Private mToken As String

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

        mToken = ObtenerToken()
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
            Await ActualizarOS(progreso)

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

        Dim adminPA As New N_AdminProcesosActualizacion
        Dim procesos = adminPA.ObtenerProcesosActualizacion()

        Dim mapProcesos = procesos.ToDictionary(Function(x) x.CodiPA, StringComparer.OrdinalIgnoreCase)

        progreso.Report(New ProgresoActualizacion With {.Valor = 0, .Mensaje = "Consultando servidor..."})

        '------------------------------------------
        ' LISTAR ZIP
        '------------------------------------------
        Dim archivos = Await mAdminActualizaciones.ListarArchivosServidorAsync(mToken)

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

            Dim rutaZip = Await mAdminActualizaciones.DescargarArchivoAsync(mToken, archivoZip)

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
                                       mAdminActualizaciones.ProcesarActualizacionArticulos(
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

    Private Async Function ActualizarOS(progreso As IProgress(Of ProgresoActualizacion)) As Task

        '==========================================
        ' ORDEN OFICIAL DE PROCESAMIENTO
        '==========================================
        Dim OrdenProcesamiento As New Dictionary(Of String, Integer)(StringComparer.OrdinalIgnoreCase) From {
        {"OSoc", 1},
        {"Planes", 2},
        {"DetVdm", 3},
        {"DatoRequerido", 4}
    }

        Dim adminPA As New N_AdminProcesosActualizacion
        Dim obrasociales = adminPA.ObtenerObraSociales

        Dim mapOS = obrasociales.ToDictionary(Function(x) x.IdOS)

        progreso.Report(New ProgresoActualizacion With {.Valor = 0, .Mensaje = "Consultando servidor..."})

        '------------------------------------------
        ' LISTAR ZIP
        '------------------------------------------
        Dim archivos = Await mAdminActualizaciones.ListarArchivosOSServidorAsync(mToken)

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

            Dim idOS = archivoZip.Substring(2, 3)

            Dim nroActual As Long = 0

            If mapOS.ContainsKey(idOS) Then
                Dim os = mapOS(idOS)
                nroActual = If(os.NumeroActualizacion.HasValue, os.NumeroActualizacion.Value, 0)
            Else
                ' ⭐ OBRA SOCIAL NUEVA
                ' Se procesa desde actualización 0
                nroActual = 0
            End If

            Dim nombreSinExtension = Path.GetFileNameWithoutExtension(archivoZip)
            Dim numeroTexto = nombreSinExtension.Substring(5)

            Dim nroActualizacionZip As Long
            If Not Long.TryParse(numeroTexto, nroActualizacionZip) Then Continue For

            If nroActualizacionZip <= nroActual Then Continue For

            progreso.Report(New ProgresoActualizacion With {.Mensaje = "Descargando " & archivoZip})

            Dim rutaZip = Await mAdminActualizaciones.DescargarArchivoAsync(mToken, archivoZip)

            Dim rutasTxt = mAdminActualizaciones.NormalizarArchivoZipOS(Path.GetFileName(rutaZip))

            trabajosTotales += rutasTxt.Count

            listaProcesamiento.Add((archivoZip, rutasTxt, rutaZip))

        Next

        '==========================================
        ' NO HAY ACTUALIZACIONES
        '==========================================
        If trabajosTotales = 0 Then

            progreso.Report(New ProgresoActualizacion With {
            .Valor = 0,
            .Mensaje = "No existen actualizaciones para procesar"
        })

            Return
        End If

        '------------------------------------------
        ' PROCESAMIENTO REAL
        '------------------------------------------
        Dim trabajosRealizados As Integer = 0

        For Each item In listaProcesamiento

            Dim nombreZip = Path.GetFileNameWithoutExtension(item.Zip)
            Dim nroActualizacionZip = CLng(nombreZip.Substring(5))

            Dim errorEnZip As Boolean = False

            '==========================================
            ' ⭐ ORDENAR TXT SEGUN DEPENDENCIAS
            '==========================================
            Dim txtOrdenados =
            item.Txt.
            OrderBy(Function(t)
                        Dim nombre = Path.GetFileNameWithoutExtension(t)

                        If OrdenProcesamiento.ContainsKey(nombre) Then
                            Return OrdenProcesamiento(nombre)
                        Else
                            Return 999 ' archivos desconocidos al final
                        End If
                    End Function).
            ToList()

            '==========================================
            ' PROCESAR ARCHIVOS
            '==========================================
            For Each rutaTxt In txtOrdenados

                Try

                    Dim nombreTxt = Path.GetFileNameWithoutExtension(rutaTxt)
                    Dim idOS = nombreZip.Substring(2, 3)

                    Dim os As ObraSocial = Nothing
                    mapOS.TryGetValue(CInt(idOS), os)
                    Dim nroActual As Long = 0

                    If os IsNot Nothing Then
                        nroActual = os.NumeroActualizacion
                    End If

                    If nroActualizacionZip <= nroActual Then Continue For

                    Dim sp As String = ObtenerProcedureOS(nombreTxt)

                    If sp = "NO APLICA" Then Continue For

                    Await Task.Run(Sub()
                                       mAdminActualizaciones.ProcesarActualizacionObraSociales(
                                       idOS,
                                       nroActualizacionZip,
                                       sp,
                                       rutaTxt)
                                   End Sub)

                    If File.Exists(rutaTxt) Then
                        File.Delete(rutaTxt)
                    End If

                Catch ex As Exception

                    errorEnZip = True

                    MessageBox.Show(
                    "Error procesando " &
                    Path.GetFileName(rutaTxt) &
                    Environment.NewLine &
                    ex.Message)

                End Try

                '------------------------------------------
                ' PROGRESO REAL
                '------------------------------------------
                trabajosRealizados += 1

                Dim porcentaje =
                CInt((trabajosRealizados / trabajosTotales) * 100)

                progreso.Report(New ProgresoActualizacion With {
                .Valor = porcentaje,
                .Mensaje = "Procesando " & Path.GetFileName(rutaTxt)
            })

            Next

            '------------------------------------------
            ' BORRAR ZIP SOLO SI TODO OK
            '------------------------------------------
            If Not errorEnZip Then
                If File.Exists(item.RutaZip) Then
                    File.Delete(item.RutaZip)
                End If
            End If

        Next

        '==========================================
        ' FIN
        '==========================================
        progreso.Report(New ProgresoActualizacion With {
        .Valor = 100,
        .Mensaje = "Actualización finalizada"
    })

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

    Private Function ObtenerProcedureOS(ByVal argNombreTXT As String) As String

        Select Case argNombreTXT
            Case "OSoc"
                Return "sp_actualizar_os"
            Case "DetVdm"
                Return "sp_actualizar_vademecum"
            Case "Planes"
                Return "sp_actualizar_planes_os"
            Case "DatoRequerido"
                Return "sp_actualizar_datos_requeridos"
            Case Else
                Return "NO APLICA"
        End Select

    End Function

    '==============================================
    ' TOKEN
    '==============================================
    Private Function ObtenerToken() As String
        Dim AdminDT As New N_AdminDB
        Dim sql As String = "SELECT Token FROM parametros_actualizacion"
        Dim token As String = AdminDT.ObtenerValor(sql)
        Return token
    End Function

End Class