Public Module Funciones

    Private Units() As String = {"", "uno", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve"}
    Private Teens() As String = {"diez", "once", "doce", "trece", "catorce", "quince", "dieciséis", "diecisiete", "dieciocho", "diecinueve"}
    Private Twenties() As String = {"veinte", "veintiuno", "veintidós", "veintitrés", "veinticuatro", "veinticinco", "veintiséis", "veintisiete", "veintiocho", "veintinueve"}
    Private Tens() As String = {"", "", "treinta", "cuarenta", "cincuenta", "sesenta", "setenta", "ochenta", "noventa"}
    Private Hundreds() As String = {"", "cien", "doscientos", "trescientos", "cuatrocientos", "quinientos", "seiscientos", "setecientos", "ochocientos", "novecientos"}

    Public Function NumEnLetras(ByVal number As Decimal) As String
        Dim integerPart As Long = Math.Truncate(number)
        Dim decimalPart As Integer = CInt((number - integerPart) * 100)
        Dim result As String = ConvertNumberToWords(integerPart)

        If decimalPart > 0 Then
            result &= " con " & ConvertNumberToWords(decimalPart) & " centavos"
        End If

        Return result.Trim()
    End Function
    Private Function ConvertNumberToWords(ByVal number As Long) As String
        If number = 0 Then
            Return "cero"
        ElseIf number < 10 Then
            Return Units(number)
        ElseIf number < 20 Then
            Return Teens(number - 10)
        ElseIf number >= 20 AndAlso number <= 29 Then
            Return Twenties(number - 20)
        ElseIf number < 100 Then
            Return Tens(number \ 10) & If((number Mod 10) > 0, " y " & Units(number Mod 10), "")
        ElseIf number < 1000 Then
            If number = 100 Then
                Return "cien"
            End If
            Return Hundreds(number \ 100) & If((number Mod 100) > 0, " " & ConvertNumberToWords(number Mod 100), "")
        ElseIf number < 1000000 Then
            Return If(number \ 1000 = 1, "mil", ConvertNumberToWords(number \ 1000) & " mil") & If((number Mod 1000) > 0, " " & ConvertNumberToWords(number Mod 1000), "")
        ElseIf number < 1000000000000 Then
            Return If(number \ 1000000 = 1, "un millón", ConvertNumberToWords(number \ 1000000) & " millones") & If((number Mod 1000000) > 0, " " & ConvertNumberToWords(number Mod 1000000), "")
        Else
            Return "Número demasiado grande"
        End If
    End Function
    Public Function CCero(ByVal Valor As String) As Integer
        Try
            If Valor = "" Then
                Return 0
            Else
                Return Valor
            End If

        Catch ex As Exception
            Return 0
        End Try

    End Function
    Public Function CDecimal(ByVal argValor As String) As Decimal
        Dim NDecimal As Decimal
        Dim decimalSeparator As String = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator
        Dim thousandsSeparator As String = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator

        ' Eliminar los separadores de miles (puntos en tu ejemplo)
        Dim valueWithoutThousands As String = argValor.Replace(thousandsSeparator, "")

        ' Reemplazar el separador decimal (coma en tu ejemplo) por el separador decimal de la cultura actual
        Dim normalizedValue As String = valueWithoutThousands.Replace(",", decimalSeparator)

        ' Intentar convertir el string a Decimal
        If Not Decimal.TryParse(normalizedValue, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.CurrentCulture, NDecimal) Then
            ' Si no se puede convertir, manejar el error (puedes lanzar una excepción o devolver un valor por defecto)
            Throw New ArgumentException("El valor proporcionado no es un número decimal válido.")
        End If

        Return NDecimal
    End Function
    Public Function MensajeError(argModulo As String, argProcedimiento As String, argDescripcion As String) As String

        Dim msj As String
        msj = "Modulo: " & argModulo & vbCrLf & "Procedimiento: " & argProcedimiento & vbCrLf & "Descripción: " & argDescripcion
        Return msj

    End Function
End Module
