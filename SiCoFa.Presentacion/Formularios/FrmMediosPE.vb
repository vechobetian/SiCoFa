Imports SiCoFa.Entidades
Imports SiCoFa.Negocio
Imports System.ComponentModel

Public Class FrmMediosPE

    Private TextoBuscar As String
    Private NuevoMedioPE As Boolean
    Private mobj_AdminSicofa As New N_AdminSiCoFa
    Private ControlesReadOnly As New List(Of String)
    Private Function SeleccionarMedioPE(ByVal IdMPE As String, ByVal ListaMedioPE As List(Of MedioPE)) As MedioPE

        Try
            Dim MedioPESeleccionado As MedioPE = Nothing

            For Each mpe As MedioPE In ListaMedioPE
                If mpe.IdMPE = IdMPE Then
                    MedioPESeleccionado = mpe
                    Exit For ' Opcional: detener la búsqueda una vez encontrado el cliente
                End If
            Next
            Return MedioPESeleccionado

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
            Return Nothing
        End Try

    End Function


End Class