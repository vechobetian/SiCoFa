Imports SiCoFa.Negocio
Public Class FrmMoviCajaOSDetalle
    Property IdCaja As Long

    Private Sub FrmMoviCajaEfectivoDetalle_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim sql As String = $"SELECT Descripcion,Fin,IdUsuario,TipoOperacion,TipoComprobante,NumComp,ImporteTotal,ImporteOS,ImporteAf FROM vw_movimientos_caja_os_detalle WHERE IdCaja={Me.IdCaja}"
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
        Dim totalOS As Decimal = 0D
        Dim totalAf As Decimal = 0D
        Dim numItems As Integer = 0
        For Each row As DataRow In dTable.Rows
            numItems += 1
            If Not IsDBNull(row("ImporteTotal")) Then
                totalImporte += Convert.ToDecimal(row("ImporteTotal"))
                totalOS += Convert.ToDecimal(row("ImporteOS"))
                totalAf += Convert.ToDecimal(row("ImporteAf"))
            End If
        Next

        Me.Label1.Text = "Items: " & numItems
        Me.Label2.Text = "Importe Total: $" & totalImporte.ToString("N2") & "  |  Importe OS: $" & totalOS.ToString("N2") & "  |   Importe Af: $" & totalAf.ToString("N2")

    End Sub
End Class