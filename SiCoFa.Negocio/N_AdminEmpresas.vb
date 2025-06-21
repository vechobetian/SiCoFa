Imports SiCoFa.Datos
Imports SiCoFa.Entidades

Public Class N_AdminEmpresas
    Public Function ObtenerEmpresaPorId(ByVal argIdEmpresa As Int32) As Empresa
        Dim AdminEmpresas As New D_AdminEmpresas
        Dim objEmp As Empresa
        Try
            objEmp = AdminEmpresas.ObtenerEmpresaPorId(argIdEmpresa)
            Return objEmp

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerEmpresaPorId", ex.Message))
            Return Nothing

        End Try
    End Function
    Public Function ListarEmpresas(ByVal argTextoBuscado As String) As List(Of Empresa)
        Dim AdminEmpresas As New D_AdminEmpresas
        Dim le As List(Of Empresa)
        Try
            le = AdminEmpresas.ListarEmpresas(argTextoBuscado)
            Return le

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ListarEmpresas", ex.Message))
            Return Nothing

        End Try
    End Function
    Public Function InsertarEmpresa(
                                    ByVal argNombre As String,
                                    ByVal argDomicilio As String,
                                    ByVal argLocalidad As String,
                                    ByVal argProvincia As String,
                                    ByVal argTelefono As String,
                                    ByVal argEmail As String,
                                    ByVal argNumDoc As String,
                                    ByVal argFechaAlta As Date,
                                    ByVal argCodIVA As String,
                                    ByVal argIB As String
                                    ) As Integer
        Try
            Dim AdminEmpresas As New D_AdminEmpresas
            Dim IdEmpresa As Integer = AdminEmpresas.InsertarEmpresa(
                                                                       UCase(argNombre),
                                                                       UCase(argDomicilio),
                                                                       UCase(argLocalidad),
                                                                       UCase(argProvincia),
                                                                       UCase(argTelefono),
                                                                       UCase(argEmail),
                                                                       UCase(argNumDoc),
                                                                       argFechaAlta,
                                                                       UCase(argCodIVA),
                                                                       UCase(argIB)
                                                                       )
            Return IdEmpresa

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarEmpresa", ex.Message))
            Return 0

        End Try

    End Function
    Public Function ActualizarEmpresa(
                                      ByVal argIdCliente As Int32,
                                      ByVal argDomicilio As String,
                                      ByVal argLocalidad As String,
                                      ByVal argProvincia As String,
                                      ByVal argTelefono As String,
                                      ByVal argEmail As String,
                                      ByVal argNumDoc As String,
                                      ByVal argFechaAlta As Date,
                                      ByVal argEstado As String,
                                      ByVal argCodIVA As String,
                                      ByVal argIB As String
                                     ) As Boolean

        Try
            Dim AdminEmpresas As New D_AdminEmpresas
            Dim Actualizado As Boolean = AdminEmpresas.ActualizarEmpresa(
                                                                           argIdCliente,
                                                                           UCase(argDomicilio),
                                                                           UCase(argLocalidad),
                                                                           UCase(argProvincia),
                                                                           argTelefono,
                                                                           argEmail,
                                                                           argNumDoc,
                                                                           argFechaAlta,
                                                                           argEstado,
                                                                           argCodIVA,
                                                                           argIB
                                                                           )
            Return Actualizado
        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ActualizarEmpresa", ex.Message))
            Return False

        End Try

    End Function
End Class
