Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Data
Imports System.Text.RegularExpressions
Imports Business.Business
Imports Entities.Entities
Imports MaterialDesignThemes.Wpf

Public Class ucChuanDoan
    Dim listChuanDoan As ObservableCollection(Of ChuanDoanDTO)
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
        'Thêm chi tiết phiếu khám mới rỗng vào danh sách
        Dim ChuanDoan As New ChuanDoanDTO() With {.MaKhamBenh = cbMaKhamBenh.SelectedValue}
        listChuanDoan.Add(ChuanDoan)
        dgDichVu.SelectedIndex = dgDichVu.Items.Count - 1
    End Sub

    Private Sub UpdateButton_Click(sender As Object, e As RoutedEventArgs)
        'Kiểm tra người dùng đã chọn chi tiết phiếu khám trong danh sách hay chưa
        If dgDichVu.SelectedIndex = -1 Then
            Domain.Dialog.Show("Chưa có đối tượng được chọn")
            Exit Sub
        End If
        'Lấy thông tin từ người dùng và kiểm tra
        Dim chuanDoan As New ChuanDoanDTO
        chuanDoan.MaKhamBenh = cbMaKhamBenh.SelectedValue
        chuanDoan.MaDichVu = cbDichVu.SelectedValue
        chuanDoan.DonGia = tbDonGia.Text
        If Not ChuanDoanBUS.IsVaildSoLuong(tbSoLuong.Text, chuanDoan.SoLuong) Then
            Domain.Dialog.Show("Số lượng không hợp lệ")
            Exit Sub
        End If
        chuanDoan.SoLuong = tbSoLuong.Text


        'Tiến hành cập nhật
        Dim result As Boolean = ChuanDoanBUS.InsertOrUpdateChuanDoan(chuanDoan)
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
        dialog.Message.Text = "Bạn chắc chắn xóa " + dgDichVu.SelectedItems.Count.ToString() + " dịch vụ chọn"
        Await DialogHost.Show(dialog)
        If (dialog.DialogResult = MessageBoxResult.No) Then
            Exit Sub
        End If
        'Tiến hành xóa
        Dim result As Boolean
        For Each ChuanDoan As ChuanDoanDTO In dgDichVu.SelectedItems
            result = ChuanDoanBUS.DeleteChuanDoanByMa(ChuanDoan.MaKhamBenh, ChuanDoan.MaDichVu)
        Next
        If (result = True) Then
            Domain.Dialog.Show("Xóa thành công")
        Else
            Domain.Dialog.Show("Xóa thất bại")
        End If
        ReloadData()
    End Sub

    Private Sub CancelButton_Click(sender As Object, e As RoutedEventArgs)
        dgDichVu.SelectedIndex = -1
    End Sub


    ''' <summary>
    ''' Tải lại dữ liệu khi người dùng chọn bệnh nhân khác
    ''' </summary>
    Private Sub ReloadData()
        If dgDichVu IsNot Nothing And cbMaKhamBenh.SelectedValue IsNot Nothing Then
            listChuanDoan = ChuanDoanBUS.GetChuanDoan(cbMaKhamBenh.SelectedValue)
            dgDichVu.DataContext = listChuanDoan
        End If
    End Sub
    ''' <summary>
    ''' Khởi tạo nguồn dữ liệu cho combobox khi người dùng vào màn hình
    ''' </summary>
    Private Sub LoadComboBoxData()
        If Me.IsVisible = True Then
            cbDichVu.ItemsSource = LoaiDichVuBUS.GetAllLoaiDichVu()
            cbLoaiBenh.ItemsSource = LoaiBenhBUS.GetAllLoaiBenh()
            If cbMaKhamBenh.SelectedItem IsNot Nothing Then
                cbLoaiBenh.SelectedValue = CType(cbMaKhamBenh.SelectedItem, KhamBenhDTO).MaLoaiBenh
            End If
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

    Private Sub UpdateBenhButton_Click(sender As Object, e As RoutedEventArgs)
        If dpNgayKhamBenh IsNot Nothing And cbMaKhamBenh.SelectedItem IsNot Nothing And cbLoaiBenh.SelectedItem IsNot Nothing Then
            Dim khamBenh As New KhamBenhDTO
            khamBenh.MaKhamBenh = cbMaKhamBenh.SelectedValue
            khamBenh.TrieuChung = tbTrieuChung.Text
            khamBenh.MaLoaiBenh = cbLoaiBenh.SelectedValue
            khamBenh.LoiDan = tbLoiDan.Text
            Dim result As Boolean = KhamBenhBUS.updateChuanDoanKhamBenh(khamBenh)
            If (result = True) Then
                Domain.Dialog.Show("Cập nhật thành công")
            Else
                Domain.Dialog.Show("Cập nhật thất bại")
            End If
        Else
            Domain.Dialog.Show("Cập nhật thất bại")
        End If
    End Sub
End Class
