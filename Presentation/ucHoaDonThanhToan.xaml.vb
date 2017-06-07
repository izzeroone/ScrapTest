Imports Entities.Entities
Imports Business.Business
Imports System.Collections.ObjectModel
Imports MaterialDesignThemes.Wpf

Public Class ucHoaDonThanhToan
    'Danh sách các loại thuốc 
    Dim listThuocPaid As ObservableCollection(Of ChiTietHoaDonDTO)
    Dim listThuocUnpaid As ObservableCollection(Of ChiTietHoaDonDTO)

    Dim firstTime As Boolean = True 'Có phải lần đầu tiền vào màn hình hay không
    Private Sub UserControl_IsVisibleChanged(sender As Object, e As DependencyPropertyChangedEventArgs)
        If Me.IsVisible = True Then
            'Nếu là lần đầu tiên vào màn hình thì chọn ngày bằng ngày hệ thống
            If firstTime Then
                dpNgayKham.SelectedDate = Date.Now
                firstTime = False
            End If
            'Lấy danh sách bệnh nhân dựa trên ngày người dùng chọn
            If dpNgayKham.SelectedDate IsNot Nothing Then
                cbMaKhamBenh.ItemsSource = KhamBenhBUS.GetKhamBenhByNgayKham(dpNgayKham.SelectedDate)
            End If
        End If
    End Sub

    Private Sub cbMaKhamBenh_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        'Kiểm tra người dùng đã chọn mã khám bệnh chưa
        If cbMaKhamBenh IsNot Nothing And cbMaKhamBenh.SelectedItem IsNot Nothing Then
            Dim maKhamBenh As String = cbMaKhamBenh.SelectedValue.ToString()
            'Kiểm tra bệnh nhân đã thanh toán chưa
            If (HoaDonBUS.IsHoaDonPay(maKhamBenh)) Then
                'Nếu đã thanh toán thì lấy hóa đơn cũng như chi tiết các thuốc đã sử dụng và thành tiền
                Dim hoaDon As HoaDonDTO = HoaDonBUS.GetHoaDon(maKhamBenh)
                listThuocPaid = ChiTietHoaDonBUS.GetAllChiTietHoaDon(maKhamBenh)
                tbTienKham.Text = hoaDon.TienKham.ToString()
                dgChiTietThuoc.ItemsSource = listThuocPaid
                'Hiển thị tiền thuốc, tiền khám và tổng tiền
                Dim tienThuoc As Integer = HoaDonBUS.CalcTienThuoc(listThuocPaid).ToString()
                tbTienThuoc.Text = tienThuoc.ToString()
                tbTongTien.Text = "Tổng tiền = " + (hoaDon.TienKham + tienThuoc).ToString()
                'Hiển thị tình trạng thanh toán
                tbTinhTrang.BorderBrush = Brushes.DarkSeaGreen
                tbTinhTrang.Text = "Đã thanh toán"
                'Cho phép xóa và không cho phép thanh toán
                btCheckout.IsEnabled = False
                btDelete.IsEnabled = True
            Else
                'Nếu hưa thanh toán thì lấy thuốc sử dụng từ chi tiết phiếu khám
                listThuocUnpaid = ChiTietPhieuKhamBUS.GetChiTietHoaDon(maKhamBenh)
                dgChiTietThuoc.ItemsSource = listThuocUnpaid
                'Hiển thị tiền thuốc và tiền khám
                tbTienKham.Text = ThongSoDTO.TienKham
                Dim tienThuoc As Integer = HoaDonBUS.CalcTienThuoc(listThuocUnpaid).ToString()
                tbTienThuoc.Text = tienThuoc.ToString()
                tbTongTien.Text = "Tổng tiền = " + (ThongSoDTO.TienKham + tienThuoc).ToString()
                'Hiển thị tình trạng thanh toán
                tbTinhTrang.BorderBrush = Brushes.OrangeRed
                tbTinhTrang.Text = "Chưa thanh toán"
                'Cho phép thanh toán và không cho phép thanh toán
                btCheckout.IsEnabled = True
                btDelete.IsEnabled = False
            End If
        End If
    End Sub

    Private Async Sub btCheckout_Click(sender As Object, e As RoutedEventArgs)
        'Kiểm tra người dùng có muốn thanh toán hay không
        Dim dialog As New Domain.YesNoDialog
        dialog.Message.Text = "Bạn có muốn lập hóa đơn thanh toán bệnh nhân " + tbHoTen.Text
        Await DialogHost.Show(dialog)
        If (dialog.DialogResult = MessageBoxResult.No) Then
            Exit Sub
        End If
        'Tiến hành thanh toán hóa đơn và cập nhật hiển thị
        Dim maKhamBenh As String = cbMaKhamBenh.SelectedValue.ToString()
        If (Not HoaDonBUS.IsHoaDonPay(maKhamBenh)) Then
            HoaDonBUS.InsertOrUpdateHoaDon(New HoaDonDTO() With {.MaKhamBenh = maKhamBenh, .TienKham = ThongSoDTO.TienKham})
            For Each cthd As ChiTietHoaDonDTO In listThuocUnpaid
                ChiTietHoaDonBUS.InsertChiTietHoaDon(cthd)
            Next
        End If
        Dim tempIndex = cbMaKhamBenh.SelectedIndex
        cbMaKhamBenh.SelectedIndex = -1
        cbMaKhamBenh.SelectedIndex = tempIndex
    End Sub

    Private Async Sub btDelete_Click(sender As Object, e As RoutedEventArgs)
        'Kiểm tra người dùng có muốn xóa hay không 
        Dim dialog As New Domain.YesNoDialog
        dialog.Message.Text = "Bạn có muốn xóa hóa đơn thanh toán bệnh nhân " + tbHoTen.Text
        Await DialogHost.Show(dialog)
        If (dialog.DialogResult = MessageBoxResult.No) Then
            Exit Sub
        End If
        'Xóa hóa đơn và cập nhật hiển thị
        Dim maKhamBenh As String = cbMaKhamBenh.SelectedValue.ToString()
        If (HoaDonBUS.IsHoaDonPay(maKhamBenh)) Then
            HoaDonBUS.DeleteHoaDon(maKhamBenh)
        End If
        Dim tempIndex = cbMaKhamBenh.SelectedIndex
        cbMaKhamBenh.SelectedIndex = -1
        cbMaKhamBenh.SelectedIndex = tempIndex
    End Sub

    Private Sub dpNgayKham_SelectedDateChanged(sender As Object, e As SelectionChangedEventArgs)
        'Thay đổi danh sách bệnh nhân khi ngày khám thay đổi
        If dpNgayKham IsNot Nothing And dpNgayKham.SelectedDate IsNot Nothing Then
            cbMaKhamBenh.ItemsSource = KhamBenhBUS.GetKhamBenhByNgayKham(dpNgayKham.SelectedDate)
        End If
    End Sub
End Class
