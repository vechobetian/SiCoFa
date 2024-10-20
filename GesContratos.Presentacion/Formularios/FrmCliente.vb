Imports System.ComponentModel
Imports SiCoFa.Entidades
Imports SiCoFa.Negocio
Public Class FrmCliente

    Private mobj_N_AdminContratos As New cls_N_AdminContratos

    Private mblnNuevo As Boolean
    Private Sub MostrarCliente(ByVal argCliente As Cliente)
        With Me
            .IdCliente.Text = argCliente.IdCliente
            .Nombre.Text = argCliente.Nombre
            .Domicilio.Text = argCliente.Domicilio
            .Localidad.Text = argCliente.Localidad
            .Provincia.Text = argCliente.Provincia
            .Telefono.Text = argCliente.Telefono
            .Movil.Text = argCliente.Movil
            .Email.Text = argCliente.Email
            .TipoDoc.Text = argCliente.Documento.TipoDoc.TipoDocumento
            .NumDoc.Text = argCliente.Documento.Numero
            .IVA.Text = argCliente.IVA.TipoIVA
        End With
    End Sub
    Private Sub ObtenerTiposDocumento()
        Me.TipoDoc.DataSource = mobj_N_AdminContratos.TiposDocumento
        Me.TipoDoc.ValueMember = "CodiTDoc"
        Me.TipoDoc.DisplayMember = "TipoDocumento"
        Me.TipoDoc.Text = ""
    End Sub
    Private Sub ObtenerTiposIVA()
        Me.IVA.DataSource = mobj_N_AdminContratos.TiposIVA
        Me.IVA.ValueMember = "CodIVA"
        Me.IVA.DisplayMember = "TipoIVA"
        Me.IVA.Text = ""
    End Sub
    Private Sub frmCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call ObtenerTiposDocumento()
        Call ObtenerTiposIVA()
    End Sub
    Private Sub Nombre_Validating(sender As Object, e As CancelEventArgs) Handles Nombre.Validating

        If Me.Nombre.Text = "" Or mblnNuevo = True Then
            Exit Sub
        End If

        Dim c As Cliente = Me.BuscarCliente(Me.Nombre.Text)

        If c Is Nothing Then
            Me.Nombre.Select()
            Me.Nombre.Text = ""
            Exit Sub
        End If

        With Me
            .LimpiarFormulario()
            .MostrarCliente(c)
            .Nombre.SelectAll()
        End With

    End Sub
    Private Function BuscarCliente(ByVal argTextoBuscado As String) As Cliente
        Dim lc As List(Of Cliente) = mobj_N_AdminContratos.ListarClientes(argTextoBuscado)
        Dim c As Cliente = Nothing

        If lc Is Nothing Then
            MsgBox("Cliente no Encontrado", vbInformation, "SiCoFa")
            Return Nothing
            Exit Function
        End If

        Select Case lc.Count
            Case 0
                MsgBox("Cliente no Encontrado", vbInformation, "SiCoFa")
                Return Nothing
                Exit Function
            Case 1
                c = lc.First
            Case > 1
                FrmBuscaClientes.Clientes = lc
                FrmBuscaClientes.ShowDialog()

                If FrmBuscaClientes.ClienteSeleccionado Is Nothing Then
                    FrmBuscaClientes.Close()
                    Return Nothing
                    Exit Function
                End If

                c = FrmBuscaClientes.ClienteSeleccionado
                FrmBuscaClientes.Close()
        End Select

        Return c
        c = Nothing

    End Function
    Private Sub Buscar_Click(sender As Object, e As EventArgs) Handles Buscar.Click
        Dim str = InputBox("Ingrese el Cliente", "SiCoFa")
        If str = "" Then
            Me.Nombre.Select()
            Exit Sub
        End If

        Dim c As Cliente = BuscarCliente(str)

        With Me
            .LimpiarFormulario()
            .MostrarCliente(c)
            .Nombre.Select()
        End With

    End Sub
    Private Sub Limpiar_Click(sender As Object, e As EventArgs) Handles Limpiar.Click
        Me.LimpiarFormulario()
        Me.Nombre.Select()
    End Sub
    Private Sub Nuevo_Click(sender As Object, e As EventArgs) Handles Nuevo.Click
        Me.LimpiarFormulario()
        mblnNuevo = True
        Me.Nombre.Focus()
    End Sub
    Private Sub Guardar_Click(sender As Object, e As EventArgs) Handles Guardar.Click
        If mblnNuevo = True Then
            Dim Id As Integer = mobj_N_AdminContratos.InsertarCliente(Me.Nombre.Text, Me.Domicilio.Text, Me.Localidad.Text, Me.Provincia.Text, Me.Telefono.Text, Me.Movil.Text, Me.Email.Text, Me.TipoDoc.SelectedValue, Me.NumDoc.Text, Me.IVA.SelectedValue)
            If Id > 0 Then
                Me.IdCliente.Text = Id
                Me.Nombre.Text = UCase(Me.Nombre.Text)
                MsgBox("Se dio de alta el Cliente " & Nombre.Text,, "SiCoFa")
            Else
                MsgBox("Ocurrio un error, intente nuevamente",, "SiCoFa")
                Exit Sub
            End If
        Else
            If Me.IdCliente.Text = "" Then
                MsgBox("El cliente " & Me.Nombre.Text & " no fue dado de Alta",, "SiCoFa")
                Exit Sub
            End If

            Dim Actualizado As Boolean = mobj_N_AdminContratos.ActualizarCliente(Me.IdCliente.Text, Me.Domicilio.Text, Me.Localidad.Text, Me.Provincia.Text, Me.Telefono.Text, Me.Movil.Text, Me.Email.Text, Me.TipoDoc.SelectedValue, Me.NumDoc.Text, Me.IVA.SelectedValue)

            If Actualizado = True Then
                MsgBox("El Cliente " & Nombre.Text & " se acutalizo correctamente",, "SiCoFa")
            Else
                MsgBox("Ocurrio un error, intente nuevamente", "SiCoFa")
                Exit Sub
            End If
        End If
    End Sub

End Class