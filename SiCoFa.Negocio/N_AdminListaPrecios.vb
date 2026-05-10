Imports System.Data.SqlClient
Imports SiCoFa.Datos
Imports SiCoFa.Entidades

Public Class N_AdminListaPrecios
    Public Function ObtenerListaPreciosPorCodiLP(ByVal argCodiLP As String) As ListaPrecios
        Dim AdminListaPrecios As New D_AdminListaPrecios
        Dim objLP As ListaPrecios
        Try
            objLP = AdminListaPrecios.ObtenerListaPreciosPorCodiLP(argCodiLP)
            Return objLP

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerListaPreciosPorCodiLP", ex.Message))
            Return Nothing

        End Try

    End Function

    Public Function ObtenerListasPreciosActivas() As List(Of ListaPrecios)

        Try

            Dim adminListaPrecios As New D_AdminListaPrecios

            Return adminListaPrecios.ObtenerListasPreciosActivas()

        Catch ex As Exception

            Throw New Exception(
            Vecho.MensajeError(Me.ToString, NameOf(ObtenerListasPreciosActivas), ex.Message))
        End Try

    End Function

End Class
