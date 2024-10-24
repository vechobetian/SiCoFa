Public Class clsFrmBase
    Inherits Form

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean

        If TypeOf Me.ActiveControl Is ComboBox Then
            If (keyData And Keys.Alt) = Keys.Alt AndAlso (keyData And Keys.Down) = Keys.Down Then
                Return False
            End If

            If (keyData And Keys.Alt) = Keys.Alt AndAlso (keyData And Keys.Up) = Keys.Up Then
                Return False ' Dejar que el comportamiento predeterminado ocurra
            End If

            If TypeOf Me.ActiveControl Is ComboBox AndAlso DirectCast(Me.ActiveControl, ComboBox).DroppedDown Then
                Return False
            End If

        End If

        If keyData = Keys.Enter OrElse keyData = Keys.Down Then

            Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
            Return True
        ElseIf keyData = Keys.Up Then

            Me.SelectNextControl(Me.ActiveControl, False, True, True, True)
            Return True
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    ' Método para limpiar todos los controles del formulario
    Protected Sub LimpiarControles(container As Control)
        For Each ctrl As Control In container.Controls
            If TypeOf ctrl Is TextBox Then
                CType(ctrl, TextBox).Clear()
            ElseIf TypeOf ctrl Is ComboBox Then
                CType(ctrl, ComboBox).SelectedIndex = -1
            ElseIf TypeOf ctrl Is CheckedListBox Then
                CType(ctrl, CheckedListBox).ClearSelected()
            ElseIf TypeOf ctrl Is RadioButton OrElse TypeOf ctrl Is CheckBox Then
                CType(ctrl, CheckBox).Checked = False
            ElseIf TypeOf ctrl Is DataGridView Then
                CType(ctrl, DataGridView).Rows.Clear()
            Else
                ' Llama recursivamente si el control contiene otros controles
                LimpiarControles(ctrl)
            End If
        Next
    End Sub
    ' Método público para limpiar el formulario
    Public Sub LimpiarFormulario()
        LimpiarControles(Me) ' Llama al método para limpiar todos los controles del formulario
    End Sub

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'clsFrmBase
        '
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Name = "clsFrmBase"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)

    End Sub
End Class

