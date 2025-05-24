Imports System.Net.NetworkInformation
Imports SiCoFa.Negocio
Imports SiCoFa.Entidades
Module ModInicio
    Public g_ParametrosTerminal As ParametrosTerminal

    Sub Main()
        Try

            Dim MacAddress As String = ObtenerMacAddress()
            g_ParametrosTerminal = ObtenerParametrosTerminal(MacAddress)

            If g_ParametrosTerminal Is Nothing Then
                MsgBox("Terminal no habilitada", vbCritical, "SiCoFa")
                Exit Sub
            End If

            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            Application.Run(New FrmInicio())

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "SiCoFa")

        End Try

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
        Try

            Dim obj_N_AdminDB As New cls_N_AdminDB
            Dim sqlPater As String = $"SELECT * FROM TblTerminales WHERE MacAddress = '{macAddress}'"

            Dim registroPaTer As Dictionary(Of String, Object) = obj_N_AdminDB.ObtenerRegistro(sqlPater)

            If registroPaTer Is Nothing Then
                Throw New Exception("No se encontró la terminal con MAC: " & macAddress)
            End If

            Dim IdEmpresa As Int32 = Convert.ToInt32(registroPaTer("IdEmpresa"))
            Dim sqlEmpresa As String = $"SELECT IdEmpresa,Nombre,Domicilio,Localidad,Provincia,Telefono,Email,CodiTDoc,NumDoc,FechaAlta,Estado,CodIVA,IB FROM TblEmpresas WHERE IdEmpresa = '{IdEmpresa}'"

            Dim registroEmpresa As Dictionary(Of String, Object) = obj_N_AdminDB.ObtenerRegistro(sqlEmpresa)
            Dim objEmpresa As New Empresa(
                                    argIdEmpresa:=Convert.ToInt32(registroEmpresa("IdEmpresa")),
                                    argNombre:=Convert.ToString(registroEmpresa("Nombre")),
                                    argDomicilio:=Convert.ToString(registroEmpresa("Domicilio")),
                                    argLocalidad:=Convert.ToString(registroEmpresa("Localidad")),
                                    argProvincia:=Convert.ToString(registroEmpresa("Provincia")),
                                    argTelefono:=Convert.ToString(registroEmpresa("Telefono")),
                                    argEmail:=Convert.ToString(registroEmpresa("Email")),
                                    argCodiTDoc:=Convert.ToString(registroEmpresa("CodiTDoc")),
                                    argNumDoc:=Convert.ToString(registroEmpresa("NumDoc")),
                                    argFechaAlta:=Convert.ToDateTime(registroEmpresa("FechaAlta")),
                                    argEstado:=Convert.ToString(registroEmpresa("Estado")),
                                    argCodIVA:=Convert.ToString(registroEmpresa("CodIVA")),
                                    argIB:=Convert.ToString(registroEmpresa("IB"))
                                      )

            ' Mapear los campos del diccionario a las propiedades del objeto ParametrosTerminal
            Dim parametros As New ParametrosTerminal(
                                                argMacAddress:=Convert.ToString(registroPaTer("MacAddress")),
                                                argEmpresa:=objEmpresa,
                                                argIdPC:=Convert.ToString(registroPaTer("IdPC")),
                                                argPVenta:=Convert.ToString(registroPaTer("PVenta")),
                                                argNCaja:=Convert.ToString(registroPaTer("NCaja")),
                                                argMenuCaja:=Convert.ToBoolean(registroPaTer("MenuCaja")),
                                                argImpresora:=Convert.ToString(registroPaTer("Impresora")),
                                                argPapel:=Convert.ToString(registroPaTer("Papel"))
                                                )

            Return parametros

        Catch ex As Exception
            Throw New Exception(Vecho.MensajeError("ModInicio", "ObtenerParametrosTerminal", ex.Message))
            Return Nothing
        End Try

    End Function
End Module
