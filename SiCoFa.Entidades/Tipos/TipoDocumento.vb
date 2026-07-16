Public Class TipoDocumento

    Public Property CodiTD As String

    Public Sub New()

        CodiTD = "DNI"

    End Sub

    Public Sub New(argCodiTD As String)

        CodiTD = If(argCodiTD, "").Trim().ToUpper()

    End Sub

    Public ReadOnly Property Descripcion As String
        Get
            Select Case CodiTD
                Case "DNI" : Return "DOCUMENTO NACIONAL DE IDENTIDAD"
                Case "CUIT" : Return "CLAVE ÚNICA DE IDENTIFICACIÓN TRIBUTARIA"
                Case "CUIL" : Return "CÓDIGO ÚNICO DE IDENTIFICACIÓN LABORAL"
                Case "LC" : Return "LIBRETA CÍVICA"
                Case "LE" : Return "LIBRETA DE ENROLAMIENTO"
                Case "CI" : Return "CÉDULA DE IDENTIDAD"
                Case "PAS" : Return "PASAPORTE"
                Case "SI" : Return "SIN IDENTIFICACIÓN"
                Case Else : Return "SIN INFORMAR"
            End Select
        End Get
    End Property

    Public ReadOnly Property CodiTDAFIP As String
        Get
            Select Case CodiTD
                Case "CUIT" : Return "80"
                Case "CUIL" : Return "86"
                Case "LC" : Return "90"
                Case "DNI" : Return "96"
                Case "SI" : Return "99"
                Case Else : Return "99"
            End Select
        End Get
    End Property

    Public ReadOnly Property CodiTDADESFA As String
        Get
            Select Case CodiTD
                Case "DNI", "CUIL", "LC", "LE", "CI", "PAS", "CUIT", "SI"
                    Return CodiTD
                Case Else
                    Return ""
            End Select
        End Get
    End Property

    Public Shared ReadOnly Property Predeterminado As TipoDocumento
        Get
            Return New TipoDocumento("DNI")
        End Get
    End Property

    Public Shared ReadOnly Property Lista As List(Of TipoDocumento)
        Get
            Return New List(Of TipoDocumento) From {
                New TipoDocumento("DNI"),
                New TipoDocumento("CUIT"),
                New TipoDocumento("CUIL"),
                New TipoDocumento("LC"),
                New TipoDocumento("LE"),
                New TipoDocumento("CI"),
                New TipoDocumento("PAS"),
                New TipoDocumento("SI")
            }
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return Descripcion
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean

        Dim otro = TryCast(obj, TipoDocumento)

        If otro Is Nothing Then Return False

        Return String.Equals(CodiTD, otro.CodiTD, StringComparison.OrdinalIgnoreCase)

    End Function

    Public Overrides Function GetHashCode() As Integer

        Return If(CodiTD, "").ToUpperInvariant().GetHashCode()

    End Function

End Class