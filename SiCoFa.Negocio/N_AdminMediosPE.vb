Imports SiCoFa.Datos
Imports SiCoFa.Entidades

Public Class N_AdminMediosPE

    Public Function ObtenerMedioPEPorId(ByVal argIdMPE As Long) As MedioPE

        Try
            Dim AdminMediosPE As New D_AdminMediosPE
            Dim objMPE As MedioPE = AdminMediosPE.ObtenerMedioPEPorId(argIdMPE)
            Return objMPE

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerMedioPEPorId", ex.Message))

        End Try

    End Function

    Public Function ListarMedioPE(ByVal argTextoBuscado As String) As List(Of MedioPE)

        Try
            Dim AdminMediosPE As New D_AdminMediosPE
            Dim lmpe As List(Of MedioPE) = AdminMediosPE.ListarMedioPE(argTextoBuscado)
            Return lmpe

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ListarMediosPE", ex.Message))
            Return Nothing

        End Try

    End Function

    Public Function InsertarMedioPE(ByVal argDescripcion As String, ByVal argIdCB As Int32) As String

        Try
            Dim AdminMediosPE As New D_AdminMediosPE
            Dim IdMPE As String = AdminMediosPE.InsertarMedioPE(argDescripcion, argIdCB)
            Return IdMPE

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarMedioPE", Ex.Message))

        End Try

    End Function
    Public Function ActualizarMedioPE(ByVal argIdMPE As String, ByVal argIdCB As Int32, ByVal argBaja As Boolean) As Boolean

        Try
            Dim AdminMediosPE As New D_AdminMediosPE
            Dim Actualizado As Boolean = AdminMediosPE.ActualizarMedioPE(argIdMPE, argIdCB, argBaja)
            Return Actualizado

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ActualizarMedioPE", Ex.Message))

        End Try

    End Function

End Class
