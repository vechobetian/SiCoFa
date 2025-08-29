Imports SiCoFa.Negocio
Imports SiCoFa.Entidades

Public Class FrmAnalisisVentas
    Property SQL As String = "SELECT Fecha,NOperac,ImpMedioTiket,ImpBto,ImpDes,ImpNeto,ImpEf,ImpCC,ImpPE FROM ConAnaVentas"

    Private mAdminDB As New N_AdminDB

    Private Sub AjustarAnchoColumnasComprobantes()
        Try

            If DataGridView1.ColumnCount = 9 Then
                Dim totalAncho As Integer = DataGridView1.Width - 42
                Dim proporciones As Double() = {0.1R, 0.1R, 0.1R, 0.2R, 0.1R, 0.1R, 0.1R, 0.1R, 0.1R}

                For i As Integer = 0 To 8
                    DataGridView1.Columns(i).Width = CInt(totalAncho * proporciones(i))
                Next

            Else
                MessageBox.Show("El DataGridView1 no tiene 9 columnas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub
    Private Sub FrmComprobantesEmitidos_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try

            Dim TblComprobantes As DataTable = mAdminDB.ObtenerTabla(Me.SQL)
            Me.DataGridView1.DataSource = TblComprobantes
            Me.AjustarAnchoColumnasComprobantes()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

    End Sub







End Class