Namespace Enums
    Public Enum TipoVenta
        NoClasificado = 0
        VentaLibre = 1
        VentaBajoReceta = 2
        VentaBajorRecetaArchivada = 3
        VentaBajoRecetaOficial = 4
        Pendiente = 5
        BajoControlMedicoRecomendado = 6
    End Enum

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

    Public Enum TipoControl
        NoControlado = 0
        PsicotropicoListaII = 2
        PsicotropicoListaIII = 3
        PsicotropicoListaIV = 4
        EstupefacienteListaI = 6
        EstupefacienteListaII = 7
        EstupefacienteListaIII = 8
        Succinilcolina = 9
        VentaVigilada = 99
    End Enum

End Namespace

