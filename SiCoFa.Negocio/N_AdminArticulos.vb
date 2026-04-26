Imports SiCoFa.Datos
Imports SiCoFa.Entidades

Public Class N_AdminArticulos
    Public Function ObtenerArticuloPorId(ByVal argIdArticulo As String) As Articulo
        Dim AdminArticulos As New D_AdminArticulos
        Dim objArt As Articulo
        Try
            objArt = AdminArticulos.ObtenerArticuloPorId(argIdArticulo)
            Return objArt

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ObtenerArticuloPorId", ex.Message))
            Return Nothing

        End Try
    End Function
    Public Function ListarArticulos(ByVal argTextoBuscado As String) As List(Of Articulo)
        Dim AdminArticulos As New D_AdminArticulos
        Dim la As List(Of Articulo)
        Try
            la = AdminArticulos.ListarArticulos(argTextoBuscado)
            Return la

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ListarArticulos", ex.Message))
            Return Nothing

        End Try
    End Function
    Public Function InsertarArticulo(
                                    ByVal argCodigo As String,
                                    ByVal argCodBarras As String,
                                    ByVal argNombre As String,
                                    ByVal argAlicIVA As Decimal,
                                    ByVal argIdSeccion As String
                                    ) As String
        Try

            Dim AdminArticulos As New D_AdminArticulos
            Dim IdArticulo As String = AdminArticulos.InsertarArticulo(
                                                                           UCase(argCodigo),
                                                                           UCase(argCodBarras),
                                                                           UCase(argNombre),
                                                                           argAlicIVA,
                                                                           argIdSeccion
                                                                           )
            Return IdArticulo

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "InsertarArticulo", ex.Message))
            Return ""

        End Try

    End Function
    Public Function ActualizarArticulo(
                                        ByVal argIdArticulo As String,
                                        ByVal argCodigo As String,
                                        ByVal argCodBarras As String,
                                        ByVal argNombre As String,
                                        ByVal argAlicIVA As Decimal,
                                        ByVal argBaja As Boolean,
                                        ByVal argIdSeccion As String
                                        ) As Boolean

        Try

            Dim AdminArticulos As New D_AdminArticulos
            Dim Actualizado As Boolean = AdminArticulos.ActualizarArticulo(
                                                                             argIdArticulo,
                                                                             UCase(argCodigo),
                                                                             UCase(argCodBarras),
                                                                             UCase(argNombre),
                                                                             argAlicIVA,
                                                                             argBaja,
                                                                             argIdSeccion
                                                                             )
            Return Actualizado
        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ActualizarArticulo", ex.Message))
            Return False

        End Try

    End Function

    Public Function ImportarArticulosDesdeArchivo(ByVal argRutaArchivo As String) As String
        Try
            ' 1. Validaciones de Negocio
            If Not System.IO.File.Exists(argRutaArchivo) Then
                Return "Error: No se encontró el archivo en la ruta especificada."
            End If

            Dim info As New System.IO.FileInfo(argRutaArchivo)
            If info.Length = 0 Then
                Return "Error: El archivo seleccionado está vacío."
            End If

            ' 2. Llamada a la Capa de Datos
            Dim AdminArticulos As New D_AdminArticulos

            ' Ejecutamos la importación masiva que definimos en la capa Datos
            Dim Exito As Boolean = AdminArticulos.ImportarArticulosDesdeArchivo(argRutaArchivo)

            If Exito Then
                ' Aquí podrías disparar el SP que procesa los 159 caracteres si fuera necesario
                Return "OK: Se procesaron " & info.Name & " correctamente."
            Else
                Return "Error: Hubo un problema al insertar los registros en la base de datos."
            End If

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "ImportarManualFarmaceutico", ex.Message))
            Return "Error crítico: " & ex.Message
        End Try
    End Function

End Class
