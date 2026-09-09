Imports MySql.Data.MySqlClient
Imports SiCoFa.Entidades

Module RecetaMapper
    Public Function Map(dr As MySqlDataReader) As Receta
        Dim adminOS As New D_AdminObraSociales
        Dim planOS As PlanOS = adminOS.ObtenerPlanOSPorId(CInt(dr("IdPlan")))
        Dim documento As Documento = Nothing
        Dim credencial As CredencialOS = Nothing

        If Not String.IsNullOrEmpty(dr("CodiTD")) AndAlso Not String.IsNullOrEmpty(dr("NumDoc")) Then
            documento = New Documento(dr("CodiTD"), dr("NumDoc"))
        End If

        If Not String.IsNullOrEmpty(dr("Credencial")) Then
            credencial = New CredencialOS()
            credencial.Numero = dr("Credencial").ToString
        End If

        Return New Receta(
                            CLng(dr("IdReceta")),
                            CLng(dr("IdOperacion")),
                            planOS,
                            If(IsDBNull(dr("FechaPrescripcion")), Nothing, CDate(dr("FechaPrescripcion"))),
                            If(IsDBNull(dr("FechaDispensacion")), Nothing, CDate(dr("FechaDispensacion"))),
                            If(IsDBNull(dr("NumReceta")), "", dr("NumReceta").ToString),
                            documento,
                            credencial,
                            CDec(dr("ImporteTotal")),
                            CDec(dr("ImporteOS")),
                            CDec(dr("ImporteCS")),
                            CDec(dr("ImporteAf")),
                            If(IsDBNull(dr("NumAutorizacion")), "", dr("NumAutorizacion").ToString),
                            If(IsDBNull(dr("EstadoReceta")), "", dr("EstadoReceta").ToString)
                            )

    End Function
End Module
