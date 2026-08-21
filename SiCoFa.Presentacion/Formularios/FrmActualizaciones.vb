Imports System.IO
Imports System.Threading.Tasks
Imports SiCoFa.Negocio
Imports SiCoFa.Entidades

Public Class FrmActualizaciones

    Private ReadOnly mAdminActualizaciones As New N_AdminActualizaciones()
    Private mToken As String
    Private mItemsActualizacion As New List(Of ItemActualizacion)

    Private Sub ConfigurarGrillaActualizaciones()

        dgvActualizaciones.AutoGenerateColumns = False
        dgvActualizaciones.AllowUserToAddRows = False
        dgvActualizaciones.AllowUserToDeleteRows = False
        dgvActualizaciones.AllowUserToResizeRows = False
        dgvActualizaciones.ReadOnly = True
        dgvActualizaciones.MultiSelect = False
        dgvActualizaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        dgvActualizaciones.Columns.Clear()

        dgvActualizaciones.Columns.Add(
        New DataGridViewTextBoxColumn With {
            .Name = "Descripcion",
            .HeaderText = "Descripción",
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        })

        dgvActualizaciones.Columns.Add(
        New DataGridViewTextBoxColumn With {
            .Name = "NumeroActualizacion",
            .HeaderText = "Actualización",
            .Width = 100
        })

        dgvActualizaciones.Columns.Add(
        New DataGridViewTextBoxColumn With {
            .Name = "Estado",
            .HeaderText = "Estado",
            .Width = 100
        })

    End Sub

    Private Sub AgregarItemActualizacion(item As ItemActualizacion)

        mItemsActualizacion.Add(item)

        Dim fila As Integer = dgvActualizaciones.Rows.Add()

        'Guardar el objeto asociado a la fila
        dgvActualizaciones.Rows(fila).Tag = item

        If item.Proceso IsNot Nothing Then

            dgvActualizaciones.Rows(fila).Cells("Descripcion").Value = item.Proceso.Descripcion

        ElseIf item.ObraSocial IsNot Nothing Then

            dgvActualizaciones.Rows(fila).Cells("Descripcion").Value = item.ObraSocial.NombreOS

        End If

        dgvActualizaciones.Rows(fila).Cells("NumeroActualizacion").Value = item.NumeroActualizacion

        dgvActualizaciones.Rows(fila).Cells("Estado").Value = item.Estado

    End Sub

    Private Async Function DescargarActualizacionesArticulos() As Task

        Dim adminPA As New N_AdminProcesosActualizacion

        Dim procesos As List(Of ProcesoActualizacion) = adminPA.ObtenerProcesosActualizacion()

        Dim mapProcesos = procesos.ToDictionary(Function(x) x.CodiPA, StringComparer.OrdinalIgnoreCase)

        lblEstado.Text = "Consultando servidor..."

        '------------------------------------------
        ' LISTAR ZIP
        '------------------------------------------

        Dim archivos = Await mAdminActualizaciones.ListarArchivosServidorAsync(mToken)

        Dim archivosOrdenados =
            archivos.OrderBy(
            Function(a)
                Dim n = Path.GetFileNameWithoutExtension(a)
                Return CLng(n.Substring(2))
            End Function).ToList()

        '------------------------------------------
        ' DESCARGAR
        '------------------------------------------

        For Each archivoZip In archivosOrdenados

            Dim codigoPA = archivoZip.Substring(0, 2)

            If Not mapProcesos.ContainsKey(codigoPA) Then
                Continue For
            End If

            Dim proceso = mapProcesos(codigoPA)

            Dim nroActual =
            If(proceso.NumeroActualizacion.HasValue,
               proceso.NumeroActualizacion.Value,
               0)

            Dim nombreSinExtension = Path.GetFileNameWithoutExtension(archivoZip)

            Dim numeroTexto = nombreSinExtension.Substring(2)

            Dim nroActualizacionZip As Long

            If Not Long.TryParse(numeroTexto, nroActualizacionZip) Then
                Continue For
            End If

            If nroActualizacionZip <= nroActual Then
                Continue For
            End If

            lblEstado.Text = "Descargando " & archivoZip

            '------------------------------------------
            ' DESCARGAR ZIP
            '------------------------------------------

            Dim rutaZip = Await mAdminActualizaciones.DescargarArchivoAsync(mToken, archivoZip)

            '------------------------------------------
            ' CREAR ITEM
            '------------------------------------------

            Dim itemActualizacion As New ItemActualizacion With {
            .Archivo = archivoZip,
            .RutaArchivo = rutaZip,
            .NumeroActualizacion = nroActualizacionZip,
            .Estado = "Pendiente",
            .Proceso = proceso
        }

            AgregarItemActualizacion(itemActualizacion)

        Next

        lblEstado.Text = "Descarga de artículos finalizada"

    End Function

    Private Async Function DescargarActualizacionesOS() As Task

        Dim adminPA As New N_AdminProcesosActualizacion

        Dim obrasociales = adminPA.ObtenerObraSociales()

        Dim mapOS = obrasociales.ToDictionary(Function(x) x.IdOS)

        lblEstado.Text = "Consultando actualizaciones de obras sociales..."

        '------------------------------------------
        ' LISTAR ZIP
        '------------------------------------------

        Dim archivos = Await mAdminActualizaciones.ListarArchivosOSServidorAsync(mToken)

        Dim archivosOrdenados =
        archivos.OrderBy(
            Function(a)
                Dim n = Path.GetFileNameWithoutExtension(a)
                Return CLng(n.Substring(5))
            End Function).ToList()

        '------------------------------------------
        ' DESCARGAR
        '------------------------------------------

        For Each archivoZip In archivosOrdenados

            '------------------------------------------
            ' ID OBRA SOCIAL
            '------------------------------------------

            Dim idOSTexto = archivoZip.Substring(2, 3)

            Dim idOS As Integer

            If Not Integer.TryParse(idOSTexto, idOS) Then
                Continue For
            End If

            '------------------------------------------
            ' BUSCAR OBRA SOCIAL
            '------------------------------------------

            Dim os As ObraSocial = Nothing

            If Not mapOS.TryGetValue(idOS, os) Then
                Continue For
            End If

            '------------------------------------------
            ' NUMERO ACTUAL
            '------------------------------------------

            Dim nroActual As Long =
            If(os.NumeroActualizacion.HasValue,
               os.NumeroActualizacion.Value,
               0)

            '------------------------------------------
            ' NUMERO ACTUALIZACION DEL ZIP
            '------------------------------------------

            Dim nombreSinExtension = Path.GetFileNameWithoutExtension(archivoZip)

            Dim numeroTexto = nombreSinExtension.Substring(5)

            Dim nroActualizacionZip As Long

            If Not Long.TryParse(numeroTexto, nroActualizacionZip) Then
                Continue For
            End If

            If nroActualizacionZip <= nroActual Then
                Continue For
            End If

            lblEstado.Text = "Descargando " & archivoZip

            '------------------------------------------
            ' DESCARGAR ZIP
            '------------------------------------------

            Dim rutaZip = Await mAdminActualizaciones.DescargarArchivoAsync(mToken, archivoZip)

            '------------------------------------------
            ' CREAR ITEM
            '------------------------------------------

            Dim itemActualizacion As New ItemActualizacion With {
            .Archivo = archivoZip,
            .RutaArchivo = rutaZip,
            .NumeroActualizacion = nroActualizacionZip,
            .Estado = "Pendiente",
            .ObraSocial = os
        }

            AgregarItemActualizacion(itemActualizacion)

        Next

        lblEstado.Text =
        "Descarga de obras sociales finalizada"

    End Function

    Private Async Function ProcesarActualizaciones() As Task

        If mItemsActualizacion.Count = 0 Then
            Return
        End If

        For Each item In mItemsActualizacion

            If item.Estado <> "Pendiente" Then
                Continue For
            End If

            item.Estado = "Procesando..."
            ActualizarEstadoGrilla(item)

            If item.Proceso IsNot Nothing Then

                Await ProcesarItemArticulo(item)

            ElseIf item.ObraSocial IsNot Nothing Then

                Await ProcesarItemObraSocial(item)

            End If

        Next

        lblEstado.Text = "Procesamiento finalizado"

    End Function

    Private Async Function ProcesarItemArticulo(item As ItemActualizacion) As Task

        Dim errorEnItem As Boolean = False

        Try

            '==========================================
            ' OBTENER PROCESOS
            '==========================================

            Dim adminPA As New N_AdminProcesosActualizacion

            Dim procesos As List(Of ProcesoActualizacion) = adminPA.ObtenerProcesosActualizacion()

            Dim mapProcesos =
            procesos.ToDictionary(
                Function(x) x.CodiPA,
                StringComparer.OrdinalIgnoreCase)

            '==========================================
            ' EXTRAER ZIP
            '==========================================

            lblEstado.Text = "Extrayendo " & item.Archivo

            Dim rutasTxt = mAdminActualizaciones.NormalizarArchivoZip(Path.GetFileName(item.RutaArchivo))

            '==========================================
            ' PROCESAR CADA TXT
            '==========================================

            For Each rutaTxt In rutasTxt

                Try

                    Dim nombreTxt = Path.GetFileNameWithoutExtension(rutaTxt)

                    If nombreTxt.Length < 2 Then
                        Continue For
                    End If

                    Dim codigoPA = nombreTxt.Substring(0, 2)

                    '----------------------------------
                    ' BUSCAR PROCESO SEGÚN EL TXT
                    '----------------------------------

                    If Not mapProcesos.ContainsKey(codigoPA) Then

                        Throw New Exception(
                        "No existe proceso de actualización para " &
                        nombreTxt)

                    End If

                    Dim proceso = mapProcesos(codigoPA)

                    lblEstado.Text = "Procesando " & proceso.Descripcion

                    '----------------------------------
                    ' PROCESAR
                    '----------------------------------

                    Await Task.Run(
                    Sub()

                        mAdminActualizaciones.ProcesarActualizacionArticulos(
                            proceso.CodiPA,
                            item.NumeroActualizacion,
                            proceso.StoredProcedure,
                            proceso.PorcentajeAplicado,
                            rutaTxt)

                    End Sub)

                    '----------------------------------
                    ' BORRAR TXT
                    '----------------------------------

                    If File.Exists(rutaTxt) Then
                        File.Delete(rutaTxt)
                    End If

                Catch ex As Exception

                    errorEnItem = True

                    MessageBox.Show(
                    "Error procesando " &
                    Path.GetFileName(rutaTxt) &
                    Environment.NewLine &
                    ex.Message,
                    "Actualizaciones",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error)

                    Exit For

                End Try

            Next

        Catch ex As Exception

            errorEnItem = True

            MessageBox.Show(
            "Error procesando ZIP " &
            item.Archivo &
            Environment.NewLine &
            ex.Message,
            "Actualizaciones",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error)

        End Try

        '==========================================
        ' RESULTADO
        '==========================================

        If Not errorEnItem Then

            If File.Exists(item.RutaArchivo) Then
                File.Delete(item.RutaArchivo)
            End If

            item.Estado = "Procesado"

        Else

            item.Estado = "Error"

        End If

        ActualizarEstadoGrilla(item)

    End Function

    Private Async Function ProcesarItemObraSocial(item As ItemActualizacion) As Task

        Dim errorEnItem As Boolean = False

        Dim OrdenProcesamiento As New Dictionary(Of String, Integer)(
        StringComparer.OrdinalIgnoreCase) From {
            {"OSoc", 1},
            {"Planes", 2},
            {"DetVdm", 3},
            {"DatoRequerido", 4}
        }

        Try

            '==========================================
            ' ID OBRA SOCIAL
            '==========================================

            Dim idOS As Integer = item.ObraSocial.IdOS

            '==========================================
            ' EXTRAER ZIP
            '==========================================

            lblEstado.Text = "Extrayendo " & item.Archivo

            Dim rutasTxt = mAdminActualizaciones.NormalizarArchivoZipOS(Path.GetFileName(item.RutaArchivo))

            '==========================================
            ' ORDENAR TXT
            '==========================================

            Dim txtOrdenados =
            rutasTxt.OrderBy(
                Function(t)

                    Dim nombre =
                        Path.GetFileNameWithoutExtension(t)

                    If OrdenProcesamiento.ContainsKey(nombre) Then
                        Return OrdenProcesamiento(nombre)
                    End If

                    Return 999

                End Function).ToList()

            '==========================================
            ' PROCESAR TXT
            '==========================================

            For Each rutaTxt In txtOrdenados

                Try

                    Dim nombreTxt = Path.GetFileNameWithoutExtension(rutaTxt)

                    Dim sp As String = ObtenerProcedureOS(nombreTxt)

                    If sp = "NO APLICA" Then

                        If File.Exists(rutaTxt) Then
                            File.Delete(rutaTxt)
                        End If

                        Continue For

                    End If

                    lblEstado.Text = "Procesando " & item.ObraSocial.NombreOS & " - " & nombreTxt

                    '----------------------------------
                    ' PROCESAR
                    '----------------------------------

                    Await Task.Run(
                    Sub()

                        mAdminActualizaciones.ProcesarActualizacionObraSociales(
                            idOS,
                            item.NumeroActualizacion,
                            sp,
                            rutaTxt)

                    End Sub)

                    '----------------------------------
                    ' BORRAR TXT
                    '----------------------------------

                    If File.Exists(rutaTxt) Then
                        File.Delete(rutaTxt)
                    End If

                Catch ex As Exception

                    errorEnItem = True

                    MessageBox.Show(
                    "Error procesando " &
                    Path.GetFileName(rutaTxt) &
                    Environment.NewLine &
                    ex.Message,
                    "Actualizaciones",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error)

                    Exit For

                End Try

            Next

        Catch ex As Exception

            errorEnItem = True

            MessageBox.Show(
            "Error procesando " &
            item.Archivo &
            Environment.NewLine &
            ex.Message,
            "Actualizaciones",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error)

        End Try

        '==========================================
        ' RESULTADO
        '==========================================

        If Not errorEnItem Then

            If File.Exists(item.RutaArchivo) Then
                File.Delete(item.RutaArchivo)
            End If

            item.Estado = "Procesado"

        Else

            item.Estado = "Error"

        End If

        ActualizarEstadoGrilla(item)

    End Function

    Private Sub ActualizarEstadoGrilla(item As ItemActualizacion)

        For Each fila As DataGridViewRow In dgvActualizaciones.Rows

            If fila.IsNewRow Then Continue For

            Dim itemFila = TryCast(fila.Tag, ItemActualizacion)

            If itemFila Is item Then

                fila.Cells("Estado").Value = item.Estado
                Exit For

            End If

        Next

    End Sub

    '==============================================
    ' LOAD
    '==============================================
    Private Sub FrmActualizaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        mToken = ObtenerToken()
        lblEstado.Text = "Preparado..."
        ConfigurarGrillaActualizaciones()
        CrearCarpetas()
        LimpiarCarpetas()

        btnDescargar.Visible = True
        btnProcesar.Visible = False

    End Sub

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

    Private Async Sub btnDescargar_Click(sender As Object, e As EventArgs) Handles btnDescargar.Click

        btnDescargar.Enabled = False

        Try

            mItemsActualizacion.Clear()
            dgvActualizaciones.Rows.Clear()

            Await DescargarActualizacionesArticulos()
            Await DescargarActualizacionesOS()

            lblEstado.Text = "Descarga finalizada"

            btnDescargar.Visible = False
            btnProcesar.Visible = True

        Catch ex As Exception

            MessageBox.Show(
            "Error descargando actualizaciones:" &
            Environment.NewLine &
            ex.Message,
            "Actualizaciones",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error)

        Finally

            btnDescargar.Enabled = True

        End Try

    End Sub

    Private Async Sub btnProcesar_Click(sender As Object, e As EventArgs) Handles btnProcesar.Click

        If mItemsActualizacion.Count = 0 Then

            MessageBox.Show(
            "No hay actualizaciones pendientes para procesar.",
            "Actualizaciones",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information)

            Return

        End If

        btnProcesar.Enabled = False

        Try

            Await ProcesarActualizaciones()

            lblEstado.Text = "Procesamiento finalizado"

        Catch ex As Exception

            MessageBox.Show(
            "Error procesando actualizaciones:" &
            Environment.NewLine &
            ex.Message,
            "Actualizaciones",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error)

        Finally

            btnProcesar.Enabled = True

        End Try

    End Sub

End Class