Imports SiCoFa.Datos
Imports SiCoFa.Entidades

Public Class N_ParametrosSistema

    Private mobj_Parametros As Dictionary(Of String, ParametrosSistema)

    Public Sub New()
        CargarParametros()
    End Sub

    Private Sub CargarParametros()
        Dim datos As New D_ParametrosSistema
        Dim lista = datos.ObtenerParametrosSistema()
        mobj_Parametros = lista.ToDictionary(Function(p) p.CodiParam, StringComparer.OrdinalIgnoreCase)
    End Sub

    Public Function GetValor(clave As String) As String
        If mobj_Parametros IsNot Nothing AndAlso mobj_Parametros.ContainsKey(clave) Then
            Return mobj_Parametros(clave).Valor
        Else
            Return Nothing
        End If
    End Function

    Public Function GetBooleano(clave As String) As Boolean
        Dim valor = GetValor(clave)
        Return Not String.IsNullOrEmpty(valor) AndAlso valor.Trim().ToLower() = "true"
    End Function

    Public Function GetDecimal(clave As String) As Decimal
        Dim result As Decimal
        Decimal.TryParse(GetValor(clave), result)
        Return result
    End Function

    Public Function GetEntero(clave As String) As Integer
        Dim result As Integer
        Integer.TryParse(GetValor(clave), result)
        Return result
    End Function

    Public Function GetFecha(clave As String) As DateTime?
        Dim resultado As DateTime
        If DateTime.TryParse(GetValor(clave), resultado) Then
            Return resultado
        Else
            Return Nothing
        End If
    End Function

End Class
