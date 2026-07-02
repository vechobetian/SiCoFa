Imports System.Text
Imports System.Xml
Imports SiCoFa.Entidades

Public Class LPAMI
    Implements IValidador

    Private Const VERSION_ADESFA As String = "3.1.0"
    Private Const NOMBRE_SOFTWARE As String = "SICOFA"
    Private Const VERSION_SOFTWARE As String = "4.0.0"
    Private Const COD_ACCION_AUTORIZACION As String = "290020"
    Private Const COD_ACCION_CONSULTA_RECETAS As String = "490220"

    Public Function ConsultaRecetasBeneficiario(argReceta As Receta) As ResultadoValidacion Implements IValidador.ConsultaRecetasBeneficiario
        Dim xmlAdesfa As String = MensajeAdesfaConsultaRecetas(argReceta, 1, "200")

        ' Por ahora solo para probar
        IO.File.WriteAllText("C:\Temp\ConsultaRecetas.xml", xmlAdesfa)

        Dim resultado As New ResultadoValidacion
        resultado.XmlRespuesta = xmlAdesfa

        Return resultado

    End Function

    Public Function SolicitarAutorizacion(argReceta As Receta) As ResultadoValidacion Implements IValidador.SolicitarAutorizacion

        Throw New NotImplementedException()

    End Function

    '=========================================================
    ' ENCABEZADO MENSAJE
    '=========================================================
    Private Sub EncabezadoMensajeAdesfa(writer As XmlWriter,
                                       argReceta As Receta,
                                       argTipoMensaje As String,
                                       argCodigoAccion As String,
                                       argIdMensaje As Long,
                                       argFechaHora As DateTime)

        writer.WriteStartElement("EncabezadoMensaje")

        writer.WriteElementString("TipoMsj", argTipoMensaje)
        writer.WriteElementString("CodAccion", argCodigoAccion)
        writer.WriteElementString("IdMsj", argIdMensaje.ToString())

        writer.WriteStartElement("InicioTrx")
        writer.WriteElementString("Fecha", argFechaHora.ToString("yyyyMMdd"))
        writer.WriteElementString("Hora", argFechaHora.ToString("HHmmss"))
        writer.WriteEndElement()

        writer.WriteStartElement("Software")
        writer.WriteElementString("Nombre", NOMBRE_SOFTWARE)
        writer.WriteElementString("Version", VERSION_SOFTWARE)
        writer.WriteEndElement()

        writer.WriteStartElement("Validador")
        writer.WriteElementString("CodigoADESFA", "0")
        writer.WriteElementString("Nombre", "IMED")
        writer.WriteEndElement()

        writer.WriteStartElement("Prestador")
        writer.WriteElementString("Cuit", argReceta.Plan.OS.PValidacion.CuitPrestador)
        writer.WriteElementString("Sucursal", "0")
        writer.WriteElementString("RazonSocial", "")
        writer.WriteElementString("Codigo", argReceta.Plan.OS.PValidacion.NumPrestador)
        writer.WriteEndElement()

        writer.WriteEndElement()

    End Sub

    Private Sub EncabezadoConsultaRecetasAdesfa(writer As XmlWriter,
                                            argReceta As Receta)

        writer.WriteStartElement("EncabezadoReceta")

        writer.WriteStartElement("Financiador")
        writer.WriteElementString("CodigoADESFA", "")
        writer.WriteElementString("Codigo", argReceta.Plan.OS.Financiador)
        writer.WriteElementString("Cuit", "")
        writer.WriteElementString("Sucursal", "")
        writer.WriteEndElement()

        writer.WriteStartElement("Beneficiario")
        writer.WriteElementString("TipoDoc", "")
        writer.WriteElementString("NroDoc", "")
        writer.WriteElementString("Apellido", "")
        writer.WriteElementString("Nombre", "")
        writer.WriteElementString("Sexo", "")
        writer.WriteElementString("FechaNacimiento", "")
        writer.WriteElementString("Parentesco", "")
        writer.WriteElementString("EdadUnidad", "")
        writer.WriteElementString("Edad", "")
        writer.WriteEndElement()

        writer.WriteStartElement("Credencial")
        writer.WriteElementString("Numero", argReceta.Credencial.Numero)
        writer.WriteElementString("Track", "")
        writer.WriteElementString("Version", "")
        writer.WriteElementString("Vencimiento", "")
        writer.WriteElementString("ModoIngreso", "")
        writer.WriteElementString("EsProvisorio", "")
        writer.WriteElementString("Plan", "41")
        writer.WriteElementString("cvc2", "")
        writer.WriteEndElement()

        writer.WriteEndElement() 'EncabezadoReceta

    End Sub

    '=========================================================
    ' ENCABEZADO RECETA
    '=========================================================
    Private Sub EncabezadoRecetaAdesfa(writer As XmlWriter,
                                       argReceta As Receta,
                                       argFechaHora As DateTime)

        writer.WriteStartElement("EncabezadoReceta")

        writer.WriteStartElement("Validador")
        writer.WriteElementString("CodigoADESFA", "0")
        writer.WriteElementString("Nombre", "IMED")
        writer.WriteEndElement()

        writer.WriteStartElement("Prescriptor")
        writer.WriteElementString("Apellido", "")
        writer.WriteElementString("Nombre", "")
        writer.WriteElementString("TipoMatricula", argReceta.Prescriptor.Matricula.CodiTMatADESFA)
        writer.WriteElementString("Provincia", argReceta.Prescriptor.Provincia.CodigoProvincia)
        writer.WriteElementString("NroMatricula", argReceta.Prescriptor.Matricula.Numero)
        writer.WriteElementString("TipoPrescriptor", argReceta.Prescriptor.TipoPrescriptor.CodiTPresADESFA)
        writer.WriteElementString("Cuit", "")
        writer.WriteElementString("Especialidad", "")
        writer.WriteEndElement()

        writer.WriteElementString("Beneficiario", "")

        writer.WriteStartElement("Financiador")
        writer.WriteElementString("Codigo", argReceta.Plan.OS.Financiador)
        writer.WriteEndElement()

        writer.WriteStartElement("Credencial")
        writer.WriteElementString("Numero", argReceta.Credencial.Numero)
        writer.WriteElementString("Track", "")
        writer.WriteElementString("Version", "")
        writer.WriteElementString("Vencimiento", "")
        writer.WriteElementString("ModoIngreso", "A")
        writer.WriteElementString("EsProvisorio", "")
        writer.WriteElementString("Plan", "0")
        writer.WriteElementString("cvc2", "")
        writer.WriteEndElement()

        writer.WriteStartElement("Preautorizacion")
        writer.WriteElementString("Codigo", "")
        writer.WriteElementString("Fecha", "")
        writer.WriteEndElement()

        writer.WriteElementString("FechaReceta", argReceta.FechaPrescripcion.ToString("yyyyMMdd"))

        writer.WriteStartElement("Dispensa")
        writer.WriteElementString("Fecha", argFechaHora.ToString("yyyyMMdd"))
        writer.WriteElementString("Hora", argFechaHora.ToString("HHmmss"))
        writer.WriteEndElement()

        writer.WriteStartElement("Formulario")
        writer.WriteElementString("Fecha", "")
        writer.WriteElementString("Tipo", "0")
        writer.WriteElementString("Numero", argReceta.NumReceta)
        writer.WriteElementString("Serie", "0")
        writer.WriteElementString("NroAutEspecial", "0")
        writer.WriteElementString("NroFormulario", "0")
        writer.WriteEndElement()

        writer.WriteElementString("TipoTratamiento", argReceta.Tratamiento)
        writer.WriteElementString("Diagnostico", "")

        writer.WriteStartElement("Institucion")
        writer.WriteElementString("Codigo", "000000000000000")
        writer.WriteElementString("Cuit", "0")
        writer.WriteElementString("Sucursal", "0")
        writer.WriteEndElement()

        writer.WriteStartElement("Retira")
        writer.WriteElementString("Apellido", "")
        writer.WriteElementString("Nombre", "")
        writer.WriteElementString("TipoDoc", "")
        writer.WriteElementString("NroDoc", "")
        writer.WriteElementString("NroTelefono", "")
        writer.WriteEndElement()

        writer.WriteEndElement()

    End Sub

    '=========================================================
    ' DETALLE
    '=========================================================
    Private Sub DetalleRecetaAdesfa(writer As XmlWriter,
                                   argReceta As Receta)

        writer.WriteStartElement("DetalleReceta")

        Dim nroItem As Integer = 0

        For Each argItem In argReceta.Items

            nroItem += 1

            writer.WriteStartElement("Item")

            writer.WriteElementString("NroItem", nroItem.ToString())
            writer.WriteElementString("CodBarras", argItem.Articulo.CodBarras)
            writer.WriteElementString("CodTroquel", argItem.Articulo.NTroquel)
            writer.WriteElementString("Alfabeta", argItem.Articulo.Codigo)
            writer.WriteElementString("Kairos", "0")
            writer.WriteElementString("Codigo", "0")
            writer.WriteElementString("ImporteUnitario", "0")
            writer.WriteElementString("CantidadSolicitada", argItem.Cantidad.ToString())
            writer.WriteElementString("PorcentajeCobertura", "0")
            writer.WriteElementString("CodPreautorizacion", "0")
            writer.WriteElementString("ImporteCobertura", "0")
            writer.WriteElementString("Diagnostico", "N")
            writer.WriteElementString("DosisDiaria", "0")
            writer.WriteElementString("Generico", "M")

            writer.WriteEndElement()

        Next

        writer.WriteEndElement()

    End Sub

    Private Function MensajeAdesfaConsultaRecetas(argReceta As Receta,
                                              argIdMensaje As Long,
                                              argTipoMensaje As String) As String

        Dim settings As New XmlWriterSettings With {
        .Indent = True,
        .OmitXmlDeclaration = True
    }

        Dim sb As New StringBuilder()
        Dim argFechaHora As DateTime = DateTime.Now

        Using writer As XmlWriter = XmlWriter.Create(sb, settings)

            writer.WriteStartElement("MensajeADESFA")
            writer.WriteAttributeString("version", VERSION_ADESFA)

            EncabezadoMensajeAdesfa(writer,
                                argReceta,
                                argTipoMensaje,
                                COD_ACCION_CONSULTA_RECETAS,
                                argIdMensaje,
                                argFechaHora)

            EncabezadoConsultaRecetasAdesfa(writer,
                                        argReceta)

            writer.WriteEndElement() 'MensajeADESFA

        End Using

        Return sb.ToString()

    End Function

    '=========================================================
    ' MENSAJE COMPLETO
    '=========================================================
    Private Function MensajeAdesfaAutorizacion(argReceta As Receta,
                                               argIdMensaje As Long,
                                               argTipoMensaje As String) As String

        Dim settings As New XmlWriterSettings With {
            .Indent = True,
            .OmitXmlDeclaration = True
        }

        Dim sb As New StringBuilder()
        Dim argFechaHora As DateTime = DateTime.Now

        Using writer As XmlWriter = XmlWriter.Create(sb, settings)

            writer.WriteStartElement("MensajeADESFA")
            writer.WriteAttributeString("version", VERSION_ADESFA)

            EncabezadoMensajeAdesfa(writer,
                                    argReceta,
                                    argTipoMensaje,
                                    COD_ACCION_AUTORIZACION,
                                    argIdMensaje,
                                    argFechaHora)

            EncabezadoRecetaAdesfa(writer,
                                  argReceta,
                                  argFechaHora)

            DetalleRecetaAdesfa(writer,
                               argReceta)

            writer.WriteEndElement()

        End Using

        Return sb.ToString()

    End Function

    '=========================================================
    ' SOAP
    '=========================================================
    Private Function CrearSoap(argReceta As Receta,
                           argMetodo As String,
                           argNamespace As String,
                           argMensajeAdesfa As String) As String

        Dim settings As New XmlWriterSettings With {
            .Indent = True,
            .OmitXmlDeclaration = False,
            .Encoding = Encoding.UTF8
        }

        Dim sb As New StringBuilder()

        Dim p As ParametrosValidacion = argReceta.Plan.OS.PValidacion

        Using writer As XmlWriter = XmlWriter.Create(sb, settings)

            Dim fechaUtc As String = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ")

            writer.WriteStartDocument()

            writer.WriteStartElement("soap", "Envelope", "http://schemas.xmlsoap.org/soap/envelope/")

            writer.WriteAttributeString("xmlns", "wsse", Nothing,
                "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd")

            writer.WriteAttributeString("xmlns", "wsu", Nothing,
                "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd")

            writer.WriteAttributeString("xmlns", "ns1", Nothing, argNamespace)

            '========================================================
            ' HEADER
            '========================================================
            writer.WriteStartElement("soap", "Header", "http://schemas.xmlsoap.org/soap/envelope/")

            writer.WriteStartElement("wsse", "Security",
                "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd")

            writer.WriteStartElement("wsse", "UsernameToken",
                "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd")

            writer.WriteAttributeString("wsu", "Id",
                "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd",
                "Id-" & Guid.NewGuid().ToString())

            writer.WriteElementString("wsse", "Username", Nothing, p.Usuario)

            writer.WriteStartElement("wsse", "Password", Nothing)
            writer.WriteAttributeString("Type",
                "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-username-token-profile-1.0#PasswordText")
            writer.WriteString(p.Licencia)
            writer.WriteEndElement()

            writer.WriteElementString("wsu", "Created",
                "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd",
                fechaUtc)

            writer.WriteEndElement() 'UsernameToken
            writer.WriteEndElement() 'Security
            writer.WriteEndElement() 'Header

            '========================================================
            ' BODY
            '========================================================
            writer.WriteStartElement("soap", "Body", "http://schemas.xmlsoap.org/soap/envelope/")

            writer.WriteStartElement("ns1", argMetodo, argNamespace)

            writer.WriteStartElement("ns1", "infoCabeceraRq", argNamespace)

            writer.WriteElementString("ns1", "idOrganizacion", argNamespace, p.IdOrganizacion)
            writer.WriteElementString("ns1", "tipoOrganizacion", argNamespace, "FAR")

            writer.WriteEndElement() 'infoCabeceraRq

            writer.WriteElementString("ns1", "payload", argNamespace, argMensajeAdesfa)

            writer.WriteEndElement() 'argMetodo

            writer.WriteEndElement() 'Body
            writer.WriteEndElement() 'Envelope

            writer.WriteEndDocument()

        End Using

        Return sb.ToString()

    End Function

End Class