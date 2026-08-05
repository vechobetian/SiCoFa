Imports System.Reflection

Public Class UcSelectorUniversal

#Region "Campos privados"

    Private m_Id As Object
    Private m_EsNuevo As Boolean
    Private m_ObjetoSeleccionado As Object
    Private m_SoloLectura As Boolean

#End Region

#Region "Propiedades de configuración"

    Public Property Objetos As IEnumerable

    Public Property NombrePropiedadId As String

    Public Property NombrePropiedadDescripcion As String

    Public Property TituloSelector As String = "Selección"

    Public Property HeaderDescripcion As String = "Descripción"

    Public Property BuscarConTextoVacio As Boolean = False

    Public Property PermitirVacio As Boolean = True

    Public Property ValorPredeterminado As Object = Nothing

    Public Property TextoPredeterminado As String = ""

    Public Property PermitirNuevo As Boolean = False

    Public Property IdNuevo As Object = Nothing

#End Region

#Region "Propiedades públicas"

    Public Property SoloLectura As Boolean

        Get
            Return m_SoloLectura
        End Get

        Set(value As Boolean)

            m_SoloLectura = value

            If IsHandleCreated Then
                ActualizarSoloLectura()
            End If

        End Set

    End Property

    Public ReadOnly Property TextoIngresado As String

        Get
            Return TxtSelector.Text.Trim()
        End Get

    End Property

    Public ReadOnly Property EsNuevo As Boolean

        Get
            Return m_EsNuevo
        End Get

    End Property

    Public ReadOnly Property ObjetoSeleccionado As Object

        Get
            Return m_ObjetoSeleccionado
        End Get

    End Property

    Public Property Id As Object

        Get
            Return m_Id
        End Get

        Set(value As Object)

            m_Id = value
            m_ObjetoSeleccionado = Nothing
            m_EsNuevo = False

            TxtSelector.Text = ""

            If Objetos Is Nothing Then Exit Property


            For Each obj In Objetos

                If Object.Equals(ObtenerId(obj), value) Then

                    m_ObjetoSeleccionado = obj
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

                If String.Equals(ObtenerDescripcion(obj), value, StringComparison.OrdinalIgnoreCase) Then

                    m_Id = ObtenerId(obj)
                    m_ObjetoSeleccionado = obj

                    Exit For

                End If

            Next

        End Set

    End Property

    Public ReadOnly Property HaySeleccion As Boolean

        Get
            Return m_Id IsNot Nothing
        End Get

    End Property

#End Region

#Region "Eventos"

    Public Event Seleccionado(sender As Object, e As EventArgs)

    Public Event ValorCambiado(sender As Object, e As EventArgs)

    Public Event SelectorValidating(sender As Object, e As System.ComponentModel.CancelEventArgs)

#End Region

#Region "Métodos públicos"

    Public Sub Limpiar()

        m_Id = Nothing
        m_ObjetoSeleccionado = Nothing
        m_EsNuevo = False

        TxtSelector.Text = ""

        RaiseEvent ValorCambiado(Me, EventArgs.Empty)

    End Sub

    Public Sub Asignar(id As Object, descripcion As String)

        m_Id = id
        m_ObjetoSeleccionado = Nothing
        m_EsNuevo = False

        If Objetos IsNot Nothing Then

            For Each obj In Objetos

                If Object.Equals(ObtenerId(obj), id) Then

                    m_ObjetoSeleccionado = obj
                    Exit For

                End If

            Next

        End If

        TxtSelector.Text = descripcion

        RaiseEvent ValorCambiado(Me, EventArgs.Empty)

    End Sub

    Public Sub RestablecerValorPredeterminado()

        If ValorPredeterminado Is Nothing Then

            Limpiar()
            Return

        End If

        If Objetos IsNot Nothing Then

            For Each obj In Objetos

                If Object.Equals(ObtenerId(obj), ValorPredeterminado) Then

                    AsignarObjeto(obj)
                    Return

                End If

            Next

        End If

        'Si no existe el objeto en la lista
        m_Id = ValorPredeterminado
        m_ObjetoSeleccionado = Nothing
        m_EsNuevo = False

        TxtSelector.Text = TextoPredeterminado

        RaiseEvent ValorCambiado(Me, EventArgs.Empty)

    End Sub

#End Region

#Region "Métodos internos de selección"

    Private Sub AsignarObjeto(obj As Object)

        If obj Is Nothing Then

            Limpiar()
            Return

        End If

        m_EsNuevo = False
        m_ObjetoSeleccionado = obj
        m_Id = ObtenerId(obj)

        TxtSelector.Text = ObtenerDescripcion(obj)

        RaiseEvent ValorCambiado(Me, EventArgs.Empty)

    End Sub

    Private Sub IrAlSiguienteControl()

        Dim frm As Form = Me.FindForm()

        If frm Is Nothing Then Exit Sub

        frm.SelectNextControl(TxtSelector, True, True, True, True)

    End Sub

#End Region

