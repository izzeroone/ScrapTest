Public Class ucMainMenu
    Private Sub GitHubButton_OnClick(sender As Object, e As RoutedEventArgs)
        Process.Start("https://github.com/trumpsilver/ScrapTest")
    End Sub

    Private Sub EmailButton_OnClick(sender As Object, e As RoutedEventArgs)
        Process.Start("mailto://15521037@gm.uit.edu.vn")
    End Sub
End Class
