Imports System.ComponentModel
Imports SiCoFa.Entidades
Public Class FrmProveedores
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

End Class