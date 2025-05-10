Imports System.ComponentModel
Imports SiCoFa.Entidades
Imports SiCoFa.Negocio
Public Class FrmArticulos
    Property TextoBuscar As String
    Property NuevoArticulo As Boolean

    Private mobj_N_AdminSiCoFa As New cls_N_AdminSiCoFa
    Private ControlesReadOnly As New List(Of String)
    Private Sub ObtenerAlicuotasIVA()

        Try
            With Me.AlicuotaIVA
                .DataSource = mobj_N_AdminSiCoFa.AlicuotasIVA
                .ValueMember = "AlicIVA"
                .DisplayMember = "AlicuotaIVA"
                .SelectedIndex = -1
            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Private Sub ObtenerSecciones()

        Try
            With Me.Seccion
                .DataSource = mobj_N_AdminSiCoFa.ListarSecciones("*")
                .ValueMember = "IdSeccion"
                .DisplayMember = "Seccion"
                .SelectedIndex = -1
            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Private Function BuscarArticulo(ByVal argTextoBuscado As String) As Articulo

        Try

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
                    FrmBuscaArticulos.Articulos = la
                    FrmBuscaArticulos.ShowDialog()

                    If FrmBuscaArticulos.ArticuloSeleccionado IsNot Nothing Then
                        a = FrmBuscaArticulos.ArticuloSeleccionado
                    End If
                    FrmBuscaArticulos.Close()
            End Select

            Return a
            a = Nothing

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
            Return Nothing

        End Try

    End Function
    Private Sub MostrarArticulo(ByVal argArticulo As Articulo)

        Try
            With Me
                .IdArticulo.Text = argArticulo.IdArticulo
                .Nombre.Text = argArticulo.Nombre
                .Codigo.Text = argArticulo.Codigo
                .CodBarra.Text = argArticulo.CodBarra
                .AlicuotaIVA.Text = argArticulo.AlicuotaIVA.AlicuotaIVA
                .Baja.SelectedIndex = If(argArticulo.Baja, 1, 0)
                .Seccion.Text = argArticulo.Seccion.Seccion
            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Private Sub FrmArticulos_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.ObtenerAlicuotasIVA()
        Me.ObtenerSecciones()
    End Sub
    Private Sub Guardar_Click(sender As Object, e As EventArgs) Handles Guardar.Click
        Try

            Me.ValidarCampos(ControlesReadOnly)

            If Me.ValidacionOK = False Then
                Exit Sub
            End If

            If Me.NuevoArticulo = True Then
                Dim IdArticulo As String = mobj_N_AdminSiCoFa.InsertarArticulo(Me.Codigo.Text, Me.CodBarra.Text, Me.Nombre.Text, Me.AlicuotaIVA.SelectedValue, Me.Seccion.SelectedValue)
                If IdArticulo <> "" Then
                    Me.IdArticulo.Text = IdArticulo
                    Me.Nombre.Text = UCase(Me.Nombre.Text)
                    MsgBox("Se dio de alta el Articulo " & Nombre.Text, vbInformation, "SiCoFa")
                Else
                    MsgBox("Ocurrio un error, intente nuevamente", vbCritical, "SiCoFa")
                    Exit Sub
                End If
                Me.NuevoArticulo = False
            Else
                If Me.IdArticulo.Text = "" Then
                    MsgBox("El Articulo " & Me.Nombre.Text & " no fue dado de Alta", vbInformation, "SiCoFa")
                    Exit Sub
                End If

                Dim baja As Boolean = If(Me.Baja.SelectedItem.ToString() = "SI", True, False)
                Dim Actualizado As Boolean = mobj_N_AdminSiCoFa.ActualizarArticulo(Me.IdArticulo.Text, Me.Codigo.Text, Me.CodBarra.Text, Me.Nombre.Text, Me.AlicuotaIVA.SelectedValue, baja, Me.Seccion.SelectedValue)

                If Actualizado = True Then
                    MsgBox("El Articulo " & Nombre.Text & " se acutalizo correctamente", vbInformation, "SiCoFa")
                Else
                    MsgBox("Ocurrio un error, intente nuevamente", vbCritical, "SiCoFa")
                    Exit Sub
                End If
            End If

            Me.LimpiarFormulario()
            Me.Nombre.Select()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Private Sub Nuevo_Click(sender As Object, e As EventArgs) Handles Nuevo.Click
        Try

            Me.LimpiarFormulario()

            Me.NuevoArticulo = True

            Dim valoresDefecto As New Dictionary(Of String, Object)
            With valoresDefecto
                .Add("Baja", "NO")
            End With

            EstablecerValoresPorDefecto(Me, valoresDefecto)

            With Me.ControlesReadOnly
                .Add("IdArticulo")
                .Add("Baja")
            End With

            Me.EstablecerReadOnly(ControlesReadOnly)

            Me.Nombre.Select()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Private Sub Buscar_Click_1(sender As Object, e As EventArgs) Handles Buscar.Click

        Try
            Dim str = InputBox("Ingrese el articulo buscado", "SiCoFa")
            Me.TextoBuscar = ""

            If str = "" Then
                Me.Nombre.Select()
                Exit Sub
            Else
                Me.TextoBuscar = str
            End If

            If Me.TextoBuscar = "" Then
                Exit Sub
            End If

            Dim a As Articulo = BuscarArticulo(Me.TextoBuscar)

            If a Is Nothing Then
                Exit Sub
            End If

            With Me
                .LimpiarFormulario()
                .MostrarArticulo(a)
                .Nombre.Select()
                .Nombre.SelectAll()
            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Private Sub Limpiar_Click(sender As Object, e As EventArgs) Handles Limpiar.Click
        Try

            Me.LimpiarFormulario()
            Me.NuevoArticulo = False
            Me.ControlesReadOnly.Clear()

            With Me.ControlesReadOnly
                .Add("IdArticulo")
            End With

            Me.EstablecerReadOnly(ControlesReadOnly)
            Me.Nombre.Select()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Private Sub Nombre_Validating(sender As Object, e As CancelEventArgs) Handles Nombre.Validating
        Try
            If Me.Nombre.Text = "" Or Me.NuevoArticulo = True Or Me.IdArticulo.Text <> "" Then
                Exit Sub
            End If

            Dim art As Articulo = Me.BuscarArticulo(Me.Nombre.Text)

            If art Is Nothing Then
                Me.Nombre.Select()
                Me.Nombre.Text = ""
                Exit Sub
            End If

            With Me
                .LimpiarFormulario()
                .MostrarArticulo(art)
                .Nombre.Select()
                .Nombre.SelectAll()
            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
End Class