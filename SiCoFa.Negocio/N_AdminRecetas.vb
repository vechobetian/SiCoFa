Imports SiCoFa.ServiciosExternos
Imports SiCoFa.Datos
Imports SiCoFa.Entidades

Public Class N_AdminRecetas

    Public Function ObtenerIdMensajeValidador(ByVal argValidador As String) As Long

        Dim AdminRecetas As New D_AdminRecetas
        Dim IdMensaje As Long = AdminRecetas.ObtenerIdMensajeValidador(argValidador)
        Return IdMensaje

    End Function

    Public Function ConsultaRecetasBeneficiario(argIdPC As String, argCredencial As CredencialOS, argPValidacion As ParametrosValidacion) As List(Of Receta)

        Dim iVal As IValidador = S_AdminValidadores.ObtenerValidador(argPValidacion.Validador)
        Dim idMsje As Long = Me.ObtenerIdMensajeValidador(argPValidacion.Validador)
        Dim consultaResponse As List(Of Receta) = iVal.ConsultaRecetasBeneficiario(argIdPC, argCredencial, argPValidacion, idMsje)
        Return consultaResponse

    End Function

    Public Function ConsultaRecetaElectronica(argIdPC As String, argReceta As Receta) As Receta

        Dim iVal As IValidador = S_AdminValidadores.ObtenerValidador(argReceta.Plan.OS.PValidacion.Validador)
        Dim idMsje As Long = Me.ObtenerIdMensajeValidador(argReceta.Plan.OS.PValidacion.Validador)
        Dim consultaResponse As Receta = iVal.ConsultaRecetaElectronica(argIdPC, argReceta, idMsje)
        Return consultaResponse

    End Function

    Public Sub SolicitarAutorizacion(argIdPC As String, argReceta As Receta)

        Dim iVal As IValidador = S_AdminValidadores.ObtenerValidador(argReceta.Plan.OS.PValidacion.Validador)
        Dim idMsje As Long = Me.ObtenerIdMensajeValidador(argReceta.Plan.OS.PValidacion.Validador)
        iVal.SolicitarAutorizacion(argIdPC, argReceta, idMsje)

    End Sub

    Public Sub SolicitarCancelacion(argIdPC As String, argReceta As Receta)

        Dim iVal As IValidador = S_AdminValidadores.ObtenerValidador(argReceta.Plan.OS.PValidacion.Validador)
        Dim idMsje As Long = Me.ObtenerIdMensajeValidador(argReceta.Plan.OS.PValidacion.Validador)
        iVal.SolicitarAutorizacion(argIdPC, argReceta, idMsje)

    End Sub

    Public Sub ObtenerCobertura(ByVal argArticulo As Articulo, ByRef argItemComprobante As ItemComprobante)

        If argItemComprobante.Receta Is Nothing OrElse argItemComprobante.Receta.Plan Is Nothing Then
            Exit Sub
        End If

        Select Case argItemComprobante.Receta.Plan.Proceso

            Case 1
                Me.Proceso1(argArticulo, argItemComprobante)

            Case 2
                Me.Proceso2(argArticulo, argItemComprobante)

            Case 3
                Me.Proceso3(argArticulo, argItemComprobante)

            Case 12
                Me.Proceso12(argArticulo, argItemComprobante)

            Case 13
                Me.Proceso13(argArticulo, argItemComprobante)


        End Select

    End Sub

    Private Sub Proceso1(ByVal argArticulo As Articulo, ByRef argItemComprobante As ItemComprobante)

        Dim codigo As Integer = argArticulo.Codigo
        Dim POS As Decimal = 0
        Dim DOS As Decimal = 0
        Dim PCS As Decimal = 0
        Dim DCS As Decimal = 0

        If argItemComprobante.Receta.Plan.Vademecum1 IsNot Nothing Then
            Dim itemVdm = argItemComprobante.Receta.Plan.Vademecum1.FirstOrDefault(Function(x) x.Codigo = codigo)

            If itemVdm IsNot Nothing Then
                POS = argItemComprobante.Receta.Plan.DesGeneral1
                DOS = Math.Round(argArticulo.PrecioVenta * POS / 100, 2, MidpointRounding.ToEven)
                PCS = 0
                DCS = 0
            End If

        End If

        If DOS > 0 Then

            With argItemComprobante
                .PorcentajeOS = POS
                .DescuentoOS = DOS
                .PorcentajeCS = PCS
                .DescuentoCS = DCS
            End With

        End If

    End Sub

    Private Sub Proceso2(ByVal argArticulo As Articulo, ByRef argItemComprobante As ItemComprobante)

        Dim codigo As Integer = argArticulo.Codigo
        Dim POS As Decimal = 0
        Dim DOS As Decimal = 0
        Dim PCS As Decimal = 0
        Dim DCS As Decimal = 0

        If argItemComprobante.Receta.Plan.Vademecum1 IsNot Nothing Then
            Dim itemVdm = argItemComprobante.Receta.Plan.Vademecum1.FirstOrDefault(Function(x) x.Codigo = codigo)

            If itemVdm IsNot Nothing Then
                POS = itemVdm.Descuento
                DOS = Math.Round(argArticulo.PrecioVenta * POS / 100, 2, MidpointRounding.ToEven)
                PCS = 0
                DCS = 0
            End If

        End If

        If DOS > 0 Then

            With argItemComprobante
                .PorcentajeOS = POS
                .DescuentoOS = DOS
                .PorcentajeCS = PCS
                .DescuentoCS = DCS
            End With

        End If

    End Sub

    Private Sub Proceso3(ByVal argArticulo As Articulo, ByRef argItemComprobante As ItemComprobante)

        Dim codigo As Integer = argArticulo.Codigo
        Dim POS As Decimal = 0
        Dim DOS As Decimal = 0
        Dim PCS As Decimal = 0
        Dim DCS As Decimal = 0

        If argItemComprobante.Receta.Plan.Vademecum1 IsNot Nothing Then
            Dim itemVdm = argItemComprobante.Receta.Plan.Vademecum1.FirstOrDefault(Function(x) x.Codigo = codigo)

            If itemVdm IsNot Nothing Then
                POS = argItemComprobante.Receta.Plan.DesGeneral1
                DOS = Math.Round(argArticulo.PrecioVenta * POS / 100, 2, MidpointRounding.ToEven)
                PCS = 0
                DCS = 0

            Else
                POS = argItemComprobante.Receta.Plan.DesGeneral2
                DOS = Math.Round(argArticulo.PrecioVenta * POS / 100, 2, MidpointRounding.ToEven)
                PCS = 0
                DCS = 0

            End If

        End If

        If DOS > 0 Then

            With argItemComprobante
                .PorcentajeOS = POS
                .DescuentoOS = DOS
                .PorcentajeCS = PCS
                .DescuentoCS = DCS
            End With

        End If

    End Sub

    Private Sub Proceso4(ByVal argArticulo As Articulo, ByRef argItemComprobante As ItemComprobante)

        Dim POS As Decimal = 0
        Dim DOS As Decimal = 0
        Dim PCS As Decimal = 0
        Dim DCS As Decimal = 0

        POS = argItemComprobante.Receta.Plan.DesGeneral1
        DOS = Math.Round(argArticulo.PrecioVenta * POS / 100, 2, MidpointRounding.ToEven)
        PCS = 0
        DCS = 0

        With argItemComprobante
            .PorcentajeOS = POS
            .DescuentoOS = DOS
            .PorcentajeCS = PCS
            .DescuentoCS = DCS
        End With

    End Sub

    Private Sub Proceso12(ByVal argArticulo As Articulo, ByRef argItemComprobante As ItemComprobante)

        Dim POS As Decimal = 0
        Dim DOS As Decimal = 0
        Dim PCS As Decimal = 0
        Dim DCS As Decimal = 0
        Dim strPOS As String = ""

        Do
            strPOS = InputBox("Ingrese el porcentaje de Descuento:", "Cobertura Obra Social")

            ' Si presiona Cancelar
            If strPOS = "" Then Exit Sub

            If Decimal.TryParse(strPOS, POS) AndAlso POS > 0 AndAlso POS < 101 Then
                Exit Do
            End If

            MsgBox("Debe ingresar un porcentaje válido (mayor que 0 y menor o igual a 100)", vbOK, "SiCoFa")

        Loop

        DOS = Math.Round(argArticulo.PrecioVenta * POS / 100, 2, MidpointRounding.ToEven)
        PCS = 0
        DCS = 0

        With argItemComprobante
            .PorcentajeOS = POS
            .DescuentoOS = DOS
            .PorcentajeCS = PCS
            .DescuentoCS = DCS
        End With

    End Sub

    Private Sub Proceso13(ByVal argArticulo As Articulo, ByRef argItemComprobante As ItemComprobante)

        Dim POS As Decimal = 0
        Dim DOS As Decimal = 0
        Dim PCS As Decimal = 0
        Dim DCS As Decimal = 0

        POS = argItemComprobante.Receta.Plan.DesGeneral1
        DOS = Math.Round(argArticulo.PrecioVenta * POS / 100, 2, MidpointRounding.ToEven)
        PCS = argItemComprobante.Receta.Plan.DesGeneral2
        DCS = Math.Round(argArticulo.PrecioVenta * PCS / 100, 2, MidpointRounding.ToEven)


        With argItemComprobante
            .PorcentajeOS = POS
            .DescuentoOS = DOS
            .PorcentajeCS = PCS
            .DescuentoCS = DCS
        End With

    End Sub

    Private Sub Proceso(ByVal argArticulo As Articulo, ByRef argItemComprobante As ItemComprobante)

        Dim codigo As Integer = argArticulo.Codigo
        Dim POS As Decimal = 0
        Dim DOS As Decimal = 0
        Dim PCS As Decimal = 0
        Dim DCS As Decimal = 0

        If argItemComprobante.Receta.Plan.Vademecum1 IsNot Nothing Then
            Dim itemVdm = argItemComprobante.Receta.Plan.Vademecum1.FirstOrDefault(Function(x) x.Codigo = codigo)

            If itemVdm IsNot Nothing Then
                POS = argItemComprobante.Receta.Plan.DesGeneral1
                DOS = Math.Round(argArticulo.PrecioVenta * POS / 100, 2, MidpointRounding.ToEven)
            End If

        End If

        If argItemComprobante.Receta.Plan.Vademecum2 IsNot Nothing Then
            Dim itemVdm = argItemComprobante.Receta.Plan.Vademecum2.FirstOrDefault(Function(x) x.Codigo = codigo)

            If itemVdm IsNot Nothing Then
                PCS = argItemComprobante.Receta.Plan.DesGeneral2
                DCS = Math.Round(argArticulo.PrecioVenta * PCS / 100, 2, MidpointRounding.ToEven)
            End If

        End If

        If DOS > 0 OrElse DCS > 0 Then

            With argItemComprobante
                .PorcentajeOS = POS
                .DescuentoOS = DOS
                .PorcentajeCS = PCS
                .DescuentoCS = DCS
            End With

        End If

    End Sub

End Class