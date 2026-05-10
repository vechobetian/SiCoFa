Imports System.Collections.Generic
Imports System.IO
Imports System.Net.Http
Imports System.Text
Imports System.Threading.Tasks
Imports MySql.Data.MySqlClient

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
    Public Async Function DescargarArchivoAsync(token As String, nombreArchivo As String, rutaDestino As String) As Task

        If String.IsNullOrWhiteSpace(token) OrElse String.IsNullOrWhiteSpace(nombreArchivo) Then

            Throw New ArgumentException("Token o archivo inválido")

        End If

        Dim url As String = $"https://www.sicofa.com.ar/descargar.php?token={Uri.EscapeDataString(token)}&archivo={Uri.EscapeDataString(nombreArchivo)}"

        Try

            Using response = Await http.GetAsync(url, HttpCompletionOption.ResponseHeadersRead)

                response.EnsureSuccessStatusCode()

                Using stream = Await response.Content.ReadAsStreamAsync()

                    Using fs As New FileStream(rutaDestino, FileMode.Create, FileAccess.Write, FileShare.None)

                        Await stream.CopyToAsync(fs)

                    End Using

                End Using

            End Using

        Catch ex As Exception
            Throw New Exception($"Error descargando {nombreArchivo}: {ex.Message}", ex)

        End Try

    End Function

    Public Function ImportarAStaging1(ByVal rutaArchivo As String) As Boolean

        Dim objConexionDB As New D_Conexion

        Using cn As MySqlConnection = objConexionDB.ObtenerConexion
            Dim tx As MySqlTransaction = cn.BeginTransaction()

            Try
                ' Limpiar tabla
                Using cmdTruncate As New MySqlCommand("TRUNCATE TABLE staging", cn, tx)
                    cmdTruncate.ExecuteNonQuery()
                End Using

                Dim sqlBase As String =
                    "INSERT INTO staging (linea_completa) VALUES "

                Dim sb As New Text.StringBuilder()
                sb.Append(sqlBase)

                Dim contadorLote As Integer = 0

                Using sr As New StreamReader(rutaArchivo, Encoding.GetEncoding(437), False, 65536)

                    Dim linea As String

                    Do While Not sr.EndOfStream

                        linea = sr.ReadLine()

                        ' SOLO ignoramos NULL reales
                        If linea Is Nothing Then Continue Do

                        linea = linea.Replace("'", "''")

                        sb.AppendFormat("('{0}'),", linea)
                        contadorLote += 1

                        If contadorLote = 1000 Then

                            Using cmdInsert As New MySqlCommand(sb.ToString().TrimEnd(","c), cn, tx)
                                cmdInsert.ExecuteNonQuery()
                            End Using

                            sb.Clear()
                            sb.Append(sqlBase)
                            contadorLote = 0
                        End If

                    Loop

                End Using

                ' Insertar resto
                If contadorLote > 0 Then
                    Using cmdInsert As New MySqlCommand(sb.ToString().TrimEnd(","c), cn, tx)
                        cmdInsert.ExecuteNonQuery()
                    End Using
                End If

                tx.Commit()
                Return True

            Catch ex As Exception
                tx.Rollback()
                Throw
            End Try
        End Using

    End Function

    Public Sub ProcesarActualizacion(argCodiLP As String, argNumeroActualizacion As Long, argSP As String, argPorcentaje As Decimal, argRutaArchivo As String)

        Dim objConexionDB As New D_Conexion

        Using cn As MySqlConnection = objConexionDB.ObtenerConexion()

            Using tx = cn.BeginTransaction()

                Try
                    ImportarAStaging(argRutaArchivo, cn, tx)
                    ActualizarArticulos(argSP, argPorcentaje, cn, tx)
                    ActualizarNumeroActualizacion(argCodiLP, argNumeroActualizacion, cn, tx)

                    tx.Commit()

                Catch ex As Exception
                    tx.Rollback()
                    Throw New Exception("Error en proceso completo: " & ex.Message, ex)
                End Try

            End Using

        End Using

    End Sub

    Public Sub ImportarAStaging(rutaArchivo As String, cn As MySqlConnection, tx As MySqlTransaction)

        ' ⭐ Convertir a UTF8
        Dim contenido = File.ReadAllText(rutaArchivo, Encoding.GetEncoding(437))
        Dim utf8SinBom As New UTF8Encoding(False)

        File.WriteAllText(rutaArchivo, contenido, utf8SinBom)

        Using cmd As New MySqlCommand("TRUNCATE TABLE staging", cn, tx)
            cmd.ExecuteNonQuery()
        End Using

        Dim sql As String =
        "LOAD DATA LOCAL INFILE @archivo
         INTO TABLE staging
         CHARACTER SET utf8
         FIELDS TERMINATED BY '\n'
         LINES TERMINATED BY '\n'
         (linea_completa);"

        Using cmd As New MySqlCommand(sql, cn, tx)
            cmd.Parameters.AddWithValue("@archivo", rutaArchivo)
            cmd.ExecuteNonQuery()
        End Using

    End Sub

    Public Sub ActualizarArticulos(sp As String, porcentaje As Decimal, cn As MySqlConnection, tx As MySqlTransaction)

        Using cmd As New MySqlCommand(sp, cn, tx)

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 0

            cmd.Parameters.Add("p_Porcentaje", MySqlDbType.Decimal).Value = porcentaje

            cmd.ExecuteNonQuery()

        End Using

    End Sub

    Public Sub ActualizarNumeroActualizacion(ByVal argCodiLP As String, ByVal argNumeroActualizacion As Long, cn As MySqlConnection, tx As MySqlTransaction)

        Dim sql As String = "UPDATE lista_precios SET NumeroActualizacion = @nro  WHERE CodiLP = @codi"

        Using cmd As New MySqlCommand(sql, cn, tx)

            cmd.Parameters.Add("@nro", MySqlDbType.Int64).Value = argNumeroActualizacion
            cmd.Parameters.Add("@codi", MySqlDbType.VarChar).Value = argCodiLP

            cmd.ExecuteNonQuery()

        End Using

    End Sub

End Class