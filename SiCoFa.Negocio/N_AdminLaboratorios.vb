Imports SiCoFa.Datos
Imports SiCoFa.Entidades

Public Class N_AdminLaboratorios
    Public Function ListarLaboratorios(ByVal argTextoBuscado As String) As List(Of Laboratorio)
        Dim AdminLaboratorios As New D_AdminLaboratorios
        Dim ls As List(Of Laboratorio)

        ls = AdminLaboratorios.ListarLaboratorios(argTextoBuscado)
        Return ls

    End Function

End Class
