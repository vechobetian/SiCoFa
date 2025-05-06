Imports SiCoFa.Entidades
Imports SiCoFa.Negocio
Public Class FrmArticulos
    Property TextoBuscar As String
    Property NuevoArticulo As Boolean

    Private mobj_N_AdminSiCoFa As New cls_N_AdminSiCoFa
    Private ControlesReadOnly As New List(Of String)
    Private Sub ObtenerAlicuotasIVA()
        With Me.AlicuotaIVA
            .DataSource = mobj_N_AdminSiCoFa.AlicuotasIVA
            .ValueMember = "AlicIVA"
            .DisplayMember = "AlicuotaIVA"
            .SelectedIndex = -1
        End With
    End Sub
    Private Sub ObtenerSecciones()
        With Me.Seccion
            .DataSource = mobj_N_AdminSiCoFa.ListarSecciones("*")
            .ValueMember = "IdSeccion"
            .DisplayMember = "Seccion"
            .SelectedIndex = -1
        End With
    End Sub
    Private Function BuscarArticulo(ByVal argTextoBuscado As String) As Articulo
        Dim la As List(Of Articulo) = mobj_N_AdminSiCoFa.ListarArticulos(argTextoBuscado)
        Dim a As Articulo = Nothing

        If la Is Nothing Then
            MsgBox("Articulo no Encontrado", vbInformation, "SiCoFa")
            Return Nothing
            Exit Function
        End If

        Select Case la.Count
            Case 0
                MsgBox("Articulo no Encontrado", vbInformation, "SiCoFa")
                Return Nothing
                Exit Function
            Case 1
                a = la.First
            Case > 1
                'FrmBuscaPersonas.Personas = le
                'FrmBuscaPersonas.ShowDialog()

                'If FrmBuscaPersonas.PersonaSeleccionado IsNot Nothing Then
                'Dim p = FrmBuscaPersonas.PersonaSeleccionado
                'e = New Empleado(p.Id, p.Nombre, p.Domicilio, p.Localidad, p.Provincia, p.Telefono, p.Email, p.Documento.TipoDoc.CodiTDoc, p.Documento.Numero, p.FechaAlta, p.Estado)
                'End If
                'FrmBuscaPersonas.Close()
        End Select

        Return a
        a = Nothing

    End Function
    Private Sub MostrarEmpleado(ByVal argArticulo As Articulo)
        With Me
            .IdArticulo.Text = argArticulo.IdArticulo
            .Nombre.Text = argArticulo.Nombre
            .Codigo.Text = argArticulo.Codigo
            .CodBarra.Text = argArticulo.CodBarra

        End With
    End Sub
    Private Sub FrmArticulos_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.ObtenerAlicuotasIVA()
        Me.ObtenerSecciones()
    End Sub
    Private Sub Nuevo_Click(sender As Object, e As EventArgs) Handles Nuevo.Click
        Me.NuevoArticulo = True

        Dim valoresDefecto As New Dictionary(Of String, Object)
        With valoresDefecto
            .Add("Baja", "NO")
        End With

        EstablecerValoresPorDefecto(valoresDefecto)

        With Me.ControlesReadOnly
            .Add("IdArticulo")
            .Add("Baja")
        End With

        Me.EstablecerReadOnly(ControlesReadOnly)

        Me.Nombre.Select()
    End Sub
    Private Sub Limpiar_Click(sender As Object, e As EventArgs) Handles Limpiar.Click
        Me.LimpiarFormulario()
        Me.ControlesReadOnly.Clear()

        With Me.ControlesReadOnly
            .Add("IdArticulo")
        End With

        Me.EstablecerReadOnly(ControlesReadOnly)
        Me.Nombre.Select()
    End Sub

End Class