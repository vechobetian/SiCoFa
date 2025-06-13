Imports System.Net.Mail
Imports SiCoFa.Datos
Imports SiCoFa.Entidades
Public Class N_AdminEmail
    Public Function EnviarMail(ByVal argNombreMostrado As String, ByVal argMail As String, ByVal argAsunto As String, ByVal argMensaje As String, Optional ByVal argPathAdjunto As String = "") As Boolean

        Dim obj_D_AdminCuentaEmail As New D_AdminCuentasEmail
        Dim CtaE As CuentaEmail = obj_D_AdminCuentaEmail.ObtenerCuentaEmail

        If CtaE Is Nothing Then
            Return False
        End If

        Try

            Using smtp As New SmtpClient

                With smtp
                    .Port = CtaE.Port 'para gmail y hotmail es 587
                    .Host = CtaE.Host 'para gmail=smtp.gmail.com, para hotmail=smtp.office365.com
                    .Credentials = New System.Net.NetworkCredential(CtaE.User, CtaE.Psw) 'en gmail y hotmail el usuario es el correo
                    .EnableSsl = True
                End With

                Using correo As New MailMessage

                    With correo
                        .From = New MailAddress(CtaE.Mail, argNombreMostrado)
                        .To.Add(argMail)
                        .Subject = argAsunto
                        .Body = argMensaje
                        .IsBodyHtml = False
                        .Priority = MailPriority.Normal

                        If argPathAdjunto <> "" Then
                            Dim adjunto As New Attachment(argPathAdjunto)
                            .Attachments.Add(adjunto)
                        End If

                    End With

                    smtp.Send(correo)

                End Using

            End Using

            Return True

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError(Me.ToString, "EnviarMail", ex.Message))

        End Try

    End Function
End Class