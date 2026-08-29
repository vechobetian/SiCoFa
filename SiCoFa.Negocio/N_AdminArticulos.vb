Imports SiCoFa.Datos
Imports SiCoFa.Entidades

Public Class N_AdminArticulos
    Public Function ArticuloGenericoExento(ByVal argDescripcion As String) As Articulo
        Dim AdminArticulos As New D_AdminArticulos
        Dim objArt As Articulo
        Try
            objArt = AdminArticulos.ArticuloGenericoExento(argDescripcion)
            Return objArt

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ArticuloGenericoExento", ex.Message))
            Return Nothing

        End Try
    End Function

    Public Function ArticuloGenericoGravado(ByVal argDescripcion As String) As Articulo
        Dim AdminArticulos As New D_AdminArticulos
        Dim objArt As Articulo
        Try
            objArt = AdminArticulos.ArticuloGenericoGravado(argDescripcion)
            Return objArt

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ArticuloGenericoExento", ex.Message))
            Return Nothing

        End Try
    End Function

    Public Function ObtenerArticuloPorId(ByVal argIdArticulo As String) As Articulo
        Dim AdminArticulos As New D_AdminArticulos
        Dim objArt As Articulo
        Try
            objArt = AdminArticulos.ObtenerArticuloPorId(argIdArticulo)
            Return objArt

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerArticuloPorId", ex.Message))
            Return Nothing

        End Try
    End Function

    Public Function ListarArticulos(ByVal argTextoBuscado As String) As List(Of Articulo)
        Dim AdminArticulos As New D_AdminArticulos
        Dim la As List(Of Articulo)
        Try
            la = AdminArticulos.ListarArticulos(argTextoBuscado)
            Return la

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ListarArticulos", ex.Message))
            Return Nothing

        End Try
    End Function

    Public Function ListarArticulosEquivalentes(ByVal argArticulo As Articulo) As List(Of Articulo)
        Dim AdminArticulos As New D_AdminArticulos
        Dim la As List(Of Articulo)
        Try
            la = AdminArticulos.ListarArticulosEquivalentes(argArticulo)
            Return la

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ListarArticulosEquivalentes", ex.Message))
            Return Nothing

        End Try
    End Function

    Public Function ListarArticulosCodiAcFa(ByVal argCodiAcFa As Integer) As List(Of Articulo)
        Dim AdminArticulos As New D_AdminArticulos
        Dim la As List(Of Articulo)
        Try
            la = AdminArticulos.ListarArticulosCodiAcFa(argCodiAcFa)
            Return la

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ListarArticulosCodiAcFa", ex.Message))
            Return Nothing

        End Try
    End Function

    Public Function ListarArticulosCodiMon(ByVal argCodiMon As Integer) As List(Of Articulo)
        Dim AdminArticulos As New D_AdminArticulos
        Dim la As List(Of Articulo)
        Try
            la = AdminArticulos.ListarArticulosCodiMon(argCodiMon)
            Return la

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ListarArticulosCodiMon", ex.Message))
            Return Nothing

        End Try
    End Function


    Public Function InsertarArticulo(
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
                                    argIdSeccion As String
                                    ) As String
        Try

            Dim AdminArticulos As New D_AdminArticulos
            Dim IdArticulo As String = AdminArticulos.InsertarArticulo(
                                                                        UCase(argCodBarras),
                                                                        UCase(argNTroquel),
                                                                        UCase(argNombre),
                                                                        argCodiTV,
                                                                        argAlicIVA,
                                                                        argCodiTE,
                                                                        argCodiLabora,
                                                                        argCodiMon,
                                                                        argCodiAcFa,
                                                                        argCodiTiCo,
                                                                        argHeladera,
                                                                        argIdSeccion
                                                                      )
            Return IdArticulo

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarArticulo", ex.Message))
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


        Dim AdminArticulos As New D_AdminArticulos
            Dim Actualizado As Boolean = AdminArticulos.ActualizarArticulo(
                                                                           argIdArticulo,
                                                                           UCase(argCodBarras),
                                                                           UCase(argNTroquel),
                                                                           UCase(argNombre),
                                                                           argCodiTV,
                                                                           argAlicIVA,
                                                                           argCodiTE,
                                                                           argCodiLabora,
                                                                           argCodiMon,
                                                                           argCodiAcFa,
                                                                           argCodiTiCo,
                                                                           argHeladera,
                                                                           argBaja,
                                                                           argIdSeccion
                                                                           )
            Return Actualizado

    End Function



End Class
