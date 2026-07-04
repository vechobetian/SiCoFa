Imports SiCoFa.Entidades
Public Interface IValidador

    Function ConsultaRecetasBeneficiario(argCredencial As CredencialOS, argPValidacion As ParametrosValidacion, argIdMensaje As Long) As List(Of Receta)

    Function SolicitarAutorizacion(argIdMensaje As Long, argReceta As Receta) As ResultadoValidacion

End Interface
