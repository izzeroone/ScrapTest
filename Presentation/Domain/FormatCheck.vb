Imports System.Text.RegularExpressions

Namespace Domain
    Public Class FormatCheck
        Public Sub NumberValidationTextBox(ByVal sender As Object, ByVal e As TextCompositionEventArgs)
            Dim regex As Regex = New Regex("[^0-9]+")
            e.Handled = regex.IsMatch(e.Text)
        End Sub
    End Class
End Namespace
