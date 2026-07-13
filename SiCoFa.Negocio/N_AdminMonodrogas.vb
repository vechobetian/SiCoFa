Imports SiCoFa.Datos
Imports SiCoFa.Entidades

Public Class N_AdminMonodrogas
    Public Function ListarMonodrogas(ByVal argTextoBuscado As String) As List(Of Monodroga)
        Dim AdminMonodrogas As New D_AdminMonodrogas
        Dim ls As List(Of Monodroga)

        ls = AdminMonodrogas.ListarMonodrogas(argTextoBuscado)
        Return ls

    End Function
End Class
