Imports System.Collections.Generic
Imports MySql.Data.MySqlClient
Imports SiCoFa.Entidades

Public Class D_AdminProcesosActualizacion

    Private ReadOnly objConexionDB As New D_Conexion

    '-------------------------------------------------------
    ' MAPEO CENTRALIZADO
    '-------------------------------------------------------
    Private Function MapProcesoActualizacion(dr As MySqlDataReader) As ProcesoActualizacion

        Return New ProcesoActualizacion(
        argCodiPA:=dr("CodiPA").ToString(),
        argDescripcion:=dr("Descripcion").ToString(),
        argPorcentajeAplicado:=If(IsDBNull(dr("PorcentajeAplicado")), Nothing, Convert.ToDecimal(dr("PorcentajeAplicado"))),
        argNumeroActualizacion:=If(IsDBNull(dr("NumeroActualizacion")), Nothing, Convert.ToInt64(dr("NumeroActualizacion"))),
        argStoredProcedure:=If(IsDBNull(dr("StoredProcedure")), Nothing, dr("StoredProcedure").ToString())
    )

    End Function

    Public Function ObtenerProcesosActualizacion() As List(Of ProcesoActualizacion)

        Dim lista As New List(Of ProcesoActualizacion)

        Try
            Using cn = objConexionDB.ObtenerConexion()

                Const sql As String =
                "SELECT 
                    CodiPA,
                    Descripcion,
                    PorcentajeAplicado,
                    NumeroActualizacion,
                    StoredProcedure
                 FROM procesos_actualizacion                 
                 ORDER BY Descripcion"

                Using cmd As New MySqlCommand(sql, cn)

                    Using dr = cmd.ExecuteReader()

                        While dr.Read()
                            lista.Add(MapProcesoActualizacion(dr))
                        End While

                    End Using
                End Using
            End Using

            Return lista

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, NameOf(ObtenerProcesosActualizacion), ex.Message))
        End Try

    End Function

End Class