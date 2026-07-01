Imports MySql.Data.MySqlClient
Imports SiCoFa.Entidades

Public Module PlanOSMapper

    Public Function Map(datos As MySqlDataReader) As PlanOS

        Dim PValOS As ParametrosValidacion = Nothing

        If Not IsDBNull(datos("ValidadorOS")) Then
            PValOS = New ParametrosValidacion(
                If(IsDBNull(datos("ValidadorOS")), Nothing, datos("ValidadorOS").ToString()),
                If(IsDBNull(datos("DescripcionValidadorOS")), Nothing, datos("DescripcionValidadorOS").ToString()),
                If(IsDBNull(datos("NumPrestadorOS")), Nothing, datos("NumPrestadorOS").ToString()),
                If(IsDBNull(datos("CuitPrestador")), Nothing, datos("CuitPrestador").ToString()),
                If(IsDBNull(datos("UsuarioOS")), Nothing, datos("UsuarioOS").ToString()),
                If(IsDBNull(datos("IdOrganizacionOS")), Nothing, datos("IdOrganizacionOS").ToString()),
                If(IsDBNull(datos("LicenciaOS")), Nothing, datos("LicenciaOS").ToString()),
                If(IsDBNull(datos("ReporteOS")), Nothing, datos("ReporteOS").ToString()),
                If(IsDBNull(datos("UrlOS")), Nothing, datos("UrlOS").ToString())
                )
        End If

        Dim OS As New ObraSocial(
            Convert.ToInt32(datos("IdOS")),
            datos("NombreOS").ToString(),
            If(IsDBNull(datos("ValidadorOS")), Nothing, datos("ValidadorOS")).ToString(),
            PValOS,
            If(IsDBNull(datos("FinanciadorOS")), Nothing, datos("FinanciadorOS").ToString()),
            Convert.ToBoolean(datos("ComprobanteFiscalOS")),
            Nothing
        )

        Dim PValCS As ParametrosValidacion = Nothing

        If Not IsDBNull(datos("ValidadorCS")) Then
            PValOS = New ParametrosValidacion(
                If(IsDBNull(datos("ValidadorCS")), Nothing, datos("ValidadorCS").ToString()),
                If(IsDBNull(datos("DescripcionValidadorCS")), Nothing, datos("DescripcionValidadorCS").ToString()),
                If(IsDBNull(datos("NumPrestadorCS")), Nothing, datos("NumPrestadorCS").ToString()),
                If(IsDBNull(datos("CuitPrestador")), Nothing, datos("CuitPrestador").ToString()),
                If(IsDBNull(datos("UsuarioCS")), Nothing, datos("UsuarioCS").ToString()),
                If(IsDBNull(datos("IdOrganizacionCS")), Nothing, datos("IdOrganizacionCS").ToString()),
                If(IsDBNull(datos("LicenciaCS")), Nothing, datos("LicenciaCS").ToString()),
                If(IsDBNull(datos("ReporteCS")), Nothing, datos("ReporteCS").ToString()),
                If(IsDBNull(datos("UrlCS")), Nothing, datos("UrlCS").ToString())
                )
        End If

        Dim CS As ObraSocial = Nothing

        If Convert.ToInt32(datos("IdCS")) > 0 Then

            CS = New ObraSocial(
                Convert.ToInt32(datos("IdCS")),
                datos("NombreCS").ToString(),
                If(IsDBNull(datos("ValidadorCS")), Nothing, datos("ValidadorCS")).ToString(),
                PValCS,
                If(IsDBNull(datos("FinanciadorCS")), Nothing, datos("FinanciadorCS").ToString()),
                Convert.ToBoolean(datos("ComprobanteFiscalCS")),
                Nothing
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