Imports System.ComponentModel
Imports SiCoFa.Entidades
Public Class FrmClientes
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
                FrmBuscaPersonas.Personas = lc
                FrmBuscaPersonas.ShowDialog()

                ' Verificamos si el usuario seleccionó un cliente
                If FrmBuscaPersonas.PersonaSeleccionado IsNot Nothing Then
                    Dim p = FrmBuscaPersonas.PersonaSeleccionado
                    c = New Cliente(p.Id, p.Nombre, p.Domicilio, p.Localidad, p.Provincia, p.Telefono, p.Email, p.Documento.TipoDoc.CodiTDoc, p.Documento.Numero, p.IVA.CodIVA)
                End If
                FrmBuscaPersonas.Close()
        End Select

        Return c
        c = Nothing

    End Function
    Private Sub MostrarCliente(ByVal argCliente As Cliente)
        With Me
            .Id.Text = argCliente.Id
            .Nombre.Text = argCliente.Nombre
            .Domicilio.Text = argCliente.Domicilio
            .Localidad.Text = argCliente.Localidad
            .Provincia.Text = argCliente.Provincia
            .Telefono.Text = argCliente.Telefono
            .Email.Text = argCliente.Email
            .TipoDoc.Text = argCliente.Documento.TipoDoc.TipoDocumento
            .NumDoc.Text = argCliente.Documento.Numero
            .IVA.Text = argCliente.IVA.TipoIVA
        End With
    End Sub
    Public Overrides Sub Guardar_Click(sender As Object, e As EventArgs)
        MyBase.Guardar_Click(sender, e)

        If Me.ValidacionOK = False Then
            Exit Sub
        End If

        If Me.NuevaPersona = True Then
            Dim Id As Integer = mobj_N_AdminContratos.InsertarCliente(Me.Nombre.Text, Me.Domicilio.Text, Me.Localidad.Text, Me.Provincia.Text, Me.Telefono.Text, Me.Email.Text, Me.TipoDoc.SelectedValue, Me.NumDoc.Text, Me.IVA.SelectedValue)
            If Id > 0 Then
                Me.Id.Text = Id
                Me.Nombre.Text = UCase(Me.Nombre.Text)
                MsgBox("Se dio de alta el Cliente " & Nombre.Text,, "SiCoFa")
            Else
                MsgBox("Ocurrio un error, intente nuevamente",, "SiCoFa")
                Exit Sub
            End If
            Me.NuevaPersona = False
        Else
            If Me.Id.Text = "" Then
                MsgBox("El cliente " & Me.Nombre.Text & " no fue dado de Alta",, "SiCoFa")
                Exit Sub
            End If

            Dim Actualizado As Boolean = mobj_N_AdminContratos.ActualizarCliente(Me.Id.Text, Me.Domicilio.Text, Me.Localidad.Text, Me.Provincia.Text, Me.Telefono.Text, Me.Email.Text, Me.TipoDoc.SelectedValue, Me.NumDoc.Text, Me.IVA.SelectedValue)

            If Actualizado = True Then
                MsgBox("El Cliente " & Nombre.Text & " se acutalizo correctamente",, "SiCoFa")
            Else
                MsgBox("Ocurrio un error, intente nuevamente", "SiCoFa")
                Exit Sub
            End If
        End If

        Me.LimpiarFormulario()
        Me.Nombre.Select()

    End Sub
    Public Overrides Sub Buscar_Click(sender As Object, e As EventArgs)
        MyBase.Buscar_Click(sender, e)

        If Me.TextoBuscar = "" Then
            Exit Sub
        End If

        Dim c As Cliente = BuscarCliente(Me.TextoBuscar)

        If c Is Nothing Then
            Exit Sub
        End If

        With Me
            .LimpiarFormulario()
            .MostrarCliente(c)
            .Nombre.Select()
        End With

    End Sub
    Public Overrides Sub Nombre_Validating(sender As Object, e As CancelEventArgs)

        If Me.Nombre.Text = "" Or Me.NuevaPersona = True Then
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

End Class