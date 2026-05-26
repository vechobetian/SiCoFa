Namespace Enums

    Public Enum TipoVenta

        VentaLibre = 1
        VentaBajoReceta = 2
        VentaBajoRecetaArchivada = 3
        VentaBajoRecetaOficial = 4
        Pendiente = 5
        BajoControlMedicoRecomendado = 6
        NoClasificado = 7

    End Enum

    Public Module TipoVentaHelper

        Public Function FromManualDat(valor As String) As TipoVenta

            Select Case valor.Trim()

                Case "1"
                    Return TipoVenta.VentaLibre

                Case "2"
                    Return TipoVenta.VentaBajoReceta

                Case "3"
                    Return TipoVenta.VentaBajoRecetaArchivada

                Case "4"
                    Return TipoVenta.VentaBajoRecetaOficial

                Case "5"
                    Return TipoVenta.Pendiente

                Case "6"
                    Return TipoVenta.BajoControlMedicoRecomendado

                Case "7"
                    Return TipoVenta.NoClasificado

                Case Else
                    Return TipoVenta.NoClasificado

            End Select

        End Function

        Public Function Descripcion(tipo As TipoVenta) As String

            Select Case tipo

                Case TipoVenta.NoClasificado
                    Return "No Clasificado"

                Case TipoVenta.VentaLibre
                    Return "Venta Libre"

                Case TipoVenta.VentaBajoReceta
                    Return "Venta Bajo Receta"

                Case TipoVenta.VentaBajoRecetaArchivada
                    Return "Venta Bajo Receta Archivada"

                Case TipoVenta.VentaBajoRecetaOficial
                    Return "Venta Bajo Receta Oficial"

                Case TipoVenta.Pendiente
                    Return "Pendiente"

                Case TipoVenta.BajoControlMedicoRecomendado
                    Return "Bajo Control Médico Recomendado"

                Case Else
                    Return "Desconocido"

            End Select

        End Function

    End Module

End Namespace