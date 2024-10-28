Imports System.ComponentModel
Imports SiCoFa.Entidades
Public Class FrmProveedores
    Private Function BuscarProveedor(ByVal argTextoBuscado As String) As Proveedor
        Dim lp As List(Of Proveedor) = mobj_N_AdminSiCoFa.ListarProveedores(argTextoBuscado)
        Dim pv As Proveedor = Nothing

        If lp Is Nothing Then
            MsgBox("Proveedor no Encontrado", vbInformation, "SiCoFa")
            Return Nothing
            Exit Function
        End If

        Select Case lp.Count
            Case 0
                MsgBox("Proveedor no Encontrado", vbInformation, "SiCoFa")
                Return Nothing
                Exit Function
            Case 1
                pv = lp.First
            Case > 1
                FrmBuscaPersonas.Personas = lp
                FrmBuscaPersonas.ShowDialog()

                ' Verificamos si el usuario seleccionó un cliente
                If FrmBuscaPersonas.PersonaSeleccionado IsNot Nothing Then
                    Dim p = FrmBuscaPersonas.PersonaSeleccionado
                    pv = New Proveedor(p.Id, p.Nombre, p.Domicilio, p.Localidad, p.Provincia, p.Telefono, p.Email, p.Documento.TipoDoc.CodiTDoc, p.Documento.Numero, p.IVA.CodIVA)
                End If
                FrmBuscaPersonas.Close()
        End Select

        Return pv
        pv = Nothing

    End Function
    Private Sub MostrarProveedor(ByVal argProveedor As Proveedor)
        With Me
            .Id.Text = argProveedor.Id
            .Nombre.Text = argProveedor.Nombre
            .Domicilio.Text = argProveedor.Domicilio
            .Localidad.Text = argProveedor.Localidad
            .Provincia.Text = argProveedor.Provincia
            .Telefono.Text = argProveedor.Telefono
            .Email.Text = argProveedor.Email
            .TipoDoc.Text = argProveedor.Documento.TipoDoc.TipoDocumento
            .NumDoc.Text = argProveedor.Documento.Numero
            .IVA.Text = argProveedor.IVA.TipoIVA
        End With
    End Sub
    Public Overrides Sub Guardar_Click(sender As Object, e As EventArgs)
        MyBase.Guardar_Click(sender, e)

        If Me.ValidacionOK = False Then
            Exit Sub
        End If

        If Me.NuevaPersona = True Then
            Dim Id As Integer = mobj_N_AdminSiCoFa.InsertarProveedor(Me.Nombre.Text, Me.Domicilio.Text, Me.Localidad.Text, Me.Provincia.Text, Me.Telefono.Text, Me.Email.Text, Me.TipoDoc.SelectedValue, Me.NumDoc.Text, Me.IVA.SelectedValue)
            If Id > 0 Then
                Me.Id.Text = Id
                Me.Nombre.Text = UCase(Me.Nombre.Text)
                MsgBox("Se dio de alta el Proveedor " & Nombre.Text, vbInformation, "SiCoFa")
            Else
                MsgBox("Ocurrio un error, intente nuevamente", vbCritical, "SiCoFa")
                Exit Sub
            End If
            Me.NuevaPersona = False
        Else
            If Me.Id.Text = "" Then
                MsgBox("El Proveedor " & Me.Nombre.Text & " no fue dado de Alta", vbInformation, "SiCoFa")
                Exit Sub
            End If

            Dim Actualizado As Boolean = mobj_N_AdminSiCoFa.ActualizarProveedor(Me.Id.Text, Me.Domicilio.Text, Me.Localidad.Text, Me.Provincia.Text, Me.Telefono.Text, Me.Email.Text, Me.TipoDoc.SelectedValue, Me.NumDoc.Text, Me.IVA.SelectedValue)

            If Actualizado = True Then
                MsgBox("El Proveedor " & Nombre.Text & " se acutalizo correctamente", vbInformation, "SiCoFa")
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

        Dim p As Proveedor = BuscarProveedor(Me.TextoBuscar)

        If p Is Nothing Then
            Exit Sub
        End If

        With Me
            .LimpiarFormulario()
            .MostrarProveedor(p)
            .Nombre.Select()
        End With

    End Sub
    Public Overrides Sub Nombre_Validating(sender As Object, e As CancelEventArgs)
        MyBase.Nombre_Validating(sender, e)

        If Me.Nombre.Text = "" Or Me.NuevaPersona = True Then
            Exit Sub
        End If

        Dim p As Proveedor = Me.BuscarProveedor(Me.Nombre.Text)

        If p Is Nothing Then
            Me.Nombre.Select()
            Me.Nombre.Text = ""
            Exit Sub
        End If

        With Me
            .LimpiarFormulario()
            .MostrarProveedor(p)
            .Nombre.SelectAll()
        End With

    End Sub
End Class