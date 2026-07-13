Public Class TipoVenta
    Public Property CodiTV As String

    Private m_Descripcion As String

    Public ReadOnly Property Descripcion As String
        Get
            Return m_Descripcion
        End Get
    End Property

    Public Shared ReadOnly Property Predeterminado As TipoVenta
        Get
            Return New TipoVenta("7")
        End Get
    End Property

    Public Shared ReadOnly Property Lista As List(Of TipoVenta)
        Get
            Return New List(Of TipoVenta) From {
                New TipoVenta("1"),
                New TipoVenta("2"),
                New TipoVenta("3"),
                New TipoVenta("4"),
                New TipoVenta("5"),
                New TipoVenta("6"),
                New TipoVenta("7")
                }
        End Get

    End Property

    Public Sub New(argCodiTV As String)

        Me.CodiTV = argCodiTV.Trim().ToUpper

        Select Case argCodiTV.Trim().ToUpper
            Case "1" : m_Descripcion = "VENTA LIBRE"
            Case "2" : m_Descripcion = "VENTA BAJO RECETA"
            Case "3" : m_Descripcion = "VENTA BAJO RECETA ARCHIVADA"
            Case "4" : m_Descripcion = "VENTA BAJO RECETA OFICIAL"
            Case "5" : m_Descripcion = "PENDIENTE"
            Case "6" : m_Descripcion = "BAJO CONTROL MEDICO RECOMENDADO"
            Case "7" : m_Descripcion = "NO CLASIFICADO"
        End Select
    End Sub

End Class