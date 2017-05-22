Imports Entities.Entities
Imports Business.Business
Imports System.Collections.ObjectModel
Public Class ucHoaDonThanhToan
    Dim listThuocPaid As ObservableCollection(Of ChiTietHoaDonDTO)
    Dim listThuocUnpaid As ObservableCollection(Of ChiTietHoaDonDTO)
    Private Sub UserControl_IsVisibleChanged(sender As Object, e As DependencyPropertyChangedEventArgs)
        If (Me.IsVisible = True) Then
            cbMaKhamBenh.DisplayMemberPath = "MaKhamBenh"
            cbMaKhamBenh.SelectedValuePath = "MaKhamBenh"
            cbMaKhamBenh.ItemsSource = KhamBenhBUS.GetAllKhamBenh()
        End If
    End Sub

    Private Sub cbMaKhamBenh_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        If cbMaKhamBenh IsNot Nothing And cbMaKhamBenh.SelectedItem IsNot Nothing Then
            Dim maKhamBenh As String = cbMaKhamBenh.SelectedValue.ToString()
            If (HoaDonBUS.IsHoaDonPay(maKhamBenh)) Then
                Dim hoaDon As HoaDonDTO = HoaDonBUS.GetHoaDon(maKhamBenh)
                listThuocPaid = ChiTietHoaDonBUS.GetAllChiTietHoaDon(hoaDon.MaHoaDon)
                tbTienKham.Text = hoaDon.TienKham
                dgChiTietThuoc.ItemsSource = listThuocPaid
                tbTienThuoc.Text = HoaDonBUS.CalcTienThuoc(listThuocPaid).ToString()
                tbTinhTrang.BorderBrush = Brushes.DarkSeaGreen
                tbTinhTrang.Text = "Đã thanh toán"
            Else
                tbTienKham.Text = ThongSoDTO.TienKham
                listThuocUnpaid = ChiTietPhieuKhamBUS.GetChiTietHoaDon(maKhamBenh)
                dgChiTietThuoc.ItemsSource = listThuocUnpaid
                tbTienThuoc.Text = HoaDonBUS.CalcTienThuoc(listThuocUnpaid).ToString()
                tbTinhTrang.BorderBrush = Brushes.OrangeRed
                tbTinhTrang.Text = "Chưa thanh toán"
            End If
        End If
    End Sub

    Private Sub btThanhToan_Click(sender As Object, e As RoutedEventArgs)
        Dim maKhamBenh As String = cbMaKhamBenh.SelectedValue.ToString()
        If (Not HoaDonBUS.IsHoaDonPay(maKhamBenh)) Then
            HoaDonBUS.InsertOrUpdateHoaDon(New HoaDonDTO() With {.MaKhamBenh = maKhamBenh, .TienKham = ThongSoDTO.TienKham, .MaHoaDon = ""})
            Dim maHoaDon As String = HoaDonBUS.GetHoaDon(maKhamBenh).MaHoaDon
            For Each cthd As ChiTietHoaDonDTO In listThuocUnpaid
                cthd.MaHoaDon = maHoaDon
                ChiTietHoaDonBUS.InsertChiTietHoaDon(cthd)
            Next
        End If
    End Sub

    Private Sub btDelete_Click(sender As Object, e As RoutedEventArgs)
        Dim maKhamBenh As String = cbMaKhamBenh.SelectedValue.ToString()
        If (HoaDonBUS.IsHoaDonPay(maKhamBenh)) Then
            HoaDonBUS.DeleteHoaDon(maKhamBenh)
        End If
    End Sub
End Class
