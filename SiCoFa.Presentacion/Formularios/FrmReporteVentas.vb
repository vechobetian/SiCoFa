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

            ' Agregar las filas de totales y porcentajes
            Me.AgregarFilasTotalesYPorcentaje()
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
        Dim impMedioTiket As Decimal = 0D ' Aquí se almacena la suma para el promedio
        Dim impBto As Decimal = 0D
        Dim impDes As Decimal = 0D
        Dim impNeto As Decimal = 0D
        Dim impEx As Decimal = 0D
        Dim impGrav1 As Decimal = 0D
        Dim impGrav2 As Decimal = 0D
        Dim impEf As Decimal = 0D
        Dim impCC As Decimal = 0D
        Dim impPE As Decimal = 0D
        Dim impOS As Decimal = 0D

        For Each row As DataRow In dt.Rows
            If row.RowState <> DataRowState.Deleted Then
                totalNOperac += If(IsNumeric(row("NOperac")), Convert.ToInt32(row("NOperac")), 0)
                ImpMedioTiket += If(IsNumeric(row("ImpMedioTiket")), Convert.ToDecimal(row("ImpMedioTiket")), 0)
                ImpBto += If(IsNumeric(row("ImpBto")), Convert.ToDecimal(row("ImpBto")), 0)
                ImpDes += If(IsNumeric(row("ImpDes")), Convert.ToDecimal(row("ImpDes")), 0)
                impNeto += If(IsNumeric(row("ImpNeto")), Convert.ToDecimal(row("ImpNeto")), 0)
                impEx += If(IsNumeric(row("ImpEx")), Convert.ToDecimal(row("ImpEx")), 0)
                impGrav1 += If(IsNumeric(row("ImpGrav1")), Convert.ToDecimal(row("ImpGrav1")), 0)
                impGrav2 += If(IsNumeric(row("ImpGrav2")), Convert.ToDecimal(row("ImpGrav2")), 0)
                impEf += If(IsNumeric(row("ImpEf")), Convert.ToDecimal(row("ImpEf")), 0)
                ImpCC += If(IsNumeric(row("ImpCC")), Convert.ToDecimal(row("ImpCC")), 0)
                impPE += If(IsNumeric(row("ImpPE")), Convert.ToDecimal(row("ImpPE")), 0)
                impOS += If(IsNumeric(row("ImpOS")), Convert.ToDecimal(row("ImpOS")), 0)
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
        filaTotal("ImpDes") = impDes
        filaTotal("ImpNeto") = impNeto
        filaTotal("ImpEx") = impEx
        filaTotal("ImpGrav1") = impGrav1
        filaTotal("ImpGrav2") = impGrav2
        filaTotal("ImpEf") = ImpEf
        filaTotal("ImpCC") = impCC
        filaTotal("ImpPE") = impPE
        filaTotal("ImpOS") = impOS
        dt.Rows.Add(filaTotal)

        ' --- Fila PORCENTAJE ---
        Dim filaPorcentaje As DataRow = dt.NewRow()
        filaPorcentaje("Fecha") = DBNull.Value
        filaPorcentaje("NOperac") = DBNull.Value
        filaPorcentaje("ImpMedioTiket") = DBNull.Value ' Este valor se formateará en el evento CellFormatting

        If ImpBto <> 0 Then
            filaPorcentaje("ImpBto") = 100
            filaPorcentaje("ImpDes") = Math.Round((ImpDes / ImpBto) * 100, 2)
            filaPorcentaje("ImpNeto") = Math.Round((impNeto / impBto) * 100, 2)
            filaPorcentaje("ImpEx") = Math.Round((impEx / impBto) * 100, 2)
            filaPorcentaje("ImpGrav1") = Math.Round((impGrav1 / impBto) * 100, 2)
            filaPorcentaje("ImpGrav2") = Math.Round((impGrav2 / impBto) * 100, 2)
            filaPorcentaje("ImpEf") = Math.Round((ImpEf / ImpNeto) * 100, 2)
            filaPorcentaje("ImpCC") = Math.Round((ImpCC / ImpNeto) * 100, 2)
            filaPorcentaje("ImpPE") = Math.Round((impPE / impNeto) * 100, 2)
            filaPorcentaje("ImpOS") = Math.Round((impOS / impNeto) * 100, 2)
            filaPorcentaje("ImpMedioTiket") = Math.Round((TiketPromedioFinal / ImpNeto) * 100, 2) ' Se utiliza el total de TiketPromedioFinal
        Else
            filaPorcentaje("ImpBto") = 0
            filaPorcentaje("ImpDes") = 0
            filaPorcentaje("ImpNeto") = 0
            filaPorcentaje("ImpEx") = 0
            filaPorcentaje("ImpGrav1") = 0
            filaPorcentaje("ImpGrav2") = 0
            filaPorcentaje("ImpEf") = 0
            filaPorcentaje("ImpCC") = 0
            filaPorcentaje("ImpPE") = 0
            filaPorcentaje("ImpOS") = 0
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
            Dim columnasPorcentaje As String() = {"ImpBto", "ImpDes", "ImpNeto", "ImpEx", "ImpGrav1", "ImpGrav2", "ImpEf", "ImpCC", "ImpPE", "ImpOS", "ImpMedioTiket"}
            If e.RowIndex = DataGridView1.Rows.Count - 1 AndAlso columnasPorcentaje.Contains(DataGridView1.Columns(e.ColumnIndex).Name) AndAlso e.Value IsNot Nothing Then
                e.Value = e.Value.ToString() & " %"
                e.FormattingApplied = True
            End If
        End If
    End Sub

End Class





