Imports System.IO
Imports SiCoFa.Negocio
Imports SiCoFa.Entidades
Public Class FrmMDI
    Property Secion As Secion
    Private mobj_N_AdminContratos As New cls_N_AdminContratos

    Private Sub LimpiarCarpetaTemp()
        Try

            If System.IO.Directory.Exists(Application.StartupPath & "\Temp") Then
                System.IO.Directory.Delete(Application.StartupPath & "\Temp", True)
                System.IO.Directory.CreateDirectory(Application.StartupPath & "\Temp")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub MostrarSecion()
        Select Case Me.Secion.Estado
            Case "INIC"
                Me.EstadoSecion.Text = "Seción Iniciada por"
            Case "NO_INIC"
                Me.EstadoSecion.Text = "Seción no Iniciada"
            Case "SUS"
                Me.EstadoSecion.Text = "Seción Suspendida"
        End Select

        Me.IdUsuario.Text = "Id Usuario: " & Me.Secion.Usuario.IdUsuario
        Me.Usuario.Text = "Nombre Usuario: " & Me.Secion.Usuario.Nombre
    End Sub
    Private Sub FrmMDI_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub
    Private Sub FrmMDI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FrmInicioSecion.ShowDialog()
        Me.LimpiarCarpetaTemp()
        Me.MostrarSecion()
    End Sub
    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        End
    End Sub
    Private Sub PagoDeClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PagoDeClientesToolStripMenuItem.Click
        Dim f As New FrmIngPagoClientes
        f.IdUsuario = Me.Secion.Usuario.IdUsuario
        f.Show()

    End Sub
    Private Sub mnuAbrirContrato_Click(sender As Object, e As EventArgs) Handles mnuAbrirContrato.Click
        Dim f As New FrmPanelContratos
        f.Show()
    End Sub
    Private Sub DevengarServiciosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DevengarServiciosToolStripMenuItem.Click
        Try

            Dim obj_N_AdminContratos As New cls_N_AdminContratos
            Dim RegAfectados As Integer = obj_N_AdminContratos.DevengarServicios(Me.Secion.Usuario.IdUsuario)
            obj_N_AdminContratos.AplicarPagosAbiertos(Me.Secion.Usuario.IdUsuario)

            MsgBox("Se registraron " & RegAfectados & " operaciones", vbInformation, "SiCoFa")

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub
    Private Sub EnviarMailServiciosPrestadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnviarMailServiciosPrestadosToolStripMenuItem.Click

        With FrmEnviarMailServicios
            .Show()
            .IniciarProcesos()
        End With

    End Sub
    Private Sub FacturarServiciosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacturarServiciosToolStripMenuItem.Click
        With FrmFacturarServicios
            .Show()
            .IdUsuario = Me.Secion.Usuario.IdUsuario
            .IniciarProcesos()
        End With
    End Sub
    Private Sub EstadoDeCuentaGruposToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EstadoDeCuentaGruposToolStripMenuItem.Click

        With FrmOperaContratos
            .Nivel = 1
            .MostrarDatos()
            .Show()
        End With
    End Sub
    Private Sub RegistroCLuzToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistroCLuzToolStripMenuItem.Click

        With FrmIngConsumoLuz
            .Show()
        End With

    End Sub
    Private Sub ServiciosPrestadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ServiciosPrestadosToolStripMenuItem.Click

        With FrmEdicionTabla
            .Caption = "Servicios Prestados"
            .SQL = "SELECT * FROM TblServicios"
            .Show()
        End With

    End Sub
    Private Sub CuadroTarifarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CuadroTarifarioToolStripMenuItem.Click

        With FrmEdicionTabla
            .Caption = "Items Consumo de Luz"
            .SQL = "SELECT * FROM TblItemsConsumoLuz"
            .Show()
        End With

    End Sub
    Private Sub MedidoresDeLuzToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MedidoresDeLuzToolStripMenuItem.Click

        With FrmEdicionTabla
            .Caption = "Medidores de Luz"
            .SQL = "SELECT * FROM TblMedidoresLuz"
            .Show()
        End With

    End Sub
    Private Sub ComprobantesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComprobantesToolStripMenuItem.Click
        FrmAperComprobantes.Show()
    End Sub
    Private Sub EstadoDeCuentaClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EstadoDeCuentaClientesToolStripMenuItem.Click

        Dim str = InputBox("Ingrese el Cliente", "SiCoFa")
        Dim cte As Cliente = BuscarCliente(str)
        Dim cto As Contrato = mobj_N_AdminContratos.ObtenerContrato(0, cte.IdCliente)

        With FrmEstadCuentaClientes
            .OperaContratos(cte, cto, "DEBE")
            .Show()
        End With

    End Sub
    Private Function BuscarCliente(ByVal argTextoBuscado As String) As Cliente
        Dim lc As List(Of Cliente) = mobj_N_AdminContratos.ListarClientes(argTextoBuscado)
        Dim cte As Cliente = Nothing

        If lc Is Nothing Then
            MsgBox("Cliente no Encontrado", vbInformation, "SiCoFa")
            Return Nothing
            Exit Function
        End If

        Select Case lc.Count
            Case 0
                MsgBox("No se encontro el Cliente",, "SiCoFa")
                Return Nothing
                Exit Function
            Case 1
                cte = lc.First
            Case > 1
                FrmBuscaClientes.Clientes = lc
                FrmBuscaClientes.ShowDialog()

                If FrmBuscaClientes.ClienteSeleccionado Is Nothing Then
                    FrmBuscaClientes.Close()
                    Return Nothing
                    Exit Function
                End If

                cte = FrmBuscaClientes.ClienteSeleccionado
                FrmBuscaClientes.Close()
        End Select

        Return cte
    End Function

    Private Sub ListarArchivosFTPToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListarArchivosFTPToolStripMenuItem.Click

        Dim sql As String = "SELECT UsFTP FROM TblContratos"
        Dim obj_N_AdminDB As New cls_N_AdminDB
        Dim dt As DataTable = obj_N_AdminDB.ObtenerTabla(sql)
        Dim filePath As String = "C:\SiCoFa_Server\archivo.txt"

        Try
            Using writer As New StreamWriter(filePath)
                For Each row As DataRow In dt.Rows
                    For Each column As DataColumn In dt.Columns
                        writer.Write(row(column).ToString())
                    Next
                    writer.WriteLine()
                Next
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try
        'Dim obj_N_AdminFTP As New cls_N_AdminFTP
        'obj_N_AdminFTP.ListFiles("/Actualizaciones")

        'MsgBox(obj_N_AdminFTP.UploadFile("/Clientes/id8.txt", "C:\SiCoFa_Server\id7.txt"))


    End Sub
End Class