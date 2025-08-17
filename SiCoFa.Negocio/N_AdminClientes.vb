Imports SiCoFa.Datos
Imports SiCoFa.Entidades

Public Class N_AdminClientes
    Public Function ObtenerClientePorId(ByVal argIdCliente As Int32) As Cliente
        Dim AdminClientes As New D_AdminClientes
        Dim objCli As Cliente
        Try
            objCli = AdminClientes.ObtenerClientePorId(argIdCliente)
            Return objCli

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerClientePorId", ex.Message))
            Return Nothing

        End Try
    End Function

    Public Function ListarClientes(ByVal argTextoBuscado As String) As List(Of Cliente)
        Dim AdminClientes As New D_AdminClientes
        Dim lc As List(Of Cliente)
        Try
            lc = AdminClientes.ListarClientes(argTextoBuscado)
            Return lc

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ListarClientes", ex.Message))
            Return Nothing

        End Try
    End Function

    Public Function InsertarCliente(
                                    ByVal argNombre As String,
                                    ByVal argDomicilio As String,
                                    ByVal argLocalidad As String,
                                    ByVal argProvincia As String,
                                    ByVal argTelefono As String,
                                    ByVal argEmail As String,
                                    ByVal argCodiTDoc As String,
                                    ByVal argNumDoc As String,
                                    ByVal argCodIVA As String
                                    ) As Integer
        Try

            Dim AdminClientes As New D_AdminClientes
            Dim IdCliente As Integer = AdminClientes.InsertarCliente(
                                                                       UCase(argNombre),
                                                                       UCase(argDomicilio),
                                                                       UCase(argLocalidad),
                                                                       UCase(argProvincia),
                                                                       UCase(argTelefono),
                                                                       UCase(argEmail),
                                                                       UCase(argCodiTDoc),
                                                                       UCase(argNumDoc),
                                                                       UCase(argCodIVA)
                                                                       )
            Return IdCliente

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarCliente", ex.Message))
            Return 0

        End Try

    End Function

    Public Function ActualizarCliente(
                                      ByVal argIdCliente As Int32,
                                      ByVal argDomicilio As String,
                                      ByVal argLocalidad As String,
                                      ByVal argProvincia As String,
                                      ByVal argTelefono As String,
                                      ByVal argEmail As String,
                                      ByVal argCodiTDoc As String,
                                      ByVal argNumDoc As String,
                                      ByVal argCodIVA As String,
                                      ByVal argEstado As String
                                     ) As Boolean

        Try
            Dim AdminClientes As New D_AdminClientes
            Dim Actualizado As Boolean = AdminClientes.ActualizarCliente(
                                                                           argIdCliente,
                                                                           UCase(argDomicilio),
                                                                           UCase(argLocalidad),
                                                                           UCase(argProvincia),
                                                                           argTelefono,
                                                                           argEmail,
                                                                           argCodiTDoc,
                                                                           UCase(argNumDoc),
                                                                           argCodIVA,
                                                                           argEstado
                                                                           )
            Return Actualizado
        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ActualizarCliente", ex.Message))
            Return False

        End Try

    End Function

    Public Function ObtenerCuentaCorrientePorIdCliente(ByVal argIdCliente As Int32) As CuentaCorriente
        Dim AdminClientes As New D_AdminClientes
        Dim objCC As CuentaCorriente
        Try
            objCC = AdminClientes.ObtenerCuentaCorrientePorIdCliente(argIdCliente)
            Return objCC

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerCuentaCorrientePorIdCliente", ex.Message))
            Return Nothing

        End Try
    End Function

    Public Function ListarCuentasCorriente(ByVal argTextoBuscado As String) As List(Of CuentaCorriente)
        Dim AdminClientes As New D_AdminClientes
        Dim lc As List(Of CuentaCorriente)

        Try
            lc = AdminClientes.ListarCuentasCorriente(argTextoBuscado)
            Return lc

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ListarCuentasCorriente", ex.Message))
            Return Nothing

        End Try
    End Function

    Public Function InsertarCuentaCorriente(
                                            ByVal argIdCliente As Int32,
                                            ByVal argDescripcion As String,
                                            ByVal argCredito As Decimal,
                                            ByVal argObservaciones As String
                                            ) As Int16
        Try
            Dim AdminClientes As New D_AdminClientes
            Dim IdCC As Int16 = AdminClientes.InsertarCuentaCorriente(argIdCliente,
                                                                            UCase(argDescripcion),
                                                                            argCredito,
                                                                            argObservaciones
                                                                            )
            Return IdCC

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarCuentaCorriente", ex.Message))
            Return 0

        End Try

    End Function

    Public Function ActualizarCuentaCorriente(
                                              ByVal argIdCC As Int32,
                                              ByVal argCredito As Decimal,
                                              ByVal argObservaciones As String,
                                              ByVal argEstado As String
                                              ) As Boolean
        Try
            Dim AdminClientes As New D_AdminClientes
            Dim Actualizado As Boolean = AdminClientes.ActualizarCuentaCorriente(argIdCC,
                                                                                      argCredito,
                                                                                      argObservaciones,
                                                                                      argEstado
                                                                                      )
            Return Actualizado

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ActualizarCuentaCorriente", ex.Message))
            Return 0

        End Try

    End Function
End Class
