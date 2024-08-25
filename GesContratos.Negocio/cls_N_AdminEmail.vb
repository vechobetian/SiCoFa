Imports System.Net.Mail
Imports SiCoFa.Datos
Imports SiCoFa.Entidades
Public Class cls_N_AdminEmail
    Private mobj_D_AdminEmail As cls_D_AdminEmail
    Private mobj_CuentaEmail As CuentaEmail
    Public Sub New()
        mobj_D_AdminEmail = New cls_D_AdminEmail
        mobj_CuentaEmail = mobj_D_AdminEmail.ObtenerCuentaEmail
    End Sub
    Private Function ObtenerCuentaEmail() As CuentaEmail
        Try
            Dim CEmail As CuentaEmail
            CEmail = mobj_D_AdminEmail.ObtenerCuentaEmail()
            Return CEmail

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "ObtenerEmailEmpresa", ex.Message))
            Return Nothing

        End Try

    End Function
    Public Function EnviarMail(ByVal argNombreMostrado As String, ByVal argMail As String, ByVal argAsunto As String, ByVal argMensaje As String, Optional ByVal argPathAdjunto As String = "") As Boolean

        Dim smtp As New SmtpClient
        Dim correo As New MailMessage
        Dim adjunto As Attachment = Nothing

        With smtp
            .Port = mobj_CuentaEmail.Port 'para gmail y hotmail es 587
            .Host = mobj_CuentaEmail.Host 'para gmail=smtp.gmail.com, para hotmail=smtp.office365.com
            .Credentials = New System.Net.NetworkCredential(mobj_CuentaEmail.User, mobj_CuentaEmail.Psw) 'en gmail y hotmail el usuario es el correo
            .EnableSsl = True
        End With

        If argPathAdjunto <> "" Then
            adjunto = New Attachment(argPathAdjunto)
        End If

        With correo
            .From = New MailAddress(mobj_CuentaEmail.Mail, argNombreMostrado)
            .To.Add(argMail)
            .Subject = argAsunto
            .Body = argMensaje
            .IsBodyHtml = False
            .Priority = MailPriority.Normal

            If argPathAdjunto <> "" Then
                .Attachments.Add(adjunto)
            End If

        End With

            Try
            smtp.Send(correo)
            Return True

        Catch ex As Exception
            Throw New Exception(vecho.MensajeError(Me.ToString, "EnviarMail", ex.Message))
            Return Nothing
        End Try

        smtp.Dispose()
        correo.Dispose()
        adjunto.Dispose()

    End Function

End Class