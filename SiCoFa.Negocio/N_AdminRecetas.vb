Imports SiCoFa.Datos
Imports SiCoFa.Entidades

Public Class N_AdminRecetas

    Public Function ObtenerDescuento(receta As Receta, articulo As Articulo) As Decimal

        If receta Is Nothing OrElse receta.Plan Is Nothing Then
            Return 0
        End If

        Dim plan As PlanOS = receta.Plan

        Select Case plan.Proceso

            Case 1
                Return Proceso1(plan, articulo)

            Case Else
                Return 0

        End Select

    End Function


    Private Function Proceso1(plan As PlanOS, articulo As Articulo) As Decimal

        Dim codigo As Integer = articulo.Codigo

        If plan.Vademecum1 IsNot Nothing Then
            Dim item = plan.Vademecum1.FirstOrDefault(Function(x) x.Codigo = codigo)

            If item IsNot Nothing Then
                Return plan.DesGeneral1
            End If
        End If

        Return 0

    End Function



End Class