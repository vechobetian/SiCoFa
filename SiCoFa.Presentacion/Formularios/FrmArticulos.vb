Imports System.ComponentModel
Imports SiCoFa.Entidades
Imports SiCoFa.Negocio
Public Class FrmArticulos
    Private TextoBuscar As String
    Private NuevoArticulo As Boolean
    Private mobj_AdminSicofa As New cls_N_AdminSiCoFa
    Private ControlesReadOnly As New List(Of String)
    Private Sub ObtenerAlicuotasIVA()

        Try
            With Me.AlicuotaIVA
                .DataSource = mobj_AdminSicofa.AlicuotasIVA
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
                .DataSource = mobj_AdminSicofa.ListarSecciones("*")
                .ValueMember = "IdSeccion"
                .DisplayMember = "Seccion"
                .SelectedIndex = -1
            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Private Sub BuscarArticulo(ByVal argTextoBuscado As String)

        Try

            Dim la As List(Of Articulo) = mobj_AdminSicofa.ListarArticulos(argTextoBuscado)
            Dim a As Articulo = Nothing

            If la Is Nothing Then
                MsgBox("Articulo no Encontrado", vbInformation, "SiCoFa")
                Exit Sub
            End If

            Select Case la.Count
                Case 0
                    MsgBox("Articulo no Encontrado", vbInformation, "SiCoFa")
                    Me.Nombre.Text = ""
                    Me.Nombre.Select()
                    Exit Sub

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
    Private Sub MostrarArticulo(ByVal argArticulo As Articulo)

        Try
            If argArticulo Is Nothing Then
                Exit Sub
            End If

            With Me
                .IdArticulo.Text = argArticulo.IdArticulo
                .Nombre.Text = argArticulo.Nombre
                .Codigo.Text = argArticulo.Codigo
                .CodBarras.Text = argArticulo.CodBarras
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

            Me.ValidarCampos(Me, ControlesReadOnly)

            If Me.ValidacionOK = False Then
                Exit Sub
            End If

            If Me.NuevoArticulo = True Then
                Dim IdArticulo As String = mobj_AdminSicofa.InsertarArticulo(Me.Codigo.Text, Me.CodBarras.Text, Me.Nombre.Text, Me.AlicuotaIVA.SelectedValue, Me.Seccion.SelectedValue)
                If IdArticulo <> "" Then
                    Me.IdArticulo.Text = IdArticulo
                    Me.Nombre.Text = UCase(Me.Nombre.Text)
                    MsgBox("Se dio de alta el Articulo " & Nombre.Text, vbInformation, "SiCoFa")
                Else
                    MsgBox("Ocurrio un error, intente nuevamente", vbCritical, "SiCoFa")
                    Exit Sub
                End If
                Me.NuevoArticulo = False
                Me.Nuevo.Checked = False

            Else
                If Me.IdArticulo.Text = "" Then
                    MsgBox("El Articulo " & Me.Nombre.Text & " no fue dado de Alta", vbInformation, "SiCoFa")
                    Exit Sub
                End If

                Dim baja As Boolean = If(Me.Baja.SelectedItem.ToString() = "SI", True, False)
                Dim Actualizado As Boolean = mobj_AdminSicofa.ActualizarArticulo(Me.IdArticulo.Text, Me.Codigo.Text, Me.CodBarras.Text, Me.Nombre.Text, Me.AlicuotaIVA.SelectedValue, baja, Me.Seccion.SelectedValue)

                If Actualizado = True Then
                    MsgBox("El Articulo " & Nombre.Text & " se acutalizo correctamente", vbInformation, "SiCoFa")
                Else
                    MsgBox("Ocurrio un error, intente nuevamente", vbCritical, "SiCoFa")
                    Exit Sub
                End If
            End If


            With Me.ControlesReadOnly
                .Clear()
                .Add("IdArticulo")
            End With

            Me.EstablecerReadOnly(Me, ControlesReadOnly)
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
            Me.Nuevo.Checked = True

            Dim valoresDefecto As New Dictionary(Of String, Object)
            With valoresDefecto
                .Add("Baja", "NO")
            End With

            EstablecerValoresPorDefecto(Me, valoresDefecto)

            With Me.ControlesReadOnly
                .Add("IdArticulo")
                .Add("Baja")
            End With

            Me.EstablecerReadOnly(Me, ControlesReadOnly)

            Me.Nombre.Select()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Private Sub Buscar_Click_1(sender As Object, e As EventArgs) Handles Buscar.Click

        Try
            If NuevoArticulo = True Then
                Exit Sub
            End If

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

            Me.BuscarArticulo(Me.TextoBuscar)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Private Sub Limpiar_Click(sender As Object, e As EventArgs) Handles Limpiar.Click
        Try

            Me.LimpiarFormulario()
            Me.NuevoArticulo = False
            Me.Nuevo.Checked = False
            Me.ControlesReadOnly.Clear()

            With Me.ControlesReadOnly
                .Add("IdArticulo")
            End With

            Me.EstablecerReadOnly(Me, ControlesReadOnly)
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

            Me.BuscarArticulo(Me.Nombre.Text)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

End Class