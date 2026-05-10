Imports System.IO
Imports System.Threading.Tasks
Imports Newtonsoft.Json.Linq
Imports SiCoFa.Negocio

Public Class FrmActualizaciones

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
            Directory.CreateDirectory(Path.Combine(rutaBase, "dat"))
            Directory.CreateDirectory(Path.Combine(rutaBase, "Procesadas"))

        Catch ex As Exception
            MessageBox.Show("Error al crear carpetas: " & ex.Message)
        End Try

    End Sub

    Private Sub LimpiarCarpetas()

        Try
            Dim rutaBase As String = "C:\SiCoFa_Server\Actualizaciones"

            If Directory.Exists(rutaBase) Then
                For Each archivo In Directory.GetFiles(rutaBase, "*.*", SearchOption.AllDirectories)
                    File.Delete(archivo)
                Next
            End If

        Catch ex As Exception
            MessageBox.Show("Error limpiando carpetas: " & ex.Message)
        End Try

    End Sub

    Private Async Function ActualizarArticulos() As Task

        Try

            Dim token As String = ObtenerToken()
            Dim adminLP As New N_AdminListaPrecios
            Dim listas = adminLP.ObtenerListasPreciosActivas()

            Dim mapListas = listas.ToDictionary(Function(x) x.CodiLP, StringComparer.OrdinalIgnoreCase)

            Dim archivos = Await mAdminActualizaciones.ListarArchivosServidorAsync(token)

            Dim archivosOrdenados =
            archivos.OrderBy(Function(a) CLng(a.Substring(2, 8)))

            For Each archivo In archivosOrdenados

                Dim codigoLista = archivo.Substring(0, 2)

                If Not mapListas.ContainsKey(codigoLista) Then Continue For

                Dim lista = mapListas(codigoLista)

                Dim nroActualizacionArchivo = CLng(archivo.Substring(2, 8))

                Dim nroActual = If(lista.NumeroActualizacion.HasValue, lista.NumeroActualizacion.Value, 0)

                If nroActualizacionArchivo <= nroActual Then Continue For

                Dim rutaZip = Await mAdminActualizaciones.DescargarArchivoAsync(token, archivo)

                Dim rutaTxt = mAdminActualizaciones.NormalizarArchivoZip(archivo)

                mAdminActualizaciones.ProcesarActualizacion(lista.CodiLP, nroActualizacionArchivo, lista.SP, lista.PorcentajeAplicado, rutaTxt)
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Function

    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            Await Me.ActualizarArticulos

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Function ObtenerToken() As String
        Return "21036271"
    End Function

    Private Function ObtenerRutaZip() As String
        Return "C:\SiCoFa_Server\Actualizaciones\zip"
    End Function

End Class