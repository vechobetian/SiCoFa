Imports SiCoFa.Datos
Imports SiCoFa.Entidades
Public Class cls_N_AdminConsumoLuz
    Property ListaMedidores As List(Of Medidor)
    Private mobj_D_AdminConsumoLuz As New cls_D_AdminConsumoLuz
    Public Function ObtenerRegConsumoLuzIniciado(ByVal argEstado As String, Optional ByVal argIdMedidor As Integer = 0, Optional ByVal argIdRegistro As Long = 0) As RegConsumoLuz
        Dim r As RegConsumoLuz = mobj_D_AdminConsumoLuz.ObtenerRegConsumoLuzIniciado(argEstado, argIdMedidor, argIdRegistro)
        Return r
    End Function
    Public Function InsertarRegConsumoLuz(
                                         ByVal argIdContrato As Integer,
                                        ByVal argFechaUL As Date,
                                        ByVal argMes As String,
                                        ByVal argAño As String,
                                        ByVal argIdMedidor As Integer,
                                        ByVal argKWLAn As Integer,
                                        ByVal argKWLAc As Integer,
                                        ByVal argObservaciones As String
                                        ) As Long
        Try
            Dim IdRegistro As Long = mobj_D_AdminConsumoLuz.InsertarRegConsumoLuz(argIdContrato, argFechaUL, argMes, argAño, argIdMedidor, argKWLAn, argKWLAc, argObservaciones)
            Return IdRegistro

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarRegistroConsumoLuz", ex.Message))
            Return 0

        End Try

    End Function
    Public Function EliminarRegConsumoLuz(ByVal argIdRegistro As Long) As Integer
        Dim RegistrosAfectados As Integer
        Try
            RegistrosAfectados = mobj_D_AdminConsumoLuz.EliminarRegConsumoLuz(argIdRegistro)
            Return RegistrosAfectados

        Catch Ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "EliminarRegConsumoLuz", Ex.Message))
            Return 0
        End Try

    End Function
    Public Function ActualizarTotalesConsumoLuz(ByVal argIdRegistro As Long) As Boolean
        Dim Actualizado As Boolean = mobj_D_AdminConsumoLuz.ActualizarTotalesConsumoLuz(argIdRegistro)
        Return Actualizado

    End Function
    Public Function ActualizarEstadoRegistroConsumoLuz(ByVal argIdRegistro As Long, ByVal argEstadoNuevo As String) As Integer

        Try
            Dim Actualizado As Boolean = mobj_D_AdminConsumoLuz.ActualizarEstadoRegistroConsumoLuz(argIdRegistro, argEstadoNuevo)
            Return Actualizado

        Catch Ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ActualizarEstadoRegistroConsumoLuz", Ex.Message))
            Return 0
        End Try

    End Function
    Public Function ListarMedidores() As Integer
        Dim NumMed As Integer
        Try
            If Me.ListaMedidores Is Nothing Then
                Dim lm As New List(Of Medidor)
                lm = mobj_D_AdminConsumoLuz.ListarMedidores
                Me.ListaMedidores = lm
                NumMed = lm.Count
            Else
                NumMed = Me.ListaMedidores.Count
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return 0

        End Try

        Return NumMed

    End Function
    Public Function ObtenerMedidoresListado(ByVal argIdMedidor As Integer) As Medidor
        For Each m As Medidor In ListaMedidores
            If m.IdMedidor = argIdMedidor Then
                Return m
                Exit For
            End If
        Next
        Return Nothing
    End Function
    Public Function ObtenerDetConsumoLuz(ByVal argIdRegistro) As List(Of ItemConsumoLuz)

        Try
            Return mobj_D_AdminConsumoLuz.ObtenerDetConsumoLuz(argIdRegistro)
        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ObtenerDetalle", ex.Message))
            Return Nothing
        End Try

    End Function
    Public Function InsertarDetConsumoLuz(
                                                ByVal argIdRegistro As Long,
                                                ByVal argCat As String,
                                                ByVal argKWConsumo As Integer
                                                ) As Integer

        Dim RegistroInsertados As Integer = mobj_D_AdminConsumoLuz.InsertarDetConsumoLuz(argIdRegistro, argCat, argKWConsumo)
        Return RegistroInsertados
    End Function

End Class
