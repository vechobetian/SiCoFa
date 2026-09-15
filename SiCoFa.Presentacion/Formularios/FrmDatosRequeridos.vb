Imports SiCoFa.Entidades

Public Class FrmDatosRequeridos

    Private m_PlanOS As PlanOS

    Public Property PlanOS As PlanOS
        Get
            Return m_PlanOS
        End Get
        Set(objeto As PlanOS)
            m_PlanOS = objeto

            If m_PlanOS IsNot Nothing Then
                ' 1. Mostrar la descripción del plan
                Me.lblPlanOS.Text = m_PlanOS.Descripcion

                ' 2. Mapear los CheckBoxes de forma segura (si DatosRequeridos es Nothing, asigna False por defecto)
                Dim req = m_PlanOS.DatosRequeridos

                Me.chkNumRta.Checked = If(req IsNot Nothing, req.NumeroReceta, False)
                Me.chkNumAf.Checked = If(req IsNot Nothing, req.NumeroAfiliado, False)
                Me.chkDocumentoAf.Checked = If(req IsNot Nothing, req.DocumentoAfiliado, False)
                Me.chkPrescriptor.Checked = If(req IsNot Nothing, req.Prescriptor, False)
                Me.chkToken.Checked = If(req IsNot Nothing, req.Token, False)
            End If
        End Set
    End Property

End Class