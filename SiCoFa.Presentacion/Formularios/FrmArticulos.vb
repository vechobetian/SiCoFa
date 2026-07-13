Imports System.ComponentModel
Imports SiCoFa.Entidades
Imports SiCoFa.Entidades.Enums
Imports SiCoFa.Negocio

Public Class FrmArticulos
    Private TextoBuscar As String
    Private NuevoArticulo As Boolean
    Private mobj_AdminArticulos As New N_AdminArticulos
    Private ControlesReadOnly As New List(Of String)
    Private DatosOpcionales As New List(Of String) From {"TxtIdArticulo", "TxtNTroquel", "TxtCodBarras"}

    Private Sub CargarSelectorTipoVenta()

        With UcTipoVenta
            .Objetos = TipoVenta.Lista
            .NombrePropiedadId = "CodiTV"
            .NombrePropiedadDescripcion = "Descripcion"
            .TituloSelector = "Tipos de Venta"
            .HeaderDescripcion = "Tipo de Venta"
            .ValorPredeterminado = "7"
            .TextoPredeterminado = "NO CLASIFICADO"
            .PermitirVacio = False
        End With

    End Sub

    Private Sub CargarSelectorAlicuotaIVA()

        With UcAlicuotaIVA
            .Objetos = AlicuotaIVA.Lista
            .NombrePropiedadId = "AlicIVA"
            .NombrePropiedadDescripcion = "Descripcion"
            .TituloSelector = "Alicuotas IVA"
            .HeaderDescripcion = "Alicuota IVA"
            .PermitirVacio = True

        End With

    End Sub

    Private Sub CargarSelectorTamanioEnvase()

        With UcTamanioEnvase
            .Objetos = TamanioEnvase.Lista
            .NombrePropiedadId = "CodiTE"
            .NombrePropiedadDescripcion = "Descripcion"
            .TituloSelector = "Tamaños Envase"
            .HeaderDescripcion = "Tamaño Envase"
            .ValorPredeterminado = 0
            .TextoPredeterminado = "NO CLASIFICADO"
            .PermitirVacio = False
        End With

    End Sub

    Private Sub CargarSelectorLaboratorio()
        Dim Admin As New N_AdminLaboratorios

        With UcLaboratorio
            .Objetos = Admin.ListarLaboratorios("*")
            .NombrePropiedadId = "CodiLabora"
            .NombrePropiedadDescripcion = "Laboratorio"
            .TituloSelector = "Laboratorios"
            .HeaderDescripcion = "Laboratorio"
            .ValorPredeterminado = 0
            .TextoPredeterminado = "NO ESTABLECIDO"
            .PermitirVacio = False
        End With
    End Sub

    Private Sub CargarSelectorMonodroga()
        Dim Admin As New N_AdminMonodrogas

        With UcMonodroga
            .Objetos = Admin.ListarMonodrogas("*")
            .NombrePropiedadId = "CodiMon"
            .NombrePropiedadDescripcion = "Monodroga"
            .TituloSelector = "Monodrogas"
            .HeaderDescripcion = "Monodroga"
            .ValorPredeterminado = 0
            .TextoPredeterminado = "NO ESTABLECIDA"
            .PermitirVacio = False
        End With
    End Sub

    Private Sub CargarSelectorAccionFarmacologica()
        Dim Admin As New N_AdminAccionesFarmacologicas

        With UcAccionFarmacologica
            .Objetos = Admin.ListarAccionesFarmacologicas("*")
            .NombrePropiedadId = "CodiAcFa"
            .NombrePropiedadDescripcion = "AccionFarmacologica"
            .TituloSelector = "Acciones Farmacologicas"
            .HeaderDescripcion = "Accion Farmacologica"
            .ValorPredeterminado = 0
            .TextoPredeterminado = "NO ESTABLECIDA"
            .PermitirVacio = False
        End With
    End Sub

    Private Sub CargarSelectorTipoControl()

        With UcTipoControl
            .Objetos = TipoControl.Lista
            .NombrePropiedadId = "CodiTiCo"
            .NombrePropiedadDescripcion = "Descripcion"
            .TituloSelector = "Tipos de control"
            .HeaderDescripcion = "Tipo de control"
            .ValorPredeterminado = 0
            .TextoPredeterminado = "NO CONTROLADO"
            .PermitirVacio = False
        End With

    End Sub

    Private Sub CargarSelectorHeladera()

        With UcHeladera
            .Objetos = Buleano.Lista
            .NombrePropiedadId = "Valor"
            .NombrePropiedadDescripcion = "Descripcion"
            .TituloSelector = "Cadena de Frío"
            .HeaderDescripcion = "Heladera"
            .ValorPredeterminado = 0
            .TextoPredeterminado = "NO"
            .PermitirVacio = False
        End With

    End Sub

    Private Sub CargarSelectorBaja()

        With UcBaja
            .Objetos = Buleano.Lista
            .NombrePropiedadId = "Valor"
            .NombrePropiedadDescripcion = "Descripcion"
            .TituloSelector = "Baja de Producto"
            .HeaderDescripcion = "Baja"
            .ValorPredeterminado = 0
            .TextoPredeterminado = "NO"
            .PermitirVacio = False
        End With

    End Sub

    Private Sub CargarSelectorSeccion()

        Try
            Dim AdminSecciones As New N_AdminSecciones

            With UcSeccion
                .Objetos = AdminSecciones.ListarSecciones("*")
                .NombrePropiedadId = "IdSeccion"
                .NombrePropiedadDescripcion = "Seccion"
                .TituloSelector = "Secciones"
                .HeaderDescripcion = "Sección"
                .PermitirVacio = True
            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub BuscarArticulo(ByVal argTextoBuscado As String)

        Try

            Dim la As List(Of Articulo) = mobj_AdminArticulos.ListarArticulos(argTextoBuscado)
            Dim a As Articulo = Nothing

            If la Is Nothing Then
                MsgBox("Articulo no Encontrado", vbInformation, "SiCoFa")
                Exit Sub
            End If

            Select Case la.Count
                Case 0
                    MsgBox("Articulo no Encontrado", vbInformation, "SiCoFa")
                    Me.TxtNombre.Text = ""
                    Me.TxtNombre.Select()
                    Exit Sub

                Case 1
                    a = la.First

                Case > 1

                    Using f As New FrmBuscaArticulos
                        f.Articulos = la
                        f.ShowDialog()
                        If f.DialogResult = DialogResult.OK Then
                            a = f.ArticuloSeleccionado
                        End If
                        f.Close()
                    End Using

            End Select

            With Me
                .LimpiarFormulario()
                .MostrarArticulo(a)
                .TxtNombre.Select()
                .TxtNombre.SelectAll()
            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub MostrarArticulo(ByVal argArticulo As Articulo)

        Try
            If argArticulo Is Nothing Then
                Exit Sub
            End If

            With Me
                .TxtIdArticulo.Text = argArticulo.IdArticulo
                .TxtNombre.Text = argArticulo.Nombre
                .TxtNTroquel.Text = argArticulo.NTroquel
                .TxtCodBarras.Text = argArticulo.CodBarras
                .UcTipoVenta.Asignar(argArticulo.TipoVenta.CodiTV, argArticulo.TipoVenta.Descripcion)
                Dim alicIVA As New AlicuotaIVA(argArticulo.AlicIVA)
                .UcAlicuotaIVA.Asignar(alicIVA.AlicIVA, alicIVA.Descripcion)
                .UcTamanioEnvase.Asignar(argArticulo.TamanioEnvase.CodiTE, argArticulo.TamanioEnvase.Descripcion)
                .UcLaboratorio.Asignar(argArticulo.Laboratorio.CodiLabora, argArticulo.Laboratorio.Laboratorio)
                .UcMonodroga.Asignar(argArticulo.Monodroga.CodiMon, argArticulo.Monodroga.Monodroga)
                .UcAccionFarmacologica.Asignar(argArticulo.AccionFarmacologica.CodiAcFa, argArticulo.AccionFarmacologica.AccionFarmacologica)
                UcTipoControl.Asignar(argArticulo.TipoControl.CodiTiCo, argArticulo.TipoControl.Descripcion)
                Dim blnHeladera As Buleano = New Buleano(argArticulo.Heladera)
                .UcHeladera.Asignar(blnHeladera.Valor, blnHeladera.Descripcion)
                Dim blnBaja As Buleano = New Buleano(argArticulo.Baja)
                .UcBaja.Asignar(blnBaja.Valor, blnBaja.Descripcion)
                .UcSeccion.Asignar(argArticulo.Seccion.IdSeccion, argArticulo.Seccion.Seccion)
            End With

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub FrmArticulos_Load(sender As Object, e As EventArgs) Handles Me.Load

        With Me.ControlesReadOnly
            .Clear()
            .Add("IdArticulo")
        End With

        Me.EstablecerReadOnly(Me, ControlesReadOnly)

        Me.CargarSelectorTipoVenta()
        Me.CargarSelectorAlicuotaIVA()
        Me.CargarSelectorTamanioEnvase()
        Me.CargarSelectorLaboratorio()
        Me.CargarSelectorMonodroga()
        Me.CargarSelectorAccionFarmacologica()
        Me.CargarSelectorTipoControl()
        Me.CargarSelectorHeladera()
        Me.CargarSelectorBaja()
        Me.CargarSelectorSeccion()
    End Sub

    Private Sub Guardar_Click(sender As Object, e As EventArgs) Handles Guardar.Click
        Try

            Me.ValidarCampos(Me, DatosOpcionales)

            If Me.ValidacionOK = False Then
                Exit Sub
            End If

            If Me.NuevoArticulo = True Then
                Dim IdArticulo As String = mobj_AdminArticulos.InsertarArticulo(
                                                                                Me.TxtCodBarras.Text,
                                                                                Me.TxtNTroquel.Text,
                                                                                Me.TxtNombre.Text,
                                                                                Me.UcTipoVenta.Id,
                                                                                Me.UcAlicuotaIVA.Id,
                                                                                Me.UcTamanioEnvase.Id,
                                                                                Me.UcLaboratorio.Id,
                                                                                Me.UcMonodroga.Id,
                                                                                Me.UcAccionFarmacologica.Id,
                                                                                Me.UcTipoControl.Id,
                                                                                Me.UcHeladera.Id,
                                                                                Me.UcSeccion.Id
                                                                                )

                If IdArticulo <> "" Then
                    Me.TxtIdArticulo.Text = IdArticulo
                    Me.TxtNombre.Text = UCase(Me.TxtNombre.Text)
                    MsgBox("Se dio de alta el Articulo " & TxtNombre.Text, vbInformation, "SiCoFa")
                Else
                    MsgBox("Ocurrio un error, intente nuevamente", vbCritical, "SiCoFa")
                    Exit Sub
                End If
                Me.NuevoArticulo = False
                Me.Nuevo.Checked = False

            Else
                If Me.TxtIdArticulo.Text = "" Then
                    MsgBox("El Articulo " & Me.TxtNombre.Text & " no fue dado de Alta", vbInformation, "SiCoFa")
                    Exit Sub
                End If

                Dim Actualizado As Boolean = mobj_AdminArticulos.ActualizarArticulo(
                                                                                    Me.TxtIdArticulo.Text,
                                                                                    Me.TxtCodBarras.Text,
                                                                                    Me.TxtNTroquel.Text,
                                                                                    Me.TxtNombre.Text,
                                                                                    Me.UcTipoVenta.Id,
                                                                                    Me.UcAlicuotaIVA.Id,
                                                                                    Me.UcTamanioEnvase.Id,
                                                                                    Me.UcLaboratorio.Id,
                                                                                    Me.UcMonodroga.Id,
                                                                                    Me.UcAccionFarmacologica.Id,
                                                                                    Me.UcTipoControl.Id,
                                                                                    Me.UcHeladera.Id,
                                                                                    Me.UcBaja.Id,
                                                                                    Me.UcSeccion.Id
                                                                                    )

                If Actualizado = True Then
                    MsgBox("El Articulo " & TxtNombre.Text & " se acutalizo correctamente", vbInformation, "SiCoFa")
                Else
                    MsgBox("Ocurrio un error, intente nuevamente", vbCritical, "SiCoFa")
                    Exit Sub
                End If
            End If


                With Me.ControlesReadOnly
                .Clear()
                .Add("IdArticulo")
            End With

            Me.EstablecerReadOnly(Me, ControlesReadOnly)
            Me.LimpiarFormulario()
            Me.TxtNombre.Select()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub Nuevo_Click(sender As Object, e As EventArgs) Handles Nuevo.Click
        Try

            Me.LimpiarFormulario()

            Me.NuevoArticulo = True
            Me.Nuevo.Checked = True

            Dim valoresDefecto As New Dictionary(Of String, Object)
            With valoresDefecto
                .Add("Baja", "NO")
            End With

            EstablecerValoresPorDefecto(Me, valoresDefecto)

            With Me.ControlesReadOnly
                .Add("IdArticulo")
                .Add("Baja")
            End With

            Me.EstablecerReadOnly(Me, ControlesReadOnly)

            Me.TxtNombre.Select()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub Buscar_Click_1(sender As Object, e As EventArgs) Handles Buscar.Click

        Try
            If NuevoArticulo = True Then
                Exit Sub
            End If

            Dim str = InputBox("Ingrese el articulo buscado", "SiCoFa")
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

            Me.BuscarArticulo(Me.TextoBuscar)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub Limpiar_Click(sender As Object, e As EventArgs) Handles Limpiar.Click
        Try

            Me.LimpiarFormulario()
            Me.NuevoArticulo = False
            Me.Nuevo.Checked = False
            Me.ControlesReadOnly.Clear()

            With Me.ControlesReadOnly
                .Add("IdArticulo")
            End With

            Me.EstablecerReadOnly(Me, ControlesReadOnly)
            Me.TxtNombre.Select()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

    Private Sub Nombre_Validating(sender As Object, e As CancelEventArgs) Handles TxtNombre.Validating
        Try
            If Me.TxtNombre.Text = "" Or Me.NuevoArticulo = True Or Me.TxtIdArticulo.Text <> "" Then
                Exit Sub
            End If

            Me.BuscarArticulo(Me.TxtNombre.Text)

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub

End Class