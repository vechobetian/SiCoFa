Imports SiCoFa.Negocio
Imports SiCoFa.Entidades
Imports SiCoFa.Entidades.Enums

Public Class FrmBuscaArticulos
    Property Articulos As IEnumerable(Of Articulo)
    Property ArticuloSeleccionado As Articulo

    Private FormularioCargado As Boolean = False

    Private Sub SeleccionarArticulo()
        'Dim AdminListaPrecios As New N_AdminListaPrecios
        Dim AdminArticulos As New N_AdminArticulos
        'Dim listaPrecios As ListaPrecios = AdminListaPrecios.ObtenerListaPreciosPorCodiLP(Me.DataGridView1.CurrentRow.Cells("CodiLP").Value)
        Dim IdArticulo As String = Me.DataGridView1.CurrentRow.Cells("IdArticulo").Value
        Dim a As Articulo = AdminArticulos.ObtenerArticuloPorId(IdArticulo)
        Me.ArticuloSeleccionado = a

    End Sub
    Private Sub CargarDatosEnDataGridView()
        Dim x As Integer
        For Each a As Articulo In Me.Articulos
            With Me.DataGridView1
                .Rows.Add()
                .Rows(x).Cells("IdArticulo").Value = a.IdArticulo
                .Rows(x).Cells("Codigo").Value = a.Codigo
                .Rows(x).Cells("CodBarras").Value = a.CodBarras
                .Rows(x).Cells("Nombre").Value = a.Nombre
                .Rows(x).Cells("AlicIVA").Value = a.AlicIVA
                .Rows(x).Cells("FechaPrecio").Value = a.FechaPrecio
                .Rows(x).Cells("PrecioCosto").Value = a.PrecioCosto
                .Rows(x).Cells("PrecioVenta").Value = a.PrecioVenta
                .Rows(x).Cells("PrecioOferta").Value = a.PrecioOferta
                .Rows(x).Cells("Baja").Value = a.Baja
                .Rows(x).Cells("IdSeccion").Value = a.Seccion.IdSeccion
                .Rows(x).Cells("Seccion").Value = a.Seccion.Seccion
                .Rows(x).Cells("EstablecerPrecio").Value = a.Seccion.EstablecerPrecio
                .Rows(x).Cells("ActualizarPrecio").Value = a.ActualizarPrecio
                .Rows(x).Cells("StockC").Value = a.StockC
                .Rows(x).Cells("StockF").Value = a.StockF
                .Rows(x).Cells("CodiLP").Value = a.ListaPrecios.CodiLP
                .Rows(x).Cells("ListaPrecios").Value = a.ListaPrecios.ListaPrecios
                .Rows(x).Cells("Laboratorio").Value = a.Laboratorio.Laboratorio
            End With
            x += 1
        Next
        Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(0).Cells(3)

    End Sub
    Private Sub FrmBuscaPersonas_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.FormularioCargado = False
        Me.CargarDatosEnDataGridView()
        Me.FormularioCargado = True
        Me.ActualizarDatosAdicionales()
    End Sub

    Private Sub ActualizarDatosAdicionales()
        Try

            If Me.DataGridView1.CurrentRow Is Nothing OrElse FormularioCargado = False Then
                Me.DataGridView1.DataSource = Nothing
                Exit Sub
            End If

            Dim IdArticulo As String = Me.DataGridView1.CurrentRow.Cells("IdArticulo").Value.ToString

            Dim a As Articulo = Me.Articulos.FirstOrDefault(Function(x) x.IdArticulo = IdArticulo)

            If a Is Nothing Then Exit Sub

            Me.Monodroga.Text = a.Monodroga.Monodroga
            Me.AccionFarmacologica.Text = a.AccionFarmacologica.AccionFarmacologica
            If a.GTIN <> "" Then Me.Trazabilidad.Text = "SI" Else Me.Trazabilidad.Text = "NO"
            Me.TipoControl.Text = a.TipoControl.Descripcion
            Me.TipoVenta.Text = a.TipoVenta.Descripcion
            Me.ViaAdministracion.Text = a.ViaAdministracion.ViaAdministracion
            If a.Heladera = True Then Me.Heladera.Text = "SI" Else Me.Heladera.Text = "NO"

        Catch ex As Exception

        End Try

    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        Me.ActualizarDatosAdicionales()
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