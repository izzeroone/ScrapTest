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
            Dim khamBenh As KhamBenhDTO = cbMaKhamBenh.SelectedItem
            If (khamBenh.TienKham <> 0 And khamBenh.TienThuoc <> 0) Then
                tbTienKham.Text = khamBenh.TienKham.ToString()
                tbTienThuoc.Text = khamBenh.TienThuoc.ToString()
                tbTinhTrang.Text = "Đã thanh toán"
                tbTinhTrang.Foreground = Brushes.LightSeaGreen
                btThanhToan.IsEnabled = False
            Else
                tbTienKham.Text = ThongSoDTO.TienKham.ToString()
                Dim list As ObservableCollection(Of ChiTietThuocDTO) = ChiTietThuocBUS.GetChiTietThuoc(khamBenh.MaKhamBenh)
                dgChiTietThuoc.ItemsSource = list
                Dim tongGiaThuoc As Integer = 0
                For Each item As ChiTietThuocDTO In list
                    tongGiaThuoc += item.ThanhTien
                Next
                tbTienThuoc.Text = tongGiaThuoc.ToString()
                tbTinhTrang.Text = "Chưa thanh toán"
                tbTinhTrang.Foreground = Brushes.DarkRed
                btThanhToan.IsEnabled = True
            End If
        End If
    End Sub

    Private Sub btThanhToan_Click(sender As Object, e As RoutedEventArgs)

    End Sub
End Class
