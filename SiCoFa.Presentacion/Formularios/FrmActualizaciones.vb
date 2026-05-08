Imports System.IO
Imports Newtonsoft.Json.Linq
Imports System.Windows.Controls
Imports SiCoFa.Negocio
Imports System.Threading.Tasks

Public Class FrmActualizaciones

    Private ReadOnly mAdminActualizaciones As New N_AdminActualizaciones()

    Private Sub FrmActualizaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CrearCarpetas()
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

    Private Async Function DescargarArchivosNoProcesados() As Task
        Try
            Dim archivos = Await mAdminActualizaciones.ListarArchivosServidorAsync("21036271")
            For Each a In archivos
                If a = "ab26050601.zip" Then
                    Await mAdminActualizaciones.DescargarArchivoAsync("21036271", a)
                End If
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try

    End Function

    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            Dim archivos = Await mAdminActualizaciones.ListarArchivosServidorAsync("21036271")

            For Each a In archivos
                If a = "ab26050601.zip" Then
                    Await mAdminActualizaciones.DescargarArchivoAsync("21036271", a)
                End If
            Next

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