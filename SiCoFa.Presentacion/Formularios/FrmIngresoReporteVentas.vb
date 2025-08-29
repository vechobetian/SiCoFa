Public Class FrmIngresoReporteVentas

    Private DatosOpcionales As New List(Of String)
    Private Const WM_SYSCOMMAND As Integer = &H112
    Private Const SC_CLOSE As Integer = &HF060

    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.Msg = WM_SYSCOMMAND AndAlso (m.WParam.ToInt32() And &HFFF0) = SC_CLOSE Then
            ' El usuario hizo clic en la X → desactivamos validación
            Me.AutoValidate = AutoValidate.Disable
        End If
        MyBase.WndProc(m)
    End Sub

    Private Sub mtxtFechaDesde_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles mtxtFechaDesde.MaskInputRejected
        Try
            Dim fecha As Date

            ' Si está vacío o incompleto
            If Not mtxtFechaDesde.MaskCompleted Then
                MsgBox("Debe ingresar una fecha completa.", vbExclamation, "Validación")
                mtxtFechaDesde.SelectAll()
                mtxtFechaDesde.Focus()
                Exit Sub
            End If

            ' Validación de fecha válida
            If Date.TryParseExact(mtxtFechaDesde.Text, "dd/MM/yyyy", Nothing, Globalization.DateTimeStyles.None, fecha) Then
                mtxtFechaDesde.Text = fecha.ToString("dd/MM/yyyy") ' Normaliza la fecha
            Else
                MsgBox("La fecha ingresada no es válida.", vbExclamation, "Validación")
                mtxtFechaDesde.SelectAll()
                mtxtFechaDesde.Focus()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
        End Try
    End Sub

    Private Sub mtxtFechaHasta_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles mtxtFechaHasta.MaskInputRejected
        Try
            Dim fecha As Date

            ' Si está vacío o incompleto
            If Not mtxtFechaDesde.MaskCompleted Then
                MsgBox("Debe ingresar una fecha completa.", vbExclamation, "Validación")
                mtxtFechaHasta.SelectAll()
                mtxtFechaHasta.Focus()
                Exit Sub
            End If

            ' Validación de fecha válida
            If Date.TryParseExact(mtxtFechaHasta.Text, "dd/MM/yyyy", Nothing, Globalization.DateTimeStyles.None, fecha) Then
                mtxtFechaHasta.Text = fecha.ToString("dd/MM/yyyy") ' Normaliza la fecha
            Else
                MsgBox("La fecha ingresada no es válida.", vbExclamation, "Validación")
                mtxtFechaHasta.SelectAll()
                mtxtFechaHasta.Focus()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")
        End Try
    End Sub

    Private Sub btnMostrarVentas_Click(sender As Object, e As EventArgs) Handles btnMostrarVentas.Click
        Dim str As String

        str = Strings.Replace(Me.mtxtFechaDesde.Text, "/", "").Trim

        If str = "" Then
            MsgBox("Fecha Desde es un dato requerido", vbCritical, "SiCoFa")
            Me.mtxtFechaDesde.Focus()
            Exit Sub
        End If

        str = Strings.Replace(Me.mtxtFechaHasta.Text, "/", "").Trim

        If str = "" Then
            MsgBox("Fecha Hasta es un dato requerido", vbCritical, "SiCoFa")
            Me.mtxtFechaHasta.Focus()
            Exit Sub
        End If

        Me.ValidarCampos(Me, Me.DatosOpcionales)

        If Me.ValidacionOK = False Then
            Exit Sub
        End If

        Dim sql As String = ""

        Dim desdeTexto As String = Me.mtxtFechaDesde.Text.Trim()
        Dim hastaTexto As String = Me.mtxtFechaHasta.Text.Trim()

        ' Convertir texto a Date
        Dim desdeFecha As Date = Date.ParseExact(desdeTexto, "dd/MM/yyyy", Globalization.CultureInfo.InvariantCulture)
        Dim hastaFecha As Date = Date.ParseExact(hastaTexto, "dd/MM/yyyy", Globalization.CultureInfo.InvariantCulture)

        ' Formatear fechas para SQL
        Dim desdeSql As String = desdeFecha.ToString("yyyy-MM-dd")
        Dim hastaSql As String = hastaFecha.ToString("yyyy-MM-dd")

        sql = $"SELECT Fecha,NOperac,ImpMedioTiket,ImpBto,ImpDes,ImpNeto,ImpEf,ImpCC,ImpPE FROM ConReporteVentas WHERE Fecha BETWEEN '{desdeSql}' AND '{hastaSql}'"

        FrmReporteVentas.SQL = sql
        Me.Close()
        FrmReporteVentas.Show()
        FrmReporteVentas.BringToFront()

    End Sub

End Class