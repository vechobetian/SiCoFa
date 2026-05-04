Imports System.IO
Imports SiCoFa.Negocio
Imports SiCoFa.Entidades

Public Class FrmActualizaciones
    Private mAdminDB As New N_AdminDB

    Private Sub CrearCarpetas()
        Try
            ' Definimos la ruta base
            Dim rutaBase As String = "C:\SiCoFa_Server\Actualizaciones"

            ' Creamos las subcarpetas directamente
            ' .NET creará "SiCoFa_Server" y "Actualizaciones" si no existen
            Directory.CreateDirectory(Path.Combine(rutaBase, "zip"))
            Directory.CreateDirectory(Path.Combine(rutaBase, "txt"))
            Directory.CreateDirectory(Path.Combine(rutaBase, "dat"))
            Directory.CreateDirectory(Path.Combine(rutaBase, "Procesadas"))

        Catch ex As Exception
            ' Es importante manejar excepciones (ej. falta de permisos en C:\)
            MessageBox.Show("Error al crear las carpetas: " & ex.Message)
        End Try

    End Sub
    Private Function VerificarCliente() As Boolean
        Dim UsFTP As String = mAdminDB.ObtenerValor("SELECT Id FROM parametros_actualizacion")
        Dim Estado As String = mAdminDB.ObtenerValor("SELECT EstadoContrato FROM TblContratos", "CONTRATOS")
        If Estado = "VIGENTE" Then
            Return True
        End If
    End Function

    Private Sub DescargarArchivosNoProcesados()
        Try
            Dim ftp As New N_AdminFTP
            ' Definimos la ruta tal cual vimos en el árbol de directorios
            Dim rutaRemota As String = "Actualizaciones/"

            ' Obtenemos la lista de archivos
            Dim archivos As List(Of Archivo) = ftp.ListFiles(rutaRemota)

            If archivos IsNot Nothing AndAlso archivos.Count > 0 Then
                For Each archivo In archivos
                    MsgBox(archivo.Name)
                Next

            End If

        Catch ex As Exception
            MessageBox.Show("Error al listar archivos del FTP: " & ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.DescargarArchivosNoProcesados()
    End Sub
End Class