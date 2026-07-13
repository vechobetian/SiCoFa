Imports System.Reflection

Public Class UcSelectorUniversal

#Region "Campos"

    Private m_Id As Object

#End Region

#Region "Configuración"

    Public Property Objetos As IEnumerable

    Public Property NombrePropiedadId As String

    Public Property NombrePropiedadDescripcion As String

    Public Property TituloSelector As String = "Selección"

    Public Property HeaderDescripcion As String = "Descripción"

    Public Property BuscarConTextoVacio As Boolean = False

    Public Property PermitirVacio As Boolean = True

    Public Property SoloLectura As Boolean = False

    Public Property ValorPredeterminado As Object = Nothing

    Public Property TextoPredeterminado As String = ""

#End Region

#Region "Propiedades"

    Public Property Id As Object

        Get
            Return m_Id
        End Get

        Set(value As Object)

            m_Id = value

            If Objetos Is Nothing Then Exit Property

            TxtSelector.Text = ""

            For Each obj In Objetos

                If Object.Equals(ObtenerId(obj), value) Then

                    TxtSelector.Text = ObtenerDescripcion(obj)
                    Exit For

                End If

            Next

        End Set

    End Property

    Public Property Descripcion As String
        Get
            Return TxtSelector.Text
        End Get

        Set(value As String)

            TxtSelector.Text = value

            If Objetos Is Nothing Then Exit Property

            For Each obj In Objetos

                If ObtenerDescripcion(obj).ToUpper() = value.ToUpper() Then

                    Id = ObtenerId(obj)
                    Exit For

                End If

            Next

        End Set
    End Property

    Public ReadOnly Property HaySeleccion As Boolean

        Get
            Return Id IsNot Nothing
        End Get

    End Property

#End Region

#Region "Eventos"

    Public Event Seleccionado(sender As Object, e As EventArgs)

    Public Event ValorCambiado(sender As Object, e As EventArgs)

#End Region

#Region "Métodos Públicos"

    Public Sub Limpiar()

        Id = Nothing
        Descripcion = ""

        RaiseEvent ValorCambiado(Me, EventArgs.Empty)

    End Sub

    Public Sub Asignar(id As Object, descripcion As String)

        Me.Id = id
        Me.Descripcion = descripcion

        RaiseEvent ValorCambiado(Me, EventArgs.Empty)

    End Sub

    Public Sub RestablecerValorPredeterminado()

        Me.Id = ValorPredeterminado
        Me.Descripcion = TextoPredeterminado

        RaiseEvent ValorCambiado(Me, EventArgs.Empty)

    End Sub

#End Region

#Region "Eventos del TextBox"

    Private Sub TxtSelector_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtSelector.KeyDown

        If SoloLectura Then Exit Sub

        If e.KeyCode = Keys.Enter Then

            e.SuppressKeyPress = True

            If Buscar() Then

                RaiseEvent Seleccionado(Me, EventArgs.Empty)

                Dim frm As Form = Me.FindForm()

                If frm IsNot Nothing Then

                    frm.SelectNextControl(Me, True, True, True, True)

                End If

            End If

        ElseIf e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True

            If ValorPredeterminado IsNot Nothing Then
                RestablecerValorPredeterminado()
            Else
                Limpiar()
            End If

        ElseIf e.KeyCode = Keys.Escape Then

            e.SuppressKeyPress = True

            If ValorPredeterminado IsNot Nothing Then
                RestablecerValorPredeterminado()
            Else
                Limpiar()
            End If

        End If

    End Sub

    Private Sub TxtSelector_Enter(sender As Object, e As EventArgs) Handles TxtSelector.Enter

        TxtSelector.SelectAll()

    End Sub

    Private Sub TxtSelector_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtSelector.Validating

        If SoloLectura Then Exit Sub

        If String.IsNullOrWhiteSpace(Descripcion) Then

            If ValorPredeterminado IsNot Nothing Then

                RestablecerValorPredeterminado()
                Exit Sub

            End If

            If Not PermitirVacio Then

                MessageBox.Show("Debe seleccionar un " & HeaderDescripcion & ".", "SiCoFa", MessageBoxButtons.OK, MessageBoxIcon.Information)

                e.Cancel = True
                TxtSelector.SelectAll()

            End If

        End If

    End Sub

#End Region

