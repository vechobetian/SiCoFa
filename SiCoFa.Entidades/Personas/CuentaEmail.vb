Public Class CuentaEmail
    Property IdMail As Integer
    Property Port As Integer
    Property Host As String
    Property User As String
    Property Psw As String
    Property Mail As String

    Public Sub New(
                  ByVal argIdMail As Integer,
                  ByVal argPort As Integer,
                  ByVal argHost As String,
                  ByVal argUser As String,
                  ByVal argPsw As String,
                  ByVal argMail As String
                  )
        Me.IdMail = argIdMail
        Me.Port = argPort
        Me.Host = argHost
        Me.User = argUser
        Me.Psw = argPsw
        Me.Mail = argMail
    End Sub

End Class