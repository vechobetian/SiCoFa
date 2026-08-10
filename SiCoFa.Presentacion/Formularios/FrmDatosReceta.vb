Imports System.ComponentModel
Imports SiCoFa.Entidades
Imports SiCoFa.Negocio

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

            Dim codigo = ObtenerValor(m_Receta, .Tag.ToString())

            If codigo IsNot Nothing Then
                .Id = codigo
            End If
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
            .Tag = "Documento.TipoDocumento.CodiTD"
            .Name = "UcTipoDocumento"

            ' Cargar el valor actual de la receta
            Dim codigo = ObtenerValor(m_Receta, .Tag.ToString())

            If codigo IsNot Nothing Then
                .Id = codigo
            End If

        End With

        AgregarCampo("Tipo Documento", uc)

    End Sub

    Private Sub AgregarCampoTipoPrescriptor()

        Dim uc As New UcSelectorUniversal

        With uc

            .Objetos = TipoPrescriptor.Lista
            .NombrePropiedadId = "CodiTP"
            .NombrePropiedadDescripcion = "Descripcion"
            .TituloSelector = "Tipos Prescriptores"
            .HeaderDescripcion = "Tipo Prescriptor"
            .ValorPredeterminado = TipoPrescriptor.Predeterminado.CodiTD
            .TextoPredeterminado = TipoPrescriptor.Predeterminado.Descripcion
            .PermitirVacio = False
            .Tag = "Prescriptor.TipoPrescriptor.CodiTP"
            .Name = "UcTipoPrescriptor"

            Dim codigo = ObtenerValor(m_Receta, .Tag.ToString())

            If codigo IsNot Nothing Then
                .Id = codigo
            End If

        End With

        AgregarCampo("Tipo Prescriptor", uc)

    End Sub

    Private Sub AgregarCampoTipoMatricula()

        Dim uc As New UcSelectorUniversal

        With uc

            .Objetos = TipoMatricula.Lista
            .NombrePropiedadId = "CodiTM"
            .NombrePropiedadDescripcion = "Descripcion"
            .TituloSelector = "Tipos Matrícula"
            .HeaderDescripcion = "Tipo Matrícula"
            .ValorPredeterminado = TipoMatricula.Predeterminado.CodiTM
            .TextoPredeterminado = TipoMatricula.Predeterminado.Descripcion
            .PermitirVacio = False
            .Tag = "Prescriptor.Matricula.TipoMatricula.CodiTM"
            .Name = "UcTipoMatricula"

            Dim valor = ObtenerValor(m_Receta, .Tag.ToString())

            If valor IsNot Nothing Then
                .Id = valor
            End If

        End With

        AgregarCampo("Tipo Matrícula", uc)

    End Sub

    Private Sub AgregarCampoProvincia()
        Try
            Dim uc As New UcSelectorUniversal

            With uc
                .Objetos = Provincia.Lista
                .NombrePropiedadId = "CodiP"
                .NombrePropiedadDescripcion = "Provincia"
                .TituloSelector = "Provincias"
                .HeaderDescripcion = "Provincia"
                .PermitirVacio = False
                .Tag = "Prescriptor.Provincia.CodiP"
                .Name = "UcProvincia"

                Dim valor = ObtenerValor(m_Receta, .Tag.ToString())

                If valor IsNot Nothing Then
                    .Id = valor
                End If

            End With

            AgregarCampo("Provincia", uc)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
        End Try

    End Sub

    Private Sub AgregarCampoPrescriptor()

        Try

            Dim adminDB As New N_AdminDB

            Dim sql As String =
            "SELECT IdPrescriptor, Matricula FROM prescriptores ORDER BY Matricula"

            Dim dt As DataTable = adminDB.ObtenerTabla(sql)

            Dim lista As New List(Of SelectorItem)

            For Each fila As DataRow In dt.Rows

                lista.Add(New SelectorItem(
                fila("IdPrescriptor").ToString(),
                fila("Matricula").ToString()))

            Next

            Dim uc As New UcSelectorUniversal

            AddHandler uc.SelectorValidating, AddressOf ValidarPrescriptor

            With uc

                .Objetos = lista
                .NombrePropiedadId = "Id"
                .NombrePropiedadDescripcion = "Descripcion"

                .TituloSelector = "Prescriptores"
                .HeaderDescripcion = "Prescriptor"

                .PermitirVacio = False
                .PermitirNuevo = True
                .IdNuevo = "0"

                .Tag = "Prescriptor.IdPrescriptor"
                .Name = "UcPrescriptor"

                If m_Receta.Prescriptor IsNot Nothing Then

                    If Not String.IsNullOrWhiteSpace(m_Receta.Prescriptor.IdPrescriptor) Then

                        .Id = m_Receta.Prescriptor.IdPrescriptor

                    End If

                End If

            End With

            AgregarCampo("Prescriptor", uc)

        Catch ex As Exception

            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Public Sub New(argReceta As Receta)

        InitializeComponent()

        m_Receta = argReceta

        Me.CargarDatosRequeridos()

    End Sub

    Private Sub FrmDatosReceta_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.Escape Then

            e.Handled = True
            e.SuppressKeyPress = True

            Me.DialogResult = DialogResult.Cancel
            Me.Close()

        End If

    End Sub

    Private Sub ActualizarRecetaDesdeControles()

        For Each pnl As Panel In FlowLayoutPanel1.Controls

            For Each ctrl As Control In pnl.Controls

                If ctrl.Tag Is Nothing Then Continue For

                Dim ruta As String = ctrl.Tag.ToString()

                Select Case True

                    Case TypeOf ctrl Is TextBox

                        AsignarValor(m_Receta, ruta, UCase(DirectCast(ctrl, TextBox).Text))

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

                        If ruta = "Prescriptor.IdPrescriptor" Then

                            If uc.EsNuevo Then

                                AsignarValor(m_Receta, ruta, "")

                                AsignarValor(m_Receta, "Prescriptor.Matricula.Numero", uc.TextoIngresado)

                            Else

                                AsignarValor(m_Receta, ruta, uc.Id)

                                AsignarValor(m_Receta, "Prescriptor.Matricula.Numero", uc.Descripcion)

                            End If

                        Else

                            If uc.EsNuevo Then
                                AsignarValor(m_Receta, ruta, uc.TextoIngresado)
                            Else
                                AsignarValor(m_Receta, ruta, uc.Id)
                            End If

                        End If
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

    Private Function ObtenerValor(obj As Object, ruta As String) As Object

        If obj Is Nothing Then Return Nothing

        Dim actual As Object = obj

        For Each nombre As String In ruta.Split("."c)

            If actual Is Nothing Then Return Nothing

            Dim p = actual.GetType().GetProperty(nombre)

            If p Is Nothing Then Return Nothing

            actual = p.GetValue(actual)

        Next

        Return actual

    End Function

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
            .Name = "Txt" & argRutaPropiedad.Replace(".", "_")
            .Tag = argRutaPropiedad           ' <-- antes guardabas el nombre de la propiedad
            '.Font = New Font("Microsoft Sans Serif", 18, FontStyle.Regular)
        End With

        AddHandler txt.Validating, AddressOf ValidarControl

        ' Cargar valor...
        Dim valor = ObtenerValor(m_Receta, argRutaPropiedad)

        If valor IsNot Nothing Then
            txt.Text = valor.ToString()
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
        Dim valor = ObtenerValor(m_Receta, argRutaPropiedad)

        If valor IsNot Nothing AndAlso TypeOf valor Is Date Then

            Dim fecha As Date = CType(valor, Date)

            If fecha <> Date.MinValue Then
                mtxt.Text = fecha.ToString("dd/MM/yyyy")
            Else
                mtxt.Clear()
            End If

        Else

            mtxt.Clear()

        End If

        AgregarCampo(argTitulo, mtxt)

    End Sub

    Private Sub CargarDatosRequeridos()

        FlowLayoutPanel1.Controls.Clear()

        If m_Receta.Plan.OS.PValidacion.RecetaElectronica = False Then
            AgregarCampoMaskedTextBox("Fecha Prescripcion", NameOf(m_Receta.FechaPrescripcion), "00/00/0000", NameOf(m_Receta.FechaPrescripcion))
            AgregarCampoTratamiento()
        End If

        Dim dr = m_Receta.Plan.DatosRequeridos

        If dr.NumeroAfiliado Then
            AgregarCampoTexto("Número Afiliado", NameOf(m_Receta.Credencial.Numero), "Credencial." & NameOf(m_Receta.Credencial.Numero))
        End If

        If dr.NombreAfiliado Then
            AgregarCampoTexto("Nombre Afiliado", NameOf(m_Receta.Credencial.Nombre), "Credencial." & NameOf(m_Receta.Credencial.Nombre))
        End If

        If dr.DocumentoAfiliado Then
            AgregarCampoTipoDocumento()
            AgregarCampoTexto("Numero Documento", NameOf(m_Receta.Credencial.Documento.Numero), "Documento." & NameOf(m_Receta.Credencial.Documento.Numero))
        End If

        If dr.NumeroReceta Then
            AgregarCampoTexto("Número Receta", NameOf(m_Receta.NumReceta), NameOf(m_Receta.NumReceta))
        End If

        If dr.Prescriptor Then

            AgregarCampoPrescriptor()
            AgregarCampoTipoPrescriptor()
            AgregarCampoTipoMatricula()
            AgregarCampoProvincia()
            AgregarCampoTexto("Apellido", NameOf(m_Receta.Prescriptor.Apellido), "Prescriptor.Apellido")
            AgregarCampoTexto("Nombre", NameOf(m_Receta.Prescriptor.Nombre), "Prescriptor.Nombre")

        End If

        If dr.Token Then
            AgregarCampoTexto("Token", NameOf(m_Receta.Credencial.Token), "Credencial." & NameOf(m_Receta.Credencial.Token))
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

        Try

            If TypeOf sender Is TextBox Then

                Dim txt As TextBox = DirectCast(sender, TextBox)

                If String.IsNullOrWhiteSpace(txt.Text) Then

                    MessageBox.Show("Debe completar " & txt.Tag.ToString() & ".", "SiCoFa", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    txt.Focus()
                    txt.SelectAll()

                    e.Cancel = True

                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub ValidarPrescriptor(sender As Object, e As CancelEventArgs)

        Dim uc = DirectCast(sender, UcSelectorUniversal)

        If uc.EsNuevo = False Then
            CargarDatosPrescriptor(uc.Id)

        Else
            LimpiarDatosPrescriptor()

        End If

    End Sub

    Private Sub LimpiarDatosPrescriptor()

        DirectCast(Controls.Find("UcTipoMatricula", True)(0), UcSelectorUniversal).Limpiar()
        DirectCast(Controls.Find("UcProvincia", True)(0), UcSelectorUniversal).Limpiar()
        DirectCast(Controls.Find("UcTipoPrescriptor", True)(0), UcSelectorUniversal).Limpiar()
        DirectCast(Controls.Find("TxtPrescriptor_Apellido", True)(0), TextBox).Clear()
        DirectCast(Controls.Find("TxtPrescriptor_Nombre", True)(0), TextBox).Clear()
        DesbloquearDatosPrescriptor()

    End Sub

    Private Sub DesbloquearDatosPrescriptor()

        DirectCast(Controls.Find("UcTipoMatricula", True)(0), UcSelectorUniversal).SoloLectura = False
        DirectCast(Controls.Find("UcProvincia", True)(0), UcSelectorUniversal).SoloLectura = False
        DirectCast(Controls.Find("UcTipoPrescriptor", True)(0), UcSelectorUniversal).SoloLectura = False

        Dim txtApellido = DirectCast(Controls.Find("TxtPrescriptor_Apellido", True)(0), TextBox)
        txtApellido.ReadOnly = False
        txtApellido.BackColor = SystemColors.Window
        txtApellido.ForeColor = SystemColors.WindowText

        Dim txtNombre = DirectCast(Controls.Find("TxtPrescriptor_Nombre", True)(0), TextBox)
        txtNombre.ReadOnly = False
        txtNombre.BackColor = SystemColors.Window
        txtNombre.ForeColor = SystemColors.WindowText

    End Sub

    Private Sub CargarDatosPrescriptor(idPrescriptor As String)

        Dim adminDB As New N_AdminDB

        Dim sql As String =
        "SELECT Matricula, Apellido, Nombre " &
        "FROM prescriptores " &
        "WHERE IdPrescriptor = '" & idPrescriptor & "'"

        Dim dt As DataTable = adminDB.ObtenerTabla(sql)

        If dt.Rows.Count = 0 Then Exit Sub

        Dim fila = dt.Rows(0)

        DirectCast(Controls.Find("UcTipoMatricula", True)(0), UcSelectorUniversal).Id = idPrescriptor.Substring(0, 1)
        DirectCast(Controls.Find("UcProvincia", True)(0), UcSelectorUniversal).Id = idPrescriptor.Substring(1, 1)
        DirectCast(Controls.Find("UcTipoPrescriptor", True)(0), UcSelectorUniversal).Id = idPrescriptor.Substring(2, 1)
        DirectCast(Controls.Find("TxtPrescriptor_Apellido", True)(0), TextBox).Text = fila("Apellido").ToString()
        DirectCast(Controls.Find("TxtPrescriptor_Nombre", True)(0), TextBox).Text = fila("Nombre").ToString()
        BloquearDatosPrescriptor()

    End Sub

    Private Sub BloquearDatosPrescriptor()

        DirectCast(Controls.Find("UcTipoMatricula", True)(0), UcSelectorUniversal).SoloLectura = True
        DirectCast(Controls.Find("UcProvincia", True)(0), UcSelectorUniversal).SoloLectura = True
        DirectCast(Controls.Find("UcTipoPrescriptor", True)(0), UcSelectorUniversal).SoloLectura = True

        Dim txtApellido = DirectCast(Controls.Find("TxtPrescriptor_Apellido", True)(0), TextBox)
        txtApellido.ReadOnly = True
        txtApellido.BackColor = Color.White
        txtApellido.ForeColor = Color.Black

        Dim txtNombre = DirectCast(Controls.Find("TxtPrescriptor_Nombre", True)(0), TextBox)
        txtNombre.ReadOnly = True
        txtNombre.BackColor = Color.White
        txtNombre.ForeColor = Color.Black

    End Sub

    Private Sub InsertarPrescriptor(argReceta As Receta)
        Try
            If argReceta.Prescriptor IsNot Nothing Then
                Dim adminDB As New N_AdminDB

                Dim ucPrescriptor = DirectCast(Controls.Find("UcPrescriptor", True)(0), UcSelectorUniversal)

                Dim p = argReceta.Prescriptor
                p.Matricula.Numero = ucPrescriptor.TextoIngresado

                Dim id As String = p.Matricula.TipoMatricula.CodiTMADESFA & p.Provincia.CodiP & p.TipoPrescriptor.CodiTP & p.Matricula.Numero

                Dim valores As New Dictionary(Of String, Object) From {
                                                                        {"IdPrescriptor", id},
                                                                        {"Matricula", p.Matricula.Numero},
                                                                        {"Apellido", p.Apellido},
                                                                        {"Nombre", p.Nombre}
                                                                       }


                adminDB.InsertarRegistro("prescriptores", valores)

                p.IdPrescriptor = id

                Dim lista = DirectCast(ucPrescriptor.Objetos, List(Of SelectorItem))

                lista.Add(New SelectorItem(id, p.Matricula.Numero))

                ucPrescriptor.Asignar(id, p.Matricula.Numero)

            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try
    End Sub

    Private Sub AjustarTamañoFormulario()

        Dim altura As Integer = 0

        For Each ctrl As Control In FlowLayoutPanel1.Controls
            altura += ctrl.Height + ctrl.Margin.Top + ctrl.Margin.Bottom
        Next

        FlowLayoutPanel1.Height = altura + 10

        Me.Height = FlowLayoutPanel1.Bottom + 50

    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean

        If keyData = Keys.F2 Then
            Me.ActualizarRecetaDesdeControles()

            Dim ucPrescriptor = TryCast(Controls.Find("UcPrescriptor", True).FirstOrDefault(), UcSelectorUniversal)

            If ucPrescriptor IsNot Nothing AndAlso ucPrescriptor.EsNuevo Then
                InsertarPrescriptor(m_Receta)
            End If

            Dim adminRecetas As New N_AdminRecetas

            If m_Receta.NumReceta = "*" Then

                Dim rtas As List(Of Receta) = adminRecetas.ConsultaRecetasBeneficiario(m_Receta.Credencial, m_Receta.Plan.OS.PValidacion)

                If rtas.Count = 0 Then
                    MessageBox.Show("Afiliado sin receta electronica", "SiCoFa", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.LimpiarFormulario()
                    ActualizarRecetaDesdeControles()
                    Me.Close()
                    Exit Function
                End If

                Using frm As New FrmRecetasBeneficiario

                    frm.RecetasBeneficiario(rtas)

                    If frm.ShowDialog() = DialogResult.OK Then

                        Dim numeroReceta As String = frm.NumeroRecetaSeleccionada

                        ' Descargar la receta electrónica
                        m_Receta.NumReceta = numeroReceta
                        adminRecetas.ConsultaRecetaElectronica(m_Receta)
                        Close()
                        Me.Close()
                    End If

                End Using
            Else

                Dim rta As Receta = adminRecetas.ConsultaRecetaElectronica(m_Receta)
                Me.Close()
            End If

            Return True   ' Indica que la teck1la fue procesada

        End If

        Return MyBase.ProcessCmdKey(msg, keyData)

    End Function

End Class