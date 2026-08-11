Imports SiCoFa.Entidades

Public Class MISV

    Implements IValidador

    Private Function ConsultaRecetaElectronica(argIdPC As String, argReceta As Receta, argIdMensaje As Long) As Receta Implements IValidador.ConsultaRecetaElectronica
        Throw New NotImplementedException()
    End Function

    Public Function ConsultaRecetasBeneficiario(argIdPC As String, argCredencial As CredencialOS, argPValidacion As ParametrosValidacion, argIdMensaje As Long) As List(Of Receta) Implements IValidador.ConsultaRecetasBeneficiario
        Throw New NotImplementedException()
    End Function

    Public Sub SolicitarAutorizacion(argIdPC As String, argReceta As Receta, argIdMensaje As Long) Implements IValidador.SolicitarAutorizacion
        Throw New NotImplementedException()
    End Sub

    Public Sub CancelarAutorizacion(argIdPC As String, argReceta As Receta, argIdMensaje As Long) Implements IValidador.CancelarAutorizacion
        Throw New NotImplementedException()
    End Sub

End Class
