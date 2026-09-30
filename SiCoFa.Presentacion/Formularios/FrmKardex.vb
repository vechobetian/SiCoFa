Imports System.ComponentModel
Imports SiCoFa.Entidades
Imports SiCoFa.Negocio

Public Class FrmKardex

    Property SQL As String = "SELECT * FROM vw_kardex"

    Private mAdminDB As New N_AdminDB

    Private Function IdArticulo(ByVal argTextoBuscado As String) As String

        Try
            Dim adminArticulos As New N_AdminArticulos
            Dim la As List(Of Articulo) = adminArticulos.ListarArticulos(argTextoBuscado, True)
            Dim a As Articulo = Nothing

            If la Is Nothing Then
                MsgBox("Articulo no Encontrado", vbInformation, "SiCoFa")
                Return ""
                Exit Function
            End If

            Select Case la.Count
                Case 0
                    MsgBox("Articulo no Encontrado", vbInformation, "SiCoFa")
                    Me.txtSelectorArticulo.Text = ""
                    Me.txtSelectorArticulo.Select()
                    Return ""
                    Exit Function

                Case 1
                    a = la.First

                Case > 1

                    Using f As New FrmBuscaArticulos
                        f.Articulos = la
                        f.ShowDialog()
                        If f.DialogResult = DialogResult.OK Then
                            a = f.ArticuloSeleccionado
                        End If
                        f.Close()
                    End Using

            End Select

            Return a.IdArticulo

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Function

    Private Sub FrmKardex_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try

            Me.dgvKardex.AutoGenerateColumns = False


        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub dgvKardex_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)

        If dgvKardex.Columns(e.ColumnIndex).Name = "Fraccionado" AndAlso
           e.Value IsNot Nothing AndAlso
           e.Value IsNot DBNull.Value Then

            e.Value = If(Convert.ToBoolean(e.Value), "SI", "NO")
            e.FormattingApplied = True

        End If

    End Sub

    Private Sub txtSelectorArticulo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSelectorArticulo.KeyDown

        If e.KeyCode <> Keys.Enter Then Exit Sub

        e.SuppressKeyPress = True

        Try

            If Me.txtSelectorArticulo.Text.Trim = "" Then Exit Sub

            Dim idArticulo As String = Me.IdArticulo(Me.txtSelectorArticulo.Text)

            If String.IsNullOrEmpty(idArticulo) Then
                Me.txtSelectorArticulo.Select()
                Exit Sub
            End If

            'Seleccionar rango de fechas
            Using f As New FrmRangoFechas

                If f.ShowDialog(Me) <> DialogResult.OK Then
                    Me.txtSelectorArticulo.Select()
                    Exit Sub
                End If

                Dim fechaDesde As Date = f.FechaDesde
                Dim fechaHasta As Date = f.FechaHasta

                'Cargar Kardex
                CargarKardex(idArticulo, fechaDesde, fechaHasta)

            End Using

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
        End Try

    End Sub

    Private Sub CargarKardex(ByVal argIdArticulo As String, ByVal argFechaDesde As Date, ByVal argFechaHasta As Date)
        Try
            Dim sql As String = $"SELECT * FROM vw_kardex WHERE IdArticulo = '{argIdArticulo}' AND Fecha BETWEEN '{argFechaDesde:yyyy-MM-dd}' AND '{argFechaHasta:yyyy-MM-dd}'"
            Dim kardex As DataTable = mAdminDB.ObtenerTabla(sql)
            Me.dgvKardex.AutoGenerateColumns = False
            Me.dgvKardex.DataSource = kardex
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
        End Try
    End Sub

End Class