Imports MySql.Data.MySqlClient
Imports SiCoFa.Entidades

Public Module PlanOSMapper

    Public Function Map(datos As MySqlDataReader) As PlanOS

        Dim OS As New ObraSocial(
            Convert.ToInt32(datos("IdOS")),
            datos("NombreOS").ToString(),
            If(IsDBNull(datos("ValidadorOS")), Nothing, datos("ValidadorOS").ToString()),
            If(IsDBNull(datos("FinanciadorOS")), Nothing, datos("FinanciadorOS").ToString()),
            Convert.ToBoolean(datos("ComprobanteFiscalOS")),
            Nothing
        )

        Dim CS As ObraSocial = Nothing

        If Convert.ToInt32(datos("IdCS")) > 0 Then

            CS = New ObraSocial(
                Convert.ToInt32(datos("IdCS")),
                datos("NombreCS").ToString(),
                If(IsDBNull(datos("ValidadorCS")), Nothing, datos("ValidadorCS").ToString()),
                If(IsDBNull(datos("FinanciadorCS")), Nothing, datos("FinanciadorCS").ToString()),
                Convert.ToBoolean(datos("ComprobanteFiscalCS")),
                Nothing
            )

        End If

        Dim PVal As ParametrosValidacion = Nothing

        If IsDBNull(datos("Validador")) = False Then


            PVal = New ParametrosValidacion(
                datos("ValidadorOS").ToString,
                datos("DescripcionValidador").ToString,
                datos("NumPrestador").ToString,
                datos("CuitPrestador").ToString,
                If(IsDBNull(datos("Usuario")), Nothing, datos("Usuario").ToString()),
                If(IsDBNull(datos("IdOrganizacion")), Nothing, datos("IdOrganizacion").ToString()),
                If(IsDBNull(datos("Licencia")), Nothing, datos("Licencia").ToString()),
                If(IsDBNull(datos("Reporte")), Nothing, datos("Reporte").ToString())
            )

        End If

        Return New PlanOS(
            Convert.ToInt64(datos("IdPlan")),
            datos("Descripcion").ToString(),
            OS,
            CS,
            Convert.ToInt32(datos("Proceso")),
            Convert.ToInt32(datos("CodiLabora")),
            Convert.ToInt32(datos("IdVdm1")),
            Convert.ToDecimal(datos("DesGeneral1")),
            Convert.ToInt32(datos("IdVdm2")),
            Convert.ToDecimal(datos("DesGeneral2")),
            Convert.ToInt32(datos("AtbMonoD")),
            Convert.ToInt32(datos("AtbMultiD")),
            Convert.ToInt32(datos("UnidRpChico")),
            Convert.ToInt32(datos("UnidRpGrande")),
            Convert.ToInt32(datos("LineasRta")),
            Convert.ToInt32(datos("EnvGrandeRta")),
            Convert.ToBoolean(datos("IncluyeVL")),
            Convert.ToInt32(datos("DiasVencimientoRta")),
            Convert.ToBoolean(datos("Display")),
            If(IsDBNull(datos("Observaciones")), Nothing, datos("Observaciones").ToString()),
            If(IsDBNull(datos("PlanValidacion")), Nothing, datos("PlanValidacion").ToString())
            )

    End Function

End Module