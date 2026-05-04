Imports SiCoFa.Datos

Public Class N_AdminDB

    Dim mobj_D_AdminDB As New D_AdminDB

    Public Function ObtenerTabla(ByVal argSql As String, Optional ByVal argDataBase As String = "FARMACIAS") As DataTable

        Try

            Dim tbl As DataTable = mobj_D_AdminDB.ObtenerTabla(argSql, argDataBase)
            Return tbl

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerTabla", ex.Message))
            Return Nothing
        End Try

    End Function

    Public Sub ActualizarTabla(ByVal argSql As String, ByVal argTbl As DataTable, Optional ByVal argDataBase As String = "FARMACIAS")

        Try

            mobj_D_AdminDB.ActualizarTabla(argSql, argTbl, argDataBase)

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ActualizarTabla", ex.Message))
        End Try

    End Sub

    Public Function ObtenerValor(ByVal argSql As String, Optional ByVal argDataBase As String = "FARMACIAS") As Object

        Try

            Return mobj_D_AdminDB.ObtenerValor(argSql, argDataBase)

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerValor", ex.Message))

        End Try

    End Function

    Public Function ObtenerRegistro(ByVal argSql As String, Optional ByVal argDataBase As String = "FARMACIAS") As Dictionary(Of String, Object)

        Try

            Return mobj_D_AdminDB.ObtenerRegistro(argSql, argDataBase)

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerValor", ex.Message))

        End Try

    End Function

    Public Sub InsertarRegistro(ByVal argSql As String, ByVal argValoresColumnas As Dictionary(Of String, Object), Optional ByVal argDataBase As String = "FARMACIAS")

        Try

            mobj_D_AdminDB.InsertarRegistro(argSql, argValoresColumnas, argDataBase)

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarRegistros", ex.Message))

        End Try

    End Sub

    Public Function CuentaRegistros(ByVal argSql As String, Optional ByVal argDataBase As String = "FARMACIAS") As Integer

        Try

            Dim cantidad As Integer = mobj_D_AdminDB.CuentaRegistros(argSql, argDataBase)
            Return cantidad

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "CuentaRegistros", ex.Message))

        End Try

    End Function

    Public Function EliminarRegistros(ByVal argSql As String, Optional ByVal argDataBase As String = "FARMACIAS") As Integer

        Try
            Dim FilasAfectadas As Integer = mobj_D_AdminDB.EliminarRegistros(argSql, argDataBase)
            Return FilasAfectadas

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "EliminarRegistros", ex.Message))
        End Try

    End Function

    Public Function ActualizarCampo(ByVal argTabla As String, ByVal argCampo As String, ByVal argValor As Object, ByVal argCondicion As String, Optional ByVal argDataBase As String = "FARMACIAS") As Integer

        Try
            Dim FilasAfectadas As Integer = mobj_D_AdminDB.ActualizarCampo(argTabla, argCampo, argValor, argCondicion, argDataBase)
            Return FilasAfectadas

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ActualizarCampo", ex.Message))
        End Try

    End Function

End Class
