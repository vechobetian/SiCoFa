Imports SiCoFa.Negocio
Imports SiCoFa.Entidades

Public Class FrmSelectorPlanesOS

    Private m_PlanSeleccionado As PlanOS

    Public ReadOnly Property PlanSeleccionado As PlanOS
        Get
            Return m_PlanSeleccionado
        End Get
    End Property

    Private Sub CargarSelectorPlanesOS()

        Try

            Dim adminDB As New N_AdminDB

            Dim sql As String = "SELECT IdPlan, Descripcion FROM planes_os"

            Dim dt As DataTable = adminDB.ObtenerTabla(sql, "OS")

            Dim lista As New List(Of SelectorItem)

            For Each fila As DataRow In dt.Rows

                lista.Add(New SelectorItem(fila("IdPlan"), fila("Descripcion").ToString()))

            Next

            With UcSelectorPlanes

                .Objetos = lista
                .NombrePropiedadId = "Id"
                .NombrePropiedadDescripcion = "Descripcion"
                .TituloSelector = "Planes OS"
                .HeaderDescripcion = "Plan OS"
                .PermitirVacio = True

            End With


        Catch ex As Exception

            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub FrmSelectorPlanesOS_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.Escape Then

            e.Handled = True
            e.SuppressKeyPress = True

            Me.DialogResult = DialogResult.Cancel
            Me.Close()

        End If

    End Sub

    Private Sub FrmSelectorPlanesOS_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.CargarSelectorPlanesOS()
    End Sub

    Private Sub UcSelectorPlanes_Seleccionado(sender As Object, e As EventArgs) Handles UcSelectorPlanes.Seleccionado

        Try

            Dim adminOS As New N_AdminObraSociales

            m_PlanSeleccionado = adminOS.ObtenerPlanOSPorId(CLng(UcSelectorPlanes.Id))


            If m_PlanSeleccionado IsNot Nothing Then

                Me.DialogResult = DialogResult.OK
                Me.Close()

            End If


        Catch ex As Exception

            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

End Class