#Region "Eventos del TextBox"

    Private Sub TxtSelector_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtSelector.KeyDown

        If SoloLectura Then

            If e.KeyCode = Keys.Enter Then

                e.SuppressKeyPress = True

                IrAlSiguienteControl()

            End If

            Exit Sub

        End If

        Select Case e.KeyCode

            Case Keys.Enter

                e.SuppressKeyPress = True

                If Buscar() Then

                    RaiseEvent Seleccionado(Me, EventArgs.Empty)

                    IrAlSiguienteControl()

                End If

            Case Keys.Tab

                e.SuppressKeyPress = True


                If ValorPredeterminado IsNot Nothing Then

                    RestablecerValorPredeterminado()

                Else

                    Limpiar()

                End If

            Case Keys.Escape

                e.SuppressKeyPress = True

                If ValorPredeterminado IsNot Nothing Then

                    RestablecerValorPredeterminado()

                Else

                    Limpiar()

                End If

        End Select

    End Sub

    Private Sub TxtSelector_Enter(sender As Object, e As EventArgs) Handles TxtSelector.Enter

        TxtSelector.SelectAll()

    End Sub

    Private Sub TxtSelector_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtSelector.Validating

        RaiseEvent SelectorValidating(Me, e)

        If e.Cancel Then Exit Sub

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

#Region "Inicialización"

    Private Sub UcSelectorUniversal_Load(sender As Object, e As EventArgs) Handles Me.Load

        TxtSelector.Font = Me.Font

        ActualizarSoloLectura()

    End Sub

#End Region

#Region "Estado visual"

    Private Sub ActualizarSoloLectura()

        TxtSelector.ReadOnly = SoloLectura

        TxtSelector.BackColor = Color.White

        TxtSelector.ForeColor = Color.Black

    End Sub

#End Region

#Region "Búsqueda"

    Private Function Buscar() As Boolean

        If Objetos Is Nothing Then Return False

        Dim textoBuscado As String = Descripcion.Trim().ToUpper()

        '--------------------------------------------------
        ' Sin texto
        '--------------------------------------------------

        If textoBuscado = "" Then

            If ValorPredeterminado IsNot Nothing Then

                RestablecerValorPredeterminado()

                RaiseEvent Seleccionado(Me, EventArgs.Empty)

                Return True

            End If

            If PermitirVacio Then

                Return True

            End If

            Return False

        End If

        Dim mostrarTodos As Boolean = (textoBuscado = "*")

        Dim lista As New List(Of Object)

        For Each obj As Object In Objetos

            Dim descripcion As String = ObtenerDescripcion(obj).ToUpper()

            If mostrarTodos OrElse descripcion.Contains(textoBuscado) Then

                lista.Add(obj)

            End If

        Next

        Select Case lista.Count

            Case 0

                If PermitirNuevo Then

                    m_EsNuevo = True

                    m_Id = IdNuevo

                    m_ObjetoSeleccionado = Nothing

                    TxtSelector.Text = textoBuscado

                    RaiseEvent ValorCambiado(Me, EventArgs.Empty)

                    Return True

                End If

                If PermitirVacio Then

                    Limpiar()

                Else

                    MessageBox.Show("No se encontraron coincidencias.", "SiCoFa", MessageBoxButtons.OK, MessageBoxIcon.Information)

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

#Region "Selector"

    Private Function MostrarSelector(lista As List(Of Object)) As Boolean

        Using f As New FrmSelectorUniversal

            f.Text = TituloSelector

            f.Objetos = lista

            f.NombrePropiedadId = NombrePropiedadId

            f.NombrePropiedadDescripcion = NombrePropiedadDescripcion

            f.HeaderPropiedadDescripcion = HeaderDescripcion

            If f.ShowDialog() = DialogResult.OK Then

                Asignar(f.Valor1Seleccionado, Convert.ToString(f.Valor2Seleccionado))

                Return True

            End If

            'Cancelación

            If ValorPredeterminado IsNot Nothing Then

                RestablecerValorPredeterminado()

            Else

                Limpiar()

            End If

            Return False

        End Using

    End Function

#End Region

#Region "Reflexión"

    Private Function ObtenerId(obj As Object) As Object

        If obj Is Nothing Then Return Nothing

        'Soporte KeyValuePair

        If obj.GetType().IsGenericType AndAlso
           obj.GetType().GetGenericTypeDefinition() = GetType(KeyValuePair(Of ,)) Then

            Return obj.GetType().GetProperty("Key").GetValue(obj)

        End If

        If String.IsNullOrWhiteSpace(NombrePropiedadId) Then

            Return Nothing

        End If

        Dim propiedad As PropertyInfo = obj.GetType().GetProperty(NombrePropiedadId)

        If propiedad Is Nothing Then

            Return Nothing

        End If

        Return propiedad.GetValue(obj)

    End Function

    Private Function ObtenerDescripcion(obj As Object) As String

        If obj Is Nothing Then Return ""

        Dim valor As Object = Nothing

        'Soporte KeyValuePair

        If obj.GetType().IsGenericType AndAlso
           obj.GetType().GetGenericTypeDefinition() = GetType(KeyValuePair(Of ,)) Then

            valor = obj.GetType().GetProperty("Value").GetValue(obj)

        Else

            If String.IsNullOrWhiteSpace(NombrePropiedadDescripcion) Then

                Return ""

            End If

            Dim propiedad As PropertyInfo = obj.GetType().GetProperty(NombrePropiedadDescripcion)

            If propiedad Is Nothing Then

                Return ""

            End If

            valor = propiedad.GetValue(obj)

        End If

        If valor Is Nothing Then Return ""

        Return valor.ToString()

    End Function

#End Region

End Class