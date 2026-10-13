Imports System.Collections.Generic
Imports System.Security.Cryptography
Imports System.Security.Policy
Imports System.Threading.Tasks
Imports SiCoFa.Entidades
Imports SiCoFa.Datos
Imports SiCoFa.ServiciosExternos

Public Class N_AdminTrazabilidad

    ''' <summary>
    ''' Obtiene las transacciones no confirmadas invocando al servicio externo
    ''' </summary>
    Public Async Function ObtenerTransaccionesNoConfirmadasAsync(argDesde As String, argHasta As String) As Task(Of List(Of TransaccionTrazabilidad))

        ' 1. Consultamos los parámetros de PAMI usando tu función existente
        Dim adminDB As New D_AdminDB()
        Dim regParam = adminDB.ObtenerRegistro("SELECT Gln, Usuario, Password FROM parametros_trazabilidad LIMIT 1")

        If regParam Is Nothing Then
            Throw New Exception("No se encontraron los parámetros de trazabilidad configurados en la base de datos.")
        End If

        Dim gln As String = regParam("Gln").ToString()
        Dim usuario As String = regParam("Usuario").ToString()
        Dim password As String = regParam("Password").ToString()

        ' 2. Instanciamos el servicio externo y ejecutamos la llamada asíncrona a PAMI
        Dim servicio As New TrazabilidadServices()
        Dim lista = Await servicio.TransaccionesNoConfirmadasAsync(usuario, password, gln, argDesde, argHasta)

        If servicio.EsError Then
            Throw New Exception(servicio.DescripcionError)
        End If

        Return lista
    End Function

    Public Async Function VerTransacciones(argDesde As String, argHasta As String, argIdEstado As Integer) As Task(Of List(Of TransaccionTrazabilidad))

        ' 1. Consultamos los parámetros de PAMI usando tu función existente
        Dim adminDB As New D_AdminDB()
        Dim regParam = adminDB.ObtenerRegistro("SELECT GLN, Usuario, Password FROM parametros_trazabilidad LIMIT 1")

        If regParam Is Nothing Then
            Throw New Exception("No se encontraron los parámetros de trazabilidad configurados en la base de datos.")
        End If

        Dim gln As String = regParam("GLN").ToString()
        Dim usuario As String = regParam("Usuario").ToString()
        Dim password As String = regParam("Password").ToString()

        ' 2. Instanciamos el servicio externo y ejecutamos la llamada asíncrona a PAMI
        Dim servicio As New TrazabilidadServices()
        Dim lista = Await servicio.VerTransaccionesAsync(usuario, password, gln, argDesde, argHasta, argIdEstado)

        If servicio.EsError Then
            Throw New Exception(servicio.DescripcionError)
        End If

        Return lista
    End Function



End Class