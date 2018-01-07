Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Data
Imports System.Text.RegularExpressions
Imports Business.Business
Imports Entities.Entities
Imports MaterialDesignThemes.Wpf

Public Class ucPhieuKham
    Dim listChiTietPhieuKham As ObservableCollection(Of ROWChiTietPhieuKhamDTO)
    Dim firstTime As Boolean = True
    ''' <summary>
    ''' Làm cho textbox chỉ nhập đc số
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub NumberValidationTextBox(ByVal sender As Object, ByVal e As TextCompositionEventArgs)
        Dim regex As Regex = New Regex("[^0-9]+")
        e.Handled = regex.IsMatch(e.Text)
    End Sub


    Private Sub NewButton_Click(sender As Object, e As RoutedEventArgs)
        'Kiểm tra danh sách chi tiết phiếu khám có rỗng không
        If Not listChiTietPhieuKham.Count = 0 Then
            'Kiểm tra người dùng đã cập nhật chi tiết phiếu khám mới thêm vào trước đó hay chưa
            If Not listChiTietPhieuKham.Last.MaChiTietPhieuKham = ChiTietPhieuKhamBUS.GetMaChiTietPhieuKham() Then
                'Thêm chi tiết phiếu khám mới rỗng vào danh sách
                Dim ChiTietPhieuKham As New ROWChiTietPhieuKhamDTO() With {.MaChiTietPhieuKham = ChiTietPhieuKhamBUS.GetMaChiTietPhieuKham(),
                                                                       .MaKhamBenh = cbMaKhamBenh.SelectedValue}
                listChiTietPhieuKham.Add(ChiTietPhieuKham)
                dgChiTietPhieuKham.SelectedIndex = dgChiTietPhieuKham.Items.Count - 1
            Else
                Domain.Dialog.Show("Bạn chưa cập nhật bệnh nhân bạn mới thêm vào trước đó")
                Exit Sub
            End If
        Else
            'Thêm chi tiết phiếu khám mới rỗng vào danh sách
            Dim ChiTietPhieuKham As New ROWChiTietPhieuKhamDTO() With {.MaChiTietPhieuKham = ChiTietPhieuKhamBUS.GetMaChiTietPhieuKham(),
                                                                       .MaKhamBenh = cbMaKhamBenh.SelectedValue}
            listChiTietPhieuKham.Add(ChiTietPhieuKham)
            dgChiTietPhieuKham.SelectedIndex = dgChiTietPhieuKham.Items.Count - 1
        End If
    End Sub

    Private Sub UpdateButton_Click(sender As Object, e As RoutedEventArgs)
        'Kiểm tra người dùng đã chọn chi tiết phiếu khám trong danh sách hay chưa
        If dgChiTietPhieuKham.SelectedIndex = -1 Then
            Domain.Dialog.Show("Chưa có đối tượng được chọn")
            Exit Sub
        End If
        'Lấy thông tin từ người dùng và kiểm tra
        Dim chiTietPhieuKham As New ChiTietPhieuKhamDTO
        chiTietPhieuKham.MaChiTietPhieuKham = tbMaChiTietPhieuKham.Text
        chiTietPhieuKham.MaKhamBenh = cbMaKhamBenh.Text
        chiTietPhieuKham.TrieuChung = tbTrieuChung.Text
        chiTietPhieuKham.LoiDan = tbLoiDan.Text
        chiTietPhieuKham.MaLoaiBenh = cbLoaiBenh.SelectedValue
        chiTietPhieuKham.MaThuoc = cbThuoc.SelectedValue
        chiTietPhieuKham.MaDonVi = cbDonVi.SelectedValue
        If Not ChiTietPhieuKhamBUS.IsVaildSoLuong(tbSoLuong.Text, chiTietPhieuKham.SoLuong) Then
            Domain.Dialog.Show("Số lượng không hợp lệ")
            Exit Sub
        End If
        chiTietPhieuKham.MaCachDung = cbCachDung.SelectedValue
        If Not ChiTietPhieuKhamBUS.IsVaildChiTietPhieuKham(chiTietPhieuKham) Then
            Domain.Dialog.Show("Thông tin không hợp lệ")
            Exit Sub
        End If
        'Tiến hành cập nhật
        Dim result As Boolean = ChiTietPhieuKhamBUS.InsertOrUpdateChiTietPhieuKham(chiTietPhieuKham)
        If (result = True) Then
            Domain.Dialog.Show("Cập nhật thành công")
        Else
            Domain.Dialog.Show("Cập nhật thất bại")
        End If
        ReloadData()
    End Sub

    Private Async Sub DeleteButton_Click(sender As Object, e As RoutedEventArgs)
        'Kiểm tra người dùng có muốn xóa hay không
        Dim dialog As New Domain.YesNoDialog
        dialog.Message.Text = "Bạn chắc chắn xóa " + dgChiTietPhieuKham.SelectedItems.Count.ToString() + " thuốc được chọn"
        Await DialogHost.Show(dialog)
        If (dialog.DialogResult = MessageBoxResult.No) Then
            Exit Sub
        End If
        'Tiến hành xóa
        Dim result As Boolean
        For Each ChiTietPhieuKham As ChiTietPhieuKhamDTO In dgChiTietPhieuKham.SelectedItems
            result = DeleteChiTietPhieuKhamByMa(ChiTietPhieuKham.MaChiTietPhieuKham)
        Next
        If (result = True) Then
            Domain.Dialog.Show("Xóa thành công")
        Else
            Domain.Dialog.Show("Xóa thất bại")
        End If
        ReloadData()
    End Sub

    Private Sub CancelButton_Click(sender As Object, e As RoutedEventArgs)
        dgChiTietPhieuKham.SelectedIndex = -1
    End Sub

    Private Sub ExportButton_Click(sender As Object, e As RoutedEventArgs)
        'Kiểm tra danh sách chi tiết phiếu khám có rỗng không
        If Not listChiTietPhieuKham.Count = 0 Then
            'Kiểm tra người dùng đã cập nhật chi tiết phiếu khám mới thêm vào trước đó hay chưa
            If Not listChiTietPhieuKham.Last.MaChiTietPhieuKham = ChiTietPhieuKhamBUS.GetMaChiTietPhieuKham() Then
                'Thêm chi tiết phiếu khám mới rỗng vào danh sách
                PhieuKhamBUS.ExportInvoice(cbMaKhamBenh.SelectedValue)
            Else
                Domain.Dialog.Show("Bạn chưa cập nhật bệnh nhân bạn mới thêm vào trước đó")
                Exit Sub
            End If
        Else
            'Thêm chi tiết phiếu khám mới rỗng vào danh sách
            PhieuKhamBUS.ExportInvoice(cbMaKhamBenh.SelectedValue)
        End If
    End Sub
    ''' <summary>
    ''' Tải lại dữ liệu khi người dùng chọn bệnh nhân khác
    ''' </summary>
    Private Sub ReloadData()
        If dgChiTietPhieuKham IsNot Nothing And cbMaKhamBenh.SelectedValue IsNot Nothing Then
            listChiTietPhieuKham = ROWChiTietPhieuKhamBUS.GetChiTietPhieuKhamByMaKhamBenh(cbMaKhamBenh.SelectedValue.ToString())
            dgChiTietPhieuKham.DataContext = listChiTietPhieuKham
        End If
    End Sub
    ''' <summary>
    ''' Khởi tạo nguồn dữ liệu cho combobox khi người dùng vào màn hình
    ''' </summary>
    Private Sub LoadComboBoxData()
        If Me.IsVisible = True Then
            If firstTime Then
                dpNgayKhamBenh.SelectedDate = Date.Now
                firstTime = False
            End If
            cbLoaiBenh.ItemsSource = LoaiBenhBUS.GetAllLoaiBenh()
            If cbMaKhamBenh.SelectedItem IsNot Nothing Then
                cbLoaiBenh.SelectedValue = CType(cbMaKhamBenh.SelectedItem, KhamBenhDTO).MaLoaiBenh
            End If
            cbDonVi.ItemsSource = LoaiDonViBUS.GetAllLoaiDonVi()
            cbCachDung.ItemsSource = LoaiCachDungBUS.GetAllLoaiCachDung()
            cbThuoc.ItemsSource = LoaiThuocBUS.GetAllLoaiThuoc()
            ReloadData()
        End If
    End Sub

    Private Sub cbMaKhamBenh_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        'Cập nhật lại danh sách chi tiết phiếu khám khi người dùng chọn bệnh nhân khác
        If cbMaKhamBenh IsNot Nothing Then
            ReloadData()
        End If
    End Sub

    Private Sub dpNgayKhamBenh_SelectedDateChanged(sender As Object, e As SelectionChangedEventArgs)
        'Cập nhật lại danh sách bệnh nhân khi ngày người dùng chọn thay đổi
        If dpNgayKhamBenh IsNot Nothing And dpNgayKhamBenh.SelectedDate IsNot Nothing Then
            cbMaKhamBenh.ItemsSource = KhamBenhBUS.GetKhamBenhByNgayKham(dpNgayKhamBenh.SelectedDate)
        End If
    End Sub

    Private Sub cbMaKhamBenh_MouseDown(sender As Object, e As MouseButtonEventArgs)
        If dpNgayKhamBenh.SelectedDate Is Nothing Then
            Domain.Dialog.Show("Ngày khám chưa được chọn")
        End If
    End Sub
    ''' <summary>
    ''' Kiếm tra xem ngày hợp lệ hay không
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DatePickerDateValidationError(sender As Object, e As DatePickerDateValidationErrorEventArgs)
        Dim dp As DatePicker = sender
        e.ThrowException = False
        Domain.Dialog.Show("Ngày không hợp lệ")
        dp.SelectedDate = Date.Now()
    End Sub
End Class
