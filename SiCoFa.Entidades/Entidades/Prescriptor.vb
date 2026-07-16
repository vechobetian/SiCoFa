Public Class Prescriptor

    Public Property TipoPrescriptor As TipoPrescriptor
    Public Property Provincia As Provincia
    Public Property Apellido As String
    Public Property Nombre As String
    Public Property Matricula As Matricula

    Public Sub New()
        Me.TipoPrescriptor = New TipoPrescriptor
        Me.Provincia = New Provincia
        Me.Matricula = New Matricula
    End Sub

    Public Sub New(ByVal argTipoPrescriptor As TipoPrescriptor, ByVal argProvincia As Provincia, ByVal argApellido As String, argNombre As String, argMatricula As Matricula)
        Me.TipoPrescriptor = argTipoPrescriptor
        Me.Provincia = argProvincia
        Me.Apellido = argApellido
        Me.Nombre = argNombre
        Me.Matricula = argMatricula
    End Sub

End Class
