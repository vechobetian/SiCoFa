Imports MySql.Data.MySqlClient
Imports SiCoFa.Entidades

Public Module PlanOSMapper

    Public Function Map(datos As MySqlDataReader) As PlanOS

        Dim pValOS As ParametrosValidacion = Nothing

        If Not IsDBNull(datos("ValidadorOS")) Then
            pValOS = New ParametrosValidacion(
                If(IsDBNull(datos("ValidadorOS")), Nothing, datos("ValidadorOS").ToString()),
                If(IsDBNull(datos("DescripcionValidadorOS")), Nothing, datos("DescripcionValidadorOS").ToString()),
                If(IsDBNull(datos("NumPrestadorOS")), Nothing, datos("NumPrestadorOS").ToString()),
                If(IsDBNull(datos("CuitPrestador")), Nothing, datos("CuitPrestador").ToString()),
                If(IsDBNull(datos("UsuarioOS")), Nothing, datos("UsuarioOS").ToString()),
                If(IsDBNull(datos("IdOrganizacionOS")), Nothing, datos("IdOrganizacionOS").ToString()),
                If(IsDBNull(datos("LicenciaOS")), Nothing, datos("LicenciaOS").ToString()),
                If(IsDBNull(datos("FinanciadorOS")), Nothing, datos("FinanciadorOS").ToString()),
                If(IsDBNull(datos("ReporteOS")), Nothing, datos("ReporteOS").ToString()),
                Convert.ToBoolean(datos("RecetaElectronicaOS"))
                )
        End If

        Dim os As New ObraSocial(
            Convert.ToInt32(datos("IdOS")),
            datos("NombreOS").ToString(),
            If(IsDBNull(datos("ValidadorOS")), Nothing, datos("ValidadorOS")).ToString(),
            PValOS,
            Convert.ToBoolean(datos("ComprobanteFiscalOS")),
            Nothing
        )

        Dim pValCS As ParametrosValidacion = Nothing

        If Not IsDBNull(datos("ValidadorCS")) Then
            pValOS = New ParametrosValidacion(
                If(IsDBNull(datos("ValidadorCS")), Nothing, datos("ValidadorCS").ToString()),
                If(IsDBNull(datos("DescripcionValidadorCS")), Nothing, datos("DescripcionValidadorCS").ToString()),
                If(IsDBNull(datos("NumPrestadorCS")), Nothing, datos("NumPrestadorCS").ToString()),
                If(IsDBNull(datos("CuitPrestador")), Nothing, datos("CuitPrestador").ToString()),
                If(IsDBNull(datos("UsuarioCS")), Nothing, datos("UsuarioCS").ToString()),
                If(IsDBNull(datos("IdOrganizacionCS")), Nothing, datos("IdOrganizacionCS").ToString()),
                If(IsDBNull(datos("LicenciaCS")), Nothing, datos("LicenciaCS").ToString()),
                If(IsDBNull(datos("FinanciadorCS")), Nothing, datos("FinanciadorCS").ToString()),
                If(IsDBNull(datos("ReporteCS")), Nothing, datos("ReporteCS").ToString()),
                Convert.ToBoolean(datos("RecetaElectronicaCS"))
                )
        End If

        Dim cs As ObraSocial = Nothing

        If Convert.ToInt32(datos("IdCS")) > 0 Then

            cs = New ObraSocial(
                Convert.ToInt32(datos("IdCS")),
                datos("NombreCS").ToString(),
                If(IsDBNull(datos("ValidadorCS")), Nothing, datos("ValidadorCS")).ToString(),
                pValCS,
                Convert.ToBoolean(datos("ComprobanteFiscalCS")),
                Nothing
            )

        End If

        Dim dr As DatosRequeridos = Nothing

        If Not datos.IsDBNull(datos.GetOrdinal("NumRta")) Then
            dr = New DatosRequeridos(
                                    Convert.ToInt64(datos("IdPlan")),
                                    Convert.ToBoolean(datos("NumRta")),
                                    Convert.ToBoolean(datos("NumAf")),
                                    Convert.ToBoolean(datos("NombreAf")),
                                    Convert.ToBoolean(datos("DocumentoAf")),
                                    Convert.ToBoolean(datos("Prescriptor")),
                                    Convert.ToBoolean(datos("Token")),
                                    Convert.ToBoolean(datos("Diagnostico"))
                                    )
        End If

        Return New PlanOS(
            Convert.ToInt64(datos("IdPlan")),
            datos("Descripcion").ToString(),
            os,
            cs,
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
            If(IsDBNull(datos("PlanValidacion")), Nothing, datos("PlanValidacion").ToString()),
            dr
            )

    End Function

End Module