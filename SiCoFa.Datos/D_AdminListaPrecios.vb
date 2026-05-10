Imports System.Collections.Generic
Imports MySql.Data.MySqlClient
Imports SiCoFa.Entidades

Public Class D_AdminListaPrecios

    Private ReadOnly objConexionDB As New D_Conexion

    '-------------------------------------------------------
    ' MAPEO CENTRALIZADO
    '-------------------------------------------------------
    Private Function MapListaPrecio(dr As MySqlDataReader) As ListaPrecios

        Return New ListaPrecios(
        argCodiLP:=dr("CodiLP").ToString(),
        argListaPrecios:=dr("ListaPrecios").ToString(),
        argPrecioReferencia:=dr("PrecioReferencia").ToString(),
        argPorcentajeAplicado:=If(IsDBNull(dr("PorcentajeAplicado")), Nothing, Convert.ToDecimal(dr("PorcentajeAplicado"))),
        argNumeroActualizacion:=If(IsDBNull(dr("NumeroActualizacion")), Nothing, Convert.ToInt64(dr("NumeroActualizacion"))),
        argBaja:=If(IsDBNull(dr("Baja")), Nothing, Convert.ToBoolean(dr("Baja"))),
        argSP:=If(IsDBNull(dr("SP")), Nothing, dr("SP").ToString())
    )

    End Function

    '-------------------------------------------------------
    ' UNA lista por código
    '-------------------------------------------------------
    Public Function ObtenerListaPreciosPorCodiLP(argCodiLP As String) As ListaPrecios

        Try
            Using cn = objConexionDB.ObtenerConexion()

                Const sql As String =
                "SELECT 
                    CodiLP,
                    ListaPrecios,
                    PrecioReferencia,
                    PorcentajeAplicado,
                    NumeroActualizacion,
                    Baja,
                    SP
                 FROM lista_precios
                 WHERE CodiLP = @CodiLP
                 LIMIT 1"

                Using cmd As New MySqlCommand(sql, cn)

                    cmd.Parameters.Add("@CodiLP", MySqlDbType.VarChar).Value = argCodiLP

                    Using dr = cmd.ExecuteReader()

                        If dr.Read() Then
                            Return MapListaPrecio(dr)
                        End If

                    End Using
                End Using
            End Using

            Return Nothing

        Catch ex As Exception
            Throw New Exception(
                Vecho.MensajeError(Me.ToString,
                                   NameOf(ObtenerListaPreciosPorCodiLP),
                                   ex.Message))
        End Try

    End Function

    '-------------------------------------------------------
    ' TODAS las listas activas
    '-------------------------------------------------------
    Public Function ObtenerListasPreciosActivas() As List(Of ListaPrecios)

        Dim lista As New List(Of ListaPrecios)

        Try
            Using cn = objConexionDB.ObtenerConexion()

                Const sql As String =
                "SELECT 
                    CodiLP,
                    ListaPrecios,
                    PrecioReferencia,
                    PorcentajeAplicado,
                    NumeroActualizacion,
                    Baja,
                    SP
                 FROM lista_precios
                 WHERE Baja = 0
                 ORDER BY ListaPrecios"

                Using cmd As New MySqlCommand(sql, cn)

                    Using dr = cmd.ExecuteReader()

                        While dr.Read()
                            lista.Add(MapListaPrecio(dr))
                        End While

                    End Using
                End Using
            End Using

            Return lista

        Catch ex As Exception
            Throw New Exception(
                Vecho.MensajeError(Me.ToString,
                                   NameOf(ObtenerListasPreciosActivas),
                                   ex.Message))
        End Try

    End Function

End Class