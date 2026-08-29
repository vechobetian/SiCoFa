Imports System.Collections.Generic
Imports MySql.Data.MySqlClient
Imports SiCoFa.Entidades
Imports SiCoFa.Entidades.Enums

Public Class D_AdminArticulos

    Public Function ArticuloGenericoExento(ByVal argDescripcion As String) As Articulo

        Dim a As Articulo = Nothing
        Dim la As New List(Of Articulo)
        Dim TipoVenta As New TipoVenta("7")
        Dim TipoControl As New TipoControl("0")
        Dim TamanioEnvase As New TamanioEnvase("0")
        Dim Laboratorio As Laboratorio = New Laboratorio(0, "NO ESTABLECIDO")
        Dim Monodroga As Monodroga = New Monodroga(0, "NO ESTABLECIDA")
        Dim AccionFarmacologica As AccionFarmacologica = New AccionFarmacologica(0, "NO ESTABLECIDA")
        Dim SeccionItem As Seccion = New Seccion("0", "GENERICO 1", True)
        Dim ViaAdministracion As ViaAdministracion = New ViaAdministracion(1, "NO CLASIFICADA")
        Dim TipoPromocion As New TipoPromocion("0")

        a = New Articulo(
                         "0",
                          0,
                          "",
                          "",
                          UCase(argDescripcion.Substring(1)),
                          TipoVenta,
                          0,
                          1,
                          TamanioEnvase,
                          Now.Date,
                          0,
                          0,
                          0,
                          Laboratorio,
                          Monodroga,
                          AccionFarmacologica,
                          0,
                          TipoControl,
                          False,
                          SeccionItem,
                          True,
                          0,
                          0,
                          "",
                          ViaAdministracion,
                          0,
                          TipoPromocion,
                          False,
                          "NO APLICA",
                          1,
                          0,
                          False,
                          0,
                          "",
                          0,
                          0,
                          Nothing
                          )

        Return a
    End Function

    Public Function ArticuloGenericoGravado(ByVal argDescripcion As String) As Articulo

        Dim a As Articulo = Nothing
        Dim la As New List(Of Articulo)
        Dim TipoVenta As New TipoVenta("7")
        Dim TipoControl As New TipoControl("0")
        Dim TamanioEnvase As New TamanioEnvase("0")
        Dim Laboratorio As Laboratorio = New Laboratorio(0, "NO ESTABLECIDO")
        Dim Monodroga As Monodroga = New Monodroga(0, "NO ESTABLECIDA")
        Dim AccionFarmacologica As AccionFarmacologica = New AccionFarmacologica(0, "NO ESTABLECIDA")
        Dim SeccionItem As Seccion = New Seccion("0", "GENERICO 1", True)
        Dim ViaAdministracion As ViaAdministracion = New ViaAdministracion(1, "NO CLASIFICADA")
        Dim TipoPromocion As New TipoPromocion("0")

        a = New Articulo(
                         "0",
                          0,
                          "",
                          "",
                          UCase(argDescripcion.Substring(1)),
                          TipoVenta,
                          21,
                          1,
                          TamanioEnvase,
                          Now.Date,
                          0,
                          0,
                          0,
                          Laboratorio,
                          Monodroga,
                          AccionFarmacologica,
                          0,
                          TipoControl,
                          False,
                          SeccionItem,
                          True,
                          0,
                          0,
                          "",
                          ViaAdministracion,
                          0,
                          TipoPromocion,
                          False,
                          "NO APLICA",
                          1,
                          0,
                          False,
                          0,
                          "",
                          0,
                          0,
                          Nothing
                          )

        Return a
    End Function

    Public Function ObtenerArticuloPorId(ByVal argIdArticulo As String) As Articulo

        Dim objConexionDB As New D_Conexion

        Try

            Dim sql As String = "SELECT IdArticulo,
                                        Codigo,
                                        CodBarras,
                                        NTroquel,
                                        Nombre,
                                        CodiTV,
                                        AlicIVA,
                                        Unidades,
                                        CodiTE,
                                        FechaPrecio,
                                        PrecioCosto,
                                        PrecioVenta,
                                        PrecioOferta,
                                        CodiPro,
                                        CodiLabora,
                                        Laboratorio,
                                        CodiMon,
                                        Monodroga,
                                        CodiAcFa,
                                        AccionFarmacologica,
                                        Baja,
                                        CodiTiCo,
                                        Heladera,
                                        IdSeccion,
                                        Seccion,
                                        EstablecerPrecio,
                                        ActualizarPrecio,
                                        StockC,
                                        StockF,
                                        GTIN,
                                        CodiVia,
                                        ViaAdministracion,
                                        DesOferta,
                                        Fraccionable,
                                        UDiv,
                                        DFrac,
                                        RFrac,
                                        CodiLP,
                                        ListaPrecios,
                                        Gravamen,
                                        CodiFF,
                                        Potencia,
                                        CodiUP,
                                        CodiTU                                        
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

            Throw New Exception(Vecho.MensajeError(Me.ToString, NameOf(ObtenerArticuloPorId), ex.Message))

        End Try

    End Function

    Public Function ListarArticulos(argTextoBuscado As String, Optional argBajas As Boolean = False) As List(Of Articulo)

        Dim objConexionDB As New D_Conexion
        Dim objLA As New List(Of Articulo)

        Try

            Dim sql As String = $"SELECT IdArticulo,
                                        Codigo,
                                        CodBarras,
                                        NTroquel,
                                        Nombre,
                                        CodiTV,
                                        AlicIVA,
                                        Unidades,
                                        CodiTE,
                                        FechaPrecio,
                                        PrecioCosto,
                                        PrecioVenta,
                                        PrecioOferta,
                                        CodiPro,
                                        CodiLabora,
                                        Laboratorio,
                                        CodiMon,
                                        Monodroga,
                                        CodiAcFa,
                                        AccionFarmacologica,
                                        Baja,
                                        CodiTiCo,
                                        Heladera,
                                        IdSeccion,
                                        Seccion,
                                        EstablecerPrecio,
                                        ActualizarPrecio,
                                        StockC,
                                        StockF,
                                        GTIN,
                                        CodiVia,
                                        ViaAdministracion,
                                        DesOferta,
                                        Fraccionable,
                                        UDiv,
                                        DFrac,
                                        RFrac,
                                        CodiLP,
                                        ListaPrecios,
                                        Gravamen,
                                        CodiFF,
                                        Potencia,
                                        CodiUP,
                                        CodiTU                                        
                                FROM vw_articulos
                                WHERE (Nombre LIKE @Nombre OR NTroquel = @NTroquel OR CodBarras = @CodBarras) AND Baja=@Bajas
                                ORDER BY Nombre"

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand

                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql

                    cmd.Parameters.AddWithValue("@Nombre", Replace(UCase(argTextoBuscado), " ", "%") & "%")
                    cmd.Parameters.AddWithValue("@NTroquel", argTextoBuscado)
                    cmd.Parameters.AddWithValue("@CodBarras", argTextoBuscado)
                    cmd.Parameters.AddWithValue("@Bajas", argBajas)

                    Using datos As MySqlDataReader = cmd.ExecuteReader()

                        While datos.Read()

                            objLA.Add(ArticuloMapper.Map(datos))

                        End While

                    End Using

                End Using

            End Using

            Return objLA

        Catch ex As Exception

            Throw New Exception(Vecho.MensajeError(Me.ToString, NameOf(ListarArticulos), ex.Message))

        End Try

    End Function

    Public Function ListarArticulosEquivalentes(ByVal argArticulo As Articulo, Optional argBajas As Boolean = False) As List(Of Articulo)

        Dim objConexionDB As New D_Conexion
        Dim objLA As New List(Of Articulo)

        Try

            Dim sql As String = "SELECT IdArticulo,
                                        Codigo,
                                        CodBarras,
                                        NTroquel,
                                        Nombre,
                                        CodiTV,
                                        AlicIVA,
                                        Unidades,
                                        CodiTE,
                                        FechaPrecio,
                                        PrecioCosto,
                                        PrecioVenta,
                                        PrecioOferta,
                                        CodiPro,
                                        CodiLabora,
                                        Laboratorio,
                                        CodiMon,
                                        Monodroga,
                                        CodiAcFa,
                                        AccionFarmacologica,
                                        Baja,
                                        CodiTiCo,
                                        Heladera,
                                        IdSeccion,
                                        Seccion,
                                        EstablecerPrecio,
                                        ActualizarPrecio,
                                        StockC,
                                        StockF,
                                        GTIN,
                                        CodiVia,
                                        ViaAdministracion,
                                        DesOferta,
                                        Fraccionable,
                                        UDiv,
                                        DFrac,
                                        RFrac,
                                        CodiLP,
                                        ListaPrecios,
                                        Gravamen,
                                        CodiFF,
                                        Potencia,
                                        CodiUP,
                                        CodiTU                                        
                                FROM vw_articulos
                                WHERE CodiMon = @CodiMon AND CodiFF=@CodiFF AND Potencia=@Potencia AND CodiUP=@CodiUP AND CodiTU=@CodiTU AND Baja=@Bajas
                                ORDER BY Nombre"

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand

                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql

                    cmd.Parameters.AddWithValue("@CodiMon", argArticulo.Monodroga.CodiMon)
                    cmd.Parameters.AddWithValue("@CodiFF", argArticulo.CodiFF)
                    cmd.Parameters.AddWithValue("@Potencia", argArticulo.Potencia)
                    cmd.Parameters.AddWithValue("@CodiUP", argArticulo.CodiUP)
                    cmd.Parameters.AddWithValue("@CodiTU", argArticulo.CodiTU)
                    cmd.Parameters.AddWithValue("@Bajas", argBajas)

                    Using datos As MySqlDataReader = cmd.ExecuteReader()

                        While datos.Read()

                            objLA.Add(ArticuloMapper.Map(datos))

                        End While

                    End Using

                End Using

            End Using

            Return objLA

        Catch ex As Exception

            Throw New Exception(Vecho.MensajeError(Me.ToString, NameOf(ListarArticulosCodiAcFa), ex.Message))

        End Try

    End Function

    Public Function ListarArticulosCodiAcFa(ByVal argCodiAcFa As Integer, Optional argBajas As Boolean = False) As List(Of Articulo)

        Dim objConexionDB As New D_Conexion
        Dim objLA As New List(Of Articulo)

        Try

            Dim sql As String = "SELECT IdArticulo,
                                        Codigo,
                                        CodBarras,
                                        NTroquel,
                                        Nombre,
                                        CodiTV,
                                        AlicIVA,
                                        Unidades,
                                        CodiTE,
                                        FechaPrecio,
                                        PrecioCosto,
                                        PrecioVenta,
                                        PrecioOferta,
                                        CodiPro,
                                        CodiLabora,
                                        Laboratorio,
                                        CodiMon,
                                        Monodroga,
                                        CodiAcFa,
                                        AccionFarmacologica,
                                        Baja,
                                        CodiTiCo,
                                        Heladera,
                                        IdSeccion,
                                        Seccion,
                                        EstablecerPrecio,
                                        ActualizarPrecio,
                                        StockC,
                                        StockF,
                                        GTIN,
                                        CodiVia,
                                        ViaAdministracion,
                                        DesOferta,
                                        Fraccionable,
                                        UDiv,
                                        DFrac,
                                        RFrac,
                                        CodiLP,
                                        ListaPrecios,
                                        Gravamen,
                                        CodiFF,
                                        Potencia,
                                        CodiUP,
                                        CodiTU                                        
                                FROM vw_articulos
                                WHERE CodiAcFa = @CodiAcFa AND Baja=@Bajas
                                ORDER BY Nombre"

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand

                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql

                    cmd.Parameters.AddWithValue("@CodiAcFa", argCodiAcFa)
                    cmd.Parameters.AddWithValue("@Bajas", argBajas)

                    Using datos As MySqlDataReader = cmd.ExecuteReader()

                        While datos.Read()

                            objLA.Add(ArticuloMapper.Map(datos))

                        End While

                    End Using

                End Using

            End Using

            Return objLA

        Catch ex As Exception

            Throw New Exception(Vecho.MensajeError(Me.ToString, NameOf(ListarArticulosCodiAcFa), ex.Message))

        End Try

    End Function

    Public Function ListarArticulosCodiMon(ByVal argCodiMon As Integer, Optional argBajas As Boolean = False) As List(Of Articulo)

        Dim objConexionDB As New D_Conexion
        Dim objLA As New List(Of Articulo)

        Try

            Dim sql As String = "SELECT IdArticulo,
                                        Codigo,
                                        CodBarras,
                                        NTroquel,
                                        Nombre,
                                        CodiTV,
                                        AlicIVA,
                                        Unidades,
                                        CodiTE,
                                        FechaPrecio,
                                        PrecioCosto,
                                        PrecioVenta,
                                        PrecioOferta,
                                        CodiPro,
                                        CodiLabora,
                                        Laboratorio,
                                        CodiMon,
                                        Monodroga,
                                        CodiAcFa,
                                        AccionFarmacologica,
                                        Baja,
                                        CodiTiCo,
                                        Heladera,
                                        IdSeccion,
                                        Seccion,
                                        EstablecerPrecio,
                                        ActualizarPrecio,
                                        StockC,
                                        StockF,
                                        GTIN,
                                        CodiVia,
                                        ViaAdministracion,
                                        DesOferta,
                                        Fraccionable,
                                        UDiv,
                                        DFrac,
                                        RFrac,
                                        CodiLP,
                                        ListaPrecios,
                                        Gravamen,
                                        CodiFF,
                                        Potencia,
                                        CodiUP,
                                        CodiTU                                        
                                FROM vw_articulos
                                WHERE CodiMon = @CodiMon AND Baja=@Bajas
                                ORDER BY Nombre"

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As MySqlCommand = cn.CreateCommand

                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql

                    cmd.Parameters.AddWithValue("@CodiMon", argCodiMon)
                    cmd.Parameters.AddWithValue("@Bajas", argBajas)

                    Using datos As MySqlDataReader = cmd.ExecuteReader()

                        While datos.Read()

                            objLA.Add(ArticuloMapper.Map(datos))

                        End While

                    End Using

                End Using

            End Using

            Return objLA

        Catch ex As Exception

            Throw New Exception(Vecho.MensajeError(Me.ToString, NameOf(ListarArticulosCodiMon), ex.Message))

        End Try

    End Function

    Public Function InsertarArticulo(
                                    argNTroquel As String,
                                    argCodBarras As String,
                                    argNombre As String,
                                    argCodiTV As String,
                                    argAlicIVA As Decimal,
                                    argCodiTE As String,
                                    argCodiLabora As Integer,
                                    argCodiMon As Integer,
                                    argCodiAcFa As Integer,
                                    argCodiTiCo As String,
                                    argHeladera As Boolean,
                                    argIdSeccion As String
                                    ) As String

        Try
            Dim objConexionDB As New D_Conexion
            Dim IdArticulo As String

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("sp_insertar_articulo", cn) With {.CommandType = CommandType.StoredProcedure}
                    With cmd.Parameters
                        .Add("p_CodBarras", MySqlDbType.VarChar).Value = argCodBarras
                        .Add("p_NTroquel", MySqlDbType.VarChar).Value = argNTroquel
                        .Add("p_Nombre", MySqlDbType.VarChar).Value = argNombre
                        .Add("p_CodiTV", MySqlDbType.VarChar).Value = argCodiTV
                        .Add("p_AlicIVA", MySqlDbType.Decimal).Value = argAlicIVA
                        .Add("p_CodiTE", MySqlDbType.VarChar).Value = argCodiTE
                        .Add("p_CodiLabora", MySqlDbType.Int32).Value = argCodiLabora
                        .Add("p_CodiMon", MySqlDbType.Int32).Value = argCodiMon
                        .Add("p_CodiAcFa", MySqlDbType.Int32).Value = argCodiAcFa
                        .Add("p_CodiTiCo", MySqlDbType.VarChar).Value = argCodiTiCo
                        .Add("p_Heladera", MySqlDbType.Bit).Value = argHeladera
                        .Add("p_IdSeccion", MySqlDbType.VarChar).Value = argIdSeccion
                        .Add("p_IdArticulo", MySqlDbType.VarChar, 10)
                    End With

                    cmd.Parameters("p_IdArticulo").Direction = ParameterDirection.Output
                    cmd.ExecuteNonQuery()
                    IdArticulo = cmd.Parameters("p_IdArticulo").Value.ToString
                    Return IdArticulo
                End Using

            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, NameOf(InsertarArticulo), Ex.Message))
            Return ""

        End Try

    End Function

    Public Function ActualizarArticulo(
                                        argIdArticulo As String,
                                        argCodBarras As String,
                                        argNTroquel As String,
                                        argNombre As String,
                                        argCodiTV As String,
                                        argAlicIVA As Decimal,
                                        argCodiTE As String,
                                        argCodiLabora As Integer,
                                        argCodiMon As Integer,
                                        argCodiAcFa As Integer,
                                        argCodiTiCo As String,
                                        argHeladera As Boolean,
                                        argBaja As Boolean,
                                        argIdSeccion As String
                                        ) As Boolean


        Try
            Dim objConexionDB As New D_Conexion

            Using cn As MySqlConnection = objConexionDB.ObtenerConexion

                Using cmd As New MySqlCommand("sp_actualizar_articulo", cn) With {.CommandType = CommandType.StoredProcedure}
                    With cmd.Parameters
                        .Add("p_IdArticulo", MySqlDbType.VarChar).Value = argIdArticulo
                        .Add("p_CodBarras", MySqlDbType.VarChar).Value = argCodBarras
                        .Add("p_NTroquel", MySqlDbType.VarChar).Value = argNTroquel
                        .Add("p_Nombre", MySqlDbType.VarChar).Value = argNombre
                        .Add("p_CodiTV", MySqlDbType.VarChar).Value = argCodiTV
                        .Add("p_AlicIVA", MySqlDbType.Decimal).Value = argAlicIVA
                        .Add("p_CodiTE", MySqlDbType.VarChar).Value = argCodiTE
                        .Add("p_CodiLabora", MySqlDbType.VarChar).Value = argCodiLabora
                        .Add("p_CodiMon", MySqlDbType.VarChar).Value = argCodiMon
                        .Add("p_CodiAcFa", MySqlDbType.VarChar).Value = argCodiAcFa
                        .Add("p_CodiTiCo", MySqlDbType.VarChar).Value = argCodiTiCo
                        .Add("p_Heladera", MySqlDbType.Bit).Value = argHeladera
                        .Add("p_Baja", MySqlDbType.Bit).Value = argBaja
                        .Add("p_IdSeccion", MySqlDbType.VarChar).Value = argIdSeccion
                    End With

                    Dim FilasAfectadas As Int32 = Convert.ToInt32(cmd.ExecuteNonQuery())
                    Return (FilasAfectadas > 0) ' Devuelve True si se actualizó al menos una fila

                End Using

            End Using

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, NameOf(ActualizarArticulo), Ex.Message))

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
