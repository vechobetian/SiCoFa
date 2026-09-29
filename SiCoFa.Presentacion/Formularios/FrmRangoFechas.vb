Imports System.Globalization

Public Class FrmRangoFechas

    Private m_FechaDesde As Date
    Private m_FechaHasta As Date

    Public ReadOnly Property FechaDesde As Date
        Get
            Return m_FechaDesde
        End Get
    End Property

    Public ReadOnly Property FechaHasta As Date
        Get
            Return m_FechaHasta
        End Get
    End Property

    Private Sub FrmRangoFechas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.KeyPreview = True

        txtFechaDesde.Text = Today.ToString("dd/MM/yyyy")
        txtFechaHasta.Text = Today.ToString("dd/MM/yyyy")

        txtFechaDesde.Focus()
        txtFechaDesde.SelectAll()

    End Sub

    Private Sub txtFechaHasta_Leave(sender As Object, e As EventArgs) Handles txtFechaHasta.Leave

        Dim fechaDesde As Date
        Dim fechaHasta As Date

        '----------------------------------------------------------
        ' Validar Fecha Desde
        '----------------------------------------------------------
        If Not ObtenerFecha(txtFechaDesde.Text, fechaDesde) Then

            MessageBox.Show("La fecha desde no es válida.", "Rango de fechas", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            txtFechaDesde.Focus()
            txtFechaDesde.SelectAll()

            Return

        End If

        '----------------------------------------------------------
        ' Validar Fecha Hasta
        '----------------------------------------------------------
        If Not ObtenerFecha(txtFechaHasta.Text, fechaHasta) Then

            MessageBox.Show("La fecha hasta no es válida.", "Rango de fechas", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            txtFechaHasta.Focus()
            txtFechaHasta.SelectAll()

            Return

        End If

        '----------------------------------------------------------
        ' Validar que Hasta no sea anterior a Desde
        '----------------------------------------------------------
        If fechaHasta < fechaDesde Then

            MessageBox.Show("La fecha hasta no puede ser anterior a la fecha desde.", "Rango de fechas", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            txtFechaHasta.Focus()
            txtFechaHasta.SelectAll()

            Return

        End If

        '----------------------------------------------------------
        ' Guardar las fechas
        '----------------------------------------------------------
        m_FechaDesde = fechaDesde
        m_FechaHasta = fechaHasta

        '----------------------------------------------------------
        ' Indicar al formulario que llamó que el rango es válido
        '----------------------------------------------------------
        Me.DialogResult = DialogResult.OK

    End Sub

    Private Function ObtenerFecha(texto As String, ByRef fecha As Date) As Boolean

        Return Date.TryParseExact(texto.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, fecha)

    End Function

    Private Sub FrmRangoFechas_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Escape Then

            Me.DialogResult = DialogResult.Cancel

            e.Handled = True
            e.SuppressKeyPress = True

        End If

    End Sub

End Class
