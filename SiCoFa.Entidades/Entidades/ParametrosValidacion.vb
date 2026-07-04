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

    Public Sub New(ByVal argValidador As String,
                   ByVal argDescripcion As String,
                   ByVal argNumPrestador As String,
                   ByVal argCuitPrestador As String,
                   ByVal argUsuario As String,
                   ByVal argIdOrganizacion As String,
                   ByVal argLicencia As String,
                   ByRef argFinanciador As String,
                   ByVal argReporte As String
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

    End Sub

End Class
