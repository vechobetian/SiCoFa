Imports SiCoFa.Datos
Imports SiCoFa.Entidades

Public Class N_AdminCuentasBancarias

    Public Function ObtenerCuentaBancariaPorId(ByVal argIdCB As Long) As CuentaBancaria

        Try
            Dim AdminCuentasBancarias As New N_AdminCuentasBancarias
            Dim objCB As CuentaBancaria = AdminCuentasBancarias.ObtenerCuentaBancariaPorId(argIdCB)
            Return objCB

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerCuentaBancariaPorId", ex.Message))

        End Try

    End Function

    Public Function ListarCuentasBancarias(ByVal argTextoBuscado As String) As List(Of CuentaBancaria)

        Try
            Dim AdminCuentasBancarias As New N_AdminCuentasBancarias
            Dim lcb As List(Of CuentaBancaria) = AdminCuentasBancarias.ListarCuentasBancarias(argTextoBuscado)
            Return lcb

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ListarCuentasBancarias", ex.Message))
            Return Nothing

        End Try

    End Function
    Public Function InsertarCuentaBancaria(ByVal argDescripcion As String, ByVal argNumCuenta As String) As Int32

        Try

            Dim AdminCuentasBancarias As New N_AdminCuentasBancarias
            Dim IdCB As Int32 = AdminCuentasBancarias.InsertarCuentaBancaria(argDescripcion, argNumCuenta)
            Return IdCB

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarCuentaBancaria", Ex.Message))

        End Try

    End Function
    Public Function ActualizarCuentaBancaria(ByVal argIdCB As Int32, ByVal argBaja As Boolean) As Boolean

        Try

            Dim AdminCuentasBancarias As New N_AdminCuentasBancarias
            Dim Actualizado As Boolean = AdminCuentasBancarias.ActualizarCuentaBancaria(argIdCB, argBaja)
            Return Actualizado

        Catch Ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ActualizarCuentaBancaria", Ex.Message))

        End Try

    End Function

End Class
