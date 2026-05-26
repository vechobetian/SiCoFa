Namespace Enums

    Public Enum TamanioEnvase
        NoClasificado = 0
        Menor = 1
        Siguiente = 2
        GrandeDosPresentaciones = 3
        Gigante = 4
        GrandeMasDeDosPresentaciones = 5
        AntibioticoMonodosis = 6
        AntibioticoMultidosis = 7
        SolucionesParenterales = 8
        Hospitatalario = 9
    End Enum

    Public Module TamanioEnvaseHelper

        Public Function FromManualDat(valor As String) As TipoVenta

            Select Case valor.Trim()

                Case "0"
                    Return TamanioEnvase.NoClasificado

                Case "1"
                    Return TamanioEnvase.Menor

                Case "2"
                    Return TamanioEnvase.Siguiente

                Case "3"
                    Return TamanioEnvase.GrandeMasDeDosPresentaciones

                Case "4"
                    Return TamanioEnvase.Gigante

                Case "5"
                    Return TamanioEnvase.GrandeMasDeDosPresentaciones

                Case "6"
                    Return TamanioEnvase.AntibioticoMonodosis

                Case "7"
                    Return TamanioEnvase.AntibioticoMultidosis

                Case "8"
                    Return TamanioEnvase.SolucionesParenterales

                Case "9"
                    Return TamanioEnvase.Hospitatalario

                Case Else
                    Return TipoVenta.NoClasificado

            End Select

        End Function

        Public Function Descripcion(tipo As TamanioEnvase) As String

            Select Case tipo

                Case TamanioEnvase.NoClasificado
                    Return "No Clasificado"

                Case TamanioEnvase.Menor
                    Return "Menor"

                Case TamanioEnvase.Siguiente
                    Return "Siguiente"

                Case TamanioEnvase.GrandeDosPresentaciones
                    Return "Grande de dos Presentaciones"

                Case TamanioEnvase.Gigante
                    Return "Gigante"

                Case TamanioEnvase.GrandeMasDeDosPresentaciones
                    Return "Grande mas de dos Presentaciones"

                Case TamanioEnvase.AntibioticoMonodosis
                    Return "Antibiotico Monodosis"

                Case TamanioEnvase.AntibioticoMultidosis
                    Return "Antibiotico Multidosis"

                Case TamanioEnvase.SolucionesParenterales
                    Return "Soluciones Parenterales"

                Case TamanioEnvase.Hospitatalario
                    Return "Hospitalario"

                Case Else
                    Return "Desconocido"

            End Select

        End Function

    End Module

End Namespace
