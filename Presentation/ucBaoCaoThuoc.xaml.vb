Imports Entities.Entities
Imports Business.Business
Imports System.Collections.ObjectModel
Public Class ucBaoCaoThuoc
    Dim list As ObservableCollection(Of BaoCaoThuocDTO)
    Private Sub tbNgayKham_SelectedDateChanged(sender As Object, e As SelectionChangedEventArgs)
        list = BaoCaoThuocBUS.GetBaoCaoThuoc(tbNgayKham.SelectedDate)
        If dgChiTietThuoc IsNot Nothing Then
            dgChiTietThuoc.ItemsSource = list
        End If
    End Sub
End Class
