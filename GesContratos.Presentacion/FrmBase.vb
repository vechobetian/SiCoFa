Public Class FrmBase
    Inherits Form

    ' Sobrescribimos el método ProcessCmdKey para capturar la tecla Enter en todos los formularios que hereden de FormBase
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        ' Verifica si la tecla presionada es Enter
        If keyData = Keys.Enter OrElse keyData = Keys.Down Then
            ' Mueve el enfoque al siguiente control
            Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
            Return True ' Indica que el evento ha sido manejado
        ElseIf keyData = Keys.Up Then
            ' Mueve el enfoque al control anterior
            Me.SelectNextControl(Me.ActiveControl, False, True, True, True)
            Return True ' Indica que el evento ha sido manejado
        End If
        ' Si no es Enter, ejecuta el comportamiento predeterminado
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

End Class

