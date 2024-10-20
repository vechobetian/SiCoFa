
Public Class Medidor
    Property IdMedidor() As Integer
    Property Descripcion As String
    Property Categoria As String
    Property NumCliente As String
    Property Suministro As String
    Property IVA As Decimal
    Property RG2123 As Decimal
    Property IdContrato As Integer
    Property FechaUL As Date
    Property UltimaLectura As Integer
    Public Sub New(
                    ByVal argIdMedidor As Integer,
                    ByVal argDescripcion As String,
                    ByVal argCategoria As String,
                    ByVal argNumCliente As String,
                    ByVal argSuministro As String,
                    ByVal argIVA As Decimal,
                    ByVal argRG2123 As Decimal,
                    ByVal argIdContrato As Integer,
                    ByVal argFechaUL As Date,
                    ByVal argUltimaLectura As Integer
                    )

        Me.IdMedidor = argIdMedidor
        Me.Descripcion = argDescripcion
        Me.Categoria = argCategoria
        Me.NumCliente = argNumCliente
        Me.Suministro = argSuministro
        Me.IVA = argIVA
        Me.RG2123 = argRG2123
        Me.IdContrato = argIdContrato
        Me.FechaUL = argFechaUL
        Me.UltimaLectura = argUltimaLectura

    End Sub

End Class
