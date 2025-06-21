Imports SiCoFa.Negocio
Imports SiCoFa.Entidades

Public Class N_AdminEmpleados

    Public Function ObtenerEmpleadoPorId(ByVal argIdEmpleado As Int32) As Empleado
        Dim AdminEmpleados As New N_AdminEmpleados
        Dim objEmp As Empleado = Nothing

        Try
            objEmp = AdminEmpleados.ObtenerEmpleadoPorId(argIdEmpleado)
            Return objEmp

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerEmpleadoPorId", ex.Message))

        End Try
    End Function
    Public Function ListarEmpleados(ByVal argTextoBuscado As String) As List(Of Empleado)
        Dim AdminEmpleados As New N_AdminEmpleados
        Dim le As List(Of Empleado) = Nothing

        Try
            le = AdminEmpleados.ListarEmpleados(argTextoBuscado)
            Return le

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ListarEmpleados", ex.Message))

        End Try
    End Function
    Public Function InsertarEmpleado(
                                    ByVal argNombre As String,
                                    ByVal argDomicilio As String,
                                    ByVal argLocalidad As String,
                                    ByVal argProvincia As String,
                                    ByVal argTelefono As String,
                                    ByVal argEmail As String,
                                    ByVal argCodiTDoc As String,
                                    ByVal argNumDoc As String
                                    ) As Integer
        Try
            Dim AdminEmpleados As New N_AdminEmpleados
            Dim IdEmpleado As Integer = AdminEmpleados.InsertarEmpleado(
                                                                           UCase(argNombre),
                                                                           UCase(argDomicilio),
                                                                           UCase(argLocalidad),
                                                                           UCase(argProvincia),
                                                                           UCase(argTelefono),
                                                                           UCase(argEmail),
                                                                           UCase(argCodiTDoc),
                                                                           UCase(argNumDoc)
                                                                           )
            Return IdEmpleado

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarEmpleado", ex.Message))

        End Try

    End Function
    Public Function ActualizarEmpleado(
                                      ByVal argIdEmpleado As Int32,
                                      ByVal argDomicilio As String,
                                      ByVal argLocalidad As String,
                                      ByVal argProvincia As String,
                                      ByVal argTelefono As String,
                                      ByVal argEmail As String,
                                      ByVal argCodiTDoc As String,
                                      ByVal argNumDoc As String,
                                      ByVal argEstado As String
                                     ) As Boolean

        Try
            Dim AdminEmpleados As New N_AdminEmpleados
            Dim Actualizado As Boolean = AdminEmpleados.ActualizarEmpleado(
                                                                               argIdEmpleado,
                                                                               UCase(argDomicilio),
                                                                               UCase(argLocalidad),
                                                                               UCase(argProvincia),
                                                                               argTelefono,
                                                                               argEmail,
                                                                               argCodiTDoc,
                                                                               argNumDoc,
                                                                               argEstado
                                                                               )
            Return Actualizado

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ActualizarEmpleado", ex.Message))

        End Try

    End Function
End Class
