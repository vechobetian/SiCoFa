Imports SiCoFa.Entidades
Public Interface IValidador

    Function ConsultaRecetasBeneficiario(argReceta As Receta) As ResultadoValidacion

    Function SolicitarAutorizacion(argReceta As Receta) As ResultadoValidacion

End Interface
