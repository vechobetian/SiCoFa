Imports MySql.Data.MySqlClient
Imports SiCoFa.Entidades

Public Class D_AdminListaPrecios
    Public Function ObtenerListaPreciosPorCodiLP(ByVal argCodiLP As String) As ListaPrecios

        Dim objConexionDB As New D_Conexion
        Dim objLP As ListaPrecios = Nothing

        Try
            Dim sql As String = "SELECT CodiLP,ListaPrecios,PrecioReferencia,PorcentajeAplicado,NumeroActualizacion,Baja FROM lista_precios WHERE CodiLP=@CodiLP"

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql
                    cmd.Parameters.AddWithValue("@CodiLP", argCodiLP)

                    Using datos As MySqlDataReader = cmd.ExecuteReader()

                        If datos.Read() Then
                            objLP = New ListaPrecios(
                                                    argCodiLP:=datos.GetString("CodiLP"),
                                                    argListaPrecios:=datos.GetString("ListaPrecios"),
                                                    argPrecioReferencia:=datos.GetString("PrecioReferencia"),
                                                    argPorcentajeAplicado:=Convert.ToDecimal(datos("PorcentajeAplicado")),
                                                    argNumeroActualizacion:=Convert.ToInt64(datos("NumeroActualizacion")),
                                                    argBaja:=datos.GetBoolean("Baja")
                                                    )

                        End If

                    End Using

                End Using

            End Using
            Return objLP

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerListaPreciosPorCodiLP", ex.Message))

        End Try

    End Function
End Class
