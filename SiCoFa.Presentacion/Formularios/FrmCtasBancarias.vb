Imports SiCoFa.Negocio
Imports SiCoFa.Entidades
Imports System.ComponentModel

Public Class FrmCtasBancarias

    Private TextoBuscar As String
    Private NuevaCB As Boolean
    Private mobj_AdminSicofa As New N_AdminSiCoFa
    Private mobj_CuentaBancaria As CuentaBancaria

    Private ControlesReadOnly As New List(Of String) From {"IdCBTextBox", "FechaAltaTextBox"}

    Private Sub ObtenerOpcionesBoolean()
        '
        Dim listaBooleanos As New List(Of OpcionBoolean) From {
            New OpcionBoolean("No", False),
            New OpcionBoolean("Sí", True)
        }

        BajaComboBox.DataSource = listaBooleanos
        BajaComboBox.DisplayMember = "Texto"
        BajaComboBox.ValueMember = "Valor"

    End Sub

    Private Sub DesvincularControles()
        IdCBTextBox.DataBindings.Clear()
        DescripcionTextBox.DataBindings.Clear()
        NumCuentaTextBox.DataBindings.Clear()
        FechaAltaTextBox.DataBindings.Clear()
        BajaComboBox.DataBindings.Clear()
    End Sub

    Private Sub VincularControles()
        ' Primero limpiás los bindings
        IdCBTextBox.DataBindings.Clear()
        DescripcionTextBox.DataBindings.Clear()
        NumCuentaTextBox.DataBindings.Clear()
        FechaAltaTextBox.DataBindings.Clear()
        BajaComboBox.DataBindings.Clear()

        ' Luego volvés a enlazarlos
        IdCBTextBox.DataBindings.Add("Text", mobj_CuentaBancaria, "IdCB")
        DescripcionTextBox.DataBindings.Add("Text", mobj_CuentaBancaria, "Descripcion")
        NumCuentaTextBox.DataBindings.Add("Text", mobj_CuentaBancaria, "NumCuenta")
        FechaAltaTextBox.DataBindings.Add("Text", mobj_CuentaBancaria, "FechaAlta", True, DataSourceUpdateMode.OnPropertyChanged, "", "dd/MM/yyyy")
        BajaComboBox.DataBindings.Add("SelectedValue", mobj_CuentaBancaria, "Baja", True, DataSourceUpdateMode.OnPropertyChanged)
    End Sub

    Private Function SeleccionarCuentaListado(ByVal argIdCB As Int32, ByVal argListaCuentas As List(Of CuentaBancaria)) As CuentaBancaria

        Try
            Dim CuentaSeleccionada As CuentaBancaria = Nothing

            For Each cb As CuentaBancaria In argListaCuentas
                If cb.IdCB = argIdCB Then
                    CuentaSeleccionada = cb
                    Exit For ' Opcional: detener la búsqueda una vez encontrado el cliente
                End If
            Next

            Return CuentaSeleccionada

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
            Return Nothing
        End Try

    End Function

    Private Sub BuscarCuentaBancaria(ByVal argTextoBuscado As String)

        Try

            Dim lcb As List(Of CuentaBancaria) = mobj_AdminSicofa.ListarCuentasBancarias(argTextoBuscado)
            Dim cb As CuentaBancaria = Nothing

            If lcb Is Nothing Then
                MsgBox("Cuenta no Encontrada", vbInformation, "SiCoFa")
                Exit Sub
            End If

            Select Case lcb.Count
                Case 0
                    MsgBox("Cuenta no Encontrada", vbInformation, "SiCoFa")
                    Me.DescripcionTextBox.Text = ""
                    Me.DescripcionTextBox.Select()
                    Exit Sub
                Case 1
                    cb = lcb.First

                Case > 1
                    Using f As New FrmSelectorUniversal
                        f.Text = "Cuentas Bancarias"
                        f.Objetos = lcb
                        f.NombrePropiedadId = "IdCB"
                        f.NombrePropiedadDescripcion = "Descripcion"
                        f.HeaderPropiedadDescripcion = "Cuenta"
                        If f.ShowDialog() = DialogResult.OK Then
                            cb = Me.SeleccionarCuentaListado(f.Valor1Seleccionado, lcb)
                        Else
                            Me.DescripcionTextBox.Text = ""
                            Me.DescripcionTextBox.Select()
                            Exit Sub

                        End If
                    End Using ' <- aquí se libera completamente
            End Select


            With Me.ControlesReadOnly
                .Clear()
                .Add("IdCBTextBox")
                .Add("DescripcionTextBox")
                .Add("FechaAltaTextBox")
            End With

            Me.EstablecerReadOnly(Me, ControlesReadOnly)

            With Me
                .LimpiarFormulario()
                mobj_CuentaBancaria = cb
                Me.VincularControles()
                .DescripcionTextBox.Select()
                .DescripcionTextBox.SelectAll()
            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Private Sub FrmCtasBancarias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ObtenerOpcionesBoolean()
    End Sub

    Private Sub Guardar_Click(sender As Object, e As EventArgs) Handles Guardar.Click
        Try

            Me.ValidarCampos(Me, ControlesReadOnly)

            If Me.ValidacionOK = False Then
                Exit Sub
            End If

            If Me.NuevaCB = True Then

                Dim valoresDefecto As New Dictionary(Of String, Object)
                With valoresDefecto
                    .Add("FechaAltaTextBox", Date.Today.ToShortDateString)
                    .Add("BajaTextBox", "NO")
                End With

                EstablecerValoresPorDefecto(Me, valoresDefecto)

                Dim Idcb As Int32 = mobj_AdminSicofa.InsertarCuentaBancaria(mobj_CuentaBancaria.Descripcion, mobj_CuentaBancaria.NumCuenta)
                If Idcb > 0 Then
                    Me.IdCBTextBox.Text = Idcb
                    Me.DescripcionTextBox.Text = UCase(Me.DescripcionTextBox.Text)
                    MsgBox("Se dio de alta la cuenta " & Me.DescripcionTextBox.Text, vbInformation, "SiCoFa")
                Else
                    MsgBox("Ocurrio un error, intente nuevamente", vbCritical, "SiCoFa")
                    Exit Sub
                End If
                Me.NuevaCB = False
                Me.Nuevo.Checked = False

            Else
                If Me.IdCBTextBox.Text = "" Then
                    MsgBox("La cuenta " & Me.DescripcionTextBox.Text & " no fue dada de Alta", vbInformation, "SiCoFa")
                    Exit Sub
                End If

                Dim Actualizado As Boolean = mobj_AdminSicofa.ActualizarCuentaBancaria(mobj_CuentaBancaria.IdCB, mobj_CuentaBancaria.Baja)

                If Actualizado = True Then
                    MsgBox("La cuenta " & Me.DescripcionTextBox.Text & " se acutalizo correctamente", vbInformation, "SiCoFa")
                Else
                    MsgBox("Ocurrio un error, intente nuevamente", vbCritical, "SiCoFa")
                    Exit Sub
                End If
            End If

            With Me.ControlesReadOnly
                .Clear()
                .Add("IdCBTextBox")
                .Add("FechaAltaTextBox")
            End With

            Me.EstablecerReadOnly(Me, ControlesReadOnly)
            Me.LimpiarFormulario()
            mobj_CuentaBancaria = Nothing
            DesvincularControles()
            Me.DescripcionTextBox.Select()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub Nuevo_Click(sender As Object, e As EventArgs) Handles Nuevo.Click

        mobj_CuentaBancaria = Nothing
        DesvincularControles()
        Me.LimpiarFormulario()
        Me.NuevaCB = True
        Me.Nuevo.Checked = True
        Me.DescripcionTextBox.Select()

    End Sub

    Private Sub Buscar_Click(sender As Object, e As EventArgs) Handles Buscar.Click
        Try
            If NuevaCB = True Then
                Exit Sub
            End If

            Dim str = InputBox("Ingrese la Seccion buscada", "SiCoFa")
            Me.TextoBuscar = ""

            If str = "" Then
                Me.DescripcionTextBox.Select()
                Exit Sub
            Else
                Me.TextoBuscar = str
            End If

            If Me.TextoBuscar = "" Then
                Exit Sub
            End If

            Me.BuscarCuentaBancaria(Me.TextoBuscar)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub Limpiar_Click(sender As Object, e As EventArgs) Handles Limpiar.Click

        mobj_CuentaBancaria = Nothing
        Me.LimpiarFormulario()
        Me.NuevaCB = False
        Me.DescripcionTextBox.Select()

    End Sub

    Private Sub Descripcion_Validating(sender As Object, e As CancelEventArgs) Handles DescripcionTextBox.Validating
        Try
            If Me.DescripcionTextBox.Text = "" Or Me.NuevaCB = True Or Me.IdCBTextBox.Text <> "" Then
                Exit Sub
            End If

            Me.BuscarCuentaBancaria(Me.DescripcionTextBox.Text)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
End Class
