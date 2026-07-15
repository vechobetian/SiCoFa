Public Class ParametrosValidacion
    Public Property Validador As String
    Public Property Descripcion As String
    Public Property NumPrestador As String
    Public Property CuitPrestador As String
    Public Property Usuario As String
    Public Property IdOrganizacion As String
    Public Property Licencia As String
    Public Property Financiador As String
    Public Property Reporte As String
    Public Property RecetaElectronica As Boolean

    Public Sub New(
                  argValidador As String,
                  argDescripcion As String,
                  argNumPrestador As String,
                  argCuitPrestador As String,
                  argUsuario As String,
                  argIdOrganizacion As String,
                  argLicencia As String,
                  argFinanciador As String,
                  argReporte As String,
                  argRecetaElectronica As Boolean
                   )

        Me.Validador = argValidador
        Me.Descripcion = argDescripcion
        Me.NumPrestador = argNumPrestador
        Me.CuitPrestador = argCuitPrestador
        Me.Usuario = argUsuario
        Me.IdOrganizacion = argIdOrganizacion
        Me.Licencia = argLicencia
        Me.Financiador = argFinanciador
        Me.Reporte = argReporte
        Me.RecetaElectronica = argRecetaElectronica
    End Sub

End Class
