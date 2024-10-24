Imports SiCoFa.Entidades
Public Class FrmUsuarios
    Private Sub MostrarUsuario(ByVal argUsuario As Usuario)
        With Me
            .Id.Text = argUsuario.IdUsuario
            .Nombre.Text = argUsuario.Nombre
            .Domicilio.Text = argUsuario.Domicilio
            .Localidad.Text = argUsuario.Localidad
            .Provincia.Text = argUsuario.Provincia
            .Telefono.Text = argUsuario.Telefono
            .Email.Text = argUsuario.Email
            .TipoDoc.Text = argUsuario.Documento.TipoDoc.TipoDocumento
            .NumDoc.Text = argUsuario.Documento.Numero
            .Password.Text = argUsuario.Password
        End With
    End Sub
    Private Sub FrmUsuario_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.IVA.Visible = False
        Me.lblIVA.Visible = False
    End Sub
End Class