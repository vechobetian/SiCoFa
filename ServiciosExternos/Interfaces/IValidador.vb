Imports SiCoFa.Entidades
Public Interface IValidador

    Function ConsultaRecetasBeneficiario(argCredencial As CredencialOS, argPValidacion As ParametrosValidacion, argIdMensaje As Long) As List(Of Receta)

    Function ConsultaRecetaElectronica(argReceta As Receta, argIdMensaje As Long) As Receta

    Sub SolicitarAutorizacion(argReceta As Receta, argIdMensaje As Long)

    Sub CancelarAutorizacion(argReceta As Receta, argIdMensaje As Long)

End Interface
