Imports MaterialDesignThemes.Wpf

Namespace Domain
    Public Class LoginDialog
        Private _dialogResult As MessageBoxResult
        Private ReadOnly DEFAULT_USERNAME As String = "admin"
        Private ReadOnly DEFAULT_PASSWORD As String = "admin"

        Public Property DialogResult As MessageBoxResult
            Get
                Return _dialogResult
            End Get
            Set(value As MessageBoxResult)
                _dialogResult = value
            End Set
        End Property

        Private Sub ButtonYes_Click(sender As Object, e As RoutedEventArgs)
            Dim userName As String = tbDangNhap.Text
            Dim password As String = tbMatKhau.Text
            If userName.Equals(DEFAULT_USERNAME) And password.Equals(DEFAULT_PASSWORD) Then
                DialogHost.CloseDialogCommand.Execute(sender, Me)
            End If
            DialogResult = MessageBoxResult.Yes
        End Sub

        Private Sub ButtonNo_Click(sender As Object, e As RoutedEventArgs)

        End Sub
    End Class
End Namespace

