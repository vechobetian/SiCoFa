Imports SiCoFa.Negocio
Imports SiCoFa.Entidades

Public Class FrmDatosRequeridos

    Private m_PlanOS As PlanOS
    Private m_Cargando As Boolean = False


    Public Property PlanOS As PlanOS

        Get
            Return m_PlanOS
        End Get

        Set(objeto As PlanOS)

            m_PlanOS = objeto

            If m_PlanOS Is Nothing Then
                Return
            End If

            Try

                ' Evitar que los CheckedChanged actualicen la BD
                ' mientras estamos cargando los datos.
                m_Cargando = True

                '--------------------------------------------------
                ' Mostrar descripción del plan
                '--------------------------------------------------

                Me.lblPlanOS.Text = m_PlanOS.Descripcion


                '--------------------------------------------------
                ' Cargar los datos requeridos
                '--------------------------------------------------

                Dim req = m_PlanOS.DatosRequeridos

                If req Is Nothing Then

                    Me.chkNumRta.Checked = False
                    Me.chkNumAf.Checked = False
                    Me.chkDocumentoAf.Checked = False
                    Me.chkPrescriptor.Checked = False
                    Me.chkToken.Checked = False

                Else

                    Me.chkNumRta.Checked = req.NumeroReceta
                    Me.chkNumAf.Checked = req.NumeroAfiliado
                    Me.chkDocumentoAf.Checked = req.DocumentoAfiliado
                    Me.chkPrescriptor.Checked = req.Prescriptor
                    Me.chkToken.Checked = req.Token

                End If

            Finally

                ' A partir de este momento los cambios del usuario
                ' sí deben actualizar la BD.
                m_Cargando = False

            End Try

        End Set

    End Property


    '==============================================================
    ' CHECKBOX NUMERO DE RECETA
    '==============================================================

    Private Sub chkNumRta_CheckedChanged(sender As Object, e As EventArgs) Handles chkNumRta.CheckedChanged

        If m_Cargando Then Return

        ActualizarDatoRequerido("NumRta", chkNumRta.Checked)

    End Sub


    '==============================================================
    ' CHECKBOX NUMERO DE AFILIADO
    '==============================================================

    Private Sub chkNumAf_CheckedChanged(sender As Object, e As EventArgs) Handles chkNumAf.CheckedChanged

        If m_Cargando Then Return

        ActualizarDatoRequerido("NumAf", chkNumAf.Checked)

    End Sub


    '==============================================================
    ' CHECKBOX DOCUMENTO DEL AFILIADO
    '==============================================================

    Private Sub chkDocumentoAf_CheckedChanged(sender As Object, e As EventArgs) Handles chkDocumentoAf.CheckedChanged

        If m_Cargando Then Return

        ActualizarDatoRequerido("DocumentoAf", chkDocumentoAf.Checked)

    End Sub


    '==============================================================
    ' CHECKBOX PRESCRIPTOR
    '==============================================================

    Private Sub chkPrescriptor_CheckedChanged(sender As Object, e As EventArgs) Handles chkPrescriptor.CheckedChanged

        If m_Cargando Then Return

        ActualizarDatoRequerido("Prescriptor", chkPrescriptor.Checked)

    End Sub


    '==============================================================
    ' CHECKBOX TOKEN
    '==============================================================

    Private Sub chkToken_CheckedChanged(sender As Object, e As EventArgs) Handles chkToken.CheckedChanged

        If m_Cargando Then Return

        ActualizarDatoRequerido("Token", chkToken.Checked)

    End Sub


    '==============================================================
    ' ACTUALIZAR DATO REQUERIDO
    '==============================================================

    Private Sub ActualizarDatoRequerido(argCampo As String, argValor As Boolean)

        If m_PlanOS Is Nothing Then Return

        If m_PlanOS.DatosRequeridos Is Nothing Then Return


        '----------------------------------------------------------
        ' 1. Actualizar el objeto DatosRequeridos
        '----------------------------------------------------------

        Select Case argCampo

            Case "NumRta"

                m_PlanOS.DatosRequeridos.NumeroReceta = argValor


            Case "NumAf"

                m_PlanOS.DatosRequeridos.NumeroAfiliado = argValor


            Case "DocumentoAf"

                m_PlanOS.DatosRequeridos.DocumentoAfiliado = argValor


            Case "Prescriptor"

                m_PlanOS.DatosRequeridos.Prescriptor = argValor


            Case "Token"

                m_PlanOS.DatosRequeridos.Token = argValor

        End Select


        '----------------------------------------------------------
        ' 2. Convertir Boolean a 0/1 para MariaDB BIT(1)
        '----------------------------------------------------------

        Dim valorBD As Integer = If(argValor, 1, 0)


        '----------------------------------------------------------
        ' 3. Actualizar la base de datos
        '----------------------------------------------------------

        Dim adminDB As New N_AdminDB
        adminDB.ActualizarCampo("datos_requeridos", argCampo, valorBD, $"IdPlan = {m_PlanOS.IdPlan}")

    End Sub

End Class
