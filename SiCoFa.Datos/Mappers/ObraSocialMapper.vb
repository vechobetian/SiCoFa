Imports MySql.Data.MySqlClient
Imports SiCoFa.Entidades

Module ObraSocialMapper
    Public Function Map(dr As MySqlDataReader) As ObraSocial

        Return New ObraSocial(
        argIdIOS:=If(IsDBNull(dr("IdOS")), Nothing, Convert.ToInt32(dr("IdOS"))),
        argNombreOS:=dr("NombreOS").ToString(),
        argValidador:=dr("CodiVal").ToString,
        argFinanciador:=dr("Financiador"),
        argComprobanteFiscal:=If(IsDBNull(dr("ComprobanteFiscal")), Nothing, Convert.ToBoolean(dr("ComprobanteFiscal"))),
        argNumeroActualizacion:=If(IsDBNull(dr("NumeroActualizacion")), Nothing, Convert.ToInt64(dr("NumeroActualizacion")))
    )

    End Function
End Module
