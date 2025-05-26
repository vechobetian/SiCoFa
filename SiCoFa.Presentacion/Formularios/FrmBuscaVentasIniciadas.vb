Imports SiCoFa.Negocio
Imports SiCoFa.Entidades
Public Class FrmBuscaVentasIniciadas
    Property IdUsuario As Int32 = 1

    Private mobj_AdminDB As New cls_N_AdminDB

    Private Sub MostrarItems()

        If Me.dgvOperacionesIniciadas.CurrentRow.Cells(0).Value Is Nothing Then
            Exit Sub
        End If

        Dim sql As String = "SELECT IdItem,Descripcion,Cantidad,PrecioUnitario,(Cantidad*PrecioUnitario) AS Importe FROM TblItemsComprobante WHERE IdOperacion='" & Me.dgvOperacionesIniciadas.CurrentRow.Cells(0).Value & "' ORDER BY IdItem"

        Dim Items As DataTable = mobj_AdminDB.ObtenerTabla(sql)
        Me.dgvItemsOperacion.DataSource = Items
        Me.dgvItemsOperacion.ClearSelection()
        Me.dgvItemsOperacion.Refresh()

    End Sub

    Private Sub FrmBuscaVentasIniciadas_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim sql As String = "SELECT TblOperaciones.IdOperacion,TblOperaciones.Inicio,IFNULL(TblClientes.Nombre, 'CONSUMIDOR FINAL') AS Nombre FROM TblOperaciones LEFT JOIN TblOperacionesCL ON TblOperaciones.IdOperacion=TblOperacionesCL.IdOperacion 
                                LEFT JOIN TblClientes ON TblOperacionesCL.IdCliente=TblClientes.IdCliente WHERE TblOperaciones.IdUsuario=" & Me.IdUsuario & " AND TblOperaciones.EstadoOperacion='INICIADO'"

            Dim OperacionesIniciadas As DataTable = mobj_AdminDB.ObtenerTabla(sql)
            Me.dgvOperacionesIniciadas.DataSource = OperacionesIniciadas

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
        End Try
    End Sub

    Private Sub dgvOperacionesIniciadas_SelectionChanged(sender As Object, e As EventArgs) Handles dgvOperacionesIniciadas.SelectionChanged

        Try
            Me.MostrarItems()
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

End Class