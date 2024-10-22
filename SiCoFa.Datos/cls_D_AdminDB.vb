Imports System.Collections.Generic
Imports System.Linq
Imports MySql.Data.MySqlClient
Public Class cls_D_AdminDB
    Public Function ObtenerTabla(ByVal argSql As String) As DataTable

        Try
            Dim tbl As New DataTable

            Using adapter = New MySqlDataAdapter(argSql, Mod_D_Admin.ConexionDB.Conexion)
                adapter.Fill(tbl)
            End Using

            Return tbl

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ObtenerTabla", ex.Message))
            Return Nothing

        End Try

    End Function
    Public Sub ActualizarTabla(ByVal argSql As String, ByVal argTbl As DataTable)

        Try

            Using adapter = New MySqlDataAdapter(argSql, Mod_D_Admin.ConexionDB.Conexion)

                Using builder As New MySqlCommandBuilder(adapter)
                    adapter.Update(argTbl)

                End Using

            End Using

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ActualizarTabla", ex.Message))

        End Try

    End Sub
    Public Function ObtenerValor(ByVal argSql As String) As Object

        Try
            Dim command As New MySqlCommand(argSql, Mod_D_Admin.ConexionDB.Conexion)
            Dim valor As Object = command.ExecuteScalar()

            If valor IsNot Nothing Then
                Return valor
            Else
                Return Nothing
            End If

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerValor", ex.Message))

        End Try

    End Function
    Public Function ObtenerRegistro(ByVal argSql As String) As Dictionary(Of String, Object)

        Try

            Using cmd As MySqlCommand = Mod_D_Admin.ConexionDB.Conexion.CreateCommand
                cmd.CommandType = CommandType.Text
                cmd.CommandText = argSql

                Using datos As MySqlDataReader = cmd.ExecuteReader()

                    If datos.HasRows Then

                        datos.Read()

                        ' Crear un diccionario para almacenar los valores del registro
                        Dim resultado As New Dictionary(Of String, Object)()

                        ' Iterar sobre todos los campos del registro y agregar sus nombres y valores al diccionario
                        For i As Integer = 0 To datos.FieldCount - 1
                            Dim nombreCampo As String = datos.GetName(i)
                            Dim valorCampo As Object = datos.GetValue(i)
                            resultado(nombreCampo) = valorCampo
                        Next

                        ' Retornar el diccionario con los valores
                        Return resultado

                    Else
                        Return Nothing

                    End If

                End Using

            End Using

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerRegistro", ex.Message))

        End Try

    End Function
    Public Sub InsertarRegistro(ByVal argSql As String, ByVal valoresColumnas As Dictionary(Of String, Object))

        Try

            Dim columnas As String = String.Join(",", valoresColumnas.Keys.Select(Function(k) "`" & k & "`"))
            Dim valores As String = String.Join(",", valoresColumnas.Keys.Cast(Of String)().Select(Function(k) "@" & k))

            Dim insertCommand As String = $"INSERT INTO {argSql} ({columnas}) VALUES ({valores})"

            Using cmd As New MySqlCommand(insertCommand, Mod_D_Admin.ConexionDB.Conexion)

                For Each columna In valoresColumnas
                    cmd.Parameters.AddWithValue("@" & columna.Key, columna.Value)
                Next

                cmd.ExecuteNonQuery()

            End Using

        Catch ex As Exception
            ' Manejo de excepciones
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarRegistro", $"Error: {ex.Message}{Environment.NewLine}StackTrace: {ex.StackTrace}"))
        End Try

    End Sub

End Class