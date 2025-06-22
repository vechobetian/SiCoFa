Imports SiCoFa.Negocio
Public Class FrmMoviCajaEFDetalle
    Property IdCaja As Long

    Private Sub FrmMoviCajaEfectivoDetalle_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim sql As String = $"SELECT Fin,IdUsuario,TipoOperacion,TipoComprobante,NumComp,ImpEf FROM ConMoviCajaEfectivoDetalle WHERE IdCaja={Me.IdCaja}"
        Dim dTable As DataTable = Nothing
        Dim obj_ADminDB As New N_AdminDB

        If sql <> "" Then
            dTable = obj_ADminDB.ObtenerTabla(sql)
        End If

        If dTable IsNot Nothing Then
            Me.DataGridView1.DataSource = dTable
        End If

        Me.DataGridView1.DataSource = dTable
        Me.DataGridView1.Refresh()
        Me.DataGridView1.ClearSelection()

        Dim totalImporte As Decimal = 0D
        Dim numItems As Integer = 0
        For Each row As DataRow In dTable.Rows
            numItems += 1
            If Not IsDBNull(row("ImpEf")) Then
                totalImporte += Convert.ToDecimal(row("ImpEf"))
            End If
        Next

        Me.Label1.Text = "Items: " & numItems
        Me.Label2.Text = "Importe: $" & totalImporte.ToString("N2")

    End Sub
End Class