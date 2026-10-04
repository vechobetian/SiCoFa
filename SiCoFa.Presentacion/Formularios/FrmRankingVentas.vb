Imports SiCoFa.Negocio

Public Class FrmRankingVentas

    Private mAdminDB As New N_AdminDB

    Private Sub FrmRankingVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub SeleccionarPeriodo()

        Using frm As New FrmRangoFechas

            If frm.ShowDialog(Me) <> DialogResult.OK Then
                Return
            End If

            Dim fechaDesde As Date = frm.FechaDesde
            Dim fechaHasta As Date = frm.FechaHasta

            CargarRanking(fechaDesde, fechaHasta)

        End Using

    End Sub

    Private Sub CargarRanking(ByVal fechaDesde As Date, ByVal fechaHasta As Date)

        Try

            Dim desde As String = fechaDesde.ToString("yyyy-MM-dd")
            Dim hasta As String = fechaHasta.ToString("yyyy-MM-dd")

            Dim sql As String =
            "WITH ventas AS (" &
            "    SELECT " &
            "        IdArticulo, " &
            "        MAX(Nombre) AS Articulo, " &
            "        SUM(Unidades) AS Unidades, " &
            "        SUM(Importe) AS Importe " &
            "    FROM vw_ranking_ventas " &
            "    WHERE Fecha >= '" & desde & "' " &
            "      AND Fecha < DATE_ADD('" & hasta & "', INTERVAL 1 DAY) " &
            "    GROUP BY IdArticulo " &
            "), " &
            "totales AS (" &
            "    SELECT SUM(Unidades) AS TotalUnidades " &
            "    FROM ventas " &
            "), " &
            "parametros AS (" &
            "    SELECT DATEDIFF('" & hasta & "', '" & desde & "') + 1 AS Dias " &
            ") " &
            "SELECT " &
            "    ROW_NUMBER() OVER (ORDER BY v.Unidades DESC) AS Puesto, " &
            "    v.Articulo, " &
            "    ROUND(" &
            "        SUM(v.Unidades) OVER (" &
            "            ORDER BY v.Unidades DESC " &
            "            ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW" &
            "        ) * 100.0 / NULLIF(t.TotalUnidades, 0)," &
            "        0" &
            "    ) AS PorcentajeAcumulado, " &
            "    v.Importe, " &
            "    v.Unidades, " &
            "    ROUND(v.Unidades / NULLIF(p.Dias, 0), 0) AS UnidadesDia, " &
            "    ROUND((v.Unidades / NULLIF(p.Dias, 0)) * 7, 0) AS UnidadesSemana, " &
            "    ROUND((v.Unidades / NULLIF(p.Dias, 0)) * 30, 0) AS UnidadesMes " &
            "FROM ventas AS v " &
            "CROSS JOIN totales AS t " &
            "CROSS JOIN parametros AS p " &
            "ORDER BY v.Unidades DESC"

            Dim ranking As DataTable = mAdminDB.ObtenerTabla(sql)

            dgvRanking.AutoGenerateColumns = False
            dgvRanking.DataSource = ranking

        Catch ex As Exception

            MessageBox.Show(
            ex.ToString(),
            "Error al cargar ranking",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub FrmRankingVentas_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        SeleccionarPeriodo()

    End Sub

End Class