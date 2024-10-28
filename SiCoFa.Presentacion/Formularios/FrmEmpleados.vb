Imports SiCoFa.Entidades
Public Class FrmEmpleados
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