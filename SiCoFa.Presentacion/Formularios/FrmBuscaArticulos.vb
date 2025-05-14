Imports SiCoFa.Entidades

Public Class FrmBuscaArticulos
    Property Articulos As IEnumerable(Of Articulo)
    Property ArticuloSeleccionado As Articulo
    Private Sub SeleccionarArticulo()

        Dim a As New Articulo(
                              Me.DataGridView1.CurrentRow.Cells("IdArticulo").Value,
                              Me.DataGridView1.CurrentRow.Cells("Codigo").Value,
                              Me.DataGridView1.CurrentRow.Cells("CodBarra").Value,
                              Me.DataGridView1.CurrentRow.Cells("Nombre").Value,
                              New AlicuotaIVA(Me.DataGridView1.CurrentRow.Cells("AlicIVA").Value),
                              Me.DataGridView1.CurrentRow.Cells("FechaPrecio").Value,
                              Me.DataGridView1.CurrentRow.Cells("PrecioCosto").Value,
                              Me.DataGridView1.CurrentRow.Cells("PrecioVenta").Value,
                              Me.DataGridView1.CurrentRow.Cells("Baja").Value,
                              New Seccion(Me.DataGridView1.CurrentRow.Cells("IdSeccion").Value, Me.DataGridView1.CurrentRow.Cells("Seccion").Value, Me.DataGridView1.CurrentRow.Cells("EstablecerPrecio").Value),
                              Me.DataGridView1.CurrentRow.Cells("ActualizarPrecio").Value,
                              Me.DataGridView1.CurrentRow.Cells("Stock").Value,
                              New ListaPrecios(Me.DataGridView1.CurrentRow.Cells("CodiLP").Value, Me.DataGridView1.CurrentRow.Cells("ListaPrecios").Value),
                              Me.DataGridView1.CurrentRow.Cells("Fabricante").Value
                             )
        Me.ArticuloSeleccionado = a

    End Sub
    Private Sub CargarDatosEnDataGridView()
        Dim x As Integer
        For Each a As Articulo In Me.Articulos
            With Me.DataGridView1
                .Rows.Add()
                .Rows(x).Cells("IdArticulo").Value = a.IdArticulo
                .Rows(x).Cells("Codigo").Value = a.Codigo
                .Rows(x).Cells("CodBarra").Value = a.CodBarra
                .Rows(x).Cells("Nombre").Value = a.Nombre
                .Rows(x).Cells("AlicIVA").Value = a.AlicuotaIVA.AlicIVA
                .Rows(x).Cells("FechaPrecio").Value = a.FechaPrecio
                .Rows(x).Cells("PrecioCosto").Value = a.PrecioCosto
                .Rows(x).Cells("PrecioVenta").Value = a.PrecioVenta
                .Rows(x).Cells("Baja").Value = a.Baja
                .Rows(x).Cells("IdSeccion").Value = a.Seccion.IdSeccion
                .Rows(x).Cells("Seccion").Value = a.Seccion.Seccion
                .Rows(x).Cells("EstablecerPrecio").Value = a.Seccion.EstablecerPrecio
                .Rows(x).Cells("ActualizarPrecio").Value = a.ActualizarPrecio
                .Rows(x).Cells("Stock").Value = a.Stock
                .Rows(x).Cells("CodiLP").Value = a.ListaPrecios.CodiLP
                .Rows(x).Cells("ListaPrecios").Value = a.ListaPrecios.ListaPrecios
                .Rows(x).Cells("Fabricante").Value = a.Fabricante
            End With
            x += 1
        Next
        Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(0).Cells(3)
    End Sub
    Private Sub FrmBuscaPersonas_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.CargarDatosEnDataGridView()

    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData
            Case Keys.Escape
                Me.DialogResult = DialogResult.Cancel
                Me.Close()
            Case Keys.Enter
                Call SeleccionarArticulo()
                Me.DialogResult = DialogResult.OK
                Me.Hide()
            Case Else
                Return MyBase.ProcessCmdKey(msg, keyData)
        End Select
        Return True ' Asegúrate de devolver True para que la tecla se procese correctamente
    End Function
End Class