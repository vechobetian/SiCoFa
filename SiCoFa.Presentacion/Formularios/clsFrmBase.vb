Public Class clsFrmBase
    Inherits Form
    Property ValidacionOK As Boolean

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean

        If keyData = Keys.Enter Then

            If TypeOf Me.ActiveControl Is UcSelectorUniversal Then
                Return MyBase.ProcessCmdKey(msg, keyData)
            End If

        End If

        '--------------------------------------------------------
        ' COMBOBOX
        '--------------------------------------------------------
        If TypeOf Me.ActiveControl Is ComboBox Then

            Dim cbo As ComboBox = DirectCast(Me.ActiveControl, ComboBox)

            ' Alt + Flecha Abajo / Arriba
            If keyData = (Keys.Alt Or Keys.Down) OrElse keyData = (Keys.Alt Or Keys.Up) Then

                Return MyBase.ProcessCmdKey(msg, keyData)

            End If

            ' Si la lista está desplegada, dejar que el ComboBox
            ' procese las flechas, Enter, Esc, etc.
            If cbo.DroppedDown Then
                Return MyBase.ProcessCmdKey(msg, keyData)
            End If

        End If

        '--------------------------------------------------------
        ' NAVEGACIÓN GENERAL
        '--------------------------------------------------------
        Select Case keyData

            Case Keys.Enter

                ' Si es un botón, ejecuta el Click
                If TypeOf Me.ActiveControl Is Button Then
                    DirectCast(Me.ActiveControl, Button).PerformClick()
                Else
                    ' En cualquier otro control actúa como TAB
                    Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
                End If

                Return True

            Case Keys.Down

                Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
                Return True

            Case Keys.Up

                Me.SelectNextControl(Me.ActiveControl, False, True, True, True)
                Return True

        End Select

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
            ElseIf TypeOf ctrl Is UcSelectorUniversal Then
                CType(ctrl, UcSelectorUniversal).Descripcion = ""
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

    Public Sub ValidarCampos(ByVal container As Control, ByVal ControlesNoValidar As List(Of String))
        Me.ValidacionOK = False

        For Each control As Control In container.Controls
            If ControlesNoValidar.Contains(control.Name) Then Continue For

            If TypeOf control Is TextBox Then
                If Trim(control.Text) = "" Then
                    MsgBox(control.Name & " es un dato requerido", vbCritical, "SiCoFa")
                    control.Focus()
                    Exit Sub
                End If

            ElseIf TypeOf control Is ComboBox Then
                Dim combo As ComboBox = DirectCast(control, ComboBox)

                ' Para DropDownList: no se permite texto fuera de la lista
                If combo.DropDownStyle = ComboBoxStyle.DropDownList Then
                    If combo.SelectedIndex = -1 Then
                        MsgBox(control.Name & " debe tener un valor seleccionado.", vbCritical, "SiCoFa")
                        combo.Focus()
                        Exit Sub
                    End If
                Else ' Para ComboBox estilo DropDown (editable)
                    If Trim(combo.Text) = "" Then
                        MsgBox(control.Name & " no puede estar vacío.", vbCritical, "SiCoFa")
                        combo.Focus()
                        Exit Sub
                    End If
                End If

            ElseIf TypeOf control Is UcSelectorUniversal Then

                Dim selector As UcSelectorUniversal = DirectCast(control, UcSelectorUniversal)

                If selector.Id Is Nothing Then

                    MsgBox(selector.HeaderDescripcion & " es un dato requerido.", vbCritical, "SiCoFa")

                    selector.Focus()

                    Exit Sub

                End If
            End If
        Next

        Me.ValidacionOK = True
    End Sub

    Public Sub EstablecerReadOnly(ByVal container As Control, ByVal ControlesReadOnly As List(Of String))
        For Each control As Control In container.Controls
            If ControlesReadOnly.Contains(control.Name) Then
                If TypeOf control Is TextBox Then
                    Dim textBoxControl As TextBox = DirectCast(control, TextBox)
                    textBoxControl.ReadOnly = True
                ElseIf TypeOf control Is ComboBox Then
                    ' Los ComboBox no tienen una propiedad ReadOnly directamente.
                    ' Puedes deshabilitarlos para un efecto similar:
                    Dim comboBoxControl As ComboBox = DirectCast(control, ComboBox)
                    comboBoxControl.Enabled = False
                ElseIf TypeOf control Is DateTimePicker Then
                    ' Los DateTimePicker también se pueden deshabilitar:
                    Dim dateTimePickerControl As DateTimePicker = DirectCast(control, DateTimePicker)
                    dateTimePickerControl.Enabled = False
                    ' Puedes agregar más tipos de controles aquí si es necesario

                Else ' Si el control NO está en la lista de ReadOnly, asegurar que NO esté ReadOnly/Disabled
                    If TypeOf control Is TextBox Then
                        Dim textBoxControl As TextBox = DirectCast(control, TextBox)
                        textBoxControl.ReadOnly = False
                    ElseIf TypeOf control Is ComboBox Then
                        Dim comboBoxControl As ComboBox = DirectCast(control, ComboBox)
                        comboBoxControl.Enabled = True
                    ElseIf TypeOf control Is DateTimePicker Then
                        Dim dateTimePickerControl As DateTimePicker = DirectCast(control, DateTimePicker)
                        dateTimePickerControl.Enabled = True
                    End If
                End If

            Else ' El control ESTÁ en la lista de exclusión: asegurar que NO esté ReadOnly/Disabled
                If TypeOf control Is TextBox Then
                    Dim textBoxControl As TextBox = DirectCast(control, TextBox)
                    textBoxControl.ReadOnly = False
                ElseIf TypeOf control Is ComboBox Then
                    Dim comboBoxControl As ComboBox = DirectCast(control, ComboBox)
                    comboBoxControl.Enabled = True
                ElseIf TypeOf control Is DateTimePicker Then
                    Dim dateTimePickerControl As DateTimePicker = DirectCast(control, DateTimePicker)
                    dateTimePickerControl.Enabled = True
                End If
            End If
        Next
    End Sub

    Protected Sub EstablecerValoresPorDefecto(ByVal container As Control, ByVal ValoresPorDefecto As Dictionary(Of String, Object))
        For Each control As Control In container.Controls 'Me.Controls
            If ValoresPorDefecto.ContainsKey(control.Name) Then
                Dim valorDefecto As Object = ValoresPorDefecto(control.Name)

                If TypeOf control Is TextBox Then
                    Dim textBoxControl As TextBox = DirectCast(control, TextBox)
                    textBoxControl.Text = Convert.ToString(valorDefecto)

                ElseIf TypeOf control Is ComboBox Then
                    Dim comboBoxControl As ComboBox = DirectCast(control, ComboBox)
                    ' Intentar establecer por ValueMember si está definido, sino por Text
                    If Not String.IsNullOrEmpty(comboBoxControl.ValueMember) AndAlso comboBoxControl.Items.Count > 0 Then
                        ' Buscar el item por el ValueMember
                        For Each item As Object In comboBoxControl.Items
                            Dim propertyInfo = item.GetType().GetProperty(comboBoxControl.ValueMember)
                            If propertyInfo IsNot Nothing AndAlso propertyInfo.GetValue(item).Equals(valorDefecto) Then
                                comboBoxControl.SelectedItem = item
                                Exit For
                            End If
                        Next
                    Else
                        comboBoxControl.Text = Convert.ToString(valorDefecto)
                    End If

                ElseIf TypeOf control Is CheckBox Then
                    Dim checkBoxControl As CheckBox = DirectCast(control, CheckBox)
                    If TypeOf valorDefecto Is Boolean Then
                        checkBoxControl.Checked = DirectCast(valorDefecto, Boolean)
                    Else
                        ' Manejar si el valor por defecto no es booleano
                        Debug.WriteLine($"Advertencia: El valor por defecto para '{control.Name}' (CheckBox) no es booleano.")
                    End If

                ElseIf TypeOf control Is UcSelectorUniversal Then
                    Dim selector As UcSelectorUniversal = DirectCast(control, UcSelectorUniversal)

                    If String.IsNullOrWhiteSpace(selector.NombrePropiedadId) Then
                        selector.Descripcion = Convert.ToString(valorDefecto)
                    Else
                        selector.Id = valorDefecto
                    End If

                ElseIf TypeOf control Is DateTimePicker Then
                    Dim dateTimePickerControl As DateTimePicker = DirectCast(control, DateTimePicker)
                    If TypeOf valorDefecto Is Date Then
                        dateTimePickerControl.Value = DirectCast(valorDefecto, Date)
                    Else
                        ' Manejar si el valor por defecto no es una fecha
                        Debug.WriteLine($"Advertencia: El valor por defecto para '{control.Name}' (DateTimePicker) no es una fecha.")
                    End If
                    ' Puedes agregar más tipos de controles aquí si es necesario
                End If
            End If
        Next
    End Sub

    Private Sub ComboBox_Leave(sender As Object, e As EventArgs)

        Dim cbo = DirectCast(sender, ComboBox)

        If cbo.SelectedIndex = -1 AndAlso cbo.Tag IsNot Nothing Then
            cbo.SelectedValue = cbo.Tag
        End If

    End Sub

    Protected Overrides Sub OnControlAdded(e As ControlEventArgs)

        MyBase.OnControlAdded(e)

        If TypeOf e.Control Is ComboBox Then

            AddHandler DirectCast(e.Control, ComboBox).Leave, AddressOf ComboBox_Leave

        End If

    End Sub

    Private Sub RegistrarEventosCombos(contenedor As Control)

        For Each ctrl As Control In contenedor.Controls

            If TypeOf ctrl Is ComboBox Then
                AddHandler DirectCast(ctrl, ComboBox).Leave, AddressOf ComboBox_Leave
            End If

            If ctrl.HasChildren Then
                RegistrarEventosCombos(ctrl)
            End If

        Next

    End Sub

    Protected Overrides Sub OnShown(e As EventArgs)

        MyBase.OnShown(e)

        RegistrarEventosCombos(Me)

    End Sub

End Class

