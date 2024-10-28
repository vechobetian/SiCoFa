Imports System.ComponentModel
Imports SiCoFa.Entidades
Imports SiCoFa.Negocio
Public Class FrmAperComprobantes
    Private mobj_N_AdminContratos As New cls_N_AdminSiCoFa

    Private Sub LimpiarFormulario()
        Me.Cliente.Clear()
        Me.TipoComprobante.SelectedIndex = -1
        Me.Desde.Clear()
        Me.Hasta.Clear()
    End Sub

    Private Function BuscarCliente(ByVal argTextoBuscado As String) As Cliente
        Dim lc As List(Of Cliente) = mobj_N_AdminContratos.ListarClientes(argTextoBuscado)
        Dim c As Cliente = Nothing

        If lc Is Nothing Then
            MsgBox("Cliente no Encontrado", vbInformation, "SiCoFa")
            Return Nothing
            Exit Function
        End If

        Select Case lc.Count
            Case 0
                MsgBox("No se encontro el Cliente",, "SiCoFa")
                Return Nothing
                Exit Function
            Case 1
                c = lc.First
            Case > 1
                FrmBuscaPersonas.Personas = lc
                FrmBuscaPersonas.ShowDialog()

                If FrmBuscaPersonas.PersonaSeleccionado Is Nothing Then
                    FrmBuscaPersonas.Close()
                    Return Nothing
                    Exit Function
                End If

                c = FrmBuscaPersonas.PersonaSeleccionado
                FrmBuscaPersonas.Close()
        End Select

        Return c
        c = Nothing

    End Function
    Private Sub ObtenerTipoComprobantes()

        Dim obj_N_AdminDB As New cls_N_AdminDB
        Dim sql As String = "SELECT CodiTC,TipoComp FROM TblTipoComp"
        Dim TipoComp As DataTable = obj_N_AdminDB.ObtenerTabla(sql)

        ' Crear una nueva fila para "Todos" con valor 0
        Dim newRow As DataRow = TipoComp.NewRow()
        newRow("CodiTC") = 0
        newRow("TipoComp") = "Todos"
        TipoComp.Rows.InsertAt(newRow, 0)

        With Me.TipoComprobante
            .DataSource = TipoComp
            .ValueMember = "CodiTC"
            .DisplayMember = "TipoComp"
            .SelectedIndex = -1
        End With

    End Sub
    Private Sub FrmAperComprobantes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ObtenerTipoComprobantes()
    End Sub

    Private Sub Cliente_KeyUp(sender As Object, e As KeyEventArgs) Handles Cliente.KeyUp
        If e.KeyCode = 13 Then
            If Me.Cliente.Text = "" Or LCase(Me.Cliente.Text) = "todos" Then
                Me.Cliente.Text = "Todos"
                Me.Cliente.Tag = 0
                Me.Cliente.SelectAll()
                Exit Sub
            End If

            Dim c As Cliente = Me.BuscarCliente(Me.Cliente.Text)

            If c Is Nothing Then
                Exit Sub
            End If

            With Me
                .LimpiarFormulario()
                .Cliente.Tag = c.Id
                .Cliente.Text = c.Nombre
                .Cliente.SelectAll()
            End With
        End If
    End Sub
    Private Sub Cliente_Validating(sender As Object, e As CancelEventArgs) Handles Cliente.Validating
        If Me.Cliente.Text = "" Then
            Me.Cliente.Tag = 0
            Me.Cliente.Text = "Todos"
        End If
    End Sub
    Private Sub TipoComprobante_KeyUp(sender As Object, e As KeyEventArgs) Handles TipoComprobante.KeyUp

        If e.KeyCode = 13 Then
            If Me.TipoComprobante.Text = "" Then
                Me.TipoComprobante.Text = "Todos"
                Me.TipoComprobante.SelectAll()
            End If
        End If

    End Sub
    Private Sub TipoComprobante_Validating(sender As Object, e As CancelEventArgs) Handles TipoComprobante.Validating
        If Me.TipoComprobante.Text = "" Then
            Me.TipoComprobante.Text = "Todos"
        End If
    End Sub
    Private Sub Desde_Validating(sender As Object, e As CancelEventArgs) Handles Desde.Validating

        If Me.Desde.Text = "  /  /" Then
            MsgBox("Fecha Desde es un dato requrido", vbCritical, "SiCoFa")
            e.Cancel = True
        End If

    End Sub
    Private Sub Hasta_Validating(sender As Object, e As CancelEventArgs) Handles Hasta.Validating

        If Me.Hasta.Text = "  /  /" Then
            MsgBox("Fecha Hasta es un dato requrido", vbCritical, "SiCoFa")
            e.Cancel = True
        End If

    End Sub
    Private Sub Aceptar_Click(sender As Object, e As EventArgs) Handles Aceptar.Click
        Dim FechaDesde As String = Mid(Me.Desde.Text, 7, 4) & "-" & Mid(Me.Desde.Text, 4, 2) & "-" & Mid(Me.Desde.Text, 1, 2)
        Dim FechaHasta As String = Mid(Me.Hasta.Text, 7, 4) & "-" & Mid(Me.Hasta.Text, 4, 2) & "-" & Mid(Me.Hasta.Text, 1, 2)

        With FrmComprobantes
            .MostrarComprobantes(Me.Cliente.Tag, Me.TipoComprobante.SelectedValue, FechaDesde, FechaHasta)
            .Show()
            Me.Hide()
        End With

    End Sub

End Class