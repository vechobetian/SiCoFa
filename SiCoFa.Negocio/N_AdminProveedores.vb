Imports SiCoFa.Datos
Imports SiCoFa.Entidades

Public Class N_AdminProveedores
    Public Function ObtenerProveedorPorId(ByVal argIdProveedor As Int32) As Proveedor
        Dim AdminProveedores As New D_AdminProveedores
        Dim objProv As Proveedor
        Try
            objProv = AdminProveedores.ObtenerProveedorPorId(argIdProveedor)
            Return objProv

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerProveedorPorId", ex.Message))
            Return Nothing

        End Try
    End Function
    Public Function ListarProveedores(ByVal argTextoBuscado As String) As List(Of Proveedor)

        Dim AdminProveedores As New D_AdminProveedores
        Dim lp As List(Of Proveedor)
        Try
            lp = AdminProveedores.ListarProveedores(argTextoBuscado)
            Return lp

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ListarProveedores", ex.Message))
            Return Nothing

        End Try
    End Function
    Public Function InsertarProveedor(
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

            Dim AdminProveedores As New D_AdminProveedores
            Dim IdProveedor As Integer = AdminProveedores.InsertarProveedor(
                                                                           UCase(argNombre),
                                                                           UCase(argDomicilio),
                                                                           UCase(argLocalidad),
                                                                           UCase(argProvincia),
                                                                           UCase(argTelefono),
                                                                           UCase(argEmail),
                                                                           UCase(argCodiTDoc),
                                                                           UCase(argNumDoc)
                                                                           )
            Return IdProveedor

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarProveedor", ex.Message))
            Return 0

        End Try

    End Function
    Public Function ActualizarProveedor(
                                      ByVal argIdProveedor As Int32,
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

            Dim AdminProveedores As New D_AdminProveedores
            Dim Actualizado As Boolean = AdminProveedores.ActualizarProveedor(
                                                                               argIdProveedor,
                                                                               UCase(argDomicilio),
                                                                               UCase(argLocalidad),
                                                                               UCase(argProvincia),
                                                                               argTelefono,
                                                                               argEmail,
                                                                               argCodiTDoc,
                                                                               argNumDoc,
                                                                               argCodIVA,
                                                                               argEstado
                                                                               )
            Return Actualizado

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ActualizarProveedor", ex.Message))
            Return False

        End Try

    End Function
End Class
