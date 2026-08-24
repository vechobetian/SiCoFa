Imports System.ComponentModel
Imports SiCoFa.Entidades
Imports SiCoFa.Negocio

Public Class FrmFraccionables
    Private TextoBuscar As String
    Private mobj_AdminArticulos As New N_AdminArticulos
    Private ControlesReadOnly As New List(Of String)
    Private DatosOpcionales As New List(Of String) From {}

    Private Sub CargarSelectorFraccionable()

        With UcFraccionable
            .Objetos = Buleano.Lista
            .NombrePropiedadId = "Valor"
            .NombrePropiedadDescripcion = "Fraccionable"
            .TituloSelector = "Articulo Fraccionable"
            .HeaderDescripcion = "Fraccionable"
            .ValorPredeterminado = 0
            .TextoPredeterminado = "NO"
            .PermitirVacio = False
        End With

    End Sub

    Private Sub BuscarArticulo(ByVal argTextoBuscado As String)

        Try

            Dim la As List(Of Articulo) = mobj_AdminArticulos.ListarArticulos(argTextoBuscado)
            Dim a As Articulo = Nothing

            If la Is Nothing Then
                MsgBox("Articulo no Encontrado", vbInformation, "SiCoFa")
                Exit Sub
            End If

            Select Case la.Count
                Case 0
                    MsgBox("Articulo no Encontrado", vbInformation, "SiCoFa")
                    Me.TxtNombre.Text = ""
                    Me.TxtNombre.Select()
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
                .TxtNombre.Select()
                .TxtNombre.SelectAll()
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
                .TxtIdArticulo.Text = argArticulo.IdArticulo
                .TxtNombre.Text = argArticulo.Nombre
                Dim blnFraccionable As Buleano = New Buleano(argArticulo.Fraccionable)
                .UcFraccionable.Asignar(blnFraccionable.Valor, blnFraccionable.Descripcion)
                .TxtUDiv.Text = argArticulo.UDiv
                .TxtDFrac.Text = argArticulo.DFrac
                .TxtRecargo.Text = argArticulo.RFrac
            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub FrmArticulos_Load(sender As Object, e As EventArgs) Handles Me.Load

        With Me.ControlesReadOnly
            .Clear()
            .Add("IdArticulo")
        End With

        Me.EstablecerReadOnly(Me, ControlesReadOnly)
        Me.CargarSelectorFraccionable()

    End Sub

    Private Sub Guardar_Click(sender As Object, e As EventArgs) Handles Guardar.Click
        Try

            Me.ValidarCampos(Me, DatosOpcionales)

            If Me.ValidacionOK = False Then
                Exit Sub
            End If

            If Me.TxtIdArticulo.Text = "" Then
                MsgBox("El Articulo " & Me.TxtNombre.Text & " no fue dado de Alta", vbInformation, "SiCoFa")
                Exit Sub
            End If

            Dim adminDB As New N_AdminDB
            Dim frac As Boolean = CBool(UcFraccionable.Id)
            Dim unid As Integer = CInt(Me.TxtUDiv.Text)
            Dim desc As String = CStr(TxtDFrac.Text)
            Dim rec As Decimal = CDec(TxtRecargo.Text)

            Dim str As String = $"UPDATE articulos SET Fraccionable={frac},UDiv={unid},DFrac={desc},RFrac={rec}"
            Dim Actualizado As Boolean = adminDB.ActualizarTablaUpdate(str)

            If Actualizado = True Then
                MsgBox("El Articulo " & TxtNombre.Text & " se acutalizo correctamente", vbInformation, "SiCoFa")
            Else
                MsgBox("Ocurrio un error, intente nuevamente", vbCritical, "SiCoFa")
                Exit Sub
            End If



            With Me.ControlesReadOnly
                .Clear()
                .Add("IdArticulo")
            End With

            Me.EstablecerReadOnly(Me, ControlesReadOnly)
            Me.LimpiarFormulario()
            Me.TxtNombre.Select()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub Buscar_Click_1(sender As Object, e As EventArgs) Handles Buscar.Click

        Try

            Dim str = InputBox("Ingrese el articulo buscado", "SiCoFa")
            Me.TextoBuscar = ""

            If str = "" Then
                Me.TxtNombre.Select()
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
            Me.ControlesReadOnly.Clear()

            With Me.ControlesReadOnly
                .Add("IdArticulo")
            End With

            Me.EstablecerReadOnly(Me, ControlesReadOnly)
            Me.TxtNombre.Select()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub Nombre_Validating(sender As Object, e As CancelEventArgs) Handles TxtNombre.Validating
        Try
            If Me.TxtNombre.Text = "" Or Me.TxtIdArticulo.Text <> "" Then
                Exit Sub
            End If

            Me.BuscarArticulo(Me.TxtNombre.Text)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

End Class