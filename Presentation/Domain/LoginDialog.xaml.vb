Imports MaterialDesignThemes.Wpf
Imports Business
Imports System.Windows.Media.Animation
Imports Business.Business

Namespace Domain
    Public Class LoginDialog
        Private _dialogResult As MessageBoxResult
        Private ReadOnly DEFAULT_USERNAME As String = "admin"
        Private ReadOnly DEFAULT_PASSWORD As String = "admin"
        Private MyStoryBoard As Storyboard = New Storyboard

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
            Dim password As String = tbMatKhau.Password
            If (userName.Equals(DEFAULT_USERNAME) And password.Equals(DEFAULT_PASSWORD)) Then
                DialogHost.CloseDialogCommand.Execute(sender, Me)
                If (DangNhapBUS.DangNhap(userName, password)) Then
                    DialogHost.CloseDialogCommand.Execute(sender, Me)
                Else
                    Message.Text = "Tên đăng nhập hoặc mật khẩu không đúng"
                    Message.Foreground = New SolidColorBrush(Colors.Red)
                    Dim MyStoryBoard As Storyboard = New Storyboard
                    MyStoryBoard.Duration = New Duration(TimeSpan.FromSeconds(1))
                    Dim opacityAnimation As DoubleAnimation = New DoubleAnimation() With {
                        .From = 0.0,
                        .To = 1.0,
                        .BeginTime = TimeSpan.FromSeconds(0),
                        .Duration = New Duration(TimeSpan.FromSeconds(0.1))}
                    Storyboard.SetTarget(opacityAnimation, Message)
                    Storyboard.SetTargetProperty(opacityAnimation, New PropertyPath("Opacity"))
                    MyStoryBoard.Children.Add(opacityAnimation)
                    MyStoryBoard.RepeatBehavior = RepeatBehavior.Forever
                    MyStoryBoard.AutoReverse = True
                    MyStoryBoard.Begin()
                End If

            End If
            DialogResult = MessageBoxResult.Yes
        End Sub

        Private Sub ButtonNo_Click(sender As Object, e As RoutedEventArgs)
            DialogHost.CloseDialogCommand.Execute(sender, Me)
            DialogResult = MessageBoxResult.No
        End Sub


        Private Sub tbMatKhau_KeyDown(sender As Object, e As KeyEventArgs) Handles tbMatKhau.KeyDown
            Message.Opacity = 1.0
            MyStoryBoard.Stop()
        End Sub

        Private Sub tbDangNhap_KeyDown(sender As Object, e As KeyEventArgs) Handles tbDangNhap.KeyDown
            Message.Opacity = 1.0
            MyStoryBoard.Stop()
        End Sub
    End Class
End Namespace

