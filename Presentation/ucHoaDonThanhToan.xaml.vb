Imports Entities.Entities
Imports Business.Business
Imports System.Collections.ObjectModel
Public Class ucHoaDonThanhToan
    Dim listThuocPaid As ObservableCollection(Of ChiTietHoaDonDTO)
    Dim listThuocUnpaid As ObservableCollection(Of ChiTietHoaDonDTO)
    Dim firstTime As Boolean = True
    Private Sub UserControl_IsVisibleChanged(sender As Object, e As DependencyPropertyChangedEventArgs)
        If Me.IsVisible = True Then
            If firstTime Then
                dpNgayKham.SelectedDate = Date.Now
                firstTime = False
            End If
            If dpNgayKham.SelectedDate IsNot Nothing Then
                cbMaKhamBenh.ItemsSource = KhamBenhBUS.GetKhamBenhByNgayKham(dpNgayKham.SelectedDate)
            End If
        End If
    End Sub

    Private Sub cbMaKhamBenh_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        If cbMaKhamBenh IsNot Nothing And cbMaKhamBenh.SelectedItem IsNot Nothing Then
            Dim maKhamBenh As String = cbMaKhamBenh.SelectedValue.ToString()
            If (HoaDonBUS.IsHoaDonPay(maKhamBenh)) Then
                Dim hoaDon As HoaDonDTO = HoaDonBUS.GetHoaDon(maKhamBenh)
                listThuocPaid = ChiTietHoaDonBUS.GetAllChiTietHoaDon(maKhamBenh)
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
            HoaDonBUS.InsertOrUpdateHoaDon(New HoaDonDTO() With {.MaKhamBenh = maKhamBenh, .TienKham = ThongSoDTO.TienKham})
            For Each cthd As ChiTietHoaDonDTO In listThuocUnpaid
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

    Private Sub dpNgayKham_SelectedDateChanged(sender As Object, e As SelectionChangedEventArgs)
        If dpNgayKham IsNot Nothing Then
            cbMaKhamBenh.ItemsSource = KhamBenhBUS.GetKhamBenhByNgayKham(dpNgayKham.SelectedDate)
        End If
    End Sub
End Class
