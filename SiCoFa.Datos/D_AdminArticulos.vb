Imports MySql.Data.MySqlClient
Imports SiCoFa.Entidades
Imports System.Collections.Generic

Public Class D_AdminArticulos
    Public Function ObtenerArticuloPorId(ByVal argIdArticulo As String) As Articulo
        Dim objConexionDB As New D_Conexion
        Dim objArt As Articulo = Nothing

        Try
            Dim sql As String = "SELECT IdArticulo,Codigo,CodBarras,Nombre,AlicIVA,FechaPrecio,PrecioCosto,PrecioVenta,Baja,IdSeccion,Seccion,EstablecerPrecio,ActualizarPrecio,Stock,CodiLP,ListaPrecios,Fabricante FROM vw_articulos WHERE IdArticulo=@IdArticulo"

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql
                    cmd.Parameters.AddWithValue("@IdArticulo", argIdArticulo)

                    Using datos As MySqlDataReader = cmd.ExecuteReader()

                        If datos.Read Then
                            ' Obtener ordinales de las columnas
                            Dim idArticuloOrdinal As Integer = datos.GetOrdinal("IdArticulo")
                            Dim codigoOrdinal As Integer = datos.GetOrdinal("Codigo")
                            Dim codBarrasOrdinal As Integer = datos.GetOrdinal("CodBarras")
                            Dim nombreOrdinal As Integer = datos.GetOrdinal("Nombre")
                            Dim alicIVAOrdinal As Integer = datos.GetOrdinal("AlicIVA")
                            Dim fechaPrecioOrdinal As Integer = datos.GetOrdinal("FechaPrecio")
                            Dim precioCostoOrdinal As Integer = datos.GetOrdinal("PrecioCosto")
                            Dim precioVentaOrdinal As Integer = datos.GetOrdinal("PrecioVenta")
                            Dim bajaOrdinal As Integer = datos.GetOrdinal("Baja")
                            Dim idSeccionOrdinal As Integer = datos.GetOrdinal("IdSeccion")
                            Dim seccionNombreOrdinal As Integer = datos.GetOrdinal("Seccion")
                            Dim establecerPrecioOrdinal As Integer = datos.GetOrdinal("EstablecerPrecio")
                            Dim actualizarPrecioOrdinal As Integer = datos.GetOrdinal("ActualizarPrecio")
                            Dim stockOrdinal As Integer = datos.GetOrdinal("Stock")
                            Dim codiLPOrdinal As Integer = datos.GetOrdinal("CodiLP")
                            Dim listaPreciosNombreOrdinal As Integer = datos.GetOrdinal("ListaPrecios")
                            Dim fabricanteOrdinal As Integer = datos.GetOrdinal("Fabricante")

                            Dim IdArticuloResult As String = datos.GetString(idArticuloOrdinal)
                            Dim CodigoResult As String = datos.GetString(codigoOrdinal)
                            Dim CodBarrasResult As String = datos.GetString(codBarrasOrdinal)
                            Dim NombreResult As String = datos.GetString(nombreOrdinal)
                            Dim AlicIVA As Decimal = Convert.ToDecimal(datos.GetValue(alicIVAOrdinal))
                            Dim FechaPrecioResult As Date = Convert.ToDateTime(datos.GetValue(fechaPrecioOrdinal))
                            Dim PrecioCostoResult As Decimal = Convert.ToDecimal(datos.GetValue(precioCostoOrdinal))
                            Dim PrecioVentaResult As Decimal = Convert.ToDecimal(datos.GetValue(precioVentaOrdinal))
                            Dim BajaResult As Boolean = datos.GetBoolean(bajaOrdinal)
                            Dim IdSeccionResult As String = datos.GetString(idSeccionOrdinal)
                            Dim SeccionResult As String = datos.GetString(seccionNombreOrdinal)
                            Dim EstablecerPrecioResult As Boolean = datos.GetBoolean(establecerPrecioOrdinal)
                            Dim ActualizarPrecioResult As Boolean = datos.GetBoolean(actualizarPrecioOrdinal)
                            Dim StockResult As Decimal = Convert.ToDecimal(datos.GetValue(stockOrdinal))
                            Dim CodiLPResult As String = datos.GetString(codiLPOrdinal)
                            Dim ListaPreciosResult As String = datos.GetString(listaPreciosNombreOrdinal)
                            Dim FabricanteResult As String = datos.GetString(fabricanteOrdinal)

                            Dim objAlicuotaIVAResult As AlicuotaIVA = New AlicuotaIVA(AlicIVA)
                            Dim objSeccionResult As Seccion = New Seccion(IdSeccionResult, SeccionResult, EstablecerPrecioResult)
                            Dim AdminListaPrecios As New D_AdminListaPrecios
                            Dim objListaPreciosResult As ListaPrecios = AdminListaPrecios.ObtenerListaPreciosPorCodiLP(CodiLPResult)

                            objArt = New Articulo(IdArticuloResult, CodigoResult, CodBarrasResult, NombreResult, objAlicuotaIVAResult, FechaPrecioResult, PrecioCostoResult, PrecioVentaResult, BajaResult, objSeccionResult, ActualizarPrecioResult, StockResult, objListaPreciosResult, FabricanteResult)
                        End If

                    End Using

                End Using

            End Using

            Return objArt

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerArticuloPorId", ex.Message))
            Return Nothing

        End Try

    End Function

    Public Function ListarArticulos(ByVal argTextoBuscado As String) As List(Of Articulo)
        Dim objConexionDB As New D_Conexion
        Dim objLA As New List(Of Articulo)

        Try
            Dim sql As String = "SELECT IdArticulo, Codigo, CodBarras, Nombre, AlicIVA, FechaPrecio, PrecioCosto, PrecioVenta, Baja, IdSeccion, Seccion, EstablecerPrecio, ActualizarPrecio, Stock, CodiLP, ListaPrecios, Fabricante FROM vw_articulos WHERE Nombre LIKE @Nombre OR Codigo = @Codigo OR CodBarras = @CodBarras ORDER BY Nombre"

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql

                    ' Separamos los parámetros para Nombre y CodBarras
                    cmd.Parameters.AddWithValue("@Nombre", Replace(UCase(argTextoBuscado), " ", "%") & "%")
                    cmd.Parameters.AddWithValue("@Codigo", argTextoBuscado)
                    cmd.Parameters.AddWithValue("@CodBarras", argTextoBuscado)

                    Using datos As MySqlDataReader = cmd.ExecuteReader()
                        Dim idArticuloOrdinal As Integer = datos.GetOrdinal("IdArticulo")
                        Dim codigoOrdinal As Integer = datos.GetOrdinal("Codigo")
                        Dim codBarrasOrdinal As Integer = datos.GetOrdinal("CodBarras")
                        Dim nombreOrdinal As Integer = datos.GetOrdinal("Nombre")
                        Dim alicIVAOrdinal As Integer = datos.GetOrdinal("AlicIVA")
                        Dim fechaPrecioOrdinal As Integer = datos.GetOrdinal("FechaPrecio")
                        Dim precioCostoOrdinal As Integer = datos.GetOrdinal("PrecioCosto")
                        Dim precioVentaOrdinal As Integer = datos.GetOrdinal("PrecioVenta")
                        Dim bajaOrdinal As Integer = datos.GetOrdinal("Baja")
                        Dim idSeccionOrdinal As Integer = datos.GetOrdinal("IdSeccion")
                        Dim seccionNombreOrdinal As Integer = datos.GetOrdinal("Seccion")
                        Dim establecerPrecioOrdinal As Integer = datos.GetOrdinal("EstablecerPrecio")
                        Dim actualizarPrecioOrdinal As Integer = datos.GetOrdinal("ActualizarPrecio")
                        Dim stockOrdinal As Integer = datos.GetOrdinal("Stock")
                        Dim codiLPOrdinal As Integer = datos.GetOrdinal("CodiLP")
                        Dim listaPreciosNombreOrdinal As Integer = datos.GetOrdinal("ListaPrecios")
                        Dim fabricanteOrdinal As Integer = datos.GetOrdinal("Fabricante")

                        While datos.Read
                            ' Manejo explícito de DBNull y conversión a tipos de datos .NET
                            Dim IdArticuloResult As String = datos.GetString(idArticuloOrdinal)
                            Dim CodigoResult As String = datos.GetString(codigoOrdinal)
                            Dim CodBarrasResult As String = datos.GetString(codBarrasOrdinal)
                            Dim NombreResult As String = datos.GetString(nombreOrdinal)
                            Dim AlicIVA As Decimal = If(datos.IsDBNull(alicIVAOrdinal), 0.0, Convert.ToDecimal(datos.GetValue(alicIVAOrdinal)))
                            Dim FechaPrecioResult As Date = If(datos.IsDBNull(fechaPrecioOrdinal), Date.MinValue, Convert.ToDateTime(datos.GetValue(fechaPrecioOrdinal)))
                            Dim PrecioCostoResult As Decimal = If(datos.IsDBNull(precioCostoOrdinal), 0, Convert.ToDecimal(datos.GetValue(precioCostoOrdinal)))
                            Dim PrecioVentaResult As Decimal = If(datos.IsDBNull(precioVentaOrdinal), 0, Convert.ToDecimal(datos.GetValue(precioVentaOrdinal)))
                            Dim BajaResult As Boolean = datos.GetBoolean(bajaOrdinal)
                            Dim IdSeccionResult As String = datos.GetString(idSeccionOrdinal)
                            Dim SeccionResult As String = datos.GetString(seccionNombreOrdinal)
                            Dim EstablecerPrecioResult As Boolean = datos.GetBoolean(establecerPrecioOrdinal)
                            Dim ActualizarPrecioResult As Boolean = datos.GetBoolean(actualizarPrecioOrdinal)
                            Dim StockResult As Decimal = If(datos.IsDBNull(stockOrdinal), 0, Convert.ToDecimal(datos.GetValue(stockOrdinal)))
                            Dim CodiLPResult As String = datos.GetString(codiLPOrdinal)
                            Dim ListaPreciosResult As String = datos.GetString(listaPreciosNombreOrdinal)
                            Dim FabricanteResult As String = datos.GetString(fabricanteOrdinal)

                            ' Crear objetos anidados
                            Dim objAlicuotaIVAResult As AlicuotaIVA = New AlicuotaIVA(AlicIVA)
                            Dim objSeccionResult As Seccion = New Seccion(IdSeccionResult, SeccionResult, EstablecerPrecioResult)
                            Dim AdminListaPrecios As New D_AdminListaPrecios
                            Dim objListaPreciosResult As ListaPrecios = AdminListaPrecios.ObtenerListaPreciosPorCodiLP(CodiLPResult)

                            Dim objArt = New Articulo(IdArticuloResult, CodigoResult, CodBarrasResult, NombreResult, objAlicuotaIVAResult, FechaPrecioResult, PrecioCostoResult, PrecioVentaResult, BajaResult, objSeccionResult, ActualizarPrecioResult, StockResult, objListaPreciosResult, FabricanteResult)
                            objLA.Add(objArt)
                        End While
                    End Using
                End Using
            End Using

            Return objLA

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ListarArticulos", ex.Message))
            Return New List(Of Articulo)

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

            Using cmd As New MySqlCommand("sp_actualizar_stock", cn) With {.CommandType = CommandType.StoredProcedure}
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
