Imports SiCoFa.Entidades
Imports SiCoFa.Negocio
Imports System.ComponentModel

Public Class FrmSecciones
    Private TextoBuscar As String
    Private NuevaSeccion As Boolean
    Private mobj_N_AdminSiCoFa As New cls_N_AdminSiCoFa
    Private ControlesReadOnly As New List(Of String)
    Private Function SeleccionarSeccionListado(ByVal IdSeccion As String, ByVal ListaSecciones As List(Of Seccion)) As Seccion

        Try
            Dim SeccionSeleccionada As Seccion = Nothing

            For Each s As Seccion In ListaSecciones
                If s.IdSeccion = IdSeccion Then
                    SeccionSeleccionada = s
                    Exit For ' Opcional: detener la búsqueda una vez encontrado el cliente
                End If
            Next
            Return SeccionSeleccionada

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
            Return Nothing
        End Try

    End Function

    Private Sub BuscarSeccion(ByVal argTextoBuscado As String)

        Try

            Dim ls As List(Of Seccion) = mobj_N_AdminSiCoFa.ListarSecciones(argTextoBuscado)
            Dim s As Seccion = Nothing

            If ls Is Nothing Then
                MsgBox("Seccion no Encontrada", vbInformation, "SiCoFa")
                Exit Sub
            End If

            Select Case ls.Count
                Case 0
                    MsgBox("Seccion no Encontrada", vbInformation, "SiCoFa")
                    Me.Seccion.Text = ""
                    Me.Seccion.Select()
                    Exit Sub
                Case 1
                    s = ls.First
                Case > 1
                    Using f As New FrmSelectorUniversal
                        f.Text = "Secciones"
                        f.Objetos = ls
                        f.NombrePropiedadId = "IdSeccion"
                        f.NombrePropiedadDescripcion = "Seccion"
                        f.HeaderPropiedadDescripcion = "Seccion"
                        If f.ShowDialog() = DialogResult.OK Then
                            s = Me.SeleccionarSeccionListado(f.Valor1Seleccionado, ls)
                        End If
                        f.Close()
                    End Using ' <- aquí se libera completamente
            End Select

            With Me
                .LimpiarFormulario()
                .MostrarSeccion(s)
                .Seccion.Select()
                .Seccion.SelectAll()
            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Private Sub MostrarSeccion(ByVal argSeccion As Seccion)

        Try
            If argSeccion Is Nothing Then
                Exit Sub
            End If

            With Me
                .IdSeccion.Text = argSeccion.IdSeccion
                .Seccion.Text = argSeccion.Seccion
                .EstablecerPrecio.SelectedIndex = If(argSeccion.EstablecerPrecio, 1, 0)
            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Private Sub Guardar_Click(sender As Object, e As EventArgs) Handles Guardar.Click
        Try

            Me.ValidarCampos(Me, ControlesReadOnly)

            If Me.ValidacionOK = False Then
                Exit Sub
            End If

            If Me.NuevaSeccion = True Then
                Dim establecer_precio As Boolean = If(Me.EstablecerPrecio.SelectedItem.ToString() = "SI", True, False)
                Dim IdSeccion As String = mobj_N_AdminSiCoFa.InsertarSecciones(Me.Seccion.Text, establecer_precio)
                If IdSeccion <> "" Then
                    Me.IdSeccion.Text = IdSeccion
                    Me.Seccion.Text = UCase(Me.Seccion.Text)
                    MsgBox("Se dio de alta la Seccion " & Me.Seccion.Text, vbInformation, "SiCoFa")
                Else
                    MsgBox("Ocurrio un error, intente nuevamente", vbCritical, "SiCoFa")
                    Exit Sub
                End If
                Me.NuevaSeccion = False
                Me.Nuevo.Checked = False

            Else
                If Me.IdSeccion.Text = "" Then
                    MsgBox("La Seccion " & Me.Seccion.Text & " no fue dada de Alta", vbInformation, "SiCoFa")
                    Exit Sub
                End If

                Dim establecer_precio As Boolean = If(Me.EstablecerPrecio.SelectedItem.ToString() = "SI", True, False)
                Dim Actualizado As Boolean = mobj_N_AdminSiCoFa.ActualizarSeccion(Me.IdSeccion.Text, Me.Seccion.Text, establecer_precio)

                If Actualizado = True Then
                    MsgBox("La seccion " & Me.Seccion.Text & " se acutalizo correctamente", vbInformation, "SiCoFa")
                Else
                    MsgBox("Ocurrio un error, intente nuevamente", vbCritical, "SiCoFa")
                    Exit Sub
                End If
            End If

            With Me.ControlesReadOnly
                .Clear()
                .Add("IdSeccion")
            End With

            Me.EstablecerReadOnly(Me, ControlesReadOnly)
            Me.LimpiarFormulario()
            Me.Seccion.Select()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Private Sub Nuevo_Click(sender As Object, e As EventArgs) Handles Nuevo.Click
        Try

            Me.LimpiarFormulario()

            Me.NuevaSeccion = True
            Me.Nuevo.Checked = True

            With Me.ControlesReadOnly
                .Add("IdSeccion")
            End With

            Me.EstablecerReadOnly(Me, ControlesReadOnly)

            Me.Seccion.Select()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
        Private Sub Buscar_Click_1(sender As Object, e As EventArgs) Handles Buscar.Click

            Try
            If NuevaSeccion = True Then
                Exit Sub
            End If

            Dim str = InputBox("Ingrese la Seccion buscada", "SiCoFa")
            Me.TextoBuscar = ""

            If str = "" Then
                Me.Seccion.Select()
                Exit Sub
            Else
                Me.TextoBuscar = str
            End If

            If Me.TextoBuscar = "" Then
                Exit Sub
            End If

            Me.BuscarSeccion(Me.TextoBuscar)

        Catch ex As Exception
                MsgBox(ex.Message, vbCritical, "SiCoFa")

            End Try

        End Sub
        Private Sub Limpiar_Click(sender As Object, e As EventArgs) Handles Limpiar.Click

        Try

            Me.LimpiarFormulario()
            Me.NuevaSeccion = False
            Me.Nuevo.Checked = False
            Me.ControlesReadOnly.Clear()

            With Me.ControlesReadOnly
                .Add("IdSeccion")
            End With

            Me.EstablecerReadOnly(Me, ControlesReadOnly)
            Me.Seccion.Select()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Private Sub Seccion_Validating(sender As Object, e As CancelEventArgs) Handles Seccion.Validating
        Try
            If Me.Seccion.Text = "" Or Me.NuevaSeccion = True Or Me.IdSeccion.Text <> "" Then
                Exit Sub
            End If

            Me.BuscarSeccion(Me.Seccion.Text)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
End Class
