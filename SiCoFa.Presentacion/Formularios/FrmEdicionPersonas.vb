Imports System.ComponentModel
Imports SiCoFa.Entidades

Public Class FrmEdicionPersonas
    Property TextoBuscar As String
    Property NuevaPersona As Boolean

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
                .NombrePropiedadId = "CodiTD"
                .NombrePropiedadDescripcion = "Descripcion"
                .TituloSelector = "Tipos Documento"
                .HeaderDescripcion = "Tipo Documento"
                .ValorPredeterminado = TipoDocumento.Predeterminado.CodiTD
                .TextoPredeterminado = TipoDocumento.Predeterminado.Descripcion
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

    Private Sub FrmEdicionPersonas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CargarSelectorProvincia()
        Me.CargarSelectorTipoDoc()
        Me.CargarSelectorEstado()
    End Sub

    Public Overridable Sub Guardar_Click(sender As Object, e As EventArgs) Handles Guardar.Click

    End Sub

    Public Overridable Sub Nuevo_Click(sender As Object, e As EventArgs) Handles Nuevo.Click
        Me.LimpiarFormulario()
        Me.NuevaPersona = True
        Me.TxtNombre.Select()
        Me.Nuevo.Checked = True
    End Sub

    Public Overridable Sub Buscar_Click(sender As Object, e As EventArgs) Handles Buscar.Click
        If NuevaPersona = True Then
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

    End Sub

    Private Sub Limpiar_Click(sender As Object, e As EventArgs) Handles Limpiar.Click
        Me.LimpiarFormulario()
        Me.NuevaPersona = False
        Me.TxtNombre.Select()
        Me.Nuevo.Checked = False
    End Sub

    Public Overridable Sub Nombre_Validating(sender As Object, e As CancelEventArgs) Handles TxtNombre.Validating

    End Sub

End Class