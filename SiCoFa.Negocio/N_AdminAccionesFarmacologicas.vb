Imports SiCoFa.Datos
Imports SiCoFa.Entidades

Public Class N_AdminAccionesFarmacologicas
    Public Function ListarAccionesFarmacologicas(ByVal argTextoBuscado As String) As List(Of AccionFarmacologica)
        Dim AdminAccionesFarmacologicas As New D_AdminAccionesFarmacologicas
        Dim ls As List(Of AccionFarmacologica)

        ls = AdminAccionesFarmacologicas.ListarAccionesFarmacologicas(argTextoBuscado)
        Return ls

    End Function
End Class
