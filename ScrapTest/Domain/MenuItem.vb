
Imports System.ComponentModel

Public Class MenuItem
    Implements INotifyPropertyChanged
    Private _name As String
    Private _content As Object
    Private _horizontalScrollBarVisibilityRequirement As ScrollBarVisibility
    Private _verticalScrollBarVisibilityRequirement As ScrollBarVisibility
    Private _marginRequirement As Thickness

    Public Sub New(ByVal Name As String, ByVal Content As Object)
        _name = Name
        _content = Content
        _marginRequirement = New Thickness(16)
    End Sub

    Public Property Name As String
        Get
            Return Me._name
        End Get
        Set(value As String)
            Me.MutateVerbose(Me._name, value, Me.RaisePropertyChanged)
        End Set
    End Property

    Public Property Content As Object
        Get
            Return Me._content
        End Get
        Set(value As Object)
            Me.MutateVerbose(Me._content, value, Me.RaisePropertyChanged)
        End Set
    End Property

    Public Property HorizontalScrollBarVisibilityRequirement As ScrollBarVisibility
        Get
            Return Me._horizontalScrollBarVisibilityRequirement
        End Get
        Set
            Me.MutateVerbose(Me._horizontalScrollBarVisibilityRequirement, Value, Me.RaisePropertyChanged)
        End Set
    End Property

    Public Property VerticalScrollBarVisibilityRequirement As ScrollBarVisibility
        Get
            Return Me._verticalScrollBarVisibilityRequirement
        End Get
        Set
            Me.MutateVerbose(Me._verticalScrollBarVisibilityRequirement, Value, Me.RaisePropertyChanged)
        End Set
    End Property

    Public Property MarginRequirement As Thickness
        Get
            Return Me._marginRequirement
        End Get
        Set
            Me.MutateVerbose(Me._marginRequirement, Value, RaisePropertyChanged)
        End Set
    End Property

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Private Function RaisePropertyChanged() As Action(Of PropertyChangedEventArgs)
        Return Sub(ByVal arg)
                   RaiseEvent PropertyChanged(Me, arg)
               End Sub
    End Function

End Class
