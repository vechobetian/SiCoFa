Imports SiCoFa.Entidades

Public Class FrmDatosReceta
    Private m_Receta As Receta

    Private Sub AgregarCampoTratamiento()

        Dim uc As New UcSelectorUniversal

        With uc
            .Objetos = TipoTratamiento.Lista
            .NombrePropiedadId = "CodiTT"
            .NombrePropiedadDescripcion = "Descripcion"
            .TituloSelector = "Tratamientos"
            .HeaderDescripcion = "Tratamiento"
            .ValorPredeterminado = TipoTratamiento.Predeterminado.CodiTT
            .TextoPredeterminado = TipoTratamiento.Predeterminado.Descripcion
            .PermitirVacio = False
            .Tag = "Tratamiento"
            .Name = "UcTratamiento"
        End With

        AgregarCampo("Tratamiento", uc)

    End Sub

    Private Sub AgregarCampoTipoDocumento()

        Dim uc As New UcSelectorUniversal

        With uc
            .Objetos = TipoDocumento.Lista
            .NombrePropiedadId = "CodiTD"
            .NombrePropiedadDescripcion = "Descripcion"
            .TituloSelector = "Tipos Documento"
            .HeaderDescripcion = "Tipo Documento"
            .ValorPredeterminado = TipoDocumento.Predeterminado.CodiTDADESFA
            .TextoPredeterminado = TipoDocumento.Predeterminado.Descripcion
            .PermitirVacio = False
            .Tag = "Documento.CodiTD"
            .Name = "UcTipoDocumento"
        End With

        AgregarCampo("Tipo Documento", uc)

    End Sub

    Private Sub AgregarCampoTipoPrescriptor()

        Dim uc As New UcSelectorUniversal

        With uc
            .Objetos = TipoPrescriptor.Lista
            .NombrePropiedadId = "CodiTP"
            .NombrePropiedadDescripcion = "Descripcion"
            .TituloSelector = "Tipo Prescriptores"
            .HeaderDescripcion = "Tipo Prescriptor"
            .ValorPredeterminado = TipoDocumento.Predeterminado.CodiTDADESFA
            .TextoPredeterminado = TipoDocumento.Predeterminado.Descripcion
            .PermitirVacio = False
            .Tag = "CodiTP"
        End With

        AgregarCampo("Tipo Prescriptor", uc)

    End Sub

    Public Sub New(argReceta As Receta)

        InitializeComponent()

        m_Receta = argReceta

        Me.CargarDatosRequeridos()

    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message,
                                           keyData As Keys) As Boolean

        If keyData = Keys.F2 Then
            Me.ActualizarRecetaDesdeControles()
            Return True   ' Indica que la teck1la fue procesada
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)

    End Function

    Private Sub ActualizarRecetaDesdeControles()

        For Each pnl As Panel In FlowLayoutPanel1.Controls

            For Each ctrl As Control In pnl.Controls

                If ctrl.Tag Is Nothing Then Continue For

                Dim ruta As String = ctrl.Tag.ToString()

                Select Case True

                    Case TypeOf ctrl Is TextBox

                        AsignarValor(m_Receta, ruta, DirectCast(ctrl, TextBox).Text)

                    Case TypeOf ctrl Is MaskedTextBox

                        Dim mtxt = DirectCast(ctrl, MaskedTextBox)

                        If mtxt.MaskCompleted Then

                            Dim fecha As Date

                            If Date.TryParse(mtxt.Text, fecha) Then
                                AsignarValor(m_Receta, ruta, fecha)
                            End If

                        End If
                    Case TypeOf ctrl Is UcSelectorUniversal
                        Dim uc = DirectCast(ctrl, UcSelectorUniversal)
                        Dim obj As Object = uc.ObjetoSeleccionado

                    Case TypeOf ctrl Is ComboBox

                        AsignarValor(m_Receta, ruta, DirectCast(ctrl, ComboBox).SelectedValue)

                End Select

            Next

        Next

    End Sub

    Private Sub AsignarValor(obj As Object, ruta As String, valor As Object)

        Dim partes() As String = ruta.Split("."c)

        Dim actual As Object = obj

        For i As Integer = 0 To partes.Length - 2

            Dim p = actual.GetType().GetProperty(partes(i))

            Dim siguiente = p.GetValue(actual)

            ' Si el objeto intermedio es Nothing, lo crea
            If siguiente Is Nothing Then
                siguiente = Activator.CreateInstance(p.PropertyType)
                p.SetValue(actual, siguiente)
            End If

            actual = siguiente

        Next

        Dim pFinal = actual.GetType().GetProperty(partes.Last)

        pFinal.SetValue(actual, valor)

    End Sub

    Private Sub AgregarCampo(argTitulo As String, argControl As Control)

        ' Panel contenedor
        Dim pnl As New Panel

        With pnl
            .Width = FlowLayoutPanel1.ClientSize.Width
            .Height = 40
            .Margin = New Padding(3)
        End With

        ' Etiqueta
        Dim lbl As New Label

        With lbl
            .Text = argTitulo & ": "
            .AutoSize = False
            .Width = 255
            .Height = 30
            .Location = New Point(0, 5)
            .TextAlign = ContentAlignment.MiddleLeft
            .Font = New Font("Microsoft Sans Serif", 18, FontStyle.Regular)
        End With

        ' Posicionar el control recibido
        With argControl
            .Location = New Point(259, 3)
            .Width = 500
            .Height = 35
        End With

        pnl.Controls.Add(lbl)
        pnl.Controls.Add(argControl)

        FlowLayoutPanel1.Controls.Add(pnl)

    End Sub

    Private Sub AgregarCampoTexto(argTitulo As String, argNombrePropiedad As String, argRutaPropiedad As String)

        Dim txt As New TextBox

        With txt
            .Name = "Txt" & argNombrePropiedad
            .Tag = argRutaPropiedad           ' <-- antes guardabas el nombre de la propiedad
            '.Font = New Font("Microsoft Sans Serif", 18, FontStyle.Regular)
        End With

        AddHandler txt.Validating, AddressOf ValidarControl

        ' Cargar valor...
        Dim p = GetType(Receta).GetProperty(argNombrePropiedad)

        If p IsNot Nothing Then

            Dim valor = p.GetValue(m_Receta)

            If valor IsNot Nothing Then
                txt.Text = valor.ToString()
            End If

        End If

        AgregarCampo(argTitulo, txt)

    End Sub

    Private Sub AgregarCampoMaskedTextBox(argTitulo As String, argNombrePropiedad As String, argMascara As String, argRutaPropiedad As String)

        Dim mtxt As New MaskedTextBox

        With mtxt
            .Name = "Mtxt" & argNombrePropiedad
            .Tag = argRutaPropiedad
            .Mask = argMascara
            .TextMaskFormat = MaskFormat.IncludeLiterals
            .ValidatingType = GetType(Date)
        End With

        AddHandler mtxt.Validating, AddressOf ValidarFechaPrescripcion

        ' Cargar valor
        Dim p = GetType(Receta).GetProperty(argNombrePropiedad)

        If p IsNot Nothing Then
            Dim valor = p.GetValue(m_Receta)

            If valor IsNot Nothing Then
                If TypeOf valor Is Date Then
                    mtxt.Text = CType(valor, Date).ToString("dd/MM/yyyy")
                Else
                    mtxt.Text = valor.ToString()
                End If
            End If
        End If

        AgregarCampo(argTitulo, mtxt)
        mtxt.Clear()

    End Sub

    Private Sub CargarDatosRequeridos()

        FlowLayoutPanel1.Controls.Clear()

        If m_Receta.Plan.OS.PValidacion.RecetaElectronica = False Then
            AgregarCampoMaskedTextBox("Fecha Prescripcion", NameOf(m_Receta.FechaPrescripcion), "00/00/0000", NameOf(m_Receta.FechaPrescripcion))
            AgregarCampoTratamiento()
        End If

        Dim dr = m_Receta.Plan.DatosRequeridos

        If dr.NumeroAfiliado Then
            AgregarCampoTexto("Número Afiliado", NameOf(m_Receta.Credencial.Numero), "CredencialOS." & NameOf(m_Receta.Credencial.Numero))
        End If

        If dr.NombreAfiliado Then
            AgregarCampoTexto("Nombre Afiliado", NameOf(m_Receta.Credencial.Nombre), "CredencialOS." & NameOf(m_Receta.Credencial.Numero))
        End If

        If dr.DocumentoAfiliado Then
            AgregarCampoTipoDocumento()
            AgregarCampoTexto("Numero Documento", NameOf(m_Receta.Credencial.Documento.Numero), "Documento." & NameOf(m_Receta.Credencial.Documento.Numero))
        End If

        If dr.NumeroReceta Then
            AgregarCampoTexto("Número Receta", NameOf(m_Receta.NumReceta), NameOf(m_Receta.NumReceta))
        End If

        If dr.Prescriptor Then

        End If

        If dr.Token Then
            AgregarCampoTexto("Token", NameOf(m_Receta.Credencial.Token), "CredencialOS." & NameOf(m_Receta.Credencial.Numero))
        End If

        If dr.Diagnostico Then
            AgregarCampoTexto("Diagnostico", NameOf(m_Receta.Diagnostico), NameOf(m_Receta.Diagnostico))
        End If

        AjustarTamañoFormulario()

    End Sub

    Private Sub ValidarFechaPrescripcion(sender As Object, e As System.ComponentModel.CancelEventArgs)

        Dim mtxt As MaskedTextBox = DirectCast(sender, MaskedTextBox)

        If Not mtxt.MaskCompleted Then
            e.Cancel = True
            MessageBox.Show("Debe ingresar la fecha de prescripción", "SiCoFa", MessageBoxButtons.OK, MessageBoxIcon.Information)
            mtxt.Clear()
            Exit Sub
        End If

        Dim fechaPrescripcion As Date

        If Not Date.TryParse(mtxt.Text, fechaPrescripcion) Then
            e.Cancel = True
            MessageBox.Show("La fecha de prescripción ingresada no es válida", "SiCoFa", MessageBoxButtons.OK, MessageBoxIcon.Information)
            mtxt.Clear()
            Exit Sub
        End If

        If Date.Now.Date.Subtract(fechaPrescripcion.Date).Days > m_Receta.Plan.DiasVencimientoRta Then
            e.Cancel = True
            MessageBox.Show("Receta Vencida", "SiCoFa", MessageBoxButtons.OK, MessageBoxIcon.Information)
            mtxt.Clear()
            Exit Sub
        End If

        If fechaPrescripcion.Date > Date.Today Then
            e.Cancel = True
            MessageBox.Show("La fecha de prescripción no puede ser mayor a la fecha actual", "SiCoFa", MessageBoxButtons.OK, MessageBoxIcon.Information)
            mtxt.Clear()
            Exit Sub
        End If

    End Sub

    Private Sub ValidarControl(sender As Object, e As System.ComponentModel.CancelEventArgs)

        If TypeOf sender Is TextBox Then

            Dim txt As TextBox = DirectCast(sender, TextBox)

            If String.IsNullOrWhiteSpace(txt.Text) Then

                MessageBox.Show("Debe completar " & txt.Tag.ToString() & ".", "SiCoFa", MessageBoxButtons.OK, MessageBoxIcon.Information)

                txt.Focus()
                txt.SelectAll()

                e.Cancel = True

            End If

        End If

    End Sub

    Private Sub AjustarTamañoFormulario()

        Dim altura As Integer = 0

        For Each ctrl As Control In FlowLayoutPanel1.Controls
            altura += ctrl.Height + ctrl.Margin.Top + ctrl.Margin.Bottom
        Next

        FlowLayoutPanel1.Height = altura + 10

        Me.Height = FlowLayoutPanel1.Bottom + 50

    End Sub

End Class