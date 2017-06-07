Imports System.Collections.ObjectModel
Imports System.ComponentModel
Namespace Domain
    Public Class GroupMenuItem
        Implements INotifyPropertyChanged
        Private _name As String
        Private _content As Object
        Private _menuItems As ObservableCollection(Of MenuItem)

        Public Property MenuItems As ObservableCollection(Of MenuItem)
            Get
                Return _menuItems
            End Get
            Set(value As ObservableCollection(Of MenuItem))
                _menuItems = value
            End Set
        End Property

        Public Property Name As String
            Get
                Return _name
            End Get
            Set(value As String)
                _name = value
            End Set
        End Property

        Public Property Content As Object
            Get
                Return _content
            End Get
            Set(value As Object)
                _content = value
            End Set
        End Property

        Public Sub New()
            _menuItems = New ObservableCollection(Of MenuItem)
        End Sub

        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
        Private Function RaisePropertyChanged() As Action(Of PropertyChangedEventArgs)
            Return Sub(ByVal arg)
                       RaiseEvent PropertyChanged(Me, arg)
                   End Sub
        End Function
    End Class
End Namespace
