Namespace Domain
    Public Class YesNoDialog
        Private _dialogResult As MessageBoxResult

        Public Property DialogResult As MessageBoxResult
            Get
                Return _dialogResult
            End Get
            Set(value As MessageBoxResult)
                _dialogResult = value
            End Set
        End Property

        Private Sub ButtonYes_Click(sender As Object, e As RoutedEventArgs)
            DialogResult = MessageBoxResult.Yes
        End Sub

        Private Sub ButtonNo_Click(sender As Object, e As RoutedEventArgs)
            DialogResult = MessageBoxResult.No
        End Sub
    End Class
End Namespace

