Imports Entities.Entities
Imports Business.Business
Imports System.Collections.ObjectModel
Public Class ucHoaDonThanhToan
    Private Sub UserControl_IsVisibleChanged(sender As Object, e As DependencyPropertyChangedEventArgs)
        If (Me.IsVisible = True) Then
            cbMaKhamBenh.DisplayMemberPath = "MaKhamBenh"
            cbMaKhamBenh.SelectedValuePath = "MaKhamBenh"
            cbMaKhamBenh.ItemsSource = KhamBenhBUS.GetAllKhamBenh()
        End If
    End Sub

    Private Sub cbMaKhamBenh_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        If cbMaKhamBenh IsNot Nothing And cbMaKhamBenh.SelectedItem IsNot Nothing Then

        End If
    End Sub

    Private Sub btThanhToan_Click(sender As Object, e As RoutedEventArgs)

    End Sub
End Class
