Public Class Provincia

    Private m_CodiP As String
    Private m_Provincia As String

    Public Property CodiP As String
        Get
            Return m_CodiP
        End Get
        Set(value As String)

            m_CodiP = value.Trim().ToUpper()

            Select Case m_CodiP
                Case "A" : m_Provincia = "NEUQUEN"
                Case "B" : m_Provincia = "BUENOS AIRES"
                Case "C" : m_Provincia = "CABA"
                Case "D" : m_Provincia = "LA RIOJA"
                Case "E" : m_Provincia = "ENTRE RIOS"
                Case "F" : m_Provincia = "FORMOSA"
                Case "G" : m_Provincia = "SANTIAGO DEL ESTERO"
                Case "H" : m_Provincia = "CHACO"
                Case "I" : m_Provincia = "MISIONES"
                Case "J" : m_Provincia = "CORRIENTES"
                Case "K" : m_Provincia = "SAN JUAN"
                Case "L" : m_Provincia = "LA PAMPA"
                Case "M" : m_Provincia = "MENDOZA"
                Case "N" : m_Provincia = "CATAMARCA"
                Case "O" : m_Provincia = "SAN LUIS"
                Case "P" : m_Provincia = "TUCUMAN"
                Case "Q" : m_Provincia = "TIERRA DEL FUEGO"
                Case "R" : m_Provincia = "RIO NEGRO"
                Case "S" : m_Provincia = "SANTA FE"
                Case "T" : m_Provincia = "SALTA"
                Case "U" : m_Provincia = "CHUBUT"
                Case "X" : m_Provincia = "CORDOBA"
                Case "Y" : m_Provincia = "JUJUY"
                Case "Z" : m_Provincia = "SANTA CRUZ"
                Case Else : m_Provincia = "DESCONOCIDO"
            End Select

        End Set
    End Property

    Public ReadOnly Property Provincia As String
        Get
            Return m_Provincia
        End Get
    End Property

    Public Shared ReadOnly Property Lista As List(Of Provincia)
        Get
            Return New List(Of Provincia) From {
                New Provincia("A"),
                New Provincia("B"),
                New Provincia("C"),
                New Provincia("D"),
                New Provincia("E"),
                New Provincia("F"),
                New Provincia("G"),
                New Provincia("H"),
                New Provincia("I"),
                New Provincia("J"),
                New Provincia("K"),
                New Provincia("L"),
                New Provincia("M"),
                New Provincia("N"),
                New Provincia("O"),
                New Provincia("P"),
                New Provincia("Q"),
                New Provincia("R"),
                New Provincia("S"),
                New Provincia("T"),
                New Provincia("U"),
                New Provincia("X"),
                New Provincia("Y"),
                New Provincia("Z")
                }
        End Get
    End Property

    Public Sub New()
        Me.CodiP = ""
    End Sub

    Public Sub New(ByVal argCodiP As String)

        Me.CodiP = argCodiP.Trim().ToUpper

    End Sub
End Class
