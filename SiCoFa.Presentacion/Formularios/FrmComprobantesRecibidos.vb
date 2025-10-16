Imports SiCoFa.Negocio
Imports SiCoFa.Entidades

Public Class FrmComprobantesRecibidos
    Property SQL As String

    Private mAdminDB As New N_AdminDB

    Private Sub ActualizarDetalle()
        Try
            If Me.DataGridView1.CurrentRow Is Nothing Then Exit Sub
            Dim valor = Me.DataGridView1.CurrentRow.Cells(0).Value
            If valor Is Nothing OrElse Not IsNumeric(valor) Then Exit Sub
            Dim idOperacion As Long = Convert.ToInt64(valor)

            Dim AdminItems As New N_AdminItemsComprobante
            Dim objItems As List(Of ItemComprobanteCompra) = AdminItems.ListarItemsCompraPorIdOperacion(idOperacion)

            Me.DataGridView2.AutoGenerateColumns = False
            Me.DataGridView2.DataSource = objItems
            Me.DataGridView2.ClearSelection()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
        End Try

    End Sub

    Private Sub AjustarAnchoColumnasComprobantes()
        Try

            If DataGridView1.ColumnCount = 18 Then
                Dim totalAncho As Integer = DataGridView1.Width - 42
                Dim proporciones As Double() = {0.0R, 0.0R, 0.05R, 0.17R, 0.06R, 0.15R, 0.07R, 0.05R, 0.07R, 0.2R, 0.1R, 0.1R, 0.0R, 0.0R, 0.0R, 0.0R, 0.0R, 0.0R}

                For i As Integer = 0 To 17
                    DataGridView1.Columns(i).Width = CInt(totalAncho * proporciones(i))
                Next

            Else
                MessageBox.Show("El DataGridView1 no tiene 13 columnas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub AjustarAnchoColumnasDetalle()
        Try

            If DataGridView2.ColumnCount = 9 Then
                Dim totalAncho As Integer = DataGridView1.Width
                Dim proporciones As Double() = {0.0R, 0.08R, 0.58R, 0.05R, 0.05R, 0.08R, 0.08R, 0.05R, 0.08R, 0.08R}

                For i As Integer = 0 To 8 ' Itera a través de las 9 columnas
                    DataGridView2.Columns(i).Width = CInt(totalAncho * proporciones(i))
                Next
            Else
                MessageBox.Show("El DataGridView2 no tiene 9 columnas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub


    Private Sub FrmComprobantesEmitidos_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try

            Dim comprobantes As DataTable = mAdminDB.ObtenerTabla(Me.SQL)
            Me.DataGridView1.AutoGenerateColumns = False
            Me.DataGridView1.DataSource = comprobantes

            'Me.StartPosition = FormStartPosition.Manual
            'Me.Location = Screen.PrimaryScreen.WorkingArea.Location
            'Me.Size = Screen.PrimaryScreen.WorkingArea.Size

            Me.ActualizarDetalle()

            Me.AjustarAnchoColumnasComprobantes()
            Me.AjustarAnchoColumnasDetalle()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged

        Try
            If Me.DataGridView1.CurrentRow Is Nothing Then
                Me.DataGridView1.DataSource = Nothing
                Exit Sub
            End If

            Me.ActualizarDetalle()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub ImprimirComprobante(ByVal argNumCopias As Integer)
        Try
            If Me.DataGridView1.CurrentRow Is Nothing Then Exit Sub
            Dim valor = Me.DataGridView1.CurrentRow.Cells(0).Value
            If valor Is Nothing OrElse Not IsNumeric(valor) Then Exit Sub
            Dim idOperacion As Long = Convert.ToInt64(valor)

            Dim AdminComprobantes As New N_AdminComprobantes
            Dim objComprobante As Comprobante = AdminComprobantes.ObtenerComprobanteEmitidoPorIdOperacion(idOperacion, g_ParametrosTerminal.Empresa)

            Dim ReporteComprobantes As New ReporteComprobantes
            ReporteComprobantes.ImprimirComprobante(objComprobante, argNumCopias)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
        End Try
    End Sub

    Private Sub OriginalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuArchivoImprimirOriginal.Click
        Me.ImprimirComprobante(-1)
    End Sub

    Private Sub mnuArchivoImprimirDuplicado_Click(sender As Object, e As EventArgs) Handles mnuArchivoImprimirDuplicado.Click
        Me.ImprimirComprobante(-2)
    End Sub

    Private Sub mnuArchivoGuardarComo_Click(sender As Object, e As EventArgs) Handles mnuArchivoGuardarComo.Click
        Try

            If Me.DataGridView1.CurrentRow Is Nothing Then Exit Sub
            Dim valor = Me.DataGridView1.CurrentRow.Cells(0).Value
            If valor Is Nothing OrElse Not IsNumeric(valor) Then Exit Sub
            Dim idOperacion As Long = Convert.ToInt64(valor)

            Dim AdminComprobantes As New N_AdminComprobantes
            Dim objComprobante As Comprobante = AdminComprobantes.ObtenerComprobanteEmitidoPorIdOperacion(idOperacion, g_ParametrosTerminal.Empresa)

            Dim saveFileDialog1 As New SaveFileDialog()
            With saveFileDialog1
                .Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
                .FilterIndex = 2
                .FileName = objComprobante.TipoComprobante.CodiTC_SiCoFa & "-" & objComprobante.PVenta & "-" & objComprobante.NumComp
                .DefaultExt = ".pdf"
                .RestoreDirectory = True
            End With

            If saveFileDialog1.ShowDialog() = DialogResult.OK Then
                Dim ReporteComprobantes As New ReporteComprobantes
                ReporteComprobantes.PdfA4(saveFileDialog1.FileName, objComprobante)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub mnuOperacionesNC_Click(sender As Object, e As EventArgs) Handles mnuOperacionesNC.Click
        Try

            If Me.DataGridView1.CurrentRow Is Nothing Then Exit Sub
            Dim valor = Me.DataGridView1.CurrentRow.Cells(0).Value
            If valor Is Nothing OrElse Not IsNumeric(valor) Then Exit Sub
            Dim idOperacion As Long = Convert.ToInt64(valor)

            Dim u As Usuario = ModSeguridad.ValidarUsuario("NOTA_CREDITO")

            If u IsNot Nothing Then
                Dim f As New FrmNotaCredito()
                f.Usuario = u
                f.ObtenerComprobanteOrigen(idOperacion)
                f.Show()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
End Class