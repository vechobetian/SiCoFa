Imports SiCoFa.Entidades

Public Class FrmDatosReceta
    Private m_Receta As Receta

    Private Sub CargarSelectorTratamiento()

        Try
            With UcTratamiento
                .Objetos = TipoTratamiento.Lista
                .NombrePropiedadId = "CodiTT"
                .NombrePropiedadDescripcion = "Descripcion"
                .TituloSelector = "Tipos Tratamiento"
                .HeaderDescripcion = "Tipo Tratamiento"
                .ValorPredeterminado = TipoTratamiento.Predeterminado.CodiTT
                .TextoPredeterminado = TipoTratamiento.Predeterminado.Descripcion
                .PermitirVacio = False
            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try
    End Sub

    Private Sub AgregarCampoTipoDocumento()

        Dim uc As New UcSelectorUniversal

        With uc
            .Objetos = TipoDocumento.Lista
            .NombrePropiedadId = "CodiTDoc"
            .NombrePropiedadDescripcion = "Descripcion"
            .TituloSelector = "Tipos Documento"
            .HeaderDescripcion = "Tipo Documento"
            .ValorPredeterminado = TipoDocumento.Predeterminado.CodiTDocADESFA
            .TextoPredeterminado = TipoDocumento.Predeterminado.Descripcion
            .PermitirVacio = False
            .Tag = "Credencial.Documento.TipoDoc"
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
            .TituloSelector = "Tipos Documento"
            .HeaderDescripcion = "Tipo Documento"
            .ValorPredeterminado = TipoDocumento.Predeterminado.CodiTDocADESFA
            .TextoPredeterminado = TipoDocumento.Predeterminado.Descripcion
            .PermitirVacio = False
            .Tag = "Credencial.Documento.TipoDoc"
        End With

        AgregarCampo("Tipo Documento", uc)

    End Sub

    Public Sub New(argReceta As Receta)

        InitializeComponent()

        m_Receta = argReceta

        Me.CargarSelectorTratamiento()
        Me.CargarDatosRequeridos()

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

    Private Sub AgregarCampoTexto(argTitulo As String, argNombrePropiedad As String)

        Dim txt As New TextBox

        With txt
            .Name = "Txt" & argNombrePropiedad
            .Tag = argNombrePropiedad
            '.Font = New Font("Microsoft Sans Serif", 18, FontStyle.Regular)
        End With

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

    Private Sub CargarDatosRequeridos()

        FlowLayoutPanel1.Controls.Clear()

        If m_Receta Is Nothing Then Exit Sub
        If m_Receta.Plan Is Nothing Then Exit Sub
        If m_Receta.Plan.DatosRequeridos Is Nothing Then Exit Sub

        Dim dr = m_Receta.Plan.DatosRequeridos

        If dr.NumeroAfiliado Then
            AgregarCampoTexto("Número Afiliado", NameOf(m_Receta.Credencial.Numero))
        End If

        If dr.NombreAfiliado Then
            AgregarCampoTexto("Nombre Afiliado", NameOf(m_Receta.Credencial.Nombre))
        End If

        If dr.DocumentoAfiliado Then
            AgregarCampoTipoDocumento()
            AgregarCampoTexto("Numero Documento", NameOf(m_Receta.Credencial.Documento.Numero))
        End If

        If dr.NumeroReceta Then
            AgregarCampoTexto("Número Receta", NameOf(m_Receta.NumReceta))
        End If

        If dr.Prescriptor Then

        End If

        If dr.Token Then
            AgregarCampoTexto("Token", NameOf(m_Receta.Credencial.Token))
        End If

        If dr.Diagnostico Then
            AgregarCampoTexto("Diagnostico", NameOf(m_Receta.Diagnostico))
        End If

        AjustarTamañoFormulario()

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