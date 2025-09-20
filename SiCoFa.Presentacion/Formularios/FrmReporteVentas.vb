Imports SiCoFa.Negocio

Public Class FrmReporteVentas
    ' Propiedad para la consulta SQL
    Property SQL As String

    Private mAdminDB As New N_AdminDB

    Private Sub FrmComprobantesEmitidos_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            ' Obtener los datos originales de la base de datos
            Dim ReporteVentas As DataTable = mAdminDB.ObtenerTabla(Me.SQL)

            ' Asignar la fuente de datos al DataGridView
            Me.DataGridView1.DataSource = ReporteVentas
            Me.AjustarAnchoColumnas()

            ' Agregar las filas de totales y porcentajes
            Me.AgregarFilasTotalesYPorcentaje()
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
        End Try
    End Sub

    Private Sub AjustarAnchoColumnas()
        Try
            If DataGridView1.ColumnCount = 9 Then
                Dim totalAncho As Integer = DataGridView1.Width - 42
                Dim proporciones As Double() = {0.1R, 0.1R, 0.1R, 0.2R, 0.1R, 0.1R, 0.1R, 0.1R, 0.1R}
                For i As Integer = 0 To 8
                    DataGridView1.Columns(i).Width = CInt(totalAncho * proporciones(i))
                Next
            Else
                MessageBox.Show("El DataGridView1 no tiene 9 columnas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
        End Try
    End Sub

    Private Sub AgregarFilasTotalesYPorcentaje()
        Dim dt As DataTable = CType(DataGridView1.DataSource, DataTable)

        ' Eliminar filas totales y de porcentajes anteriores
        Dim filasAEliminar As New List(Of DataRow)()
        For Each row As DataRow In dt.Rows
            If row.RowState <> DataRowState.Deleted AndAlso row.IsNull("Fecha") Then
                filasAEliminar.Add(row)
            End If
        Next
        For Each row As DataRow In filasAEliminar
            dt.Rows.Remove(row)
        Next

        ' Variables acumuladoras
        Dim totalNOperac As Integer = 0
        Dim ImpMedioTiket As Decimal = 0 ' Aquí se almacena la suma para el promedio
        Dim ImpBto As Decimal = 0
        Dim ImpDes As Decimal = 0
        Dim ImpNeto As Decimal = 0
        Dim ImpEf As Decimal = 0
        Dim ImpCC As Decimal = 0
        Dim ImpPE As Decimal = 0

        For Each row As DataRow In dt.Rows
            If row.RowState <> DataRowState.Deleted Then
                totalNOperac += If(IsNumeric(row("NOperac")), Convert.ToInt32(row("NOperac")), 0)
                ImpMedioTiket += If(IsNumeric(row("ImpMedioTiket")), Convert.ToDecimal(row("ImpMedioTiket")), 0)
                ImpBto += If(IsNumeric(row("ImpBto")), Convert.ToDecimal(row("ImpBto")), 0)
                ImpDes += If(IsNumeric(row("ImpDes")), Convert.ToDecimal(row("ImpDes")), 0)
                ImpNeto += If(IsNumeric(row("ImpNeto")), Convert.ToDecimal(row("ImpNeto")), 0)
                ImpEf += If(IsNumeric(row("ImpEf")), Convert.ToDecimal(row("ImpEf")), 0)
                ImpCC += If(IsNumeric(row("ImpCC")), Convert.ToDecimal(row("ImpCC")), 0)
                ImpPE += If(IsNumeric(row("ImpPE")), Convert.ToDecimal(row("ImpPE")), 0)
            End If
        Next

        ' Calcular el TicketPromedio final
        Dim TiketPromedioFinal As Decimal = If(totalNOperac > 0, Math.Round(ImpNeto / totalNOperac, 2), 0)

        ' --- Fila TOTAL ---
        Dim filaTotal As DataRow = dt.NewRow()
        filaTotal("Fecha") = DBNull.Value
        filaTotal("NOperac") = totalNOperac
        filaTotal("ImpMedioTiket") = TiketPromedioFinal
        filaTotal("ImpBto") = ImpBto
        filaTotal("ImpDes") = ImpDes
        filaTotal("ImpNeto") = ImpNeto
        filaTotal("ImpEf") = ImpEf
        filaTotal("ImpCC") = ImpCC
        filaTotal("ImpPE") = ImpPE
        dt.Rows.Add(filaTotal)

        ' --- Fila PORCENTAJE ---
        Dim filaPorcentaje As DataRow = dt.NewRow()
        filaPorcentaje("Fecha") = DBNull.Value
        filaPorcentaje("NOperac") = DBNull.Value
        filaPorcentaje("ImpMedioTiket") = DBNull.Value ' Este valor se formateará en el evento CellFormatting

        If ImpBto <> 0 Then
            filaPorcentaje("ImpBto") = 100
            filaPorcentaje("ImpDes") = Math.Round((ImpDes / ImpBto) * 100, 2)
            filaPorcentaje("ImpNeto") = Math.Round((ImpNeto / ImpBto) * 100, 2)
            filaPorcentaje("ImpEf") = Math.Round((ImpEf / ImpNeto) * 100, 2)
            filaPorcentaje("ImpCC") = Math.Round((ImpCC / ImpNeto) * 100, 2)
            filaPorcentaje("ImpPE") = Math.Round((ImpPE / ImpNeto) * 100, 2)
            filaPorcentaje("ImpMedioTiket") = Math.Round((TiketPromedioFinal / ImpNeto) * 100, 2) ' Se utiliza el total de TiketPromedioFinal
        Else
            filaPorcentaje("ImpBto") = 0
            filaPorcentaje("ImpDes") = 0
            filaPorcentaje("ImpNeto") = 0
            filaPorcentaje("ImpEf") = 0
            filaPorcentaje("ImpCC") = 0
            filaPorcentaje("ImpPE") = 0
            filaPorcentaje("ImpMedioTiket") = 0
        End If
        dt.Rows.Add(filaPorcentaje)
    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        Dim fila As DataGridViewRow = DataGridView1.Rows(e.RowIndex)

        ' Usar la columna Fecha como indicador para las filas especiales
        If fila.Cells("Fecha").Value Is DBNull.Value Then
            ' Fila TOTAL
            If DataGridView1.Columns(e.ColumnIndex).Name = "Fecha" Then
                ' Mostrar "TOTAL" en la columna Fecha
                If e.RowIndex = DataGridView1.Rows.Count - 2 Then
                    e.Value = "TOTALES"
                    fila.DefaultCellStyle.BackColor = Color.LightGray
                    fila.DefaultCellStyle.Font = New Font(DataGridView1.Font, FontStyle.Bold)
                End If
            End If

            ' Fila PORCENTAJES
            If DataGridView1.Columns(e.ColumnIndex).Name = "Fecha" Then
                ' Mostrar "PORCENTAJES" en la columna Fecha
                If e.RowIndex = DataGridView1.Rows.Count - 1 Then
                    e.Value = "PORCENTAJES"
                    fila.DefaultCellStyle.BackColor = Color.LightBlue
                    fila.DefaultCellStyle.Font = New Font(DataGridView1.Font, FontStyle.Bold)
                End If
            End If

            ' Agregar % visualmente a las columnas numéricas para la fila de porcentajes
            Dim columnasPorcentaje As String() = {"ImpBto", "ImpDes", "ImpNeto", "ImpEf", "ImpCC", "ImpPE", "ImpMedioTiket"}
            If e.RowIndex = DataGridView1.Rows.Count - 1 AndAlso columnasPorcentaje.Contains(DataGridView1.Columns(e.ColumnIndex).Name) AndAlso e.Value IsNot Nothing Then
                e.Value = e.Value.ToString() & " %"
                e.FormattingApplied = True
            End If
        End If
    End Sub

End Class





