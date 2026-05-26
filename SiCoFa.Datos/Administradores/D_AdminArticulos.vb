Imports System.Collections.Generic
Imports MySql.Data.MySqlClient
Imports SiCoFa.Entidades
Imports SiCoFa.Entidades.Enums

Public Class D_AdminArticulos

    Public Function ObtenerArticuloPorId(ByVal argIdArticulo As String) As Articulo

        Dim objConexionDB As New D_Conexion

        Try

            Dim sql As String = "SELECT IdArticulo,
                                        Codigo,
                                        CodBarras,
                                        Nombre,
                                        CodiTV,
                                        AlicIVA,
                                        Unidades,
                                        CodiTE,
                                        FechaPrecio,
                                        PrecioCosto,
                                        PrecioVenta,
                                        PrecioOferta,
                                        CodiLabora,
                                        Laboratorio,
                                        CodiMon,
                                        Monodroga,
                                        CodiAcFa,
                                        AccionFarmacologica,
                                        Baja,
                                        CodiTiCo,
                                        IdSeccion,
                                        Seccion,
                                        EstablecerPrecio,
                                        ActualizarPrecio,
                                        StockC,
                                        StockF,
                                        CodiLP,
                                        ListaPrecios 
                                FROM vw_articulos
                                WHERE IdArticulo=@IdArticulo"

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand

                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql

                    cmd.Parameters.AddWithValue("@IdArticulo", argIdArticulo)

                    Using datos As MySqlDataReader = cmd.ExecuteReader()

                        If datos.Read() Then

                            Return ArticuloMapper.Map(datos)

                        End If

                    End Using

                End Using

            End Using

            Return Nothing

        Catch ex As Exception

            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerArticuloPorId", ex.Message))

        End Try

    End Function

    Public Function ListarArticulos(ByVal argTextoBuscado As String) As List(Of Articulo)

        Dim objConexionDB As New D_Conexion
        Dim objLA As New List(Of Articulo)

        Try

            Dim sql As String = "SELECT IdArticulo,
                                        Codigo,
                                        CodBarras,
                                        Nombre,
                                        CodiTV,
                                        AlicIVA,
                                        Unidades,
                                        CodiTE,
                                        FechaPrecio,
                                        PrecioCosto,
                                        PrecioVenta,
                                        PrecioOferta,
                                        CodiLabora,
                                        Laboratorio,
                                        CodiMon,
                                        Monodroga,
                                        CodiAcFa,
                                        AccionFarmacologica,
                                        Baja,
                                        CodiTiCo,
                                        IdSeccion,
                                        Seccion,
                                        EstablecerPrecio,
                                        ActualizarPrecio,
                                        StockC,
                                        StockF,
                                        CodiLP,
                                        ListaPrecios 
                                FROM vw_articulos 
                                WHERE Nombre LIKE @Nombre OR Codigo = @Codigo OR CodBarras = @CodBarras 
                                ORDER BY Nombre"

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand

                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql

                    cmd.Parameters.AddWithValue("@Nombre", Replace(UCase(argTextoBuscado), " ", "%") & "%")

                    cmd.Parameters.AddWithValue("@Codigo", argTextoBuscado)

                    cmd.Parameters.AddWithValue("@CodBarras", argTextoBuscado)

                    Using datos As MySqlDataReader = cmd.ExecuteReader()

                        While datos.Read()

                            objLA.Add(ArticuloMapper.Map(datos))

                        End While

                    End Using

                End Using

            End Using

            Return objLA

        Catch ex As Exception

            Throw New Exception(Vecho.MensajeError(Me.ToString, "ListarArticulos", ex.Message))

        End Try

    End Function

    Public Function InsertarArticulo(
                                    ByVal argCodigo As String,
                                    ByVal argCodBarras As String,
                                    ByVal argNombre As String,
                                    ByVal argAlicIVA As Decimal,
                                    ByVal argIdSeccion As String
                                    ) As String

        Try
            Dim objConexionDB As New D_Conexion
            Dim IdArticulo As String

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("sp_insertar_articulo", cn) With {.CommandType = CommandType.StoredProcedure}
                    With cmd.Parameters
                        .Add("_Codigo", MySqlDbType.VarChar).Value = argCodigo
                        .Add("_CodBarras", MySqlDbType.VarChar).Value = argCodBarras
                        .Add("_Nombre", MySqlDbType.VarChar).Value = argNombre
                        .Add("_AlicIVA", MySqlDbType.Decimal).Value = argAlicIVA
                        .Add("_IdSeccion", MySqlDbType.VarChar).Value = argIdSeccion
                        .Add("_IdArticulo", MySqlDbType.VarChar, 10)
                    End With

                    cmd.Parameters("_IdArticulo").Direction = ParameterDirection.Output
                    cmd.ExecuteNonQuery()
                    IdArticulo = cmd.Parameters("_IdArticulo").Value.ToString
                    Return IdArticulo
                End Using

            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarArticulo", Ex.Message))
            Return ""

        End Try

    End Function

    Public Function ActualizarArticulo(
                                        ByVal argIdArticulo As String,
                                        ByVal argCodigo As String,
                                        ByVal argCodBarras As String,
                                        ByVal argNombre As String,
                                        ByVal argAlicIVA As Decimal,
                                        ByVal argBaja As Boolean,
                                        ByVal argIdSeccion As String
                                        ) As Boolean


        Try
            Dim objConexionDB As New D_Conexion

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("sp_actualizar_articulo", cn) With {.CommandType = CommandType.StoredProcedure}
                    With cmd.Parameters
                        .Add("_IdArticulo", MySqlDbType.VarChar).Value = argIdArticulo
                        .Add("_Codigo", MySqlDbType.VarChar).Value = argCodigo
                        .Add("_CodBarras", MySqlDbType.VarChar).Value = argCodBarras
                        .Add("_Nombre", MySqlDbType.VarChar).Value = argNombre
                        .Add("_AlicIVA", MySqlDbType.Decimal).Value = argAlicIVA
                        .Add("_Baja", MySqlDbType.Bit).Value = argBaja
                        .Add("_IdSeccion", MySqlDbType.VarChar).Value = argIdSeccion
                    End With

                    Dim FilasAfectadas As Int32 = Convert.ToInt32(cmd.ExecuteNonQuery())
                    Return (FilasAfectadas > 0) ' Devuelve True si se actualizó al menos una fila

                End Using

            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ActualizarArticulo", Ex.Message))

        End Try

    End Function

    Friend Function ActualizarStock(ByVal argIdOperacion As Long, ByVal argEfectoInventario As Int16, ByVal cn As MySqlConnection, ByVal tx As MySqlTransaction) As Boolean


        Try

            Using cmd As New MySqlCommand("sp_actualizar_stock_c", cn) With {.CommandType = CommandType.StoredProcedure}
                With cmd.Parameters
                    .Add("p_IdOperacion", MySqlDbType.Int64).Value = argIdOperacion
                    .Add("p_EfInv", MySqlDbType.Int16).Value = argEfectoInventario
                End With

                Dim FilasAfectadas As Int32 = Convert.ToInt32(cmd.ExecuteNonQuery())
                Return (FilasAfectadas > 0) ' Devuelve True si se actualizó al menos una fila

            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ActualizarStock", Ex.Message))

        End Try

    End Function



End Class
