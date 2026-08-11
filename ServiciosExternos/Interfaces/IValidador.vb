Imports SiCoFa.Entidades
Public Interface IValidador

    Function ConsultaRecetasBeneficiario(argIdPC As String, argCredencial As CredencialOS, argPValidacion As ParametrosValidacion, argIdMensaje As Long) As List(Of Receta)

    Function ConsultaRecetaElectronica(argIdPC As String, argReceta As Receta, argIdMensaje As Long) As Receta

    Sub SolicitarAutorizacion(argIdPC As String, argReceta As Receta, argIdMensaje As Long)

    Sub CancelarAutorizacion(argIdPC As String, argReceta As Receta, argIdMensaje As Long)

End Interface
