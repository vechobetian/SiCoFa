Imports System.ComponentModel

Public Class CuentaBancaria
    Implements INotifyPropertyChanged

    Private _IdCB As Int32
    Private _Descripcion As String
    Private _NumCuenta As String
    Private _FechaAlta As Date
    Private _Baja As Boolean

    Public Property IdCB As Int32
        Get
            Return _IdCB
        End Get
        Set(value As Int32)
            If _IdCB <> value Then
                _IdCB = value
                OnPropertyChanged(NameOf(IdCB))
            End If
        End Set
    End Property

    Public Property Descripcion As String
        Get
            Return _Descripcion
        End Get
        Set(value As String)
            If _Descripcion <> value Then
                _Descripcion = value
                OnPropertyChanged(NameOf(Descripcion))
            End If
        End Set
    End Property

    Public Property NumCuenta As String
        Get
            Return _NumCuenta
        End Get
        Set(value As String)
            If _NumCuenta <> value Then
                _NumCuenta = value
                OnPropertyChanged(NameOf(NumCuenta))
            End If
        End Set
    End Property

    Public Property FechaAlta As Date
        Get
            Return _FechaAlta
        End Get
        Set(value As Date)
            If _FechaAlta <> value Then
                _FechaAlta = value
                OnPropertyChanged(NameOf(FechaAlta))
            End If
        End Set
    End Property

    Public Property Baja As Boolean
        Get
            Return _Baja
        End Get
        Set(value As Boolean)
            If _Baja <> value Then
                _Baja = value
                OnPropertyChanged(NameOf(Baja))
            End If
        End Set
    End Property

    Public Event PropertyChanged As PropertyChangedEventHandler _
        Implements INotifyPropertyChanged.PropertyChanged

    Protected Sub OnPropertyChanged(propertyName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

    Public Sub New()
    End Sub

    ' Constructor con parámetros opcional
    Public Sub New(argIdCB As Int32, argDescripcion As String, argNumCuenta As String, argFechaAlta As Date, argBaja As Boolean)
        IdCB = argIdCB
        Descripcion = argDescripcion
        NumCuenta = argNumCuenta
        FechaAlta = argFechaAlta
        Baja = argBaja
    End Sub
End Class
