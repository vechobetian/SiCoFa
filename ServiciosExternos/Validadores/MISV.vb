Imports SiCoFa.Entidades
Public Class MISV

    Implements IValidador

    Public Function SolicitarAutorizacion(argIdMensaje As Long, argReceta As Receta) As ResultadoValidacion Implements IValidador.SolicitarAutorizacion
        Throw New NotImplementedException()
    End Function

    Public Function ConsultaRecetasBeneficiario(argCredencial As CredencialOS, argPValidacion As ParametrosValidacion, argIdMensaje As Long) As List(Of Receta) Implements IValidador.ConsultaRecetasBeneficiario
        Throw New NotImplementedException()
    End Function
End Class
