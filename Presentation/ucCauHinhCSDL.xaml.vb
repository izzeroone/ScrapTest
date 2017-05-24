Imports Business.Business
Imports Entities.Entities
Imports System.Collections.ObjectModel
Public Class ucCauHinhCSDL
    Private Sub UserControl_IsVisibleChanged(sender As Object, e As DependencyPropertyChangedEventArgs)
        If Me.IsVisible = True Then
            cbProfile.ItemsSource = CauHinhCSDLBUS.GetAllCauHinhCSDL()
        End If
    End Sub

    Private Sub Accept_Click(sender As Object, e As RoutedEventArgs)
        If cbProfile.SelectedIndex <> -1 Then
            If CauHinhCSDLBUS.SetActive(cbProfile.SelectedIndex) = False Then
                Domain.Dialog.Show("Không thể kết nối tới Cơ sở dữ liệu")
            End If
        End If
    End Sub

End Class
