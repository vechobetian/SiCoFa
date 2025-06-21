Imports SiCoFa.Entidades
Imports SiCoFa.Negocio
Imports System.ComponentModel

Public Class FrmMediosPE

    Private TextoBuscar As String
    Private NuevoMedioPE As Boolean
    Private mAdminMediosPE As New N_AdminMediosPE

    Private ControlesNoValidar As New List(Of String) From {"IdMPETextBox"}

    Private Sub ObtenerOpcionesBoolean()

        Dim listaBooleanos As New List(Of OpcionBoolean) From {
            New OpcionBoolean("No", False),
            New OpcionBoolean("Sí", True)
        }

        BajaComboBox.DataSource = listaBooleanos
        BajaComboBox.DisplayMember = "Texto"
        BajaComboBox.ValueMember = "Valor"
        BajaComboBox.SelectedIndex = -1

    End Sub

    Private Sub ObtenerCuentasBancarias()

        Try
            Dim AdminCuentasBancarias As New N_AdminCuentasBancarias
            With Me.CuentaBancariaComboBox
                .DataSource = AdminCuentasBancarias.ListarCuentasBancarias("*")
                .ValueMember = "IdCB"
                .DisplayMember = "Descripcion"
                .SelectedIndex = -1
            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Function SeleccionarMedioPE(ByVal IdMPE As String, ByVal ListaMedioPE As List(Of MedioPE)) As MedioPE

        Try
            Dim MedioPESeleccionado As MedioPE = Nothing

            For Each mpe As MedioPE In ListaMedioPE
                If mpe.IdMPE = IdMPE Then
                    MedioPESeleccionado = mpe
                    Exit For ' Opcional: detener la búsqueda una vez encontrado el cliente
                End If
            Next
            Return MedioPESeleccionado

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
            Return Nothing
        End Try

    End Function

    Private Sub BuscarMedioPE(ByVal argTextoBuscado As String)

        Try

            Dim lmpe As List(Of MedioPE) = mAdminMediosPE.ListarMedioPE(argTextoBuscado)
            Dim mpe As MedioPE = Nothing

            If lmpe Is Nothing Then
                MsgBox("Medio de pago no encontrado", vbInformation, "SiCoFa")
                Exit Sub
            End If

            Select Case lmpe.Count
                Case 0
                    MsgBox("Medio de pago no Encontrado", vbInformation, "SiCoFa")
                    Me.DescripcionTextBox.Text = ""
                    Me.DescripcionTextBox.Select()
                    Exit Sub

                Case 1
                    mpe = lmpe.First

                Case > 1
                    Using f As New FrmSelectorUniversal
                        f.Text = "Medio de Pago Electronico"
                        f.Objetos = lmpe
                        f.NombrePropiedadId = "IdMPE"
                        f.NombrePropiedadDescripcion = "Descripcion"
                        f.HeaderPropiedadDescripcion = "Descripcion"
                        If f.ShowDialog() = DialogResult.OK Then
                            mpe = Me.SeleccionarMedioPE(f.Valor1Seleccionado, lmpe)
                        End If
                        f.Close()
                    End Using ' <- aquí se libera completamente
            End Select

            With Me
                .LimpiarFormulario()
                .MostrarMedioPE(mpe)
                .DescripcionTextBox.Select()
                .DescripcionTextBox.SelectAll()
            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub MostrarMedioPE(ByVal argMedioPE As MedioPE)

        Try
            If argMedioPE Is Nothing Then
                Exit Sub
            End If

            With Me
                .IdMPETextBox.Text = argMedioPE.IdMPE
                .DescripcionTextBox.Text = argMedioPE.Descripcion
                .CuentaBancariaComboBox.Text = argMedioPE.CuentaBancaria.Descripcion
                .BajaComboBox.SelectedIndex = argMedioPE.Baja
            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub Guardar_Click(sender As Object, e As EventArgs) Handles Guardar.Click
        Try

            Me.ValidarCampos(Me, ControlesNoValidar)

            If Me.ValidacionOK = False Then
                Exit Sub
            End If

            If Me.NuevoMedioPE = True Then
                Dim IdMPE As String = mAdminMediosPE.InsertarMedioPE(Me.DescripcionTextBox.Text, Me.CuentaBancariaComboBox.SelectedValue)
                If IdMPE <> "" Then
                    Me.IdMPETextBox.Text = IdMPE
                    Me.DescripcionTextBox.Text = UCase(Me.DescripcionTextBox.Text)
                    MsgBox("Se dio de alta " & Me.DescripcionTextBox.Text, vbInformation, "SiCoFa")
                Else
                    MsgBox("Ocurrio un error, intente nuevamente", vbCritical, "SiCoFa")
                    Exit Sub
                End If
                Me.NuevoMedioPE = False
                Me.Nuevo.Checked = False

            Else
                If Me.IdMPETextBox.Text = "" Then
                    MsgBox(Me.DescripcionTextBox.Text & " no fue dada de Alta", vbInformation, "SiCoFa")
                    Exit Sub
                End If

                Dim Actualizado As Boolean = mAdminMediosPE.ActualizarMedioPE(Me.IdMPETextBox.Text, Me.CuentaBancariaComboBox.SelectedValue, BajaComboBox.SelectedValue)

                If Actualizado = True Then
                    MsgBox(Me.DescripcionTextBox.Text & " se acutalizo correctamente", vbInformation, "SiCoFa")
                Else
                    MsgBox("Ocurrio un error, intente nuevamente", vbCritical, "SiCoFa")
                    Exit Sub
                End If
            End If

            Me.LimpiarFormulario()
            Me.DescripcionTextBox.Select()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub Nuevo_Click(sender As Object, e As EventArgs) Handles Nuevo.Click
        Try

            Me.LimpiarFormulario()

            Me.NuevoMedioPE = True
            Me.Nuevo.Checked = True
            Me.DescripcionTextBox.Select()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub Buscar_Click(sender As Object, e As EventArgs) Handles Buscar.Click

        Try
            If NuevoMedioPE = True Then
                Exit Sub
            End If

            Dim str = InputBox("Ingrese el texto buscado", "SiCoFa")
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

            Me.BuscarMedioPE(Me.TextoBuscar)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub Limpiar_Click(sender As Object, e As EventArgs) Handles Limpiar.Click

        Try

            Me.LimpiarFormulario()
            Me.NuevoMedioPE = False
            Me.Nuevo.Checked = False
            Me.DescripcionTextBox.Select()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub DescripcionTextBox_Validating(sender As Object, e As CancelEventArgs) Handles DescripcionTextBox.Validating
        Try
            If Me.DescripcionTextBox.Text = "" Or Me.NuevoMedioPE = True Or Me.IdMPETextBox.Text <> "" Then
                Exit Sub
            End If

            Me.BuscarMedioPE(Me.DescripcionTextBox.Text)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub FrmMediosPE_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.ObtenerCuentasBancarias()
        Me.ObtenerOpcionesBoolean()
    End Sub

    Private Sub CuentaBancariaComboBox_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles CuentaBancariaComboBox.Validating
        If CuentaBancariaComboBox.SelectedIndex = -1 Then
            MessageBox.Show("Debe seleccionar un elemento de la lista.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            e.Cancel = True ' Cancela el cambio de foco
        End If
    End Sub

End Class