Imports System.Text
Imports SiCoFa.Entidades

Public Class FrmRecetasBeneficiario

    Public Property NumeroRecetaSeleccionada As String

    Private Sub FrmRecetasBeneficiario_Load(sender As Object, e As EventArgs) Handles Me.Load

        With DgvRecetas

            .AutoGenerateColumns = False
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeRows = False
            .ReadOnly = True
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .RowHeadersVisible = False

            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

        End With

    End Sub

    Public Sub RecetasBeneficiario(argRecetas As List(Of Receta))

        DgvRecetas.Rows.Clear()

        For Each receta As Receta In argRecetas

            DgvRecetas.Rows.Add(receta.NumReceta, receta.FechaPrescripcion, ObtenerDetalle(receta))

        Next

        If DgvRecetas.Rows.Count > 0 Then
            DgvRecetas.CurrentCell = DgvRecetas.Rows(0).Cells(0)
        End If

    End Sub

    Private Function ObtenerDetalle(argReceta As Receta) As String

        Dim sb As New StringBuilder

        For Each item As ItemComprobante In argReceta.Items

            If sb.Length > 0 Then
                sb.AppendLine()
                sb.AppendLine("────────────────────────────────")
            End If

            sb.Append(item.Descripcion)

        Next

        Return sb.ToString()

    End Function

    Private Sub FrmRecetasBeneficiario_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        If DgvRecetas.Rows.Count > 0 Then

            DgvRecetas.ClearSelection()

            DgvRecetas.CurrentCell = DgvRecetas.Rows(0).Cells(0)
            DgvRecetas.Rows(0).Selected = True

            DgvRecetas.Focus()

        End If

    End Sub

    Private Sub SeleccionarReceta()

        If DgvRecetas.CurrentRow Is Nothing Then Exit Sub

        NumeroRecetaSeleccionada = DgvRecetas.CurrentRow.Cells("NumReceta").Value.ToString()

        DialogResult = DialogResult.OK
        Close()

    End Sub

    Private Sub DgvRecetas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvRecetas.CellDoubleClick

        If e.RowIndex >= 0 Then
            SeleccionarReceta()
        End If

    End Sub

    Private Sub DgvRecetas_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvRecetas.KeyDown

        If e.KeyCode = Keys.Enter Then

            e.Handled = True
            e.SuppressKeyPress = True

            SeleccionarReceta()

        ElseIf e.KeyCode = Keys.Escape Then

            e.Handled = True
            e.SuppressKeyPress = True

            Me.DialogResult = DialogResult.Cancel
            Me.Close()

        End If

    End Sub

End Class