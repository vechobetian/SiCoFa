Public Class TipoDocumento

    Public Property CodiTDoc As String

    Private m_Descripcion As String

    Public ReadOnly Property CodiTDocAFIP As String
        Get
            Select Case CodiTDoc
                Case "CUIT"
                    Return "80"

                Case "CUIL"
                    Return "86"

                Case "LC"
                    Return "90"

                Case "DNI"
                    Return "96"

                Case "SI"
                    Return "99"

                Case Else
                    Return "99"
            End Select
        End Get
    End Property

    Public ReadOnly Property CodiTDocADESFA As String
        Get
            Select Case CodiTDoc
                Case "DNI", "CUIL", "LC", "LE", "CI", "PAS", "CUIT", "SI"
                    Return CodiTDoc

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

    Public ReadOnly Property Descripcion As String
        Get
            Return m_Descripcion
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

    Public Sub New(argCodiTDoc As String)

        Me.CodiTDoc = argCodiTDoc.Trim().ToUpper

        Select Case argCodiTDoc.Trim().ToUpper
            Case "DNI" : m_Descripcion = "DOCUMENTO NACIONAL DE IDENTIDAD"
            Case "CUIT" : m_Descripcion = "CLAVE UNICA DE IDENTIFICACION TRIBUTARIA"
            Case "CUIL" : m_Descripcion = "CODIGO UNICO DE IDENTIFICACION LABORAL"
            Case "LC" : m_Descripcion = "LIBRETA CIVICA"
            Case "LE" : m_Descripcion = "LIBRETA DE ENROLAMIENTO"
            Case "CI" : m_Descripcion = "CEDULA DE IDENTIDAD"
            Case "PAS" : m_Descripcion = "PASAPORTE"
            Case "SI" : m_Descripcion = "SIN IDENTIFICACION"
            Case Else : m_Descripcion = "SIN INFORMAR"
        End Select

    End Sub

End Class