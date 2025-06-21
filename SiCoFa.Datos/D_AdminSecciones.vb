Imports MySql.Data.MySqlClient
Imports SiCoFa.Entidades
Imports System.Collections.Generic

Public Class D_AdminSecciones

    Public Function ObtenerSeccionPorId(ByVal argIdSeccion As String) As Seccion

        Dim objConexionDB As New D_Conexion
        Dim objSec As Seccion

        Try
            Dim sql As String = "SELECT IdSeccion,Seccion,EstablecerPrecio FROM TblSecciones WHERE IdSeccion=@IdSeccion"

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql
                    cmd.Parameters.AddWithValue("@IdSeccion", argIdSeccion)

                    Using datos As MySqlDataReader = cmd.ExecuteReader()

                        If datos.Read Then
                            Dim IdSeccion As String = datos("IdSeccion")
                            Dim Seccion As String = datos("Seccion")
                            Dim EstablecerPrecio As String = datos("EstablecerPrecio")
                            objSec = New Seccion(IdSeccion, Seccion, EstablecerPrecio)
                        Else
                            objSec = Nothing
                        End If

                    End Using

                End Using

            End Using
            Return objSec

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerSeccionPorId", ex.Message))
            Return Nothing

        End Try

    End Function
    Public Function ListarSecciones(ByVal argTextoBuscado As String) As List(Of Seccion)
        Dim objConexionDB As New D_Conexion
        Dim ls As New List(Of Seccion)
        Dim s As Seccion

        Try
            Dim sql As String
            If argTextoBuscado = "*" Then
                sql = "SELECT IdSeccion,Seccion,EstablecerPrecio FROM TblSecciones ORDER BY Seccion"
            Else
                sql = "SELECT IdSeccion,Seccion,EstablecerPrecio FROM TblSecciones WHERE Seccion LIKE @Seccion ORDER BY Seccion"
            End If

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql

                    If argTextoBuscado <> "*" Then
                        cmd.Parameters.AddWithValue("@Seccion", Replace(UCase(argTextoBuscado), " ", "%") & "%")
                    End If

                    Using datos As MySqlDataReader = cmd.ExecuteReader()

                        While datos.Read
                            s = New Seccion(datos("IdSeccion"), datos("Seccion"), datos("EstablecerPrecio"))
                            ls.Add(s)
                        End While

                    End Using

                End Using

            End Using

            Return ls

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ListarSecciones", ex.Message))
            Return Nothing

        End Try

    End Function
    Public Function InsertarSeccion(
                                    ByVal argSeccion As String,
                                    ByVal argEstablecerPrecio As Boolean
                                    ) As String

        Dim objConexionDB As New D_Conexion
        Dim IdSeccion As String
        Try
            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("SeccionInsertar", cn) With {.CommandType = CommandType.StoredProcedure}
                    With cmd.Parameters
                        .Add("_Seccion", MySqlDbType.VarChar).Value = argSeccion
                        .Add("_EstablecerPrecio", MySqlDbType.Bit).Value = argEstablecerPrecio
                        .Add("_IdSeccion", MySqlDbType.VarChar)
                    End With

                    cmd.Parameters("_IdSeccion").Direction = ParameterDirection.Output
                    cmd.ExecuteNonQuery()
                    IdSeccion = cmd.Parameters("_IdSeccion").ToString
                End Using

            End Using
            Return IdSeccion

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarSeccion", Ex.Message))
            Return ""

        End Try

    End Function
    Public Function ActualizarSeccion(
                                    ByVal argIdSeccion As String,
                                    ByVal argSeccion As String,
                                    ByVal argEstablecerPrecio As Boolean
                                    ) As Boolean



        Try
            Dim objConexionDB As New D_Conexion
            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("SeccionActualizar", cn) With {.CommandType = CommandType.StoredProcedure}
                    With cmd.Parameters
                        .Add("_IdSeccion", MySqlDbType.VarChar).Value = argIdSeccion
                        .Add("_Seccion", MySqlDbType.VarChar).Value = argSeccion
                        .Add("_EstablecerPrecio", MySqlDbType.Bit).Value = argEstablecerPrecio
                    End With

                    Dim filasAfectadas As Integer = Convert.ToInt32(cmd.ExecuteNonQuery())
                    Return (filasAfectadas > 0) ' Devuelve True si se actualizó al menos una fila

                End Using

            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ActualizarSeccion", Ex.Message))
            Return False

        End Try

    End Function

End Class
