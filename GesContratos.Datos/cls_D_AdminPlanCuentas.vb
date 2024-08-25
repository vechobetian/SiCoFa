Imports MySql.Data.MySqlClient
Imports SiCoFa.Entidades
Imports System.Collections.Generic
Public Class cls_D_AdminPlanCuentas
    Public Function Rubros() As List(Of RubroContabilidad)
        Dim lr As New List(Of RubroContabilidad)
        Dim rb As RubroContabilidad

        Try
            Dim sql As String = "SELECT CodiRub,NombreRub FROM TblRubros ORDER BY CodiRub"

            Dim cmd As MySqlCommand = Mod_D_Admin.ConexionDB.Conexion.CreateCommand
            cmd.CommandType = CommandType.Text
            cmd.CommandText = sql
            Dim datos As MySqlDataReader = cmd.ExecuteReader()
            While datos.Read()
                rb = New RubroContabilidad(datos("CodiRub"), datos("NombreRub"))
                lr.Add(rb)
            End While
            datos.Close()
            datos.DisposeAsync()
            Return lr

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "Rubros", ex.Message))
            Return Nothing
        End Try

    End Function
    Public Function SubRubros(ByVal argCodiRub As String) As List(Of SubRubroContabilidad)
        Dim lsr As New List(Of SubRubroContabilidad)
        Dim srb As SubRubroContabilidad

        Try
            Dim sql As String = "SELECT CodiSubRub,CodiRub,NombreSubRubro FROM TblSubRubros WHERE CodiRub='" & argCodiRub & "' ORDER BY CodiSubRub"
            Dim cmd As MySqlCommand = Mod_D_Admin.ConexionDB.Conexion.CreateCommand
            cmd.CommandType = CommandType.Text
            cmd.CommandText = sql
            Dim datos As MySqlDataReader = cmd.ExecuteReader()
            While datos.Read()
                srb = New SubRubroContabilidad(datos("CodiSubRub"), datos("CodiRub"), datos("NombreSubRubro"))
                lsr.Add(srb)
            End While

            datos.Close()
            datos.DisposeAsync()
            Return lsr

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "SubRubros", ex.Message))
            Return Nothing

        End Try

    End Function
    Public Function CuentasColectivas(ByVal argCodiSubRub As String) As List(Of CuentaColectiva)
        Dim lcc As New List(Of CuentaColectiva)
        Dim cc As CuentaColectiva

        Try
            Dim sql As String = "SELECT CodiCtaCol,CodiSubRub,NombreCtaCol FROM TblCtasColectivas WHERE CodiSubRub='" & argCodiSubRub & "' ORDER BY CodiCtaCol"
            Dim cmd As MySqlCommand = Mod_D_Admin.ConexionDB.Conexion.CreateCommand
            cmd.CommandType = CommandType.Text
            cmd.CommandText = sql
            Dim datos As MySqlDataReader = cmd.ExecuteReader()
            While datos.Read()
                cc = New CuentaColectiva(datos("CodiCtaCol"), datos("CodiSubRub"), datos("NombreCtaCol"))
                lcc.Add(cc)
            End While
            datos.Close()
            datos.DisposeAsync()
            Return lcc

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "CuentasColectivas", ex.Message))
            Return Nothing

        End Try

    End Function
    Public Function CuentasImputables(ByVal argCodiCtaCol As String) As List(Of CuentaImputable)
        Dim lci As New List(Of CuentaImputable)
        Dim ci As CuentaImputable

        Try
            Dim sql As String = "SELECT CodiCta,CodiCtaCol,NombreCta FROM TblCtasImputables WHERE CodiCtaCol='" & argCodiCtaCol & "' ORDER BY CodiCta"
            Dim cmd As MySqlCommand = Mod_D_Admin.ConexionDB.Conexion.CreateCommand
            cmd.CommandType = CommandType.Text
            cmd.CommandText = sql
            Dim datos As MySqlDataReader = cmd.ExecuteReader()
            While datos.Read()
                ci = New CuentaImputable(datos("CodiCta"), datos("CodiCtaCol"), datos("NombreCta"))
                lci.Add(ci)
            End While
            datos.Close()
            datos.DisposeAsync()
            Return lci

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "CuentasImputables", ex.Message))
            Return Nothing

        End Try

    End Function

End Class
