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

        cmbBaja.DataSource = listaBooleanos
        cmbBaja.DisplayMember = "Texto"
        cmbBaja.ValueMember = "Valor"
        cmbBaja.SelectedIndex = -1

    End Sub

    Private Sub ObtenerCuentasBancarias()

        Try
            Dim AdminCuentasBancarias As New N_AdminCuentasBancarias
            With Me.cmbCuentaBancaria
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
                    Me.txtDescripcion.Text = ""
                    Me.txtDescripcion.Select()
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
                .txtDescripcion.Select()
                .txtDescripcion.SelectAll()
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
                .txtIdMPE.Text = argMedioPE.IdMPE
                .txtDescripcion.Text = argMedioPE.Descripcion
                .cmbCuentaBancaria.Text = argMedioPE.CuentaBancaria.Descripcion
                .cmbBaja.SelectedIndex = argMedioPE.Baja
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
                Dim IdMPE As String = mAdminMediosPE.InsertarMedioPE(Me.txtDescripcion.Text, Me.cmbCuentaBancaria.SelectedValue)
                If IdMPE <> "" Then
                    Me.txtIdMPE.Text = IdMPE
                    Me.txtDescripcion.Text = UCase(Me.txtDescripcion.Text)
                    MsgBox("Se dio de alta " & Me.txtDescripcion.Text, vbInformation, "SiCoFa")
                Else
                    MsgBox("Ocurrio un error, intente nuevamente", vbCritical, "SiCoFa")
                    Exit Sub
                End If
                Me.NuevoMedioPE = False
                Me.Nuevo.Checked = False

            Else
                If Me.txtIdMPE.Text = "" Then
                    MsgBox(Me.txtDescripcion.Text & " no fue dada de Alta", vbInformation, "SiCoFa")
                    Exit Sub
                End If

                Dim Actualizado As Boolean = mAdminMediosPE.ActualizarMedioPE(Me.txtIdMPE.Text, Me.cmbCuentaBancaria.SelectedValue, cmbBaja.SelectedValue)

                If Actualizado = True Then
                    MsgBox(Me.txtDescripcion.Text & " se acutalizo correctamente", vbInformation, "SiCoFa")
                Else
                    MsgBox("Ocurrio un error, intente nuevamente", vbCritical, "SiCoFa")
                    Exit Sub
                End If
            End If

            Me.LimpiarFormulario()
            Me.txtDescripcion.Select()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub Nuevo_Click(sender As Object, e As EventArgs) Handles Nuevo.Click
        Try

            Me.LimpiarFormulario()

            Me.NuevoMedioPE = True
            Me.Nuevo.Checked = True
            Me.txtDescripcion.Select()

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
                Me.txtDescripcion.Select()
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
            Me.txtDescripcion.Select()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub txtDescripcion_Validating(sender As Object, e As CancelEventArgs) Handles txtDescripcion.Validating
        Try
            If Me.txtDescripcion.Text = "" Or Me.NuevoMedioPE = True Or Me.txtIdMPE.Text <> "" Then
                Exit Sub
            End If

            Me.BuscarMedioPE(Me.txtDescripcion.Text)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub FrmMediosPE_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.ObtenerCuentasBancarias()
        Me.ObtenerOpcionesBoolean()
    End Sub

    Private Sub cmbCuentaBancaria_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbCuentaBancaria.Validating
        If cmbCuentaBancaria.SelectedIndex = -1 Then
            MessageBox.Show("Debe seleccionar un elemento de la lista.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            e.Cancel = True ' Cancela el cambio de foco
        End If
    End Sub

End Class