Public Class TamanioEnvase
    Public Property CodiTE As String
    Private Property m_Descripcion As String

    Public ReadOnly Property Descripcion As String
        Get
            Return m_Descripcion
        End Get
    End Property

    Public Shared ReadOnly Property Predeterminado As TamanioEnvase
        Get
            Return New TamanioEnvase("0")
        End Get
    End Property

    Public Shared ReadOnly Property Lista As List(Of TamanioEnvase)
        Get
            Return New List(Of TamanioEnvase) From {
                New TamanioEnvase("0"),
                New TamanioEnvase("1"),
                New TamanioEnvase("2"),
                New TamanioEnvase("3"),
                New TamanioEnvase("4"),
                New TamanioEnvase("5"),
                New TamanioEnvase("6"),
                New TamanioEnvase("7")
                }
        End Get

    End Property

    Public Sub New(argCodiTE As String)

        Me.CodiTE = argCodiTE

        Select Case argCodiTE.Trim.ToUpper
            Case "0" : m_Descripcion = "NO CLASIFICADO"
            Case "1" : m_Descripcion = "MENOR"
            Case "2" : m_Descripcion = "SIGUIENTE"
            Case "3" : m_Descripcion = "GRANDE DOS PRESENTACIONES"
            Case "4" : m_Descripcion = "GIGANTE"
            Case "5" : m_Descripcion = "GRANDE MAS DE DOS PRESENTACIONES"
            Case "6" : m_Descripcion = "ANTIBIO MONODOSIS"
            Case "7" : m_Descripcion = "ANTIBIOTICO MULTIDOSIS"
            Case "8" : m_Descripcion = "SOLUCIONES PARENTERALES"
            Case "9" : m_Descripcion = "HOSPITALARIO"
        End Select
    End Sub

End Class


