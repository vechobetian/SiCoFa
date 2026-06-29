Imports SiCoFa.Entidades

Public Class UcReceta

    Private mobj_Receta As Receta

    Public Property Receta As Receta
        Get
            Return mobj_Receta
        End Get
        Set(value As Receta)

            mobj_Receta = value
            ActualizarControles()

        End Set
    End Property

    Private Sub ActualizarControles()

        If mobj_Receta Is Nothing Then
            Limpiar()
            Return
        End If

        lblIdReceta.Text = mobj_Receta.IdReceta.ToString()
        lblPlanOS.Text = mobj_Receta.Plan.Descripcion
        lblValidacion.Text = mobj_Receta.Plan.OS.Validador & mobj_Receta.NumAutorizacion
        lblTotalReceta.Text = mobj_Receta.ImporteTotal.ToString("C2")
        lblImporteOS.Text = mobj_Receta.ImporteOS.ToString("C2")
        lblImporteCS.Text = mobj_Receta.ImporteCS.ToString("C2")
        lblImporteAF.Text = mobj_Receta.ImporteAf.ToString("C2")

        Visible = True

    End Sub

    Public Sub Limpiar()

        lblIdReceta.Text = ""
        lblPlanOS.Text = ""
        lblValidacion.Text = ""
        lblTotalReceta.Text = ""
        lblImporteOS.Text = ""
        lblImporteCS.Text = ""
        lblImporteAF.Text = ""

        Visible = False

    End Sub

    Public Sub AplicarColor(color As Color)

        Me.BackColor = color

        lblIdRecetaEtiqueta.BackColor = color
        lblPlanOSEtiqueta.BackColor = color
        lblValidacionEtiqueta.BackColor = color
        lblTotalRecetaEtiqueta.BackColor = color
        lblImporteOSEtiqueta.BackColor = color
        lblImporteCSEtiqueta.BackColor = color
        lblImporteAfEtiqueta.BackColor = color

        lblIdReceta.BackColor = color
        lblPlanOS.BackColor = color
        lblValidacion.BackColor = color
        lblTotalReceta.BackColor = color
        lblImporteOS.BackColor = color
        lblImporteCS.BackColor = color
        lblImporteAF.BackColor = color

    End Sub

End Class
