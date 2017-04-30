Imports MaterialDesignThemes.Wpf

Module Dialog
    Public Async Sub Show(ByVal content As String)
        Dim messageDialog As New MessageDialog
        messageDialog.Message.Text = content
        Await DialogHost.Show(messageDialog)
    End Sub
End Module
