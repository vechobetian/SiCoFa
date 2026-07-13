Public Class TipoControl

    Public Property CodiTiCo As String
    Private m_Descripcion As String

    Public ReadOnly Property Descripcion As String
        Get
            Return m_Descripcion
        End Get
    End Property

    Public Shared ReadOnly Property Predeterminado As TipoControl
        Get
            Return New TipoControl("0")
        End Get
    End Property

    Public Shared ReadOnly Property Lista As List(Of TipoControl)
        Get
            Return New List(Of TipoControl) From {
                New TipoControl("0"),
                New TipoControl("2"),
                New TipoControl("3"),
                New TipoControl("4"),
                New TipoControl("6"),
                New TipoControl("7"),
                New TipoControl("8"),
                New TipoControl("9"),
                New TipoControl("A")
            }
        End Get
    End Property

    Public Sub New(argCodiTiCo As String)

        Me.CodiTiCo = argCodiTiCo.Trim().ToUpper

        Select Case argCodiTiCo.Trim().ToUpper()
            Case "0" : m_Descripcion = "NO CONTROLADO"
            Case "2" : m_Descripcion = "PSICOTROPICO LISTA II"
            Case "3" : m_Descripcion = "PSICOTROPICO LISTA III"
            Case "4" : m_Descripcion = "PSICOTROPICO LISTA IV"
            Case "6" : m_Descripcion = "ESTUPEFACIENTE LISTA I"
            Case "7" : m_Descripcion = "ESTUPEFACIENTE LISTA II"
            Case "8" : m_Descripcion = "ESTUPEFACIENTE LISTA III"
            Case "9" : m_Descripcion = "SUCCINILCOLINA"
            Case "A" : m_Descripcion = "VENTA VIGILADA"
            Case Else : m_Descripcion = "DESCONOCIDO"
        End Select

    End Sub


End Class