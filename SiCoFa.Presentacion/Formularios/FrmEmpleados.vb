Imports System.ComponentModel
Imports SiCoFa.Entidades
Public Class FrmEmpleados
    Private Function BuscarEmpleado(ByVal argTextoBuscado As String) As Cliente
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
    Private Sub MostrarEmpleado(ByVal argEmpleado As Empleado)
        With Me
            .Id.Text = argEmpleado.Id
            .Nombre.Text = argEmpleado.Nombre
            .Domicilio.Text = argEmpleado.Domicilio
            .Localidad.Text = argEmpleado.Localidad
            .Provincia.Text = argEmpleado.Provincia
            .Telefono.Text = argEmpleado.Telefono
            .Email.Text = argEmpleado.Email
            .TipoDoc.Text = argEmpleado.Documento.TipoDoc.TipoDocumento
            .NumDoc.Text = argEmpleado.Documento.Numero
        End With
    End Sub
    Private Sub FrmEmpleado_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.IVA.Visible = False
        Me.lblIVA.Visible = False
        Me.Height = Me.Height - Me.IVA.Height + 5
    End Sub
End Class