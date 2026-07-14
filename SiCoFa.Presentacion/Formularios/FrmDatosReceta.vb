Imports SiCoFa.Entidades

Public Class FrmDatosReceta
    Private m_Receta As Receta

    Public Sub New(argReceta As Receta)

        InitializeComponent()

        m_Receta = argReceta

        Me.CargarDatosRequeridos()

    End Sub

    Private Sub AgregarCampoTexto(argTitulo As String, argNombrePropiedad As String)

        ' Panel contenedor
        Dim pnl As New Panel

        With pnl
            .Width = FlowLayoutPanel1.ClientSize.Width - 25
            .Height = 55
            .Margin = New Padding(3)
        End With

        ' Etiqueta
        Dim lbl As New Label

        With lbl
            .Text = argTitulo
            .AutoSize = False
            .Location = New Point(12, 36)
            .Font = New Font("Microsoft Sans Serif", 18, FontStyle.Regular)
        End With

        ' Caja de texto
        Dim txt As New TextBox

        With txt
            .Name = "Txt" & argNombrePropiedad
            .Tag = argNombrePropiedad
            .Width = pnl.Width
            .Location = New Point(0, 22)
            .Font = New Font("Microsoft Sans Serif", 18, FontStyle.Regular)
        End With

        ' Si la propiedad ya tiene un valor en la receta, lo mostramos
        Dim p = GetType(Receta).GetProperty(argNombrePropiedad)

        If p IsNot Nothing Then

            Dim valor = p.GetValue(m_Receta)

            If valor IsNot Nothing Then
                txt.Text = valor.ToString()
            End If

        End If

        pnl.Controls.Add(lbl)
        pnl.Controls.Add(txt)

        FlowLayoutPanel1.Controls.Add(pnl)

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
            AgregarCampoTexto("Tipo Documento", NameOf(m_Receta.Credencial.Documento.TipoDoc))
            AgregarCampoTexto("Numero Documento", NameOf(m_Receta.Credencial.Documento.Numero))
        End If

        If dr.NumeroReceta Then
            AgregarCampoTexto("Número Receta", NameOf(m_Receta.NumReceta))
        End If

        If dr.Token Then
            AgregarCampoTexto("Token", NameOf(m_Receta.Credencial.Token))
        End If

    End Sub

End Class