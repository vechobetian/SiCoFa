Imports SiCoFa.Entidades
Public Interface IValidador

    Function ConsultaRecetasBeneficiario(argIdMensaje As Long, argReceta As Receta) As ResultadoValidacion

    Function SolicitarAutorizacion(argIdMensaje As Long, argReceta As Receta) As ResultadoValidacion

End Interface
