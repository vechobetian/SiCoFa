Imports SiCoFa.Entidades
Imports System.ComponentModel

Public Class clsPortapapelesVenta
    Public Shared Operacion As Operacion
    Public Shared Cliente As Cliente

    Private Shared _Items As BindingList(Of ItemComprobante)
    Public Shared Property Items As BindingList(Of ItemComprobante)
        Get
            Return _Items
        End Get
        Set(value As BindingList(Of ItemComprobante))
            _Items = value

            ' Lógica automática: establecer IdItem = 0 en todos los ítems
            If _Items IsNot Nothing Then
                For Each item As ItemComprobante In _Items
                    item.IdItem = 0
                Next
            End If
        End Set
    End Property

End Class
