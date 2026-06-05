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
                    Return "NO CLASIFICADO"

                Case TipoVenta.VentaLibre
                    Return "VENTA LIBRE"

                Case TipoVenta.VentaBajoReceta
                    Return "VENTA BAJO RECETA"

                Case TipoVenta.VentaBajoRecetaArchivada
                    Return "VENTA BAJO RECETA ARCHIVADA"

                Case TipoVenta.VentaBajoRecetaOficial
                    Return "VENTA BAJO RECETA OFICIAL"

                Case TipoVenta.Pendiente
                    Return "PENDIENTE"

                Case TipoVenta.BajoControlMedicoRecomendado
                    Return "BAJO CONTROL MEDICO RECOMENDADO"

                Case Else
                    Return "DESCONOCIDO"

            End Select

        End Function

    End Module

End Namespace