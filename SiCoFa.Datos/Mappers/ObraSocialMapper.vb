Imports MySql.Data.MySqlClient
Imports SiCoFa.Entidades

Module ObraSocialMapper
    Public Function Map(dr As MySqlDataReader) As ObraSocial


        Return New ObraSocial(
        argIdOS:=If(IsDBNull(dr("IdOS")), Nothing, Convert.ToInt32(dr("IdOS"))),
        argNombreOS:=If(IsDBNull(dr("NombreOS")), Nothing, dr("NombreOS")).ToString,
        argValidador:=If(IsDBNull(dr("Validador")), Nothing, dr("Validador")).ToString(),
        Nothing,
        argFinanciador:=If(IsDBNull(dr("Finanaciador")), Nothing, dr("Financiador")).ToString(),
        argComprobanteFiscal:=If(IsDBNull(dr("ComprobanteFiscal")), Nothing, Convert.ToBoolean(dr("ComprobanteFiscal"))),
        argNumeroActualizacion:=If(IsDBNull(dr("NumeroActualizacion")), Nothing, Convert.ToInt64(dr("NumeroActualizacion")))
    )

    End Function
End Module
