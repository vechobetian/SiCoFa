Imports SiCoFa.Negocio
Public Class FrmBuscaOperacionesIniciadas
    Property IdOperacionSeleccionado As Long

    Private mobj_AdminDB As New N_AdminDB

    Public Function CargarVentasIniciadas(ByVal argIdEmpresa As Int32, ByVal argIdUsuario As Int32, ByVal argCodiTO As String) As Boolean
        Try

            Dim sql As String = $"
            SELECT operaciones.IdOperacion, operaciones.Inicio,
                   IFNULL(clientes.Nombre, 'CONSUMIDOR FINAL NO IDENTIFICADO') AS Nombre
            FROM operaciones
            LEFT JOIN TblOperacionesCL ON operaciones.IdOperacion = TblOperacionesCL.IdOperacion
            LEFT JOIN clientes ON TblOperacionesCL.IdCliente = clientes.IdCliente
            WHERE operaciones.IdEmpresa = {argIdEmpresa} AND 
                  operaciones.IdUsuario = {argIdUsuario} AND
                  operaciones.CodiTO='{argCodiTO}' AND
                  operaciones.EstadoOperacion = 'GUARDADO'"

            Dim OperacionesIniciadas As DataTable = mobj_AdminDB.ObtenerTabla(sql)

            If OperacionesIniciadas.Rows.Count = 0 Then
                Return False
            End If

            Me.dgvOperacionesIniciadas.DataSource = OperacionesIniciadas
            Me.dgvOperacionesIniciadas.ClearSelection()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
            Return False
        End Try
    End Function

    Private Sub MostrarItems()

        If Me.dgvOperacionesIniciadas.RowCount = 0 Then
            Me.dgvItemsOperacion.Rows.Clear()
            Exit Sub
        End If

        If Me.dgvOperacionesIniciadas.CurrentRow.Cells(0).Value Is Nothing Then
            Exit Sub
        End If

        Dim sql As String = "SELECT IdItem,Descripcion,Cantidad,PrecioUnitario,(Cantidad*PrecioUnitario) AS Importe FROM TblItemsComprobante WHERE IdOperacion='" & Me.dgvOperacionesIniciadas.CurrentRow.Cells(0).Value & "' ORDER BY IdItem"

        Dim Items As DataTable = mobj_AdminDB.ObtenerTabla(sql)
        Me.dgvItemsOperacion.DataSource = Items
        Me.dgvItemsOperacion.Refresh()

    End Sub

    Private Sub dgvOperacionesIniciadas_SelectionChanged(sender As Object, e As EventArgs) Handles dgvOperacionesIniciadas.SelectionChanged

        Try
            If dgvOperacionesIniciadas.CurrentRow Is Nothing Then
                Me.dgvItemsOperacion.DataSource = Nothing
                Exit Sub
            End If
            Me.MostrarItems()
            Me.dgvItemsOperacion.ClearSelection()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData
            Case Keys.Escape
                Me.DialogResult = DialogResult.Cancel
                Me.Close()

            Case Keys.Enter
                Me.IdOperacionSeleccionado = Me.dgvOperacionesIniciadas.CurrentRow.Cells("IdOperacion").Value
                Me.DialogResult = DialogResult.OK
                Me.Hide()

            Case Keys.Delete
                Dim sql As String = $"DELETE FROM operaciones WHERE IdOperacion= {Me.dgvOperacionesIniciadas.CurrentRow.Cells("IdOperacion").Value } "
                Dim eliminado As Boolean = mobj_AdminDB.EliminarRegistros(sql)

                If eliminado Then
                    dgvOperacionesIniciadas.Rows.Remove(dgvOperacionesIniciadas.CurrentRow)
                Else
                    MessageBox.Show("No se pudo eliminar la operación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Case Else
                Return MyBase.ProcessCmdKey(msg, keyData)
        End Select
        Return True ' Asegúrate de devolver True para que la tecla se procese correctamente
    End Function


End Class