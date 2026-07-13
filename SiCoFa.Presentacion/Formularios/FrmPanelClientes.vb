Imports System.ComponentModel
Imports SiCoFa.Entidades
Imports SiCoFa.Negocio
Public Class FrmPanelClientes
    Private TextoBuscar As String
    Private NuevaPersona As Boolean
    Private NuevaCtaCte As Boolean
    Private mobj_AdminClientes As New N_AdminClientes
    Private ControlesReadOnly As New List(Of String) From {"TxtId", "TxtFechaAltaCliente", "TxtIdCC", "TxtDescripcion", "TxtFechaAltaCuentaCorriente"}
    Private DatosOpcionales As New List(Of String) From {"TxtId", "TxtDomicilio", "TxtLocalidad", "UcProvincia", "TxtTelefono", "TxtEmail", "TxtIdCC", "TxtDescripcion", "TxtObservaciones"}
    Private pestanaCuentaCorriente As TabPage
    Private indiceOriginalCuentaCorriente As Integer

    Private Sub OcultarPestanaCuentaCorriente()
        Try

            If Me.PanelCliente.TabPages.Contains(pestanaCuentaCorriente) Then
                Me.PanelCliente.TabPages.Remove(pestanaCuentaCorriente)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Private Sub MostrarPestanaCuentaCorriente()
        Try

            If Not Me.PanelCliente.TabPages.Contains(pestanaCuentaCorriente) AndAlso pestanaCuentaCorriente IsNot Nothing Then
                If indiceOriginalCuentaCorriente >= 0 AndAlso indiceOriginalCuentaCorriente <= Me.PanelCliente.TabPages.Count Then
                    Me.PanelCliente.TabPages.Insert(indiceOriginalCuentaCorriente, pestanaCuentaCorriente)
                Else
                    ' Si el índice no es válido, la agrega al final (esto no debería ocurrir aquí)
                    Me.PanelCliente.TabPages.Add(pestanaCuentaCorriente)
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Private Sub CargarSelectorProvincia()
        Try
            With UcProvincia
                .Objetos = Provincia.Lista
                .NombrePropiedadId = "CodiProvincia"
                .NombrePropiedadDescripcion = "Provincia"
                .TituloSelector = "Provincias"
                .HeaderDescripcion = "Provincia"
                .PermitirVacio = True
            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
        End Try

    End Sub

    Private Sub CargarSelectorTipoDoc()

        Try
            With UcTipoDoc
                .Objetos = TipoDocumento.Lista
                .NombrePropiedadId = "CodiTDoc"
                .NombrePropiedadDescripcion = "Descripcion"
                .TituloSelector = "Tipos Documento"
                .HeaderDescripcion = "Tipo Documento"
                .ValorPredeterminado = "DNI"
                .TextoPredeterminado = "DOCUMENTO NACIONAL DE IDENTIDAD"
                .PermitirVacio = False
            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub CargarSelectorEstado()

        Try
            Dim estados As New Dictionary(Of String, String)

            With estados
                .Add("A", "ACTIVO")
                .Add("B", "BAJA")
            End With

            With UcEstado
                .Objetos = estados
                .NombrePropiedadId = "Key"
                .NombrePropiedadDescripcion = "Value"
                .TituloSelector = "Estados"
                .HeaderDescripcion = "Estado"
                .ValorPredeterminado = "A"
                .TextoPredeterminado = "ACTIVO"
                .PermitirVacio = False
            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try


    End Sub

    Private Sub CargarSelectorEstadoCC()

        Try
            Dim estados As New Dictionary(Of String, String)

            With estados
                .Add("H", "HABILITADA")
                .Add("B", "BAJA")
                .Add("S", "SUSPENDIDA")
            End With

            With UcEstadoCC
                .Objetos = estados
                .NombrePropiedadId = "Key"
                .NombrePropiedadDescripcion = "Value"
                .TituloSelector = "Estados"
                .HeaderDescripcion = "Estado"
                .ValorPredeterminado = "H"
                .TextoPredeterminado = "HABILITADA"
                .PermitirVacio = False
            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try


    End Sub

    Private Sub CargarSelectorIVA()

        Try

            With UcIVA
                .Objetos = TipoIVA.Lista
                .NombrePropiedadId = "CodIVA"
                .NombrePropiedadDescripcion = "Descripcion"
                .TituloSelector = "Tipos de IVA"
                .HeaderDescripcion = "Tipo IVA"
                .ValorPredeterminado = "CF"
                .TextoPredeterminado = "CONSUMIDOR FINAL"
                .PermitirVacio = False
            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Function SeleccionarClienteListado(ByVal Id As Int32, ByVal ListaClientes As List(Of Cliente)) As Cliente

        Try
            Dim ClienteSeleccionado As Cliente = Nothing

            For Each c As Cliente In ListaClientes
                If c.Id = Id Then
                    ClienteSeleccionado = c
                    Exit For ' Opcional: detener la búsqueda una vez encontrado el cliente
                End If
            Next
            Return ClienteSeleccionado

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
            Return Nothing
        End Try

    End Function

    Private Sub BuscarCliente(ByVal argTextoBuscado As String)

        Try

            Dim lc As List(Of Cliente) = mobj_AdminClientes.ListarClientes(argTextoBuscado)
            Dim c As Cliente = Nothing

            If lc Is Nothing Then
                MsgBox("Cliente no Encontrado", vbInformation, "SiCoFa")
                Exit Sub
            End If

            Select Case lc.Count
                Case 0
                    MsgBox("Cliente no Encontrado", vbInformation, "SiCoFa")
                    Me.TxtNombre.Text = ""
                    Me.TxtNombre.Select()
                    Exit Sub

                Case 1
                    c = lc.First

                Case > 1
                    Using f As New FrmBuscaPersonas
                        f.Personas = lc
                        f.ShowDialog()
                        If f.DialogResult = DialogResult.OK Then
                            Dim p As Persona = f.PersonaSeleccionado
                            c = Me.SeleccionarClienteListado(p.Id, lc)
                        End If
                        f.Close()
                    End Using
            End Select

            With Me
                .LimpiarFormulario()
                .MostrarCliente(c)
                .MostrarCuentaCorriente(c.Id)
                .TxtNombre.ReadOnly = True
                .TxtNombre.Select()
                .TxtNombre.SelectAll()
            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
        End Try

    End Sub

    Private Sub MostrarCliente(ByVal argCliente As Cliente)

        Try
            With Me
                .TxtId.Text = argCliente.Id
                .TxtNombre.Text = argCliente.Nombre
                .TxtDomicilio.Text = argCliente.Domicilio
                .TxtLocalidad.Text = argCliente.Localidad
                .UcProvincia.Descripcion = argCliente.Provincia
                .TxtTelefono.Text = argCliente.Telefono
                .TxtEmail.Text = argCliente.Email
                .UcTipoDoc.Id = argCliente.Documento.TipoDoc.CodiTDoc
                .TxtNumDoc.Text = argCliente.Documento.Numero
                .TxtFechaAltaCliente.Text = argCliente.FechaAlta
                .UcEstado.Descripcion = argCliente.Estado
                .UcIVA.Id = argCliente.IVA.CodIVA
            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub MostrarCuentaCorriente(ByVal argIdCliente As Int32)
        Try
            Dim cc As CuentaCorriente = mobj_AdminClientes.ObtenerCuentaCorrientePorIdCliente(argIdCliente)
            If cc IsNot Nothing Then
                Me.TxtIdCC.Text = cc.IdCC
                Me.TxtDescripcion.Text = cc.Descripcion
                Me.TxtCredito.Text = cc.Credito
                Me.TxtFechaAltaCuentaCorriente.Text = cc.FechaAlta
                Me.UcEstadoCC.Descripcion = cc.Estado
                Me.TxtObservaciones.Text = cc.Observaciones
                Me.MostrarPestanaCuentaCorriente()
            Else
                Me.TxtIdCC.Text = ""
                Me.TxtDescripcion.Text = ""
                Me.TxtCredito.Text = ""
                Me.UcEstadoCC.Descripcion = ""
                Me.TxtObservaciones.Text = ""
                Me.NuevaCuentaCorriente.Visible = True

            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub Guardar_Click(sender As Object, e As EventArgs) Handles Guardar.Click

        Try
            Me.ValidarCampos(Me.Cliente, DatosOpcionales)

            If Me.ValidacionOK = False Then
                Exit Sub
            End If

            If Me.NuevaPersona = True Then

                Dim IdCliente As Integer = mobj_AdminClientes.InsertarCliente(Me.TxtNombre.Text, Me.TxtDomicilio.Text, Me.TxtLocalidad.Text, UcProvincia.Descripcion, Me.TxtTelefono.Text, Me.TxtEmail.Text, UcTipoDoc.Id, Me.TxtNumDoc.Text, Me.UcIVA.Id)
                If IdCliente > 0 Then
                    Me.TxtId.Text = IdCliente
                    Me.TxtNombre.Text = UCase(Me.TxtNombre.Text)
                    MsgBox("Se dio de alta el Cliente " & TxtNombre.Text,, "SiCoFa")
                Else
                    MsgBox("Ocurrio un error, intente nuevamente",, "SiCoFa")
                    Exit Sub
                End If

                Me.NuevaPersona = False
                Me.NuevoCliente.Checked = False

            Else
                If Me.TxtId.Text = "" Then
                    MsgBox("El cliente " & Me.TxtNombre.Text & " no fue dado de Alta", vbInformation, "SiCoFa")
                    Exit Sub
                End If

                Dim Actualizado As Boolean = mobj_AdminClientes.ActualizarCliente(Me.TxtId.Text, Me.TxtDomicilio.Text, Me.TxtLocalidad.Text, UcProvincia.Descripcion, Me.TxtTelefono.Text, Me.TxtEmail.Text, UcTipoDoc.Id, Me.TxtNumDoc.Text, Me.UcIVA.Id, Me.UcEstado.Descripcion)

                If Actualizado = True Then
                    MsgBox("El Cliente " & TxtNombre.Text & " se acutalizo correctamente",, "SiCoFa")
                Else
                    MsgBox("Ocurrio un error, intente nuevamente", "SiCoFa")
                    Exit Sub
                End If
            End If

            If Me.NuevaCtaCte = True Or Me.TxtIdCC.Text <> "" Then
                Me.ValidacionOK = False
                Me.ValidarCampos(Me.CuentaCorriente, DatosOpcionales)
            End If

            If Me.ValidacionOK = False Then
                Exit Sub
            End If

            If Me.NuevaCtaCte = True Then

                Dim IdCC As Integer = mobj_AdminClientes.InsertarCuentaCorriente(Me.TxtId.Text, UCase(Me.TxtDescripcion.Text), Convert.ToDecimal(Me.TxtCredito.Text), Me.TxtObservaciones.Text)
                If IdCC > 0 Then
                    Me.TxtIdCC.Text = IdCC
                Else
                    MsgBox("No se pudo crear la cuenta corriente, intente nuevamente",, "SiCoFa")
                    Exit Sub
                End If

                Me.NuevaCtaCte = False
                Me.NuevoCliente.Checked = False

            ElseIf Me.TxtIdCC.Text <> "" Then

                Dim Actualizado As Boolean = mobj_AdminClientes.ActualizarCuentaCorriente(Me.TxtIdCC.Text, Me.TxtCredito.Text, Me.TxtObservaciones.Text, Me.UcEstadoCC.Descripcion)

                If Actualizado = False Then
                    MsgBox("No se pudo actualizar la cuenta corriente, intente nuevamente", "SiCoFa")
                    Exit Sub
                End If
            End If

            Me.LimpiarFormulario()
            Me.OcultarPestanaCuentaCorriente()
            Me.PanelCliente.SelectedTab = Me.Cliente
            Me.TxtNombre.ReadOnly = False
            Me.TxtNombre.Select()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try
    End Sub

    Private Sub NuevoCliente_Click(sender As Object, e As EventArgs) Handles NuevoCliente.Click
        Try
            Me.LimpiarFormulario()
            Me.NuevaPersona = True
            Me.NuevoCliente.Checked = True
            Me.TxtNombre.ReadOnly = False
            Me.TxtNombre.Select()

            Dim valoresDefecto As New Dictionary(Of String, Object)

            With valoresDefecto
                .Add("TxtFechaAltaCliente", Date.Today.ToShortDateString)
                .Add("TxtFechaAltaCuentaCorriente", Date.Today.ToShortDateString)
            End With

            Me.EstablecerValoresPorDefecto(Me.Cliente, valoresDefecto)
            Me.EstablecerValoresPorDefecto(Me.CuentaCorriente, valoresDefecto)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try
    End Sub
    Private Sub Buscar_Click(sender As Object, e As EventArgs) Handles Buscar.Click

        Try
            If Me.NuevaPersona = True Then
                Exit Sub
            End If

            Dim str = InputBox("Ingrese la Persona", "SiCoFa")
            Me.TextoBuscar = ""
            If str = "" Then
                Me.TxtNombre.Select()
                Exit Sub
            Else
                Me.TextoBuscar = str
            End If

            If Me.TextoBuscar = "" Then
                Exit Sub
            End If

            Me.BuscarCliente(Me.TextoBuscar)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub Limpiar_Click(sender As Object, e As EventArgs) Handles Limpiar.Click
        Try

            Me.LimpiarFormulario()
            Me.NuevaPersona = False
            Me.OcultarPestanaCuentaCorriente()
            Me.TxtNombre.ReadOnly = False
            Me.TxtNombre.Select()
            Me.NuevoCliente.Checked = False

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
        End Try

    End Sub
    Private Sub NuevaCuentaCorriente_Click(sender As Object, e As EventArgs) Handles NuevaCuentaCorriente.Click
        Try
            Me.MostrarPestanaCuentaCorriente()
            Me.NuevaCtaCte = True
            Dim valoresDefecto As New Dictionary(Of String, Object)

            With valoresDefecto
                .Add("TxtDescripcion", UCase(Me.TxtNombre.Text))
                .Add("TxtFechaAltaCuentaCorriente", Date.Today.ToShortDateString)
                .Add("UcEstadoCC", "H")
            End With

            Me.EstablecerValoresPorDefecto(Me.CuentaCorriente, valoresDefecto)

            Me.PanelCliente.SelectedTab = Me.CuentaCorriente

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub Nombre_Validating(sender As Object, e As CancelEventArgs) Handles TxtNombre.Validating

        Try

            If Me.TxtNombre.Text = "" Or Me.NuevaPersona = True Or Me.TxtId.Text <> "" Then
                Exit Sub
            End If

            Me.BuscarCliente(Me.TxtNombre.Text)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Private Sub FrmPanelClientes_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try

            Me.EstablecerReadOnly(Me.Cliente, Me.ControlesReadOnly)
            Me.EstablecerReadOnly(Me.CuentaCorriente, Me.ControlesReadOnly)
            Me.CargarSelectorProvincia()
            Me.CargarSelectorTipoDoc()
            Me.CargarSelectorEstado()
            Me.CargarSelectorEstadoCC()
            Me.CargarSelectorIVA()
            pestanaCuentaCorriente = Me.PanelCliente.TabPages("CuentaCorriente")
            indiceOriginalCuentaCorriente = Me.PanelCliente.TabPages.IndexOf(pestanaCuentaCorriente)
            OcultarPestanaCuentaCorriente()
            Me.TxtNombre.Select()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

End Class
