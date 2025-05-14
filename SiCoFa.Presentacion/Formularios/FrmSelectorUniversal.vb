Imports System.Reflection
Public Class FrmSelectorUniversal
    Property Objetos As IEnumerable
    Property HeaderPropiedadDescripcion As String
    Property NombrePropiedadId As String ' Nombre de la propiedad que actúa como identificador
    Property NombrePropiedadDescripcion As String ' Nombre de la propiedad que actúa como descripción
    Property PropiedadValor1 As String ' Propiedad a devolver como Valor1 (aquí será NombrePropiedadId)
    Property PropiedadValor2 As String ' Propiedad a devolver como Valor2 (aquí será NombrePropiedadDescripcion)

    Private m_Valor1Seleccionado As Object
    Private m_Valor2Seleccionado As Object

    Public ReadOnly Property Valor1Seleccionado As Object
        Get
            Return m_Valor1Seleccionado
        End Get
    End Property

    Public ReadOnly Property Valor2Seleccionado As Object
        Get
            Return m_Valor2Seleccionado
        End Get
    End Property
    Private Sub FrmSelectorUniversal_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Objetos Is Nothing OrElse String.IsNullOrEmpty(NombrePropiedadId) OrElse String.IsNullOrEmpty(NombrePropiedadDescripcion) Then
            MessageBox.Show("Debe proporcionar una colección de objetos y los nombres de las propiedades Id y Descripción.", "Error de Configuración", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
            Exit Sub
        End If

        ' Limpiamos las columnas
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.Columns.Clear()

        ' Creamos la columna para la Descripción (lo que se mostrará)
        Dim columnaDescripcion As New DataGridViewTextBoxColumn()
        columnaDescripcion.HeaderText = Me.HeaderPropiedadDescripcion
        columnaDescripcion.DataPropertyName = NombrePropiedadDescripcion ' Enlazamos a la propiedad de descripción
        columnaDescripcion.Width = 350
        Me.DataGridView1.Columns.Add(columnaDescripcion)

        ' Asignamos la colección de objetos como DataSource
        Me.DataGridView1.DataSource = Objetos

        ' Establecemos la primera celda activa
        If Me.DataGridView1.Rows.Count > 0 AndAlso Me.DataGridView1.Columns.Count > 0 Then
            Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(0).Cells(0)
        End If

        ' Establecemos las propiedades de valor a retornar
        PropiedadValor1 = NombrePropiedadId
        PropiedadValor2 = NombrePropiedadDescripcion
    End Sub
    Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.DialogResult = DialogResult.Cancel
                Me.Close()

            Case Keys.Enter
                e.Handled = True
                e.SuppressKeyPress = True ' evita beep y evita que pase al próximo control

                If Me.DataGridView1.CurrentRow IsNot Nothing Then
                    Dim rowIndex As Integer = Me.DataGridView1.CurrentRow.Index

                    Dim objetoSeleccionado As Object = Me.DataGridView1.Rows(rowIndex).DataBoundItem

                    If objetoSeleccionado IsNot Nothing Then
                        Dim tipoObjeto As Type = objetoSeleccionado.GetType()

                        ' Obtener Valor1 (Identificador)
                        Dim propiedadValor1Info As PropertyInfo = tipoObjeto.GetProperty(NombrePropiedadId)
                        If propiedadValor1Info IsNot Nothing Then
                            m_Valor1Seleccionado = propiedadValor1Info.GetValue(objetoSeleccionado)
                        Else
                            m_Valor1Seleccionado = Nothing
                        End If

                        ' Obtener Valor2 (Descripción)
                        Dim propiedadValor2Info As PropertyInfo = tipoObjeto.GetProperty(NombrePropiedadDescripcion)
                        If propiedadValor2Info IsNot Nothing Then
                            m_Valor2Seleccionado = propiedadValor2Info.GetValue(objetoSeleccionado)
                        Else
                            m_Valor2Seleccionado = Nothing
                        End If

                        Me.DialogResult = DialogResult.OK
                        Me.Hide()
                    End If
                End If
        End Select
    End Sub


End Class