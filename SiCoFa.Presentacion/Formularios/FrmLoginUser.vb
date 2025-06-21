Imports SiCoFa.Negocio
Imports SiCoFa.Entidades
Imports System.ComponentModel
Public Class FrmLoginUser
    Property IdProceso As Integer
    Property Usuario As Usuario

    Private mAdminUsuarios As New N_AdminUsuarios
    Private Function VerificarAutorizacionProceso(ByVal argIdUsusario As Integer, ByVal argPassword As String, ByVal argIdProceso As Integer) As String

        Try
            Dim Autorizacion As String = mAdminUsuarios.VerificarAutorizacionProceso(argIdUsusario, argPassword, argIdProceso)
            Return Autorizacion

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
            Return "ERROR"
        End Try

    End Function
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean

        Select Case keyData
            Case Keys.Escape
                Me.DialogResult = DialogResult.Cancel
                Me.Close()
            Case Else
                Return MyBase.ProcessCmdKey(msg, keyData)
        End Select
        Return True ' Asegúrate de devolver True para que la tecla se procese correctamente
    End Function
    Private Sub Password_Validating(sender As Object, e As CancelEventArgs) Handles Password.Validating
        Me.ValidarCampos(Me, New List(Of String))
        If Me.ValidacionOK = False Then
            Exit Sub
        End If

        Dim Autorizacion As String = Me.VerificarAutorizacionProceso(Convert.ToInt32(Me.IdUsuario.Text), Me.Password.Text.ToString, Convert.ToInt32(Me.IdProceso))

        Select Case Autorizacion
            Case "AUTORIZADO"
                Me.Usuario = mAdminUsuarios.ObtenerUsuarioPorId(Convert.ToInt32(Me.IdUsuario.Text))
                Me.DialogResult = DialogResult.OK
                Me.Hide()

            Case "DESAUTORIZADO"
                MsgBox("Usuario no autorizado para ejecutar este proceso", vbCritical, "SiCoFa")
                Me.DialogResult = DialogResult.Cancel
                Me.Close()

            Case "LOGIN_INCORRECTO"
                MsgBox("Usuario o Password incorrecto", vbCritical, "SiCoFa")
                Me.IdUsuario.Text = ""
                Me.Password.Text = ""
                Me.IdUsuario.Select()

        End Select
    End Sub


End Class