#Region "Búsqueda"

    Private Function ObtenerId(obj As Object) As Object

        If obj Is Nothing Then Return Nothing

        ' Soporte para Dictionary (KeyValuePair)
        If obj.GetType.IsGenericType AndAlso obj.GetType.GetGenericTypeDefinition() = GetType(KeyValuePair(Of ,)) Then

            Return obj.GetType().GetProperty("Key").GetValue(obj)

        End If

        ' Soporte para objetos normales
        If String.IsNullOrWhiteSpace(NombrePropiedadId) Then
            Return Nothing
        End If

        Dim p As PropertyInfo = obj.GetType().GetProperty(NombrePropiedadId)

        If p Is Nothing Then Return Nothing

        Return p.GetValue(obj)

    End Function

    Private Function ObtenerDescripcion(obj As Object) As String

        If obj Is Nothing Then Return ""

        Dim descripcion As Object = Nothing

        ' Dictionary
        If obj.GetType.IsGenericType AndAlso obj.GetType.GetGenericTypeDefinition() = GetType(KeyValuePair(Of ,)) Then

            descripcion = obj.GetType().GetProperty("Value").GetValue(obj)

        Else

            Dim p = obj.GetType().GetProperty(NombrePropiedadDescripcion)
            If p Is Nothing Then Return ""

            descripcion = p.GetValue(obj)

        End If

        If descripcion Is Nothing Then Return ""

        Return descripcion.ToString()

    End Function

    Private Function Buscar() As Boolean

        If Objetos Is Nothing Then Return False

        Dim textoBuscado As String = Descripcion.Trim().ToUpper()

        '----------------------------------------------------
        ' Sin texto: aplicar valor predeterminado
        '----------------------------------------------------
        If textoBuscado = "" Then

            If ValorPredeterminado IsNot Nothing Then

                RestablecerValorPredeterminado()

                RaiseEvent Seleccionado(Me, EventArgs.Empty)

                Return True

            Else

                If PermitirVacio = False Then
                    Return False
                Else
                    Return True
                End If

            End If
        End If

        '----------------------------------------------------
        ' Mostrar todos los elementos
        '----------------------------------------------------
        Dim mostrarTodos As Boolean = (textoBuscado = "*")

        Dim lista As New List(Of Object)

        For Each obj As Object In Objetos

            Dim propiedad As PropertyInfo = obj.GetType().GetProperty(NombrePropiedadDescripcion)

            If propiedad Is Nothing Then Continue For

            Dim valor As String = Convert.ToString(propiedad.GetValue(obj)).ToUpper()

            If mostrarTodos OrElse valor.Contains(textoBuscado) Then

                lista.Add(obj)

            End If

        Next

        Select Case lista.Count

            Case 0

                If PermitirVacio Then

                    Limpiar()

                Else

                    MessageBox.Show("No se encontraron coincidencias.",
                                "SiCoFa",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information)

                    If ValorPredeterminado IsNot Nothing Then
                        RestablecerValorPredeterminado()
                    End If

                End If

                Return False

            Case 1

                AsignarObjeto(lista.First())

                Return True

            Case Else

                Return MostrarSelector(lista)

        End Select

    End Function

#End Region

#Region "Selección"

    Private Sub AsignarObjeto(obj As Object)

        Dim pId As PropertyInfo =
            obj.GetType().GetProperty(NombrePropiedadId)

        Dim pDescripcion As PropertyInfo =
            obj.GetType().GetProperty(NombrePropiedadDescripcion)

        If pId IsNot Nothing Then
            Id = pId.GetValue(obj)
        End If

        If pDescripcion IsNot Nothing Then
            Descripcion = Convert.ToString(pDescripcion.GetValue(obj))
        End If

        RaiseEvent ValorCambiado(Me, EventArgs.Empty)

    End Sub

    Private Function MostrarSelector(lista As List(Of Object)) As Boolean

        Using f As New FrmSelectorUniversal

            f.Text = TituloSelector
            f.Objetos = lista
            f.NombrePropiedadId = NombrePropiedadId
            f.NombrePropiedadDescripcion = NombrePropiedadDescripcion
            f.HeaderPropiedadDescripcion = HeaderDescripcion

            If f.ShowDialog() = DialogResult.OK Then

                Id = f.Valor1Seleccionado
                Descripcion = Convert.ToString(f.Valor2Seleccionado)

                RaiseEvent ValorCambiado(Me, EventArgs.Empty)

                Return True

            Else

                ' El usuario canceló la selección
                Id = Nothing

                If ValorPredeterminado IsNot Nothing Then
                    RestablecerValorPredeterminado()
                Else
                    Descripcion = ""
                End If

                RaiseEvent ValorCambiado(Me, EventArgs.Empty)

                Return False

            End If

        End Using

    End Function

#End Region

End Class