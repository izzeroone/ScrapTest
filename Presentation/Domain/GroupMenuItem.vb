Imports System.Collections.ObjectModel
Imports System.ComponentModel
Namespace Domain
    Public Class GroupMenuItem
        Implements INotifyPropertyChanged
        Private _Name As String
        Private _Content As Object
        Private _MenuItems As ObservableCollection(Of MenuItem)

        Public Property MenuItems As ObservableCollection(Of MenuItem)
            Get
                Return _MenuItems
            End Get
            Set(value As ObservableCollection(Of MenuItem))
                _MenuItems = value
            End Set
        End Property

        Public Property Name As String
            Get
                Return _Name
            End Get
            Set(value As String)
                _Name = value
            End Set
        End Property

        Public Property Content As Object
            Get
                Return _Content
            End Get
            Set(value As Object)
                _Content = value
            End Set
        End Property

        Public Sub New()
            _MenuItems = New ObservableCollection(Of MenuItem)
        End Sub

        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
        Private Function RaisePropertyChanged() As Action(Of PropertyChangedEventArgs)
            Return Sub(ByVal arg)
                       RaiseEvent PropertyChanged(Me, arg)
                   End Sub
        End Function
    End Class
End Namespace
