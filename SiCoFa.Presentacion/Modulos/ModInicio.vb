Imports System.Net.NetworkInformation
Imports SiCoFa.Negocio
Imports SiCoFa.Entidades
Module ModInicio
    Public g_ParametrosTerminal As ParametrosTerminal

    Sub Main()

        Dim MacAddress As String = ObtenerMacAddress()
        g_ParametrosTerminal = ObtenerParametrosTerminal(MacAddress)
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New FrmInicio())
    End Sub
    Private Function ObtenerMacAddress() As String
        Try
            Dim nics As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
            For Each adapter As NetworkInterface In nics
                If adapter.OperationalStatus = OperationalStatus.Up AndAlso
                   adapter.NetworkInterfaceType <> NetworkInterfaceType.Loopback Then

                    Dim macBytes As Byte() = adapter.GetPhysicalAddress().GetAddressBytes()
                    If macBytes.Length = 6 Then
                        Return BitConverter.ToString(macBytes) ' Devuelve con guiones
                    End If
                End If
            Next

            Return "00-00-00-00-00-00" ' Por si no encuentra ninguna
        Catch ex As Exception
            Return "Error: " & ex.Message
        End Try
    End Function
    Private Function ObtenerParametrosTerminal(ByVal macAddress As String) As ParametrosTerminal
        Dim obj_N_AdminDB As New cls_N_AdminDB
        Dim sql As String = $"SELECT * FROM TblTerminales WHERE MacAddress = '{macAddress}'"

        Dim registro As Dictionary(Of String, Object) = obj_N_AdminDB.ObtenerRegistro(sql)

        If registro Is Nothing Then
            Throw New Exception("No se encontró la terminal con MAC: " & macAddress)
        End If

        ' Mapear los campos del diccionario a las propiedades del objeto ParametrosTerminal
        Dim parametros As New ParametrosTerminal(
                                                argMacAddress:=Convert.ToString(registro("MacAddress")),
                                                argIdEmpresa:=Convert.ToInt32(registro("IdEmpresa")),
                                                argIdPC:=Convert.ToString(registro("IdPC")),
                                                argPVenta:=Convert.ToString(registro("PVenta")),
                                                argNCaja:=Convert.ToString(registro("NCaja")),
                                                argMenuCaja:=Convert.ToBoolean(registro("MenuCaja")),
                                                argImpresora:=Convert.ToString(registro("Impresora")),
                                                argPapel:=Convert.ToString(registro("Papel"))
                                                )

        Return parametros
    End Function
End Module
