Imports SiCoFa.Entidades
Public Class MISV

    Implements IValidador

    Private Function ConsultaRecetaElectronica(argReceta As Receta, argIdMensaje As Long) As Receta Implements IValidador.ConsultaRecetaElectronica
        Throw New NotImplementedException()
    End Function

    Public Function ConsultaRecetasBeneficiario(argCredencial As CredencialOS, argPValidacion As ParametrosValidacion, argIdMensaje As Long) As List(Of Receta) Implements IValidador.ConsultaRecetasBeneficiario
        Throw New NotImplementedException()
    End Function

    Public Sub SolicitarAutorizacion(argReceta As Receta, argIdMensaje As Long) Implements IValidador.SolicitarAutorizacion
        Throw New NotImplementedException()
    End Sub

    Public Sub CancelarAutorizacion(argReceta As Receta, argIdMensaje As Long) Implements IValidador.CancelarAutorizacion
        Throw New NotImplementedException()
    End Sub

End Class
