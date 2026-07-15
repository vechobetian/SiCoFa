Imports SiCoFa.Datos
Imports SiCoFa.Entidades

Public Class N_AdminEmpleados

    Public Function ObtenerEmpleadoPorId(ByVal argIdEmpleado As Int32) As Empleado
        Dim AdminEmpleados As New D_AdminEmpleados
        Dim objEmp As Empleado = Nothing

        Try
            objEmp = AdminEmpleados.ObtenerEmpleadoPorId(argIdEmpleado)
            Return objEmp

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerEmpleadoPorId", ex.Message))

        End Try
    End Function

    Public Function ListarEmpleados(ByVal argTextoBuscado As String) As List(Of Empleado)
        Dim AdminEmpleados As New D_AdminEmpleados
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
                                    ByVal argCodiTD As String,
                                    ByVal argNumDoc As String
                                    ) As Integer
        Dim AdminEmpleados As New D_AdminEmpleados
        Dim IdEmpleado As Integer = AdminEmpleados.InsertarEmpleado(
                                                                    UCase(argNombre),
                                                                    UCase(argDomicilio),
                                                                    UCase(argLocalidad),
                                                                    UCase(argProvincia),
                                                                    UCase(argTelefono),
                                                                    UCase(argEmail),
                                                                    UCase(argCodiTD),
                                                                    UCase(argNumDoc)
                                                                    )
        Return IdEmpleado


    End Function
    Public Function ActualizarEmpleado(
                                      ByVal argIdEmpleado As Int32,
                                      ByVal argDomicilio As String,
                                      ByVal argLocalidad As String,
                                      ByVal argProvincia As String,
                                      ByVal argTelefono As String,
                                      ByVal argEmail As String,
                                      ByVal argCodiTD As String,
                                      ByVal argNumDoc As String,
                                      ByVal argEstado As String
                                     ) As Boolean

        Dim AdminEmpleados As New D_AdminEmpleados
        Dim Actualizado As Boolean = AdminEmpleados.ActualizarEmpleado(
                                                                       argIdEmpleado,
                                                                       UCase(argDomicilio),
                                                                       UCase(argLocalidad),
                                                                       UCase(argProvincia),
                                                                       argTelefono,
                                                                       argEmail,
                                                                       argCodiTD,
                                                                       argNumDoc,
                                                                       argEstado
                                                                       )
        Return Actualizado


    End Function
End Class
