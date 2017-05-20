Imports Entities.Entities
Imports Business.Business
Imports System.Collections.ObjectModel
Public Class ucBaoCaoDoanhThu
    Dim list As ObservableCollection(Of BaoCaoDoanhThuDTO)
    Private Sub tbNgayKham_SelectedDateChanged(sender As Object, e As SelectionChangedEventArgs)
        Dim tong As Long
        list = BaoCaoDoanhThuBUS.GetBaoCaoDoanhThu(tbNgayKham.SelectedDate, tong)
        If (dgChiTietDoanhThu IsNot Nothing) Then
            dgChiTietDoanhThu.ItemsSource = list
        End If
    End Sub
End Class
