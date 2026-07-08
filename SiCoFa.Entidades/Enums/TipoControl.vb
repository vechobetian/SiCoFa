Namespace Enums
    Public Class TipoControl

        Public Property CodiTiCo As String
        Public Property Descripcion As String

        Public Sub New(codigo As String)

            CodiTiCo = codigo

            Select Case codigo.Trim().ToUpper()
                Case "0" : Descripcion = "NO CONTROLADO"
                Case "2" : Descripcion = "PSICOTROPICO LISTA II"
                Case "3" : Descripcion = "PSICOTROPICO LISTA III"
                Case "4" : Descripcion = "PSICOTROPICO LISTA IV"
                Case "6" : Descripcion = "ESTUPEFACIENTE LISTA I"
                Case "7" : Descripcion = "ESTUPEFACIENTE LISTA II"
                Case "8" : Descripcion = "ESTUPEFACIENTE LISTA III"
                Case "9" : Descripcion = "SUCCINILCOLINA"
                Case "A" : Descripcion = "VENTA VIGILADA"
                Case Else : Descripcion = "DESCONOCIDO"
            End Select

        End Sub

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

    End Class

End Namespace

